using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ApostasBalas.Pages
{
    public partial class Apostas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
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