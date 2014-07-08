using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Linq;

using TestWebService.BVWebService;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data;
using System.Collections.Generic;

namespace TestWebService
{
	/// <summary>
	/// Summary description for Form_rdmPBSDeal.
	/// </summary>
	public class Form_rdmPBSDeal : Form_Base
	{
        private System.Windows.Forms.DataGrid dgOrionAPIs;
		private System.Windows.Forms.GroupBox grpBoxDeal;
		private System.Windows.Forms.Button btnReleaseLock;
		private System.Windows.Forms.Button btnPutDealTechnical;
		private System.Windows.Forms.Button btnPutDealGeneral;
		private System.Windows.Forms.Button btnPutDealRights;
		private System.Windows.Forms.Button btnPutDealFunding;
		private System.Windows.Forms.Button btnPutDeal;
		private System.Windows.Forms.CheckBox chkRequestLock;
		private System.Windows.Forms.Button btnGetDealTechnical;
		private System.Windows.Forms.Button btnGetDealGeneral;
		private System.Windows.Forms.Button btnGetDealRights;
		private System.Windows.Forms.Button btnGetDealWithFunding;
		private System.Windows.Forms.Label lblDealId;
		private System.Windows.Forms.TextBox txtDealId;
		private System.Windows.Forms.Button btnGetDeal;
		private System.Windows.Forms.Label lblLockId;
		private System.Windows.Forms.TextBox txtLockId;
		private System.Windows.Forms.Button btnGetDealAll;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label label1;
        private TextBox txtNewDealId;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox txtMasterDealTitle;
        private TextBox txtMasterDealId;
        private TextBox txtNewDealDesc;
        private CheckBox chkSDRights;
        private Label label5;
        private LinkLabel linkLabel1;
        private CheckBox chkHDRights;
        private Label label7;
        private Label label6;
        private LinkLabel linkLabel2;
        private LinkLabel linkLabel3;
        private TextBox txtSourceDealId;
        private Label label8;
        private TextBox txtEpisodeIds;
        private Button btnCreateDeal;
        private CheckBox chkDealAttribute_ReUp;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form_rdmPBSDeal()
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
            this.dgOrionAPIs = new System.Windows.Forms.DataGrid();
            this.grpBoxDeal = new System.Windows.Forms.GroupBox();
            this.btnReleaseLock = new System.Windows.Forms.Button();
            this.btnPutDealTechnical = new System.Windows.Forms.Button();
            this.btnPutDealGeneral = new System.Windows.Forms.Button();
            this.btnPutDealRights = new System.Windows.Forms.Button();
            this.btnPutDealFunding = new System.Windows.Forms.Button();
            this.btnPutDeal = new System.Windows.Forms.Button();
            this.chkRequestLock = new System.Windows.Forms.CheckBox();
            this.btnGetDealTechnical = new System.Windows.Forms.Button();
            this.btnGetDealGeneral = new System.Windows.Forms.Button();
            this.btnGetDealRights = new System.Windows.Forms.Button();
            this.btnGetDealWithFunding = new System.Windows.Forms.Button();
            this.lblDealId = new System.Windows.Forms.Label();
            this.txtDealId = new System.Windows.Forms.TextBox();
            this.btnGetDeal = new System.Windows.Forms.Button();
            this.lblLockId = new System.Windows.Forms.Label();
            this.txtLockId = new System.Windows.Forms.TextBox();
            this.btnGetDealAll = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnCreateDeal = new System.Windows.Forms.Button();
            this.chkDealAttribute_ReUp = new System.Windows.Forms.CheckBox();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.chkHDRights = new System.Windows.Forms.CheckBox();
            this.chkSDRights = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEpisodeIds = new System.Windows.Forms.TextBox();
            this.txtSourceDealId = new System.Windows.Forms.TextBox();
            this.txtNewDealId = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMasterDealTitle = new System.Windows.Forms.TextBox();
            this.txtMasterDealId = new System.Windows.Forms.TextBox();
            this.txtNewDealDesc = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgOrionAPIs)).BeginInit();
            this.grpBoxDeal.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(552, 56);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(552, 32);
            // 
            // btnClearLog
            // 
            this.btnClearLog.Location = new System.Drawing.Point(552, 80);
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(0, 486);
            this.txtLog.Size = new System.Drawing.Size(624, 72);
            // 
            // chkGlobalSaveResults
            // 
            this.chkGlobalSaveResults.Location = new System.Drawing.Point(536, 112);
            this.chkGlobalSaveResults.Size = new System.Drawing.Size(80, 32);
            // 
            // dgOrionAPIs
            // 
            this.dgOrionAPIs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgOrionAPIs.DataMember = "";
            this.dgOrionAPIs.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgOrionAPIs.Location = new System.Drawing.Point(8, 300);
            this.dgOrionAPIs.Name = "dgOrionAPIs";
            this.dgOrionAPIs.Size = new System.Drawing.Size(600, 180);
            this.dgOrionAPIs.TabIndex = 15;
            // 
            // grpBoxDeal
            // 
            this.grpBoxDeal.Controls.Add(this.btnReleaseLock);
            this.grpBoxDeal.Controls.Add(this.btnPutDealTechnical);
            this.grpBoxDeal.Controls.Add(this.btnPutDealGeneral);
            this.grpBoxDeal.Controls.Add(this.btnPutDealRights);
            this.grpBoxDeal.Controls.Add(this.btnPutDealFunding);
            this.grpBoxDeal.Controls.Add(this.btnPutDeal);
            this.grpBoxDeal.Controls.Add(this.chkRequestLock);
            this.grpBoxDeal.Controls.Add(this.btnGetDealTechnical);
            this.grpBoxDeal.Controls.Add(this.btnGetDealGeneral);
            this.grpBoxDeal.Controls.Add(this.btnGetDealRights);
            this.grpBoxDeal.Controls.Add(this.btnGetDealWithFunding);
            this.grpBoxDeal.Controls.Add(this.lblDealId);
            this.grpBoxDeal.Controls.Add(this.txtDealId);
            this.grpBoxDeal.Controls.Add(this.btnGetDeal);
            this.grpBoxDeal.Controls.Add(this.lblLockId);
            this.grpBoxDeal.Controls.Add(this.txtLockId);
            this.grpBoxDeal.Controls.Add(this.btnGetDealAll);
            this.grpBoxDeal.Location = new System.Drawing.Point(16, 7);
            this.grpBoxDeal.Name = "grpBoxDeal";
            this.grpBoxDeal.Size = new System.Drawing.Size(320, 224);
            this.grpBoxDeal.TabIndex = 14;
            this.grpBoxDeal.TabStop = false;
            this.grpBoxDeal.Text = "Deal";
            // 
            // btnReleaseLock
            // 
            this.btnReleaseLock.Location = new System.Drawing.Point(192, 40);
            this.btnReleaseLock.Name = "btnReleaseLock";
            this.btnReleaseLock.Size = new System.Drawing.Size(112, 23);
            this.btnReleaseLock.TabIndex = 15;
            this.btnReleaseLock.Text = "ReleaseLock";
            this.btnReleaseLock.Click += new System.EventHandler(this.btnReleaseLock_Click_1);
            // 
            // btnPutDealTechnical
            // 
            this.btnPutDealTechnical.Location = new System.Drawing.Point(120, 168);
            this.btnPutDealTechnical.Name = "btnPutDealTechnical";
            this.btnPutDealTechnical.Size = new System.Drawing.Size(104, 23);
            this.btnPutDealTechnical.TabIndex = 14;
            this.btnPutDealTechnical.Text = "PutDealTechnical";
            this.btnPutDealTechnical.Click += new System.EventHandler(this.btnPutDealTechnical_Click);
            // 
            // btnPutDealGeneral
            // 
            this.btnPutDealGeneral.Location = new System.Drawing.Point(119, 96);
            this.btnPutDealGeneral.Name = "btnPutDealGeneral";
            this.btnPutDealGeneral.Size = new System.Drawing.Size(105, 23);
            this.btnPutDealGeneral.TabIndex = 13;
            this.btnPutDealGeneral.Text = "PutDealGeneral";
            this.btnPutDealGeneral.Click += new System.EventHandler(this.btnPutDealGeneral_Click);
            // 
            // btnPutDealRights
            // 
            this.btnPutDealRights.Location = new System.Drawing.Point(120, 144);
            this.btnPutDealRights.Name = "btnPutDealRights";
            this.btnPutDealRights.Size = new System.Drawing.Size(104, 23);
            this.btnPutDealRights.TabIndex = 12;
            this.btnPutDealRights.Text = "PutDealRights";
            this.btnPutDealRights.Click += new System.EventHandler(this.btnPutDealRights_Click);
            // 
            // btnPutDealFunding
            // 
            this.btnPutDealFunding.Location = new System.Drawing.Point(119, 120);
            this.btnPutDealFunding.Name = "btnPutDealFunding";
            this.btnPutDealFunding.Size = new System.Drawing.Size(105, 23);
            this.btnPutDealFunding.TabIndex = 10;
            this.btnPutDealFunding.Text = "PutDealFunding";
            this.btnPutDealFunding.Click += new System.EventHandler(this.btnPutDealFunding_Click);
            // 
            // btnPutDeal
            // 
            this.btnPutDeal.Location = new System.Drawing.Point(120, 72);
            this.btnPutDeal.Name = "btnPutDeal";
            this.btnPutDeal.Size = new System.Drawing.Size(104, 23);
            this.btnPutDeal.TabIndex = 9;
            this.btnPutDeal.Text = "PutDeal";
            this.btnPutDeal.Click += new System.EventHandler(this.btnPutDeal_Click);
            // 
            // chkRequestLock
            // 
            this.chkRequestLock.Location = new System.Drawing.Point(192, 16);
            this.chkRequestLock.Name = "chkRequestLock";
            this.chkRequestLock.Size = new System.Drawing.Size(104, 24);
            this.chkRequestLock.TabIndex = 8;
            this.chkRequestLock.Text = "RequestLock?";
            // 
            // btnGetDealTechnical
            // 
            this.btnGetDealTechnical.Location = new System.Drawing.Point(8, 168);
            this.btnGetDealTechnical.Name = "btnGetDealTechnical";
            this.btnGetDealTechnical.Size = new System.Drawing.Size(104, 23);
            this.btnGetDealTechnical.TabIndex = 7;
            this.btnGetDealTechnical.Text = "GetDealTechnical";
            this.btnGetDealTechnical.Click += new System.EventHandler(this.btnGetDealTechnical_Click);
            // 
            // btnGetDealGeneral
            // 
            this.btnGetDealGeneral.Location = new System.Drawing.Point(8, 96);
            this.btnGetDealGeneral.Name = "btnGetDealGeneral";
            this.btnGetDealGeneral.Size = new System.Drawing.Size(104, 23);
            this.btnGetDealGeneral.TabIndex = 6;
            this.btnGetDealGeneral.Text = "GetDealGeneral";
            this.btnGetDealGeneral.Click += new System.EventHandler(this.btnGetDealGeneral_Click);
            // 
            // btnGetDealRights
            // 
            this.btnGetDealRights.Location = new System.Drawing.Point(8, 144);
            this.btnGetDealRights.Name = "btnGetDealRights";
            this.btnGetDealRights.Size = new System.Drawing.Size(104, 23);
            this.btnGetDealRights.TabIndex = 5;
            this.btnGetDealRights.Text = "GetDealRights";
            this.btnGetDealRights.Click += new System.EventHandler(this.btnGetDealRights_Click);
            // 
            // btnGetDealWithFunding
            // 
            this.btnGetDealWithFunding.Location = new System.Drawing.Point(8, 120);
            this.btnGetDealWithFunding.Name = "btnGetDealWithFunding";
            this.btnGetDealWithFunding.Size = new System.Drawing.Size(104, 23);
            this.btnGetDealWithFunding.TabIndex = 3;
            this.btnGetDealWithFunding.Text = "GetDealFunding";
            this.btnGetDealWithFunding.Click += new System.EventHandler(this.btnGetDealWithFunding_Click);
            // 
            // lblDealId
            // 
            this.lblDealId.Location = new System.Drawing.Point(8, 16);
            this.lblDealId.Name = "lblDealId";
            this.lblDealId.Size = new System.Drawing.Size(40, 16);
            this.lblDealId.TabIndex = 2;
            this.lblDealId.Text = "DealId";
            // 
            // txtDealId
            // 
            this.txtDealId.Location = new System.Drawing.Point(56, 16);
            this.txtDealId.Name = "txtDealId";
            this.txtDealId.Size = new System.Drawing.Size(120, 20);
            this.txtDealId.TabIndex = 1;
            this.txtDealId.Text = "24381484";
            // 
            // btnGetDeal
            // 
            this.btnGetDeal.Location = new System.Drawing.Point(8, 72);
            this.btnGetDeal.Name = "btnGetDeal";
            this.btnGetDeal.Size = new System.Drawing.Size(104, 23);
            this.btnGetDeal.TabIndex = 0;
            this.btnGetDeal.Text = "GetDeal";
            this.btnGetDeal.Click += new System.EventHandler(this.btnGetDeal_Click);
            // 
            // lblLockId
            // 
            this.lblLockId.Location = new System.Drawing.Point(8, 40);
            this.lblLockId.Name = "lblLockId";
            this.lblLockId.Size = new System.Drawing.Size(40, 16);
            this.lblLockId.TabIndex = 2;
            this.lblLockId.Text = "LockId";
            // 
            // txtLockId
            // 
            this.txtLockId.Location = new System.Drawing.Point(56, 40);
            this.txtLockId.Name = "txtLockId";
            this.txtLockId.Size = new System.Drawing.Size(120, 20);
            this.txtLockId.TabIndex = 1;
            // 
            // btnGetDealAll
            // 
            this.btnGetDealAll.Location = new System.Drawing.Point(8, 192);
            this.btnGetDealAll.Name = "btnGetDealAll";
            this.btnGetDealAll.Size = new System.Drawing.Size(104, 23);
            this.btnGetDealAll.TabIndex = 0;
            this.btnGetDealAll.Text = "GetDealAll";
            this.btnGetDealAll.Click += new System.EventHandler(this.btnGetDealAll_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 32);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(518, 262);
            this.tabControl1.TabIndex = 17;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grpBoxDeal);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(510, 236);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Get/PutDeal";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnCreateDeal);
            this.tabPage2.Controls.Add(this.chkDealAttribute_ReUp);
            this.tabPage2.Controls.Add(this.linkLabel3);
            this.tabPage2.Controls.Add(this.linkLabel2);
            this.tabPage2.Controls.Add(this.linkLabel1);
            this.tabPage2.Controls.Add(this.chkHDRights);
            this.tabPage2.Controls.Add(this.chkSDRights);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.txtEpisodeIds);
            this.tabPage2.Controls.Add(this.txtSourceDealId);
            this.tabPage2.Controls.Add(this.txtNewDealId);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.txtMasterDealTitle);
            this.tabPage2.Controls.Add(this.txtMasterDealId);
            this.tabPage2.Controls.Add(this.txtNewDealDesc);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(510, 236);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "CreateDeal";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnCreateDeal
            // 
            this.btnCreateDeal.Location = new System.Drawing.Point(367, 191);
            this.btnCreateDeal.Name = "btnCreateDeal";
            this.btnCreateDeal.Size = new System.Drawing.Size(75, 23);
            this.btnCreateDeal.TabIndex = 11;
            this.btnCreateDeal.Text = "CreateDeal";
            this.btnCreateDeal.UseVisualStyleBackColor = true;
            this.btnCreateDeal.Click += new System.EventHandler(this.btnCreateDeal_Click);
            // 
            // chkDealAttribute_ReUp
            // 
            this.chkDealAttribute_ReUp.AutoSize = true;
            this.chkDealAttribute_ReUp.Location = new System.Drawing.Point(115, 167);
            this.chkDealAttribute_ReUp.Name = "chkDealAttribute_ReUp";
            this.chkDealAttribute_ReUp.Size = new System.Drawing.Size(54, 17);
            this.chkDealAttribute_ReUp.TabIndex = 10;
            this.chkDealAttribute_ReUp.Text = "ReUp";
            this.chkDealAttribute_ReUp.UseVisualStyleBackColor = true;
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Location = new System.Drawing.Point(242, 146);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(74, 13);
            this.linkLabel3.TabIndex = 9;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "Pick Episodes";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(242, 77);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(68, 13);
            this.linkLabel2.TabIndex = 9;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Load New Id";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(243, 28);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(68, 13);
            this.linkLabel1.TabIndex = 8;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Load New Id";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // chkHDRights
            // 
            this.chkHDRights.AutoSize = true;
            this.chkHDRights.Location = new System.Drawing.Point(163, 125);
            this.chkHDRights.Name = "chkHDRights";
            this.chkHDRights.Size = new System.Drawing.Size(42, 17);
            this.chkHDRights.TabIndex = 7;
            this.chkHDRights.Text = "HD";
            this.chkHDRights.UseVisualStyleBackColor = true;
            // 
            // chkSDRights
            // 
            this.chkSDRights.AutoSize = true;
            this.chkSDRights.Location = new System.Drawing.Point(116, 126);
            this.chkSDRights.Name = "chkSDRights";
            this.chkSDRights.Size = new System.Drawing.Size(41, 17);
            this.chkSDRights.TabIndex = 7;
            this.chkSDRights.Text = "SD";
            this.chkSDRights.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "DealId";
            // 
            // txtEpisodeIds
            // 
            this.txtEpisodeIds.Location = new System.Drawing.Point(116, 146);
            this.txtEpisodeIds.Name = "txtEpisodeIds";
            this.txtEpisodeIds.Size = new System.Drawing.Size(120, 20);
            this.txtEpisodeIds.TabIndex = 3;
            // 
            // txtSourceDealId
            // 
            this.txtSourceDealId.Location = new System.Drawing.Point(322, 143);
            this.txtSourceDealId.Name = "txtSourceDealId";
            this.txtSourceDealId.Size = new System.Drawing.Size(120, 20);
            this.txtSourceDealId.TabIndex = 3;
            // 
            // txtNewDealId
            // 
            this.txtNewDealId.Location = new System.Drawing.Point(116, 23);
            this.txtNewDealId.Name = "txtNewDealId";
            this.txtNewDealId.Size = new System.Drawing.Size(120, 20);
            this.txtNewDealId.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(10, 168);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Deal Attr. Ids";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(10, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Episode Ids";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Master Deal Title";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(319, 123);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 20);
            this.label8.TabIndex = 6;
            this.label8.Text = "Source Deal Id";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(10, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Rights";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(9, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 14);
            this.label3.TabIndex = 6;
            this.label3.Text = "Master Deal Id";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(9, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Deal Desc";
            // 
            // txtMasterDealTitle
            // 
            this.txtMasterDealTitle.Location = new System.Drawing.Point(116, 99);
            this.txtMasterDealTitle.Name = "txtMasterDealTitle";
            this.txtMasterDealTitle.Size = new System.Drawing.Size(120, 20);
            this.txtMasterDealTitle.TabIndex = 4;
            // 
            // txtMasterDealId
            // 
            this.txtMasterDealId.Location = new System.Drawing.Point(116, 73);
            this.txtMasterDealId.Name = "txtMasterDealId";
            this.txtMasterDealId.Size = new System.Drawing.Size(120, 20);
            this.txtMasterDealId.TabIndex = 4;
            // 
            // txtNewDealDesc
            // 
            this.txtNewDealDesc.Location = new System.Drawing.Point(116, 47);
            this.txtNewDealDesc.Name = "txtNewDealDesc";
            this.txtNewDealDesc.Size = new System.Drawing.Size(120, 20);
            this.txtNewDealDesc.TabIndex = 4;
            // 
            // Form_rdmPBSDeal
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(624, 558);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.dgOrionAPIs);
            this.Name = "Form_rdmPBSDeal";
            this.Text = "Form_rdmPBSDeal";
            this.Controls.SetChildIndex(this.dgOrionAPIs, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.sltProxyEnvironment, 0);
            this.Controls.SetChildIndex(this.chkGlobalSaveResults, 0);
            this.Controls.SetChildIndex(this.btnLogin, 0);
            this.Controls.SetChildIndex(this.btnLogout, 0);
            this.Controls.SetChildIndex(this.btnClearLog, 0);
            this.Controls.SetChildIndex(this.txtLog, 0);
            this.Controls.SetChildIndex(this.txtWebServiceURL, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgOrionAPIs)).EndInit();
            this.grpBoxDeal.ResumeLayout(false);
            this.grpBoxDeal.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion


