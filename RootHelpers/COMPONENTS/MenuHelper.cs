using System;
using System.Web.Mvc;

namespace RootHelpers
{
    /// <summary>
    /// Menu current active item helper class.
    /// </summary>
    public static class MenuHelper
    {
        /// <summary>
        /// Determines whether the specified controller is selected.
        /// </summary>
        /// <param name="html">The HTML.</param>
        /// <param name="controller">The controller.</param>
        /// <param name="action">The action.</param>
        /// <param name="cssClass">The CSS class.</param>
        /// <returns></returns>
        public static string IsSelected(this HtmlHelper html, string controller = null, string action = null, string cssClass = "selected")
        {
            // const string cssClass = "selected";
            var currentAction = (string)html.ViewContext.RouteData.Values["action"];
            var currentController = (string)html.ViewContext.RouteData.Values["controller"];

            if (String.IsNullOrEmpty(controller))
                controller = currentController;

            if (String.IsNullOrEmpty(action))
                action = currentAction;

            return controller == currentController && action == currentAction ?
                cssClass : String.Empty;
        }

        public static Boolean IsSelected(this HtmlHelper html, string controller = null, string action = null)
        {
            var currentAction = (string)html.ViewContext.RouteData.Values["action"];
            var currentController = (string)html.ViewContext.RouteData.Values["controller"];

            if (String.IsNullOrEmpty(controller))
                controller = currentController;

            if (String.IsNullOrEmpty(action))
                action = currentAction;

            return controller == currentController && action == currentAction ?
                true : false;
        }

        /// <summary>
        /// Styles the is selected.
        /// </summary>
        /// <param name="html">The HTML.</param>
        /// <param name="controller">The controller.</param>
        /// <param name="action">The action.</param>
        /// <param name="cssClass">The CSS class.</param>
        /// <returns></returns>
        public static string StyleIsSelected(this HtmlHelper html, string controller = null, string action = null, string cssClass = "display: block;")
        {
            // const string cssClass = "selected";
            var currentAction = (string)html.ViewContext.RouteData.Values["action"];
            var currentController = (string)html.ViewContext.RouteData.Values["controller"];

            if (String.IsNullOrEmpty(controller))
                controller = currentController;

            if (String.IsNullOrEmpty(action))
                action = currentAction;

            return controller == currentController && action == currentAction ?
                cssClass : String.Empty;
        }

        /// <summary>
        /// Saycheckeds the specified valeur.
        /// </summary>
        /// <param name="valeur">The valeur.</param>
        /// <param name="valeurvoulu">The valeurvoulu.</param>
        /// <param name="contain">if set to <c>true</c> [contain].</param>
        /// <returns></returns>
        public static string saychecked(string valeur, string valeurvoulu, bool contain = false)
        {
            if (valeur == null) valeur = "";
            if (valeurvoulu == null) valeurvoulu = "";
            if (contain && valeur.ToLower().Contains(valeurvoulu.ToLower())) return "checked";
            if (valeur.ToLower() == valeurvoulu.ToLower()) return "checked";
            else return "";
        }

        /// <summary>
        /// Sayselecteds the specified valeur.
        /// </summary>
        /// <param name="valeur">The valeur.</param>
        /// <param name="valeurvoulu">The valeurvoulu.</param>
        /// <param name="contain">if set to <c>true</c> [contain].</param>
        /// <returns></returns>
        public static string sayselected(string valeur, string valeurvoulu, bool contain = false)
        {
            if (valeur == null) valeur = "";
            if (valeurvoulu == null) valeurvoulu = "";
            if (contain && valeur.ToLower().Contains(valeurvoulu.ToLower())) return "selected";
            if (valeur.ToLower() == valeurvoulu.ToLower()) return "selected";
            else return "";
        }

        /// <summary>
        /// Sayactives the specified valeur.
        /// </summary>
        /// <param name="valeur">The valeur.</param>
        /// <param name="valeurvoulu">The valeurvoulu.</param>
        /// <param name="contain">if set to <c>true</c> [contain].</param>
        /// <returns></returns>
        public static string sayactive(string valeur, string valeurvoulu, bool contain = false)
        {
            if (valeur == null) valeur = "";
            if (valeurvoulu == null) valeurvoulu = "";
            if (contain && valeur.ToLower().Contains(valeurvoulu.ToLower())) return "active";
            else if (valeur.ToLower() == valeurvoulu.ToLower()) return "active";
            else return "";
        }
    }
}