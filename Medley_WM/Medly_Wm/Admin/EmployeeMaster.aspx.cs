using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace AdminAfforadbleApp
{
    public partial class EmployeeMaster : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //LoadGrid();
               
                 string EmployeeId = Request.QueryString.Get("EmployeeId");
                 if (EmployeeId != null)
                 {
                     DataSet ds = dbObj.GetEditEmployee(EmployeeId);
                     if (ds.Tables[0].Rows.Count > 0)
                     {
                         string Id = ds.Tables[0].Rows[0]["EmployeeId"].ToString();
                         // listcategory.Enabled = false;
                         txtemployeename.Text = ds.Tables[0].Rows[0]["EmpName"].ToString();

                         lbleid.Text = ds.Tables[0].Rows[0]["EmployeeId"].ToString();
                         ddldesignation.SelectedItem.Text = ds.Tables[0].Rows[0]["Designation"].ToString();
                         txtusername.Text = ds.Tables[0].Rows[0]["UserName"].ToString();
                         txtPassword.Text = ds.Tables[0].Rows[0]["Password"].ToString();
                         txtMobileno.Text = ds.Tables[0].Rows[0]["MobileNo"].ToString();
                         txtEmailid.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                         ddldesignation.SelectedValue = ds.Tables[0].Rows[0]["DesignationId"].ToString();

                         btnSave.Visible = true;
                         btnSave.Text = "Update";
                     }
                 }
                 else
                 {

                     Clear();
                 }
            }
        }


        //protected void btnReset_Click(object sender, EventArgs e)
        //{
        //    Clear();
        //   // Response.Redirect("EmployeeMaster.aspx");
        //}
            
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtemployeename.Text == "")
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Enter Employee Name');", true);
                    txtemployeename.Focus();
                    return;
                }

                if (txtusername.Text == "")
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Enter UserName');", true);
                    txtusername.Focus();
                    return;
                }
                if (txtPassword.Text == "")
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Enter Password');", true);
                    txtPassword.Focus();
                    return;
                }
                if (btnSave.Text == "Save")
                {
                    string active = "Yes";
                    int iSuccess = dbObj.insert_Employee(txtemployeename.Text, ddldesignation.SelectedItem.Text, txtusername.Text, txtPassword.Text, txtMobileno.Text, txtEmailid.Text, ddldesignation.SelectedValue, active);


                    // LoadGrid();
                    Clear();
                }
                else if (btnSave.Text == "Update")
                {
                    int iSuccess1 = dbObj.Update_Employee(txtemployeename.Text, ddldesignation.SelectedItem.Text, txtusername.Text, txtPassword.Text, txtMobileno.Text, txtEmailid.Text, ddldesignation.SelectedValue, lbleid.Text);
                    Clear();
                    //LoadGrid();
                }
                Response.Redirect("EmployeeGrid.aspx");
            }
            catch (Exception ex)
            { throw ex; }
        }

       

        protected void Clear()
        {
            txtemployeename.Text = "";
            txtMobileno.Text = "";
            txtusername.Text = "";
            txtPassword.Text = "";
            txtEmailid.Text = "";
            ddldesignation.SelectedValue = "1";
            txtemployeename.Focus();

        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeGrid.aspx");
        }



        }
    }
