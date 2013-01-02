using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace ApostasBalas.Pages
{
    public partial class Campeonatos : ApostasBalasBusinessModel.PlatformModel
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Logic.VerificarSessao();
                rptCompeticoes.DataSource = Logic.ObterCompeticoes();
                rptCompeticoes.DataBind();                              
            }
        }
    }
}