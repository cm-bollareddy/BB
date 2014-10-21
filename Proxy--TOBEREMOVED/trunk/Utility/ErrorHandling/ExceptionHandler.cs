using System;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Diagnostics;
using System.Xml;

namespace Pbs.WebServices.Utility
{
	/// <summary>
	/// Summary description for ExceptionHandler.
	/// </summary>
	public class ExceptionHandler
	{
		public ExceptionHandler()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static void ThrowSoapException(Exception ex)
		{
			Type exceptionType = ex.GetType();
			//if (ex is BVException)
			if (exceptionType == typeof(BVException))
			{
				BVException bvEx = (BVException) ex;
				
				//Check if the xml error foarmat is empty or not.
				if( bvEx.XMLErrorFormat!=string.Empty)
				{
					XmlDocument xmlErrDoc =  new XmlDocument();
					xmlErrDoc.LoadXml(bvEx.XMLErrorFormat);
					XmlNode xmlErrorNode = xmlErrDoc.SelectSingleNode("Detail"); 
					if (null!=xmlErrorNode)
					{
						throw new SoapException(bvEx.Message + " @ " + DateTime.Now, SoapException.ServerFaultCode,bvEx.Actor.ToString(),xmlErrorNode);
						


					}
				}
				else
				{
					throw new SoapException(bvEx.Message + " @ " + DateTime.Now, SoapException.ServerFaultCode, bvEx.Actor.ToString(), ex);
				}
						
			}
			else if (exceptionType == typeof(ServiceException))
			{
				ServiceException serEx = (ServiceException) ex;
				throw new SoapException(serEx.Message + " @ " + DateTime.Now, SoapException.ServerFaultCode, serEx.Actor.ToString(), ex);
			}
			else
			{
				throw new SoapException("WebService error. " + ex.Message + " @ " + DateTime.Now, SoapException.ServerFaultCode, "WebService", ex);
			}
		}


	}
}
