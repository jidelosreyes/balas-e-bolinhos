using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Text.RegularExpressions;

namespace ApostasBalas
{
    public partial class Default : ApostasBalasBusinessModel.PlatformModel
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string Login()
        {
            return DateTime.Now.ToString("dd/MMM/yyyy HH:mm:ss");
        }

        [WebMethod]
        public static void Registar(string Email, string Nome, string Password)
        {            
            Logic.RegistarUtilizador();
        }        

        [WebMethod]
        public static string RecuperarPassword(string args)
        {       
            return args;
        }
    }
}