using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrafficDataRightLineMapperWebUI
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            using (var Context = new TrafficDataEntities())
            {
                this.gdMasterLookup.DataSource = Context.MasterLookups.ToList();
                this.gdMasterLookup.DataBind();
            }
        }

        protected void gdMasterLookup_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadLookupValues(getSelectedMasterLookupItem());
        }

        protected void gdMasterLookup_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int iMasterID = (int)gdMasterLookup.DataKeys[e.RowIndex].Values[0];

            TextBox tbValue = (TextBox)gdMasterLookup.Rows[e.RowIndex].FindControl("tbValue");


            using (var oContext = new TrafficDataEntities())
            {

                MasterLookup oMasterLookup = oContext.MasterLookups.Where(x => x.ID == iMasterID).First();

                oMasterLookup.value = tbValue.Text;

                oContext.SaveChanges();

            }

            gdMasterLookup.EditIndex = -1;
            LoadData();
        }

        protected void gdMasterLookup_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gdMasterLookup.SelectedIndex = e.NewEditIndex;
            int iML_ID = getSelectedMasterLookupItem();
            gdMasterLookup.EditIndex = e.NewEditIndex;
            LoadData();
            LoadLookupValues(iML_ID);
        }

        protected void gdMasterLookup_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            int Index = gdMasterLookup.EditIndex;
            gdMasterLookup.EditIndex = -1;
            LoadData();
            gdMasterLookup.SelectedIndex = Index;
        }

        protected void gdMasterLookup_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gdMasterLookup_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }


        private int getSelectedMasterLookupItem()
        {
            string sID = gdMasterLookup.DataKeys[gdMasterLookup.SelectedIndex].Value.ToString();
            int iID = int.Parse(sID);

            return iID;
        }

        protected void lbInsertLookupValue_Click(object sender, EventArgs e)
        {

            using (var oContext = new TrafficDataEntities())
            {
                LinkButton btn = (LinkButton)sender;
                GridViewRow GrdRow = (GridViewRow)btn.Parent.Parent;

                TextBox tbValue = (TextBox)GrdRow.Cells[2].FindControl("tbValue");

                MasterLookup oMasterLookup = new MasterLookup();
                oMasterLookup.value = tbValue.Text;


                oContext.MasterLookups.Add(oMasterLookup);
                oContext.SaveChanges();

                gdMasterLookup.EditIndex = -1;
                LoadData();
                gdMasterLookup.SelectedIndex = gdMasterLookup.Rows.Count - 1;

            }
        }

        private void LoadLookupValues(int iMaterID)
        {
            using (var oContext = new TrafficDataEntities())
            {
                this.gdMasterLookUpValues.DataSource = oContext.MasterLookupValues.Where(x => x.ML_ID == iMaterID).OrderBy(x => x.ID).ToList();
                this.gdMasterLookUpValues.DataBind();
            }
        }

        protected void gdMasterLookup_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int iID = (int)gdMasterLookup.DataKeys[e.RowIndex].Value;

            using (var oContext = new TrafficDataEntities())
            {
                MasterLookup oMasterLookup = oContext.MasterLookups.Where(x => x.ID == iID).FirstOrDefault();

                if (oMasterLookup != null)
                {

                    oContext.MasterLookups.Remove(oMasterLookup);
                }

                oContext.SaveChanges();

            }

            LoadData();
        }

        protected void lbInsertLookupMasterValues_Click(object sender, EventArgs e)
        {
            using (var oContext = new TrafficDataEntities())
            {
                LinkButton btn = (LinkButton)sender;
                GridViewRow GrdRow = (GridViewRow)btn.Parent.Parent;

                TextBox tbField = (TextBox)GrdRow.Cells[3].FindControl("tbField");
                TextBox tbDerivedValue = (TextBox)GrdRow.Cells[4].FindControl("tbDerivedValue");
                TextBox tbDBValue = (TextBox)GrdRow.Cells[5].FindControl("tbDBValue");


                MasterLookupValue oMasterLookupValue = new MasterLookupValue();
                oMasterLookupValue.dbvalue = tbDBValue.Text;
                oMasterLookupValue.DerivedValue = tbDerivedValue.Text;
                oMasterLookupValue.field = tbField.Text;
                oMasterLookupValue.ML_ID = getSelectedMasterLookupItem();


                oContext.MasterLookupValues.Add(oMasterLookupValue);
                oContext.SaveChanges();

                gdMasterLookup.EditIndex = -1;
                LoadLookupValues(getSelectedMasterLookupItem());
                gdMasterLookup.SelectedIndex = gdMasterLookup.Rows.Count - 1;

            }
        }

        protected void gdMasterLookUpValues_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gdMasterLookUpValues_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int iMasterID = (int)gdMasterLookUpValues.DataKeys[e.RowIndex].Values[0];


            TextBox tbField = (TextBox)gdMasterLookUpValues.Rows[e.RowIndex].FindControl("tbField");
            TextBox tbDerivedValue = (TextBox)gdMasterLookUpValues.Rows[e.RowIndex].FindControl("tbDerivedValue");
            TextBox tbDBValue = (TextBox)gdMasterLookUpValues.Rows[e.RowIndex].FindControl("tbDBValue");


            using (var oContext = new TrafficDataEntities())
            {

                MasterLookupValue oMasterLookup = oContext.MasterLookupValues.Where(x => x.ID == iMasterID).First();

                oMasterLookup.dbvalue = tbDBValue.Text;
                oMasterLookup.DerivedValue = tbDerivedValue.Text;
                oMasterLookup.field = tbField.Text;

                oContext.SaveChanges();

            }

            gdMasterLookUpValues.EditIndex = -1;
            LoadLookupValues(getSelectedMasterLookupItem());
        }

        protected void gdMasterLookUpValues_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gdMasterLookUpValues.EditIndex = e.NewEditIndex;
            LoadLookupValues(getSelectedMasterLookupItem());
        }

        protected void gdMasterLookUpValues_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            int Index = gdMasterLookUpValues.EditIndex;
            gdMasterLookUpValues.EditIndex = -1;
            LoadLookupValues(getSelectedMasterLookupItem());

        }

        protected void gdMasterLookUpValues_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gdMasterLookUpValues_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gdMasterLookUpValues_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int iID = (int)gdMasterLookUpValues.DataKeys[e.RowIndex].Value;

            using (var oContext = new TrafficDataEntities())
            {
                MasterLookupValue oMasterLookupValue = oContext.MasterLookupValues.Where(x => x.ID == iID).FirstOrDefault();

                if (oMasterLookupValue != null)
                {

                    oContext.MasterLookupValues.Remove(oMasterLookupValue);
                }

                oContext.SaveChanges();

            }

            LoadLookupValues(getSelectedMasterLookupItem());
        }

    }
}