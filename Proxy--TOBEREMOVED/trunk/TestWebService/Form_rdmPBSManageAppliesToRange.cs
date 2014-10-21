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
	/// Summary description for Form_rdmPBSManageAppliesToRange.
	/// </summary>
	public class Form_rdmPBSManageAppliesToRange : Form_Base
	{
		private System.Windows.Forms.Label lblGetMasterDealHelp;
		private System.Windows.Forms.GroupBox grpBoxGetAssetAppliesToRangeByTab;
		private System.Windows.Forms.Button btnGetAssetAppliesToRangeByTab;
		private System.Windows.Forms.Label lblTabId;
		private System.Windows.Forms.DataGrid dgOrionAPIs;
		private System.Windows.Forms.Label lblTabType;
		private System.Windows.Forms.TextBox txtTabId;
		private System.Windows.Forms.Button btnPutAssetAppliesToRangeByTab;
		private System.Windows.Forms.GroupBox groupBoxGetPackageAppliesToRangeByTab;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnGetPackageAppliesToRangeByTab;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtPackageTabId;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnPutPackageAppliesToRangeByTab;
		private System.Windows.Forms.ComboBox sltGetAssetAppliesToRangeByTabFormType;
		private System.Windows.Forms.ComboBox sltGetPackageAppliesToRangeByTabFormType;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form_rdmPBSManageAppliesToRange()
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
			this.grpBoxGetAssetAppliesToRangeByTab = new System.Windows.Forms.GroupBox();
			this.sltGetAssetAppliesToRangeByTabFormType = new System.Windows.Forms.ComboBox();
			this.lblGetMasterDealHelp = new System.Windows.Forms.Label();
			this.btnGetAssetAppliesToRangeByTab = new System.Windows.Forms.Button();
			this.lblTabId = new System.Windows.Forms.Label();
			this.txtTabId = new System.Windows.Forms.TextBox();
			this.lblTabType = new System.Windows.Forms.Label();
			this.btnPutAssetAppliesToRangeByTab = new System.Windows.Forms.Button();
			this.dgOrionAPIs = new System.Windows.Forms.DataGrid();
			this.groupBoxGetPackageAppliesToRangeByTab = new System.Windows.Forms.GroupBox();
			this.sltGetPackageAppliesToRangeByTabFormType = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnGetPackageAppliesToRangeByTab = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.txtPackageTabId = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.btnPutPackageAppliesToRangeByTab = new System.Windows.Forms.Button();
			this.grpBoxGetAssetAppliesToRangeByTab.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgOrionAPIs)).BeginInit();
			this.groupBoxGetPackageAppliesToRangeByTab.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnLogout
			// 
			this.btnLogout.Location = new System.Drawing.Point(704, 56);
			this.btnLogout.Name = "btnLogout";
			// 
			// btnLogin
			// 
			this.btnLogin.Location = new System.Drawing.Point(704, 32);
			this.btnLogin.Name = "btnLogin";
			// 
			// btnClearLog
			// 
			this.btnClearLog.Location = new System.Drawing.Point(704, 80);
			this.btnClearLog.Name = "btnClearLog";
			// 
			// txtWebServiceURL
			// 
			this.txtWebServiceURL.Name = "txtWebServiceURL";
			this.txtWebServiceURL.Size = new System.Drawing.Size(784, 20);
			// 
			// txtLog
			// 
			this.txtLog.Location = new System.Drawing.Point(0, 494);
			this.txtLog.Name = "txtLog";
			this.txtLog.Size = new System.Drawing.Size(776, 56);
			// 
			// chkGlobalSaveResults
			// 
			this.chkGlobalSaveResults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chkGlobalSaveResults.Location = new System.Drawing.Point(696, 112);
			this.chkGlobalSaveResults.Name = "chkGlobalSaveResults";
			this.chkGlobalSaveResults.Size = new System.Drawing.Size(72, 72);
			// 
			// grpBoxGetAssetAppliesToRangeByTab
			// 
			this.grpBoxGetAssetAppliesToRangeByTab.Controls.Add(this.sltGetAssetAppliesToRangeByTabFormType);
			this.grpBoxGetAssetAppliesToRangeByTab.Controls.Add(this.lblGetMasterDealHelp);
			this.grpBoxGetAssetAppliesToRangeByTab.Controls.Add(this.btnGetAssetAppliesToRangeByTab);
			this.grpBoxGetAssetAppliesToRangeByTab.Controls.Add(this.lblTabId);
			this.grpBoxGetAssetAppliesToRangeByTab.Controls.Add(this.txtTabId);
			this.grpBoxGetAssetAppliesToRangeByTab.Controls.Add(this.lblTabType);
			this.grpBoxGetAssetAppliesToRangeByTab.Controls.Add(this.btnPutAssetAppliesToRangeByTab);
			this.grpBoxGetAssetAppliesToRangeByTab.Location = new System.Drawing.Point(8, 32);
			this.grpBoxGetAssetAppliesToRangeByTab.Name = "grpBoxGetAssetAppliesToRangeByTab";
			this.grpBoxGetAssetAppliesToRangeByTab.Size = new System.Drawing.Size(648, 72);
			this.grpBoxGetAssetAppliesToRangeByTab.TabIndex = 15;
			this.grpBoxGetAssetAppliesToRangeByTab.TabStop = false;
			this.grpBoxGetAssetAppliesToRangeByTab.Text = "AssetAppliesToRangeByTab";
			// 
			// sltGetAssetAppliesToRangeByTabFormType
			// 
			this.sltGetAssetAppliesToRangeByTabFormType.Items.AddRange(new object[] {
																						"MUS",
																						"VIS"});
			this.sltGetAssetAppliesToRangeByTabFormType.Location = new System.Drawing.Point(88, 40);
			this.sltGetAssetAppliesToRangeByTabFormType.Name = "sltGetAssetAppliesToRangeByTabFormType";
			this.sltGetAssetAppliesToRangeByTabFormType.Size = new System.Drawing.Size(120, 21);
			this.sltGetAssetAppliesToRangeByTabFormType.TabIndex = 36;
			// 
			// lblGetMasterDealHelp
			// 
			this.lblGetMasterDealHelp.Location = new System.Drawing.Point(264, 48);
			this.lblGetMasterDealHelp.Name = "lblGetMasterDealHelp";
			this.lblGetMasterDealHelp.Size = new System.Drawing.Size(100, 16);
			this.lblGetMasterDealHelp.TabIndex = 34;
			this.lblGetMasterDealHelp.Text = "Results in Datagrid";
			// 
			// btnGetAssetAppliesToRangeByTab
			// 
			this.btnGetAssetAppliesToRangeByTab.Location = new System.Drawing.Point(216, 16);
			this.btnGetAssetAppliesToRangeByTab.Name = "btnGetAssetAppliesToRangeByTab";
			this.btnGetAssetAppliesToRangeByTab.Size = new System.Drawing.Size(200, 23);
			this.btnGetAssetAppliesToRangeByTab.TabIndex = 15;
			this.btnGetAssetAppliesToRangeByTab.Text = "GetAssetAppliesToRangeByTab";
			this.btnGetAssetAppliesToRangeByTab.Click += new System.EventHandler(this.btnGetAssetAppliesToRangeByTab_Click);
			// 
			// lblTabId
			// 
			this.lblTabId.Location = new System.Drawing.Point(8, 16);
			this.lblTabId.Name = "lblTabId";
			this.lblTabId.Size = new System.Drawing.Size(72, 16);
			this.lblTabId.TabIndex = 2;
			this.lblTabId.Text = "TabId";
			// 
			// txtTabId
			// 
			this.txtTabId.Location = new System.Drawing.Point(88, 16);
			this.txtTabId.Name = "txtTabId";
			this.txtTabId.Size = new System.Drawing.Size(120, 20);
			this.txtTabId.TabIndex = 1;
			this.txtTabId.Text = "756";
			// 
			// lblTabType
			// 
			this.lblTabType.Location = new System.Drawing.Point(8, 40);
			this.lblTabType.Name = "lblTabType";
			this.lblTabType.Size = new System.Drawing.Size(72, 16);
			this.lblTabType.TabIndex = 2;
			this.lblTabType.Text = "TabType";
			// 
			// btnPutAssetAppliesToRangeByTab
			// 
			this.btnPutAssetAppliesToRangeByTab.Location = new System.Drawing.Point(424, 16);
			this.btnPutAssetAppliesToRangeByTab.Name = "btnPutAssetAppliesToRangeByTab";
			this.btnPutAssetAppliesToRangeByTab.Size = new System.Drawing.Size(200, 23);
			this.btnPutAssetAppliesToRangeByTab.TabIndex = 15;
			this.btnPutAssetAppliesToRangeByTab.Text = "PutAssetAppliesToRangeByTab";
			this.btnPutAssetAppliesToRangeByTab.Click += new System.EventHandler(this.btnPutAssetAppliesToRangeByTab_Click);
			// 
			// dgOrionAPIs
			// 
			this.dgOrionAPIs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dgOrionAPIs.DataMember = "";
			this.dgOrionAPIs.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgOrionAPIs.Location = new System.Drawing.Point(8, 200);
			this.dgOrionAPIs.Name = "dgOrionAPIs";
			this.dgOrionAPIs.Size = new System.Drawing.Size(760, 208);
			this.dgOrionAPIs.TabIndex = 16;
			// 
			// groupBoxGetPackageAppliesToRangeByTab
			// 
			this.groupBoxGetPackageAppliesToRangeByTab.Controls.Add(this.sltGetPackageAppliesToRangeByTabFormType);
			this.groupBoxGetPackageAppliesToRangeByTab.Controls.Add(this.label2);
			this.groupBoxGetPackageAppliesToRangeByTab.Controls.Add(this.btnGetPackageAppliesToRangeByTab);
			this.groupBoxGetPackageAppliesToRangeByTab.Controls.Add(this.label3);
			this.groupBoxGetPackageAppliesToRangeByTab.Controls.Add(this.txtPackageTabId);
			this.groupBoxGetPackageAppliesToRangeByTab.Controls.Add(this.label4);
			this.groupBoxGetPackageAppliesToRangeByTab.Controls.Add(this.btnPutPackageAppliesToRangeByTab);
			this.groupBoxGetPackageAppliesToRangeByTab.Location = new System.Drawing.Point(8, 112);
			this.groupBoxGetPackageAppliesToRangeByTab.Name = "groupBoxGetPackageAppliesToRangeByTab";
			this.groupBoxGetPackageAppliesToRangeByTab.Size = new System.Drawing.Size(648, 72);
			this.groupBoxGetPackageAppliesToRangeByTab.TabIndex = 15;
			this.groupBoxGetPackageAppliesToRangeByTab.TabStop = false;
			this.groupBoxGetPackageAppliesToRangeByTab.Text = "PackageAppliesToRangeByTab";
			// 
			// sltGetPackageAppliesToRangeByTabFormType
			// 
			this.sltGetPackageAppliesToRangeByTabFormType.Items.AddRange(new object[] {
																						  "UCC",
																						  "ICC",
																						  "FOR",
																						  "OAC"});
			this.sltGetPackageAppliesToRangeByTabFormType.Location = new System.Drawing.Point(88, 40);
			this.sltGetPackageAppliesToRangeByTabFormType.Name = "sltGetPackageAppliesToRangeByTabFormType";
			this.sltGetPackageAppliesToRangeByTabFormType.Size = new System.Drawing.Size(120, 21);
			this.sltGetPackageAppliesToRangeByTabFormType.TabIndex = 37;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(224, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 16);
			this.label2.TabIndex = 34;
			this.label2.Text = "Results in Datagrid";
			// 
			// btnGetPackageAppliesToRangeByTab
			// 
			this.btnGetPackageAppliesToRangeByTab.Location = new System.Drawing.Point(216, 16);
			this.btnGetPackageAppliesToRangeByTab.Name = "btnGetPackageAppliesToRangeByTab";
			this.btnGetPackageAppliesToRangeByTab.Size = new System.Drawing.Size(200, 23);
			this.btnGetPackageAppliesToRangeByTab.TabIndex = 15;
			this.btnGetPackageAppliesToRangeByTab.Text = "GetPackageAppliesToRangeByTab";
			this.btnGetPackageAppliesToRangeByTab.Click += new System.EventHandler(this.btnGetPackageAppliesToRangeByTab_Click);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 16);
			this.label3.TabIndex = 2;
			this.label3.Text = "TabId";
			// 
			// txtPackageTabId
			// 
			this.txtPackageTabId.Location = new System.Drawing.Point(88, 16);
			this.txtPackageTabId.Name = "txtPackageTabId";
			this.txtPackageTabId.Size = new System.Drawing.Size(120, 20);
			this.txtPackageTabId.TabIndex = 1;
			this.txtPackageTabId.Text = "3729";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 40);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 16);
			this.label4.TabIndex = 2;
			this.label4.Text = "TabType";
			// 
			// btnPutPackageAppliesToRangeByTab
			// 
			this.btnPutPackageAppliesToRangeByTab.Location = new System.Drawing.Point(424, 16);
			this.btnPutPackageAppliesToRangeByTab.Name = "btnPutPackageAppliesToRangeByTab";
			this.btnPutPackageAppliesToRangeByTab.Size = new System.Drawing.Size(200, 23);
			this.btnPutPackageAppliesToRangeByTab.TabIndex = 15;
			this.btnPutPackageAppliesToRangeByTab.Text = "PutPackageAppliesToRangeByTab";
			this.btnPutPackageAppliesToRangeByTab.Click += new System.EventHandler(this.btnPutPackageAppliesToRangeByTab_Click);
			// 
			// Form_rdmPBSManageAppliesToRange
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(776, 550);
			this.Controls.Add(this.dgOrionAPIs);
			this.Controls.Add(this.grpBoxGetAssetAppliesToRangeByTab);
			this.Controls.Add(this.groupBoxGetPackageAppliesToRangeByTab);
			this.Name = "Form_rdmPBSManageAppliesToRange";
			this.Text = "Form_rdmPBSManageAppliesToRange";
			this.Controls.SetChildIndex(this.chkGlobalSaveResults, 0);
			this.Controls.SetChildIndex(this.btnLogin, 0);
			this.Controls.SetChildIndex(this.btnLogout, 0);
			this.Controls.SetChildIndex(this.btnClearLog, 0);
			this.Controls.SetChildIndex(this.groupBoxGetPackageAppliesToRangeByTab, 0);
			this.Controls.SetChildIndex(this.txtLog, 0);
			this.Controls.SetChildIndex(this.txtWebServiceURL, 0);
			this.Controls.SetChildIndex(this.grpBoxGetAssetAppliesToRangeByTab, 0);
			this.Controls.SetChildIndex(this.dgOrionAPIs, 0);
			this.grpBoxGetAssetAppliesToRangeByTab.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgOrionAPIs)).EndInit();
			this.groupBoxGetPackageAppliesToRangeByTab.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnGetAssetAppliesToRangeByTab_Click(object sender, System.EventArgs e)
		{
			
			dgOrionAPIs.DataSource = null;

			if (!ValidateSession())
				return;


			if (txtTabId.Text == string.Empty)
			{
				this.Log("Enter a Tab Id", true);
				return;
			}

			if (sltGetAssetAppliesToRangeByTabFormType.SelectedItem == null)
			{
				this.Log("Select a Tab Type", true);
				return;
			}


			if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
			{
				BVWebService.BVWebService oBVWebService = new BVWebService.BVWebService();
				oBVWebService.Url = this.txtWebServiceURL.Text + @"/Service.asmx";

				this.Log("Start GetAssetAppliesToRangeByTab Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
				DataSet oDataSetResult = oBVWebService.GetAssetAppliesToRangeByTab(m_sBVSessionId, int.Parse(txtTabId.Text),sltGetAssetAppliesToRangeByTabFormType.SelectedItem.ToString());
				dgOrionAPIs.DataSource = oDataSetResult;
				this.Log("End GetAssetAppliesToRangeByTab Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );
			}
			else
			{
				this.Log("Please log in. Session Null", true);
			}
		}

		private void btnPutAssetAppliesToRangeByTab_Click(object sender, System.EventArgs e)
		{

			
			if (!ValidateSession())
				return;

			if (dgOrionAPIs == null || dgOrionAPIs.DataSource == null)
			{
				this.Log("DataGrid is Null.  Perform Getxxx First.", true);
				return;
			}


			if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
			{
				BVWebService.BVWebService oBVWebService = new BVWebService.BVWebService();
				oBVWebService.Url = this.txtWebServiceURL.Text + @"/Service.asmx";

				this.Log("Start PutAssetAppliesToRangeByTab Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
				oBVWebService.PutAssetAppliesToRangeByTab(m_sBVSessionId,(DataSet)dgOrionAPIs.DataSource);
				this.Log("End PutAssetAppliesToRangeByTab Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );

				dgOrionAPIs.DataSource = null;
			}
			else
			{
				this.Log("Please log in. Session Null", true);
			}

		
		}

		private void btnGetPackageAppliesToRangeByTab_Click(object sender, System.EventArgs e)
		{
			
			dgOrionAPIs.DataSource = null;

			if (!ValidateSession())
				return;


			if (txtPackageTabId.Text == string.Empty)
			{
				this.Log("Enter a Tab Id", true);
				return;
			}

			if (sltGetPackageAppliesToRangeByTabFormType.SelectedItem == null)
			{
				this.Log("Select a Tab Type", true);
				return;
			}


			if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
			{
				BVWebService.BVWebService oBVWebService = new BVWebService.BVWebService();
				oBVWebService.Url = this.txtWebServiceURL.Text + @"/Service.asmx";

				this.Log("Start GetPackageAppliesToRangeByTab Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
				DataSet oDataSetResult = oBVWebService.GetPackageAppliesToRangeByTab(m_sBVSessionId, int.Parse(txtPackageTabId.Text),sltGetPackageAppliesToRangeByTabFormType.SelectedItem.ToString());
				dgOrionAPIs.DataSource = oDataSetResult;

				if (chkGlobalSaveResults.Checked)
				{
					if (folderBrowserDialogGlobalSaveResults.ShowDialog() == DialogResult.OK)
					{
							if (folderBrowserDialogGlobalSaveResults.SelectedPath != null)
							{
								string sPath = folderBrowserDialogGlobalSaveResults.SelectedPath + System.IO.Path.DirectorySeparatorChar.ToString();
								sPath += "GetPackageAppliesToRangeByTab" + "_" + DateTime.Now.ToString("yyyyMMdd_hhMM") + ".xml";
								this.Log("Saving Result File to:  " + sPath);
								oDataSetResult.WriteXml(sPath);
							}
					}
				}


				this.Log("End GetPackageAppliesToRangeByTab Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );
			}
			else
			{
				this.Log("Please log in. Session Null", true);
			}
		}

		private void btnPutPackageAppliesToRangeByTab_Click(object sender, System.EventArgs e)
		{
			if (!ValidateSession())
				return;

			if (dgOrionAPIs == null || dgOrionAPIs.DataSource == null)
			{
				this.Log("DataGrid is Null.  Perform Getxxx First.", true);
				return;
			}


			if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
			{
				BVWebService.BVWebService oBVWebService = new BVWebService.BVWebService();
				oBVWebService.Url = this.txtWebServiceURL.Text + @"/Service.asmx";

				this.Log("Start PutPackageAppliesToRangeByTab Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
				oBVWebService.PutPackageAppliesToRangeByTab(m_sBVSessionId,(DataSet)dgOrionAPIs.DataSource);
				this.Log("End PutPackageAppliesToRangeByTab Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );

				dgOrionAPIs.DataSource = null;
			}
			else
			{
				this.Log("Please log in. Session Null", true);
			}

		
		}

	}
}
