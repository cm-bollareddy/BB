using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using TestWebService.BVWebService;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data;

using System.Reflection;



namespace TestWebService
{
	/// <summary>
	/// Summary description for Form_rdmPBSGetLookup.
	/// </summary>
	public class Form_rdmPBSGetLookup : Form_Base
	{
		private System.Windows.Forms.ListBox sltLoadAPIName;
		private System.Windows.Forms.Button btnLoadAll;
		private System.Windows.Forms.Button btnLoadSelect;
		private System.Windows.Forms.CheckBox chkSaveResults;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogSaveResults;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form_rdmPBSGetLookup()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();


			this.HideButton(btnLogin);
			this.HideButton(btnLogout);
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
			this.sltLoadAPIName = new System.Windows.Forms.ListBox();
			this.btnLoadAll = new System.Windows.Forms.Button();
			this.btnLoadSelect = new System.Windows.Forms.Button();
			this.chkSaveResults = new System.Windows.Forms.CheckBox();
			this.folderBrowserDialogSaveResults = new System.Windows.Forms.FolderBrowserDialog();
			this.SuspendLayout();
			// 
			// btnLogout
			// 
			this.btnLogout.Location = new System.Drawing.Point(408, 48);
			this.btnLogout.Name = "btnLogout";
			// 
			// btnLogin
			// 
			this.btnLogin.Location = new System.Drawing.Point(408, 24);
			this.btnLogin.Name = "btnLogin";
			// 
			// btnClearLog
			// 
			this.btnClearLog.Location = new System.Drawing.Point(408, 72);
			this.btnClearLog.Name = "btnClearLog";
			// 
			// txtWebServiceURL
			// 
			this.txtWebServiceURL.Name = "txtWebServiceURL";
			this.txtWebServiceURL.Size = new System.Drawing.Size(784, 20);
			// 
			// txtLog
			// 
			this.txtLog.Location = new System.Drawing.Point(0, 262);
			this.txtLog.Name = "txtLog";
			this.txtLog.Size = new System.Drawing.Size(488, 112);
			// 
			// sltProxyEnvironment
			// 
			this.sltProxyEnvironment.Name = "sltProxyEnvironment";
			// 
			// chkGlobalSaveResults
			// 
			this.chkGlobalSaveResults.Name = "chkGlobalSaveResults";
			// 
			// sltLoadAPIName
			// 
			this.sltLoadAPIName.Items.AddRange(new object[] {
																"LoadAlliantContractModels",
																"LoadAspectRatioType",
																"LoadAssetCategory",
																"LoadAudioType",
																"LoadBillTo",
																"LoadBillToContact",
																"LoadCaptionVendor",
																"LoadCompany",
																"LoadContactType",
																"LoadCutItemType",
																"LoadDisclaimer",
																"LoadDistributors",
																"LoadFunders",
																"LoadFunderType",
																"LoadGenre",
																"LoadHighDefType",
																"LoadKeywords",
																"LoadLanguage",
																"LoadLocalUnderwriting",
																"LoadMediaFeature",
																"LoadMediaFeatureClass",
																"LoadMediaFormatType",
																"LoadMediaInventoryType",
																"LoadMediaStatus",
																"LoadOacPostOfferDescriptionType",
																"LoadOacPreOfferDescriptionType",
																"LoadPackageType",
																"LoadPBSProgramType",
																"LoadPlayRule",
																"LoadProgramType",
																"LoadRating",
																"LoadSchoolRights",
																"LoadStations",
																"LoadSurroundSoundType",
																"LoadTalentRoles",
																"LoadUplinks",
																"LoadVChipValues",
																"LoadVersionFormatAndType",
																"LoadVideoFormat"});
			this.sltLoadAPIName.Location = new System.Drawing.Point(16, 136);
			this.sltLoadAPIName.Name = "sltLoadAPIName";
			this.sltLoadAPIName.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.sltLoadAPIName.Size = new System.Drawing.Size(264, 95);
			this.sltLoadAPIName.TabIndex = 11;
			// 
			// btnLoadAll
			// 
			this.btnLoadAll.Location = new System.Drawing.Point(16, 64);
			this.btnLoadAll.Name = "btnLoadAll";
			this.btnLoadAll.Size = new System.Drawing.Size(144, 23);
			this.btnLoadAll.TabIndex = 10;
			this.btnLoadAll.Text = "Test All Load Methods";
			this.btnLoadAll.Click += new System.EventHandler(this.btnLoadAll_Click);
			// 
			// btnLoadSelect
			// 
			this.btnLoadSelect.Location = new System.Drawing.Point(16, 104);
			this.btnLoadSelect.Name = "btnLoadSelect";
			this.btnLoadSelect.Size = new System.Drawing.Size(144, 23);
			this.btnLoadSelect.TabIndex = 12;
			this.btnLoadSelect.Text = "Test Select Load Methods";
			this.btnLoadSelect.Click += new System.EventHandler(this.btnLoadSelect_Click);
			// 
			// chkSaveResults
			// 
			this.chkSaveResults.Location = new System.Drawing.Point(176, 104);
			this.chkSaveResults.Name = "chkSaveResults";
			this.chkSaveResults.Size = new System.Drawing.Size(144, 24);
			this.chkSaveResults.TabIndex = 17;
			this.chkSaveResults.Text = "Save Results to File";
			// 
			// Form_rdmPBSGetLookup
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(488, 374);
			this.Controls.Add(this.chkSaveResults);
			this.Controls.Add(this.btnLoadSelect);
			this.Controls.Add(this.sltLoadAPIName);
			this.Controls.Add(this.btnLoadAll);
			this.Name = "Form_rdmPBSGetLookup";
			this.Text = "Form_rdmPBSGetLookup";
			this.Controls.SetChildIndex(this.sltProxyEnvironment, 0);
			this.Controls.SetChildIndex(this.chkGlobalSaveResults, 0);
			this.Controls.SetChildIndex(this.btnLogin, 0);
			this.Controls.SetChildIndex(this.btnLogout, 0);
			this.Controls.SetChildIndex(this.btnClearLog, 0);
			this.Controls.SetChildIndex(this.txtLog, 0);
			this.Controls.SetChildIndex(this.btnLoadAll, 0);
			this.Controls.SetChildIndex(this.sltLoadAPIName, 0);
			this.Controls.SetChildIndex(this.btnLoadSelect, 0);
			this.Controls.SetChildIndex(this.txtWebServiceURL, 0);
			this.Controls.SetChildIndex(this.chkSaveResults, 0);
			this.ResumeLayout(false);

		}
		#endregion



