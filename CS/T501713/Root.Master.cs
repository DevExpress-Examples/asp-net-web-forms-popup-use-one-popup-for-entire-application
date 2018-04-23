using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace T501713 {
    public partial class Root : System.Web.UI.MasterPage {
        protected void Page_Load(object sender, EventArgs e) {

        }

        public event EventHandler PopupInit;
        protected void popupControl_Init(object sender, EventArgs e) {
            if (PopupInit != null)
                PopupInit(sender, e);
            popupControl.FooterText = "Rendered by the master page";
            popupControl.ShowFooter = true;
        }

        public event PopupWindowCallbackEventHandler PopupCallback;
        protected void popupControl_WindowCallback(object source, PopupWindowCallbackArgs e) {
            if (PopupCallback != null)
                PopupCallback(source, e);
        }

    }
}