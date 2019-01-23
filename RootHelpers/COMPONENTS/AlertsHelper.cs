using System;
using System.Text;
using System.Web.Mvc;

namespace RootHelpers
{
    /// <summary>
    /// The alert component is used to provide visual feedback to the user.
    /// </summary>
    /// <remarks>
    /// This can be used to provide the user with either confirmation messages that a record has been saved,
    /// warning messages that an error occurred, or an information message based on a system event.
    /// </remarks>
    public static class AlertsHelper
    {
        #region basically

        /// <summary>
        /// Display Alert
        /// </summary>
        /// <param name="MessageAlert">if the message is empty, nothing is displayed, otherwise the alert box is displayed.</param>
        /// <param name="AlertType"> Bootstrap provides four differently styled alerts  : Primary, Secondary, Success, Danger, Warning, Info, Light, Dark</param>
        /// <returns></returns>
        /// <remarks>
        /// Create a alert with Html.Alert()
        ///@Html.Alert("This is Primary info alert", RootHelpers.Type.Primary)
        /// </remarks>

        public static MvcHtmlString Alert<TModel>(this HtmlHelper<TModel> html, String MessageAlert, Type AlertType)
        {
            switch (AlertType)
            {
                case Type.Primary: return AlertPrimary<TModel>(html, MessageAlert);
                case Type.Secondary: return AlertSecondary<TModel>(html, MessageAlert);
                case Type.Success: return AlertSuccess<TModel>(html, MessageAlert);
                case Type.Danger: return AlertDanger<TModel>(html, MessageAlert);
                case Type.Warning: return AlertWarning<TModel>(html, MessageAlert);
                case Type.Info: return AlertInfo<TModel>(html, MessageAlert);
                case Type.Light: return AlertLight<TModel>(html, MessageAlert);
                case Type.Dark: return AlertDark<TModel>(html, MessageAlert);
                default: return new MvcHtmlString("");
            }
        }

        /// <summary>
        /// Display Primary alert
        /// </summary>
        /// <param name="MessageAlert">if the message is empty, nothing is displayed, otherwise the alert box is displayed.</param>
        /// <returns></returns>
        /// <remarks>
        /// Create a Primary alert with Html.AlertPrimary()
        /// Use: @Html.AlertPrimary()
        /// </remarks>

        public static MvcHtmlString AlertPrimary<TModel>(this HtmlHelper<TModel> html, String MessageAlert)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine(String.Format("<div class='{2} {1}' role='alert'>{0}</div>", MessageAlert, GENERAL.Tools.GetPostitionText(), GetAlertType(Type.Primary)));
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Display Secondary alert
        /// </summary>
        /// <param name="MessageAlert">if the message is empty, nothing is displayed, otherwise the alert box is displayed.</param>
        /// <returns></returns>
        /// <remarks>
        /// Create a Primary alert with Html.AlertSecondary()
        /// Use: @Html.AlertSecondary()
        /// </remarks>

        public static MvcHtmlString AlertSecondary<TModel>(this HtmlHelper<TModel> html, String MessageAlert)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine(String.Format("<div class='{2} {1}' role='alert'>{0}</div>", MessageAlert, GENERAL.Tools.GetPostitionText(), GetAlertType(Type.Secondary)));
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Display Success alert
        /// </summary>
        /// <param name="MessageAlert">if the message is empty, nothing is displayed, otherwise the alert box is displayed.</param>
        /// <returns></returns>
        /// <remarks>
        /// Create a Primary alert with Html.AlertSuccess()
        /// Use: @Html.AlertSuccess()
        /// </remarks>

        public static MvcHtmlString AlertSuccess<TModel>(this HtmlHelper<TModel> html, String MessageAlert)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine(String.Format("<div class='{2} {1}' role='alert'>{0}</div>", MessageAlert, GENERAL.Tools.GetPostitionText(), GetAlertType(Type.Success)));
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Display Danger alert
        /// </summary>
        /// <param name="MessageAlert">if the message is empty, nothing is displayed, otherwise the alert box is displayed.</param>
        /// <returns></returns>
        /// <remarks>
        /// Create a Primary alert with Html.AlertDanger()
        /// Use: @Html.AlertDanger()
        /// </remarks>

