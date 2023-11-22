using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Medly_Wm
{
    public partial class AddProduct : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
        int iProductID = 0; int Empid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                txtInitialadditiondate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtInitialadditiondate.Enabled = false;
                #region Edit
                iProductID = Convert.ToInt32(Request.QueryString.Get("iProductID"));
                if (Request.Cookies["userInfo"]["EmployeeID"] != null && Request.Cookies["userInfo"]["Empname"] != null)
                {
                    Empid = Convert.ToInt32(Request.Cookies["userInfo"]["EmployeeID"]);


                }
                if (iProductID != 0)
                {

                    DataSet dsProdId = new DataSet();
                    dsProdId = dbObj.selectProduct_byProductId(iProductID);
                    ViewState["vsPrdct"] = iProductID;

                    if (dsProdId.Tables[0].Rows.Count > 0)
                    {
                        int ApproverId= Convert.ToInt32(dsProdId.Tables[0].Rows[0]["Approvarid"].ToString());
                        if (ApproverId == Empid)
                        {
                            ddlStatus.Enabled = true;
                        }
                        //txtProductid.Text = dsProdId.Tables[0].Rows[0]["ProductID"].ToString();
                        txtInitialadditiondate.Text = ((DateTime)dsProdId.Tables[0].Rows[0]["Initialadditiondate"]).ToString("yyyy-MM-dd");
                        txtProductname.Text = dsProdId.Tables[0].Rows[0]["Productname"].ToString();
                        txtLicenseno.Text = dsProdId.Tables[0].Rows[0]["Licenseno"].ToString();
                       // txtvalidtill.Text = ((DateTime)dsProdId.Tables[0].Rows[0]["Validtill"]).ToString("yyyy-MM-dd");
                        ddlDosageform.SelectedItem.Text = dsProdId.Tables[0].Rows[0]["Dosageform"].ToString();
                        txtPacksize.Text = dsProdId.Tables[0].Rows[0]["Packsize"].ToString();
                        txtStrength.Text = dsProdId.Tables[0].Rows[0]["Strength"].ToString();
                        ddlProductanufacture.SelectedItem.Text = dsProdId.Tables[0].Rows[0]["Productmanufacture"].ToString();
                        ddlproductcatogory.SelectedItem.Text = dsProdId.Tables[0].Rows[0]["Productcatogory"].ToString();
                        txtProductCode.Text = dsProdId.Tables[0].Rows[0]["Productcode"].ToString();
                        txtGTINBarcode.Text = dsProdId.Tables[0].Rows[0]["ProductGTINbarcode"].ToString();
                        ddlTaxationtype.SelectedItem.Text = dsProdId.Tables[0].Rows[0]["Taxationtype"].ToString();
                        txtminimumqty.Text = dsProdId.Tables[0].Rows[0]["ProductQty"].ToString();
                        txtPIPcode.Text = dsProdId.Tables[0].Rows[0]["PIPcode"].ToString();
                        //  ddlPacktype.SelectedItem.Text = dsProdId.Tables[0].Rows[0]["Packtype"].ToString();
                        // txtPriceperpack.Text = dsProdId.Tables[0].Rows[0]["Priceperpack"].ToString();
                        //  ddlCurrency.SelectedItem.Text = dsProdId.Tables[0].Rows[0]["Currency"].ToString();
                        // ddlproductmanufacturecountry.SelectedItem.Text = dsProdId.Tables[0].Rows[0]["Productmanufacturecountry"].ToString();
                        // ddlProductapprovalauthority.SelectedItem.Text = dsProdId.Tables[0].Rows[0]["Productaprovalauthority"].ToString();
                        //ddlProductapprovalstatus.SelectedItem.Text = dsProdId.Tables[0].Rows[0]["Productaprovalstatus"].ToString();
                        // txtTax.Text = dsProdId.Tables[0].Rows[0]["Tax"].ToString();
                        //imgProductphoto.FileContent = dsDesgnId.Tables[0].Rows[0]["Productphoto"].ToString();
                        #region Dropdown Approver
                        DataSet dsApprovar1 = new DataSet();
                        dsApprovar1 = dbObj.Select_Employeename();
                        if (dsApprovar1.Tables[0].Rows.Count > 0)
                        {
                            ddlSelectapprover.DataSource = dsApprovar1;
                            ddlSelectapprover.DataTextField = "EmployeeName";
                            ddlSelectapprover.DataValueField = "EmployeeID";
                            ddlSelectapprover.DataBind();
                            ddlSelectapprover.Items.Insert(0, "Select Approver");
                        }
                        #endregion
                        ddlSelectapprover.SelectedValue = dsProdId.Tables[0].Rows[0]["Approvarid"].ToString();
                        ddlStatus.SelectedItem.Text = dsProdId.Tables[0].Rows[0]["Status"].ToString();
                        ddlProductStatus.SelectedItem.Text = dsProdId.Tables[0].Rows[0]["Productstatus"].ToString();
                        btnSubmit.Text = "Update";
                    }
                }
                #endregion
                //#region Dropdown Approver
                //DataSet dsApprovar = new DataSet();
                //dsApprovar = dbObj.Select_Employeename();
                //if (dsApprovar.Tables[0].Rows.Count > 0)
                //{
                //   ddlSelectapprover.DataSource = dsApprovar;
                //    ddlSelectapprover.DataTextField = "EmployeeName";
                //    ddlSelectapprover.DataValueField = "EmployeeID";
                //    ddlSelectapprover.DataBind();
                //    ddlSelectapprover.Items.Insert(0, "Select Approver");
                //}
                //#endregion

            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ddlDosageform.SelectedItem.Text == "Select")
            {
                string script = "alert('Select Dosage form')";
                ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
            }
            else if (ddlProductanufacture.SelectedItem.Text == "Select")
            {
                string script = "alert('Select Product Manufacturer')";
                ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
            }
            else if (ddlproductcatogory.SelectedItem.Text == "Select")
            {
                string script = "alert('Select Product Catogory')";
                ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
            }
            //else if (ddlSelectapprover.SelectedValue == "Select Approver")
            //{
            //    string script = "alert('Select Approver')";
            //    ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
            //}
            else
            {
                if (btnSubmit.Text == "Submit")
                {
                    DateTime TodayDate = DateTime.ParseExact(txtInitialadditiondate.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    //DateTime validtil = DateTime.ParseExact(txtInitialadditiondate.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    int isucess = 0;
                    isucess = dbObj.InsertProduct(TodayDate, txtProductname.Text, txtLicenseno.Text, ddlDosageform.SelectedItem.Text, txtPacksize.Text, txtStrength.Text, ddlProductanufacture.SelectedItem.Text, ddlproductcatogory.SelectedItem.Text, txtProductCode.Text, txtGTINBarcode.Text, ddlTaxationtype.SelectedItem.Text,0,"0", txtminimumqty.Text,txtPIPcode.Text,ddlProductStatus.SelectedItem.Text);
                    // isucess = dbObj.InsertProduct(Convert.ToDateTime(txtInitialadditiondate.Text), txtProductname.Text, txtLicenseno.Text, Convert.ToDateTime(txtvalidtill.Text), ddlDosageform.SelectedItem.Text, ddlPacktype.SelectedItem.Text, txtPacksize.Text, txtPriceperpack.Text, txtStrength.Text, ddlCurrency.SelectedItem.Text, ddlProductanufacture.SelectedItem.Text, ddlproductmanufacturecountry.SelectedItem.Text, txtProductCode.Text, txtGTINBarcode.Text, ddlProductapprovalauthority.SelectedItem.Text, ddlProductapprovalstatus.SelectedItem.Text, txtTax.Text, ddlTaxationtype.SelectedItem.Text, imgProductphoto.FileName, ddlSelectapprover.SelectedValue, Convert.ToInt32(ddlSelectapprover.SelectedValue), ddlStatus.SelectedItem.Text);
                    //Response.Redirect("../Accountsbootstrap/viewbranch.aspx");
                    string script = "alert('Data Saved')";
                    ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                    Response.Redirect("ProductGridpage.aspx");
                }
                else if (btnSubmit.Text == "Update")
                {
                    int isucess = 0;
                    isucess = dbObj.UpdateProduct(Convert.ToInt32(ViewState["vsPrdct"].ToString()), Convert.ToDateTime(txtInitialadditiondate.Text), txtProductname.Text, txtLicenseno.Text, ddlDosageform.SelectedItem.Text, txtPacksize.Text, txtStrength.Text, ddlProductanufacture.SelectedItem.Text, ddlproductcatogory.SelectedItem.Text, txtProductCode.Text, txtGTINBarcode.Text, ddlTaxationtype.SelectedItem.Text, txtminimumqty.Text,txtPIPcode.Text, ddlProductStatus.SelectedItem.Text);
                    string script = "alert('Data Updated')";
                    ClientScript.RegisterStartupScript(this.GetType(), "UpdateMessage", script, true);
                    Response.Redirect("ProductGridpage.aspx");
                }

            }
        }

        protected void btsclear_Click(object sender, EventArgs e)
        {
           
        }
    }
}
