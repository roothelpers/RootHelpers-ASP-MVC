using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace RootHelpers
{
    /// <summary>
    ///
    /// </summary>
    public static class CarouselHelper
    {
        #region basically

        /// <summary>
        /// Slideses the specified identifier slide.
        /// </summary>
        /// <param name="IDSlide">The identifier slide.</param>
        /// <param name="nav">The nav.</param>
        /// <param name="Pos">The position.</param>
        /// <param name="Withcontrols">if set to <c>true</c> [withcontrols].</param>
        /// <param name="Withindicators">if set to <c>true</c> [withindicators].</param>
        /// <returns></returns>
        public static MvcHtmlString Slides<TModel>(this HtmlHelper<TModel> html, String IDSlide, Dictionary<String, String> nav, int Pos = -1, bool Withcontrols = false, bool Withindicators = false)
        {
            int i = 0;
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine("<div id='" + IDSlide + "' class='carousel slide' data-ride='carousel'>");
            if (Withcontrols == true)
            {
                int j = 0;
                retour.AppendLine("<ol class='carousel-indicators'>");
                foreach (var item in nav)
                {
                    retour.AppendLine("  <li data-target='#" + IDSlide + "' data-slide-to=" + j + " class='" + (i == Pos ? "active" : "") + " '></li>");
                    j++;
                }
                retour.AppendLine("</ol>");
            }
            retour.AppendLine("  <div class='carousel-inner'>");
            foreach (var item in nav)
            {
                i++;
                retour.AppendLine("  <div class='carousel-item " + (i == Pos ? "active" : "") + " '>");
                retour.AppendLine(String.Format("<img class='d-block w-100' src='{0}' alt='{1}' style='height: 480px !important; '>", item.Key, item.Value));
                retour.AppendLine("    </div>");
            }
            retour.AppendLine("</div>");
            if (Withcontrols == true)
            {
                retour.AppendLine("<a class='carousel-control-prev' href='#" + IDSlide + "' role='button' data-slide='prev'>");
                retour.AppendLine("<span class='carousel-control-prev-icon' aria-hidden='true'></span>");
                retour.AppendLine("<span class='sr-only'>Previous</span>");
                retour.AppendLine("</a>");
                retour.AppendLine("<a class='carousel-control-next' href='#" + IDSlide + "' role='button' data-slide='next'>");
                retour.AppendLine("<span class='carousel-control-next-icon' aria-hidden='true'></span>");
                retour.AppendLine("<span class='sr-only'>Next</span>");
                retour.AppendLine("</a>");
            }

            retour.AppendLine("</div>");
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Crossfades the specified identifier slide.
        /// </summary>
        /// <param name="IDSlide">The identifier slide.</param>
        /// <param name="nav">The nav.</param>
        /// <param name="Pos">The position.</param>
        /// <param name="Withcontrols">if set to <c>true</c> [withcontrols].</param>
        /// <param name="Withindicators">if set to <c>true</c> [withindicators].</param>
        /// <returns></returns>
        public static MvcHtmlString Crossfade<TModel>(this HtmlHelper<TModel> html, String IDSlide, Dictionary<String, String> nav, int Pos = 0, bool Withcontrols = false, bool Withindicators = false)
        {
            int i = 0;
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine("<div id='" + IDSlide + "' class='carousel slide  carousel-fade' data-ride='carousel'>");
            if (Withcontrols == true)
            {
                int j = 0;
                retour.AppendLine("<ol class='carousel-indicators'>");
                foreach (var item in nav)
                {
                    retour.AppendLine("  <li data-target='#" + IDSlide + "' data-slide-to=" + j + " class='" + (i == Pos ? "active" : "") + " '></li>");
                    j++;
                }
                retour.AppendLine("</ol>");
            }
            retour.AppendLine("  <div class='carousel-inner'>");
            foreach (var item in nav)
            {
                i++;
                retour.AppendLine("  <div class='carousel-item " + (i == Pos ? "active" : "") + " '>");
                retour.AppendLine(String.Format("<img class='d-block w-100' src='{0}' alt='{1}' style='height: 480px !important; '>", item.Key, item.Value));
                retour.AppendLine("    </div>");
            }
            retour.AppendLine("</div>");
            if (Withcontrols == true)
            {
                retour.AppendLine("<a class='carousel-control-prev' href='#" + IDSlide + "' role='button' data-slide='prev'>");
                retour.AppendLine("<span class='carousel-control-prev-icon' aria-hidden='true'></span>");
                retour.AppendLine("<span class='sr-only'>Previous</span>");
                retour.AppendLine("</a>");
                retour.AppendLine("<a class='carousel-control-next' href='#" + IDSlide + "' role='button' data-slide='next'>");
                retour.AppendLine("<span class='carousel-control-next-icon' aria-hidden='true'></span>");
                retour.AppendLine("<span class='sr-only'>Next</span>");
                retour.AppendLine("</a>");
            }

            retour.AppendLine("</div>");
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        #endregion basically
    }
}