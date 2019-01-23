using System;
using System.Text;

namespace RootHelpers.TOOLS
{
    public static class WidgetsHelpers
    {
        public class WidgetsHelpersPoco
        {
            public string ContentHtml { get; set; }

            public string BodyHtml { get; set; }
            public string BodyColor = "white";

            public string HeaderColor = "white";
            public string HeaderImage { get; set; }
            public bool HeaderImagelazyhovereffectimg { get; set; }
            public string HeaderTitle { get; set; }

            public string HeaderOverlayerHtml { get; set; }

            public string HeaderHtml { get; set; }
            public int HeaderMaxheight = 345;

            public bool isHeader
            {
                get
                {
                    if (!string.IsNullOrWhiteSpace(HeaderImage)) return true;
                    if (!string.IsNullOrWhiteSpace(HeaderTitle)) return true;
                    if (!string.IsNullOrWhiteSpace(HeaderHtml)) return true;
                    else return false;
                }
            }

            public void Init()
            {
                //tests

                //Corrections
            }
        }

        public static string EncapsulWidgetBeforeBody(WidgetsHelpersPoco poco)
        {
            try
            {
                StringBuilder html = new StringBuilder();
                html.Append("<div class=\"widget-item\">");
                html.Append("<div class=\"controller overlay right\"> <a href=\"javascript:;\" class=\"reload\"></a> <a href=\"javascript:;\" class=\"remove\"></a> </div>");

                if (poco.isHeader)
                {
                    if (!string.IsNullOrWhiteSpace(poco.HeaderImage))
                    {
                        html.AppendFormat("<div class=\"tiles {0} overflow-hidden full-height\" style=\"max-height:{1}px\">", poco.HeaderColor, poco.HeaderMaxheight);

                        html.AppendFormat("<img src=\"{0}\" alt=\"\" ", poco.HeaderImage);
                        if (poco.HeaderImagelazyhovereffectimg) html.Append(" class=\"lazy hover-effect-img\" ");
                        html.Append(" />");
                    }
                    else
                    {
                        html.AppendFormat("<div class=\"tiles {0}\" style=\"max-height:{1}px\">", poco.HeaderColor, poco.HeaderMaxheight);
                        html.Append("<div class=\"tiles-body\">");
                        if (!string.IsNullOrWhiteSpace(poco.HeaderTitle))
                            html.Append("<h3 class=\"text-white m-t-50 m-b-30 m-r-20\">" + poco.HeaderTitle + "</h3>");
                        else if (!string.IsNullOrWhiteSpace(poco.HeaderHtml))
                            html.Append(poco.HeaderHtml);
                        html.Append("</div>");
                    }

                    if (!string.IsNullOrWhiteSpace(poco.HeaderOverlayerHtml))
                    {
                        html.Append("<div class=\"overlayer bottom-right fullwidth\">");
                        html.Append("<div class=\"overlayer-wrapper\">");
                        html.Append("<div class=\" p-l-20 p-r-20 p-b-20 p-t-20\">");
                        html.Append(poco.HeaderOverlayerHtml);
                        html.Append("<div class=\"clearfix\"></div>");
                        html.Append("</div>");
                        html.Append("</div>");
                        html.Append("</div>");
                    }
                    html.Append("</div>");
                }

                // start body
                html.AppendFormat("<div class=\"tiles {0}\">", poco.BodyColor);
                html.Append("<div class=\"tiles-body\">");
                html.Append("<div class=\"row\">");

                return html.ToString();
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public static string EncapsulWidgetAfterBody(WidgetsHelpersPoco poco)
        {
            try
            {
                StringBuilder html = new StringBuilder();
                // close body
                html.Append("</div>");
                html.Append("</div>");
                html.Append("</div>");

                //close widget
                html.Append("</div>");

                return html.ToString();
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public static string EncapsulWidget(WidgetsHelpersPoco poco)
        {
            try
            {
                poco.Init();

                StringBuilder html = new StringBuilder();

                html.Append(EncapsulWidgetBeforeBody(poco));

                html.Append(poco.BodyHtml);

                html.Append(EncapsulWidgetAfterBody(poco));
                return html.ToString();
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public static string EncapsulWidgetMaster(string ContentHtml)
        {
            try
            {
                StringBuilder html = new StringBuilder();
                html.Append("<div class=\"widget-item\">");
                html.Append("<div class=\"controller overlay right\"> <a href=\"javascript:;\" class=\"reload\"></a> <a href=\"javascript:;\" class=\"remove\"></a> </div>");
                html.Append(ContentHtml);
                html.Append("</div>");
                return html.ToString();
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public static string widgetblog1()
        {
            try
            {
                StringBuilder html = new StringBuilder();
                html.Append("<div class=\"tiles white p-t-15\">");
                // HEADER
                html.Append("<div class=\"row\">");
                html.Append("<div class=\"col-md-2\">");
                html.Append("<div class=\"profile-img-wrapper pull-left m-l-10\">");
                html.Append("<div class=\" p-r-10\">");
                html.Append("<img src=\"/assets/img/profiles/c.jpg\" alt=\"\" data-src=\"/assets/img/profiles/c.jpg\" data-src-retina=\"/assets/img/profiles/c2x.jpg\" width=\"35\" height=\"35\">");
                html.Append("</div>");
                html.Append("</div>");
                html.Append("</div>");
                html.Append("<div class=\"col-md-10\">");
                html.Append(" <div class=\"user-name text-black bold large-text\"> John <span class=\"semi-bold\">Smith</span> </div>");
                html.Append("<div class=\"preview-wrapper\">shared a picture with <span class=\"bold\">Jane Smith</span>.</div>");
                html.Append("</div>");
                html.Append("</div>");

                html.Append("<div id=\"image-demo-carl-2\" class=\"m-t-15 owl-carousel owl-theme\">");
                html.Append("<div class=\"item\"><img src=\"/assets/img/others/1.jpg\" alt=\"\"></div>");
                html.Append("<div class=\"item\"><img src=\"/assets/img/others/2.jpg\" alt=\"\"></div>");
                html.Append("</div>");
                html.Append("<div class=\"post p-b-15 p-t-15 p-l-15 b-b b-grey\">");
                html.Append(" <ul class=\"action-bar no-margin \">");
                html.Append("<li><a href=\"#\" class=\"muted\"><i class=\"fa fa-comment m-r-5\"></i> 24</a> </li>");
                html.Append(" <li><a href=\"#\" class=\"text-error bold\"> <i class=\"fa fa-heart-o  m-r-5\"></i> 5</a> </li>");
                html.Append("</ul>");
                html.Append("<div class=\"clearfix\"></div>");
                html.Append("</div>");
                html.Append("<p class=\"p-t-10 p-b-10 p-l-15 p-r-15\"><span class=\"bold\">Jane Smith, John Smith, David Jester, pepper</span> post and 214 others like this.</p>");
                html.Append("<div class=\"clearfix\"></div>");
                html.Append("<div class=\"p-b-10 p-l-10 p-r-10\">");
                html.Append(" <div class=\"profile-img-wrapper pull-left\"> <img src=\"/assets/img/profiles/avatar_small.jpg\" alt=\"\" data-src=\"/assets/img/profiles/avatar_small.jpg\" data-src-retina=\"/assets/img/profiles/avatar_small2x.jpg\" width=\"35\" height=\"35\"> </div>");
                html.Append("<div class=\"inline pull-right\" style=\"width:86%\">");
                html.Append("<div class=\"input-group transparent \">");
                html.Append("<input type=\"text\" class=\"form-control\" placeholder=\"Write a comment\">");
                html.Append("<span class=\"input-group-addon\"> <i class=\"fa fa-camera\"></i> </span>");
                html.Append("</div>");
                html.Append("</div>");
                html.Append("<div class=\"clearfix\"></div>");
                html.Append("</div>");
                html.Append(" </div>");

                return WidgetsHelpers.EncapsulWidgetMaster(html.ToString());
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}