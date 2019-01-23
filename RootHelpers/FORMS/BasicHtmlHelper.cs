using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace RootHelpers
{
    public static class BasicHtmlHelper
    {
        public static string getlanguage()
        {
            string lang = "en";
            var ci = HttpContext.Current.Session["Language"];
            if (ci != null)
            {
                lang = ci.ToString();
            }
            return lang;
        }

        public static MvcHtmlString Version1<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            var metaData = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            //string retVal = String.Empty;
            //var customTypeDescriptor = new AssociatedMetadataTypeTypeDescriptionProvider(metadata.ContainerType).GetTypeDescriptor(metadata.ContainerType);
            //if (customTypeDescriptor != null)
            //{
            //    var descriptor = customTypeDescriptor.GetProperties().Find(metadata.PropertyName, true);
            //    var req = (new List<RequiredAttribute>(descriptor.Attributes.OfType<RequiredAttribute>())).OfType<RequiredAttribute>().FirstOrDefault();

            //    if (req != null)
            //        retVal = req.ErrorMessage;
            //}

            //* Get currant Language *//
            string lang = getlanguage();
            //* Get name of id  *//
            var body = (MemberExpression)expression.Body;
            var propertyName = body.Member.Name;
            //* Get all translation  *//
            var namevalue = "";
            //* get Attribute *//
            bool hasRequiredAttribute = body.Member.GetCustomAttributes(typeof(RequiredAttribute), false).Length > 0;

            //  var propertyInfo = (PropertyInfo)body.Member;
            //  var propertyType = propertyInfo.PropertyType.Name;
            //   var propertyName = propertyInfo.Name;

            String theeditor = String.Empty;
            //    theeditor += $" <br> {propertyType} {propertyName} <br>";

            theeditor += "<div class='form-group row'>";

            theeditor += "<div class='col-sm-12'>";
            if (lang == "en")
            {
                theeditor += $"<label class='col-sm-12 control-label text-left pt-2'>{propertyName} " + (hasRequiredAttribute == true ? " <span class='required'>*</span>" : "") + "</label>";
            }
            else
            {
                theeditor += $"<label class='col-sm-12 control-label text-right pt-2'> " + (hasRequiredAttribute == true ? " <span class='required'>*</span>" : "") + " " + (propertyName) + " </label>";
            }
            if (!html.ViewData.ModelState.IsValid)
            {
                theeditor += $"<div class=\"validation-summary  text-danger {(lang == "en" ? "text-left" : "text-right")} \">" + html.ValidationMessageFor(expression) + "</div>";
            }
            theeditor += "<div class='col-sm-12'>";
            theeditor += $"<input type = 'text' name='{propertyName}' class='form-control {(lang == "en" ? "text-left" : "text-right")}' placeholder='eg.: {propertyName}'>";
            theeditor += "</div>";
            theeditor += "</div>";
            theeditor += "</div>";
            return new MvcHtmlString(theeditor.ToString());
        }

        public static MvcHtmlString Version2<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            var metaData = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            //string retVal = String.Empty;
            //var customTypeDescriptor = new AssociatedMetadataTypeTypeDescriptionProvider(metadata.ContainerType).GetTypeDescriptor(metadata.ContainerType);
            //if (customTypeDescriptor != null)
            //{
            //    var descriptor = customTypeDescriptor.GetProperties().Find(metadata.PropertyName, true);
            //    var req = (new List<RequiredAttribute>(descriptor.Attributes.OfType<RequiredAttribute>())).OfType<RequiredAttribute>().FirstOrDefault();

            //    if (req != null)
            //        retVal = req.ErrorMessage;
            //}

            //* Get currant Language *//
            string lang = getlanguage();
            //* Get name of id  *//
            var body = (MemberExpression)expression.Body;
            var propertyName = body.Member.Name;
            //* Get all translation  *//
            var namevalue = "";
            //* get Attribute *//
            bool hasRequiredAttribute = body.Member.GetCustomAttributes(typeof(RequiredAttribute), false).Length > 0;

            //  var propertyInfo = (PropertyInfo)body.Member;
            //  var propertyType = propertyInfo.PropertyType.Name;
            //   var propertyName = propertyInfo.Name;

            String theeditor = String.Empty;
            //    theeditor += $" <br> {propertyType} {propertyName} <br>";

            theeditor += "<div class='form-group row'>";

            theeditor += "<div class='col-sm-12 row'>";
            if (lang == "en")
            {
                theeditor += $"<div class='col-lg-6'><label class='col-lg-6 control-label text-left pt-2'>{propertyName} " + (hasRequiredAttribute == true ? " <span class='required'>*</span>" : "") + "</label></div>";
            }
            else
            {
                theeditor += $"<div class='col-lg-6'><label class='col-lg-6 control-label text-right pt-2'> " + (hasRequiredAttribute == true ? " <span class='required'>*</span>" : "") + " " + (propertyName) + " </label></div>";
            }

            theeditor += "<div class='col-lg-6'>";
            theeditor += $"<input type = 'text' name='{propertyName}' class='form-control {(lang == "en" ? "text-left" : "text-right")}' placeholder='eg.: {propertyName}'>";
            theeditor += "</div>";
            theeditor += "</div>";
            theeditor += "</div>";
            if (!html.ViewData.ModelState.IsValid)
            {
                theeditor += $"<div class=\"validation-summary  text-danger {(lang == "en" ? "text-left" : "text-right")} \">" + html.ValidationMessageFor(expression) + "</div>";
            }
            return new MvcHtmlString(theeditor.ToString());
        }
    }
}