using System;
using System.Text;
using System.Web.Mvc;

namespace RootHelpers
{
    /// <summary>
    ///Badges are used to highlight items. Badges are numerical indicators of how many items
    /// </summary>
    ///  <remarks>
    /// You would normally see badges to indicate the number of new or unread items, depending on the type of application.
    /// </remarks>
    public static class BadgeHelper
    {
        #region basically

        /// <summary>
        /// Badges the specified message badge.
        /// </summary>
        /// <param name="MessageBadge">if the message is empty, nothing is displayed, otherwise the alert box is displayed.</param>
        /// <param name="Type"> Bootstrap provides four differently styled alerts  : Primary, Secondary, Success, Danger, Warning, Info, Light, Dark</param>
        /// <returns></returns>
        /// <remarks>
        /// Create a Badge with Html.Badge()
        ///@Html.Badge("Default", RootHelpers.Type.Primary)
        /// </remarks>
        public static MvcHtmlString Badge<TModel>(this HtmlHelper<TModel> html, String MessageBadge, Type Type)
        {
            switch (Type)
            {
                case Type.Primary: return BadgePrimary<TModel>(html, MessageBadge);
                case Type.Secondary: return BadgeSecondary<TModel>(html, MessageBadge);
                case Type.Success: return BadgeSuccess<TModel>(html, MessageBadge);
                case Type.Danger: return BadgeDanger<TModel>(html, MessageBadge);
                case Type.Warning: return BadgeWarning<TModel>(html, MessageBadge);
                case Type.Info: return BadgeInfo<TModel>(html, MessageBadge);
                case Type.Light: return BadgeLight<TModel>(html, MessageBadge);
                case Type.Dark: return BadgeDark<TModel>(html, MessageBadge);
                default: return new MvcHtmlString("");
            }
        }

        /// <summary>
        /// Display Primary Badge
        /// </summary>
        /// <param name="MessageBadge">if the message is empty, nothing is displayed, otherwise the alert box is displayed.</param>
        /// <returns></returns>
        /// <remarks>
        /// Create a Badge with Html.BadgePrimary()
        ///@Html.BadgePrimary("BadgePrimary")
        /// </remarks>
        ///
        public static MvcHtmlString BadgePrimary<TModel>(this HtmlHelper<TModel> html, String MessageBadge)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine(String.Format("<span class='badge {1} {2}'>{0}</span>", MessageBadge, GetTextType(Type.Primary), GENERAL.Tools.GetPostitionText()));
            return new MvcHtmlString(retour.ToString());
        }

