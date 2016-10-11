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
	/// Summary description for Form_rdmPBSMediaInventory.
	/// </summary>
	public class Form_rdmPBSMediaInventory : Form_Base
	{
		private System.Windows.Forms.GroupBox grpBoxMediaInventoryRevision;
		private System.Windows.Forms.Button btnReleaseLock;
		private System.Windows.Forms.CheckBox chkRequestLock;
		private System.Windows.Forms.Label lblLockId;
		private System.Windows.Forms.TextBox txtLockId;
		private System.Windows.Forms.Label lblGetMasterDealHelp;
		private System.Windows.Forms.Button btnGetMediaInventoryRevision;
		private System.Windows.Forms.Label lblMediaInventoryId;
		private System.Windows.Forms.TextBox txtMediaInventoryId;
		private System.Windows.Forms.DataGrid dgOrionAPIs;
		private System.Windows.Forms.Button btnPutMediaInventoryRevision;
		private System.Windows.Forms.Button btnCreateMediaInventoryRevision;
		private System.Windows.Forms.Button btnGetBarcode;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Button btnGetFMI;
		private System.Windows.Forms.Button btnPutFMI;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogGetBarcode;
		private System.Windows.Forms.Button btnGetBarcodeLocalPath;
		private System.Windows.Forms.TextBox txtGetBarcodeSaveDirectory;
		private System.ComponentModel.IContainer components;

		public Form_rdmPBSMediaInventory()
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
			this.components = new System.ComponentModel.Container();
			this.grpBoxMediaInventoryRevision = new System.Windows.Forms.GroupBox();
			this.btnGetFMI = new System.Windows.Forms.Button();
			this.btnPutFMI = new System.Windows.Forms.Button();
			this.btnCreateMediaInventoryRevision = new System.Windows.Forms.Button();
			this.btnReleaseLock = new System.Windows.Forms.Button();
			this.chkRequestLock = new System.Windows.Forms.CheckBox();
			this.lblLockId = new System.Windows.Forms.Label();
			this.txtLockId = new System.Windows.Forms.TextBox();
			this.lblGetMasterDealHelp = new System.Windows.Forms.Label();
			this.btnGetMediaInventoryRevision = new System.Windows.Forms.Button();
			this.lblMediaInventoryId = new System.Windows.Forms.Label();
			this.txtMediaInventoryId = new System.Windows.Forms.TextBox();
			this.btnPutMediaInventoryRevision = new System.Windows.Forms.Button();
			this.btnGetBarcode = new System.Windows.Forms.Button();
			this.btnGetBarcodeLocalPath = new System.Windows.Forms.Button();
			this.txtGetBarcodeSaveDirectory = new System.Windows.Forms.TextBox();
			this.dgOrionAPIs = new System.Windows.Forms.DataGrid();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.folderBrowserDialogGetBarcode = new System.Windows.Forms.FolderBrowserDialog();
			this.grpBoxMediaInventoryRevision.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgOrionAPIs)).BeginInit();
			this.SuspendLayout();
			// 
			// btnLogout
			// 
			this.btnLogout.Location = new System.Drawing.Point(720, 64);
			this.btnLogout.Name = "btnLogout";
			// 
			// btnLogin
			// 
			this.btnLogin.Location = new System.Drawing.Point(720, 40);
			this.btnLogin.Name = "btnLogin";
			// 
			// btnClearLog
			// 
			this.btnClearLog.Location = new System.Drawing.Point(720, 88);
			this.btnClearLog.Name = "btnClearLog";
			// 
			// txtWebServiceURL
			// 
			this.txtWebServiceURL.Name = "txtWebServiceURL";
			// 
			// txtLog
			// 
			this.txtLog.Location = new System.Drawing.Point(0, 358);
			this.txtLog.Name = "txtLog";
			this.txtLog.Size = new System.Drawing.Size(792, 112);
			// 
			// grpBoxMediaInventoryRevision
			// 
			this.grpBoxMediaInventoryRevision.Controls.Add(this.btnGetFMI);
			this.grpBoxMediaInventoryRevision.Controls.Add(this.btnPutFMI);
			this.grpBoxMediaInventoryRevision.Controls.Add(this.btnCreateMediaInventoryRevision);
			this.grpBoxMediaInventoryRevision.Controls.Add(this.btnReleaseLock);
			this.grpBoxMediaInventoryRevision.Controls.Add(this.chkRequestLock);
			this.grpBoxMediaInventoryRevision.Controls.Add(this.lblLockId);
			this.grpBoxMediaInventoryRevision.Controls.Add(this.txtLockId);
			this.grpBoxMediaInventoryRevision.Controls.Add(this.lblGetMasterDealHelp);
			this.grpBoxMediaInventoryRevision.Controls.Add(this.btnGetMediaInventoryRevision);
			this.grpBoxMediaInventoryRevision.Controls.Add(this.lblMediaInventoryId);
			this.grpBoxMediaInventoryRevision.Controls.Add(this.txtMediaInventoryId);
			this.grpBoxMediaInventoryRevision.Controls.Add(this.btnPutMediaInventoryRevision);
			this.grpBoxMediaInventoryRevision.Controls.Add(this.btnGetBarcode);
			this.grpBoxMediaInventoryRevision.Controls.Add(this.btnGetBarcodeLocalPath);
			this.grpBoxMediaInventoryRevision.Controls.Add(this.txtGetBarcodeSaveDirectory);
			this.grpBoxMediaInventoryRevision.Location = new System.Drawing.Point(16, 32);
			this.grpBoxMediaInventoryRevision.Name = "grpBoxMediaInventoryRevision";
			this.grpBoxMediaInventoryRevision.Size = new System.Drawing.Size(608, 160);
			this.grpBoxMediaInventoryRevision.TabIndex = 17;
			this.grpBoxMediaInventoryRevision.TabStop = false;
			this.grpBoxMediaInventoryRevision.Text = "MediaInventoryRevision";
			// 
			// btnGetFMI
			// 
			this.btnGetFMI.Location = new System.Drawing.Point(200, 40);
			this.btnGetFMI.Name = "btnGetFMI";
			this.btnGetFMI.Size = new System.Drawing.Size(184, 23);
			this.btnGetFMI.TabIndex = 42;
			this.btnGetFMI.Text = "GetFeatureMediaInventory";
			this.btnGetFMI.Click += new System.EventHandler(this.btnGetFMI_Click);
			// 
			// btnPutFMI
			// 
			this.btnPutFMI.Location = new System.Drawing.Point(392, 40);
			this.btnPutFMI.Name = "btnPutFMI";
			this.btnPutFMI.Size = new System.Drawing.Size(184, 23);
			this.btnPutFMI.TabIndex = 41;
			this.btnPutFMI.Text = "PutFeatureMediaInventory";
			this.btnPutFMI.Click += new System.EventHandler(this.btnPutFMI_Click);
			// 
			// btnCreateMediaInventoryRevision
			// 
			this.btnCreateMediaInventoryRevision.Location = new System.Drawing.Point(392, 64);
			this.btnCreateMediaInventoryRevision.Name = "btnCreateMediaInventoryRevision";
			this.btnCreateMediaInventoryRevision.Size = new System.Drawing.Size(184, 23);
			this.btnCreateMediaInventoryRevision.TabIndex = 40;
			this.btnCreateMediaInventoryRevision.Text = "CreateMediaInventoryRevision";
			this.btnCreateMediaInventoryRevision.Click += new System.EventHandler(this.btnCreateMediaInventoryRevision_Click);
			// 
			// btnReleaseLock
			// 
			this.btnReleaseLock.Location = new System.Drawing.Point(200, 64);
			this.btnReleaseLock.Name = "btnReleaseLock";
			this.btnReleaseLock.Size = new System.Drawing.Size(184, 23);
			this.btnReleaseLock.TabIndex = 39;
			this.btnReleaseLock.Text = "ReleaseLock";
			this.btnReleaseLock.Click += new System.EventHandler(this.btnReleaseLock_Click);
			// 
			// chkRequestLock
			// 
			this.chkRequestLock.Location = new System.Drawing.Point(72, 64);
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
			this.txtLockId.Location = new System.Drawing.Point(72, 40);
			this.txtLockId.Name = "txtLockId";
			this.txtLockId.Size = new System.Drawing.Size(120, 20);
			this.txtLockId.TabIndex = 36;
			this.txtLockId.Text = "";
			// 
			// lblGetMasterDealHelp
			// 
			this.lblGetMasterDealHelp.Location = new System.Drawing.Point(56, 104);
			this.lblGetMasterDealHelp.Name = "lblGetMasterDealHelp";
			this.lblGetMasterDealHelp.Size = new System.Drawing.Size(100, 16);
			this.lblGetMasterDealHelp.TabIndex = 34;
			this.lblGetMasterDealHelp.Text = "Results in Datagrid";
			// 
			// btnGetMediaInventoryRevision
			// 
			this.btnGetMediaInventoryRevision.Location = new System.Drawing.Point(200, 16);
			this.btnGetMediaInventoryRevision.Name = "btnGetMediaInventoryRevision";
			this.btnGetMediaInventoryRevision.Size = new System.Drawing.Size(184, 23);
			this.btnGetMediaInventoryRevision.TabIndex = 15;
			this.btnGetMediaInventoryRevision.Text = "GetMediaInventoryRevision";
			this.btnGetMediaInventoryRevision.Click += new System.EventHandler(this.btnGetMediaInventoryRevision_Click);
			// 
			// lblMediaInventoryId
			// 
			this.lblMediaInventoryId.Location = new System.Drawing.Point(16, 16);
			this.lblMediaInventoryId.Name = "lblMediaInventoryId";
			this.lblMediaInventoryId.Size = new System.Drawing.Size(56, 16);
			this.lblMediaInventoryId.TabIndex = 2;
			this.lblMediaInventoryId.Text = "MI Id";
			// 
			// txtMediaInventoryId
			// 
			this.txtMediaInventoryId.Location = new System.Drawing.Point(72, 16);
			this.txtMediaInventoryId.Name = "txtMediaInventoryId";
			this.txtMediaInventoryId.Size = new System.Drawing.Size(120, 20);
			this.txtMediaInventoryId.TabIndex = 1;
			this.txtMediaInventoryId.Text = "23014256";
			// 
			// btnPutMediaInventoryRevision
			// 
			this.btnPutMediaInventoryRevision.Location = new System.Drawing.Point(392, 16);
			this.btnPutMediaInventoryRevision.Name = "btnPutMediaInventoryRevision";
			this.btnPutMediaInventoryRevision.Size = new System.Drawing.Size(184, 23);
			this.btnPutMediaInventoryRevision.TabIndex = 15;
			this.btnPutMediaInventoryRevision.Text = "PutMediaInventoryRevision";
			this.btnPutMediaInventoryRevision.Click += new System.EventHandler(this.btnPutMediaInventoryRevision_Click);
			// 
			// btnGetBarcode
			// 
			this.btnGetBarcode.Location = new System.Drawing.Point(392, 96);
			this.btnGetBarcode.Name = "btnGetBarcode";
			this.btnGetBarcode.Size = new System.Drawing.Size(184, 23);
			this.btnGetBarcode.TabIndex = 40;
			this.btnGetBarcode.Text = "GetBarcode";
			this.btnGetBarcode.Click += new System.EventHandler(this.btnGetBarcode_Click);
			// 
			// btnGetBarcodeLocalPath
			// 
			this.btnGetBarcodeLocalPath.Location = new System.Drawing.Point(392, 128);
			this.btnGetBarcodeLocalPath.Name = "btnGetBarcodeLocalPath";
			this.btnGetBarcodeLocalPath.Size = new System.Drawing.Size(40, 23);
			this.btnGetBarcodeLocalPath.TabIndex = 40;
			this.btnGetBarcodeLocalPath.Text = "Path";
			this.btnGetBarcodeLocalPath.Click += new System.EventHandler(this.btnGetBarcodeLocalPath_Click);
			// 
			// txtGetBarcodeSaveDirectory
			// 
			this.txtGetBarcodeSaveDirectory.Location = new System.Drawing.Point(440, 128);
			this.txtGetBarcodeSaveDirectory.Name = "txtGetBarcodeSaveDirectory";
			this.txtGetBarcodeSaveDirectory.Size = new System.Drawing.Size(136, 20);
			this.txtGetBarcodeSaveDirectory.TabIndex = 1;
			this.txtGetBarcodeSaveDirectory.Text = "";
			// 
			// dgOrionAPIs
			// 
			this.dgOrionAPIs.DataMember = "";
			this.dgOrionAPIs.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgOrionAPIs.Location = new System.Drawing.Point(16, 200);
			this.dgOrionAPIs.Name = "dgOrionAPIs";
			this.dgOrionAPIs.Size = new System.Drawing.Size(768, 144);
			this.dgOrionAPIs.TabIndex = 18;
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// Form_rdmPBSMediaInventory
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(792, 470);
			this.Controls.Add(this.dgOrionAPIs);
			this.Controls.Add(this.grpBoxMediaInventoryRevision);
			this.Name = "Form_rdmPBSMediaInventory";
			this.Text = "Form_rdmPBSMediaInventory";
			this.Controls.SetChildIndex(this.btnLogin, 0);
			this.Controls.SetChildIndex(this.btnLogout, 0);
			this.Controls.SetChildIndex(this.btnClearLog, 0);
			this.Controls.SetChildIndex(this.txtLog, 0);
			this.Controls.SetChildIndex(this.txtWebServiceURL, 0);
			this.Controls.SetChildIndex(this.grpBoxMediaInventoryRevision, 0);
			this.Controls.SetChildIndex(this.dgOrionAPIs, 0);
			this.grpBoxMediaInventoryRevision.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgOrionAPIs)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion



		private void btnGetMediaInventoryRevision_Click(object sender, System.EventArgs e)
		{
			dgOrionAPIs.DataSource = null;

			if (!ValidateSession())
				return;


			if (txtMediaInventoryId.Text == string.Empty)
			{
				this.Log("Enter a Media Inventory Id", true);
				return;
			}

		
			if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
			{

				string sLockId = string.Empty;

				BVWebService.BVWebService oBVWebService = new BVWebService.BVWebService();
				oBVWebService.Url = this.txtWebServiceURL.Text + @"/Service.asmx";


				DataSet oDataSetResult = null;

				this.Log("Start GetMediaInventoryRevision Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
				oDataSetResult = oBVWebService.GetMediaInventoryRevision(m_sBVSessionId, int.Parse(txtMediaInventoryId.Text), chkRequestLock.Checked,out sLockId);
				dgOrionAPIs.DataSource = oDataSetResult;
				txtLockId.Text = sLockId;
				this.Log("End GetMediaInventoryRevision Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );

			}
			else
			{
				this.Log("Please log in. Session Null", true);
			}
		
		}

		private void btnPutMediaInventoryRevision_Click(object sender, System.EventArgs e)
		{
			if (!ValidateSession())
				return;


			if (txtMediaInventoryId.Text == string.Empty)
			{
				this.Log("Enter a Media Inventory Id", true);
				return;
			}
			if (txtLockId.Text == string.Empty)
			{
	
				txtLockId.Text = null;

//				this.Log("A record lock is required for updates.", true);
//				return;
			}
		
			if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
			{

				string sLockId = string.Empty;

				BVWebService.BVWebService oBVWebService = new BVWebService.BVWebService();
				oBVWebService.Url = this.txtWebServiceURL.Text + @"/Service.asmx";


				

				this.Log("Start PutMediaInventoryRevision Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
				oBVWebService.PutMediaInventoryRevision(m_sBVSessionId, txtLockId.Text, (DataSet) dgOrionAPIs.DataSource);
				dgOrionAPIs.DataSource = null;
				txtLockId.Text = string.Empty;
				chkRequestLock.Checked = false;
				this.Log("End PutMediaInventoryRevision Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );

			}
			else
			{
				this.Log("Please log in. Session Null", true);
			}
		}

		private void btnCreateMediaInventoryRevision_Click(object sender, System.EventArgs e)
		{
			if (!ValidateSession())
				return;


			if (txtMediaInventoryId.Text == string.Empty)
			{
				this.Log("Enter a Media Inventory Id", true);
				return;
			}
			if (txtLockId.Text == string.Empty)
			{
				this.Log("A record lock is required for creation.", true);
				return;
			}
		
			if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
			{

				string sLockId = string.Empty;

				BVWebService.BVWebService oBVWebService = new BVWebService.BVWebService();
				oBVWebService.Url = this.txtWebServiceURL.Text + @"/Service.asmx";

				this.Log("Start GetIDs Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
				int[] oNewId = oBVWebService.GetIDs(1);
				this.Log("Finish GetIDs Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
				

				this.Log("Start CreateMediaInventoryRevision Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
				oBVWebService.CreateMediaInventoryRevision(m_sBVSessionId, txtLockId.Text, int.Parse(txtMediaInventoryId.Text),oNewId[0]);
				dgOrionAPIs.DataSource = null;
				txtLockId.Text = string.Empty;
				chkRequestLock.Checked = false;
				this.Log("End CreateMediaInventoryRevision Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );

			}
			else
			{
				this.Log("Please log in. Session Null", true);
			}
		
		}

		private void btnGetBarcode_Click(object sender, System.EventArgs e)
		{
			if (!ValidateSession())
				return;


			if (txtMediaInventoryId.Text == string.Empty)
			{
				this.Log("Enter a Media Inventory Id", true);
				return;
			}
		
			if (txtGetBarcodeSaveDirectory.Text == string.Empty)
			{
				this.Log("Select a path to save the Barcode File", true);
				return;
			}

			if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
			{

				BVWebService.BVWebService oBVWebService = new BVWebService.BVWebService();
				oBVWebService.Url = this.txtWebServiceURL.Text + @"/Service.asmx";

				this.Log("Start GetBarCode Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
				System.Byte[] oBarcode = oBVWebService.GetBarCode(m_sBVSessionId, int.Parse(txtMediaInventoryId.Text));
				dgOrionAPIs.DataSource = null;
				this.Log("End GetBarCode Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );

				this.Log("Start GetBarCode Write File Sequence :StartTime : " + DateTime.Now.ToLongTimeString());

				System.IO.BinaryWriter oBinaryWriter = null;
				try
				{
					oBinaryWriter = new System.IO.BinaryWriter(System.IO.File.Open(txtGetBarcodeSaveDirectory.Text + "\\" + "GetBarCode_" + System.DateTime.Now.ToString("yyyy.MM.dd_HH.mm.ss.ffff") +".pdf", System.IO.FileMode.Create));
					oBinaryWriter.Write(oBarcode,0,oBarcode.Length);
				}
				catch(Exception oException)
				{
					this.Log("Error writing Barcode file output." + oException.ToString(), true);
				}
				finally
				{
					if (oBinaryWriter != null)
					{
						oBinaryWriter.Flush();
						oBinaryWriter.Close();
					}
				}
				this.Log("End GetBarCode Write File Sequence :StartTime : " + DateTime.Now.ToLongTimeString());


			}
			else
			{
				this.Log("Please log in. Session Null", true);
			}
		
		}

		private void btnGetFMI_Click(object sender, System.EventArgs e)
		{
			dgOrionAPIs.DataSource = null;

			if (!ValidateSession())
				return;


			if (txtMediaInventoryId.Text == string.Empty)
			{
				this.Log("Enter a Media Inventory Id", true);
				return;
			}

		
			if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
			{

				string sLockId = string.Empty;

				BVWebService.BVWebService oBVWebService = new BVWebService.BVWebService();
				oBVWebService.Url = this.txtWebServiceURL.Text + @"/Service.asmx";


				DataSet oDataSetResult = null;

				this.Log("Start GetFeatureMediaInventory Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
				oDataSetResult = oBVWebService.GetFeatureMediaInventory(m_sBVSessionId, int.Parse(txtMediaInventoryId.Text), chkRequestLock.Checked,out sLockId);
				dgOrionAPIs.DataSource = oDataSetResult;
				txtLockId.Text = sLockId;
				this.Log("End GetFeatureMediaInventory Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );

			}
			else
			{
				this.Log("Please log in. Session Null", true);
			}
		}

		private void btnPutFMI_Click(object sender, System.EventArgs e)
		{
			if (!ValidateSession())
				return;


			if (txtMediaInventoryId.Text == string.Empty)
			{
				this.Log("Enter a Media Inventory Id", true);
				return;
			}
			if (txtLockId.Text == string.Empty)
			{
				this.Log("A record lock is required for updates.", true);
				return;
			}
		
			if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
			{

				string sLockId = string.Empty;

				BVWebService.BVWebService oBVWebService = new BVWebService.BVWebService();
				oBVWebService.Url = this.txtWebServiceURL.Text + @"/Service.asmx";


				

				this.Log("Start PutFeatureMediaInventory Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
				oBVWebService.PutFeatureMediaInventory(m_sBVSessionId, txtLockId.Text, (DataSet) dgOrionAPIs.DataSource);
				dgOrionAPIs.DataSource = null;
				txtLockId.Text = string.Empty;
				chkRequestLock.Checked = false;
				this.Log("End PutFeatureMediaInventory Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );

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


		private void btnGetBarcodeLocalPath_Click(object sender, System.EventArgs e)
		{
			if (folderBrowserDialogGetBarcode.ShowDialog() == DialogResult.OK) 
			{
				txtGetBarcodeSaveDirectory.Text = folderBrowserDialogGetBarcode.SelectedPath;
			}
		}


	}
}
