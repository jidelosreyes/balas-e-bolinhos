using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

namespace ApostasBalas.Pages
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblNome.Text = ApostasBalasBusinessModel.PlatformModel.Logic.VerificarSessao();

                var Noticia = ApostasBalasBusinessModel.PlatformModel.Logic.ObterUltimaNoticia();
                tituloNoticia.InnerText = Noticia.Titulo;
                descricaoNoticia.InnerText = Noticia.Descricao;
                dataNoticia.InnerText = Noticia.DataCriacao.ToString();
            }
        }
    }
}