        /// <summary>
        /// Display Secondary Badge
        /// </summary>
        /// <param name="MessageBadge">if the message is empty, nothing is displayed, otherwise the alert box is displayed.</param>
        /// <returns></returns>
        /// <remarks>
        /// Create a Badge with Html.BadgeSecondary()
        ///@Html.BadgeSecondary("BadgeSecondary")
        /// </remarks>
        public static MvcHtmlString BadgeSecondary<TModel>(this HtmlHelper<TModel> html, String MessageBadge)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine(String.Format("<span class='badge {1} {2}'>{0}</span>", MessageBadge, GetTextType(Type.Secondary), GENERAL.Tools.GetPostitionText()));
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Display success Badge
        /// </summary>
        /// <param name="MessageBadge">if the message is empty, nothing is displayed, otherwise the alert box is displayed.</param>
        /// <returns></returns>
        /// <remarks>
        /// Create a Badge with Html.BadgeSuccess()
        ///@Html.BadgeSuccess("BadgeSuccess")
        /// </remarks>
        public static MvcHtmlString BadgeSuccess<TModel>(this HtmlHelper<TModel> html, String MessageBadge)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine(String.Format("<span class='badge {1} {2}'>{0}</span>", MessageBadge, GetTextType(Type.Success), GENERAL.Tools.GetPostitionText()));
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Display Danger Badge
        /// </summary>
        /// <param name="MessageBadge">if the message is empty, nothing is displayed, otherwise the alert box is displayed.</param>
        /// <returns></returns>
        /// <remarks>
        /// Create a Badge with Html.BadgeDanger()
        ///@Html.BadgeDanger("BadgeDanger")
        /// </remarks>
        public static MvcHtmlString BadgeDanger<TModel>(this HtmlHelper<TModel> html, String MessageBadge)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine(String.Format("<span class='badge {1} {2}'>{0}</span>", MessageBadge, GetTextType(Type.Danger), GENERAL.Tools.GetPostitionText()));
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Display Warning Badge
        /// </summary>
        /// <param name="MessageBadge">if the message is empty, nothing is displayed, otherwise the alert box is displayed.</param>
        /// <returns></returns>
        /// <remarks>
        /// Create a Badge with Html.BadgeWarning()
        ///@Html.BadgeWarning("BadgeWarning")
        /// </remarks>
        public static MvcHtmlString BadgeWarning<TModel>(this HtmlHelper<TModel> html, String MessageBadge)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine(String.Format("<span class='badge {1} {2}'>{0}</span>", MessageBadge, GetTextType(Type.Warning), GENERAL.Tools.GetPostitionText()));
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Display Info Badge
        /// </summary>
        /// <param name="MessageBadge">if the message is empty, nothing is displayed, otherwise the alert box is displayed.</param>
        /// <returns></returns>
        /// <remarks>
        /// Create a Badge with Html.BadgeInfo()
        ///@Html.BadgeInfo("BadgeInfo")
        /// </remarks>
        public static MvcHtmlString BadgeInfo<TModel>(this HtmlHelper<TModel> html, String MessageBadge)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine(String.Format("<span class='badge {1} {2}'>{0}</span>", MessageBadge, GetTextType(Type.Info), GENERAL.Tools.GetPostitionText()));
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Display Light Badge
        /// </summary>
        /// <param name="MessageBadge">if the message is empty, nothing is displayed, otherwise the alert box is displayed.</param>
        /// <returns></returns>
        /// <remarks>
        /// Create a Badge with Html.BadgeLight()
        ///@Html.BadgeLight("BadgeLight")
        /// </remarks>
        public static MvcHtmlString BadgeLight<TModel>(this HtmlHelper<TModel> html, String MessageBadge)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine(String.Format("<span class='badge {1} {2}'>{0}</span>", MessageBadge, GetTextType(Type.Light), GENERAL.Tools.GetPostitionText()));
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Display Dark Badge
        /// </summary>
        /// <param name="MessageBadge">if the message is empty, nothing is displayed, otherwise the alert box is displayed.</param>
        /// <returns></returns>
        /// <remarks>
        /// Create a Badge with Html.BadgeDark()
        ///@Html.BadgeDark("BadgeDark")
        /// </remarks>
        public static MvcHtmlString BadgeDark<TModel>(this HtmlHelper<TModel> html, String MessageBadge)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine(String.Format("<span class='badge {1} {2}'>{0}</span>", MessageBadge, GetTextType(Type.Dark), GENERAL.Tools.GetPostitionText()));
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        #endregion basically

        #region Pill badges

