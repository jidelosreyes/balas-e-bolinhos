using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

namespace ApostasBalas.Pages
{
    public partial class Home : ApostasBalasBusinessModel.PlatformModel
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static void LogOut()
        {
            Logic.LogOut();
        }
    }
}