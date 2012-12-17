﻿using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using ApostasBalasDataModel;
using log4net;

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

        public void Login(string Email, string Password)
        {
            try
            {                
                var Utilizador = ApostasBalasDB.Utilizador.Where(u => u.Email == Email & u.Password == Password & u.Activo == true).Single();
                if (Utilizador != null)
                {
                    NomeUtilizadorSessao = Utilizador.NomeUtilizador;
                    PasswordSessao = Utilizador.Password;
                    IdUtilizadorSessao = Utilizador.IdUtilizador.ToString();
                    Response.RedirectToRoute(ConstantsModel.HomeRoute);
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

        internal string NomeUtilizadorSessao
        {
            get
            {
                if (Session["NomeUtilizadorSessao"] == null || Session["NomeUtilizadorSessao"].Equals(string.Empty))
                {
                    return string.Empty;
                }
                return Session["NomeUtilizadorSessao"].ToString();
            }
            set
            {
                Session["NomeUtilizadorSessao"] = value;
            }
        }

        internal string PasswordSessao
        {
            get
            {
                if (Session["PasswordSessao"] == null || Session["PasswordSessao"].Equals(string.Empty))
                {
                    return string.Empty;
                }
                return Session["PasswordSessao"].ToString();
            }
            set
            {
                Session["PasswordSessao"] = value;
            }
        }

        internal string IdUtilizadorSessao
        {
            get
            {
                if (Session["IdUtilizadorSessao"].Equals(string.Empty))
                {
                    return string.Empty;
                }
                return Session["IdUtilizadorSessao"].ToString();
            }
            set
            {
                Session["IdUtilizadorSessao"] = value;
            }
        }

        internal bool VerificarSessao()
        {
            if (NomeUtilizadorSessao != string.Empty & PasswordSessao != string.Empty)
            {
                return true;
            }
            return false;
        }
    }

    public static class ConstantsModel
    {
        public static string LogMode = ConfigurationManager.AppSettings["LogMode"].ToString();
        public const int SessionTimeOut = 15;
        public const string BemVindo = "Bem Vindo ";
        public const string HomeRoute = "Home";
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
