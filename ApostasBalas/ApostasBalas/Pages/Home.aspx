<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true"
    CodeBehind="Home.aspx.cs" Inherits="ApostasBalas.Pages.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Code/Home.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        Informação sobre a competição actual</h1>
    <ul>
        <li>Nome da Competição:
            <asp:Label ID="lblNomeCompeticao" runat="server" Text="Label"></asp:Label></li>
        <li>Jogos por Jornada: 4</li>
        <li>Pontos por vitória: 3</li>
        <li>Pontos por empate: 1</li>
        <li>Pontos por derrota: 0</li>
    </ul>
    <h2>
        Primeiros classificados</h2>
    <asp:Repeater ID="rptPrimeirosClassificados" runat="server">
        <HeaderTemplate>
            <table id="example" class="DataTable" style="width: 100%; border-spacing: 0;">
                <tr>
                    <th>
                        Posição
                    </th>
                    <th>
                        Nome
                    </th>
                    <th>
                        Jogos
                    </th>
                    <th>
                        Vitorias
                    </th>
                    <th>
                        Empates
                    </th>
                    <th>
                        Derrotas
                    </th>
                    <th>
                        Pontos
                    </th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%#(Container.ItemIndex + 1) %>
                </td>
                <td>
                    <%# Eval("Nome")%>
                </td>
                <td>
                    <%# Eval("Jogos")%>
                </td>
                <td>
                    <%# Eval("Vitorias")%>
                </td>
                <td>
                    <%# Eval("Empates")%>
                </td>
                <td>
                    <%# Eval("Derrotas")%>
                </td>
                <td>
                    <%# Eval("Pontos")%>
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr>
                <td>
                    <%#(Container.ItemIndex + 1) %>
                </td>
                <td>
                    <%# Eval("Nome")%>
                </td>
                <td>
                    <%# Eval("Jogos")%>
                </td>
                <td>
                    <%# Eval("Vitorias")%>
                </td>
                <td>
                    <%# Eval("Empates")%>
                </td>
                <td>
                    <%# Eval("Derrotas")%>
                </td>
                <td>
                    <%# Eval("Pontos")%>
                </td>
            </tr>
        </AlternatingItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>  
</asp:Content>
