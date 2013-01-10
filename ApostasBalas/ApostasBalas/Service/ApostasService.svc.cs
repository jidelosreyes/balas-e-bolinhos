using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using Newtonsoft.Json;

namespace ApostasBalas.Service
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ApostasService : ApostasBalasBusinessModel.PlatformModel
    {
        // To use HTTP GET, add [WebGet] attribute. (Default ResponseFormat is WebMessageFormat.Json)
        // To create an operation that returns XML,
        //     add [WebGet(ResponseFormat=WebMessageFormat.Xml)],
        //     and include the following line in the operation body:
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
        #region Login

        [OperationContract]
        public bool Login(string Email, string Password, string Lembrarme)
        {
            return Logic.Login(Email, Password, bool.Parse(Lembrarme));
        }

        [OperationContract]
        public void Registar(string Email, string Nome, string Password)
        {
            Logic.RegistarUtilizador(Email, Nome, Password);
        }

        [OperationContract]
        public void RecuperarPassword(string Email)
        {
            Logic.RecuperarPassword(Email);
        }

        #endregion

        #region Master

        [OperationContract]
        public void LogOut()
        {
            Logic.LogOut();
        }

        #endregion

        #region Competicoes

        [OperationContract]
        public string ObterCompeticoesRegistadas()
        {
            var CompeticoesRegistadas = JsonConvert.SerializeObject(Logic.ObterCompeticoesRegistadas());
            return CompeticoesRegistadas;
        }

        [OperationContract]
        public void RegistarCompeticao(string IdCompeticao)
        {
            Logic.RegistarCompeticao(IdCompeticao);
        }

        [OperationContract]
        public void ActivarCompeticao(string IdCompeticao)
        {
            Logic.ActivarCompeticao(IdCompeticao);
        }

        #endregion

        [OperationContract]
        public string ObterJornadas()
        {
            var Jornadas = JsonConvert.SerializeObject(Logic.ObterJornadas());
            return Jornadas;
        }

        [OperationContract]
        public string ObterJornadaById(string IdJornada)
        {
            var Jornada = JsonConvert.SerializeObject(Logic.ObterJornadaById(IdJornada));
            return Jornada;
        }

        [OperationContract]
        public string ObterJogosApostar(string IdJornada)
        {
            var Jogos = JsonConvert.SerializeObject(Logic.ObterJogosApostar(IdJornada));
            return Jogos;
        }

        [OperationContract]
        public void Apostar()
        {

        }

    }
}
