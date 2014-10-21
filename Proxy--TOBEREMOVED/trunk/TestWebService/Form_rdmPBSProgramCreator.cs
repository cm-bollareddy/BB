using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace TestWebService
{
	/// <summary>
	/// Summary description for Form_rdmPBSProgramCreator.
	/// </summary>
	public class Form_rdmPBSProgramCreator : Form_Base
	{
		private System.Windows.Forms.GroupBox grpBoxProgramDetails;
		private System.Windows.Forms.Label lblSeason;
		private System.Windows.Forms.TextBox txtSeason;
		private System.Windows.Forms.Label lblMasterDealId;
		private System.Windows.Forms.TextBox txtMasterDealId;
		private System.Windows.Forms.Label lblMasterDealName;
		private System.Windows.Forms.TextBox txtMasterDealName;
		private System.Windows.Forms.TextBox txtDealDescription;
		private System.Windows.Forms.Label lblDealDescription;
		private System.Windows.Forms.TextBox txtDealSynopsis;
		private System.Windows.Forms.Label lblDealSynopsis;
		private System.Windows.Forms.Label lblPBSProgramType;
		private System.Windows.Forms.TextBox txtDuration;
		private System.Windows.Forms.Label lblDuration;
		private System.Windows.Forms.Label lblNolaRoot;
		private System.Windows.Forms.TextBox txtNolaRoot;
		private System.Windows.Forms.TextBox txtFirstEpisodeNumber;
		private System.Windows.Forms.Label lblFirstEpisodeNumber;
		private System.Windows.Forms.TextBox txtIncrement;
		private System.Windows.Forms.Label Increment;
		private System.Windows.Forms.Label lblDistributor;
		private System.Windows.Forms.Label lblGenre;
		private System.Windows.Forms.CheckBox chkLive;
		private System.Windows.Forms.CheckBox chkRecord;
		private System.Windows.Forms.Label lblRating;
		private System.Windows.Forms.Label lblDisclaimer;
		private System.Windows.Forms.Label lblPictureLockDate;
		private System.Windows.Forms.DateTimePicker dtPictureLockDate;
		private System.Windows.Forms.Label lblVCHIP;
		private System.Windows.Forms.TextBox txtAssetEpisodeTitle;
		private System.Windows.Forms.Label lblAssetEpisodeTitle;
		private System.Windows.Forms.TextBox txtAssetTitleListing;
		private System.Windows.Forms.Label lblAssetTitleListing;
		private System.Windows.Forms.CheckBox chkIsFinalTitle;
		private System.Windows.Forms.Label lblOperatingUnit;
		private System.Windows.Forms.TextBox txtOpUnit;
		private System.Windows.Forms.TextBox txtOpGroup;
		private System.Windows.Forms.Label lblOpGroup;
		private System.Windows.Forms.TextBox txtNumberOfPackages;
		private System.Windows.Forms.Label lblNumberOfPackages;
		private System.Windows.Forms.Label lblUplink;
		private System.Windows.Forms.ComboBox sltGenre;
		private System.Windows.Forms.ComboBox sltVCHIP;
		private System.Windows.Forms.ComboBox sltDistributor;
		private System.Windows.Forms.ComboBox sltUplink;
		private System.Windows.Forms.ComboBox sltRating;
		private System.Windows.Forms.ComboBox sltDisclaimer;
		private System.Windows.Forms.CheckBox chkNewMasterDeal;
		private System.Windows.Forms.ComboBox sltPBSProgramType;
		private System.Windows.Forms.Button btnCreateProgram;
		private System.Windows.Forms.TextBox txtNumberOfEpisodes;
		private System.Windows.Forms.Label lblNumberOfEpisodes;
		private System.Windows.Forms.CheckBox chkIsEIQualified;
		private System.Windows.Forms.CheckBox chkEIEmbedded;
		private System.Windows.Forms.CheckBox chkIsVCHIPEmbedded;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtPackageLength;
		private System.Windows.Forms.Label lblPackageType;
		private System.Windows.Forms.ComboBox sltPackageType;
		private System.Windows.Forms.CheckBox chkSDRights;
		private System.Windows.Forms.CheckBox chkHDRights;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form_rdmPBSProgramCreator()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();


			txtDealDescription.Text		= System.DateTime.Now.ToString("yyyy.MM.dd HH:mm");
			txtDealSynopsis.Text		= System.DateTime.Now.ToString("yyyy.MM.dd HH:mm");
			txtAssetEpisodeTitle.Text	= System.DateTime.Now.ToString("yyyy.MM.dd HH:mm");
			txtAssetTitleListing.Text	= System.DateTime.Now.ToString("yyyy.MM.dd HH:mm");

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
			this.grpBoxProgramDetails = new System.Windows.Forms.GroupBox();
			this.btnCreateProgram = new System.Windows.Forms.Button();
			this.sltGenre = new System.Windows.Forms.ComboBox();
			this.dtPictureLockDate = new System.Windows.Forms.DateTimePicker();
			this.lblSeason = new System.Windows.Forms.Label();
			this.txtSeason = new System.Windows.Forms.TextBox();
			this.lblMasterDealId = new System.Windows.Forms.Label();
			this.txtMasterDealId = new System.Windows.Forms.TextBox();
			this.lblMasterDealName = new System.Windows.Forms.Label();
			this.txtMasterDealName = new System.Windows.Forms.TextBox();
			this.txtDealDescription = new System.Windows.Forms.TextBox();
			this.lblDealDescription = new System.Windows.Forms.Label();
			this.txtDealSynopsis = new System.Windows.Forms.TextBox();
			this.lblDealSynopsis = new System.Windows.Forms.Label();
			this.lblPBSProgramType = new System.Windows.Forms.Label();
			this.txtDuration = new System.Windows.Forms.TextBox();
			this.lblDuration = new System.Windows.Forms.Label();
			this.lblNolaRoot = new System.Windows.Forms.Label();
			this.txtNolaRoot = new System.Windows.Forms.TextBox();
			this.txtFirstEpisodeNumber = new System.Windows.Forms.TextBox();
			this.lblFirstEpisodeNumber = new System.Windows.Forms.Label();
			this.txtIncrement = new System.Windows.Forms.TextBox();
			this.Increment = new System.Windows.Forms.Label();
			this.lblDistributor = new System.Windows.Forms.Label();
			this.lblGenre = new System.Windows.Forms.Label();
			this.chkLive = new System.Windows.Forms.CheckBox();
			this.chkRecord = new System.Windows.Forms.CheckBox();
			this.lblRating = new System.Windows.Forms.Label();
			this.lblDisclaimer = new System.Windows.Forms.Label();
			this.lblPictureLockDate = new System.Windows.Forms.Label();
			this.lblVCHIP = new System.Windows.Forms.Label();
			this.txtAssetEpisodeTitle = new System.Windows.Forms.TextBox();
			this.lblAssetEpisodeTitle = new System.Windows.Forms.Label();
			this.txtAssetTitleListing = new System.Windows.Forms.TextBox();
			this.lblAssetTitleListing = new System.Windows.Forms.Label();
			this.chkIsFinalTitle = new System.Windows.Forms.CheckBox();
			this.txtOpUnit = new System.Windows.Forms.TextBox();
			this.lblOperatingUnit = new System.Windows.Forms.Label();
			this.txtOpGroup = new System.Windows.Forms.TextBox();
			this.lblOpGroup = new System.Windows.Forms.Label();
			this.txtNumberOfPackages = new System.Windows.Forms.TextBox();
			this.lblNumberOfPackages = new System.Windows.Forms.Label();
			this.lblUplink = new System.Windows.Forms.Label();
			this.sltVCHIP = new System.Windows.Forms.ComboBox();
			this.sltDistributor = new System.Windows.Forms.ComboBox();
			this.sltUplink = new System.Windows.Forms.ComboBox();
			this.sltRating = new System.Windows.Forms.ComboBox();
			this.sltDisclaimer = new System.Windows.Forms.ComboBox();
			this.chkNewMasterDeal = new System.Windows.Forms.CheckBox();
			this.sltPBSProgramType = new System.Windows.Forms.ComboBox();
			this.txtNumberOfEpisodes = new System.Windows.Forms.TextBox();
			this.lblNumberOfEpisodes = new System.Windows.Forms.Label();
			this.chkIsEIQualified = new System.Windows.Forms.CheckBox();
			this.chkEIEmbedded = new System.Windows.Forms.CheckBox();
			this.chkIsVCHIPEmbedded = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtPackageLength = new System.Windows.Forms.TextBox();
			this.lblPackageType = new System.Windows.Forms.Label();
			this.sltPackageType = new System.Windows.Forms.ComboBox();
			this.chkSDRights = new System.Windows.Forms.CheckBox();
			this.chkHDRights = new System.Windows.Forms.CheckBox();
			this.grpBoxProgramDetails.SuspendLayout();
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
			// 
			// txtLog
			// 
			this.txtLog.Location = new System.Drawing.Point(0, 406);
			this.txtLog.Name = "txtLog";
			this.txtLog.Size = new System.Drawing.Size(776, 112);
			// 
			// grpBoxProgramDetails
			// 
			this.grpBoxProgramDetails.Controls.Add(this.btnCreateProgram);
			this.grpBoxProgramDetails.Controls.Add(this.sltGenre);
			this.grpBoxProgramDetails.Controls.Add(this.dtPictureLockDate);
			this.grpBoxProgramDetails.Controls.Add(this.lblSeason);
			this.grpBoxProgramDetails.Controls.Add(this.txtSeason);
			this.grpBoxProgramDetails.Controls.Add(this.lblMasterDealId);
			this.grpBoxProgramDetails.Controls.Add(this.txtMasterDealId);
			this.grpBoxProgramDetails.Controls.Add(this.lblMasterDealName);
			this.grpBoxProgramDetails.Controls.Add(this.txtMasterDealName);
			this.grpBoxProgramDetails.Controls.Add(this.txtDealDescription);
			this.grpBoxProgramDetails.Controls.Add(this.lblDealDescription);
			this.grpBoxProgramDetails.Controls.Add(this.txtDealSynopsis);
			this.grpBoxProgramDetails.Controls.Add(this.lblDealSynopsis);
			this.grpBoxProgramDetails.Controls.Add(this.lblPBSProgramType);
			this.grpBoxProgramDetails.Controls.Add(this.txtDuration);
			this.grpBoxProgramDetails.Controls.Add(this.lblDuration);
			this.grpBoxProgramDetails.Controls.Add(this.lblNolaRoot);
			this.grpBoxProgramDetails.Controls.Add(this.txtNolaRoot);
			this.grpBoxProgramDetails.Controls.Add(this.txtFirstEpisodeNumber);
			this.grpBoxProgramDetails.Controls.Add(this.lblFirstEpisodeNumber);
			this.grpBoxProgramDetails.Controls.Add(this.txtIncrement);
			this.grpBoxProgramDetails.Controls.Add(this.Increment);
			this.grpBoxProgramDetails.Controls.Add(this.lblDistributor);
			this.grpBoxProgramDetails.Controls.Add(this.lblGenre);
			this.grpBoxProgramDetails.Controls.Add(this.chkLive);
			this.grpBoxProgramDetails.Controls.Add(this.chkRecord);
			this.grpBoxProgramDetails.Controls.Add(this.lblRating);
			this.grpBoxProgramDetails.Controls.Add(this.lblDisclaimer);
			this.grpBoxProgramDetails.Controls.Add(this.lblPictureLockDate);
			this.grpBoxProgramDetails.Controls.Add(this.lblVCHIP);
			this.grpBoxProgramDetails.Controls.Add(this.txtAssetEpisodeTitle);
			this.grpBoxProgramDetails.Controls.Add(this.lblAssetEpisodeTitle);
			this.grpBoxProgramDetails.Controls.Add(this.txtAssetTitleListing);
			this.grpBoxProgramDetails.Controls.Add(this.lblAssetTitleListing);
			this.grpBoxProgramDetails.Controls.Add(this.chkIsFinalTitle);
			this.grpBoxProgramDetails.Controls.Add(this.txtOpUnit);
			this.grpBoxProgramDetails.Controls.Add(this.lblOperatingUnit);
			this.grpBoxProgramDetails.Controls.Add(this.txtOpGroup);
			this.grpBoxProgramDetails.Controls.Add(this.lblOpGroup);
			this.grpBoxProgramDetails.Controls.Add(this.txtNumberOfPackages);
			this.grpBoxProgramDetails.Controls.Add(this.lblNumberOfPackages);
			this.grpBoxProgramDetails.Controls.Add(this.lblUplink);
			this.grpBoxProgramDetails.Controls.Add(this.sltVCHIP);
			this.grpBoxProgramDetails.Controls.Add(this.sltDistributor);
			this.grpBoxProgramDetails.Controls.Add(this.sltUplink);
			this.grpBoxProgramDetails.Controls.Add(this.sltRating);
			this.grpBoxProgramDetails.Controls.Add(this.sltDisclaimer);
			this.grpBoxProgramDetails.Controls.Add(this.chkNewMasterDeal);
			this.grpBoxProgramDetails.Controls.Add(this.sltPBSProgramType);
			this.grpBoxProgramDetails.Controls.Add(this.txtNumberOfEpisodes);
			this.grpBoxProgramDetails.Controls.Add(this.lblNumberOfEpisodes);
			this.grpBoxProgramDetails.Controls.Add(this.chkIsEIQualified);
			this.grpBoxProgramDetails.Controls.Add(this.chkEIEmbedded);
			this.grpBoxProgramDetails.Controls.Add(this.chkIsVCHIPEmbedded);
			this.grpBoxProgramDetails.Controls.Add(this.label1);
			this.grpBoxProgramDetails.Controls.Add(this.txtPackageLength);
			this.grpBoxProgramDetails.Controls.Add(this.lblPackageType);
			this.grpBoxProgramDetails.Controls.Add(this.sltPackageType);
			this.grpBoxProgramDetails.Controls.Add(this.chkSDRights);
			this.grpBoxProgramDetails.Controls.Add(this.chkHDRights);
			this.grpBoxProgramDetails.Location = new System.Drawing.Point(16, 32);
			this.grpBoxProgramDetails.Name = "grpBoxProgramDetails";
			this.grpBoxProgramDetails.Size = new System.Drawing.Size(672, 368);
			this.grpBoxProgramDetails.TabIndex = 21;
			this.grpBoxProgramDetails.TabStop = false;
			this.grpBoxProgramDetails.Text = "ProgramDetails";
			// 
			// btnCreateProgram
			// 
			this.btnCreateProgram.Location = new System.Drawing.Point(440, 16);
			this.btnCreateProgram.Name = "btnCreateProgram";
			this.btnCreateProgram.Size = new System.Drawing.Size(208, 23);
			this.btnCreateProgram.TabIndex = 43;
			this.btnCreateProgram.Text = "CreateProgram";
			this.btnCreateProgram.Click += new System.EventHandler(this.btnCreateProgram_Click);
			// 
			// sltGenre
			// 
			this.sltGenre.Items.AddRange(new object[] {
														  "CH - Children\'s|3261513",
														  "CU - Cultural|3261514",
														  "ED - Educational|3261515",
														  "H2 - How-To|3261516",
														  "HI - History|3261517",
														  "OU - Outreach|3261518",
														  "PA - Public Affairs|3261519",
														  "SC - Science/Nature|3261520",
														  "SH - Self-Help|3261521",
														  "SP - Sports|3261522"});
			this.sltGenre.Location = new System.Drawing.Point(312, 136);
			this.sltGenre.Name = "sltGenre";
			this.sltGenre.Size = new System.Drawing.Size(168, 21);
			this.sltGenre.TabIndex = 42;
			// 
			// dtPictureLockDate
			// 
			this.dtPictureLockDate.CustomFormat = "MM/dd/yyyy";
			this.dtPictureLockDate.Location = new System.Drawing.Point(312, 280);
			this.dtPictureLockDate.Name = "dtPictureLockDate";
			this.dtPictureLockDate.Size = new System.Drawing.Size(168, 20);
			this.dtPictureLockDate.TabIndex = 41;
			// 
			// lblSeason
			// 
			this.lblSeason.Location = new System.Drawing.Point(8, 192);
			this.lblSeason.Name = "lblSeason";
			this.lblSeason.Size = new System.Drawing.Size(80, 16);
			this.lblSeason.TabIndex = 37;
			this.lblSeason.Text = "Season";
			// 
			// txtSeason
			// 
			this.txtSeason.Location = new System.Drawing.Point(104, 192);
			this.txtSeason.Name = "txtSeason";
			this.txtSeason.Size = new System.Drawing.Size(96, 20);
			this.txtSeason.TabIndex = 36;
			this.txtSeason.Text = "";
			// 
			// lblMasterDealId
			// 
			this.lblMasterDealId.Location = new System.Drawing.Point(152, 20);
			this.lblMasterDealId.Name = "lblMasterDealId";
			this.lblMasterDealId.Size = new System.Drawing.Size(40, 16);
			this.lblMasterDealId.TabIndex = 2;
			this.lblMasterDealId.Text = "MD Id";
			// 
			// txtMasterDealId
			// 
			this.txtMasterDealId.Location = new System.Drawing.Point(192, 16);
			this.txtMasterDealId.Name = "txtMasterDealId";
			this.txtMasterDealId.Size = new System.Drawing.Size(56, 20);
			this.txtMasterDealId.TabIndex = 1;
			this.txtMasterDealId.Text = "";
			// 
			// lblMasterDealName
			// 
			this.lblMasterDealName.Location = new System.Drawing.Point(256, 20);
			this.lblMasterDealName.Name = "lblMasterDealName";
			this.lblMasterDealName.Size = new System.Drawing.Size(56, 16);
			this.lblMasterDealName.TabIndex = 2;
			this.lblMasterDealName.Text = "MD Name";
			// 
			// txtMasterDealName
			// 
			this.txtMasterDealName.Enabled = false;
			this.txtMasterDealName.Location = new System.Drawing.Point(312, 16);
			this.txtMasterDealName.Name = "txtMasterDealName";
			this.txtMasterDealName.Size = new System.Drawing.Size(104, 20);
			this.txtMasterDealName.TabIndex = 1;
			this.txtMasterDealName.Text = "";
			// 
			// txtDealDescription
			// 
			this.txtDealDescription.Location = new System.Drawing.Point(104, 72);
			this.txtDealDescription.Name = "txtDealDescription";
			this.txtDealDescription.Size = new System.Drawing.Size(96, 20);
			this.txtDealDescription.TabIndex = 36;
			this.txtDealDescription.Text = "";
			// 
			// lblDealDescription
			// 
			this.lblDealDescription.Location = new System.Drawing.Point(8, 72);
			this.lblDealDescription.Name = "lblDealDescription";
			this.lblDealDescription.Size = new System.Drawing.Size(88, 16);
			this.lblDealDescription.TabIndex = 37;
			this.lblDealDescription.Text = "Program Title";
			// 
			// txtDealSynopsis
			// 
			this.txtDealSynopsis.Location = new System.Drawing.Point(104, 96);
			this.txtDealSynopsis.Name = "txtDealSynopsis";
			this.txtDealSynopsis.Size = new System.Drawing.Size(96, 20);
			this.txtDealSynopsis.TabIndex = 36;
			this.txtDealSynopsis.Text = "";
			// 
			// lblDealSynopsis
			// 
			this.lblDealSynopsis.Location = new System.Drawing.Point(8, 96);
			this.lblDealSynopsis.Name = "lblDealSynopsis";
			this.lblDealSynopsis.Size = new System.Drawing.Size(88, 16);
			this.lblDealSynopsis.TabIndex = 37;
			this.lblDealSynopsis.Text = "Deal Synopsis";
			// 
			// lblPBSProgramType
			// 
			this.lblPBSProgramType.Location = new System.Drawing.Point(0, 48);
			this.lblPBSProgramType.Name = "lblPBSProgramType";
			this.lblPBSProgramType.Size = new System.Drawing.Size(104, 16);
			this.lblPBSProgramType.TabIndex = 37;
			this.lblPBSProgramType.Text = "PBS Program Type";
			// 
			// txtDuration
			// 
			this.txtDuration.Location = new System.Drawing.Point(104, 312);
			this.txtDuration.Name = "txtDuration";
			this.txtDuration.Size = new System.Drawing.Size(96, 20);
			this.txtDuration.TabIndex = 36;
			this.txtDuration.Text = "";
			// 
			// lblDuration
			// 
			this.lblDuration.Location = new System.Drawing.Point(8, 312);
			this.lblDuration.Name = "lblDuration";
			this.lblDuration.Size = new System.Drawing.Size(88, 16);
			this.lblDuration.TabIndex = 37;
			this.lblDuration.Text = "Duration";
			// 
			// lblNolaRoot
			// 
			this.lblNolaRoot.Location = new System.Drawing.Point(8, 216);
			this.lblNolaRoot.Name = "lblNolaRoot";
			this.lblNolaRoot.Size = new System.Drawing.Size(64, 16);
			this.lblNolaRoot.TabIndex = 37;
			this.lblNolaRoot.Text = "NOLA Root";
			// 
			// txtNolaRoot
			// 
			this.txtNolaRoot.Location = new System.Drawing.Point(104, 216);
			this.txtNolaRoot.Name = "txtNolaRoot";
			this.txtNolaRoot.Size = new System.Drawing.Size(96, 20);
			this.txtNolaRoot.TabIndex = 36;
			this.txtNolaRoot.Text = "";
			// 
			// txtFirstEpisodeNumber
			// 
			this.txtFirstEpisodeNumber.Location = new System.Drawing.Point(104, 240);
			this.txtFirstEpisodeNumber.Name = "txtFirstEpisodeNumber";
			this.txtFirstEpisodeNumber.Size = new System.Drawing.Size(96, 20);
			this.txtFirstEpisodeNumber.TabIndex = 36;
			this.txtFirstEpisodeNumber.Text = "";
			// 
			// lblFirstEpisodeNumber
			// 
			this.lblFirstEpisodeNumber.Location = new System.Drawing.Point(8, 240);
			this.lblFirstEpisodeNumber.Name = "lblFirstEpisodeNumber";
			this.lblFirstEpisodeNumber.Size = new System.Drawing.Size(80, 16);
			this.lblFirstEpisodeNumber.TabIndex = 37;
			this.lblFirstEpisodeNumber.Text = "First Episode #";
			// 
			// txtIncrement
			// 
			this.txtIncrement.Location = new System.Drawing.Point(104, 264);
			this.txtIncrement.Name = "txtIncrement";
			this.txtIncrement.Size = new System.Drawing.Size(96, 20);
			this.txtIncrement.TabIndex = 36;
			this.txtIncrement.Text = "1";
			// 
			// Increment
			// 
			this.Increment.Location = new System.Drawing.Point(8, 264);
			this.Increment.Name = "Increment";
			this.Increment.Size = new System.Drawing.Size(80, 16);
			this.Increment.TabIndex = 37;
			this.Increment.Text = "Increment";
			// 
			// lblDistributor
			// 
			this.lblDistributor.Location = new System.Drawing.Point(224, 216);
			this.lblDistributor.Name = "lblDistributor";
			this.lblDistributor.Size = new System.Drawing.Size(72, 16);
			this.lblDistributor.TabIndex = 37;
			this.lblDistributor.Text = "Distributor";
			// 
			// lblGenre
			// 
			this.lblGenre.Location = new System.Drawing.Point(224, 136);
			this.lblGenre.Name = "lblGenre";
			this.lblGenre.Size = new System.Drawing.Size(56, 16);
			this.lblGenre.TabIndex = 37;
			this.lblGenre.Text = "Genre";
			// 
			// chkLive
			// 
			this.chkLive.Location = new System.Drawing.Point(216, 104);
			this.chkLive.Name = "chkLive";
			this.chkLive.Size = new System.Drawing.Size(56, 24);
			this.chkLive.TabIndex = 38;
			this.chkLive.Text = "Live?";
			// 
			// chkRecord
			// 
			this.chkRecord.Location = new System.Drawing.Point(272, 104);
			this.chkRecord.Name = "chkRecord";
			this.chkRecord.Size = new System.Drawing.Size(72, 24);
			this.chkRecord.TabIndex = 38;
			this.chkRecord.Text = "Record?";
			// 
			// lblRating
			// 
			this.lblRating.Location = new System.Drawing.Point(224, 240);
			this.lblRating.Name = "lblRating";
			this.lblRating.Size = new System.Drawing.Size(64, 16);
			this.lblRating.TabIndex = 37;
			this.lblRating.Text = "Rating";
			// 
			// lblDisclaimer
			// 
			this.lblDisclaimer.Location = new System.Drawing.Point(224, 264);
			this.lblDisclaimer.Name = "lblDisclaimer";
			this.lblDisclaimer.Size = new System.Drawing.Size(64, 16);
			this.lblDisclaimer.TabIndex = 37;
			this.lblDisclaimer.Text = "Disclaimer";
			// 
			// lblPictureLockDate
			// 
			this.lblPictureLockDate.Location = new System.Drawing.Point(224, 288);
			this.lblPictureLockDate.Name = "lblPictureLockDate";
			this.lblPictureLockDate.Size = new System.Drawing.Size(88, 16);
			this.lblPictureLockDate.TabIndex = 37;
			this.lblPictureLockDate.Text = "PictureLockDate";
			// 
			// lblVCHIP
			// 
			this.lblVCHIP.Location = new System.Drawing.Point(224, 160);
			this.lblVCHIP.Name = "lblVCHIP";
			this.lblVCHIP.Size = new System.Drawing.Size(72, 16);
			this.lblVCHIP.TabIndex = 37;
			this.lblVCHIP.Text = "VCHIP";
			// 
			// txtAssetEpisodeTitle
			// 
			this.txtAssetEpisodeTitle.Location = new System.Drawing.Point(104, 144);
			this.txtAssetEpisodeTitle.Name = "txtAssetEpisodeTitle";
			this.txtAssetEpisodeTitle.Size = new System.Drawing.Size(96, 20);
			this.txtAssetEpisodeTitle.TabIndex = 36;
			this.txtAssetEpisodeTitle.Text = "";
			// 
			// lblAssetEpisodeTitle
			// 
			this.lblAssetEpisodeTitle.Location = new System.Drawing.Point(8, 144);
			this.lblAssetEpisodeTitle.Name = "lblAssetEpisodeTitle";
			this.lblAssetEpisodeTitle.Size = new System.Drawing.Size(88, 16);
			this.lblAssetEpisodeTitle.TabIndex = 37;
			this.lblAssetEpisodeTitle.Text = "Episode Title";
			// 
			// txtAssetTitleListing
			// 
			this.txtAssetTitleListing.Location = new System.Drawing.Point(104, 168);
			this.txtAssetTitleListing.Name = "txtAssetTitleListing";
			this.txtAssetTitleListing.Size = new System.Drawing.Size(96, 20);
			this.txtAssetTitleListing.TabIndex = 36;
			this.txtAssetTitleListing.Text = "";
			// 
			// lblAssetTitleListing
			// 
			this.lblAssetTitleListing.Location = new System.Drawing.Point(8, 168);
			this.lblAssetTitleListing.Name = "lblAssetTitleListing";
			this.lblAssetTitleListing.Size = new System.Drawing.Size(88, 16);
			this.lblAssetTitleListing.TabIndex = 37;
			this.lblAssetTitleListing.Text = "Ass Title Listing";
			// 
			// chkIsFinalTitle
			// 
			this.chkIsFinalTitle.Location = new System.Drawing.Point(8, 120);
			this.chkIsFinalTitle.Name = "chkIsFinalTitle";
			this.chkIsFinalTitle.TabIndex = 38;
			this.chkIsFinalTitle.Text = "Final Title?";
			// 
			// txtOpUnit
			// 
			this.txtOpUnit.Location = new System.Drawing.Point(312, 312);
			this.txtOpUnit.Name = "txtOpUnit";
			this.txtOpUnit.Size = new System.Drawing.Size(168, 20);
			this.txtOpUnit.TabIndex = 36;
			this.txtOpUnit.Text = "369";
			// 
			// lblOperatingUnit
			// 
			this.lblOperatingUnit.Location = new System.Drawing.Point(224, 320);
			this.lblOperatingUnit.Name = "lblOperatingUnit";
			this.lblOperatingUnit.Size = new System.Drawing.Size(88, 16);
			this.lblOperatingUnit.TabIndex = 37;
			this.lblOperatingUnit.Text = "Op Unit";
			// 
			// txtOpGroup
			// 
			this.txtOpGroup.Location = new System.Drawing.Point(312, 336);
			this.txtOpGroup.Name = "txtOpGroup";
			this.txtOpGroup.Size = new System.Drawing.Size(168, 20);
			this.txtOpGroup.TabIndex = 36;
			this.txtOpGroup.Text = "";
			// 
			// lblOpGroup
			// 
			this.lblOpGroup.Location = new System.Drawing.Point(224, 336);
			this.lblOpGroup.Name = "lblOpGroup";
			this.lblOpGroup.Size = new System.Drawing.Size(88, 16);
			this.lblOpGroup.TabIndex = 37;
			this.lblOpGroup.Text = "Op Group";
			// 
			// txtNumberOfPackages
			// 
			this.txtNumberOfPackages.Location = new System.Drawing.Point(328, 48);
			this.txtNumberOfPackages.Name = "txtNumberOfPackages";
			this.txtNumberOfPackages.Size = new System.Drawing.Size(64, 20);
			this.txtNumberOfPackages.TabIndex = 36;
			this.txtNumberOfPackages.Text = "";
			// 
			// lblNumberOfPackages
			// 
			this.lblNumberOfPackages.Location = new System.Drawing.Point(232, 56);
			this.lblNumberOfPackages.Name = "lblNumberOfPackages";
			this.lblNumberOfPackages.Size = new System.Drawing.Size(88, 16);
			this.lblNumberOfPackages.TabIndex = 37;
			this.lblNumberOfPackages.Text = "# of  Packages";
			// 
			// lblUplink
			// 
			this.lblUplink.Location = new System.Drawing.Point(224, 184);
			this.lblUplink.Name = "lblUplink";
			this.lblUplink.Size = new System.Drawing.Size(72, 16);
			this.lblUplink.TabIndex = 37;
			this.lblUplink.Text = "Uplink";
			// 
			// sltVCHIP
			// 
			this.sltVCHIP.Items.AddRange(new object[] {
														  "All Children (TV-Y)|-143",
														  "Directed to Older Children (TV-Y7)|-144",
														  "Directed to Older Children (TV-Y7-FV)|-145",
														  "General Audience (TV-G)|-117",
														  "Mature Audience Only (TV-MA+S)|-120",
														  "Mature Audience Only (TV-MA+L)|-119",
														  "Mature Audience Only (TV-MA)|-118",
														  "Mature Audience Only (TV-MA+SL)|-121",
														  "Mature Audience Only (TV-MA+VS)|-124",
														  "Mature Audience Only (TV-MA+VSL)|-125",
														  "Mature Audience Only (TV-MA+V)|-122",
														  "Mature Audience Only (TV-MA+VL)|-123",
														  "No Rating (E)|-142",
														  "Parental Guidance Suggested (TV-PG+SL)|-132",
														  "Parental Guidance Suggested (TV-PG+SLD)|-133",
														  "Parental Guidance Suggested (TV-PG+V)|-134",
														  "Parental Guidance Suggested (TV-PG+SD)|-131",
														  "Parental Guidance Suggested (TV-PG+L)|-128",
														  "Parental Guidance Suggested (TV-PG+LD)|-129",
														  "Parental Guidance Suggested (TV-PG+S)|-130",
														  "Parental Guidance Suggested (TV-PG+VSD)|-139",
														  "Parental Guidance Suggested (TV-PG+VSL)|-140",
														  "Parental Guidance Suggested (TV-PG+VSLD)|-141",
														  "Parental Guidance Suggested (TV-PG+VS)|-138",
														  "Parental Guidance Suggested (TV-PG+VD)|-135",
														  "Parental Guidance Suggested (TV-PG+VL)|-136",
														  "Parental Guidance Suggested (TV-PG+VLD)|-137",
														  "Parental Guidance Suggested (TV-PG)|-126",
														  "Parental Guidance Suggested (TV-PG+D)|-127",
														  "Parents Strongly Cautioned (TV-14+VSL)|-114",
														  "Parents Strongly Cautioned (TV-14+VSD)|-113",
														  "Parents Strongly Cautioned (TV-14+VLD)|-111",
														  "Parents Strongly Cautioned (TV-14+VSLD)|-115",
														  "Parents Strongly Cautioned (TV-14+D)|-101",
														  "Parents Strongly Cautioned (TV-14)|-100",
														  "Parents Strongly Cautioned (TV-14+VS)|-112",
														  "Parents Strongly Cautioned (TV-14+L)|-102",
														  "Parents Strongly Cautioned (TV-14+SD)|-105",
														  "Parents Strongly Cautioned (TV-14+SL)|-106",
														  "Parents Strongly Cautioned (TV-14+LD)|-103",
														  "Parents Strongly Cautioned (TV-14+S)|-104",
														  "Parents Strongly Cautioned (TV-14+VD)|-109",
														  "Parents Strongly Cautioned (TV-14+VL)|-110",
														  "Parents Strongly Cautioned (TV-14+SLD)|-107",
														  "Parents Strongly Cautioned (TV-14+V)|-108"});
			this.sltVCHIP.Location = new System.Drawing.Point(312, 160);
			this.sltVCHIP.Name = "sltVCHIP";
			this.sltVCHIP.Size = new System.Drawing.Size(168, 21);
			this.sltVCHIP.TabIndex = 42;
			// 
			// sltDistributor
			// 
			this.sltDistributor.Items.AddRange(new object[] {
																"PBS|3136739",
																"WETA|3136792"});
			this.sltDistributor.Location = new System.Drawing.Point(312, 208);
			this.sltDistributor.Name = "sltDistributor";
			this.sltDistributor.Size = new System.Drawing.Size(168, 21);
			this.sltDistributor.TabIndex = 42;
			// 
			// sltUplink
			// 
			this.sltUplink.Items.AddRange(new object[] {
														   "SOC - PBS Satellite Operations Center|3177866"});
			this.sltUplink.Location = new System.Drawing.Point(312, 184);
			this.sltUplink.Name = "sltUplink";
			this.sltUplink.Size = new System.Drawing.Size(168, 21);
			this.sltUplink.TabIndex = 42;
			// 
			// sltRating
			// 
			this.sltRating.Items.AddRange(new object[] {
														   "All Children|3124917",
														   "Children 7 and Older|3124918",
														   "Exempt|3124913",
														   "General Audience|3124914",
														   "Mature Audience Only|3124915",
														   "Parental Guidance Suggested|3124916",
														   "Parents Strongly Cautioned|3124912"});
			this.sltRating.Location = new System.Drawing.Point(312, 232);
			this.sltRating.Name = "sltRating";
			this.sltRating.Size = new System.Drawing.Size(168, 21);
			this.sltRating.TabIndex = 42;
			// 
			// sltDisclaimer
			// 
			this.sltDisclaimer.Items.AddRange(new object[] {
															   "D - Dialogue|3098274",
															   "F V  - Fantasy Violence|3125145",
															   "L - Language|3125109",
															   "L D - Language, Dialogue|3125110",
															   "S - Sexual Situations|3125111",
															   "S D - Sexual Situations, Dialogue|3125112",
															   "S L - Sexual Situations, Language|3125113",
															   "S L D - Sexual Situations, Language, Dialogue|3125114",
															   "V - Violence|3125115",
															   "V D - Violence, Dialogue|3125116",
															   "V L - Violence, Language|3125117",
															   "V L D  - Violence, Language, Dialogue|3125118",
															   "V S  - Violence, Sexual Situations|3125119",
															   "V S D  - Violence, Sexual Situations, Dialogue|3125120",
															   "V S L - Violence, Sexual Situations, Language|3125121",
															   "V S L D - |3125122",
															   "V S L D C|3125144"});
			this.sltDisclaimer.Location = new System.Drawing.Point(312, 256);
			this.sltDisclaimer.Name = "sltDisclaimer";
			this.sltDisclaimer.Size = new System.Drawing.Size(168, 21);
			this.sltDisclaimer.TabIndex = 42;
			// 
			// chkNewMasterDeal
			// 
			this.chkNewMasterDeal.Location = new System.Drawing.Point(16, 16);
			this.chkNewMasterDeal.Name = "chkNewMasterDeal";
			this.chkNewMasterDeal.Size = new System.Drawing.Size(128, 24);
			this.chkNewMasterDeal.TabIndex = 38;
			this.chkNewMasterDeal.Text = "New MasterDeal?";
			this.chkNewMasterDeal.CheckedChanged += new System.EventHandler(this.chkNewMasterDeal_CheckedChanged);
			// 
			// sltPBSProgramType
			// 
			this.sltPBSProgramType.Items.AddRange(new object[] {
																   "Promo Reel|3161912",
																   "Teleconference|3161913",
																   "Episode in a series|3163743",
																   "Miniseries|3163744",
																   "One-time-only|3163745",
																   "Series|3163746"});
			this.sltPBSProgramType.Location = new System.Drawing.Point(104, 48);
			this.sltPBSProgramType.Name = "sltPBSProgramType";
			this.sltPBSProgramType.Size = new System.Drawing.Size(112, 21);
			this.sltPBSProgramType.TabIndex = 42;
			// 
			// txtNumberOfEpisodes
			// 
			this.txtNumberOfEpisodes.Location = new System.Drawing.Point(104, 288);
			this.txtNumberOfEpisodes.Name = "txtNumberOfEpisodes";
			this.txtNumberOfEpisodes.Size = new System.Drawing.Size(96, 20);
			this.txtNumberOfEpisodes.TabIndex = 36;
			this.txtNumberOfEpisodes.Text = "";
			// 
			// lblNumberOfEpisodes
			// 
			this.lblNumberOfEpisodes.Location = new System.Drawing.Point(8, 288);
			this.lblNumberOfEpisodes.Name = "lblNumberOfEpisodes";
			this.lblNumberOfEpisodes.Size = new System.Drawing.Size(88, 16);
			this.lblNumberOfEpisodes.TabIndex = 37;
			this.lblNumberOfEpisodes.Text = "# Episodes";
			// 
			// chkIsEIQualified
			// 
			this.chkIsEIQualified.Location = new System.Drawing.Point(344, 104);
			this.chkIsEIQualified.Name = "chkIsEIQualified";
			this.chkIsEIQualified.Size = new System.Drawing.Size(88, 24);
			this.chkIsEIQualified.TabIndex = 38;
			this.chkIsEIQualified.Text = "EI Qualified?";
			// 
			// chkEIEmbedded
			// 
			this.chkEIEmbedded.Location = new System.Drawing.Point(432, 104);
			this.chkEIEmbedded.Name = "chkEIEmbedded";
			this.chkEIEmbedded.TabIndex = 38;
			this.chkEIEmbedded.Text = "EI Embedded?";
			// 
			// chkIsVCHIPEmbedded
			// 
			this.chkIsVCHIPEmbedded.Location = new System.Drawing.Point(536, 104);
			this.chkIsVCHIPEmbedded.Name = "chkIsVCHIPEmbedded";
			this.chkIsVCHIPEmbedded.Size = new System.Drawing.Size(128, 24);
			this.chkIsVCHIPEmbedded.TabIndex = 38;
			this.chkIsVCHIPEmbedded.Text = "VCHIP Embedded?";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(400, 56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 16);
			this.label1.TabIndex = 37;
			this.label1.Text = "Package Length";
			// 
			// txtPackageLength
			// 
			this.txtPackageLength.Location = new System.Drawing.Point(488, 48);
			this.txtPackageLength.Name = "txtPackageLength";
			this.txtPackageLength.Size = new System.Drawing.Size(64, 20);
			this.txtPackageLength.TabIndex = 36;
			this.txtPackageLength.Text = "";
			// 
			// lblPackageType
			// 
			this.lblPackageType.Location = new System.Drawing.Point(264, 80);
			this.lblPackageType.Name = "lblPackageType";
			this.lblPackageType.Size = new System.Drawing.Size(104, 16);
			this.lblPackageType.TabIndex = 37;
			this.lblPackageType.Text = "Package Type";
			// 
			// sltPackageType
			// 
			this.sltPackageType.Items.AddRange(new object[] {
																"HD-Base|2\t",
																"HD-Edited|3132209\t",
																"HD-Embedded Promo|3125980\t",
																"HD-Not For Air|3162322\t",
																"HD-Pledge|3128435\t",
																"HD-Pledge Event|3128436\t",
																"HD-Pledge Event Alternate Length|13583198",
																"HD-Pledge Event CPB|13688487",
																"HD-Pledge Event Extra Footage|13583186",
																"HD-Pledge Event Inclusive|8569455\t",
																"HD-Pledge Event Long|13584970",
																"HD-Pledge Event Short|13583192",
																"HD-Pledge Event Stacked|19457889",
																"HD-Pledge Stacked|19457888",
																"HD-Short|3128437\t",
																"HD-Short Embedded Promo|20543045",
																"HD-Special Report|22750929",
																"HD-Spot|18923433",
																"HD-Stacked|3125977\t",
																"HD-Stacked Not For Air|20355852",
																"HD-Stacked Unedited|3125981\t",
																"HD-Unedited|3125978\t",
																"HD-Upconverted Base|3162324\t",
																"HD-Upconverted Date Specific Tease|3162325\t",
																"HD-Upconverted Edited|3162326\t",
																"HD-Upconverted Embedded Promo|3162327\t",
																"HD-Upconverted Not For Air|3162328\t",
																"HD-Upconverted Pledge|3162329\t",
																"HD-Upconverted Pledge Event|9228482\t",
																"HD-Upconverted Short|3162331\t",
																"HD-Upconverted Stacked|3162332\t",
																"HD-Upconverted Stacked Edited|3162334\t",
																"HD-Upconverted Stacked Embedded Promo|8598492\t",
																"HD-Upconverted Stacked Unedited|3162333\t",
																"HD-Upconverted Unedited|9228487\t",
																"SD-Base|1\t",
																"SD-Date Specific Tease|3147885\t",
																"SD-Edited|3132210\t",
																"SD-Embedded Promo|3125984\t",
																"SD-Embedded Promo Edited|15708397",
																"SD-Feature Only|8907503\t",
																"SD-Not For Air|3162323\t",
																"SD-Open Captions|15549251",
																"SD-Pledge|3123038\t",
																"SD-Pledge Event|3123039\t",
																"SD-Pledge Event Alternate Length|13583084",
																"SD-Pledge Event CPB|13688489",
																"SD-Pledge Event Extra Footage|13581767",
																"SD-Pledge Event Inclusive|8569453\t",
																"SD-Pledge Event Long|13583044",
																"SD-Pledge Event Short|13583036",
																"SD-Pledge Event Stacked|19457867",
																"SD-Pledge Long|15118935",
																"SD-Pledge Short|15118934",
																"SD-Pledge Stacked|19457884",
																"SD-Short|3123034\t",
																"SD-Short Embedded Promo|20543043",
																"SD-Special Report|22750928",
																"SD-Spot|3128444\t",
																"SD-Stacked|3123036\t",
																"SD-Stacked Embedded Promo|8598493\t",
																"SD-Stacked Not For Air|20355829",
																"SD-Stacked Unedited|3125982\t",
																"SD-Subtitled|8569454\t",
																"SD-Unedited|3123033\t",
																"SD-Widescreen Base|3145837\t",
																"SD-Widescreen Edited|3145838\t",
																"SD-Widescreen Embedded Promo|3145839\t",
																"SD-Widescreen Pledge|3145840\t",
																"SD-Widescreen Pledge Event|3145841\t",
																"SD-Widescreen Short|3145843\t",
																"SD-Widescreen Stacked|3145847\t",
																"SD-Widescreen Stacked Embedded Promo|8993912\t",
																"SD-Widescreen Stacked Unedited|3145844\t",
																"SD-Widescreen Unedited|3145845"});
			this.sltPackageType.Location = new System.Drawing.Point(368, 80);
			this.sltPackageType.Name = "sltPackageType";
			this.sltPackageType.Size = new System.Drawing.Size(112, 21);
			this.sltPackageType.TabIndex = 42;
			// 
			// chkSDRights
			// 
			this.chkSDRights.Location = new System.Drawing.Point(512, 152);
			this.chkSDRights.Name = "chkSDRights";
			this.chkSDRights.Size = new System.Drawing.Size(128, 24);
			this.chkSDRights.TabIndex = 38;
			this.chkSDRights.Text = "SD Rights?";
			// 
			// chkHDRights
			// 
			this.chkHDRights.Location = new System.Drawing.Point(504, 184);
			this.chkHDRights.Name = "chkHDRights";
			this.chkHDRights.Size = new System.Drawing.Size(128, 24);
			this.chkHDRights.TabIndex = 38;
			this.chkHDRights.Text = "HD Rights?";
			// 
			// Form_rdmPBSProgramCreator
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(776, 518);
			this.Controls.Add(this.grpBoxProgramDetails);
			this.Name = "Form_rdmPBSProgramCreator";
			this.Text = "Form_rdmPBSProgramCreator";
			this.Controls.SetChildIndex(this.btnLogin, 0);
			this.Controls.SetChildIndex(this.btnLogout, 0);
			this.Controls.SetChildIndex(this.btnClearLog, 0);
			this.Controls.SetChildIndex(this.txtLog, 0);
			this.Controls.SetChildIndex(this.txtWebServiceURL, 0);
			this.Controls.SetChildIndex(this.grpBoxProgramDetails, 0);
			this.grpBoxProgramDetails.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion


		private void chkNewMasterDeal_CheckedChanged(object sender, System.EventArgs e)
		{
			if (chkNewMasterDeal.Checked)
			{
				txtMasterDealId.Enabled = false;
				txtMasterDealName.Enabled = true;
			}
			else
			{
				txtMasterDealId.Enabled = true;
				txtMasterDealName.Enabled = false;

			}
		}


		private void btnCreateProgram_Click(object sender, System.EventArgs e)
		{
			if (!ValidateSession())
				return;

			if (!chkHDRights.Checked && ! chkSDRights.Checked)
			{
				this.Log("HD and/or SD Rights must be checked for Program Creation. ", true);
				return;
			}
		
			if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
			{

				try
				{

					BVWebService.BVWebService oBVWebService = new BVWebService.BVWebService();
					oBVWebService.Url = this.txtWebServiceURL.Text + @"/Service.asmx";


					int[] oArrDealId = oBVWebService.GetIDs(1);
					int[] oArrProgramIds = oBVWebService.GetIDs(int.Parse(txtNumberOfEpisodes.Text));
					int[] oArrPackageIds = oBVWebService.GetIDs(int.Parse(txtNumberOfPackages.Text));

					
					
					TestWebService.BVWebService.Packages[] oArrPackages = new TestWebService.BVWebService.Packages[int.Parse(txtNumberOfPackages.Text)];
					for (int i=0; i<int.Parse(txtNumberOfPackages.Text); i++)
					{
						TestWebService.BVWebService.Packages oPackage = new TestWebService.BVWebService.Packages();

						//Note All Packages are created the same (FIX THIS)
						oPackage.FormatAndTypeID	= TestWebServiceHelper.GetSelectedItemValue(sltPackageType);
						oPackage.Length				= txtPackageLength.Text == String.Empty ? 3600 : int.Parse(txtPackageLength.Text);
						oPackage.VchipID			= TestWebServiceHelper.GetSelectedItemValue(sltVCHIP);
						oPackage.IsVCHIPEmbedded	= chkIsVCHIPEmbedded.Checked == true? (short)1:(short)0;
						oPackage.IsEiQualified		= chkIsEIQualified.Checked == true? (short)1:(short)0;
						oPackage.IsEiEmbedded		= chkEIEmbedded.Checked == true? (short)1:(short)0;


						oArrPackages[i] = oPackage;
					}




					this.Log("Start CreateProgram Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
					this.Log("CreateProgram Test Sequence : Deal Id [" +oArrDealId[0].ToString() +"]");
					for (int i=0; i<oArrProgramIds.Length; i++)
					{
						this.Log("CreateProgram Test Sequence : Program [Asset] Id [" +oArrProgramIds[i].ToString() +"]");
					}

					oBVWebService.CreateProgram(m_sBVSessionId, 
						int.Parse(txtMasterDealId.Text),
						txtMasterDealName.Text,
						txtSeason.Text,
						oArrDealId[0],
						txtDealDescription.Text,
						txtDealDescription.Text,
						TestWebServiceHelper.GetSelectedItemValue(sltPBSProgramType),
						TestWebServiceHelper.GetSelectedItemValue(sltUplink),
						oArrProgramIds,
						TestWebServiceHelper.GetSelectedItemValue(sltPBSProgramType),
						txtDuration.Text == String.Empty ? 0 : int.Parse(txtDuration.Text),
						txtNolaRoot.Text,
						txtFirstEpisodeNumber.Text == String.Empty ? 101 : int.Parse(txtFirstEpisodeNumber.Text),
						txtIncrement.Text == String.Empty ? 1 : int.Parse(txtIncrement.Text),
						TestWebServiceHelper.GetSelectedItemValue(sltDistributor),
						TestWebServiceHelper.GetSelectedItemValue(sltGenre),
						chkLive.Checked,
						chkRecord.Checked,
						TestWebServiceHelper.GetSelectedItemValue(sltRating),
						TestWebServiceHelper.GetSelectedItemValue(sltDisclaimer),
						dtPictureLockDate.ToString(),
						txtOpUnit.Text == String.Empty ? 369 : int.Parse(txtOpUnit.Text),
						txtOpGroup.Text,
						oArrPackages,
						TestWebServiceHelper.GetSelectedItemValue(sltVCHIP),
						txtAssetEpisodeTitle.Text,
						txtAssetTitleListing.Text,
						chkIsFinalTitle.Checked,
						chkSDRights.Checked,
						chkHDRights.Checked);
					this.Log("End CreateProgram Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );
				}
				catch(Exception oEx)
				{
					this.Log("Error in CreateProgram. " + oEx.ToString(), true);
				}
			}
			else
			{
				this.Log("Please log in. Session Null", true);
			}
		}
	}
}
