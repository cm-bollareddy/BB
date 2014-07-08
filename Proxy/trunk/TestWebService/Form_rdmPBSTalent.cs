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
	/// Summary description for Form_rdmPBSTalent.
	/// </summary>
	public class Form_rdmPBSTalent : Form_Base 
	{
		private System.Windows.Forms.GroupBox grpBoxTalentSearch;
		private System.Windows.Forms.Button btnTalentSearch;
		private System.Windows.Forms.Label lblTalentName;
		private System.Windows.Forms.TextBox txtTalentName;
		private System.Windows.Forms.DataGrid dgOrionAPIs;
		private System.Windows.Forms.GroupBox groupBoxManageTalent;
		private System.Windows.Forms.Button btnGetTalent;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtManageTalentDealId;
		private System.Windows.Forms.TextBox txtManageTalentTalentId;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox sltManageTalentRole;
		private System.Windows.Forms.DataGrid dgManageTalentEpisodeTalent;
		private System.Windows.Forms.DataGrid dgManageTalentTalent;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btnPutTalent;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form_rdmPBSTalent()
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
			this.grpBoxTalentSearch = new System.Windows.Forms.GroupBox();
			this.btnTalentSearch = new System.Windows.Forms.Button();
			this.lblTalentName = new System.Windows.Forms.Label();
			this.txtTalentName = new System.Windows.Forms.TextBox();
			this.dgOrionAPIs = new System.Windows.Forms.DataGrid();
			this.groupBoxManageTalent = new System.Windows.Forms.GroupBox();
			this.dgManageTalentEpisodeTalent = new System.Windows.Forms.DataGrid();
			this.dgManageTalentTalent = new System.Windows.Forms.DataGrid();
			this.sltManageTalentRole = new System.Windows.Forms.ComboBox();
			this.btnGetTalent = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtManageTalentDealId = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtManageTalentTalentId = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.btnPutTalent = new System.Windows.Forms.Button();
			this.grpBoxTalentSearch.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgOrionAPIs)).BeginInit();
			this.groupBoxManageTalent.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgManageTalentEpisodeTalent)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgManageTalentTalent)).BeginInit();
			this.SuspendLayout();
			// 
			// btnLogout
			// 
			this.btnLogout.Location = new System.Drawing.Point(744, 48);
			this.btnLogout.Name = "btnLogout";
			// 
			// btnLogin
			// 
			this.btnLogin.Location = new System.Drawing.Point(744, 24);
			this.btnLogin.Name = "btnLogin";
			// 
			// btnClearLog
			// 
			this.btnClearLog.Location = new System.Drawing.Point(744, 72);
			this.btnClearLog.Name = "btnClearLog";
			// 
			// txtWebServiceURL
			// 
			this.txtWebServiceURL.Name = "txtWebServiceURL";
			this.txtWebServiceURL.Size = new System.Drawing.Size(784, 20);
			// 
			// txtLog
			// 
			this.txtLog.Location = new System.Drawing.Point(0, 478);
			this.txtLog.Name = "txtLog";
			this.txtLog.Size = new System.Drawing.Size(816, 56);
			// 
			// grpBoxTalentSearch
			// 
			this.grpBoxTalentSearch.Controls.Add(this.btnTalentSearch);
			this.grpBoxTalentSearch.Controls.Add(this.lblTalentName);
			this.grpBoxTalentSearch.Controls.Add(this.txtTalentName);
			this.grpBoxTalentSearch.Location = new System.Drawing.Point(16, 48);
			this.grpBoxTalentSearch.Name = "grpBoxTalentSearch";
			this.grpBoxTalentSearch.Size = new System.Drawing.Size(328, 56);
			this.grpBoxTalentSearch.TabIndex = 15;
			this.grpBoxTalentSearch.TabStop = false;
			this.grpBoxTalentSearch.Text = "TalentSearch";
			// 
			// btnTalentSearch
			// 
			this.btnTalentSearch.Location = new System.Drawing.Point(224, 16);
			this.btnTalentSearch.Name = "btnTalentSearch";
			this.btnTalentSearch.Size = new System.Drawing.Size(96, 23);
			this.btnTalentSearch.TabIndex = 15;
			this.btnTalentSearch.Text = "TalentSearch";
			this.btnTalentSearch.Click += new System.EventHandler(this.btnTalentSearch_Click);
			// 
			// lblTalentName
			// 
			this.lblTalentName.Location = new System.Drawing.Point(8, 16);
			this.lblTalentName.Name = "lblTalentName";
			this.lblTalentName.Size = new System.Drawing.Size(72, 16);
			this.lblTalentName.TabIndex = 2;
			this.lblTalentName.Text = "Talent Name";
			// 
			// txtTalentName
			// 
			this.txtTalentName.Location = new System.Drawing.Point(88, 16);
			this.txtTalentName.Name = "txtTalentName";
			this.txtTalentName.Size = new System.Drawing.Size(120, 20);
			this.txtTalentName.TabIndex = 1;
			this.txtTalentName.Text = "Vila, Bob";
			// 
			// dgOrionAPIs
			// 
			this.dgOrionAPIs.DataMember = "";
			this.dgOrionAPIs.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgOrionAPIs.Location = new System.Drawing.Point(16, 368);
			this.dgOrionAPIs.Name = "dgOrionAPIs";
			this.dgOrionAPIs.Size = new System.Drawing.Size(792, 96);
			this.dgOrionAPIs.TabIndex = 16;
			// 
			// groupBoxManageTalent
			// 
			this.groupBoxManageTalent.Controls.Add(this.dgManageTalentEpisodeTalent);
			this.groupBoxManageTalent.Controls.Add(this.dgManageTalentTalent);
			this.groupBoxManageTalent.Controls.Add(this.sltManageTalentRole);
			this.groupBoxManageTalent.Controls.Add(this.btnGetTalent);
			this.groupBoxManageTalent.Controls.Add(this.label1);
			this.groupBoxManageTalent.Controls.Add(this.txtManageTalentDealId);
			this.groupBoxManageTalent.Controls.Add(this.label2);
			this.groupBoxManageTalent.Controls.Add(this.txtManageTalentTalentId);
			this.groupBoxManageTalent.Controls.Add(this.label3);
			this.groupBoxManageTalent.Controls.Add(this.label4);
			this.groupBoxManageTalent.Controls.Add(this.label5);
			this.groupBoxManageTalent.Controls.Add(this.btnPutTalent);
			this.groupBoxManageTalent.Location = new System.Drawing.Point(16, 112);
			this.groupBoxManageTalent.Name = "groupBoxManageTalent";
			this.groupBoxManageTalent.Size = new System.Drawing.Size(792, 248);
			this.groupBoxManageTalent.TabIndex = 15;
			this.groupBoxManageTalent.TabStop = false;
			this.groupBoxManageTalent.Text = "ManageTalent";
			// 
			// dgManageTalentEpisodeTalent
			// 
			this.dgManageTalentEpisodeTalent.DataMember = "";
			this.dgManageTalentEpisodeTalent.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgManageTalentEpisodeTalent.Location = new System.Drawing.Point(320, 32);
			this.dgManageTalentEpisodeTalent.Name = "dgManageTalentEpisodeTalent";
			this.dgManageTalentEpisodeTalent.Size = new System.Drawing.Size(464, 96);
			this.dgManageTalentEpisodeTalent.TabIndex = 18;
			// 
			// dgManageTalentTalent
			// 
			this.dgManageTalentTalent.DataMember = "";
			this.dgManageTalentTalent.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgManageTalentTalent.Location = new System.Drawing.Point(320, 152);
			this.dgManageTalentTalent.Name = "dgManageTalentTalent";
			this.dgManageTalentTalent.Size = new System.Drawing.Size(464, 88);
			this.dgManageTalentTalent.TabIndex = 17;
			// 
			// sltManageTalentRole
			// 
			this.sltManageTalentRole.Items.AddRange(new object[] {
																	 "Composer|-2",
																	 "Artist|-3",
																	 "Talent|-1",
																	 "Anchor|3262447",
																	 "Essayist|3262448",
																	 "Guest|3262449",
																	 "Host|3262450",
																	 "Interviewer|3262451",
																	 "Moderator|3262452",
																	 "Narrator|3262453",
																	 "Other|3262454",
																	 "Panelist|3262455",
																	 "Performer|3262456",
																	 "Reporter|3262457",
																	 "Subject|3262458"});
			this.sltManageTalentRole.Location = new System.Drawing.Point(88, 64);
			this.sltManageTalentRole.Name = "sltManageTalentRole";
			this.sltManageTalentRole.Size = new System.Drawing.Size(121, 21);
			this.sltManageTalentRole.TabIndex = 16;
			// 
			// btnGetTalent
			// 
			this.btnGetTalent.Location = new System.Drawing.Point(88, 96);
			this.btnGetTalent.Name = "btnGetTalent";
			this.btnGetTalent.Size = new System.Drawing.Size(120, 23);
			this.btnGetTalent.TabIndex = 15;
			this.btnGetTalent.Text = "GetTalent";
			this.btnGetTalent.Click += new System.EventHandler(this.btnGetTalent_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Deal Id";
			// 
			// txtManageTalentDealId
			// 
			this.txtManageTalentDealId.Location = new System.Drawing.Point(88, 16);
			this.txtManageTalentDealId.Name = "txtManageTalentDealId";
			this.txtManageTalentDealId.Size = new System.Drawing.Size(120, 20);
			this.txtManageTalentDealId.TabIndex = 1;
			this.txtManageTalentDealId.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Talent Id";
			// 
			// txtManageTalentTalentId
			// 
			this.txtManageTalentTalentId.Location = new System.Drawing.Point(88, 40);
			this.txtManageTalentTalentId.Name = "txtManageTalentTalentId";
			this.txtManageTalentTalentId.Size = new System.Drawing.Size(120, 20);
			this.txtManageTalentTalentId.TabIndex = 1;
			this.txtManageTalentTalentId.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 16);
			this.label3.TabIndex = 2;
			this.label3.Text = "Role";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(320, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(120, 16);
			this.label4.TabIndex = 2;
			this.label4.Text = "Episode Talent";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(320, 136);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(72, 16);
			this.label5.TabIndex = 2;
			this.label5.Text = "Talent";
			// 
			// btnPutTalent
			// 
			this.btnPutTalent.Location = new System.Drawing.Point(88, 128);
			this.btnPutTalent.Name = "btnPutTalent";
			this.btnPutTalent.Size = new System.Drawing.Size(120, 23);
			this.btnPutTalent.TabIndex = 15;
			this.btnPutTalent.Text = "PutTalent";
			this.btnPutTalent.Click += new System.EventHandler(this.btnPutTalent_Click);
			// 
			// Form_rdmPBSTalent
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(816, 534);
			this.Controls.Add(this.dgOrionAPIs);
			this.Controls.Add(this.grpBoxTalentSearch);
			this.Controls.Add(this.groupBoxManageTalent);
			this.Name = "Form_rdmPBSTalent";
			this.Text = "Form_rdmPBSTalent";
			this.Controls.SetChildIndex(this.btnLogin, 0);
			this.Controls.SetChildIndex(this.btnLogout, 0);
			this.Controls.SetChildIndex(this.btnClearLog, 0);
			this.Controls.SetChildIndex(this.groupBoxManageTalent, 0);
			this.Controls.SetChildIndex(this.txtLog, 0);
			this.Controls.SetChildIndex(this.txtWebServiceURL, 0);
			this.Controls.SetChildIndex(this.grpBoxTalentSearch, 0);
			this.Controls.SetChildIndex(this.dgOrionAPIs, 0);
			this.grpBoxTalentSearch.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgOrionAPIs)).EndInit();
			this.groupBoxManageTalent.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgManageTalentEpisodeTalent)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgManageTalentTalent)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void btnTalentSearch_Click(object sender, System.EventArgs e)
		{
			dgOrionAPIs.DataSource = null;

			if (!ValidateSession())
				return;

			if (txtTalentName.Text.ToString()== string.Empty)
			{
				this.Log("Enter a Talent Name for Talent Search", true);
				return;
			}

			if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
			{
				BVWebService.BVWebService oBVWebService = new BVWebService.BVWebService();
				oBVWebService.Url = this.txtWebServiceURL.Text + @"/Service.asmx";

				TestWebService.BVWebService.SearchCriterion[] oArrCriteria = new SearchCriterion [1];

				this.Log("Start TalentSearch Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
				DataSet oDataSetResult = oBVWebService.TalentSearch(m_sBVSessionId,TestWebServiceHelper.SEARCH_WILDCARD + txtTalentName.Text + TestWebServiceHelper.SEARCH_WILDCARD );
				dgOrionAPIs.DataSource = oDataSetResult;
				this.Log("End TalentSearch Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );
			}
			else
			{
				this.Log("Please log in. Session Null", true);
			}
		}

		private void btnGetTalent_Click(object sender, System.EventArgs e)
		{
			dgOrionAPIs.DataSource = null;
			dgManageTalentEpisodeTalent.DataSource = null;
			dgManageTalentTalent.DataSource = null;


			if (!ValidateSession())
				return;

			if (txtManageTalentDealId.Text.ToString()== string.Empty)
			{
				this.Log("Enter a Deal Id for Manage Talent", true);
				return;
			}

			if (txtManageTalentTalentId.Text.ToString()== string.Empty)
			{
				this.Log("Enter a Talent Id for Manage Talent", true);
				return;
			}


			if (sltManageTalentRole.SelectedItem == null || sltManageTalentRole.SelectedItem.ToString()== string.Empty)
			{
				this.Log("Enter a Talent Role for Manage Talent", true);
				return;
			}

			if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
			{
				BVWebService.BVWebService oBVWebService = new BVWebService.BVWebService();
				oBVWebService.Url = this.txtWebServiceURL.Text + @"/Service.asmx";

				TestWebService.BVWebService.SearchCriterion[] oArrCriteria = new SearchCriterion [1];

				this.Log("Start GetTalent Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
				DataSet oDataSetEpisodeTalent = new DataSet();
				DataSet oDataSetTalent = new DataSet();
				
				DataSet oDataSetResult = oBVWebService.GetTalent(m_sBVSessionId,int.Parse(txtManageTalentDealId.Text), int.Parse(txtManageTalentTalentId.Text),TestWebServiceHelper.GetSelectedItemValue(sltManageTalentRole),out oDataSetEpisodeTalent, out oDataSetTalent);
				dgOrionAPIs.DataSource = oDataSetResult;
				dgManageTalentEpisodeTalent.DataSource = oDataSetEpisodeTalent;
				dgManageTalentTalent.DataSource = oDataSetTalent;


				this.Log("End GetTalent Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );
			}
			else
			{
				this.Log("Please log in. Session Null", true);
			}
		}

		private void btnPutTalent_Click(object sender, System.EventArgs e)
		{
			if (!ValidateSession())
				return;

			if (dgManageTalentEpisodeTalent.DataSource == null)
			{
				this.Log("Put Talent requires Episode Talent data.  Perform Get Talent first.", true);
				return;
			}

			if (dgManageTalentTalent.DataSource == null)
			{
				this.Log("Put Talent requires Talent data.  Perform Get Talent first.", true);
				return;
			}

			if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
			{
				BVWebService.BVWebService oBVWebService = new BVWebService.BVWebService();
				oBVWebService.Url = this.txtWebServiceURL.Text + @"/Service.asmx";

				this.Log("Start PutTalent Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
				oBVWebService.PutTalent(m_sBVSessionId,(DataSet) dgManageTalentEpisodeTalent.DataSource, (DataSet) dgManageTalentTalent.DataSource);
				this.Log("End PutTalent Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );

				dgOrionAPIs.DataSource = null;
				dgManageTalentEpisodeTalent.DataSource = null;
				dgManageTalentTalent.DataSource = null;
			}
			else
			{
				this.Log("Please log in. Session Null", true);
			}
		}


	}
}
