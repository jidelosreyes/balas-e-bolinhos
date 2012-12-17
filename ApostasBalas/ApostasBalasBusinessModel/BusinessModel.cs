using System;
using System.Configuration;
using ApostasBalasDataModel;
using log4net;

namespace ApostasBalasBusinessModel
{
    public sealed class BusinessModel
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

        public void RegistarUtilizador()
        {
            var Utilizador = new Utilizador()
            {
                Administrador = false,
                DataActualizacao = DateTime.Now,
                DataCriacao = DateTime.Now,
                NomeUtilizador = "Teste",
                Password="Teste"
            };
            ApostasBalasDB.Utilizador.AddObject(Utilizador);
            ApostasBalasDB.SaveChanges();
        }       
    }

    public abstract class PlatformModel : System.Web.UI.Page
    {
        public static BusinessModel Logic = BusinessModel.GetInstance;
    }

    public static class LoggingModel
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

    public static class ConstantsModel
    {
        public static string LogMode = ConfigurationManager.AppSettings["LogMode"].ToString();
        public const int SessionTimeOut = 15;
        public const string Seccao = "Seccao";
        public const string IdAnuncio = "IdAnuncio";
        public const string IdAnuncioDefaultValue = "0";

        public const string Index = "Index";
        public const string Detalhe = "Detalhe";
        public const string Anunciar = "Anunciar";
        public const string Termos = "Termos";

        public const string BemVindo = "Bem Vindo ";

        public const string SeccaoMasculina = "H";
        public const string SeccaoFeminina = "M";

        public const string DistritoPT = "DistritoPT";
        public const string TipoConvivio = "TipoConvivio";
        public const string OutroHorario = "Outro";
        public const string HorarioCompleto = "24h";
        public const string DdlDefaultText = "<<Seleccione>>";
        public const string DdlDefaultValue = "-1";
        public const string DdlTextField = "Descricao";
        public const string DdlValueField = "IDReferencia";
        public const string DdlTextFieldNome = "Nome";
        public const string DdlValueFieldIdAnuncio = "IdAnuncio";

        public const string StrFalse = "False";
        public const string lblActivo = "lblActivo";
        public const string sqlDsOrders = "sqlDsOrders";
        public const string RptCmdEdit = "Edit";
        public const string RptCmdView = "View";
    }
}
