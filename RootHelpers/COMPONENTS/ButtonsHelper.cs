using System;
using System.Text;
using System.Web.Mvc;

namespace RootHelpers
{
    /// <summary>
    ///
    /// </summary>
    public static class ButtonsHelper
    {
        #region basically

        /// <summary>
        /// Buttons the specified alert type.
        /// </summary>
        /// <param name="AlertType">Type of the alert.</param>
        /// <param name="Value">The value.</param>
        /// <param name="Sizes">The sizes.</param>
        /// <param name="submit">if set to <c>true</c> [submit].</param>
        /// <param name="href">The href.</param>
        /// <returns></returns>
        public static MvcHtmlString Button<TModel>(this HtmlHelper<TModel> html, Type AlertType, String Value, Sizes Sizes = Sizes.None, bool submit = false, String href = null)
        {
            switch (AlertType)
            {
                case Type.Primary: return ButtonPrimary<TModel>(html, Value, Sizes, submit, href);
                case Type.Secondary: return ButtonSecondary<TModel>(html, Value, Sizes, submit, href);
                case Type.Success: return ButtonSuccess<TModel>(html, Value, Sizes, submit, href);
                case Type.Danger: return ButtonDanger<TModel>(html, Value, Sizes, submit, href);
                case Type.Warning: return ButtonWarning<TModel>(html, Value, Sizes, submit, href);
                case Type.Info: return ButtonInfo<TModel>(html, Value, Sizes, submit, href);
                case Type.Light: return ButtonLight<TModel>(html, Value, Sizes, submit, href);
                case Type.Dark: return ButtonDark<TModel>(html, Value, Sizes, submit, href);
                default: return new MvcHtmlString("");
            }
        }

