using BusinessLayer;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.EnterpriseServices;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace Medly_Wm
{
    public partial class CreatePO : System.Web.UI.Page
    {
        public string connnectionString;

        BSClass dbObj = new BSClass();
        int iPoid = 0;
        int itransPoid = 0;
        int iProductID = 0; int Empid = 0;
        int iProductid = 0;
        int Desid=0;
        //int iProductID = Convert.ToInt32(Request.QueryString.Get("iProductID"));
        protected void Page_Load(object sender, EventArgs e)
        {

            tble.Visible = true;
            if (!IsPostBack)
            {
                txtVAT.Text = "0";
                if (Request.Cookies["userInfo"]["Designation"] != null && Request.Cookies["userInfo"]["Empname"] != null)
                {
                    Desid = Convert.ToInt32(Request.Cookies["userInfo"]["Designation"]);

                }


                #region Clear Temp Table
                int iDelete = dbObj.ClearTempPO();
                #endregion

                #region GetMAxPO
                DataSet dsPO = dbObj.GetMaxPOPrintno_only();

                if (dsPO.Tables[0].Rows.Count > 0 && dsPO.Tables[0].Rows != null)
                {
                    txtPonumber.Text = Convert.ToString(dsPO.Tables[0].Rows[0]["Printno"].ToString());

                }
                else
                {

                    txtPonumber.Text = "1";
                }
                #endregion

                iProductID = Convert.ToInt32(Request.QueryString.Get("iProductID"));
                if (Request.Cookies["userInfo"]["EmployeeID"] != null && Request.Cookies["userInfo"]["Empname"] != null)
                {
                    Empid = Convert.ToInt32(Request.Cookies["userInfo"]["EmployeeID"]);


                }

                txtPodate.Text = DateTime.Now.ToString("yyyy-MM-dd");
               string todaydate= DateTime.Now.ToString("yyyy-MM-dd");
                txtPodate.Enabled = false;
                #region create po grid 
                iPoid = Convert.ToInt32(Request.QueryString.Get("Poid"));

                DataSet dsPoid = new DataSet();
                dsPoid = dbObj.selectPO_byPOid(iPoid);
                ViewState["vsPoid"] = iPoid;

                if (dsPoid.Tables[0].Rows.Count > 0)
                {
                    // txtLicenseno.Text = dsPoid.Tables[0].Rows[0]["Licenseno"].ToString();
                    txtProductname.Text = dsPoid.Tables[0].Rows[0]["Productname"].ToString();
                    txtDosageform.Text = dsPoid.Tables[0].Rows[0]["Dosageform"].ToString();
                    txtStrength.Text = dsPoid.Tables[0].Rows[0]["Strength"].ToString();
                    //txtPacktype.Text = dsPoid.Tables[0].Rows[0]["Packtype"].ToString();
                    //txtPacksize.Text = dsPoid.Tables[0].Rows[0]["Packsize"].ToString();
                    txtPoqty.Text = dsPoid.Tables[0].Rows[0]["PoQty"].ToString();
                    txtPriceperpack.Text = dsPoid.Tables[0].Rows[0]["Priceperpack"].ToString();
                    txtproductamt.Text = dsPoid.Tables[0].Rows[0]["Productamt"].ToString();
                    btnSubmit.Text = "Update";
                }

                #endregion

                DataSet ds = dbObj.getSuppliername(todaydate);
                ddlSuppliername.DataSource = ds;

                ddlSuppliername.DataTextField = "CompanyName";
                ddlSuppliername.DataValueField = "SupplierID";
                ddlSuppliername.DataBind();
                ddlSuppliername.Items.Insert(0, "Select CompanyName");


                DataSet ds1 = dbObj.getProductnamepo();
                ddlProductname.DataSource = ds1;

                ddlProductname.DataTextField = "Productname";
                ddlProductname.DataValueField = "ProductID";
                ddlProductname.DataBind();
                ddlProductname.Items.Insert(0, "Productname");

                #region LoadGrid CreatePO

                DataSet dscreatpo = new DataSet();
                dscreatpo = dbObj.Select_CreatePO();
                if (dscreatpo.Tables[0].Rows.Count > 0)
                {
                    grvCreatePo.DataSource = dscreatpo.Tables[0];
                    grvCreatePo.DataBind();
                }
                #endregion



                #region product details


                #endregion

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


                iPoid = Convert.ToInt32(Request.QueryString.Get("Poid"));
                itransPoid = Convert.ToInt32(Request.QueryString.Get("Transid"));

                if (iPoid != 0)
                {

                    btnSubmit.Text = "Update";
                    DataSet updatepo = new DataSet();
                    updatepo = dbObj.Select_updatepO(iPoid);
                    if (updatepo.Tables[0].Rows.Count > 0)
                    {
                        ViewState["vsPo"] = iPoid;
                    string status = updatepo.Tables[0].Rows[0]["Status"].ToString();
                    if (status == "Approved")
                    {
                        btnCancel.Text = "Back";
                        btnSubmit.Visible = false;
                        btnAddrows.Enabled = false;

                    }
                        int ApproverId = Convert.ToInt32(updatepo.Tables[0].Rows[0]["ApproverId"].ToString());
                    if (ApproverId == Empid)
                    {
                        ddlStatus.Enabled = true;
                    }
                    //itransPoid = Convert.ToInt32(updatepo.Tables[0].Rows[0]["TransPo"]);
                    txtPonumber.Text = Convert.ToString(updatepo.Tables[0].Rows[0]["POPrintno"].ToString());
                    ViewState["transid"] = itransPoid;
                        grvCreatePo.DataSource = updatepo.Tables[0];
                        grvCreatePo.DataBind();
                        #region Dropdown supliername
                        ddlSuppliername.DataSource = updatepo;
                        ddlSuppliername.DataTextField = "CompanyName";
                        ddlSuppliername.DataValueField = "SupplierID";
                        ddlSuppliername.DataBind();
                        ddlSuppliername.Items.Insert(0, "Select SupplierName");
                        ddlSuppliername.SelectedValue = updatepo.Tables[0].Rows[0]["SupplierId"].ToString();
                        #endregion

                        #region Dropdown Employee
                        ddlSelectapprover.DataSource = updatepo;
                        ddlSelectapprover.DataTextField = "EmployeeName";
                        ddlSelectapprover.DataValueField = "EmployeeID";
                        ddlSelectapprover.DataBind();
                        ddlSelectapprover.Items.Insert(0, "Select Approver");
                        #endregion

                        ddlSelectapprover.Text = updatepo.Tables[0].Rows[0]["ApproverId"].ToString();
                        txtTotalpoamount.Text = updatepo.Tables[0].Rows[0]["Amount"].ToString();
                        txtPonumber.Text = updatepo.Tables[0].Rows[0]["POPrintno"].ToString();
                        ddlStatus.Text = updatepo.Tables[0].Rows[0]["Status"].ToString();

                        iProductid = Convert.ToInt32(Request.QueryString.Get("Productid"));
                        if (iProductid != 0)
                        {
                            DataSet ds2 = dbObj.getProductnameforupdatepo(iProductid, iPoid);
                            ddlProductname.DataSource = ds2;

                            ddlProductname.DataTextField = "Productname";
                            ddlProductname.DataValueField = "ProductID";
                            ddlProductname.DataBind();
                            ddlProductname.Items.Insert(0, "Productname");
                            ddlProductname.SelectedValue = ds2.Tables[0].Rows[0]["ProductId"].ToString();
                            txtProductname.Text = ds2.Tables[0].Rows[0]["Productname"].ToString();
                            txtDosageform.Text = ds2.Tables[0].Rows[0]["Dosageform"].ToString();
                            txtStrength.Text = ds2.Tables[0].Rows[0]["Strength"].ToString();
                            txtPoqty.Text = ds2.Tables[0].Rows[0]["PoQty"].ToString();
                            txtPriceperpack.Text = ds2.Tables[0].Rows[0]["Priceperpack"].ToString();
                            txtproductamt.Text = ds2.Tables[0].Rows[0]["Productamt"].ToString();
                        }
                        else
                        {
                            DataSet ds2 = dbObj.getProductnameforupdate();
                            ddlProductname.DataSource = ds2;
                            ddlProductname.DataTextField = "Productname";
                            ddlProductname.DataValueField = "ProductID";
                            ddlProductname.DataBind();
                            ddlProductname.Items.Insert(0, "Productname");
                        }

                    }
                    else
                    {
                        string script = "alert('Data Not Available')";
                        ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                    }

                }

            }


        }


        protected void btnAddrows_Click(object sender, EventArgs e)
        {
            if (txtproductamt.Text =="0")
            {
                string script = "alert('Please Enter Price Per Pack')";
                ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
            }
            else
            {
                int pro = Convert.ToInt32(ViewState["prodid"]);
                int isucess = 0;
                iPoid = Convert.ToInt32(Request.QueryString.Get("Poid"));
                if (iPoid != 0)
                {
                    if (pro != 0)
                    {

                        DataSet prodid = dbObj.Select_Prodtemp();
                        if (prodid.Tables[0].Rows.Count > 0)
                        {
                            DataSet prodid1 = dbObj.Select_Prodpoid(Convert.ToInt32(ddlProductname.Text));
                            if (prodid1.Tables[0].Rows.Count > 0)
                            {

                                isucess = dbObj.UpdateTempProducts(Convert.ToInt32(ddlProductname.Text), txtProductname.Text, txtDosageform.Text, txtStrength.Text, txtPoqty.Text, txtPriceperpack.Text, txtVAT.Text, txtproductamt.Text);
                                string script2 = "alert('Row added')";
                                ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script2, true);
                            }
                            else
                            {
                                #region Clear Temp Table
                                int isucess3 = 0;
                                isucess3 = dbObj.ClearTempPO();
                                #endregion
                                #region Select_TransPO
                                DataSet dsTempPO = dbObj.Select_updatepO(iPoid);
                                if (dsTempPO.Tables[0].Rows.Count > 0)
                                {


                                    int count = dsTempPO.Tables[0].Rows.Count;
                                    for (int i = 0; i < count; i++)
                                    {
                                        string productname = dsTempPO.Tables[0].Rows[i]["Productid"].ToString();
                                        string Licenseno = dsTempPO.Tables[0].Rows[i]["Licenseno"].ToString();
                                        string Productname = dsTempPO.Tables[0].Rows[i]["Productname"].ToString();
                                        string Dosageform = dsTempPO.Tables[0].Rows[i]["Dosageform"].ToString();
                                        string Strength = dsTempPO.Tables[0].Rows[i]["Strength"].ToString();
                                        //string Packtype = dsTempPO.Tables[0].Rows[i]["Packtype"].ToString();
                                        //string Packsize = dsTempPO.Tables[0].Rows[i]["Packsize"].ToString();
                                        string Packqty = dsTempPO.Tables[0].Rows[i]["PoQty"].ToString();
                                        string Priceperpack = dsTempPO.Tables[0].Rows[i]["Priceperpack"].ToString();
                                        string VAT = dsTempPO.Tables[0].Rows[i]["VAT"].ToString();
                                        string Productamnt = dsTempPO.Tables[0].Rows[i]["Productamt"].ToString();
                                        isucess = dbObj.InsertProducts(Convert.ToInt32(productname), Productname, Dosageform, Strength, Packqty, Priceperpack, VAT, Productamnt);

                                    }
                                    DataSet prodid2 = dbObj.Select_Prodpoid(Convert.ToInt32(ddlProductname.Text));
                                    if (prodid2.Tables[0].Rows.Count > 0)
                                    {

                                        isucess = dbObj.UpdateTempProducts(Convert.ToInt32(ddlProductname.Text), txtProductname.Text, txtDosageform.Text, txtStrength.Text, txtPoqty.Text, txtPriceperpack.Text, txtVAT.Text, txtproductamt.Text);
                                        string script3 = "alert('Row added')";
                                        ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script3, true);
                                    }
                                    else
                                    {
                                        isucess = dbObj.InsertProducts(Convert.ToInt32(ddlProductname.Text), txtProductname.Text, txtDosageform.Text, txtStrength.Text, txtPoqty.Text, txtPriceperpack.Text, txtVAT.Text, txtproductamt.Text);
                                        string script2 = "alert('Row added')";
                                        ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script2, true);
                                    }

                                }
                                #endregion
                            }
                        }
                        else
                        {
                            #region Clear Temp Table
                            int isucess3 = 0;
                            isucess3 = dbObj.ClearTempPO();
                            #endregion
                            #region Select_TransPO
                            DataSet dsTempPO = dbObj.Select_updatepO(iPoid);
                            if (dsTempPO.Tables[0].Rows.Count > 0)
                            {


                                int count = dsTempPO.Tables[0].Rows.Count;
                                for (int i = 0; i < count; i++)
                                {
                                    string productname = dsTempPO.Tables[0].Rows[i]["Productid"].ToString();
                                    string Licenseno = dsTempPO.Tables[0].Rows[i]["Licenseno"].ToString();
                                    string Productname = dsTempPO.Tables[0].Rows[i]["Productname"].ToString();
                                    string Dosageform = dsTempPO.Tables[0].Rows[i]["Dosageform"].ToString();
                                    string Strength = dsTempPO.Tables[0].Rows[i]["Strength"].ToString();
                                    //string Packtype = dsTempPO.Tables[0].Rows[i]["Packtype"].ToString();
                                    //string Packsize = dsTempPO.Tables[0].Rows[i]["Packsize"].ToString();
                                    string Packqty = dsTempPO.Tables[0].Rows[i]["PoQty"].ToString();
                                    string Priceperpack = dsTempPO.Tables[0].Rows[i]["Priceperpack"].ToString();
                                    string VAT = dsTempPO.Tables[0].Rows[i]["VAT"].ToString();
                                    string Productamnt = dsTempPO.Tables[0].Rows[i]["Productamt"].ToString();
                                    isucess = dbObj.InsertProducts(Convert.ToInt32(productname), Productname, Dosageform, Strength, Packqty, Priceperpack, VAT, Productamnt);

                                }
                                DataSet prodid1 = dbObj.Select_Prodpoid(Convert.ToInt32(ddlProductname.Text));
                                if (prodid1.Tables[0].Rows.Count > 0)
                                {

                                    isucess = dbObj.UpdateTempProducts(Convert.ToInt32(ddlProductname.Text), txtProductname.Text, txtDosageform.Text, txtStrength.Text, txtPoqty.Text, txtPriceperpack.Text, txtVAT.Text, txtproductamt.Text);
                                    string script3 = "alert('Row added')";
                                    ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script3, true);
                                }
                                else
                                {
                                    isucess = dbObj.InsertProducts(Convert.ToInt32(ddlProductname.Text), txtProductname.Text, txtDosageform.Text, txtStrength.Text, txtPoqty.Text, txtPriceperpack.Text, txtVAT.Text, txtproductamt.Text);
                                    string script2 = "alert('Row added')";
                                    ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script2, true);
                                }

                            }
                            #endregion
                        }


                    }
                    else
                    {
                        DataSet prodid = dbObj.Select_Prodtemp();
                        if (prodid.Tables[0].Rows.Count > 0)
                        {
                            DataSet prodid1 = dbObj.Select_Prodpoid(Convert.ToInt32(ddlProductname.Text));
                            if (prodid1.Tables[0].Rows.Count > 0)
                            {

                                isucess = dbObj.UpdateTempProducts(Convert.ToInt32(ddlProductname.Text), txtProductname.Text, txtDosageform.Text, txtStrength.Text, txtPoqty.Text, txtPriceperpack.Text, txtVAT.Text, txtproductamt.Text);
                                string script2 = "alert('Row added')";
                                ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script2, true);
                            }
                            else
                            {
                                isucess = dbObj.InsertProducts(Convert.ToInt32(ddlProductname.Text), txtProductname.Text, txtDosageform.Text, txtStrength.Text, txtPoqty.Text, txtPriceperpack.Text, txtVAT.Text, txtproductamt.Text);
                                string script = "alert('Row added')";
                                ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                            }

                        }
                        else
                        {
                            #region Clear Temp Table
                            int isucess3 = 0;
                            isucess3 = dbObj.ClearTempPO();
                            #endregion

                            #region Select_TransPO
                            DataSet dsTempPO = dbObj.Select_updatepO(iPoid);
                            if (dsTempPO.Tables[0].Rows.Count > 0)
                            {


                                int count = dsTempPO.Tables[0].Rows.Count;
                                for (int i = 0; i < count; i++)
                                {
                                    string productname = dsTempPO.Tables[0].Rows[i]["Productid"].ToString();
                                    string Licenseno = dsTempPO.Tables[0].Rows[i]["Licenseno"].ToString();
                                    string Productname = dsTempPO.Tables[0].Rows[i]["Productname"].ToString();
                                    string Dosageform = dsTempPO.Tables[0].Rows[i]["Dosageform"].ToString();
                                    string Strength = dsTempPO.Tables[0].Rows[i]["Strength"].ToString();
                                    //string Packtype = dsTempPO.Tables[0].Rows[i]["Packtype"].ToString();
                                    //string Packsize = dsTempPO.Tables[0].Rows[i]["Packsize"].ToString();
                                    string Packqty = dsTempPO.Tables[0].Rows[i]["PoQty"].ToString();
                                    string Priceperpack = dsTempPO.Tables[0].Rows[i]["Priceperpack"].ToString();
                                    string VAT = dsTempPO.Tables[0].Rows[i]["VAT"].ToString();
                                    string Productamnt = dsTempPO.Tables[0].Rows[i]["Productamt"].ToString();
                                    isucess = dbObj.InsertProducts(Convert.ToInt32(productname), Productname, Dosageform, Strength, Packqty, Priceperpack, VAT, Productamnt);

                                }
                                DataSet prodid2 = dbObj.Select_Prodpoid(Convert.ToInt32(ddlProductname.Text));
                                if (prodid2.Tables[0].Rows.Count > 0)
                                {

                                    isucess = dbObj.UpdateTempProducts(Convert.ToInt32(ddlProductname.Text), txtProductname.Text, txtDosageform.Text, txtStrength.Text, txtPoqty.Text, txtPriceperpack.Text, txtVAT.Text, txtproductamt.Text);
                                    string script2 = "alert('Row added')";
                                    ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script2, true);
                                }
                                else
                                {
                                    isucess = dbObj.InsertProducts(Convert.ToInt32(ddlProductname.Text), txtProductname.Text, txtDosageform.Text, txtStrength.Text, txtPoqty.Text, txtPriceperpack.Text, txtVAT.Text, txtproductamt.Text);
                                    string script = "alert('Row added')";
                                    ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);

                                }

                            }
                            #endregion
                        }

                    }

                }
                else
                {

                    DataSet prodid2 = dbObj.Select_Prodpoid(Convert.ToInt32(ddlProductname.Text));
                    if (prodid2.Tables[0].Rows.Count > 0)
                    {

                        isucess = dbObj.UpdateTempProducts(Convert.ToInt32(ddlProductname.Text), txtProductname.Text, txtDosageform.Text, txtStrength.Text, txtPoqty.Text, txtPriceperpack.Text, txtVAT.Text, txtproductamt.Text);
                        string script2 = "alert('Row added')";
                        ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script2, true);
                    }
                    else
                    {
                        isucess = dbObj.InsertProducts(Convert.ToInt32(ddlProductname.Text), txtProductname.Text, txtDosageform.Text, txtStrength.Text, txtPoqty.Text, txtPriceperpack.Text, txtVAT.Text, txtproductamt.Text);
                        string script = "alert('Row added')";
                        ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);

                    }
                }

                DataSet dscreatpo = new DataSet();
                dscreatpo = dbObj.Select_CreatePO();
                if (dscreatpo.Tables[0].Rows.Count > 0)
                {
                    grvCreatePo.DataSource = dscreatpo.Tables[0];
                    grvCreatePo.DataBind();
                    double totalPoAmount = 0;

                    for (int i = 0; i < dscreatpo.Tables[0].Rows.Count; i++)
                    {
                        double productAmount = Convert.ToDouble(dscreatpo.Tables[0].Rows[i]["productamt"].ToString());
                        totalPoAmount += productAmount;
                    }
                    txtTotalpoamount.Text = Convert.ToString(totalPoAmount);
                    // Clearing the textboxes
                    // txtLicenseno.Text = "";
                    txtProductname.Text = "";
                    txtDosageform.Text = "";
                    txtStrength.Text = "";
                    //txtPacktype.Text = "";
                    //txtPacksize.Text = "";
                    txtPoqty.Text = "0";
                    txtPriceperpack.Text = "0";
                    txtVAT.Text = "0";
                    txtproductamt.Text = "0";

                }
                DataSet ds1 = dbObj.getProductnamepo();
                ddlProductname.DataSource = ds1;

                ddlProductname.DataTextField = "Productname";
                ddlProductname.DataValueField = "ProductID";
                ddlProductname.DataBind();
                ddlProductname.Items.Insert(0, "Productname");
            }
           
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtTotalpoamount.Text == "0")
            {
                string script = "alert('Please Select Product Details  & Click Plus Button')";
                ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
            }
            else
            {

                if (ddlSuppliername.SelectedValue == "Select CompanyName")
                {
                    string script = "alert('Select CompanyName')";
                    ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                }
                else if (ddlSelectapprover.SelectedValue == "Select Approver")
                {
                    string script = "alert('Select Approver')";
                    ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                }
                else
                {


                    if (btnSubmit.Text == "Submit")
                    {
                        int isucess = 0;
                        #region GetMAxPOPrint
                        DataSet dsPOprintno = dbObj.GetMaxPOPrintno_only();
                        int iPOprintMax = Convert.ToInt32(dsPOprintno.Tables[0].Rows[0]["Printno"].ToString());
                        #endregion
                        isucess = dbObj.InsertDetails(ddlSuppliername.SelectedValue, DateTime.Parse(txtPodate.Text), Convert.ToInt32(ddlSelectapprover.SelectedValue), ddlStatus.SelectedItem.Text, txtTotalpoamount.Text, iPOprintMax.ToString());

                        #region GetMAxPO
                        DataSet dsPO = dbObj.GetMaxPO_only();
                        int iPOMax = Convert.ToInt32(dsPO.Tables[0].Rows[0]["Poid"].ToString());
                        #endregion

                        #region Insert_TransPO
                        DataSet dsTempPO = dbObj.Select_CreatePO();
                        if (dsTempPO.Tables[0].Rows.Count > 0)
                        {
                            int count = dsTempPO.Tables[0].Rows.Count;
                            for (int i = 0; i < count; i++)
                            {
                                string productname = dsTempPO.Tables[0].Rows[i]["Productid"].ToString();
                                string Licenseno = dsTempPO.Tables[0].Rows[i]["Licenseno"].ToString();
                                string Productname = dsTempPO.Tables[0].Rows[i]["Productname"].ToString();
                                string Dosageform = dsTempPO.Tables[0].Rows[i]["Dosageform"].ToString();
                                string Strength = dsTempPO.Tables[0].Rows[i]["Strength"].ToString();
                                //string Packtype = dsTempPO.Tables[0].Rows[i]["Packtype"].ToString();
                                //string Packsize = dsTempPO.Tables[0].Rows[i]["Packsize"].ToString();
                                string Packqty = dsTempPO.Tables[0].Rows[i]["PoQty"].ToString();
                                string Priceperpack = dsTempPO.Tables[0].Rows[i]["Priceperpack"].ToString();
                                string VAT = dsTempPO.Tables[0].Rows[i]["VAT"].ToString();
                                string Productamnt = dsTempPO.Tables[0].Rows[i]["Productamt"].ToString();
                                int iSuccess1 = dbObj.InsertTransPOProducts(iPOMax, Convert.ToInt32(productname), Licenseno, Productname, Dosageform, Strength, Packqty, Priceperpack,VAT, Productamnt);
                            }
                        }
                        #endregion
                        #region Clear Temp Table
                        int iDelete = dbObj.ClearTempPO();
                        #endregion

                        string script = "alert('PO Stored');window.location.href = 'POGrid.aspx'";
                        ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                        //Response.Redirect("POGrid.aspx");

                    }
                    else if (btnSubmit.Text == "Update")
                    {
                        iPoid = Convert.ToInt32(Request.QueryString.Get("Poid"));
                        if (iPoid != 0)
                        {
                            int isucess = 0;
                            isucess = dbObj.UpdateCreatePo(Convert.ToInt32(ViewState["vsPo"]), ddlSuppliername.SelectedValue, DateTime.Parse(txtPodate.Text), Convert.ToInt32(ddlSelectapprover.SelectedValue), ddlStatus.SelectedItem.Text, txtTotalpoamount.Text);
                            int isucess3 = 0;
                            #region update po
                            DataSet dsTempPO = dbObj.Select_CreatePO();
                            if (dsTempPO.Tables[0].Rows.Count>0)
                            {
                                isucess3 = dbObj.deletetranspoold(iPoid);
                                if (dsTempPO.Tables[0].Rows.Count > 0)
                                {
                                    int count = dsTempPO.Tables[0].Rows.Count;

                                    for (int i = 0; i < count; i++)
                                    {
                                        //string Poid = dsTempPO.Tables[0].Rows[i]["Poid"].ToString();
                                        string productname = dsTempPO.Tables[0].Rows[i]["Productid"].ToString();
                                        string Licenseno = dsTempPO.Tables[0].Rows[i]["Licenseno"].ToString();
                                        string Productname = dsTempPO.Tables[0].Rows[i]["Productname"].ToString();
                                        string Dosageform = dsTempPO.Tables[0].Rows[i]["Dosageform"].ToString();
                                        string Strength = dsTempPO.Tables[0].Rows[i]["Strength"].ToString();
                                        //string Packtype = dsTempPO.Tables[0].Rows[i]["Packtype"].ToString();
                                        //string Packsize = dsTempPO.Tables[0].Rows[i]["Packsize"].ToString();
                                        string Packqty = dsTempPO.Tables[0].Rows[i]["PoQty"].ToString();
                                        string Priceperpack = dsTempPO.Tables[0].Rows[i]["Priceperpack"].ToString();
                                        string VAT = dsTempPO.Tables[0].Rows[i]["VAT"].ToString();
                                        string Productamnt = dsTempPO.Tables[0].Rows[i]["Productamt"].ToString();
                                        int isucess2 = 0;
                                        isucess2 = dbObj.updatetranspoProducts(iPoid, Convert.ToInt32(productname), Productname, Dosageform, Strength, Packqty, Priceperpack, VAT, Productamnt);
                                        //int isucess5 = 0;
                                    }
                                }
                                else
                                {
                                    isucess = dbObj.UpdateCreatePo(Convert.ToInt32(ViewState["vsPo"]), ddlSuppliername.SelectedValue, DateTime.Parse(txtPodate.Text), Convert.ToInt32(ddlSelectapprover.SelectedValue), ddlStatus.SelectedItem.Text, txtTotalpoamount.Text);
                                    string script1 = "alert('Data Updated')";
                                    ClientScript.RegisterStartupScript(this.GetType(), "UpdateMessage", script1, true);
                                    Response.Redirect("POGrid.aspx");
                                }
                              
                                //}
                            }
                            #endregion
                            string script = "alert('Data Updated')";
                            ClientScript.RegisterStartupScript(this.GetType(), "UpdateMessage", script, true);
                            Response.Redirect("POGrid.aspx");


                        }
                    }
                    else
                    {
                        string script = "alert('No data Available')";
                        ClientScript.RegisterStartupScript(this.GetType(), "UpdateMessage", script, true);
                        Response.Redirect("POGrid.aspx");
                    }

                }
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
                //txtPacktype.Text = dsProdId.Tables[0].Rows[0]["Packtype"].ToString();
                //txtPacksize.Text = dsProdId.Tables[0].Rows[0]["Packsize"].ToString();
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
        private void BindPo()
        {
            DataSet dsPO = new DataSet();
            dsPO = dbObj.Select_CreatePO();
            if (dsPO.Tables[0].Rows.Count > 0)
            {
                grvCreatePo.DataSource = dsPO.Tables[0];
                grvCreatePo.DataBind();
            }
            else
            {
                grvCreatePo.DataSource = null;
                grvCreatePo.DataBind();
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {

        }
        protected void grvCreatePo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            iPoid = Convert.ToInt32(Request.QueryString.Get("Poid"));
            #region Edit
            if (e.CommandName == "editt")
            {
                HiddenField updateprod = (HiddenField)grvCreatePo.Rows[0].FindControl("hiden");
                int editprodid = Convert.ToInt32(updateprod.Value);
                int prodid = Convert.ToInt32(e.CommandArgument);
                ViewState["prodid"] = prodid;
                //iProductid = Convert.ToInt32(Request.QueryString.Get("Productid"));
                if (prodid != 0)
                {
                    DataSet Temp = dbObj.Gettemptbl();
                    if (Temp.Tables[0].Rows.Count>0)
                    {
                        DataSet ds3 = dbObj.getProductnametemppo(prodid);
                        ddlProductname.DataSource = ds3;
                        ddlProductname.DataTextField = "Productname";
                        ddlProductname.DataValueField = "ProductID";
                        ddlProductname.DataBind();
                        ddlProductname.Items.Insert(0, "Productname");
                        ddlProductname.SelectedValue = ds3.Tables[0].Rows[0]["ProductId"].ToString();

                        txtProductname.Text = ds3.Tables[0].Rows[0]["Productname"].ToString();
                        txtDosageform.Text = ds3.Tables[0].Rows[0]["Dosageform"].ToString();
                        txtStrength.Text = ds3.Tables[0].Rows[0]["Strength"].ToString();
                        txtPoqty.Text = ds3.Tables[0].Rows[0]["PoQty"].ToString();
                        txtPriceperpack.Text = ds3.Tables[0].Rows[0]["Priceperpack"].ToString();
                        txtVAT.Text = ds3.Tables[0].Rows[0]["VAT"].ToString();
                        txtproductamt.Text = ds3.Tables[0].Rows[0]["Productamt"].ToString();
                    }
                    else
                    {
                        DataSet ds2 = dbObj.getProductnameforupdatepo(prodid, iPoid);
                        ddlProductname.DataSource = ds2;
                        ddlProductname.DataTextField = "Productname";
                        ddlProductname.DataValueField = "ProductID";
                        ddlProductname.DataBind();
                        ddlProductname.Items.Insert(0, "Productname");
                        ddlProductname.SelectedValue = ds2.Tables[0].Rows[0]["ProductId"].ToString();

                        txtProductname.Text = ds2.Tables[0].Rows[0]["Productname"].ToString();
                        txtDosageform.Text = ds2.Tables[0].Rows[0]["Dosageform"].ToString();
                        txtStrength.Text = ds2.Tables[0].Rows[0]["Strength"].ToString();
                        txtPoqty.Text = ds2.Tables[0].Rows[0]["PoQty"].ToString();
                        txtPriceperpack.Text = ds2.Tables[0].Rows[0]["Priceperpack"].ToString();
                        txtVAT.Text = ds2.Tables[0].Rows[0]["VAT"].ToString();
                        txtproductamt.Text = ds2.Tables[0].Rows[0]["Productamt"].ToString();
                    }
                   
                }
                else
                {
                    string script = "alert('No data Available')";
                    ClientScript.RegisterStartupScript(this.GetType(), "UpdateMessage", script, true);
                    Response.Redirect("POGrid.aspx");
                }
                //Response.Redirect("CreatePO.aspx?Event=Edit&Productid=" + e.CommandArgument.ToString()+"&Poid="+ iPoid);
                //Response.Redirect("CreatePO.aspx?Event=Edit&Productid=" + e.CommandArgument.ToString());

            }

            if (e.CommandName == "Del")
            {
                string[] comment1 = e.CommandArgument.ToString().Split(new char[] { ';' });
                string poid = comment1[0];
                string productid1 = comment1[1];
                int iPoid = Convert.ToInt32(poid);
                //HiddenField prodiid = (HiddenField)grvCreatePo.Rows[0].FindControl("hiddenprdid");
                //int delprodid = Convert.ToInt32(prodiid.Value);
                DataSet prodid = dbObj.Select_Prodtemp();
                if (prodid.Tables[0].Rows.Count > 0)
                {
                    dbObj.deletePO(Convert.ToInt32(productid1));
                    DataSet dscreatpo = new DataSet();
                    dscreatpo = dbObj.Select_CreatePO();
                    if (dscreatpo.Tables[0].Rows.Count > 0)
                    {
                        grvCreatePo.DataSource = dscreatpo.Tables[0];
                        grvCreatePo.DataBind();
                        double totalPoAmount = 0;

                        for (int i = 0; i < dscreatpo.Tables[0].Rows.Count; i++)
                        {
                            double productAmount = Convert.ToDouble(dscreatpo.Tables[0].Rows[i]["productamt"].ToString());
                            totalPoAmount += productAmount;
                        }
                        txtTotalpoamount.Text = Convert.ToString(totalPoAmount);
                        //BindPo();
                        txtProductname.Text = "";
                        txtDosageform.Text = "";
                        txtStrength.Text = "";
                        //txtPacktype.Text = "";
                        //txtPacksize.Text = "";
                        txtPoqty.Text = "0";
                        txtPriceperpack.Text = "0";
                        txtVAT.Text = "0";
                        txtproductamt.Text = "0";

                        DataSet ds1 = dbObj.getProductnamepo();
                        ddlProductname.DataSource = ds1;

                        ddlProductname.DataTextField = "Productname";
                        ddlProductname.DataValueField = "ProductID";
                        ddlProductname.DataBind();
                        ddlProductname.Items.Insert(0, "Productname");
                    }
                    else
                    {
                        grvCreatePo.DataSource = null;
                        grvCreatePo.DataBind();

                        txtProductname.Text = "";
                        txtDosageform.Text = "";
                        txtStrength.Text = "";
                        //txtPacktype.Text = "";
                        //txtPacksize.Text = "";
                        txtPoqty.Text = "0";
                        txtPriceperpack.Text = "0";
                        txtVAT.Text = "0";
                        txtproductamt.Text = "0";
                        txtTotalpoamount.Text = "0.00";

                        DataSet ds1 = dbObj.getProductnamepo();
                        ddlProductname.DataSource = ds1;

                        ddlProductname.DataTextField = "Productname";
                        ddlProductname.DataValueField = "ProductID";
                        ddlProductname.DataBind();
                        ddlProductname.Items.Insert(0, "Productname");
                    }
                }
                else
                {
                    #region Clear Temp Table
                    int isucess3 = 0;
                    isucess3 = dbObj.ClearTempPO();
                    #endregion

                    #region Select_TransPO
                    DataSet dsTempPO = dbObj.Select_updatepO(iPoid);
                    if (dsTempPO.Tables[0].Rows.Count > 0)
                    {
                        int count = dsTempPO.Tables[0].Rows.Count;
                        for (int i = 0; i < count; i++)
                        {
                            string productname = dsTempPO.Tables[0].Rows[i]["Productid"].ToString();
                            string Licenseno = dsTempPO.Tables[0].Rows[i]["Licenseno"].ToString();
                            string Productname = dsTempPO.Tables[0].Rows[i]["Productname"].ToString();
                            string Dosageform = dsTempPO.Tables[0].Rows[i]["Dosageform"].ToString();
                            string Strength = dsTempPO.Tables[0].Rows[i]["Strength"].ToString();
                            //string Packtype = dsTempPO.Tables[0].Rows[i]["Packtype"].ToString();
                            //string Packsize = dsTempPO.Tables[0].Rows[i]["Packsize"].ToString();
                            string Packqty = dsTempPO.Tables[0].Rows[i]["PoQty"].ToString();
                            string Priceperpack = dsTempPO.Tables[0].Rows[i]["Priceperpack"].ToString();
                            string VAT = dsTempPO.Tables[0].Rows[i]["VAT"].ToString();
                            string Productamnt = dsTempPO.Tables[0].Rows[i]["Productamt"].ToString();
                            int isucess = dbObj.InsertProducts(Convert.ToInt32(productname), Productname, Dosageform, Strength, Packqty, Priceperpack,VAT, Productamnt);

                        }
                        dbObj.deletePO(Convert.ToInt32(productid1));
                        DataSet dscreatpo = new DataSet();
                        dscreatpo = dbObj.Select_CreatePO();
                        if (dscreatpo.Tables[0].Rows.Count > 0)
                        {
                            grvCreatePo.DataSource = dscreatpo.Tables[0];
                            grvCreatePo.DataBind();
                            double totalPoAmount = 0;

                            for (int i = 0; i < dscreatpo.Tables[0].Rows.Count; i++)
                            {
                                double productAmount = Convert.ToDouble(dscreatpo.Tables[0].Rows[i]["productamt"].ToString());
                                totalPoAmount += productAmount;
                            }
                            txtTotalpoamount.Text = Convert.ToString(totalPoAmount);
                            //BindPo();
                            txtProductname.Text = "";
                            txtDosageform.Text = "";
                            txtStrength.Text = "";
                            //txtPacktype.Text = "";
                            //txtPacksize.Text = "";
                            txtPoqty.Text = "0";
                            txtPriceperpack.Text = "0";
                            txtVAT.Text = "0";
                            txtproductamt.Text = "0";

                            DataSet ds1 = dbObj.getProductnamepo();
                            ddlProductname.DataSource = ds1;

                            ddlProductname.DataTextField = "Productname";
                            ddlProductname.DataValueField = "ProductID";
                            ddlProductname.DataBind();
                            ddlProductname.Items.Insert(0, "Productname");
                        }
                        else
                        {
                            grvCreatePo.DataSource =null;
                            grvCreatePo.DataBind();

                            txtProductname.Text = "";
                            txtDosageform.Text = "";
                            txtStrength.Text = "";
                            //txtPacktype.Text = "";
                            //txtPacksize.Text = "";
                            txtPoqty.Text = "0";
                            txtPriceperpack.Text = "0";
                            txtVAT.Text = "0";
                            txtproductamt.Text = "0";
                            txtTotalpoamount.Text = "0.00";

                            DataSet ds1 = dbObj.getProductnamepo();
                            ddlProductname.DataSource = ds1;

                            ddlProductname.DataTextField = "Productname";
                            ddlProductname.DataValueField = "ProductID";
                            ddlProductname.DataBind();
                            ddlProductname.Items.Insert(0, "Productname");
                        }
                    }
                    #endregion
                }


            }
            #endregion
            updatepanel.Update();
        }

        protected void txtPoqty_TextChanged(object sender, EventArgs e)
        {
            DataSet dsProduct = new DataSet();
            dsProduct = dbObj.selectProduct_byProductId(Convert.ToInt32(ddlProductname.SelectedValue));
            if (dsProduct.Tables[0].Rows.Count > 0)
            {
                int poqty = 0;
                int.TryParse(txtPoqty.Text, out poqty);
                // Calculate the Total Batches
                decimal priceperpack = 0;
                decimal.TryParse(txtPriceperpack.Text, out priceperpack);
                decimal totalamount = poqty * priceperpack;
                vat.Text = totalamount.ToString();
                // Set the value of the Total Batches TextBox
                decimal vatamnt = (decimal.Parse(vat.Text) * decimal.Parse(txtVAT.Text)) / 100;
                decimal vatcal = Convert.ToDecimal(totalamount) + vatamnt;
                txtproductamt.Text = vatcal.ToString();
            }
            else
            {
                string script = "alert('Enter Valid Qty')";
                txtPoqty.Text = "";
                ClientScript.RegisterStartupScript(this.GetType(), "UpdateMessage", script, true);
            }
        }

       
        protected void txtVAT_TextChanged(object sender, EventArgs e)
        {
            if (vat.Text == "")
            {
                int poqty = 0;
                int.TryParse(txtPoqty.Text, out poqty);
                // Calculate the Total Batches
                decimal priceperpack = 0;
                decimal.TryParse(txtPriceperpack.Text, out priceperpack);
                decimal total = poqty * priceperpack;
                vat.Text = total.ToString();
                decimal ttlamount = Convert.ToDecimal(vat.Text);
                decimal vatamnt = (decimal.Parse(vat.Text) * decimal.Parse(txtVAT.Text)) / 100;
                decimal vatcal = Convert.ToDecimal(ttlamount) + vatamnt;
                txtproductamt.Text = vatcal.ToString();
                vat.Text = "";
            }
            else
            {
                int poqty = 0;
                int.TryParse(txtPoqty.Text, out poqty);
                // Calculate the Total Batches
                decimal priceperpack = 0;
                decimal.TryParse(txtPriceperpack.Text, out priceperpack);
                decimal total = poqty * priceperpack;
                vat.Text = total.ToString();
                decimal ttlamount = Convert.ToDecimal(vat.Text);
                decimal vatamnt = (decimal.Parse(vat.Text) * decimal.Parse(txtVAT.Text)) / 100;
                decimal vatcal = Convert.ToDecimal(ttlamount) + vatamnt;
                txtproductamt.Text = vatcal.ToString();
                vat.Text = "";
            }
            
        }

        protected void grvCreatePo_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (iPoid != 0)
                {
                    #region Check Status
                    DataSet dspocreate = dbObj.Select_updatepO(iPoid);
                    string status = dspocreate.Tables[0].Rows[0]["Status"].ToString();
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

            }
        }

    }   
}