        public static MvcHtmlString AlertDanger<TModel>(this HtmlHelper<TModel> html, String MessageAlert)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine(String.Format("<div class='{2} {1}' role='alert'>{0}</div>", MessageAlert, GENERAL.Tools.GetPostitionText(), GetAlertType(Type.Danger)));
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Display Warning alert
        /// </summary>
        /// <param name="MessageAlert">if the message is empty, nothing is displayed, otherwise the alert box is displayed.</param>
        /// <returns></returns>
        /// <remarks>
        /// Create a Primary alert with Html.AlertWarning()
        /// Use: @Html.AlertWarning()
        /// </remarks>

        public static MvcHtmlString AlertWarning<TModel>(this HtmlHelper<TModel> html, String MessageAlert)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine(String.Format("<div class='{2} {1}' role='alert'>{0}</div>", MessageAlert, GENERAL.Tools.GetPostitionText(), GetAlertType(Type.Warning)));
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Display Info alert
        /// </summary>
        /// <param name="MessageAlert">if the message is empty, nothing is displayed, otherwise the alert box is displayed.</param>
        /// <returns></returns>
        /// <remarks>
        /// Create a Primary alert with Html.AlertInfo()
        /// Use: @Html.AlertInfo()
        /// </remarks>

        public static MvcHtmlString AlertInfo<TModel>(this HtmlHelper<TModel> html, String MessageAlert)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine(String.Format("<div class='{2} {1}' role='alert'>{0}</div>", MessageAlert, GENERAL.Tools.GetPostitionText(), GetAlertType(Type.Info)));
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Display Light alert
        /// </summary>
        /// <param name="MessageAlert">if the message is empty, nothing is displayed, otherwise the alert box is displayed.</param>
        /// <returns></returns>
        /// <remarks>
        /// Create a Light alert with Html.AlertLight()
        /// Use: @Html.AlertLight()
        /// </remarks>
        ///
        public static MvcHtmlString AlertLight<TModel>(this HtmlHelper<TModel> html, String MessageAlert)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine(String.Format("<div class='{2} {1}' role='alert'>{0}</div>", MessageAlert, GENERAL.Tools.GetPostitionText(), GetAlertType(Type.Light)));
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Display Dark alert
        /// </summary>
        /// <param name="MessageAlert">if the message is empty, nothing is displayed, otherwise the alert box is displayed.</param>
        /// <returns></returns>
        /// <remarks>
        /// Create a Dark alert with Html.AlertDark()
        /// Use: @Html.AlertDark()
        /// </remarks>
        public static MvcHtmlString AlertDark<TModel>(this HtmlHelper<TModel> html, String MessageAlert)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine(String.Format("<div class='{2} {1}' role='alert'>{0}</div>", MessageAlert, GENERAL.Tools.GetPostitionText(), GetAlertType(Type.Dark)));
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        #endregion basically

        #region advanced

        #region Additional content

        /// <summary>
        /// Alerts can also contain additional HTML elements like headings, paragraphs and dividers.
        /// </summary>
        /// <param name="AlertType"> Bootstrap provides four differently styled alerts  : Primary, Secondary, Success, Danger, Warning, Info, Light, Dark</param>
        /// <param name="heading"></param>
        /// <param name="MessageAlert">if the message is empty, nothing is displayed, otherwise the alert box is displayed.</param>
        /// <param name="MessageAlert2">if you add 2 Message Alert direct dividers display.</param>
        /// <returns></returns>
        /// <remarks>
        /// Create a alert With Header with Html.AlertDark()
        /// Use: @Html.Alert()
        /// </remarks>
        public static MvcHtmlString Alert<TModel>(this HtmlHelper<TModel> html, Type AlertType, String heading, String MessageAlert, String MessageAlert2 = null)
        {
            switch (AlertType)
            {
                case Type.Primary: return AlertPrimaryAdditionalContent<TModel>(html, heading, MessageAlert, MessageAlert2);
                case Type.Secondary: return AlertSecondaryAdditionalContent<TModel>(html, heading, MessageAlert, MessageAlert2);
                case Type.Success: return AlertSuccessAdditionalContent<TModel>(html, heading, MessageAlert, MessageAlert2);
                case Type.Danger: return AlertDangerAdditionalContent<TModel>(html, heading, MessageAlert, MessageAlert2);
                case Type.Warning: return AlertWarningAdditionalContent<TModel>(html, heading, MessageAlert, MessageAlert2);
                case Type.Info: return AlertInfoAdditionalContent<TModel>(html, heading, MessageAlert, MessageAlert2);
                case Type.Light: return AlertLightAdditionalContent<TModel>(html, heading, MessageAlert, MessageAlert2);
                case Type.Dark: return AlertDarkAdditionalContent<TModel>(html, heading, MessageAlert, MessageAlert2);
                default: return new MvcHtmlString("");
            }
        }

