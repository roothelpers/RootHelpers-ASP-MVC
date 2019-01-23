using System;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;

namespace RootHelpers
{
    /// <summary>
    ///
    /// </summary>
    public static class InputgroupHelper
    {
        #region basically

        /// <summary>
        /// Inputgroups the specified expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="Sizes">The sizes.</param>
        /// <returns></returns>
        public static MvcHtmlString Inputgroup<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, Sizes Sizes = Sizes.None)
        {
            var body = (MemberExpression)expression.Body;
            var propertyName = body.Member.Name;
            string sizes = String.Empty;
            if (Sizes == Sizes.Larger) { sizes = " input-group-lg"; }
            if (Sizes == Sizes.Small) { sizes = " input-group-sm"; }
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine("<div class='input-group " + sizes + " mb-3 ' " + (GENERAL.Tools.ItEnglish() ? " style=' direction: rtl; ' " : "") + ">");
            retour.AppendLine("<div class='input-group-prepend'>");
            retour.AppendLine(String.Format("<span class='input-group-text' id='inputGroup" + sizes + "'>{0}</span>", propertyName));
            retour.AppendLine("</div>");
            retour.AppendLine(String.Format("  <input type='text' class='form-control' name='{0}' aria-label='Small' aria-describedby='inputGroup" + Sizes + "'>", propertyName));
            retour.AppendLine("</div>");
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        #endregion basically
    }
}