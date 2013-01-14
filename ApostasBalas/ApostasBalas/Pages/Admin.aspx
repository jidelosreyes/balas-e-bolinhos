<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true"
    CodeBehind="Admin.aspx.cs" Inherits="ApostasBalas.Pages.Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Code/Admin.js" type="text/javascript"></script>
    <link href="../Content/jqwidgets/jqx.base.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jqwidgets/jqxcore.js" type="text/javascript"></script>
    <script src="../Scripts/jqwidgets/jqxbuttons.js" type="text/javascript"></script>
    <script src="../Scripts/jqwidgets/jqxlistbox.js" type="text/javascript"></script>
    <script src="../Scripts/jqwidgets/jqxscrollbar.js" type="text/javascript"></script>
    <script src="../Scripts/jqwidgets/jqxdropdownlist.js" type="text/javascript"></script>
    <script src="../Scripts/jqwidgets/jqxgrid.js" type="text/javascript"></script>
    <script src="../Scripts/jqwidgets/jqxgrid.columnsresize.js" type="text/javascript"></script>
    <script src="../Scripts/jqwidgets/jqxgrid.selection.js" type="text/javascript"></script>
    <script src="../Scripts/jqwidgets/jqxdata.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <input type="button" value="Click Me" id='myButton' />
    <div id='jqxWidget'>
    </div>
    <div id="jqxgrid">
    </div>
</asp:Content>
