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
                ApostasBalasBusinessModel.PlatformModel.Logic.VerificarSessao(); 
                lblNome.Text = ApostasBalasBusinessModel.PlatformModel.Logic.ObterNomeUtilizador();
                bool? Admin = ApostasBalasBusinessModel.PlatformModel.Logic.ObterUtilizadorAdmin();
                if (Admin != null && Admin == true)
                {
                    liAdmin.Visible = true;
                }
                var Noticia = ApostasBalasBusinessModel.PlatformModel.Logic.ObterUltimaNoticia();
                if (Noticia != null)
                {
                    tituloNoticia.InnerText = Noticia.Titulo;
                    descricaoNoticia.InnerText = Noticia.Descricao;
                    dataNoticia.InnerText = Noticia.DataCriacao.ToString();
                }
                var Jogos = ApostasBalasBusinessModel.PlatformModel.Logic.ObterUltimaJornada();
                if (Jogos != null)
                {
                    rptUltimosJogos.DataSource = Jogos;
                    rptUltimosJogos.DataBind();
                }
            }
        }
    }
}