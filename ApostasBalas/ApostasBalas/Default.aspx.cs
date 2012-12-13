using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

namespace ApostasBalas
{
    public partial class Default : System.Web.UI.Page
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
        public static string Registar()
        {
            return DateTime.Now.ToString("dd/MMM/yyyy HH:mm:ss");
        }

        [WebMethod]
        public static string RecuperarPassword()
        {
            return DateTime.Now.ToString("dd/MMM/yyyy HH:mm:ss");
        }
    }
}