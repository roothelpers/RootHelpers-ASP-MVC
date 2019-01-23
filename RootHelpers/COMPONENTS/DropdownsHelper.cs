using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace RootHelpers
{
    /// <summary>
    ///
    /// </summary>
    public static class DropdownsHelper
    {
        #region basically

        /// <summary>
        /// Dropdowns the specified titlebutton.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="html">The HTML.</param>
        /// <param name="titlebutton">The titlebutton.</param>
        /// <param name="dropdowns">The dropdowns.</param>
        /// <param name="Type">The type.</param>
        /// <param name="Sizes">The sizes.</param>
        /// <returns></returns>
        public static MvcHtmlString Dropdown<TModel>(this HtmlHelper<TModel> html, String titlebutton, List<dropdowns> dropdowns, Type Type = Type.Primary, Sizes Sizes = Sizes.None)
        {
            int i = 0;
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            string type = GetBtnType(Type);
            string sizes = GetBtnSizes(Sizes);
            retour.AppendLine("<div class='dropdown'>");
            retour.AppendLine(String.Format("<button class='btn " + sizes + " " + type + " dropdown-toggle' type='button' id='dropdownMenuButton' data-toggle='dropdown' aria-haspopup='true' aria-expanded='false'>{0}</button>", titlebutton));
            retour.AppendLine("<div class='dropdown-menu' aria-labelledby='dropdownMenuButton'>");
            dropdowns = dropdowns.OrderBy(it => it.Pos).ToList();
            foreach (dropdowns item in dropdowns)
            {
                if (item.divider)
                {
                    retour.AppendLine("<div class='dropdown-divider'></div>");
                }
                else
                {
                    retour.AppendLine(String.Format("<a class='dropdown-item " + GENERAL.Tools.GetPostitionText() + "' href='{1}'>{0}</a>", item.dropdownsItem, item.dropdownshref));
                }
            }
            retour.AppendLine("</div>");
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        #endregion basically

        #region private method

        /// <summary>
        /// Gets the type of the BTN.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        private static string GetBtnType(Type type)
        {
            switch (type)
            {
                case Type.Primary: return "btn-primary";
                case Type.Secondary: return "btn-secondary";
                case Type.Success: return "btn-success";
                case Type.Danger: return "btn-danger";
                case Type.Warning: return "btn-warning";
                case Type.Info: return "btn-info";
                case Type.Light: return "btn-light";
                case Type.Dark: return "btn-dark";
                default: return String.Empty;
            }
        }

        /// <summary>
        /// Gets the BTN sizes.
        /// </summary>
        /// <param name="Sizes">The sizes.</param>
        /// <returns></returns>
        private static string GetBtnSizes(Sizes Sizes)
        {
            switch (Sizes)
            {
                case Sizes.Larger: return "btn-lg";
                case Sizes.Small: return "btn-sm";
                case Sizes.Block: return "btn-lg btn-blocks";
                default: return String.Empty;
            }
        }

        #endregion private method
    }
}