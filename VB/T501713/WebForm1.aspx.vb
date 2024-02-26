Imports DevExpress.Web
Imports System
Imports System.Linq
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace T501713

    Public Partial Class WebForm1
        Inherits Page

        Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As EventArgs)
            AddHandler Master.PopupInit, AddressOf Master_PopupInit
        End Sub

        Private Sub Master_PopupInit(ByVal sender As Object, ByVal e As EventArgs)
            RenderGrid(CType(sender, ASPxPopupControl))
        End Sub

        Private Sub RenderGrid(ByVal container As ASPxPopupControl)
            Dim grid As ASPxGridView = New ASPxGridView()
            grid.ID = "ASPxGridView"
            container.Controls.Add(grid)
            grid.Width = Unit.Percentage(100)
            AddHandler grid.DataBinding, Sub(sender, e)
                TryCast(sender, ASPxGridView).DataSource = Enumerable.Range(0, 10).[Select](Function(i) New With {.Id = i, .Name = "Name" & i}).ToList()
            End Sub
            grid.DataBind()
        End Sub
    End Class
End Namespace
