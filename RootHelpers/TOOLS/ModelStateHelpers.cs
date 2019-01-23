using RootHelpers.LIST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RootHelpers.TOOLS
{
    /// <summary>
    /// MVC ModelState helpers 
    /// </summary>
    public static class ModelStateHelpers
    {
        /// <summary>
        /// Returns a dictionary will all model state errors
        /// </summary>
        public static Dictionary<string, string> GetErrors(this ModelStateDictionary modelState, string replaceWith = ".")
        {
            var errorDictionary = new Dictionary<string, string>();
            var collection = modelState.Keys.Where(r => modelState[r].Errors.Any());
            foreach (var item in collection)
            {
                errorDictionary.Add(item.Replace(".", replaceWith), modelState[item].Errors.FirstOrDefault().ErrorMessage);
            }
            return errorDictionary;
        }

        /// <summary>
        /// Removes model state errors except for the specified filed
        /// </summary>
        public static void ClearModelState(this ModelStateDictionary modelState, string propName)
        {
            foreach (var key in modelState.Keys.ToList().Where(key => key.IndexOf(propName, System.StringComparison.Ordinal) == -1))
            {
                modelState.Remove(key);
            }
        }

        /// <summary>
        /// Substitute for ValidationSummary
        /// </summary>
        public static void AddFormError(this ModelStateDictionary modelState, string prefix, string errorMessage)
        {
            var key = string.IsNullOrEmpty(prefix) ? "BsFormError" : prefix + ".BsFormError";
            modelState.AddModelError(key, errorMessage);
        }

        /// <summary>
        /// Substitute for AddModelError
        /// </summary>
        public static void AddFieldError(this ModelStateDictionary modelState, string prefix, System.Type filedType, string errorMessage)
        {
            var key = prefix;
            if (filedType.InheritsOrImplements(typeof(SelectList<>)))
            {
                key += ".SelectedValues";
            }
            if (filedType.InheritsOrImplements(typeof(Range<>)) || filedType == typeof(LIST.DateTime))
            {
                key += ".TextValue";
            }

            modelState.AddModelError(key, errorMessage);
        }

        /// <summary>
        /// Removes model state errors except for the specified fileds
        /// </summary>
        public static void ClearModelState(this ModelStateDictionary ms, List<string> props)
        {
            foreach (var key in ms.Keys.ToList())
            {
                if (props.All(propName => key.IndexOf(propName, StringComparison.Ordinal) == -1))
                {
                    ms.Remove(key);
                }
            }
        }


    }
}
