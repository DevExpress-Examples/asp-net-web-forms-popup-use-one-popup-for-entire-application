Imports DevExpress.Web
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace T501713
    Partial Public Class Root
        Inherits System.Web.UI.MasterPage

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

        End Sub

        Public Event PopupInit As EventHandler
        Protected Sub popupControl_Init(ByVal sender As Object, ByVal e As EventArgs)
            RaiseEvent PopupInit(sender, e)
            popupControl.FooterText = "Rendered by the master page"
            popupControl.ShowFooter = True
        End Sub

        Public Event PopupCallback As PopupWindowCallbackEventHandler
        Protected Sub popupControl_WindowCallback(ByVal source As Object, ByVal e As PopupWindowCallbackArgs)
            RaiseEvent PopupCallback(source, e)
        End Sub

    End Class
End Namespace