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
	/// Summary description for TestAllProxy.
	/// </summary>
	public class TestAllProxy : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button button10;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Button button9;
        private Button button11;
        private Button button12;

		public string m_strSessionID = string.Empty;

	

		public TestAllProxy()
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
		[STAThread]
		static void Main() 
		{
			Application.Run(new TestAllProxy());
		}
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.button10 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(24, 240);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(224, 23);
            this.button10.TabIndex = 16;
            this.button10.Text = "Test rdmPBSTalent";
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(24, 120);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(224, 23);
            this.button5.TabIndex = 14;
            this.button5.Text = "Test rdmPBSManageTable";
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(24, 72);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(224, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "Test rdmPBSGetMasterDeal";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(24, 48);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(224, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Test rdmPBSDeal";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(224, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Test rdmPBSGetLookup";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(24, 144);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(224, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = "Test rdmPBSManageAppliesToRange";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(24, 192);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(224, 23);
            this.button6.TabIndex = 15;
            this.button6.Text = "Test rdmPBSMediaInventory";
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(24, 168);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(224, 23);
            this.button7.TabIndex = 11;
            this.button7.Text = "Test rdmPBSProgram";
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(24, 96);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(224, 23);
            this.button8.TabIndex = 12;
            this.button8.Text = "Test rdmPBSProgramCreator";
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(24, 216);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(224, 23);
            this.button9.TabIndex = 13;
            this.button9.Text = "Test rdmPBSSearch";
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(24, 263);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(224, 23);
            this.button11.TabIndex = 16;
            this.button11.Text = "Test rdmPBSRemedy";
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(24, 286);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(224, 23);
            this.button12.TabIndex = 16;
            this.button12.Text = "Test rdmPBSDeadlineNotification";
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // TestAllProxy
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(273, 349);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button9);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TestAllProxy";
            this.Text = "TestAllProxy";
            this.Load += new System.EventHandler(this.TestAllProxy_Load);
            this.ResumeLayout(false);

		}
		#endregion
		#region private methods
		private void TestAllProxy_Load(object sender, System.EventArgs e)
		{
		
		}
		#endregion
		private void button1_Click(object sender, System.EventArgs e)
		{
			Form_rdmPBSGetLookup oForm = new Form_rdmPBSGetLookup();
			oForm.ShowDialog(this);

		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			Form_rdmPBSDeal oForm = new Form_rdmPBSDeal();
			oForm.ShowDialog(this);
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			Form_rdmPBSGetMasterDeal  oForm = new Form_rdmPBSGetMasterDeal();
			oForm.ShowDialog(this);
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
			Form_rdmPBSManageAppliesToRange   oForm = new Form_rdmPBSManageAppliesToRange();
			oForm.ShowDialog(this);
		
		}

		private void button5_Click(object sender, System.EventArgs e)
		{
			Form_rdmPBSManageTable oForm = new Form_rdmPBSManageTable();
			oForm.ShowDialog(this);
		}

		private void button6_Click(object sender, System.EventArgs e)
		{
			Form_rdmPBSMediaInventory  oForm = new Form_rdmPBSMediaInventory();
			oForm.ShowDialog(this);
		}

		private void button7_Click(object sender, System.EventArgs e)
		{
			Form_rdmPBSProgram  oForm = new Form_rdmPBSProgram();
			oForm.ShowDialog(this);
		}

		private void button8_Click(object sender, System.EventArgs e)
		{
			Form_rdmPBSProgramCreator  oForm = new Form_rdmPBSProgramCreator();
			oForm.ShowDialog(this);
		}

		private void button9_Click(object sender, System.EventArgs e)
		{
			Form_rdmPBSSearch  oForm = new Form_rdmPBSSearch();
			oForm.ShowDialog(this);
		}

		private void button10_Click(object sender, System.EventArgs e)
		{
			Form_rdmPBSTalent  oForm = new Form_rdmPBSTalent();
			oForm.ShowDialog(this);	
		}

        private void button11_Click(object sender, System.EventArgs e)
        {
            Form_rdmPBSRemedy oForm = new Form_rdmPBSRemedy();
            oForm.ShowDialog(this);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form_rdmPBSDeadlineNotification oForm = new Form_rdmPBSDeadlineNotification();
            oForm.ShowDialog(this);
        }
	}
}
