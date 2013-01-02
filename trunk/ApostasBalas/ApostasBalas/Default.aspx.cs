using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Text.RegularExpressions;
using System.Configuration;

namespace ApostasBalas
{
    public partial class Default : ApostasBalasBusinessModel.PlatformModel
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsCookie)
            {
                Logic.CookieLogin();
            }
        }
    }
}