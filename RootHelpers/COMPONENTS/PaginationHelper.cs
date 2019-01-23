using System;
using System.Text;
using System.Web.Mvc;

namespace RootHelpers
{
    /// <summary>
    /// Add pagination links to help split up your long content into shorter, easier to understand blocks.
    /// </summary>
    public static class PaginationHelper
    {
        /// <summary>
        /// Obtient le nombre de page
        /// </summary>
        /// <param name="CountResultsTotal">The count results total.</param>
        /// <param name="ShowCountResults">nombre de résultat par page</param>
        /// <returns></returns>
        public static int CountPages(int CountResultsTotal, int ShowCountResults)
        {
            return (int)Math.Ceiling((decimal)CountResultsTotal / (decimal)ShowCountResults);
        }

        /// <summary>
        /// Obtien le offset (position de départ des résultats) en fonction de la page en cours
        /// </summary>
        /// <param name="CurrentPage">The current page.</param>
        /// <param name="ShowCountResults">The show count results.</param>
        /// <returns></returns>
        public static int OffsetPageResults(int CurrentPage, int ShowCountResults)
        {
            if (CurrentPage == 0 || CurrentPage == 1) return 0;
            if (ShowCountResults == 0) return 0;
            return (CurrentPage * ShowCountResults) - ShowCountResults;
        }

        /// <summary>
        /// Shows the result count.
        /// </summary>
        /// <returns></returns>
        public static MvcHtmlString ShowResultCount()
        {
            return new MvcHtmlString("");
        }

        /// <summary>
        /// Shows the pagination.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="html">The HTML.</param>
        /// <param name="form">The form.</param>
        /// <param name="CountResultsTotal">The count results total.</param>
        /// <param name="SubmitFormId">The submit form identifier.</param>
        /// <returns></returns>
        public static MvcHtmlString ShowPagination<TModel>(this HtmlHelper<TModel> html, ISearchForm form, int CountResultsTotal, string SubmitFormId)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            int nbpageRange = 4;
            int totalpage = CountPages(CountResultsTotal, form.LimitResults);
            int currentPage = form.CurrentPage;
            //if (currentPage == 0) currentPage = 1;
            string jsHrefFormatString = " onClick=\"location.href=URL_add_parameter(location.href,'CurrentPage',{0})\" ";

            retour.Append(" <ul class='pagination' " + (GENERAL.Tools.ItEnglish() ? " style=' direction: rtl; ' " : "") + ">");
            if (currentPage > 1)
                retour.AppendFormat("<li><a " + jsHrefFormatString + " title='Page Précédente'>&laquo;</a></li>", currentPage - 1);

            int countallwaysshow = 3; // nombres de pages des bors exterieurs a toujours afficher
            bool showspace = false;
            for (int iipage = 1; iipage <= totalpage; iipage++)
            {
                if (iipage > countallwaysshow && iipage <= (totalpage - countallwaysshow)) // on affiche toujours les pages des bords extérieurs
                    if (!(currentPage < countallwaysshow && iipage < countallwaysshow * 2 + 1)) // on affiche quand même un minimum de résultats
                        if (iipage < (currentPage - nbpageRange) || iipage > (currentPage + nbpageRange)) // on affiche toujours les pages proche de la current page
                        {
                            showspace = true;
                            continue; // cache les pages en trops pour optimiser l'affichage
                        }

                if (currentPage == iipage) retour.AppendFormat("<li class='active'><a href='#'>{0}</a></li>", iipage);
                else
                {
                    if (showspace)
                    {
                        showspace = false;
                        retour.AppendFormat("<li><a " + jsHrefFormatString + " style='margin-left:10px;' >{0}</a></li>", iipage);
                    }
                    else retour.AppendFormat("<li><a " + jsHrefFormatString + " >{0}</a></li>", iipage);
                }
            }

            if (currentPage < totalpage)
                retour.AppendFormat("<li><a " + jsHrefFormatString + "title='Page Suivante'>&raquo;</a></li>", currentPage + 1);

            retour.Append("</ul>");
            retour.AppendLine();

            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }
    }

    /// <summary>
    ///
    /// </summary>
    public interface ISearchForm
    {
        /// <summary>
        /// Gets or sets the current page.
        /// </summary>
        /// <value>
        /// The current page.
        /// </value>
        int CurrentPage { get; set; }

        /// <summary>
        /// Gets or sets the limit results.
        /// </summary>
        /// <value>
        /// The limit results.
        /// </value>
        int LimitResults { get; set; }

        /// <summary>
        /// Gets or sets the show order by.
        /// </summary>
        /// <value>
        /// The show order by.
        /// </value>
        string ShowOrderBy { get; set; }
    }
}