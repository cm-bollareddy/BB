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
	/// Summary description for Form_rdmPBSManageTable.
	/// </summary>
	public class Form_rdmPBSManageTable : Form_Base 
	{
		private System.Windows.Forms.GroupBox grpBoxGetForm;
		private System.Windows.Forms.Label lblGetMasterDealHelp;
		private System.Windows.Forms.Label lblTabId;
		private System.Windows.Forms.TextBox txtTabId;
		private System.Windows.Forms.Label lblTabType;
		private System.Windows.Forms.Button btnGetForm;
		private System.Windows.Forms.Button btnReleaseLock;
		private System.Windows.Forms.CheckBox chkRequestLock;
		private System.Windows.Forms.Label lblLockId;
		private System.Windows.Forms.TextBox txtLockId;
		private System.Windows.Forms.DataGrid dgOrionAPIs;
		private System.Windows.Forms.Button btnPutForm;
		private System.Windows.Forms.Button btnDeleteForm;
		private System.Windows.Forms.ComboBox sltFormType;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form_rdmPBSManageTable()
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

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);

			if (dgOrionAPIs != null)
			{
				dgOrionAPIs.Width = this.Width -20;
				dgOrionAPIs.Height = this.Height;
			}
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.grpBoxGetForm = new System.Windows.Forms.GroupBox();
			this.sltFormType = new System.Windows.Forms.ComboBox();
			this.btnDeleteForm = new System.Windows.Forms.Button();
			this.btnReleaseLock = new System.Windows.Forms.Button();
			this.chkRequestLock = new System.Windows.Forms.CheckBox();
			this.lblLockId = new System.Windows.Forms.Label();
			this.txtLockId = new System.Windows.Forms.TextBox();
			this.lblGetMasterDealHelp = new System.Windows.Forms.Label();
			this.btnGetForm = new System.Windows.Forms.Button();
			this.lblTabId = new System.Windows.Forms.Label();
			this.txtTabId = new System.Windows.Forms.TextBox();
			this.lblTabType = new System.Windows.Forms.Label();
			this.btnPutForm = new System.Windows.Forms.Button();
			this.dgOrionAPIs = new System.Windows.Forms.DataGrid();
			this.grpBoxGetForm.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgOrionAPIs)).BeginInit();
			this.SuspendLayout();
			// 
			// btnLogout
			// 
			this.btnLogout.Location = new System.Drawing.Point(720, 56);
			this.btnLogout.Name = "btnLogout";
			// 
			// btnLogin
			// 
			this.btnLogin.Location = new System.Drawing.Point(720, 32);
			this.btnLogin.Name = "btnLogin";
			// 
			// btnClearLog
			// 
			this.btnClearLog.Location = new System.Drawing.Point(720, 80);
			this.btnClearLog.Name = "btnClearLog";
			// 
			// txtWebServiceURL
			// 
			this.txtWebServiceURL.Name = "txtWebServiceURL";
			this.txtWebServiceURL.Size = new System.Drawing.Size(784, 20);
			// 
			// txtLog
			// 
			this.txtLog.Location = new System.Drawing.Point(0, 342);
			this.txtLog.Name = "txtLog";
			this.txtLog.Size = new System.Drawing.Size(808, 112);
			// 
			// chkGlobalSaveResults
			// 
			this.chkGlobalSaveResults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chkGlobalSaveResults.Location = new System.Drawing.Point(712, 104);
			this.chkGlobalSaveResults.Name = "chkGlobalSaveResults";
			this.chkGlobalSaveResults.Size = new System.Drawing.Size(72, 48);
			// 
			// grpBoxGetForm
			// 
			this.grpBoxGetForm.Controls.Add(this.sltFormType);
			this.grpBoxGetForm.Controls.Add(this.btnDeleteForm);
			this.grpBoxGetForm.Controls.Add(this.btnReleaseLock);
			this.grpBoxGetForm.Controls.Add(this.chkRequestLock);
			this.grpBoxGetForm.Controls.Add(this.lblLockId);
			this.grpBoxGetForm.Controls.Add(this.txtLockId);
			this.grpBoxGetForm.Controls.Add(this.lblGetMasterDealHelp);
			this.grpBoxGetForm.Controls.Add(this.btnGetForm);
			this.grpBoxGetForm.Controls.Add(this.lblTabId);
			this.grpBoxGetForm.Controls.Add(this.txtTabId);
			this.grpBoxGetForm.Controls.Add(this.lblTabType);
			this.grpBoxGetForm.Controls.Add(this.btnPutForm);
			this.grpBoxGetForm.Location = new System.Drawing.Point(8, 40);
			this.grpBoxGetForm.Name = "grpBoxGetForm";
			this.grpBoxGetForm.Size = new System.Drawing.Size(584, 144);
			this.grpBoxGetForm.TabIndex = 16;
			this.grpBoxGetForm.TabStop = false;
			this.grpBoxGetForm.Text = "GetForm";
			// 
			// sltFormType
			// 
			this.sltFormType.Items.AddRange(new object[] {
															 "MUS",
															 "VIS",
															 "UCC",
															 "IWT",
															 "FOR",
															 "OAC"});
			this.sltFormType.Location = new System.Drawing.Point(88, 40);
			this.sltFormType.Name = "sltFormType";
			this.sltFormType.Size = new System.Drawing.Size(120, 21);
			this.sltFormType.TabIndex = 41;
			// 
			// btnDeleteForm
			// 
			this.btnDeleteForm.Location = new System.Drawing.Point(216, 64);
			this.btnDeleteForm.Name = "btnDeleteForm";
			this.btnDeleteForm.Size = new System.Drawing.Size(184, 23);
			this.btnDeleteForm.TabIndex = 40;
			this.btnDeleteForm.Text = "DeleteForm";
			this.btnDeleteForm.Click += new System.EventHandler(this.btnDeleteForm_Click);
			// 
			// btnReleaseLock
			// 
			this.btnReleaseLock.Location = new System.Drawing.Point(216, 88);
			this.btnReleaseLock.Name = "btnReleaseLock";
			this.btnReleaseLock.Size = new System.Drawing.Size(184, 23);
			this.btnReleaseLock.TabIndex = 39;
			this.btnReleaseLock.Text = "ReleaseLock";
			this.btnReleaseLock.Click += new System.EventHandler(this.btnReleaseLock_Click);
			// 
			// chkRequestLock
			// 
			this.chkRequestLock.Location = new System.Drawing.Point(88, 88);
			this.chkRequestLock.Name = "chkRequestLock";
			this.chkRequestLock.TabIndex = 38;
			this.chkRequestLock.Text = "RequestLock?";
			// 
			// lblLockId
			// 
			this.lblLockId.Location = new System.Drawing.Point(16, 64);
			this.lblLockId.Name = "lblLockId";
			this.lblLockId.Size = new System.Drawing.Size(40, 16);
			this.lblLockId.TabIndex = 37;
			this.lblLockId.Text = "LockId";
			// 
			// txtLockId
			// 
			this.txtLockId.Location = new System.Drawing.Point(88, 64);
			this.txtLockId.Name = "txtLockId";
			this.txtLockId.Size = new System.Drawing.Size(120, 20);
			this.txtLockId.TabIndex = 36;
			this.txtLockId.Text = "";
			// 
			// lblGetMasterDealHelp
			// 
			this.lblGetMasterDealHelp.Location = new System.Drawing.Point(160, 120);
			this.lblGetMasterDealHelp.Name = "lblGetMasterDealHelp";
			this.lblGetMasterDealHelp.Size = new System.Drawing.Size(100, 16);
			this.lblGetMasterDealHelp.TabIndex = 34;
			this.lblGetMasterDealHelp.Text = "Results in Datagrid";
			// 
			// btnGetForm
			// 
			this.btnGetForm.Location = new System.Drawing.Point(216, 16);
			this.btnGetForm.Name = "btnGetForm";
			this.btnGetForm.Size = new System.Drawing.Size(184, 23);
			this.btnGetForm.TabIndex = 15;
			this.btnGetForm.Text = "GetForm";
			this.btnGetForm.Click += new System.EventHandler(this.btnGetForm_Click);
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
			this.lblTabType.Text = "TabType*";
			// 
			// btnPutForm
			// 
			this.btnPutForm.Location = new System.Drawing.Point(216, 40);
			this.btnPutForm.Name = "btnPutForm";
			this.btnPutForm.Size = new System.Drawing.Size(184, 23);
			this.btnPutForm.TabIndex = 15;
			this.btnPutForm.Text = "PutForm";
			this.btnPutForm.Click += new System.EventHandler(this.btnPutForm_Click);
			// 
			// dgOrionAPIs
			// 
			this.dgOrionAPIs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dgOrionAPIs.DataMember = "";
			this.dgOrionAPIs.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgOrionAPIs.Location = new System.Drawing.Point(8, 192);
			this.dgOrionAPIs.Name = "dgOrionAPIs";
			this.dgOrionAPIs.Size = new System.Drawing.Size(792, 128);
			this.dgOrionAPIs.TabIndex = 17;
			// 
			// Form_rdmPBSManageTable
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(808, 454);
			this.Controls.Add(this.dgOrionAPIs);
			this.Controls.Add(this.grpBoxGetForm);
			this.Name = "Form_rdmPBSManageTable";
			this.Text = "Form_rdmPBSManageTable";
			this.Controls.SetChildIndex(this.chkGlobalSaveResults, 0);
			this.Controls.SetChildIndex(this.btnLogin, 0);
			this.Controls.SetChildIndex(this.btnLogout, 0);
			this.Controls.SetChildIndex(this.btnClearLog, 0);
			this.Controls.SetChildIndex(this.grpBoxGetForm, 0);
			this.Controls.SetChildIndex(this.dgOrionAPIs, 0);
			this.Controls.SetChildIndex(this.txtLog, 0);
			this.Controls.SetChildIndex(this.txtWebServiceURL, 0);
			this.grpBoxGetForm.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgOrionAPIs)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

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

		private void btnGetForm_Click(object sender, System.EventArgs e)
		{
			dgOrionAPIs.DataSource = null;

			if (!ValidateSession())
				return;


			if (txtTabId.Text == string.Empty)
			{
				this.Log("Enter a Tab Id", true);
				return;
			}

			if (sltFormType.SelectedItem == null)
			{
				this.Log("Select a Tab Type", true);
				return;
			}




			bool bSaveResults = false;
			if (chkGlobalSaveResults.Checked)
			{
				if (folderBrowserDialogGlobalSaveResults.ShowDialog() == DialogResult.OK)
				{
					bSaveResults = true;
				}
				else
				{
					this.Log("Please specify a folder path to save the results.",true);
					return;
				}
			}



			if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
			{

				string sLockId = string.Empty;

				BVWebService.BVWebService oBVWebService = new BVWebService.BVWebService();
				oBVWebService.Url = this.txtWebServiceURL.Text + @"/Service.asmx";


				DataSet oDataSetResult = null;

				switch(sltFormType.SelectedItem.ToString())
				{


					case "MUS":
						this.Log("Start GetMusicCue Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
						oDataSetResult = oBVWebService.GetMusicCue(m_sBVSessionId, int.Parse(txtTabId.Text),chkRequestLock.Checked,out sLockId);

						if (bSaveResults)
						{
							if (folderBrowserDialogGlobalSaveResults.SelectedPath != null)
							{
								string sPath = folderBrowserDialogGlobalSaveResults.SelectedPath + System.IO.Path.DirectorySeparatorChar.ToString();
								sPath += "GetMusicCue" + "_" + DateTime.Now.ToString("yyyyMMdd_hhMM") + ".xml";
								this.Log("Saving Result File to:  " + sPath);
								oDataSetResult.WriteXml(sPath);
							}
						}

						dgOrionAPIs.DataSource = oDataSetResult;
						txtLockId.Text = sLockId;
						this.Log("End GetMusicCue Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );
						break;
					case "VIS":
						this.Log("Start GetVisualArt Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
						oDataSetResult = oBVWebService.GetVisualArt(m_sBVSessionId, int.Parse(txtTabId.Text),chkRequestLock.Checked,out sLockId);
						dgOrionAPIs.DataSource = oDataSetResult;
						if (bSaveResults)
						{
							if (folderBrowserDialogGlobalSaveResults.SelectedPath != null)
							{
								string sPath = folderBrowserDialogGlobalSaveResults.SelectedPath + System.IO.Path.DirectorySeparatorChar.ToString();
								sPath += "GetVisualArt" + "_" + DateTime.Now.ToString("yyyyMMdd_hhMM") + ".xml";
								this.Log("Saving Result File to:  " + sPath);
								oDataSetResult.WriteXml(sPath);
							}
						}
						txtLockId.Text = sLockId;
						this.Log("End GetVisualArt Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );
						break;
					case "UCC":
						this.Log("Start GetUCC Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
						oDataSetResult = oBVWebService.GetUCC(m_sBVSessionId, int.Parse(txtTabId.Text),chkRequestLock.Checked,out sLockId);
						dgOrionAPIs.DataSource = oDataSetResult;
						if (bSaveResults)
						{
							if (folderBrowserDialogGlobalSaveResults.SelectedPath != null)
							{
								string sPath = folderBrowserDialogGlobalSaveResults.SelectedPath + System.IO.Path.DirectorySeparatorChar.ToString();
								sPath += "GetUCC" + "_" + DateTime.Now.ToString("yyyyMMdd_hhMM") + ".xml";
								this.Log("Saving Result File to:  " + sPath);
								oDataSetResult.WriteXml(sPath);
							}
						}
						txtLockId.Text = sLockId;
						this.Log("End GetUCC Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );
						break;
					case "OAC":
						this.Log("Start GetOAC Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
						oDataSetResult = oBVWebService.GetOAC(m_sBVSessionId, int.Parse(txtTabId.Text),chkRequestLock.Checked,out sLockId);
						dgOrionAPIs.DataSource = oDataSetResult;
						if (bSaveResults)
						{
							if (folderBrowserDialogGlobalSaveResults.SelectedPath != null)
							{
								string sPath = folderBrowserDialogGlobalSaveResults.SelectedPath + System.IO.Path.DirectorySeparatorChar.ToString();
								sPath += "GetOAC" + "_" + DateTime.Now.ToString("yyyyMMdd_hhMM") + ".xml";
								this.Log("Saving Result File to:  " + sPath);
								oDataSetResult.WriteXml(sPath);
							}
						}
						txtLockId.Text = sLockId;
						this.Log("End GetOAC Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );
						break;
					case "IWT":
						this.Log("Start GetIWT Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
						oDataSetResult = oBVWebService.GetIWT(m_sBVSessionId, int.Parse(txtTabId.Text),chkRequestLock.Checked,out sLockId);
						dgOrionAPIs.DataSource = oDataSetResult;
						if (bSaveResults)
						{
							if (folderBrowserDialogGlobalSaveResults.SelectedPath != null)
							{
								string sPath = folderBrowserDialogGlobalSaveResults.SelectedPath + System.IO.Path.DirectorySeparatorChar.ToString();
								sPath += "GetIWT" + "_" + DateTime.Now.ToString("yyyyMMdd_hhMM") + ".xml";
								this.Log("Saving Result File to:  " + sPath);
								oDataSetResult.WriteXml(sPath);
							}
						}
						txtLockId.Text = sLockId;
						this.Log("End GetIWT Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );
						break;
					case "FOR":
						this.Log("Start GetFormatSheet Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
						oDataSetResult = oBVWebService.GetFormatSheet(m_sBVSessionId, int.Parse(txtTabId.Text),chkRequestLock.Checked,out sLockId);
						dgOrionAPIs.DataSource = oDataSetResult;
						if (bSaveResults)
						{
							if (folderBrowserDialogGlobalSaveResults.SelectedPath != null)
							{
								string sPath = folderBrowserDialogGlobalSaveResults.SelectedPath + System.IO.Path.DirectorySeparatorChar.ToString();
								sPath += "GetFormatSheet" + "_" + DateTime.Now.ToString("yyyyMMdd_hhMM") + ".xml";
								this.Log("Saving Result File to:  " + sPath);
								oDataSetResult.WriteXml(sPath);
							}
						}
						txtLockId.Text = sLockId;
						this.Log("End GetFormatSheet Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );
						break;





					default:
						break;
				}

			}
			else
			{
				this.Log("Please log in. Session Null", true);
			}
		}


		private void btnPutForm_Click(object sender, System.EventArgs e)
		{
			if (!ValidateSession())
				return;


			if (txtTabId.Text == string.Empty)
			{
				this.Log("Enter a Tab Id", true);
				return;
			}

			if (sltFormType.SelectedItem == null)
			{
				this.Log("Select a Tab Type", true);
				return;
			}


//			if (txtLockId.Text == string.Empty)
//			{
//				this.Log("The form must be locked in order to Update.", true);
//				return;
//			}


			if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
			{

				string sLockId = string.Empty;

				BVWebService.BVWebService oBVWebService = new BVWebService.BVWebService();
				oBVWebService.Url = this.txtWebServiceURL.Text + @"/Service.asmx";


				switch(sltFormType.SelectedItem.ToString())
				{

					case "MUS":
						this.Log("Start PutMusicCue Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
						oBVWebService.PutMusicCue(m_sBVSessionId, txtLockId.Text,(DataSet) dgOrionAPIs.DataSource);
						this.Log("End PutMusicCue Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );
						break;
					case "VIS":
						this.Log("Start PutVisualArt Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
						oBVWebService.PutVisualArt(m_sBVSessionId, txtLockId.Text,(DataSet) dgOrionAPIs.DataSource);
						this.Log("End PutVisualArt Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );
						break;
					case "UCC":
						this.Log("Start PutUCC Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
						oBVWebService.PutUCC(m_sBVSessionId, txtLockId.Text,(DataSet) dgOrionAPIs.DataSource);
						this.Log("End PutUCC Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );
						break;
					case "OAC":
						this.Log("Start PutOAC Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
						oBVWebService.PutOAC(m_sBVSessionId, txtLockId.Text,(DataSet) dgOrionAPIs.DataSource);
						this.Log("End PutOAC Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );
						break;
					case "IWT":
						this.Log("Start PutIWT Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
						oBVWebService.PutIWT(m_sBVSessionId, txtLockId.Text,(DataSet) dgOrionAPIs.DataSource);
						this.Log("End PutIWT Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );
						break;
					case "FOR":
						this.Log("Start PutFormatSheet Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
						oBVWebService.PutFormatSheet(m_sBVSessionId, txtLockId.Text,(DataSet) dgOrionAPIs.DataSource);
						this.Log("End PutFormatSheet Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );
						break;

					default:
						break;
				}

				chkRequestLock.Checked = false;
				dgOrionAPIs.DataSource = null;
				txtLockId.Text = string.Empty;

			}
			else
			{
				this.Log("Please log in. Session Null", true);
			}
		}

		private void btnDeleteForm_Click(object sender, System.EventArgs e)
		{
			if (!ValidateSession())
				return;


			if (txtTabId.Text == string.Empty)
			{
				this.Log("Enter a Tab Id", true);
				return;
			}

			if (sltFormType.SelectedItem == null)
			{
				this.Log("Select a Tab Type", true);
				return;
			}


			if (txtLockId.Text == string.Empty)
			{
				this.Log("The form must be locked in order to Delete.", true);
				return;
			}


			if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
			{

				string sLockId = string.Empty;

				BVWebService.BVWebService oBVWebService = new BVWebService.BVWebService();
				oBVWebService.Url = this.txtWebServiceURL.Text + @"/Service.asmx";


				switch(sltFormType.SelectedItem.ToString())
				{

					case "MUS":
						this.Log("Start DeleteMusicCue Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
						oBVWebService.DeleteMusicCue(m_sBVSessionId, Convert.ToInt32(txtTabId.Text), txtLockId.Text);
						this.Log("End DeleteMusicCue Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );
						break;
					case "VIS":
						this.Log("Start DeleteVisualArt Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
						oBVWebService.DeleteVisualArt(m_sBVSessionId, Convert.ToInt32(txtTabId.Text), txtLockId.Text);
						this.Log("End DeleteVisualArt Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );
						break;
					case "UCC":
						this.Log("Start DeleteUCC Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
						oBVWebService.DeleteUCC(m_sBVSessionId, Convert.ToInt32(txtTabId.Text), txtLockId.Text);
						this.Log("End DeleteUCC Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );
						break;
					case "OAC":
						this.Log("Start DeleteOAC Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
						oBVWebService.DeleteOAC(m_sBVSessionId, Convert.ToInt32(txtTabId.Text), txtLockId.Text);
						this.Log("End DeleteOAC Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );
						break;
					case "IWT":
						this.Log("Start DeleteIWT Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
						oBVWebService.DeleteIWT(m_sBVSessionId, Convert.ToInt32(txtTabId.Text), txtLockId.Text);
						this.Log("End DeleteIWT Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );
						break;
					case "FOR":
						this.Log("Start DeleteFormatSheet Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
						oBVWebService.DeleteFormatSheet(m_sBVSessionId, Convert.ToInt32(txtTabId.Text), txtLockId.Text);
						this.Log("End DeleteFormatSheet Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );
						break;

					default:
						break;
				}

				chkRequestLock.Checked = false;
				dgOrionAPIs.DataSource = null;
				txtLockId.Text = string.Empty;

			}
			else
			{
				this.Log("Please log in. Session Null", true);
			}
		}
	}
}
