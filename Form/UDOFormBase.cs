﻿/*
 *  Dover Framework - OpenSource Development framework for SAP Business One
 *  Copyright (C) 2014  Eduardo Piva
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>.
 *  
 *  Contact me at <efpiva@gmail.com>
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dover.Framework.DAO;
using SAPbouiCOM;
using SAPbouiCOM.Framework;
using Dover.Framework.Monad;
using Dover.Framework.Service;
using Dover.Framework.Factory;
using System.Xml.Linq;

namespace Dover.Framework.Form
{
    /// <summary>
    /// Base class for UDO Forms.
    /// 
    /// It will read the formType from FormAttribute and it will intercept this
    /// FormType creation bind all events to it. If form resource is not empty
    /// it means it was i18n form. For this to work properly, it must have an empty form
    /// created on the database and all forms elements are created by Dover at runtime.
    /// 
    /// It will read the resource name in FormAttribute and locate a form with
    /// the specified name in the B1S embedded resource. If not found, it will look for
    /// a srf XML file in the current solution and threat the specified resource name
    /// as the Fully Qualified Name of the embedded resource file.
    /// </summary>
    public class DoverUDOFormBase : DoverFormBase
    {
        private bool initialized = false;
        private string formUID;
        public BusinessOneUIDAO b1UIDAO { get; set; }
        public B1SResourceManager resourceManager { get; set; }

        public DoverUDOFormBase()
        {
        }

        internal override string FormUID
        {
            set
            {
                this.formUID = value;
                this.UIAPIRawForm = b1UIDAO.GetFormByUID(formUID);
            }
        }

        protected internal override void OnFormActivateAfter(SBOItemEventArg pVal)
        {
            Initialize();
        }
        
        internal void Initialize()
        {
            if (!initialized)
            {
                try
                {
                    initialized = true;
                    this.UIAPIRawForm.Freeze(true);

                    FormAttribute formAttribute = (FormAttribute)(from attribute in this.GetType().GetCustomAttributes(true)
                                                                  where attribute is FormAttribute
                                                                  select attribute).First();
                    var asmName = this.GetType().BaseType.Assembly.GetName().FullName;

                    XDocument doc = resourceManager.GetSystemFormXDoc(asmName, formAttribute.Resource, formUID);
                    if (doc != null) // i18n stuff.
                    {
                        string xml = ChangeMethodForUpdate(doc);
                        string title = GetFormTitle(doc);

                        if (!string.IsNullOrEmpty(xml))
                        {
                            b1UIDAO.LoadBatchAction(xml);
                            this.UIAPIRawForm.Title = title;
                        }
                    }
                    this.OnInitializeComponent(); // UI elements displayed only after form creation.
                }
                finally // prevent loop on exceptions.
                {
                    initialized = true;
                    this.UIAPIRawForm.Freeze(false);
                }
            }
        }

        private string GetFormTitle(XDocument doc)
        {
            string ret = null;
            var formattedElement = (from app in doc.Elements("Application")
                                    from forms in app.Elements("forms")
                                    from action in forms.Elements("action")
                                    from form in action.Elements("form")
                                    select form);
            if (formattedElement != null && formattedElement.Count() > 0)
            {
                ret = formattedElement.First().With(x => x.Attribute("title")).With(x => x.Value);
            }
            return (ret == null) ? string.Empty : ret;
        }

        private string ChangeMethodForUpdate(XDocument doc)
        {
            var formattedElement = (from app in doc.Elements("Application")
                                    from forms in app.Elements("forms")
                                    from action in forms.Elements("action")
                                    select action);
            if (formattedElement != null && formattedElement.Count() > 0)
            {
                formattedElement.First().SetAttributeValue("type", "update");
            }

            formattedElement = (from app in doc.Elements("Application")
                                    from forms in app.Elements("forms")
                                    from action in forms.Elements("action")
                                    from form in action.Elements("form")
                                    from datasource in form.Elements("datasources")
                                    from dbdatasource in datasource.Elements("dbdatasources")
                                select dbdatasource);
            if (formattedElement != null && formattedElement.Count() > 0)
            {
                formattedElement.First().RemoveAll();
            }

            var itemsCommands = (from app in doc.Elements("Application")
                                 from forms in app.Elements("forms")
                                 from action in forms.Elements("action")
                                 from form in action.Elements("form")
                                 from items in form.Elements("items")
                                 select items);

            // Update default UID and default button from empty form.
            formattedElement = (from actionForm in itemsCommands.Elements("action")
                                from formItem in actionForm.Elements("item")
                                    where actionForm.Attribute("type").Value == "add"
                                        && (formItem.Attribute("uid").Value == "0_U_E"
                                        || formItem.Attribute("uid").Value == "1")
                                select formItem);

            List<XElement> updateItens = new List<XElement>();
            if (formattedElement != null && formattedElement.Count() > 0)
            {
                foreach (var elem in formattedElement)
                {
                    updateItens.Add(elem);
                }
                foreach (var elem in updateItens)
                {
                    elem.Remove();
                }
            }

            XElement updateItensXElement;
            formattedElement = (from actionForm in itemsCommands.Elements("action")
                                where actionForm.Attribute("type").Value == "update"
                                select actionForm);

            if (formattedElement != null && formattedElement.Count() > 0)
            {
                updateItensXElement = formattedElement.First();
            }
            else
            {
                XElement updateAction = new XElement("action");
                updateAction.SetAttributeValue("type", "update");
                itemsCommands.First().Add(updateAction);
                updateItensXElement = updateAction;
            }

            foreach (var elem in updateItens)
            {
                updateItensXElement.Add(elem);
            }

            return doc.ToString();
        }

    }
}