		private void btnLoadAll_Click(object sender, System.EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			try
			{
				BVWebService.BVWebService oBVWebService = new BVWebService.BVWebService();
				oBVWebService.Url				= txtWebServiceURL.Text + @"/Service.asmx";


                bool bSaveResults = false;
                if (chkSaveResults.Checked)
                {
                    if (folderBrowserDialogSaveResults.ShowDialog() == DialogResult.OK)
                    {
                        bSaveResults = true;
                    }
                    else
                    {
                        this.Log("Please specify a folder path to save the results.", true);
                        return;
                    }
                }

                DataSet oResult = null;

				this.Log("Start:LoadAlliantContractModels");
				oResult = oBVWebService.LoadAlliantContractModels();
                if (bSaveResults) { SaveResults(oResult, folderBrowserDialogSaveResults.SelectedPath, "LoadAlliantContractModels"); }
				this.Log("Finished:LoadAlliantContractModels");

				this.Log("Start:LoadAspectRatioType");
                oResult = oBVWebService.LoadAspectRatioType();
                if (bSaveResults) { SaveResults(oResult, folderBrowserDialogSaveResults.SelectedPath, "LoadAspectRatioType"); }
				this.Log("Finished:LoadAspectRatioType");

				this.Log("Start:LoadAssetCategory");
                oResult = oBVWebService.LoadAssetCategory();
                if (bSaveResults) { SaveResults(oResult, folderBrowserDialogSaveResults.SelectedPath, "LoadAssetCategory"); }
				this.Log("Finished:LoadAssetCategory");

				this.Log("Start:LoadAudioType");
                oResult = oBVWebService.LoadAudioType();
                if (bSaveResults) { SaveResults(oResult, folderBrowserDialogSaveResults.SelectedPath, "LoadAudioType"); }
				this.Log("Finished:LoadAudioType");

				this.Log("Start:LoadBillTo");
                oResult = oBVWebService.LoadBillTo();
                if (bSaveResults) { SaveResults(oResult, folderBrowserDialogSaveResults.SelectedPath, "LoadBillTo"); }
				this.Log("Finished:LoadBillTo");

				this.Log("Start:LoadBillToContact");
                oResult = oBVWebService.LoadBillToContact();
                if (bSaveResults) { SaveResults(oResult, folderBrowserDialogSaveResults.SelectedPath, "LoadBillToContact"); }
				this.Log("Finished:LoadBillToContact");

				this.Log("Start:LoadCaptionVendor");
                oResult = oBVWebService.LoadCaptionVendor();
                if (bSaveResults) { SaveResults(oResult, folderBrowserDialogSaveResults.SelectedPath, "LoadCaptionVendor"); }
				this.Log("Finished:LoadCaptionVendor");

				this.Log("Start:LoadCompany");
                oResult = oBVWebService.LoadCompany();
                if (bSaveResults) { SaveResults(oResult, folderBrowserDialogSaveResults.SelectedPath, "LoadCompany"); }
				this.Log("Finished:LoadCompany");

				this.Log("Start:LoadContactType");
                oResult = oBVWebService.LoadContactType();
                if (bSaveResults) { SaveResults(oResult, folderBrowserDialogSaveResults.SelectedPath, "LoadContactType"); }
				this.Log("Finished:LoadContactType");

				this.Log("Start:LoadCutItemType");
                oResult = oBVWebService.LoadCutItemType();
                if (bSaveResults) { SaveResults(oResult, folderBrowserDialogSaveResults.SelectedPath, "LoadCutItemType"); }
				this.Log("Finished:LoadCutItemType");

				this.Log("Start:LoadDisclaimer");
                oResult = oBVWebService.LoadDisclaimer();
                if (bSaveResults) { SaveResults(oResult, folderBrowserDialogSaveResults.SelectedPath, "LoadDisclaimer"); }
				this.Log("Finished:LoadDisclaimer");

				this.Log("Start:LoadDistributors");
                oResult = oBVWebService.LoadDistributors();
                if (bSaveResults) { SaveResults(oResult, folderBrowserDialogSaveResults.SelectedPath, "LoadDistributors"); }
				this.Log("Finished:LoadDistributors");

				this.Log("Start:LoadFunders");
                oResult = oBVWebService.LoadFunders();
                if (bSaveResults) { SaveResults(oResult, folderBrowserDialogSaveResults.SelectedPath, "LoadFunders"); }
				this.Log("Finished:LoadFunders");

				this.Log("Start:LoadFunderType");
                oResult = oBVWebService.LoadFunderType();
                if (bSaveResults) { SaveResults(oResult, folderBrowserDialogSaveResults.SelectedPath, "LoadFunderType"); }
				this.Log("Finished:LoadFunderType");

				this.Log("Start:LoadGenre");
                oResult = oBVWebService.LoadGenre();
                if (bSaveResults) { SaveResults(oResult, folderBrowserDialogSaveResults.SelectedPath, "LoadGenre"); }
				this.Log("Finished:LoadGenre");

				this.Log("Start:LoadHighDefType");
                oResult = oBVWebService.LoadHighDefType();
                if (bSaveResults) { SaveResults(oResult, folderBrowserDialogSaveResults.SelectedPath, "LoadHighDefType"); }
				this.Log("Finished:LoadHighDefType");

				this.Log("Start:LoadKeywords");
                oResult = oBVWebService.LoadKeywords();
                if (bSaveResults) { SaveResults(oResult, folderBrowserDialogSaveResults.SelectedPath, "LoadKeywords"); }
				this.Log("Finished:LoadKeywords");

				this.Log("Start:LoadLanguage");
                oResult = oBVWebService.LoadLanguage();
                if (bSaveResults) { SaveResults(oResult, folderBrowserDialogSaveResults.SelectedPath, "LoadLanguage"); }
				this.Log("Finished:LoadLanguage");

				this.Log("Start:LoadLocalUnderwriting");
                oResult = oBVWebService.LoadLocalUnderwriting();
                if (bSaveResults) { SaveResults(oResult, folderBrowserDialogSaveResults.SelectedPath, "LoadLocalUnderwriting"); }
				this.Log("Finished:LoadLocalUnderwriting");

				this.Log("Start:LoadMediaFeature");
                oResult = oBVWebService.LoadMediaFeature();
                if (bSaveResults) { SaveResults(oResult, folderBrowserDialogSaveResults.SelectedPath, "LoadMediaFeature"); }
				this.Log("Finished:LoadMediaFeature");

				this.Log("Start:LoadMediaFeatureClass");
                oResult = oBVWebService.LoadMediaFeatureClass();
                if (bSaveResults) { SaveResults(oResult, folderBrowserDialogSaveResults.SelectedPath, "LoadMediaFeatureClass"); }
				this.Log("Finished:LoadMediaFeatureClass");

				this.Log("Start:LoadMediaFormatType");
                oResult = oBVWebService.LoadMediaFormatType();
                if (bSaveResults) { SaveResults(oResult, folderBrowserDialogSaveResults.SelectedPath, "LoadMediaFormatType"); }
				this.Log("Finished:LoadMediaFormatType");

				this.Log("Start:LoadMediaInventoryType");
                oResult = oBVWebService.LoadMediaInventoryType();
                if (bSaveResults) { SaveResults(oResult, folderBrowserDialogSaveResults.SelectedPath, "LoadMediaInventoryType"); }
				this.Log("Finished:LoadMediaInventoryType");

				this.Log("Start:LoadMediaStatus");
                oResult = oBVWebService.LoadMediaStatus();
                if (bSaveResults) { SaveResults(oResult, folderBrowserDialogSaveResults.SelectedPath, "LoadMediaStatus"); }
				this.Log("Finished:LoadMediaStatus");

				this.Log("Start:LoadOacPostOfferDescriptionType");
                oResult = oBVWebService.LoadOacPostOfferDescriptionType();
                if (bSaveResults) { SaveResults(oResult, folderBrowserDialogSaveResults.SelectedPath, "LoadOacPostOfferDescriptionType"); }
				this.Log("Finished:LoadOacPostOfferDescriptionType");

				this.Log("Start:LoadOacPreOfferDescriptionType");
                oResult = oBVWebService.LoadOacPreOfferDescriptionType();
                if (bSaveResults) { SaveResults(oResult, folderBrowserDialogSaveResults.SelectedPath, "LoadOacPreOfferDescriptionType"); }
				this.Log("Finished:LoadOacPreOfferDescriptionType");

				this.Log("Start:LoadPackageType");
                oResult = oBVWebService.LoadPackageType();
                if (bSaveResults) { SaveResults(oResult, folderBrowserDialogSaveResults.SelectedPath, "LoadPackageType"); }
				this.Log("Finished:LoadPackageType");

				this.Log("Start:LoadPBSProgramType");
                oResult = oBVWebService.LoadPBSProgramType();
                if (bSaveResults) { SaveResults(oResult, folderBrowserDialogSaveResults.SelectedPath, "LoadPBSProgramType"); }
				this.Log("Finished:LoadPBSProgramType");

				this.Log("Start:LoadPlayRule");
                oResult = oBVWebService.LoadPlayRule();
                if (bSaveResults) { SaveResults(oResult, folderBrowserDialogSaveResults.SelectedPath, "LoadPlayRule"); }
				this.Log("Finished:LoadPlayRule");

				this.Log("Start:LoadProgramType");
                oResult = oBVWebService.LoadProgramType();
                if (bSaveResults) { SaveResults(oResult, folderBrowserDialogSaveResults.SelectedPath, "LoadProgramType"); }
				this.Log("Finished:LoadProgramType");

				this.Log("Start:LoadRating");
                oResult = oBVWebService.LoadRating();
                if (bSaveResults) { SaveResults(oResult, folderBrowserDialogSaveResults.SelectedPath, "LoadRating"); }
				this.Log("Finished:LoadRating");

				this.Log("Start:LoadSchoolRights");
                oResult = oBVWebService.LoadSchoolRights();
                if (bSaveResults) { SaveResults(oResult, folderBrowserDialogSaveResults.SelectedPath, "LoadSchoolRights"); }
				this.Log("Finished:LoadSchoolRights");
				
				this.Log("Start:LoadStations");
                oResult = oBVWebService.LoadStations();
                if (bSaveResults) { SaveResults(oResult, folderBrowserDialogSaveResults.SelectedPath, "LoadStations"); }
				this.Log("Finished:LoadStations");

				this.Log("Start:LoadSurroundSoundType");
                oResult = oBVWebService.LoadSurroundSoundType();
                if (bSaveResults) { SaveResults(oResult, folderBrowserDialogSaveResults.SelectedPath, "LoadSurroundSoundType"); }
				this.Log("Finished:LoadSurroundSoundType");

				this.Log("Start:LoadTalentRoles");
                oResult = oBVWebService.LoadTalentRoles();
                if (bSaveResults) { SaveResults(oResult, folderBrowserDialogSaveResults.SelectedPath, "LoadTalentRoles"); }
				this.Log("Finished:LoadTalentRoles");

				this.Log("Start:LoadUplinks");
                oResult = oBVWebService.LoadUplinks();
                if (bSaveResults) { SaveResults(oResult, folderBrowserDialogSaveResults.SelectedPath, "LoadUplinks"); }
				this.Log("Finished:LoadUplinks");

				this.Log("Start:LoadVChipValues");
                oResult = oBVWebService.LoadVChipValues();
                if (bSaveResults) { SaveResults(oResult, folderBrowserDialogSaveResults.SelectedPath, "LoadVChipValues"); }
				this.Log("Finished:LoadVChipValues");

				this.Log("Start:LoadVersionFormatAndType");
                oResult = oBVWebService.LoadVersionFormatAndType();
                if (bSaveResults) { SaveResults(oResult, folderBrowserDialogSaveResults.SelectedPath, "LoadVersionFormatAndType"); }
				this.Log("Finished:LoadVersionFormatAndType");

				this.Log("Start:LoadVideoFormat");
                oResult = oBVWebService.LoadVideoFormat();
                if (bSaveResults) { SaveResults(oResult, folderBrowserDialogSaveResults.SelectedPath, "LoadVideoFormat"); }
				this.Log("Finished:LoadVideoFormat");

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
				this.Log("Session: " + m_sBVSessionId);
			}

		}