        /// <summary>
        /// Buttons the primary.
        /// </summary>
        /// <param name="Value">The value.</param>
        /// <param name="Sizes">The sizes.</param>
        /// <param name="submit">if set to <c>true</c> [submit].</param>
        /// <param name="href">The href.</param>
        /// <returns></returns>
        public static MvcHtmlString ButtonPrimary<TModel>(this HtmlHelper<TModel> html, String Value, Sizes Sizes = Sizes.None, bool submit = false, String href = null)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            string sizes = String.Empty;
            if (Sizes == Sizes.Larger) { sizes = "btn-lg"; }
            if (Sizes == Sizes.Small) { sizes = "btn-sm"; }
            if (Sizes == Sizes.Block) { sizes = "btn-lg btn-block"; }
            retour.AppendLine("<input class='btn btn-primary " + sizes + "    ' type='" + (submit == true ? "submit" : "") + "' " + ((!String.IsNullOrEmpty(href)) ? "href='" + href + "'" : "") + " value='" + Value + "' readonly>");
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Buttons the secondary.
        /// </summary>
        /// <param name="Value">The value.</param>
        /// <param name="Sizes">The sizes.</param>
        /// <param name="submit">if set to <c>true</c> [submit].</param>
        /// <param name="href">The href.</param>
        /// <returns></returns>
        public static MvcHtmlString ButtonSecondary<TModel>(this HtmlHelper<TModel> html, String Value, Sizes Sizes = Sizes.None, bool submit = false, String href = null)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            string sizes = String.Empty;
            if (Sizes == Sizes.Larger) { sizes = "btn-lg"; }
            if (Sizes == Sizes.Small) { sizes = "btn-sm"; }
            if (Sizes == Sizes.Block) { sizes = "btn-lg btn-block"; }
            retour.AppendLine("<input class='btn btn-secondary " + sizes + "' type='" + (submit == true ? "submit" : "") + "' " + ((!String.IsNullOrEmpty(href)) ? "href='" + href + "'" : "") + " value='" + Value + "' readonly>");
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Buttons the success.
        /// </summary>
        /// <param name="Value">The value.</param>
        /// <param name="Sizes">The sizes.</param>
        /// <param name="submit">if set to <c>true</c> [submit].</param>
        /// <param name="href">The href.</param>
        /// <returns></returns>
        public static MvcHtmlString ButtonSuccess<TModel>(this HtmlHelper<TModel> html, String Value, Sizes Sizes = Sizes.None, bool submit = false, String href = null)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            string sizes = String.Empty;
            if (Sizes == Sizes.Larger) { sizes = "btn-lg"; }
            if (Sizes == Sizes.Small) { sizes = "btn-sm"; }
            if (Sizes == Sizes.Block) { sizes = "btn-lg btn-block"; }
            retour.AppendLine("<input class='btn btn-success " + sizes + "' type='" + (submit == true ? "submit" : "") + "' " + ((!String.IsNullOrEmpty(href)) ? "href='" + href + "'" : "") + " value='" + Value + "' readonly>");
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Buttons the danger.
        /// </summary>
        /// <param name="Value">The value.</param>
        /// <param name="Sizes">The sizes.</param>
        /// <param name="submit">if set to <c>true</c> [submit].</param>
        /// <param name="href">The href.</param>
        /// <returns></returns>
        public static MvcHtmlString ButtonDanger<TModel>(this HtmlHelper<TModel> html, String Value, Sizes Sizes = Sizes.None, bool submit = false, String href = null)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            string sizes = String.Empty;
            if (Sizes == Sizes.Larger) { sizes = "btn-lg"; }
            if (Sizes == Sizes.Small) { sizes = "btn-sm"; }
            if (Sizes == Sizes.Block) { sizes = "btn-lg btn-block"; }
            retour.AppendLine("<input class='btn btn-danger " + sizes + "' type='" + (submit == true ? "submit" : "") + "' " + ((!String.IsNullOrEmpty(href)) ? "href='" + href + "'" : "") + " value='" + Value + "' readonly>");
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Buttons the warning.
        /// </summary>
        /// <param name="Value">The value.</param>
        /// <param name="Sizes">The sizes.</param>
        /// <param name="submit">if set to <c>true</c> [submit].</param>
        /// <param name="href">The href.</param>
        /// <returns></returns>
        public static MvcHtmlString ButtonWarning<TModel>(this HtmlHelper<TModel> html, String Value, Sizes Sizes = Sizes.None, bool submit = false, String href = null)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            string sizes = String.Empty;
            if (Sizes == Sizes.Larger) { sizes = "btn-lg"; }
            if (Sizes == Sizes.Small) { sizes = "btn-sm"; }
            if (Sizes == Sizes.Block) { sizes = "btn-lg btn-block"; }
            retour.AppendLine("<input class='btn btn-warning " + sizes + "' type='" + (submit == true ? "submit" : "") + "' " + ((!String.IsNullOrEmpty(href)) ? "href='" + href + "'" : "") + " value='" + Value + "' readonly>");
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Buttons the information.
        /// </summary>
        /// <param name="Value">The value.</param>
        /// <param name="Sizes">The sizes.</param>
        /// <param name="submit">if set to <c>true</c> [submit].</param>
        /// <param name="href">The href.</param>
        /// <returns></returns>
        public static MvcHtmlString ButtonInfo<TModel>(this HtmlHelper<TModel> html, String Value, Sizes Sizes = Sizes.None, bool submit = false, String href = null)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            string sizes = String.Empty;
            if (Sizes == Sizes.Larger) { sizes = "btn-lg"; }
            if (Sizes == Sizes.Small) { sizes = "btn-sm"; }
            if (Sizes == Sizes.Block) { sizes = "btn-lg btn-block"; }
            retour.AppendLine("<input class='btn btn-info " + sizes + "' type='" + (submit == true ? "submit" : "") + "' " + ((!String.IsNullOrEmpty(href)) ? "href='" + href + "'" : "") + " value='" + Value + "' readonly>");
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Buttons the light.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="html">The HTML.</param>
        /// <param name="Value">The value.</param>
        /// <param name="Sizes">The sizes.</param>
        /// <param name="submit">if set to <c>true</c> [submit].</param>
        /// <param name="href">The href.</param>
        /// <returns></returns>
        public static MvcHtmlString ButtonLight<TModel>(this HtmlHelper<TModel> html, String Value, Sizes Sizes = Sizes.None, bool submit = false, String href = null)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            string sizes = String.Empty;
            if (Sizes == Sizes.Larger) { sizes = "btn-lg"; }
            if (Sizes == Sizes.Small) { sizes = "btn-sm"; }
            if (Sizes == Sizes.Block) { sizes = "btn-lg btn-block"; }
            retour.AppendLine("<input class='btn btn-light " + sizes + "' type='" + (submit == true ? "submit" : "") + "' " + ((!String.IsNullOrEmpty(href)) ? "href='" + href + "'" : "") + " value='" + Value + "' readonly>");
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Buttons the dark.
        /// </summary>
        /// <param name="Value">The value.</param>
        /// <param name="Sizes">The sizes.</param>
        /// <param name="submit">if set to <c>true</c> [submit].</param>
        /// <param name="href">The href.</param>
        /// <returns></returns>
        public static MvcHtmlString ButtonDark<TModel>(this HtmlHelper<TModel> html, String Value, Sizes Sizes = Sizes.None, bool submit = false, String href = null)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            string sizes = String.Empty;
            if (Sizes == Sizes.Larger) { sizes = "btn-lg"; }
            if (Sizes == Sizes.Small) { sizes = "btn-sm"; }
            if (Sizes == Sizes.Block) { sizes = "btn-lg btn-block"; }
            retour.AppendLine("<input class='btn btn-dark " + sizes + "' type='" + (submit == true ? "submit" : "") + "' " + ((!String.IsNullOrEmpty(href)) ? "href='" + href + "'" : "") + " value='" + Value + "' readonly>");
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        #endregion basically

