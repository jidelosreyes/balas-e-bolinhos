<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true"
    CodeBehind="Apostas.aspx.cs" Inherits="ApostasBalas.Pages.Apostas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Code/Apostas.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Apostar</h2>
    <div class="form_settings">
        <p>
            <span>Jornadas</span>
            <select id="ddlApostar">
                <option selected="selected" value="0">Selecciona uma jornada</option>
            </select>
        </p>
    </div>
    <div id="grdApostar" class="ApostasForm_settings">



        <%--<asp:Repeater ID="rptApostar" runat="server">
            <HeaderTemplate>
                <div id="grdApostar" class="ApostasForm_settings">
            </HeaderTemplate>
            <ItemTemplate>
                <p>
                    <span>Jogo
                        <%#(Container.ItemIndex + 1) %></span>
                    <label>
                        <%# Eval("Equipa1")%></label>
                    <input type="text" value="<%# Eval("Resultado1")%>" />
                    <input type="text" value="<%# Eval("Resultado2")%>" />
                    <label>
                        <%# Eval("Equipa2")%></label>
                </p>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <p>
                    <span>Jogo
                        <%#(Container.ItemIndex + 1) %></span>
                    <label>
                        <%# Eval("Equipa1")%></label>
                    <input type="text" value="<%# Eval("Resultado1")%>" />
                    <input type="text" value="<%# Eval("Resultado2")%>" />
                    <label>
                        <%# Eval("Equipa2")%></label>
                </p>
            </AlternatingItemTemplate>
            <FooterTemplate>
                <p style="padding-top: 15px">
                    <span>&nbsp;</span><input class="submit" type="submit" id="btnApostar" value="Apostar" />
                </p>
                </div>
            </FooterTemplate>
        </asp:Repeater>--%>
        <%-- <asp:Repeater ID="rptUltimosJogos" runat="server">
            <HeaderTemplate>
                <table style="width: 50%">
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td class="icon">
                        <%# Eval("Equipa1")%>
                    </td>
                    <td>
                        <%# Eval("Resultado1")%>
                    </td>
                    <td>
                        <%# Eval("Resultado2")%>
                    </td>
                    <td>
                        <%# Eval("Equipa2")%>
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr>
                    <td class="icon">
                        <%# Eval("Equipa1")%>
                    </td>
                    <td>
                        <%# Eval("Resultado1")%>
                    </td>
                    <td>
                        <%# Eval("Resultado2")%>
                    </td>
                    <td>
                        <%# Eval("Equipa2")%>
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>--%>
    </div>
    <h2>Apostas Anteriores</h2>
    <div class="form_settings">
        <p>
            <span>Jornadas</span>
            <select id="ddlVerApostas">
                <option selected="selected" value="0">Selecciona uma jornada</option>
            </select>
        </p>
    </div>
    <div id="grdVerApostas">
    </div>
</asp:Content>
