using System.Web;

namespace ApostasBalasBusinessModel
{
    public abstract class PlatformModel : System.Web.UI.Page
    {
        public static BusinessModel Logic = BusinessModel.GetInstance;

        public string NomeUtilizadorSessao
        {
            get
            {
                if (HttpContext.Current.Session[ConstantsModel.NomeUtilizadorSessao] == null || HttpContext.Current.Session[ConstantsModel.NomeUtilizadorSessao].Equals(string.Empty))
                    return string.Empty;
                return HttpContext.Current.Session[ConstantsModel.NomeUtilizadorSessao].ToString();
            }
            set
            {
                HttpContext.Current.Session[ConstantsModel.NomeUtilizadorSessao] = value;
            }
        }

        public string PasswordSessao
        {
            get
            {
                if (HttpContext.Current.Session[ConstantsModel.PasswordSessao] == null || HttpContext.Current.Session[ConstantsModel.PasswordSessao].Equals(string.Empty))
                    return string.Empty;
                return HttpContext.Current.Session[ConstantsModel.PasswordSessao].ToString();
            }
            set
            {
                HttpContext.Current.Session[ConstantsModel.PasswordSessao] = value;
            }
        }

        public string IdUtilizadorSessao
        {
            get
            {
                if (HttpContext.Current.Session[ConstantsModel.IdUtilizadorSessao] == null || HttpContext.Current.Session[ConstantsModel.IdUtilizadorSessao].Equals(string.Empty))
                    return string.Empty;
                return HttpContext.Current.Session[ConstantsModel.IdUtilizadorSessao].ToString();
            }
            set
            {
                HttpContext.Current.Session[ConstantsModel.IdUtilizadorSessao] = value;
            }
        }

        public bool IsCookie
        {
            get
            {
                if (HttpContext.Current.Request.Cookies[ConstantsModel.CookieName] != null)
                    return true;
                return false;
            }
        }
    }
}
