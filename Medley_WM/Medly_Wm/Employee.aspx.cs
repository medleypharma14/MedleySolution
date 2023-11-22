using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Medly_Wm
{
    public partial class Employee : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
        int iEmpid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime Today = DateTime.Now;
                txtDob.Text = Today.ToString("yyyy-MM-dd");
                txtDoj.Text = Today.ToString("yyyy-MM-dd");

                #region Edit
                iEmpid = Convert.ToInt32(Request.QueryString.Get("Empid"));

                if (iEmpid != 0)
                {

                    DataSet dsDesgnId = new DataSet();
                    dsDesgnId = dbObj.Select_Employeeedid(iEmpid);
                    ViewState["vsEmp"] = iEmpid;

                    if (dsDesgnId.Tables[0].Rows.Count > 0)
                    {
                        txtEmployeeid.Text = dsDesgnId.Tables[0].Rows[0]["EmployeeID"].ToString();
                        txtEmployeename.Text = dsDesgnId.Tables[0].Rows[0]["EmployeeName"].ToString();
                        txtEmployeename.Enabled = false;
                        txtDob.Text = ((DateTime)dsDesgnId.Tables[0].Rows[0]["DateofBirth"]).ToString("yyyy-MM-dd");
                        txtDoj.Text = ((DateTime)dsDesgnId.Tables[0].Rows[0]["DateofJoining"]).ToString("yyyy-MM-dd");
                        #region Dropdown Designation
                        DataSet dsDesignation1 = new DataSet();
                        dsDesignation1 = dbObj.SelectDesignation();
                        if (dsDesignation1.Tables[0].Rows.Count > 0)
                        {
                            ddlDesignation.DataSource = dsDesignation1;
                            ddlDesignation.DataTextField = "Designation";
                            ddlDesignation.DataValueField = "Designationid";
                            ddlDesignation.DataBind();
                            ddlDesignation.Items.Insert(0, "Select Designation");
                        }
                        #endregion
                        ddlDesignation.SelectedValue= dsDesgnId.Tables[0].Rows[0]["Designation"].ToString();
                        rbgender.Text= dsDesgnId.Tables[0].Rows[0]["Gender"].ToString();
                        txtEmail.Text = dsDesgnId.Tables[0].Rows[0]["Email"].ToString();
                        txtPhonenumber.Text = dsDesgnId.Tables[0].Rows[0]["PhoneNumber"].ToString();
                        txtAddress.Text = dsDesgnId.Tables[0].Rows[0]["Address"].ToString();
                        txtUsername.Text = dsDesgnId.Tables[0].Rows[0]["Username"].ToString();
                        txtPassword.TextMode = TextBoxMode.SingleLine;
                        txtPassword.Text = dsDesgnId.Tables[0].Rows[0]["Password"].ToString();

                        btnSubmit.Text = "Update";
                    }
                }
                #endregion
                #region Dropdown Designation
                DataSet dsDesignation = new DataSet();
                dsDesignation = dbObj.SelectDesignation();
                if (dsDesignation.Tables[0].Rows.Count > 0)
                {
                    ddlDesignation.DataSource = dsDesignation;
                    ddlDesignation.DataTextField = "Designation";
                    ddlDesignation.DataValueField = "Designationid";
                    ddlDesignation.DataBind();
                    ddlDesignation.Items.Insert(0, "Select Designation");
                }
                #endregion
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DateTime dob = DateTime.ParseExact(txtDob.Text, "yyyy-MM-dd", null);
            DateTime doj = DateTime.ParseExact(txtDoj.Text, "yyyy-MM-dd", null);
            DateTime today = DateTime.Now;

            if (ddlDesignation.SelectedValue == "Select Designation")
            {
                string script = "alert('Select Designation')";
                ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
            }
            else
            {
                if (btnSubmit.Text == "Submit")
                {
                    DataSet Empname = dbObj.Check_Employeename(txtEmployeename.Text);
                    if (Empname.Tables[0].Rows.Count>0) 
                    {
                        string script1 = "alert('Employee Name Already Created,Please Create New One')";
                        ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script1, true);
                    }
                    else if (dob > today)
                    {
                        string script1 = "alert('Please select Valid Date Of Birth')";
                        ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script1, true);
                    }
                    else if (doj < today)
                    {
                        string script1 = "alert('Please select Valid Date Of Joining')";
                        ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script1, true);
                    }
                    else 
                    {
                        DataSet username = dbObj.Check_Username(txtUsername.Text);
                        if (username.Tables[0].Rows.Count > 0)
                        {
                            string script1 = "alert('Username Already Created, Please Change Username')";
                            ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script1, true);
                        }
                        else
                        {
                            int isucess = 0;
                            int isucces1 = 0;
                            isucess = dbObj.Insert_Employee(txtEmployeename.Text, Convert.ToDateTime(txtDob.Text), Convert.ToDateTime(txtDoj.Text), rbgender.Text, ddlDesignation.SelectedValue, txtEmail.Text, txtPhonenumber.Text, txtAddress.Text);
                            isucces1 = dbObj.Insert_Login(txtUsername.Text, txtPassword.Text);
                            //Response.Redirect("../Accountsbootstrap/viewbranch.aspx");
                            string script = "alert('Data Saved')";
                            ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                            Response.Redirect("EmployeeGridpage.aspx");
                        }
                        
                    }
                   
                }
                else if (btnSubmit.Text == "Update")
                {
                    if (dob > today)
                    {
                        string script1 = "alert('Please select Valid Date Of Birth')";
                        ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script1, true);
                    }
                    else if (doj < today)
                    {
                        string script1 = "alert('Please select Valid Date Of Joining')";
                        ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script1, true);
                    }
                    else
                    {
                        int isucess = 0;
                        int isucces1 = 0;
                        isucess = dbObj.UpdateEmployee(Convert.ToInt32(ViewState["vsEmp"].ToString()), txtEmployeename.Text, Convert.ToDateTime(txtDob.Text), Convert.ToDateTime(txtDoj.Text), rbgender.Text, ddlDesignation.SelectedValue, txtEmail.Text, txtPhonenumber.Text, txtAddress.Text);
                        isucces1 = dbObj.Update_Login(txtUsername.Text, txtPassword.Text, Convert.ToInt32(ViewState["vsEmp"]));
                        string script = "alert('Data Updated')";
                        ClientScript.RegisterStartupScript(this.GetType(), "UpdateMessage", script, true);
                        Response.Redirect("EmployeeGridpage.aspx");
                    }
                                   
                }
            }
        }

        protected void txtPhonenumber_TextChanged(object sender, EventArgs e)
        {
            iEmpid = Convert.ToInt32(Request.QueryString.Get("Empid"));

            if (iEmpid != 0)
            {
                DataSet pnocheck = dbObj.Check_Phonnoupdate(txtPhonenumber.Text,iEmpid);
                if (pnocheck.Tables[0].Rows.Count > 0)
                {
                    string script1 = "alert('Phone Number Already Stored Change Phone Number')";
                    ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script1, true);
                    txtPhonenumber.Text = "";
                }
            }
            else
            {
                DataSet pnocheck = dbObj.Check_Phonno(txtPhonenumber.Text);
                if (pnocheck.Tables[0].Rows.Count > 0)
                {
                    string script = "alert('Phone Number Already Stored')";
                    ClientScript.RegisterStartupScript(this.GetType(), "UpdateMessage", script, true);
                    txtPhonenumber.Text = "";
                }
            }
           
        }
    }
}