        private void SaveResults(DataSet p_oDataSet, string p_sPath, string p_sInterfaceName)
        {

            string sFullPath = p_sPath + System.IO.Path.DirectorySeparatorChar.ToString() + sltProxyEnvironment.Text  + "_"+ p_sInterfaceName + "_" + DateTime.Now.ToString("yyyyMMdd_hhMM") + ".xml";
			this.Log("Saving Result File to:  " + sFullPath);
			p_oDataSet.WriteXml(sFullPath);
        }


		private void btnLoadSelect_Click(object sender, System.EventArgs e)
		{
            
			this.Cursor = Cursors.WaitCursor;

			if (this.sltLoadAPIName.SelectedItems.Count <= 0)
			{
				this.Cursor = Cursors.Default;
				this.Log("Please Select One or More Load Methods from the Listing",true);
				return;
			}


				try
				{

					BVWebService.BVWebService oBVWebService = new BVWebService.BVWebService();
					oBVWebService.Url				= txtWebServiceURL.Text + @"/Service.asmx";
					

					bool bSaveResults = false;
					if (chkSaveResults.Checked)
					{
						if (folderBrowserDialogSaveResults.ShowDialog() == DialogResult.OK)
						{
							bSaveResults = true;
						}
						else
						{
							this.Log("Please specify a folder path to save the results.",true);
							return;
						}
					}
			

					DataSet oDataSet;
					foreach(object oSelectedItem in this.sltLoadAPIName.SelectedItems)
					{
						//MessageBox.Show(oSelectedItem.ToString());
						Type oLoadType = oBVWebService.GetType();
						MethodInfo oLoad = oLoadType.GetMethod(oSelectedItem.ToString());
						
						this.Log("Start:" + oSelectedItem.ToString());
						
						oDataSet = (DataSet) oLoad.Invoke(oBVWebService, null);

						if (bSaveResults)
						{
							
							if (folderBrowserDialogSaveResults.SelectedPath != null)
							{
								string sPath = folderBrowserDialogSaveResults.SelectedPath + System.IO.Path.DirectorySeparatorChar.ToString() + sltProxyEnvironment.Text + "_"+ oSelectedItem.ToString() + "_" + DateTime.Now.ToString("yyyyMMdd_hhMM") + ".xml";
								this.Log("Saving Result File to:  " + sPath);
								oDataSet.WriteXml(sPath);
							}
						}

						this.Log("Finish:" +  oSelectedItem.ToString());
					}
				}
				catch(SoapException oEx)
				{
					this.Log(oEx.ToString() + oEx.StackTrace,true);
				}
				catch(Exception oEx)
				{
					this.Log(oEx.ToString() + oEx.StackTrace,true);
				}
				finally
				{
					this.Cursor = Cursors.Default;
					this.Log("Session: " + m_sBVSessionId);
				}
		
		}
		
		

	}
}
