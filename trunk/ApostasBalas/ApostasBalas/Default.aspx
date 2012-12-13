<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ApostasBalas.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Balas & Bolinhos</title>
    <link href="../Css/style.css" rel="stylesheet" />

    <link href="Content/themes/custom-theme/jquery-ui.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.8.3.min.js"></script>
    <script src="Scripts/jquery-ui-1.9.2.min.js"></script>
    <script>
        $.fx.speeds._default = 1000;
        $(document).ready(function () {
            $("#mdRecuperarPassword").dialog({
                autoOpen: false,
                draggable: false,
                resizable: false,
                show: "blind",
                hide: "blind"
            });
            $("#mdRegistar").dialog({
                autoOpen: false,
                draggable: false,
                resizable: false,
                show: "blind",
                hide: "blind"
            });
            $("#btnRecuperarPassword").click(function () {
                $("#mdRecuperarPassword").dialog("open");
                return false;
            });
            $("#btnRegistar").click(function () {
                $("#mdRegistar").dialog("open");
                return false;
            });
            // Add the page method call as an onclick handler for the button.
            $("#btnLogin").click(function () {
                //get the string from the textbox
                $.ajax({
                    type: "POST",
                    url: "testSearch.aspx/GetMyShippingDate",
                    contentType: "application/json; charset=utf-8",
                    data: "{'tracking_num': '" + $("#txtTrackingNumber").val() + "'}",
                    dataType: "json",
                    success: function (date) {
                        // Replace the div's content with the page method's return.
                        //Success(date);
                        alert('sucesso');
                    },
                    error: Failed
                });
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
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
                            <span>Login:</span>
                            <input type="text" name="name" value="" />
                        </p>
                        <p>
                            <span>Password:</span>
                            <input type="password" name="name" value="" />
                        </p>
                        <p>
                            <input id="btnLogin" class="submit" type="submit" value="Login" />
                            <input id="btnRegistar" class="submit" type="submit" value="Registar" />
                            <a id="btnRecuperarPassword" href="#">Recuperar Password</a>
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
        <div id="mdRecuperarPassword" title="Recuperar Password">
            <div class="login_settings">
                <p>
                    <span>Email:</span>
                    <input type="text" name="name" value="" />
                </p>
                <p>
                    <input id="btnSubmeterEmail" class="submit" type="submit" value="Submeter" />
                </p>
            </div>
        </div>
        <div id="mdRegistar" title="Registar">
            <div class="login_settings">
                <p>
                    <span>Email:</span>
                    <input type="text" name="name" value="" />
                </p>
                <p>
                    <span>Nome:</span>
                    <input type="text" name="name" value="" />
                </p>
                <p>
                    <span>Password:</span>
                    <input type="password" name="name" value="" />
                </p>
                <p>
                    <span>Confirmar Password:</span>
                    <input type="password" name="name" value="" />
                </p>
                <p>
                    <input id="btnSubmeterRegisto" class="submit" type="submit" value="Registar" />
                </p>
            </div>
        </div>
    </form>
</body>
</html>
