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

        public class PrimeiroClassificado
        {
            public string Nome { get; set; }
            public int? Jogos { get; set; }
            public int? Vitorias { get; set; }
            public int? Empates { get; set; }
            public int? Derrotas { get; set; }
            public int? Pontos { get; set; }
        }

        public class UltimoResultado
        {
            public string Equipa1 { get; set; }
            public string Equipa2 { get; set; }
            public string Resultado1 { get; set; }
            public string Resultado2 { get; set; }
        }

        public class CompeticaoRegistada
        {
            public string Descricao { get; set; }
            public int? IdUtilizador { get; set; }
            public int? IdCompeticao { get; set; }
            public bool? Activo { get; set; }
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

        public List<UltimoResultado> ObterUltimaJornada()
        {
            try
            {
                var Id = Int32.Parse(IdUtilizadorSessao);
                var CompeticaoActiva = ApostasBalasDB.UtilizadorCompeticao.Where(uc => uc.IdUtilizador == Id & uc.Activo == true).Select(uc => uc.IdCompeticao).FirstOrDefault();
                var UltimaJornada = ApostasBalasDB.Jornada.OrderByDescending(j => j.IdJornada).Where(j => j.IdCompeticao == CompeticaoActiva).Select(j => j.IdJornada).FirstOrDefault();
                var Jogos = ApostasBalasDB.Jogo
                     .Join(ApostasBalasDB.JornadaJogoCompeticao, j => j.IdJogo, jc => jc.IdJogo, (j, jc) => new { j, jc })
                     .Where(jc => jc.jc.IdCompeticao == CompeticaoActiva && jc.jc.IdJornada == UltimaJornada && jc.j.Realizado == true)
                     .Select(j => j.j).ToList();
                var UltimoResultado = new List<UltimoResultado>();
                foreach (var item in Jogos)
                {
                    string[] Equipas = item.Descricao.Split(ConstantsModel.Delimiter);
                    string[] Resultados = item.Resultado.Split(ConstantsModel.Delimiter);
                    UltimoResultado.Add(new UltimoResultado
                    {
                        Equipa1 = Equipas[0],
                        Equipa2 = Equipas[1],
                        Resultado1 = Resultados[0],
                        Resultado2 = Resultados[1]
                    });
                }
                return UltimoResultado;
            }
            catch (Exception Ex)
            {
                LoggingModel.Log(ConstantsModel.LogMode, Ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw;
            }
        }

        public List<PrimeiroClassificado> ObterPrimeirosClassificados()
        {
            try
            {
                var Id = Int32.Parse(IdUtilizadorSessao);
                var _PrimeirosClassificados = ApostasBalasDB.Classificacao
                    .Join(ApostasBalasDB.Utilizador, c => c.IdUtilizador, u => u.IdUtilizador, (c, u) => new { c, u })
                    .Join(ApostasBalasDB.UtilizadorCompeticao, uuc => uuc.u.IdUtilizador, uc => uc.IdUtilizador, (uuc, uc) => new { uuc, uc })
                    .Where(w => w.uuc.u.IdUtilizador == Id && w.uc.Activo == true)
                    .Select(pc => new PrimeiroClassificado
                    {
                        Nome = pc.uuc.u.NomeUtilizador,
                        Derrotas = pc.uuc.c.Derrotas,
                        Empates = pc.uuc.c.Empates,
                        Jogos = pc.uuc.c.Jogos,
                        Pontos = pc.uuc.c.Pontos,
                        Vitorias = pc.uuc.c.Vitorias
                    }).OrderByDescending(o => o.Pontos).Take(5).ToList();
                return _PrimeirosClassificados;
            }
            catch (Exception Ex)
            {
                LoggingModel.Log(ConstantsModel.LogMode, Ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw;
            }
        }

        public List<Competicao> ObterCompeticoes()
        {
            try
            {
                return ApostasBalasDB.Competicao.OrderBy(c => c.IdCompeticao).ToList();
            }
            catch (Exception Ex)
            {
                LoggingModel.Log(ConstantsModel.LogMode, Ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw;
            }
        }

        public List<CompeticaoRegistada> ObterCompeticoesRegistadas()
        {
            try
            {
                var Id = Int32.Parse(IdUtilizadorSessao);
                return ApostasBalasDB.Competicao
                    .Join(ApostasBalasDB.UtilizadorCompeticao, c => c.IdCompeticao, uc => uc.IdCompeticao, (c, uc) => new { c, uc })
                    .Where(uc => uc.uc.IdUtilizador == Id)
                    .OrderByDescending(c => c.c.IdCompeticao)
                    .Select(c => new CompeticaoRegistada
                    {
                        Descricao = c.c.Descricao,
                        Activo = c.uc.Activo,
                        IdCompeticao = c.c.IdCompeticao,
                        IdUtilizador = c.uc.IdUtilizador
                    })
                    .ToList();
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
                var NomeCompeticao = ApostasBalasDB.UtilizadorCompeticao
                    .Join(ApostasBalasDB.Competicao, uc => uc.IdCompeticao, c => c.IdCompeticao, (uc, c) => new { uc, c })
                    .Where(uc => uc.uc.IdUtilizador == Id && uc.uc.Activo == true)
                    .Select(c => c.c.Descricao)
                    .FirstOrDefault();

                return NomeCompeticao;
            }
            catch (Exception Ex)
            {
                LoggingModel.Log(ConstantsModel.LogMode, Ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw;
            }
        }

        public void RegistarCompeticao(string IdCompeticao)
        {
            try
            {
                ApostasBalasDB.UtilizadorCompeticao.AddObject(new UtilizadorCompeticao
                {
                    IdCompeticao = Int32.Parse(IdCompeticao),
                    IdUtilizador = Int32.Parse(IdUtilizadorSessao),
                    Activo = false,
                    DataActualizacao = DateTime.Now,
                    DataCriacao = DateTime.Now
                });
                ApostasBalasDB.SaveChanges();
            }
            catch (Exception Ex)
            {
                LoggingModel.Log(ConstantsModel.LogMode, Ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw;
            }
        }

        public void ActivarCompeticao(string IdCompeticao)
        {
            try
            {
                var Id = Int32.Parse(IdCompeticao);
                var IdUtilizador = Int32.Parse(IdUtilizadorSessao);
                var _CompeticaoActiva = ApostasBalasDB.UtilizadorCompeticao
                    .Where(uc => uc.IdCompeticao == Id && uc.IdUtilizador == IdUtilizador)
                    .FirstOrDefault();
                _CompeticaoActiva.Activo = true;
                ApostasBalasDB.UtilizadorCompeticao.ApplyCurrentValues(_CompeticaoActiva);

                var _CompeticoesDesactivar = ApostasBalasDB.UtilizadorCompeticao
                    .Where(uc => uc.IdCompeticao != Id && uc.IdUtilizador == IdUtilizador)
                    .ToList();
                foreach (var item in _CompeticoesDesactivar)
                {
                    item.Activo = false;
                    ApostasBalasDB.UtilizadorCompeticao.ApplyCurrentValues(item);
                }
                
                ApostasBalasDB.SaveChanges();
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
    }

    internal static class LoggingModel
    {
        public static void Log(string Mode, Exception Ex, string Method)
        {
            ILog log = LogManager.GetLogger(Method);
            log4net.Config.XmlConfigurator.Configure();
            switch (Mode)
            {
                case ConstantsModel.Error:
                    log.Error(ConstantsModel.Error, Ex);
                    break;
                case ConstantsModel.Debug:
                    log.Debug(ConstantsModel.Debug, Ex);
                    break;
                case ConstantsModel.Info:
                    log.Info(ConstantsModel.Info, Ex);
                    break;
                case ConstantsModel.Warning:
                    log.Warn(ConstantsModel.Warning, Ex);
                    break;
                default:
                    log.Fatal(ConstantsModel.Fatal, Ex);
                    break;
            }
        }
    }
}
