using System;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace RootHelpers.TOOLS
{
    public static class LocalizationHelper
    {
        [Obsolete("specifying the language through <meta http-equiv=\"content-language\" content= > is obsolete. Use <html lang=> instead")]
        public static MvcHtmlString MetaContentLanguage(this HtmlHelper html)
        {
            var acceptLang = HttpUtility.HtmlAttributeEncode(Thread.CurrentThread.CurrentUICulture.ToString());
            return new MvcHtmlString(string.Format("<meta http-equiv=\"content-language\" content=\"{0}\"/>", acceptLang));
        }

        public static string Lang
        {
            get
            {
                return HttpUtility.HtmlAttributeEncode(Thread.CurrentThread.CurrentUICulture.ToString());
            }
        }
    }
}