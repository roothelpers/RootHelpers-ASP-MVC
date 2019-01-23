using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RootHelpers.Attribute
{
     public class EditorTabAttribute : System.Attribute
    {
        public string Name { get; set; }

        public object Id { get; set; }

        public bool Selected { get; set; }

        public bool Editable { get; set; }

        /// <summary>
        /// Empty ctor
        /// </summary>
        public EditorTabAttribute()
        {
        }
    }

    public class EditorGroupAttribute : System.Attribute
    {
        public object Id { get; set; }

        /// <summary>
        /// Empty ctor
        /// </summary>
        public EditorGroupAttribute()
        {

        }
    }
}
