using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RootHelpers.Attribute
{
    /// <summary>
    /// Forms control 
    /// </summary>
    public class ControlAttribute : System.Attribute
    {
        /// <summary>
        /// Specifies the name of an  control type to associate with an input HTML field
        /// </summary>
        public ControlType ControlType { get; set; }
 
        /// <summary>
        /// Empty ctor
        /// </summary>
        public ControlAttribute()
        {
        }
    
        public ControlAttribute(ControlType controlType)
        {
            ControlType = controlType;
        }
    }
}
