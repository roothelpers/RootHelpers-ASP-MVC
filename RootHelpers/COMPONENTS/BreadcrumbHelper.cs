using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace RootHelpers
{
    /// <summary>
    /// A breadcrumb navigation provide links back to each previous page the user navigated through, and shows the user's current location in a website.
    /// </summary>
    public static class BreadcrumbHelper
    {
        #region basically

        /// <summary>
        /// Breadcrumbs the specified nav.
        /// </summary>
        /// <param name="nav">The nav.</param>
        /// <param name="Pos">The position.</param>
        /// <returns></returns>
        public static MvcHtmlString Breadcrumb<TModel>(this HtmlHelper<TModel> html, List<String> nav, int Pos = -1)
        {
            int i = 0;
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine("<nav aria-label = 'breadcrumb' >");
            retour.AppendLine("<ol class='breadcrumb'  "+(GENERAL.Tools.ItEnglish() ? " style=' direction: rtl; ' " : "") +">");
            foreach (String item in nav)
            {
                i++;
                if (i == Pos)
                {
                    retour.AppendLine(String.Format("<li class='breadcrumb-item' aria-current='page'>{0}</li>", item));
                }
                else
                {
                    retour.AppendLine(String.Format("<li class='breadcrumb-item active' aria-current='page'><a href='#'>{0}</a></li>", item));
                }
            }
            retour.AppendLine("</ol>");
            retour.AppendLine("</nav>");
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Breadcrumbs the specified nav.
        /// </summary>
        /// <param name="nav">The nav.</param>
        /// <returns></returns>
        public static MvcHtmlString Breadcrumb<TModel>(this HtmlHelper<TModel> html, List<Breadcrumb> nav)
        {
            var Url = new UrlHelper(html.ViewContext.RequestContext); // to generate some URLs in a model in ASP.NET MVC
            int i = 0;
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine("<nav aria-label = 'breadcrumb' >");
            retour.AppendLine("<ol class='breadcrumb' " + (GENERAL.Tools.ItEnglish() ? " style=' direction: rtl; ' " : "") + ">");
            nav = nav.OrderBy(it => it.Pos).ToList();
            foreach (var item in nav)
            {
                i++;
                if (html.IsSelected(item.ControllerName, item.ActionName) == false)
                {
                    retour.AppendLine(String.Format("<li class='breadcrumb-item active' aria-current='page'><a href='{1}'>{0}</a></li>", item.Label, Url.Action(item.ActionName, item.ControllerName)));
                }
                else
                {
                    retour.AppendLine(String.Format("<li class='breadcrumb-item' aria-current='page'>{0}</li>", item.Label));
                }
            }
            retour.AppendLine("</ol>");
            retour.AppendLine("</nav>");
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        #endregion basically
    }
}