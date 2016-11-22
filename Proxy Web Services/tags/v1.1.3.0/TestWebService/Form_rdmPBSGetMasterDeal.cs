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
	/// Summary description for Form_rdmPBSGetMasterDeal.
	/// </summary>
	public class Form_rdmPBSGetMasterDeal : Form_Base
	{
		private System.Windows.Forms.GroupBox grpBoxGetMasterDeal;
		private System.Windows.Forms.Button btnGetMasterDeal;
		private System.Windows.Forms.Label lblLimitingDate;
		private System.Windows.Forms.TextBox txtLimitingDate;
		private System.Windows.Forms.DataGrid dgOrionAPIs;
		private System.Windows.Forms.GroupBox groupBoxListDealsByMasterDeal;
		private System.Windows.Forms.Button btnListDealsByMasterDeal;
		private System.Windows.Forms.Label lblMasterDealId;
		private System.Windows.Forms.TextBox txtMasterDealId;
		private System.Windows.Forms.Label lblGetMasterDealHelp;
		private System.Windows.Forms.Label lblListDealsByMasterDealHelp;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form_rdmPBSGetMasterDeal()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.grpBoxGetMasterDeal = new System.Windows.Forms.GroupBox();
			this.lblGetMasterDealHelp = new System.Windows.Forms.Label();
			this.btnGetMasterDeal = new System.Windows.Forms.Button();
			this.lblLimitingDate = new System.Windows.Forms.Label();
			this.txtLimitingDate = new System.Windows.Forms.TextBox();
			this.dgOrionAPIs = new System.Windows.Forms.DataGrid();
			this.groupBoxListDealsByMasterDeal = new System.Windows.Forms.GroupBox();
			this.lblListDealsByMasterDealHelp = new System.Windows.Forms.Label();
			this.btnListDealsByMasterDeal = new System.Windows.Forms.Button();
			this.lblMasterDealId = new System.Windows.Forms.Label();
			this.txtMasterDealId = new System.Windows.Forms.TextBox();
			this.grpBoxGetMasterDeal.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgOrionAPIs)).BeginInit();
			this.groupBoxListDealsByMasterDeal.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnLogout
			// 
			this.btnLogout.Location = new System.Drawing.Point(712, 56);
			this.btnLogout.Name = "btnLogout";
			// 
			// btnLogin
			// 
			this.btnLogin.Location = new System.Drawing.Point(712, 32);
			this.btnLogin.Name = "btnLogin";
			// 
			// btnClearLog
			// 
			this.btnClearLog.Location = new System.Drawing.Point(712, 80);
			this.btnClearLog.Name = "btnClearLog";
			// 
			// txtWebServiceURL
			// 
			this.txtWebServiceURL.Name = "txtWebServiceURL";
			// 
			// txtLog
			// 
			this.txtLog.Location = new System.Drawing.Point(0, 390);
			this.txtLog.Name = "txtLog";
			this.txtLog.Size = new System.Drawing.Size(792, 112);
			// 
			// grpBoxGetMasterDeal
			// 
			this.grpBoxGetMasterDeal.Controls.Add(this.lblGetMasterDealHelp);
			this.grpBoxGetMasterDeal.Controls.Add(this.btnGetMasterDeal);
			this.grpBoxGetMasterDeal.Controls.Add(this.lblLimitingDate);
			this.grpBoxGetMasterDeal.Controls.Add(this.txtLimitingDate);
			this.grpBoxGetMasterDeal.Location = new System.Drawing.Point(8, 32);
			this.grpBoxGetMasterDeal.Name = "grpBoxGetMasterDeal";
			this.grpBoxGetMasterDeal.Size = new System.Drawing.Size(480, 72);
			this.grpBoxGetMasterDeal.TabIndex = 14;
			this.grpBoxGetMasterDeal.TabStop = false;
			this.grpBoxGetMasterDeal.Text = "GetMasterDeal";
			// 
			// lblGetMasterDealHelp
			// 
			this.lblGetMasterDealHelp.Location = new System.Drawing.Point(344, 48);
			this.lblGetMasterDealHelp.Name = "lblGetMasterDealHelp";
			this.lblGetMasterDealHelp.Size = new System.Drawing.Size(100, 16);
			this.lblGetMasterDealHelp.TabIndex = 34;
			this.lblGetMasterDealHelp.Text = "Results in Datagrid";
			// 
			// btnGetMasterDeal
			// 
			this.btnGetMasterDeal.Location = new System.Drawing.Point(320, 16);
			this.btnGetMasterDeal.Name = "btnGetMasterDeal";
			this.btnGetMasterDeal.Size = new System.Drawing.Size(152, 23);
			this.btnGetMasterDeal.TabIndex = 15;
			this.btnGetMasterDeal.Text = "GetMasterDeal";
			this.btnGetMasterDeal.Click += new System.EventHandler(this.btnGetMasterDeal_Click);
			// 
			// lblLimitingDate
			// 
			this.lblLimitingDate.Location = new System.Drawing.Point(8, 16);
			this.lblLimitingDate.Name = "lblLimitingDate";
			this.lblLimitingDate.Size = new System.Drawing.Size(72, 16);
			this.lblLimitingDate.TabIndex = 2;
			this.lblLimitingDate.Text = "LimitingDate";
			// 
			// txtLimitingDate
			// 
			this.txtLimitingDate.Location = new System.Drawing.Point(88, 16);
			this.txtLimitingDate.Name = "txtLimitingDate";
			this.txtLimitingDate.Size = new System.Drawing.Size(120, 20);
			this.txtLimitingDate.TabIndex = 1;
			this.txtLimitingDate.Text = "1/1/2005";
			// 
			// dgOrionAPIs
			// 
			this.dgOrionAPIs.DataMember = "";
			this.dgOrionAPIs.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgOrionAPIs.Location = new System.Drawing.Point(8, 192);
			this.dgOrionAPIs.Name = "dgOrionAPIs";
			this.dgOrionAPIs.Size = new System.Drawing.Size(776, 184);
			this.dgOrionAPIs.TabIndex = 15;
			// 
			// groupBoxListDealsByMasterDeal
			// 
			this.groupBoxListDealsByMasterDeal.Controls.Add(this.lblListDealsByMasterDealHelp);
			this.groupBoxListDealsByMasterDeal.Controls.Add(this.btnListDealsByMasterDeal);
			this.groupBoxListDealsByMasterDeal.Controls.Add(this.lblMasterDealId);
			this.groupBoxListDealsByMasterDeal.Controls.Add(this.txtMasterDealId);
			this.groupBoxListDealsByMasterDeal.Location = new System.Drawing.Point(8, 112);
			this.groupBoxListDealsByMasterDeal.Name = "groupBoxListDealsByMasterDeal";
			this.groupBoxListDealsByMasterDeal.Size = new System.Drawing.Size(480, 72);
			this.groupBoxListDealsByMasterDeal.TabIndex = 16;
			this.groupBoxListDealsByMasterDeal.TabStop = false;
			this.groupBoxListDealsByMasterDeal.Text = "ListDealsByMasterDeal";
			// 
			// lblListDealsByMasterDealHelp
			// 
			this.lblListDealsByMasterDealHelp.Location = new System.Drawing.Point(344, 48);
			this.lblListDealsByMasterDealHelp.Name = "lblListDealsByMasterDealHelp";
			this.lblListDealsByMasterDealHelp.Size = new System.Drawing.Size(100, 16);
			this.lblListDealsByMasterDealHelp.TabIndex = 35;
			this.lblListDealsByMasterDealHelp.Text = "Results in Datagrid";
			// 
			// btnListDealsByMasterDeal
			// 
			this.btnListDealsByMasterDeal.Location = new System.Drawing.Point(320, 16);
			this.btnListDealsByMasterDeal.Name = "btnListDealsByMasterDeal";
			this.btnListDealsByMasterDeal.Size = new System.Drawing.Size(152, 23);
			this.btnListDealsByMasterDeal.TabIndex = 15;
			this.btnListDealsByMasterDeal.Text = "ListDealsByMasterDeal";
			this.btnListDealsByMasterDeal.Click += new System.EventHandler(this.btnListDealsByMasterDeal_Click);
			// 
			// lblMasterDealId
			// 
			this.lblMasterDealId.Location = new System.Drawing.Point(8, 16);
			this.lblMasterDealId.Name = "lblMasterDealId";
			this.lblMasterDealId.Size = new System.Drawing.Size(72, 16);
			this.lblMasterDealId.TabIndex = 2;
			this.lblMasterDealId.Text = "MasterDealId";
			// 
			// txtMasterDealId
			// 
			this.txtMasterDealId.Location = new System.Drawing.Point(88, 16);
			this.txtMasterDealId.Name = "txtMasterDealId";
			this.txtMasterDealId.Size = new System.Drawing.Size(120, 20);
			this.txtMasterDealId.TabIndex = 1;
			this.txtMasterDealId.Text = "3385369";
			// 
			// Form_rdmPBSGetMasterDeal
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(792, 502);
			this.Controls.Add(this.groupBoxListDealsByMasterDeal);
			this.Controls.Add(this.dgOrionAPIs);
			this.Controls.Add(this.grpBoxGetMasterDeal);
			this.Name = "Form_rdmPBSGetMasterDeal";
			this.Text = "Form_rdmPBSGetMasterDeal";
			this.Load += new System.EventHandler(this.Form_rdmPBSGetMasterDeal_Load);
			this.Controls.SetChildIndex(this.btnLogin, 0);
			this.Controls.SetChildIndex(this.btnLogout, 0);
			this.Controls.SetChildIndex(this.btnClearLog, 0);
			this.Controls.SetChildIndex(this.txtLog, 0);
			this.Controls.SetChildIndex(this.txtWebServiceURL, 0);
			this.Controls.SetChildIndex(this.grpBoxGetMasterDeal, 0);
			this.Controls.SetChildIndex(this.dgOrionAPIs, 0);
			this.Controls.SetChildIndex(this.groupBoxListDealsByMasterDeal, 0);
			this.grpBoxGetMasterDeal.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgOrionAPIs)).EndInit();
			this.groupBoxListDealsByMasterDeal.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnGetMasterDeal_Click(object sender, System.EventArgs e)
		{
			dgOrionAPIs.DataSource = null;

			if (!ValidateSession())
				return;


			if (txtLimitingDate.Text == string.Empty)
			{
				this.Log("Enter a Limiting Date ", true);
				return;
			}

			if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
			{
				BVWebService.BVWebService oBVWebService = new BVWebService.BVWebService();
				oBVWebService.Url = this.txtWebServiceURL.Text + @"/Service.asmx";

				this.Log("Start GetMasterDeal Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
				DataSet oDataSetResult = oBVWebService.GetMasterDeal(m_sBVSessionId, txtLimitingDate.Text);
				dgOrionAPIs.DataSource = oDataSetResult;
				this.Log("End GetMasterDeal Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );
			}
			else
			{
				this.Log("Please log in. Session Null", true);
			}
		}

		private void Form_rdmPBSGetMasterDeal_Load(object sender, System.EventArgs e)
		{
		
		}

		private void btnListDealsByMasterDeal_Click(object sender, System.EventArgs e)
		{

			dgOrionAPIs.DataSource = null;

			if (!ValidateSession())
				return;


			if (txtMasterDealId.Text == string.Empty)
			{
				this.Log("Enter a Master Deal Id", true);
				return;
			}

			if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
			{
				BVWebService.BVWebService oBVWebService = new BVWebService.BVWebService();
				oBVWebService.Url = this.txtWebServiceURL.Text + @"/Service.asmx";

				this.Log("Start ListDealsByMasterDeal Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
				DataSet oDataSetResult = oBVWebService.ListDealsByMasterDeal(m_sBVSessionId, Convert.ToInt32(txtMasterDealId.Text));
				dgOrionAPIs.DataSource = oDataSetResult;
				this.Log("End ListDealsByMasterDeal Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );
			}
			else
			{
				this.Log("Please log in. Session Null", true);
			}


		
		}
	}
}
