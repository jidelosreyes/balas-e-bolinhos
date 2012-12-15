<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ApostasBalas.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Balas & Bolinhos</title>
    <link href="../Css/style.css" rel="stylesheet" />
    <link href="Content/themes/custom-theme/jquery-ui.css" rel="stylesheet" />
    <script type="text/javascript" src="Scripts/jquery-1.8.3.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery-ui-1.9.2.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery.validate.min.js"></script>
    <script type="text/javascript" src="Code/Login.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div id="main">
                    <div id="header">
                        <div id="logo">
                            <div id="logo_text">
                                <!-- class="logo_colour", allows you to change the colour of the text -->
                                <h1>
                                    <a href="#">Balas &<span class="logo_colour"> Bolinhos</span></a></h1>
                                <h2>A meta é a camisola amarela!</h2>
                            </div>
                        </div>
                    </div>
                    <div id="site_content">
                        <div class="sidebar">
                            <h1>Login</h1>
                            <div class="login_settings">
                                <p>
                                    <span>Email:</span>
                                    <input id="txtEmail" type="text" title="Insere o mail." />
                                </p>
                                <p>
                                    <span>Password:</span>
                                    <input id="txtPassword" type="password" title="Insere a pass." />
                                </p>
                                <p>
                                    <span>Lembrar-me?</span>
                                    <input type="checkbox" class="checkbox" />
                                </p>
                                <p>
                                    <input id="btnLogin" class="submit" type="button" value="Login" />
                                    <input id="btnRegistar" class="submit" type="button" value="Registar" />
                                </p>
                                <p>
                                    <a id="btnRecuperar" href="#">Recuperar Password</a>
                                </p>
                            </div>
                        </div>
                        <div id="content">
                            <h1>Informacao</h1>
                            <h5>Publicado por B&B - A Gerência
                            </h5>
                            <br />
                            <p>
                                Página destinada somente a membros Balas.
                            </p>
                            <p>
                                Se és balas e ainda não estás registado efectua já o teu registo!
                            </p>
                            <p>
                                Se já es membro efecuta o teu login no menu à tua direita. Só os mais fortes resistem...
                            </p>
                        </div>
                    </div>
                    <div id="footer">
                        <p>
                            Copyright &copy; Balas & Bolinhos
                        </p>
                    </div>
                </div>
                <%--<span>Email Address</span>
                <input type="text" name="email" id="email">
                <button type="submit">Submit</button>--%>
                <div id="mdRecuperarPassword" title="Recuperar Password">
                    <div class="login_settings">
                        <p>
                            <span>Email:</span>
                            <input type="text" name="txtEmail" id="txtEmailRecup">
                        </p>
                        <p>
                            <input id="btnRecuperarPassword" class="submit" type="button" value="Submeter" />
                        </p>
                    </div>
                </div>
                <div id="mdRegistar" title="Registar">
                    <div class="login_settings">
                        <p>
                            <span>Email:</span>
                            <input type="text" />
                        </p>
                        <p>
                            <span>Nome:</span>
                            <input type="text" />
                        </p>
                        <p>
                            <span>Password:</span>
                            <input type="password" />
                        </p>
                        <p>
                            <span>Confirmar Password:</span>
                            <input type="password" />
                        </p>
                        <p>
                            <input id="btnSubmeterRegisto" class="submit" type="button" value="Registar" />
                        </p>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>

</body>
</html>
