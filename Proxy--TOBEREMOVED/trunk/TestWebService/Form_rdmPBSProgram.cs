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
	/// Summary description for Form_rdmPBSProgram.
	/// </summary>
	public class Form_rdmPBSProgram : Form_Base
	{
		private System.Windows.Forms.GroupBox grpBoxListProgramsByDeal;
		private System.Windows.Forms.Label lblGetMasterDealHelp;
		private System.Windows.Forms.Label lblDealId;
		private System.Windows.Forms.TextBox txtDealId;
		private System.Windows.Forms.Button btnListProgramsByDeal;
		private System.Windows.Forms.DataGrid dgOrionAPIs;
		private System.Windows.Forms.GroupBox groupBoxListProgramPackagesByProgram;
		private System.Windows.Forms.Button btnListProgramPackagesByProgram;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblProgramId;
		private System.Windows.Forms.TextBox txtProgramId;
		private System.Windows.Forms.GroupBox grpBoxProgramDetails;
		private System.Windows.Forms.CheckBox chkRequestLock;
		private System.Windows.Forms.Label lblLockId;
		private System.Windows.Forms.TextBox txtLockId;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnGetProgramDetails;
		private System.Windows.Forms.Label lblProgramDetailsId;
		private System.Windows.Forms.TextBox txtProgramDetailsId;
		private System.Windows.Forms.CheckBox chkPremiereDate;
		private System.Windows.Forms.Button btnPutProgramDetails;
		private System.Windows.Forms.GroupBox grpBoxPackage;
		private System.Windows.Forms.Button btnReleaseLockPackage;
		private System.Windows.Forms.CheckBox chkRequestLockPackage;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtLockIdPackage;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnGetPackage;
		private System.Windows.Forms.Label lblPackageId;
		private System.Windows.Forms.TextBox txtPackageId;
		private System.Windows.Forms.Button btnReleaseLock;
		private System.Windows.Forms.Button btnPackageHelp;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnAdCopyReleaseLock;
		private System.Windows.Forms.CheckBox chkRequestLockAdCopy;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtLockIdAdCopy;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button btnGetAdCopy;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtAdCopyId;
		private System.Windows.Forms.Button btnPutAdCopy;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form_rdmPBSProgram()
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
			this.grpBoxListProgramsByDeal = new System.Windows.Forms.GroupBox();
			this.btnListProgramsByDeal = new System.Windows.Forms.Button();
			this.lblGetMasterDealHelp = new System.Windows.Forms.Label();
			this.lblDealId = new System.Windows.Forms.Label();
			this.txtDealId = new System.Windows.Forms.TextBox();
			this.dgOrionAPIs = new System.Windows.Forms.DataGrid();
			this.groupBoxListProgramPackagesByProgram = new System.Windows.Forms.GroupBox();
			this.btnListProgramPackagesByProgram = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.lblProgramId = new System.Windows.Forms.Label();
			this.txtProgramId = new System.Windows.Forms.TextBox();
			this.grpBoxProgramDetails = new System.Windows.Forms.GroupBox();
			this.btnReleaseLock = new System.Windows.Forms.Button();
			this.chkRequestLock = new System.Windows.Forms.CheckBox();
			this.lblLockId = new System.Windows.Forms.Label();
			this.txtLockId = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnGetProgramDetails = new System.Windows.Forms.Button();
			this.lblProgramDetailsId = new System.Windows.Forms.Label();
			this.txtProgramDetailsId = new System.Windows.Forms.TextBox();
			this.chkPremiereDate = new System.Windows.Forms.CheckBox();
			this.btnPutProgramDetails = new System.Windows.Forms.Button();
			this.grpBoxPackage = new System.Windows.Forms.GroupBox();
			this.btnReleaseLockPackage = new System.Windows.Forms.Button();
			this.chkRequestLockPackage = new System.Windows.Forms.CheckBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtLockIdPackage = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.btnGetPackage = new System.Windows.Forms.Button();
			this.lblPackageId = new System.Windows.Forms.Label();
			this.txtPackageId = new System.Windows.Forms.TextBox();
			this.btnPackageHelp = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnAdCopyReleaseLock = new System.Windows.Forms.Button();
			this.chkRequestLockAdCopy = new System.Windows.Forms.CheckBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtLockIdAdCopy = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.btnGetAdCopy = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.txtAdCopyId = new System.Windows.Forms.TextBox();
			this.btnPutAdCopy = new System.Windows.Forms.Button();
			this.grpBoxListProgramsByDeal.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgOrionAPIs)).BeginInit();
			this.groupBoxListProgramPackagesByProgram.SuspendLayout();
			this.grpBoxProgramDetails.SuspendLayout();
			this.grpBoxPackage.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnLogout
			// 
			this.btnLogout.Location = new System.Drawing.Point(792, 56);
			this.btnLogout.Name = "btnLogout";
			// 
			// btnLogin
			// 
			this.btnLogin.Location = new System.Drawing.Point(792, 32);
			this.btnLogin.Name = "btnLogin";
			// 
			// btnClearLog
			// 
			this.btnClearLog.Location = new System.Drawing.Point(792, 80);
			this.btnClearLog.Name = "btnClearLog";
			// 
			// txtWebServiceURL
			// 
			this.txtWebServiceURL.Name = "txtWebServiceURL";
			this.txtWebServiceURL.Size = new System.Drawing.Size(800, 20);
			// 
			// txtLog
			// 
			this.txtLog.Location = new System.Drawing.Point(0, 582);
			this.txtLog.Name = "txtLog";
			this.txtLog.Size = new System.Drawing.Size(872, 56);
			// 
			// sltProxyEnvironment
			// 
			this.sltProxyEnvironment.Name = "sltProxyEnvironment";
			// 
			// chkGlobalSaveResults
			// 
			this.chkGlobalSaveResults.Location = new System.Drawing.Point(792, 112);
			this.chkGlobalSaveResults.Name = "chkGlobalSaveResults";
			// 
			// grpBoxListProgramsByDeal
			// 
			this.grpBoxListProgramsByDeal.Controls.Add(this.btnListProgramsByDeal);
			this.grpBoxListProgramsByDeal.Controls.Add(this.lblGetMasterDealHelp);
			this.grpBoxListProgramsByDeal.Controls.Add(this.lblDealId);
			this.grpBoxListProgramsByDeal.Controls.Add(this.txtDealId);
			this.grpBoxListProgramsByDeal.Location = new System.Drawing.Point(16, 40);
			this.grpBoxListProgramsByDeal.Name = "grpBoxListProgramsByDeal";
			this.grpBoxListProgramsByDeal.Size = new System.Drawing.Size(288, 72);
			this.grpBoxListProgramsByDeal.TabIndex = 18;
			this.grpBoxListProgramsByDeal.TabStop = false;
			this.grpBoxListProgramsByDeal.Text = "ListProgramsByDeal";
			// 
			// btnListProgramsByDeal
			// 
			this.btnListProgramsByDeal.Location = new System.Drawing.Point(152, 16);
			this.btnListProgramsByDeal.Name = "btnListProgramsByDeal";
			this.btnListProgramsByDeal.Size = new System.Drawing.Size(128, 23);
			this.btnListProgramsByDeal.TabIndex = 35;
			this.btnListProgramsByDeal.Text = "ListProgramsByDeal";
			this.btnListProgramsByDeal.Click += new System.EventHandler(this.btnListProgramsByDeal_Click);
			// 
			// lblGetMasterDealHelp
			// 
			this.lblGetMasterDealHelp.Location = new System.Drawing.Point(128, 48);
			this.lblGetMasterDealHelp.Name = "lblGetMasterDealHelp";
			this.lblGetMasterDealHelp.Size = new System.Drawing.Size(100, 16);
			this.lblGetMasterDealHelp.TabIndex = 34;
			this.lblGetMasterDealHelp.Text = "Results in Datagrid";
			// 
			// lblDealId
			// 
			this.lblDealId.Location = new System.Drawing.Point(8, 16);
			this.lblDealId.Name = "lblDealId";
			this.lblDealId.Size = new System.Drawing.Size(40, 16);
			this.lblDealId.TabIndex = 2;
			this.lblDealId.Text = "Deal Id";
			// 
			// txtDealId
			// 
			this.txtDealId.Location = new System.Drawing.Point(64, 16);
			this.txtDealId.Name = "txtDealId";
			this.txtDealId.Size = new System.Drawing.Size(80, 20);
			this.txtDealId.TabIndex = 1;
			this.txtDealId.Text = "24381484";
			// 
			// dgOrionAPIs
			// 
			this.dgOrionAPIs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dgOrionAPIs.DataMember = "";
			this.dgOrionAPIs.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgOrionAPIs.Location = new System.Drawing.Point(0, 328);
			this.dgOrionAPIs.Name = "dgOrionAPIs";
			this.dgOrionAPIs.Size = new System.Drawing.Size(864, 240);
			this.dgOrionAPIs.TabIndex = 19;
			// 
			// groupBoxListProgramPackagesByProgram
			// 
			this.groupBoxListProgramPackagesByProgram.Controls.Add(this.btnListProgramPackagesByProgram);
			this.groupBoxListProgramPackagesByProgram.Controls.Add(this.label1);
			this.groupBoxListProgramPackagesByProgram.Controls.Add(this.lblProgramId);
			this.groupBoxListProgramPackagesByProgram.Controls.Add(this.txtProgramId);
			this.groupBoxListProgramPackagesByProgram.Location = new System.Drawing.Point(312, 40);
			this.groupBoxListProgramPackagesByProgram.Name = "groupBoxListProgramPackagesByProgram";
			this.groupBoxListProgramPackagesByProgram.Size = new System.Drawing.Size(376, 72);
			this.groupBoxListProgramPackagesByProgram.TabIndex = 18;
			this.groupBoxListProgramPackagesByProgram.TabStop = false;
			this.groupBoxListProgramPackagesByProgram.Text = "ListProgramPackagesByProgram";
			// 
			// btnListProgramPackagesByProgram
			// 
			this.btnListProgramPackagesByProgram.Location = new System.Drawing.Point(184, 16);
			this.btnListProgramPackagesByProgram.Name = "btnListProgramPackagesByProgram";
			this.btnListProgramPackagesByProgram.Size = new System.Drawing.Size(184, 23);
			this.btnListProgramPackagesByProgram.TabIndex = 35;
			this.btnListProgramPackagesByProgram.Text = "ListProgramPackagesByProgram";
			this.btnListProgramPackagesByProgram.Click += new System.EventHandler(this.btnListProgramPackagesByProgram_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(128, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 16);
			this.label1.TabIndex = 34;
			this.label1.Text = "Results in Datagrid";
			// 
			// lblProgramId
			// 
			this.lblProgramId.Location = new System.Drawing.Point(8, 16);
			this.lblProgramId.Name = "lblProgramId";
			this.lblProgramId.Size = new System.Drawing.Size(64, 24);
			this.lblProgramId.TabIndex = 2;
			this.lblProgramId.Text = "Program Id";
			// 
			// txtProgramId
			// 
			this.txtProgramId.Location = new System.Drawing.Point(88, 16);
			this.txtProgramId.Name = "txtProgramId";
			this.txtProgramId.Size = new System.Drawing.Size(88, 20);
			this.txtProgramId.TabIndex = 1;
			this.txtProgramId.Text = "24381487";
			// 
			// grpBoxProgramDetails
			// 
			this.grpBoxProgramDetails.Controls.Add(this.btnReleaseLock);
			this.grpBoxProgramDetails.Controls.Add(this.chkRequestLock);
			this.grpBoxProgramDetails.Controls.Add(this.lblLockId);
			this.grpBoxProgramDetails.Controls.Add(this.txtLockId);
			this.grpBoxProgramDetails.Controls.Add(this.label2);
			this.grpBoxProgramDetails.Controls.Add(this.btnGetProgramDetails);
			this.grpBoxProgramDetails.Controls.Add(this.lblProgramDetailsId);
			this.grpBoxProgramDetails.Controls.Add(this.txtProgramDetailsId);
			this.grpBoxProgramDetails.Controls.Add(this.chkPremiereDate);
			this.grpBoxProgramDetails.Controls.Add(this.btnPutProgramDetails);
			this.grpBoxProgramDetails.Location = new System.Drawing.Point(16, 120);
			this.grpBoxProgramDetails.Name = "grpBoxProgramDetails";
			this.grpBoxProgramDetails.Size = new System.Drawing.Size(424, 104);
			this.grpBoxProgramDetails.TabIndex = 20;
			this.grpBoxProgramDetails.TabStop = false;
			this.grpBoxProgramDetails.Text = "ProgramDetails";
			// 
			// btnReleaseLock
			// 
			this.btnReleaseLock.Location = new System.Drawing.Point(304, 40);
			this.btnReleaseLock.Name = "btnReleaseLock";
			this.btnReleaseLock.Size = new System.Drawing.Size(104, 23);
			this.btnReleaseLock.TabIndex = 40;
			this.btnReleaseLock.Text = "ReleaseLock";
			this.btnReleaseLock.Click += new System.EventHandler(this.btnReleaseLock_Click);
			// 
			// chkRequestLock
			// 
			this.chkRequestLock.Location = new System.Drawing.Point(200, 40);
			this.chkRequestLock.Name = "chkRequestLock";
			this.chkRequestLock.TabIndex = 38;
			this.chkRequestLock.Text = "RequestLock?";
			// 
			// lblLockId
			// 
			this.lblLockId.Location = new System.Drawing.Point(16, 48);
			this.lblLockId.Name = "lblLockId";
			this.lblLockId.Size = new System.Drawing.Size(40, 16);
			this.lblLockId.TabIndex = 37;
			this.lblLockId.Text = "LockId";
			// 
			// txtLockId
			// 
			this.txtLockId.Location = new System.Drawing.Point(88, 40);
			this.txtLockId.Name = "txtLockId";
			this.txtLockId.Size = new System.Drawing.Size(104, 20);
			this.txtLockId.TabIndex = 36;
			this.txtLockId.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(240, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 16);
			this.label2.TabIndex = 34;
			this.label2.Text = "Results in Datagrid";
			// 
			// btnGetProgramDetails
			// 
			this.btnGetProgramDetails.Location = new System.Drawing.Point(200, 16);
			this.btnGetProgramDetails.Name = "btnGetProgramDetails";
			this.btnGetProgramDetails.Size = new System.Drawing.Size(104, 23);
			this.btnGetProgramDetails.TabIndex = 15;
			this.btnGetProgramDetails.Text = "GetProgramDetails";
			this.btnGetProgramDetails.Click += new System.EventHandler(this.btnGetProgramDetails_Click);
			// 
			// lblProgramDetailsId
			// 
			this.lblProgramDetailsId.Location = new System.Drawing.Point(8, 16);
			this.lblProgramDetailsId.Name = "lblProgramDetailsId";
			this.lblProgramDetailsId.Size = new System.Drawing.Size(72, 16);
			this.lblProgramDetailsId.TabIndex = 2;
			this.lblProgramDetailsId.Text = "Program Id";
			// 
			// txtProgramDetailsId
			// 
			this.txtProgramDetailsId.Location = new System.Drawing.Point(88, 16);
			this.txtProgramDetailsId.Name = "txtProgramDetailsId";
			this.txtProgramDetailsId.Size = new System.Drawing.Size(104, 20);
			this.txtProgramDetailsId.TabIndex = 1;
			this.txtProgramDetailsId.Text = "24381487";
			// 
			// chkPremiereDate
			// 
			this.chkPremiereDate.Location = new System.Drawing.Point(24, 64);
			this.chkPremiereDate.Name = "chkPremiereDate";
			this.chkPremiereDate.Size = new System.Drawing.Size(128, 32);
			this.chkPremiereDate.TabIndex = 38;
			this.chkPremiereDate.Text = "Get Premiere Date?";
			// 
			// btnPutProgramDetails
			// 
			this.btnPutProgramDetails.Location = new System.Drawing.Point(304, 16);
			this.btnPutProgramDetails.Name = "btnPutProgramDetails";
			this.btnPutProgramDetails.Size = new System.Drawing.Size(104, 23);
			this.btnPutProgramDetails.TabIndex = 15;
			this.btnPutProgramDetails.Text = "PutProgramDetails";
			this.btnPutProgramDetails.Click += new System.EventHandler(this.btnPutProgramDetails_Click);
			// 
			// grpBoxPackage
			// 
			this.grpBoxPackage.Controls.Add(this.btnReleaseLockPackage);
			this.grpBoxPackage.Controls.Add(this.chkRequestLockPackage);
			this.grpBoxPackage.Controls.Add(this.label3);
			this.grpBoxPackage.Controls.Add(this.txtLockIdPackage);
			this.grpBoxPackage.Controls.Add(this.label4);
			this.grpBoxPackage.Controls.Add(this.btnGetPackage);
			this.grpBoxPackage.Controls.Add(this.lblPackageId);
			this.grpBoxPackage.Controls.Add(this.txtPackageId);
			this.grpBoxPackage.Controls.Add(this.btnPackageHelp);
			this.grpBoxPackage.Location = new System.Drawing.Point(456, 120);
			this.grpBoxPackage.Name = "grpBoxPackage";
			this.grpBoxPackage.Size = new System.Drawing.Size(328, 104);
			this.grpBoxPackage.TabIndex = 21;
			this.grpBoxPackage.TabStop = false;
			this.grpBoxPackage.Text = "Package";
			this.grpBoxPackage.Enter += new System.EventHandler(this.grpBoxPackage_Enter);
			// 
			// btnReleaseLockPackage
			// 
			this.btnReleaseLockPackage.Location = new System.Drawing.Point(216, 64);
			this.btnReleaseLockPackage.Name = "btnReleaseLockPackage";
			this.btnReleaseLockPackage.Size = new System.Drawing.Size(96, 23);
			this.btnReleaseLockPackage.TabIndex = 39;
			this.btnReleaseLockPackage.Text = "ReleaseLock";
			this.btnReleaseLockPackage.Click += new System.EventHandler(this.btnReleaseLockPackage_Click);
			// 
			// chkRequestLockPackage
			// 
			this.chkRequestLockPackage.Location = new System.Drawing.Point(216, 40);
			this.chkRequestLockPackage.Name = "chkRequestLockPackage";
			this.chkRequestLockPackage.TabIndex = 38;
			this.chkRequestLockPackage.Text = "RequestLock?";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(40, 16);
			this.label3.TabIndex = 37;
			this.label3.Text = "LockId";
			// 
			// txtLockIdPackage
			// 
			this.txtLockIdPackage.Location = new System.Drawing.Point(88, 40);
			this.txtLockIdPackage.Name = "txtLockIdPackage";
			this.txtLockIdPackage.Size = new System.Drawing.Size(120, 20);
			this.txtLockIdPackage.TabIndex = 36;
			this.txtLockIdPackage.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(64, 72);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 16);
			this.label4.TabIndex = 34;
			this.label4.Text = "Results in Datagrid";
			// 
			// btnGetPackage
			// 
			this.btnGetPackage.Location = new System.Drawing.Point(216, 16);
			this.btnGetPackage.Name = "btnGetPackage";
			this.btnGetPackage.Size = new System.Drawing.Size(96, 23);
			this.btnGetPackage.TabIndex = 15;
			this.btnGetPackage.Text = "GetPackage";
			this.btnGetPackage.Click += new System.EventHandler(this.btnGetPackage_Click);
			// 
			// lblPackageId
			// 
			this.lblPackageId.Location = new System.Drawing.Point(8, 16);
			this.lblPackageId.Name = "lblPackageId";
			this.lblPackageId.Size = new System.Drawing.Size(72, 16);
			this.lblPackageId.TabIndex = 2;
			this.lblPackageId.Text = "Package Id";
			// 
			// txtPackageId
			// 
			this.txtPackageId.Location = new System.Drawing.Point(88, 16);
			this.txtPackageId.Name = "txtPackageId";
			this.txtPackageId.Size = new System.Drawing.Size(120, 20);
			this.txtPackageId.TabIndex = 1;
			this.txtPackageId.Text = "23011537";
			// 
			// btnPackageHelp
			// 
			this.btnPackageHelp.Location = new System.Drawing.Point(8, 72);
			this.btnPackageHelp.Name = "btnPackageHelp";
			this.btnPackageHelp.Size = new System.Drawing.Size(24, 23);
			this.btnPackageHelp.TabIndex = 39;
			this.btnPackageHelp.Text = "?";
			this.btnPackageHelp.Click += new System.EventHandler(this.btnPackageHelp_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnAdCopyReleaseLock);
			this.groupBox1.Controls.Add(this.chkRequestLockAdCopy);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.txtLockIdAdCopy);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.btnGetAdCopy);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.txtAdCopyId);
			this.groupBox1.Controls.Add(this.btnPutAdCopy);
			this.groupBox1.Location = new System.Drawing.Point(16, 232);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(464, 88);
			this.groupBox1.TabIndex = 21;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Ad Copy";
			// 
			// btnAdCopyReleaseLock
			// 
			this.btnAdCopyReleaseLock.Location = new System.Drawing.Point(320, 40);
			this.btnAdCopyReleaseLock.Name = "btnAdCopyReleaseLock";
			this.btnAdCopyReleaseLock.Size = new System.Drawing.Size(96, 23);
			this.btnAdCopyReleaseLock.TabIndex = 39;
			this.btnAdCopyReleaseLock.Text = "ReleaseLock";
			this.btnAdCopyReleaseLock.Click += new System.EventHandler(this.btnAdCopyReleaseLock_Click);
			// 
			// chkRequestLockAdCopy
			// 
			this.chkRequestLockAdCopy.Location = new System.Drawing.Point(216, 40);
			this.chkRequestLockAdCopy.Name = "chkRequestLockAdCopy";
			this.chkRequestLockAdCopy.TabIndex = 38;
			this.chkRequestLockAdCopy.Text = "RequestLock?";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 48);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(40, 16);
			this.label5.TabIndex = 37;
			this.label5.Text = "LockId";
			// 
			// txtLockIdAdCopy
			// 
			this.txtLockIdAdCopy.Location = new System.Drawing.Point(88, 40);
			this.txtLockIdAdCopy.Name = "txtLockIdAdCopy";
			this.txtLockIdAdCopy.Size = new System.Drawing.Size(120, 20);
			this.txtLockIdAdCopy.TabIndex = 36;
			this.txtLockIdAdCopy.Text = "";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(64, 72);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 16);
			this.label6.TabIndex = 34;
			this.label6.Text = "Results in Datagrid";
			// 
			// btnGetAdCopy
			// 
			this.btnGetAdCopy.Location = new System.Drawing.Point(216, 16);
			this.btnGetAdCopy.Name = "btnGetAdCopy";
			this.btnGetAdCopy.Size = new System.Drawing.Size(96, 23);
			this.btnGetAdCopy.TabIndex = 15;
			this.btnGetAdCopy.Text = "GetAdCopy";
			this.btnGetAdCopy.Click += new System.EventHandler(this.btnGetAdCopy_Click);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(8, 16);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(72, 16);
			this.label7.TabIndex = 2;
			this.label7.Text = "Ad Copy Id";
			// 
			// txtAdCopyId
			// 
			this.txtAdCopyId.Location = new System.Drawing.Point(88, 16);
			this.txtAdCopyId.Name = "txtAdCopyId";
			this.txtAdCopyId.Size = new System.Drawing.Size(120, 20);
			this.txtAdCopyId.TabIndex = 1;
			this.txtAdCopyId.Text = "23011537";
			// 
			// btnPutAdCopy
			// 
			this.btnPutAdCopy.Location = new System.Drawing.Point(320, 16);
			this.btnPutAdCopy.Name = "btnPutAdCopy";
			this.btnPutAdCopy.Size = new System.Drawing.Size(96, 23);
			this.btnPutAdCopy.TabIndex = 15;
			this.btnPutAdCopy.Text = "PutAdCopy";
			this.btnPutAdCopy.Click += new System.EventHandler(this.btnPutAdCopy_Click);
			// 
			// Form_rdmPBSProgram
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(872, 638);
			this.Controls.Add(this.grpBoxPackage);
			this.Controls.Add(this.grpBoxProgramDetails);
			this.Controls.Add(this.dgOrionAPIs);
			this.Controls.Add(this.grpBoxListProgramsByDeal);
			this.Controls.Add(this.groupBoxListProgramPackagesByProgram);
			this.Controls.Add(this.groupBox1);
			this.Name = "Form_rdmPBSProgram";
			this.Text = "Form_rdmPBSProgram";
			this.Controls.SetChildIndex(this.groupBox1, 0);
			this.Controls.SetChildIndex(this.sltProxyEnvironment, 0);
			this.Controls.SetChildIndex(this.chkGlobalSaveResults, 0);
			this.Controls.SetChildIndex(this.btnLogin, 0);
			this.Controls.SetChildIndex(this.btnLogout, 0);
			this.Controls.SetChildIndex(this.btnClearLog, 0);
			this.Controls.SetChildIndex(this.groupBoxListProgramPackagesByProgram, 0);
			this.Controls.SetChildIndex(this.txtLog, 0);
			this.Controls.SetChildIndex(this.txtWebServiceURL, 0);
			this.Controls.SetChildIndex(this.grpBoxListProgramsByDeal, 0);
			this.Controls.SetChildIndex(this.dgOrionAPIs, 0);
			this.Controls.SetChildIndex(this.grpBoxProgramDetails, 0);
			this.Controls.SetChildIndex(this.grpBoxPackage, 0);
			this.grpBoxListProgramsByDeal.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgOrionAPIs)).EndInit();
			this.groupBoxListProgramPackagesByProgram.ResumeLayout(false);
			this.grpBoxProgramDetails.ResumeLayout(false);
			this.grpBoxPackage.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnListProgramsByDeal_Click(object sender, System.EventArgs e)
		{
			dgOrionAPIs.DataSource = null;

			if (!ValidateSession())
				return;


			if (txtDealId.Text == string.Empty)
			{
				this.Log("Enter a Deal Id", true);
				return;
			}

		
			if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
			{

			

				BVWebService.BVWebService oBVWebService = new BVWebService.BVWebService();
				oBVWebService.Url = this.txtWebServiceURL.Text + @"/Service.asmx";


				DataSet oDataSetResult = null;

				this.Log("Start ListProgramByDeal Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
				oDataSetResult = oBVWebService.ListProgramByDeal(m_sBVSessionId, int.Parse(txtDealId.Text));
				dgOrionAPIs.DataSource = oDataSetResult;
				
				this.Log("End ListProgramByDeal Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );

			}
			else
			{
				this.Log("Please log in. Session Null", true);
			}
		}

		private void btnListProgramPackagesByProgram_Click(object sender, System.EventArgs e)
		{
			dgOrionAPIs.DataSource = null;

			if (!ValidateSession())
				return;


			if (txtProgramId.Text == string.Empty)
			{
				this.Log("Enter a Program Id", true);
				return;
			}

		
			if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
			{

				BVWebService.BVWebService oBVWebService = new BVWebService.BVWebService();
				oBVWebService.Url = this.txtWebServiceURL.Text + @"/Service.asmx";


				DataSet oDataSetResult = null;

				this.Log("Start ListProgramPackagesByProgram Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
				oDataSetResult = oBVWebService.ListProgramPackagesByProgram(m_sBVSessionId, int.Parse(txtProgramId.Text));
				dgOrionAPIs.DataSource = oDataSetResult;
				this.Log("End ListProgramPackagesByProgram Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );

			}
			else
			{
				this.Log("Please log in. Session Null", true);
			}
		}

		private void btnGetProgramDetails_Click(object sender, System.EventArgs e)
		{
			dgOrionAPIs.DataSource = null;

			if (!ValidateSession())
				return;


			if (txtProgramDetailsId.Text == string.Empty)
			{
				this.Log("Enter a Program Id", true);
				return;
			}

		
			if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
			{
				string sLockId = string.Empty;

				BVWebService.BVWebService oBVWebService = new BVWebService.BVWebService();
				oBVWebService.Url = this.txtWebServiceURL.Text + @"/Service.asmx";

				DataSet oDataSetResult = null;

				this.Log("Start GetProgramDetails Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
				oDataSetResult = oBVWebService.GetProgramDetails(m_sBVSessionId, int.Parse(txtProgramDetailsId.Text),chkRequestLock.Checked, chkPremiereDate.Checked, out sLockId);
				dgOrionAPIs.DataSource = oDataSetResult;
				txtLockId.Text = sLockId;
				chkRequestLock.Checked = false;

				this.Log("End GetProgramDetails Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );

			}
			else
			{
				this.Log("Please log in. Session Null", true);
			}
		}

		private void btnPutProgramDetails_Click(object sender, System.EventArgs e)
		{
			if (!ValidateSession())
				return;


			if (txtProgramDetailsId.Text == string.Empty)
			{
				this.Log("Enter a Program Id", true);
				return;
			}
			if (txtLockId.Text == string.Empty)
			{
				this.Log("A record lock is required for data updates.", true);
				return;
			}
		
			if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
			{
				string sLockId = string.Empty;

				BVWebService.BVWebService oBVWebService = new BVWebService.BVWebService();
				oBVWebService.Url = this.txtWebServiceURL.Text + @"/Service.asmx";

				this.Log("Start PutProgramDetails Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
				oBVWebService.PutProgramDetails(m_sBVSessionId, int.Parse(txtProgramDetailsId.Text),txtLockId.Text,(DataSet)dgOrionAPIs.DataSource);
				dgOrionAPIs.DataSource = null;
				txtLockId.Text = string.Empty;
				chkRequestLock.Checked = false;

				this.Log("End PutProgramDetails Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );

			}
			else
			{
				this.Log("Please log in. Session Null", true);
			}
		}

		private void grpBoxPackage_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void btnGetPackage_Click(object sender, System.EventArgs e)
		{
			dgOrionAPIs.DataSource = null;

			if (!ValidateSession())
				return;


			if (txtPackageId.Text == string.Empty)
			{
				this.Log("Enter a Package Id", true);
				return;
			}

		
			if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
			{
				string sLockId = string.Empty;

				BVWebService.BVWebService oBVWebService = new BVWebService.BVWebService();
				oBVWebService.Url = this.txtWebServiceURL.Text + @"/Service.asmx";

				DataSet oDataSetResult = null;

				this.Log("Start GetPackage Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
				oDataSetResult = oBVWebService.GetPackage(m_sBVSessionId, int.Parse(txtPackageId.Text),chkRequestLockPackage.Checked, out sLockId);
				dgOrionAPIs.DataSource = oDataSetResult;
				txtLockIdPackage.Text = sLockId;
				chkRequestLockPackage.Checked = false;

				this.Log("End GetPackage Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );

			}
			else
			{
				this.Log("Please log in. Session Null", true);
			}
		}

		private void btnReleaseLock_Click(object sender, System.EventArgs e)
		{
			
			if (!ValidateSession())
				return;

			if (txtLockId.Text == string.Empty)
			{
				this.Log("Lock Id is Required.",true);
				return;
			}
			
			
			if (m_sBVSessionId != "")
			{
				BVWebService.BVWebService s = new BVWebService.BVWebService();
				s.Url = this.txtWebServiceURL.Text + @"/Service.asmx";

				this.Log("Start ReleaseLock Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString()  );
				s.ReleaseLock(m_sBVSessionId,txtLockId.Text);
				this.Log("End ReleaseLock Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );

				txtLockId.Text = string.Empty;
				chkRequestLock.Checked = false;
				dgOrionAPIs.DataSource = null;
			}
			else
			{
				this.Log("Please log in. Session Null",true);
			}
		}

		private void btnReleaseLockPackage_Click(object sender, System.EventArgs e)
		{
			
			if (!ValidateSession())
				return;

			if (txtLockIdPackage.Text == string.Empty)
			{
				this.Log("Lock Id is Required.",true);
				return;
			}
			
			
			if (m_sBVSessionId != "")
			{
				BVWebService.BVWebService s = new BVWebService.BVWebService();
				s.Url = this.txtWebServiceURL.Text + @"/Service.asmx";

				this.Log("Start ReleaseLock Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString()  );
				s.ReleaseLock(m_sBVSessionId,txtLockIdPackage.Text);
				this.Log("End ReleaseLock Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );

				txtLockIdPackage.Text = string.Empty;
				chkRequestLockPackage.Checked = false;
				dgOrionAPIs.DataSource = null;
			}
			else
			{
				this.Log("Please log in. Session Null",true);
			}
		}

		private void btnPackageHelp_Click(object sender, System.EventArgs e)
		{

			System.Text.StringBuilder oS = new System.Text.StringBuilder();

			oS.Append("Heres how to test this API:\n\n");
			oS.Append("Package Id's are not visible within Orion.\n");
			oS.Append("1) Use the database, and locate a package for a given Program Item.\n");
			oS.Append("2) select * from version where VERSION.ver_ass_id = <asset_id>;\n");
			MessageBox.Show(this,oS.ToString());

			
		}

		private void btnGetAdCopy_Click(object sender, System.EventArgs e)
		{
			dgOrionAPIs.DataSource = null;

			if (!ValidateSession())
				return;


			if (txtAdCopyId.Text == string.Empty)
			{
				this.Log("Enter an Ad Copy Id", true);
				return;
			}

		
			if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
			{
				string sLockId = string.Empty;

				BVWebService.BVWebService oBVWebService = new BVWebService.BVWebService();
				oBVWebService.Url = this.txtWebServiceURL.Text + @"/Service.asmx";

				DataSet oDataSetResult = null;

				this.Log("Start GetAdCopy Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
				oDataSetResult = oBVWebService.GetAdCopy(m_sBVSessionId, int.Parse(txtAdCopyId.Text),chkRequestLockAdCopy.Checked, out sLockId);
				dgOrionAPIs.DataSource = oDataSetResult;
				txtLockIdAdCopy.Text = sLockId;
				chkRequestLockAdCopy.Checked = false;

				this.Log("End GetAdCopy Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );

			}
			else
			{
				this.Log("Please log in. Session Null", true);
			}
		
		}

		private void btnPutAdCopy_Click(object sender, System.EventArgs e)
		{
			if (!ValidateSession())
				return;


			if (txtAdCopyId.Text == string.Empty)
			{
				this.Log("Enter an Ad Copy Id", true);
				return;
			}
//			if (txtLockId.Text == string.Empty)
//			{
//				this.Log("A record lock is required for data updates.", true);
//				return;
//			}
		
			if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
			{
				string sLockId = string.Empty;

				BVWebService.BVWebService oBVWebService = new BVWebService.BVWebService();
				oBVWebService.Url = this.txtWebServiceURL.Text + @"/Service.asmx";

				this.Log("Start PutAdCopy Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
				oBVWebService.PutAdCopy(m_sBVSessionId, int.Parse(txtAdCopyId.Text),txtLockIdAdCopy.Text,(DataSet)dgOrionAPIs.DataSource);
				dgOrionAPIs.DataSource = null;
				txtLockIdAdCopy.Text = string.Empty;
				chkRequestLockAdCopy.Checked = false;

				this.Log("End PutAdCopy Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );

			}
			else
			{
				this.Log("Please log in. Session Null", true);
			}
		}

		private void btnAdCopyReleaseLock_Click(object sender, System.EventArgs e)
		{
			if (!ValidateSession())
				return;

			if (txtLockIdAdCopy.Text == string.Empty)
			{
				this.Log("Lock Id is Required.",true);
				return;
			}
			
			
			if (m_sBVSessionId != "")
			{
				BVWebService.BVWebService s = new BVWebService.BVWebService();
				s.Url = this.txtWebServiceURL.Text + @"/Service.asmx";

				this.Log("Start ReleaseLock Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString()  );
				s.ReleaseLock(m_sBVSessionId,txtLockIdAdCopy.Text);
				this.Log("End ReleaseLock Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );

				txtLockIdAdCopy.Text = string.Empty;
				chkRequestLockAdCopy.Checked = false;
				dgOrionAPIs.DataSource = null;
			}
			else
			{
				this.Log("Please log in. Session Null",true);
			}
		}
	}
}