        /// <summary>
        /// Display Dark Pill Badge
        /// </summary>
        /// <param name="MessageBadge">if the message is empty, nothing is displayed, otherwise the alert box is displayed.</param>
        /// <param name="Type"> Bootstrap provides four differently styled alerts  : Primary, Secondary, Success, Danger, Warning, Info, Light, Dark</param>
        /// <returns></returns>
        /// <remarks>
        /// Create a Badge with Html.PillBadge()
        ///@Html.PillBadge("PillBadge")
        /// </remarks>
        public static MvcHtmlString PillBadge<TModel>(this HtmlHelper<TModel> html, String MessageBadge, Type Type)
        {
            switch (Type)
            {
                case Type.Primary: return PillBadgePrimary<TModel>(html, MessageBadge);
                case Type.Secondary: return PillBadgeSecondary<TModel>(html, MessageBadge);
                case Type.Success: return PillBadgeSuccess<TModel>(html, MessageBadge);
                case Type.Danger: return PillBadgeDanger<TModel>(html, MessageBadge);
                case Type.Warning: return PillBadgeWarning<TModel>(html, MessageBadge);
                case Type.Info: return PillBadgeInfo<TModel>(html, MessageBadge);
                case Type.Light: return PillBadgeLight<TModel>(html, MessageBadge);
                case Type.Dark: return PillBadgeDark<TModel>(html, MessageBadge);
                default: return new MvcHtmlString("");
            }
        }

        /// <summary>
        /// Display Pill Badge Primary
        /// </summary>
        /// <param name="MessageBadge">if the message is empty, nothing is displayed, otherwise the alert box is displayed.</param>
        /// <returns></returns>
        /// <remarks>
        /// Create a Badge with Html.PillBadgePrimary()
        ///@Html.PillBadgePrimary("PillBadgePrimary")
        /// </remarks>
        public static MvcHtmlString PillBadgePrimary<TModel>(this HtmlHelper<TModel> html, String MessageBadge)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine(String.Format("<span class='badge badge-pill {1} {2}'>{0}</span>", MessageBadge, GetTextType(Type.Primary), GENERAL.Tools.GetPostitionText()));
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Display Pill Badge Secondary
        /// </summary>
        /// <param name="MessageBadge">if the message is empty, nothing is displayed, otherwise the alert box is displayed.</param>
        /// <returns></returns>
        /// <remarks>
        /// Create a Badge with Html.PillBadgeSecondary()
        ///@Html.PillBadgeSecondary("PillBadgeSecondary")
        /// </remarks>
        public static MvcHtmlString PillBadgeSecondary<TModel>(this HtmlHelper<TModel> html, String MessageBadge)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine(String.Format("<span class='badge badge-pill {1} {2}'>{0}</span>", MessageBadge, GetTextType(Type.Secondary), GENERAL.Tools.GetPostitionText()));
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Display Pill Badge Success
        /// </summary>
        /// <param name="MessageBadge">if the message is empty, nothing is displayed, otherwise the alert box is displayed.</param>
        /// <returns></returns>
        /// <remarks>
        /// Create a Badge with Html.PillBadgeSuccess()
        ///@Html.PillBadgeSuccess("PillBadgeSuccess")
        /// </remarks>
        public static MvcHtmlString PillBadgeSuccess<TModel>(this HtmlHelper<TModel> html, String MessageBadge)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine(String.Format("<span class='badge badge-pill {1} {2}'>{0}</span>", MessageBadge, GetTextType(Type.Success), GENERAL.Tools.GetPostitionText()));
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Display Pill Badge Danger
        /// </summary>
        /// <param name="MessageBadge">if the message is empty, nothing is displayed, otherwise the alert box is displayed.</param>
        /// <returns></returns>
        /// <remarks>
        /// Create a Badge with Html.PillBadgeDanger()
        ///@Html.PillBadgeDanger("PillBadgeDanger")
        /// </remarks>
        public static MvcHtmlString PillBadgeDanger<TModel>(this HtmlHelper<TModel> html, String MessageBadge)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine(String.Format("<span class='badge badge-pill {1} {2}'>{0}</span>", MessageBadge, GetTextType(Type.Danger), GENERAL.Tools.GetPostitionText()));
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Display Pill Badge Warning
        /// </summary>
        /// <param name="MessageBadge">if the message is empty, nothing is displayed, otherwise the alert box is displayed.</param>
        /// <returns></returns>
        /// <remarks>
        /// Create a Badge with Html.PillBadgeWarning()
        ///@Html.PillBadgeWarning("PillBadgeWarning")
        /// </remarks>

