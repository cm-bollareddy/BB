using System;
using System.Diagnostics;

namespace Pbs.WebServices.Utility
{
	/// <summary>
	/// Summary description for EventLogger.
	/// </summary>
	public class EventLogger : EventLog
	{
		private const string EVENT_LOG_NAME_CONFIG_KEY = "ProxyEventLogName";
		private const string EVENT_LOG_SOURCE_CONFIG_KEY = "ProxyEventLogSource";

		public EventLogger()
		{
			this.Log	= System.Configuration.ConfigurationManager.AppSettings[EVENT_LOG_NAME_CONFIG_KEY];
            this.Source = System.Configuration.ConfigurationManager.AppSettings[EVENT_LOG_SOURCE_CONFIG_KEY];
		}

		public void LogError(Exception ex)
		{
			try
			{
				//
				// Iterate through all the inner exceptions and create a log of error messages...
				//
				string errorMessage = "";
				Exception innerException = ex.InnerException;
				while (innerException != null)
				{
					errorMessage += "\n" + innerException.GetType().ToString() + ": " + innerException.Message;
					innerException = innerException.InnerException;
				}
				if (errorMessage != "")
					errorMessage += "\n\n";

				//
				// Now write them to the event log
				//
				if (ex is ServiceException)
				{
					ServiceException serviceException = (ServiceException) ex;

					WriteEntry(
						serviceException.Message + "\n" + errorMessage + serviceException.StackTrace + "\n\n" + serviceException.ErrorInfo,
						EventLogEntryType.Error);
				}
				else if (ex is BVException)
				{
					BVException bvException = (BVException) ex;

					WriteEntry(
						bvException.Message + "\n" + errorMessage + bvException.StackTrace + "\n\n" + bvException.ErrorInfo,
						EventLogEntryType.Error);
				}
				else
				{
					WriteEntry(
						ex.Message + "\n" + errorMessage + ex.StackTrace,
						EventLogEntryType.Error);
				}
			}
			catch
			{
				// Ignore any and all error in logging!
			}
		}

		public void LogInfo(string strInfo)
		{
			try
			{
				WriteEntry(strInfo, EventLogEntryType.Information);
			}
			catch 
			{
				
				//throw e;
				// Ignore any and all error in logging!
			}
		}

		public void LogWarning(string strWarning)
		{
			try
			{
				WriteEntry(strWarning, EventLogEntryType.Warning);
			}
			catch
			{
				// Ignore any and all error in logging!
			}
		}

		public void LogError(string strError)
		{
			try
			{
				WriteEntry(strError, EventLogEntryType.Error);
			}
			catch
			{
				// Ignore any and all error in logging!
			}
		}
	}
}
