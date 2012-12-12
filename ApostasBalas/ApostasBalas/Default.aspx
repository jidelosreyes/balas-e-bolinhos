<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ApostasBalas.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Balas & Bolinhos</title>
    <link href="../Css/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="main">
        <div id="header">
            <div id="logo">
                <div id="logo_text">
                    <!-- class="logo_colour", allows you to change the colour of the text -->
                    <h1>
                        <a href="">Balas &<span class="logo_colour"> Bolinhos</span></a></h1>
                    <h2>
                        A meta é a camisola amarela!</h2>
                </div>
            </div>
        </div>
        <div id="site_content">
            <div class="sidebar">
                <h1>
                    Login</h1>
                <h4>
                    Bem Vindo [NomeUtilizador]
                </h4>
                <h1>
                    Noticias</h1>
                <h4>
                    [Titulo]</h4>
                <h5>
                    [Data]</h5>
                <p>
                    [Descricao]
                </p>
            </div>
            <div id="content">
                <h1>
                    Informacao</h1>
                <h5>
                    Publicado por B&B - A Gerência
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
    </form>
</body>
</html>
