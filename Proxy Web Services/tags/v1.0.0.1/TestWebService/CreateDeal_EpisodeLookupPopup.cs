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
    public partial class CreateDeal_EpisodeLookupPopup : System.Windows.Forms.Form
    {
        public CreateDeal_EpisodeLookupPopup()
        {
            InitializeComponent();
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void LoadDataGridView(DataTable p_oDataTable)
        {
            dataGridView1.DataSource = p_oDataTable;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count == 0 )
            {
                MessageBox.Show("You must select rows to continue.");
             
                return;
            }
            
            List<int> oIds = new List<int>();
            
            foreach (DataGridViewRow oRow in dataGridView1.SelectedRows)
            {
                oIds.Add((int)oRow.Cells["ASS_ID"].Value);
            }

            ((Form_rdmPBSDeal)(this.Owner)).UpdateEpisodeIdList(String.Join(",", oIds.ToArray())); 
        }

        
    }
}
