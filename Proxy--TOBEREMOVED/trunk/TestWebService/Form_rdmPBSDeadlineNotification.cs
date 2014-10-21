using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestWebService
{
    public partial class Form_rdmPBSDeadlineNotification : Form_Base
    {
        public Form_rdmPBSDeadlineNotification()
        {
            InitializeComponent();
        }

        private void btnListPAADeadline_Click(object sender, EventArgs e)
        {
            dgOrionAPIs.DataSource = null;

            if (!ValidateSession())
                return;


            if (sltFormStatus.SelectedItem == null)
            {
                this.Log("Select a Form Status", true);
                return;
            }

            if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
            {
              
                
                
                BVWebService.BVWebService oBVWebService = new BVWebService.BVWebService();
                oBVWebService.Url = this.txtWebServiceURL.Text + @"/Service.asmx";

                this.Log("Start ListPAADeadline Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
                DataSet oDataSetResult = oBVWebService.ListPAADeadline(m_sBVSessionId, ((PBSComboItem)sltFormStatus.SelectedItem).iKey);
                dgOrionAPIs.DataSource = oDataSetResult;
                this.Log("End ListPAADeadline Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString());
            }
            else
            {
                this.Log("Please log in. Session Null", true);
            }
        }

        private void btnListFormDeadline_Click(object sender, EventArgs e)
        {
            dgOrionAPIs.DataSource = null;

            if (!ValidateSession())
                return;


            if (sltFormStatus.SelectedItem == null)
            {
                this.Log("Select a Form Status", true);
                return;
            }


            if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
            {
           

                BVWebService.BVWebService oBVWebService = new BVWebService.BVWebService();
                oBVWebService.Url = this.txtWebServiceURL.Text + @"/Service.asmx";

                this.Log("Start ListFormDeadline Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
                DataSet oDataSetResult = oBVWebService.ListFormDeadline(m_sBVSessionId, ((PBSComboItem)sltFormStatus.SelectedItem).iKey);
                dgOrionAPIs.DataSource = oDataSetResult;
                this.Log("End ListFormDeadline Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString());
            }
            else
            {
                this.Log("Please log in. Session Null", true);
            }
        }

        private void btnListMissingEpisodeFormDeadline_Click(object sender, EventArgs e)
        {
            dgOrionAPIs.DataSource = null;

            if (!ValidateSession())
                return;


          

            if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
            {
                

                BVWebService.BVWebService oBVWebService = new BVWebService.BVWebService();
                oBVWebService.Url = this.txtWebServiceURL.Text + @"/Service.asmx";

                this.Log("Start ListMissingEpisodeFormDeadline Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
                DataSet oDataSetResult = oBVWebService.ListMissingEpisodeFormDeadline(m_sBVSessionId);
                dgOrionAPIs.DataSource = oDataSetResult;
                this.Log("End ListMissingEpisodeFormDeadline Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString());
            }
            else
            {
                this.Log("Please log in. Session Null", true);
            }
        }

        private void btnListMissingVersionFormDeadline_Click(object sender, EventArgs e)
        {
            dgOrionAPIs.DataSource = null;

            if (!ValidateSession())
                return;


          
            if (m_sBVSessionId != null && m_sBVSessionId != string.Empty)
            {
                

                BVWebService.BVWebService oBVWebService = new BVWebService.BVWebService();
                oBVWebService.Url = this.txtWebServiceURL.Text + @"/Service.asmx";

                this.Log("Start ListMissingVersionFormDeadline Test Sequence :StartTime : " + DateTime.Now.ToLongTimeString());
                DataSet oDataSetResult = oBVWebService.ListMissingVersionFormDeadline(m_sBVSessionId);
                dgOrionAPIs.DataSource = oDataSetResult;
                this.Log("End ListMissingVersionFormDeadline Test Sequence :EndTime : " + DateTime.Now.ToLongTimeString());
            }
            else
            {
                this.Log("Please log in. Session Null", true);
            }
        }

    }
}