        /// <summary>
        /// Display Primary alert With Header
        /// </summary>
        /// <param name="heading">if the message is empty, nothing is displayed, otherwise the message is displayed at the beginning of a block (header)</param>
        /// <param name="MessageAlert">f the message is empty, nothing is displayed, otherwise the alert box is displayed.</param>
        /// <param name="MessageAlert2">f the message is empty, nothing is displayed, otherwise the alert box is displayed.</param>
        /// <returns></returns>
        /// <remarks>
        /// Create a alert With Header with Html.AlertPrimaryAdditionalContent()
        /// Use: @Html.AlertPrimaryAdditionalContent()
        /// </remarks>

        public static MvcHtmlString AlertPrimaryAdditionalContent<TModel>(this HtmlHelper<TModel> html, String heading, String MessageAlert, String MessageAlert2 = null)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine(String.Format("<div class='{1} {0}' role='alert'>", GENERAL.Tools.GetPostitionText(), GetAlertType(Type.Primary)));
            retour.AppendLine(String.Format("<h4 class='alert-heading'>{0}</h4> <br> <p>{1}</p>", heading, MessageAlert));
            if (!String.IsNullOrEmpty(MessageAlert2)) // if the MessageAlert2 is not empty, we display dividers and MessageAlert2
            {
                retour.AppendLine(String.Format("<hr> <p class='mb-0'>{0}</p>", MessageAlert2));
            }
            retour.AppendLine("</div>");
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Display Secondary alert With Header
        /// </summary>
        /// <param name="heading">if the message is empty, nothing is displayed, otherwise the message is displayed at the beginning of a block (header)</param>
        /// <param name="MessageAlert">f the message is empty, nothing is displayed, otherwise the alert box is displayed.</param>
        /// <param name="MessageAlert2">f the message is empty, nothing is displayed, otherwise the alert box is displayed.</param>
        /// <returns></returns>
        /// <remarks>
        /// Create a alert With Header with Html.AlertSecondaryAdditionalContent()
        /// Use: @Html.AlertSecondaryAdditionalContent()
        /// </remarks>

        public static MvcHtmlString AlertSecondaryAdditionalContent<TModel>(this HtmlHelper<TModel> html, String heading, String MessageAlert, String MessageAlert2 = null)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine(String.Format("<div class='{1} {0}' role='alert'>", GENERAL.Tools.GetPostitionText(), GetAlertType(Type.Secondary)));
            retour.AppendLine(String.Format("<h4 class='alert-heading'>{0}</h4> <br> <p>{1}</p>", heading, MessageAlert));
            if (!String.IsNullOrEmpty(MessageAlert2)) // if the MessageAlert2 is not empty, we display dividers and MessageAlert2
            {
                retour.AppendLine(String.Format("<hr> <p class='mb-0'>{0}</p>", MessageAlert2));
            }
            retour.AppendLine("</div>");
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Display Success alert With Header
        /// </summary>
        /// <param name="heading">if the message is empty, nothing is displayed, otherwise the message is displayed at the beginning of a block (header)</param>
        /// <param name="MessageAlert">f the message is empty, nothing is displayed, otherwise the alert box is displayed.</param>
        /// <param name="MessageAlert2">f the message is empty, nothing is displayed, otherwise the alert box is displayed.</param>
        /// <returns></returns>
        /// <remarks>
        /// Create a alert With Header with Html.AlertSuccessAdditionalContent()
        /// Use: @Html.AlertSuccessAdditionalContent()
        /// </remarks>

