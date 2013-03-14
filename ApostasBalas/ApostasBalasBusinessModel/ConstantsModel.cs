using System.Configuration;

namespace ApostasBalasBusinessModel
{
    public static class ConstantsModel
    {
        public static string LogMode = ConfigurationManager.AppSettings["LogMode"].ToString();
        public static string CookieName = ConfigurationManager.AppSettings["CookieName"].ToString();
        public const int SessionTimeOut = 15;
        public const string BemVindo = "Bem Vindo ";
        public const string HomeRoute = "Home";
        public const string InicioRoute = "Inicio";
        public const string NomeUtilizadorSessao = "NomeUtilizadorSessao";
        public const string PasswordSessao = "PasswordSessao";
        public const string IdUtilizadorSessao = "IdUtilizadorSessao";
        public const string Error = "Error";
        public const string Debug = "Debug";
        public const string Info = "Info";
        public const string Warning = "Warning";
        public const string Fatal = "Fatal";
        public const char Delimiter = '-';
        public const string NullResult = "0-0";
        public const string Zero = "0";
    }
}
