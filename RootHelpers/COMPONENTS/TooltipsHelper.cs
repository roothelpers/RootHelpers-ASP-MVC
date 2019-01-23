using System;
using System.Text;
using System.Web.Mvc;

namespace RootHelpers
{
    /// <summary>
    /// The Tooltip plugin is small pop-up box that appears when the user moves the mouse pointer over an element
    /// </summary>
    public static class TooltipsHelper
    {
        #region basically

        /// <summary>
        /// display Tooltip
        /// </summary>
        /// <param name="Tooltips">to set the position of the tooltip on top, bottom, left or the right side of the element</param>
        /// <param name="tooltiptitle">to specify the text that should be displayed inside the tooltip </param>
        /// <param name="tooltiplabel">to specify the text that should be displayed inside the button</param>
        /// <param name="Type"> to specify the style that shloud be displayed : Primary, Secondary, Success, Danger, Warning, Info, Light, Dark</param>
        /// <param name="Sizes"> to specify The sizes.</param>
        /// <returns></returns>
        /// <remarks>
        /// Create a Tooltip with Html.Tooltip()
        /// Use: @Html.Tooltip()
        /// </remarks>
        ///
        public static MvcHtmlString Tooltip<TModel>(this HtmlHelper<TModel> html, Tooltips Tooltips, String tooltiptitle, String tooltiplabel, Type Type, Sizes Sizes = Sizes.None)
        {
            switch (Tooltips)
            {
                case Tooltips.top: return TooltipTop<TModel>(html, tooltiptitle, tooltiplabel, Type, Sizes);
                case Tooltips.bottom: return TooltipBottom<TModel>(html, tooltiptitle, tooltiplabel, Type, Sizes);
                case Tooltips.left: return TooltipLeft<TModel>(html, tooltiptitle, tooltiplabel, Type, Sizes);
                case Tooltips.right: return TooltipRight<TModel>(html, tooltiptitle, tooltiplabel, Type, Sizes);

                default: return new MvcHtmlString("");
            }
        }

        /// <summary>
        /// display top Tooltip
        /// </summary>
        /// <param name="tooltiptitle">to specify the text that should be displayed inside the tooltip </param>
        /// <param name="tooltiplabel">to specify the text that should be displayed inside the button</param>
        /// <param name="Type"> to specify the style that shloud be displayed : Primary, Secondary, Success, Danger, Warning, Info, Light, Dark</param>
        /// <param name="Sizes"> to specify The sizes.</param>
        /// <returns></returns>
        /// <remarks>
        /// Create a top Tooltip with Html.TooltipTop()
        /// Use: @Html.TooltipTop()
        /// </remarks>
        ///
        public static MvcHtmlString TooltipTop<TModel>(this HtmlHelper<TModel> html, String tooltiptitle, String tooltiplabel, Type Type, Sizes Sizes = Sizes.None)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            string type = GetBtnType(Type);
            string sizes = GetBtnSizes(Sizes);
            retour.AppendLine(String.Format("<button type='button' class='btn " + sizes + " " + type + " "+ GENERAL.Tools.GetPostitionText() + "' data-toggle='tooltip' data-placement='top' title='{0}'>{1}</button>", tooltiptitle, tooltiplabel));
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// display Right Tooltips.
        /// </summary>
        /// <param name="tooltiptitle">to specify the text that should be displayed inside the tooltip </param>
        /// <param name="tooltiplabel">to specify the text that should be displayed inside the button</param>
        /// <param name="Type"> to specify the style that shloud be displayed : Primary, Secondary, Success, Danger, Warning, Info, Light, Dark</param>
        /// <param name="Sizes"> to specify The sizes.</param>
        /// <returns></returns>
        /// <remarks>
        /// Create a Right Tooltip with Html.TooltipRight()
        /// Use: @Html.TooltipRight()
        /// </remarks>
        ///
        public static MvcHtmlString TooltipRight<TModel>(this HtmlHelper<TModel> html, String tooltiptitle, String tooltiplabel, Type Type, Sizes Sizes = Sizes.None)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            string type = GetBtnType(Type);
            string sizes = GetBtnSizes(Sizes);
            retour.AppendLine(String.Format("<button type='button' class='btn " + sizes + " " + type + "  " + GENERAL.Tools.GetPostitionText() + "' data-toggle='tooltip' data-placement='right' title='{0}'>{1}</button>", tooltiptitle, tooltiplabel));
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Tooltips the bottom.
        /// </summary>
        /// <param name="tooltiptitle">to specify the text that should be displayed inside the tooltip </param>
        /// <param name="tooltiplabel">to specify the text that should be displayed inside the button</param>
        /// <param name="Type"> to specify the style that shloud be displayed : Primary, Secondary, Success, Danger, Warning, Info, Light, Dark</param>
        /// <param name="Sizes"> to specify The sizes.</param>
        /// <returns></returns>
        /// <remarks>
        /// Create a Bottom Tooltip with Html.TooltipBottom()
        /// Use: @Html.TooltipBottom()
        /// </remarks>
        ///
        public static MvcHtmlString TooltipBottom<TModel>(this HtmlHelper<TModel> html, String tooltiptitle, String tooltiplabel, Type Type, Sizes Sizes = Sizes.None)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            string type = GetBtnType(Type);
            string sizes = GetBtnSizes(Sizes);
            retour.AppendLine(String.Format("<button type='button' class='btn " + sizes + " " + type + "  " + GENERAL.Tools.GetPostitionText() + "' data-toggle='tooltip' data-placement='bottom' title='{0}'>{1}</button>", tooltiptitle, tooltiplabel));
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Tooltips the left.
        /// </summary>
        /// <param name="tooltiptitle">to specify the text that should be displayed inside the tooltip </param>
        /// <param name="tooltiplabel">to specify the text that should be displayed inside the button</param>
        /// <param name="Type"> to specify the style that shloud be displayed : Primary, Secondary, Success, Danger, Warning, Info, Light, Dark</param>
        /// <param name="Sizes"> to specify The sizes.</param>
        /// <returns></returns>
        /// <remarks>
        /// Create a Left Tooltip with Html.TooltipLeft()
        /// Use: @Html.TooltipLeft()
        /// </remarks>
        ///
        public static MvcHtmlString TooltipLeft<TModel>(this HtmlHelper<TModel> html, String tooltiptitle, String tooltiplabel, Type Type, Sizes Sizes = Sizes.None)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            string type = GetBtnType(Type);
            string sizes = GetBtnSizes(Sizes);
            retour.AppendLine(String.Format("<button type='button' class='btn " + sizes + " " + type + "  " + GENERAL.Tools.GetPostitionText() + "' data-toggle='tooltip' data-placement='left' title='{0}'>{1}</button>", tooltiptitle, tooltiplabel));
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        #endregion basically

