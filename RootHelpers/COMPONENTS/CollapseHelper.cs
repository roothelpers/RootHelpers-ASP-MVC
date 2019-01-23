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
    public static class CollapseHelper
    {
        #region basically

        /// <summary>
        /// Collapses the specified titlebutton.
        /// </summary>
        /// <param name="titlebutton">The titlebutton.</param>
        /// <param name="msgbutton">The msgbutton.</param>
        /// <returns></returns>
        public static MvcHtmlString Collapse<TModel>(this HtmlHelper<TModel> html, String titlebutton, String msgbutton)
        {
            int i = 0;
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine("<p>");
            retour.AppendLine("<a class='btn btn-primary' data-toggle='collapse' href='#collapseExample' role='button' aria-expanded='false' aria-controls='collapseExample'>");
            retour.AppendLine(titlebutton);
            retour.AppendLine("  </a>");
            retour.AppendLine("<p>");
            retour.AppendLine("<div class='collapse' id='collapseExample'>");
            retour.AppendLine("  <div class='card card-body " + GENERAL.Tools.GetPostitionText() + "'>");
            retour.AppendLine(msgbutton);
            retour.AppendLine("</div>");
            retour.AppendLine("</div>");
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Collapses the group.
        /// </summary>
        /// <param name="IDaccordion">The i daccordion.</param>
        /// <param name="ListGroup">The list group.</param>
        /// <param name="Pos">The position.</param>
        /// <returns></returns>
        public static MvcHtmlString CollapseGroup<TModel>(this HtmlHelper<TModel> html, String IDaccordion, List<Accordion> ListGroup, Int32 Pos)
        {
            int i = 0;
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine("<div class='accordion' id='" + IDaccordion + "'>");
            ListGroup = ListGroup.OrderBy(x => x.Pos).ToList();
            foreach (Accordion item in ListGroup)
            {
                retour.AppendLine("<div class='card " + GENERAL.Tools.GetPostitionText() + "'>");
                retour.AppendLine("<div class='card-header' id='heading" + item.Pos + "'>");
                retour.AppendLine("<h5 class='mb-0'>");
                retour.AppendLine(String.Format("<button class='btn btn-link' type='button' data-toggle='collapse' data-target='#collapse{0}' aria-expanded='" + (item.Pos == Pos ? "true" : "false") + "' aria-controls='collapse{0}'> {1}</button>", item.Pos, item.AccordionItem));
                retour.AppendLine("</h5>");
                retour.AppendLine("</div>");
                retour.AppendLine("<div id='collapse" + item.Pos + "' class='collapse " + (item.Pos == Pos ? "show" : "") + " ' aria-labelledby='" + item.Pos + "' data-parent='#" + IDaccordion + "'>");
                retour.AppendLine("<div class='card-body'>");
                retour.AppendLine(item.Accordionbody);
                retour.AppendLine("</div>");
                retour.AppendLine("</div>");
                retour.AppendLine("</div>");
            }
            retour.AppendLine("</div>");

            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        #endregion basically
    }
}