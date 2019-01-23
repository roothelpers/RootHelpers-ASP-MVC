using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace RootHelpers
{
    public static class CountryHelper
    {
        public static List<string> GetCountryList()
        {
            List<string> CountryList = new List<string>();
            CultureInfo[] CInfoList = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            foreach (CultureInfo CInfo in CInfoList)
            {
                RegionInfo R = new RegionInfo(CInfo.LCID);
                if (!(CountryList.Contains(R.EnglishName)))
                {
                    CountryList.Add(R.EnglishName);
                }
            }

            CountryList.Sort();
            return CountryList;
        }

        public static List<string> GetCountryLetterList()
        {
            List<string> CountryList = new List<string>();
            CultureInfo[] CInfoList = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            foreach (CultureInfo CInfo in CInfoList)
            {
                RegionInfo R = new RegionInfo(CInfo.LCID);
                if (!(CountryList.Contains(R.TwoLetterISORegionName)))
                {
                    CountryList.Add(R.TwoLetterISORegionName);
                }
            }

            CountryList.Sort();
            return CountryList;
        }

        public static HtmlString ShowContryList<TModel>(this HtmlHelper<TModel> html, string name = "CompanyCountry", string value = null)
        {
            StringBuilder retour = new StringBuilder();
            List<string> CountryList = GetCountryList();
            retour.AppendLine("<select class='form-control' id='" + name + "' name='" + name + "' style='height: 46px; '>");
            retour.AppendLine("<option> -- Select -- </option>");

            foreach (var item in CountryList)
            {
                string Isselected = "";
                if (item == value) Isselected = "selected";
                retour.Append(String.Format("<option " + Isselected + ">{0}</option>", item));
            }

            retour.AppendLine("</select>");

            return new HtmlString(retour.ToString());
        }

        public static HtmlString ShowContryTwoLetterList<TModel>(this HtmlHelper<TModel> html, string name = "CompanyCountry", string value = null)
        {
            StringBuilder retour = new StringBuilder();
            List<string> GetCountryLetter = GetCountryLetterList();
            retour.AppendLine("<select class='form-control' id='" + name + "' name='" + name + "' style='height: 46px; '>");
            retour.AppendLine("<option> -- Select -- </option>");

            foreach (var item in GetCountryLetter)
            {
                string Isselected = "";
                if (item.Length == 2)
                {
                    if (item == value) Isselected = "selected";
                    retour.Append(String.Format("<option " + Isselected + "> <i class='fa fa-user'></i>{0}</option>", item));
                }
            }

            retour.AppendLine("</select>");

            return new HtmlString(retour.ToString());
        }
    }
}