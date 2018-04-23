using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace T501713 {
    public partial class WebForm1 : System.Web.UI.Page {
        protected void Page_PreInit(object sender, EventArgs e) {
            Master.PopupInit += Master_PopupInit;
        }

        private void Master_PopupInit(object sender, EventArgs e) {
            RenderGrid((ASPxPopupControl)sender);
        }

        private void RenderGrid(ASPxPopupControl container) {
            ASPxGridView grid = new ASPxGridView();
            grid.ID = "ASPxGridView";
            container.Controls.Add(grid);

            grid.Width = Unit.Percentage(100);
            grid.DataBinding += (sender, e) => {
                (sender as ASPxGridView).DataSource = Enumerable.Range(0, 10).Select(i => new { Id = i, Name = "Name" + i }).ToList();
            };
            grid.DataBind();
        }
    }
}