        public static MvcHtmlString PillBadgeWarning<TModel>(this HtmlHelper<TModel> html, String MessageBadge)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine(String.Format("<span class='badge badge-pill {1} {2}'>{0}</span>", MessageBadge, GetTextType(Type.Warning), GENERAL.Tools.GetPostitionText()));
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Display Pill Badge info
        /// </summary>
        /// <param name="MessageBadge">if the message is empty, nothing is displayed, otherwise the alert box is displayed.</param>
        /// <returns></returns>
        /// <remarks>
        /// Create a Badge with Html.PillBadgeInfo()
        ///@Html.PillBadgeInfo("PillBadgeInfo")
        /// </remarks>
        public static MvcHtmlString PillBadgeInfo<TModel>(this HtmlHelper<TModel> html, String MessageBadge)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine(String.Format("<span class='badge badge-pill {1} {2}'>{0}</span>", MessageBadge, GetTextType(Type.Info), GENERAL.Tools.GetPostitionText()));
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Display Pill Badge Light
        /// </summary>
        /// <param name="MessageBadge">if the message is empty, nothing is displayed, otherwise the alert box is displayed.</param>
        /// <returns></returns>
        /// <remarks>
        /// Create a Badge with Html.PillBadgeLight()
        ///@Html.PillBadgeLight("PillBadgeLight")
        /// </remarks>
        public static MvcHtmlString PillBadgeLight<TModel>(this HtmlHelper<TModel> html, String MessageBadge)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine(String.Format("<span class='badge badge-pill {1} {2}'>{0}</span>", MessageBadge, GetTextType(Type.Light), GENERAL.Tools.GetPostitionText()));
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Display Pill Badge Dark
        /// </summary>
        /// <param name="MessageBadge">if the message is empty, nothing is displayed, otherwise the alert box is displayed.</param>
        /// <returns></returns>
        /// <remarks>
        /// Create a Badge with Html.PillBadgeDark()
        ///@Html.PillBadgeDark("PillBadgeDark")
        /// </remarks>
        public static MvcHtmlString PillBadgeDark<TModel>(this HtmlHelper<TModel> html, String MessageBadge)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine(String.Format("<span class='badge badge-pill {1} {2}'>{0}</span>", MessageBadge, GetTextType(Type.Dark), GENERAL.Tools.GetPostitionText()));
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        #endregion Pill badges

        #region Markup

        /// <summary>
        /// Display  Badge with markup
        /// </summary>
        /// <param name="MessageBadge">if the message is empty, nothing is displayed, otherwise the alert box is displayed.</param>
        /// <param name="href">The href.</param>
        /// <param name="Type">The type.</param>
        /// <param name="Pillbadges">if set to <c>true</c> [pillbadges].</param>
        /// <returns></returns>
        public static MvcHtmlString BadgeMarkup<TModel>(this HtmlHelper<TModel> html, String MessageBadge, String href, Type Type, bool Pillbadges = false)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            string type = GetTextType(Type);
            retour.AppendLine(String.Format("<a href = '" + href + "' class='badge  " + type + " " + (Pillbadges ? "badge-pill" : "") + " {1}'>{0}</a>", MessageBadge, GENERAL.Tools.GetPostitionText()));
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        #endregion Markup

        #region private method

        /// <summary>
        /// Gets the type of the text.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        private static string GetTextType(Type type)
        {
            switch (type)
            {
                case Type.Primary: return "badge-primary";
                case Type.Secondary: return "badge-secondary";
                case Type.Success: return "badge-success";
                case Type.Danger: return "badge-danger";
                case Type.Warning: return "badge-warning";
                case Type.Info: return "badge-info";
                case Type.Light: return "badge-light";
                case Type.Dark: return "badge-dark";
                default: return String.Empty;
            }
        }

        #endregion private method
    }
}