<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true"
    CodeBehind="Campeonatos.aspx.cs" Inherits="ApostasBalas.Pages.Campeonatos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Code/Campeonatos.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        Competicoes Existentes</h2>
    <asp:Repeater ID="rptCompeticoes" runat="server">
        <HeaderTemplate>
            <div id="DivCompeticoes" class="RegistarCompeticoes">
        </HeaderTemplate>
        <ItemTemplate>
            <p>
                <label>
                    <%# Eval("Descricao")%></label>
                <button class="buttondiv">
                    Registar</button>
                <button class="buttondiv">
                    Activar</button>
            </p>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <p>
                <label>
                    <%# Eval("Descricao")%></label>
                <button class="buttondiv">
                    Registar</button>
                <button class="buttondiv">
                    Activar</button>
            </p>
        </AlternatingItemTemplate>
        <FooterTemplate>
            </div>
        </FooterTemplate>
    </asp:Repeater>
    <h2>
        Competicoes Registadas</h2>
    <asp:Repeater ID="rptCompeticoesRegistadas" runat="server">
        <HeaderTemplate>
            <div id="DivRegistadas" class="RegistarCompeticoes">
        </HeaderTemplate>
        <ItemTemplate>
            <p>
                <%# Eval("Descricao")%>
            </p>
            <p>
                <%# Eval("IdUtilizador")%>
            </p>
            <p>
                <%# Eval("IdCompeticao")%>
            </p>
            <p>
                <%# Eval("Activo")%>
            </p>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <p>
                <%# Eval("Descricao")%>
            </p>
            <p>
                <%# Eval("IdUtilizador")%>
            </p>
            <p>
                <%# Eval("IdCompeticao")%>
            </p>
            <p>
                <%# Eval("Activo")%>
            </p>
        </AlternatingItemTemplate>
        <FooterTemplate>
            </div>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