        public static MvcHtmlString AlertSuccessAdditionalContent<TModel>(this HtmlHelper<TModel> html, String heading, String MessageAlert, String MessageAlert2 = null)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine(String.Format("<div class='{1} {0}' role='alert'>", GENERAL.Tools.GetPostitionText(), GetAlertType(Type.Success)));
            retour.AppendLine(String.Format("<h4 class='alert-heading'>{0}</h4> <br> <p>{1}</p>", heading, MessageAlert));
            if (!String.IsNullOrEmpty(MessageAlert2)) // if the MessageAlert2 is not empty, we display dividers and MessageAlert2
            {
                retour.AppendLine(String.Format("<hr> <p class='mb-0'>{0}</p>", MessageAlert2));
            }
            retour.AppendLine("</div>");
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Display Danger alert With Header
        /// </summary>
        /// <param name="heading">if the message is empty, nothing is displayed, otherwise the message is displayed at the beginning of a block (header)</param>
        /// <param name="MessageAlert">f the message is empty, nothing is displayed, otherwise the alert box is displayed.</param>
        /// <param name="MessageAlert2">f the message is empty, nothing is displayed, otherwise the alert box is displayed.</param>
        /// <returns></returns>
        /// <remarks>
        /// Create a alert With Header with Html.AlertDangerAdditionalContent()
        /// Use: @Html.AlertDangerAdditionalContent()
        /// </remarks>

        public static MvcHtmlString AlertDangerAdditionalContent<TModel>(this HtmlHelper<TModel> html, String heading, String MessageAlert, String MessageAlert2 = null)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine(String.Format("<div class='{1} {0}' role='alert'>", GENERAL.Tools.GetPostitionText(), GetAlertType(Type.Danger)));
            retour.AppendLine(String.Format("<h4 class='alert-heading'>{0}</h4> <br> <p>{1}</p>", heading, MessageAlert));
            if (!String.IsNullOrEmpty(MessageAlert2)) // if the MessageAlert2 is not empty, we display dividers and MessageAlert2
            {
                retour.AppendLine(String.Format("<hr> <p class='mb-0'>{0}</p>", MessageAlert2));
            }
            retour.AppendLine("</div>");
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Display Warning alert With Header
        /// </summary>
        /// <param name="heading">if the message is empty, nothing is displayed, otherwise the message is displayed at the beginning of a block (header)</param>
        /// <param name="MessageAlert">f the message is empty, nothing is displayed, otherwise the alert box is displayed.</param>
        /// <param name="MessageAlert2">f the message is empty, nothing is displayed, otherwise the alert box is displayed.</param>
        /// <returns></returns>
        /// <remarks>
        /// Create a alert With Header with Html.AlertWarningAdditionalContent()
        /// Use: @Html.AlertWarningAdditionalContent()
        /// </remarks>

        public static MvcHtmlString AlertWarningAdditionalContent<TModel>(this HtmlHelper<TModel> html, String heading, String MessageAlert, String MessageAlert2 = null)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine(String.Format("<div class='{1} {0}' role='alert'>", GENERAL.Tools.GetPostitionText(), GetAlertType(Type.Warning)));
            retour.AppendLine(String.Format("<h4 class='alert-heading'>{0}</h4> <br> <p>{1}</p>", heading, MessageAlert));
            if (!String.IsNullOrEmpty(MessageAlert2)) // if the MessageAlert2 is not empty, we display dividers and MessageAlert2
            {
                retour.AppendLine(String.Format("<hr> <p class='mb-0'>{0}</p>", MessageAlert2));
            }
            retour.AppendLine("</div>");
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Display Info alert With Header
        /// </summary>
        /// <param name="heading">if the message is empty, nothing is displayed, otherwise the message is displayed at the beginning of a block (header)</param>
        /// <param name="MessageAlert">if the message is empty, nothing is displayed, otherwise the alert box is displayed.</param>
        /// <param name="MessageAlert2">if the message is empty, nothing is displayed, otherwise the alert box is displayed.</param>
        /// <returns></returns>
        /// <remarks>
        /// Create a alert With Header with Html.AlertInfoAdditionalContent()
        /// Use: @Html.AlertInfoAdditionalContent()
        /// </remarks>

