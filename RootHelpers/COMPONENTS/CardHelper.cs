using System;
using System.Text;
using System.Web.Mvc;

namespace RootHelpers
{
    /// <summary>
    ///
    /// </summary>
    public static class CardHelper
    {
        #region basically

        /// <summary>
        /// Cardwithes the image.
        /// </summary>
        /// <param name="imgscr">The imgscr.</param>
        /// <param name="text">The text.</param>
        /// <param name="title">The title.</param>
        /// <returns></returns>
        public static MvcHtmlString CardwithImage<TModel>(this HtmlHelper<TModel> html, String imgscr, String text, String title = null)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine("<div class='card' style='width: 18rem;'>");
            retour.AppendLine(String.Format("<img class='card-img-top' src='{0}'  >", imgscr));
            retour.AppendLine("  <div class='card-body "+ GENERAL.Tools.GetPostitionText() + "'>");
            retour.AppendLine(String.Format("  <h5 class='card-title'>{0}</h5>", title));
            retour.AppendLine(String.Format("<p class='card-text'>{0}</p>", text));
            retour.AppendLine("</div>");
            retour.AppendLine("</div>");
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Cards the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="title">The title.</param>
        /// <returns></returns>
        public static MvcHtmlString Card<TModel>(this HtmlHelper<TModel> html, String text, String title = null)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine("<div class='card'  >");
            retour.AppendLine("  <div class='card-body " + GENERAL.Tools.GetPostitionText() + "'>");
            retour.AppendLine(String.Format("  <h5 class='card-title'>{0}</h5>", title));
            retour.AppendLine(String.Format("<p class='card-text'>{0}</p>", text));
            retour.AppendLine("</div>");
            retour.AppendLine("</div>");
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        #endregion basically
    }
}