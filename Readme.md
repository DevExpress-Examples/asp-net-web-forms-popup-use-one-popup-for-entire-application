<!-- default badges list -->
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T501713)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# Popup Control for ASP.NET Web Forms - How to use one pop-up across all pages of an application

You can use one [Popup Control](https://docs.devexpress.com/AspNet/3582/components/docking-and-popups/popup-control) across all pages of your application to improve performance. This example demonstrates how to create a popup control on the master page and invoke it from multiple pages. The pop-up window's content depends on the page that shows this window.

![Popup Window](popup.png)

In this example, the **WebForm1** page populates the pop-up window with content during control initialization. The **WebForm2** page specifies the window's content once the control sends a callback to the server. Use **Init approach** and **Callback approach** menu items to switch between these pages. Click the **Show Popup** button to show the pop-up window.

## Overview

Follow the steps below to use one pop-up across multiple pages:

1. Place an empty popup control in the root master page.

2. Handle one of the following events:

    * The `Init` event allows you to create pop-up window content at runtime during popup control initialization.
    * The [WindowCallback](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxPopupControlBase.WindowCallback) event allows you to dynamically create pop-up window content once the window sends a callback.

    The code snippet below handles the `Init` event:

    ```aspx
    <dx:ASPxPopupControl ID="popupControl" runat="server" ClientInstanceName="popup" 
        OnInit="popupControl_Init" />
    ```

3. Create a delegate for the event you handled on the previous step:

    ```cs
    public event EventHandler PopupInit;
    protected void popupControl_Init(object sender, EventArgs e) {
        if (PopupInit != null)
            PopupInit(sender, e);
    }
    ```

4. Specify the master page's type name in all pages where you want to display pop-up windows:

    ```aspx
    <%@ MasterType TypeName="T501713.Root" %>
    ```

5. In these pages, call the event delegate and populate the pop-up window with content:

    ```cs
    protected void Page_PreInit(object sender, EventArgs e) {
        Master.PopupInit += Master_PopupInit;
    }

    private void Master_PopupInit(object sender, EventArgs e) {
        // Populate the pop-up window with page-specific content
    }
    ```

6. Use the popup control's client instance name to show the pop-up window:

    ```js
    function button1_Click(s, e) {
        popup.Show();
    }
    ```

## Files to Review

* [Root.Master](./CS/T501713/Root.Master) (VB: [Root.Master](./VB/T501713/Root.Master))
* [Root.Master.cs](./CS/T501713/Root.Master.cs) (VB: [Root.Master.vb](./VB/T501713/Root.Master.vb))
* [WebForm1.aspx](./CS/T501713/WebForm1.aspx) (VB: [WebForm1.aspx](./VB/T501713/WebForm1.aspx))
* [WebForm1.aspx.cs](./CS/T501713/WebForm1.aspx.cs) (VB: [WebForm1.aspx.vb](./VB/T501713/WebForm1.aspx.vb))
* [WebForm2.aspx](./CS/T501713/WebForm2.aspx) (VB: [WebForm2.aspx](./VB/T501713/WebForm2.aspx))
* [WebForm2.aspx.cs](./CS/T501713/WebForm2.aspx.cs) (VB: [WebForm2.aspx.vb](./VB/T501713/WebForm2.aspx.vb))

## Documentation

- [Docking and Popups](https://docs.devexpress.com/AspNet/14830/components/docking-and-popups)

## More Examples

- [How to customize a pop-up window's content and layout](https://github.com/DevExpress-Examples/asp-net-web-forms-popup-customize-content-and-layout)
- [How to create ASP.NET Web Forms controls dynamically](https://github.com/DevExpress-Examples/asp-net-web-forms-create-controls-dynamically)
