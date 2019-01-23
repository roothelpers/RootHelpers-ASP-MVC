using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace RootHelpers.TOOLS
{
    /// <summary>
    /// Aide & accesseur pour les vues
    /// </summary>
    public class LayoutManager
    {
        private readonly System.Web.Mvc.TempDataDictionary _temp = null; // !!! améliorer en passant un context plus large

        private List<BreadcrumbData> _breadcrumbList;

        public System.Diagnostics.Stopwatch watchTimeInitPage = null;

        public string AreaName = null;
        public string ActionName = null;
        public string ControllerName = null;

        /// <summary>
        /// Constructeur simplifié
        /// </summary>
        /// <param name="temp"></param>
        public LayoutManager(TempDataDictionary temp)
        {
            this._temp = temp;
            _breadcrumbList = new List<BreadcrumbData>();
        }

        /// <summary>
        /// Constructeur complet
        /// </summary>
        /// <param name="controller"></param>
        public LayoutManager(Controller controller)
        {
            this._temp = controller.TempData;
            _breadcrumbList = new List<BreadcrumbData>();
            try
            {
                this.ActionName = controller.RouteData.GetRequiredString("action");
                this.ControllerName = controller.RouteData.GetRequiredString("controller");
                this.AreaName = controller.RouteData.GetRequiredString("area");
            }
            catch { }
        }

        public void AddMsgAlert(string message)
        {
            this._temp.Add("MsgAlert", message);
        }

        public void AlertMsgStay(string texte, int level = 1, bool ErrorAlertJS = false)
        {
            AlertMsgData alert = new AlertMsgData()
            {
                Message = texte,
                Level = level,
                JsAlert = ErrorAlertJS
            };

            if (_temp != null)
                _temp["AlertMsgStay"] = alert;
        }

        public void BreadcrumbAdd(string libelle, int position, string url = null)
        {
            _breadcrumbList.Add(new BreadcrumbData()
            {
                Libelle = libelle,
                Postition = position,
                Url = url
            });
        }

        #region RenduHtml

        public string GetAlertMsgHtml()
        {
            try
            {
                AlertMsgData alert = null;
                if (_temp != null)
                    alert = _temp["AlertMsgStay"] as AlertMsgData;

                if (alert == null)
                    return "";

                _temp["AlertMsgStay"] = null;

                string retour = "";

                if (alert.Level == 0 || alert.Level == 1) retour = "<div class=\"alert alert-info\">" + alert.Message + "</div>";
                else if (alert.Level == 2) retour = "<div class=\"alert alert-success\">" + alert.Message + "</div>";
                else if (alert.Level == 3) retour = "<div class=\"alert alert-warning\">" + alert.Message + "</div>";
                else if (alert.Level == 4 || alert.Level == 5) retour = "<div class=\"alert alert-danger\">" + alert.Message + "</div>";
                if (alert.JsAlert) retour += "<script> alert(\"Une erreur s'est produite !\");</script>";

                return retour;
            }
            catch (Exception)
            {
                return "<div class='alert alert-warning'><b>Ooops</b> Incident sur l'affichage des notifications</div>";
            }
        }

        public string GetBreadCrumbHtml()
        {
            try
            {
                if (_breadcrumbList == null || _breadcrumbList.Count == 0) return "";

                StringBuilder retour = new StringBuilder();
                retour.Append("<ol class=\"breadcrumb\"><span class=\"glyphicon glyphicon-home\"></span>");
                foreach (BreadcrumbData breadcrumbData in _breadcrumbList.OrderBy(b => b.Postition))
                {
                    if (breadcrumbData.Url != "")
                        retour.AppendFormat("<li><a href=\"{0}\">{1}</a></li>", breadcrumbData.Url, breadcrumbData.Libelle);
                    else
                        retour.AppendFormat("<li class=\"active\">{0}</li>", breadcrumbData.Libelle);
                }
                retour.Append("</ol>");
                return retour.ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }

        public HtmlString GenerateAlertBloc()
        {
            if (this._temp["MsgAlert"] == null) return null;
            object msg = this._temp["MsgAlert"];
            if (msg == null) return null;
            string retour = "<div class='alert alert-danger' role='alert'>" + msg.ToString() + "</div>";
            return new HtmlString(retour);
        }

        #endregion RenduHtml

        private class AlertMsgData
        {
            public string Message { get; set; }

            public int Level { get; set; }

            public bool JsAlert { get; set; }
        }

        private class BreadcrumbData
        {
            public string Libelle { get; set; }

            public string Url { get; set; }

            public int Postition { get; set; }
        }
    }
}