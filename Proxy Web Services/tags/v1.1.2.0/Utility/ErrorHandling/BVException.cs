using System;

namespace Pbs.WebServices.Utility
{
	/// <summary>
	/// Summary description for BVException.
	/// </summary>
	public class BVException : Exception
	{
		public enum ExceptionCode
		{
			GenericError = 0,
			ClientError,
			ServiceError,
			ServerComponentError,

			// These error are raised by COM runtime...
			ComponentAccessFailure = 1000,
			ComponentExecutionFailure,
			UnknownException
		};

		public enum ExceptionActor
		{
			None,
			ServerComponent,
			Service,
			Client
		}

		private const int PBS_ERRORCODE_NO_ERROR		= 0x000;
		private const int PBS_ERRORCODE_UNKNOWN_ERROR	= 0x001;
		private const int PBS_DATABASE_CONNECTION_ERROR = 0x002;
		private const int PBS_DATASET_OPEN_ERROR		= 0x004;
		private const int PBS_INCORRECT_XML_DATA		= 0x008;
		private const int PBS_UPDATE_DATASET_ERROR		= 0x010;
		private const int PBS_ERRORCODE_EXCEPTION		= 0x020;
		private const int PBS_INVALID_SESSIONID			= 0x040;
		private const int PBS_GETTING_SESSION_MANAGER	= 0x080;
		private const int PBS_CORRUPTED_SESSION_MANAGER = 0x100;
		private const int PBS_INVALID_LOCKID			= 0x200;
		//private const int PBS_RECORD_LOCKED				= 0x020;

        
        //New Error Flags with the COM Rewrite of the BroadView OrionProxy
        private const int PROXY_SUCCESS                 = 0x10000000; //SUCCESS
        private const int PROXY_BVS_REQUEST_FAILURE     = 0x10000001; //BVSM request has failed
        private const int PROXY_DB_NOT_FOUND            = 0x10000002; //Database has not been found
        private const int PROXY_DB_NOT_ACCESSIBLE       = 0x10000004; //Database is not accessible
        private const int PROXY_RESPONSE_TIMEOUT        = 0x10000008; //Response timeout
        private const int PROXY_GENERIC_EXCEPTION       = 0x10000020; //Exception


		//definitions of the XML elements to sent back in case of a BV Error.
		private const string PBS_XML_ERROR_HEADER = "<?xml version='1.0' encoding='utf-8'?><Detail>@</Detail>";
		private const string PBS_XML_ERROR_ELEMENT = "<ErrorDetails>@</ErrorDetails>";
		private const string PBS_XML_ERROR_SUB_ELEMENT = "<ErrorElement>@</ErrorElement>";
		private const string PBS_XML_ERROR_COMBINED_CODE = "<ErrorCombinedCode>@</ErrorCombinedCode>";
		private const string PBS_XML_ERROR_INFO = "<ErrorInfo>@</ErrorInfo>";
		private const string PBS_XML_ERROR_CODE = "<ErrorCode>@</ErrorCode>";
		private const string PBS_XML_ERROR_DESC = "<ErrorDesc>@</ErrorDesc>";


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

		private string m_xmlError = string.Empty;
		public string XMLErrorFormat
		{
			get{return m_xmlError;}
		}

		public BVException(ExceptionCode exceptionCode, string message, string errorInfo)
		{
			m_ErrorCode  = exceptionCode;
			m_ErrorInfo  = errorInfo;

			if (exceptionCode == ExceptionCode.ClientError)
			{
				m_Actor = ExceptionActor.Client;
				m_Message = "Client-side error. " + message;
			}
			else
			{
				m_Actor = ExceptionActor.ServerComponent;
				m_Message = "Server component error. " + message;
			}
		}

		public BVException(ExceptionCode exceptionCode, string message, string errorInfo, Exception exception) : base(message, exception)
		{
			m_ErrorCode  = exceptionCode;
			m_ErrorInfo  = errorInfo;

			if (exceptionCode == ExceptionCode.ClientError)
			{
				m_Actor   = ExceptionActor.Client;
				m_Message = "Client-side error. " + message;
			}
			else
			{
				m_Actor   = ExceptionActor.ServerComponent;
				m_Message = "Server component error. " + message;
			}
		}