#region GET DEAL APIs
		private void btnGetDeal_Click(object sender, System.EventArgs e)
		{
			dgOrionAPIs.DataSource = null;

			if (!ValidateSession())
				return;


			if (txtDealId.Text == string.Empty)
			{
				this.Log("Enter a Deal Id ", true);
				return;
			}

			if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
			{
				string sLockId;

				BVWebService.BVWebService oBVWebService = new BVWebService.BVWebService();
				oBVWebService.Url = this.txtWebServiceURL.Text + @"/Service.asmx";

				this.Log("Start GetDeal Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
				DataSet oDataSetResult = oBVWebService.GetDeal(m_sBVSessionId, int.Parse(txtDealId.Text), chkRequestLock.Checked,out sLockId);
				txtLockId.Text = sLockId;
				dgOrionAPIs.DataSource = oDataSetResult;
				this.Log("End GetDeal Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );
			}
			else
			{
				this.Log("Please log in. Session Null", true);
			}

		}

		private void btnGetDealGeneral_Click(object sender, System.EventArgs e)
		{
			dgOrionAPIs.DataSource = null;

			if (!ValidateSession())
				return;

			if (txtDealId.Text == string.Empty)
			{
				this.Log("Enter a Deal Id ");
				return;
			}

			if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
			{
				string sLockId;

				BVWebService.BVWebService s = new BVWebService.BVWebService();
				s.Url = this.txtWebServiceURL.Text + @"/Service.asmx";

				this.Log("Start GetDealWithGeneral Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString()  );
				DataSet oDataSetResult = s.GetDealWithGeneral(m_sBVSessionId, int.Parse(txtDealId.Text), chkRequestLock.Checked,out sLockId);
				dgOrionAPIs.DataSource = oDataSetResult;
				txtLockId.Text = sLockId;
				this.Log("End GetDealWithGeneral Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );
			}
			else
			{
				this.Log("Please log in. Session Null", true);
			}
		}

		private void btnGetDealWithFunding_Click(object sender, System.EventArgs e)
		{
			dgOrionAPIs.DataSource = null;

			if (!ValidateSession())
				return;

			if (txtDealId.Text == string.Empty)
			{
				this.Log("Enter a Deal Id ");
				return;
			}

			if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
			{
				string sLockId;

				BVWebService.BVWebService s = new BVWebService.BVWebService();
				s.Url = this.txtWebServiceURL.Text + @"/Service.asmx";

				this.Log("Start GetDealWithFunding Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString()  );
				DataSet oDataSetResult = s.GetDealWithFunding(m_sBVSessionId, int.Parse(txtDealId.Text), chkRequestLock.Checked,out sLockId);
				txtLockId.Text = sLockId;
				dgOrionAPIs.DataSource = oDataSetResult;
				this.Log("End GetDealWithFunding Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );
			}
			else
			{
				this.Log("Please log in. Session Null", true);
			}

		}

		private void btnGetDealRights_Click(object sender, System.EventArgs e)
		{
			dgOrionAPIs.DataSource = null;

			if (!ValidateSession())
				return;

			if (txtDealId.Text == string.Empty)
			{
				this.Log("Enter a Deal Id ");
				return;
			}

			if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
			{
				string sLockId;

				BVWebService.BVWebService s = new BVWebService.BVWebService();
				s.Url = this.txtWebServiceURL.Text + @"/Service.asmx";

				this.Log("Start GetDealWithRights Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString()  );
				DataSet oDataSetResult = s.GetDealWithRights(m_sBVSessionId, int.Parse(txtDealId.Text), chkRequestLock.Checked,out sLockId);
				dgOrionAPIs.DataSource = oDataSetResult;


				string sAPI = "GetDealRights";
				if (chkGlobalSaveResults.Checked)
				{
					if (folderBrowserDialogGlobalSaveResults.ShowDialog() == DialogResult.OK)
					{
						if (folderBrowserDialogGlobalSaveResults.SelectedPath != null)
						{
							string sPath = folderBrowserDialogGlobalSaveResults.SelectedPath + System.IO.Path.DirectorySeparatorChar.ToString() + sltProxyEnvironment.Text + "_" + sAPI + "_" + DateTime.Now.ToString("yyyyMMdd_hhMM") + ".xml";
							this.Log("Saving Result File to:  " + sPath);
							oDataSetResult.WriteXml(sPath);
						}
					}
					else
					{
						this.Log("Please specify a folder path to save the results.",true);
						return;
					}
				}




				txtLockId.Text = sLockId;
				this.Log("End GetDealWithRights Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );
			}
			else
			{
				this.Log("Please log in. Session Null", true);
			}
		}

		private void btnGetDealTechnical_Click(object sender, System.EventArgs e)
		{
			dgOrionAPIs.DataSource = null;

			if (!ValidateSession())
				return;

			if (txtDealId.Text == string.Empty)
			{
				this.Log("Enter a Deal Id ");
				return;
			}

			if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
			{
				string sLockId;

				BVWebService.BVWebService s = new BVWebService.BVWebService();
				s.Url = this.txtWebServiceURL.Text + @"/Service.asmx";

				this.Log("Start GetDealWithTechnical Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString()  );
				DataSet oDataSetResult = s.GetDealWithTechnical(m_sBVSessionId, int.Parse(txtDealId.Text), chkRequestLock.Checked,out sLockId);
				dgOrionAPIs.DataSource = oDataSetResult;
				txtLockId.Text = sLockId;
				this.Log("End GetDealWithTechnical Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );
			}
			else
			{
				this.Log("Please log in. Session Null", true);
			}
		
		}

		private void btnGetDealAll_Click(object sender, System.EventArgs e)
		{
			dgOrionAPIs.DataSource = null;

			if (!ValidateSession())
				return;

			if (txtDealId.Text == string.Empty)
			{
				this.Log("Enter a Deal Id ");
				return;
			}

			if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
			{

				string sLockId;

				BVWebService.BVWebService s = new BVWebService.BVWebService();
				s.Url = this.txtWebServiceURL.Text + @"/Service.asmx";

				this.Log("Start GetDealAll Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString()  );
				DataSet oDataSetResult = s.GetDealAll(m_sBVSessionId, int.Parse(txtDealId.Text), chkRequestLock.Checked,out sLockId);
				txtLockId.Text = sLockId;
				dgOrionAPIs.DataSource = oDataSetResult;
				this.Log("End GetDealAll Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );
			}
			else
			{
				this.Log("Please log in. Session Null",true);
			}
		}
		
#endregion

#region PUT DEAL APIs
		private void btnPutDeal_Click(object sender, System.EventArgs e)
		{

			if (!ValidateSession())
				return;

			if (txtDealId.Text == string.Empty)
			{
				this.Log("Deal Id is Missing");
				return;
			}

			if (txtLockId.Text == string.Empty)
			{
				this.Log("Lock Id is missing");
				return;
			}

			if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
			{
				

				BVWebService.BVWebService s = new BVWebService.BVWebService();
				s.Url = this.txtWebServiceURL.Text + @"/Service.asmx";

				this.Log("Start PutDeal Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString()  );
				s.PutDeal(m_sBVSessionId, int.Parse(txtDealId.Text), txtLockId.Text, (DataSet) dgOrionAPIs.DataSource );
				this.Log("End PutDeal Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );

				dgOrionAPIs.DataSource = null;
				txtLockId.Text = string.Empty;
				chkRequestLock.Checked = false;

			}
			else
			{
				this.Log("Please log in. Session Null", true);
			}

		
		}

		private void btnPutDealGeneral_Click(object sender, System.EventArgs e)
		{
			if (!ValidateSession())
				return;

			if (txtDealId.Text == string.Empty)
			{
				this.Log("Deal Id is Missing");
				return;
			}

			if (txtLockId.Text == string.Empty)
			{
				this.Log("Lock Id is missing");
				return;
			}

			if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
			{
				

				BVWebService.BVWebService s = new BVWebService.BVWebService();
				s.Url = this.txtWebServiceURL.Text + @"/Service.asmx";

				this.Log("Start PutDealGeneral Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString()  );
				s.PutDealWithGeneral(m_sBVSessionId, int.Parse(txtDealId.Text), txtLockId.Text, (DataSet) dgOrionAPIs.DataSource );
				this.Log("End PutDealGeneral Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );

				dgOrionAPIs.DataSource = null;
				txtLockId.Text = string.Empty;
				chkRequestLock.Checked = false;

			}
			else
			{
				this.Log("Please log in. Session Null", true);
			}


		}

		private void btnPutDealFunding_Click(object sender, System.EventArgs e)
		{
			if (!ValidateSession())
				return;

			if (txtDealId.Text == string.Empty)
			{
				this.Log("Deal Id is Missing");
				return;
			}

			if (txtLockId.Text == string.Empty)
			{
				this.Log("Lock Id is missing");
				return;
			}

			if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
			{
				

				BVWebService.BVWebService s = new BVWebService.BVWebService();
				s.Url = this.txtWebServiceURL.Text + @"/Service.asmx";

				this.Log("Start PutDealWithFunding Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString()  );
				s.PutDealWithFunding(m_sBVSessionId, int.Parse(txtDealId.Text), txtLockId.Text, (DataSet) dgOrionAPIs.DataSource );
				this.Log("End PutDealWithFunding Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );

				dgOrionAPIs.DataSource = null;
				txtLockId.Text = string.Empty;
				chkRequestLock.Checked = false;

			}
			else
			{
				this.Log("Please log in. Session Null", true);
			}


		}

		private void btnPutDealRights_Click(object sender, System.EventArgs e)
		{

			if (!ValidateSession())
				return;

			if (txtDealId.Text == string.Empty)
			{
				this.Log("Deal Id is Missing");
				return;
			}

			if (txtLockId.Text == string.Empty)
			{
				this.Log("Lock Id is missing");
				return;
			}

			if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
			{
				

				BVWebService.BVWebService s = new BVWebService.BVWebService();
				s.Url = this.txtWebServiceURL.Text + @"/Service.asmx";

				this.Log("Start PutDealWithRights Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString()  );
				s.PutDealWithRights(m_sBVSessionId, int.Parse(txtDealId.Text), txtLockId.Text, (DataSet) dgOrionAPIs.DataSource );
				this.Log("End PutDealWithRights Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );

				dgOrionAPIs.DataSource = null;
				txtLockId.Text = string.Empty;
				chkRequestLock.Checked = false;

			}
			else
			{
				this.Log("Please log in. Session Null", true);
			}


		}

		private void btnPutDealTechnical_Click(object sender, System.EventArgs e)
		{
			if (!ValidateSession())
				return;

			if (txtDealId.Text == string.Empty)
			{
				this.Log("Deal Id is Missing");
				return;
			}

			if (txtLockId.Text == string.Empty)
			{
				this.Log("Lock Id is missing");
				return;
			}

			if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
			{
				

				BVWebService.BVWebService s = new BVWebService.BVWebService();
				s.Url = this.txtWebServiceURL.Text + @"/Service.asmx";

				this.Log("Start PutDealWithTechnical Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString()  );
				s.PutDealWithTechnical(m_sBVSessionId, int.Parse(txtDealId.Text), txtLockId.Text, (DataSet) dgOrionAPIs.DataSource );
				this.Log("End PutDealWithTechnical Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );

				dgOrionAPIs.DataSource = null;
				txtLockId.Text = string.Empty;
				chkRequestLock.Checked = false;

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
				this.Log("Lock Id is missing");
				return;
			}

			if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
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
				this.Log("Please log in. Session Null", true);
			}
		}

#endregion

		private void btnReleaseLock_Click_1(object sender, System.EventArgs e)
		{
			dgOrionAPIs.DataSource = null;

			if (!ValidateSession())
				return;


			if (txtLockId.Text == string.Empty)
			{
				this.Log("Lock Id is required.", true);
				return;
			}

			if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
			{

				BVWebService.BVWebService oBVWebService = new BVWebService.BVWebService();
				oBVWebService.Url = this.txtWebServiceURL.Text + @"/Service.asmx";

				this.Log("Start ReleaseLock Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
				oBVWebService.ReleaseLock(m_sBVSessionId, txtLockId.Text);
				txtLockId.Text = string.Empty;
				this.Log("End ReleaseLock Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );
			}
			else
			{
				this.Log("Please log in. Session Null", true);
			}
        }

        protected int GetId()
        {
            int iReturn = -1;

            if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
            {
                BVWebService.BVWebService oBVWebService = new BVWebService.BVWebService();
                oBVWebService.Url = this.txtWebServiceURL.Text + @"/Service.asmx";

                this.Log("Start GetIds Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
                int[] oArrResults = oBVWebService.GetIDs(1);
                this.Log("End GetIds Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString());
                           
                iReturn = oArrResults[0];
            }
            else
            {
                this.Log("Please log in. Session Null", true);
            }

            return iReturn;

        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtNewDealId.Text = GetId().ToString();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtMasterDealId.Text = GetId().ToString();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        public void UpdateEpisodeIdList(string p_sEpisodeIds)
        {
            txtEpisodeIds.Text = p_sEpisodeIds;
            this.Refresh();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateDeal_EpisodeLookupPopup oForm = new CreateDeal_EpisodeLookupPopup();
            oForm.Show(this);
            
           
             

            if (!ValidateSession())
                return;


            if (txtSourceDealId.Text == string.Empty)
            {
                this.Log("Enter a Source Deal Id to search for Episodes", true);
                return;
            }


            if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
            {
                BVWebService.BVWebService oBVWebService = new BVWebService.BVWebService();
                oBVWebService.Url = this.txtWebServiceURL.Text + @"/Service.asmx";


                DataSet oDataSetResult = null;

                this.Log("Start ListProgramByDeal Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
                oDataSetResult = oBVWebService.ListProgramByDeal(m_sBVSessionId, int.Parse(txtDealId.Text));
               
                oForm.LoadDataGridView(oDataSetResult.Tables["ASSET"]);

                this.Log("End ListProgramByDeal Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString());

            }
            else
            {
                this.Log("Please log in. Session Null", true);
            }
        }

        private void btnCreateDeal_Click(object sender, EventArgs e)
        {
           

            if (!ValidateSession())
                return;


            if (txtNewDealId.Text == string.Empty)
            {
                this.Log("Deal Id is required.", true);
                return;
            }

            if (txtMasterDealId.Text == string.Empty)
            {
                this.Log("Master Deal Id is required.", true);
                return;
            }

            if (txtEpisodeIds.Text == string.Empty)
            {
                this.Log("Episode Id(s) are required.", true);
                return;
            }


            if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
            {

                BVWebService.BVWebService oBVWebService = new BVWebService.BVWebService();
                oBVWebService.Url = this.txtWebServiceURL.Text + @"/Service.asmx";

                this.Log("Start CreateDeal Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());

                int[] aiEpisodeIds;
                if (!string.IsNullOrEmpty(txtEpisodeIds.Text.Trim()))
                {
                    aiEpisodeIds = txtEpisodeIds.Text.Split(',').Select(n => Convert.ToInt32(n)).ToArray();
                }
                else
                {
                    aiEpisodeIds = new int[]{};
                }
                
                List<int> iDealAttributes = new List<int>();
                                
                if(chkDealAttribute_ReUp.Checked)
                    iDealAttributes.Add(3125356);

                oBVWebService.CreateDeal(m_sBVSessionId
                                    , int.Parse(txtNewDealId.Text)
                                    , txtNewDealDesc.Text
                                    , int.Parse(txtMasterDealId.Text)
                                    , txtMasterDealTitle.Text 
                                    , chkSDRights.Checked
                                    , chkHDRights.Checked
                                    , aiEpisodeIds
                                    , iDealAttributes.ToArray());
                
                this.Log("End CreateDeal Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString());
            }
            else
            {
                this.Log("Please log in. Session Null", true);
            }
        }










	}
}
