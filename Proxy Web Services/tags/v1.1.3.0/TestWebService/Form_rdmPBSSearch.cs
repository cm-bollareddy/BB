using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;


using TestWebService.BVWebService;
using TestWebService.SAWebService;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data;

namespace TestWebService
{
	/// <summary>
	/// Summary description for Form_rdmPBSSearch.
	/// </summary>
	public class Form_rdmPBSSearch : Form_Base
	{
		private System.Windows.Forms.DataGrid dgOrionAPIs;
		


		private System.Windows.Forms.TabControl tabControlSearch;
		private System.Windows.Forms.TabPage tabPageSearch;
		private System.Windows.Forms.GroupBox grpBoxSearch;
		private System.Windows.Forms.GroupBox groupBoxProgramSearch;
		private System.Windows.Forms.Button btnProgramSearch;
		private System.Windows.Forms.Label lblProgramSearchMaxRows;
		private System.Windows.Forms.TextBox txtProgramSearchMaxRows;
		private System.Windows.Forms.Label lblProgramSearchCriteriaKey;
		private System.Windows.Forms.GroupBox groupBoxDealSearch;
		private System.Windows.Forms.Button btnDealSearch;
		private System.Windows.Forms.Label lblDealSearchMaxRows;
		private System.Windows.Forms.TextBox txtDealSearchMaxRows;
		private System.Windows.Forms.Label labelDealSearchCriteriaKey;
		private System.Windows.Forms.GroupBox groupBoxMasterDealSearch;
		private System.Windows.Forms.Button btnMasterDealSearch;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtMasterDealSearchMaxRows;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBoxMediaInventorySearch;
		private System.Windows.Forms.Button btnMediaInventorySearch;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtMediaInventorySearchMaxRows;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TabPage tabPageSearch2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnSearchPackageAirDateHelp;
		private System.Windows.Forms.Button btnPackageAirDate;
		private System.Windows.Forms.TextBox txtSearchPackageAirDateResult;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox txtTune3;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox txtPackageNumber;
		private System.Windows.Forms.Label lblPackageNumber;
		private System.Windows.Forms.GroupBox grpFeatureAirDate;
		private System.Windows.Forms.TextBox txtFeatureMIId;
		private System.Windows.Forms.Label lblFeatureMediaInventoryId;
		private System.Windows.Forms.Button btnSearchFeatureAirDate;
		private System.Windows.Forms.TextBox txtTune2;
		private System.Windows.Forms.Label lblTune2;
		private System.Windows.Forms.TextBox txtFeatureAirDateResult;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.GroupBox grpMediaAirDate;
		private System.Windows.Forms.TextBox txtHouseNumber;
		private System.Windows.Forms.Label lblHouseNumber;
		private System.Windows.Forms.Button btnSearchMediaAirDate;
		private System.Windows.Forms.TextBox txtTune;
		private System.Windows.Forms.Label lblTune;
		private System.Windows.Forms.TextBox txtMediaAirDateResult;
		private System.Windows.Forms.Label lblMediaAirDate;
		private System.Windows.Forms.GroupBox grpBoxDetailedAirDate;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TextBox txtMediaInventoryId;
		private System.Windows.Forms.Label lblMediaInventoryId;
		private System.Windows.Forms.Button btnDetailedAirDate;
		private System.Windows.Forms.Button btnSearchFeatureAirDateHelp;
		private System.Windows.Forms.Button btnSearchMediaAirDateHelp;
		private System.Windows.Forms.TabPage tabPageSearch3;
		private System.Windows.Forms.GroupBox grpSearchPackageInfo;
		private System.Windows.Forms.TextBox txtSearchPackageInfoResultsQuantity;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Button btnSearchPackageInfo;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.GroupBox groupBoxSearchMediaInfo;
		private System.Windows.Forms.GroupBox groupBoxListPackageCutsInfo;
		private System.Windows.Forms.GroupBox groupBoxListMediaCutsInfo;
		private System.Windows.Forms.DataGrid dgMediaInventorySearchCriteria;
		private System.Windows.Forms.DataGrid dgDealSearchCriteria;
		private System.Windows.Forms.GroupBox groupBoxTrafficItemSearch;
		private System.Windows.Forms.Button btnTrafficItemSearch;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtTrafficItemSearchMaxRows;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox sltTrafficItemFormat;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.GroupBox groupBoxAdCopySearch;
		private System.Windows.Forms.Button btnAdCopySearch;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox txtAdCopySearchMaxRows;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.ComboBox sltAdCopyFormat;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.DataGrid dgProgramSearchCriteria;
		private System.Windows.Forms.DataGrid dgMasterDealSearchCriteria;
		private System.Windows.Forms.DataGrid dgTrafficItemSearchCriteria;
		private System.Windows.Forms.DataGrid dgAdCopySearchCriteria;
		private System.Windows.Forms.GroupBox groupBoxValidateEpisodeSlate;
		private System.Windows.Forms.Button btnValidateEpisodeSlate;
		private System.Windows.Forms.TextBox txtValidateEpisodeSlateNolaRoot;
		private System.Windows.Forms.Label lblNolaRoot;
		private System.Windows.Forms.TextBox txtValidateEpisodeSlateStartingEpisodeNumber;
		private System.Windows.Forms.Label lblStartingEpisodeNumber;
		private System.Windows.Forms.TextBox txtValidateEpisodeSlateNumberOfPrograms;
		private System.Windows.Forms.Label lblNumberOfPrograms;
		private System.Windows.Forms.TabPage tabPageSearch4;
		private System.Windows.Forms.DataGrid dgSearchPackageInfoSearchCriteria;
		private System.Windows.Forms.DataGrid dgSearchMediaInfoSearchCriteria;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnSearchMediaInfo;
		private System.Windows.Forms.TextBox txtSearchMediaInfoResultsQuantity;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Button btnListPackageCutsInfo;
		private System.Windows.Forms.TextBox txtListPackageCutsInfoResultsQuantity;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.DataGrid dgListPackageCutsInfoSearchCriteria;
		private System.Windows.Forms.DataGrid dgListMediaCutsInfoSearchCriteria;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Button btnListMediaCutsInfo;
		private System.Windows.Forms.TextBox txtListMediaCutsInfoResultsQuantity;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.TabPage tabPageSearch5;
		private System.Windows.Forms.GroupBox groupBoxListPackageMediaInfo;
		private System.Windows.Forms.DataGrid dgListPackageMediaInfoSearchCriteria;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Button btnListPackageMediaInfo;
		private System.Windows.Forms.TextBox txtListPackageMediaInfoResultsQuantity;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Button btnGetId;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.TextBox txtHowManyIds;
		private System.Windows.Forms.DataGrid dgIds;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form_rdmPBSSearch()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//


			SetSearchCriteria();

		}


