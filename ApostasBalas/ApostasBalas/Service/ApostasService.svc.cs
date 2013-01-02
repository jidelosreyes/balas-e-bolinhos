using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

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

    }
}
