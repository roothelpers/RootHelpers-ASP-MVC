using System;
using System.Text;
using System.Web.Mvc;

namespace RootHelpers
{
    /// <summary>
    ///
    /// </summary>
    public static class JumbotronHelper
    {
        #region basically

        /// <summary>
        /// Jumbotrons the specified title.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="html">The HTML.</param>
        /// <param name="title">The title.</param>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        public static MvcHtmlString Jumbotron<TModel>(this HtmlHelper<TModel> html, String title, String description)
        {
            int i = 0;
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine("<div class='jumbotron jumbotron-fluid'>");
            retour.AppendLine("<div class='container " + GENERAL.Tools.GetPostitionText() + "'>");
            retour.AppendLine(String.Format("<h1 class='display-4'>{0}</h1>", title));
            retour.AppendLine(String.Format("<p class='lead'>{0}</h1>", description));
            retour.AppendLine("</div>");
            retour.AppendLine("</div>");
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        #endregion basically
    }
}