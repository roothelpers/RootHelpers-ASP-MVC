using System;
using System.Text;
using System.Web.Mvc;

namespace RootHelpers
{
    /// <summary>
    ///
    /// </summary>
    public static class ModalHelper
    {
        #region basically

        /// <summary>
        /// Modals
        /// </summary>
        /// <param name="IDmodel">unique id for an HTML element</param>
        /// <param name="title">The title.</param>
        /// <param name="Partial">Body of Model</param>
        /// <returns></returns>
        public static MvcHtmlString Modal<TModel>(this HtmlHelper<TModel> html, String IDmodel, String title = "Launch demo modal ", String Partial = null,Boolean footer =false)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine(String.Format("<button type='button' class='btn btn-primary' data-toggle='modal' data-target='#" + IDmodel + "'>{0}</button>", title));
            retour.AppendLine("<div class='modal fade' id='" + IDmodel + "' tabindex='-1' role='dialog' aria-labelledby='" + IDmodel + "' aria-hidden='true'>");
            retour.AppendLine("<div class='modal-dialog' role='document'>");
            retour.AppendLine("<div class='modal-content'>");
            retour.AppendLine(" <div class='modal-header " + GENERAL.Tools.GetPostitionText() + "'>");
            retour.AppendLine("<h5 class='modal-title ' id='" + IDmodel + "'>Modal title</h5>");
            retour.AppendLine("<button type = 'button' class='close' data-dismiss='modal' aria-label='Close'>");
            retour.AppendLine(" <span aria-hidden='true'>&times;</span>");
            retour.AppendLine("</button>");
            retour.AppendLine("</div>");
            retour.AppendLine("<div class='modal-body " + GENERAL.Tools.GetPostitionText() + "'>");
            retour.AppendLine(Partial);
            retour.AppendLine("</div>");
            if (footer)
            {
                retour.AppendLine("<div class='modal-footer'>");
                retour.AppendLine("<button type = 'button' class='btn btn-secondary' data-dismiss='modal'>Close</button>");
                retour.AppendLine("<button type = 'button' class='btn btn-primary'>Save changes</button>");
                retour.AppendLine("</div>");

            }
            retour.AppendLine("</div>");
            retour.AppendLine("</div>");
            retour.AppendLine("</div>");
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        #endregion basically
    }
}