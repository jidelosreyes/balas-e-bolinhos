using System;
using log4net;

namespace ApostasBalasBusinessModel
{
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
