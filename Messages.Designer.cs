﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AddOne.Framework {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Messages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Messages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("AddOne.Framework.Messages", typeof(Messages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Erro no addin {0} versão {1}.
        /// </summary>
        internal static string AddInError {
            get {
                return ResourceManager.GetString("AddInError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Erro inesperado no AddOne: {0}\n {1}.
        /// </summary>
        internal static string AddInException {
            get {
                return ResourceManager.GetString("AddInException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Todos os argumentos são obrigatórios..
        /// </summary>
        internal static string AllArgumentsMandatory {
            get {
                return ResourceManager.GetString("AllArgumentsMandatory", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Criada AppFolder {0} - iniciando addins e core.
        /// </summary>
        internal static string CreatedAppFolder {
            get {
                return ResourceManager.GetString("CreatedAppFolder", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Erro iniciando addins.
        /// </summary>
        internal static string ErrorStartup {
            get {
                return ResourceManager.GetString("ErrorStartup", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Informe o nome do Arquivo.
        /// </summary>
        internal static string FileDialogTitle {
            get {
                return ResourceManager.GetString("FileDialogTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Informe a pasta.
        /// </summary>
        internal static string FolderDialogTitle {
            get {
                return ResourceManager.GetString("FolderDialogTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Erro preparando Framework - {0}.
        /// </summary>
        internal static string GeneralError {
            get {
                return ResourceManager.GetString("GeneralError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Preparando Framework para inicialização.
        /// </summary>
        internal static string PreparingFramework {
            get {
                return ResourceManager.GetString("PreparingFramework", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Iniciando Framework({0}).
        /// </summary>
        internal static string Starting {
            get {
                return ResourceManager.GetString("Starting", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Iniciando assemblies na pasta {0}.
        /// </summary>
        internal static string StartupFolder {
            get {
                return ResourceManager.GetString("StartupFolder", resourceCulture);
            }
        }
    }
}
