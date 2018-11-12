using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.Web;
using DevExpress.Web.Mvc;

namespace SmartQA1._1._2.Views.CommonSettings
{
    public static class PopupSettings
    {
        public static void AddPopupSettings(this PopupControlSettings s)
        {
            s.AllowResize = false;
            s.ShowHeader = true;
            s.ShowOnPageLoad = false;
            s.AllowDragging = true;
            s.CloseAction = CloseAction.CloseButton;
            s.CloseOnEscape = false;
            s.Modal = false;
            s.PopupHorizontalAlign = PopupHorizontalAlign.WindowCenter;
            s.PopupVerticalAlign = PopupVerticalAlign.WindowCenter;
        }
    }
}