using BusinessLayer;
using Microsoft.Ajax.Utilities;
using System;
using System.Data;
using System.Security.Cryptography;
using System.Web.Services.Description;
using System.Web.UI.WebControls;

namespace Medly_Wm
{
    public partial class CreateSO : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
        int iSoid = 0;
        int iProductID = 0; int Empid = 0;
        int iProductid=0;
        protected void Page_Load(object sender, EventArgs e)
        {
            table.Visible = true;
            if (!IsPostBack)
            {
                #region Clear Temp Table
                int iDelete = dbObj.ClearTempSO();
                #endregion

                txtSOdate.Text = DateTime.Now.ToString("yyyy-MM-dd");
               string todaydate = DateTime.Now.ToString("yyyy-MM-dd");
                txtSOdate.Enabled = false;
                #region GetMAxSO
                DataSet dsPO = dbObj.GetMaxSOPrintno_only();
                if (dsPO.Tables[0].Rows.Count > 0 && dsPO.Tables[0].Rows != null)
                {
                    txtSOnumber.Text = Convert.ToString(dsPO.Tables[0].Rows[0]["Printno"].ToString());

                }
                else
                {

                    txtSOnumber.Text = "1";
                }
                #endregion
                DataSet ds = dbObj.getProductname();
                ddlProductname.DataSource = ds;
                ddlProductname.DataTextField = "Productname";
                ddlProductname.DataValueField = "ProductId";
                ddlProductname.DataBind();
                ddlProductname.Items.Insert(0, "Productname");
                #region LoadGrid CreatePO
                DataSet dscreatpo = new DataSet();
                dscreatpo = dbObj.Select_CreateSO();
                if (dscreatpo.Tables[0].Rows.Count > 0)
                {
                    grvCreateSo.DataSource = dscreatpo.Tables[0];
                    grvCreateSo.DataBind();
                }
                #endregion

                #region company name
               // string todaydate = DateTime.Now.ToString("yyyy-MM-dd");
                DataSet Companyname = dbObj.getCompanyname(todaydate);
                ddlCompanyname.DataSource = Companyname;
                ddlCompanyname.DataTextField = "CompanyName";
                ddlCompanyname.DataValueField = "SupplierID";
                ddlCompanyname.DataBind();
                ddlCompanyname.Items.Insert(0, "Select Company");
                #endregion

                #region create so grid 
                iSoid = Convert.ToInt32(Request.QueryString.Get("Soid"));
                if (iSoid != 0)
                {
                    iProductID = Convert.ToInt32(Request.QueryString.Get("iProductID"));
                    if (Request.Cookies["userInfo"]["EmployeeID"] != null && Request.Cookies["userInfo"]["Empname"] != null)
                    {
                        Empid = Convert.ToInt32(Request.Cookies["userInfo"]["EmployeeID"]);
                    }
                    DataSet dsSoid = new DataSet();
                    dsSoid = dbObj.selectSO_bySOid(iSoid);

                    ViewState["vsSoid"] = iSoid;
                    if (dsSoid.Tables[0].Rows.Count > 0)
                    {
                        grvCreateSo.DataSource = dsSoid.Tables[0];
                        grvCreateSo.DataBind();

                        //txtLicenseno.Text = dsSoid.Tables[0].Rows[0]["Licenseno"].ToString();
                        txtProductname.Text = dsSoid.Tables[0].Rows[0]["Productname"].ToString();
                        txtDosageform.Text = dsSoid.Tables[0].Rows[0]["Dosageform"].ToString();
                        txtStrength.Text = dsSoid.Tables[0].Rows[0]["Strength"].ToString();
                        txtSoqty.Text = dsSoid.Tables[0].Rows[0]["SoQty"].ToString();
                        txtPriceperpack.Text = dsSoid.Tables[0].Rows[0]["Priceperpack"].ToString();
                        txtVAT.Text = dsSoid.Tables[0].Rows[0]["VAT"].ToString();
                        txttotalamt.Text = dsSoid.Tables[0].Rows[0]["Totalamount"].ToString();
                        ddlSelectapprover.Text = dsSoid.Tables[0].Rows[0]["ApproverId"].ToString();
                        txtTotalSOamount.Text = dsSoid.Tables[0].Rows[0]["Amount"].ToString();
                        ddlStatus.Text = dsSoid.Tables[0].Rows[0]["Status"].ToString();
                        btnSubmit.Text = "Update";
                    }
                }
                #endregion dropdown

                    //DataSet ds4 = dbObj.getSuppliername(todaydate);
                    //ddlSuppliername.DataSource = ds4;
                    //ddlSuppliername.DataTextField = "ContactName";
                    //ddlSuppliername.DataValueField = "SupplierID";
                    //ddlSuppliername.DataBind();
                    //ddlSuppliername.Items.Insert(0, "Select Customer");
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

                #region Edit
                iSoid = Convert.ToInt32(Request.QueryString.Get("Soid"));
                iProductid = Convert.ToInt32(Request.QueryString.Get("Productid"));
                if (iSoid != 0)
                {

                    btnSubmit.Text = "Update";
                    DataSet dssocreate = new DataSet();
                    dssocreate = dbObj.Select_UpdateSo1(iSoid);
                    ViewState["vsPo"] = iSoid;
                    
                    if (dssocreate.Tables[0].Rows.Count > 0)
                    {
                        string status = dssocreate.Tables[0].Rows[0]["Status"].ToString();

                        if (status =="Approved")
                        {
                            btnCancel.Text = "Back";
                            btnAddrows.Enabled = false;
                            ddlSuppliername.Enabled = false;
                            ddlCompanyname.Enabled = false;
                            btnSubmit.Visible = false;

                        }
                        int ApproverId = Convert.ToInt32(dssocreate.Tables[0].Rows[0]["ApproverId"].ToString());
                        if (ApproverId == Empid)
                        {
                            ddlStatus.Enabled = true;
                        }
                        txtSOnumber.Text = Convert.ToString(dssocreate.Tables[0].Rows[0]["SOPrintno"]);
                        if (dssocreate.Tables[0].Rows.Count > 0)
                        {
                            grvCreateSo.DataSource = dssocreate.Tables[0];
                            grvCreateSo.DataBind();

                            #region Dropdown Companyname
                            ddlCompanyname.DataSource = dssocreate;
                            ddlCompanyname.DataTextField = "CompanyName";
                            ddlCompanyname.DataValueField = "SupplierID";
                            ddlCompanyname.DataBind();
                            ddlCompanyname.Items.Insert(0, "Select SupplierName");
                            ddlCompanyname.SelectedValue = dssocreate.Tables[0].Rows[0]["SupplierID"].ToString();
                            #endregion

                            #region Dropdown supliername
                            ddlSuppliername.DataSource = dssocreate;
                            ddlSuppliername.DataTextField = "PersonName";
                            ddlSuppliername.DataValueField = "SupplierID";
                            ddlSuppliername.DataBind();
                            ddlSuppliername.Items.Insert(0, "Select SupplierName");
                            ddlSuppliername.SelectedValue = dssocreate.Tables[0].Rows[0]["SupplierID"].ToString();
                            #endregion


                            txtSOdate.Text = ((DateTime)dssocreate.Tables[0].Rows[0]["SOdatetime"]).ToString("yyyy-MM-dd");
                            txtDeliverydate.Text = ((DateTime)dssocreate.Tables[0].Rows[0]["Deliverydate"]).ToString("yyyy-MM-dd");
                            txtRefno.Text= dssocreate.Tables[0].Rows[0]["Refno"].ToString();

                            #region Dropdown Approver
                            ddlSelectapprover.DataSource = dssocreate;
                            ddlSelectapprover.DataTextField = "EmployeeName";
                            ddlSelectapprover.DataValueField = "EmployeeID";
                            ddlSelectapprover.DataBind();
                            ddlSelectapprover.Items.Insert(0, "Select Approver");
                            #endregion
                            ddlSelectapprover.SelectedValue = dssocreate.Tables[0].Rows[0]["EmployeeID"].ToString();
                            ddlStatus.SelectedItem.Text= dssocreate.Tables[0].Rows[0]["Status"].ToString();
                            txtTotalSOamount.Text = dssocreate.Tables[0].Rows[0]["Amount"].ToString();

                            #region address
                            //ddlAddress.DataSource = dssocreate;
                            //ddlAddress.DataTextField = "DelAddress";
                            //ddlAddress.DataValueField = "DelAddress";
                            //ddlAddress.DataBind();
                            //ddlAddress.Items.Insert(0, "Select Address");
                            txtAddress.Text = dssocreate.Tables[0].Rows[0]["DelAddress"].ToString();
                            #endregion
                            if (iProductid != 0)
                            {
                                DataSet ds1 = dbObj.getProductnameforupdate1(iProductid,iSoid);
                                ddlProductname.DataSource = ds1;
                                ddlProductname.DataTextField = "Productname";
                                ddlProductname.DataValueField = "ProductID";
                                ddlProductname.DataBind();
                                ddlProductname.Items.Insert(0, "Productname");
                                ddlProductname.SelectedValue = ds1.Tables[0].Rows[0]["ProductId"].ToString();
                                txtProductname.Text = ds1.Tables[0].Rows[0]["Productname"].ToString();
                                txtDosageform.Text = ds1.Tables[0].Rows[0]["Dosageform"].ToString();
                                txtStrength.Text = ds1.Tables[0].Rows[0]["Strength"].ToString();
                                txtSoqty.Text = ds1.Tables[0].Rows[0]["SoQty"].ToString();
                                txtPriceperpack.Text = ds1.Tables[0].Rows[0]["Priceperpack"].ToString();
                                txtVAT.Text = ds1.Tables[0].Rows[0]["VAT"].ToString();
                                txttotalamt.Text = ds1.Tables[0].Rows[0]["Totalamount"].ToString();
                            }
                            else
                            {
                                DataSet ds1 = dbObj.getProductnameforupdate();
                                ddlProductname.DataSource = ds1;
                                ddlProductname.DataTextField = "Productname";
                                ddlProductname.DataValueField = "ProductID";
                                ddlProductname.DataBind();
                                ddlProductname.Items.Insert(0, "Productname");
                            }


                        }
                        #endregion
                    }
                    else
                    {
                        string script2 = "alert('No SO Available')";
                        ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script2, true);
                    }



                }

            }
        }
        private void BindSo()
        {
            DataSet dsSO = new DataSet();
            dsSO = dbObj.Select_CreateSO();
            if (dsSO.Tables[0].Rows.Count > 0)
            {
                grvCreateSo.DataSource = dsSO.Tables[0];
                grvCreateSo.DataBind();
            }
        }
        protected void btnAddrows_Click(object sender, EventArgs e)
        {
            if (txttotalamt.Text == "0")
            {
                string script2 = "alert('Please Enter Price Per Pack')";
                ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script2, true);
            }
            else
            {
                int pro = Convert.ToInt32(ViewState["prodid"]);
                int isucess = 0;
                iSoid = Convert.ToInt32(Request.QueryString.Get("Soid"));
                if (iSoid != 0)
                {
                    if (pro != 0)
                    {
                        DataSet prodid = dbObj.Gettemptblso();
                        if (prodid.Tables[0].Rows.Count > 0)
                        {
                            DataSet prodid1 = dbObj.Select_ProdSoid(Convert.ToInt32(ddlProductname.Text));
                            if (prodid1.Tables[0].Rows.Count > 0)
                            {
                                isucess = dbObj.UpdateTempProductsso(Convert.ToInt32(ddlProductname.Text), txtProductname.Text, txtDosageform.Text, txtStrength.Text, txtSoqty.Text, txtPriceperpack.Text, txtVAT.Text, txttotalamt.Text);
                                //isucess = dbObj.InsertProducts(Convert.ToInt32(ddlProductname.Text), txtProductname.Text, txtDosageform.Text, txtStrength.Text, txtPacktype.Text, txtPacksize.Text, txtPoqty.Text, txtPriceperpack.Text, txtproductamt.Text);
                                string script2 = "alert('Row added')";
                                ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script2, true);

                            }
                            else
                            {
                                isucess = dbObj.InsertSoProducts(Convert.ToInt32(ddlProductname.Text), txtProductname.Text, txtDosageform.Text, txtStrength.Text, txtSoqty.Text, txtPriceperpack.Text, txtVAT.Text, txttotalamt.Text);
                                // isucess = dbObj.InsertSoProducts(Convert.ToInt32(ddlProductname.Text), txtLicenseno.Text, txtProductname.Text, txtDosageform.Text, txtStrength.Text, txtPacktype.Text, txtPacksize.Text, txtSoqty.Text, txtPriceperpack.Text,txtVAT.Text, txttotalamt.Text);
                                string script1 = "alert('Row added')";
                                ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script1, true);
                            }
                        }
                        else
                        {
                            #region Clear Temp Table
                            int iDelete = dbObj.ClearTempSO();
                            #endregion
                            #region Insert_TransSO
                            DataSet dsTempSO = dbObj.Select_UpdateSo1(iSoid);
                            if (dsTempSO.Tables[0].Rows.Count > 0)
                            {


                                int count = dsTempSO.Tables[0].Rows.Count;
                                for (int i = 0; i < count; i++)
                                {
                                    string productname = dsTempSO.Tables[0].Rows[i]["Productid"].ToString();
                                    string Licenseno = dsTempSO.Tables[0].Rows[i]["Licenseno"].ToString();
                                    string Productname = dsTempSO.Tables[0].Rows[i]["Productname"].ToString();
                                    string Dosageform = dsTempSO.Tables[0].Rows[i]["Dosageform"].ToString();
                                    string Strength = dsTempSO.Tables[0].Rows[i]["Strength"].ToString();
                                    //string Packtype = dsTempSO.Tables[0].Rows[i]["Packtype"].ToString();
                                    //string Packsize = dsTempSO.Tables[0].Rows[i]["Packsize"].ToString();
                                    string Packqty = dsTempSO.Tables[0].Rows[i]["SoQty"].ToString();
                                    string Priceperpack = dsTempSO.Tables[0].Rows[i]["Priceperpack"].ToString();
                                    string vat = dsTempSO.Tables[0].Rows[i]["VAT"].ToString();
                                    string Productamnt = dsTempSO.Tables[0].Rows[i]["Totalamount"].ToString();
                                    isucess = dbObj.InsertSoProducts(Convert.ToInt32(productname), Productname, Dosageform, Strength, Packqty, Priceperpack, vat, Productamnt);

                                }
                                DataSet prodid1 = dbObj.Select_ProdSoid(Convert.ToInt32(ddlProductname.Text));
                                if (prodid1.Tables[0].Rows.Count > 0)
                                {
                                    isucess = dbObj.UpdateTempProductsso(Convert.ToInt32(ddlProductname.Text), txtProductname.Text, txtDosageform.Text, txtStrength.Text, txtSoqty.Text, txtPriceperpack.Text, txtVAT.Text, txttotalamt.Text);
                                    //isucess = dbObj.InsertProducts(Convert.ToInt32(ddlProductname.Text), txtProductname.Text, txtDosageform.Text, txtStrength.Text, txtPacktype.Text, txtPacksize.Text, txtPoqty.Text, txtPriceperpack.Text, txtproductamt.Text);
                                    string script2 = "alert('Row added')";
                                    ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script2, true);

                                }
                                else
                                {
                                    isucess = dbObj.InsertSoProducts(Convert.ToInt32(ddlProductname.Text), txtProductname.Text, txtDosageform.Text, txtStrength.Text, txtSoqty.Text, txtPriceperpack.Text, txtVAT.Text, txttotalamt.Text);
                                    // isucess = dbObj.InsertSoProducts(Convert.ToInt32(ddlProductname.Text), txtLicenseno.Text, txtProductname.Text, txtDosageform.Text, txtStrength.Text, txtPacktype.Text, txtPacksize.Text, txtSoqty.Text, txtPriceperpack.Text,txtVAT.Text, txttotalamt.Text);
                                    string script1 = "alert('Row added')";
                                    ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script1, true);
                                }
                            }
                            #endregion

                        }
                    }
                    else
                    {
                        DataSet prodid = dbObj.Gettemptblso();
                        if (prodid.Tables[0].Rows.Count > 0)
                        {
                            DataSet prodid1 = dbObj.Select_ProdSoid(Convert.ToInt32(ddlProductname.Text));
                            if (prodid1.Tables[0].Rows.Count > 0)
                            {
                                isucess = dbObj.UpdateTempProductsso(Convert.ToInt32(ddlProductname.Text), txtProductname.Text, txtDosageform.Text, txtStrength.Text, txtSoqty.Text, txtPriceperpack.Text, txtVAT.Text, txttotalamt.Text);
                                //isucess = dbObj.InsertProducts(Convert.ToInt32(ddlProductname.Text), txtProductname.Text, txtDosageform.Text, txtStrength.Text, txtPacktype.Text, txtPacksize.Text, txtPoqty.Text, txtPriceperpack.Text, txtproductamt.Text);
                                string script2 = "alert('Row added')";
                                ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script2, true);

                            }
                            else
                            {
                                isucess = dbObj.InsertSoProducts(Convert.ToInt32(ddlProductname.Text), txtProductname.Text, txtDosageform.Text, txtStrength.Text, txtSoqty.Text, txtPriceperpack.Text, txtVAT.Text, txttotalamt.Text);
                                // isucess = dbObj.InsertSoProducts(Convert.ToInt32(ddlProductname.Text), txtLicenseno.Text, txtProductname.Text, txtDosageform.Text, txtStrength.Text, txtPacktype.Text, txtPacksize.Text, txtSoqty.Text, txtPriceperpack.Text,txtVAT.Text, txttotalamt.Text);
                                string script1 = "alert('Row added')";
                                ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script1, true);
                            }
                        }
                        else
                        {
                            #region Clear Temp Table
                            int iDelete = dbObj.ClearTempSO();
                            #endregion
                            #region Insert_TransSO to temposo
                            DataSet dsTempSO = dbObj.Select_UpdateSo1(iSoid);
                            if (dsTempSO.Tables[0].Rows.Count > 0)
                            {


                                int count = dsTempSO.Tables[0].Rows.Count;
                                for (int i = 0; i < count; i++)
                                {
                                    string productname = dsTempSO.Tables[0].Rows[i]["Productid"].ToString();
                                    string Licenseno = dsTempSO.Tables[0].Rows[i]["Licenseno"].ToString();
                                    string Productname = dsTempSO.Tables[0].Rows[i]["Productname"].ToString();
                                    string Dosageform = dsTempSO.Tables[0].Rows[i]["Dosageform"].ToString();
                                    string Strength = dsTempSO.Tables[0].Rows[i]["Strength"].ToString();
                                    //string Packtype = dsTempSO.Tables[0].Rows[i]["Packtype"].ToString();
                                    //string Packsize = dsTempSO.Tables[0].Rows[i]["Packsize"].ToString();
                                    string Packqty = dsTempSO.Tables[0].Rows[i]["SoQty"].ToString();
                                    string Priceperpack = dsTempSO.Tables[0].Rows[i]["Priceperpack"].ToString();
                                    string vat = dsTempSO.Tables[0].Rows[i]["VAT"].ToString();
                                    string Productamnt = dsTempSO.Tables[0].Rows[i]["Totalamount"].ToString();
                                    isucess = dbObj.InsertSoProducts(Convert.ToInt32(productname), Productname, Dosageform, Strength, Packqty, Priceperpack, vat, Productamnt);

                                }
                                DataSet prodid1 = dbObj.Select_ProdSoid(Convert.ToInt32(ddlProductname.Text));
                                if (prodid1.Tables[0].Rows.Count > 0)
                                {
                                    isucess = dbObj.UpdateTempProductsso(Convert.ToInt32(ddlProductname.Text), txtProductname.Text, txtDosageform.Text, txtStrength.Text, txtSoqty.Text, txtPriceperpack.Text, txtVAT.Text, txttotalamt.Text);
                                    //isucess = dbObj.InsertProducts(Convert.ToInt32(ddlProductname.Text), txtProductname.Text, txtDosageform.Text, txtStrength.Text, txtPacktype.Text, txtPacksize.Text, txtPoqty.Text, txtPriceperpack.Text, txtproductamt.Text);
                                    string script2 = "alert('Row added')";
                                    ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script2, true);

                                }
                                else
                                {
                                    isucess = dbObj.InsertSoProducts(Convert.ToInt32(ddlProductname.Text), txtProductname.Text, txtDosageform.Text, txtStrength.Text, txtSoqty.Text, txtPriceperpack.Text, txtVAT.Text, txttotalamt.Text);
                                    // isucess = dbObj.InsertSoProducts(Convert.ToInt32(ddlProductname.Text), txtLicenseno.Text, txtProductname.Text, txtDosageform.Text, txtStrength.Text, txtPacktype.Text, txtPacksize.Text, txtSoqty.Text, txtPriceperpack.Text,txtVAT.Text, txttotalamt.Text);
                                    string script1 = "alert('Row added')";
                                    ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script1, true);
                                }
                            }
                            #endregion
                        }

                    }

                }
                else
                {
                    DataSet prodid1 = dbObj.Select_ProdSoid(Convert.ToInt32(ddlProductname.Text));
                    if (prodid1.Tables[0].Rows.Count > 0)
                    {
                        isucess = dbObj.UpdateTempProductsso(Convert.ToInt32(ddlProductname.Text), txtProductname.Text, txtDosageform.Text, txtStrength.Text, txtSoqty.Text, txtPriceperpack.Text, txtVAT.Text, txttotalamt.Text);
                        //isucess = dbObj.InsertProducts(Convert.ToInt32(ddlProductname.Text), txtProductname.Text, txtDosageform.Text, txtStrength.Text, txtPacktype.Text, txtPacksize.Text, txtPoqty.Text, txtPriceperpack.Text, txtproductamt.Text);
                        string script2 = "alert('Row added')";
                        ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script2, true);

                    }
                    else
                    {
                        isucess = dbObj.InsertSoProducts(Convert.ToInt32(ddlProductname.Text), txtProductname.Text, txtDosageform.Text, txtStrength.Text, txtSoqty.Text, txtPriceperpack.Text, txtVAT.Text, txttotalamt.Text);
                        // isucess = dbObj.InsertSoProducts(Convert.ToInt32(ddlProductname.Text), txtLicenseno.Text, txtProductname.Text, txtDosageform.Text, txtStrength.Text, txtPacktype.Text, txtPacksize.Text, txtSoqty.Text, txtPriceperpack.Text,txtVAT.Text, txttotalamt.Text);
                        string script1 = "alert('Row added')";
                        ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script1, true);
                    }
                }

                DataSet dscreatso = new DataSet();
                dscreatso = dbObj.Select_CreateSO();
                if (dscreatso.Tables[0].Rows.Count > 0)
                {
                    grvCreateSo.DataSource = dscreatso.Tables[0];
                    grvCreateSo.DataBind();
                    double totalSoAmount = 0;
                    for (int i = 0; i < dscreatso.Tables[0].Rows.Count; i++)
                    {
                        double productAmount = Convert.ToDouble(dscreatso.Tables[0].Rows[i]["Totalamount"].ToString());
                        totalSoAmount += productAmount;
                    }
                    txtTotalSOamount.Text = Convert.ToString(totalSoAmount);
                    //txtLicenseno.Text = "";
                    txtProductname.Text = "";
                    txtDosageform.Text = "";
                    txtStrength.Text = "";
                    // txtPacktype.Text = "";
                    // txtPacksize.Text = "";
                    txtPriceperpack.Text = "0";
                    txtSoqty.Text = "0";
                    txtVAT.Text = "0";
                    txttotalamt.Text = "0";
                    iProductid = 0;
                }
                DataSet ds = dbObj.getProductname();
                ddlProductname.DataSource = ds;
                ddlProductname.DataTextField = "Productname";
                ddlProductname.DataValueField = "ProductId";
                ddlProductname.DataBind();
                ddlProductname.Items.Insert(0, "Productname");
            }

        }
        protected void ddlProductname_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsProdId = new DataSet();
            dsProdId = dbObj.selectProduct_byProductId(Convert.ToInt32(ddlProductname.SelectedValue));
            ViewState["vsPrdct"] = iProductID;
            if (dsProdId.Tables[0].Rows.Count > 0)
            {
                //txtLicenseno.Text = dsProdId.Tables[0].Rows[0]["Licenseno"].ToString();
                txtProductname.Text = dsProdId.Tables[0].Rows[0]["Productname"].ToString();
                txtDosageform.Text = dsProdId.Tables[0].Rows[0]["Dosageform"].ToString();
                txtStrength.Text = dsProdId.Tables[0].Rows[0]["Strength"].ToString();
                // txtPacktype.Text = dsProdId.Tables[0].Rows[0]["Packtype"].ToString();
                // txtPacksize.Text = dsProdId.Tables[0].Rows[0]["Packsize"].ToString();
                txtPriceperpack.Text = dsProdId.Tables[0].Rows[0]["Priceperpack"].ToString();
                //txtPacktype.Text = dsProdId.Tables[0].Rows[0]["Currency"].ToString();
                //ddlProductanufacture.SelectedItem.Text = dsProdId.Tables[0].Rows[0]["Productmanufacture"].ToString();
                //ddlproductmanufacturecountry.SelectedItem.Text = dsProdId.Tables[0].Rows[0]["Productmanufacturecountry"].ToString();
                //txtProductCode.Text = dsProdId.Tables[0].Rows[0]["Productcode"].ToString();
                //txtGTINBarcode.Text = dsProdId.Tables[0].Rows[0]["ProductGTINbarcode"].ToString();
                //ddlProductapprovalauthority.SelectedItem.Text = dsProdId.Tables[0].Rows[0]["Productaprovalauthority"].ToString();
                //ddlProductapprovalstatus.SelectedItem.Text = dsProdId.Tables[0].Rows[0]["Productaprovalstatus"].ToString();
                //txtTax.Text = dsProdId.Tables[0].Rows[0]["Tax"].ToString();
                //ddlTaxationtype.SelectedItem.Text = dsProdId.Tables[0].Rows[0]["Taxationtype"].ToString();
                ////imgProductphoto.FileContent = dsDesgnId.Tables[0].Rows[0]["Productphoto"].ToString();
                //ddlSelectapprover.SelectedItem.Text = dsProdId.Tables[0].Rows[0]["Selectaproval"].ToString();
                //btnSubmit.Text = "Update";
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ddlCompanyname.SelectedValue == "Select Company")
            {
                string script = "alert('Select Company')";
                ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
            }
            else
            {
                if (ddlSuppliername.SelectedValue == "Select Customer")
                {
                    string script = "alert('Select Customer')";
                    ClientScript.RegisterStartupScript(this.GetType(), "UpdateMessage", script, true);
                }
                else if (txtDeliverydate.Text == "")
                {
                    string script = "alert('Please Select Delivery Date')";
                    ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                }
                else if (txtTotalSOamount.Text=="0")
                {
                    string script = "alert('Please Select Product Details  & Click Plus Button')";
                    ClientScript.RegisterStartupScript(this.GetType(), "UpdateMessage", script, true);
                }
                else if (ddlSelectapprover.SelectedValue == "Select Approver")
                {
                    string script = "alert('Select Approver')";
                    ClientScript.RegisterStartupScript(this.GetType(), "UpdateMessage", script, true);
                }
                else
                {
                    if (btnSubmit.Text == "Submit")
                    {
                        int isucess = 0;

                        #region GetMAxSOPrint
                        DataSet dsSOprintno = dbObj.GetMaxSOPrintno_only();
                        int iSOprintMax = Convert.ToInt32(dsSOprintno.Tables[0].Rows[0]["Printno"].ToString());
                        #endregion
                        isucess = dbObj.InsertSoDetails(ddlSuppliername.SelectedValue, DateTime.Parse(txtSOdate.Text), Convert.ToInt32(ddlSelectapprover.SelectedValue), ddlStatus.SelectedItem.Text, txtTotalSOamount.Text, iSOprintMax.ToString(), txtAddress.Text,txtRefno.Text, DateTime.Parse(txtDeliverydate.Text));
                        #region GetMAxPO
                        DataSet dsSO = dbObj.GetMaxSO_only();
                        int iSOMax = Convert.ToInt32(dsSO.Tables[0].Rows[0]["Soid"].ToString());
                        #endregion
                        #region Insert_TransPO
                        DataSet dsTempSO = dbObj.Select_CreateSO();
                        if (dsTempSO.Tables[0].Rows.Count > 0)
                        {
                            int count = dsTempSO.Tables[0].Rows.Count;
                            for (int i = 0; i < count; i++)
                            {
                                string productname = dsTempSO.Tables[0].Rows[i]["Productid"].ToString();
                                string Licenseno = dsTempSO.Tables[0].Rows[i]["Licenseno"].ToString();
                                string Productname = dsTempSO.Tables[0].Rows[i]["Productname"].ToString();
                                string Dosageform = dsTempSO.Tables[0].Rows[i]["Dosageform"].ToString();
                                string Strength = dsTempSO.Tables[0].Rows[i]["Strength"].ToString();
                                string Packtype = dsTempSO.Tables[0].Rows[i]["Packtype"].ToString();
                                string Packsize = dsTempSO.Tables[0].Rows[i]["Packsize"].ToString();
                                string Packqty = dsTempSO.Tables[0].Rows[i]["SoQty"].ToString();
                                string Priceperpack = dsTempSO.Tables[0].Rows[i]["Priceperpack"].ToString();
                                string VAT = dsTempSO.Tables[0].Rows[i]["VAT"].ToString();
                                string Totalamount = dsTempSO.Tables[0].Rows[i]["Totalamount"].ToString();
                                int iSuccess1 = dbObj.InsertTransSo(iSOMax, Convert.ToInt32(productname), Licenseno, Productname, Dosageform, Strength, Packtype, Packsize, Packqty, Priceperpack, VAT, Totalamount);
                            }
                        }
                        #endregion
                        #region Clear Temp Table
                        int iDelete = dbObj.ClearTempSO();
                        #endregion
                        string script = "alert('SO Stored');window.location.href = 'SOGrid.aspx'";
                        ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                        //Response.Redirect("SOgrid.aspx");
                    }
                    else if (btnSubmit.Text == "Update")
                    {
                        iSoid = Convert.ToInt32(Request.QueryString.Get("Soid"));
                        if(iSoid!=0)
                        {
                            int isucess = 0;
                            isucess = dbObj.UpdateCreateSo(iSoid, ddlSuppliername.SelectedValue, DateTime.Parse(txtSOdate.Text), Convert.ToInt32(ddlSelectapprover.SelectedValue), ddlStatus.SelectedItem.Text, txtTotalSOamount.Text, txtAddress.Text, txtRefno.Text, Convert.ToDateTime(txtDeliverydate.Text));

                            #region update so
                            DataSet dsTempSO = dbObj.Select_CreateSO();
                            if (dsTempSO.Tables[0].Rows.Count > 0)
                            {
                                int isucess3;
                                isucess3 = dbObj.deletetranssoold(iSoid);
                                if (dsTempSO.Tables[0].Rows.Count > 0)
                                {
                                    int count = dsTempSO.Tables[0].Rows.Count;

                                    for (int i = 0; i < count; i++)
                                    {
                                        string productname = dsTempSO.Tables[0].Rows[i]["Productid"].ToString();
                                        string Licenseno = dsTempSO.Tables[0].Rows[i]["Licenseno"].ToString();
                                        string Productname = dsTempSO.Tables[0].Rows[i]["Productname"].ToString();
                                        string Dosageform = dsTempSO.Tables[0].Rows[i]["Dosageform"].ToString();
                                        string Strength = dsTempSO.Tables[0].Rows[i]["Strength"].ToString();
                                        //string Packtype = dsTempPO.Tables[0].Rows[i]["Packtype"].ToString();
                                        //string Packsize = dsTempPO.Tables[0].Rows[i]["Packsize"].ToString();
                                        string Packqty = dsTempSO.Tables[0].Rows[i]["SoQty"].ToString();
                                        string Priceperpack = dsTempSO.Tables[0].Rows[i]["Priceperpack"].ToString();
                                        string VAT = dsTempSO.Tables[0].Rows[i]["VAT"].ToString();
                                        string Productamnt = dsTempSO.Tables[0].Rows[i]["Totalamount"].ToString();
                                        int isucess2 = 0;
                                        isucess2 = dbObj.updatetranssoProducts(iSoid, Convert.ToInt32(productname), Productname, Dosageform, Strength, Packqty, Priceperpack, VAT, Productamnt);
                                        //int isucess5 = 0;
                                    }
                                }
                                else
                                {
                                    isucess = dbObj.UpdateCreateSo(iSoid, ddlSuppliername.SelectedValue, DateTime.Parse(txtSOdate.Text), Convert.ToInt32(ddlSelectapprover.SelectedValue), ddlStatus.SelectedItem.Text, txtTotalSOamount.Text, txtAddress.Text, txtRefno.Text, Convert.ToDateTime(txtDeliverydate.Text));

                                }
                            }
                            
                            #endregion

                            string script = "alert('Data Updated')";
                            ClientScript.RegisterStartupScript(this.GetType(), "UpdateMessage", script, true);
                            Response.Redirect("SOGrid.aspx");
                        }
                        else
                        {
                            string script = "alert('No Data Available ')";
                            ClientScript.RegisterStartupScript(this.GetType(), "UpdateMessage", script, true);
                            Response.Redirect("SOGrid.aspx");
                        }
                        
                    }
                }
            }
        }
        protected void grvCreateSo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            iSoid = Convert.ToInt32(Request.QueryString.Get("Soid"));
            #region Edit
            if (e.CommandName == "editt")
            {                int prodid = Convert.ToInt32(e.CommandArgument);
                ViewState["prodid"] = prodid;
                if (prodid != 0)
                {
                    DataSet Temp = dbObj.Gettemptblso();
                    if (Temp.Tables[0].Rows.Count > 0)
                    {
                        DataSet ds3 = dbObj.getProductnametempSo(prodid);
                        ddlProductname.DataSource = ds3;
                        ddlProductname.DataTextField = "Productname";
                        ddlProductname.DataValueField = "ProductID";
                        ddlProductname.DataBind();
                        ddlProductname.Items.Insert(0, "Productname");
                        ddlProductname.SelectedValue = ds3.Tables[0].Rows[0]["ProductId"].ToString();

                        txtProductname.Text = ds3.Tables[0].Rows[0]["Productname"].ToString();
                        txtDosageform.Text = ds3.Tables[0].Rows[0]["Dosageform"].ToString();
                        txtStrength.Text = ds3.Tables[0].Rows[0]["Strength"].ToString();
                        txtSoqty.Text = ds3.Tables[0].Rows[0]["SoQty"].ToString();
                        txtPriceperpack.Text = ds3.Tables[0].Rows[0]["Priceperpack"].ToString();
                        txtVAT.Text = ds3.Tables[0].Rows[0]["VAT"].ToString();
                        txttotalamt.Text = ds3.Tables[0].Rows[0]["Totalamount"].ToString();
                    }
                    else
                    {
                        DataSet ds2 = dbObj.getProductnameforupdateso(prodid, iSoid);
                        ddlProductname.DataSource = ds2;
                        ddlProductname.DataTextField = "Productname";
                        ddlProductname.DataValueField = "ProductID";
                        ddlProductname.DataBind();
                        ddlProductname.Items.Insert(0, "Productname");
                        ddlProductname.SelectedValue = ds2.Tables[0].Rows[0]["ProductId"].ToString();

                        txtProductname.Text = ds2.Tables[0].Rows[0]["Productname"].ToString();
                        txtDosageform.Text = ds2.Tables[0].Rows[0]["Dosageform"].ToString();
                        txtStrength.Text = ds2.Tables[0].Rows[0]["Strength"].ToString();
                        txtSoqty.Text = ds2.Tables[0].Rows[0]["SoQty"].ToString();
                        txtPriceperpack.Text = ds2.Tables[0].Rows[0]["Priceperpack"].ToString();
                        txtVAT.Text = ds2.Tables[0].Rows[0]["VAT"].ToString();
                        txttotalamt.Text = ds2.Tables[0].Rows[0]["Totalamount"].ToString();
                    }

                }
                else
                {
                    string script = "alert('No data Available')";
                    ClientScript.RegisterStartupScript(this.GetType(), "UpdateMessage", script, true);
                    Response.Redirect("POGrid.aspx");
                }
                //Response.Redirect("CreateSO.aspx?Event=Edit&Productid=" + e.CommandArgument.ToString()+"&Soid="+ iSoid);
            }
            if (e.CommandName == "Del")
            {
                string[] comment1 = e.CommandArgument.ToString().Split(new char[] { ';' });
                string soid = comment1[0];
                string productid1 = comment1[1];
                int iSoid = Convert.ToInt32(soid);
                DataSet prodid = dbObj.Gettemptblso();
                if (prodid.Tables[0].Rows.Count > 0)
                {
                    dbObj.deleteSO(Convert.ToInt32(productid1));
                   
                    DataSet dscreatso = dbObj.Select_CreateSO();
                    if (dscreatso.Tables[0].Rows.Count > 0)
                    {
                        grvCreateSo.DataSource = dscreatso.Tables[0];
                        grvCreateSo.DataBind();
                        double totalSoAmount = 0;
                        for (int i = 0; i < dscreatso.Tables[0].Rows.Count; i++)
                        {
                            double productAmount = Convert.ToDouble(dscreatso.Tables[0].Rows[i]["Totalamount"].ToString());
                            totalSoAmount += productAmount;
                        }
                        txtTotalSOamount.Text = Convert.ToString(totalSoAmount);
                        // BindSo();
                        txtProductname.Text = "";
                        txtDosageform.Text = "";
                        txtStrength.Text = "";
                        // txtPacktype.Text = "";
                        // txtPacksize.Text = "";
                        txtPriceperpack.Text = "0";
                        txtSoqty.Text = "0";
                        txtVAT.Text = "0";
                        txttotalamt.Text = "0";

                        DataSet ds = dbObj.getProductname();
                        ddlProductname.DataSource = ds;
                        ddlProductname.DataTextField = "Productname";
                        ddlProductname.DataValueField = "ProductId";
                        ddlProductname.DataBind();
                        ddlProductname.Items.Insert(0, "Productname");
                    }
                    else
                    {
                        grvCreateSo.DataSource =null;
                        grvCreateSo.DataBind();

                        txtProductname.Text = "";
                        txtDosageform.Text = "";
                        txtStrength.Text = "";
                        // txtPacktype.Text = "";
                        // txtPacksize.Text = "";
                        txtPriceperpack.Text = "0";
                        txtSoqty.Text = "0";
                        txtVAT.Text = "0";
                        txttotalamt.Text = "0";
                        txtTotalSOamount.Text = "0.00";

                        DataSet ds = dbObj.getProductname();
                        ddlProductname.DataSource = ds;
                        ddlProductname.DataTextField = "Productname";
                        ddlProductname.DataValueField = "ProductId";
                        ddlProductname.DataBind();
                        ddlProductname.Items.Insert(0, "Productname");
                    }
                }
                else
                {
                    int isucess = 0;
                    #region Insert_TransSO to temposo
                    DataSet dsTempSO = dbObj.Select_UpdateSo1(iSoid);
                    if (dsTempSO.Tables[0].Rows.Count > 0)
                    {


                        int count = dsTempSO.Tables[0].Rows.Count;
                        for (int i = 0; i < count; i++)
                        {
                            string productname = dsTempSO.Tables[0].Rows[i]["Productid"].ToString();
                            string Soid = dsTempSO.Tables[0].Rows[i]["Soid"].ToString();
                            string Licenseno = dsTempSO.Tables[0].Rows[i]["Licenseno"].ToString();
                            string Productname = dsTempSO.Tables[0].Rows[i]["Productname"].ToString();
                            string Dosageform = dsTempSO.Tables[0].Rows[i]["Dosageform"].ToString();
                            string Strength = dsTempSO.Tables[0].Rows[i]["Strength"].ToString();
                            //string Packtype = dsTempSO.Tables[0].Rows[i]["Packtype"].ToString();
                            //string Packsize = dsTempSO.Tables[0].Rows[i]["Packsize"].ToString();
                            string Packqty = dsTempSO.Tables[0].Rows[i]["SoQty"].ToString();
                            string Priceperpack = dsTempSO.Tables[0].Rows[i]["Priceperpack"].ToString();
                            string vat = dsTempSO.Tables[0].Rows[i]["VAT"].ToString();
                            string Productamnt = dsTempSO.Tables[0].Rows[i]["Totalamount"].ToString();
                            isucess = dbObj.InsertSoProducts(Convert.ToInt32(productname), Productname, Dosageform, Strength, Packqty, Priceperpack, vat, Productamnt);

                        }
                        int iSoid1 = Convert.ToInt32(e.CommandArgument);
                        dbObj.deleteSO(Convert.ToInt32(productid1));
                        DataSet dscreatso = dbObj.Select_CreateSO();
                        if (dscreatso.Tables[0].Rows.Count > 0)
                        {
                            grvCreateSo.DataSource = dscreatso.Tables[0];
                            grvCreateSo.DataBind();
                            double totalSoAmount = 0;
                            for (int i = 0; i < dscreatso.Tables[0].Rows.Count; i++)
                            {
                                double productAmount = Convert.ToDouble(dscreatso.Tables[0].Rows[i]["Totalamount"].ToString());
                                totalSoAmount += productAmount;
                            }
                            txtTotalSOamount.Text = Convert.ToString(totalSoAmount);
                            //BindSo();
                            txtProductname.Text = "";
                            txtDosageform.Text = "";
                            txtStrength.Text = "";
                            // txtPacktype.Text = "";
                            // txtPacksize.Text = "";
                            txtPriceperpack.Text = "0";
                            txtSoqty.Text = "0";
                            txtVAT.Text = "0";
                            txttotalamt.Text = "0";

                            DataSet ds = dbObj.getProductname();
                            ddlProductname.DataSource = ds;
                            ddlProductname.DataTextField = "Productname";
                            ddlProductname.DataValueField = "ProductId";
                            ddlProductname.DataBind();
                            ddlProductname.Items.Insert(0, "Productname");
                        }
                        else
                        {
                            grvCreateSo.DataSource = null;
                            grvCreateSo.DataBind();

                            txtProductname.Text = "";
                            txtDosageform.Text = "";
                            txtStrength.Text = "";
                            // txtPacktype.Text = "";
                            // txtPacksize.Text = "";
                            txtPriceperpack.Text = "0";
                            txtSoqty.Text = "0";
                            txtVAT.Text = "0";
                            txttotalamt.Text = "0";
                            txtTotalSOamount.Text = "0.00";

                            DataSet ds = dbObj.getProductname();
                            ddlProductname.DataSource = ds;
                            ddlProductname.DataTextField = "Productname";
                            ddlProductname.DataValueField = "ProductId";
                            ddlProductname.DataBind();
                            ddlProductname.Items.Insert(0, "Productname");
                        }
                    }
                    #endregion
                }
                //Response.Redirect("CreateSO.aspx");
            }
            #endregion
            updatepanel.Update();
        }
        protected void txtSoqty_TextChanged(object sender, EventArgs e)
        {
            DataSet dsProduct = new DataSet();
            dsProduct = dbObj.selectProduct_byProductId(Convert.ToInt32(ddlProductname.SelectedValue));
            if (dsProduct.Tables[0].Rows.Count > 0)
            {
                //txtPriceperpack.Text = dsProduct.Tables[0].Rows[0]["Priceperpack"].ToString();
                int poqty = 0;
                int.TryParse(txtSoqty.Text, out poqty);

                //DataSet dsProductqty = new DataSet();
                //dsProductqty = dbObj.selectProduct_qty(Convert.ToInt32(ddlProductname.SelectedValue));
                //if (poqty <= Convert.ToInt32(dsProductqty.Tables[0].Rows[0]["productqty"].ToString()))
                //{
                //    decimal pricePerPack = 0;
                //    decimal.TryParse(txtPriceperpack.Text, out pricePerPack);
                //    decimal totalamount = poqty * pricePerPack;
                //    txttotalamt.Text = totalamount.ToString();
                //}
                //else
                //{
                    decimal pricePerPack = 0;
                    decimal.TryParse(txtPriceperpack.Text, out pricePerPack);
                    decimal totalamount = poqty * pricePerPack;
                    vat.Text=totalamount.ToString();
                    decimal vatamnt = (decimal.Parse(vat.Text) * decimal.Parse(txtVAT.Text)) / 100;
                    decimal vatcal = Convert.ToDecimal(totalamount) + vatamnt;
                txttotalamt.Text = vatcal.ToString();
                    //string script = "alert('Given  Qty not available in werehouse, Re Enter  PO Qty')";
                    //txtSoqty.Text = "";
                    //ClientScript.RegisterStartupScript(this.GetType(), "UpdateMessage", script, true);
                //}

            }
            else
            {
                string script = "alert('Enter Valid Qty')";
                txtSoqty.Text = "";
                ClientScript.RegisterStartupScript(this.GetType(), "UpdateMessage", script, true);
            }
        }

        protected void txtVAT_TextChanged(object sender, EventArgs e)
        {
            if (vat.Text == "")
            {
                int poqty = 0;
                int.TryParse(txtSoqty.Text, out poqty);
                decimal pricePerPack = 0;
                decimal.TryParse(txtPriceperpack.Text, out pricePerPack);
                decimal total = poqty * pricePerPack;
                vat.Text = total.ToString();
                decimal ttlamount = Convert.ToDecimal(vat.Text);
                decimal vatamnt = (decimal.Parse(vat.Text) * decimal.Parse(txtVAT.Text)) / 100;
                decimal vatcal = Convert.ToDecimal(ttlamount) + vatamnt;
                txttotalamt.Text = vatcal.ToString();
                vat.Text = "";
            }
            else
            {
                int poqty = 0;
                int.TryParse(txtSoqty.Text, out poqty);
                decimal pricePerPack = 0;
                decimal.TryParse(txtPriceperpack.Text, out pricePerPack);
                decimal total = poqty * pricePerPack;
                vat.Text = total.ToString();
                decimal ttlamount = Convert.ToDecimal(vat.Text);
                decimal vatamnt = (decimal.Parse(vat.Text) * decimal.Parse(txtVAT.Text)) / 100;
                decimal vatcal = Convert.ToDecimal(ttlamount) + vatamnt;
                txttotalamt.Text = vatcal.ToString();
                vat.Text = "";
            }
           
        }

        protected void grvCreateSo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (iSoid != 0)
                {
                    #region Check Status
                    DataSet dssocreate = dbObj.Select_UpdateSo1(iSoid);
                    string status = dssocreate.Tables[0].Rows[0]["Status"].ToString();
                    if (status == "Approved")
                    {

                        LinkButton btnEdit = (LinkButton)e.Row.FindControl("btnedit");
                        ImageButton imgEdit = (ImageButton)e.Row.FindControl("imgEdit");

                        LinkButton btndel = (LinkButton)e.Row.FindControl("btndel");
                        ImageButton imgDel = (ImageButton)e.Row.FindControl("imgDel");
                        imgEdit.Enabled = false;
                        imgDel.Enabled = false;
                        btndel.Enabled = false;
                        imgDel.Enabled = false;
                    }
                    #endregion
                }


                TextBox txtPoqty = (TextBox)e.Row.FindControl("txtSoqty1");
                TextBox txtPriceperpack = (TextBox)e.Row.FindControl("txtPriceperpack1");
                TextBox txtProductamt = (TextBox)e.Row.FindControl("txtproductamt");

                if (txtSoqty != null && txtPriceperpack != null && txtProductamt != null)
                {
                    decimal soQty = 0;
                    decimal pricePerPack = 0;
                    if (decimal.TryParse(txtSoqty.Text, out soQty) && decimal.TryParse(txtPriceperpack.Text, out pricePerPack))
                    {
                        decimal productAmount = soQty * pricePerPack;
                        txtProductamt.Text = productAmount.ToString();
                        txtTotalSOamount.Text += productAmount;
                    }
                }
            }
        }

        protected void ddlSuppliername_TextChanged(object sender, EventArgs e)
        {
            DataSet supplierAddress = dbObj.getSupplierAddress(ddlSuppliername.SelectedValue);
            if (supplierAddress.Tables[0].Rows.Count > 0)
            {
                txtAddress.Text = supplierAddress.Tables[0].Rows[0]["Address"].ToString();
            }
            else
            {
                string script = "alert('Address Not Avlailable')";
                ClientScript.RegisterStartupScript(this.GetType(), "UpdateMessage", script, true);
            }
        }

        protected void ddlCompanyname_TextChanged(object sender, EventArgs e)
        {
            string todaydate = DateTime.Now.ToString("yyyy-MM-dd");

            DataSet dsCompanysupplier = dbObj.getCompanySuppliername(Convert.ToInt32(ddlCompanyname.SelectedValue),todaydate);
            ddlSuppliername.DataSource = dsCompanysupplier;
            ddlSuppliername.DataTextField = "PersonName";
            ddlSuppliername.DataValueField = "TransSupplierID";
            ddlSuppliername.DataBind();
            ddlSuppliername.Items.Insert(0, "Select Customer");
        }
    }
}
