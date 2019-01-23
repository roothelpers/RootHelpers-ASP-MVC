using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace RootHelpers
{
    public static class Helpers
    {
        public static MvcHtmlString Clipboard<TModel>(this HtmlHelper<TModel> html, String ID, String Code)
        {
            StringBuilder retour = new StringBuilder();
            retour.AppendLine("<div class='bd-clipboard'>");
            retour.AppendLine("<button class='btn btn-clipboard' data-clipboard-target='#" + ID + "' data-original-title='Copy to clipboard'><i class='fa fa-copy'></i> Copy</button>");
            retour.AppendLine("</div>");
            retour.AppendLine("<figure id='" + ID + "' class=''>");
            retour.AppendLine(" <pre class='prettyprint' id='quine'>");
            retour.AppendLine(Code);
            retour.AppendLine("</pre>");
            retour.AppendLine("</figure>");
            return new MvcHtmlString(retour.ToString());
        }

        public static string StripHTML(string input)
        {
            return Regex.Replace(input, "<.*?>", String.Empty);
        }

        public static HtmlString ShowLinksLi(Dictionary<string, string> labellinks)
        {
            StringBuilder html = new StringBuilder();
            if (labellinks != null)
                foreach (string item in labellinks.Keys) //<i class="fa fa-cogs" aria-hidden="true"></i> Gestion Logiciel
                {
                    html.AppendFormat("<li><a href='{1}'>{0}</a></li>", item, labellinks[item]);
                    html.AppendLine();
                }

            return new HtmlString(html.ToString());
        }

        public static string DisplayDateFR(DateTime date)
        {
            var year = date.Year;
            var month = date.Month;
            var day = date.Day;

            var str = day + " ";
            if (month == 1) str += "Janvier";
            if (month == 2) str += "F&eacute;vrier";
            if (month == 3) str += "Mars";
            if (month == 4) str += "Avril";
            if (month == 5) str += "Mai";
            if (month == 6) str += "Juin";
            if (month == 7) str += "Juillet";
            if (month == 8) str += "Ao&ucirc;t";
            if (month == 9) str += "Septembre";
            if (month == 10) str += "Octobre";
            if (month == 11) str += "Novembre";
            if (month == 12) str += "D&eacute;cembre";
            str += " " + year;

            return str;
        }

        public static MvcHtmlString BooleanDropdownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return BooleanDropdownListFor(htmlHelper, expression, null, null);
        }

        public static MvcHtmlString BooleanDropdownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            return BooleanDropdownListFor(htmlHelper, expression, htmlAttributes, null);
        }

        public static MvcHtmlString BooleanDropdownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes, string EmptyText)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            bool? value = null;

            if (metadata != null && metadata.Model != null)
            {
                if (metadata.Model is bool)
                    value = (bool)metadata.Model;
                else if (metadata.Model.GetType() == typeof(bool?))
                    value = (bool?)metadata.Model;
            }

            List<SelectListItem> items = EmptyText != null ?
                new List<SelectListItem>() { new SelectListItem() { Text = EmptyText, Value = "" }, new SelectListItem() { Text = "Yes", Value = "True", Selected = (value.HasValue && value.Value == true) }, new SelectListItem() { Text = "No", Value = "False", Selected = (value.HasValue && value.Value == false) } } :
                new List<SelectListItem>() { new SelectListItem() { Text = "Yes", Value = "True", Selected = (value.HasValue && value.Value == true) }, new SelectListItem() { Text = "No", Value = "False", Selected = (value.HasValue && value.Value == false) } };

            return htmlHelper.DropDownListFor(expression, items, htmlAttributes);
        }
    }
}