using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;
using System.Diagnostics;
using Pbs.WebServices.Utility;

using TVSServer = OrionProxy;

namespace BVWebService 
{
	/// <summary>
	/// Summary description for Global.
	/// </summary>
	public class Global : System.Web.HttpApplication
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		private static TVSServer.rdmPBSAuthorization m_oPBSAuthorization = null;

		public Global()
		{
			InitializeComponent();
		}	
		
		protected void Application_Start(Object sender, EventArgs e)
		{
			//
			// Create a PBS object and hang on to it... this keeps the server up without closing our sessions
			//
			if (m_oPBSAuthorization == null)
			{
				lock(this)
				{
					try
					{
						m_oPBSAuthorization = ComponentFactory.CreateAuthorizationClass();
						//new rdmPBSAuthorizationClass();
					}
					catch (Exception ex)
					{
						Tracer oTracer = new Tracer();
						oTracer.LogError("Error while creating PBSAuthorization server component. " + ex.Message);
					}
				}
			}
		}
 
		protected void Session_Start(Object sender, EventArgs e)
		{
			Session["ID"] = "";
		}

		protected void Application_BeginRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_EndRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_Error(Object sender, EventArgs e)
		{

		}

		protected void Session_End(Object sender, EventArgs e)
		{
			try
			{
				if ((string) Session["ID"] != "")
				{
					// Log this session out of BroadView server
					BVSession oSession = new BVSession();
					oSession.Logout((string) Session["ID"]);
				}
			}
			catch(Exception ex)
			{
				Tracer oTracer = new Tracer();
				oTracer.LogError(ex);
			}
		}

		protected void Application_End(Object sender, EventArgs e)
		{
			m_oPBSAuthorization = null;
		}
			
		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.components = new System.ComponentModel.Container();
		}
		#endregion
	}
}

