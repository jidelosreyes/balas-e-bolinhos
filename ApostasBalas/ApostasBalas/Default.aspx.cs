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
        public static void Login(string Email, string Password)
        {
            Logic.Login(Email, Password);
        }

        [WebMethod]
        public static void Registar(string Email, string Nome, string Password)
        {            
            Logic.RegistarUtilizador(Email, Nome, Password);            
        }        

        [WebMethod]
        public static void RecuperarPassword(string Email)
        {
            Logic.RecuperarPassword(Email);
        }
    }
}