		public void SetSearchCriteria()
		{
			dgMediaInventorySearchCriteria.DataSource		= TestWebServiceHelper.GetMediaInventorySearchCriteria();
			dgDealSearchCriteria.DataSource					= TestWebServiceHelper.GetDealSearchCriteria();
			dgMasterDealSearchCriteria.DataSource			= TestWebServiceHelper.GetMasterDealSearchCriteria();
			dgProgramSearchCriteria.DataSource				= TestWebServiceHelper.GetProgramSearchSearchCriteria();
			dgTrafficItemSearchCriteria.DataSource			= TestWebServiceHelper.GetTrafficItemSearchCriteria();
			dgAdCopySearchCriteria.DataSource				= TestWebServiceHelper.GetAdCopySearchCriteria();
			dgSearchPackageInfoSearchCriteria.DataSource	= TestWebServiceHelper.GetSearchPackageInfoSearchCriteria();
			dgSearchMediaInfoSearchCriteria.DataSource		= TestWebServiceHelper.GetSearchMediaInfoSearchCriteria();
			dgListPackageCutsInfoSearchCriteria.DataSource	= TestWebServiceHelper.GetListPackageCutsInfoSearchCriteria();
			dgListMediaCutsInfoSearchCriteria.DataSource	= TestWebServiceHelper.GetListMediaCutsInfoSearchCriteria();
			dgListPackageMediaInfoSearchCriteria.DataSource	= TestWebServiceHelper.GetListPackageMediaInfoSearchCriteria();
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
			this.tabControlSearch = new System.Windows.Forms.TabControl();
			this.tabPageSearch = new System.Windows.Forms.TabPage();
			this.grpBoxSearch = new System.Windows.Forms.GroupBox();
			this.groupBoxProgramSearch = new System.Windows.Forms.GroupBox();
			this.dgProgramSearchCriteria = new System.Windows.Forms.DataGrid();
			this.btnProgramSearch = new System.Windows.Forms.Button();
			this.lblProgramSearchMaxRows = new System.Windows.Forms.Label();
			this.txtProgramSearchMaxRows = new System.Windows.Forms.TextBox();
			this.lblProgramSearchCriteriaKey = new System.Windows.Forms.Label();
			this.groupBoxDealSearch = new System.Windows.Forms.GroupBox();
			this.btnDealSearch = new System.Windows.Forms.Button();
			this.lblDealSearchMaxRows = new System.Windows.Forms.Label();
			this.txtDealSearchMaxRows = new System.Windows.Forms.TextBox();
			this.labelDealSearchCriteriaKey = new System.Windows.Forms.Label();
			this.dgDealSearchCriteria = new System.Windows.Forms.DataGrid();
			this.groupBoxMasterDealSearch = new System.Windows.Forms.GroupBox();
			this.dgMasterDealSearchCriteria = new System.Windows.Forms.DataGrid();
			this.btnMasterDealSearch = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtMasterDealSearchMaxRows = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBoxMediaInventorySearch = new System.Windows.Forms.GroupBox();
			this.dgMediaInventorySearchCriteria = new System.Windows.Forms.DataGrid();
			this.btnMediaInventorySearch = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.txtMediaInventorySearchMaxRows = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.tabPageSearch4 = new System.Windows.Forms.TabPage();
			this.groupBoxValidateEpisodeSlate = new System.Windows.Forms.GroupBox();
			this.btnValidateEpisodeSlate = new System.Windows.Forms.Button();
			this.txtValidateEpisodeSlateNolaRoot = new System.Windows.Forms.TextBox();
			this.lblNolaRoot = new System.Windows.Forms.Label();
			this.txtValidateEpisodeSlateStartingEpisodeNumber = new System.Windows.Forms.TextBox();
			this.lblStartingEpisodeNumber = new System.Windows.Forms.Label();
			this.txtValidateEpisodeSlateNumberOfPrograms = new System.Windows.Forms.TextBox();
			this.lblNumberOfPrograms = new System.Windows.Forms.Label();
			this.groupBoxAdCopySearch = new System.Windows.Forms.GroupBox();
			this.dgAdCopySearchCriteria = new System.Windows.Forms.DataGrid();
			this.btnAdCopySearch = new System.Windows.Forms.Button();
			this.label11 = new System.Windows.Forms.Label();
			this.txtAdCopySearchMaxRows = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.sltAdCopyFormat = new System.Windows.Forms.ComboBox();
			this.label14 = new System.Windows.Forms.Label();
			this.groupBoxTrafficItemSearch = new System.Windows.Forms.GroupBox();
			this.dgTrafficItemSearchCriteria = new System.Windows.Forms.DataGrid();
			this.btnTrafficItemSearch = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.txtTrafficItemSearchMaxRows = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.sltTrafficItemFormat = new System.Windows.Forms.ComboBox();
			this.label10 = new System.Windows.Forms.Label();
			this.tabPageSearch2 = new System.Windows.Forms.TabPage();
			this.grpBoxDetailedAirDate = new System.Windows.Forms.GroupBox();
			this.label18 = new System.Windows.Forms.Label();
			this.txtMediaInventoryId = new System.Windows.Forms.TextBox();
			this.lblMediaInventoryId = new System.Windows.Forms.Label();
			this.btnDetailedAirDate = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnSearchPackageAirDateHelp = new System.Windows.Forms.Button();
			this.btnPackageAirDate = new System.Windows.Forms.Button();
			this.txtSearchPackageAirDateResult = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.txtTune3 = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.txtPackageNumber = new System.Windows.Forms.TextBox();
			this.lblPackageNumber = new System.Windows.Forms.Label();
			this.grpFeatureAirDate = new System.Windows.Forms.GroupBox();
			this.btnSearchFeatureAirDateHelp = new System.Windows.Forms.Button();
			this.txtFeatureMIId = new System.Windows.Forms.TextBox();
			this.lblFeatureMediaInventoryId = new System.Windows.Forms.Label();
			this.btnSearchFeatureAirDate = new System.Windows.Forms.Button();
			this.txtTune2 = new System.Windows.Forms.TextBox();
			this.lblTune2 = new System.Windows.Forms.Label();
			this.txtFeatureAirDateResult = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.grpMediaAirDate = new System.Windows.Forms.GroupBox();
			this.btnSearchMediaAirDateHelp = new System.Windows.Forms.Button();
			this.txtHouseNumber = new System.Windows.Forms.TextBox();
			this.lblHouseNumber = new System.Windows.Forms.Label();
			this.btnSearchMediaAirDate = new System.Windows.Forms.Button();
			this.txtTune = new System.Windows.Forms.TextBox();
			this.lblTune = new System.Windows.Forms.Label();
			this.txtMediaAirDateResult = new System.Windows.Forms.TextBox();
			this.lblMediaAirDate = new System.Windows.Forms.Label();
			this.tabPageSearch3 = new System.Windows.Forms.TabPage();
			this.grpSearchPackageInfo = new System.Windows.Forms.GroupBox();
			this.dgSearchPackageInfoSearchCriteria = new System.Windows.Forms.DataGrid();
			this.label21 = new System.Windows.Forms.Label();
			this.btnSearchPackageInfo = new System.Windows.Forms.Button();
			this.txtSearchPackageInfoResultsQuantity = new System.Windows.Forms.TextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.groupBoxSearchMediaInfo = new System.Windows.Forms.GroupBox();
			this.dgSearchMediaInfoSearchCriteria = new System.Windows.Forms.DataGrid();
			this.label3 = new System.Windows.Forms.Label();
			this.btnSearchMediaInfo = new System.Windows.Forms.Button();
			this.txtSearchMediaInfoResultsQuantity = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.groupBoxListPackageCutsInfo = new System.Windows.Forms.GroupBox();
			this.dgListPackageCutsInfoSearchCriteria = new System.Windows.Forms.DataGrid();
			this.label13 = new System.Windows.Forms.Label();
			this.btnListPackageCutsInfo = new System.Windows.Forms.Button();
			this.txtListPackageCutsInfoResultsQuantity = new System.Windows.Forms.TextBox();
			this.label22 = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.groupBoxListMediaCutsInfo = new System.Windows.Forms.GroupBox();
			this.dgListMediaCutsInfoSearchCriteria = new System.Windows.Forms.DataGrid();
			this.label24 = new System.Windows.Forms.Label();
			this.btnListMediaCutsInfo = new System.Windows.Forms.Button();
			this.txtListMediaCutsInfoResultsQuantity = new System.Windows.Forms.TextBox();
			this.label25 = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			this.tabPageSearch5 = new System.Windows.Forms.TabPage();
			this.groupBoxListPackageMediaInfo = new System.Windows.Forms.GroupBox();
			this.dgListPackageMediaInfoSearchCriteria = new System.Windows.Forms.DataGrid();
			this.label27 = new System.Windows.Forms.Label();
			this.btnListPackageMediaInfo = new System.Windows.Forms.Button();
			this.txtListPackageMediaInfoResultsQuantity = new System.Windows.Forms.TextBox();
			this.label28 = new System.Windows.Forms.Label();
			this.label29 = new System.Windows.Forms.Label();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.dgIds = new System.Windows.Forms.DataGrid();
			this.label30 = new System.Windows.Forms.Label();
			this.btnGetId = new System.Windows.Forms.Button();
			this.txtHowManyIds = new System.Windows.Forms.TextBox();
			this.label31 = new System.Windows.Forms.Label();
			this.label32 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dgOrionAPIs)).BeginInit();
			this.tabControlSearch.SuspendLayout();
			this.tabPageSearch.SuspendLayout();
			this.grpBoxSearch.SuspendLayout();
			this.groupBoxProgramSearch.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgProgramSearchCriteria)).BeginInit();
			this.groupBoxDealSearch.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgDealSearchCriteria)).BeginInit();
			this.groupBoxMasterDealSearch.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgMasterDealSearchCriteria)).BeginInit();
			this.groupBoxMediaInventorySearch.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgMediaInventorySearchCriteria)).BeginInit();
			this.tabPageSearch4.SuspendLayout();
			this.groupBoxValidateEpisodeSlate.SuspendLayout();
			this.groupBoxAdCopySearch.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgAdCopySearchCriteria)).BeginInit();
			this.groupBoxTrafficItemSearch.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgTrafficItemSearchCriteria)).BeginInit();
			this.tabPageSearch2.SuspendLayout();
			this.grpBoxDetailedAirDate.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.grpFeatureAirDate.SuspendLayout();
			this.grpMediaAirDate.SuspendLayout();
			this.tabPageSearch3.SuspendLayout();
			this.grpSearchPackageInfo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgSearchPackageInfoSearchCriteria)).BeginInit();
			this.groupBoxSearchMediaInfo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgSearchMediaInfoSearchCriteria)).BeginInit();
			this.groupBoxListPackageCutsInfo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgListPackageCutsInfoSearchCriteria)).BeginInit();
			this.groupBoxListMediaCutsInfo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgListMediaCutsInfoSearchCriteria)).BeginInit();
			this.tabPageSearch5.SuspendLayout();
			this.groupBoxListPackageMediaInfo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgListPackageMediaInfoSearchCriteria)).BeginInit();
			this.tabPage1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgIds)).BeginInit();
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
			this.txtWebServiceURL.Size = new System.Drawing.Size(832, 20);
			// 
			// txtLog
			// 
			this.txtLog.Location = new System.Drawing.Point(0, 542);
			this.txtLog.Name = "txtLog";
			this.txtLog.Size = new System.Drawing.Size(784, 112);
			// 
			// sltProxyEnvironment
			// 
			this.sltProxyEnvironment.Name = "sltProxyEnvironment";
			// 
			// chkGlobalSaveResults
			// 
			this.chkGlobalSaveResults.Location = new System.Drawing.Point(704, 112);
			this.chkGlobalSaveResults.Name = "chkGlobalSaveResults";
			this.chkGlobalSaveResults.Size = new System.Drawing.Size(72, 32);
			// 
			// dgOrionAPIs
			// 
			this.dgOrionAPIs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dgOrionAPIs.DataMember = "";
			this.dgOrionAPIs.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgOrionAPIs.Location = new System.Drawing.Point(8, 376);
			this.dgOrionAPIs.Name = "dgOrionAPIs";
			this.dgOrionAPIs.Size = new System.Drawing.Size(688, 160);
			this.dgOrionAPIs.TabIndex = 19;
			// 
			// tabControlSearch
			// 
			this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControlSearch.Controls.Add(this.tabPageSearch);
			this.tabControlSearch.Controls.Add(this.tabPageSearch4);
			this.tabControlSearch.Controls.Add(this.tabPageSearch2);
			this.tabControlSearch.Controls.Add(this.tabPageSearch3);
			this.tabControlSearch.Controls.Add(this.tabPageSearch5);
			this.tabControlSearch.Controls.Add(this.tabPage1);
			this.tabControlSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tabControlSearch.Location = new System.Drawing.Point(8, 32);
			this.tabControlSearch.Name = "tabControlSearch";
			this.tabControlSearch.SelectedIndex = 0;
			this.tabControlSearch.Size = new System.Drawing.Size(688, 392);
			this.tabControlSearch.TabIndex = 20;
			// 
			// tabPageSearch
			// 
			this.tabPageSearch.Controls.Add(this.grpBoxSearch);
			this.tabPageSearch.Location = new System.Drawing.Point(4, 22);
			this.tabPageSearch.Name = "tabPageSearch";
			this.tabPageSearch.Size = new System.Drawing.Size(680, 366);
			this.tabPageSearch.TabIndex = 0;
			this.tabPageSearch.Text = "Orion Search 1";
			// 
			// grpBoxSearch
			// 
			this.grpBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.grpBoxSearch.Controls.Add(this.groupBoxProgramSearch);
			this.grpBoxSearch.Controls.Add(this.groupBoxDealSearch);
			this.grpBoxSearch.Controls.Add(this.groupBoxMasterDealSearch);
			this.grpBoxSearch.Controls.Add(this.groupBoxMediaInventorySearch);
			this.grpBoxSearch.Location = new System.Drawing.Point(8, 7);
			this.grpBoxSearch.Name = "grpBoxSearch";
			this.grpBoxSearch.Size = new System.Drawing.Size(928, 352);
			this.grpBoxSearch.TabIndex = 19;
			this.grpBoxSearch.TabStop = false;
			this.grpBoxSearch.Text = "Search";
			// 
			// groupBoxProgramSearch
			// 
			this.groupBoxProgramSearch.Controls.Add(this.dgProgramSearchCriteria);
			this.groupBoxProgramSearch.Controls.Add(this.btnProgramSearch);
			this.groupBoxProgramSearch.Controls.Add(this.lblProgramSearchMaxRows);
			this.groupBoxProgramSearch.Controls.Add(this.txtProgramSearchMaxRows);
			this.groupBoxProgramSearch.Controls.Add(this.lblProgramSearchCriteriaKey);
			this.groupBoxProgramSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupBoxProgramSearch.Location = new System.Drawing.Point(8, 24);
			this.groupBoxProgramSearch.Name = "groupBoxProgramSearch";
			this.groupBoxProgramSearch.Size = new System.Drawing.Size(304, 104);
			this.groupBoxProgramSearch.TabIndex = 36;
			this.groupBoxProgramSearch.TabStop = false;
			this.groupBoxProgramSearch.Text = "Program Search";
			// 
			// dgProgramSearchCriteria
			// 
			this.dgProgramSearchCriteria.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dgProgramSearchCriteria.CaptionVisible = false;
			this.dgProgramSearchCriteria.DataMember = "";
			this.dgProgramSearchCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dgProgramSearchCriteria.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgProgramSearchCriteria.Location = new System.Drawing.Point(112, 12);
			this.dgProgramSearchCriteria.Name = "dgProgramSearchCriteria";
			this.dgProgramSearchCriteria.PreferredColumnWidth = 80;
			this.dgProgramSearchCriteria.PreferredRowHeight = 15;
			this.dgProgramSearchCriteria.RowHeaderWidth = 10;
			this.dgProgramSearchCriteria.Size = new System.Drawing.Size(184, 80);
			this.dgProgramSearchCriteria.TabIndex = 42;
			// 
			// btnProgramSearch
			// 
			this.btnProgramSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnProgramSearch.Location = new System.Drawing.Point(8, 72);
			this.btnProgramSearch.Name = "btnProgramSearch";
			this.btnProgramSearch.Size = new System.Drawing.Size(80, 23);
			this.btnProgramSearch.TabIndex = 40;
			this.btnProgramSearch.Text = "ProgramSearch";
			this.btnProgramSearch.Click += new System.EventHandler(this.btnProgramSearch_Click);
			// 
			// lblProgramSearchMaxRows
			// 
			this.lblProgramSearchMaxRows.Location = new System.Drawing.Point(8, 32);
			this.lblProgramSearchMaxRows.Name = "lblProgramSearchMaxRows";
			this.lblProgramSearchMaxRows.Size = new System.Drawing.Size(64, 16);
			this.lblProgramSearchMaxRows.TabIndex = 38;
			this.lblProgramSearchMaxRows.Text = "Max Rows";
			// 
			// txtProgramSearchMaxRows
			// 
			this.txtProgramSearchMaxRows.Location = new System.Drawing.Point(24, 48);
			this.txtProgramSearchMaxRows.Name = "txtProgramSearchMaxRows";
			this.txtProgramSearchMaxRows.Size = new System.Drawing.Size(24, 18);
			this.txtProgramSearchMaxRows.TabIndex = 36;
			this.txtProgramSearchMaxRows.Text = "10";
			// 
			// lblProgramSearchCriteriaKey
			// 
			this.lblProgramSearchCriteriaKey.Location = new System.Drawing.Point(8, 16);
			this.lblProgramSearchCriteriaKey.Name = "lblProgramSearchCriteriaKey";
			this.lblProgramSearchCriteriaKey.Size = new System.Drawing.Size(80, 16);
			this.lblProgramSearchCriteriaKey.TabIndex = 37;
			this.lblProgramSearchCriteriaKey.Text = "Search Criteria";
			// 
			// groupBoxDealSearch
			// 
			this.groupBoxDealSearch.Controls.Add(this.btnDealSearch);
			this.groupBoxDealSearch.Controls.Add(this.lblDealSearchMaxRows);
			this.groupBoxDealSearch.Controls.Add(this.txtDealSearchMaxRows);
			this.groupBoxDealSearch.Controls.Add(this.labelDealSearchCriteriaKey);
			this.groupBoxDealSearch.Controls.Add(this.dgDealSearchCriteria);
			this.groupBoxDealSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupBoxDealSearch.Location = new System.Drawing.Point(344, 24);
			this.groupBoxDealSearch.Name = "groupBoxDealSearch";
			this.groupBoxDealSearch.Size = new System.Drawing.Size(304, 104);
			this.groupBoxDealSearch.TabIndex = 36;
			this.groupBoxDealSearch.TabStop = false;
			this.groupBoxDealSearch.Text = "Deal Search";
			// 
			// btnDealSearch
			// 
			this.btnDealSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnDealSearch.Location = new System.Drawing.Point(8, 72);
			this.btnDealSearch.Name = "btnDealSearch";
			this.btnDealSearch.Size = new System.Drawing.Size(88, 23);
			this.btnDealSearch.TabIndex = 40;
			this.btnDealSearch.Text = "DealSearch";
			this.btnDealSearch.Click += new System.EventHandler(this.btnDealSearch_Click);
			// 
			// lblDealSearchMaxRows
			// 
			this.lblDealSearchMaxRows.Location = new System.Drawing.Point(8, 32);
			this.lblDealSearchMaxRows.Name = "lblDealSearchMaxRows";
			this.lblDealSearchMaxRows.Size = new System.Drawing.Size(64, 16);
			this.lblDealSearchMaxRows.TabIndex = 38;
			this.lblDealSearchMaxRows.Text = "Max Rows";
			// 
			// txtDealSearchMaxRows
			// 
			this.txtDealSearchMaxRows.Location = new System.Drawing.Point(24, 48);
			this.txtDealSearchMaxRows.Name = "txtDealSearchMaxRows";
			this.txtDealSearchMaxRows.Size = new System.Drawing.Size(24, 18);
			this.txtDealSearchMaxRows.TabIndex = 36;
			this.txtDealSearchMaxRows.Text = "10";
			// 
			// labelDealSearchCriteriaKey
			// 
			this.labelDealSearchCriteriaKey.Location = new System.Drawing.Point(8, 16);
			this.labelDealSearchCriteriaKey.Name = "labelDealSearchCriteriaKey";
			this.labelDealSearchCriteriaKey.Size = new System.Drawing.Size(80, 16);
			this.labelDealSearchCriteriaKey.TabIndex = 37;
			this.labelDealSearchCriteriaKey.Text = "Search Criteria";
			// 
			// dgDealSearchCriteria
			// 
			this.dgDealSearchCriteria.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dgDealSearchCriteria.CaptionVisible = false;
			this.dgDealSearchCriteria.DataMember = "";
			this.dgDealSearchCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dgDealSearchCriteria.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgDealSearchCriteria.Location = new System.Drawing.Point(112, 8);
			this.dgDealSearchCriteria.Name = "dgDealSearchCriteria";
			this.dgDealSearchCriteria.PreferredColumnWidth = 80;
			this.dgDealSearchCriteria.PreferredRowHeight = 15;
			this.dgDealSearchCriteria.RowHeaderWidth = 10;
			this.dgDealSearchCriteria.Size = new System.Drawing.Size(184, 80);
			this.dgDealSearchCriteria.TabIndex = 41;
			// 
			// groupBoxMasterDealSearch
			// 
			this.groupBoxMasterDealSearch.Controls.Add(this.dgMasterDealSearchCriteria);
			this.groupBoxMasterDealSearch.Controls.Add(this.btnMasterDealSearch);
			this.groupBoxMasterDealSearch.Controls.Add(this.label1);
			this.groupBoxMasterDealSearch.Controls.Add(this.txtMasterDealSearchMaxRows);
			this.groupBoxMasterDealSearch.Controls.Add(this.label2);
			this.groupBoxMasterDealSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupBoxMasterDealSearch.Location = new System.Drawing.Point(8, 136);
			this.groupBoxMasterDealSearch.Name = "groupBoxMasterDealSearch";
			this.groupBoxMasterDealSearch.Size = new System.Drawing.Size(304, 104);
			this.groupBoxMasterDealSearch.TabIndex = 36;
			this.groupBoxMasterDealSearch.TabStop = false;
			this.groupBoxMasterDealSearch.Text = "Master Deal Search";
			// 
			// dgMasterDealSearchCriteria
			// 
			this.dgMasterDealSearchCriteria.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dgMasterDealSearchCriteria.CaptionVisible = false;
			this.dgMasterDealSearchCriteria.DataMember = "";
			this.dgMasterDealSearchCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dgMasterDealSearchCriteria.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgMasterDealSearchCriteria.Location = new System.Drawing.Point(112, 16);
			this.dgMasterDealSearchCriteria.Name = "dgMasterDealSearchCriteria";
			this.dgMasterDealSearchCriteria.PreferredColumnWidth = 80;
			this.dgMasterDealSearchCriteria.PreferredRowHeight = 15;
			this.dgMasterDealSearchCriteria.RowHeaderWidth = 10;
			this.dgMasterDealSearchCriteria.Size = new System.Drawing.Size(184, 80);
			this.dgMasterDealSearchCriteria.TabIndex = 43;
			// 
			// btnMasterDealSearch
			// 
			this.btnMasterDealSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnMasterDealSearch.Location = new System.Drawing.Point(8, 72);
			this.btnMasterDealSearch.Name = "btnMasterDealSearch";
			this.btnMasterDealSearch.Size = new System.Drawing.Size(96, 23);
			this.btnMasterDealSearch.TabIndex = 40;
			this.btnMasterDealSearch.Text = "MasterDealSearch";
			this.btnMasterDealSearch.Click += new System.EventHandler(this.btnMasterDealSearch_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 16);
			this.label1.TabIndex = 38;
			this.label1.Text = "Max Rows";
			// 
			// txtMasterDealSearchMaxRows
			// 
			this.txtMasterDealSearchMaxRows.Location = new System.Drawing.Point(16, 48);
			this.txtMasterDealSearchMaxRows.Name = "txtMasterDealSearchMaxRows";
			this.txtMasterDealSearchMaxRows.Size = new System.Drawing.Size(24, 18);
			this.txtMasterDealSearchMaxRows.TabIndex = 36;
			this.txtMasterDealSearchMaxRows.Text = "10";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 16);
			this.label2.TabIndex = 37;
			this.label2.Text = "Search Criteria";
			// 
			// groupBoxMediaInventorySearch
			// 
			this.groupBoxMediaInventorySearch.Controls.Add(this.dgMediaInventorySearchCriteria);
			this.groupBoxMediaInventorySearch.Controls.Add(this.btnMediaInventorySearch);
			this.groupBoxMediaInventorySearch.Controls.Add(this.label4);
			this.groupBoxMediaInventorySearch.Controls.Add(this.txtMediaInventorySearchMaxRows);
			this.groupBoxMediaInventorySearch.Controls.Add(this.label5);
			this.groupBoxMediaInventorySearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupBoxMediaInventorySearch.Location = new System.Drawing.Point(344, 136);
			this.groupBoxMediaInventorySearch.Name = "groupBoxMediaInventorySearch";
			this.groupBoxMediaInventorySearch.Size = new System.Drawing.Size(304, 104);
			this.groupBoxMediaInventorySearch.TabIndex = 36;
			this.groupBoxMediaInventorySearch.TabStop = false;
			this.groupBoxMediaInventorySearch.Text = "Media Inventory Search";
			// 
			// dgMediaInventorySearchCriteria
			// 
			this.dgMediaInventorySearchCriteria.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dgMediaInventorySearchCriteria.CaptionVisible = false;
			this.dgMediaInventorySearchCriteria.DataMember = "";
			this.dgMediaInventorySearchCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dgMediaInventorySearchCriteria.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgMediaInventorySearchCriteria.Location = new System.Drawing.Point(112, 16);
			this.dgMediaInventorySearchCriteria.Name = "dgMediaInventorySearchCriteria";
			this.dgMediaInventorySearchCriteria.PreferredColumnWidth = 80;
			this.dgMediaInventorySearchCriteria.PreferredRowHeight = 15;
			this.dgMediaInventorySearchCriteria.RowHeaderWidth = 10;
			this.dgMediaInventorySearchCriteria.Size = new System.Drawing.Size(184, 80);
			this.dgMediaInventorySearchCriteria.TabIndex = 41;
			// 
			// btnMediaInventorySearch
			// 
			this.btnMediaInventorySearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnMediaInventorySearch.Location = new System.Drawing.Point(8, 72);
			this.btnMediaInventorySearch.Name = "btnMediaInventorySearch";
			this.btnMediaInventorySearch.Size = new System.Drawing.Size(96, 23);
			this.btnMediaInventorySearch.TabIndex = 40;
			this.btnMediaInventorySearch.Text = "MISearch";
			this.btnMediaInventorySearch.Click += new System.EventHandler(this.btnMediaInventorySearch_Click);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 32);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 16);
			this.label4.TabIndex = 38;
			this.label4.Text = "Max Rows";
			// 
			// txtMediaInventorySearchMaxRows
			// 
			this.txtMediaInventorySearchMaxRows.Location = new System.Drawing.Point(16, 48);
			this.txtMediaInventorySearchMaxRows.Name = "txtMediaInventorySearchMaxRows";
			this.txtMediaInventorySearchMaxRows.Size = new System.Drawing.Size(24, 18);
			this.txtMediaInventorySearchMaxRows.TabIndex = 36;
			this.txtMediaInventorySearchMaxRows.Text = "10";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(80, 16);
			this.label5.TabIndex = 37;
			this.label5.Text = "Search Criteria";
			// 
			// tabPageSearch4
			// 
			this.tabPageSearch4.Controls.Add(this.groupBoxValidateEpisodeSlate);
			this.tabPageSearch4.Controls.Add(this.groupBoxAdCopySearch);
			this.tabPageSearch4.Controls.Add(this.groupBoxTrafficItemSearch);
			this.tabPageSearch4.Location = new System.Drawing.Point(4, 22);
			this.tabPageSearch4.Name = "tabPageSearch4";
			this.tabPageSearch4.Size = new System.Drawing.Size(680, 366);
			this.tabPageSearch4.TabIndex = 3;
			this.tabPageSearch4.Text = "Orion Search 2";
			// 
			// groupBoxValidateEpisodeSlate
			// 
			this.groupBoxValidateEpisodeSlate.Controls.Add(this.btnValidateEpisodeSlate);
			this.groupBoxValidateEpisodeSlate.Controls.Add(this.txtValidateEpisodeSlateNolaRoot);
			this.groupBoxValidateEpisodeSlate.Controls.Add(this.lblNolaRoot);
			this.groupBoxValidateEpisodeSlate.Controls.Add(this.txtValidateEpisodeSlateStartingEpisodeNumber);
			this.groupBoxValidateEpisodeSlate.Controls.Add(this.lblStartingEpisodeNumber);
			this.groupBoxValidateEpisodeSlate.Controls.Add(this.txtValidateEpisodeSlateNumberOfPrograms);
			this.groupBoxValidateEpisodeSlate.Controls.Add(this.lblNumberOfPrograms);
			this.groupBoxValidateEpisodeSlate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupBoxValidateEpisodeSlate.Location = new System.Drawing.Point(376, 16);
			this.groupBoxValidateEpisodeSlate.Name = "groupBoxValidateEpisodeSlate";
			this.groupBoxValidateEpisodeSlate.Size = new System.Drawing.Size(208, 120);
			this.groupBoxValidateEpisodeSlate.TabIndex = 42;
			this.groupBoxValidateEpisodeSlate.TabStop = false;
			this.groupBoxValidateEpisodeSlate.Text = "ValidateEpisodeSlate";
			// 
			// btnValidateEpisodeSlate
			// 
			this.btnValidateEpisodeSlate.Location = new System.Drawing.Point(40, 90);
			this.btnValidateEpisodeSlate.Name = "btnValidateEpisodeSlate";
			this.btnValidateEpisodeSlate.Size = new System.Drawing.Size(128, 23);
			this.btnValidateEpisodeSlate.TabIndex = 9;
			this.btnValidateEpisodeSlate.Text = "ValidateEpisodeSlate";
			this.btnValidateEpisodeSlate.Click += new System.EventHandler(this.btnValidateEpisodeSlate_Click);
			// 
			// txtValidateEpisodeSlateNolaRoot
			// 
			this.txtValidateEpisodeSlateNolaRoot.Location = new System.Drawing.Point(96, 16);
			this.txtValidateEpisodeSlateNolaRoot.Name = "txtValidateEpisodeSlateNolaRoot";
			this.txtValidateEpisodeSlateNolaRoot.TabIndex = 7;
			this.txtValidateEpisodeSlateNolaRoot.Text = "";
			// 
			// lblNolaRoot
			// 
			this.lblNolaRoot.Location = new System.Drawing.Point(8, 24);
			this.lblNolaRoot.Name = "lblNolaRoot";
			this.lblNolaRoot.Size = new System.Drawing.Size(80, 16);
			this.lblNolaRoot.TabIndex = 3;
			this.lblNolaRoot.Text = "NolaRoot";
			// 
			// txtValidateEpisodeSlateStartingEpisodeNumber
			// 
			this.txtValidateEpisodeSlateStartingEpisodeNumber.Location = new System.Drawing.Point(96, 40);
			this.txtValidateEpisodeSlateStartingEpisodeNumber.Name = "txtValidateEpisodeSlateStartingEpisodeNumber";
			this.txtValidateEpisodeSlateStartingEpisodeNumber.TabIndex = 8;
			this.txtValidateEpisodeSlateStartingEpisodeNumber.Text = "";
			// 
			// lblStartingEpisodeNumber
			// 
			this.lblStartingEpisodeNumber.Location = new System.Drawing.Point(8, 40);
			this.lblStartingEpisodeNumber.Name = "lblStartingEpisodeNumber";
			this.lblStartingEpisodeNumber.Size = new System.Drawing.Size(80, 16);
			this.lblStartingEpisodeNumber.TabIndex = 4;
			this.lblStartingEpisodeNumber.Text = "Start Ep #";
			// 
			// txtValidateEpisodeSlateNumberOfPrograms
			// 
			this.txtValidateEpisodeSlateNumberOfPrograms.Location = new System.Drawing.Point(96, 64);
			this.txtValidateEpisodeSlateNumberOfPrograms.Name = "txtValidateEpisodeSlateNumberOfPrograms";
			this.txtValidateEpisodeSlateNumberOfPrograms.TabIndex = 6;
			this.txtValidateEpisodeSlateNumberOfPrograms.Text = "";
			// 
			// lblNumberOfPrograms
			// 
			this.lblNumberOfPrograms.Location = new System.Drawing.Point(8, 64);
			this.lblNumberOfPrograms.Name = "lblNumberOfPrograms";
			this.lblNumberOfPrograms.Size = new System.Drawing.Size(80, 16);
			this.lblNumberOfPrograms.TabIndex = 5;
			this.lblNumberOfPrograms.Text = "# of Programs";
			// 
			// groupBoxAdCopySearch
			// 
			this.groupBoxAdCopySearch.Controls.Add(this.dgAdCopySearchCriteria);
			this.groupBoxAdCopySearch.Controls.Add(this.btnAdCopySearch);
			this.groupBoxAdCopySearch.Controls.Add(this.label11);
			this.groupBoxAdCopySearch.Controls.Add(this.txtAdCopySearchMaxRows);
			this.groupBoxAdCopySearch.Controls.Add(this.label12);
			this.groupBoxAdCopySearch.Controls.Add(this.sltAdCopyFormat);
			this.groupBoxAdCopySearch.Controls.Add(this.label14);
			this.groupBoxAdCopySearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupBoxAdCopySearch.Location = new System.Drawing.Point(24, 152);
			this.groupBoxAdCopySearch.Name = "groupBoxAdCopySearch";
			this.groupBoxAdCopySearch.Size = new System.Drawing.Size(344, 120);
			this.groupBoxAdCopySearch.TabIndex = 38;
			this.groupBoxAdCopySearch.TabStop = false;
			this.groupBoxAdCopySearch.Text = "Ad Copy Search";
			// 
			// dgAdCopySearchCriteria
			// 
			this.dgAdCopySearchCriteria.CaptionVisible = false;
			this.dgAdCopySearchCriteria.DataMember = "";
			this.dgAdCopySearchCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dgAdCopySearchCriteria.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgAdCopySearchCriteria.Location = new System.Drawing.Point(152, 16);
			this.dgAdCopySearchCriteria.Name = "dgAdCopySearchCriteria";
			this.dgAdCopySearchCriteria.PreferredColumnWidth = 80;
			this.dgAdCopySearchCriteria.PreferredRowHeight = 15;
			this.dgAdCopySearchCriteria.RowHeaderWidth = 10;
			this.dgAdCopySearchCriteria.Size = new System.Drawing.Size(184, 96);
			this.dgAdCopySearchCriteria.TabIndex = 44;
			// 
			// btnAdCopySearch
			// 
			this.btnAdCopySearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnAdCopySearch.Location = new System.Drawing.Point(8, 88);
			this.btnAdCopySearch.Name = "btnAdCopySearch";
			this.btnAdCopySearch.Size = new System.Drawing.Size(96, 23);
			this.btnAdCopySearch.TabIndex = 40;
			this.btnAdCopySearch.Text = "AdCopySearch";
			this.btnAdCopySearch.Click += new System.EventHandler(this.btnAdCopySearch_Click);
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(8, 56);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(64, 16);
			this.label11.TabIndex = 38;
			this.label11.Text = "Max Rows";
			// 
			// txtAdCopySearchMaxRows
			// 
			this.txtAdCopySearchMaxRows.Location = new System.Drawing.Point(72, 56);
			this.txtAdCopySearchMaxRows.Name = "txtAdCopySearchMaxRows";
			this.txtAdCopySearchMaxRows.Size = new System.Drawing.Size(24, 18);
			this.txtAdCopySearchMaxRows.TabIndex = 36;
			this.txtAdCopySearchMaxRows.Text = "10";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(8, 16);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(88, 16);
			this.label12.TabIndex = 37;
			this.label12.Text = "Search Criteria";
			// 
			// sltAdCopyFormat
			// 
			this.sltAdCopyFormat.Items.AddRange(new object[] {
																 "HD|54002",
																 "SD|54001"});
			this.sltAdCopyFormat.Location = new System.Drawing.Point(72, 32);
			this.sltAdCopyFormat.Name = "sltAdCopyFormat";
			this.sltAdCopyFormat.Size = new System.Drawing.Size(56, 20);
			this.sltAdCopyFormat.TabIndex = 39;
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(8, 32);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(40, 16);
			this.label14.TabIndex = 37;
			this.label14.Text = "Format";
			// 
			// groupBoxTrafficItemSearch
			// 
			this.groupBoxTrafficItemSearch.Controls.Add(this.dgTrafficItemSearchCriteria);
			this.groupBoxTrafficItemSearch.Controls.Add(this.btnTrafficItemSearch);
			this.groupBoxTrafficItemSearch.Controls.Add(this.label7);
			this.groupBoxTrafficItemSearch.Controls.Add(this.txtTrafficItemSearchMaxRows);
			this.groupBoxTrafficItemSearch.Controls.Add(this.label9);
			this.groupBoxTrafficItemSearch.Controls.Add(this.sltTrafficItemFormat);
			this.groupBoxTrafficItemSearch.Controls.Add(this.label10);
			this.groupBoxTrafficItemSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupBoxTrafficItemSearch.Location = new System.Drawing.Point(24, 16);
			this.groupBoxTrafficItemSearch.Name = "groupBoxTrafficItemSearch";
			this.groupBoxTrafficItemSearch.Size = new System.Drawing.Size(344, 120);
			this.groupBoxTrafficItemSearch.TabIndex = 37;
			this.groupBoxTrafficItemSearch.TabStop = false;
			this.groupBoxTrafficItemSearch.Text = "Traffic Item Search";
			// 
			// dgTrafficItemSearchCriteria
			// 
			this.dgTrafficItemSearchCriteria.CaptionVisible = false;
			this.dgTrafficItemSearchCriteria.DataMember = "";
			this.dgTrafficItemSearchCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dgTrafficItemSearchCriteria.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgTrafficItemSearchCriteria.Location = new System.Drawing.Point(152, 16);
			this.dgTrafficItemSearchCriteria.Name = "dgTrafficItemSearchCriteria";
			this.dgTrafficItemSearchCriteria.PreferredColumnWidth = 80;
			this.dgTrafficItemSearchCriteria.PreferredRowHeight = 15;
			this.dgTrafficItemSearchCriteria.RowHeaderWidth = 10;
			this.dgTrafficItemSearchCriteria.Size = new System.Drawing.Size(184, 96);
			this.dgTrafficItemSearchCriteria.TabIndex = 43;
			// 
			// btnTrafficItemSearch
			// 
			this.btnTrafficItemSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnTrafficItemSearch.Location = new System.Drawing.Point(8, 80);
			this.btnTrafficItemSearch.Name = "btnTrafficItemSearch";
			this.btnTrafficItemSearch.Size = new System.Drawing.Size(96, 23);
			this.btnTrafficItemSearch.TabIndex = 40;
			this.btnTrafficItemSearch.Text = "TrafficItemSearch";
			this.btnTrafficItemSearch.Click += new System.EventHandler(this.btnTrafficItemSearch_Click);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(8, 56);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(64, 16);
			this.label7.TabIndex = 38;
			this.label7.Text = "Max Rows";
			// 
			// txtTrafficItemSearchMaxRows
			// 
			this.txtTrafficItemSearchMaxRows.Location = new System.Drawing.Point(72, 56);
			this.txtTrafficItemSearchMaxRows.Name = "txtTrafficItemSearchMaxRows";
			this.txtTrafficItemSearchMaxRows.Size = new System.Drawing.Size(24, 18);
			this.txtTrafficItemSearchMaxRows.TabIndex = 36;
			this.txtTrafficItemSearchMaxRows.Text = "10";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(8, 16);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(80, 16);
			this.label9.TabIndex = 38;
			this.label9.Text = "Search Criteria";
			// 
			// sltTrafficItemFormat
			// 
			this.sltTrafficItemFormat.Items.AddRange(new object[] {
																	  "HD|54002",
																	  "SD|54001"});
			this.sltTrafficItemFormat.Location = new System.Drawing.Point(72, 32);
			this.sltTrafficItemFormat.Name = "sltTrafficItemFormat";
			this.sltTrafficItemFormat.Size = new System.Drawing.Size(64, 20);
			this.sltTrafficItemFormat.TabIndex = 39;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(8, 32);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(64, 16);
			this.label10.TabIndex = 37;
			this.label10.Text = "Format";
			// 
			// tabPageSearch2
			// 
			this.tabPageSearch2.Controls.Add(this.grpBoxDetailedAirDate);
			this.tabPageSearch2.Controls.Add(this.groupBox1);
			this.tabPageSearch2.Controls.Add(this.grpFeatureAirDate);
			this.tabPageSearch2.Controls.Add(this.grpMediaAirDate);
			this.tabPageSearch2.Location = new System.Drawing.Point(4, 22);
			this.tabPageSearch2.Name = "tabPageSearch2";
			this.tabPageSearch2.Size = new System.Drawing.Size(680, 366);
			this.tabPageSearch2.TabIndex = 1;
			this.tabPageSearch2.Text = "ScheduAll Search";
			// 
			// grpBoxDetailedAirDate
			// 
			this.grpBoxDetailedAirDate.Controls.Add(this.label18);
			this.grpBoxDetailedAirDate.Controls.Add(this.txtMediaInventoryId);
			this.grpBoxDetailedAirDate.Controls.Add(this.lblMediaInventoryId);
			this.grpBoxDetailedAirDate.Controls.Add(this.btnDetailedAirDate);
			this.grpBoxDetailedAirDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.grpBoxDetailedAirDate.Location = new System.Drawing.Point(8, 184);
			this.grpBoxDetailedAirDate.Name = "grpBoxDetailedAirDate";
			this.grpBoxDetailedAirDate.Size = new System.Drawing.Size(200, 120);
			this.grpBoxDetailedAirDate.TabIndex = 40;
			this.grpBoxDetailedAirDate.TabStop = false;
			this.grpBoxDetailedAirDate.Text = "Detailed Air Date";
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(32, 96);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(100, 16);
			this.label18.TabIndex = 33;
			this.label18.Text = "results in datagrid";
			// 
			// txtMediaInventoryId
			// 
			this.txtMediaInventoryId.Location = new System.Drawing.Point(56, 32);
			this.txtMediaInventoryId.Name = "txtMediaInventoryId";
			this.txtMediaInventoryId.TabIndex = 32;
			this.txtMediaInventoryId.Text = "3788818";
			// 
			// lblMediaInventoryId
			// 
			this.lblMediaInventoryId.Location = new System.Drawing.Point(8, 32);
			this.lblMediaInventoryId.Name = "lblMediaInventoryId";
			this.lblMediaInventoryId.Size = new System.Drawing.Size(48, 16);
			this.lblMediaInventoryId.TabIndex = 31;
			this.lblMediaInventoryId.Text = "MEI_ID";
			// 
			// btnDetailedAirDate
			// 
			this.btnDetailedAirDate.Location = new System.Drawing.Point(24, 64);
			this.btnDetailedAirDate.Name = "btnDetailedAirDate";
			this.btnDetailedAirDate.Size = new System.Drawing.Size(120, 23);
			this.btnDetailedAirDate.TabIndex = 30;
			this.btnDetailedAirDate.Text = "GetDetailedAirDate";
			this.btnDetailedAirDate.Click += new System.EventHandler(this.btnDetailedAirDate_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnSearchPackageAirDateHelp);
			this.groupBox1.Controls.Add(this.btnPackageAirDate);
			this.groupBox1.Controls.Add(this.txtSearchPackageAirDateResult);
			this.groupBox1.Controls.Add(this.label15);
			this.groupBox1.Controls.Add(this.txtTune3);
			this.groupBox1.Controls.Add(this.label16);
			this.groupBox1.Controls.Add(this.txtPackageNumber);
			this.groupBox1.Controls.Add(this.lblPackageNumber);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(424, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(208, 160);
			this.groupBox1.TabIndex = 39;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Search Package Air Date";
			// 
			// btnSearchPackageAirDateHelp
			// 
			this.btnSearchPackageAirDateHelp.Location = new System.Drawing.Point(144, 88);
			this.btnSearchPackageAirDateHelp.Name = "btnSearchPackageAirDateHelp";
			this.btnSearchPackageAirDateHelp.Size = new System.Drawing.Size(56, 23);
			this.btnSearchPackageAirDateHelp.TabIndex = 34;
			this.btnSearchPackageAirDateHelp.Text = "HELP";
			this.btnSearchPackageAirDateHelp.Click += new System.EventHandler(this.btnSearchPackageAirDateHelp_Click);
			// 
			// btnPackageAirDate
			// 
			this.btnPackageAirDate.Location = new System.Drawing.Point(8, 88);
			this.btnPackageAirDate.Name = "btnPackageAirDate";
			this.btnPackageAirDate.Size = new System.Drawing.Size(136, 23);
			this.btnPackageAirDate.TabIndex = 25;
			this.btnPackageAirDate.Text = "PackageAirDate";
			this.btnPackageAirDate.Click += new System.EventHandler(this.btnPackageAirDate_Click);
			// 
			// txtSearchPackageAirDateResult
			// 
			this.txtSearchPackageAirDateResult.Location = new System.Drawing.Point(56, 120);
			this.txtSearchPackageAirDateResult.Name = "txtSearchPackageAirDateResult";
			this.txtSearchPackageAirDateResult.TabIndex = 32;
			this.txtSearchPackageAirDateResult.Text = "";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(8, 120);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(48, 24);
			this.label15.TabIndex = 31;
			this.label15.Text = "Result";
			// 
			// txtTune3
			// 
			this.txtTune3.Location = new System.Drawing.Point(72, 48);
			this.txtTune3.Name = "txtTune3";
			this.txtTune3.TabIndex = 32;
			this.txtTune3.Text = "1";
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(24, 48);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(48, 16);
			this.label16.TabIndex = 31;
			this.label16.Text = "Tune";
			// 
			// txtPackageNumber
			// 
			this.txtPackageNumber.Location = new System.Drawing.Point(72, 24);
			this.txtPackageNumber.Name = "txtPackageNumber";
			this.txtPackageNumber.TabIndex = 32;
			this.txtPackageNumber.Text = "P311154-001";
			// 
			// lblPackageNumber
			// 
			this.lblPackageNumber.Location = new System.Drawing.Point(24, 24);
			this.lblPackageNumber.Name = "lblPackageNumber";
			this.lblPackageNumber.Size = new System.Drawing.Size(48, 16);
			this.lblPackageNumber.TabIndex = 31;
			this.lblPackageNumber.Text = "Package#";
			// 
			// grpFeatureAirDate
			// 
			this.grpFeatureAirDate.Controls.Add(this.btnSearchFeatureAirDateHelp);
			this.grpFeatureAirDate.Controls.Add(this.txtFeatureMIId);
			this.grpFeatureAirDate.Controls.Add(this.lblFeatureMediaInventoryId);
			this.grpFeatureAirDate.Controls.Add(this.btnSearchFeatureAirDate);
			this.grpFeatureAirDate.Controls.Add(this.txtTune2);
			this.grpFeatureAirDate.Controls.Add(this.lblTune2);
			this.grpFeatureAirDate.Controls.Add(this.txtFeatureAirDateResult);
			this.grpFeatureAirDate.Controls.Add(this.label17);
			this.grpFeatureAirDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.grpFeatureAirDate.Location = new System.Drawing.Point(216, 16);
			this.grpFeatureAirDate.Name = "grpFeatureAirDate";
			this.grpFeatureAirDate.Size = new System.Drawing.Size(200, 160);
			this.grpFeatureAirDate.TabIndex = 38;
			this.grpFeatureAirDate.TabStop = false;
			this.grpFeatureAirDate.Text = "Search Feature Air Date";
			// 
			// btnSearchFeatureAirDateHelp
			// 
			this.btnSearchFeatureAirDateHelp.Location = new System.Drawing.Point(136, 88);
			this.btnSearchFeatureAirDateHelp.Name = "btnSearchFeatureAirDateHelp";
			this.btnSearchFeatureAirDateHelp.Size = new System.Drawing.Size(56, 23);
			this.btnSearchFeatureAirDateHelp.TabIndex = 33;
			this.btnSearchFeatureAirDateHelp.Text = "HELP";
			this.btnSearchFeatureAirDateHelp.Click += new System.EventHandler(this.btnSearchFeatureAirDateHelp_Click);
			// 
			// txtFeatureMIId
			// 
			this.txtFeatureMIId.Location = new System.Drawing.Point(56, 32);
			this.txtFeatureMIId.Name = "txtFeatureMIId";
			this.txtFeatureMIId.TabIndex = 32;
			this.txtFeatureMIId.Text = "23019073";
			// 
			// lblFeatureMediaInventoryId
			// 
			this.lblFeatureMediaInventoryId.Location = new System.Drawing.Point(8, 32);
			this.lblFeatureMediaInventoryId.Name = "lblFeatureMediaInventoryId";
			this.lblFeatureMediaInventoryId.Size = new System.Drawing.Size(48, 16);
			this.lblFeatureMediaInventoryId.TabIndex = 31;
			this.lblFeatureMediaInventoryId.Text = "FMI ID";
			// 
			// btnSearchFeatureAirDate
			// 
			this.btnSearchFeatureAirDate.Location = new System.Drawing.Point(8, 88);
			this.btnSearchFeatureAirDate.Name = "btnSearchFeatureAirDate";
			this.btnSearchFeatureAirDate.Size = new System.Drawing.Size(128, 23);
			this.btnSearchFeatureAirDate.TabIndex = 30;
			this.btnSearchFeatureAirDate.Text = "SearchFeatureAirDate";
			this.btnSearchFeatureAirDate.Click += new System.EventHandler(this.btnSearchFeatureAirDate_Click);
			// 
			// txtTune2
			// 
			this.txtTune2.Location = new System.Drawing.Point(56, 56);
			this.txtTune2.Name = "txtTune2";
			this.txtTune2.TabIndex = 32;
			this.txtTune2.Text = "0";
			// 
			// lblTune2
			// 
			this.lblTune2.Location = new System.Drawing.Point(8, 56);
			this.lblTune2.Name = "lblTune2";
			this.lblTune2.Size = new System.Drawing.Size(48, 16);
			this.lblTune2.TabIndex = 31;
			this.lblTune2.Text = "Tune";
			// 
			// txtFeatureAirDateResult
			// 
			this.txtFeatureAirDateResult.Location = new System.Drawing.Point(56, 120);
			this.txtFeatureAirDateResult.Name = "txtFeatureAirDateResult";
			this.txtFeatureAirDateResult.TabIndex = 32;
			this.txtFeatureAirDateResult.Text = "";
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(8, 120);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(48, 24);
			this.label17.TabIndex = 31;
			this.label17.Text = "Result";
			// 
			// grpMediaAirDate
			// 
			this.grpMediaAirDate.Controls.Add(this.btnSearchMediaAirDateHelp);
			this.grpMediaAirDate.Controls.Add(this.txtHouseNumber);
			this.grpMediaAirDate.Controls.Add(this.lblHouseNumber);
			this.grpMediaAirDate.Controls.Add(this.btnSearchMediaAirDate);
			this.grpMediaAirDate.Controls.Add(this.txtTune);
			this.grpMediaAirDate.Controls.Add(this.lblTune);
			this.grpMediaAirDate.Controls.Add(this.txtMediaAirDateResult);
			this.grpMediaAirDate.Controls.Add(this.lblMediaAirDate);
			this.grpMediaAirDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.grpMediaAirDate.Location = new System.Drawing.Point(8, 16);
			this.grpMediaAirDate.Name = "grpMediaAirDate";
			this.grpMediaAirDate.Size = new System.Drawing.Size(200, 160);
			this.grpMediaAirDate.TabIndex = 37;
			this.grpMediaAirDate.TabStop = false;
			this.grpMediaAirDate.Text = "Search Media Air Date";
			// 
			// btnSearchMediaAirDateHelp
			// 
			this.btnSearchMediaAirDateHelp.Location = new System.Drawing.Point(128, 88);
			this.btnSearchMediaAirDateHelp.Name = "btnSearchMediaAirDateHelp";
			this.btnSearchMediaAirDateHelp.Size = new System.Drawing.Size(56, 23);
			this.btnSearchMediaAirDateHelp.TabIndex = 33;
			this.btnSearchMediaAirDateHelp.Text = "HELP";
			this.btnSearchMediaAirDateHelp.Click += new System.EventHandler(this.btnSearchMediaAirDateHelp_Click);
			// 
			// txtHouseNumber
			// 
			this.txtHouseNumber.Location = new System.Drawing.Point(56, 32);
			this.txtHouseNumber.Name = "txtHouseNumber";
			this.txtHouseNumber.TabIndex = 32;
			this.txtHouseNumber.Text = "1083955-1";
			// 
			// lblHouseNumber
			// 
			this.lblHouseNumber.Location = new System.Drawing.Point(8, 32);
			this.lblHouseNumber.Name = "lblHouseNumber";
			this.lblHouseNumber.Size = new System.Drawing.Size(48, 16);
			this.lblHouseNumber.TabIndex = 31;
			this.lblHouseNumber.Text = "House #";
			// 
			// btnSearchMediaAirDate
			// 
			this.btnSearchMediaAirDate.Location = new System.Drawing.Point(8, 88);
			this.btnSearchMediaAirDate.Name = "btnSearchMediaAirDate";
			this.btnSearchMediaAirDate.Size = new System.Drawing.Size(120, 23);
			this.btnSearchMediaAirDate.TabIndex = 30;
			this.btnSearchMediaAirDate.Text = "SearchMediaAirDate";
			this.btnSearchMediaAirDate.Click += new System.EventHandler(this.btnSearchMediaAirDate_Click);
			// 
			// txtTune
			// 
			this.txtTune.Location = new System.Drawing.Point(56, 56);
			this.txtTune.Name = "txtTune";
			this.txtTune.TabIndex = 32;
			this.txtTune.Text = "1";
			// 
			// lblTune
			// 
			this.lblTune.Location = new System.Drawing.Point(8, 56);
			this.lblTune.Name = "lblTune";
			this.lblTune.Size = new System.Drawing.Size(48, 16);
			this.lblTune.TabIndex = 31;
			this.lblTune.Text = "Tune";
			// 
			// txtMediaAirDateResult
			// 
			this.txtMediaAirDateResult.Location = new System.Drawing.Point(56, 120);
			this.txtMediaAirDateResult.Name = "txtMediaAirDateResult";
			this.txtMediaAirDateResult.TabIndex = 32;
			this.txtMediaAirDateResult.Text = "";
			// 
			// lblMediaAirDate
			// 
			this.lblMediaAirDate.Location = new System.Drawing.Point(8, 120);
			this.lblMediaAirDate.Name = "lblMediaAirDate";
			this.lblMediaAirDate.Size = new System.Drawing.Size(48, 24);
			this.lblMediaAirDate.TabIndex = 31;
			this.lblMediaAirDate.Text = "Result";
			// 
			// tabPageSearch3
			// 
			this.tabPageSearch3.Controls.Add(this.grpSearchPackageInfo);
			this.tabPageSearch3.Controls.Add(this.groupBoxSearchMediaInfo);
			this.tabPageSearch3.Controls.Add(this.groupBoxListPackageCutsInfo);
			this.tabPageSearch3.Controls.Add(this.groupBoxListMediaCutsInfo);
			this.tabPageSearch3.Location = new System.Drawing.Point(4, 22);
			this.tabPageSearch3.Name = "tabPageSearch3";
			this.tabPageSearch3.Size = new System.Drawing.Size(680, 366);
			this.tabPageSearch3.TabIndex = 2;
			this.tabPageSearch3.Text = "ScheduAll Search 2";
			// 
			// grpSearchPackageInfo
			// 
			this.grpSearchPackageInfo.Controls.Add(this.dgSearchPackageInfoSearchCriteria);
			this.grpSearchPackageInfo.Controls.Add(this.label21);
			this.grpSearchPackageInfo.Controls.Add(this.btnSearchPackageInfo);
			this.grpSearchPackageInfo.Controls.Add(this.txtSearchPackageInfoResultsQuantity);
			this.grpSearchPackageInfo.Controls.Add(this.label19);
			this.grpSearchPackageInfo.Controls.Add(this.label20);
			this.grpSearchPackageInfo.Location = new System.Drawing.Point(8, 16);
			this.grpSearchPackageInfo.Name = "grpSearchPackageInfo";
			this.grpSearchPackageInfo.Size = new System.Drawing.Size(320, 120);
			this.grpSearchPackageInfo.TabIndex = 35;
			this.grpSearchPackageInfo.TabStop = false;
			this.grpSearchPackageInfo.Text = "Search Package Info";
			// 
			// dgSearchPackageInfoSearchCriteria
			// 
			this.dgSearchPackageInfoSearchCriteria.CaptionVisible = false;
			this.dgSearchPackageInfoSearchCriteria.DataMember = "";
			this.dgSearchPackageInfoSearchCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dgSearchPackageInfoSearchCriteria.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgSearchPackageInfoSearchCriteria.Location = new System.Drawing.Point(136, 16);
			this.dgSearchPackageInfoSearchCriteria.Name = "dgSearchPackageInfoSearchCriteria";
			this.dgSearchPackageInfoSearchCriteria.PreferredColumnWidth = 80;
			this.dgSearchPackageInfoSearchCriteria.PreferredRowHeight = 15;
			this.dgSearchPackageInfoSearchCriteria.RowHeaderWidth = 10;
			this.dgSearchPackageInfoSearchCriteria.Size = new System.Drawing.Size(176, 96);
			this.dgSearchPackageInfoSearchCriteria.TabIndex = 44;
			// 
			// label21
			// 
			this.label21.Location = new System.Drawing.Point(8, 24);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(88, 16);
			this.label21.TabIndex = 39;
			this.label21.Text = "Search Criterion ";
			this.label21.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// btnSearchPackageInfo
			// 
			this.btnSearchPackageInfo.Location = new System.Drawing.Point(8, 64);
			this.btnSearchPackageInfo.Name = "btnSearchPackageInfo";
			this.btnSearchPackageInfo.Size = new System.Drawing.Size(112, 23);
			this.btnSearchPackageInfo.TabIndex = 12;
			this.btnSearchPackageInfo.Text = "SearchPackageInfo";
			this.btnSearchPackageInfo.Click += new System.EventHandler(this.btnSearchPackageInfo_Click);
			// 
			// txtSearchPackageInfoResultsQuantity
			// 
			this.txtSearchPackageInfoResultsQuantity.Location = new System.Drawing.Point(88, 40);
			this.txtSearchPackageInfoResultsQuantity.Name = "txtSearchPackageInfoResultsQuantity";
			this.txtSearchPackageInfoResultsQuantity.Size = new System.Drawing.Size(24, 20);
			this.txtSearchPackageInfoResultsQuantity.TabIndex = 32;
			this.txtSearchPackageInfoResultsQuantity.Text = "1";
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(16, 40);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(64, 16);
			this.label19.TabIndex = 31;
			this.label19.Text = "# of Results";
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(16, 96);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(100, 16);
			this.label20.TabIndex = 33;
			this.label20.Text = "results in datagrid";
			// 
			// groupBoxSearchMediaInfo
			// 
			this.groupBoxSearchMediaInfo.Controls.Add(this.dgSearchMediaInfoSearchCriteria);
			this.groupBoxSearchMediaInfo.Controls.Add(this.label3);
			this.groupBoxSearchMediaInfo.Controls.Add(this.btnSearchMediaInfo);
			this.groupBoxSearchMediaInfo.Controls.Add(this.txtSearchMediaInfoResultsQuantity);
			this.groupBoxSearchMediaInfo.Controls.Add(this.label6);
			this.groupBoxSearchMediaInfo.Controls.Add(this.label8);
			this.groupBoxSearchMediaInfo.Location = new System.Drawing.Point(8, 160);
			this.groupBoxSearchMediaInfo.Name = "groupBoxSearchMediaInfo";
			this.groupBoxSearchMediaInfo.Size = new System.Drawing.Size(320, 120);
			this.groupBoxSearchMediaInfo.TabIndex = 35;
			this.groupBoxSearchMediaInfo.TabStop = false;
			this.groupBoxSearchMediaInfo.Text = "Search Media Info";
			// 
			// dgSearchMediaInfoSearchCriteria
			// 
			this.dgSearchMediaInfoSearchCriteria.CaptionVisible = false;
			this.dgSearchMediaInfoSearchCriteria.DataMember = "";
			this.dgSearchMediaInfoSearchCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dgSearchMediaInfoSearchCriteria.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgSearchMediaInfoSearchCriteria.Location = new System.Drawing.Point(136, 12);
			this.dgSearchMediaInfoSearchCriteria.Name = "dgSearchMediaInfoSearchCriteria";
			this.dgSearchMediaInfoSearchCriteria.PreferredColumnWidth = 80;
			this.dgSearchMediaInfoSearchCriteria.PreferredRowHeight = 15;
			this.dgSearchMediaInfoSearchCriteria.RowHeaderWidth = 10;
			this.dgSearchMediaInfoSearchCriteria.Size = new System.Drawing.Size(176, 96);
			this.dgSearchMediaInfoSearchCriteria.TabIndex = 50;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 20);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(88, 16);
			this.label3.TabIndex = 49;
			this.label3.Text = "Search Criterion ";
			this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// btnSearchMediaInfo
			// 
			this.btnSearchMediaInfo.Location = new System.Drawing.Point(8, 60);
			this.btnSearchMediaInfo.Name = "btnSearchMediaInfo";
			this.btnSearchMediaInfo.Size = new System.Drawing.Size(112, 23);
			this.btnSearchMediaInfo.TabIndex = 45;
			this.btnSearchMediaInfo.Text = "SearchMediaInfo";
			this.btnSearchMediaInfo.Click += new System.EventHandler(this.btnSearchMediaInfo_Click);
			// 
			// txtSearchMediaInfoResultsQuantity
			// 
			this.txtSearchMediaInfoResultsQuantity.Location = new System.Drawing.Point(80, 36);
			this.txtSearchMediaInfoResultsQuantity.Name = "txtSearchMediaInfoResultsQuantity";
			this.txtSearchMediaInfoResultsQuantity.Size = new System.Drawing.Size(24, 20);
			this.txtSearchMediaInfoResultsQuantity.TabIndex = 47;
			this.txtSearchMediaInfoResultsQuantity.Text = "1";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 36);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(64, 16);
			this.label6.TabIndex = 46;
			this.label6.Text = "# of Results";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(8, 92);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(100, 16);
			this.label8.TabIndex = 48;
			this.label8.Text = "results in datagrid";
			// 
			// groupBoxListPackageCutsInfo
			// 
			this.groupBoxListPackageCutsInfo.Controls.Add(this.dgListPackageCutsInfoSearchCriteria);
			this.groupBoxListPackageCutsInfo.Controls.Add(this.label13);
			this.groupBoxListPackageCutsInfo.Controls.Add(this.btnListPackageCutsInfo);
			this.groupBoxListPackageCutsInfo.Controls.Add(this.txtListPackageCutsInfoResultsQuantity);
			this.groupBoxListPackageCutsInfo.Controls.Add(this.label22);
			this.groupBoxListPackageCutsInfo.Controls.Add(this.label23);
			this.groupBoxListPackageCutsInfo.Location = new System.Drawing.Point(344, 16);
			this.groupBoxListPackageCutsInfo.Name = "groupBoxListPackageCutsInfo";
			this.groupBoxListPackageCutsInfo.Size = new System.Drawing.Size(320, 120);
			this.groupBoxListPackageCutsInfo.TabIndex = 35;
			this.groupBoxListPackageCutsInfo.TabStop = false;
			this.groupBoxListPackageCutsInfo.Text = "List Package Cuts Info";
			// 
			// dgListPackageCutsInfoSearchCriteria
			// 
			this.dgListPackageCutsInfoSearchCriteria.CaptionVisible = false;
			this.dgListPackageCutsInfoSearchCriteria.DataMember = "";
			this.dgListPackageCutsInfoSearchCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dgListPackageCutsInfoSearchCriteria.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgListPackageCutsInfoSearchCriteria.Location = new System.Drawing.Point(136, 12);
			this.dgListPackageCutsInfoSearchCriteria.Name = "dgListPackageCutsInfoSearchCriteria";
			this.dgListPackageCutsInfoSearchCriteria.PreferredColumnWidth = 80;
			this.dgListPackageCutsInfoSearchCriteria.PreferredRowHeight = 15;
			this.dgListPackageCutsInfoSearchCriteria.RowHeaderWidth = 10;
			this.dgListPackageCutsInfoSearchCriteria.Size = new System.Drawing.Size(176, 96);
			this.dgListPackageCutsInfoSearchCriteria.TabIndex = 50;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(8, 20);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(88, 16);
			this.label13.TabIndex = 49;
			this.label13.Text = "Search Criterion ";
			this.label13.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// btnListPackageCutsInfo
			// 
			this.btnListPackageCutsInfo.Location = new System.Drawing.Point(8, 60);
			this.btnListPackageCutsInfo.Name = "btnListPackageCutsInfo";
			this.btnListPackageCutsInfo.Size = new System.Drawing.Size(120, 23);
			this.btnListPackageCutsInfo.TabIndex = 45;
			this.btnListPackageCutsInfo.Text = "ListPackageCutsInfo";
			this.btnListPackageCutsInfo.Click += new System.EventHandler(this.btnListPackageCutsInfo_Click);
			// 
			// txtListPackageCutsInfoResultsQuantity
			// 
			this.txtListPackageCutsInfoResultsQuantity.Location = new System.Drawing.Point(88, 36);
			this.txtListPackageCutsInfoResultsQuantity.Name = "txtListPackageCutsInfoResultsQuantity";
			this.txtListPackageCutsInfoResultsQuantity.Size = new System.Drawing.Size(24, 20);
			this.txtListPackageCutsInfoResultsQuantity.TabIndex = 47;
			this.txtListPackageCutsInfoResultsQuantity.Text = "1";
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(16, 36);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(64, 16);
			this.label22.TabIndex = 46;
			this.label22.Text = "# of Results";
			// 
			// label23
			// 
			this.label23.Location = new System.Drawing.Point(16, 92);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(100, 16);
			this.label23.TabIndex = 48;
			this.label23.Text = "results in datagrid";
			// 
			// groupBoxListMediaCutsInfo
			// 
			this.groupBoxListMediaCutsInfo.Controls.Add(this.dgListMediaCutsInfoSearchCriteria);
			this.groupBoxListMediaCutsInfo.Controls.Add(this.label24);
			this.groupBoxListMediaCutsInfo.Controls.Add(this.btnListMediaCutsInfo);
			this.groupBoxListMediaCutsInfo.Controls.Add(this.txtListMediaCutsInfoResultsQuantity);
			this.groupBoxListMediaCutsInfo.Controls.Add(this.label25);
			this.groupBoxListMediaCutsInfo.Controls.Add(this.label26);
			this.groupBoxListMediaCutsInfo.Location = new System.Drawing.Point(344, 160);
			this.groupBoxListMediaCutsInfo.Name = "groupBoxListMediaCutsInfo";
			this.groupBoxListMediaCutsInfo.Size = new System.Drawing.Size(328, 120);
			this.groupBoxListMediaCutsInfo.TabIndex = 35;
			this.groupBoxListMediaCutsInfo.TabStop = false;
			this.groupBoxListMediaCutsInfo.Text = "List Media Cuts Info";
			// 
			// dgListMediaCutsInfoSearchCriteria
			// 
			this.dgListMediaCutsInfoSearchCriteria.CaptionVisible = false;
			this.dgListMediaCutsInfoSearchCriteria.DataMember = "";
			this.dgListMediaCutsInfoSearchCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dgListMediaCutsInfoSearchCriteria.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgListMediaCutsInfoSearchCriteria.Location = new System.Drawing.Point(140, 12);
			this.dgListMediaCutsInfoSearchCriteria.Name = "dgListMediaCutsInfoSearchCriteria";
			this.dgListMediaCutsInfoSearchCriteria.PreferredColumnWidth = 80;
			this.dgListMediaCutsInfoSearchCriteria.PreferredRowHeight = 15;
			this.dgListMediaCutsInfoSearchCriteria.RowHeaderWidth = 10;
			this.dgListMediaCutsInfoSearchCriteria.Size = new System.Drawing.Size(176, 96);
			this.dgListMediaCutsInfoSearchCriteria.TabIndex = 56;
			// 
			// label24
			// 
			this.label24.Location = new System.Drawing.Point(12, 20);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(88, 16);
			this.label24.TabIndex = 55;
			this.label24.Text = "Search Criterion ";
			this.label24.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// btnListMediaCutsInfo
			// 
			this.btnListMediaCutsInfo.Location = new System.Drawing.Point(12, 60);
			this.btnListMediaCutsInfo.Name = "btnListMediaCutsInfo";
			this.btnListMediaCutsInfo.Size = new System.Drawing.Size(120, 23);
			this.btnListMediaCutsInfo.TabIndex = 51;
			this.btnListMediaCutsInfo.Text = "ListMediaCutsInfo";
			this.btnListMediaCutsInfo.Click += new System.EventHandler(this.btnListMediaCutsInfo_Click);
			// 
			// txtListMediaCutsInfoResultsQuantity
			// 
			this.txtListMediaCutsInfoResultsQuantity.Location = new System.Drawing.Point(92, 36);
			this.txtListMediaCutsInfoResultsQuantity.Name = "txtListMediaCutsInfoResultsQuantity";
			this.txtListMediaCutsInfoResultsQuantity.Size = new System.Drawing.Size(24, 20);
			this.txtListMediaCutsInfoResultsQuantity.TabIndex = 53;
			this.txtListMediaCutsInfoResultsQuantity.Text = "1";
			// 
			// label25
			// 
			this.label25.Location = new System.Drawing.Point(20, 36);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(64, 16);
			this.label25.TabIndex = 52;
			this.label25.Text = "# of Results";
			// 
			// label26
			// 
			this.label26.Location = new System.Drawing.Point(20, 92);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(100, 16);
			this.label26.TabIndex = 54;
			this.label26.Text = "results in datagrid";
			// 
			// tabPageSearch5
			// 
			this.tabPageSearch5.Controls.Add(this.groupBoxListPackageMediaInfo);
			this.tabPageSearch5.Location = new System.Drawing.Point(4, 22);
			this.tabPageSearch5.Name = "tabPageSearch5";
			this.tabPageSearch5.Size = new System.Drawing.Size(680, 366);
			this.tabPageSearch5.TabIndex = 4;
			this.tabPageSearch5.Text = "ScheduAll Search 3";
			// 
			// groupBoxListPackageMediaInfo
			// 
			this.groupBoxListPackageMediaInfo.Controls.Add(this.dgListPackageMediaInfoSearchCriteria);
			this.groupBoxListPackageMediaInfo.Controls.Add(this.label27);
			this.groupBoxListPackageMediaInfo.Controls.Add(this.btnListPackageMediaInfo);
			this.groupBoxListPackageMediaInfo.Controls.Add(this.txtListPackageMediaInfoResultsQuantity);
			this.groupBoxListPackageMediaInfo.Controls.Add(this.label28);
			this.groupBoxListPackageMediaInfo.Controls.Add(this.label29);
			this.groupBoxListPackageMediaInfo.Location = new System.Drawing.Point(24, 16);
			this.groupBoxListPackageMediaInfo.Name = "groupBoxListPackageMediaInfo";
			this.groupBoxListPackageMediaInfo.Size = new System.Drawing.Size(320, 120);
			this.groupBoxListPackageMediaInfo.TabIndex = 36;
			this.groupBoxListPackageMediaInfo.TabStop = false;
			this.groupBoxListPackageMediaInfo.Text = "List Package Media Info";
			// 
			// dgListPackageMediaInfoSearchCriteria
			// 
			this.dgListPackageMediaInfoSearchCriteria.CaptionVisible = false;
			this.dgListPackageMediaInfoSearchCriteria.DataMember = "";
			this.dgListPackageMediaInfoSearchCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dgListPackageMediaInfoSearchCriteria.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgListPackageMediaInfoSearchCriteria.Location = new System.Drawing.Point(136, 16);
			this.dgListPackageMediaInfoSearchCriteria.Name = "dgListPackageMediaInfoSearchCriteria";
			this.dgListPackageMediaInfoSearchCriteria.PreferredColumnWidth = 80;
			this.dgListPackageMediaInfoSearchCriteria.PreferredRowHeight = 15;
			this.dgListPackageMediaInfoSearchCriteria.RowHeaderWidth = 10;
			this.dgListPackageMediaInfoSearchCriteria.Size = new System.Drawing.Size(176, 96);
			this.dgListPackageMediaInfoSearchCriteria.TabIndex = 56;
			// 
			// label27
			// 
			this.label27.Location = new System.Drawing.Point(8, 24);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(88, 16);
			this.label27.TabIndex = 55;
			this.label27.Text = "Search Criterion ";
			this.label27.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// btnListPackageMediaInfo
			// 
			this.btnListPackageMediaInfo.Location = new System.Drawing.Point(8, 64);
			this.btnListPackageMediaInfo.Name = "btnListPackageMediaInfo";
			this.btnListPackageMediaInfo.Size = new System.Drawing.Size(120, 23);
			this.btnListPackageMediaInfo.TabIndex = 51;
			this.btnListPackageMediaInfo.Text = "ListPackageMediaInfo";
			this.btnListPackageMediaInfo.Click += new System.EventHandler(this.btnListPackageMediaInfo_Click);
			// 
			// txtListPackageMediaInfoResultsQuantity
			// 
			this.txtListPackageMediaInfoResultsQuantity.Location = new System.Drawing.Point(88, 40);
			this.txtListPackageMediaInfoResultsQuantity.Name = "txtListPackageMediaInfoResultsQuantity";
			this.txtListPackageMediaInfoResultsQuantity.Size = new System.Drawing.Size(24, 20);
			this.txtListPackageMediaInfoResultsQuantity.TabIndex = 53;
			this.txtListPackageMediaInfoResultsQuantity.Text = "1";
			// 
			// label28
			// 
			this.label28.Location = new System.Drawing.Point(16, 40);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(64, 16);
			this.label28.TabIndex = 52;
			this.label28.Text = "# of Results";
			// 
			// label29
			// 
			this.label29.Location = new System.Drawing.Point(16, 96);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(100, 16);
			this.label29.TabIndex = 54;
			this.label29.Text = "results in datagrid";
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.groupBox2);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(680, 366);
			this.tabPage1.TabIndex = 5;
			this.tabPage1.Text = "GetIds";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.dgIds);
			this.groupBox2.Controls.Add(this.label30);
			this.groupBox2.Controls.Add(this.btnGetId);
			this.groupBox2.Controls.Add(this.txtHowManyIds);
			this.groupBox2.Controls.Add(this.label31);
			this.groupBox2.Controls.Add(this.label32);
			this.groupBox2.Location = new System.Drawing.Point(24, 16);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(320, 120);
			this.groupBox2.TabIndex = 37;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "GetIds";
			// 
			// dgIds
			// 
			this.dgIds.CaptionVisible = false;
			this.dgIds.DataMember = "";
			this.dgIds.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dgIds.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgIds.Location = new System.Drawing.Point(136, 16);
			this.dgIds.Name = "dgIds";
			this.dgIds.PreferredColumnWidth = 80;
			this.dgIds.PreferredRowHeight = 15;
			this.dgIds.RowHeaderWidth = 10;
			this.dgIds.Size = new System.Drawing.Size(176, 96);
			this.dgIds.TabIndex = 56;
			// 
			// label30
			// 
			this.label30.Location = new System.Drawing.Point(8, 24);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(88, 16);
			this.label30.TabIndex = 55;
			this.label30.Text = "Search Criterion ";
			this.label30.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// btnGetId
			// 
			this.btnGetId.Location = new System.Drawing.Point(8, 64);
			this.btnGetId.Name = "btnGetId";
			this.btnGetId.Size = new System.Drawing.Size(120, 23);
			this.btnGetId.TabIndex = 51;
			this.btnGetId.Text = "GetId";
			this.btnGetId.Click += new System.EventHandler(this.btnGetId_Click);
			// 
			// txtHowManyIds
			// 
			this.txtHowManyIds.Location = new System.Drawing.Point(88, 40);
			this.txtHowManyIds.Name = "txtHowManyIds";
			this.txtHowManyIds.Size = new System.Drawing.Size(24, 20);
			this.txtHowManyIds.TabIndex = 53;
			this.txtHowManyIds.Text = "1";
			// 
			// label31
			// 
			this.label31.Location = new System.Drawing.Point(16, 40);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(64, 16);
			this.label31.TabIndex = 52;
			this.label31.Text = "How Many?";
			// 
			// label32
			// 
			this.label32.Location = new System.Drawing.Point(16, 96);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(100, 16);
			this.label32.TabIndex = 54;
			this.label32.Text = "results in datagrid";
			// 
			// Form_rdmPBSSearch
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(784, 654);
			this.Controls.Add(this.dgOrionAPIs);
			this.Controls.Add(this.tabControlSearch);
			this.Name = "Form_rdmPBSSearch";
			this.Text = "Form_rdmPBSSearch";
			this.Controls.SetChildIndex(this.sltProxyEnvironment, 0);
			this.Controls.SetChildIndex(this.chkGlobalSaveResults, 0);
			this.Controls.SetChildIndex(this.btnLogin, 0);
			this.Controls.SetChildIndex(this.btnLogout, 0);
			this.Controls.SetChildIndex(this.btnClearLog, 0);
			this.Controls.SetChildIndex(this.tabControlSearch, 0);
			this.Controls.SetChildIndex(this.txtLog, 0);
			this.Controls.SetChildIndex(this.txtWebServiceURL, 0);
			this.Controls.SetChildIndex(this.dgOrionAPIs, 0);
			((System.ComponentModel.ISupportInitialize)(this.dgOrionAPIs)).EndInit();
			this.tabControlSearch.ResumeLayout(false);
			this.tabPageSearch.ResumeLayout(false);
			this.grpBoxSearch.ResumeLayout(false);
			this.groupBoxProgramSearch.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgProgramSearchCriteria)).EndInit();
			this.groupBoxDealSearch.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgDealSearchCriteria)).EndInit();
			this.groupBoxMasterDealSearch.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgMasterDealSearchCriteria)).EndInit();
			this.groupBoxMediaInventorySearch.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgMediaInventorySearchCriteria)).EndInit();
			this.tabPageSearch4.ResumeLayout(false);
			this.groupBoxValidateEpisodeSlate.ResumeLayout(false);
			this.groupBoxAdCopySearch.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgAdCopySearchCriteria)).EndInit();
			this.groupBoxTrafficItemSearch.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgTrafficItemSearchCriteria)).EndInit();
			this.tabPageSearch2.ResumeLayout(false);
			this.grpBoxDetailedAirDate.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.grpFeatureAirDate.ResumeLayout(false);
			this.grpMediaAirDate.ResumeLayout(false);
			this.tabPageSearch3.ResumeLayout(false);
			this.grpSearchPackageInfo.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgSearchPackageInfoSearchCriteria)).EndInit();
			this.groupBoxSearchMediaInfo.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgSearchMediaInfoSearchCriteria)).EndInit();
			this.groupBoxListPackageCutsInfo.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgListPackageCutsInfoSearchCriteria)).EndInit();
			this.groupBoxListMediaCutsInfo.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgListMediaCutsInfoSearchCriteria)).EndInit();
			this.tabPageSearch5.ResumeLayout(false);
			this.groupBoxListPackageMediaInfo.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgListPackageMediaInfoSearchCriteria)).EndInit();
			this.tabPage1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgIds)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void btnProgramSearch_Click(object sender, System.EventArgs e)
		{
			dgOrionAPIs.DataSource = null;

			if (!ValidateSession())
				return;

			DataTable oTable = (DataTable)dgProgramSearchCriteria.DataSource;
			
			if (oTable == null)
			{
				this.Log("Search Criteria Missing for Program Search", true);
				return;
			}

			ArrayList oArrSearchCriterion = new ArrayList();
			BVWebService.SearchCriterion oSearchCriterion;
			IEnumerator oEnum = oTable.Rows.GetEnumerator();
			System.Data.DataRow oRow;

			while (oEnum.MoveNext())
			{
				oRow = (System.Data.DataRow) oEnum.Current;
				switch(oRow.ItemArray[0].ToString())
				{
					case "program_title":
					case "episode_title":
					case "episode_nola":
						if (oRow.ItemArray[1].ToString() != string.Empty)
						{
							oSearchCriterion = new BVWebService.SearchCriterion();
							oSearchCriterion.SearchField = oRow.ItemArray[0].ToString();
							oSearchCriterion.SearchValue = TestWebServiceHelper.SEARCH_WILDCARD + oRow.ItemArray[1].ToString() + TestWebServiceHelper.SEARCH_WILDCARD;
							oArrSearchCriterion.Add(oSearchCriterion);
						}
						break;
				
					case "program_season":
						if (oRow.ItemArray[1].ToString() != string.Empty)
						{
							oSearchCriterion = new BVWebService.SearchCriterion();
							oSearchCriterion.SearchField = oRow.ItemArray[0].ToString();
							oSearchCriterion.SearchValue = oRow.ItemArray[1].ToString();
							oArrSearchCriterion.Add(oSearchCriterion);
						}
						break;
					default:
						break;
				}
			}

			if (oArrSearchCriterion.Count == 0)
			{
				this.Log("Enter a Search Criteria for Program Search", true);
				return;
			}

			if (txtProgramSearchMaxRows.Text == string.Empty)
			{
				this.Log("Enter a Max Rows Value for Program Search", true);
				return;
			}


			if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
			{
				BVWebService.BVWebService oBVWebService = new BVWebService.BVWebService();
				oBVWebService.Url = this.txtWebServiceURL.Text + @"/Service.asmx";

				TestWebService.BVWebService.SearchCriterion[] oArrCriteria = new TestWebService.BVWebService.SearchCriterion[oArrSearchCriterion.Count];
				int iCount=0;
				foreach(BVWebService.SearchCriterion oSC in oArrSearchCriterion)
				{	
					oArrCriteria[iCount] = oSC;
					iCount++;
				}

				this.Log("Start ProgramSearch Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
				DataSet oDataSetResult = oBVWebService.ProgramSearch(m_sBVSessionId, oArrCriteria,int.Parse(txtProgramSearchMaxRows.Text));
				dgOrionAPIs.DataSource = oDataSetResult;
				this.Log("End ProgramSearch Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );
			}
			else
			{
				this.Log("Please log in. Session Null", true);
			}
		}

		private void btnDealSearch_Click(object sender, System.EventArgs e)
		{
		
			dgOrionAPIs.DataSource = null;

			if (!ValidateSession())
				return;


			DataTable oTable = (DataTable)dgDealSearchCriteria.DataSource;
			
			if (oTable == null)
			{
				this.Log("Search Criteria Missing for Deal Search", true);
				return;
			}

			ArrayList oArrSearchCriterion = new ArrayList();
			BVWebService.SearchCriterion oSearchCriterion;
			IEnumerator oEnum = oTable.Rows.GetEnumerator();
			System.Data.DataRow oRow;

			while (oEnum.MoveNext())
			{
				oRow = (System.Data.DataRow) oEnum.Current;
				switch(oRow.ItemArray[0].ToString())
				{
					case "sub_deal_season":
						if (oRow.ItemArray[1].ToString() != string.Empty)
						{
							oSearchCriterion = new BVWebService.SearchCriterion();
							oSearchCriterion.SearchField = oRow.ItemArray[0].ToString();
							oSearchCriterion.SearchValue = oRow.ItemArray[1].ToString();
							oArrSearchCriterion.Add(oSearchCriterion);
						}
						break;
					
					case "sub_deal_description":
						if (oRow.ItemArray[1].ToString() != string.Empty)
						{
							oSearchCriterion = new BVWebService.SearchCriterion();
							oSearchCriterion.SearchField = oRow.ItemArray[0].ToString();
							oSearchCriterion.SearchValue = TestWebServiceHelper.SEARCH_WILDCARD + oRow.ItemArray[1].ToString() + TestWebServiceHelper.SEARCH_WILDCARD;
							oArrSearchCriterion.Add(oSearchCriterion);
						}
						break;
					default:
						break;
				}
			}

			if (oArrSearchCriterion.Count == 0)
			{
				this.Log("Enter a Search Criteria for Deal Search", true);
				return;
			}

			if (txtDealSearchMaxRows.Text == string.Empty)
			{
				this.Log("Enter a Max Rows Value for Deal Search", true);
				return;
			}


			if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
			{
				BVWebService.BVWebService oBVWebService = new BVWebService.BVWebService();
				oBVWebService.Url = this.txtWebServiceURL.Text + @"/Service.asmx";

				TestWebService.BVWebService.SearchCriterion[] oArrCriteria = new TestWebService.BVWebService.SearchCriterion[oArrSearchCriterion.Count];
				int iCount=0;
				foreach(BVWebService.SearchCriterion oSC in oArrSearchCriterion)
				{	
					oArrCriteria[iCount] = oSC;
					iCount++;
				}
				
				this.Log("Start DealSearch Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
				DataSet oDataSetResult = oBVWebService.DealSearch(m_sBVSessionId, oArrCriteria,int.Parse(txtDealSearchMaxRows.Text));
				dgOrionAPIs.DataSource = oDataSetResult;
				this.Log("Finish DealSearch Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );
			}
			else
			{
				this.Log("Please log in. Session Null", true);
			}
		}

		private void btnMasterDealSearch_Click(object sender, System.EventArgs e)
		{
			dgOrionAPIs.DataSource = null;

			if (!ValidateSession())
				return;


			DataTable oTable = (DataTable)dgMasterDealSearchCriteria.DataSource;
			
			if (oTable == null)
			{
				this.Log("Search Criteria Missing for Master Deal Search", true);
				return;
			}


			ArrayList oArrSearchCriterion = new ArrayList();
			BVWebService.SearchCriterion oSearchCriterion;
			IEnumerator oEnum = oTable.Rows.GetEnumerator();
			System.Data.DataRow oRow;

			while (oEnum.MoveNext())
			{
				oRow = (System.Data.DataRow) oEnum.Current;
				switch(oRow.ItemArray[0].ToString())
				{
					case "title":
						if (oRow.ItemArray[1].ToString() != string.Empty)
						{
							oSearchCriterion = new BVWebService.SearchCriterion();
							oSearchCriterion.SearchField = oRow.ItemArray[0].ToString();
							oSearchCriterion.SearchValue = oRow.ItemArray[1].ToString() + TestWebServiceHelper.SEARCH_WILDCARD;
							oArrSearchCriterion.Add(oSearchCriterion);
						}
						break;
					default:
						break;
				}
			}

			if (oArrSearchCriterion.Count == 0)
			{
				this.Log("Enter a Search Criteria Key for Master Deal Search", true);
				return;
			}


			if (txtMasterDealSearchMaxRows.Text == string.Empty)
			{
				this.Log("Enter a Max Rows Value for Master Deal Search", true);
				return;
			}


			if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
			{
				BVWebService.BVWebService oBVWebService = new BVWebService.BVWebService();
				oBVWebService.Url = this.txtWebServiceURL.Text + @"/Service.asmx";

				TestWebService.BVWebService.SearchCriterion[] oArrCriteria = new TestWebService.BVWebService.SearchCriterion[oArrSearchCriterion.Count];
				int iCount=0;
				foreach(BVWebService.SearchCriterion oSC in oArrSearchCriterion)
				{	
					oArrCriteria[iCount] = oSC;
					iCount++;
				}

				this.Log("Start MasterDealSearch Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
				DataSet oDataSetResult = oBVWebService.MasterDealSearch(m_sBVSessionId, oArrCriteria,int.Parse(txtMasterDealSearchMaxRows.Text));
				dgOrionAPIs.DataSource = oDataSetResult;
				this.Log("Finish MasterDealSearch Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );
			}
			else
			{
				this.Log("Please log in. Session Null", true);
			}
		}

		private void btnMediaInventorySearch_Click(object sender, System.EventArgs e)
		{
			dgOrionAPIs.DataSource = null;

			if (!ValidateSession())
				return;


			DataTable oTable = (DataTable)dgMediaInventorySearchCriteria.DataSource;
			
			if (oTable == null)
			{
				this.Log("Search Criteria Missing for MediaInventory Search", true);
				return;
			}


			ArrayList oArrSearchCriterion = new ArrayList();
			BVWebService.SearchCriterion oSearchCriterion;
			IEnumerator oEnum = oTable.Rows.GetEnumerator();
			System.Data.DataRow oRow;

			while (oEnum.MoveNext())
			{
				oRow = (System.Data.DataRow) oEnum.Current;
				switch(oRow.ItemArray[0].ToString())
				{
					case "program_id":
					case "deal_id":
					case "operating_unit":
					case "operating_group": //OG could be an empty string.
						if (oRow.ItemArray[1].ToString() != string.Empty)
						{
							oSearchCriterion = new BVWebService.SearchCriterion();
							oSearchCriterion.SearchField = oRow.ItemArray[0].ToString();
							oSearchCriterion.SearchValue = oRow.ItemArray[1].ToString();
							oArrSearchCriterion.Add(oSearchCriterion);
						}
						break;
					case "title":
						if (oRow.ItemArray[1].ToString() != string.Empty)
						{
							oSearchCriterion = new BVWebService.SearchCriterion();
							oSearchCriterion.SearchField = oRow.ItemArray[0].ToString();
							oSearchCriterion.SearchValue = TestWebServiceHelper.SEARCH_WILDCARD + oRow.ItemArray[1].ToString() + TestWebServiceHelper.SEARCH_WILDCARD;
							oArrSearchCriterion.Add(oSearchCriterion);
						}
						break;
					default:
						break;
				}
			}

			if (oArrSearchCriterion.Count == 0)
			{
				this.Log("Enter a Search Criteria Key for MediaInventory Search", true);
				return;
			}
			if (txtMediaInventorySearchMaxRows.Text == string.Empty)
			{
				this.Log("Enter a Max Rows Value for MediaInventory Search", true);
				return;
			}


			if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
			{
				BVWebService.BVWebService oBVWebService = new BVWebService.BVWebService();
				oBVWebService.Url = this.txtWebServiceURL.Text + @"/Service.asmx";

				TestWebService.BVWebService.SearchCriterion[] oArrCriteria = new TestWebService.BVWebService.SearchCriterion[oArrSearchCriterion.Count];
				int iCount=0;
				foreach(BVWebService.SearchCriterion oSC in oArrSearchCriterion)
				{	
					oArrCriteria[iCount] = oSC;
					iCount++;
				}

				this.Log("Start MediaInventorySearch Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
				DataSet oDataSetResult = oBVWebService.MediaInventorySearch(m_sBVSessionId, oArrCriteria,int.Parse(txtMediaInventorySearchMaxRows.Text));
				dgOrionAPIs.DataSource = oDataSetResult;
				this.Log("Finish MediaInventorySearch Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );
			}
			else
			{
				this.Log("Please log in. Session Null", true);
			}
		}

		private void btnTrafficItemSearch_Click(object sender, System.EventArgs e)
		{
			dgOrionAPIs.DataSource = null;

			if (!ValidateSession())
				return;


			DataTable oTable = (DataTable)dgTrafficItemSearchCriteria.DataSource;
			
			if (oTable == null)
			{
				this.Log("Search Criteria Missing for Traffic Item Search", true);
				return;
			}


			ArrayList oArrSearchCriterion = new ArrayList();
			BVWebService.SearchCriterion oSearchCriterion;
			IEnumerator oEnum = oTable.Rows.GetEnumerator();
			System.Data.DataRow oRow;

			while (oEnum.MoveNext())
			{
				oRow = (System.Data.DataRow) oEnum.Current;
				switch(oRow.ItemArray[0].ToString())
				{
					case "Title":
						if (oRow.ItemArray[1].ToString() != string.Empty)
						{
							oSearchCriterion = new BVWebService.SearchCriterion();
							oSearchCriterion.SearchField = oRow.ItemArray[0].ToString();
							oSearchCriterion.SearchValue = TestWebServiceHelper.SEARCH_WILDCARD +  oRow.ItemArray[1].ToString() + TestWebServiceHelper.SEARCH_WILDCARD;
							oArrSearchCriterion.Add(oSearchCriterion);
						}
						break;

					case "Duration":
						if (oRow.ItemArray[1].ToString() != string.Empty)
						{
							oSearchCriterion = new BVWebService.SearchCriterion();
							oSearchCriterion.SearchField = oRow.ItemArray[0].ToString();
							oSearchCriterion.SearchValue = oRow.ItemArray[1].ToString();
							oArrSearchCriterion.Add(oSearchCriterion);
						}
						break;

					case "Category":
						if (oRow.ItemArray[1].ToString() != string.Empty)
						{
							oSearchCriterion = new BVWebService.SearchCriterion();
							oSearchCriterion.SearchField = oRow.ItemArray[0].ToString();
							oSearchCriterion.SearchValue = oRow.ItemArray[1].ToString();
							oArrSearchCriterion.Add(oSearchCriterion);
						}
						break;
					case "Is_Approved":
						if (oRow.ItemArray[1].ToString() != string.Empty)
						{
							oSearchCriterion = new BVWebService.SearchCriterion();
							oSearchCriterion.SearchField = oRow.ItemArray[0].ToString();
							oSearchCriterion.SearchValue = oRow.ItemArray[1].ToString();
							oArrSearchCriterion.Add(oSearchCriterion);
						}
						break;
					case "EXCLUDEINUSE":
						if (oRow.ItemArray[1].ToString() != string.Empty)
						{
							oSearchCriterion = new BVWebService.SearchCriterion();
							oSearchCriterion.SearchField = oRow.ItemArray[0].ToString();
							oSearchCriterion.SearchValue = oRow.ItemArray[1].ToString();
							oArrSearchCriterion.Add(oSearchCriterion);
						}
						break;
					default:
						break;
				}
			}

			if (sltTrafficItemFormat.SelectedItem == null || sltTrafficItemFormat.SelectedItem.ToString()== string.Empty)
			{
//				this.Log("Enter a Format for Traffic Item Search", true);
//				return;
			}
			else
			{
				oSearchCriterion = new BVWebService.SearchCriterion();
				oSearchCriterion.SearchField = "Video_Format";
				oSearchCriterion.SearchValue = TestWebServiceHelper.GetSelectedItemValue(sltTrafficItemFormat).ToString();
				oArrSearchCriterion.Add(oSearchCriterion);
			}

			
			if (oArrSearchCriterion.Count == 0)
			{
				this.Log("Enter a Search Criteria Key for Traffic Item Search", true);
				return;
			}

			if (txtTrafficItemSearchMaxRows.Text == string.Empty)
			{
				this.Log("Enter a Max Rows Value for Traffic Item Search", true);
				return;
			}


			if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
			{
				BVWebService.BVWebService oBVWebService = new BVWebService.BVWebService();
				oBVWebService.Url = this.txtWebServiceURL.Text + @"/Service.asmx";

				TestWebService.BVWebService.SearchCriterion[] oArrCriteria = new TestWebService.BVWebService.SearchCriterion[oArrSearchCriterion.Count];
				int iCount=0;
				foreach(BVWebService.SearchCriterion oSC in oArrSearchCriterion)
				{	
					oArrCriteria[iCount] = oSC;
					iCount++;
				}

				this.Log("Start TrafficItemSearch Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
				DataSet oDataSetResult = oBVWebService.TrafficItemSearch(m_sBVSessionId, oArrCriteria,int.Parse(txtTrafficItemSearchMaxRows.Text));
				dgOrionAPIs.DataSource = oDataSetResult;

				if (base.chkGlobalSaveResults.Checked)
				{
					if (folderBrowserDialogGlobalSaveResults.ShowDialog() == DialogResult.OK)
					{
						if (base.folderBrowserDialogGlobalSaveResults.SelectedPath != null)
						{
							string sPath = base.folderBrowserDialogGlobalSaveResults.SelectedPath + System.IO.Path.DirectorySeparatorChar.ToString();
							sPath +=  "TrafficItemSearch" + "_" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".xml";
							this.Log("Saving Result File to:  " + sPath);
							oDataSetResult.WriteXml(sPath);
						}
						
					}
				}


				this.Log("Finish TrafficItemSearch Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );
			}
			else
			{
				this.Log("Please log in. Session Null", true);
			}
		}

		private void btnAdCopySearch_Click(object sender, System.EventArgs e)
		{

			dgOrionAPIs.DataSource = null;

			if (!ValidateSession())
				return;


			DataTable oTable = (DataTable)dgAdCopySearchCriteria.DataSource;
			
			if (oTable == null)
			{
				this.Log("Search Criteria Missing for Ad Copy Search", true);
				return;
			}

			ArrayList oArrSearchCriterion = new ArrayList();
			BVWebService.SearchCriterion oSearchCriterion;
			IEnumerator oEnum = oTable.Rows.GetEnumerator();
			System.Data.DataRow oRow;

			while (oEnum.MoveNext())
			{
				oRow = (System.Data.DataRow) oEnum.Current;
				switch(oRow.ItemArray[0].ToString())
				{
					case "Title":
						if (oRow.ItemArray[1].ToString() != string.Empty)
						{
							oSearchCriterion = new BVWebService.SearchCriterion();
							oSearchCriterion.SearchField = oRow.ItemArray[0].ToString();
							oSearchCriterion.SearchValue = TestWebServiceHelper.SEARCH_WILDCARD +  oRow.ItemArray[1].ToString() + TestWebServiceHelper.SEARCH_WILDCARD;
							oArrSearchCriterion.Add(oSearchCriterion);
						}
						break;

					case "Duration":
						if (oRow.ItemArray[1].ToString() != string.Empty)
						{
							oSearchCriterion = new BVWebService.SearchCriterion();
							oSearchCriterion.SearchField = oRow.ItemArray[0].ToString();
							oSearchCriterion.SearchValue = oRow.ItemArray[1].ToString();
							oArrSearchCriterion.Add(oSearchCriterion);
						}
						break;
					case "Underwriter_Id":
						if (oRow.ItemArray[1].ToString() != string.Empty)
						{
							oSearchCriterion = new BVWebService.SearchCriterion();
							oSearchCriterion.SearchField = oRow.ItemArray[0].ToString();
							oSearchCriterion.SearchValue = oRow.ItemArray[1].ToString();
							oArrSearchCriterion.Add(oSearchCriterion);
						}
						break;
					case "Is_Approved":
						if (oRow.ItemArray[1].ToString() != string.Empty)
						{
							oSearchCriterion = new BVWebService.SearchCriterion();
							oSearchCriterion.SearchField = oRow.ItemArray[0].ToString();
							oSearchCriterion.SearchValue = oRow.ItemArray[1].ToString();
							oArrSearchCriterion.Add(oSearchCriterion);
						}
						break;
					case "EXCLUDEINUSE":
						if (oRow.ItemArray[1].ToString() != string.Empty)
						{
							oSearchCriterion = new BVWebService.SearchCriterion();
							oSearchCriterion.SearchField = oRow.ItemArray[0].ToString();
							oSearchCriterion.SearchValue = oRow.ItemArray[1].ToString();
							oArrSearchCriterion.Add(oSearchCriterion);
						}
						break;
					default:
						break;
				}
			}

			if (sltAdCopyFormat.SelectedItem == null || sltAdCopyFormat.SelectedItem.ToString()== string.Empty)
			{
//				this.Log("Enter a Format for Ad Copy Search", true);
//				return;
			}
			else
			{
				oSearchCriterion = new BVWebService.SearchCriterion();
				oSearchCriterion.SearchField = "Video_Format";
				oSearchCriterion.SearchValue = TestWebServiceHelper.GetSelectedItemValue(sltAdCopyFormat).ToString();
				oArrSearchCriterion.Add(oSearchCriterion);
			}

			
			if (oArrSearchCriterion.Count == 0)
			{
				this.Log("Enter a Search Criteria Key for Ad Copy Search", true);
				return;
			}

			if (txtAdCopySearchMaxRows.Text == string.Empty)
			{
				this.Log("Enter a Max Rows Value for Ad Copy Search", true);
				return;
			}


			if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
			{
				BVWebService.BVWebService oBVWebService = new BVWebService.BVWebService();
				oBVWebService.Url = this.txtWebServiceURL.Text + @"/Service.asmx";

				TestWebService.BVWebService.SearchCriterion[] oArrCriteria = new TestWebService.BVWebService.SearchCriterion[oArrSearchCriterion.Count];
				int iCount=0;
				foreach(BVWebService.SearchCriterion oSC in oArrSearchCriterion)
				{	
					oArrCriteria[iCount] = oSC;
					iCount++;
				}

				this.Log("Start AdCopySearch Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
				DataSet oDataSetResult = oBVWebService.AdCopySearch(m_sBVSessionId, oArrCriteria,int.Parse(txtAdCopySearchMaxRows.Text));
				dgOrionAPIs.DataSource = oDataSetResult;

				if (base.chkGlobalSaveResults.Checked)
				{
					if (folderBrowserDialogGlobalSaveResults.ShowDialog() == DialogResult.OK)
					{
						if (base.folderBrowserDialogGlobalSaveResults.SelectedPath != null)
						{
							string sPath = base.folderBrowserDialogGlobalSaveResults.SelectedPath + System.IO.Path.DirectorySeparatorChar.ToString();
							sPath +=  "AdCopySearch" + "_" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".xml";
							this.Log("Saving Result File to:  " + sPath);
							oDataSetResult.WriteXml(sPath);
						}
						
					}
				}

				this.Log("Finish AdCopySearch Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );
			}
			else
			{
				this.Log("Please log in. Session Null", true);
			}



		}

	
		
		
		
		private void btnSearchMediaAirDate_Click(object sender, System.EventArgs e)
		{
			txtMediaAirDateResult.Text = "";

			if (txtHouseNumber.Text == string.Empty)
			{
				this.Log("Enter Search Media Air Date House Number",true);
				return;
			}

			if (txtTune.Text == string.Empty)
			{
				this.Log("Enter Search Media Air Date Tune",true);
				return;
			}
			if (m_sBVSessionId != "")
			{

				SAWebService.SAWebService s = new SAWebService.SAWebService();
				s.Url = this.txtWebServiceURL.Text.Replace("BVWebService","SAWebService") + @"/Service.asmx";

				this.Log("Start SearchMediaAirDate Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());

				string sResult = string.Empty;
				sResult = s.SearchMediaAirDate(m_sBVSessionId, txtHouseNumber.Text, Convert.ToInt32(txtTune.Text));
				

				if (sResult != null && sResult != string.Empty)
				{
					txtMediaAirDateResult.Text = sResult;
				}
				else
				{
					txtMediaAirDateResult.Text = "< null or empty string >";
				}

				this.Log("Finish SearchMediaAirDate Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());

				
			}
			else
			{
				this.Log("Please log in. Session Null", true);
			}
		}

		private void btnSearchFeatureAirDate_Click(object sender, System.EventArgs e)
		{

			txtFeatureAirDateResult.Text = string.Empty;

			if (txtFeatureMIId.Text == string.Empty)
			{
				this.Log("Enter Search Feature Air Date Feature Media Inventory Id",true);
				return;
			}

			if (txtTune2.Text == string.Empty)
			{
				this.Log("Enter Search Feature Air Date Tune",true);
				return;
			}


			SAWebService.SAWebService s = new SAWebService.SAWebService();
			s.Url = this.txtWebServiceURL.Text.Replace("BVWebService","SAWebService") + @"/Service.asmx";

			this.Log("Start SearchFeatureAirDate Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());

			string sResult = string.Empty;
			sResult = s.SearchFeatureAirDate(int.Parse(txtFeatureMIId.Text),int.Parse(txtTune2.Text));
			
			if (sResult != null &&  sResult != string.Empty)
			{
				txtFeatureAirDateResult.Text = sResult;
			}
			else
			{
				txtFeatureAirDateResult.Text = "< null or empty string >";
			}

			this.Log("Finish SearchFeatureAirDate Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());

		}

		private void btnPackageAirDate_Click(object sender, System.EventArgs e)
		{
			txtSearchPackageAirDateResult.Text = "";
			

			if (txtPackageNumber.Text == string.Empty)
			{
				this.Log("Enter Search Package Air Date Package Number",true);
				return;
			}

			if (txtTune3.Text == string.Empty)
			{
				this.Log("Enter Search Package Air Date Tune");
				return;
			}
			
			if (m_sBVSessionId != "")
			{

				SAWebService.SAWebService s = new SAWebService.SAWebService();
				s.Url = this.txtWebServiceURL.Text.Replace("BVWebService","SAWebService") + @"/Service.asmx";

				this.Log("Start SearchPackageAirDate Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());

				string sResult = string.Empty;
				sResult = s.SearchPackageAirDate(m_sBVSessionId, txtPackageNumber.Text, int.Parse(txtTune3.Text));
				
				if (sResult != null &&  sResult != string.Empty)
				{
					txtSearchPackageAirDateResult.Text = sResult;
				}
				else
				{
					txtSearchPackageAirDateResult.Text = "< null or empty string >";
				}
				
				this.Log("Finish SearchPackageAirDate Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
			}
			else
			{
				this.Log("Please log in. Session Null",true);
			}
		}

		private void btnDetailedAirDate_Click(object sender, System.EventArgs e)
		{
			dgOrionAPIs.DataSource = null;

			if (txtMediaInventoryId.Text == string.Empty)
			{
				this.Log("Enter Detailed Air Date MediaInventory Id",true);
				return;
			}


			if (m_sBVSessionId != "")
			{
				SAWebService.SAWebService s = new SAWebService.SAWebService();
				s.Url = this.txtWebServiceURL.Text.Replace("BVWebService","SAWebService") + @"/Service.asmx";

				this.Log("Start GetDetailedAirDate Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
				DataSet oDataSet = s.GetDetailedAirDate(m_sBVSessionId, Convert.ToInt32(txtMediaInventoryId.Text));
				dgOrionAPIs.DataSource = oDataSet;
				this.Log("Finish GetDetailedAirDate Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());

			}
			else
			{
				this.Log("Please log in. Session Null",true);
			}
		}

		private void btnValidateEpisodeSlate_Click(object sender, System.EventArgs e)
		{

			dgOrionAPIs.DataSource = null;


			if (txtValidateEpisodeSlateNolaRoot.Text == string.Empty)
			{
				this.Log("Enter Validate Episode Slate Nola Root",true);
				return;
			}
			
			if (txtValidateEpisodeSlateNumberOfPrograms.Text == string.Empty)
			{
				this.Log("Enter Validate Episode Slate # of Programs",true);
				return;
			}
			if (txtValidateEpisodeSlateStartingEpisodeNumber.Text == string.Empty)
			{
				this.Log("Enter Validate Episode Slate Starting Episode Number",true);
				return;
			}

			if (m_sBVSessionId != "")
			{

				BVWebService.BVWebService s = new BVWebService.BVWebService();
				s.Url = this.txtWebServiceURL.Text + @"/Service.asmx";

				this.Log("Start ValidateEpisodeSlate Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
				DataSet oDataSetResult = s.ValidateEpisodeSlate(m_sBVSessionId, txtValidateEpisodeSlateNolaRoot.Text, int.Parse(txtValidateEpisodeSlateStartingEpisodeNumber.Text), int.Parse(txtValidateEpisodeSlateNumberOfPrograms.Text));
				dgOrionAPIs.DataSource = oDataSetResult;
				this.Log("Finish ValidateEpisodeSlate Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
			}
			else
			{
				this.Log("Please log in. Session Null",true);
			
			}
		}

		private void btnSearchMediaAirDateHelp_Click(object sender, System.EventArgs e)
		{
			System.Text.StringBuilder oS = new System.Text.StringBuilder();

			oS.Append("Heres how to test this API:\n\n");
			oS.Append("1) Go to the scheduler in broadview (use 502) \n");
			oS.Append("2) right click on a program item and open the program \n");
			oS.Append("3) go to the packages tab on the program, and right click on a package and select 'related media inventories'\n");
			oS.Append("Note: you need a 'related media inventory' that actually has media iventories listed (so you may need to select a different program or package) \n");
			oS.Append("4) on the related media inventory tab, right click on a related media inventory and open the media inventory\n");
			oS.Append("5) for the house number attribute of this API use the media inventory # on the top left side of the screen\n\n\n");
			oS.Append("Note: the house number may be in a #####-# format (e.g. 1002279-1) \n");
			
			MessageBox.Show(this,oS.ToString());
		}

		private void btnSearchFeatureAirDateHelp_Click(object sender, System.EventArgs e)
		{
			
			System.Text.StringBuilder oS = new System.Text.StringBuilder();

			oS.Append("Heres how to test this API:\n\n");
			oS.Append("1) Go to the scheduler in broadview (use 502) \n");
			oS.Append("2) right click on a program item and open the program \n");
			oS.Append("3) go to the packages tab on the program, and right click on a package and select 'related media inventories'\n");
			oS.Append("Note: you need a 'related media inventory' that actually has media iventories listed (so you may need to select a different program or package) \n");
			oS.Append("4) on the related media inventory tab, right click in the related media inventory area and add a feature media inventory\n");
			oS.Append("Note: this likely requires an existing PI MI first. \n");
			oS.Append("5) for the Feature Media Inventory # - use the # in the footer of the Feature media Inventory form\n\n\n");
			
			MessageBox.Show(this,oS.ToString());

		}

		private void btnSearchPackageAirDateHelp_Click(object sender, System.EventArgs e)
		{
			
			System.Text.StringBuilder oS = new System.Text.StringBuilder();

			oS.Append("Heres how to test this API:\n\n");
			oS.Append("1) Enter a package number (note: they are not entirely numeric)\n");
			oS.Append("2) Enter a Tune of 1\n");
			
			MessageBox.Show(this,oS.ToString());

		
		}

		private void btnSearchPackageInfo_Click(object sender, System.EventArgs e)
		{
			
			dgOrionAPIs.DataSource = null;		


			DataTable oTable = (DataTable)dgSearchPackageInfoSearchCriteria.DataSource;
			
			if (oTable == null)
			{
				this.Log("Search Criteria Missing for Search Package Info Search", true);
				return;
			}


			ArrayList oArrSearchCriterion = new ArrayList();
			SAWebService.SearchCriterion oSearchCriterion;
			IEnumerator oEnum = oTable.Rows.GetEnumerator();
			System.Data.DataRow oRow;

			while (oEnum.MoveNext())
			{
				oRow = (System.Data.DataRow) oEnum.Current;
				switch(oRow.ItemArray[0].ToString())
				{
					case "PACKAGENAME":
						if (oRow.ItemArray[1].ToString() != string.Empty)
						{
							oSearchCriterion = new SAWebService.SearchCriterion();
							oSearchCriterion.SearchField = oRow.ItemArray[0].ToString();
							oSearchCriterion.SearchValue = TestWebServiceHelper.SEARCH_WILDCARD + oRow.ItemArray[1].ToString() + TestWebServiceHelper.SEARCH_WILDCARD;
							oArrSearchCriterion.Add(oSearchCriterion);
						}
						break;
					default:
						break;
				}
			}

			if (oArrSearchCriterion.Count == 0)
			{
				this.Log("Enter a Search Criteria for Search Package Info Search", true);
				return;
			}

			if (txtSearchPackageInfoResultsQuantity.Text == string.Empty )
			{
				this.Log("Search Package Info Number of Results is Required.", true);
				return;
			}
			
			if (m_sBVSessionId != "")
			{

				SAWebService.SAWebService s = new SAWebService.SAWebService();
				s.Url = this.txtWebServiceURL.Text.Replace("BVWebService","SAWebService") + @"/Service.asmx";

				this.Log("Start SearchPackageInfo Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());


				TestWebService.SAWebService.SearchCriterion[] oArrCriteria = new TestWebService.SAWebService.SearchCriterion[oArrSearchCriterion.Count];
				int iCount=0;
				foreach(SAWebService.SearchCriterion oSC in oArrSearchCriterion)
				{	
					oArrCriteria[iCount] = oSC;
					iCount++;
				}

				DataSet oDataSet = s.SearchPackageInfo(m_sBVSessionId,oArrCriteria, int.Parse(txtSearchPackageInfoResultsQuantity.Text));
				dgOrionAPIs.DataSource = oDataSet;

				this.Log("Finish SearchPackageInfo Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());


			}
			else
			{
				this.Log("Please log in. Session Null",true);
			}
		
		}

		private void btnSearchMediaInfo_Click(object sender, System.EventArgs e)
		{
		

			dgOrionAPIs.DataSource = null;		

			DataTable oTable = (DataTable)dgSearchMediaInfoSearchCriteria.DataSource;
			
			if (oTable == null)
			{
				this.Log("Search Criteria Missing for Search Media Info Search", true);
				return;
			}


			ArrayList oArrSearchCriterion = new ArrayList();
			SAWebService.SearchCriterion oSearchCriterion;
			IEnumerator oEnum = oTable.Rows.GetEnumerator();
			System.Data.DataRow oRow;

			while (oEnum.MoveNext())
			{
				oRow = (System.Data.DataRow) oEnum.Current;
				switch(oRow.ItemArray[0].ToString())
				{
					case "DESCRIPTION":
					case "NOLACODE":
						
						if (oRow.ItemArray[1].ToString() != string.Empty)
						{
							oSearchCriterion = new SAWebService.SearchCriterion();
							oSearchCriterion.SearchField = oRow.ItemArray[0].ToString();
							oSearchCriterion.SearchValue = TestWebServiceHelper.SEARCH_WILDCARD + oRow.ItemArray[1].ToString() + TestWebServiceHelper.SEARCH_WILDCARD;
							oArrSearchCriterion.Add(oSearchCriterion);
						}
						break;
					
					case "REVISIONHOUSENUMBER":
						
						if (oRow.ItemArray[1].ToString() != string.Empty)
						{
							oSearchCriterion = new SAWebService.SearchCriterion();
							oSearchCriterion.SearchField = oRow.ItemArray[0].ToString();
							oSearchCriterion.SearchValue = oRow.ItemArray[1].ToString();
							oArrSearchCriterion.Add(oSearchCriterion);
						}
						break;
					default:
						break;
				}
			}

			if (oArrSearchCriterion.Count == 0)
			{
				this.Log("Enter a Search Criteria for Search Media Info Search", true);
				return;
			}

			if (txtSearchMediaInfoResultsQuantity.Text == string.Empty )
			{
				this.Log("Search Media Info Number of Results is Required.", true);
				return;
			}
			
			if (m_sBVSessionId != "")
			{

				SAWebService.SAWebService s = new SAWebService.SAWebService();
				s.Url = this.txtWebServiceURL.Text.Replace("BVWebService","SAWebService") + @"/Service.asmx";

				this.Log("Start SearchMediaInfo Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());


				TestWebService.SAWebService.SearchCriterion[] oArrCriteria = new TestWebService.SAWebService.SearchCriterion[oArrSearchCriterion.Count];
				int iCount=0;
				foreach(SAWebService.SearchCriterion oSC in oArrSearchCriterion)
				{	
					oArrCriteria[iCount] = oSC;
					iCount++;
				}

				DataSet oDataSet = s.SearchMediaInfo(m_sBVSessionId, oArrCriteria, int.Parse(txtSearchMediaInfoResultsQuantity.Text));
				dgOrionAPIs.DataSource = oDataSet;

				this.Log("Finish SearchMediaInfo Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());


			}
			else
			{
				this.Log("Please log in. Session Null",true);
			}

		}

		private void btnListPackageCutsInfo_Click(object sender, System.EventArgs e)
		{
			dgOrionAPIs.DataSource = null;		

			DataTable oTable = (DataTable)dgListPackageCutsInfoSearchCriteria.DataSource;
			
			if (oTable == null)
			{
				this.Log("Search Criteria Missing for List Package Cuts Info Search", true);
				return;
			}


			ArrayList oArrSearchCriterion = new ArrayList();
			SAWebService.SearchCriterion oSearchCriterion;
			IEnumerator oEnum = oTable.Rows.GetEnumerator();
			System.Data.DataRow oRow;

			while (oEnum.MoveNext())
			{
				oRow = (System.Data.DataRow) oEnum.Current;
				switch(oRow.ItemArray[0].ToString())
				{
					
					case "REVISIONHOUSENUMBER":
						
						if (oRow.ItemArray[1].ToString() != string.Empty)
						{
							oSearchCriterion = new SAWebService.SearchCriterion();
							oSearchCriterion.SearchField = oRow.ItemArray[0].ToString();
							oSearchCriterion.SearchValue = oRow.ItemArray[1].ToString();
							oArrSearchCriterion.Add(oSearchCriterion);
						}
						break;
					default:
						break;
				}
			}

			if (oArrSearchCriterion.Count == 0)
			{
				this.Log("Enter a Search Criteria for List Package Cuts Info Search", true);
				return;
			}

			if (txtListPackageCutsInfoResultsQuantity.Text == string.Empty )
			{
				this.Log("List Package Cuts Info Number of Results is Required.", true);
				return;
			}
			
			if (m_sBVSessionId != "")
			{

				SAWebService.SAWebService s = new SAWebService.SAWebService();
				s.Url = this.txtWebServiceURL.Text.Replace("BVWebService","SAWebService") + @"/Service.asmx";

				this.Log("Start ListPackageCutsInfo Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());


				TestWebService.SAWebService.SearchCriterion[] oArrCriteria = new TestWebService.SAWebService.SearchCriterion[oArrSearchCriterion.Count];
				int iCount=0;
				foreach(SAWebService.SearchCriterion oSC in oArrSearchCriterion)
				{	
					oArrCriteria[iCount] = oSC;
					iCount++;
				}

				DataSet oDataSet = s.ListPackageCutsInfo(m_sBVSessionId, oArrCriteria, int.Parse(txtListPackageCutsInfoResultsQuantity.Text));
				dgOrionAPIs.DataSource = oDataSet;

				this.Log("Finish ListPackageCutsInfo Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());


			}
			else
			{
				this.Log("Please log in. Session Null",true);
			}
		}

		private void btnListMediaCutsInfo_Click(object sender, System.EventArgs e)
		{
			dgOrionAPIs.DataSource = null;		

			DataTable oTable = (DataTable)dgListMediaCutsInfoSearchCriteria.DataSource;
			
			if (oTable == null)
			{
				this.Log("Search Criteria Missing for List Media Cuts Info Search", true);
				return;
			}


			ArrayList oArrSearchCriterion = new ArrayList();
			SAWebService.SearchCriterion oSearchCriterion;
			IEnumerator oEnum = oTable.Rows.GetEnumerator();
			System.Data.DataRow oRow;

			while (oEnum.MoveNext())
			{
				oRow = (System.Data.DataRow) oEnum.Current;
				switch(oRow.ItemArray[0].ToString())
				{
					
					case "REVISIONHOUSENUMBER":
						
						if (oRow.ItemArray[1].ToString() != string.Empty)
						{
							oSearchCriterion = new SAWebService.SearchCriterion();
							oSearchCriterion.SearchField = oRow.ItemArray[0].ToString();
							oSearchCriterion.SearchValue = oRow.ItemArray[1].ToString();
							oArrSearchCriterion.Add(oSearchCriterion);
						}
						break;
					default:
						break;
				}
			}

			if (oArrSearchCriterion.Count == 0)
			{
				this.Log("Enter a Search Criteria for List Media Cuts Info Search", true);
				return;
			}

			if (txtListMediaCutsInfoResultsQuantity.Text == string.Empty )
			{
				this.Log("List Meida Cuts Info Number of Results is Required.", true);
				return;
			}
			
			if (m_sBVSessionId != "")
			{

				SAWebService.SAWebService s = new SAWebService.SAWebService();
				s.Url = this.txtWebServiceURL.Text.Replace("BVWebService","SAWebService") + @"/Service.asmx";

				this.Log("Start ListMediaCutsInfo Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());


				TestWebService.SAWebService.SearchCriterion[] oArrCriteria = new TestWebService.SAWebService.SearchCriterion[oArrSearchCriterion.Count];
				int iCount=0;
				foreach(SAWebService.SearchCriterion oSC in oArrSearchCriterion)
				{	
					oArrCriteria[iCount] = oSC;
					iCount++;
				}

				DataSet oDataSet = s.ListMediaCutsInfo(m_sBVSessionId, oArrCriteria, int.Parse(txtListMediaCutsInfoResultsQuantity.Text));
				dgOrionAPIs.DataSource = oDataSet;

				this.Log("Finish ListMediaCutsInfo Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());


			}
			else
			{
				this.Log("Please log in. Session Null",true);
			}


		}

		private void btnListPackageMediaInfo_Click(object sender, System.EventArgs e)
		{
			dgOrionAPIs.DataSource = null;		

			DataTable oTable = (DataTable)dgListPackageMediaInfoSearchCriteria.DataSource;
			
			if (oTable == null)
			{
				this.Log("Search Criteria Missing for List Package Media Info Search", true);
				return;
			}


			ArrayList oArrSearchCriterion = new ArrayList();
			SAWebService.SearchCriterion oSearchCriterion;
			IEnumerator oEnum = oTable.Rows.GetEnumerator();
			System.Data.DataRow oRow;

			while (oEnum.MoveNext())
			{
				oRow = (System.Data.DataRow) oEnum.Current;
				switch(oRow.ItemArray[0].ToString())
				{
					
					case "REVISIONHOUSENUMBER":
						
						if (oRow.ItemArray[1].ToString() != string.Empty)
						{
							oSearchCriterion = new SAWebService.SearchCriterion();
							oSearchCriterion.SearchField = oRow.ItemArray[0].ToString();
							oSearchCriterion.SearchValue = oRow.ItemArray[1].ToString();
							oArrSearchCriterion.Add(oSearchCriterion);
						}
						break;
					default:
						break;
				}
			}

			if (oArrSearchCriterion.Count == 0)
			{
				this.Log("Enter a Search Criteria for List Package Media Info Search", true);
				return;
			}

			if (txtListPackageMediaInfoResultsQuantity.Text == string.Empty )
			{
				this.Log("List Package Media Info Number of Results is Required.", true);
				return;
			}
			
			if (m_sBVSessionId != "")
			{

				SAWebService.SAWebService s = new SAWebService.SAWebService();
				s.Url = this.txtWebServiceURL.Text.Replace("BVWebService","SAWebService") + @"/Service.asmx";

				this.Log("Start ListPackageMediaInfo Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());


				TestWebService.SAWebService.SearchCriterion[] oArrCriteria = new TestWebService.SAWebService.SearchCriterion[oArrSearchCriterion.Count];
				int iCount=0;
				foreach(SAWebService.SearchCriterion oSC in oArrSearchCriterion)
				{	
					oArrCriteria[iCount] = oSC;
					iCount++;
				}

				DataSet oDataSet = s.ListPackageMediaInfo(m_sBVSessionId, oArrCriteria, int.Parse(txtListPackageMediaInfoResultsQuantity.Text));
				dgOrionAPIs.DataSource = oDataSet;

				this.Log("Finish ListPackageMediaInfo Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());


			}
			else
			{
				this.Log("Please log in. Session Null",true);
			}
		}

		private void btnGetId_Click(object sender, System.EventArgs e)
		{
			if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
			{
				BVWebService.BVWebService oBVWebService = new BVWebService.BVWebService();
				oBVWebService.Url = this.txtWebServiceURL.Text + @"/Service.asmx";


				int iHowMany = int.Parse(txtHowManyIds.Text);

				this.Log("Start GetIds Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
				int[] oArrResults = oBVWebService.GetIDs(iHowMany);
				this.Log("End GetIds Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );




				DataTable oTable = new DataTable();
				oTable.Columns.Add("id", typeof(int) );
				//oTable.Rows.Add();
				
				System.Data.DataRow oRow;
				
				for (int i=0; i < oArrResults.Length; i++)
				{
					oRow = oTable.NewRow();
					oRow["id"]= oArrResults[i];
					oTable.Rows.Add(oRow);
				}

				
				dgIds.DataSource = oTable;
				
				
			}
			else
			{
				this.Log("Please log in. Session Null", true);
			}
		}






	}
}
