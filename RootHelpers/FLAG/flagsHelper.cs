using System.Text;
using System.Web.Mvc;

namespace RootHelpers
{
    public static class flagsHelper
    {
        // https://www.phoca.cz/cssflags/#demo

        public static MvcHtmlString TN<TModel>(this HtmlHelper<TModel> html, string style = "height: 18px;")
        {
            StringBuilder theeditor = new StringBuilder();
            string codeimage = "data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiBzdGFuZGFsb25lPSJubyI/Pg0KPCFET0NUWVBFIHN2ZyBQVUJMSUMgIi0vL1czQy8vRFREIFNWRyAxLjEvL0VOIiAiaHR0cDovL3d3dy53My5vcmcvR3JhcGhpY3MvU1ZHLzEuMS9EVEQvc3ZnMTEuZHRkIj4NCjxzdmcgdmVyc2lvbj0iMS4xIiBiYXNlUHJvZmlsZT0iZnVsbCIgeG1sbnM6ZXY9Imh0dHA6Ly93d3cudzMub3JnLzIwMDEveG1sLWV2ZW50cyIgeG1sbnM6eGxpbms9Imh0dHA6Ly93d3cudzMub3JnLzE5OTkveGxpbmsiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyIgcHJlc2VydmVBc3BlY3RSYXRpbz0ieE1pZFlNaWQgbWVldCIgem9vbUFuZFBhbj0ibWFnbmlmeSINCiAgIGlkPSJGbGFnIG9mIFR1bmlzaWEiDQogICB2aWV3Qm94PSItNjAgLTQwIDEyMCA4MCINCiAgIHdpZHRoPSIxMjAwIg0KICAgaGVpZ2h0PSI4MDAiPg0KICAgDQoNCiAgIDxnIGZpbGw9IiNlNzAwMTMiPg0KICAgICAgPHJlY3Qgd2lkdGg9IjEwMCUiIGhlaWdodD0iMTAwJSIgeD0iLTUwJSIgeT0iLTUwJSIvPg0KICAgICAgPGNpcmNsZSByPSIyMCIgZmlsbD0id2hpdGUiLz4NCiAgICAgIDxjaXJjbGUgcj0iMTUiLz4NCiAgICAgIDxjaXJjbGUgY3g9IjQiIHI9IjEyIiBmaWxsPSJ3aGl0ZSIvPiAgIA0KICAgICAgPGcgaWQ9InN0YXIiIHRyYW5zZm9ybT0idHJhbnNsYXRlKDQpIHJvdGF0ZSgtOTApIHNjYWxlKDkpIj4NCiAgICAgICAgIDxnIGlkPSJjb25lIj4NCiAgICAgICAgICAgIDxwb2x5bGluZSBpZD0idHJpYW5nbGUiIHBvaW50cz0iMCwwIDAsMSAuNSwxIiB0cmFuc2Zvcm09InRyYW5zbGF0ZSgwLC0xKSByb3RhdGUoMTgpIi8+DQogICAgICAgICAgICA8dXNlIHhsaW5rOmhyZWY9IiN0cmlhbmdsZSIgdHJhbnNmb3JtPSJzY2FsZSgtMSwxKSIvPg0KICAgICAgICAgPC9nPg0KICAgICAgICAgPHVzZSB4bGluazpocmVmPSIjY29uZSIgdHJhbnNmb3JtPSJyb3RhdGUoNzIpIi8+DQogICAgICAgICA8dXNlIHhsaW5rOmhyZWY9IiNjb25lIiB0cmFuc2Zvcm09InJvdGF0ZSgtNzIpIi8+DQogICAgICAgICA8dXNlIHhsaW5rOmhyZWY9IiNjb25lIiB0cmFuc2Zvcm09InJvdGF0ZSgxNDQpIi8+DQogICAgICAgICA8dXNlIHhsaW5rOmhyZWY9IiNjb25lIiB0cmFuc2Zvcm09InJvdGF0ZSgtMTQ0KSIvPg0KICAgICAgPC9nPg0KICAgPC9nPg0KPC9zdmc+DQo=";
            theeditor.AppendFormat("<img src='{0}' style='{1}'>", codeimage, style);
            return new MvcHtmlString(theeditor.ToString());
        }

        public static MvcHtmlString AM<TModel>(this HtmlHelper<TModel> html, string style = "height: 18px;")
        {
            StringBuilder theeditor = new StringBuilder();
            string codeimage = "data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMTAwMCIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIiBoZWlnaHQ9IjUwMCIgdmlld0JveD0iLTMgLTEuNSA2IDMiIHhtbG5zOnhsaW5rPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5L3hsaW5rIj4NCjxnIGZpbGw9Im5vbmUiPg0KPHBhdGggc3Ryb2tlPSIjZjAwIiBkPSJtLTMtMWg2Ii8+DQo8cGF0aCBzdHJva2U9IiMwMDAwZDYiIGQ9Im0tMywwaDYiLz4NCjxwYXRoIHN0cm9rZT0iI2ZmYjEwMCIgZD0ibS0zLDFoNiIvPg0KPC9nPg0KPC9zdmc+DQo=";
            theeditor.AppendFormat("<img src='{0}' style='{1}'>", codeimage, style);
            return new MvcHtmlString(theeditor.ToString());
        }

