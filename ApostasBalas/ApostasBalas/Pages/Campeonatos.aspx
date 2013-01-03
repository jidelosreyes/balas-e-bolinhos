<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true"
    CodeBehind="Campeonatos.aspx.cs" Inherits="ApostasBalas.Pages.Campeonatos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Code/Campeonatos.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        Registo de Competicoes</h2>
    <asp:Repeater ID="rptCompeticoes" runat="server">
        <HeaderTemplate>
            <div id="DivCompeticoes" class="RegistarCompeticoes" onload="Teste()">
        </HeaderTemplate>
        <ItemTemplate>
            <p id="p<%# Eval("IdCompeticao")%>">
                <input id="hddId" type="hidden" value="<%# Eval("IdCompeticao")%>" />
                <label>
                    <%# Eval("Descricao")%></label>
                <button id="btnRegistar" class="buttondiv">
                    Registar</button>
                <button id="btnactivar" class="buttondiv">
                    Activar</button>
            </p>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <p>
                <input id="hddId" type="hidden" value=" <%# Eval("IdCompeticao")%>" />
                <label>
                    <%# Eval("Descricao")%></label>
                <button class="buttondiv">
                     <span class="registado">Registado</span> <span class="registar">Registar</button>
                <button class="buttondiv">
                    Activar</button>
                <button class="buttondiv registarregistado">
                    <span class="registar">Registado</span> <span class="registado">Registar</span>
                </button>
            </p>
        </AlternatingItemTemplate>
        <FooterTemplate>
            </div>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