        public static MvcHtmlString AlertInfoAdditionalContent<TModel>(this HtmlHelper<TModel> html, String heading, String MessageAlert, String MessageAlert2 = null)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine(String.Format("<div class='{1} {0}' role='alert'>", GENERAL.Tools.GetPostitionText(), GetAlertType(Type.Info)));
            retour.AppendLine(String.Format("<h4 class='alert-heading'>{0}</h4> <br> <p>{1}</p>", heading, MessageAlert));
            if (!String.IsNullOrEmpty(MessageAlert2)) // if the MessageAlert2 is not empty, we display dividers and MessageAlert2
            {
                retour.AppendLine(String.Format("<hr> <p class='mb-0'>{0}</p>", MessageAlert2));
            }
            retour.AppendLine("</div>");
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Display Light alert With Header
        /// </summary>
        /// <param name="heading">if the message is empty, nothing is displayed, otherwise the message is displayed at the beginning of a block (header)</param>
        /// <param name="MessageAlert">f the message is empty, nothing is displayed, otherwise the alert box is displayed.</param>
        /// <param name="MessageAlert2">f the message is empty, nothing is displayed, otherwise the alert box is displayed.</param>
        /// <returns></returns>
        /// <remarks>
        /// Create a alert With Header with Html.AlertLightAdditionalContent()
        /// Use: @Html.AlertLightAdditionalContent()
        /// </remarks>

        public static MvcHtmlString AlertLightAdditionalContent<TModel>(this HtmlHelper<TModel> html, String heading, String MessageAlert, String MessageAlert2 = null)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine(String.Format("<div class='{1} {0}' role='alert'>", GENERAL.Tools.GetPostitionText(), GetAlertType(Type.Light)));
            retour.AppendLine(String.Format("<h4 class='alert-heading'>{0}</h4> <br> <p>{1}</p>", heading, MessageAlert));
            if (!String.IsNullOrEmpty(MessageAlert2)) // if the MessageAlert2 is not empty, we display dividers and MessageAlert2
            {
                retour.AppendLine(String.Format("<hr> <p class='mb-0'>{0}</p>", MessageAlert2));
            }
            retour.AppendLine("</div>");
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Display Dark alert With Header
        /// </summary>
        /// <param name="heading">if the message is empty, nothing is displayed, otherwise the message is displayed at the beginning of a block (header)</param>
        /// <param name="MessageAlert">if the message is empty, nothing is displayed, otherwise the alert box is displayed.</param>
        /// <param name="MessageAlert2">if the message is empty, nothing is displayed, otherwise the alert box is displayed.</param>
        /// <returns></returns>
        /// <remarks>
        /// Create a alert With Header with Html.AlertDarkAdditionalContent()
        /// Use: @Html.AlertDarkAdditionalContent()
        /// </remarks>

        public static MvcHtmlString AlertDarkAdditionalContent<TModel>(this HtmlHelper<TModel> html, String heading, String MessageAlert, String MessageAlert2 = null)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine(String.Format("<div class='{1} {0}' role='alert'>", GENERAL.Tools.GetPostitionText(), GetAlertType(Type.Dark)));
            retour.AppendLine(String.Format("<h4 class='alert-heading'>{0}</h4> <br> <p>{1}</p>", heading, MessageAlert));
            if (!String.IsNullOrEmpty(MessageAlert2)) // if the MessageAlert2 is not empty, we display dividers and MessageAlert2
            {
                retour.AppendLine(String.Format("<hr> <p class='mb-0'>{0}</p>", MessageAlert2));
            }
            retour.AppendLine("</div>");
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        #endregion Additional content

