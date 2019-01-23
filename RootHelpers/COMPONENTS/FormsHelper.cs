using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Web.Mvc;

namespace RootHelpers
{

    public  class RootDropDownList
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string pathimage { get; set; }
    }
    /// <summary>
    ///
    /// </summary>
    public static class FormsHelper
    {
        #region basic method

        /// <summary>
        /// Getproperties the name.
        /// </summary>
        /// <param name="expression">The expression lamda.</param>
        /// <returns></returns>
        private static string getpropertyName<TModel, TValue>(Expression<Func<TModel, TValue>> expression)
        {
            var body = (MemberExpression)expression.Body;
            return body.Member.Name;
        }

        /// <summary>
        /// Getproperties the name.
        /// </summary>
        /// <param name="expression">The expression lamda.</param>
        /// <returns></returns>
        private static ttAttribute getpropertyAttirube<TModel, TValue, ttAttribute>(Expression<Func<TModel, TValue>> expression) where ttAttribute : System.Attribute
        {
            var Proexpression = (MemberExpression)expression.Body;
            var propertyInfo = (PropertyInfo)Proexpression.Member;
            var attr = propertyInfo.GetCustomAttributes(typeof(ttAttribute), true).FirstOrDefault() as ttAttribute;
            return attr;
        }

        private static Expression<Func<TModel, T>> GenerateMemberExpression<TModel, T>(string propertyName)
        {
            var propertyInfo = typeof(TModel).GetProperty(propertyName);

            var entityParam = Expression.Parameter(typeof(TModel), "e");
            Expression columnExpr = Expression.Property(entityParam, propertyInfo);

            if (propertyInfo.PropertyType != typeof(T))
                columnExpr = Expression.Convert(columnExpr, typeof(T));

            return Expression.Lambda<Func<TModel, T>>(columnExpr, entityParam);
        }

        #endregion basic method

        #region basically

        /// <summary>
        /// Forms the model.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="html">The HTML.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="Forms">The forms.</param>
        /// <returns></returns>
        public static MvcHtmlString FormModel<TModel>(this HtmlHelper<TModel> html, TModel expression, Forms Forms)
        {
            String theeditor = String.Empty;
            object queryvalue = null;

            foreach (var property in expression.GetType().GetProperties())
            {
                var name = property.Name;
                PropertyInfo pInfo = typeof(TModel).GetProperty(name);
                ParameterExpression paramExpr = Expression.Parameter(typeof(TModel));
                MemberExpression propertyAccess = Expression.MakeMemberAccess(paramExpr, pInfo);

                System.Type propertyType = pInfo.PropertyType;

                // convert the value appropriately
                if (propertyType == typeof(System.Int32))
                {
                    var lambdaExpr = Expression.Lambda<Func<TModel, Int32>>(propertyAccess, paramExpr);
                    theeditor += html.Form(lambdaExpr, Forms);
                }
                if (property.PropertyType == typeof(DateTime))
                {
                    var lambdaExpr = Expression.Lambda<Func<TModel, DateTime>>(propertyAccess, paramExpr);
                    theeditor += html.Form(lambdaExpr, Forms);
                }
                if (property.PropertyType == typeof(Double))
                {
                    var lambdaExpr = Expression.Lambda<Func<TModel, Double>>(propertyAccess, paramExpr);
                    theeditor += html.Form(lambdaExpr, Forms);
                }
                if (property.PropertyType == typeof(String))
                {
                    var lambdaExpr = Expression.Lambda<Func<TModel, String>>(propertyAccess, paramExpr);
                    theeditor += html.Form(lambdaExpr, Forms);
                }
                if (property.PropertyType == typeof(Boolean))
                {
                    var lambdaExpr = Expression.Lambda<Func<TModel, Boolean>>(propertyAccess, paramExpr);
                    theeditor += html.Form(lambdaExpr, Forms);
                }
                if (property.PropertyType.IsEnum)
                {
                    theeditor += html.Form2(property, Forms, false);
                }
                if (propertyType.IsGenericType)
                {
                    theeditor += html.Form2(property, Forms, true);
                }
            }
            return new MvcHtmlString(theeditor.ToString());
        }

        /// <summary>
        /// Forms the specified expression.
        /// </summary>
        /// <param name="html">The HTML.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="Forms">The forms.</param>
        /// <returns></returns>
        public static MvcHtmlString Form<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, Forms Forms)
        {
            String propertyName = getpropertyName(expression);
            //* get Attribute *//
            var body = (MemberExpression)expression.Body;
            //    bool hasRequiredAttribute = body.Member.GetCustomAttributes(typeof(RequiredAttribute), false).Length > 0;
            String msgerror = " erorr hasRequiredAttribute";
            var property = PropertyHelper<TModel>.GetProperty(expression);
            var hasRequiredAttribute = System.Attribute.IsDefined(property, typeof(RequiredAttribute));
            // msgerror = checkmsg(hasRequiredAttribute, msgerror);
            var hasMaxLength = System.Attribute.IsDefined(property, typeof(MaxLengthAttribute));

            String theeditor = String.Empty;

            String Label = html.GetLabel(expression).ToHtmlString();
            String Input = html.GetInput(expression).ToHtmlString();
            String Validation = html.GetValidation(expression, Forms.ErrorType.ToString()).ToHtmlString();
            if (Forms.Position == PositionDIV.Vertical)
            {
                if (Forms.ErrorPosition == ErrorPosition.Align)
                {
                    theeditor += html.RawGenerateDIVPosition(expression, Label, Input, Validation, PositionDIV.Vertical.ToString(), true).ToHtmlString();
                }
                else
                {
                    if (Forms.ErrorPosition == ErrorPosition.Top)
                    {
                        theeditor += html.RawGenerateDIVPosition(expression, Label, Validation, Input, PositionDIV.Vertical.ToString(), false).ToHtmlString();
                    }
                    if (Forms.ErrorPosition == ErrorPosition.Bottom)
                    {
                        theeditor += html.RawGenerateDIVPosition(expression, Label, Input, Validation, PositionDIV.Vertical.ToString(), false).ToHtmlString();
                    }
                }
            }
            else
            {
                if (Forms.ErrorPosition == ErrorPosition.Align)
                {
                    theeditor += html.RawGenerateDIVPosition(expression, Label, Input, Validation, PositionDIV.Horizontal.ToString(), true).ToHtmlString();
                }
                else
                {
                    if (Forms.ErrorPosition == ErrorPosition.Top)
                    {
                        theeditor += html.RawGenerateDIVPosition(expression, Label, Validation, Input, PositionDIV.Horizontal.ToString(), false).ToHtmlString();
                    }
                    if (Forms.ErrorPosition == ErrorPosition.Bottom)
                    {
                        theeditor += html.RawGenerateDIVPosition(expression, Label, Input, Validation, PositionDIV.Horizontal.ToString(), false).ToHtmlString();
                    }
                }
            }
            if (Forms.Border == true)
            {
                theeditor += "<style type='text/css'> /* Styles for validation helpers*/ .field-validation-error { color: #ff0000; }  .field-validation-valid { display: none; } .input-validation-error { border: 1px solid #ff0000 !important; background-color: #ffeeee !important; } .validation-summary-errors { font-weight: bold !important; color: #ff0000 !important; } .validation-summary-valid { display: none; }</style>";
            }
            if (Forms.ErrorType == RootHelpers.ErrorType.Alert)
            {
                theeditor += "<style type='text/css'>  .field-validation-error {color: #721c24; background-color: #f8d7da; border-color: #f5c6cb;}</style>";
            }

            return new MvcHtmlString(theeditor.ToString());
        }

        /// <summary>
        /// Dispay Checkboxes, Radio Buttons, Dropdowns
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <param name="html">The HTML.</param>
        /// <param name="property">The property.</param>
        /// <param name="Forms">The forms.</param>
        /// <param name="isList">The is list.</param>
        /// <returns>MvcHtmlString.</returns>
        internal static MvcHtmlString Form2<TModel>(this HtmlHelper<TModel> html, PropertyInfo property, Forms Forms, Boolean isList)
        {
            String theeditor = String.Empty;
             object[] attrs = property.GetCustomAttributes(true);
            ControlType ControlType = new ControlType();
            foreach (object attr in attrs)
            {
                RootHelpers.Attribute.ControlAttribute authAttr = attr as RootHelpers.Attribute.ControlAttribute;
                if (authAttr != null)
                {
                    ControlType = authAttr.ControlType;
                }
            }
            List<String> listitem = new List<string>();
            //get common type
            System.Type dynamicType = property.PropertyType;

            if (isList)
            {
               var myObject = ModelMetadata.FromStringExpression(property.Name, html.ViewData).Model;
                var memberInfos = (List<RootDropDownList>)myObject;
                if (ControlType == ControlType.DropDownListwithImage)
                {
                    return new MvcHtmlString(html.DropDownListwithImage(property.Name, memberInfos).ToHtmlString());
                }
                if (ControlType == ControlType.DropDownList)
                {
                    return new MvcHtmlString(html.RootDropDownList(property.Name, listitem).ToHtmlString());
                }
            }
            else
            {
                MemberInfo[] memberInfos = dynamicType.GetMembers(BindingFlags.Public | BindingFlags.Static);
                foreach (MemberInfo propertyInfo in memberInfos)
                {
                    object[] attrs2 = propertyInfo.GetCustomAttributes(true);
                    String NamepropertyInfo = propertyInfo.Name;
                    listitem.Add(NamepropertyInfo);
                }
            }



            if (ControlType == ControlType.CheckBox)
            {
                return new MvcHtmlString(html.RootCheckBox(property.Name, listitem).ToHtmlString());
            }

            if (ControlType == ControlType.RadioButton)
            {
                return new MvcHtmlString(html.RootRadioBox(property.Name, listitem).ToHtmlString());
            }

            return new MvcHtmlString(theeditor.ToString());
        }

        internal static MvcHtmlString RawGenerateDIVPosition<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, String StringLabel, String Composanttop, String CompsantBotton, String Position, Boolean ErrorPositionAlign)
        {
            String propertyName = getpropertyName(expression);
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine("<div class='form-group row' style='" + ((Position == PositionDIV.Horizontal.ToString() && GENERAL.Tools.ItEnglish()) ? "  direction: rtl; " : "") + "'>");
            retour.AppendLine("<div class='col-sm-12 row'>");
            if (Position == PositionDIV.Vertical.ToString())
            {
                retour.AppendLine(StringLabel);
            }
            else
            {
                retour.AppendLine(String.Format("<div class='col-sm-4'>{0}</div>", StringLabel));
            }
            // div bettween input & validation
            retour.AppendLine("<div class='col-sm-" + (Position == PositionDIV.Vertical.ToString() ? "12" : "8") + "'>");
            /////  dans le cas  ErrorPosition Align
            if (ErrorPositionAlign)
            {
                //// add composant on top  col-8
                retour.AppendLine("<div class='col-sm-8'>");
                retour.AppendLine(Composanttop);
                retour.AppendLine("</div>");

                //// add composant on botton col-4
                retour.AppendLine("<div class='col-sm-4'>");
                retour.AppendLine(CompsantBotton);
                retour.AppendLine("</div>");
            }
            else
            {
                ///// else ErrorPosition n'est pas Align
                retour.AppendLine(Composanttop);
                retour.AppendLine(CompsantBotton);
            }
            retour.AppendLine("</div>");
            retour.AppendLine("</div>");
            retour.AppendLine("</div>");
            retour.AppendLine("</div>");
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        #endregion basically

        #region GetLabel

        public static MvcHtmlString GetLabel<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            String propertyName = getpropertyName(expression);
            var translate = html.Translate(propertyName).ToHtmlString();
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine("<div class='col-sm-12'>");
            retour.AppendLine("<div class='col-sm-12 " + GENERAL.Tools.GetPostitionText() + "''>");
            retour.AppendLine($"<label class='col-sm-4 control-label pt-2'>{ (String.IsNullOrEmpty(translate) ? propertyName : translate)} </label>");
            retour.AppendLine("</div>");
            retour.AppendLine("</div>");
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        #endregion GetLabel

        #region GetValidation

        public static MvcHtmlString GetValidation<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, String ErrorType)
        {
            String propertyName = getpropertyName(expression);
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine("<div class='col-sm-12 '>");
            retour.AppendLine($"<div data-valmsg-for={propertyName} data-valmsg-replace='true' class=\"validation-summary  col-sm-12 " + GENERAL.Tools.GetPostitionText() + " " + ((ErrorType == RootHelpers.ErrorType.Alert.ToString()) ? " " : "text-danger") + "   text-left \">");
            retour.AppendLine("</div>");
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        #endregion GetValidation

        #region Get Input

        /// <summary>
        /// Bootstrap supports all the HTML5 input types: text, password, datetime, datetime-local, date, month, time, week, number, email, url, search, tel, and color.
        /// </summary>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString GetInput<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            var getproperty = getpropertyAttirube<TModel, TValue, RootHelpers.Attribute.ControlAttribute>(expression);

            if (getproperty.ControlType == ControlType.TextBox)
            {
                return new MvcHtmlString(html.RootTextBox(expression).ToHtmlString());
            }
            if (getproperty.ControlType == ControlType.Email)
            {
                return new MvcHtmlString(html.RootEmail(expression).ToHtmlString());
            }
            if (getproperty.ControlType == ControlType.Upload)
            {
                return new MvcHtmlString(html.RootFileUpload(expression).ToHtmlString());
            }
            if (getproperty.ControlType == ControlType.Password)
            {
                return new MvcHtmlString(html.RootPassword(expression).ToHtmlString());
            }
            if (getproperty.ControlType == ControlType.TextArea)
            {
                return new MvcHtmlString(html.RootTextArea(expression).ToHtmlString());
            }
            if (getproperty.ControlType == ControlType.Number)
            {
                return new MvcHtmlString(html.RootNumber(expression).ToHtmlString());
            }
            if (getproperty.ControlType == ControlType.DatePicker)
            {
                return new MvcHtmlString(html.Rootdate(expression).ToHtmlString());
            }
            if (getproperty.ControlType == ControlType.TimePicker)
            {
                return new MvcHtmlString(html.RootTime(expression).ToHtmlString());
            }


            return new MvcHtmlString("");
        }

        #region TextBox input

        /// <summary>
        /// Roots the text box.
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <typeparam name="TValue">The type of the t value.</typeparam>
        /// <param name="html">The HTML.</param>
        /// <param name="expression">The expression.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString RootTextBox<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            String propertyName = getpropertyName(expression);
            var translate = html.Translate(propertyName).ToHtmlString();

            // get value de l'expression
            Func<TModel, TValue> method = expression.Compile();
            TValue value = method(html.ViewData.Model);

            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine("<div class='col-sm-12'>");
            retour.AppendLine($"<input type = 'text'  style='max-width: 100%;' data-val='true' name='{propertyName}' class='form-control  " + GENERAL.Tools.GetPostitionText() + "' data-val-required='The Email field is required.' placeholder='" + html.ViewData.ModelMetadata.DisplayName + "'  value='" + value + "'>");
            retour.AppendLine("</div>");
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        #endregion TextBox input

        #region TextArea input

        /// <summary>
        /// The textarea is used when you need multiple lines of input.
        /// </summary>
        /// <returns></returns>
        public static MvcHtmlString RootTextArea<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            String propertyName = getpropertyName(expression);
            var translate = html.Translate(propertyName).ToHtmlString();

            // get value de l'expression
            Func<TModel, TValue> method = expression.Compile();
            TValue value = method(html.ViewData.Model);

            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine("<div class='col-sm-12'>");
            retour.AppendLine($"<textarea  style='max-width: 100%;' data-val='true' name='{propertyName}' class='form-control  " + GENERAL.Tools.GetPostitionText() + "' data-val-required='The Email field is required.' > " + value + "</textarea>");
            retour.AppendLine("</div>");
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        #endregion TextArea input


        #region file upload input

        /// <summary>
        /// Roots the file upload.
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <typeparam name="TValue">The type of the t value.</typeparam>
        /// <param name="html">The HTML.</param>
        /// <param name="expression">The expression.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString RootFileUpload<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            String propertyName = getpropertyName(expression);
            var translate = html.Translate(propertyName).ToHtmlString();

            // get value de l'expression
            Func<TModel, TValue> method = expression.Compile();
            TValue value = method(html.ViewData.Model);

            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine("<div class='col-sm-12'>");
            retour.AppendLine($"<input type = 'file'  style='max-width: 100%;' data-val='true' name='{propertyName}' class='form-control  " + GENERAL.Tools.GetPostitionText() + "' data-val-required='The Email field is required.' >");
            retour.AppendLine("</div>");
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        #endregion file upload input

        #region Email input

        /// <summary>
        /// Roots the email.
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <typeparam name="TValue">The type of the t value.</typeparam>
        /// <param name="html">The HTML.</param>
        /// <param name="expression">The expression.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString RootEmail<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            String propertyName = getpropertyName(expression);
            var translate = html.Translate(propertyName).ToHtmlString();

            // get value de l'expression
            Func<TModel, TValue> method = expression.Compile();
            TValue value = method(html.ViewData.Model);

            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine("<div class='col-sm-12'>");
            retour.AppendLine($"<input type = 'email'  style='max-width: 100%;' data-val='true' name='{propertyName}' class='form-control  " + GENERAL.Tools.GetPostitionText() + "' data-val-required='The Email field is required.' placeholder='" + html.ViewData.ModelMetadata.DisplayName + "'  value='" + value + "'>");
            retour.AppendLine("</div>");
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        #endregion Email input

        #region Password Input

        /// <summary>
        /// Roots the password.
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <typeparam name="TValue">The type of the t value.</typeparam>
        /// <param name="html">The HTML.</param>
        /// <param name="expression">The expression.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString RootPassword<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            String propertyName = getpropertyName(expression);
            var translate = html.Translate(propertyName).ToHtmlString();

            // get value de l'expression
            Func<TModel, TValue> method = expression.Compile();
            TValue value = method(html.ViewData.Model);

            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine("<div class='col-sm-12'>");
            retour.AppendLine($"<input type = 'password'  style='max-width: 100%;' data-val='true' name='{propertyName}' class='form-control  " + GENERAL.Tools.GetPostitionText() + "' data-val-required='The Email field is required.' placeholder='" + html.ViewData.ModelMetadata.DisplayName + "'  value='" + value + "'>");
            retour.AppendLine("</div>");
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        #endregion Password Input

  
      

        #region Number Input

        /// <summary>
        /// Roots the number.
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <typeparam name="TValue">The type of the t value.</typeparam>
        /// <param name="html">The HTML.</param>
        /// <param name="expression">The expression.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString RootNumber<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            String propertyName = getpropertyName(expression);
            var translate = html.Translate(propertyName).ToHtmlString();

            // get value de l'expression
            Func<TModel, TValue> method = expression.Compile();
            TValue value = method(html.ViewData.Model);

            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine("<div class='col-sm-12'>");
            retour.AppendLine($"<input type = 'number'  style='max-width: 100%;' data-val='true' name='{propertyName}' class='form-control  " + GENERAL.Tools.GetPostitionText() + "' data-val-required='The Email field is required.' placeholder='" + html.ViewData.ModelMetadata.DisplayName + "'  value='" + value + "'>");
            retour.AppendLine("</div>");
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        #endregion Number Input

        #region date Picker Input

        /// <summary>
        /// Rootdates the specified expression.
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <typeparam name="TValue">The type of the t value.</typeparam>
        /// <param name="html">The HTML.</param>
        /// <param name="expression">The expression.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString Rootdate<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            String propertyName = getpropertyName(expression);
            var translate = html.Translate(propertyName).ToHtmlString();

            // get value de l'expression
            Func<TModel, TValue> method = expression.Compile();
            TValue value = method(html.ViewData.Model);

            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine("<div class='col-sm-12'>");
            retour.AppendLine($"<input type = 'date'  style='max-width: 100%;' data-val='true' name='{propertyName}' class='form-control  " + GENERAL.Tools.GetPostitionText() + "' data-val-required='The Email field is required.' placeholder='" + html.ViewData.ModelMetadata.DisplayName + "'  value='" + value + "'>");
            retour.AppendLine("</div>");
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        #endregion date Picker Input

        #region time Picker Input

        /// <summary>
        /// Roots the time.
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <typeparam name="TValue">The type of the t value.</typeparam>
        /// <param name="html">The HTML.</param>
        /// <param name="expression">The expression.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString RootTime<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            String propertyName = getpropertyName(expression);
            var translate = html.Translate(propertyName).ToHtmlString();

            // get value de l'expression
            Func<TModel, TValue> method = expression.Compile();
            TValue value = method(html.ViewData.Model);

            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine("<div class='col-sm-12'>");
            retour.AppendLine($"<input type = 'time'  style='max-width: 100%;' data-val='true' name='{propertyName}' class='form-control  " + GENERAL.Tools.GetPostitionText() + "' data-val-required='The Email field is required.' placeholder='" + html.ViewData.ModelMetadata.DisplayName + "'  value='" + value + "'>");
            retour.AppendLine("</div>");
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        #endregion time Picker Input

 
        
        #region DropDownList Input

        /// <summary>
        /// A DropDownList is used when you want to allow the user to pick from multiple options, but by default it only allows one.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="listitem">The listitem.</param>
        /// <returns></returns>
        public static MvcHtmlString RootDropDownList<TModel>(this HtmlHelper<TModel> html, String propertyName, List<String> listitem)
        {
            StringBuilder retour = new StringBuilder();
            retour.AppendLine("<select class='form-control' id='" + propertyName + "' name='" + propertyName + "' style='height: 46px; '>");
            retour.AppendLine("<option> -- Select -- </option>");

            foreach (var item in listitem)
            {
                retour.Append(String.Format("<option " + item + ">{0}</option>", item));
            }

            retour.AppendLine("</select>");

            return new MvcHtmlString(retour.ToString());
        }


        /// <summary>
        /// A DropDownList is used when you want to allow the user to pick from multiple options, but by default it only allows one.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="listitem">The listitem.</param>
        /// <returns></returns>
        public static MvcHtmlString DropDownListwithImage<TModel>(this HtmlHelper<TModel> html, String propertyName, List<RootDropDownList> listitem)
        {
            StringBuilder retour = new StringBuilder();
            retour.AppendLine("<div class='" + propertyName + "' id='" + propertyName + "'><a><img src=" + listitem[0].pathimage + " class='imgDisplay' /><p class='imageText'>" + listitem[0].Name + "</p><i class='fa fa-angle-down' aria-hidden='true'></i></a></div>");
            retour.AppendLine("<ul class='" + propertyName + "' id='ul" + propertyName + "' style='display: none; '>");
            int i =0;
            foreach (var item in listitem)
            {
                retour.Append(String.Format("<li id='{0}'><a><img src={1} class='imgDisplay' /><p class='imageText'>{2}</p></a></li>", i,item.pathimage,item.Name));
                i++;
            }

            retour.AppendLine("</ul>");
            retour.AppendLine("<style> .imgDisplay { display: inline; vertical-align: middle; width: 50px; height: 50px;} .imageText { display: inline; vertical-align: middle; padding-left: 5px; } ." + propertyName + " {/* border: 1px solid black; */ background-repeat: no-repeat; background-position: right; margin: 0; cursor: pointer; align-content: center; list-style-type: none; } .ul" + propertyName + " { display: none; /*hide dropdown by default*/ width: 120px; background-color: white; border: 1px solid black; border-top: none; margin: 0; padding: 0; position: absolute; } .ul" + propertyName + " li { border-top: 1px solid gray; height: 22px; } .ul" + propertyName + " li:hover { background-color: lightblue; cursor: pointer; } </style>");
            retour.AppendLine("<script src='https://code.jquery.com/jquery-3.3.1.min.js'></script>");
            retour.AppendLine("<script>$(document).ready(function () {");
            retour.AppendLine("$('#" + propertyName + "').click(function () { var dropDwn = $(this).next(); if (dropDwn.is(':visible')) dropDwn.hide(); else dropDwn.show(); })");
            retour.AppendLine("$('#ul" + propertyName + " li').click(function () { var cmbBox = $(this).parent().prev(); cmbBox.html($(this).html()); $(this).parent().hide(); });");
            retour.AppendLine("$(document).on('click', function (e) { var element, evt = e ? e : event; if (evt.srcElement) element = evt.srcElement; else if (evt.target) element = evt.target; if (element.className != " + propertyName + ") { $('ul" + propertyName + "').hide(); } });});");
            retour.AppendLine("</script>");


            return new MvcHtmlString(retour.ToString());
        }

        #endregion DropDownList Input


        #region RadioBox Input

        /// <summary>
        /// use RadioBox if you want to limit the user to just one selection.
        /// </summary>
        /// <remarks>Checkboxes and radio buttons are great when you want users to choose from a list of preset options.</remarks>
        /// <param name="Htmlhelper"></param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="listitem">The listitem.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString RootRadioBox<TModel>(this HtmlHelper<TModel> Htmlhelper, String propertyName, List<String> listitem)
        {
            // get translate of this property from resources file
            var translate = Htmlhelper.Translate(propertyName).ToHtmlString();
            // create global div when will contain all the RadioBox components
            var contentDivGlobal = new TagBuilder("div");
            contentDivGlobal.AddCssClass("col-sm-12");
            contentDivGlobal.InnerHtml += propertyName + "<br>";

            // browse all list items to create for each RadioBox input
            foreach (var item in listitem)
            {
                // create local div when will contain this the RadioBox component
                var contentDiv = new TagBuilder("div");
                contentDiv.AddCssClass("col-sm-12 row");
                contentDiv.MergeAttribute("style", (GENERAL.Tools.ItEnglish() ? "  direction: rtl; " : ""));
                // create this the label component
                var label = new TagBuilder("label ");
                label.MergeAttribute("for", item);
                label.AddCssClass("col-sm-4");
                //******************************  !!!! translate item   !!!!***********************************///
                var translateitem = Htmlhelper.Translate(item).ToHtmlString();
                label.InnerHtml += item;

                // create this the RadioBox component
                var input = new TagBuilder("input");
                input.AddCssClass("form-control col-sm-1");
                // added the specific attributes for <input>
                input.MergeAttribute("id", item);
                input.MergeAttribute("name", propertyName);
                input.MergeAttribute("type", "radio");
                input.MergeAttribute("style", "max-width: 100%;");
                input.MergeAttribute("data-val", "true");
                input.MergeAttribute("value", item);
                // add this RadioBox component in this local div
                contentDiv.InnerHtml += label;
                contentDiv.InnerHtml += input;
                // add this RadioBox component in this global div
                contentDivGlobal.InnerHtml += contentDiv;
            }
            return new MvcHtmlString(contentDivGlobal.ToString());
        }

        #endregion RadioBox Input

        #region CheckBox Input

        /// <summary>
        /// CheckBox helper method renders a checkbox and has the name and id that you specify.
        /// </summary>
        /// <remarks>
        /// Checkboxes and radio buttons are great when you want users to choose from a list of preset options.
        /// use checkbox if you want the user to select any number of options from a list.
        /// </remarks>
        /// <param name="Htmlhelper">HTML Helpers are used in View to render HTML content.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="listitem">The listitem.</param>
        /// <returns></returns>
        public static MvcHtmlString RootCheckBox<TModel>(this HtmlHelper<TModel> Htmlhelper, String propertyName, List<String> listitem)
        {
            // get translate of this property from resources file
            var translate = Htmlhelper.Translate(propertyName).ToHtmlString();
            // create global div when will contain all the Checkbox components
            var contentDivGlobal = new TagBuilder("div");
            contentDivGlobal.AddCssClass("col-sm-12");
            contentDivGlobal.InnerHtml += propertyName +"<br>";

            // browse all list items to create for each CheckBox input
            foreach (var item in listitem)
            {
                // create local div when will contain this the Checkbox component
                var contentDiv = new TagBuilder("div");
                contentDiv.AddCssClass("col-sm-12 row");
                contentDiv.MergeAttribute("style",(GENERAL.Tools.ItEnglish() ? "  direction: rtl; " : ""));
                // create this the label component
                var label = new TagBuilder("label ");
                label.MergeAttribute("for", item);
                label.AddCssClass("col-sm-4");
                //******************************  !!!! translate item   !!!!***********************************///
                var translateitem = Htmlhelper.Translate(item).ToHtmlString();
                label.InnerHtml += item; 

                // create this the Checkbox component
                var input = new TagBuilder("input");
                input.AddCssClass("form-control col-sm-1");
                // added the specific attributes for <input>
                input.MergeAttribute("id", item);
                input.MergeAttribute("name", propertyName);
                input.MergeAttribute("type", "checkbox");
                input.MergeAttribute("style", "max-width: 100%;");
                input.MergeAttribute("data-val", "true");
                input.MergeAttribute("value", item);
                // add this Checkbox component in this local div
                contentDiv.InnerHtml += label;
                contentDiv.InnerHtml += input;
                // add this Checkbox component in this global div
                contentDivGlobal.InnerHtml += contentDiv;
            }
            return new MvcHtmlString(contentDivGlobal.ToString()); 
        }

        #endregion CheckBox Input

        #endregion Get Input

    }
}

public static class PropertyHelper<T>
{
    public static PropertyInfo GetProperty<TValue>(
        Expression<Func<T, TValue>> selector)
    {
        Expression body = selector;
        if (body is LambdaExpression)
        {
            body = ((LambdaExpression)body).Body;
        }
        switch (body.NodeType)
        {
            case ExpressionType.MemberAccess:
                return (PropertyInfo)((MemberExpression)body).Member;

            default:
                throw new InvalidOperationException();
        }
    }
}