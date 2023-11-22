using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medly_Wm
{
    public partial class SupplierMaster : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
        int isupplierid = 0;
        int iProductID = 0; int Empid = 0;
        protected void Page_Load(object sender, EventArgs e)
        { 
            if (!IsPostBack)
            {
                txtadditionaldate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtadditionaldate.Enabled = false;
                iProductID = Convert.ToInt32(Request.QueryString.Get("iProductID"));
                if (Request.Cookies["userInfo"]["EmployeeID"] != null && Request.Cookies["userInfo"]["Empname"] != null)
                {
                    Empid = Convert.ToInt32(Request.Cookies["userInfo"]["EmployeeID"]);

                }
                #region Dropdown Country
                DataSet dsCountry = new DataSet();
                dsCountry = dbObj.Select_Country();
                if (dsCountry.Tables[0].Rows.Count > 0)
                {
                    ddlcountry.DataSource = dsCountry;
                    ddlcountry.DataTextField = "CountryName";
                    ddlcountry.DataValueField = "CountryID";
                    ddlcountry.DataBind();

                    ddlCCountry1.DataSource = dsCountry;
                    ddlCCountry1.DataTextField = "CountryName";
                    ddlCCountry1.DataValueField = "CountryID";
                    ddlCCountry1.DataBind();

                    ddlCCountry2.DataSource = dsCountry;
                    ddlCCountry2.DataTextField = "CountryName";
                    ddlCCountry2.DataValueField = "CountryID";
                    ddlCCountry2.DataBind();

                    ddlCCountry3.DataSource = dsCountry;
                    ddlCCountry3.DataTextField = "CountryName";
                    ddlCCountry3.DataValueField = "CountryID";
                    ddlCCountry3.DataBind();
                }
                #endregion
                #region Edit
                isupplierid = Convert.ToInt32(Request.QueryString.Get("Supid"));

                if (isupplierid != 0)
                {
                    DataSet dsSupId = new DataSet();
                    dsSupId = dbObj.selectsuplier_bysuplierid(isupplierid);
                    ViewState["vssupl"] = isupplierid;
                    if (dsSupId.Tables[0].Rows.Count > 0)
                    {
                        int ApproverId = Convert.ToInt32(dsSupId.Tables[0].Rows[0]["SelectApproverid"].ToString());
                        if (ApproverId == Empid)
                        {
                            ddlStatus.Enabled = true;
                        }
                        txtsupplierid.Text = dsSupId.Tables[0].Rows[0]["SupplierID"].ToString();
                        txtadditionaldate.Text = ((DateTime)dsSupId.Tables[0].Rows[0]["Initialadditionaldate"]).ToString("yyyy-MM-dd");
                        txtcompanyname.Text = dsSupId.Tables[0].Rows[0]["CompanyName"].ToString();
                        txtcompanyname.Enabled = false;
                        txtcontactname.Text = dsSupId.Tables[0].Rows[0]["ContactName"].ToString();
                        txtcontactname.Enabled = false;
                        txtcontactname1.Text = dsSupId.Tables[0].Rows[0]["ContactName1"].ToString();
                        txtcontactname2.Text = dsSupId.Tables[0].Rows[0]["ContactName2"].ToString();
                        txtcontactname3.Text = dsSupId.Tables[0].Rows[0]["ContactName3"].ToString();
                        txtcontactname4.Text = dsSupId.Tables[0].Rows[0]["ContactName4"].ToString();
                        txtcontactemail.Text = dsSupId.Tables[0].Rows[0]["ContactEmail"].ToString();
                        txtContactnumber.Text = dsSupId.Tables[0].Rows[0]["ContactNumber"].ToString();
                        txtvalidtill.Text = ((DateTime)dsSupId.Tables[0].Rows[0]["ValidTill"]).ToString("yyyy-MM-dd");
                      //  ddldefaultcurrency.SelectedItem.Text = dsSupId.Tables[0].Rows[0]["DefaultCurrency"].ToString();
                        ddlsuplierstatus.SelectedItem.Text = dsSupId.Tables[0].Rows[0]["SupplierStatus"].ToString();
                        ddlsuplierqualification.SelectedItem.Text = dsSupId.Tables[0].Rows[0]["SupplierQualification"].ToString();
                        txtaddressline1.Text = dsSupId.Tables[0].Rows[0]["AddressLine1"].ToString();
                        Addres2.Text = dsSupId.Tables[0].Rows[0]["AddressLine2"].ToString();
                        Addres3.Text = dsSupId.Tables[0].Rows[0]["AddressLine3"].ToString();
                        Addres4.Text = dsSupId.Tables[0].Rows[0]["AddressLine4"].ToString();
                        Addres5.Text = dsSupId.Tables[0].Rows[0]["AddressLine5"].ToString();
                        //txtaddressline2.Text = dsSupId.Tables[0].Rows[0]["AddressLine2"].ToString();
                        //txtaddressline3.Text = dsSupId.Tables[0].Rows[0]["AddessLine3"].ToString();
                      //  txttown.Text = dsSupId.Tables[0].Rows[0]["Town"].ToString();
                        DataSet dscountry1 = dbObj.Select_Country();
                        if (dscountry1.Tables[0].Rows.Count > 0)
                        {
                            ddlcountry.DataSource = dscountry1;
                            ddlcountry.DataTextField = "CountryName";
                            ddlcountry.DataValueField = "CountryID";
                            ddlcountry.DataBind();
                            ddlcountry.Items.Insert(0, "Select Country");
                        }
                        ddlcountry.SelectedItem.Text = dsSupId.Tables[0].Rows[0]["Country"].ToString();
                        txtposcode.Text = dsSupId.Tables[0].Rows[0]["PostCode"].ToString();
                        //#region Dropdown Approver
                        //DataSet dsApprovar1 = new DataSet();
                        //dsApprovar1 = dbObj.Select_Employeename();
                        //if (dsApprovar1.Tables[0].Rows.Count > 0)
                        //{
                        //    ddlSelectapprover.DataSource = dsApprovar1;
                        //    ddlSelectapprover.DataTextField = "EmployeeName";
                        //    ddlSelectapprover.DataValueField = "EmployeeID";
                        //    ddlSelectapprover.DataBind();
                        //    ddlSelectapprover.Items.Insert(0, "Select Approver");
                        //}
                        //#endregion
                        //ddlSelectapprover.SelectedValue = dsSupId.Tables[0].Rows[0]["SelectApproverid"].ToString();
                        //ddlStatus.SelectedItem.Text = dsSupId.Tables[0].Rows[0]["Status"].ToString();

                        #region Supplier Contact
                        DataSet Supp_Contact = dbObj.selectTranssuplier_bysuplierid(isupplierid);
                        if (Supp_Contact.Tables[0].Rows.Count > 0)
                        {
                            divContact1.Visible = true;
                            txtcontactname.Text = Supp_Contact.Tables[0].Rows[0]["PersonName"].ToString();
                            txtcontactemail.Text = Supp_Contact.Tables[0].Rows[0]["EmailId"].ToString(); 
                            txtContactnumber.Text = Supp_Contact.Tables[0].Rows[0]["Phone"].ToString();
                            txtaddressline1.Text = Supp_Contact.Tables[0].Rows[0]["Address"].ToString();
                            ddlcountry.SelectedValue = Supp_Contact.Tables[0].Rows[0]["Country"].ToString();
                            txtposcode.Text = Supp_Contact.Tables[0].Rows[0]["Postcode"].ToString();
                            ddlNumber.SelectedItem.Text= Supp_Contact.Tables[0].Rows[0]["CountryCode"].ToString();

                            if (Supp_Contact.Tables[0].Rows.Count > 1)
                            {
                                divContact2.Visible = true;
                                txtCName1.Text = Supp_Contact.Tables[0].Rows[1]["PersonName"].ToString();
                                txtCEmail1.Text = Supp_Contact.Tables[0].Rows[1]["EmailId"].ToString(); 
                                txtCNumber1.Text = Supp_Contact.Tables[0].Rows[1]["Phone"].ToString();
                                txtCAddress1.Text = Supp_Contact.Tables[0].Rows[1]["Address"].ToString();
                                ddlCCountry1.SelectedValue = Supp_Contact.Tables[0].Rows[1]["Country"].ToString();
                                txtCPost1.Text = Supp_Contact.Tables[0].Rows[1]["Postcode"].ToString();
                                ddlCCode1.SelectedItem.Text = Supp_Contact.Tables[0].Rows[1]["CountryCode"].ToString();
                               
                            }


                            if (Supp_Contact.Tables[0].Rows.Count > 2)
                            {
                                divContact3.Visible = true;
                                txtCName2.Text = Supp_Contact.Tables[0].Rows[2]["PersonName"].ToString();
                                txtCEmail2.Text = Supp_Contact.Tables[0].Rows[2]["EmailId"].ToString(); 
                                txtCNumber2.Text = Supp_Contact.Tables[0].Rows[2]["Phone"].ToString();
                                txtCAddress2.Text = Supp_Contact.Tables[0].Rows[2]["Address"].ToString();
                                ddlCCountry2.SelectedValue = Supp_Contact.Tables[0].Rows[2]["Country"].ToString();
                                txtCPost2.Text = Supp_Contact.Tables[0].Rows[2]["Postcode"].ToString();
                                ddlCCode2.SelectedItem.Text = Supp_Contact.Tables[0].Rows[2]["CountryCode"].ToString();

                            }
                            if (Supp_Contact.Tables[0].Rows.Count > 3)
                            {
                                divContact4.Visible = true;
                                txtCName3.Text = Supp_Contact.Tables[0].Rows[3]["PersonName"].ToString();
                                txtCEmail3.Text = Supp_Contact.Tables[0].Rows[3]["EmailId"].ToString();
                                txtCNumber3.Text = Supp_Contact.Tables[0].Rows[3]["Phone"].ToString();
                                txtCAddress3.Text = Supp_Contact.Tables[0].Rows[3]["Address"].ToString(); 
                                ddlCCountry3.SelectedValue = Supp_Contact.Tables[0].Rows[3]["Country"].ToString();
                                txtCPost3.Text = Supp_Contact.Tables[0].Rows[3]["Postcode"].ToString();
                                ddlCCode3.SelectedItem.Text = Supp_Contact.Tables[0].Rows[3]["CountryCode"].ToString();

                            }
                        }
                        #endregion

                        btnSubmit.Text = "Update";
                        
                    }
                }
                #endregion
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

                DataSet dsSuppId = dbObj.Select_MaxSupplier();
                int Id = 0;
                if (dsSuppId.Tables[0].Rows.Count > 0 && dsSuppId.Tables[0].Rows != null)
                {
                     Id = Convert.ToInt32(dsSuppId.Tables[0].Rows[0]["Id"].ToString());
                   
                }
                else
                {

                    Id = 1;
                }
                txtsupplierid.Text = Id.ToString();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ddlsuplierstatus.SelectedItem.Text == "Select")
            {
                string script = "alert('Select Status')";
                ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
            }
            else if (ddlsuplierqualification.SelectedItem.Text == "Select")
            {
                string script = "alert('Select Supplier Type')";
                ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
            }
            //else if (ddlSelectapprover.SelectedItem.Text == "Select Approver")
            //{
            //    string script = "alert('Select Approver')";
            //    ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
            //}
            else
            {

                if (btnSubmit.Text == "Submit")
                {
                    DataSet comname = dbObj.Select_Supliername(txtcompanyname.Text);
                    if (comname.Tables[0].Rows.Count > 0)
                    {
                        string script1 = "alert('Company Name Already Created,Please Create New one !.')";
                        ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script1, true);
                    }
                    else
                    {
                            int isucess = 0;
                            isucess = dbObj.InsertSuplier(Convert.ToDateTime(txtadditionaldate.Text), txtcompanyname.Text, txtcontactname.Text, txtcontactname1.Text, txtcontactname2.Text, txtcontactname3.Text, txtcontactname4.Text, txtcontactemail.Text, (txtContactnumber.Text), Convert.ToDateTime(txtvalidtill.Text), ddlsuplierstatus.SelectedItem.Text, ddlsuplierqualification.SelectedItem.Text, txtaddressline1.Text, Addres2.Text, Addres3.Text, Addres4.Text, Addres5.Text, ddlcountry.SelectedValue, txtposcode.Text);

                            int iSuccess1 = dbObj.InsertTransSuplier(Convert.ToInt32(txtsupplierid.Text), txtcontactname.Text, txtcontactemail.Text, txtContactnumber.Text, txtaddressline1.Text, Convert.ToInt32(ddlcountry.SelectedValue), txtposcode.Text, ddlNumber.SelectedItem.Text);
                            if (divContact2.Visible == true && txtCName1.Text != "")
                            {

                                int iSuccess2 = dbObj.InsertTransSuplier(Convert.ToInt32(txtsupplierid.Text), txtCName1.Text, txtCEmail1.Text, txtCNumber1.Text, txtCAddress1.Text, Convert.ToInt32(ddlCCountry1.SelectedValue), txtCPost1.Text, ddlCCode1.SelectedItem.Text);
                            }

                            if (divContact3.Visible == true && txtCName2.Text != "")
                            {

                                int iSuccess3 = dbObj.InsertTransSuplier(Convert.ToInt32(txtsupplierid.Text), txtCName2.Text, txtCEmail2.Text, txtCNumber2.Text, txtCAddress2.Text, Convert.ToInt32(ddlCCountry2.SelectedValue), txtCPost2.Text, ddlCCode2.SelectedItem.Text);
                            }


                            if (divContact4.Visible == true && txtCName3.Text != "")
                            {

                                int iSucces4 = dbObj.InsertTransSuplier(Convert.ToInt32(txtsupplierid.Text), txtCName3.Text, txtCEmail3.Text, txtCNumber3.Text, txtCAddress3.Text, Convert.ToInt32(ddlCCountry3.SelectedValue), txtCPost3.Text, ddlCCode3.SelectedItem.Text);
                            }
                            string script = "alert('Data Saved')";
                            ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                            Response.Redirect("SuplierGridpage.aspx");
                        }
                       

                    }
                else if (btnSubmit.Text == "Update")
                {
                    isupplierid = Convert.ToInt32(Request.QueryString.Get("Supid"));

                    int isucess = 0;
                    isucess = dbObj.UpdateSuplier(Convert.ToInt32(isupplierid), Convert.ToDateTime(txtadditionaldate.Text), txtcompanyname.Text, txtcontactname.Text, txtcontactname1.Text, txtcontactname2.Text, txtcontactname3.Text, txtcontactname4.Text, txtcontactemail.Text, (txtContactnumber.Text), Convert.ToDateTime(txtvalidtill.Text), ddlsuplierstatus.SelectedItem.Text, ddlsuplierqualification.SelectedItem.Text, txtaddressline1.Text, Addres2.Text, Addres3.Text, Addres4.Text, Addres5.Text, ddlcountry.SelectedValue, txtposcode.Text);
                    isucess = dbObj.deleteTransSuplier(Convert.ToInt32(isupplierid));

                    int iSuccess1 = dbObj.InsertTransSuplier(Convert.ToInt32(isupplierid), txtcontactname.Text, txtcontactemail.Text, txtContactnumber.Text, txtaddressline1.Text, Convert.ToInt32(ddlcountry.SelectedValue), txtposcode.Text, ddlNumber.SelectedItem.Text);
                    if (divContact2.Visible == true && txtCName1.Text != "")
                    {

                        int iSuccess2 = dbObj.InsertTransSuplier(Convert.ToInt32(isupplierid), txtCName1.Text, txtCEmail1.Text, txtCNumber1.Text, txtCAddress1.Text, Convert.ToInt32(ddlCCountry1.SelectedValue), txtCPost1.Text, ddlCCode1.SelectedItem.Text);
                    }

                    if (divContact3.Visible == true && txtCName2.Text != "")
                    {

                        int iSuccess3 = dbObj.InsertTransSuplier(Convert.ToInt32(isupplierid), txtCName2.Text, txtCEmail2.Text, txtCNumber2.Text, txtCAddress2.Text, Convert.ToInt32(ddlCCountry2.SelectedValue), txtCPost2.Text, ddlCCode2.SelectedItem.Text);
                    }


                    if (divContact4.Visible == true && txtCName3.Text != "")
                    {

                        int iSucces4 = dbObj.InsertTransSuplier(Convert.ToInt32(isupplierid), txtCName3.Text, txtCEmail3.Text, txtCNumber3.Text, txtCAddress3.Text, Convert.ToInt32(ddlCCountry3.SelectedValue), txtCPost3.Text, ddlCCode3.SelectedItem.Text);
                    }

                    string script = "alert('Data Updated')";
                    ClientScript.RegisterStartupScript(this.GetType(), "UpdateMessage", script, true);
                    Response.Redirect("SuplierGridpage.aspx");
                }

            }
        }

        protected void addtextbox_Click(object sender, EventArgs e)
        {
            textBoxContainer.Visible = true;
        }
        protected void addtextbox2_Click(object sender, EventArgs e)
        {
            textBoxContainer1.Visible = true;
        }
        protected void addtextbox3_Click(object sender, EventArgs e)
        {
            textBoxContainer2.Visible = true;
        }
        protected void addtextbox4_Click(object sender, EventArgs e)
        {
            textBoxContainer3.Visible = true;
        }

        protected void addname_Click(object sender, EventArgs e)
        {
            //name1container.Visible = true;
            divContact2.Visible = true;
        }

        protected void addname1_Click(object sender, EventArgs e)
        {
            // name2container.Visible = true;
            divContact3.Visible = true;
        }

        protected void addname2_Click(object sender, EventArgs e)
        {
            //name3container.Visible = true;
            divContact4.Visible = true;
        }

        protected void addname3_Click(object sender, EventArgs e)
        {
            name4container.Visible = true;
        }

        protected void addname4_Click(object sender, EventArgs e)
        {

        }
        protected void minusname2_Click(object sender, ImageClickEventArgs e)
        {
            
            divContact2.Visible = false;
        }

        protected void minusname3_Click(object sender, ImageClickEventArgs e)
        {
            
            divContact3.Visible = false;
        }

        protected void minusname4_Click(object sender, ImageClickEventArgs e)
        {
            divContact4.Visible = false;
        }

        protected void txtContactnumber_TextChanged(object sender, EventArgs e)
        {
            isupplierid = Convert.ToInt32(Request.QueryString.Get("Supid"));
            if (isupplierid != 0)
            {
                DataSet dssupcontactcheck = dbObj.selectsuplier_Contactnumsupid(isupplierid,txtContactnumber.Text);
                if (dssupcontactcheck.Tables[0].Rows.Count > 0)
                {
                    string script = "alert('Please change contact Number , Given Number already stored')";
                    ClientScript.RegisterStartupScript(this.GetType(), "UpdateMessage", script, true);
                    txtContactnumber.Text = "";
                }
                else
                {

                }
            }
            else
            {
                DataSet dssupcontactcheck = dbObj.selectsuplier_Contactnum(txtContactnumber.Text);
                if (dssupcontactcheck.Tables[0].Rows.Count>0)
                {
                    string script = "alert('Please change contact Number , Given Number already stored')";
                    ClientScript.RegisterStartupScript(this.GetType(), "UpdateMessage", script, true);
                    txtContactnumber.Text = "";
                }
                else
                {

                }
            }
            
        }

        protected void txtCNumber1_TextChanged(object sender, EventArgs e)
        {
            if (txtCNumber1.Text == txtContactnumber.Text)
            {
                string script = "alert('Please change contact Number2')";
                ClientScript.RegisterStartupScript(this.GetType(), "UpdateMessage", script, true);
                txtCNumber1.Text = "";
            }
            else
            {
                isupplierid = Convert.ToInt32(Request.QueryString.Get("Supid"));
                if (isupplierid != 0)
                {
                    DataSet dssupcontactcheck = dbObj.selectsuplier_Contactnumtranssupid(isupplierid, txtCNumber1.Text);
                    if (dssupcontactcheck.Tables[0].Rows.Count > 0)
                    {
                        string script = "alert('Please change contact Number2 , Given Number already stored')";
                        ClientScript.RegisterStartupScript(this.GetType(), "UpdateMessage", script, true);
                        txtCNumber1.Text = "";
                    }
                }
                else
                {
                    DataSet dssupcontactcheck = dbObj.selectsuplier_Contactnumtrans(txtCNumber1.Text);
                    if (dssupcontactcheck.Tables[0].Rows.Count > 0)
                    {
                        string script = "alert('Please change contact Number2 , Given Number already stored')";
                        ClientScript.RegisterStartupScript(this.GetType(), "UpdateMessage", script, true);
                        txtCNumber1.Text = "";
                    }
                }
            }
          
        }

        protected void txtCNumber2_TextChanged(object sender, EventArgs e)
        {
            if (txtCNumber2.Text == txtContactnumber.Text|| txtCNumber1.Text==txtCNumber2.Text)
            {
                string script = "alert('Please change contact Number3')";
                ClientScript.RegisterStartupScript(this.GetType(), "UpdateMessage", script, true);
                txtCNumber2.Text = "";
            }
            else
            {
                isupplierid = Convert.ToInt32(Request.QueryString.Get("Supid"));
                if (isupplierid != 0)
                {
                    DataSet dssupcontactcheck = dbObj.selectsuplier_Contactnumtranssupid(isupplierid, txtCNumber2.Text);
                    if (dssupcontactcheck.Tables[0].Rows.Count > 0)
                    {
                        string script = "alert('Please change contact Number3 , Given Number already stored')";
                        ClientScript.RegisterStartupScript(this.GetType(), "UpdateMessage", script, true);
                        txtCNumber2.Text = "";
                    }
                }
                else
                {
                    DataSet dssupcontactcheck = dbObj.selectsuplier_Contactnumtrans(txtCNumber2.Text);
                    if (dssupcontactcheck.Tables[0].Rows.Count > 0)
                    {
                        string script = "alert('Please change contact Number3 , Given Number already stored')";
                        ClientScript.RegisterStartupScript(this.GetType(), "UpdateMessage", script, true);
                        txtCNumber2.Text = "";
                    }
                }
            }
        }

        protected void txtCNumber3_TextChanged(object sender, EventArgs e)
        {
            if (txtCNumber3.Text == txtContactnumber.Text || txtCNumber1.Text == txtCNumber3.Text||txtCNumber2.Text==txtCNumber3.Text)
            {
                string script = "alert('Please change contact Number4')";
                ClientScript.RegisterStartupScript(this.GetType(), "UpdateMessage", script, true);
                txtCNumber3.Text = "";
            }
            else
            {
                if (isupplierid != 0)
                {
                    isupplierid = Convert.ToInt32(Request.QueryString.Get("Supid"));
                    DataSet dssupcontactcheck = dbObj.selectsuplier_Contactnumtranssupid(isupplierid, txtCNumber3.Text);
                    if (dssupcontactcheck.Tables[0].Rows.Count > 0)
                    {
                        string script = "alert('Please change contact Number4 , Given Number already stored')";
                        ClientScript.RegisterStartupScript(this.GetType(), "UpdateMessage", script, true);
                        txtCNumber3.Text = "";
                    }
                }
                else
                {
                    DataSet dssupcontactcheck = dbObj.selectsuplier_Contactnumtrans(txtCNumber3.Text);
                    if (dssupcontactcheck.Tables[0].Rows.Count > 0)
                    {
                        string script = "alert('Please change contact Number4 , Given Number already stored')";
                        ClientScript.RegisterStartupScript(this.GetType(), "UpdateMessage", script, true);
                        txtCNumber3.Text = "";
                    }
                }
            }
        }
    }
}