        public static MvcHtmlString AG<TModel>(this HtmlHelper<TModel> html, string style = "height: 18px;")
        {
            StringBuilder theeditor = new StringBuilder();
            string codeimage = "data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiPz4KPCFET0NUWVBFIHN2ZyBQVUJMSUMgIi0vL1czQy8vRFREIFNWRyAxLjEvL0VOIiAiaHR0cDovL3d3dy53My5vcmcvR3JhcGhpY3MvU1ZHLzEuMS9EVEQvc3ZnMTEuZHRkIj4KPHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHhtbG5zOnhsaW5rPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5L3hsaW5rIiB3aWR0aD0iNzUwcHgiIGhlaWdodD0iNTAwcHgiIHZpZXdCb3g9Ii02OSAtNDYgMTM4IDkyIj4KCTx0aXRsZT5GbGFnIG9mIEFudGlndWEgYW5kIEJhcmJ1ZGE8L3RpdGxlPgoKCTxyZWN0IGlkPSJmaWVsZCIgeD0iLTUwJSIgeT0iLTUwJSIgd2lkdGg9IjEwMCUiIGhlaWdodD0iMTAwJSIgZmlsbD0id2hpdGUiLz4KCTxyZWN0IGlkPSJibHVlYmFuZCIgeD0iLTUwJSIgeT0iLTEwIiB3aWR0aD0iMTAwJSIgaGVpZ2h0PSIyMCIgZmlsbD0iIzAwNzJjNiIvPgoJPHJlY3QgaWQ9ImJsYWNrYmFuZCIgeD0iLTUwJSIgeT0iLTUwJSIgd2lkdGg9IjEwMCUiIGhlaWdodD0iMzYiIGZpbGw9ImJsYWNrIi8+Cgk8cGF0aCBpZD0icmVkdHJpYW5nbGVzIiBkPSJNLTY5LC00NiB2OTIgaDEzOCB2LTkyIGwtNjksOTIgeiIgZmlsbD0iI2NlMTEyNiIvPgoJPGNsaXBQYXRoIGlkPSJjbGlwc3VuIj4KCQk8cmVjdCB4PSItNTAlIiB5PSItNTAlIiB3aWR0aD0iMTAwJSIgaGVpZ2h0PSI1MCUiLz4KCTwvY2xpcFBhdGg+Cgk8ZyBpZD0ic3VuIiBmaWxsPSIjZmNkMTE2IiB0cmFuc2Zvcm09InRyYW5zbGF0ZSgwLC0xMCkgc2NhbGUoMzApIiBjbGlwLXBhdGg9InVybCgjY2xpcHN1bikiPgoJCTxnIGlkPSJ0aHJlZV9jb25lcyI+CgkJCTxnIGlkPSJjb25lIj4KCQkJCTxwb2x5Z29uIGlkPSJ0cmlhbmdsZSIgcG9pbnRzPSIwLDAgMCwxIC4yNSwxIiB0cmFuc2Zvcm09InRyYW5zbGF0ZSgwLC0xKSByb3RhdGUoMTEuMjUpIi8+CgkJCQk8dXNlIHhsaW5rOmhyZWY9IiN0cmlhbmdsZSIgdHJhbnNmb3JtPSJzY2FsZSgtMSwxKSIgLz4KCQkJPC9nPgoJCQk8dXNlIHhsaW5rOmhyZWY9IiNjb25lIiB0cmFuc2Zvcm09InJvdGF0ZSgyMi41KSIvPgoJCQk8dXNlIHhsaW5rOmhyZWY9IiNjb25lIiB0cmFuc2Zvcm09InJvdGF0ZSgtMjIuNSkiLz4KCQk8L2c+CgkJPHVzZSB4bGluazpocmVmPSIjdGhyZWVfY29uZXMiIHRyYW5zZm9ybT0icm90YXRlKDY3LjUpIi8+CgkJPHVzZSB4bGluazpocmVmPSIjdGhyZWVfY29uZXMiIHRyYW5zZm9ybT0icm90YXRlKC02Ny41KSIvPgoJPC9nPgo8L3N2Zz4K";
            theeditor.AppendFormat("<img src='{0}' style='{1}'>", codeimage, style);
            return new MvcHtmlString(theeditor.ToString());
        }

        public static MvcHtmlString AE<TModel>(this HtmlHelper<TModel> html, string style = "height: 18px;")
        {
            StringBuilder theeditor = new StringBuilder();
            string codeimage = "data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMTIwMCIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIiBoZWlnaHQ9IjYwMCIgdmlld0JveD0iMCAwIDEyIDYiIHhtbG5zOnhsaW5rPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5L3hsaW5rIj4NCjxwYXRoIGZpbGw9IiNjZTExMjYiIGQ9Im0wLDBoM3Y2aC0zeiIvPg0KPHBhdGggZmlsbD0iIzAwOWEwMCIgZD0ibTMsMGg5djJoLTl6Ii8+DQo8cGF0aCBmaWxsPSIjZmZmIiBkPSJtMywyaDl2MmgtOXoiLz4NCjxwYXRoIGQ9Im0zLDRoOXYyaC05eiIvPg0KPC9zdmc+DQo=";
            theeditor.AppendFormat("<img src='{0}' style='{1}'>", codeimage, style);
            return new MvcHtmlString(theeditor.ToString());
        }
    }
}