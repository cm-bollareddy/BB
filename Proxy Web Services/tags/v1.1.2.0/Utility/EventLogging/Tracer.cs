using System;
using System.Diagnostics;
using log4net;



namespace Pbs.WebServices.Utility
{
	/// <summary>
	/// Summary description for TraceListener.
	/// </summary>
	public class Tracer
	{
        private static readonly ILog m_oLogger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static Tracer()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

		public Tracer()
		{
            
		}

        public void LogDebug(string p_sMessage)
        {
            LogDebug(p_sMessage, null);
        }

        public void LogDebug(string p_sMessage, Exception p_oException)
        {
            m_oLogger.Debug(p_sMessage, p_oException);
        }

        public void LogError(string p_sMessage)
        {
            LogError(p_sMessage, null);
        }

        public void LogError(Exception p_oException)
        {
            LogError(null, p_oException);
        }

        public void LogError(string p_sMessage, Exception p_oException)
        {
            m_oLogger.Error(p_sMessage, p_oException);
        }

        public void LogFatal(string p_sMessage)
        {
            LogFatal(p_sMessage, null);
        }

        public void LogFatal(string p_sMessage, Exception p_oException)
        {
            m_oLogger.Fatal(p_sMessage, p_oException);
        }

        public void LogInfo(string p_sMessage)
        {
            LogInfo(p_sMessage, null);
        }

        public void LogInfo(string p_sMessage, Exception p_oException)
        {
            m_oLogger.Info(p_sMessage, p_oException);
        }

        public void LogWarning(string p_sMessage)
        {
            LogWarning(p_sMessage, null);
        }

        public void LogWarning(string p_sMessage, Exception p_oException)
        {
            m_oLogger.Warn(p_sMessage, p_oException);
        }






        public bool IsDebugEnabled
        {
            get
            {
                return m_oLogger.IsDebugEnabled;
            }
        }

        
	}
}
