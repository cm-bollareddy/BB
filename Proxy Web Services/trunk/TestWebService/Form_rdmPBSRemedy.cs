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
	/// Summary description for Form_rdmPBSRemedy.
	/// </summary>
	public class Form_rdmPBSRemedy : Form_Base
	{
		private System.Windows.Forms.GroupBox grpBoxGetDiscrepancyProgram;
		private System.Windows.Forms.GroupBox groupBoxInput;
		private System.Windows.Forms.GroupBox groupBoxOutput;
		private System.Windows.Forms.DateTimePicker dtDiscrepancyStart;
		private System.Windows.Forms.Button btnGetDiscrepancyProgram;
		private System.Windows.Forms.Label lblChannel;
		private System.Windows.Forms.TextBox txtChannel;
		private System.Windows.Forms.Label lblDiscrepancyStart;
		private System.Windows.Forms.TextBox txtPackageNumber;
		private System.Windows.Forms.Label lblPackageNumber;
		private System.Windows.Forms.TextBox txtPackageTitle;
		private System.Windows.Forms.Label lblPackageTitle;
		private System.Windows.Forms.Label lblProgramTitle;
		private System.Windows.Forms.TextBox txtProgramTitle;
		private System.Windows.Forms.TextBox txtSeriesTitle;
		private System.Windows.Forms.Label lblSeriesTitle;
		private System.Windows.Forms.TextBox txtProgramEpisodeTitle;
		private System.Windows.Forms.Label lblProgramEpisodeTitle;
		private System.Windows.Forms.Label lblScheduleDate;
		private System.Windows.Forms.TextBox txtScheduleDate;
		private System.Windows.Forms.Label lblScheduleDuration;
		private System.Windows.Forms.TextBox txtScheduleDuration;
		private System.Windows.Forms.Label lblResult;
		private System.Windows.Forms.TextBox txtResult;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form_rdmPBSRemedy()
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
			this.grpBoxGetDiscrepancyProgram = new System.Windows.Forms.GroupBox();
			this.groupBoxInput = new System.Windows.Forms.GroupBox();
			this.dtDiscrepancyStart = new System.Windows.Forms.DateTimePicker();
			this.btnGetDiscrepancyProgram = new System.Windows.Forms.Button();
			this.lblChannel = new System.Windows.Forms.Label();
			this.txtChannel = new System.Windows.Forms.TextBox();
			this.lblDiscrepancyStart = new System.Windows.Forms.Label();
			this.groupBoxOutput = new System.Windows.Forms.GroupBox();
			this.txtPackageNumber = new System.Windows.Forms.TextBox();
			this.lblPackageNumber = new System.Windows.Forms.Label();
			this.txtPackageTitle = new System.Windows.Forms.TextBox();
			this.lblPackageTitle = new System.Windows.Forms.Label();
			this.lblProgramTitle = new System.Windows.Forms.Label();
			this.txtProgramTitle = new System.Windows.Forms.TextBox();
			this.txtSeriesTitle = new System.Windows.Forms.TextBox();
			this.lblSeriesTitle = new System.Windows.Forms.Label();
			this.txtProgramEpisodeTitle = new System.Windows.Forms.TextBox();
			this.lblProgramEpisodeTitle = new System.Windows.Forms.Label();
			this.lblScheduleDate = new System.Windows.Forms.Label();
			this.txtScheduleDate = new System.Windows.Forms.TextBox();
			this.lblScheduleDuration = new System.Windows.Forms.Label();
			this.txtScheduleDuration = new System.Windows.Forms.TextBox();
			this.lblResult = new System.Windows.Forms.Label();
			this.txtResult = new System.Windows.Forms.TextBox();
			this.grpBoxGetDiscrepancyProgram.SuspendLayout();
			this.groupBoxInput.SuspendLayout();
			this.groupBoxOutput.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnLogout
			// 
			this.btnLogout.Location = new System.Drawing.Point(592, 48);
			this.btnLogout.Name = "btnLogout";
			// 
			// btnLogin
			// 
			this.btnLogin.Location = new System.Drawing.Point(592, 24);
			this.btnLogin.Name = "btnLogin";
			// 
			// btnClearLog
			// 
			this.btnClearLog.Location = new System.Drawing.Point(592, 72);
			this.btnClearLog.Name = "btnClearLog";
			// 
			// txtWebServiceURL
			// 
			this.txtWebServiceURL.Name = "txtWebServiceURL";
			this.txtWebServiceURL.Size = new System.Drawing.Size(784, 20);
			// 
			// txtLog
			// 
			this.txtLog.Location = new System.Drawing.Point(0, 294);
			this.txtLog.Name = "txtLog";
			this.txtLog.Size = new System.Drawing.Size(664, 72);
			// 
			// grpBoxGetDiscrepancyProgram
			// 
			this.grpBoxGetDiscrepancyProgram.Controls.Add(this.groupBoxInput);
			this.grpBoxGetDiscrepancyProgram.Controls.Add(this.groupBoxOutput);
			this.grpBoxGetDiscrepancyProgram.Location = new System.Drawing.Point(16, 24);
			this.grpBoxGetDiscrepancyProgram.Name = "grpBoxGetDiscrepancyProgram";
			this.grpBoxGetDiscrepancyProgram.Size = new System.Drawing.Size(568, 264);
			this.grpBoxGetDiscrepancyProgram.TabIndex = 17;
			this.grpBoxGetDiscrepancyProgram.TabStop = false;
			this.grpBoxGetDiscrepancyProgram.Text = "GetDiscrepancyProgram";
			// 
			// groupBoxInput
			// 
			this.groupBoxInput.Controls.Add(this.dtDiscrepancyStart);
			this.groupBoxInput.Controls.Add(this.btnGetDiscrepancyProgram);
			this.groupBoxInput.Controls.Add(this.lblChannel);
			this.groupBoxInput.Controls.Add(this.txtChannel);
			this.groupBoxInput.Controls.Add(this.lblDiscrepancyStart);
			this.groupBoxInput.Location = new System.Drawing.Point(16, 24);
			this.groupBoxInput.Name = "groupBoxInput";
			this.groupBoxInput.Size = new System.Drawing.Size(248, 232);
			this.groupBoxInput.TabIndex = 38;
			this.groupBoxInput.TabStop = false;
			this.groupBoxInput.Text = "Input";
			// 
			// dtDiscrepancyStart
			// 
			this.dtDiscrepancyStart.Location = new System.Drawing.Point(104, 48);
			this.dtDiscrepancyStart.Name = "dtDiscrepancyStart";
			this.dtDiscrepancyStart.Size = new System.Drawing.Size(128, 20);
			this.dtDiscrepancyStart.TabIndex = 42;
			// 
			// btnGetDiscrepancyProgram
			// 
			this.btnGetDiscrepancyProgram.Location = new System.Drawing.Point(32, 80);
			this.btnGetDiscrepancyProgram.Name = "btnGetDiscrepancyProgram";
			this.btnGetDiscrepancyProgram.Size = new System.Drawing.Size(168, 23);
			this.btnGetDiscrepancyProgram.TabIndex = 41;
			this.btnGetDiscrepancyProgram.Text = "GetDiscrepancyProgram";
			this.btnGetDiscrepancyProgram.Click += new System.EventHandler(this.btnGetDiscrepancyProgram_Click);
			// 
			// lblChannel
			// 
			this.lblChannel.Location = new System.Drawing.Point(8, 24);
			this.lblChannel.Name = "lblChannel";
			this.lblChannel.Size = new System.Drawing.Size(96, 16);
			this.lblChannel.TabIndex = 40;
			this.lblChannel.Text = "Channel";
			// 
			// txtChannel
			// 
			this.txtChannel.Location = new System.Drawing.Point(104, 24);
			this.txtChannel.Name = "txtChannel";
			this.txtChannel.Size = new System.Drawing.Size(128, 20);
			this.txtChannel.TabIndex = 38;
			this.txtChannel.Text = "";
			// 
			// lblDiscrepancyStart
			// 
			this.lblDiscrepancyStart.Location = new System.Drawing.Point(8, 48);
			this.lblDiscrepancyStart.Name = "lblDiscrepancyStart";
			this.lblDiscrepancyStart.Size = new System.Drawing.Size(96, 16);
			this.lblDiscrepancyStart.TabIndex = 39;
			this.lblDiscrepancyStart.Text = "Discrepancy Start";
			// 
			// groupBoxOutput
			// 
			this.groupBoxOutput.Controls.Add(this.txtPackageNumber);
			this.groupBoxOutput.Controls.Add(this.lblPackageNumber);
			this.groupBoxOutput.Controls.Add(this.txtPackageTitle);
			this.groupBoxOutput.Controls.Add(this.lblPackageTitle);
			this.groupBoxOutput.Controls.Add(this.lblProgramTitle);
			this.groupBoxOutput.Controls.Add(this.txtProgramTitle);
			this.groupBoxOutput.Controls.Add(this.txtSeriesTitle);
			this.groupBoxOutput.Controls.Add(this.lblSeriesTitle);
			this.groupBoxOutput.Controls.Add(this.txtProgramEpisodeTitle);
			this.groupBoxOutput.Controls.Add(this.lblProgramEpisodeTitle);
			this.groupBoxOutput.Controls.Add(this.lblScheduleDate);
			this.groupBoxOutput.Controls.Add(this.txtScheduleDate);
			this.groupBoxOutput.Controls.Add(this.lblScheduleDuration);
			this.groupBoxOutput.Controls.Add(this.txtScheduleDuration);
			this.groupBoxOutput.Controls.Add(this.lblResult);
			this.groupBoxOutput.Controls.Add(this.txtResult);
			this.groupBoxOutput.Location = new System.Drawing.Point(272, 24);
			this.groupBoxOutput.Name = "groupBoxOutput";
			this.groupBoxOutput.Size = new System.Drawing.Size(280, 232);
			this.groupBoxOutput.TabIndex = 38;
			this.groupBoxOutput.TabStop = false;
			this.groupBoxOutput.Text = "Output";
			// 
			// txtPackageNumber
			// 
			this.txtPackageNumber.Location = new System.Drawing.Point(132, 32);
			this.txtPackageNumber.Name = "txtPackageNumber";
			this.txtPackageNumber.Size = new System.Drawing.Size(128, 20);
			this.txtPackageNumber.TabIndex = 9;
			this.txtPackageNumber.Text = "";
			// 
			// lblPackageNumber
			// 
			this.lblPackageNumber.Location = new System.Drawing.Point(24, 32);
			this.lblPackageNumber.Name = "lblPackageNumber";
			this.lblPackageNumber.Size = new System.Drawing.Size(104, 16);
			this.lblPackageNumber.TabIndex = 12;
			this.lblPackageNumber.Text = "Package Number";
			// 
			// txtPackageTitle
			// 
			this.txtPackageTitle.Location = new System.Drawing.Point(132, 56);
			this.txtPackageTitle.Name = "txtPackageTitle";
			this.txtPackageTitle.Size = new System.Drawing.Size(128, 20);
			this.txtPackageTitle.TabIndex = 8;
			this.txtPackageTitle.Text = "";
			// 
			// lblPackageTitle
			// 
			this.lblPackageTitle.Location = new System.Drawing.Point(20, 56);
			this.lblPackageTitle.Name = "lblPackageTitle";
			this.lblPackageTitle.Size = new System.Drawing.Size(104, 16);
			this.lblPackageTitle.TabIndex = 13;
			this.lblPackageTitle.Text = "Package Title";
			// 
			// lblProgramTitle
			// 
			this.lblProgramTitle.Location = new System.Drawing.Point(20, 80);
			this.lblProgramTitle.Name = "lblProgramTitle";
			this.lblProgramTitle.Size = new System.Drawing.Size(104, 16);
			this.lblProgramTitle.TabIndex = 14;
			this.lblProgramTitle.Text = "Program Title";
			// 
			// txtProgramTitle
			// 
			this.txtProgramTitle.Location = new System.Drawing.Point(132, 80);
			this.txtProgramTitle.Name = "txtProgramTitle";
			this.txtProgramTitle.Size = new System.Drawing.Size(128, 20);
			this.txtProgramTitle.TabIndex = 4;
			this.txtProgramTitle.Text = "";
			// 
			// txtSeriesTitle
			// 
			this.txtSeriesTitle.Location = new System.Drawing.Point(132, 104);
			this.txtSeriesTitle.Name = "txtSeriesTitle";
			this.txtSeriesTitle.Size = new System.Drawing.Size(128, 20);
			this.txtSeriesTitle.TabIndex = 3;
			this.txtSeriesTitle.Text = "";
			// 
			// lblSeriesTitle
			// 
			this.lblSeriesTitle.Location = new System.Drawing.Point(20, 104);
			this.lblSeriesTitle.Name = "lblSeriesTitle";
			this.lblSeriesTitle.Size = new System.Drawing.Size(104, 16);
			this.lblSeriesTitle.TabIndex = 16;
			this.lblSeriesTitle.Text = "Series Title";
			// 
			// txtProgramEpisodeTitle
			// 
			this.txtProgramEpisodeTitle.Location = new System.Drawing.Point(132, 128);
			this.txtProgramEpisodeTitle.Name = "txtProgramEpisodeTitle";
			this.txtProgramEpisodeTitle.Size = new System.Drawing.Size(128, 20);
			this.txtProgramEpisodeTitle.TabIndex = 5;
			this.txtProgramEpisodeTitle.Text = "";
			// 
			// lblProgramEpisodeTitle
			// 
			this.lblProgramEpisodeTitle.Location = new System.Drawing.Point(20, 128);
			this.lblProgramEpisodeTitle.Name = "lblProgramEpisodeTitle";
			this.lblProgramEpisodeTitle.Size = new System.Drawing.Size(104, 16);
			this.lblProgramEpisodeTitle.TabIndex = 15;
			this.lblProgramEpisodeTitle.Text = "Prog Ep Title";
			// 
			// lblScheduleDate
			// 
			this.lblScheduleDate.Location = new System.Drawing.Point(20, 152);
			this.lblScheduleDate.Name = "lblScheduleDate";
			this.lblScheduleDate.Size = new System.Drawing.Size(104, 16);
			this.lblScheduleDate.TabIndex = 10;
			this.lblScheduleDate.Text = "Schedule Date";
			// 
			// txtScheduleDate
			// 
			this.txtScheduleDate.Location = new System.Drawing.Point(132, 152);
			this.txtScheduleDate.Name = "txtScheduleDate";
			this.txtScheduleDate.Size = new System.Drawing.Size(128, 20);
			this.txtScheduleDate.TabIndex = 7;
			this.txtScheduleDate.Text = "";
			// 
			// lblScheduleDuration
			// 
			this.lblScheduleDuration.Location = new System.Drawing.Point(20, 176);
			this.lblScheduleDuration.Name = "lblScheduleDuration";
			this.lblScheduleDuration.Size = new System.Drawing.Size(104, 16);
			this.lblScheduleDuration.TabIndex = 11;
			this.lblScheduleDuration.Text = "Schedule Duration";
			// 
			// txtScheduleDuration
			// 
			this.txtScheduleDuration.Location = new System.Drawing.Point(132, 176);
			this.txtScheduleDuration.Name = "txtScheduleDuration";
			this.txtScheduleDuration.Size = new System.Drawing.Size(128, 20);
			this.txtScheduleDuration.TabIndex = 6;
			this.txtScheduleDuration.Text = "";
			// 
			// lblResult
			// 
			this.lblResult.Location = new System.Drawing.Point(16, 200);
			this.lblResult.Name = "lblResult";
			this.lblResult.Size = new System.Drawing.Size(104, 16);
			this.lblResult.TabIndex = 11;
			this.lblResult.Text = "Result";
			// 
			// txtResult
			// 
			this.txtResult.Location = new System.Drawing.Point(132, 200);
			this.txtResult.Name = "txtResult";
			this.txtResult.Size = new System.Drawing.Size(128, 20);
			this.txtResult.TabIndex = 6;
			this.txtResult.Text = "";
			// 
			// Form_rdmPBSRemedy
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(664, 366);
			this.Controls.Add(this.grpBoxGetDiscrepancyProgram);
			this.Name = "Form_rdmPBSRemedy";
			this.Text = "Form_rdmPBSRemedy";
			this.Controls.SetChildIndex(this.btnLogin, 0);
			this.Controls.SetChildIndex(this.btnLogout, 0);
			this.Controls.SetChildIndex(this.btnClearLog, 0);
			this.Controls.SetChildIndex(this.txtLog, 0);
			this.Controls.SetChildIndex(this.txtWebServiceURL, 0);
			this.Controls.SetChildIndex(this.grpBoxGetDiscrepancyProgram, 0);
			this.grpBoxGetDiscrepancyProgram.ResumeLayout(false);
			this.groupBoxInput.ResumeLayout(false);
			this.groupBoxOutput.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnGetDiscrepancyProgram_Click(object sender, System.EventArgs e)
		{
			
			if (!ValidateSession())
				return;


			if (txtChannel.Text == string.Empty)
			{
				this.Log("Enter a Channel", true);
				return;
			}

			if (dtDiscrepancyStart.Text == string.Empty)
			{
				this.Log("Select a Discrepancy Start Date", true);
				return;
			}


			txtPackageNumber.Text		= string.Empty;
			txtPackageTitle.Text		= string.Empty;
			txtProgramTitle.Text		= string.Empty;
			txtSeriesTitle.Text			= string.Empty;
			txtProgramEpisodeTitle.Text = string.Empty;
			txtScheduleDate.Text		= string.Empty;
			txtScheduleDuration.Text	= string.Empty;
			txtResult.Text				= string.Empty;

			if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
			{
				BVWebService.BVWebService oBVWebService = new BVWebService.BVWebService();
				oBVWebService.Url = this.txtWebServiceURL.Text + @"/Service.asmx";

				this.Log("Start GetDiscrepancyProgram Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
				string sPackageNumber;
				string sPackageTitle;
				string sProgramTitle;
				string sSeriesTitle;
				string sProgramEpisodeTitle;
				DateTime dtSchedule;
				int iScheduleDuration;

				string sResult = oBVWebService.GetDiscrepancyProgram(txtChannel.Text, 
										dtDiscrepancyStart.Text,  
										out sPackageNumber,
										out sPackageTitle,
										out sProgramTitle,
										out sSeriesTitle,
										out sProgramEpisodeTitle,
										out dtSchedule,
										out iScheduleDuration);



				PopulateResult(txtPackageNumber, sPackageNumber);
				PopulateResult(txtPackageTitle, sPackageTitle);
				PopulateResult(txtProgramTitle , sProgramTitle);
				PopulateResult(txtSeriesTitle, sSeriesTitle);
				PopulateResult(txtProgramEpisodeTitle , sProgramEpisodeTitle);
				PopulateResult(txtScheduleDate , dtSchedule.ToString());
				PopulateResult(txtScheduleDuration , iScheduleDuration.ToString());
				PopulateResult(txtResult, sResult);



									
				this.Log("End GetDiscrepancyProgram Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString()  );

			}
			else
			{
				this.Log("Please log in. Session Null", true);
			}
		}



		private void PopulateResult(System.Windows.Forms.TextBox p_oTextBox, string sResult)
		{
			if (sResult != null && sResult != string.Empty)
			{
				p_oTextBox.Text = sResult;
			}
			else
			{
				p_oTextBox.Text = "<null or empty string>";
			}

		}


	}
}
