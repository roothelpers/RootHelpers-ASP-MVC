using System;
using System.Text;
using System.Web.Mvc;

namespace RootHelpers
{
    /// <summary>
    ///         The Popover plugin is similar to tooltips; it is a pop-up box that appears when the user clicks on an element. The difference is that the popover can contain much more content.
    /// </summary>
    public static class PopoversHelper
    {
        #region basically

        /// <summary>
        /// Popovers the specified popovertitle.
        /// </summary>
        /// <param name="Popovertitle">to specify the header text of the popover</param>
        /// <param name="Popovercontent">to specify the text that should be displayed inside the popover's body</param>
        /// <param name="Popovermsg">to specify the text that should be displayed inside the button</param>
        /// <param name="Popovers">to set the position of the tooltip on top, bottom, left or the right side of the element.</param>
        /// <param name="Type"> to specify the style that shloud be displayed : Primary, Secondary, Success, Danger, Warning, Info, Light, Dark</param>
        /// <param name="Sizes"> to specify The sizes.</param>
        /// <returns></returns>
        /// <remarks>
        /// Create a Popover with Html.Popover()
        /// Use: @Html.Popover()
        /// </remarks>
        ///
        public static MvcHtmlString Popover<TModel>(this HtmlHelper<TModel> html, String Popovertitle, String Popovercontent, String Popovermsg, Popovers Popovers = Popovers.top, Type Type = Type.Info, Sizes Sizes = Sizes.None)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            String type = GetBtnType(Type);
            String sizes = GetBtnSizes(Sizes);
            String position = GetPosition(Popovers);
            retour.AppendLine(String.Format("<button type='button' class='btn " + sizes + " " + type + "  " + GENERAL.Tools.GetPostitionText() + " ' data-placement='" + position + "'  data-toggle='popover' title='{0}' data-content='{1}'>{2}</button>", Popovertitle, Popovercontent, Popovermsg));
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        #endregion basically

        #region private method

        private static string GetPosition(Popovers Popovers)
        {
            switch (Popovers)
            {
                case Popovers.top: return "top";
                case Popovers.bottom: return "bottom";
                case Popovers.left: return "left";
                case Popovers.right: return "right";
                default: return String.Empty;
            }
        }

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