        #region Dismissing

        /// <summary>
        /// A dismissible alert is an alert that can be closed by the user by clicking on a small X icon in its top right-hand corner.
        /// </summary>
        /// <param name="MessageAlert">f the message is empty, nothing is displayed, otherwise the alert box is displayed.</param>
        /// <param name="AlertType"> Bootstrap provides four differently styled alerts  : Primary, Secondary, Success, Danger, Warning, Info, Light, Dark</param>
        /// <returns></returns>
        /// <remarks>
        /// Create a dismissible alert with Html.AlertDismissing()
        /// Use: @Html.AlertDismissing()
        /// </remarks>

        public static MvcHtmlString AlertDismissing<TModel>(this HtmlHelper<TModel> html, String MessageAlert, Type AlertType)
        {
            switch (AlertType)
            {
                case Type.Primary: return AlertPrimaryDismissing<TModel>(html, MessageAlert);
                case Type.Secondary: return AlertSecondaryDismissing<TModel>(html, MessageAlert);
                case Type.Success: return AlertSuccessDismissing<TModel>(html, MessageAlert);
                case Type.Danger: return AlertDangerDismissing<TModel>(html, MessageAlert);
                case Type.Warning: return AlertWarningDismissing<TModel>(html, MessageAlert);
                case Type.Info: return AlertInfoDismissing<TModel>(html, MessageAlert);
                case Type.Light: return AlertLightDismissing<TModel>(html, MessageAlert);
                case Type.Dark: return AlertDarkDismissing<TModel>(html, MessageAlert);
                default: return new MvcHtmlString("");
            }
        }

        /// <summary>
        /// Display dismissible Primary alert
        /// </summary>
        /// <param name="MessageAlert">f the message is empty, nothing is displayed, otherwise the alert box is displayed.</param>
        /// <returns></returns>
        /// <remarks>
        /// Create a dismissible Primary alert with Html.AlertPrimaryDismissing()
        /// Use: @Html.AlertPrimaryDismissing()
        /// </remarks>

        public static MvcHtmlString AlertPrimaryDismissing<TModel>(this HtmlHelper<TModel> html, String MessageAlert)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine(String.Format("<div class='{2} alert-dismissible {1} fade show' role='alert'>{0}<button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button></div>", MessageAlert, GENERAL.Tools.GetPostitionText(), GetAlertType(Type.Primary)));
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Display dismissible Secondary alert
        /// </summary>
        /// <param name="MessageAlert">f the message is empty, nothing is displayed, otherwise the alert box is displayed.</param>
        /// <returns></returns>
        /// <remarks>
        /// Create a dismissible Secondary alert with Html.AlertSecondaryDismissing()
        /// Use: @Html.AlertSecondaryDismissing()
        /// </remarks>

        public static MvcHtmlString AlertSecondaryDismissing<TModel>(this HtmlHelper<TModel> html, String MessageAlert)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine(String.Format("<div class='{2} alert-dismissible {1} fade show' role='alert'>{0}<button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button></div>", MessageAlert, GENERAL.Tools.GetPostitionText(), GetAlertType(Type.Secondary)));
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Display dismissible Success alert
        /// </summary>
        /// <param name="MessageAlert">f the message is empty, nothing is displayed, otherwise the alert box is displayed.</param>
        /// <returns></returns>
        /// <remarks>
        /// Create a dismissible Success alert with Html.AlertSuccessDismissing()
        /// Use: @Html.AlertSuccessDismissing()
        /// </remarks>
        public static MvcHtmlString AlertSuccessDismissing<TModel>(this HtmlHelper<TModel> html, String MessageAlert)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine(String.Format("<div class='{2} alert-dismissible {1} fade show' role='alert'>{0}<button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button></div>", MessageAlert, GENERAL.Tools.GetPostitionText(), GetAlertType(Type.Success)));
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Display dismissible Danger alert
        /// </summary>
        /// <param name="MessageAlert">f the message is empty, nothing is displayed, otherwise the alert box is displayed.</param>
        /// <returns></returns>
        /// <remarks>
        /// Create a dismissible Danger alert with Html.AlertDangerDismissing()
        /// Use: @Html.AlertDangerDismissing()
        /// </remarks>
        ///

