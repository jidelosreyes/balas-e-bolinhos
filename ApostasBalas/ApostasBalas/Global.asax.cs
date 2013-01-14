using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;

namespace ApostasBalas
{
    public class Global : System.Web.HttpApplication
    {
        private void RegisterRoutes(RouteCollection Routes)
        {
            Routes.MapPageRoute("Inicio", "Inicio", "~/Default.aspx");
            Routes.MapPageRoute("Home", "Home", "~/Pages/Home.aspx");
            Routes.MapPageRoute("Apostas", "Apostas", "~/Pages/Apostas.aspx");
            Routes.MapPageRoute("Campeonatos", "Campeonatos", "~/Pages/Campeonatos.aspx");
            Routes.MapPageRoute("Classificacao", "Classificacao", "~/Pages/Classificacao.aspx");
            Routes.MapPageRoute("Estatisticas", "Estatisticas", "~/Pages/Estatisticas.aspx");
            Routes.MapPageRoute("Admin", "Admin", "~/Pages/Admin.aspx");            
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}