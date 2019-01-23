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
    public static class DataTableHelper
    {
        /// <summary>
        /// Raws the table.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="showkeys">if set to <c>true</c> [showkeys].</param>
        /// <returns></returns>
        public static MvcHtmlString RawTable<TModel>(this HtmlHelper<TModel> html, System.Data.DataTable table, bool showkeys = false)
        {
            StringBuilder retour = new StringBuilder();
            retour.AppendLine("<table class='table table-striped table-hover' style='border:1px solid #D8D8D8;background-color:#FFFFFF;" + (GENERAL.Tools.ItEnglish() ? "  direction: rtl; " : "") + "' >");
            retour.Append("<thead><tr>");
            foreach (System.Data.DataColumn itemcol in table.Columns)
            {
                //if (forbidenCols.Contains(itemcol.ColumnName)) { continue; }
                //if (ShowOnlyCols != null && !ShowOnlyCols.Contains(itemcol.ColumnName)) { continue; }
                retour.Append("<th style='font-size:x-small;'>" + itemcol.ColumnName + "</th>");
            }

            retour.AppendLine("</tr><thead>");
            retour.AppendLine("<tbody>");
            foreach (System.Data.DataRow row in table.Rows)
            {
                retour.AppendLine(RawLine(row, showkeys).ToString());
            }
            retour.AppendLine("</tbody>");
            retour.AppendLine("</table>");
            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Raws the line.
        /// </summary>
        /// <param name="ligne">The ligne.</param>
        /// <param name="showkeys">if set to <c>true</c> [showkeys].</param>
        /// <returns></returns>
        private static string RawLine(System.Data.DataRow ligne, bool showkeys = false)
        {
            StringBuilder retour = new StringBuilder();

            string colorlign = "color:black;";
            retour.Append("<tr style=''>");

            foreach (System.Data.DataColumn itemcol in ligne.Table.Columns)
            {
                //if (forbidenCols.Contains(itemcol.ColumnName)) { continue; }
                //if (ShowOnlyCols != null && !ShowOnlyCols.Contains(itemcol.ColumnName)) { continue; }
                retour.Append("<td style='font-size:x-small;' >" + ligne[itemcol.ColumnName] + "</td>");
            }

            retour.Append("</tr>");
            return retour.ToString();
        }

        /// <summary>
        /// Raws the generate table clik.
        /// </summary>
        /// <param name="rowDataOnes">The row data ones.</param>
        /// <param name="ShowOnlyCols">The show only cols.</param>
        /// <returns></returns>
        public static MvcHtmlString RawTableExpandable<TModel>(this HtmlHelper<TModel> html, System.Data.DataTable rowDataOnes, List<string> ShowOnlyCols = null)
        {
            //List<string> forbidenCols = new List<string>() { "IDCounter", "Valid", "Valeur" };

            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine("<table class='table table-striped table-hover ' style='border:1px solid #D8D8D8;background-color:#FFFFFF;" + (GENERAL.Tools.ItEnglish() ? "  direction: rtl; " : "") + "'>");
            retour.Append("<thead><tr>");
            int countrowDataOnes = 0;
            foreach (System.Data.DataColumn itemcol in rowDataOnes.Columns)
            {
                countrowDataOnes++;
                if (ShowOnlyCols != null && !ShowOnlyCols.Contains(itemcol.ColumnName)) { continue; }
                retour.Append("<th style='font-size:x-small;'>" + itemcol.ColumnName + "</th>");
            }
            int NbrColSpan = countrowDataOnes - ShowOnlyCols.Count;
            retour.AppendLine("</tr><thead>");
            retour.AppendLine("<tbody>");
            int yidline = 0;
            int uniqueid = 0;
            foreach (System.Data.DataRow row in rowDataOnes.Rows)
            {
                uniqueid++;
                string colorlign = "color:black;";
                //if (stat.Valid) { colorlign = "color:green;"; }
                //else if (stat.join_ValidationObligatoire) { colorlign = "color:brown;"; }

                string formuids = null;
                retour.Append("<tr style=''>");

                foreach (System.Data.DataColumn itemcol in rowDataOnes.Columns)
                {
                    uniqueid++;
                    if (ShowOnlyCols != null && !ShowOnlyCols.Contains(itemcol.ColumnName)) { continue; }
                    if (rowDataOnes.PrimaryKey.Contains(itemcol)) retour.Append("<td style='font-size:x-small;color:gray;' data-columnname='" + itemcol.ColumnName + "' data-yidline='" + yidline + "'>" + row[itemcol.ColumnName] + "</td>");
                    else retour.Append("<td style='font-size:x-small;' id='uniqueid" + uniqueid + "' data-columnname='" + itemcol.ColumnName + "'  '>" + row[itemcol.ColumnName] + "</td>");
                }
              

                retour.AppendLine("</tr>");
                if (NbrColSpan < 0)
                {

                }
                else
                {
                    retour.Append("<td  colspan='" + NbrColSpan + "' ><p class='"+ GENERAL.Tools.GetPostitionText() + "'> ");
                    foreach (System.Data.DataColumn itemcol in rowDataOnes.Columns)
                    {
                        if (ShowOnlyCols != null && ShowOnlyCols.Contains(itemcol.ColumnName)) { continue; }
                        retour.Append("ColumnName" + itemcol.ColumnName + "  : " + row[itemcol.ColumnName] + "<br>");
                    }
                    retour.Append(" <p></td>");
                }
            }
            retour.AppendLine("</tbody>");
            retour.AppendLine("</table>");
            retour.AppendLine("<script>$(function() { $('td[colspan = "+ NbrColSpan + "]').find('p').hide(); $('table').click(function(event) { event.stopPropagation(); var $target = $(event.target); if ( $target.closest('td').attr('colspan') > 1 ) {  } else { $target.closest('tr').next().find('p').slideToggle(); } }); });</script>");

            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }


        /// <summary>
        /// Raws the   table expandable.
        /// </summary>
        /// <param name="rowDataOnes">The row data ones.</param>
        /// <param name="ShowOnlyCols">The show only cols.</param>
        /// <returns></returns>
        public static MvcHtmlString RawGenerateTableClik<TModel>(this HtmlHelper<TModel> html, System.Data.DataTable rowDataOnes, List<string> ShowOnlyCols = null)
        {
            StringBuilder retour = new StringBuilder(); // Unlike a string, a StringBuilder can be changed. With it, an algorithm that modifies characters in a loop runs fast.
            retour.AppendLine("<table class='table table-striped table-hover' style='border:1px solid #D8D8D8;background-color:#FFFFFF;" + (GENERAL.Tools.ItEnglish() ? "  direction: rtl; " : "") + "'>");
            retour.Append("<thead><tr>");
            foreach (System.Data.DataColumn itemcol in rowDataOnes.Columns)
            {
                //if (forbidenCols.Contains(itemcol.ColumnName)) { continue; }
                if (ShowOnlyCols != null && !ShowOnlyCols.Contains(itemcol.ColumnName)) { continue; }
                retour.Append("<th style='font-size:x-small;'>" + itemcol.ColumnName + "</th>");
            }

            retour.AppendLine("</tr><thead>");
            retour.AppendLine("<tbody>");
            int yidline = 0;
            int uniqueid = 0;
            foreach (System.Data.DataRow row in rowDataOnes.Rows)
            {
                uniqueid++;
                string colorlign = "color:black;";
                //if (stat.Valid) { colorlign = "color:green;"; }
                //else if (stat.join_ValidationObligatoire) { colorlign = "color:brown;"; }

                string formuids = null;
                retour.Append("<tr style=''>");

                foreach (System.Data.DataColumn itemcol in rowDataOnes.Columns)
                {
                    uniqueid++;
                    //if (forbidenCols.Contains(itemcol.ColumnName)) { continue; }
                    if (ShowOnlyCols != null && !ShowOnlyCols.Contains(itemcol.ColumnName)) { continue; }
                    if (rowDataOnes.PrimaryKey.Contains(itemcol)) retour.Append("<td style='font-size:x-small;color:gray;' data-columnname='" + itemcol.ColumnName + "' data-yidline='" + yidline + "'>" + row[itemcol.ColumnName] + "</td>");
                    else retour.Append("<td style='font-size:x-small;' id='uniqueid" + uniqueid + "' data-columnname='" + itemcol.ColumnName + "'  onclick='functionName(\"yuniqueid" + uniqueid + "\",\"" + itemcol.ColumnName + "\"," + yidline + ",\"" + row[itemcol.ColumnName] + "\")'>" + row[itemcol.ColumnName] + "</td>");
                }
                /*
                if (!string.IsNullOrWhiteSpace(ValueColName))
                {
                    string valeur = Convert.ToString(row[ValueColName]);
                    if (string.IsNullOrWhiteSpace(formuids)) retour.Append("<td style='font-size:x-small;'><b>" + valeur + "</b></td>");
                    retour.Append(" <input type='text' id='formuids_'" + formuids + "' name='formuids_'" + formuids + "' value='" + valeur + "'  onchange='NeedUpdFormuids(\"formuids_'" + formuids + "\");'  />");
                }
                */
                retour.AppendLine("</tr>");
            }
            retour.AppendLine("</tbody>");
            retour.AppendLine("</table>");
            retour.AppendLine("<script>function functionName(parameter1, parameter2, parameter3, parameter4) { console.log(parameter1,parameter2,parameter3,parameter4); }</script>");

            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Raws the data.
        /// </summary>
        /// <param name="ligne">The ligne.</param>
        /// <param name="showkeys">if set to <c>true</c> [showkeys].</param>
        /// <returns></returns>
        public static MvcHtmlString RawData<TModel>(this HtmlHelper<TModel> html, System.Data.DataRow ligne, bool showkeys = false)
        {
            string retour = "";

            foreach (System.Data.DataColumn itemcol in ligne.Table.Columns)
            {
                if (itemcol.ColumnName.ToLower().Contains("flux")) continue; // trop gros...
                if (!showkeys && ligne.Table.PrimaryKey.Contains(itemcol)) continue; // Interdit de modifier les clefs
                string ColumnName = itemcol.ColumnName;
                string ColumnValue = GetRowString(ligne, itemcol.ColumnName);

                retour += "<div class=\"input-group\"  style=\"margin-left:20px;" + (GENERAL.Tools.ItEnglish() ? "  direction: rtl; " : "") + "\">";
                retour += "<span class=\"input-group-addon\" style=\"width:120px; font-size:x-small;\">" + itemcol.ColumnName + "</span>";

                if (itemcol.DataType.ToString() == "System.Boolean")
                {
                    retour += "<select  class=\"form-control\" name=\"" + ColumnName + "\"  >";
                    retour += "<option value=\"NULL\" " + MenuHelper.sayselected(ColumnValue, "") + ">NULL</option>";
                    retour += "<option value=\"True\" " + MenuHelper.sayselected(ColumnValue, "True") + ">True</option>";
                    retour += "<option value=\"False\" " + MenuHelper.sayselected(ColumnValue, "False") + ">False</option>";
                    retour += "</select>";
                }
                else if (ligne[itemcol.ColumnName] == DBNull.Value)
                {
                    retour += "<input type=\"text\" class=\"form-control\" name=\"" + ColumnName + "\"  placeholder=\"NULL [" + itemcol.DataType + "]\" style='' value='' > ";
                }
                else if (string.IsNullOrWhiteSpace(ColumnValue))
                {
                    retour += "<input type=\"text\" class=\"form-control\" name=\"" + ColumnName + "\"  placeholder=\"Empty [" + itemcol.DataType + "]\" style='' value=\"" + ColumnValue + "\" > ";
                }
                else
                {
                    retour += "<input type=\"text\" class=\"form-control\" name=\"" + ColumnName + "\"   value=\"" + ColumnValue + "\">";
                }

                retour += "<span class=\"input-group-btn\"> <button class=\"btn btn-default\" disabled>.</button></span>";
                retour += " </div>";
            }

            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Raws the data with BTNS.
        /// </summary>
        /// <param name="ligne">The ligne.</param>
        /// <param name="KeysObjets">The keys objets.</param>
        /// <param name="ActionUrl">The action URL.</param>
        /// <returns></returns>
        public static MvcHtmlString RawDataWithBtns<TModel>(this HtmlHelper<TModel> html, System.Data.DataRow ligne, Dictionary<string, object> KeysObjets, string ActionUrl = null)
        {
            string retour = "";

            if (!string.IsNullOrWhiteSpace(ActionUrl)) ActionUrl = "action='" + ActionUrl + "'";
            int countl = 0;
            foreach (System.Data.DataColumn itemcol in ligne.Table.Columns)
            {
                countl++;
                if (itemcol.ColumnName.ToLower().Contains("flux")) continue; // trop gros...
                if (ligne.Table.PrimaryKey.Contains(itemcol)) continue; // Interdit de modifier les clefs
                string valeurb = GetRowString(ligne, itemcol.ColumnName);
                retour += "<form method=\"POST\" " + ActionUrl + " name='formRawDataWithBtns" + countl + "' id='formRawDataWithBtns" + countl + "' > "; //name=\"form"++"\""
                retour += "<input type=\"hidden\" name=\"ColumnName\" value=\"" + itemcol.ColumnName + "\"/>";
                foreach (string idsObjetKey in KeysObjets.Keys)
                {
                    retour += "<input type=\"hidden\" name=\"" + idsObjetKey + "\" value=\"" + KeysObjets[idsObjetKey] + "\"/>";
                }

                retour += "<div class=\"input-group\"  style=\"margin-left:20px;\">";
                retour += "<span class=\"input-group-addon\" style=\"width:120px; font-size:x-small;\">" + itemcol.ColumnName + "</span>";

                if (itemcol.DataType.ToString() == "System.Boolean")
                {
                    retour += "<select  class=\"form-control\" name=\"ColumnValue\" >";
                    retour += "<option value=\"NULL\" " + MenuHelper.sayselected(valeurb, "") + ">NULL</option>";
                    retour += "<option value=\"True\" " + MenuHelper.sayselected(valeurb, "True") + ">True</option>";
                    retour += "<option value=\"False\" " + MenuHelper.sayselected(valeurb, "False") + ">False</option>";
                    retour += "</select>";
                }
                else if (ligne[itemcol.ColumnName] == DBNull.Value)
                {
                    retour += "<input type=\"text\" class=\"form-control\" name=\"ColumnValue\"  placeholder=\"NULL [" + itemcol.DataType + "]\" style='' value='' > ";
                }
                else if (string.IsNullOrWhiteSpace(valeurb))
                {
                    retour += "<input type=\"text\" class=\"form-control\" name=\"ColumnValue\"  placeholder=\"Empty [" + itemcol.DataType + "]\" style='' value=\"" + valeurb + "\" > ";
                }
                else
                {
                    retour += "<input type=\"text\" class=\"form-control\" name=\"ColumnValue\"   value=\"" + valeurb + "\">";
                }

                retour += "<span class=\"input-group-btn\"> <button class=\"btn btn-primary\" type=\"submit\">send</button></span>";
                retour += " </div>";
                retour += "</form>" + "\r\n";
            }

            return new MvcHtmlString(retour.ToString()); // This returns the buffer. We will almost always want ToString—it will return the contents as a string.
        }

        /// <summary>
        /// Easies the table infos.
        /// </summary>
        /// <param name="rowsTr">The rows tr.</param>
        /// <param name="SizeLabel">The size label.</param>
        /// <returns></returns>
        public static string EasyTableInfos(Dictionary<string, string> rowsTr, int SizeLabel = 150)
        {
            StringBuilder html = new StringBuilder();
            html.Append("<table class='table table-striped table-hover table-condensed' style='border:1px solid #D8D8D8;background-color:#FFFFFF;'>");
            html.Append("<tbody>");
            foreach (string keyrow in rowsTr.Keys)
            {
                html.Append("<tr>");
                html.AppendFormat("<td style='width: {1}px;font-size:small;'>{0}</td>", keyrow, SizeLabel);
                html.Append("<td>" + rowsTr[keyrow] + "</td>");
                html.Append("</tr>");
            }
            html.Append("</tbody>");
            html.Append("</table>");
            return html.ToString();
        }

        /// <summary>
        /// Gets the row string.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <param name="nameValue">The name value.</param>
        /// <returns></returns>
        private static string GetRowString(System.Data.DataRow row, string nameValue)
        {
            try
            {
                object obj = GetRowObject(row, nameValue);
                if (obj == null || obj == DBNull.Value) return string.Empty;
                else return Convert.ToString(obj);
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the row object.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <param name="nameValue">The name value.</param>
        /// <returns></returns>
        private static object GetRowObject(System.Data.DataRow row, string nameValue)
        {
            if (row == null) return null;
            try
            {
                System.Data.DataColumn realColumn = GetRealColumn(row, nameValue);
                if (realColumn != null) return row[realColumn];
                else return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the row object.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <param name="realColumn">The real column.</param>
        /// <returns></returns>
        private static object GetRowObject(System.Data.DataRow row, System.Data.DataColumn realColumn)
        {
            if (row == null) return null;
            if (realColumn == null) return null;

            if (!row.Table.Columns.Contains(realColumn.ColumnName.ToString())) return null;
            if (realColumn != null) return row[realColumn];
            else return null;
        }

        /// <summary>
        /// Gets the real column.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <param name="nameValue">The name value.</param>
        /// <returns></returns>
        private static System.Data.DataColumn GetRealColumn(System.Data.DataRow row, string nameValue)
        {
            if (row.Table.Columns.Contains(nameValue)) return row.Table.Columns[nameValue];
            else
            {
                nameValue = nameValue.ToUpper();
                foreach (System.Data.DataColumn colonne in row.Table.Columns)
                {
                    if (colonne.ColumnName.ToUpper() == nameValue) return row.Table.Columns[colonne.Ordinal];
                }
            }
            return null;
        }
    }
}