using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Configuration;

namespace CreateSchema
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class FormMain : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBoxGenSchema;
		private System.Windows.Forms.Button btnGo;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtTargetDir;
		private System.Windows.Forms.Button btnAdHocGenerator;
        private Button button1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormMain()
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
				if (components != null) 
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
            this.comboBoxGenSchema = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTargetDir = new System.Windows.Forms.TextBox();
            this.btnAdHocGenerator = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxGenSchema
            // 
            this.comboBoxGenSchema.Items.AddRange(new object[] {
            "EVERYTHING",
            "rdmPBSAuthorization",
            "rdmPBSDeadlineNotification",
            "rdmPBSDeal",
            "rdmPBSGetLookup",
            "rdmPBSGetMasterDeal",
            "rdmPBSManageAppliesToRange",
            "rdmPBSManageTable",
            "rdmPBSMediaInventory",
            "rdmPBSProgram",
            "rdmPBSProgramCreator",
            "rdmPBSRemedy",
            "rdmPBSSearch",
            "rdmPBSTalent"});
            this.comboBoxGenSchema.Location = new System.Drawing.Point(168, 56);
            this.comboBoxGenSchema.Name = "comboBoxGenSchema";
            this.comboBoxGenSchema.Size = new System.Drawing.Size(392, 21);
            this.comboBoxGenSchema.TabIndex = 0;
            this.comboBoxGenSchema.SelectedIndexChanged += new System.EventHandler(this.comboBoxGenSchema_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(24, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Generate Schema For:";
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(256, 88);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "GO!";
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(24, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Target Directory:";
            // 
            // txtTargetDir
            // 
            this.txtTargetDir.Location = new System.Drawing.Point(168, 16);
            this.txtTargetDir.Name = "txtTargetDir";
            this.txtTargetDir.Size = new System.Drawing.Size(304, 20);
            this.txtTargetDir.TabIndex = 4;
            this.txtTargetDir.Text = "..\\..\\Target";
            this.txtTargetDir.Validating += new System.ComponentModel.CancelEventHandler(this.txtTargetDir_Validating);
            // 
            // btnAdHocGenerator
            // 
            this.btnAdHocGenerator.Location = new System.Drawing.Point(16, 128);
            this.btnAdHocGenerator.Name = "btnAdHocGenerator";
            this.btnAdHocGenerator.Size = new System.Drawing.Size(144, 23);
            this.btnAdHocGenerator.TabIndex = 6;
            this.btnAdHocGenerator.Text = "Open AdHocGenerator";
            this.btnAdHocGenerator.Click += new System.EventHandler(this.btnAdHocGenerator_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(418, 128);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Open CodeGenerator";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(600, 158);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAdHocGenerator);
            this.Controls.Add(this.txtTargetDir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxGenSchema);
            this.Name = "FormMain";
            this.Text = "Code Generator";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new FormMain());
		}



        private void GenSchemaForAllrdmPBSAuthorization(string strTargetDir)
        {
#warning - Session
            //CloseSession;
            //DebugTimeout;
            //OpenSession;
            //ReleaseLock
        }
        private void GenSchemaForAllrdmPBSDeadlineNotification(string strTargetDir)
        {
            ListPAADeadline oListPAADeadline = new ListPAADeadline();
            oListPAADeadline.GenSchema(txtTargetDir.Text);

            ListFormDeadline oListFormDeadline = new ListFormDeadline();
            oListFormDeadline.GenSchema(txtTargetDir.Text);

            ListMissingEpisodeFormDeadline oListMissingEpisodeFormDeadline = new ListMissingEpisodeFormDeadline();
            oListMissingEpisodeFormDeadline.GenSchema(txtTargetDir.Text);

            ListMissingVersionFormDeadline oListMissingVersionFormDeadline = new ListMissingVersionFormDeadline();
            oListMissingVersionFormDeadline.GenSchema(txtTargetDir.Text);

        }
        private void GenSchemaForAllrdmPBSDeal(string strTargetDir)
        {

            GetDeal oGetDeal = new GetDeal();
            oGetDeal.GenSchema(txtTargetDir.Text);

            CreateDeal oCreateDeal = new CreateDeal();
            oCreateDeal.GenSchema(txtTargetDir.Text);

            GetDealAll oGetDealAll = new GetDealAll();
            oGetDealAll.GenSchema(txtTargetDir.Text);

            GetDealWithFunding oGetDealWithFunding = new GetDealWithFunding();
            oGetDealWithFunding.GenSchema(txtTargetDir.Text);

            GetDealWithGeneral oGetDealWithGeneral = new GetDealWithGeneral();
            oGetDealWithGeneral.GenSchema(txtTargetDir.Text);

            GetDealWithRights oGetDealWithRights = new GetDealWithRights();
            oGetDealWithRights.GenSchema(txtTargetDir.Text);

            GetDealWithTechnical oGetDealWithTechnical = new GetDealWithTechnical();
            oGetDealWithTechnical.GenSchema(txtTargetDir.Text);

            //Note:  PutDealXXX methods are Genereated within the GetDealXXX.GenSchema
            //There is no PutDealAll method.


            //PutDeal oPutDeal = new PutDeal();
            //oGetDeal.GenSchema(txtTargetDir.Text);

            //PutDealWithFunding oPutDealWithFunding = new PutDealWithFunding();
            //oPutDealWithFunding.GenSchema(txtTargetDir.Text);

            //PutDealWithGeneral oPutDealWithGeneral = new PutDealWithGeneral();
            //oPutDealWithGeneral.GenSchema(txtTargetDir.Text);

            //PutDealWithRights oPutDealWithRights = new PutDealWithRights();
            //oPutDealWithRights.GenSchema(txtTargetDir.Text);

            //PutDealWithTechnical oPutDealWithTechnical = new PutDealWithTechnical();
            //oPutDealWithTechnical.GenSchema(txtTargetDir.Text);





        }
        private void GenSchemaForAllrdmPBSGetLookup(string strTargetDir)
		{
            {
                LoadAlliantContractModels oLoadAlliantContractModels = new LoadAlliantContractModels();
                oLoadAlliantContractModels.GenSchema(txtTargetDir.Text);
            }

            {
                LoadStations oLoadStations = new LoadStations();
                oLoadStations.GenSchema(txtTargetDir.Text);
            }

            
            {
				LoadBillTo oLoadBillTo = new LoadBillTo();
				oLoadBillTo.GenSchema(txtTargetDir.Text);
			}

			{
				LoadBillToContact oLoadBillToContact = new LoadBillToContact();
				oLoadBillToContact.GenSchema(txtTargetDir.Text);
			}

			{
				LoadCaptionVendor oLoadCaptionVendor = new LoadCaptionVendor();
				oLoadCaptionVendor.GenSchema(txtTargetDir.Text);
			}
			{
				LoadCompany oLoadCompany = new LoadCompany();
				oLoadCompany.GenSchema(strTargetDir);
			}
			{
				LoadContactType oLoadContactType = new LoadContactType();
				oLoadContactType.GenSchema(strTargetDir);
			}
			{
				LoadDisclaimer oLoadDisclaimer = new LoadDisclaimer();
				oLoadDisclaimer.GenSchema(strTargetDir);
			}
			{
				LoadDistributors oLoadDistributors = new LoadDistributors();
				oLoadDistributors.GenSchema(strTargetDir);
			}
			{
				LoadFunders oLoadFunders = new LoadFunders();
				oLoadFunders.GenSchema(strTargetDir);
			}
			{
				LoadFunderType oLoadFunderType = new LoadFunderType();
				oLoadFunderType.GenSchema(strTargetDir);
			}
			{
				LoadGenre oLoadGenre = new LoadGenre();
				oLoadGenre.GenSchema(strTargetDir);
			}
			{
				LoadKeywords oLoadKeywords = new LoadKeywords();
				oLoadKeywords.GenSchema(txtTargetDir.Text);
			}
			{
				LoadLanguage oLoadLanguage = new LoadLanguage();
				oLoadLanguage.GenSchema(strTargetDir);
			}
			{
				LoadProgramType oLoadProgramType = new LoadProgramType();
				oLoadProgramType.GenSchema(txtTargetDir.Text);
			}
			{
				LoadLocalUnderwriting oLoadLocalUnderwriting = new LoadLocalUnderwriting();
				oLoadLocalUnderwriting.GenSchema(strTargetDir);
			}
			{
				LoadPBSProgramType oLoadPBSProgramType = new LoadPBSProgramType();
				oLoadPBSProgramType.GenSchema(strTargetDir);
			}
			{
				LoadPlayRule oLoadPlayRule = new LoadPlayRule();
				oLoadPlayRule.GenSchema(strTargetDir);
			}
			{
				LoadRating oLoadRating = new LoadRating();
				oLoadRating.GenSchema(strTargetDir);
			}
			{
				LoadSchoolRights oLoadSchoolRights = new LoadSchoolRights();
				oLoadSchoolRights.GenSchema(strTargetDir);
			}
			{
				LoadUplinks oLoadUplinks = new LoadUplinks();
				oLoadUplinks.GenSchema(txtTargetDir.Text);
			}
			{
				LoadVersionFormatAndType oLoadVersionFormatAndType = new LoadVersionFormatAndType();
				oLoadVersionFormatAndType.GenSchema(txtTargetDir.Text);
			}
			{
				LoadAudioType oLoadAudioType = new LoadAudioType();
				oLoadAudioType.GenSchema(txtTargetDir.Text);
			}
			{
				LoadTalentRoles oLoadTalentRoles = new LoadTalentRoles();
				oLoadTalentRoles.GenSchema(txtTargetDir.Text);
			}
			{
				LoadSurroundSoundType oLoadSurroundSoundType = new LoadSurroundSoundType();
				oLoadSurroundSoundType.GenSchema(txtTargetDir.Text);
			}
			{
				LoadAspectRatioType oAspectRatio =  new LoadAspectRatioType();
				oAspectRatio.GenSchema(txtTargetDir.Text);
			}
			{
				LoadAssetCategory oLoadAssetCategory =  new LoadAssetCategory();
				oLoadAssetCategory.GenSchema(txtTargetDir.Text);
			}
			{
				LoadHighDefType oLoadHighDefType =  new LoadHighDefType();
				oLoadHighDefType.GenSchema(txtTargetDir.Text);
			}
			{
				LoadVideoFormat oLoadVideoFormat =  new LoadVideoFormat();
				oLoadVideoFormat.GenSchema(txtTargetDir.Text);
			}
			{
				LoadMediaFeatureClass oLoadMediaFeatureClass =  new LoadMediaFeatureClass();
				oLoadMediaFeatureClass.GenSchema(txtTargetDir.Text);
			}
			{
				LoadCutItemType oLoadCutItemType =  new LoadCutItemType();
				oLoadCutItemType.GenSchema(txtTargetDir.Text);
			}
			{
				LoadMediaFormatType oLoadMediaFormatType =  new LoadMediaFormatType();
				oLoadMediaFormatType.GenSchema(txtTargetDir.Text);
			}
			{
				LoadMediaInventoryType oLoadMediaInventoryType =  new LoadMediaInventoryType();
				oLoadMediaInventoryType.GenSchema(txtTargetDir.Text);
			}
			{
				LoadMediaStatus oLoadMediaStatus =  new LoadMediaStatus();
				oLoadMediaStatus.GenSchema(txtTargetDir.Text);
			}
			{
				LoadMediaFeature oLoadMediaFeature =  new LoadMediaFeature();
				oLoadMediaFeature.GenSchema(txtTargetDir.Text);
			}
			{
				LoadPackageType oLoadPackageType =  new LoadPackageType();
				oLoadPackageType.GenSchema(txtTargetDir.Text);
			}
			{
				LoadOacPreOfferDescriptionType oLoadOacPreOfferDescriptionType =  new LoadOacPreOfferDescriptionType();
				oLoadOacPreOfferDescriptionType.GenSchema(txtTargetDir.Text);
			}
			{
				LoadOacPostOfferDescriptionType oLoadOacPostOfferDescriptionType =  new LoadOacPostOfferDescriptionType();
				oLoadOacPostOfferDescriptionType.GenSchema(txtTargetDir.Text);
			}
			{
				LoadVCHIPValues oLoadVCHIPValues =  new LoadVCHIPValues();
				oLoadVCHIPValues.GenSchema(txtTargetDir.Text);
			}
		}
        private void GenSchemaForAllrdmPBSGetMasterDeal(string strTargetDir)
        {
            ListDealsByMasterDeal oListDealsByMasterDeal = new ListDealsByMasterDeal();
            oListDealsByMasterDeal.GenSchema(txtTargetDir.Text);

            GetMasterDeal oGetMasterDeal = new GetMasterDeal();
            oGetMasterDeal.GenSchema(txtTargetDir.Text);

            //There is no PutMasterDeal
        }
        private void GenSchemaForAllrdmPBSManageAppliesToRange(string strTargetDir)
        {
            GetAssetAppliesToRangeByTab oGetAssetAppliesToRangeByTab = new GetAssetAppliesToRangeByTab();
            oGetAssetAppliesToRangeByTab.GenSchema(txtTargetDir.Text);

            GetPackageAppliesToRangeByTab oGetPackageAppliesToRangeByTab = new GetPackageAppliesToRangeByTab();
            oGetPackageAppliesToRangeByTab.GenSchema(txtTargetDir.Text);

            //Note: PutXXX methods are Genereated within the GetXXX.GenSchema

            ListTabMapByDeal oListTabMapByDeal = new ListTabMapByDeal();
            oListTabMapByDeal.GenSchema(txtTargetDir.Text);



        }
        private void GenSchemaForAllrdmPBSManageTable(string strTargetDir)
        {
            GetMusicCue oGetMusicCue = new GetMusicCue();
            oGetMusicCue.GenSchema(txtTargetDir.Text);

            GetVisualArt oGetVisualArt = new GetVisualArt();
            oGetVisualArt.GenSchema(txtTargetDir.Text);

            GetFormatSheet oGetFormatSheet = new GetFormatSheet();
            oGetFormatSheet.GenSchema(txtTargetDir.Text);

            GetOAC oGetOAC = new GetOAC();
            oGetOAC.GenSchema(txtTargetDir.Text);

            GetIWT oGetIWT = new GetIWT();
            oGetIWT.GenSchema(txtTargetDir.Text);

            GetUCC oGetUCC = new GetUCC();
            oGetUCC.GenSchema(txtTargetDir.Text);


            //Note:  DeleteXXX and PutXXX methods are Genereated within the GetXXX.GenSchema



            //DeleteMusicCue oDeleteMusicCue = new DeleteMusicCue();
            //oDeleteMusicCue.GenSchema(txtTargetDir.Text);

            //DeleteVisualArt oDeleteVisualArt = new DeleteVisualArt();
            //oDeleteVisualArt.GenSchema(txtTargetDir.Text);

            //DeleteFormatSheet oDeleteFormatSheet = new DeleteFormatSheet();
            //oDeleteFormatSheet.GenSchema(txtTargetDir.Text);

            //DeleteOAC oDeleteOAC = new DeleteOAC();
            //oDeleteOAC.GenSchema(txtTargetDir.Text);

            //DeleteIWT oDeleteIWT = new DeleteIWT();
            //oDeleteIWT.GenSchema(txtTargetDir.Text);

            //DeleteUCC oDeleteUCC = new DeleteUCC();
            //oDeleteUCC.GenSchema(txtTargetDir.Text);

            //PutMusicCue oPutMusicCue = new PutMusicCue();
            //oPutMusicCue.GenSchema(txtTargetDir.Text);

            //PutVisualArt oPutVisualArt = new PutVisualArt();
            //oPutVisualArt.GenSchema(txtTargetDir.Text);

            //PutFormatSheet oPutFormatSheet = new PutFormatSheet();
            //oPutFormatSheet.GenSchema(txtTargetDir.Text);

            //PutOAC oPutOAC = new PutOAC();
            //oPutOAC.GenSchema(txtTargetDir.Text);

            //PutIWT oPutIWT = new PutIWT();
            //oPutIWT.GenSchema(txtTargetDir.Text);

            //PutUCC oPutUCC = new PutUCC();
            //oPutUCC.GenSchema(txtTargetDir.Text);



        }
        private void GenSchemaForAllrdmPBSMediaInventory(string strTargetDir)
        {

            GetFeatureMediaInventory oGetFeatureMediaInventory = new GetFeatureMediaInventory();
            oGetFeatureMediaInventory.GenSchema(txtTargetDir.Text);

            GetMediaInventoryRevision oGetMediaInventoryRevision = new GetMediaInventoryRevision();
            oGetMediaInventoryRevision.GenSchema(txtTargetDir.Text);

            //Note:  PutXXX methods are Genereated within the GetXXX.GenSchema
            //Note:  CreateMediaInventoryRevision, GetBarCode methods are Genereated within the GetMediaInventoryRevision.GenSchema

            //PutFeatureMediaInventory oPutFeatureMediaInventory = new PutFeatureMediaInventory();
            //oPutFeatureMediaInventory.GenSchema(txtTargetDir.Text);

            //PutMediaInventoryRevision oPutMediaInventoryRevision = new PutMediaInventoryRevision();
            //oPutMediaInventoryRevision.GenSchema(txtTargetDir.Text);

            //CreateMediaInventoryRevision oCreateMediaInventoryRevision = new CreateMediaInventoryRevision();
            //oCreateMediaInventoryRevision.GenSchema(txtTargetDir.Text);

            //GetBarCode oGetBarCode = new GetBarCode();
            //oGetBarCode.GenSchema(txtTargetDir.Text);


        }
        private void GenSchemaForAllrdmPBSProgram(string strTargetDir)
        {


            ListProgramPackagesByProgram oListProgramPackagesByProgram = new ListProgramPackagesByProgram();
            oListProgramPackagesByProgram.GenSchema(txtTargetDir.Text);

            ListProgramsByDeal oListProgramsByDeal = new ListProgramsByDeal();
            oListProgramsByDeal.GenSchema(txtTargetDir.Text);

            GetProgramDetails oGetProgramDetails = new GetProgramDetails();
            oGetProgramDetails.GenSchema(txtTargetDir.Text);

            GetPackage oGetPackage = new GetPackage();
            oGetPackage.GenSchema(txtTargetDir.Text);

            GetAdCopy oGetAdCopy = new GetAdCopy();
            oGetAdCopy.GenSchema(txtTargetDir.Text);

            //Note:  PutAdCopy method is  Genereated within the GetAdCopy.GenSchema
            //Note:  PutProgramDetails method is  Genereated within the GetProgramDetails.GenSchema
            //Note:  There is no PutPackage API

            //PutAdCopy oPutAdCopy = new PutAdCopy();
            //oPutAdCopy.GenSchema(txtTargetDir.Text);

            //PutProgramDetails oPutProgramDetails = new PutProgramDetails();
            //oPutProgramDetails.GenSchema(txtTargetDir.Text);

            //PutPackage oPutPackage = new PutPackage();
            //oPutPackage.GenSchema(txtTargetDir.Text);

        }
        private void GenSchemaForAllrdmPBSProgramCreator(string strTargetDir)
        {
            CreateProgram oCreateProgram = new CreateProgram();
            oCreateProgram.GenSchema(txtTargetDir.Text);
        }
        private void GenSchemaForAllrdmPBSRemedy(string strTargetDir)
        {
            GetDiscrepancyProgram oGetDiscrepancyProgram = new GetDiscrepancyProgram();
            oGetDiscrepancyProgram.GenSchema(txtTargetDir.Text);
        }
        private void GenSchemaForAllrdmPBSSearch(string strTargetDir)
        {

            DealSearch oDealSearch = new DealSearch();
            oDealSearch.GenSchema(txtTargetDir.Text);

            ProgramSearch oProgramSearch = new ProgramSearch();
            oProgramSearch.GenSchema(txtTargetDir.Text);

            TrafficItemSearch oTrafficItemSearch = new TrafficItemSearch();
            oTrafficItemSearch.GenSchema(txtTargetDir.Text);

            MediaInventorySearch oMediaInventorySearch = new MediaInventorySearch();
            oMediaInventorySearch.GenSchema(txtTargetDir.Text);

            AdCopySearch oAdCopySearch = new AdCopySearch();
            oAdCopySearch.GenSchema(txtTargetDir.Text);

            MasterDealSearch oMasterDealSearch = new MasterDealSearch();
            oMasterDealSearch.GenSchema(txtTargetDir.Text);

            ValidateEpisodeSlate oValidateEpisodeSlate = new ValidateEpisodeSlate();
            oValidateEpisodeSlate.GenSchema(txtTargetDir.Text);




            //ScheduAll
            MediaInfoSearch oMediaInfoSearch = new MediaInfoSearch();
            oMediaInfoSearch.GenSchema(txtTargetDir.Text);

            PackageInfoSearch oPackageInfoSearch = new PackageInfoSearch();
            oPackageInfoSearch.GenSchema(txtTargetDir.Text);

            ListMediaCutsInfo oListMediaCutsInfo = new ListMediaCutsInfo();
            oListMediaCutsInfo.GenSchema(txtTargetDir.Text);

            ListPackageCutsInfo oListPackageCutsInfo = new ListPackageCutsInfo();
            oListPackageCutsInfo.GenSchema(txtTargetDir.Text);

            ListPackageMediaInfo oListPackageMediaInfo = new ListPackageMediaInfo();
            oListPackageMediaInfo.GenSchema(txtTargetDir.Text);

            DetailedAirDate oDetailedAirDate = new DetailedAirDate();
            oDetailedAirDate.GenSchema(txtTargetDir.Text);

            //Note:  There are no XSD, XML or XSLTs for SearchFeatureAirDate, SearchMediaAirDate, SearchPackageAirDate

            SearchFeatureAirDate oSearchFeatureAirDate = new SearchFeatureAirDate();
            oSearchFeatureAirDate.GenSchema(txtTargetDir.Text);

            SearchMediaAirDate oSearchMediaAirDate = new SearchMediaAirDate();
            oSearchMediaAirDate.GenSchema(txtTargetDir.Text);

            SearchPackageAirDate oSearchPackageAirDate = new SearchPackageAirDate();
            oSearchPackageAirDate.GenSchema(txtTargetDir.Text);

        }
        private void GenSchemaForAllrdmPBSTalent(string strTargetDir)
        {
            GetTalent oGetTalent = new GetTalent();
            oGetTalent.GenSchema(txtTargetDir.Text);

            //Note:  PutTalent method is Genereated within the GetTalent.GenSchema

            TalentSearch oTalent = new TalentSearch();
            oTalent.GenSchema(txtTargetDir.Text);

            //PutTalent oPutTalent = new PutTalent();
            //oPutTalent.GenSchema(txtTargetDir.Text);


        }

        //Templates Done
        //GenSchemaForAllrdmPBSDeadlineNotification
        //GenSchemaForAllrdmPBSDeal
        //GenSchemaForAllrdmPBSGetLookup
        //GenSchemaForAllrdmPBSGetMasterDeal
        //GenSchemaForAllrdmPBSManageAppliesToRange
        //GenSchemaForAllrdmPBSManageTable
        //GenSchemaForAllrdmPBSMediaInventory
        //GenSchemaForAllrdmPBSProgram
        //GenSchemaForAllrdmPBSProgramCreator
        //GenSchemaForAllrdmPBSRemedy
        //GenSchemaForAllrdmPBSSearch
        //GenSchemaForAllrdmPBSTalent
		
		private void FormMain_Load(object sender, System.EventArgs e)
		{
			// Get application settings from our configuration file
            string strTargetDir = System.Configuration.ConfigurationManager.AppSettings["TargetDir"];

			if (!Directory.Exists(strTargetDir))
			{
				MessageBox.Show("Given target directory: " + strTargetDir + " does not exist! Please fix!");
			}
			else
			{
				txtTargetDir.Text = strTargetDir;
			}
		}

		private void btnGo_Click(object sender, System.EventArgs e)
		{
		    
            try
			{
				Cursor = Cursors.WaitCursor;

				switch (comboBoxGenSchema.Text)
                {
                    case "rdmPBSAuthorization":
                        {
                            GenSchemaForAllrdmPBSAuthorization(txtTargetDir.Text);
                            break;
                        }
                    case "rdmPBSDeadlineNotification":
                        {
                            GenSchemaForAllrdmPBSDeadlineNotification(txtTargetDir.Text);
                            break;
                        }
                    case "rdmPBSDeal":
                        {
                            GenSchemaForAllrdmPBSDeal(txtTargetDir.Text);
                            break;
                        }
                    case "rdmPBSGetLookup":
                        {
                            GenSchemaForAllrdmPBSGetLookup(txtTargetDir.Text);
                            break;
                        }
                    case "rdmPBSGetMasterDeal":
                        {
                            GenSchemaForAllrdmPBSGetMasterDeal(txtTargetDir.Text);
                            break;
                        }
                    case "rdmPBSManageAppliesToRange":
                        {
                            GenSchemaForAllrdmPBSManageAppliesToRange(txtTargetDir.Text);
                            break;
                        }
                    case "rdmPBSManageTable":
                        {
                            GenSchemaForAllrdmPBSManageTable(txtTargetDir.Text);
                            break;
                        }
                    case "rdmPBSMediaInventory":
                        {
                            GenSchemaForAllrdmPBSMediaInventory(txtTargetDir.Text);
                            break;
                        }
                    case "rdmPBSProgram":
                        {
                            GenSchemaForAllrdmPBSProgram(txtTargetDir.Text);
                            break;
                        }
                    case "rdmPBSProgramCreator":
                        {
                            GenSchemaForAllrdmPBSProgramCreator(txtTargetDir.Text);
                            break;
                        }
                    case "rdmPBSRemedy":
                        {
                            GenSchemaForAllrdmPBSRemedy(txtTargetDir.Text);
                            break;
                        }
                    case "rdmPBSSearch":
                        {
                            GenSchemaForAllrdmPBSSearch(txtTargetDir.Text);
                            break;
                        }
                    case "rdmPBSTalent":
                        {
                            GenSchemaForAllrdmPBSTalent(txtTargetDir.Text);
                            break;
                        }

                    case "EVERYTHING":
                        {
                            GenSchemaForAllrdmPBSAuthorization(txtTargetDir.Text);
                            GenSchemaForAllrdmPBSDeadlineNotification(txtTargetDir.Text);
                            GenSchemaForAllrdmPBSDeal(txtTargetDir.Text);
                            GenSchemaForAllrdmPBSGetLookup(txtTargetDir.Text);
                            GenSchemaForAllrdmPBSGetMasterDeal(txtTargetDir.Text);
                            GenSchemaForAllrdmPBSManageAppliesToRange(txtTargetDir.Text);
                            GenSchemaForAllrdmPBSManageTable(txtTargetDir.Text);
                            GenSchemaForAllrdmPBSMediaInventory(txtTargetDir.Text);
                            GenSchemaForAllrdmPBSProgram(txtTargetDir.Text);
                            GenSchemaForAllrdmPBSProgramCreator(txtTargetDir.Text);
                            GenSchemaForAllrdmPBSRemedy(txtTargetDir.Text);
                            GenSchemaForAllrdmPBSSearch(txtTargetDir.Text);
                            GenSchemaForAllrdmPBSTalent(txtTargetDir.Text);
                            break;
                        }

                    default:
						break;
				}

				MessageBox.Show("Schema Generated!");
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error while generating schema: " + ex.Message);
			}
			finally
			{
				Cursor = Cursors.Default;
			}
		}

		private void txtTargetDir_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			string strTargetDir = ((TextBox) sender).Text.Trim();

			// Validate that the given folder exists and has the necessary subfolders
			if (strTargetDir == "")
			{
				MessageBox.Show("Target directory must not be empty!");
			}
			else
			{
				if (! Directory.Exists(strTargetDir))
				{
					MessageBox.Show("Given target directory: " + strTargetDir + " does not exist!");
					e.Cancel = true;
				}

				// Create subdirectories...
				if (! Directory.Exists(strTargetDir + @"\BVSchema"))
				{
					Directory.CreateDirectory(strTargetDir + @"\BVSchema");
				}

				if (! Directory.Exists(strTargetDir + @"\xsd"))
				{
					Directory.CreateDirectory(strTargetDir + @"\xsd");
				}

				if (! Directory.Exists(strTargetDir + @"\xslt"))
				{
					Directory.CreateDirectory(strTargetDir + @"\xslt");
				}

				//if (! Directory.Exists(strTargetDir + @"\xsltClass"))
				//{
				//	Directory.CreateDirectory(strTargetDir + @"\xsltClass");
				//}
			}		
		}

	

		private void btnAdHocGenerator_Click(object sender, System.EventArgs e)
		{
			FormAdHocGenerator oAdHoc	= new FormAdHocGenerator();
			oAdHoc.TargetDir			= txtTargetDir.Text;
			oAdHoc.ShowDialog(this);
		}

        private void comboBoxGenSchema_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormCodeGenerator oFormCodeGenerator = new FormCodeGenerator();
           
            oFormCodeGenerator.ShowDialog(this);
        }
	}
}