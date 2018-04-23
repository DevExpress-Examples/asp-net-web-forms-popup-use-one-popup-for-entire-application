using DevExpress.Web;
using DevExpress.Web.ASPxTreeList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace T501713 {
    public partial class WebForm2 : System.Web.UI.Page {
        protected void Page_PreInit(object sender, EventArgs e) {
            Master.PopupInit += Master_PopupInit;
            Master.PopupCallback += Master_PopupCallback; ;
        }


        private void Master_PopupInit(object sender, EventArgs e) {
            if (Session["isRendered"] != null)
                RenderTree((ASPxPopupControl)sender);
        }

        private void Master_PopupCallback(object source, PopupWindowCallbackArgs e) {
            if (e.Parameter == "tree") {
                RenderTree((ASPxPopupControl)source);
                Session["isRendered"] = true;
            }
        }

        private void RenderTree(ASPxPopupControl container) {
            container.Controls.Clear();
            ASPxTreeList tree = new ASPxTreeList();
            tree.ID = "ASPxTreeList";
            container.Controls.Add(tree);

            tree.Width = Unit.Percentage(100);
            tree.DataBinding += (sender, e) => {
                (sender as ASPxTreeList).ParentFieldName = "Parent";
                (sender as ASPxTreeList).DataSource = Enumerable.Range(0, 10).Select(i => new { Id = i, Name = "Name" + i, Parent = i % 3 }).ToList();
            };
            tree.DataBind();
        }
    }
}