        #region Outline buttons

        /// <summary>
        /// Outlines the button.
        /// </summary>
        /// <param name="AlertType">Type of the alert.</param>
        /// <param name="Value">The value.</param>
        /// <param name="Sizes">The sizes.</param>
        /// <param name="submit">if set to <c>true</c> [submit].</param>
        /// <param name="href">The href.</param>
        /// <returns></returns>
        public static MvcHtmlString OutlineButton<TModel>(this HtmlHelper<TModel> html, Type AlertType, String Value, Sizes Sizes = Sizes.None, bool submit = false, String href = null)
        {
            switch (AlertType)
            {
                case Type.Primary: return OutlineButtonPrimary<TModel>(html, Value, Sizes, submit, href);
                case Type.Secondary: return OutlineButtonSecondary<TModel>(html, Value, Sizes, submit, href);
                case Type.Success: return OutlineButtonSuccess<TModel>(html, Value, Sizes, submit, href);
                case Type.Danger: return OutlineButtonDanger<TModel>(html, Value, Sizes, submit, href);
                case Type.Warning: return OutlineButtonWarning<TModel>(html, Value, Sizes, submit, href);
                case Type.Info: return OutlineButtonInfo<TModel>(html, Value, Sizes, submit, href);
                case Type.Light: return OutlineButtonLight<TModel>(html, Value, Sizes, submit, href);
                case Type.Dark: return OutlineButtonDark<TModel>(html, Value, Sizes, submit, href);
                default: return new MvcHtmlString("");
            }
        }

