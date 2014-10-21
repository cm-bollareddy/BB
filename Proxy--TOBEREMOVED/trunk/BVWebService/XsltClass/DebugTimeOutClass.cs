using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Xml;
using System.Xml.Xsl;
using System.IO;
using System.Globalization;
using Pbs.WebServices.Utility;

using TVSServer = OrionProxy;

namespace BVWebService
{
	/// <summary>
	/// DebugTimeOutClass: Implement the DebugTimeOut web method 
	/// </summary>
	class DebugTimeOutClass
	{
		

		public DebugTimeOutClass()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public void DebugTimeOut(string strSessionID,int nTimeOut)
		{
			

			
			Tracer oTracer = new Tracer();
			oTracer.LogInfo("Entering DebugTimeOut.\n strSessionID=" + strSessionID);
		
			

			

			//
			// Go ahead and search based upon given parameters
			//
            TVSServer.rdmPBSAuthorization oPBSAuth;

			try
			{
				oPBSAuth = ComponentFactory.CreateAuthorizationClass();
				
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentAccessFailure,
					"Error while creating server component: " + ex.Message,
					"Component= TVSServer.rdmPBSAuthorizationClass\nparams(" +strSessionID+ ")",
					ex);
			}

			int nErrorCode = 0;
			string strErrorText = "";
			
			try
			{
				nErrorCode = oPBSAuth.DebugTimeOut(strSessionID, nTimeOut,out strErrorText);
			}
			catch (Exception ex)
			{
				throw new BVException(
					BVException.ExceptionCode.ComponentExecutionFailure,
					"Error while executing server component method: " + ex.Message,
					"SessionID= " + strSessionID + ", Params(" + nTimeOut +  ")",
					ex);
			}

			if (nErrorCode == 0)
			{
				
			}
			else
			{
				throw new BVException(nErrorCode, strErrorText, "SessionID= " + strSessionID + ", Params(" + nTimeOut + ")");
			}
		}
	}
}