        public static MvcHtmlString AlertDangerDismissing<TModel>(this HtmlHelper<TModel> html, String MessageAlert)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine(String.Format("<div class='{2} alert-dismissible {1} fade show' role='alert'>{0}<button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button></div>", MessageAlert, GENERAL.Tools.GetPostitionText(), GetAlertType(Type.Danger)));
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Display dismissible Warning alert
        /// </summary>
        /// <param name="MessageAlert">f the message is empty, nothing is displayed, otherwise the alert box is displayed.</param>
        /// <returns></returns>
        /// <remarks>
        /// Create a dismissible Danger alert with Html.AlertWarningDismissing()
        /// Use: @Html.AlertWarningDismissing()
        /// </remarks>

        public static MvcHtmlString AlertWarningDismissing<TModel>(this HtmlHelper<TModel> html, String MessageAlert)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine(String.Format("<div class='{2} alert-dismissible {1} fade show' role='alert'>{0}<button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button></div>", MessageAlert, GENERAL.Tools.GetPostitionText(), GetAlertType(Type.Warning)));
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Display dismissible Info alert
        /// </summary>
        /// <param name="MessageAlert">f the message is empty, nothing is displayed, otherwise the alert box is displayed.</param>
        /// <returns></returns>
        /// <remarks>
        /// Create a dismissible Danger alert with Html.AlertInfoDismissing()
        /// Use: @Html.AlertInfoDismissing()
        /// </remarks>
        ///
        public static MvcHtmlString AlertInfoDismissing<TModel>(this HtmlHelper<TModel> html, String MessageAlert)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine(String.Format("<div class='{2} alert-dismissible {1} fade show' role='alert'>{0}<button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button></div>", MessageAlert, GENERAL.Tools.GetPostitionText(), GetAlertType(Type.Info)));
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Display dismissible Light alert
        /// </summary>
        /// <param name="MessageAlert">f the message is empty, nothing is displayed, otherwise the alert box is displayed.</param>
        /// <returns></returns>
        /// <remarks>
        /// Create a dismissible Danger alert with Html.AlertLightDismissing()
        /// Use: @Html.AlertLightDismissing()
        /// </remarks>
        ///

        public static MvcHtmlString AlertLightDismissing<TModel>(this HtmlHelper<TModel> html, String MessageAlert)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine(String.Format("<div class='{2} alert-dismissible {1} fade show' role='alert'>{0}<button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button></div>", MessageAlert, GENERAL.Tools.GetPostitionText(), GetAlertType(Type.Light)));
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Display dismissible Dark alert
        /// </summary>
        /// <param name="MessageAlert">f the message is empty, nothing is displayed, otherwise the alert box is displayed.</param>
        /// <returns></returns>
        ///  <remarks>
        /// Create a dismissible Dark alert with Html.AlertDarkDismissing()
        /// Use: @Html.AlertDarkDismissing()
        /// </remarks>
        ///
        public static MvcHtmlString AlertDarkDismissing<TModel>(this HtmlHelper<TModel> html, String MessageAlert)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine(String.Format("<div class='{2} alert-dismissible {1} fade show' role='alert'>{0}<button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button></div>", MessageAlert, GENERAL.Tools.GetPostitionText(), GetAlertType(Type.Dark)));
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        #endregion Dismissing

        #endregion advanced

        #region private method

        private static string GetAlertType(Type type)
        {
            switch (type)
            {
                case Type.Primary: return "alert alert-primary";
                case Type.Secondary: return "alert alert-secondary";
                case Type.Success: return "alert alert-success";
                case Type.Danger: return "alert alert-danger";
                case Type.Warning: return "alert alert-warning";
                case Type.Info: return "alert alert-info";
                case Type.Light: return "alert alert-light";
                case Type.Dark: return "alert alert-dark";
                default: return String.Empty;
            }
        }

        #endregion private method
    }
}