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
    public partial class BatchSampling : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
        int iPoid = 0;
        int iGRId = 0;
        int iTransGRId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                iTransGRId = Convert.ToInt32(Request.QueryString.Get("TransGRId"));
                #region Dropdown Approver
                DataSet dsApprovar = new DataSet();
                dsApprovar = dbObj.Select_Employeename();
                if (dsApprovar.Tables[0].Rows.Count > 0)
                {
                    ddlSelectapprover.DataSource = dsApprovar;
                    ddlSelectapprover.DataTextField = "EmployeeName";
                    ddlSelectapprover.DataValueField = "EmployeeID";
                    ddlSelectapprover.DataBind();
                    ddlSelectapprover.Items.Insert(0, "Select Approver");
                }
                #endregion
            }
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
           
                #region Load GR
                DataSet dssamplingovr = new DataSet();
                dssamplingovr = dbObj.LoadBatchsampling2(Convert.ToString(txtBatchno.Text));
            if (dssamplingovr.Tables[0].Rows.Count > 0)
            {
                string status = dssamplingovr.Tables[0].Rows[0]["BatchStatus"].ToString();
                if (status != "Release")
                {
                    if (dssamplingovr.Tables[0].Rows.Count > 0)
                    {
                        gvbatchsamp.DataSource = dssamplingovr.Tables[0];
                        gvbatchsamp.DataBind();

                    }
                }
                else
                {
                    string script = "alert('Sampling Already Completed')";
                    ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                }
                #endregion
            }
            else
            {
                string script = "alert('No Batches available')";
                ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
            }
            
        }


        protected void txtSampleqty_TextChanged1(object sender, EventArgs e)
        {
           
                iTransGRId = Convert.ToInt32(ViewState["Trans"]);
                DataSet dssampling = new DataSet();
                dssampling = dbObj.LoadBatchsampling2(Convert.ToString(txtBatchno.Text));
                for (int i = 0; i < dssampling.Tables[0].Rows.Count; i++)
                {

                    int BatchQty = 0;
                    TextBox txtSampleqty = (TextBox)sender; // Get the reference to the TextBox control
                    GridViewRow row = (GridViewRow)txtSampleqty.NamingContainer; // Get the reference to the GridView row
                    TextBox txtFinalbatchqty = (TextBox)row.FindControl("txtFinalbatchqty"); // Get the reference to the TextBox control for Total Batches
                    int j = row.RowIndex;
                    BatchQty = Convert.ToInt32(dssampling.Tables[0].Rows[j]["Qty"].ToString());
                    //iGRId= Convert.ToInt32(dssampling.Tables[0].Rows[i]["TransGRId"].ToString());
                    int sampleqty = 0;
                    int.TryParse(txtSampleqty.Text, out sampleqty);
                    int totalfinalBatchqty = BatchQty - sampleqty;
                    txtFinalbatchqty.Text = totalfinalBatchqty.ToString();

                }
            
        }
           

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //if (ddlSelectapprover.SelectedValue == "Select Approver")
            //{
            //    string script = "alert('Select Approver')";
            //    ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
            //}
            //else
            //if(txtSamNo.Text=="")
            //{
            //    string script = "alert('Enter Sam No')";
            //    ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
            //}
            //else
            //{
                string today = DateTime.Today.ToString("yyyy-MM-dd");
                int isucess = 0;
                isucess = dbObj.Insertsampling(txtBatchno.Text,"0", 0, ddlStatus.SelectedItem.Text, DateTime.Parse(today));

                #region Insert_TransPO
                DataSet dssampling = new DataSet();
                dssampling = dbObj.LoadBatchsampling1(Convert.ToString(txtBatchno.Text));
                if (dssampling.Tables[0].Rows.Count > 0)
                {
                    int count = dssampling.Tables[0].Rows.Count;
                    for (int i = 0; i < count; i++)
                    {
                        string BtachNo = dssampling.Tables[0].Rows[i]["Batchnumber"].ToString();
                        string GRId = dssampling.Tables[0].Rows[i]["GRId"].ToString();
                        string ProductID = dssampling.Tables[0].Rows[i]["ProductID"].ToString();
                        string Productname = dssampling.Tables[0].Rows[i]["Productname"].ToString();
                        string Strength = dssampling.Tables[0].Rows[i]["Strength"].ToString();
                        string Packtype = dssampling.Tables[0].Rows[i]["Packtype"].ToString();
                        string Packsize = dssampling.Tables[0].Rows[i]["Packsize"].ToString();
                        string BatchQty = dssampling.Tables[0].Rows[i]["OrderQty"].ToString();
                        string Units = dssampling.Tables[0].Rows[i]["Unitname"].ToString();
                        string Pallets = dssampling.Tables[0].Rows[i]["PalletsQty"].ToString();
                        TextBox txtSampleQty = (TextBox)gvbatchsamp.Rows[i].FindControl("txtSampleqty");
                        string SampleQty = txtSampleQty.Text;
                        TextBox txtFinalBatchQty = (TextBox)gvbatchsamp.Rows[i].FindControl("txtFinalbatchqty");
                        string FinalBatchQty = txtFinalBatchQty.Text;
                        int status = 0;
                        if (FinalBatchQty == "0")
                        {
                            status = 1;
                        }
                        string BatchStatus = dssampling.Tables[0].Rows[i]["BatchStatus"].ToString();
                        TextBox txtRemark = (TextBox)gvbatchsamp.Rows[i].FindControl("txtRemark");
                        if (SampleQty != "0")
                        { 
                        int iSuccess1 = dbObj.InsertSamplingProducts(BtachNo, GRId, ProductID, Productname, Strength, BatchQty, Units, Pallets, SampleQty, FinalBatchQty, BatchStatus);
                        int iSuccess2 = dbObj.UpdateTransGRsam(Units, SampleQty, FinalBatchQty);
                        int iSuccess3 = dbObj.UpdateUnitvalue(Units, FinalBatchQty, status);
                        int iSuccess4 = dbObj.Updatetracevalue(Units, FinalBatchQty);
                    }
                    }
                //}
                #endregion
                string script = "alert('Row added')";
                ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                Response.Redirect("Sampling.aspx");
            }
           
        }

        protected void txtSamNo_TextChanged(object sender, EventArgs e)
        {
            DataSet dssampling = dbObj.checkSampleAvailable(Convert.ToString(txtSamNo.Text));
            if (dssampling.Tables[0].Rows.Count > 0)
            {
                string script = "alert('Sample Already Exist, Create New One')";
                ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
            }
                
        }
    }
}