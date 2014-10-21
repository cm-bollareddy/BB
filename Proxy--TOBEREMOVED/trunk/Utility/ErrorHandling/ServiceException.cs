using System;

namespace Pbs.WebServices.Utility
{
	/// <summary>
	/// Summary description for ServiceException.
	/// </summary>
	public class ServiceException : Exception
	{
		public enum ExceptionCode
		{
			NoError = 0,

			//
			// XML/XSLT related errors
			//
			InvalidXml,
			InvalidXslt,
			InvalidDataSet,
			XsltTransformationError,

			//
			// Configuration errors
			//
			InvalidConfiguration,

			//
			// Method specific...
			//
			InvalidParameters
		};

		public enum ExceptionActor
		{
			None,
			ServerComponent,
			Service,
			Client
		}

		private ExceptionCode m_ErrorCode;
		public ExceptionCode ErrorCode
		{
			get
			{
				return m_ErrorCode;
			}
		}

		private ExceptionActor m_Actor;
		public ExceptionActor Actor
		{
			get
			{
				return m_Actor;
			}
		}

		private string m_Message;
		public override string Message
		{
			get
			{
				return m_Message;
			}
		}

		private string m_ErrorInfo;
		public string ErrorInfo
		{
			get
			{
				if (m_ErrorInfo != null)
					return m_ErrorInfo;
				else
					return "";
			}
		}

		public ServiceException(ExceptionCode exceptionCode, string message)
		{
			m_ErrorCode  = exceptionCode;
			m_Message    = message;
			m_ErrorInfo  = null;
			m_Actor		 = ExceptionActor.Service;
		}

		public ServiceException(ExceptionCode exceptionCode, string message, string errorInfo)
		{
			m_ErrorCode  = exceptionCode;
			m_Message    = message;
			m_ErrorInfo  = errorInfo;
			m_Actor		 = ExceptionActor.Service;
		}

		public ServiceException(ExceptionCode exceptionCode, string message, Exception exception) : base(message, exception)
		{
			m_ErrorCode  = exceptionCode;
			m_Message    = message;
			m_ErrorInfo  = null;
			m_Actor		 = ExceptionActor.Service;
		}

		public ServiceException(ExceptionCode exceptionCode, string message, string errorInfo, Exception exception) : base(message, exception)
		{
			m_ErrorCode  = exceptionCode;
			m_Message    = message;
			m_ErrorInfo  = errorInfo;
			m_Actor		 = ExceptionActor.Service;
		}

		public ServiceException(ExceptionCode exceptionCode, string message, string errorInfo, ExceptionActor actor) : base(message)
		{
			m_ErrorCode  = exceptionCode;
			m_Message    = message;
			m_ErrorInfo  = errorInfo;
			m_Actor		 = actor;

			if (actor == ExceptionActor.Client)
			{
				m_Message = "Client-side error. " + message;
			}
			else if (actor == ExceptionActor.Service)
			{
				m_Message = "Service error. " + message;
			}
			else
			{
				m_Message = "Server component error. " + message;
			}
		}
	}
}
