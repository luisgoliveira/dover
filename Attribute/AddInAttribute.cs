﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddOne.Framework.Attribute
{
    
    [System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = false)]
    public class AddInAttribute : System.Attribute
    {
        public string Description { get; set; }
        public bool i18n = false;
    }
}