namespace TestWebService
{
    partial class Form_rdmPBSDeadlineNotification
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpBoxDeal = new System.Windows.Forms.GroupBox();
            this.btnListFormDeadline = new System.Windows.Forms.Button();
            this.btnListMissingVersionFormDeadline = new System.Windows.Forms.Button();
            this.btnListMissingEpisodeFormDeadline = new System.Windows.Forms.Button();
            this.btnListPAADeadline = new System.Windows.Forms.Button();
            this.dgOrionAPIs = new System.Windows.Forms.DataGrid();
            this.lblStatus = new System.Windows.Forms.Label();
            this.sltFormStatus = new System.Windows.Forms.ComboBox();
            this.grpBoxDeal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgOrionAPIs)).BeginInit();
            this.SuspendLayout();
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(0, 448);
            // 
            // grpBoxDeal
            // 
            this.grpBoxDeal.Controls.Add(this.sltFormStatus);
            this.grpBoxDeal.Controls.Add(this.lblStatus);
            this.grpBoxDeal.Controls.Add(this.btnListFormDeadline);
            this.grpBoxDeal.Controls.Add(this.btnListMissingVersionFormDeadline);
            this.grpBoxDeal.Controls.Add(this.btnListMissingEpisodeFormDeadline);
            this.grpBoxDeal.Controls.Add(this.btnListPAADeadline);
            this.grpBoxDeal.Location = new System.Drawing.Point(12, 27);
            this.grpBoxDeal.Name = "grpBoxDeal";
            this.grpBoxDeal.Size = new System.Drawing.Size(532, 224);
            this.grpBoxDeal.TabIndex = 17;
            this.grpBoxDeal.TabStop = false;
            this.grpBoxDeal.Text = "Deadline";
            // 
            // btnListFormDeadline
            // 
            this.btnListFormDeadline.Location = new System.Drawing.Point(278, 44);
            this.btnListFormDeadline.Name = "btnListFormDeadline";
            this.btnListFormDeadline.Size = new System.Drawing.Size(196, 23);
            this.btnListFormDeadline.TabIndex = 6;
            this.btnListFormDeadline.Text = "ListFormDeadline";
            this.btnListFormDeadline.Click += new System.EventHandler(this.btnListFormDeadline_Click);
            // 
            // btnListMissingVersionFormDeadline
            // 
            this.btnListMissingVersionFormDeadline.Location = new System.Drawing.Point(138, 127);
            this.btnListMissingVersionFormDeadline.Name = "btnListMissingVersionFormDeadline";
            this.btnListMissingVersionFormDeadline.Size = new System.Drawing.Size(196, 23);
            this.btnListMissingVersionFormDeadline.TabIndex = 5;
            this.btnListMissingVersionFormDeadline.Text = "List Missing Version Form Deadline";
            this.btnListMissingVersionFormDeadline.Click += new System.EventHandler(this.btnListMissingVersionFormDeadline_Click);
            // 
            // btnListMissingEpisodeFormDeadline
            // 
            this.btnListMissingEpisodeFormDeadline.Location = new System.Drawing.Point(138, 104);
            this.btnListMissingEpisodeFormDeadline.Name = "btnListMissingEpisodeFormDeadline";
            this.btnListMissingEpisodeFormDeadline.Size = new System.Drawing.Size(196, 23);
            this.btnListMissingEpisodeFormDeadline.TabIndex = 3;
            this.btnListMissingEpisodeFormDeadline.Text = "List Missing Episode Form Deadline";
            this.btnListMissingEpisodeFormDeadline.Click += new System.EventHandler(this.btnListMissingEpisodeFormDeadline_Click);
            // 
            // btnListPAADeadline
            // 
            this.btnListPAADeadline.Location = new System.Drawing.Point(278, 21);
            this.btnListPAADeadline.Name = "btnListPAADeadline";
            this.btnListPAADeadline.Size = new System.Drawing.Size(196, 23);
            this.btnListPAADeadline.TabIndex = 0;
            this.btnListPAADeadline.Text = "ListPAADeadline";
            this.btnListPAADeadline.Click += new System.EventHandler(this.btnListPAADeadline_Click);
            // 
            // dgOrionAPIs
            // 
            this.dgOrionAPIs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgOrionAPIs.DataMember = "";
            this.dgOrionAPIs.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgOrionAPIs.Location = new System.Drawing.Point(12, 257);
            this.dgOrionAPIs.Name = "dgOrionAPIs";
            this.dgOrionAPIs.Size = new System.Drawing.Size(600, 185);
            this.dgOrionAPIs.TabIndex = 18;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(49, 45);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(62, 13);
            this.lblStatus.TabIndex = 15;
            this.lblStatus.Text = "Deal Status";
            // 
            // sltFormStatus
            // 
            this.sltFormStatus.FormattingEnabled = true;
            this.sltFormStatus.Location = new System.Drawing.Point(117, 37);
            this.sltFormStatus.Name = "sltFormStatus";
            this.sltFormStatus.Size = new System.Drawing.Size(121, 21);
            this.sltFormStatus.TabIndex = 17;

            this.sltFormStatus.Items.AddRange(new object[]{
                new PBSComboItem(30, "In Progress"),
                new PBSComboItem(50, "Approved"),
                new PBSComboItem(60, "In Revision")
            });


            // 
            // Form_rdmPBSDeadlineNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 560);
            this.Controls.Add(this.dgOrionAPIs);
            this.Controls.Add(this.grpBoxDeal);
            this.Name = "Form_rdmPBSDeadlineNotification";
            this.Text = "Form_rdmPBSDeadlineNotification";
            this.Controls.SetChildIndex(this.btnLogin, 0);
            this.Controls.SetChildIndex(this.btnLogout, 0);
            this.Controls.SetChildIndex(this.txtLog, 0);
            this.Controls.SetChildIndex(this.txtWebServiceURL, 0);
            this.Controls.SetChildIndex(this.btnClearLog, 0);
            this.Controls.SetChildIndex(this.sltProxyEnvironment, 0);
            this.Controls.SetChildIndex(this.chkGlobalSaveResults, 0);
            this.Controls.SetChildIndex(this.grpBoxDeal, 0);
            this.Controls.SetChildIndex(this.dgOrionAPIs, 0);
            this.grpBoxDeal.ResumeLayout(false);
            this.grpBoxDeal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgOrionAPIs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxDeal;
        private System.Windows.Forms.Button btnListFormDeadline;
        private System.Windows.Forms.Button btnListMissingVersionFormDeadline;
        private System.Windows.Forms.Button btnListMissingEpisodeFormDeadline;
        private System.Windows.Forms.Button btnListPAADeadline;
        private System.Windows.Forms.DataGrid dgOrionAPIs;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox sltFormStatus;


        

    }

   


}