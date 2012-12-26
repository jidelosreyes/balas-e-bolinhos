using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using ApostasBalasDataModel;
using log4net;
using System.Collections.Generic;

namespace ApostasBalasBusinessModel
{
    public sealed class BusinessModel : PlatformModel
    {
        #region Instancia & Contructor

        public static BusinessModel GetInstance { get { return Instance(); } }
        private static BusinessModel LogicModelInstance = null;
        private static BusinessModel Instance()
        {
            if (null == LogicModelInstance)
                LogicModelInstance = new BusinessModel();
            return LogicModelInstance;
        }

        ApostasBalasDBEntities ApostasBalasDB = null;
        private BusinessModel()
        {
            if (ApostasBalasDB == null)
            {
                ApostasBalasDB = new ApostasBalasDBEntities();
            }
        }

        #endregion

        public class PrimeirosClassificados
        {
            public string Nome { get; set; }
            public int? Jogos { get; set; }
            public int? Vitorias { get; set; }
            public int? Empates { get; set; }
            public int? Derrotas { get; set; }
            public int? Pontos { get; set; }
        }

        public Noticia ObterUltimaNoticia()
        {
            try
            {
                return ApostasBalasDB.Noticia.OrderByDescending(n => n.DataCriacao).FirstOrDefault();
            }
            catch (Exception Ex)
            {
                LoggingModel.Log(ConstantsModel.LogMode, Ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw;
            }
        }

        public List<Jogo> ObterUltimaJornada()
        {
            try
            {
                var Id = Int32.Parse(IdUtilizadorSessao);
                var CompeticaoActiva = ApostasBalasDB.UtilizadorCompeticao.Where(uc => uc.IdUtilizador == Id & uc.Activo == true).Select(uc => uc.IdCompeticao).FirstOrDefault();
                var UltimaJornada = ApostasBalasDB.Jornada.OrderByDescending(j => j.IdJornada).Where(j => j.IdCompeticao == CompeticaoActiva).Select(j => j.IdJornada).FirstOrDefault();
                var Jogos = (from j in ApostasBalasDB.Jogo
                             join jjc in ApostasBalasDB.JornadaJogoCompeticao
                             on j.IdJogo equals jjc.IdJogo
                             where jjc.IdCompeticao == CompeticaoActiva & jjc.IdJornada == UltimaJornada
                             select j).ToList();
                return Jogos;
            }
            catch (Exception Ex)
            {
                LoggingModel.Log(ConstantsModel.LogMode, Ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw;
            }
        }

        public List<PrimeirosClassificados> ObterPrimeirosClassificados()
        {
            try
            {
                var Id = Int32.Parse(IdUtilizadorSessao);
                var _PrimeirosClassificados = ApostasBalasDB.Classificacao
                    .Join(ApostasBalasDB.Utilizador, c => c.IdUtilizador, u => u.IdUtilizador, (c, u) => new { c, u })
                    .Join(ApostasBalasDB.UtilizadorCompeticao, uuc => uuc.u.IdUtilizador, uc => uc.IdUtilizador, (uuc, uc) => new { uuc, uc })
                    .Where(w => w.uuc.u.IdUtilizador == Id && w.uc.Activo == true)
                    .Select(pc => new PrimeirosClassificados
                    {
                        Nome = pc.uuc.u.NomeUtilizador,
                        Derrotas = pc.uuc.c.Derrotas,
                        Empates = pc.uuc.c.Empates,
                        Jogos = pc.uuc.c.Jogos,
                        Pontos = pc.uuc.c.Pontos,
                        Vitorias = pc.uuc.c.Vitorias
                    }).OrderByDescending(o => o.Pontos).ToList();
                return _PrimeirosClassificados;
            }
            catch (Exception Ex)
            {
                LoggingModel.Log(ConstantsModel.LogMode, Ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw;
            }
        }

        public string ObterNomeCompeticaoActiva()
        {
            try
            {
                var Id = Int32.Parse(IdUtilizadorSessao);
                var NomeCompeticao = (from uc in ApostasBalasDB.UtilizadorCompeticao
                                      join c in ApostasBalasDB.Competicao
                                      on uc.IdCompeticao equals c.IdCompeticao
                                      where uc.IdUtilizador == Id && uc.Activo == true
                                      select c.Descricao).FirstOrDefault();
                return NomeCompeticao;
            }
            catch (Exception Ex)
            {
                LoggingModel.Log(ConstantsModel.LogMode, Ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw;
            }
        }

        public void RegistarUtilizador(string Email, string Nome, string Password)
        {
            try
            {
                var Utilizador = new Utilizador()
                           {
                               Activo = false,
                               Administrador = false,
                               DataActualizacao = DateTime.Now,
                               DataCriacao = DateTime.Now,
                               Email = Email,
                               NomeUtilizador = Nome,
                               Password = Password
                           };
                ApostasBalasDB.Utilizador.AddObject(Utilizador);
                ApostasBalasDB.SaveChanges();
            }
            catch (Exception Ex)
            {
                LoggingModel.Log(ConstantsModel.LogMode, Ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw;
            }
        }

        public void RecuperarPassword(string Email)
        {
            try
            {

            }
            catch (Exception Ex)
            {
                LoggingModel.Log(ConstantsModel.LogMode, Ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw;
            }
        }

        public bool Login(string Email, string Password, bool Lembrarme)
        {
            try
            {
                var Utilizador = ApostasBalasDB.Utilizador.Where(u => u.Email == Email & u.Password == Password & u.Activo == true).SingleOrDefault();
                if (Utilizador != null)
                {
                    NomeUtilizadorSessao = Utilizador.NomeUtilizador;
                    PasswordSessao = Utilizador.Password;
                    IdUtilizadorSessao = Utilizador.IdUtilizador.ToString();
                    HttpContext.Current.Session.Timeout = ConstantsModel.SessionTimeOut;
                    if (Lembrarme)
                    {
                        HttpCookie Cookie = new HttpCookie(ConstantsModel.CookieName);
                        Cookie.Value = IdUtilizadorSessao;
                        Cookie.Expires = DateTime.Now.AddDays(5);
                        HttpContext.Current.Response.Cookies.Add(Cookie);
                    }
                    return true;
                }
                return false;
            }
            catch (Exception Ex)
            {
                LoggingModel.Log(ConstantsModel.LogMode, Ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw;
            }
        }

        public void LogOut()
        {
            try
            {
                HttpContext.Current.Session.Clear();
                HttpContext.Current.Session.Abandon();
                if (IsCookie)
                {
                    HttpCookie Cookie = new HttpCookie(ConstantsModel.CookieName);
                    Cookie.Expires = DateTime.Now.AddDays(-1d);
                    HttpContext.Current.Response.Cookies.Add(Cookie);
                }
            }
            catch (Exception Ex)
            {
                LoggingModel.Log(ConstantsModel.LogMode, Ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw;
            }
        }

        public void CookieLogin()
        {
            try
            {
                var IdUtilizador = Int32.Parse(HttpContext.Current.Request.Cookies[ConstantsModel.CookieName].Value.ToString());
                var Utilizador = ApostasBalasDB.Utilizador.Where(u => u.IdUtilizador == IdUtilizador).SingleOrDefault();
                NomeUtilizadorSessao = Utilizador.NomeUtilizador;
                PasswordSessao = Utilizador.Password;
                IdUtilizadorSessao = Utilizador.IdUtilizador.ToString();
                Session.Timeout = ConstantsModel.SessionTimeOut;
                HttpContext.Current.Response.RedirectToRoute(ConstantsModel.HomeRoute);
            }
            catch (Exception Ex)
            {
                LoggingModel.Log(ConstantsModel.LogMode, Ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw;
            }
        }

        public string ObterNomeUtilizador()
        {
            try
            {
                if (NomeUtilizadorSessao != string.Empty & PasswordSessao != string.Empty & IdUtilizadorSessao != string.Empty)
                {
                    return NomeUtilizadorSessao;
                }
                return string.Empty;
            }
            catch (Exception Ex)
            {
                LoggingModel.Log(ConstantsModel.LogMode, Ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw;
            }
        }

        public void VerificarSessao()
        {
            try
            {
                if (NomeUtilizadorSessao != string.Empty & PasswordSessao != string.Empty & IdUtilizadorSessao != string.Empty)
                {
                    return;
                }
                if (IsCookie)
                {
                    CookieLogin();
                }
            }
            catch (Exception Ex)
            {
                LoggingModel.Log(ConstantsModel.LogMode, Ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw;
            }
        }
    }

    public abstract class PlatformModel : System.Web.UI.Page
    {
        public static BusinessModel Logic = BusinessModel.GetInstance;

        public string NomeUtilizadorSessao
        {
            get
            {
                if (HttpContext.Current.Session["NomeUtilizadorSessao"] == null || HttpContext.Current.Session["NomeUtilizadorSessao"].Equals(string.Empty))
                    return string.Empty;
                return HttpContext.Current.Session["NomeUtilizadorSessao"].ToString();
            }
            set
            {
                HttpContext.Current.Session["NomeUtilizadorSessao"] = value;
            }
        }

        public string PasswordSessao
        {
            get
            {
                if (HttpContext.Current.Session["PasswordSessao"] == null || HttpContext.Current.Session["PasswordSessao"].Equals(string.Empty))
                    return string.Empty;
                return HttpContext.Current.Session["PasswordSessao"].ToString();
            }
            set
            {
                HttpContext.Current.Session["PasswordSessao"] = value;
            }
        }

        public string IdUtilizadorSessao
        {
            get
            {
                if (HttpContext.Current.Session["IdUtilizadorSessao"] == null || HttpContext.Current.Session["IdUtilizadorSessao"].Equals(string.Empty))
                    return string.Empty;
                return HttpContext.Current.Session["IdUtilizadorSessao"].ToString();
            }
            set
            {
                HttpContext.Current.Session["IdUtilizadorSessao"] = value;
            }
        }

        public bool IsCookie
        {
            get
            {
                if (HttpContext.Current.Request.Cookies[ApostasBalasBusinessModel.ConstantsModel.CookieName] != null)
                    return true;
                return false;
            }
        }
    }

    public static class ConstantsModel
    {
        public static string LogMode = ConfigurationManager.AppSettings["LogMode"].ToString();
        public static string CookieName = ConfigurationManager.AppSettings["CookieName"].ToString();
        public const int SessionTimeOut = 15;
        public const string BemVindo = "Bem Vindo ";
        public const string HomeRoute = "Home";
        public const string InicioRoute = "Inicio";
    }

    internal static class LoggingModel
    {
        public static void Log(string Mode, Exception Ex, string Method)
        {
            ILog log = LogManager.GetLogger(Method);
            log4net.Config.XmlConfigurator.Configure();
            switch (Mode)
            {
                case "Error":
                    log.Error("Error", Ex);
                    break;
                case "Debug":
                    log.Debug("Debug", Ex);
                    break;
                case "Info":
                    log.Info("Info", Ex);
                    break;
                case "Warning":
                    log.Warn("Warning", Ex);
                    break;
                default:
                    log.Fatal("Fatal", Ex);
                    break;
            }
        }
    }
}
