using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medly_Wm
{
    public partial class BatchManagement : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
        int iPoid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //#region Dropdown Approver
            //DataSet dsApprovar = new DataSet();
            //dsApprovar = dbObj.Select_Employeename();
            //if (dsApprovar.Tables[0].Rows.Count > 0)
            //{
            //    ddlSelectapprover.DataSource = dsApprovar;
            //    ddlSelectapprover.DataTextField = "EmployeeName";
            //    ddlSelectapprover.DataValueField = "EmployeeID";
            //    ddlSelectapprover.DataBind();
            //    ddlSelectapprover.Items.Insert(0, "Select Approver");
            //}
            //#endregion
        }
        protected void btnGo_Click(object sender, EventArgs e)
        {

            #region Load GR
            DataSet dsBatchMan = new DataSet();
            dsBatchMan = dbObj.LoadBatchmanagement(Convert.ToString(txtBatchno.Text));
            if (dsBatchMan.Tables[0].Rows.Count > 0)
            {
                gvbatchsamp.DataSource = dsBatchMan.Tables[0];
                gvbatchsamp.DataBind();
            }
            #endregion

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DataSet dsBatchMan = new DataSet();
            dsBatchMan = dbObj.LoadBatchmanagement(Convert.ToString(txtBatchno.Text));
            if (dsBatchMan.Tables[0].Rows.Count > 0)
            {
                int count = dsBatchMan.Tables[0].Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    string unitname = dsBatchMan.Tables[0].Rows[i]["Unitname"].ToString();
                    string ddBatchStatus = ((DropDownList)gvbatchsamp.Rows[i].FindControl("ddlBatchStatus")).SelectedValue;
                    int iSuccess2 = dbObj.UpdateTranceGRstatus(unitname, ddBatchStatus);
                    int iSuccess = dbObj.UpdateUnitstatus(unitname, ddBatchStatus);
                    if (ddBatchStatus == "Release")
                    {
                        int iSuccess1 = dbObj.UpdateGrstatus(txtBatchno.Text, ddBatchStatus);
                    }
                   
                }
                Response.Redirect("BatchManagement.aspx");
            }
        }
    }
}