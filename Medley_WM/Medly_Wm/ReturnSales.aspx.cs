using BusinessLayer;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medly_Wm
{
    public partial class ReturnSales : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
        int iReturnid = 0;
        int Empid = 0;
        int iSoid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            
            {
                if (Request.Cookies["userInfo"]["EmployeeID"] != null && Request.Cookies["userInfo"]["Empname"] != null)
                {
                    Empid = Convert.ToInt32(Request.Cookies["userInfo"]["EmployeeID"]);
                }
                iReturnid = Convert.ToInt32(Request.QueryString.Get("Returnid"));
                if (iReturnid != 0)
                {
                    
                    DataSet Editreturn=new DataSet();
                    Editreturn = dbObj.EditReturn(Convert.ToInt32(iReturnid));
                    lblsoid.Text =Editreturn.Tables[0].Rows[0]["Soid1"].ToString();
                    int ApproverId = Convert.ToInt32(Editreturn.Tables[0].Rows[0]["ApproverId"].ToString());
                    if (ApproverId == Empid)
                    {
                        ddlStatus.Enabled = true;
                    }

                    if (Editreturn.Tables[0].Rows.Count > 0)
                    {
                        string status = Editreturn.Tables[0].Rows[0]["Status"].ToString().Trim();

                        if (status == "Approved")
                        {
                            btnCancel.Text = "Back";
                            ddlSuppliername.Enabled = false;
                            ddlCompanyname.Enabled = false;
                            btnSubmit.Visible = false;

                        }
                        EditReturngrid.Visible=true;
                        Vieweditgrid.DataSource = Editreturn;
                        Vieweditgrid.DataBind();

                        #region Comapny 
                        ddlCompanyname.DataSource = Editreturn;
                        ddlCompanyname.DataTextField = "CompanyName";
                        ddlCompanyname.DataValueField = "SupplierID";
                        ddlCompanyname.DataBind();
                        ddlCompanyname.Items.Insert(0, "Select Company");
                        ddlCompanyname.SelectedValue = Editreturn.Tables[0].Rows[0]["SupplierId"].ToString();
                        #endregion

                        #region Customer
                        ddlSuppliername.DataSource = Editreturn;
                        ddlSuppliername.DataTextField = "PersonName";
                        ddlSuppliername.DataValueField = "TransSupplierID";
                        ddlSuppliername.DataBind();
                        //ddlSuppliername.Items.Insert(0, "Select Customer");
                        ddlCompanyname.SelectedValue = Editreturn.Tables[0].Rows[0]["TransSupplierID"].ToString();
                        #endregion

                        ddlSONumber.DataSource = Editreturn;
                        ddlSONumber.DataTextField = "ReturnPrintno";
                        ddlSONumber.DataValueField = "Returnid";
                        ddlSONumber.DataBind();
                        //ddlSONumber.Items.Insert(0, "Select SO Number");
                        ddlSONumber.SelectedValue = Editreturn.Tables[0].Rows[0]["Returnid"].ToString();

                        txtReturndate.Text =Convert.ToDateTime(Editreturn.Tables[0].Rows[0]["Returndatetime"]).ToString("yyyy-MM-dd");
                        txtReturnNo.Text = Editreturn.Tables[0].Rows[0]["ReturnPrintno"].ToString();

                        ddlApprover.DataSource = Editreturn;
                        ddlApprover.DataTextField = "EmployeeName";
                        ddlApprover.DataValueField = "EmployeeID";
                        ddlApprover.DataBind();
                        ddlApprover.Items.Insert(0, "Select Approver");
                        ddlApprover.SelectedValue= Editreturn.Tables[0].Rows[0]["ApproverId"].ToString();
                        ddlStatus.SelectedItem.Text= Editreturn.Tables[0].Rows[0]["Status"].ToString();
                        txtTotalReturnamnt.Text = Editreturn.Tables[0].Rows[0]["ReturnAmount"].ToString();
                        btnSubmit.Text = "Update";
                    }
                    else
                    {
                        string script = "alert('Edit value Not Available')";
                        ClientScript.RegisterStartupScript(this.GetType(), "Save Message", script, true);
                    }
                    
                }
                else
                {
                    #region GetMAxReturnPrint
                    DataSet Returnprintno = dbObj.GetMaxReturnPrintno_only();
                    txtReturnNo.Text = Returnprintno.Tables[0].Rows[0]["Printno"].ToString();
                    #endregion
                    string Todaydate = DateTime.Now.ToString("yyyy-MM-dd");
                    txtReturndate.Text = DateTime.Now.ToString("yyyy-MM-dd");

                    #region Company Dropdown
                    DataSet ds4 = dbObj.getCompanyname(Todaydate);
                    ddlCompanyname.DataSource = ds4;
                    ddlCompanyname.DataTextField = "CompanyName";
                    ddlCompanyname.DataValueField = "SupplierID";
                    ddlCompanyname.DataBind();
                    ddlCompanyname.Items.Insert(0, "Select Company");
                    #endregion

                    #region Dropdown Approver
                    DataSet dsApprovar = dbObj.Select_Employeename();
                    ddlApprover.DataSource = dsApprovar;
                    ddlApprover.DataTextField = "EmployeeName";
                    ddlApprover.DataValueField = "EmployeeID";
                    ddlApprover.DataBind();
                    ddlApprover.Items.Insert(0, "Select Approver");
                    #endregion
                }

            }
        }

        protected void ddlSuppliername_TextChanged(object sender, EventArgs e)
        {
            #region SO Number Dropdown
            DataSet sonnum = dbObj.GetSonumber(Convert.ToInt32(ddlSuppliername.SelectedValue));
            ddlSONumber.DataSource = sonnum;
            ddlSONumber.DataTextField = "SOPrintno";
            ddlSONumber.DataValueField = "Soid";
            ddlSONumber.DataBind();
            ddlSONumber.Items.Insert(0, "Select SO No");
            #endregion
        }

        protected void ddlSONumber_TextChanged(object sender, EventArgs e)
        {
            returngrid.Visible = true;
            DataSet ReturnProduct = dbObj.GetSoDetailsforReturn(Convert.ToInt32(ddlSONumber.SelectedValue));
            if (ReturnProduct.Tables[0].Rows.Count > 0)
            {
                gvReturn.DataSource = ReturnProduct;
                gvReturn.DataBind();
            }
            else
            {
                string script = "alert('Return Already Completed')";
                ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
            }
            
        }

        protected void txtReturnAmnt_TextChanged(object sender, EventArgs e)
        {
            UpdateTotalReturnAmount();
        }

        protected void txtReturnQty_TextChanged(object sender, EventArgs e)
        {
            GridViewRow row = (GridViewRow)((TextBox)sender).NamingContainer;
            TextBox txtReturnQty = (TextBox)row.FindControl("txtReturnQty");
            Label txtPriceperpack = (Label)row.FindControl("txtPriceperpack");
            TextBox txtReturnAmnt = (TextBox)row.FindControl("txtReturnAmnt");
            Label txtVAT = (Label)row.FindControl("txtVAT");

            if (txtReturnQty != null && txtPriceperpack != null && txtReturnAmnt != null && txtVAT != null)
            {
               
                
                decimal returnQty, pricePerPack, returnAmnt;
                if (decimal.TryParse(txtReturnQty.Text, out returnQty) &&
                    decimal.TryParse(txtPriceperpack.Text, out pricePerPack))
                {
                    HiddenField hidden = (HiddenField)row.FindControl("Hidden");
                    int hiddenvalus = Convert.ToInt32(hidden.Value);
                    DataSet dsreturnqty = dbObj.GetSoQtyDetailsforReturn(Convert.ToInt32(ddlSONumber.SelectedValue), hiddenvalus);
                    int SoQty =Convert.ToInt32(dsreturnqty.Tables[0].Rows[0]["SoQty"]);
                    if (SoQty >= Convert.ToInt32(returnQty))
                    { 
                    returnAmnt = returnQty * pricePerPack;
                    //txtReturnAmnt.Text = returnAmnt.ToString();
                    // decimal txtReturnAmnt = Convert.ToDecimal(txttotalamt.Text);
                    decimal vatamnt = (returnAmnt * decimal.Parse(txtVAT.Text)) / 100;
                    decimal vatcal = Convert.ToDecimal(returnAmnt) + vatamnt;
                    txtReturnAmnt.Text = vatcal.ToString();
                    UpdateTotalReturnAmount();

                    }
                    else
                    {
                        string script = "alert('Please Enter Valid Return Qty')";
                        ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                    }
                }
                else
                {
                    txtReturnAmnt.Text = string.Empty;
                }
            }
        }
        private void UpdateTotalReturnAmount()
        {
            double totalReturnAmount = 0;

            foreach (GridViewRow row in gvReturn.Rows)
            {
                TextBox txtReturnAmnt = (TextBox)row.FindControl("txtReturnAmnt");

                if (double.TryParse(txtReturnAmnt.Text, out double returnAmnt))
                {
                    totalReturnAmount += returnAmnt;
                    txtTotalReturnamnt.Text = totalReturnAmount.ToString();
                }
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ddlCompanyname.SelectedValue == "Select Company")
            {
                string script = "alert('Please Select Company')";
                ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
            }
            else
            {
                if (ddlSuppliername.SelectedValue == "Select Customer")
                {
                    string script = "alert('Please Select Customer')";
                    ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                }
                else if (txtTotalReturnamnt.Text=="0")
                {
                    string script = "alert('Please Enter Return Product Details')";
                    ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                }
                else if (ddlApprover.SelectedValue == "Select Approver")
                {
                    string script = "alert('Please Select Approver')";
                    ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                }
                else
                {
                    if (btnSubmit.Text == "Submit")
                    {
                        #region GetMAxReturnPrint
                        DataSet dsSOprintno = dbObj.GetMaxReturnPrintno_only();
                        int ireturnprintMax = Convert.ToInt32(dsSOprintno.Tables[0].Rows[0]["Printno"].ToString());
                        #endregion
                        int isucess = 0;
                        isucess = dbObj.InsertReturn(ddlSuppliername.SelectedValue, Convert.ToDateTime(txtReturndate.Text), ddlApprover.SelectedValue, txtTotalReturnamnt.Text,ddlStatus.SelectedItem.Text.Trim(), ireturnprintMax.ToString(), Convert.ToString(ddlSONumber.SelectedValue));
                        #region Insert_TransPO

                        #region GetMAxReturnPrint
                        DataSet maxreturnid = dbObj.GetMaxReturnID_only();
                        int Returnid = Convert.ToInt32(maxreturnid.Tables[0].Rows[0]["Returnid"].ToString());
                        #endregion
                        DataSet dsreturn = new DataSet();
                        dsreturn = dbObj.SelectSoDetailsFroReturn(Convert.ToString(ddlSONumber.SelectedValue));
                        if (dsreturn.Tables[0].Rows.Count > 0)
                        {
                            int count = dsreturn.Tables[0].Rows.Count;
                            for (int i = 0; i < count; i++)
                            {
                                int productid = Convert.ToInt32(dsreturn.Tables[0].Rows[i]["Productid"]);
                                string Licenseno = dsreturn.Tables[0].Rows[i]["LicenseNo"].ToString();
                                string Productname = dsreturn.Tables[0].Rows[i]["Productname"].ToString();
                                string Dosageform = dsreturn.Tables[0].Rows[i]["Dosageform"].ToString();
                                string Strength = dsreturn.Tables[0].Rows[i]["Strength"].ToString();
                                string Packtype = dsreturn.Tables[0].Rows[i]["Packtype"].ToString();
                                string Packsize = dsreturn.Tables[0].Rows[i]["Packsize"].ToString();
                                string SoQty = dsreturn.Tables[0].Rows[i]["SoQty"].ToString();
                                string Priceperpack = dsreturn.Tables[0].Rows[i]["Priceperpack"].ToString();
                                string VAT = dsreturn.Tables[0].Rows[i]["VAT"].ToString();
                                string Totalamount = dsreturn.Tables[0].Rows[i]["Totalamount"].ToString();
                                TextBox txtReturnQty = (TextBox)gvReturn.Rows[i].FindControl("txtReturnQty");
                                string ReturnQty = txtReturnQty.Text;
                                TextBox txtReturnAmnt = (TextBox)gvReturn.Rows[i].FindControl("txtReturnAmnt");
                                string ReturnAmnt = txtReturnAmnt.Text;
                                int isuccess = 0;
                                isuccess = dbObj.InsertReturnvalues(Returnid, Convert.ToInt32(ddlSONumber.SelectedValue), productid, Licenseno, Productname, Dosageform, Strength, Packtype, Packsize, SoQty, Priceperpack, VAT, Totalamount, ReturnQty, ReturnAmnt);
                            }
                            string script = "alert('Sales Return Stored Successfully')";
                            ClientScript.RegisterStartupScript(this.GetType(), "Save Message", script, true);

                        }
                        else
                        {
                            string script = "alert('Data Not inserted')";
                            ClientScript.RegisterStartupScript(this.GetType(), "Save Message", script, true);
                        }

                        #endregion
                        Response.Redirect("GoodsReturn.aspx");
                    }
                    else if (btnSubmit.Text == "Update")
                    {
                        int isucess = 0;
                        isucess = dbObj.UpdateReturn(ddlSuppliername.SelectedValue, Convert.ToDateTime(txtReturndate.Text), ddlApprover.SelectedValue,txtTotalReturnamnt.Text,ddlStatus.SelectedItem.Text.Trim(),txtReturnNo.Text, Convert.ToInt32(ddlSONumber.SelectedValue), Convert.ToInt32(lblsoid.Text));
                        string script = "alert('Updated Return Values')";
                        ClientScript.RegisterStartupScript(this.GetType(), "Save Message", script, true);
                        Response.Redirect("GoodsReturn.aspx");
                    }
                    else
                    {
                        string script = "alert('Data Not inserted')";
                        ClientScript.RegisterStartupScript(this.GetType(), "Save Message", script, true);
                    }
                }
            }

           
            
        }

        protected void ddlCompanyname_TextChanged(object sender, EventArgs e)
        {
            string Todaydate = DateTime.Now.ToString("yyyy-MM-dd");
            #region Customer Dropdown
            DataSet ds4 = dbObj.getsupplierforreturn(Todaydate,Convert.ToInt32(ddlCompanyname.SelectedValue));
            ddlSuppliername.DataSource = ds4;
            ddlSuppliername.DataTextField = "PersonName";
            ddlSuppliername.DataValueField = "TransSupplierID";
            ddlSuppliername.DataBind();
            ddlSuppliername.Items.Insert(0, "Select Customer");
            #endregion
        }

        protected void gvReturn_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && gvReturn.EditIndex == -1)
            {
                iReturnid = Convert.ToInt32(Request.QueryString.Get("Returnid"));

                if (iReturnid != 0)
                {
                    LinkButton btnEdit = (LinkButton)e.Row.FindControl("btnedit");
                    ImageButton imgEdit = (ImageButton)e.Row.FindControl("imgEdit");

                    LinkButton btndel = (LinkButton)e.Row.FindControl("btndel");
                    ImageButton imgDel = (ImageButton)e.Row.FindControl("imgDel");

                    DataRowView drv = (DataRowView)e.Row.DataItem;
                    string Status = Convert.ToString(drv["Status"]);

                    if (Status == "Approved")
                    {
                        btndel.Enabled = false;
                        imgDel.Enabled = false;
                    }
                }
              
            }

        }
    }
}