        #region Markup

        /// <summary>
        /// Tooltips the markup.
        /// </summary>
        /// <param name="Tooltips">The tooltips.</param>
        /// <param name="tooltiptitle">to specify the text that should be displayed inside the tooltip </param>
        /// <param name="tooltiplabel">to specify the text that should be displayed inside the button</param>
        /// <param name="href">The href.</param>
        /// <param name="Type"> to specify the style that shloud be displayed : Primary, Secondary, Success, Danger, Warning, Info, Light, Dark</param>
        /// <returns></returns>
        /// <remarks>
        /// Create a Tooltip with Html.TooltipMarkup()
        /// Use: @Html.TooltipMarkup()
        /// </remarks>
        ///
        public static MvcHtmlString TooltipMarkup<TModel>(this HtmlHelper<TModel> html, Tooltips Tooltips, String tooltiptitle, String tooltiplabel, String href, Type Type = Type.Primary, Sizes Sizes = Sizes.None)
        {
            switch (Tooltips)
            {
                case Tooltips.top: return TooltipTopMarkup<TModel>(html, tooltiptitle, tooltiplabel, href, Type, Sizes);
                case Tooltips.bottom: return TooltipBottomMarkup<TModel>(html, tooltiptitle, tooltiplabel, href, Type, Sizes);
                case Tooltips.left: return TooltipLeftMarkup<TModel>(html, tooltiptitle, tooltiplabel, href, Type, Sizes);
                case Tooltips.right: return TooltipRightMarkup<TModel>(html, tooltiptitle, tooltiplabel, href, Type, Sizes);
                default: return new MvcHtmlString("");
            }
        }

