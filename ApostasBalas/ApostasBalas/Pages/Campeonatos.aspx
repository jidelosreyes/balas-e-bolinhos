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
            <table id="example" class="DataTable" style="width: 100%; border-spacing: 0;">
                <tr class="TableNormal">
                    <th>
                        Id
                    </th>
                    <th>
                        Descricao
                    </th>
                    <th>
                        Registar
                    </th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr class="TableNormal">
                <td>
                    <%# Eval("IdCompeticao")%>
                </td>
                <td>
                    <%# Eval("Descricao")%>
                </td>
                <td>
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr class="TableNormal">
                <td>
                    <%# Eval("IdCompeticao")%>
                </td>
                <td>
                    <%# Eval("Descricao")%>
                </td>
                <td>
                </td>
            </tr>
        </AlternatingItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <h2>
        Competicoes Registadas</h2>
        <asp:Repeater ID="rptCompeticoesRegistadas" runat="server">
        <HeaderTemplate>
            <table id="example" class="DataTable" style="width: 100%; border-spacing: 0;">
                <tr class="TableNormal">
                    <th>
                        Id
                    </th>
                    <th>
                        Descricao
                    </th>                   
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr class="TableNormal">
                <td>
                    <%# Eval("IdCompeticao")%>
                </td>
                <td>
                    <%# Eval("Descricao")%>
                </td>
               
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr class="TableNormal">
                <td>
                    <%# Eval("IdCompeticao")%>
                </td>
                <td>
                    <%# Eval("Descricao")%>
                </td>               
            </tr>
        </AlternatingItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
