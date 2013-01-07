<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true"
    CodeBehind="Apostas.aspx.cs" Inherits="ApostasBalas.Pages.Apostas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Code/Apostas.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        Apostar</h2>
    <div class="form_settings">
        <p>
            <span>Escolher Jornada</span>
            <select id="ddlApostar">                
            </select>
        </p>
    </div>
    <h2>
        Apostas Anteriores</h2>
    <div class="form_settings">
        <p>
            <span>Escolher Jornada</span>
            <select id="ddlVerApostas">             
            </select>
        </p>
    </div>
</asp:Content>
