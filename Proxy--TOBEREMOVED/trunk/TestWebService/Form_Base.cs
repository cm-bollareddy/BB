using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using TestWebService.BVWebService;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data;

namespace TestWebService
{
	/// <summary>
	/// Summary description for Form_Base.
	/// </summary>
	public class Form_Base : System.Windows.Forms.Form
	{
		
		protected System.Windows.Forms.Button btnLogout;
		protected System.Windows.Forms.Button btnLogin;
		protected System.Windows.Forms.Button btnClearLog;

		protected string m_sBVSessionId;
		protected System.Windows.Forms.TextBox txtWebServiceURL;
		protected System.Windows.Forms.TextBox txtLog;
		
		protected System.Windows.Forms.ComboBox sltProxyEnvironment;
		protected System.Windows.Forms.CheckBox chkGlobalSaveResults;
		protected System.Windows.Forms.FolderBrowserDialog folderBrowserDialogGlobalSaveResults;
        


		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form_Base()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			LoadEnvironmentOptions();
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		protected void LoadEnvironmentOptions()
		{
			sltProxyEnvironment.DisplayMember	= "Name";
			sltProxyEnvironment.ValueMember		= "Value";

			sltProxyEnvironment.DataSource = TestWebServiceHelper.GetEnvironmentList();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		private void Logout()
		{
			if (m_sBVSessionId != null && m_sBVSessionId != "")
			{
				this.Cursor = Cursors.WaitCursor;

				try
				{
					BVWebService.BVWebService oBVWebService = new BVWebService.BVWebService();
					oBVWebService.Url				= txtWebServiceURL.Text + @"/Service.asmx";
					oBVWebService.CloseSession(m_sBVSessionId);
				}
				catch(SoapException oEx)
				{
					this.Log(oEx.StackTrace,true);
				}
				catch(Exception oEx)
				{
					this.Log(oEx.StackTrace,true);
				}
				finally
				{ 
					this.Log("Logged Out: " + m_sBVSessionId);
					m_sBVSessionId = string.Empty;
					this.Cursor = Cursors.Default;
				}
			}
			else
			{
				this.Log("No Existing Session to Log Out.  Please Log In.", true);
			}
		}
	
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtWebServiceURL = new System.Windows.Forms.TextBox();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.sltProxyEnvironment = new System.Windows.Forms.ComboBox();
            this.chkGlobalSaveResults = new System.Windows.Forms.CheckBox();
            this.folderBrowserDialogGlobalSaveResults = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtLog.Location = new System.Drawing.Point(0, 286);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(664, 112);
            this.txtLog.TabIndex = 8;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.Location = new System.Drawing.Point(592, 48);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(64, 23);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "LogOut";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogin.Location = new System.Drawing.Point(592, 24);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(64, 23);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "Login";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtWebServiceURL
            // 
            this.txtWebServiceURL.Location = new System.Drawing.Point(216, 0);
            this.txtWebServiceURL.Name = "txtWebServiceURL";
            this.txtWebServiceURL.Size = new System.Drawing.Size(576, 20);
            this.txtWebServiceURL.TabIndex = 13;
            this.txtWebServiceURL.Text = "http://localhost/BVWebService";
            // 
            // btnClearLog
            // 
            this.btnClearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearLog.Location = new System.Drawing.Point(592, 72);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(64, 23);
            this.btnClearLog.TabIndex = 14;
            this.btnClearLog.Text = "Clear Log";
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // sltProxyEnvironment
            // 
            this.sltProxyEnvironment.Location = new System.Drawing.Point(0, 0);
            this.sltProxyEnvironment.Name = "sltProxyEnvironment";
            this.sltProxyEnvironment.Size = new System.Drawing.Size(216, 21);
            this.sltProxyEnvironment.TabIndex = 15;
            this.sltProxyEnvironment.SelectedIndexChanged += new System.EventHandler(this.sltProxyEnvironment_SelectedIndexChanged);
            // 
            // chkGlobalSaveResults
            // 
            this.chkGlobalSaveResults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkGlobalSaveResults.Location = new System.Drawing.Point(592, 112);
            this.chkGlobalSaveResults.Name = "chkGlobalSaveResults";
            this.chkGlobalSaveResults.Size = new System.Drawing.Size(64, 32);
            this.chkGlobalSaveResults.TabIndex = 16;
            this.chkGlobalSaveResults.Text = "Save Results?";
            this.chkGlobalSaveResults.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            
            // 
            // Form_Base
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(664, 398);
            this.Controls.Add(this.chkGlobalSaveResults);
            this.Controls.Add(this.sltProxyEnvironment);
            this.Controls.Add(this.btnClearLog);
            this.Controls.Add(this.txtWebServiceURL);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnLogin);
            this.Name = "Form_Base";
            this.Text = "Form_Base";
            this.Closed += new System.EventHandler(this.Form_Base_Closed);
           
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void btnLogout_Click(object sender, System.EventArgs e)
		{
			Logout();
			
		}

		private void btnLogin_Click(object sender, System.EventArgs e)
		{
			if (m_sBVSessionId == null || m_sBVSessionId == "")
			{
				this.Cursor = Cursors.WaitCursor;
				try
				{
					BVWebService.BVWebService oBVWebService = new BVWebService.BVWebService();
					oBVWebService.Url				= txtWebServiceURL.Text + @"/Service.asmx";
					UserProfile oUserProfile		= TestWebServiceHelper.GetUserProfile();
					m_sBVSessionId					= oBVWebService.OpenSession(oUserProfile);
				}
				catch(SoapException oEx)
				{
					this.Log(oEx.StackTrace,true);
				}
				catch(Exception oEx)
				{
					this.Log(oEx.StackTrace,true);
				}
				finally
				{
					this.Cursor = Cursors.Default;
					this.Log("Logged In: " + m_sBVSessionId);
				}
			}
			else
			{
				this.Log("A Session is already Active. Please Log Out.", true);
			}
		}

		private void btnClearLog_Click(object sender, System.EventArgs e)
		{
			txtLog.Text = string.Empty;
		}

		

		protected void Log(string p_sMessage)
		{
			Log(p_sMessage, false);
		}
		protected void Log(string p_sMessage, bool p_bShowMessageBox)
		{
			this.txtLog.Text = p_sMessage + "\r\n" + txtLog.Text;

            Pbs.WebServices.Utility.Tracer oTracer = new Pbs.WebServices.Utility.Tracer();
            oTracer.LogDebug(p_sMessage);

			if (p_bShowMessageBox)
			{
				MessageBox.Show(this,p_sMessage);
			}
		}

		protected bool ValidateSession()
		{
			if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
			{
				return true;
			}
			else
			{
				this.Log("Session is Null.  Please Log In.", true);
				return false;
			}

			

		}

		private void Form_Base_Closed(object sender, System.EventArgs e)
		{
			if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
			{
				Log("Cleaning up open sessions");
				Logout();
			}

		}

		private void sltProxyEnvironment_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
			if (sltProxyEnvironment.SelectedItem != null)
			{
				txtWebServiceURL.Text = sltProxyEnvironment.SelectedValue.ToString(); 
			}

		}


		public void HideButton(System.Windows.Forms.Button p_oButton)
		{

			if (p_oButton != null)
			{
				p_oButton.Visible = false;
			}
		}
		


	}
}