		public BVException(int errorCode, string message, string errorInfo)
		{
			
			m_Message = "";
			string m_xml = string.Empty;
			string m_sCode = string.Empty;
			string m_sDesc = string.Empty;
		

			//
			// Report as many errors as we can...
			//
			if ((errorCode & PBS_ERRORCODE_UNKNOWN_ERROR) == PBS_ERRORCODE_UNKNOWN_ERROR)
			{
				m_Message	+= " Error raised, but errorcode is unknown.";
				m_ErrorCode  = ExceptionCode.ServerComponentError;

				//Build the xml
				m_sDesc =ReplaceErrorValues( BVException.PBS_XML_ERROR_DESC,"Error raised, but errorcode is unknown.");
				m_sCode = ReplaceErrorValues(BVException.PBS_XML_ERROR_CODE,"0x" + Convert.ToString(PBS_ERRORCODE_UNKNOWN_ERROR, 16));
				m_xml += ReplaceErrorValues(BVException.PBS_XML_ERROR_SUB_ELEMENT,m_sCode + m_sDesc);
				
			}
			if ((errorCode & PBS_ERRORCODE_EXCEPTION) == PBS_ERRORCODE_EXCEPTION)
			{
				m_Message	+= "Exception Raised.";
				m_ErrorCode  = ExceptionCode.ServerComponentError;

				//Build the xml
				m_sDesc =ReplaceErrorValues( BVException.PBS_XML_ERROR_DESC,"Exception Raised.");
				m_sCode = ReplaceErrorValues(BVException.PBS_XML_ERROR_CODE,"0x" + Convert.ToString(PBS_ERRORCODE_EXCEPTION, 16));
				m_xml += ReplaceErrorValues(BVException.PBS_XML_ERROR_SUB_ELEMENT,m_sCode + m_sDesc);
				
			}

			if ((errorCode & PBS_DATABASE_CONNECTION_ERROR) == PBS_DATABASE_CONNECTION_ERROR)
			{
				m_Message	+= " Database connection error.";
				m_ErrorCode  = ExceptionCode.ServerComponentError;

				m_sDesc =ReplaceErrorValues( BVException.PBS_XML_ERROR_DESC,"Database connection error.");
				m_sCode = ReplaceErrorValues(BVException.PBS_XML_ERROR_CODE,"0x" + Convert.ToString(PBS_DATABASE_CONNECTION_ERROR, 16));
				m_xml += ReplaceErrorValues(BVException.PBS_XML_ERROR_SUB_ELEMENT,m_sCode + m_sDesc);

			}

			if ((errorCode & PBS_GETTING_SESSION_MANAGER) == PBS_GETTING_SESSION_MANAGER)
			{
				m_Message   += " Error getting session manager.";
				m_ErrorCode  = ExceptionCode.ServerComponentError;
				
				//Build the xml
				m_sDesc =ReplaceErrorValues( BVException.PBS_XML_ERROR_DESC," Error getting session manager.");
				m_sCode = ReplaceErrorValues(BVException.PBS_XML_ERROR_CODE,"0x" + Convert.ToString(PBS_GETTING_SESSION_MANAGER, 16));
				m_xml += ReplaceErrorValues(BVException.PBS_XML_ERROR_SUB_ELEMENT,m_sCode + m_sDesc);



			}

			if ((errorCode & PBS_CORRUPTED_SESSION_MANAGER) == PBS_CORRUPTED_SESSION_MANAGER)
			{
				m_Message	+= " Invalid or corrupted session manager.";
				m_ErrorCode  = ExceptionCode.ServerComponentError;

				//Build the xml
				m_sDesc =ReplaceErrorValues( BVException.PBS_XML_ERROR_DESC," Invalid or corrupted session manager.");
				m_sCode = ReplaceErrorValues(BVException.PBS_XML_ERROR_CODE,"0x" + Convert.ToString(PBS_CORRUPTED_SESSION_MANAGER, 16));
				m_xml += ReplaceErrorValues(BVException.PBS_XML_ERROR_SUB_ELEMENT,m_sCode + m_sDesc);

			}

			if ((errorCode & PBS_DATASET_OPEN_ERROR) == PBS_DATASET_OPEN_ERROR)
			{
				m_Message	+= " Dataset open error.";
				//m_ErrorCode  = ExceptionCode.ServerComponentError;
				m_ErrorCode  = ExceptionCode.ClientError;

				
				//Build the xml
				m_sDesc =ReplaceErrorValues( BVException.PBS_XML_ERROR_DESC," Dataset open error.");
				m_sCode = ReplaceErrorValues(BVException.PBS_XML_ERROR_CODE,"0x" + Convert.ToString(PBS_DATASET_OPEN_ERROR, 16));
				m_xml += ReplaceErrorValues(BVException.PBS_XML_ERROR_SUB_ELEMENT,m_sCode + m_sDesc);


			}

			if ((errorCode & PBS_UPDATE_DATASET_ERROR) == PBS_UPDATE_DATASET_ERROR)
			{
				m_Message	+= " Dataset update failed.";
				m_ErrorCode  = ExceptionCode.ClientError;


				//Build the xml
				m_sDesc =ReplaceErrorValues( BVException.PBS_XML_ERROR_DESC," Dataset update failed.");
				m_sCode = ReplaceErrorValues(BVException.PBS_XML_ERROR_CODE,"0x" + Convert.ToString(PBS_UPDATE_DATASET_ERROR, 16));
				m_xml += ReplaceErrorValues(BVException.PBS_XML_ERROR_SUB_ELEMENT,m_sCode + m_sDesc);
			}

			if ((errorCode & PBS_INCORRECT_XML_DATA) == PBS_INCORRECT_XML_DATA)
			{
				m_Message	+= " Invalid data.";
				m_ErrorCode  = ExceptionCode.ClientError;

				//Build the xml
				m_sDesc =ReplaceErrorValues( BVException.PBS_XML_ERROR_DESC," Invalid data.");
				m_sCode = ReplaceErrorValues(BVException.PBS_XML_ERROR_CODE,"0x" + Convert.ToString(PBS_INCORRECT_XML_DATA, 16));
				m_xml += ReplaceErrorValues(BVException.PBS_XML_ERROR_SUB_ELEMENT,m_sCode + m_sDesc);

			}			

			if ((errorCode & PBS_INVALID_SESSIONID) == PBS_INVALID_SESSIONID)
			{
				m_Message   += " Invalid Session ID.";
				m_ErrorCode  = ExceptionCode.ClientError;

				//Build the xml
				m_sDesc =ReplaceErrorValues( BVException.PBS_XML_ERROR_DESC," Invalid Session ID.");
				m_sCode = ReplaceErrorValues(BVException.PBS_XML_ERROR_CODE,"0x" + Convert.ToString(PBS_INVALID_SESSIONID, 16));
				m_xml += ReplaceErrorValues(BVException.PBS_XML_ERROR_SUB_ELEMENT,m_sCode + m_sDesc);


			}

			if ((errorCode & PBS_INVALID_LOCKID) == PBS_INVALID_LOCKID)
			{
				m_Message	+= " Invalid Lock ID.";
				m_ErrorCode  = ExceptionCode.ClientError;

				//Build the xml
				m_sDesc =ReplaceErrorValues( BVException.PBS_XML_ERROR_DESC," Invalid Lock ID.");
				m_sCode = ReplaceErrorValues(BVException.PBS_XML_ERROR_CODE,"0x" + Convert.ToString(PBS_INVALID_LOCKID, 16));
				m_xml += ReplaceErrorValues(BVException.PBS_XML_ERROR_SUB_ELEMENT,m_sCode + m_sDesc);
			}

//NEW

            if ((errorCode & PROXY_BVS_REQUEST_FAILURE) == PROXY_BVS_REQUEST_FAILURE)
			{
				m_Message   += " BVSM request has failed.";
				m_ErrorCode  = ExceptionCode.ServerComponentError;
				
				//Build the xml
				m_sDesc =ReplaceErrorValues( BVException.PBS_XML_ERROR_DESC," BVSM request has failed.");
				m_sCode = ReplaceErrorValues(BVException.PBS_XML_ERROR_CODE,"0x" + Convert.ToString(PROXY_BVS_REQUEST_FAILURE, 16));
				m_xml += ReplaceErrorValues(BVException.PBS_XML_ERROR_SUB_ELEMENT,m_sCode + m_sDesc);
			}

            if ((errorCode & PROXY_DB_NOT_FOUND) == PROXY_DB_NOT_FOUND)
			{
				m_Message   += " Database has not been found.";
				m_ErrorCode  = ExceptionCode.ServerComponentError;
				
				//Build the xml
				m_sDesc =ReplaceErrorValues( BVException.PBS_XML_ERROR_DESC," Database has not been found.");
				m_sCode = ReplaceErrorValues(BVException.PBS_XML_ERROR_CODE,"0x" + Convert.ToString(PROXY_DB_NOT_FOUND, 16));
				m_xml += ReplaceErrorValues(BVException.PBS_XML_ERROR_SUB_ELEMENT,m_sCode + m_sDesc);
			}

            if ((errorCode & PROXY_DB_NOT_ACCESSIBLE) == PROXY_DB_NOT_ACCESSIBLE)
			{
				m_Message   += " Database is not accessible.";
				m_ErrorCode  = ExceptionCode.ServerComponentError;
				
				//Build the xml
				m_sDesc =ReplaceErrorValues( BVException.PBS_XML_ERROR_DESC," Database is not accessible.");
				m_sCode = ReplaceErrorValues(BVException.PBS_XML_ERROR_CODE,"0x" + Convert.ToString(PROXY_DB_NOT_ACCESSIBLE, 16));
				m_xml += ReplaceErrorValues(BVException.PBS_XML_ERROR_SUB_ELEMENT,m_sCode + m_sDesc);
			}

            if ((errorCode & PROXY_RESPONSE_TIMEOUT) == PROXY_RESPONSE_TIMEOUT)
			{
				m_Message   += " Response timeout.";
				m_ErrorCode  = ExceptionCode.ServerComponentError;
				
				//Build the xml
				m_sDesc =ReplaceErrorValues( BVException.PBS_XML_ERROR_DESC," Response timeout.");
				m_sCode = ReplaceErrorValues(BVException.PBS_XML_ERROR_CODE,"0x" + Convert.ToString(PROXY_RESPONSE_TIMEOUT, 16));
				m_xml += ReplaceErrorValues(BVException.PBS_XML_ERROR_SUB_ELEMENT,m_sCode + m_sDesc);
			}

            if ((errorCode & PROXY_GENERIC_EXCEPTION) == PROXY_GENERIC_EXCEPTION)
			{
				m_Message   += " Generic exception.";
				m_ErrorCode  = ExceptionCode.ServerComponentError;
				
				//Build the xml
				m_sDesc =ReplaceErrorValues( BVException.PBS_XML_ERROR_DESC," Generic exception.");
				m_sCode = ReplaceErrorValues(BVException.PBS_XML_ERROR_CODE,"0x" + Convert.ToString(PROXY_GENERIC_EXCEPTION, 16));
				m_xml += ReplaceErrorValues(BVException.PBS_XML_ERROR_SUB_ELEMENT,m_sCode + m_sDesc);
			}



			//
			// Decide the actor
			//
			if (m_ErrorCode == ExceptionCode.ClientError)
			{
				m_Actor   = ExceptionActor.Client;
				m_Message = "Client-side error. " + m_Message + " " + message;
			}
			else if (m_ErrorCode == ExceptionCode.ServiceError)
			{
				m_Actor   = ExceptionActor.Service;
				m_Message = "Service error. " + m_Message + " " + message;
			}
			else
			{
				m_Actor   = ExceptionActor.ServerComponent;
				m_Message = "Server component error. " + m_Message + " " + message;
			}

			//set the xml
			m_xml = ReplaceErrorValues(BVException.PBS_XML_ERROR_ELEMENT,m_xml);
			string m_xmlErrorCode = ReplaceErrorValues(BVException.PBS_XML_ERROR_COMBINED_CODE,"0x" + Convert.ToString(errorCode, 16));
			string m_xmlErrorDesc = ReplaceErrorValues(BVException.PBS_XML_ERROR_INFO,message);
			m_xml =  m_xmlErrorCode + m_xmlErrorDesc + m_xml  ;
			m_xmlError = ReplaceErrorValues(BVException.PBS_XML_ERROR_HEADER,m_xml);


			m_ErrorInfo = "ErrorCode=0x" + Convert.ToString(errorCode, 16) + "\n" + errorInfo;



		}

		private string ReplaceErrorValues(string sXMLContainer, string sValue)
		{
			return sXMLContainer.Replace("@",sValue).Trim();

		}
	}
}
