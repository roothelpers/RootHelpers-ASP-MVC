using System;
using System.Web;

namespace RootHelpers.GENERAL
{
    public static class Tools
    {
        public static string getlanguage()
        {
            string lang = "en";
            var ci = HttpContext.Current.Session["Language"];
            var cokkies= HttpContext.Current.Request.Cookies["Language"];
            
            if (ci != null)
            {
                lang = ci.ToString();
            }
            if (cokkies != null)
            {
                lang = cokkies.Value;
            }
            return lang;
        }

        public static string GetPostitionText()
        {
            String lang = GENERAL.Tools.getlanguage();
            return (lang == "ar" ? "text-right" : "text-left");
        }

        public static bool ItEnglish()
        {
            String lang = GENERAL.Tools.getlanguage();
            return (lang == "ar" ? true : false);
        }
        public static void Create()
        {
            try
            {
                // Create a instance of ResourceWriter and specify the name of the resource file.
                System.Resources.ResourceWriter RWObj = new System.Resources.ResourceWriter(AppDomain.CurrentDomain.BaseDirectory + "MyResource.resx");

                // Add String resource 
                RWObj.AddResource("FirstName", "Kishor");
                RWObj.AddResource("LastName", "Naik");

                // Close the Resource Writer
                RWObj.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}