        /// <summary>
        /// Tooltips the top markup.
        /// </summary>
        /// <param name="tooltiptitle">to specify the text that should be displayed inside the tooltip </param>
        /// <param name="tooltiplabel">to specify the text that should be displayed inside the button</param>
        /// <param name="href">The href.</param>
        /// <param name="Type"> to specify the style that shloud be displayed : Primary, Secondary, Success, Danger, Warning, Info, Light, Dark</param>
        /// <returns></returns>
        /// <remarks>
        /// Create a Top Tooltip with Html.TooltipTopMarkup()
        /// Use: @Html.TooltipTopMarkup()
        /// </remarks>
        ///
        public static MvcHtmlString TooltipTopMarkup<TModel>(this HtmlHelper<TModel> html, String tooltiptitle, String tooltiplabel, String href, Type Type = Type.Primary, Sizes Sizes = Sizes.None)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            string type = GetTextType(Type);
            string sizes = GetBtnSizes(Sizes);
            retour.AppendLine(String.Format("<a href = '" + href + "' class='" + type + " " + sizes + "  " + GENERAL.Tools.GetPostitionText() + "'  data-toggle='tooltip' data-placement='top' title='{0}'>{1}</a>", tooltiptitle, tooltiplabel));
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Tooltips the right markup.
        /// </summary>
        /// <param name="tooltiptitle">to specify the text that should be displayed inside the tooltip </param>
        /// <param name="tooltiplabel">to specify the text that should be displayed inside the button</param>
        /// <param name="href">The href.</param>
        /// <param name="Type"> to specify the style that shloud be displayed : Primary, Secondary, Success, Danger, Warning, Info, Light, Dark</param>
        /// <returns></returns>
        /// <remarks>
        /// Create a Right Tooltip with Html.TooltipRightMarkup()
        /// Use: @Html.TooltipRightMarkup()
        /// </remarks>
        ///
        public static MvcHtmlString TooltipRightMarkup<TModel>(this HtmlHelper<TModel> html, String tooltiptitle, String tooltiplabel, String href, Type Type = Type.Primary, Sizes Sizes = Sizes.None)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            string type = GetTextType(Type);
            string sizes = GetBtnSizes(Sizes);
            retour.AppendLine(String.Format("<a href='" + href + "'  class='" + type + " " + sizes + "  " + GENERAL.Tools.GetPostitionText() + "' data-toggle='tooltip' data-placement='right' title='{0}'>{1}</a>", tooltiptitle, tooltiplabel));
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Tooltips the bottom markup.
        /// </summary>
        /// <param name="tooltiptitle">to specify the text that should be displayed inside the tooltip </param>
        /// <param name="tooltiplabel">to specify the text that should be displayed inside the button</param>
        /// <param name="href">The href.</param>
        /// <param name="Type"> to specify the style that shloud be displayed : Primary, Secondary, Success, Danger, Warning, Info, Light, Dark</param>
        /// <returns></returns>
        /// <remarks>
        /// Create a bottom Tooltip with Html.TooltipBottomMarkup()
        /// Use: @Html.TooltipBottomMarkup()
        /// </remarks>
        ///
        public static MvcHtmlString TooltipBottomMarkup<TModel>(this HtmlHelper<TModel> html, String tooltiptitle, String tooltiplabel, String href, Type Type = Type.Primary, Sizes Sizes = Sizes.None)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            string sizes = GetBtnSizes(Sizes);
            string type = GetTextType(Type);
            retour.AppendLine(String.Format("<a href='" + href + "' class='" + type + " " + sizes + "  " + GENERAL.Tools.GetPostitionText() + "' data-toggle='tooltip' data-placement='bottom' title='{0}'>{1}</a>", tooltiptitle, tooltiplabel));
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Tooltips the left markup.
        /// </summary>
        /// <param name="tooltiptitle">to specify the text that should be displayed inside the tooltip </param>
        /// <param name="tooltiplabel">to specify the text that should be displayed inside the button</param>
        /// <param name="href">The href.</param>
        /// <param name="Type"> to specify the style that shloud be displayed : Primary, Secondary, Success, Danger, Warning, Info, Light, Dark</param>
        /// <returns></returns>
        /// <remarks>
        /// Create a Left Tooltip  with Html.TooltipLeftMarkup()
        /// Use: @Html.TooltipLeftMarkup()
        /// </remarks>
        ///
        public static MvcHtmlString TooltipLeftMarkup<TModel>(this HtmlHelper<TModel> html, String tooltiptitle, String tooltiplabel, String href, Type Type = Type.Primary, Sizes Sizes = Sizes.None)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            string type = GetTextType(Type);
            string sizes = GetBtnSizes(Sizes);
            retour.AppendLine(String.Format("<a href = '" + href + "' class='" + type + " " + sizes + "  " + GENERAL.Tools.GetPostitionText() + "' data-toggle='tooltip' data-placement='left' title='{0}'>{1}</a>", tooltiptitle, tooltiplabel));
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        #endregion Markup

        #region private method

        /// <summary>
        /// Gets the type of the text.
        /// </summary>
        /// <param name="type"> to specify the style that shloud be displayed : Primary, Secondary, Success, Danger, Warning, Info, Light, Dark</param>
        /// <returns></returns>
        private static string GetTextType(Type type)
        {
            switch (type)
            {
                case Type.Primary: return "text-primary";
                case Type.Secondary: return "text-secondary";
                case Type.Success: return "text-success";
                case Type.Danger: return "text-danger";
                case Type.Warning: return "text-warning";
                case Type.Info: return "text-info";
                case Type.Light: return "text-light";
                case Type.Dark: return "text-dark";
                default: return String.Empty;
            }
        }

        /// <summary>
        /// Gets the type of the BTN.
        /// </summary>
        /// <param name="type"> to specify the style that shloud be displayed : Primary, Secondary, Success, Danger, Warning, Info, Light, Dark</param>
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