        /// <summary>
        /// Outlines the button primary.
        /// </summary>
        /// <param name="Value">The value.</param>
        /// <param name="Sizes">The sizes.</param>
        /// <param name="submit">if set to <c>true</c> [submit].</param>
        /// <param name="href">The href.</param>
        /// <returns></returns>
        public static MvcHtmlString OutlineButtonPrimary<TModel>(this HtmlHelper<TModel> html, String Value, Sizes Sizes = Sizes.None, bool submit = false, String href = null)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            string sizes = String.Empty;
            if (Sizes == Sizes.Larger) { sizes = "btn-lg"; }
            if (Sizes == Sizes.Small) { sizes = "btn-sm"; }
            if (Sizes == Sizes.Block) { sizes = "btn-lg btn-block"; }
            retour.AppendLine("<input class='btn btn-outline-primary " + sizes + "' type='" + (submit == true ? "submit" : "") + "' " + ((!String.IsNullOrEmpty(href)) ? "href='" + href + "'" : "") + " value='" + Value + "' readonly>");
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Outlines the button secondary.
        /// </summary>
        /// <param name="Value">The value.</param>
        /// <param name="Sizes">The sizes.</param>
        /// <param name="submit">if set to <c>true</c> [submit].</param>
        /// <param name="href">The href.</param>
        /// <returns></returns>
        public static MvcHtmlString OutlineButtonSecondary<TModel>(this HtmlHelper<TModel> html, String Value, Sizes Sizes = Sizes.None, bool submit = false, String href = null)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            string sizes = String.Empty;
            if (Sizes == Sizes.Larger) { sizes = "btn-lg"; }
            if (Sizes == Sizes.Small) { sizes = "btn-sm"; }
            if (Sizes == Sizes.Block) { sizes = "btn-lg btn-block"; }
            retour.AppendLine("<input class='btn btn-outline-secondary " + sizes + "' type='" + (submit == true ? "submit" : "") + "' " + ((!String.IsNullOrEmpty(href)) ? "href='" + href + "'" : "") + " value='" + Value + "' readonly>");
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Outlines the button success.
        /// </summary>
        /// <param name="Value">The value.</param>
        /// <param name="Sizes">The sizes.</param>
        /// <param name="submit">if set to <c>true</c> [submit].</param>
        /// <param name="href">The href.</param>
        /// <returns></returns>
        public static MvcHtmlString OutlineButtonSuccess<TModel>(this HtmlHelper<TModel> html, String Value, Sizes Sizes = Sizes.None, bool submit = false, String href = null)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            string sizes = String.Empty;
            if (Sizes == Sizes.Larger) { sizes = "btn-lg"; }
            if (Sizes == Sizes.Small) { sizes = "btn-sm"; }
            if (Sizes == Sizes.Block) { sizes = "btn-lg btn-block"; }
            retour.AppendLine("<input class='btn btn-outline-success " + sizes + "' type='" + (submit == true ? "submit" : "") + "' " + ((!String.IsNullOrEmpty(href)) ? "href='" + href + "'" : "") + " value='" + Value + "' readonly>");
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Outlines the button danger.
        /// </summary>
        /// <param name="Value">The value.</param>
        /// <param name="Sizes">The sizes.</param>
        /// <param name="submit">if set to <c>true</c> [submit].</param>
        /// <param name="href">The href.</param>
        /// <returns></returns>
        public static MvcHtmlString OutlineButtonDanger<TModel>(this HtmlHelper<TModel> html, String Value, Sizes Sizes = Sizes.None, bool submit = false, String href = null)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            string sizes = String.Empty;
            if (Sizes == Sizes.Larger) { sizes = "btn-lg"; }
            if (Sizes == Sizes.Small) { sizes = "btn-sm"; }
            if (Sizes == Sizes.Block) { sizes = "btn-lg btn-block"; }
            retour.AppendLine("<input class='btn btn-outline-danger " + sizes + "' type='" + (submit == true ? "submit" : "") + "' " + ((!String.IsNullOrEmpty(href)) ? "href='" + href + "'" : "") + " value='" + Value + "' readonly>");
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Outlines the button warning.
        /// </summary>
        /// <param name="Value">The value.</param>
        /// <param name="Sizes">The sizes.</param>
        /// <param name="submit">if set to <c>true</c> [submit].</param>
        /// <param name="href">The href.</param>
        /// <returns></returns>
        public static MvcHtmlString OutlineButtonWarning<TModel>(this HtmlHelper<TModel> html, String Value, Sizes Sizes = Sizes.None, bool submit = false, String href = null)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            string sizes = String.Empty;
            if (Sizes == Sizes.Larger) { sizes = "btn-lg"; }
            if (Sizes == Sizes.Small) { sizes = "btn-sm"; }
            if (Sizes == Sizes.Block) { sizes = "btn-lg btn-block"; }
            retour.AppendLine("<input class='btn btn-outline-warning " + sizes + "' type='" + (submit == true ? "submit" : "") + "' " + ((!String.IsNullOrEmpty(href)) ? "href='" + href + "'" : "") + " value='" + Value + "' readonly>");
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Outlines the button information.
        /// </summary>
        /// <param name="Value">The value.</param>
        /// <param name="Sizes">The sizes.</param>
        /// <param name="submit">if set to <c>true</c> [submit].</param>
        /// <param name="href">The href.</param>
        /// <returns></returns>
        public static MvcHtmlString OutlineButtonInfo<TModel>(this HtmlHelper<TModel> html, String Value, Sizes Sizes = Sizes.None, bool submit = false, String href = null)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            string sizes = String.Empty;
            if (Sizes == Sizes.Larger) { sizes = "btn-lg"; }
            if (Sizes == Sizes.Small) { sizes = "btn-sm"; }
            if (Sizes == Sizes.Block) { sizes = "btn-lg btn-block"; }
            retour.AppendLine("<input class='btn btn-outline-info " + sizes + "' type='" + (submit == true ? "submit" : "") + "' " + ((!String.IsNullOrEmpty(href)) ? "href='" + href + "'" : "") + " value='" + Value + "' readonly>");
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Outlines the button light.
        /// </summary>
        /// <param name="Value">The value.</param>
        /// <param name="Sizes">The sizes.</param>
        /// <param name="submit">if set to <c>true</c> [submit].</param>
        /// <param name="href">The href.</param>
        /// <returns></returns>
        public static MvcHtmlString OutlineButtonLight<TModel>(this HtmlHelper<TModel> html, String Value, Sizes Sizes = Sizes.None, bool submit = false, String href = null)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            string sizes = String.Empty;
            if (Sizes == Sizes.Larger) { sizes = "btn-lg"; }
            if (Sizes == Sizes.Small) { sizes = "btn-sm"; }
            if (Sizes == Sizes.Block) { sizes = "btn-lg btn-block"; }
            retour.AppendLine("<input class='btn btn-outline-light " + sizes + "' type='" + (submit == true ? "submit" : "") + "' " + ((!String.IsNullOrEmpty(href)) ? "href='" + href + "'" : "") + " value='" + Value + "' readonly>");
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Outlines the button dark.
        /// </summary>
        /// <param name="Value">The value.</param>
        /// <param name="Sizes">The sizes.</param>
        /// <param name="submit">if set to <c>true</c> [submit].</param>
        /// <param name="href">The href.</param>
        /// <returns></returns>
        public static MvcHtmlString OutlineButtonDark<TModel>(this HtmlHelper<TModel> html, String Value, Sizes Sizes = Sizes.None, bool submit = false, String href = null)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            string sizes = String.Empty;
            if (Sizes == Sizes.Larger) { sizes = "btn-lg"; }
            if (Sizes == Sizes.Small) { sizes = "btn-sm"; }
            if (Sizes == Sizes.Block) { sizes = "btn-lg btn-block"; }
            retour.AppendLine("<input class='btn btn-outline-dark " + sizes + "' type='" + (submit == true ? "submit" : "") + "' " + ((!String.IsNullOrEmpty(href)) ? "href='" + href + "'" : "") + " value='" + Value + "' readonly>");
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        #endregion Outline buttons
    }
}