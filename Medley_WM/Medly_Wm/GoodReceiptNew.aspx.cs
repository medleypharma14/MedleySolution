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
    public partial class GoodReceiptNew : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
        int iWarehouseId = 0;
        int iPoid; int iProId; string sName; string Total;
        int iProductID = 0; int Empid = 0;
        int iGRId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                
                iPoid = Convert.ToInt32(Request.QueryString.Get("Poid"));
                iProId = Convert.ToInt32(Request.QueryString.Get("Productid"));
                sName = (Request.QueryString.Get("name"));
                Total = (Request.QueryString.Get("Total"));
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
                editpalet.Visible = false;
                if (iPoid != 0)
                {

                    DataSet dsgr = new DataSet();
                    dsgr = dbObj.selecttranspoby_poid(iPoid);
                    ViewState["vspoid"] = iPoid;

                    if (dsgr.Tables[0].Rows.Count > 0)
                    {
                        #region Poid
                        DataSet ds1 = dbObj.select_Po1();//select_Po();
                        ddlPOnumber.DataSource = ds1;
                        ddlPOnumber.DataTextField = "Poid";
                        ddlPOnumber.DataValueField = "Poid";
                        ddlPOnumber.DataBind();
                        ddlPOnumber.Items.Insert(0, "Select Poid");
                        #endregion

                        ddlPOnumber.Text = dsgr.Tables[0].Rows[0]["Poid"].ToString();
                        #region productid
                        DataSet dsProdId = new DataSet();
                        dsProdId = dbObj.select_TranspoProductid();
                        ddlProductid.DataSource = dsProdId;
                        ddlProductid.DataTextField = "Productname";
                        ddlProductid.DataValueField = "Productid";
                        ddlProductid.DataBind();
                        ddlProductid.Items.Insert(0, "Select Productid");
                        #endregion
                        ddlProductid.Text = dsgr.Tables[0].Rows[0]["ProductId"].ToString();
                        txtDosageform.Text = dsgr.Tables[0].Rows[0]["Dosageform"].ToString();
                        txtStrength.Text = dsgr.Tables[0].Rows[0]["Strength"].ToString();
                        txtOrderqty.Text = dsgr.Tables[0].Rows[0]["PoQty"].ToString();
                        txtOrderAmount.Text = dsgr.Tables[0].Rows[0]["Productamt"].ToString();
                        txtRecdQty.Text = Total;

                        #region Dropdown Approver
                        DataSet dsApprovar1 = new DataSet();
                        dsApprovar1 = dbObj.Select_Employeename();
                        if (dsApprovar1.Tables[0].Rows.Count > 0)
                        {
                            ddlSelectapprover.DataSource = dsApprovar1;
                            ddlSelectapprover.DataTextField = "EmployeeName";
                            ddlSelectapprover.DataValueField = "EmployeeID";
                            ddlSelectapprover.DataBind();
                        }
                        #endregion
                        //ddlSelectapprover.SelectedValue = dsgr.Tables[0].Rows[0]["ApproverId"].ToString();
                        // ddlStatus.SelectedItem.Text = dsgr.Tables[0].Rows[0]["Status"].ToString();
                    }
                }



                #region Edit
                iProductID = Convert.ToInt32(Request.QueryString.Get("iProductID"));
                if (Request.Cookies["userInfo"]["EmployeeID"] != null && Request.Cookies["userInfo"]["Empname"] != null)
                {
                    Empid = Convert.ToInt32(Request.Cookies["userInfo"]["EmployeeID"]);


                }
                
                iGRId = Convert.ToInt32(Request.QueryString.Get("GRId"));
                if (iGRId != 0)
                {
                    clearunit.Visible = true;
                    editpalet.Visible = true;
                    txtPallets.Enabled = false;
                    SelectOrder.Visible = false;
                    DataSet dsgr = new DataSet();
                    dsgr = dbObj.selectGR_byGRId(iGRId);
                    ViewState["vsGR"] = iGRId;
                    string Returnidval = dsgr.Tables[0].Rows[0]["Returnid"].ToString();
                    if (!string.IsNullOrEmpty(Returnidval) && Convert.ToInt32(Returnidval) != 0)
                    {
                        poorder.Visible = false;
                        returnorder.Visible = true;
                        if (dsgr.Tables[0].Rows.Count > 0)
                        {
                            int ApproverId = Convert.ToInt32(dsgr.Tables[0].Rows[0]["ApproverId"].ToString());
                            if (ApproverId == Empid)
                            {
                                ddlStatus.Enabled = true;
                            }
                            ddlReturnnumber.Enabled = false;
                            txtGRNnumber.Text = dsgr.Tables[0].Rows[0]["GRId"].ToString();
                            ddlReturnnumber.DataSource = dsgr;
                            ddlReturnnumber.DataTextField = "ReturnPrintno";
                            ddlReturnnumber.DataValueField = "Returnid";
                            ddlReturnnumber.DataBind();
                            ddlReturnnumber.Items.Insert(0, "Select ReturnID");
                            ddlReturnnumber.Text = Convert.ToInt32(dsgr.Tables[0].Rows[0]["Returnid"]).ToString();
                            #region productid
                            DataSet dsProdId = new DataSet();
                            dsProdId = dbObj.select_TranspoProductid();
                            ddlProductid.DataSource = dsProdId;
                            ddlProductid.DataTextField = "Productname";
                            ddlProductid.DataValueField = "Productid";
                            ddlProductid.DataBind();
                            ddlProductid.Items.Insert(0, "Select Productid");
                            #endregion
                            ddlProductid.Text = dsgr.Tables[0].Rows[0]["ProductId"].ToString();
                            ddlProductid.Enabled = false;
                            txtDosageform.Text = dsgr.Tables[0].Rows[0]["Dosage"].ToString();
                            txtStrength.Text = dsgr.Tables[0].Rows[0]["Strength"].ToString();                            //txtPacktype.Text = dsgr.Tables[0].Rows[0]["Packtype"].ToString();
                            txtOrderqty.Text = dsgr.Tables[0].Rows[0]["OrderQty"].ToString();
                            txtOrderAmount.Text = dsgr.Tables[0].Rows[0]["OrderAmt"].ToString();
                            txtBatch.Text = dsgr.Tables[0].Rows[0]["Batchnumber"].ToString();
                            int Ordqty = Convert.ToInt32(dsgr.Tables[0].Rows[0]["OrderQty"].ToString());
                            int Rcdqty = Convert.ToInt32(dsgr.Tables[0].Rows[0]["Qty"].ToString());
                            int remainqty = 0;
                            txtRecdQty.Text = dsgr.Tables[0].Rows[0]["Qty"].ToString();
                            DataSet dsremqty = dbObj.Getremcqtyret(Convert.ToInt32(ddlReturnnumber.Text), Convert.ToInt32(ddlProductid.Text));
                            if (dsremqty.Tables[0].Rows.Count > 0)
                            {
                                int rqty = Convert.ToInt32(dsremqty.Tables[0].Rows[0]["Qty"].ToString());
                                remainqty = Ordqty - rqty;
                                txtRemqty.Text = remainqty.ToString();
                            }
                            else
                            {
                                remainqty = Ordqty - Rcdqty;
                                txtRemqty.Text = remainqty.ToString();
                            }
                            txtExpDate.Text = ((DateTime)dsgr.Tables[0].Rows[0]["ExpiryDate"]).ToString("yyyy-MM-dd");
                            txtPallets.Text = dsgr.Tables[0].Rows[0]["PalletsQty"].ToString();
                            txtPallets.Enabled = false;
                            ddlbatchstatus.SelectedItem.Text = dsgr.Tables[0].Rows[0]["BatchStatus"].ToString();
                            txtPallets_TextChanged(sender, e);
                            #region Dropdown Approver
                            DataSet dsApprovar1 = new DataSet();
                            dsApprovar1 = dbObj.Select_Employeename();
                            if (dsApprovar1.Tables[0].Rows.Count > 0)
                            {
                                ddlSelectapprover.DataSource = dsApprovar1;
                                ddlSelectapprover.DataTextField = "EmployeeName";
                                ddlSelectapprover.DataValueField = "EmployeeID";
                                ddlSelectapprover.DataBind();
                            }
                            #endregion
                            ddlSelectapprover.SelectedValue = dsgr.Tables[0].Rows[0]["ApproverId"].ToString();
                            ddlStatus.SelectedItem.Text = dsgr.Tables[0].Rows[0]["Status"].ToString();
                            btnSubmit.Text = "Update";
                        }
                    }
                    else
                    {
                        returnorder.Visible = false;
                        poorder.Visible = true;
                        if (dsgr.Tables[0].Rows.Count > 0)
                        {
                            int ApproverId = Convert.ToInt32(dsgr.Tables[0].Rows[0]["ApproverId"].ToString());
                            if (ApproverId == Empid)
                            {
                                ddlStatus.Enabled = true;
                            }

                            #region Poid
                            DataSet ds1 = dbObj.select_Po();
                            ddlPOnumber.DataSource = ds1;
                            ddlPOnumber.DataTextField = "POPrintno";
                            ddlPOnumber.DataValueField = "Poid";
                            ddlPOnumber.DataBind();
                            ddlPOnumber.Items.Insert(0, "Select Poid");
                            #endregion
                            txtGRNnumber.Text = dsgr.Tables[0].Rows[0]["GRId"].ToString();
                            ddlPOnumber.Enabled = false;
                            ddlPOnumber.Text = dsgr.Tables[0].Rows[0]["Poid"].ToString();
                            #region productid
                            DataSet dsProdId = new DataSet();
                            dsProdId = dbObj.select_TranspoProductid();
                            ddlProductid.DataSource = dsProdId;
                            ddlProductid.DataTextField = "Productname";
                            ddlProductid.DataValueField = "Productid";
                            ddlProductid.DataBind();
                            ddlProductid.Items.Insert(0, "Select Productid");
                            #endregion
                            ddlProductid.Text = dsgr.Tables[0].Rows[0]["ProductId"].ToString();
                            ddlProductid.Enabled = false;
                            // txtLicenceNo.Text = dsgr.Tables[0].Rows[0]["License"].ToString();
                            //txtLicenseno.Text = dsProdId.Tables[0].Rows[0]["Licenseno"].ToString();
                            txtDosageform.Text = dsgr.Tables[0].Rows[0]["Dosage"].ToString();
                            txtStrength.Text = dsgr.Tables[0].Rows[0]["Strength"].ToString();
                            //txtPacktype.Text = dsgr.Tables[0].Rows[0]["Packtype"].ToString();
                            //txtPacksize.Text = dsgr.Tables[0].Rows[0]["Packsize"].ToString();
                            txtOrderqty.Text = dsgr.Tables[0].Rows[0]["OrderQty"].ToString();
                            txtOrderAmount.Text = dsgr.Tables[0].Rows[0]["OrderAmt"].ToString();
                            txtBatch.Text = dsgr.Tables[0].Rows[0]["Batchnumber"].ToString();
                            int Ordqty = Convert.ToInt32(dsgr.Tables[0].Rows[0]["OrderQty"].ToString());
                            int Rcdqty = Convert.ToInt32(dsgr.Tables[0].Rows[0]["Qty"].ToString());
                            int remainqty = 0;
                            txtRecdQty.Text = dsgr.Tables[0].Rows[0]["Qty"].ToString();
                            DataSet dsremqty = dbObj.Getremcqty(Convert.ToInt32(ddlPOnumber.Text),Convert.ToInt32(ddlProductid.Text));
                            if (dsremqty.Tables[0].Rows.Count > 0)
                            {
                                int rqty =Convert.ToInt32(dsremqty.Tables[0].Rows[0]["Qty"].ToString());
                                remainqty = Ordqty - rqty;
                                txtRemqty.Text = remainqty.ToString();
                            }
                            else
                            {
                                remainqty = Ordqty - Rcdqty;
                                txtRemqty.Text = remainqty.ToString();
                            }
                            
                            
                            txtExpDate.Text = ((DateTime)dsgr.Tables[0].Rows[0]["ExpiryDate"]).ToString("yyyy-MM-dd");
                            ddlbatchstatus.SelectedItem.Text = dsgr.Tables[0].Rows[0]["BatchStatus"].ToString();

                            txtPallets_TextChanged(sender, e);

                            #region Dropdown Approver
                            DataSet dsApprovar1 = new DataSet();
                            dsApprovar1 = dbObj.Select_Employeename();
                            if (dsApprovar1.Tables[0].Rows.Count > 0)
                            {
                                ddlSelectapprover.DataSource = dsApprovar1;
                                ddlSelectapprover.DataTextField = "EmployeeName";
                                ddlSelectapprover.DataValueField = "EmployeeID";
                                ddlSelectapprover.DataBind();
                            }
                            #endregion
                            ddlSelectapprover.SelectedValue = dsgr.Tables[0].Rows[0]["ApproverId"].ToString();
                            ddlStatus.SelectedItem.Text = dsgr.Tables[0].Rows[0]["Status"].ToString();
                            btnSubmit.Text = "Update";
                        }
                    }

                }
                else
                {

                }
                #endregion
                DataSet dsUnits1 = new DataSet();
                dsUnits1 = dbObj.Select_Units1();
                if (dsUnits1.Tables[0].Rows.Count > 0)
                {
                    ddUnits1.DataSource = dsUnits1.Tables[0];
                    ddUnits1.DataBind();
                }

                DataSet dswarehouse = dbObj.Select_Warehouse();
                if (dswarehouse.Tables[0].Rows.Count > 0)
                {
                    ddlwarehouse.DataSource = dswarehouse;
                    ddlwarehouse.DataTextField = "WarehouseName";
                    ddlwarehouse.DataValueField = "WarehouseID";
                    ddlwarehouse.DataBind();
                }

            }

        }
        protected void ddRoomListSecond_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            int count = ddUnits1.Items.Count;
            //foreach (DataListItem dl in ddRoomListALL.Items)
            // for (int i = 0; i < count; i++)
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                Button btn = (Button)e.Item.FindControl("btns1");

                if (btn.CommandName == "0")
                {
                    btn.BackColor = System.Drawing.Color.Gray;
                    btn.ForeColor = System.Drawing.Color.White;
                }
                else if (btn.CommandName == "1")
                {
                    btn.BackColor = System.Drawing.Color.Green;
                    btn.ForeColor = System.Drawing.Color.White;

                    //btn.Enabled = false;
                }

            }
        }
        protected void btnClick(object sender, EventArgs e)
        {
            Button Btn = (sender as Button);
            Session["UnitId"] = Btn.CommandArgument.ToString();
            DataSet dsUnit = dbObj.Select_UnitsCheck(Convert.ToInt32(Session["UnitId"].ToString()));
            if (dsUnit.Tables[0].Rows.Count > 0)
            {
                lblFloor.Text = dsUnit.Tables[0].Rows[0]["Floor"].ToString();
                lblUnit.Text = dsUnit.Tables[0].Rows[0]["Unitname"].ToString();
            }

        }

        protected void ddlPOnumber_SelectedIndexChanged(object sender, EventArgs e)
        {


            DataSet ds1 = dbObj.select_TranspoProduct(Convert.ToInt32(ddlPOnumber.SelectedValue));
            ddlProductid.DataSource = ds1;

            ddlProductid.DataTextField = "Productname";
            ddlProductid.DataValueField = "Productid";
            ddlProductid.DataBind();
            ddlProductid.Items.Insert(0, "Select Product");
            txtDosageform.Text = "";
            txtOrderqty.Text = "";
            txtRemqty.Text = "";
            txtStrength.Text = "";
            txtStrength.Text = "";

        }

        protected void ddlProductid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlReturnnumber.SelectedValue) && Convert.ToInt32(ddlReturnnumber.SelectedValue) != 0)
            {
                DataSet dsProdId = dbObj.select_TransReturnProductvalues(Convert.ToInt32(ddlProductid.SelectedValue), Convert.ToInt32(ddlReturnnumber.SelectedValue));
                ViewState["vsPrdct"] = iPoid;

                if (dsProdId.Tables[0].Rows.Count > 0)
                {
                    txtDosageform.Text = dsProdId.Tables[0].Rows[0]["Dosageform"].ToString();
                    txtStrength.Text = dsProdId.Tables[0].Rows[0]["Strength"].ToString();
                    txtOrderqty.Text = dsProdId.Tables[0].Rows[0]["ReturnQty"].ToString();
                    txtRemqty.Text = dsProdId.Tables[0].Rows[0]["ReturnQty"].ToString();
                    txtRecdQty.Enabled = false;
                    txtRecdQty.Text = dsProdId.Tables[0].Rows[0]["ReturnQty"].ToString();
                    txtOrderAmount.Text = dsProdId.Tables[0].Rows[0]["ReturnAmount"].ToString();
                    string Returnid = dsProdId.Tables[0].Rows[0]["Returnid"].ToString();
                    string prodid = dsProdId.Tables[0].Rows[0]["Productid"].ToString();
                    DataSet dsgr = dbObj.select_Goodsreceiptreturnidcheck(Returnid, prodid);
                    if (dsgr.Tables[0].Rows.Count > 0)
                    {
                        int OrderQty = Convert.ToInt32(dsgr.Tables[0].Rows[0]["OrderQty"].ToString());
                        txtOrderqty.Text = OrderQty.ToString();
                        int ReceivedQty = 0;
                        for (int i = 0; i < dsgr.Tables[0].Rows.Count; i++)
                        {
                            int RecQty = Convert.ToInt32(dsgr.Tables[0].Rows[i]["ReceivedQty"].ToString());
                            ReceivedQty += RecQty;


                        }
                        if (OrderQty != ReceivedQty)
                        {
                            int Remainingqty = OrderQty - ReceivedQty;
                            txtRemqty.Text = Remainingqty.ToString();
                            txtBatch.Text = dsgr.Tables[0].Rows[0]["Batchnumber"].ToString();
                            txtBatch.Enabled = false;
                        }
                        else
                        {
                            string script = "alert('You Are Received all PO Qty,Please Check the status')";
                            ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                            txtRemqty.Text = "0";
                            return;

                        }

                    }
                    else
                    {

                    }
                }
            }
            else
            {
                DataSet dsProdId = new DataSet();
                dsProdId = dbObj.select_TranspoProductvalues(Convert.ToInt32(ddlProductid.SelectedValue), Convert.ToInt32(ddlPOnumber.SelectedValue));
                ViewState["vsPrdct"] = iPoid;

                if (dsProdId.Tables[0].Rows.Count > 0)
                {
                    txtDosageform.Text = dsProdId.Tables[0].Rows[0]["Dosageform"].ToString();
                    txtStrength.Text = dsProdId.Tables[0].Rows[0]["Strength"].ToString();
                    txtOrderqty.Text = dsProdId.Tables[0].Rows[0]["PoQty"].ToString();
                    txtOrderqty.Text = dsProdId.Tables[0].Rows[0]["PoQty"].ToString();
                    txtRemqty.Text = dsProdId.Tables[0].Rows[0]["PoQty"].ToString();
                    txtOrderAmount.Text = dsProdId.Tables[0].Rows[0]["Productamt"].ToString();
                    string poid = dsProdId.Tables[0].Rows[0]["Poid"].ToString();
                    string prodid = dsProdId.Tables[0].Rows[0]["Productid"].ToString();
                    DataSet dsgr = dbObj.select_Goodsreceiptpoidcheck(poid, prodid);
                    if (dsgr.Tables[0].Rows.Count > 0)
                    {
                        int OrderQty = Convert.ToInt32(dsgr.Tables[0].Rows[0]["OrderQty"].ToString());
                        txtOrderqty.Text = OrderQty.ToString();
                        int ReceivedQty = 0;
                        for (int i = 0; i < dsgr.Tables[0].Rows.Count; i++)
                        {
                            int RecQty = Convert.ToInt32(dsgr.Tables[0].Rows[i]["ReceivedQty"].ToString());
                            ReceivedQty += RecQty;


                        }
                        if (OrderQty != ReceivedQty)
                        {
                            int Remainingqty = OrderQty - ReceivedQty;
                            txtRemqty.Text = Remainingqty.ToString();
                            txtBatch.Text = dsgr.Tables[0].Rows[0]["Batchnumber"].ToString();
                            txtBatch.Enabled = false;
                        }
                        else
                        {
                            string script = "alert('You Are Received all PO Qty,Please Check the status')";
                            ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                            txtRemqty.Text = "0";
                            return;

                        }

                    }
                    else
                    {

                    }
                }
            }

        }

        protected void txtPallets_TextChanged(object sender, EventArgs e)
        {
            iGRId = Convert.ToInt32(Request.QueryString.Get("GRId"));
            if (iGRId != 0)
            {
                List.Visible = true;
                DataSet dsUnits1 = dbObj.select_Editunitvalue(iGRId, Convert.ToInt32(ddlProductid.Text));
                string palletsno = dsUnits1.Tables[0].Rows[0]["rows"].ToString();
                txtPallets.Text = palletsno;
                for (int i = 0; i < Convert.ToInt32(txtPallets.Text); i++)
                {
                    if (i == 0)
                    {

                        lbl0.Visible = true;
                        txt0.Visible = true;
                        txtpr0.Visible = true;
                        lbl0.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();
                        txt0.Text = dsUnits1.Tables[0].Rows[i]["Qty"].ToString();
                        txtpr0.Text = dsUnits1.Tables[0].Rows[i]["Palletsrefno"].ToString();
                       // btnAdd0.Visible = true;

                        lbl1.Visible = false;
                        txt1.Visible = false;
                        txtpr1.Visible = false;

                        lbl2.Visible = false;
                        txt2.Visible = false;
                        txtpr2.Visible = false;

                        lbl3.Visible = false;
                        txt3.Visible = false;
                        txtpr3.Visible = false;

                        lbl4.Visible = false;
                        txt4.Visible = false;
                        txtpr4.Visible = false;

                        lbl5.Visible = false;
                        txt5.Visible = false;
                        txtpr5.Visible = false;

                        lbl6.Visible = false;
                        txt6.Visible = false;
                        txtpr6.Visible = false;

                        lbl7.Visible = false;
                        txt7.Visible = false;
                        txtpr7.Visible = false;

                        lbl8.Visible = false;
                        txt8.Visible = false;
                        txtpr8.Visible = false;

                        lbl10.Visible = false;
                        txt10.Visible = false;
                        txtpr10.Visible = false;

                        lbl11.Visible = false;
                        txt11.Visible = false;
                        txtpr11.Visible = false;

                        lbl12.Visible = false;
                        txt12.Visible = false;
                        txtpr12.Visible = false;

                        lbl13.Visible = false;
                        txt13.Visible = false;
                        txtpr13.Visible = false;

                        lbl14.Visible = false;
                        txt14.Visible = false;
                        txtpr14.Visible = false;

                        lbl15.Visible = false;
                        txt15.Visible = false;
                        txtpr15.Visible = false;

                        lbl16.Visible = false;
                        txt16.Visible = false;
                        txtpr16.Visible = false;

                        lbl17.Visible = false;
                        txt17.Visible = false;
                        txtpr17.Visible = false;

                        lbl18.Visible = false;
                        txt18.Visible = false;
                        txtpr18.Visible = false;

                        lbl19.Visible = false;
                        txt19.Visible = false;
                        txtpr19.Visible = false;


                    }
                    else if (i == 1)
                    {

                        lbl1.Visible = true;
                        txt1.Visible = true;
                        txtpr1.Visible = true;
                        lbl1.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();
                        txt1.Text = dsUnits1.Tables[0].Rows[i]["Qty"].ToString();
                        txtpr1.Text = dsUnits1.Tables[0].Rows[i]["Palletsrefno"].ToString();
                      //  btnAdd1.Visible = true;
                        //btnAdd0.Visible = false;
                        

                        lbl2.Visible = false;
                        txt2.Visible = false;
                        txtpr2.Visible = false;

                        lbl3.Visible = false;
                        txt3.Visible = false;
                        txtpr3.Visible = false;

                        lbl4.Visible = false;
                        txt4.Visible = false;
                        txtpr4.Visible = false;

                        lbl5.Visible = false;
                        txt5.Visible = false;
                        txtpr5.Visible = false;

                        lbl6.Visible = false;
                        txt6.Visible = false;
                        txtpr6.Visible = false;

                        lbl7.Visible = false;
                        txt7.Visible = false;
                        txtpr7.Visible = false;

                        lbl8.Visible = false;
                        txt8.Visible = false;
                        txtpr8.Visible = false;

                        lbl9.Visible = false;
                        txt9.Visible = false;
                        txtpr9.Visible = false;

                        lbl10.Visible = false;
                        txt10.Visible = false;
                        txtpr10.Visible = false;

                        lbl11.Visible = false;
                        txt11.Visible = false;
                        txtpr11.Visible = false;

                        lbl12.Visible = false;
                        txt12.Visible = false;
                        txtpr12.Visible = false;

                        lbl13.Visible = false;
                        txt13.Visible = false;
                        txtpr13.Visible = false;

                        lbl14.Visible = false;
                        txt14.Visible = false;
                        txtpr14.Visible = false;

                        lbl15.Visible = false;
                        txt15.Visible = false;
                        txtpr15.Visible = false;

                        lbl16.Visible = false;
                        txt16.Visible = false;
                        txtpr16.Visible = false;

                        lbl17.Visible = false;
                        txt17.Visible = false;
                        txtpr17.Visible = false;

                        lbl18.Visible = false;
                        txt18.Visible = false;
                        txtpr18.Visible = false;

                        lbl19.Visible = false;
                        txt19.Visible = false;
                        txtpr19.Visible = false;
                    }
                    else if (i == 2)
                    {

                        lbl2.Visible = true;
                        txt2.Visible = true;
                        txtpr2.Visible = true;
                        lbl2.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();
                        txt2.Text = dsUnits1.Tables[0].Rows[i]["Qty"].ToString();
                        txtpr2.Text = dsUnits1.Tables[0].Rows[i]["Palletsrefno"].ToString();
                       //btnAdd2.Visible = true; 
                        //btnAdd1.Visible = false;

                        lbl3.Visible = false;
                        txt3.Visible = false;
                        txtpr3.Visible = false;

                        lbl4.Visible = false;
                        txt4.Visible = false;
                        txtpr4.Visible = false;

                        lbl5.Visible = false;
                        txt5.Visible = false;
                        txtpr5.Visible = false;

                        lbl6.Visible = false;
                        txt6.Visible = false;
                        txtpr6.Visible = false;

                        lbl7.Visible = false;
                        txt7.Visible = false;
                        txtpr7.Visible = false;

                        lbl8.Visible = false;
                        txt8.Visible = false;
                        txtpr8.Visible = false;

                        lbl9.Visible = false;
                        txt9.Visible = false;
                        txtpr9.Visible = false;

                        lbl10.Visible = false;
                        txt10.Visible = false;
                        txtpr10.Visible = false;

                        lbl11.Visible = false;
                        txt11.Visible = false;
                        txtpr11.Visible = false;

                        lbl12.Visible = false;
                        txt12.Visible = false;
                        txtpr12.Visible = false;

                        lbl13.Visible = false;
                        txt13.Visible = false;
                        txtpr13.Visible = false;

                        lbl14.Visible = false;
                        txt14.Visible = false;
                        txtpr14.Visible = false;

                        lbl15.Visible = false;
                        txt15.Visible = false;
                        txtpr15.Visible = false;

                        lbl16.Visible = false;
                        txt16.Visible = false;
                        txtpr16.Visible = false;

                        lbl17.Visible = false;
                        txt17.Visible = false;
                        txtpr17.Visible = false;

                        lbl18.Visible = false;
                        txt18.Visible = false;
                        txtpr18.Visible = false;

                        lbl19.Visible = false;
                        txt19.Visible = false;
                        txtpr19.Visible = false;
                    }
                    else if (i == 3)
                    {

                        lbl3.Visible = true;
                        txt3.Visible = true;
                        txtpr3.Visible = true;
                        lbl3.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();
                        txt3.Text = dsUnits1.Tables[0].Rows[i]["Qty"].ToString();
                        txtpr3.Text = dsUnits1.Tables[0].Rows[i]["Palletsrefno"].ToString();
                       // btnAdd33.Visible = true;
                        //btnAdd2.Visible = false;

                        lbl4.Visible = false;
                        txt4.Visible = false;
                        txtpr4.Visible = false;

                        lbl5.Visible = false;
                        txt5.Visible = false;
                        txtpr5.Visible = false;

                        lbl6.Visible = false;
                        txt6.Visible = false;
                        txtpr6.Visible = false;

                        lbl7.Visible = false;
                        txt7.Visible = false;
                        txtpr7.Visible = false;

                        lbl8.Visible = false;
                        txt8.Visible = false;
                        txtpr8.Visible = false;

                        lbl9.Visible = false;
                        txt9.Visible = false;
                        txtpr9.Visible = false;

                        lbl10.Visible = false;
                        txt10.Visible = false;
                        txtpr10.Visible = false;

                        lbl11.Visible = false;
                        txt11.Visible = false;
                        txtpr11.Visible = false;

                        lbl12.Visible = false;
                        txt12.Visible = false;
                        txtpr12.Visible = false;

                        lbl13.Visible = false;
                        txt13.Visible = false;
                        txtpr13.Visible = false;

                        lbl14.Visible = false;
                        txt14.Visible = false;
                        txtpr14.Visible = false;

                        lbl15.Visible = false;
                        txt15.Visible = false;
                        txtpr15.Visible = false;

                        lbl16.Visible = false;
                        txt16.Visible = false;
                        txtpr16.Visible = false;

                        lbl17.Visible = false;
                        txt17.Visible = false;
                        txtpr17.Visible = false;

                        lbl18.Visible = false;
                        txt18.Visible = false;
                        txtpr18.Visible = false;

                        lbl19.Visible = false;
                        txt19.Visible = false;
                        txtpr19.Visible = false;
                    }
                    else if (i == 4)
                    {

                        lbl4.Visible = true;
                        txt4.Visible = true;
                        txtpr4.Visible = true;
                        lbl4.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();
                        txt4.Text = dsUnits1.Tables[0].Rows[i]["Qty"].ToString();
                        txtpr4.Text = dsUnits1.Tables[0].Rows[i]["Palletsrefno"].ToString();
                       // btnAdd4.Visible = true;
                       // btnAdd33.Visible = false;

                        lbl5.Visible = false;
                        txt5.Visible = false;
                        txtpr5.Visible = false;

                        lbl6.Visible = false;
                        txt6.Visible = false;
                        txtpr6.Visible = false;

                        lbl7.Visible = false;
                        txt7.Visible = false;
                        txtpr7.Visible = false;

                        lbl8.Visible = false;
                        txt8.Visible = false;
                        txtpr8.Visible = false;

                        lbl9.Visible = false;
                        txt9.Visible = false;
                        txtpr9.Visible = false;

                        lbl10.Visible = false;
                        txt10.Visible = false;
                        txtpr10.Visible = false;

                        lbl11.Visible = false;
                        txt11.Visible = false;
                        txtpr11.Visible = false;

                        lbl12.Visible = false;
                        txt12.Visible = false;
                        txtpr12.Visible = false;

                        lbl13.Visible = false;
                        txt13.Visible = false;
                        txtpr13.Visible = false;

                        lbl14.Visible = false;
                        txt14.Visible = false;
                        txtpr14.Visible = false;

                        lbl15.Visible = false;
                        txt15.Visible = false;
                        txtpr15.Visible = false;

                        lbl16.Visible = false;
                        txt16.Visible = false;
                        txtpr16.Visible = false;

                        lbl17.Visible = false;
                        txt17.Visible = false;
                        txtpr17.Visible = false;

                        lbl18.Visible = false;
                        txt18.Visible = false;
                        txtpr18.Visible = false;

                        lbl19.Visible = false;
                        txt19.Visible = false;
                        txtpr19.Visible = false;

                    }
                    else if (i == 5)
                    {

                        lbl5.Visible = true;
                        txt5.Visible = true;
                        txtpr5.Visible = true;
                        lbl5.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();
                        txt5.Text = dsUnits1.Tables[0].Rows[i]["Qty"].ToString();
                        txtpr5.Text = dsUnits1.Tables[0].Rows[i]["Palletsrefno"].ToString();
                        //btnAdd5.Visible = true;
                        //btnAdd4.Visible = false;

                        lbl6.Visible = false;
                        txt6.Visible = false;
                        txtpr6.Visible = false;

                        lbl7.Visible = false;
                        txt7.Visible = false;
                        txtpr7.Visible = false;

                        lbl8.Visible = false;
                        txt8.Visible = false;
                        txtpr8.Visible = false;

                        lbl9.Visible = false;
                        txt9.Visible = false;
                        txtpr9.Visible = false;

                        lbl10.Visible = false;
                        txt10.Visible = false;
                        txtpr10.Visible = false;

                        lbl11.Visible = false;
                        txt11.Visible = false;
                        txtpr11.Visible = false;

                        lbl12.Visible = false;
                        txt12.Visible = false;
                        txtpr12.Visible = false;

                        lbl13.Visible = false;
                        txt13.Visible = false;
                        txtpr13.Visible = false;

                        lbl14.Visible = false;
                        txt14.Visible = false;
                        txtpr14.Visible = false;

                        lbl15.Visible = false;
                        txt15.Visible = false;
                        txtpr15.Visible = false;

                        lbl16.Visible = false;
                        txt16.Visible = false;
                        txtpr16.Visible = false;

                        lbl17.Visible = false;
                        txt17.Visible = false;
                        txtpr17.Visible = false;

                        lbl18.Visible = false;
                        txt18.Visible = false;
                        txtpr18.Visible = false;

                        lbl19.Visible = false;
                        txt19.Visible = false;
                        txtpr19.Visible = false;

                    }
                    else if (i == 6)
                    {

                        lbl6.Visible = true;
                        txt6.Visible = true;
                        txtpr6.Visible = true;
                        lbl6.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();
                        txt6.Text = dsUnits1.Tables[0].Rows[i]["Qty"].ToString();
                        txtpr6.Text = dsUnits1.Tables[0].Rows[i]["Palletsrefno"].ToString();
                        //btnAdd6.Visible = true;
                        //btnAdd5.Visible = false;

                        lbl7.Visible = false;
                        txt7.Visible = false;
                        txtpr7.Visible = false;

                        lbl8.Visible = false;
                        txt8.Visible = false;
                        txtpr8.Visible = false;

                        lbl9.Visible = false;
                        txt9.Visible = false;
                        txtpr9.Visible = false;

                        lbl10.Visible = false;
                        txt10.Visible = false;
                        txtpr10.Visible = false;

                        lbl11.Visible = false;
                        txt11.Visible = false;
                        txtpr11.Visible = false;

                        lbl12.Visible = false;
                        txt12.Visible = false;
                        txtpr12.Visible = false;

                        lbl13.Visible = false;
                        txt13.Visible = false;
                        txtpr13.Visible = false;

                        lbl14.Visible = false;
                        txt14.Visible = false;
                        txtpr14.Visible = false;

                        lbl15.Visible = false;
                        txt15.Visible = false;
                        txtpr15.Visible = false;

                        lbl16.Visible = false;
                        txt16.Visible = false;
                        txtpr16.Visible = false;

                        lbl17.Visible = false;
                        txt17.Visible = false;
                        txtpr17.Visible = false;

                        lbl18.Visible = false;
                        txt18.Visible = false;
                        txtpr18.Visible = false;

                        lbl19.Visible = false;
                        txt19.Visible = false;
                        txtpr19.Visible = false;
                    }
                    else if (i == 7)
                    {

                        lbl7.Visible = true;
                        txt7.Visible = true;
                        txtpr7.Visible = true;
                        lbl7.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();
                        txt7.Text = dsUnits1.Tables[0].Rows[i]["Qty"].ToString();
                        txtpr7.Text = dsUnits1.Tables[0].Rows[i]["Palletsrefno"].ToString();
                        //btnAdd7.Visible = true;
                        //btnAdd6.Visible = false;

                        lbl8.Visible = false;
                        txt8.Visible = false;
                        txtpr8.Visible = false;

                        lbl9.Visible = false;
                        txt9.Visible = false;
                        txtpr9.Visible = false;

                        lbl10.Visible = false;
                        txt10.Visible = false;
                        txtpr10.Visible = false;

                        lbl11.Visible = false;
                        txt11.Visible = false;
                        txtpr11.Visible = false;

                        lbl12.Visible = false;
                        txt12.Visible = false;
                        txtpr12.Visible = false;

                        lbl13.Visible = false;
                        txt13.Visible = false;
                        txtpr13.Visible = false;

                        lbl14.Visible = false;
                        txt14.Visible = false;
                        txtpr14.Visible = false;

                        lbl15.Visible = false;
                        txt15.Visible = false;
                        txtpr15.Visible = false;

                        lbl16.Visible = false;
                        txt16.Visible = false;
                        txtpr16.Visible = false;

                        lbl17.Visible = false;
                        txt17.Visible = false;
                        txtpr17.Visible = false;

                        lbl18.Visible = false;
                        txt18.Visible = false;
                        txtpr18.Visible = false;

                        lbl19.Visible = false;
                        txt19.Visible = false;
                        txtpr19.Visible = false;

                    }
                    else if (i == 8)
                    {

                        lbl8.Visible = true;
                        txt8.Visible = true;
                        txtpr8.Visible = true;
                        lbl8.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();
                        txt8.Text = dsUnits1.Tables[0].Rows[i]["Qty"].ToString();
                        txtpr8.Text = dsUnits1.Tables[0].Rows[i]["Palletsrefno"].ToString();
                       // btnAdd8.Visible = true;
                       // btnAdd7.Visible = false;

                        lbl9.Visible = false;
                        txt9.Visible = false;
                        txtpr9.Visible = false;

                        lbl10.Visible = false;
                        txt10.Visible = false;
                        txtpr10.Visible = false;

                        lbl11.Visible = false;
                        txt11.Visible = false;
                        txtpr11.Visible = false;

                        lbl12.Visible = false;
                        txt12.Visible = false;
                        txtpr12.Visible = false;

                        lbl13.Visible = false;
                        txt13.Visible = false;
                        txtpr13.Visible = false;

                        lbl14.Visible = false;
                        txt14.Visible = false;
                        txtpr14.Visible = false;

                        lbl15.Visible = false;
                        txt15.Visible = false;
                        txtpr15.Visible = false;

                        lbl16.Visible = false;
                        txt16.Visible = false;
                        txtpr16.Visible = false;

                        lbl17.Visible = false;
                        txt17.Visible = false;
                        txtpr17.Visible = false;

                        lbl18.Visible = false;
                        txt18.Visible = false;
                        txtpr18.Visible = false;

                        lbl19.Visible = false;
                        txt19.Visible = false;
                        txtpr19.Visible = false;
                    }
                    else if (i == 9)
                    {

                        lbl9.Visible = true;
                        txt9.Visible = true;
                        txtpr9.Visible = true;
                        lbl9.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();
                        txt9.Text = dsUnits1.Tables[0].Rows[i]["Qty"].ToString();
                        txtpr9.Text = dsUnits1.Tables[0].Rows[i]["Palletsrefno"].ToString();
                       // btnAdd9.Visible = true;
                       // btnAdd8.Visible = false;


                        lbl10.Visible = false;
                        txt10.Visible = false;
                        txtpr10.Visible = false;

                        lbl11.Visible = false;
                        txt11.Visible = false;
                        txtpr11.Visible = false;

                        lbl12.Visible = false;
                        txt12.Visible = false;
                        txtpr12.Visible = false;

                        lbl13.Visible = false;
                        txt13.Visible = false;
                        txtpr13.Visible = false;

                        lbl14.Visible = false;
                        txt14.Visible = false;
                        txtpr14.Visible = false;

                        lbl15.Visible = false;
                        txt15.Visible = false;
                        txtpr15.Visible = false;

                        lbl16.Visible = false;
                        txt16.Visible = false;
                        txtpr16.Visible = false;

                        lbl17.Visible = false;
                        txt17.Visible = false;
                        txtpr17.Visible = false;

                        lbl18.Visible = false;
                        txt18.Visible = false;
                        txtpr18.Visible = false;

                        lbl19.Visible = false;
                        txt19.Visible = false;
                        txtpr19.Visible = false;
                    }
                    else if (i == 10)
                    {
                        lbl10.Visible = true;
                        txt10.Visible = true;
                        txtpr10.Visible = true;
                        lbl10.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();
                        txt10.Text = dsUnits1.Tables[0].Rows[i]["Qty"].ToString();
                        txtpr10.Text = dsUnits1.Tables[0].Rows[i]["Palletsrefno"].ToString();
                      //  btnAdd10.Visible = true;
                       // btnAdd9.Visible = false;


                        lbl11.Visible = false;
                        txt11.Visible = false;
                        txtpr11.Visible = false;

                        lbl12.Visible = false;
                        txt12.Visible = false;
                        txtpr12.Visible = false;

                        lbl13.Visible = false;
                        txt13.Visible = false;
                        txtpr13.Visible = false;

                        lbl14.Visible = false;
                        txt14.Visible = false;
                        txtpr14.Visible = false;

                        lbl15.Visible = false;
                        txt15.Visible = false;
                        txtpr15.Visible = false;

                        lbl16.Visible = false;
                        txt16.Visible = false;
                        txtpr16.Visible = false;

                        lbl17.Visible = false;
                        txt17.Visible = false;
                        txtpr17.Visible = false;

                        lbl18.Visible = false;
                        txt18.Visible = false;
                        txtpr18.Visible = false;

                        lbl19.Visible = false;
                        txt19.Visible = false;
                        txtpr19.Visible = false;
                    }
                    else if (i == 11)
                    {

                        lbl11.Visible = true;
                        txt11.Visible = true;
                        txtpr11.Visible = true;
                        lbl11.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();
                        txt11.Text = dsUnits1.Tables[0].Rows[i]["Qty"].ToString();
                        txtpr11.Text = dsUnits1.Tables[0].Rows[i]["Palletsrefno"].ToString();
                      // btnAdd11.Visible = true;
                       // btnAdd10.Visible = false;


                        lbl12.Visible = false;
                        txt12.Visible = false;
                        txtpr12.Visible = false;

                        lbl13.Visible = false;
                        txt13.Visible = false;
                        txtpr13.Visible = false;

                        lbl14.Visible = false;
                        txt14.Visible = false;
                        txtpr14.Visible = false;

                        lbl15.Visible = false;
                        txt15.Visible = false;
                        txtpr15.Visible = false;

                        lbl16.Visible = false;
                        txt16.Visible = false;
                        txtpr16.Visible = false;

                        lbl17.Visible = false;
                        txt17.Visible = false;
                        txtpr17.Visible = false;

                        lbl18.Visible = false;
                        txt18.Visible = false;
                        txtpr18.Visible = false;

                        lbl19.Visible = false;
                        txt19.Visible = false;
                        txtpr19.Visible = false;
                    }
                    else if (i == 12)
                    {

                        lbl12.Visible = true;
                        txt12.Visible = true;
                        txtpr12.Visible = true;
                        lbl12.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();
                        txt12.Text = dsUnits1.Tables[0].Rows[i]["Qty"].ToString();
                        txtpr12.Text = dsUnits1.Tables[0].Rows[i]["Palletsrefno"].ToString();
                        //btnAdd12.Visible = true;
                        //btnAdd11.Visible = false;

                        lbl13.Visible = false;
                        txt13.Visible = false;
                        txtpr13.Visible = false;

                        lbl14.Visible = false;
                        txt14.Visible = false;
                        txtpr14.Visible = false;

                        lbl15.Visible = false;
                        txt15.Visible = false;
                        txtpr15.Visible = false;

                        lbl16.Visible = false;
                        txt16.Visible = false;
                        txtpr16.Visible = false;

                        lbl17.Visible = false;
                        txt17.Visible = false;
                        txtpr17.Visible = false;

                        lbl18.Visible = false;
                        txt18.Visible = false;
                        txtpr18.Visible = false;

                        lbl19.Visible = false;
                        txt19.Visible = false;
                        txtpr19.Visible = false;
                    }
                    else if (i == 13)
                    {

                        lbl13.Visible = true;
                        txt13.Visible = true;
                        txtpr13.Visible = true;
                        lbl13.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();
                        txt13.Text = dsUnits1.Tables[0].Rows[i]["Qty"].ToString();
                        txtpr13.Text = dsUnits1.Tables[0].Rows[i]["Palletsrefno"].ToString();
                       /// btnAdd13.Visible = true;
                       // btnAdd12.Visible = false;

                        lbl14.Visible = false;
                        txt14.Visible = false;
                        txtpr14.Visible = false;

                        lbl15.Visible = false;
                        txt15.Visible = false;
                        txtpr15.Visible = false;

                        lbl16.Visible = false;
                        txt16.Visible = false;
                        txtpr16.Visible = false;

                        lbl17.Visible = false;
                        txt17.Visible = false;
                        txtpr17.Visible = false;

                        lbl18.Visible = false;
                        txt18.Visible = false;
                        txtpr18.Visible = false;

                        lbl19.Visible = false;
                        txt19.Visible = false;
                        txtpr19.Visible = false;
                    }
                    else if (i == 14)
                    {

                        lbl14.Visible = true;
                        txt14.Visible = true;
                        txtpr14.Visible = true;
                        lbl14.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();
                        txt14.Text = dsUnits1.Tables[0].Rows[i]["Qty"].ToString();
                        txtpr14.Text = dsUnits1.Tables[0].Rows[i]["Palletsrefno"].ToString();
                       // btnAdd14.Visible = true;
                       // btnAdd13.Visible = false;

                        lbl15.Visible = false;
                        txt15.Visible = false;
                        txtpr15.Visible = false;

                        lbl16.Visible = false;
                        txt16.Visible = false;
                        txtpr16.Visible = false;

                        lbl17.Visible = false;
                        txt17.Visible = false;
                        txtpr17.Visible = false;

                        lbl18.Visible = false;
                        txt18.Visible = false;
                        txtpr18.Visible = false;

                        lbl19.Visible = false;
                        txt19.Visible = false;
                        txtpr19.Visible = false;
                    }
                    else if (i == 15)
                    {

                        lbl15.Visible = true;
                        txt15.Visible = true;
                        txtpr15.Visible = true;
                        lbl15.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();
                        txt15.Text = dsUnits1.Tables[0].Rows[i]["Qty"].ToString();
                        txtpr15.Text = dsUnits1.Tables[0].Rows[i]["Palletsrefno"].ToString();
                       // btnAdd15.Visible = true;
                       // btnAdd14.Visible = false;

                        lbl16.Visible = false;
                        txt16.Visible = false;
                        txtpr16.Visible = false;

                        lbl17.Visible = false;
                        txt17.Visible = false;
                        txtpr17.Visible = false;

                        lbl18.Visible = false;
                        txt18.Visible = false;
                        txtpr18.Visible = false;

                        lbl19.Visible = false;
                        txt19.Visible = false;
                        txtpr19.Visible = false;
                    }
                    else if (i == 16)
                    {

                        lbl16.Visible = true;
                        txt16.Visible = true;
                        txtpr16.Visible = true;
                        lbl16.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();
                        txt16.Text = dsUnits1.Tables[0].Rows[i]["Qty"].ToString();
                        txtpr16.Text = dsUnits1.Tables[0].Rows[i]["Palletsrefno"].ToString();
                       // btnAdd16.Visible = true;
                       // btnAdd15.Visible = false;


                        lbl17.Visible = false;
                        txt17.Visible = false;
                        txtpr17.Visible = false;

                        lbl18.Visible = false;
                        txt18.Visible = false;
                        txtpr18.Visible = false;

                        lbl19.Visible = false;
                        txt19.Visible = false;
                        txtpr19.Visible = false;
                    }
                    else if (i == 17)
                    {

                        lbl17.Visible = true;
                        txt17.Visible = true;
                        txtpr17.Visible = true;
                        lbl17.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();
                        txt17.Text = dsUnits1.Tables[0].Rows[i]["Qty"].ToString();
                        txtpr17.Text = dsUnits1.Tables[0].Rows[i]["Palletsrefno"].ToString();
                       // btnAdd17.Visible = true;
                       // btnAdd16.Visible = false;

                        lbl18.Visible = false;
                        txt18.Visible = false;
                        txtpr18.Visible = false;

                        lbl19.Visible = false;
                        txt19.Visible = false;
                        txtpr19.Visible = false;
                    }
                    else if (i == 18)
                    {

                        lbl18.Visible = true;
                        txt18.Visible = true;
                        txtpr18.Visible = true;
                        lbl18.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();
                        txt18.Text = dsUnits1.Tables[0].Rows[i]["Qty"].ToString();
                        txtpr18.Text = dsUnits1.Tables[0].Rows[i]["Palletsrefno"].ToString();
                       // btnAdd18.Visible = true;
                        //btnAdd17.Visible = false;

                        lbl19.Visible = false;
                        txt19.Visible = false;
                        txtpr19.Visible = false;
                    }
                    else
                    {

                        lbl19.Visible = true;
                        txt19.Visible = true;
                        txtpr19.Visible = true;
                        lbl19.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();
                        txt19.Text = dsUnits1.Tables[0].Rows[i]["Qty"].ToString();
                        txtpr19.Text = dsUnits1.Tables[0].Rows[i]["Palletsrefno"].ToString();
                        //btnAdd18.Visible = false;
                    }

                }
            }
            else
            {
                if (ddlProductid.SelectedValue != "Select Product" && ddlProductid.SelectedValue != "")
                {
                    if (int.Parse(txtPallets.Text) <= 20)
                    {
                        List.Visible = true;
                        DataSet dsUnits1 = new DataSet();
                        dsUnits1 = dbObj.Select_Units_Green_Number(Convert.ToInt32(txtPallets.Text));
                        if (dsUnits1.Tables[0].Rows.Count > 0)
                        {

                            for (int i = 0; i < Convert.ToInt32(txtPallets.Text); i++)
                            {
                                if (i == 0)
                                {

                                    lbl0.Visible = true;
                                    txt0.Visible = true;
                                    txtpr0.Visible = true;
                                    //txtpr0.Text = txtpalletsrefno.Text;
                                    lbl0.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();

                                    lbl1.Visible = false;
                                    txt1.Visible = false;
                                    txtpr1.Visible = false;

                                    lbl2.Visible = false;
                                    txt2.Visible = false;
                                    txtpr2.Visible = false;

                                    lbl3.Visible = false;
                                    txt3.Visible = false;
                                    txtpr3.Visible = false;

                                    lbl4.Visible = false;
                                    txt4.Visible = false;
                                    txtpr4.Visible = false;

                                    lbl5.Visible = false;
                                    txt5.Visible = false;
                                    txtpr5.Visible = false;

                                    lbl6.Visible = false;
                                    txt6.Visible = false;
                                    txtpr6.Visible = false;

                                    lbl7.Visible = false;
                                    txt7.Visible = false;
                                    txtpr7.Visible = false;

                                    lbl8.Visible = false;
                                    txt8.Visible = false;
                                    txtpr8.Visible = false;

                                    lbl10.Visible = false;
                                    txt10.Visible = false;
                                    txtpr10.Visible = false;

                                    lbl11.Visible = false;
                                    txt11.Visible = false;
                                    txtpr11.Visible = false;

                                    lbl12.Visible = false;
                                    txt12.Visible = false;
                                    txtpr12.Visible = false;

                                    lbl13.Visible = false;
                                    txt13.Visible = false;
                                    txtpr13.Visible = false;

                                    lbl14.Visible = false;
                                    txt14.Visible = false;
                                    txtpr14.Visible = false;

                                    lbl15.Visible = false;
                                    txt15.Visible = false;
                                    txtpr15.Visible = false;

                                    lbl16.Visible = false;
                                    txt16.Visible = false;
                                    txtpr16.Visible = false;

                                    lbl17.Visible = false;
                                    txt17.Visible = false;
                                    txtpr17.Visible = false;

                                    lbl18.Visible = false;
                                    txt18.Visible = false;
                                    txtpr18.Visible = false;

                                    lbl19.Visible = false;
                                    txt19.Visible = false;
                                    txtpr19.Visible = false;


                                }
                                else if (i == 1)
                                {

                                    lbl1.Visible = true;
                                    txt1.Visible = true;
                                    txtpr1.Visible = true;
                                    //txtpr1.Text = txtpalletsrefno.Text;
                                    lbl1.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();

                                    lbl2.Visible = false;
                                    txt2.Visible = false;
                                    txtpr2.Visible = false;

                                    lbl3.Visible = false;
                                    txt3.Visible = false;
                                    txtpr3.Visible = false;

                                    lbl4.Visible = false;
                                    txt4.Visible = false;
                                    txtpr4.Visible = false;

                                    lbl5.Visible = false;
                                    txt5.Visible = false;
                                    txtpr5.Visible = false;

                                    lbl6.Visible = false;
                                    txt6.Visible = false;
                                    txtpr6.Visible = false;

                                    lbl7.Visible = false;
                                    txt7.Visible = false;
                                    txtpr7.Visible = false;

                                    lbl8.Visible = false;
                                    txt8.Visible = false;
                                    txtpr8.Visible = false;

                                    lbl9.Visible = false;
                                    txt9.Visible = false;
                                    txtpr9.Visible = false;

                                    lbl10.Visible = false;
                                    txt10.Visible = false;
                                    txtpr10.Visible = false;

                                    lbl11.Visible = false;
                                    txt11.Visible = false;
                                    txtpr11.Visible = false;

                                    lbl12.Visible = false;
                                    txt12.Visible = false;
                                    txtpr12.Visible = false;

                                    lbl13.Visible = false;
                                    txt13.Visible = false;
                                    txtpr13.Visible = false;

                                    lbl14.Visible = false;
                                    txt14.Visible = false;
                                    txtpr14.Visible = false;

                                    lbl15.Visible = false;
                                    txt15.Visible = false;
                                    txtpr15.Visible = false;

                                    lbl16.Visible = false;
                                    txt16.Visible = false;
                                    txtpr16.Visible = false;

                                    lbl17.Visible = false;
                                    txt17.Visible = false;
                                    txtpr17.Visible = false;

                                    lbl18.Visible = false;
                                    txt18.Visible = false;
                                    txtpr18.Visible = false;

                                    lbl19.Visible = false;
                                    txt19.Visible = false;
                                    txtpr19.Visible = false;
                                }
                                else if (i == 2)
                                {

                                    lbl2.Visible = true;
                                    txt2.Visible = true;
                                    txtpr2.Visible = true;
                                    //txtpr2.Text = txtpalletsrefno.Text;
                                    lbl2.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();

                                    lbl3.Visible = false;
                                    txt3.Visible = false;
                                    txtpr3.Visible = false;

                                    lbl4.Visible = false;
                                    txt4.Visible = false;
                                    txtpr4.Visible = false;

                                    lbl5.Visible = false;
                                    txt5.Visible = false;
                                    txtpr5.Visible = false;

                                    lbl6.Visible = false;
                                    txt6.Visible = false;
                                    txtpr6.Visible = false;

                                    lbl7.Visible = false;
                                    txt7.Visible = false;
                                    txtpr7.Visible = false;

                                    lbl8.Visible = false;
                                    txt8.Visible = false;
                                    txtpr8.Visible = false;

                                    lbl9.Visible = false;
                                    txt9.Visible = false;
                                    txtpr9.Visible = false;

                                    lbl10.Visible = false;
                                    txt10.Visible = false;
                                    txtpr10.Visible = false;

                                    lbl11.Visible = false;
                                    txt11.Visible = false;
                                    txtpr11.Visible = false;

                                    lbl12.Visible = false;
                                    txt12.Visible = false;
                                    txtpr12.Visible = false;

                                    lbl13.Visible = false;
                                    txt13.Visible = false;
                                    txtpr13.Visible = false;

                                    lbl14.Visible = false;
                                    txt14.Visible = false;
                                    txtpr14.Visible = false;

                                    lbl15.Visible = false;
                                    txt15.Visible = false;
                                    txtpr15.Visible = false;

                                    lbl16.Visible = false;
                                    txt16.Visible = false;
                                    txtpr16.Visible = false;

                                    lbl17.Visible = false;
                                    txt17.Visible = false;
                                    txtpr17.Visible = false;

                                    lbl18.Visible = false;
                                    txt18.Visible = false;
                                    txtpr18.Visible = false;

                                    lbl19.Visible = false;
                                    txt19.Visible = false;
                                    txtpr19.Visible = false;
                                }
                                else if (i == 3)
                                {

                                    lbl3.Visible = true;
                                    txt3.Visible = true;
                                    txtpr3.Visible = true;
                                    //.Text = txtpalletsrefno.Text;
                                    lbl3.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();

                                    lbl4.Visible = false;
                                    txt4.Visible = false;
                                    txtpr4.Visible = false;

                                    lbl5.Visible = false;
                                    txt5.Visible = false;
                                    txtpr5.Visible = false;

                                    lbl6.Visible = false;
                                    txt6.Visible = false;
                                    txtpr6.Visible = false;

                                    lbl7.Visible = false;
                                    txt7.Visible = false;
                                    txtpr7.Visible = false;

                                    lbl8.Visible = false;
                                    txt8.Visible = false;
                                    txtpr8.Visible = false;

                                    lbl9.Visible = false;
                                    txt9.Visible = false;
                                    txtpr9.Visible = false;

                                    lbl10.Visible = false;
                                    txt10.Visible = false;
                                    txtpr10.Visible = false;

                                    lbl11.Visible = false;
                                    txt11.Visible = false;
                                    txtpr11.Visible = false;

                                    lbl12.Visible = false;
                                    txt12.Visible = false;
                                    txtpr12.Visible = false;

                                    lbl13.Visible = false;
                                    txt13.Visible = false;
                                    txtpr13.Visible = false;

                                    lbl14.Visible = false;
                                    txt14.Visible = false;
                                    txtpr14.Visible = false;

                                    lbl15.Visible = false;
                                    txt15.Visible = false;
                                    txtpr15.Visible = false;

                                    lbl16.Visible = false;
                                    txt16.Visible = false;
                                    txtpr16.Visible = false;

                                    lbl17.Visible = false;
                                    txt17.Visible = false;
                                    txtpr17.Visible = false;

                                    lbl18.Visible = false;
                                    txt18.Visible = false;
                                    txtpr18.Visible = false;

                                    lbl19.Visible = false;
                                    txt19.Visible = false;
                                    txtpr19.Visible = false;
                                }
                                else if (i == 4)
                                {

                                    lbl4.Visible = true;
                                    txt4.Visible = true;
                                    txtpr4.Visible = true;
                                    // txtpr4.Text = txtpalletsrefno.Text;
                                    lbl4.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();

                                    lbl5.Visible = false;
                                    txt5.Visible = false;
                                    txtpr5.Visible = false;

                                    lbl6.Visible = false;
                                    txt6.Visible = false;
                                    txtpr6.Visible = false;

                                    lbl7.Visible = false;
                                    txt7.Visible = false;
                                    txtpr7.Visible = false;

                                    lbl8.Visible = false;
                                    txt8.Visible = false;
                                    txtpr8.Visible = false;

                                    lbl9.Visible = false;
                                    txt9.Visible = false;
                                    txtpr9.Visible = false;

                                    lbl10.Visible = false;
                                    txt10.Visible = false;
                                    txtpr10.Visible = false;

                                    lbl11.Visible = false;
                                    txt11.Visible = false;
                                    txtpr11.Visible = false;

                                    lbl12.Visible = false;
                                    txt12.Visible = false;
                                    txtpr12.Visible = false;

                                    lbl13.Visible = false;
                                    txt13.Visible = false;
                                    txtpr13.Visible = false;

                                    lbl14.Visible = false;
                                    txt14.Visible = false;
                                    txtpr14.Visible = false;

                                    lbl15.Visible = false;
                                    txt15.Visible = false;
                                    txtpr15.Visible = false;

                                    lbl16.Visible = false;
                                    txt16.Visible = false;
                                    txtpr16.Visible = false;

                                    lbl17.Visible = false;
                                    txt17.Visible = false;
                                    txtpr17.Visible = false;

                                    lbl18.Visible = false;
                                    txt18.Visible = false;
                                    txtpr18.Visible = false;

                                    lbl19.Visible = false;
                                    txt19.Visible = false;
                                    txtpr19.Visible = false;

                                }
                                else if (i == 5)
                                {

                                    lbl5.Visible = true;
                                    txt5.Visible = true;
                                    txtpr5.Visible = true;
                                    //txtpr5.Text = txtpalletsrefno.Text;
                                    lbl5.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();

                                    lbl6.Visible = false;
                                    txt6.Visible = false;
                                    txtpr6.Visible = false;

                                    lbl7.Visible = false;
                                    txt7.Visible = false;
                                    txtpr7.Visible = false;

                                    lbl8.Visible = false;
                                    txt8.Visible = false;
                                    txtpr8.Visible = false;

                                    lbl9.Visible = false;
                                    txt9.Visible = false;
                                    txtpr9.Visible = false;

                                    lbl10.Visible = false;
                                    txt10.Visible = false;
                                    txtpr10.Visible = false;

                                    lbl11.Visible = false;
                                    txt11.Visible = false;
                                    txtpr11.Visible = false;

                                    lbl12.Visible = false;
                                    txt12.Visible = false;
                                    txtpr12.Visible = false;

                                    lbl13.Visible = false;
                                    txt13.Visible = false;
                                    txtpr13.Visible = false;

                                    lbl14.Visible = false;
                                    txt14.Visible = false;
                                    txtpr14.Visible = false;

                                    lbl15.Visible = false;
                                    txt15.Visible = false;
                                    txtpr15.Visible = false;

                                    lbl16.Visible = false;
                                    txt16.Visible = false;
                                    txtpr16.Visible = false;

                                    lbl17.Visible = false;
                                    txt17.Visible = false;
                                    txtpr17.Visible = false;

                                    lbl18.Visible = false;
                                    txt18.Visible = false;
                                    txtpr18.Visible = false;

                                    lbl19.Visible = false;
                                    txt19.Visible = false;
                                    txtpr19.Visible = false;

                                }
                                else if (i == 6)
                                {

                                    lbl6.Visible = true;
                                    txt6.Visible = true;
                                    txtpr6.Visible = true;
                                    //txtpr6.Text = txtpalletsrefno.Text;
                                    lbl6.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();

                                    lbl7.Visible = false;
                                    txt7.Visible = false;
                                    txtpr7.Visible = false;

                                    lbl8.Visible = false;
                                    txt8.Visible = false;
                                    txtpr8.Visible = false;

                                    lbl9.Visible = false;
                                    txt9.Visible = false;
                                    txtpr9.Visible = false;

                                    lbl10.Visible = false;
                                    txt10.Visible = false;
                                    txtpr10.Visible = false;

                                    lbl11.Visible = false;
                                    txt11.Visible = false;
                                    txtpr11.Visible = false;

                                    lbl12.Visible = false;
                                    txt12.Visible = false;
                                    txtpr12.Visible = false;

                                    lbl13.Visible = false;
                                    txt13.Visible = false;
                                    txtpr13.Visible = false;

                                    lbl14.Visible = false;
                                    txt14.Visible = false;
                                    txtpr14.Visible = false;

                                    lbl15.Visible = false;
                                    txt15.Visible = false;
                                    txtpr15.Visible = false;

                                    lbl16.Visible = false;
                                    txt16.Visible = false;
                                    txtpr16.Visible = false;

                                    lbl17.Visible = false;
                                    txt17.Visible = false;
                                    txtpr17.Visible = false;

                                    lbl18.Visible = false;
                                    txt18.Visible = false;
                                    txtpr18.Visible = false;

                                    lbl19.Visible = false;
                                    txt19.Visible = false;
                                    txtpr19.Visible = false;
                                }
                                else if (i == 7)
                                {

                                    lbl7.Visible = true;
                                    txt7.Visible = true;
                                    txtpr7.Visible = true;
                                    //txtpr7.Text = txtpalletsrefno.Text;
                                    lbl7.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();

                                    lbl8.Visible = false;
                                    txt8.Visible = false;
                                    txtpr8.Visible = false;

                                    lbl9.Visible = false;
                                    txt9.Visible = false;
                                    txtpr9.Visible = false;

                                    lbl10.Visible = false;
                                    txt10.Visible = false;
                                    txtpr10.Visible = false;

                                    lbl11.Visible = false;
                                    txt11.Visible = false;
                                    txtpr11.Visible = false;

                                    lbl12.Visible = false;
                                    txt12.Visible = false;
                                    txtpr12.Visible = false;

                                    lbl13.Visible = false;
                                    txt13.Visible = false;
                                    txtpr13.Visible = false;

                                    lbl14.Visible = false;
                                    txt14.Visible = false;
                                    txtpr14.Visible = false;

                                    lbl15.Visible = false;
                                    txt15.Visible = false;
                                    txtpr15.Visible = false;

                                    lbl16.Visible = false;
                                    txt16.Visible = false;
                                    txtpr16.Visible = false;

                                    lbl17.Visible = false;
                                    txt17.Visible = false;
                                    txtpr17.Visible = false;

                                    lbl18.Visible = false;
                                    txt18.Visible = false;
                                    txtpr18.Visible = false;

                                    lbl19.Visible = false;
                                    txt19.Visible = false;
                                    txtpr19.Visible = false;

                                }
                                else if (i == 8)
                                {

                                    lbl8.Visible = true;
                                    txt8.Visible = true;
                                    txtpr8.Visible = true;
                                    //txtpr8.Text = txtpalletsrefno.Text;
                                    lbl8.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();

                                    lbl9.Visible = false;
                                    txt9.Visible = false;
                                    txtpr9.Visible = false;

                                    lbl10.Visible = false;
                                    txt10.Visible = false;
                                    txtpr10.Visible = false;

                                    lbl11.Visible = false;
                                    txt11.Visible = false;
                                    txtpr11.Visible = false;

                                    lbl12.Visible = false;
                                    txt12.Visible = false;
                                    txtpr12.Visible = false;

                                    lbl13.Visible = false;
                                    txt13.Visible = false;
                                    txtpr13.Visible = false;

                                    lbl14.Visible = false;
                                    txt14.Visible = false;
                                    txtpr14.Visible = false;

                                    lbl15.Visible = false;
                                    txt15.Visible = false;
                                    txtpr15.Visible = false;

                                    lbl16.Visible = false;
                                    txt16.Visible = false;
                                    txtpr16.Visible = false;

                                    lbl17.Visible = false;
                                    txt17.Visible = false;
                                    txtpr17.Visible = false;

                                    lbl18.Visible = false;
                                    txt18.Visible = false;
                                    txtpr18.Visible = false;

                                    lbl19.Visible = false;
                                    txt19.Visible = false;
                                    txtpr19.Visible = false;
                                }
                                else if (i == 9)
                                {

                                    lbl9.Visible = true;
                                    txt9.Visible = true;
                                    txtpr9.Visible = true;
                                    lbl9.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();


                                    lbl10.Visible = false;
                                    txt10.Visible = false;
                                    txtpr10.Visible = false;

                                    lbl11.Visible = false;
                                    txt11.Visible = false;
                                    txtpr11.Visible = false;

                                    lbl12.Visible = false;
                                    txt12.Visible = false;
                                    txtpr12.Visible = false;

                                    lbl13.Visible = false;
                                    txt13.Visible = false;
                                    txtpr13.Visible = false;

                                    lbl14.Visible = false;
                                    txt14.Visible = false;
                                    txtpr14.Visible = false;

                                    lbl15.Visible = false;
                                    txt15.Visible = false;
                                    txtpr15.Visible = false;

                                    lbl16.Visible = false;
                                    txt16.Visible = false;
                                    txtpr16.Visible = false;

                                    lbl17.Visible = false;
                                    txt17.Visible = false;
                                    txtpr17.Visible = false;

                                    lbl18.Visible = false;
                                    txt18.Visible = false;
                                    txtpr18.Visible = false;

                                    lbl19.Visible = false;
                                    txt19.Visible = false;
                                    txtpr19.Visible = false;
                                }
                                else if (i == 10)
                                {
                                    lbl10.Visible = true;
                                    txt10.Visible = true;
                                    txtpr10.Visible = true;
                                    lbl10.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();


                                    lbl11.Visible = false;
                                    txt11.Visible = false;
                                    txtpr11.Visible = false;

                                    lbl12.Visible = false;
                                    txt12.Visible = false;
                                    txtpr12.Visible = false;

                                    lbl13.Visible = false;
                                    txt13.Visible = false;
                                    txtpr13.Visible = false;

                                    lbl14.Visible = false;
                                    txt14.Visible = false;
                                    txtpr14.Visible = false;

                                    lbl15.Visible = false;
                                    txt15.Visible = false;
                                    txtpr15.Visible = false;

                                    lbl16.Visible = false;
                                    txt16.Visible = false;
                                    txtpr16.Visible = false;

                                    lbl17.Visible = false;
                                    txt17.Visible = false;
                                    txtpr17.Visible = false;

                                    lbl18.Visible = false;
                                    txt18.Visible = false;
                                    txtpr18.Visible = false;

                                    lbl19.Visible = false;
                                    txt19.Visible = false;
                                    txtpr19.Visible = false;
                                }
                                else if (i == 11)
                                {

                                    lbl11.Visible = true;
                                    txt11.Visible = true;
                                    txtpr11.Visible = true;
                                    lbl11.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();


                                    lbl12.Visible = false;
                                    txt12.Visible = false;
                                    txtpr12.Visible = false;

                                    lbl13.Visible = false;
                                    txt13.Visible = false;
                                    txtpr13.Visible = false;

                                    lbl14.Visible = false;
                                    txt14.Visible = false;
                                    txtpr14.Visible = false;

                                    lbl15.Visible = false;
                                    txt15.Visible = false;
                                    txtpr15.Visible = false;

                                    lbl16.Visible = false;
                                    txt16.Visible = false;
                                    txtpr16.Visible = false;

                                    lbl17.Visible = false;
                                    txt17.Visible = false;
                                    txtpr17.Visible = false;

                                    lbl18.Visible = false;
                                    txt18.Visible = false;
                                    txtpr18.Visible = false;

                                    lbl19.Visible = false;
                                    txt19.Visible = false;
                                    txtpr19.Visible = false;
                                }
                                else if (i == 12)
                                {

                                    lbl12.Visible = true;
                                    txt12.Visible = true;
                                    txtpr12.Visible = true;
                                    lbl12.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();

                                    lbl13.Visible = false;
                                    txt13.Visible = false;
                                    txtpr13.Visible = false;

                                    lbl14.Visible = false;
                                    txt14.Visible = false;
                                    txtpr14.Visible = false;

                                    lbl15.Visible = false;
                                    txt15.Visible = false;
                                    txtpr15.Visible = false;

                                    lbl16.Visible = false;
                                    txt16.Visible = false;
                                    txtpr16.Visible = false;

                                    lbl17.Visible = false;
                                    txt17.Visible = false;
                                    txtpr17.Visible = false;

                                    lbl18.Visible = false;
                                    txt18.Visible = false;
                                    txtpr18.Visible = false;

                                    lbl19.Visible = false;
                                    txt19.Visible = false;
                                    txtpr19.Visible = false;
                                }
                                else if (i == 13)
                                {

                                    lbl13.Visible = true;
                                    txt13.Visible = true;
                                    txtpr13.Visible = true;
                                    lbl13.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();

                                    lbl14.Visible = false;
                                    txt14.Visible = false;
                                    txtpr14.Visible = false;

                                    lbl15.Visible = false;
                                    txt15.Visible = false;
                                    txtpr15.Visible = false;

                                    lbl16.Visible = false;
                                    txt16.Visible = false;
                                    txtpr16.Visible = false;

                                    lbl17.Visible = false;
                                    txt17.Visible = false;
                                    txtpr17.Visible = false;

                                    lbl18.Visible = false;
                                    txt18.Visible = false;
                                    txtpr18.Visible = false;

                                    lbl19.Visible = false;
                                    txt19.Visible = false;
                                    txtpr19.Visible = false;
                                }
                                else if (i == 14)
                                {

                                    lbl14.Visible = true;
                                    txt14.Visible = true;
                                    txtpr14.Visible = true;
                                    lbl14.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();

                                    lbl15.Visible = false;
                                    txt15.Visible = false;
                                    txtpr15.Visible = false;

                                    lbl16.Visible = false;
                                    txt16.Visible = false;
                                    txtpr16.Visible = false;

                                    lbl17.Visible = false;
                                    txt17.Visible = false;
                                    txtpr17.Visible = false;

                                    lbl18.Visible = false;
                                    txt18.Visible = false;
                                    txtpr18.Visible = false;

                                    lbl19.Visible = false;
                                    txt19.Visible = false;
                                    txtpr19.Visible = false;
                                }
                                else if (i == 15)
                                {

                                    lbl15.Visible = true;
                                    txt15.Visible = true;
                                    txtpr15.Visible = true;
                                    lbl15.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();

                                    lbl16.Visible = false;
                                    txt16.Visible = false;
                                    txtpr16.Visible = false;

                                    lbl17.Visible = false;
                                    txt17.Visible = false;
                                    txtpr17.Visible = false;

                                    lbl18.Visible = false;
                                    txt18.Visible = false;
                                    txtpr18.Visible = false;

                                    lbl19.Visible = false;
                                    txt19.Visible = false;
                                    txtpr19.Visible = false;
                                }
                                else if (i == 16)
                                {

                                    lbl16.Visible = true;
                                    txt16.Visible = true;
                                    txtpr16.Visible = true;
                                    lbl16.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();


                                    lbl17.Visible = false;
                                    txt17.Visible = false;
                                    txtpr17.Visible = false;

                                    lbl18.Visible = false;
                                    txt18.Visible = false;
                                    txtpr18.Visible = false;

                                    lbl19.Visible = false;
                                    txt19.Visible = false;
                                    txtpr19.Visible = false;
                                }
                                else if (i == 17)
                                {

                                    lbl17.Visible = true;
                                    txt17.Visible = true;
                                    txtpr17.Visible = true;
                                    lbl17.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();

                                    lbl18.Visible = false;
                                    txt18.Visible = false;
                                    txtpr18.Visible = false;

                                    lbl19.Visible = false;
                                    txt19.Visible = false;
                                    txtpr19.Visible = false;
                                }
                                else if (i == 18)
                                {

                                    lbl18.Visible = true;
                                    txt18.Visible = true;
                                    txtpr18.Visible = true;
                                    lbl18.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();

                                    lbl19.Visible = false;
                                    txt19.Visible = false;
                                    txtpr19.Visible = false;
                                }
                                else
                                {

                                    lbl19.Visible = true;
                                    txt19.Visible = true;
                                    txtpr19.Visible = true;
                                    //txtpr9.Text = txtpalletsrefno.Text;
                                    lbl19.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();
                                }

                            }
                        }
                    }
                    else
                    {
                        string script = "alert('Able to enter less than 20 pallets only!')";
                        ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                        txtPallets.Text = "";
                    }

                }
                else
                {
                    string script = "alert('Please Select Product Details')";
                    ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                    txtPallets.Text = "";
                }
            }
           

        }



        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now;
            if (txtExpDate.Text == "")
            {
                string script = "alert('Please Select Expiry Date')";
                ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
            }
            else
            {
                DateTime expirydate = Convert.ToDateTime(txtExpDate.Text);
                if (expirydate < today)
                {
                    string script = "alert('Please Select Valid Expiry Date')";
                    ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                }
                else
                {
                    if (txtBatch.Text == "")
                    {
                        string script = "alert('Enter Batch Number')";
                        ClientScript.RegisterStartupScript(this.GetType(), "UpdateMessage", script, true);
                    }
                    //else if (txtBatch.Text == "")
                    //{
                    //    string script = "alert('Enter Batch Number')";
                    //    ClientScript.RegisterStartupScript(this.GetType(), "UpdateMessage", script, true);
                    //}
                    else if (ddlSelectapprover.SelectedValue == "Select Approver")
                    {
                        string script = "alert('Select Approver')";
                        ClientScript.RegisterStartupScript(this.GetType(), "UpdateMessage", script, true);
                    }

                    else
                    {
                        if (btnSubmit.Text == "Submit")
                        {


                            if (txtRecdQty.Text == "0" || txtRecdQty.Text == "")
                            {
                                if (Convert.ToInt32(txtOrderqty.Text) != Convert.ToInt32(txtRemqty.Text))
                                {
                                    string script = "alert('Please Enter the Valid received qty')";
                                    ClientScript.RegisterStartupScript(this.GetType(), "UpdateMessage", script, true);
                                }
                                else
                                {

                                }


                            }
                            else
                            {

                                if (!string.IsNullOrEmpty(ddlReturnnumber.SelectedValue) && Convert.ToInt32(ddlReturnnumber.SelectedValue) != 0)
                                {
                                    int qty0 = Convert.ToInt32(txt0.Text); int qty1 = Convert.ToInt32(txt1.Text); int qty2 = Convert.ToInt32(txt2.Text);
                                    int qty3 = Convert.ToInt32(txt3.Text); int qty4 = Convert.ToInt32(txt4.Text); int qty5 = Convert.ToInt32(txt5.Text);
                                    int qty6 = Convert.ToInt32(txt6.Text); int qty7 = Convert.ToInt32(txt7.Text); int qty8 = Convert.ToInt32(txt8.Text);
                                    int qty9 = Convert.ToInt32(txt9.Text); int qty10 = Convert.ToInt32(txt10.Text); int qty11 = Convert.ToInt32(txt11.Text);
                                    int qty12 = Convert.ToInt32(txt12.Text); int qty13 = Convert.ToInt32(txt13.Text); int qty14 = Convert.ToInt32(txt14.Text);
                                    int qty15 = Convert.ToInt32(txt15.Text); int qty16 = Convert.ToInt32(txt16.Text); int qty17 = Convert.ToInt32(txt17.Text);
                                    int qty18 = Convert.ToInt32(txt18.Text); int qty19 = Convert.ToInt32(txt19.Text);
                                    int totalqty = qty0 + qty1 + qty2 + qty3 + qty4 + qty5 + qty6 + qty7 + qty8 + qty9 + qty10 + qty11 + qty12 + qty13 + qty14 + qty15 + qty16 + qty17 + qty18 + qty19;
                                    //int odrqty = Convert.ToInt32(txtOrderqty.Text);
                                    //int rcdqty = Convert.ToInt32(txtRemqty.Text);
                                    //if (odrqty == rcdqty)
                                    //{
                                    //    txtRecdQty.Text = odrqty.ToString();
                                    //}
                                    //else
                                    //{
                                    //    txtRecdQty.Text = rcdqty.ToString();
                                    //}
                                    if (Convert.ToInt32(txtRecdQty.Text) == totalqty)
                                    {
                                        DateTime date = DateTime.Now;
                                        int iSuccess10 = dbObj.InsertGR(0, Convert.ToInt32(ddlProductid.SelectedValue), txtDosageform.Text, txtStrength.Text, Convert.ToInt32(txtOrderqty.Text), Convert.ToDouble(txtOrderAmount.Text), txtBatch.Text, Convert.ToInt32(txtRecdQty.Text), txtExpDate.Text, Convert.ToInt32(txtPallets.Text), Convert.ToString(ddlbatchstatus.SelectedItem.Text), Convert.ToInt32(ddlSelectapprover.SelectedValue), ddlStatus.SelectedItem.Text, date, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                        int iSuccess11 = dbObj.UpdatePO_GoodReceipt(0, Convert.ToInt32(ddlProductid.SelectedValue), ddlStatus.SelectedItem.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                        DataSet dsGRi = dbObj.GetMax_GR();
                                        if (dsGRi.Tables[0].Rows.Count > 0)
                                        {
                                            if (dsGRi.Tables[0].Rows[0]["Id"].ToString() != null && dsGRi.Tables[0].Rows[0]["Id"].ToString() != "")
                                            {
                                                txtGRNnumber.Text = dsGRi.Tables[0].Rows[0]["Id"].ToString();
                                                // txtGRNnumber.Text = Convert.ToString(Id + 1);
                                            }
                                            else
                                            {
                                                txtGRNnumber.Text = "1";

                                            }
                                        }
                                        else
                                        {
                                            txtGRNnumber.Text = "1";
                                        }
                                        int iSuccess12 = dbObj.InsertTraceablity(0, Convert.ToInt32(ddlProductid.SelectedValue), Convert.ToInt32(txtGRNnumber.Text), txtBatch.Text, Convert.ToInt32(ddlSelectapprover.SelectedValue), Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                        for (int i = 0; i < Convert.ToInt32(txtPallets.Text); i++)
                                        {
                                            if (lbl0.Visible == true)
                                            {


                                                int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl0.Text, Convert.ToInt32(txt0.Text), txtpr0.Text, ddlbatchstatus.SelectedItem.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                int Id = 0;
                                                DataSet dsGR = dbObj.GetMax_TransGR();
                                                if (dsGR.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                    {
                                                        Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                    }
                                                    else
                                                    {
                                                        Id = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    Id = 1;
                                                }
                                                DataSet dsTrace = dbObj.GetMax_Traceid();
                                                int TraceId = +1;
                                                if (dsTrace.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                    {
                                                        TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                        TraceId = TraceId + 1;

                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    TraceId = 1;
                                                }
                                                int iSuccess1 = dbObj.InsertTransetraceablity(0, lbl0.Text, Convert.ToInt32(txt0.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr0.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                int iUpdate = dbObj.UpdateUnitQty(Id, lbl0.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt0.Text), ddlbatchstatus.SelectedItem.Text, txtpr0.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                lbl0.Visible = false; txt0.Visible = false; txtpr0.Visible = false; btnCalSubmit.Visible = false;
                                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);

                                            }
                                            else if (lbl1.Visible == true)
                                            {


                                                int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl1.Text, Convert.ToInt32(txt1.Text), txtpr1.Text, ddlbatchstatus.SelectedItem.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                int Id = 0;
                                                DataSet dsGR = dbObj.GetMax_TransGR();
                                                if (dsGR.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                    {
                                                        Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                    }
                                                    else
                                                    {
                                                        Id = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    Id = 1;
                                                }

                                                DataSet dsTrace = dbObj.GetMax_Traceid();
                                                int TraceId;
                                                if (dsTrace.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                    {
                                                        TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                        TraceId = TraceId + 1;
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    TraceId = 1;
                                                }
                                                int iSuccess1 = dbObj.InsertTransetraceablity(0, lbl1.Text, Convert.ToInt32(txt1.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr1.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                int iUpdate = dbObj.UpdateUnitQty(Id, lbl1.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt1.Text), ddlbatchstatus.SelectedItem.Text, txtpr1.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                lbl1.Visible = false; txt1.Visible = false; txtpr1.Visible = false; btnCalSubmit.Visible = false;
                                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                            }
                                            else if (lbl2.Visible == true)
                                            {


                                                int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl2.Text, Convert.ToInt32(txt2.Text), txtpr2.Text, ddlbatchstatus.SelectedItem.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                int Id = 0;
                                                DataSet dsGR = dbObj.GetMax_TransGR();
                                                if (dsGR.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                    {
                                                        Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                    }
                                                    else
                                                    {
                                                        Id = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    Id = 1;
                                                }
                                                DataSet dsTrace = dbObj.GetMax_Traceid();
                                                int TraceId;
                                                if (dsTrace.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                    {
                                                        TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                        TraceId = TraceId + 1;
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    TraceId = 1;
                                                }
                                                int iSuccess1 = dbObj.InsertTransetraceablity(0, lbl2.Text, Convert.ToInt32(txt2.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr2.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                int iUpdate = dbObj.UpdateUnitQty(Id, lbl2.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt2.Text), ddlbatchstatus.SelectedItem.Text, txtpr2.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                lbl2.Visible = false; txt2.Visible = false; txtpr2.Visible = false; btnCalSubmit.Visible = false;
                                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                            }
                                            else if (lbl3.Visible == true)
                                            {

                                                int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl3.Text, Convert.ToInt32(txt3.Text), txtpr3.Text, ddlbatchstatus.SelectedItem.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                int Id = 0;
                                                DataSet dsGR = dbObj.GetMax_TransGR();
                                                if (dsGR.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                    {
                                                        Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                    }
                                                    else
                                                    {
                                                        Id = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    Id = 1;
                                                }

                                                DataSet dsTrace = dbObj.GetMax_Traceid();
                                                int TraceId;
                                                if (dsTrace.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                    {
                                                        TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                        TraceId = TraceId + 1;
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    TraceId = 1;
                                                }
                                                int iSuccess1 = dbObj.InsertTransetraceablity(0, lbl3.Text, Convert.ToInt32(txt3.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr3.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                int iUpdate = dbObj.UpdateUnitQty(Id, lbl3.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt3.Text), ddlbatchstatus.SelectedItem.Text, txtpr3.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                lbl3.Visible = false; txt3.Visible = false; txtpr3.Visible = false; btnCalSubmit.Visible = false;
                                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                            }
                                            else if (lbl4.Visible == true)
                                            {

                                                int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl4.Text, Convert.ToInt32(txt4.Text), txtpr4.Text, ddlbatchstatus.SelectedItem.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));

                                                int Id = 0;
                                                DataSet dsGR = dbObj.GetMax_TransGR();
                                                if (dsGR.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                    {
                                                        Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                    }
                                                    else
                                                    {
                                                        Id = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    Id = 1;
                                                }

                                                DataSet dsTrace = dbObj.GetMax_Traceid();
                                                int TraceId;
                                                if (dsTrace.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                    {
                                                        TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                        TraceId = TraceId + 1;
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    TraceId = 1;
                                                }
                                                int iSuccess1 = dbObj.InsertTransetraceablity(0, lbl4.Text, Convert.ToInt32(txt4.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr4.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                int iUpdate = dbObj.UpdateUnitQty(Id, lbl4.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt4.Text), ddlbatchstatus.SelectedItem.Text, txtpr4.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                lbl4.Visible = false; txt4.Visible = false; txtpr4.Visible = false; btnCalSubmit.Visible = false;
                                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                            }
                                            else if (lbl5.Visible == true)
                                            {

                                                int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl5.Text, Convert.ToInt32(txt5.Text), txtpr5.Text, ddlbatchstatus.SelectedItem.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                int Id = 0;
                                                DataSet dsGR = dbObj.GetMax_TransGR();
                                                if (dsGR.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                    {
                                                        Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                    }
                                                    else
                                                    {
                                                        Id = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    Id = 1;
                                                }

                                                DataSet dsTrace = dbObj.GetMax_Traceid();
                                                int TraceId;
                                                if (dsTrace.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                    {
                                                        TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                        TraceId = TraceId + 1;
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    TraceId = 1;
                                                }
                                                int iSuccess1 = dbObj.InsertTransetraceablity(0, lbl5.Text, Convert.ToInt32(txt5.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr5.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                int iUpdate = dbObj.UpdateUnitQty(Id, lbl5.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt5.Text), ddlbatchstatus.SelectedItem.Text, txtpr5.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                lbl5.Visible = false; txt5.Visible = false; txtpr5.Visible = false; btnCalSubmit.Visible = false;
                                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                            }
                                            else if (lbl6.Visible == true)
                                            {

                                                int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl6.Text, Convert.ToInt32(txt6.Text), txtpr6.Text, ddlbatchstatus.SelectedItem.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                int Id = 0;
                                                DataSet dsGR = dbObj.GetMax_TransGR();
                                                if (dsGR.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                    {
                                                        Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                    }
                                                    else
                                                    {
                                                        Id = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    Id = 1;
                                                }

                                                DataSet dsTrace = dbObj.GetMax_Traceid();
                                                int TraceId;
                                                if (dsTrace.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                    {
                                                        TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                        TraceId = TraceId + 1;
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    TraceId = 1;
                                                }
                                                int iSuccess1 = dbObj.InsertTransetraceablity(0, lbl6.Text, Convert.ToInt32(txt6.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr6.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                int iUpdate = dbObj.UpdateUnitQty(Id, lbl6.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt6.Text), ddlbatchstatus.SelectedItem.Text, txtpr6.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                lbl6.Visible = false; txt6.Visible = false; txtpr6.Visible = false; btnCalSubmit.Visible = false;
                                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                            }
                                            else if (lbl7.Visible == true)
                                            {


                                                int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl7.Text, Convert.ToInt32(txt7.Text), txtpr7.Text, ddlbatchstatus.SelectedItem.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                int Id = 0;
                                                DataSet dsGR = dbObj.GetMax_TransGR();
                                                if (dsGR.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                    {
                                                        Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                    }
                                                    else
                                                    {
                                                        Id = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    Id = 1;
                                                }
                                                DataSet dsTrace = dbObj.GetMax_Traceid();
                                                int TraceId;
                                                if (dsTrace.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                    {
                                                        TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                        TraceId = TraceId + 1;
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    TraceId = 1;
                                                }
                                                int iSuccess1 = dbObj.InsertTransetraceablity(0, lbl7.Text, Convert.ToInt32(txt7.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr7.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                int iUpdate = dbObj.UpdateUnitQty(Id, lbl7.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt7.Text), ddlbatchstatus.SelectedItem.Text, txtpr7.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                lbl7.Visible = false; txt7.Visible = false; txtpr7.Visible = false; btnCalSubmit.Visible = false;
                                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);

                                            }
                                            else if (lbl8.Visible == true)
                                            {

                                                int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl8.Text, Convert.ToInt32(txt8.Text), txtpr8.Text, ddlbatchstatus.SelectedItem.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                int Id = 0;
                                                DataSet dsGR = dbObj.GetMax_TransGR();
                                                if (dsGR.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                    {
                                                        Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                    }
                                                    else
                                                    {
                                                        Id = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    Id = 1;
                                                }

                                                DataSet dsTrace = dbObj.GetMax_Traceid();
                                                int TraceId;
                                                if (dsTrace.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                    {
                                                        TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                        TraceId = TraceId + 1;
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    TraceId = 1;
                                                }
                                                int iSuccess1 = dbObj.InsertTransetraceablity(0, lbl8.Text, Convert.ToInt32(txt8.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr8.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                int iUpdate = dbObj.UpdateUnitQty(Id, lbl8.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt8.Text), ddlbatchstatus.SelectedItem.Text, txtpr8.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                lbl8.Visible = false; txt8.Visible = false; txtpr8.Visible = false; btnCalSubmit.Visible = false;
                                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                            }
                                            else if (lbl9.Visible == true)
                                            {


                                                int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl9.Text, Convert.ToInt32(txt9.Text), txtpr9.Text, ddlbatchstatus.SelectedItem.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                int Id = 0;
                                                DataSet dsGR = dbObj.GetMax_TransGR();
                                                if (dsGR.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                    {
                                                        Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                    }
                                                    else
                                                    {
                                                        Id = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    Id = 1;
                                                }
                                                DataSet dsTrace = dbObj.GetMax_Traceid();
                                                int TraceId;
                                                if (dsTrace.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                    {
                                                        TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                        TraceId = TraceId + 1;
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    TraceId = 1;
                                                }
                                                int iSuccess1 = dbObj.InsertTransetraceablity(0, lbl9.Text, Convert.ToInt32(txt9.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr9.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                int iUpdate = dbObj.UpdateUnitQty(Id, lbl9.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt9.Text), ddlbatchstatus.SelectedItem.Text, txtpr9.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                lbl9.Visible = false; txt9.Visible = false; txtpr9.Visible = false; btnCalSubmit.Visible = false;
                                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                            }
                                            else if (lbl10.Visible == true)
                                            {


                                                int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl10.Text, Convert.ToInt32(txt10.Text), txtpr10.Text, ddlbatchstatus.SelectedItem.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                int Id = 0;
                                                DataSet dsGR = dbObj.GetMax_TransGR();
                                                if (dsGR.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                    {
                                                        Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                    }
                                                    else
                                                    {
                                                        Id = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    Id = 1;
                                                }
                                                DataSet dsTrace = dbObj.GetMax_Traceid();
                                                int TraceId;
                                                if (dsTrace.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                    {
                                                        TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                        TraceId = TraceId + 1;
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    TraceId = 1;
                                                }
                                                int iSuccess1 = dbObj.InsertTransetraceablity(0, lbl10.Text, Convert.ToInt32(txt10.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr10.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                int iUpdate = dbObj.UpdateUnitQty(Id, lbl10.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt10.Text), ddlbatchstatus.SelectedItem.Text, txtpr10.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                lbl10.Visible = false; txt10.Visible = false; txtpr10.Visible = false; btnCalSubmit.Visible = false;
                                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                            }
                                            else if (lbl11.Visible == true)
                                            {


                                                int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl11.Text, Convert.ToInt32(txt11.Text), txtpr11.Text, ddlbatchstatus.SelectedItem.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                int Id = 0;
                                                DataSet dsGR = dbObj.GetMax_TransGR();
                                                if (dsGR.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                    {
                                                        Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                    }
                                                    else
                                                    {
                                                        Id = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    Id = 1;
                                                }
                                                DataSet dsTrace = dbObj.GetMax_Traceid();
                                                int TraceId;
                                                if (dsTrace.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                    {
                                                        TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                        TraceId = TraceId + 1;
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    TraceId = 1;
                                                }
                                                int iSuccess1 = dbObj.InsertTransetraceablity(0, lbl11.Text, Convert.ToInt32(txt11.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr11.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                int iUpdate = dbObj.UpdateUnitQty(Id, lbl11.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt11.Text), ddlbatchstatus.SelectedItem.Text, txtpr11.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                lbl10.Visible = false; txt11.Visible = false; txtpr11.Visible = false; btnCalSubmit.Visible = false;
                                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                            }
                                            else if (lbl12.Visible == true)
                                            {


                                                int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl12.Text, Convert.ToInt32(txt12.Text), txtpr12.Text, ddlbatchstatus.SelectedItem.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                int Id = 0;
                                                DataSet dsGR = dbObj.GetMax_TransGR();
                                                if (dsGR.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                    {
                                                        Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                    }
                                                    else
                                                    {
                                                        Id = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    Id = 1;
                                                }
                                                DataSet dsTrace = dbObj.GetMax_Traceid();
                                                int TraceId;
                                                if (dsTrace.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                    {
                                                        TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                        TraceId = TraceId + 1;
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    TraceId = 1;
                                                }
                                                int iSuccess1 = dbObj.InsertTransetraceablity(0, lbl12.Text, Convert.ToInt32(txt12.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr12.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                int iUpdate = dbObj.UpdateUnitQty(Id, lbl12.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt12.Text), ddlbatchstatus.SelectedItem.Text, txtpr12.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                lbl12.Visible = false; txt12.Visible = false; txtpr12.Visible = false; btnCalSubmit.Visible = false;
                                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                            }
                                            else if (lbl13.Visible == true)
                                            {


                                                int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl13.Text, Convert.ToInt32(txt13.Text), txtpr13.Text, ddlbatchstatus.SelectedItem.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                int Id = 0;
                                                DataSet dsGR = dbObj.GetMax_TransGR();
                                                if (dsGR.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                    {
                                                        Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                    }
                                                    else
                                                    {
                                                        Id = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    Id = 1;
                                                }
                                                DataSet dsTrace = dbObj.GetMax_Traceid();
                                                int TraceId;
                                                if (dsTrace.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                    {
                                                        TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                        TraceId = TraceId + 1;
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    TraceId = 1;
                                                }
                                                int iSuccess1 = dbObj.InsertTransetraceablity(0, lbl13.Text, Convert.ToInt32(txt13.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr13.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                int iUpdate = dbObj.UpdateUnitQty(Id, lbl13.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt13.Text), ddlbatchstatus.SelectedItem.Text, txtpr13.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                lbl13.Visible = false; txt13.Visible = false; txtpr13.Visible = false; btnCalSubmit.Visible = false;
                                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                            }
                                            else if (lbl14.Visible == true)
                                            {


                                                int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl14.Text, Convert.ToInt32(txt14.Text), txtpr14.Text, ddlbatchstatus.SelectedItem.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                int Id = 0;
                                                DataSet dsGR = dbObj.GetMax_TransGR();
                                                if (dsGR.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                    {
                                                        Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                    }
                                                    else
                                                    {
                                                        Id = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    Id = 1;
                                                }
                                                DataSet dsTrace = dbObj.GetMax_Traceid();
                                                int TraceId;
                                                if (dsTrace.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                    {
                                                        TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                        TraceId = TraceId + 1;
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    TraceId = 1;
                                                }
                                                int iSuccess1 = dbObj.InsertTransetraceablity(0, lbl14.Text, Convert.ToInt32(txt14.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr14.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                int iUpdate = dbObj.UpdateUnitQty(Id, lbl14.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt14.Text), ddlbatchstatus.SelectedItem.Text, txtpr14.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                lbl14.Visible = false; txt14.Visible = false; txtpr14.Visible = false; btnCalSubmit.Visible = false;
                                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                            }
                                            else if (lbl15.Visible == true)
                                            {


                                                int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl15.Text, Convert.ToInt32(txt15.Text), txtpr15.Text, ddlbatchstatus.SelectedItem.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                int Id = 0;
                                                DataSet dsGR = dbObj.GetMax_TransGR();
                                                if (dsGR.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                    {
                                                        Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                    }
                                                    else
                                                    {
                                                        Id = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    Id = 1;
                                                }
                                                DataSet dsTrace = dbObj.GetMax_Traceid();
                                                int TraceId;
                                                if (dsTrace.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                    {
                                                        TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                        TraceId = TraceId + 1;
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    TraceId = 1;
                                                }
                                                int iSuccess1 = dbObj.InsertTransetraceablity(0, lbl15.Text, Convert.ToInt32(txt15.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr15.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                int iUpdate = dbObj.UpdateUnitQty(Id, lbl15.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt5.Text), ddlbatchstatus.SelectedItem.Text, txtpr15.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                lbl15.Visible = false; txt15.Visible = false; txtpr15.Visible = false; btnCalSubmit.Visible = false;
                                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                            }
                                            else if (lbl16.Visible == true)
                                            {


                                                int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl16.Text, Convert.ToInt32(txt16.Text), txtpr16.Text, ddlbatchstatus.SelectedItem.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                int Id = 0;
                                                DataSet dsGR = dbObj.GetMax_TransGR();
                                                if (dsGR.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                    {
                                                        Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                    }
                                                    else
                                                    {
                                                        Id = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    Id = 1;
                                                }
                                                DataSet dsTrace = dbObj.GetMax_Traceid();
                                                int TraceId;
                                                if (dsTrace.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                    {
                                                        TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                        TraceId = TraceId + 1;
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    TraceId = 1;
                                                }
                                                int iSuccess1 = dbObj.InsertTransetraceablity(0, lbl16.Text, Convert.ToInt32(txt16.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr16.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                int iUpdate = dbObj.UpdateUnitQty(Id, lbl16.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt6.Text), ddlbatchstatus.SelectedItem.Text, txtpr16.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                lbl16.Visible = false; txt16.Visible = false; txtpr16.Visible = false; btnCalSubmit.Visible = false;
                                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                            }
                                            else if (lbl17.Visible == true)
                                            {


                                                int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl17.Text, Convert.ToInt32(txt17.Text), txtpr17.Text, ddlbatchstatus.SelectedItem.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                int Id = 0;
                                                DataSet dsGR = dbObj.GetMax_TransGR();
                                                if (dsGR.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                    {
                                                        Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                    }
                                                    else
                                                    {
                                                        Id = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    Id = 1;
                                                }
                                                DataSet dsTrace = dbObj.GetMax_Traceid();
                                                int TraceId;
                                                if (dsTrace.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                    {
                                                        TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                        TraceId = TraceId + 1;
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    TraceId = 1;
                                                }
                                                int iSuccess1 = dbObj.InsertTransetraceablity(0, lbl17.Text, Convert.ToInt32(txt17.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr17.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                int iUpdate = dbObj.UpdateUnitQty(Id, lbl17.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt17.Text), ddlbatchstatus.SelectedItem.Text, txtpr17.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                lbl17.Visible = false; txt17.Visible = false; txtpr17.Visible = false; btnCalSubmit.Visible = false;
                                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                            }
                                            else if (lbl18.Visible == true)
                                            {


                                                int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl18.Text, Convert.ToInt32(txt18.Text), txtpr18.Text, ddlbatchstatus.SelectedItem.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                int Id = 0;
                                                DataSet dsGR = dbObj.GetMax_TransGR();
                                                if (dsGR.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                    {
                                                        Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                    }
                                                    else
                                                    {
                                                        Id = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    Id = 1;
                                                }
                                                DataSet dsTrace = dbObj.GetMax_Traceid();
                                                int TraceId;
                                                if (dsTrace.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                    {
                                                        TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                        TraceId = TraceId + 1;
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    TraceId = 1;
                                                }
                                                int iSuccess1 = dbObj.InsertTransetraceablity(0, lbl18.Text, Convert.ToInt32(txt18.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr18.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                int iUpdate = dbObj.UpdateUnitQty(Id, lbl18.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt18.Text), ddlbatchstatus.SelectedItem.Text, txtpr18.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                lbl18.Visible = false; txt18.Visible = false; txtpr18.Visible = false; btnCalSubmit.Visible = false;
                                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                            }
                                            else
                                            {


                                                int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl19.Text, Convert.ToInt32(txt19.Text), txtpr19.Text, ddlbatchstatus.SelectedItem.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                int Id = 0;
                                                DataSet dsGR = dbObj.GetMax_TransGR();
                                                if (dsGR.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                    {
                                                        Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                    }
                                                    else
                                                    {
                                                        Id = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    Id = 1;
                                                }
                                                DataSet dsTrace = dbObj.GetMax_Traceid();
                                                int TraceId;
                                                if (dsTrace.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                    {
                                                        TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                        TraceId = TraceId + 1;
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    TraceId = 1;
                                                }
                                                int iSuccess1 = dbObj.InsertTransetraceablity(0, lbl19.Text, Convert.ToInt32(txt19.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr19.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                int iUpdate = dbObj.UpdateUnitQty(Id, lbl19.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt19.Text), ddlbatchstatus.SelectedItem.Text, txtpr19.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                lbl19.Visible = false; txt19.Visible = false; txtpr19.Visible = false; btnCalSubmit.Visible = false;
                                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                            }
                                        }


                                        // int iSuccess1 = dbObj.InsertGRandUnits(Convert.ToInt32(ddlProductid.SelectedValue),txtBatch.Text,txtExpDate.Text, Convert.ToInt32(txtRecdQty.Text));
                                        Response.Redirect("GoodReceiptGrid.aspx");
                                    }
                                    else
                                    {
                                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Unable to Process, Quantity Mismatch!');", true);
                                    }



                                }
                                else
                                {


                                    int qty0 = Convert.ToInt32(txt0.Text); int qty1 = Convert.ToInt32(txt1.Text); int qty2 = Convert.ToInt32(txt2.Text);
                                    int qty3 = Convert.ToInt32(txt3.Text); int qty4 = Convert.ToInt32(txt4.Text); int qty5 = Convert.ToInt32(txt5.Text);
                                    int qty6 = Convert.ToInt32(txt6.Text); int qty7 = Convert.ToInt32(txt7.Text); int qty8 = Convert.ToInt32(txt8.Text);
                                    int qty9 = Convert.ToInt32(txt9.Text); int qty10 = Convert.ToInt32(txt10.Text); int qty11 = Convert.ToInt32(txt11.Text);
                                    int qty12 = Convert.ToInt32(txt12.Text); int qty13 = Convert.ToInt32(txt13.Text); int qty14 = Convert.ToInt32(txt14.Text);
                                    int qty15 = Convert.ToInt32(txt15.Text); int qty16 = Convert.ToInt32(txt16.Text); int qty17 = Convert.ToInt32(txt17.Text);
                                    int qty18 = Convert.ToInt32(txt18.Text); int qty19 = Convert.ToInt32(txt19.Text);
                                    int totalqty = qty0 + qty1 + qty2 + qty3 + qty4 + qty5 + qty6 + qty7 + qty8 + qty9 + qty10 + qty11 + qty12 + qty13 + qty14 + qty15 + qty16 + qty17 + qty18 + qty19;
                                    //int odrqty = Convert.ToInt32(txtOrderqty.Text);
                                    //int rcdqty = Convert.ToInt32(txtRemqty.Text);
                                    //if (odrqty == rcdqty)
                                    //{
                                    //    txtRecdQty.Text = odrqty.ToString();
                                    //}
                                    //else
                                    //{
                                    //    txtRecdQty.Text = rcdqty.ToString();
                                    //}
                                    if (Convert.ToInt32(txtRecdQty.Text) == totalqty)
                                    {
                                        DateTime date = DateTime.Now;
                                        int iSuccess13 = dbObj.InsertGR(Convert.ToInt32(ddlPOnumber.SelectedValue), Convert.ToInt32(ddlProductid.SelectedValue), txtDosageform.Text, txtStrength.Text, Convert.ToInt32(txtOrderqty.Text), Convert.ToDouble(txtOrderAmount.Text), txtBatch.Text, Convert.ToInt32(txtRecdQty.Text), txtExpDate.Text, Convert.ToInt32(txtPallets.Text), Convert.ToString(ddlbatchstatus.SelectedItem.Text), Convert.ToInt32(ddlSelectapprover.SelectedValue), ddlStatus.SelectedItem.Text, date, 0);
                                        int iSuccess14 = dbObj.UpdatePO_GoodReceipt(Convert.ToInt32(ddlPOnumber.SelectedValue), Convert.ToInt32(ddlProductid.SelectedValue), ddlStatus.SelectedItem.Text, 0);
                                        DataSet dsGRi = dbObj.GetMax_GR();
                                        if (dsGRi.Tables[0].Rows.Count > 0)
                                        {
                                            if (dsGRi.Tables[0].Rows[0]["Id"].ToString() != null && dsGRi.Tables[0].Rows[0]["Id"].ToString() != "")
                                            {
                                                txtGRNnumber.Text = dsGRi.Tables[0].Rows[0]["Id"].ToString();
                                                // txtGRNnumber.Text = Convert.ToString(Id + 1);
                                            }
                                            else
                                            {
                                                txtGRNnumber.Text = "1";

                                            }
                                        }
                                        else
                                        {
                                            txtGRNnumber.Text = "1";
                                        }
                                        int iSuccess15 = dbObj.InsertTraceablity(Convert.ToInt32(ddlPOnumber.SelectedValue), Convert.ToInt32(ddlProductid.SelectedValue), Convert.ToInt32(txtGRNnumber.Text), txtBatch.Text, Convert.ToInt32(ddlSelectapprover.SelectedValue), 0);

                                        for (int i = 0; i < Convert.ToInt32(txtPallets.Text); i++)
                                        {
                                            if (lbl0.Visible == true)
                                            {

                                                int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl0.Text, Convert.ToInt32(txt0.Text), txtpr0.Text, ddlbatchstatus.SelectedItem.Text, 0);
                                                int Id = 0;
                                                DataSet dsGR = dbObj.GetMax_TransGR();
                                                if (dsGR.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                    {
                                                        Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                    }
                                                    else
                                                    {
                                                        Id = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    Id = 1;
                                                }

                                                DataSet dsTrace = dbObj.GetMax_Traceid();
                                                int TraceId = +1;
                                                if (dsTrace.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                    {
                                                        TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                        TraceId = TraceId + 1;

                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    TraceId = 1;
                                                }
                                                int iSuccess1 = dbObj.InsertTransetraceablity(Convert.ToInt32(ddlPOnumber.SelectedValue), lbl0.Text, Convert.ToInt32(txt0.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr0.Text, 0);
                                                int iUpdate = dbObj.UpdateUnitQty(Id, lbl0.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt0.Text), ddlbatchstatus.SelectedItem.Text, txtpr0.Text, 0);
                                                lbl0.Visible = false; txt0.Visible = false; txtpr0.Visible = false; btnCalSubmit.Visible = false;
                                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);

                                            }
                                            else if (lbl1.Visible == true)
                                            {



                                                int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl1.Text, Convert.ToInt32(txt1.Text), txtpr1.Text, ddlbatchstatus.SelectedItem.Text, 0);
                                                int Id = 0;
                                                DataSet dsGR = dbObj.GetMax_TransGR();
                                                if (dsGR.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                    {
                                                        Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());


                                                    }
                                                    else
                                                    {
                                                        Id = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    Id = 1;
                                                }
                                                DataSet dsTrace = dbObj.GetMax_Traceid();
                                                int TraceId;
                                                if (dsTrace.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                    {
                                                        TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                        TraceId = TraceId + 1;
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    TraceId = 1;
                                                }
                                                int iSuccess1 = dbObj.InsertTransetraceablity(Convert.ToInt32(ddlPOnumber.SelectedValue), lbl1.Text, Convert.ToInt32(txt1.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr1.Text, 0);
                                                int iUpdate = dbObj.UpdateUnitQty(Id, lbl1.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt1.Text), ddlbatchstatus.SelectedItem.Text, txtpr1.Text, 0);
                                                lbl1.Visible = false; txt1.Visible = false; txtpr1.Visible = false; btnCalSubmit.Visible = false;
                                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                            }
                                            else if (lbl2.Visible == true)
                                            {


                                                int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl2.Text, Convert.ToInt32(txt2.Text), txtpr2.Text, ddlbatchstatus.SelectedItem.Text, 0);
                                                int Id = 0;
                                                DataSet dsGR = dbObj.GetMax_TransGR();
                                                if (dsGR.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                    {
                                                        Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                    }
                                                    else
                                                    {
                                                        Id = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    Id = 1;
                                                }
                                                DataSet dsTrace = dbObj.GetMax_Traceid();
                                                int TraceId;
                                                if (dsTrace.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                    {
                                                        TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                        TraceId = TraceId + 1;
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    TraceId = 1;
                                                }
                                                int iSuccess1 = dbObj.InsertTransetraceablity(Convert.ToInt32(ddlPOnumber.SelectedValue), lbl2.Text, Convert.ToInt32(txt2.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr2.Text, 0);
                                                int iUpdate = dbObj.UpdateUnitQty(Id, lbl2.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt2.Text), ddlbatchstatus.SelectedItem.Text, txtpr2.Text, 0);
                                                lbl2.Visible = false; txt2.Visible = false; txtpr2.Visible = false; btnCalSubmit.Visible = false;
                                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                            }
                                            else if (lbl3.Visible == true)
                                            {

                                                int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl3.Text, Convert.ToInt32(txt3.Text), txtpr3.Text, ddlbatchstatus.SelectedItem.Text, 0);
                                                int Id = 0;
                                                DataSet dsGR = dbObj.GetMax_TransGR();
                                                if (dsGR.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                    {
                                                        Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                    }
                                                    else
                                                    {
                                                        Id = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    Id = 1;
                                                }

                                                DataSet dsTrace = dbObj.GetMax_Traceid();
                                                int TraceId;
                                                if (dsTrace.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                    {
                                                        TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                        TraceId = TraceId + 1;
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    TraceId = 1;
                                                }
                                                int iSuccess1 = dbObj.InsertTransetraceablity(Convert.ToInt32(ddlPOnumber.SelectedValue), lbl3.Text, Convert.ToInt32(txt3.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr3.Text, 0);
                                                int iUpdate = dbObj.UpdateUnitQty(Id, lbl3.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt3.Text), ddlbatchstatus.SelectedItem.Text, txtpr3.Text, 0);
                                                lbl3.Visible = false; txt3.Visible = false; txtpr3.Visible = false; btnCalSubmit.Visible = false;
                                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                            }
                                            else if (lbl4.Visible == true)
                                            {


                                                int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl4.Text, Convert.ToInt32(txt4.Text), txtpr4.Text, ddlbatchstatus.SelectedItem.Text, 0);
                                                int Id = 0;
                                                DataSet dsGR = dbObj.GetMax_TransGR();
                                                if (dsGR.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                    {
                                                        Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                    }
                                                    else
                                                    {
                                                        Id = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    Id = 1;
                                                }

                                                DataSet dsTrace = dbObj.GetMax_Traceid();
                                                int TraceId;
                                                if (dsTrace.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                    {
                                                        TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                        TraceId = TraceId + 1;
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    TraceId = 1;
                                                }
                                                int iSuccess1 = dbObj.InsertTransetraceablity(Convert.ToInt32(ddlPOnumber.SelectedValue), lbl4.Text, Convert.ToInt32(txt4.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr4.Text, 0);
                                                int iUpdate = dbObj.UpdateUnitQty(Id, lbl4.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt4.Text), ddlbatchstatus.SelectedItem.Text, txtpr4.Text, 0);
                                                lbl4.Visible = false; txt4.Visible = false; txtpr4.Visible = false; btnCalSubmit.Visible = false;
                                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                            }
                                            else if (lbl5.Visible == true)
                                            {


                                                int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl5.Text, Convert.ToInt32(txt5.Text), txtpr5.Text, ddlbatchstatus.SelectedItem.Text, 0);
                                                int Id = 0;
                                                DataSet dsGR = dbObj.GetMax_TransGR();
                                                if (dsGR.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                    {
                                                        Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                    }
                                                    else
                                                    {
                                                        Id = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    Id = 1;
                                                }
                                                DataSet dsTrace = dbObj.GetMax_Traceid();
                                                int TraceId;
                                                if (dsTrace.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                    {
                                                        TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                        TraceId = TraceId + 1;
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    TraceId = 1;
                                                }
                                                int iSuccess1 = dbObj.InsertTransetraceablity(Convert.ToInt32(ddlPOnumber.SelectedValue), lbl5.Text, Convert.ToInt32(txt5.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr5.Text, 0);
                                                int iUpdate = dbObj.UpdateUnitQty(Id, lbl5.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt5.Text), ddlbatchstatus.SelectedItem.Text, txtpr5.Text, 0);
                                                lbl5.Visible = false; txt5.Visible = false; txtpr5.Visible = false; btnCalSubmit.Visible = false;
                                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                            }
                                            else if (lbl6.Visible == true)
                                            {

                                                int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl6.Text, Convert.ToInt32(txt6.Text), txtpr6.Text, ddlbatchstatus.SelectedItem.Text, 0);
                                                int Id = 0;
                                                DataSet dsGR = dbObj.GetMax_TransGR();
                                                if (dsGR.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                    {
                                                        Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                    }
                                                    else
                                                    {
                                                        Id = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    Id = 1;
                                                }

                                                DataSet dsTrace = dbObj.GetMax_Traceid();
                                                int TraceId;
                                                if (dsTrace.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                    {
                                                        TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                        TraceId = TraceId + 1;
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    TraceId = 1;
                                                }
                                                int iSuccess1 = dbObj.InsertTransetraceablity(Convert.ToInt32(ddlPOnumber.SelectedValue), lbl6.Text, Convert.ToInt32(txt6.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr6.Text, 0);
                                                int iUpdate = dbObj.UpdateUnitQty(Id, lbl6.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt6.Text), ddlbatchstatus.SelectedItem.Text, txtpr6.Text, 0);
                                                lbl6.Visible = false; txt6.Visible = false; txtpr6.Visible = false; btnCalSubmit.Visible = false;
                                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                            }
                                            else if (lbl7.Visible == true)
                                            {

                                                int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl7.Text, Convert.ToInt32(txt7.Text), txtpr7.Text, ddlbatchstatus.SelectedItem.Text, 0);
                                                int Id = 0;
                                                DataSet dsGR = dbObj.GetMax_TransGR();
                                                if (dsGR.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                    {
                                                        Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                    }
                                                    else
                                                    {
                                                        Id = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    Id = 1;
                                                }

                                                DataSet dsTrace = dbObj.GetMax_Traceid();
                                                int TraceId;
                                                if (dsTrace.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                    {
                                                        TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                        TraceId = TraceId + 1;
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    TraceId = 1;
                                                }
                                                int iSuccess1 = dbObj.InsertTransetraceablity(Convert.ToInt32(ddlPOnumber.SelectedValue), lbl7.Text, Convert.ToInt32(txt7.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr7.Text, 0);
                                                int iUpdate = dbObj.UpdateUnitQty(Id, lbl7.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt7.Text), ddlbatchstatus.SelectedItem.Text, txtpr7.Text, 0);
                                                lbl7.Visible = false; txt7.Visible = false; txtpr7.Visible = false; btnCalSubmit.Visible = false;
                                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);

                                            }
                                            else if (lbl8.Visible == true)
                                            {

                                                int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl8.Text, Convert.ToInt32(txt8.Text), txtpr8.Text, ddlbatchstatus.SelectedItem.Text, 0);
                                                int Id = 0;
                                                DataSet dsGR = dbObj.GetMax_TransGR();
                                                if (dsGR.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                    {
                                                        Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                    }
                                                    else
                                                    {
                                                        Id = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    Id = 1;
                                                }

                                                DataSet dsTrace = dbObj.GetMax_Traceid();
                                                int TraceId;
                                                if (dsTrace.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                    {
                                                        TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                        TraceId = TraceId + 1;
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    TraceId = 1;
                                                }
                                                int iSuccess1 = dbObj.InsertTransetraceablity(Convert.ToInt32(ddlPOnumber.SelectedValue), lbl8.Text, Convert.ToInt32(txt8.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr8.Text, 0);
                                                int iUpdate = dbObj.UpdateUnitQty(Id, lbl8.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt8.Text), ddlbatchstatus.SelectedItem.Text, txtpr8.Text, 0);
                                                lbl8.Visible = false; txt8.Visible = false; txtpr8.Visible = false; btnCalSubmit.Visible = false;
                                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                            }
                                            else if (lbl9.Visible == true)
                                            {


                                                int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl9.Text, Convert.ToInt32(txt9.Text), txtpr9.Text, ddlbatchstatus.SelectedItem.Text, Convert.ToInt32(ddlPOnumber.SelectedValue));
                                                int Id = 0;
                                                DataSet dsGR = dbObj.GetMax_TransGR();
                                                if (dsGR.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                    {
                                                        Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                    }
                                                    else
                                                    {
                                                        Id = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    Id = 1;
                                                }
                                                DataSet dsTrace = dbObj.GetMax_Traceid();
                                                int TraceId;
                                                if (dsTrace.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                    {
                                                        TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                        TraceId = TraceId + 1;
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    TraceId = 1;
                                                }
                                                int iSuccess1 = dbObj.InsertTransetraceablity(0, lbl9.Text, Convert.ToInt32(txt9.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr9.Text, Convert.ToInt32(ddlPOnumber.SelectedValue));
                                                int iUpdate = dbObj.UpdateUnitQty(Id, lbl9.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt9.Text), ddlbatchstatus.SelectedItem.Text, txtpr9.Text, Convert.ToInt32(ddlPOnumber.SelectedValue));
                                                lbl9.Visible = false; txt9.Visible = false; txtpr9.Visible = false; btnCalSubmit.Visible = false;
                                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                            }
                                            else if (lbl10.Visible == true)
                                            {


                                                int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl10.Text, Convert.ToInt32(txt10.Text), txtpr10.Text, ddlbatchstatus.SelectedItem.Text, 0);
                                                int Id = 0;
                                                DataSet dsGR = dbObj.GetMax_TransGR();
                                                if (dsGR.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                    {
                                                        Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                    }
                                                    else
                                                    {
                                                        Id = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    Id = 1;
                                                }
                                                DataSet dsTrace = dbObj.GetMax_Traceid();
                                                int TraceId;
                                                if (dsTrace.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                    {
                                                        TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                        TraceId = TraceId + 1;
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    TraceId = 1;
                                                }
                                                int iSuccess1 = dbObj.InsertTransetraceablity(Convert.ToInt32(ddlPOnumber.SelectedValue), lbl10.Text, Convert.ToInt32(txt10.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr10.Text, 0);
                                                int iUpdate = dbObj.UpdateUnitQty(Id, lbl10.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt10.Text), ddlbatchstatus.SelectedItem.Text, txtpr10.Text, 0);
                                                lbl10.Visible = false; txt10.Visible = false; txtpr10.Visible = false; btnCalSubmit.Visible = false;
                                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                            }
                                            else if (lbl11.Visible == true)
                                            {


                                                int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl11.Text, Convert.ToInt32(txt11.Text), txtpr11.Text, ddlbatchstatus.SelectedItem.Text, 0);
                                                int Id = 0;
                                                DataSet dsGR = dbObj.GetMax_TransGR();
                                                if (dsGR.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                    {
                                                        Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                    }
                                                    else
                                                    {
                                                        Id = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    Id = 1;
                                                }
                                                DataSet dsTrace = dbObj.GetMax_Traceid();
                                                int TraceId;
                                                if (dsTrace.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                    {
                                                        TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                        TraceId = TraceId + 1;
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    TraceId = 1;
                                                }
                                                int iSuccess1 = dbObj.InsertTransetraceablity(Convert.ToInt32(ddlPOnumber.SelectedValue), lbl11.Text, Convert.ToInt32(txt11.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr11.Text, 0);
                                                int iUpdate = dbObj.UpdateUnitQty(Id, lbl11.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt11.Text), ddlbatchstatus.SelectedItem.Text, txtpr11.Text, 0);
                                                lbl11.Visible = false; txt11.Visible = false; txtpr11.Visible = false; btnCalSubmit.Visible = false;
                                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                            }
                                            else if (lbl12.Visible == true)
                                            {


                                                int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl12.Text, Convert.ToInt32(txt12.Text), txtpr12.Text, ddlbatchstatus.SelectedItem.Text, 0);
                                                int Id = 0;
                                                DataSet dsGR = dbObj.GetMax_TransGR();
                                                if (dsGR.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                    {
                                                        Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                    }
                                                    else
                                                    {
                                                        Id = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    Id = 1;
                                                }
                                                DataSet dsTrace = dbObj.GetMax_Traceid();
                                                int TraceId;
                                                if (dsTrace.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                    {
                                                        TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                        TraceId = TraceId + 1;
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    TraceId = 1;
                                                }
                                                int iSuccess1 = dbObj.InsertTransetraceablity(Convert.ToInt32(ddlPOnumber.SelectedValue), lbl12.Text, Convert.ToInt32(txt12.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr12.Text, Convert.ToInt32(ddlPOnumber.SelectedValue));
                                                int iUpdate = dbObj.UpdateUnitQty(Id, lbl12.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt12.Text), ddlbatchstatus.SelectedItem.Text, txtpr12.Text, Convert.ToInt32(ddlPOnumber.SelectedValue));
                                                lbl12.Visible = false; txt12.Visible = false; txtpr12.Visible = false; btnCalSubmit.Visible = false;
                                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                            }
                                            else if (lbl13.Visible == true)
                                            {


                                                int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl13.Text, Convert.ToInt32(txt13.Text), txtpr13.Text, ddlbatchstatus.SelectedItem.Text, Convert.ToInt32(ddlPOnumber.SelectedValue));
                                                int Id = 0;
                                                DataSet dsGR = dbObj.GetMax_TransGR();
                                                if (dsGR.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                    {
                                                        Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                    }
                                                    else
                                                    {
                                                        Id = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    Id = 1;
                                                }
                                                DataSet dsTrace = dbObj.GetMax_Traceid();
                                                int TraceId;
                                                if (dsTrace.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                    {
                                                        TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                        TraceId = TraceId + 1;
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    TraceId = 1;
                                                }
                                                int iSuccess1 = dbObj.InsertTransetraceablity(Convert.ToInt32(ddlPOnumber.SelectedValue), lbl13.Text, Convert.ToInt32(txt13.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr13.Text, 0);
                                                int iUpdate = dbObj.UpdateUnitQty(Id, lbl13.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt13.Text), ddlbatchstatus.SelectedItem.Text, txtpr13.Text, 0);
                                                lbl13.Visible = false; txt13.Visible = false; txtpr13.Visible = false; btnCalSubmit.Visible = false;
                                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                            }
                                            else if (lbl14.Visible == true)
                                            {


                                                int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl14.Text, Convert.ToInt32(txt14.Text), txtpr14.Text, ddlbatchstatus.SelectedItem.Text, 0);
                                                int Id = 0;
                                                DataSet dsGR = dbObj.GetMax_TransGR();
                                                if (dsGR.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                    {
                                                        Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                    }
                                                    else
                                                    {
                                                        Id = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    Id = 1;
                                                }
                                                DataSet dsTrace = dbObj.GetMax_Traceid();
                                                int TraceId;
                                                if (dsTrace.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                    {
                                                        TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                        TraceId = TraceId + 1;
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    TraceId = 1;
                                                }
                                                int iSuccess1 = dbObj.InsertTransetraceablity(Convert.ToInt32(ddlPOnumber.SelectedValue), lbl14.Text, Convert.ToInt32(txt14.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr14.Text, 0);
                                                int iUpdate = dbObj.UpdateUnitQty(Id, lbl14.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt14.Text), ddlbatchstatus.SelectedItem.Text, txtpr14.Text, 0);
                                                lbl14.Visible = false; txt14.Visible = false; txtpr14.Visible = false; btnCalSubmit.Visible = false;
                                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                            }
                                            else if (lbl15.Visible == true)
                                            {


                                                int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl15.Text, Convert.ToInt32(txt15.Text), txtpr15.Text, ddlbatchstatus.SelectedItem.Text, 0);
                                                int Id = 0;
                                                DataSet dsGR = dbObj.GetMax_TransGR();
                                                if (dsGR.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                    {
                                                        Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                    }
                                                    else
                                                    {
                                                        Id = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    Id = 1;
                                                }
                                                DataSet dsTrace = dbObj.GetMax_Traceid();
                                                int TraceId;
                                                if (dsTrace.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                    {
                                                        TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                        TraceId = TraceId + 1;
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    TraceId = 1;
                                                }
                                                int iSuccess1 = dbObj.InsertTransetraceablity(Convert.ToInt32(ddlPOnumber.SelectedValue), lbl15.Text, Convert.ToInt32(txt15.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr15.Text, 0);
                                                int iUpdate = dbObj.UpdateUnitQty(Id, lbl15.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt5.Text), ddlbatchstatus.SelectedItem.Text, txtpr15.Text, 0);
                                                lbl15.Visible = false; txt15.Visible = false; txtpr15.Visible = false; btnCalSubmit.Visible = false;
                                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                            }
                                            else if (lbl16.Visible == true)
                                            {


                                                int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl16.Text, Convert.ToInt32(txt16.Text), txtpr16.Text, ddlbatchstatus.SelectedItem.Text, 0);
                                                int Id = 0;
                                                DataSet dsGR = dbObj.GetMax_TransGR();
                                                if (dsGR.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                    {
                                                        Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                    }
                                                    else
                                                    {
                                                        Id = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    Id = 1;
                                                }
                                                DataSet dsTrace = dbObj.GetMax_Traceid();
                                                int TraceId;
                                                if (dsTrace.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                    {
                                                        TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                        TraceId = TraceId + 1;
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    TraceId = 1;
                                                }
                                                int iSuccess1 = dbObj.InsertTransetraceablity(Convert.ToInt32(ddlPOnumber.SelectedValue), lbl16.Text, Convert.ToInt32(txt16.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr16.Text, 0);
                                                int iUpdate = dbObj.UpdateUnitQty(Id, lbl16.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt6.Text), ddlbatchstatus.SelectedItem.Text, txtpr16.Text, 0);
                                                lbl16.Visible = false; txt16.Visible = false; txtpr16.Visible = false; btnCalSubmit.Visible = false;
                                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                            }
                                            else if (lbl17.Visible == true)
                                            {


                                                int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl17.Text, Convert.ToInt32(txt17.Text), txtpr17.Text, ddlbatchstatus.SelectedItem.Text, 0);
                                                int Id = 0;
                                                DataSet dsGR = dbObj.GetMax_TransGR();
                                                if (dsGR.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                    {
                                                        Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                    }
                                                    else
                                                    {
                                                        Id = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    Id = 1;
                                                }
                                                DataSet dsTrace = dbObj.GetMax_Traceid();
                                                int TraceId;
                                                if (dsTrace.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                    {
                                                        TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                        TraceId = TraceId + 1;
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    TraceId = 1;
                                                }
                                                int iSuccess1 = dbObj.InsertTransetraceablity(Convert.ToInt32(ddlPOnumber.SelectedValue), lbl17.Text, Convert.ToInt32(txt17.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr17.Text, 0);
                                                int iUpdate = dbObj.UpdateUnitQty(Id, lbl17.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt17.Text), ddlbatchstatus.SelectedItem.Text, txtpr17.Text, 0);
                                                lbl17.Visible = false; txt17.Visible = false; txtpr17.Visible = false; btnCalSubmit.Visible = false;
                                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                            }
                                            else if (lbl18.Visible == true)
                                            {


                                                int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl18.Text, Convert.ToInt32(txt18.Text), txtpr18.Text, ddlbatchstatus.SelectedItem.Text, 0);
                                                int Id = 0;
                                                DataSet dsGR = dbObj.GetMax_TransGR();
                                                if (dsGR.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                    {
                                                        Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                    }
                                                    else
                                                    {
                                                        Id = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    Id = 1;
                                                }
                                                DataSet dsTrace = dbObj.GetMax_Traceid();
                                                int TraceId;
                                                if (dsTrace.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                    {
                                                        TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                        TraceId = TraceId + 1;
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    TraceId = 1;
                                                }
                                                int iSuccess1 = dbObj.InsertTransetraceablity(Convert.ToInt32(ddlPOnumber.SelectedValue), lbl18.Text, Convert.ToInt32(txt18.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr18.Text, 0);
                                                int iUpdate = dbObj.UpdateUnitQty(Id, lbl18.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt18.Text), ddlbatchstatus.SelectedItem.Text, txtpr18.Text, 0);
                                                lbl18.Visible = false; txt18.Visible = false; txtpr18.Visible = false; btnCalSubmit.Visible = false;
                                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                            }
                                            else
                                            {


                                                int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl19.Text, Convert.ToInt32(txt19.Text), txtpr19.Text, ddlbatchstatus.SelectedItem.Text, 0);
                                                int Id = 0;
                                                DataSet dsGR = dbObj.GetMax_TransGR();
                                                if (dsGR.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                    {
                                                        Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                    }
                                                    else
                                                    {
                                                        Id = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    Id = 1;
                                                }
                                                DataSet dsTrace = dbObj.GetMax_Traceid();
                                                int TraceId;
                                                if (dsTrace.Tables[0].Rows.Count > 0)
                                                {
                                                    if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                    {
                                                        TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                        TraceId = TraceId + 1;
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;

                                                    }
                                                }
                                                else
                                                {
                                                    TraceId = 1;
                                                }
                                                int iSuccess1 = dbObj.InsertTransetraceablity(Convert.ToInt32(ddlPOnumber.SelectedValue), lbl19.Text, Convert.ToInt32(txt19.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr19.Text, 0);
                                                int iUpdate = dbObj.UpdateUnitQty(Id, lbl19.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt19.Text), ddlbatchstatus.SelectedItem.Text, txtpr19.Text, 0);
                                                lbl19.Visible = false; txt19.Visible = false; txtpr19.Visible = false; btnCalSubmit.Visible = false;
                                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                            }
                                        }
                                        Response.Redirect("GoodReceiptGrid.aspx");
                                    }
                                    else
                                    {
                                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Unable to Process, Quantity Mismatch!');", true);
                                    }

                                }

                            }
                        }
                        else if (btnSubmit.Text == "Update")
                        {

                            if (!string.IsNullOrEmpty(ddlReturnnumber.SelectedValue) && Convert.ToInt32(ddlReturnnumber.SelectedValue) != 0)
                            {
                                if (txtRecdQty.Text == "0" || txtRecdQty.Text == "")
                                {
                                    string script = "alert('Please Enter the Valid received qty')";
                                    ClientScript.RegisterStartupScript(this.GetType(), "UpdateMessage", script, true);
                                }
                                else
                                {
                                    txtGRNnumber.Text = Convert.ToString(Request.QueryString.Get("GRId"));
                                    DateTime date = DateTime.Now;
                                    if (ddlStatus.Text == "Rejected")
                                    {
                                        int iSuccesss = dbObj.UpdateUnitQtyupdate1(Convert.ToInt32(txtGRNnumber.Text), ddlStatus.Text);
                                        int iSuccesss1 = dbObj.UpdateGRforreject(Convert.ToInt32(txtGRNnumber.Text), Convert.ToInt32(ddlProductid.SelectedValue));
                                        int iSuccesss2 = dbObj.UpdatePO_GoodReceiptforreject(0, Convert.ToInt32(ddlProductid.SelectedValue), Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                        int iSuccesss3 = dbObj.UpdatetblTrancetraceablityforrej(Convert.ToInt32(txtGRNnumber.Text), ddlStatus.SelectedItem.Text);
                                    }
                                    else
                                    {
                                        int txtpallets = Convert.ToInt32(txtPallets.Text);
                                        int txtnewpallet = Convert.ToInt32(txtnewpallets.Text);
                                        int totalpalletes = txtpallets + txtnewpallet;
                                        txtPallets.Text = totalpalletes.ToString();

                                        int qty0 = Convert.ToInt32(txt0.Text); int qty1 = Convert.ToInt32(txt1.Text); int qty2 = Convert.ToInt32(txt2.Text);
                                        int qty3 = Convert.ToInt32(txt3.Text); int qty4 = Convert.ToInt32(txt4.Text); int qty5 = Convert.ToInt32(txt5.Text);
                                        int qty6 = Convert.ToInt32(txt6.Text); int qty7 = Convert.ToInt32(txt7.Text); int qty8 = Convert.ToInt32(txt8.Text);
                                        int qty9 = Convert.ToInt32(txt9.Text); int qty10 = Convert.ToInt32(txt10.Text); int qty11 = Convert.ToInt32(txt11.Text);
                                        int qty12 = Convert.ToInt32(txt12.Text); int qty13 = Convert.ToInt32(txt13.Text); int qty14 = Convert.ToInt32(txt14.Text);
                                        int qty15 = Convert.ToInt32(txt15.Text); int qty16 = Convert.ToInt32(txt16.Text); int qty17 = Convert.ToInt32(txt17.Text);
                                        int qty18 = Convert.ToInt32(txt18.Text); int qty19 = Convert.ToInt32(txt19.Text);
                                        int totalqty = qty0 + qty1 + qty2 + qty3 + qty4 + qty5 + qty6 + qty7 + qty8 + qty9 + qty10 + qty11 + qty12 + qty13 + qty14 + qty15 + qty16 + qty17 + qty18 + qty19;
                                        if (Convert.ToInt32(txtRecdQty.Text) == totalqty)
                                        {
                                            for (int i = 0; i < Convert.ToInt32(txtPallets.Text); i++)
                                            {
                                                if (lbl0.Visible == true)
                                                {

                                                    int iSuccess = dbObj.InsertTransGRedit(Convert.ToInt32(txtGRNnumber.Text), lbl0.Text, Convert.ToInt32(txt0.Text), txtpr0.Text, ddlbatchstatus.SelectedItem.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    int Id = 0;
                                                    DataSet dsGR = dbObj.GetMax_TransGR();
                                                    if (dsGR.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                        {
                                                            Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                        }
                                                        else
                                                        {
                                                            Id = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        Id = 1;
                                                    }

                                                    DataSet dsTrace = dbObj.GetMax_Traceid();
                                                    int TraceId = +1;
                                                    if (dsTrace.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                        {
                                                            TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                            TraceId = TraceId + 1;

                                                        }
                                                        else
                                                        {
                                                            TraceId = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;
                                                    }
                                                    int iSuccess1 = dbObj.InsertTransetraceablityedit(Convert.ToInt32(0), lbl0.Text, Convert.ToInt32(txt0.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr0.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    int iUpdate = dbObj.UpdateUnitQty(Id, lbl0.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt0.Text), ddlbatchstatus.SelectedItem.Text, txtpr0.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    lbl0.Visible = false; txt0.Visible = false; txtpr0.Visible = false; btnCalSubmit.Visible = false;
                                                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);

                                                }
                                                else if (lbl1.Visible == true)
                                                {



                                                    int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl1.Text, Convert.ToInt32(txt1.Text), txtpr1.Text, ddlbatchstatus.SelectedItem.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    int Id = 0;
                                                    DataSet dsGR = dbObj.GetMax_TransGR();
                                                    if (dsGR.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                        {
                                                            Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());


                                                        }
                                                        else
                                                        {
                                                            Id = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        Id = 1;
                                                    }
                                                    DataSet dsTrace = dbObj.GetMax_Traceid();
                                                    int TraceId;
                                                    if (dsTrace.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                        {
                                                            TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                            TraceId = TraceId + 1;
                                                        }
                                                        else
                                                        {
                                                            TraceId = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;
                                                    }
                                                    int iSuccess1 = dbObj.InsertTransetraceablity(Convert.ToInt32(0), lbl1.Text, Convert.ToInt32(txt1.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr1.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    int iUpdate = dbObj.UpdateUnitQty(Id, lbl1.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt1.Text), ddlbatchstatus.SelectedItem.Text, txtpr1.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    lbl1.Visible = false; txt1.Visible = false; txtpr1.Visible = false; btnCalSubmit.Visible = false;
                                                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                                }
                                                else if (lbl2.Visible == true)
                                                {


                                                    int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl2.Text, Convert.ToInt32(txt2.Text), txtpr2.Text, ddlbatchstatus.SelectedItem.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    int Id = 0;
                                                    DataSet dsGR = dbObj.GetMax_TransGR();
                                                    if (dsGR.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                        {
                                                            Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                        }
                                                        else
                                                        {
                                                            Id = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        Id = 1;
                                                    }
                                                    DataSet dsTrace = dbObj.GetMax_Traceid();
                                                    int TraceId;
                                                    if (dsTrace.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                        {
                                                            TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                            TraceId = TraceId + 1;
                                                        }
                                                        else
                                                        {
                                                            TraceId = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;
                                                    }
                                                    int iSuccess1 = dbObj.InsertTransetraceablity(Convert.ToInt32(0), lbl2.Text, Convert.ToInt32(txt2.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr2.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    int iUpdate = dbObj.UpdateUnitQty(Id, lbl2.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt2.Text), ddlbatchstatus.SelectedItem.Text, txtpr2.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    lbl2.Visible = false; txt2.Visible = false; txtpr2.Visible = false; btnCalSubmit.Visible = false;
                                                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                                }
                                                else if (lbl3.Visible == true)
                                                {

                                                    int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl3.Text, Convert.ToInt32(txt3.Text), txtpr3.Text, ddlbatchstatus.SelectedItem.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    int Id = 0;
                                                    DataSet dsGR = dbObj.GetMax_TransGR();
                                                    if (dsGR.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                        {
                                                            Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                        }
                                                        else
                                                        {
                                                            Id = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        Id = 1;
                                                    }

                                                    DataSet dsTrace = dbObj.GetMax_Traceid();
                                                    int TraceId;
                                                    if (dsTrace.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                        {
                                                            TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                            TraceId = TraceId + 1;
                                                        }
                                                        else
                                                        {
                                                            TraceId = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;
                                                    }
                                                    int iSuccess1 = dbObj.InsertTransetraceablity(Convert.ToInt32(0), lbl3.Text, Convert.ToInt32(txt3.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr3.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    int iUpdate = dbObj.UpdateUnitQty(Id, lbl3.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt3.Text), ddlbatchstatus.SelectedItem.Text, txtpr3.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    lbl3.Visible = false; txt3.Visible = false; txtpr3.Visible = false; btnCalSubmit.Visible = false;
                                                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                                }
                                                else if (lbl4.Visible == true)
                                                {


                                                    int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl4.Text, Convert.ToInt32(txt4.Text), txtpr4.Text, ddlbatchstatus.SelectedItem.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    int Id = 0;
                                                    DataSet dsGR = dbObj.GetMax_TransGR();
                                                    if (dsGR.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                        {
                                                            Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                        }
                                                        else
                                                        {
                                                            Id = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        Id = 1;
                                                    }

                                                    DataSet dsTrace = dbObj.GetMax_Traceid();
                                                    int TraceId;
                                                    if (dsTrace.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                        {
                                                            TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                            TraceId = TraceId + 1;
                                                        }
                                                        else
                                                        {
                                                            TraceId = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;
                                                    }
                                                    int iSuccess1 = dbObj.InsertTransetraceablity(Convert.ToInt32(0), lbl4.Text, Convert.ToInt32(txt4.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr4.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    int iUpdate = dbObj.UpdateUnitQty(Id, lbl4.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt4.Text), ddlbatchstatus.SelectedItem.Text, txtpr4.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    lbl4.Visible = false; txt4.Visible = false; txtpr4.Visible = false; btnCalSubmit.Visible = false;
                                                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                                }
                                                else if (lbl5.Visible == true)
                                                {


                                                    int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl5.Text, Convert.ToInt32(txt5.Text), txtpr5.Text, ddlbatchstatus.SelectedItem.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    int Id = 0;
                                                    DataSet dsGR = dbObj.GetMax_TransGR();
                                                    if (dsGR.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                        {
                                                            Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                        }
                                                        else
                                                        {
                                                            Id = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        Id = 1;
                                                    }
                                                    DataSet dsTrace = dbObj.GetMax_Traceid();
                                                    int TraceId;
                                                    if (dsTrace.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                        {
                                                            TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                            TraceId = TraceId + 1;
                                                        }
                                                        else
                                                        {
                                                            TraceId = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;
                                                    }
                                                    int iSuccess1 = dbObj.InsertTransetraceablity(Convert.ToInt32(0), lbl5.Text, Convert.ToInt32(txt5.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr5.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    int iUpdate = dbObj.UpdateUnitQty(Id, lbl5.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt5.Text), ddlbatchstatus.SelectedItem.Text, txtpr5.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    lbl5.Visible = false; txt5.Visible = false; txtpr5.Visible = false; btnCalSubmit.Visible = false;
                                                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                                }
                                                else if (lbl6.Visible == true)
                                                {

                                                    int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl6.Text, Convert.ToInt32(txt6.Text), txtpr6.Text, ddlbatchstatus.SelectedItem.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    int Id = 0;
                                                    DataSet dsGR = dbObj.GetMax_TransGR();
                                                    if (dsGR.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                        {
                                                            Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                        }
                                                        else
                                                        {
                                                            Id = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        Id = 1;
                                                    }

                                                    DataSet dsTrace = dbObj.GetMax_Traceid();
                                                    int TraceId;
                                                    if (dsTrace.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                        {
                                                            TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                            TraceId = TraceId + 1;
                                                        }
                                                        else
                                                        {
                                                            TraceId = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;
                                                    }
                                                    int iSuccess1 = dbObj.InsertTransetraceablity(Convert.ToInt32(0), lbl6.Text, Convert.ToInt32(txt6.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr6.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    int iUpdate = dbObj.UpdateUnitQty(Id, lbl6.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt6.Text), ddlbatchstatus.SelectedItem.Text, txtpr6.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    lbl6.Visible = false; txt6.Visible = false; txtpr6.Visible = false; btnCalSubmit.Visible = false;
                                                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                                }
                                                else if (lbl7.Visible == true)
                                                {

                                                    int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl7.Text, Convert.ToInt32(txt7.Text), txtpr7.Text, ddlbatchstatus.SelectedItem.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    int Id = 0;
                                                    DataSet dsGR = dbObj.GetMax_TransGR();
                                                    if (dsGR.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                        {
                                                            Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                        }
                                                        else
                                                        {
                                                            Id = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        Id = 1;
                                                    }

                                                    DataSet dsTrace = dbObj.GetMax_Traceid();
                                                    int TraceId;
                                                    if (dsTrace.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                        {
                                                            TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                            TraceId = TraceId + 1;
                                                        }
                                                        else
                                                        {
                                                            TraceId = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;
                                                    }
                                                    int iSuccess1 = dbObj.InsertTransetraceablity(Convert.ToInt32(0), lbl7.Text, Convert.ToInt32(txt7.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr7.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    int iUpdate = dbObj.UpdateUnitQty(Id, lbl7.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt7.Text), ddlbatchstatus.SelectedItem.Text, txtpr7.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    lbl7.Visible = false; txt7.Visible = false; txtpr7.Visible = false; btnCalSubmit.Visible = false;
                                                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);

                                                }
                                                else if (lbl8.Visible == true)
                                                {

                                                    int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl8.Text, Convert.ToInt32(txt8.Text), txtpr8.Text, ddlbatchstatus.SelectedItem.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    int Id = 0;
                                                    DataSet dsGR = dbObj.GetMax_TransGR();
                                                    if (dsGR.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                        {
                                                            Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                        }
                                                        else
                                                        {
                                                            Id = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        Id = 1;
                                                    }

                                                    DataSet dsTrace = dbObj.GetMax_Traceid();
                                                    int TraceId;
                                                    if (dsTrace.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                        {
                                                            TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                            TraceId = TraceId + 1;
                                                        }
                                                        else
                                                        {
                                                            TraceId = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;
                                                    }
                                                    int iSuccess1 = dbObj.InsertTransetraceablity(Convert.ToInt32(0), lbl8.Text, Convert.ToInt32(txt8.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr8.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    int iUpdate = dbObj.UpdateUnitQty(Id, lbl8.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt8.Text), ddlbatchstatus.SelectedItem.Text, txtpr8.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    lbl8.Visible = false; txt8.Visible = false; txtpr8.Visible = false; btnCalSubmit.Visible = false;
                                                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                                }
                                                else if (lbl9.Visible == true)
                                                {


                                                    int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl9.Text, Convert.ToInt32(txt9.Text), txtpr9.Text, ddlbatchstatus.SelectedItem.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    int Id = 0;
                                                    DataSet dsGR = dbObj.GetMax_TransGR();
                                                    if (dsGR.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                        {
                                                            Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                        }
                                                        else
                                                        {
                                                            Id = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        Id = 1;
                                                    }
                                                    DataSet dsTrace = dbObj.GetMax_Traceid();
                                                    int TraceId;
                                                    if (dsTrace.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                        {
                                                            TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                            TraceId = TraceId + 1;
                                                        }
                                                        else
                                                        {
                                                            TraceId = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;
                                                    }
                                                    int iSuccess1 = dbObj.InsertTransetraceablity(0, lbl9.Text, Convert.ToInt32(txt9.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr9.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    int iUpdate = dbObj.UpdateUnitQty(Id, lbl9.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt9.Text), ddlbatchstatus.SelectedItem.Text, txtpr9.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    lbl9.Visible = false; txt9.Visible = false; txtpr9.Visible = false; btnCalSubmit.Visible = false;
                                                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                                }
                                                else if (lbl10.Visible == true)
                                                {


                                                    int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl10.Text, Convert.ToInt32(txt10.Text), txtpr10.Text, ddlbatchstatus.SelectedItem.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    int Id = 0;
                                                    DataSet dsGR = dbObj.GetMax_TransGR();
                                                    if (dsGR.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                        {
                                                            Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                        }
                                                        else
                                                        {
                                                            Id = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        Id = 1;
                                                    }
                                                    DataSet dsTrace = dbObj.GetMax_Traceid();
                                                    int TraceId;
                                                    if (dsTrace.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                        {
                                                            TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                            TraceId = TraceId + 1;
                                                        }
                                                        else
                                                        {
                                                            TraceId = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;
                                                    }
                                                    int iSuccess1 = dbObj.InsertTransetraceablity(0, lbl10.Text, Convert.ToInt32(txt10.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr10.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    int iUpdate = dbObj.UpdateUnitQty(Id, lbl10.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt10.Text), ddlbatchstatus.SelectedItem.Text, txtpr10.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    lbl10.Visible = false; txt10.Visible = false; txtpr10.Visible = false; btnCalSubmit.Visible = false;
                                                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                                }
                                                else if (lbl11.Visible == true)
                                                {


                                                    int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl11.Text, Convert.ToInt32(txt11.Text), txtpr11.Text, ddlbatchstatus.SelectedItem.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    int Id = 0;
                                                    DataSet dsGR = dbObj.GetMax_TransGR();
                                                    if (dsGR.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                        {
                                                            Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                        }
                                                        else
                                                        {
                                                            Id = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        Id = 1;
                                                    }
                                                    DataSet dsTrace = dbObj.GetMax_Traceid();
                                                    int TraceId;
                                                    if (dsTrace.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                        {
                                                            TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                            TraceId = TraceId + 1;
                                                        }
                                                        else
                                                        {
                                                            TraceId = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;
                                                    }
                                                    int iSuccess1 = dbObj.InsertTransetraceablity(0, lbl11.Text, Convert.ToInt32(txt11.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr11.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    int iUpdate = dbObj.UpdateUnitQty(Id, lbl11.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt11.Text), ddlbatchstatus.SelectedItem.Text, txtpr11.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    lbl10.Visible = false; txt11.Visible = false; txtpr11.Visible = false; btnCalSubmit.Visible = false;
                                                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                                }
                                                else if (lbl12.Visible == true)
                                                {


                                                    int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl12.Text, Convert.ToInt32(txt12.Text), txtpr12.Text, ddlbatchstatus.SelectedItem.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    int Id = 0;
                                                    DataSet dsGR = dbObj.GetMax_TransGR();
                                                    if (dsGR.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                        {
                                                            Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                        }
                                                        else
                                                        {
                                                            Id = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        Id = 1;
                                                    }
                                                    DataSet dsTrace = dbObj.GetMax_Traceid();
                                                    int TraceId;
                                                    if (dsTrace.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                        {
                                                            TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                            TraceId = TraceId + 1;
                                                        }
                                                        else
                                                        {
                                                            TraceId = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;
                                                    }
                                                    int iSuccess1 = dbObj.InsertTransetraceablity(0, lbl12.Text, Convert.ToInt32(txt12.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr12.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    int iUpdate = dbObj.UpdateUnitQty(Id, lbl12.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt12.Text), ddlbatchstatus.SelectedItem.Text, txtpr12.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    lbl12.Visible = false; txt12.Visible = false; txtpr12.Visible = false; btnCalSubmit.Visible = false;
                                                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                                }
                                                else if (lbl13.Visible == true)
                                                {


                                                    int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl13.Text, Convert.ToInt32(txt13.Text), txtpr13.Text, ddlbatchstatus.SelectedItem.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    int Id = 0;
                                                    DataSet dsGR = dbObj.GetMax_TransGR();
                                                    if (dsGR.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                        {
                                                            Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                        }
                                                        else
                                                        {
                                                            Id = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        Id = 1;
                                                    }
                                                    DataSet dsTrace = dbObj.GetMax_Traceid();
                                                    int TraceId;
                                                    if (dsTrace.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                        {
                                                            TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                            TraceId = TraceId + 1;
                                                        }
                                                        else
                                                        {
                                                            TraceId = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;
                                                    }
                                                    int iSuccess1 = dbObj.InsertTransetraceablity(0, lbl13.Text, Convert.ToInt32(txt13.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr13.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    int iUpdate = dbObj.UpdateUnitQty(Id, lbl13.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt13.Text), ddlbatchstatus.SelectedItem.Text, txtpr13.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    lbl13.Visible = false; txt13.Visible = false; txtpr13.Visible = false; btnCalSubmit.Visible = false;
                                                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                                }
                                                else if (lbl14.Visible == true)
                                                {


                                                    int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl14.Text, Convert.ToInt32(txt14.Text), txtpr14.Text, ddlbatchstatus.SelectedItem.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    int Id = 0;
                                                    DataSet dsGR = dbObj.GetMax_TransGR();
                                                    if (dsGR.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                        {
                                                            Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                        }
                                                        else
                                                        {
                                                            Id = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        Id = 1;
                                                    }
                                                    DataSet dsTrace = dbObj.GetMax_Traceid();
                                                    int TraceId;
                                                    if (dsTrace.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                        {
                                                            TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                            TraceId = TraceId + 1;
                                                        }
                                                        else
                                                        {
                                                            TraceId = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;
                                                    }
                                                    int iSuccess1 = dbObj.InsertTransetraceablity(0, lbl14.Text, Convert.ToInt32(txt14.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr14.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    int iUpdate = dbObj.UpdateUnitQty(Id, lbl14.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt14.Text), ddlbatchstatus.SelectedItem.Text, txtpr14.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    lbl14.Visible = false; txt14.Visible = false; txtpr14.Visible = false; btnCalSubmit.Visible = false;
                                                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                                }
                                                else if (lbl15.Visible == true)
                                                {


                                                    int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl15.Text, Convert.ToInt32(txt15.Text), txtpr15.Text, ddlbatchstatus.SelectedItem.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    int Id = 0;
                                                    DataSet dsGR = dbObj.GetMax_TransGR();
                                                    if (dsGR.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                        {
                                                            Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                        }
                                                        else
                                                        {
                                                            Id = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        Id = 1;
                                                    }
                                                    DataSet dsTrace = dbObj.GetMax_Traceid();
                                                    int TraceId;
                                                    if (dsTrace.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                        {
                                                            TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                            TraceId = TraceId + 1;
                                                        }
                                                        else
                                                        {
                                                            TraceId = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;
                                                    }
                                                    int iSuccess1 = dbObj.InsertTransetraceablity(0, lbl15.Text, Convert.ToInt32(txt15.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr15.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    int iUpdate = dbObj.UpdateUnitQty(Id, lbl15.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt5.Text), ddlbatchstatus.SelectedItem.Text, txtpr15.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    lbl15.Visible = false; txt15.Visible = false; txtpr15.Visible = false; btnCalSubmit.Visible = false;
                                                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                                }
                                                else if (lbl16.Visible == true)
                                                {


                                                    int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl16.Text, Convert.ToInt32(txt16.Text), txtpr16.Text, ddlbatchstatus.SelectedItem.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    int Id = 0;
                                                    DataSet dsGR = dbObj.GetMax_TransGR();
                                                    if (dsGR.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                        {
                                                            Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                        }
                                                        else
                                                        {
                                                            Id = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        Id = 1;
                                                    }
                                                    DataSet dsTrace = dbObj.GetMax_Traceid();
                                                    int TraceId;
                                                    if (dsTrace.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                        {
                                                            TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                            TraceId = TraceId + 1;
                                                        }
                                                        else
                                                        {
                                                            TraceId = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;
                                                    }
                                                    int iSuccess1 = dbObj.InsertTransetraceablity(0, lbl16.Text, Convert.ToInt32(txt16.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr16.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    int iUpdate = dbObj.UpdateUnitQty(Id, lbl16.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt6.Text), ddlbatchstatus.SelectedItem.Text, txtpr16.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    lbl16.Visible = false; txt16.Visible = false; txtpr16.Visible = false; btnCalSubmit.Visible = false;
                                                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                                }
                                                else if (lbl17.Visible == true)
                                                {


                                                    int iSuccess = dbObj.InsertTransGRedit(Convert.ToInt32(txtGRNnumber.Text), lbl17.Text, Convert.ToInt32(txt17.Text), txtpr17.Text, ddlbatchstatus.SelectedItem.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    int Id = 0;
                                                    DataSet dsGR = dbObj.GetMax_TransGR();
                                                    if (dsGR.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                        {
                                                            Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                        }
                                                        else
                                                        {
                                                            Id = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        Id = 1;
                                                    }
                                                    DataSet dsTrace = dbObj.GetMax_Traceid();
                                                    int TraceId;
                                                    if (dsTrace.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                        {
                                                            TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                            TraceId = TraceId + 1;
                                                        }
                                                        else
                                                        {
                                                            TraceId = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;
                                                    }
                                                    int iSuccess1 = dbObj.InsertTransetraceablityedit(0, lbl17.Text, Convert.ToInt32(txt17.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr17.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    int iUpdate = dbObj.UpdateUnitQty(Id, lbl17.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt17.Text), ddlbatchstatus.SelectedItem.Text, txtpr17.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    lbl17.Visible = false; txt17.Visible = false; txtpr17.Visible = false; btnCalSubmit.Visible = false;
                                                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                                }
                                                else if (lbl18.Visible == true)
                                                {


                                                    int iSuccess = dbObj.InsertTransGRedit(Convert.ToInt32(txtGRNnumber.Text), lbl18.Text, Convert.ToInt32(txt18.Text), txtpr18.Text, ddlbatchstatus.SelectedItem.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    int Id = 0;
                                                    DataSet dsGR = dbObj.GetMax_TransGR();
                                                    if (dsGR.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                        {
                                                            Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                        }
                                                        else
                                                        {
                                                            Id = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        Id = 1;
                                                    }
                                                    DataSet dsTrace = dbObj.GetMax_Traceid();
                                                    int TraceId;
                                                    if (dsTrace.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                        {
                                                            TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                            TraceId = TraceId + 1;
                                                        }
                                                        else
                                                        {
                                                            TraceId = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;
                                                    }
                                                    int iSuccess1 = dbObj.InsertTransetraceablityedit(0, lbl18.Text, Convert.ToInt32(txt18.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr18.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    int iUpdate = dbObj.UpdateUnitQty(Id, lbl18.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt18.Text), ddlbatchstatus.SelectedItem.Text, txtpr18.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    lbl18.Visible = false; txt18.Visible = false; txtpr18.Visible = false; btnCalSubmit.Visible = false;
                                                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                                }
                                                else
                                                {


                                                    int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl19.Text, Convert.ToInt32(txt19.Text), txtpr19.Text, ddlbatchstatus.SelectedItem.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    int Id = 0;
                                                    DataSet dsGR = dbObj.GetMax_TransGR();
                                                    if (dsGR.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                        {
                                                            Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                        }
                                                        else
                                                        {
                                                            Id = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        Id = 1;
                                                    }
                                                    DataSet dsTrace = dbObj.GetMax_Traceid();
                                                    int TraceId;
                                                    if (dsTrace.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                        {
                                                            TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                            TraceId = TraceId + 1;
                                                        }
                                                        else
                                                        {
                                                            TraceId = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;
                                                    }
                                                    int iSuccess1 = dbObj.InsertTransetraceablity(0, lbl19.Text, Convert.ToInt32(txt19.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr19.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    int iUpdate = dbObj.UpdateUnitQty(Id, lbl19.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt19.Text), ddlbatchstatus.SelectedItem.Text, txtpr19.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                    lbl19.Visible = false; txt19.Visible = false; txtpr19.Visible = false; btnCalSubmit.Visible = false;
                                                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                                }
                                            }

                                            int iSuccess3 = dbObj.UpdateGR(Convert.ToInt32(txtGRNnumber.Text), 0, Convert.ToInt32(ddlProductid.SelectedValue), txtDosageform.Text, txtStrength.Text, Convert.ToInt32(txtOrderqty.Text), Convert.ToDouble(txtOrderAmount.Text), txtBatch.Text, Convert.ToInt32(txtRecdQty.Text), txtExpDate.Text, Convert.ToInt32(txtPallets.Text), Convert.ToString(ddlbatchstatus.SelectedItem.Text), Convert.ToInt32(ddlSelectapprover.SelectedValue), ddlStatus.SelectedItem.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                            int orderqty = Convert.ToInt32(txtOrderqty.Text);
                                            int recdqty = 0;
                                            DataSet qtycheck = dbObj.Getremcqtyret(Convert.ToInt32(ddlReturnnumber.SelectedValue), Convert.ToInt32(ddlProductid.SelectedValue));
                                            if (qtycheck.Tables[0].Rows.Count > 0)
                                            {
                                                recdqty = Convert.ToInt32(qtycheck.Tables[0].Rows[0]["Qty"].ToString());
                                                if (orderqty == recdqty)
                                                {
                                                    int iSuccess11 = dbObj.UpdatePO_GoodReceipt(0, Convert.ToInt32(ddlProductid.SelectedValue), ddlStatus.SelectedItem.Text, Convert.ToInt32(ddlReturnnumber.SelectedValue));
                                                }
                                            }
                                            int iSuccess15 = dbObj.UpdateTraceablity(0, Convert.ToInt32(ddlProductid.SelectedValue), Convert.ToInt32(txtGRNnumber.Text), txtBatch.Text, Convert.ToInt32(ddlSelectapprover.SelectedValue), Convert.ToInt32(ddlReturnnumber.SelectedValue));


                                        }
                                        else
                                        {
                                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Unable to Process, Quantity Mismatch!');", true);
                                            return;
                                        }

                                    }
                                }

                                //string script = "alert('Data Updated')";
                                //ClientScript.RegisterStartupScript(this.GetType(), "UpdateMessage", script, true);
                                Response.Redirect("GoodReceiptGrid.aspx");
                            }
                            else
                            {
                                if (txtRecdQty.Text == "0" || txtRecdQty.Text == "")
                                {
                                    string script = "alert('Please Enter the Valid received qty')";
                                    ClientScript.RegisterStartupScript(this.GetType(), "UpdateMessage", script, true);
                                }
                                else
                                {
                                    txtGRNnumber.Text = Convert.ToString(Request.QueryString.Get("GRId"));
                                    DateTime date = DateTime.Now;
                                    if (ddlStatus.Text == "Rejected")
                                    {
                                        int iSuccesss = dbObj.UpdateUnitQtyupdate1(Convert.ToInt32(txtGRNnumber.Text), ddlStatus.Text);
                                        int iSuccesss1 = dbObj.UpdateGRforreject(Convert.ToInt32(txtGRNnumber.Text), Convert.ToInt32(ddlProductid.SelectedValue));
                                        int iSuccesss2 = dbObj.UpdatePO_GoodReceiptforreject(0, Convert.ToInt32(ddlProductid.SelectedValue), Convert.ToInt32(ddlPOnumber.SelectedValue));
                                        int iSuccesss3 = dbObj.UpdatetblTrancetraceablityforrej(Convert.ToInt32(txtGRNnumber.Text), ddlStatus.SelectedItem.Text);
                                    }
                                    else
                                    {
                                        int txtpallets = Convert.ToInt32(txtPallets.Text);
                                        int txtnewpallet = Convert.ToInt32(txtnewpallets.Text);
                                        int totalpalletes = txtpallets + txtnewpallet;
                                        txtPallets.Text = totalpalletes.ToString();

                                        int qty0 = Convert.ToInt32(txt0.Text); int qty1 = Convert.ToInt32(txt1.Text); int qty2 = Convert.ToInt32(txt2.Text);
                                        int qty3 = Convert.ToInt32(txt3.Text); int qty4 = Convert.ToInt32(txt4.Text); int qty5 = Convert.ToInt32(txt5.Text);
                                        int qty6 = Convert.ToInt32(txt6.Text); int qty7 = Convert.ToInt32(txt7.Text); int qty8 = Convert.ToInt32(txt8.Text);
                                        int qty9 = Convert.ToInt32(txt9.Text); int qty10 = Convert.ToInt32(txt10.Text); int qty11 = Convert.ToInt32(txt11.Text);
                                        int qty12 = Convert.ToInt32(txt12.Text); int qty13 = Convert.ToInt32(txt13.Text); int qty14 = Convert.ToInt32(txt14.Text);
                                        int qty15 = Convert.ToInt32(txt15.Text); int qty16 = Convert.ToInt32(txt16.Text); int qty17 = Convert.ToInt32(txt17.Text);
                                        int qty18 = Convert.ToInt32(txt18.Text); int qty19 = Convert.ToInt32(txt19.Text);
                                        int totalqty = qty0 + qty1 + qty2 + qty3 + qty4 + qty5 + qty6 + qty7 + qty8 + qty9 + qty10 + qty11 + qty12 + qty13 + qty14 + qty15 + qty16 + qty17 + qty18 + qty19;
                                        if (Convert.ToInt32(txtRecdQty.Text) == totalqty)
                                        {
                                            for (int i = 0; i < Convert.ToInt32(txtPallets.Text); i++)
                                            {
                                                if (lbl0.Visible == true)
                                                {

                                                    int iSuccess = dbObj.InsertTransGRedit(Convert.ToInt32(txtGRNnumber.Text), lbl0.Text, Convert.ToInt32(txt0.Text), txtpr0.Text, ddlbatchstatus.SelectedItem.Text, 0);
                                                    int Id = 0;
                                                    DataSet dsGR = dbObj.GetMax_TransGR();
                                                    if (dsGR.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                        {
                                                            Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                        }
                                                        else
                                                        {
                                                            Id = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        Id = 1;
                                                    }

                                                    DataSet dsTrace = dbObj.GetMax_Traceid();
                                                    int TraceId = +1;
                                                    if (dsTrace.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                        {
                                                            TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                            TraceId = TraceId + 1;

                                                        }
                                                        else
                                                        {
                                                            TraceId = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;
                                                    }
                                                    int iSuccess1 = dbObj.InsertTransetraceablityedit(Convert.ToInt32(ddlPOnumber.SelectedValue), lbl0.Text, Convert.ToInt32(txt0.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr0.Text, 0);
                                                    int iUpdate = dbObj.UpdateUnitQty(Id, lbl0.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt0.Text), ddlbatchstatus.SelectedItem.Text, txtpr0.Text, 0);
                                                    lbl0.Visible = false; txt0.Visible = false; txtpr0.Visible = false; btnCalSubmit.Visible = false;
                                                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);

                                                }
                                                else if (lbl1.Visible == true)
                                                {



                                                    int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl1.Text, Convert.ToInt32(txt1.Text), txtpr1.Text, ddlbatchstatus.SelectedItem.Text, 0);
                                                    int Id = 0;
                                                    DataSet dsGR = dbObj.GetMax_TransGR();
                                                    if (dsGR.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                        {
                                                            Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());


                                                        }
                                                        else
                                                        {
                                                            Id = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        Id = 1;
                                                    }
                                                    DataSet dsTrace = dbObj.GetMax_Traceid();
                                                    int TraceId;
                                                    if (dsTrace.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                        {
                                                            TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                            TraceId = TraceId + 1;
                                                        }
                                                        else
                                                        {
                                                            TraceId = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;
                                                    }
                                                    int iSuccess1 = dbObj.InsertTransetraceablity(Convert.ToInt32(ddlPOnumber.SelectedValue), lbl1.Text, Convert.ToInt32(txt1.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr1.Text, 0);
                                                    int iUpdate = dbObj.UpdateUnitQty(Id, lbl1.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt1.Text), ddlbatchstatus.SelectedItem.Text, txtpr1.Text, 0);
                                                    lbl1.Visible = false; txt1.Visible = false; txtpr1.Visible = false; btnCalSubmit.Visible = false;
                                                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                                }
                                                else if (lbl2.Visible == true)
                                                {


                                                    int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl2.Text, Convert.ToInt32(txt2.Text), txtpr2.Text, ddlbatchstatus.SelectedItem.Text, 0);
                                                    int Id = 0;
                                                    DataSet dsGR = dbObj.GetMax_TransGR();
                                                    if (dsGR.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                        {
                                                            Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                        }
                                                        else
                                                        {
                                                            Id = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        Id = 1;
                                                    }
                                                    DataSet dsTrace = dbObj.GetMax_Traceid();
                                                    int TraceId;
                                                    if (dsTrace.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                        {
                                                            TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                            TraceId = TraceId + 1;
                                                        }
                                                        else
                                                        {
                                                            TraceId = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;
                                                    }
                                                    int iSuccess1 = dbObj.InsertTransetraceablity(Convert.ToInt32(ddlPOnumber.SelectedValue), lbl2.Text, Convert.ToInt32(txt2.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr2.Text, 0);
                                                    int iUpdate = dbObj.UpdateUnitQty(Id, lbl2.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt2.Text), ddlbatchstatus.SelectedItem.Text, txtpr2.Text, 0);
                                                    lbl2.Visible = false; txt2.Visible = false; txtpr2.Visible = false; btnCalSubmit.Visible = false;
                                                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                                }
                                                else if (lbl3.Visible == true)
                                                {

                                                    int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl3.Text, Convert.ToInt32(txt3.Text), txtpr3.Text, ddlbatchstatus.SelectedItem.Text, 0);
                                                    int Id = 0;
                                                    DataSet dsGR = dbObj.GetMax_TransGR();
                                                    if (dsGR.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                        {
                                                            Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                        }
                                                        else
                                                        {
                                                            Id = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        Id = 1;
                                                    }

                                                    DataSet dsTrace = dbObj.GetMax_Traceid();
                                                    int TraceId;
                                                    if (dsTrace.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                        {
                                                            TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                            TraceId = TraceId + 1;
                                                        }
                                                        else
                                                        {
                                                            TraceId = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;
                                                    }
                                                    int iSuccess1 = dbObj.InsertTransetraceablity(Convert.ToInt32(ddlPOnumber.SelectedValue), lbl3.Text, Convert.ToInt32(txt3.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr3.Text, 0);
                                                    int iUpdate = dbObj.UpdateUnitQty(Id, lbl3.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt3.Text), ddlbatchstatus.SelectedItem.Text, txtpr3.Text, 0);
                                                    lbl3.Visible = false; txt3.Visible = false; txtpr3.Visible = false; btnCalSubmit.Visible = false;
                                                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                                }
                                                else if (lbl4.Visible == true)
                                                {


                                                    int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl4.Text, Convert.ToInt32(txt4.Text), txtpr4.Text, ddlbatchstatus.SelectedItem.Text, 0);
                                                    int Id = 0;
                                                    DataSet dsGR = dbObj.GetMax_TransGR();
                                                    if (dsGR.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                        {
                                                            Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                        }
                                                        else
                                                        {
                                                            Id = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        Id = 1;
                                                    }

                                                    DataSet dsTrace = dbObj.GetMax_Traceid();
                                                    int TraceId;
                                                    if (dsTrace.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                        {
                                                            TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                            TraceId = TraceId + 1;
                                                        }
                                                        else
                                                        {
                                                            TraceId = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;
                                                    }
                                                    int iSuccess1 = dbObj.InsertTransetraceablity(Convert.ToInt32(ddlPOnumber.SelectedValue), lbl4.Text, Convert.ToInt32(txt4.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr4.Text, 0);
                                                    int iUpdate = dbObj.UpdateUnitQty(Id, lbl4.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt4.Text), ddlbatchstatus.SelectedItem.Text, txtpr4.Text, 0);
                                                    lbl4.Visible = false; txt4.Visible = false; txtpr4.Visible = false; btnCalSubmit.Visible = false;
                                                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                                }
                                                else if (lbl5.Visible == true)
                                                {


                                                    int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl5.Text, Convert.ToInt32(txt5.Text), txtpr5.Text, ddlbatchstatus.SelectedItem.Text, 0);
                                                    int Id = 0;
                                                    DataSet dsGR = dbObj.GetMax_TransGR();
                                                    if (dsGR.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                        {
                                                            Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                        }
                                                        else
                                                        {
                                                            Id = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        Id = 1;
                                                    }
                                                    DataSet dsTrace = dbObj.GetMax_Traceid();
                                                    int TraceId;
                                                    if (dsTrace.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                        {
                                                            TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                            TraceId = TraceId + 1;
                                                        }
                                                        else
                                                        {
                                                            TraceId = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;
                                                    }
                                                    int iSuccess1 = dbObj.InsertTransetraceablity(Convert.ToInt32(ddlPOnumber.SelectedValue), lbl5.Text, Convert.ToInt32(txt5.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr5.Text, 0);
                                                    int iUpdate = dbObj.UpdateUnitQty(Id, lbl5.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt5.Text), ddlbatchstatus.SelectedItem.Text, txtpr5.Text, 0);
                                                    lbl5.Visible = false; txt5.Visible = false; txtpr5.Visible = false; btnCalSubmit.Visible = false;
                                                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                                }
                                                else if (lbl6.Visible == true)
                                                {

                                                    int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl6.Text, Convert.ToInt32(txt6.Text), txtpr6.Text, ddlbatchstatus.SelectedItem.Text, 0);
                                                    int Id = 0;
                                                    DataSet dsGR = dbObj.GetMax_TransGR();
                                                    if (dsGR.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                        {
                                                            Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                        }
                                                        else
                                                        {
                                                            Id = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        Id = 1;
                                                    }

                                                    DataSet dsTrace = dbObj.GetMax_Traceid();
                                                    int TraceId;
                                                    if (dsTrace.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                        {
                                                            TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                            TraceId = TraceId + 1;
                                                        }
                                                        else
                                                        {
                                                            TraceId = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;
                                                    }
                                                    int iSuccess1 = dbObj.InsertTransetraceablity(Convert.ToInt32(ddlPOnumber.SelectedValue), lbl6.Text, Convert.ToInt32(txt6.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr6.Text, 0);
                                                    int iUpdate = dbObj.UpdateUnitQty(Id, lbl6.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt6.Text), ddlbatchstatus.SelectedItem.Text, txtpr6.Text, 0);
                                                    lbl6.Visible = false; txt6.Visible = false; txtpr6.Visible = false; btnCalSubmit.Visible = false;
                                                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                                }
                                                else if (lbl7.Visible == true)
                                                {

                                                    int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl7.Text, Convert.ToInt32(txt7.Text), txtpr7.Text, ddlbatchstatus.SelectedItem.Text, 0);
                                                    int Id = 0;
                                                    DataSet dsGR = dbObj.GetMax_TransGR();
                                                    if (dsGR.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                        {
                                                            Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                        }
                                                        else
                                                        {
                                                            Id = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        Id = 1;
                                                    }

                                                    DataSet dsTrace = dbObj.GetMax_Traceid();
                                                    int TraceId;
                                                    if (dsTrace.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                        {
                                                            TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                            TraceId = TraceId + 1;
                                                        }
                                                        else
                                                        {
                                                            TraceId = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;
                                                    }
                                                    int iSuccess1 = dbObj.InsertTransetraceablity(Convert.ToInt32(ddlPOnumber.SelectedValue), lbl7.Text, Convert.ToInt32(txt7.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr7.Text, 0);
                                                    int iUpdate = dbObj.UpdateUnitQty(Id, lbl7.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt7.Text), ddlbatchstatus.SelectedItem.Text, txtpr7.Text, 0);
                                                    lbl7.Visible = false; txt7.Visible = false; txtpr7.Visible = false; btnCalSubmit.Visible = false;
                                                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);

                                                }
                                                else if (lbl8.Visible == true)
                                                {

                                                    int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl8.Text, Convert.ToInt32(txt8.Text), txtpr8.Text, ddlbatchstatus.SelectedItem.Text, 0);
                                                    int Id = 0;
                                                    DataSet dsGR = dbObj.GetMax_TransGR();
                                                    if (dsGR.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                        {
                                                            Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                        }
                                                        else
                                                        {
                                                            Id = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        Id = 1;
                                                    }

                                                    DataSet dsTrace = dbObj.GetMax_Traceid();
                                                    int TraceId;
                                                    if (dsTrace.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                        {
                                                            TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                            TraceId = TraceId + 1;
                                                        }
                                                        else
                                                        {
                                                            TraceId = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;
                                                    }
                                                    int iSuccess1 = dbObj.InsertTransetraceablity(Convert.ToInt32(ddlPOnumber.SelectedValue), lbl8.Text, Convert.ToInt32(txt8.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr8.Text, 0);
                                                    int iUpdate = dbObj.UpdateUnitQty(Id, lbl8.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt8.Text), ddlbatchstatus.SelectedItem.Text, txtpr8.Text, 0);
                                                    lbl8.Visible = false; txt8.Visible = false; txtpr8.Visible = false; btnCalSubmit.Visible = false;
                                                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                                }
                                                else if (lbl9.Visible == true)
                                                {


                                                    int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl9.Text, Convert.ToInt32(txt9.Text), txtpr9.Text, ddlbatchstatus.SelectedItem.Text, 0);
                                                    int Id = 0;
                                                    DataSet dsGR = dbObj.GetMax_TransGR();
                                                    if (dsGR.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                        {
                                                            Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                        }
                                                        else
                                                        {
                                                            Id = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        Id = 1;
                                                    }
                                                    DataSet dsTrace = dbObj.GetMax_Traceid();
                                                    int TraceId;
                                                    if (dsTrace.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                        {
                                                            TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                            TraceId = TraceId + 1;
                                                        }
                                                        else
                                                        {
                                                            TraceId = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;
                                                    }
                                                    int iSuccess1 = dbObj.InsertTransetraceablity(Convert.ToInt32(ddlPOnumber.SelectedValue), lbl9.Text, Convert.ToInt32(txt9.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr9.Text, 0);
                                                    int iUpdate = dbObj.UpdateUnitQty(Id, lbl9.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt9.Text), ddlbatchstatus.SelectedItem.Text, txtpr9.Text, 0);
                                                    lbl9.Visible = false; txt9.Visible = false; txtpr9.Visible = false; btnCalSubmit.Visible = false;
                                                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                                }
                                                else if (lbl10.Visible == true)
                                                {


                                                    int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl10.Text, Convert.ToInt32(txt10.Text), txtpr10.Text, ddlbatchstatus.SelectedItem.Text, 0);
                                                    int Id = 0;
                                                    DataSet dsGR = dbObj.GetMax_TransGR();
                                                    if (dsGR.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                        {
                                                            Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                        }
                                                        else
                                                        {
                                                            Id = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        Id = 1;
                                                    }
                                                    DataSet dsTrace = dbObj.GetMax_Traceid();
                                                    int TraceId;
                                                    if (dsTrace.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                        {
                                                            TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                            TraceId = TraceId + 1;
                                                        }
                                                        else
                                                        {
                                                            TraceId = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;
                                                    }
                                                    int iSuccess1 = dbObj.InsertTransetraceablity(Convert.ToInt32(ddlPOnumber.SelectedValue), lbl10.Text, Convert.ToInt32(txt10.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr10.Text, 0);
                                                    int iUpdate = dbObj.UpdateUnitQty(Id, lbl10.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt10.Text), ddlbatchstatus.SelectedItem.Text, txtpr10.Text, 0);
                                                    lbl10.Visible = false; txt10.Visible = false; txtpr10.Visible = false; btnCalSubmit.Visible = false;
                                                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                                }
                                                else if (lbl11.Visible == true)
                                                {


                                                    int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl11.Text, Convert.ToInt32(txt11.Text), txtpr11.Text, ddlbatchstatus.SelectedItem.Text, 0);
                                                    int Id = 0;
                                                    DataSet dsGR = dbObj.GetMax_TransGR();
                                                    if (dsGR.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                        {
                                                            Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                        }
                                                        else
                                                        {
                                                            Id = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        Id = 1;
                                                    }
                                                    DataSet dsTrace = dbObj.GetMax_Traceid();
                                                    int TraceId;
                                                    if (dsTrace.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                        {
                                                            TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                            TraceId = TraceId + 1;
                                                        }
                                                        else
                                                        {
                                                            TraceId = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;
                                                    }
                                                    int iSuccess1 = dbObj.InsertTransetraceablity(Convert.ToInt32(ddlPOnumber.SelectedValue), lbl11.Text, Convert.ToInt32(txt11.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr11.Text, 0);
                                                    int iUpdate = dbObj.UpdateUnitQty(Id, lbl11.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt11.Text), ddlbatchstatus.SelectedItem.Text, txtpr11.Text, 0);
                                                    lbl11.Visible = false; txt11.Visible = false; txtpr11.Visible = false; btnCalSubmit.Visible = false;
                                                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                                }
                                                else if (lbl12.Visible == true)
                                                {


                                                    int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl12.Text, Convert.ToInt32(txt12.Text), txtpr12.Text, ddlbatchstatus.SelectedItem.Text, 0);
                                                    int Id = 0;
                                                    DataSet dsGR = dbObj.GetMax_TransGR();
                                                    if (dsGR.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                        {
                                                            Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                        }
                                                        else
                                                        {
                                                            Id = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        Id = 1;
                                                    }
                                                    DataSet dsTrace = dbObj.GetMax_Traceid();
                                                    int TraceId;
                                                    if (dsTrace.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                        {
                                                            TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                            TraceId = TraceId + 1;
                                                        }
                                                        else
                                                        {
                                                            TraceId = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;
                                                    }
                                                    int iSuccess1 = dbObj.InsertTransetraceablity(Convert.ToInt32(ddlPOnumber.SelectedValue), lbl12.Text, Convert.ToInt32(txt12.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr12.Text, 0);
                                                    int iUpdate = dbObj.UpdateUnitQty(Id, lbl12.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt12.Text), ddlbatchstatus.SelectedItem.Text, txtpr12.Text, 0);
                                                    lbl12.Visible = false; txt12.Visible = false; txtpr12.Visible = false; btnCalSubmit.Visible = false;
                                                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                                }
                                                else if (lbl13.Visible == true)
                                                {


                                                    int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl13.Text, Convert.ToInt32(txt13.Text), txtpr13.Text, ddlbatchstatus.SelectedItem.Text, 0);
                                                    int Id = 0;
                                                    DataSet dsGR = dbObj.GetMax_TransGR();
                                                    if (dsGR.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                        {
                                                            Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                        }
                                                        else
                                                        {
                                                            Id = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        Id = 1;
                                                    }
                                                    DataSet dsTrace = dbObj.GetMax_Traceid();
                                                    int TraceId;
                                                    if (dsTrace.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                        {
                                                            TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                            TraceId = TraceId + 1;
                                                        }
                                                        else
                                                        {
                                                            TraceId = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;
                                                    }
                                                    int iSuccess1 = dbObj.InsertTransetraceablity(Convert.ToInt32(ddlPOnumber.SelectedValue), lbl13.Text, Convert.ToInt32(txt13.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr13.Text, 0);
                                                    int iUpdate = dbObj.UpdateUnitQty(Id, lbl13.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt13.Text), ddlbatchstatus.SelectedItem.Text, txtpr13.Text, 0);
                                                    lbl13.Visible = false; txt13.Visible = false; txtpr13.Visible = false; btnCalSubmit.Visible = false;
                                                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                                }
                                                else if (lbl14.Visible == true)
                                                {


                                                    int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl14.Text, Convert.ToInt32(txt14.Text), txtpr14.Text, ddlbatchstatus.SelectedItem.Text, 0);
                                                    int Id = 0;
                                                    DataSet dsGR = dbObj.GetMax_TransGR();
                                                    if (dsGR.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                        {
                                                            Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                        }
                                                        else
                                                        {
                                                            Id = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        Id = 1;
                                                    }
                                                    DataSet dsTrace = dbObj.GetMax_Traceid();
                                                    int TraceId;
                                                    if (dsTrace.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                        {
                                                            TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                            TraceId = TraceId + 1;
                                                        }
                                                        else
                                                        {
                                                            TraceId = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;
                                                    }
                                                    int iSuccess1 = dbObj.InsertTransetraceablity(Convert.ToInt32(ddlPOnumber.SelectedValue), lbl14.Text, Convert.ToInt32(txt14.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr14.Text, 0);
                                                    int iUpdate = dbObj.UpdateUnitQty(Id, lbl14.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt14.Text), ddlbatchstatus.SelectedItem.Text, txtpr14.Text, 0);
                                                    lbl14.Visible = false; txt14.Visible = false; txtpr14.Visible = false; btnCalSubmit.Visible = false;
                                                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                                }
                                                else if (lbl15.Visible == true)
                                                {


                                                    int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl15.Text, Convert.ToInt32(txt15.Text), txtpr15.Text, ddlbatchstatus.SelectedItem.Text, 0);
                                                    int Id = 0;
                                                    DataSet dsGR = dbObj.GetMax_TransGR();
                                                    if (dsGR.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                        {
                                                            Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                        }
                                                        else
                                                        {
                                                            Id = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        Id = 1;
                                                    }
                                                    DataSet dsTrace = dbObj.GetMax_Traceid();
                                                    int TraceId;
                                                    if (dsTrace.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                        {
                                                            TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                            TraceId = TraceId + 1;
                                                        }
                                                        else
                                                        {
                                                            TraceId = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;
                                                    }
                                                    int iSuccess1 = dbObj.InsertTransetraceablity(Convert.ToInt32(ddlPOnumber.SelectedValue), lbl15.Text, Convert.ToInt32(txt15.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr15.Text, 0);
                                                    int iUpdate = dbObj.UpdateUnitQty(Id, lbl15.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt5.Text), ddlbatchstatus.SelectedItem.Text, txtpr15.Text, 0);
                                                    lbl15.Visible = false; txt15.Visible = false; txtpr15.Visible = false; btnCalSubmit.Visible = false;
                                                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                                }
                                                else if (lbl16.Visible == true)
                                                {


                                                    int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl16.Text, Convert.ToInt32(txt16.Text), txtpr16.Text, ddlbatchstatus.SelectedItem.Text, 0);
                                                    int Id = 0;
                                                    DataSet dsGR = dbObj.GetMax_TransGR();
                                                    if (dsGR.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                        {
                                                            Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                        }
                                                        else
                                                        {
                                                            Id = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        Id = 1;
                                                    }
                                                    DataSet dsTrace = dbObj.GetMax_Traceid();
                                                    int TraceId;
                                                    if (dsTrace.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                        {
                                                            TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                            TraceId = TraceId + 1;
                                                        }
                                                        else
                                                        {
                                                            TraceId = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;
                                                    }
                                                    int iSuccess1 = dbObj.InsertTransetraceablity(Convert.ToInt32(ddlPOnumber.SelectedValue), lbl16.Text, Convert.ToInt32(txt16.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr16.Text, 0);
                                                    int iUpdate = dbObj.UpdateUnitQty(Id, lbl16.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt6.Text), ddlbatchstatus.SelectedItem.Text, txtpr16.Text, 0);
                                                    lbl16.Visible = false; txt16.Visible = false; txtpr16.Visible = false; btnCalSubmit.Visible = false;
                                                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                                }
                                                else if (lbl17.Visible == true)
                                                {


                                                    int iSuccess = dbObj.InsertTransGRedit(Convert.ToInt32(txtGRNnumber.Text), lbl17.Text, Convert.ToInt32(txt17.Text), txtpr17.Text, ddlbatchstatus.SelectedItem.Text, 0);
                                                    int Id = 0;
                                                    DataSet dsGR = dbObj.GetMax_TransGR();
                                                    if (dsGR.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                        {
                                                            Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                        }
                                                        else
                                                        {
                                                            Id = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        Id = 1;
                                                    }
                                                    DataSet dsTrace = dbObj.GetMax_Traceid();
                                                    int TraceId;
                                                    if (dsTrace.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                        {
                                                            TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                            TraceId = TraceId + 1;
                                                        }
                                                        else
                                                        {
                                                            TraceId = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;
                                                    }
                                                    int iSuccess1 = dbObj.InsertTransetraceablityedit(Convert.ToInt32(ddlPOnumber.SelectedValue), lbl17.Text, Convert.ToInt32(txt17.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr17.Text, 0);
                                                    int iUpdate = dbObj.UpdateUnitQty(Id, lbl17.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt17.Text), ddlbatchstatus.SelectedItem.Text, txtpr17.Text, 0);
                                                    lbl17.Visible = false; txt17.Visible = false; txtpr17.Visible = false; btnCalSubmit.Visible = false;
                                                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                                }
                                                else if (lbl18.Visible == true)
                                                {


                                                    int iSuccess = dbObj.InsertTransGRedit(Convert.ToInt32(txtGRNnumber.Text), lbl18.Text, Convert.ToInt32(txt18.Text), txtpr18.Text, ddlbatchstatus.SelectedItem.Text, 0);
                                                    int Id = 0;
                                                    DataSet dsGR = dbObj.GetMax_TransGR();
                                                    if (dsGR.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                        {
                                                            Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                        }
                                                        else
                                                        {
                                                            Id = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        Id = 1;
                                                    }
                                                    DataSet dsTrace = dbObj.GetMax_Traceid();
                                                    int TraceId;
                                                    if (dsTrace.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                        {
                                                            TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                            TraceId = TraceId + 1;
                                                        }
                                                        else
                                                        {
                                                            TraceId = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;
                                                    }
                                                    int iSuccess1 = dbObj.InsertTransetraceablityedit(Convert.ToInt32(ddlPOnumber.SelectedValue), lbl18.Text, Convert.ToInt32(txt18.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr18.Text, 0);
                                                    int iUpdate = dbObj.UpdateUnitQty(Id, lbl18.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt18.Text), ddlbatchstatus.SelectedItem.Text, txtpr18.Text, 0);
                                                    lbl18.Visible = false; txt18.Visible = false; txtpr18.Visible = false; btnCalSubmit.Visible = false;
                                                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                                }
                                                else
                                                {


                                                    int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl19.Text, Convert.ToInt32(txt19.Text), txtpr19.Text, ddlbatchstatus.SelectedItem.Text, 0);
                                                    int Id = 0;
                                                    DataSet dsGR = dbObj.GetMax_TransGR();
                                                    if (dsGR.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                                        {
                                                            Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                                        }
                                                        else
                                                        {
                                                            Id = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        Id = 1;
                                                    }
                                                    DataSet dsTrace = dbObj.GetMax_Traceid();
                                                    int TraceId;
                                                    if (dsTrace.Tables[0].Rows.Count > 0)
                                                    {
                                                        if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                                        {
                                                            TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                                            TraceId = TraceId + 1;
                                                        }
                                                        else
                                                        {
                                                            TraceId = 1;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        TraceId = 1;
                                                    }
                                                    int iSuccess1 = dbObj.InsertTransetraceablity(Convert.ToInt32(ddlPOnumber.SelectedValue), lbl19.Text, Convert.ToInt32(txt19.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr19.Text, 0);
                                                    int iUpdate = dbObj.UpdateUnitQty(Id, lbl19.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt19.Text), ddlbatchstatus.SelectedItem.Text, txtpr19.Text, 0);
                                                    lbl19.Visible = false; txt19.Visible = false; txtpr19.Visible = false; btnCalSubmit.Visible = false;
                                                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Data Stored Successfully');", true);
                                                }
                                            }

                                            int iSuccess3 = dbObj.UpdateGR(Convert.ToInt32(txtGRNnumber.Text), Convert.ToInt32(ddlPOnumber.SelectedValue), Convert.ToInt32(ddlProductid.SelectedValue), txtDosageform.Text, txtStrength.Text, Convert.ToInt32(txtOrderqty.Text), Convert.ToDouble(txtOrderAmount.Text), txtBatch.Text, Convert.ToInt32(txtRecdQty.Text), txtExpDate.Text, Convert.ToInt32(txtPallets.Text), Convert.ToString(ddlbatchstatus.SelectedItem.Text), Convert.ToInt32(ddlSelectapprover.SelectedValue), ddlStatus.SelectedItem.Text, 0);
                                            int orderqty = Convert.ToInt32(txtOrderqty.Text);
                                            int recdqty = 0;
                                            DataSet qtycheck = dbObj.Getremcqty(Convert.ToInt32(ddlPOnumber.SelectedValue), Convert.ToInt32(ddlProductid.SelectedValue));
                                            if (qtycheck.Tables[0].Rows.Count > 0)
                                            {
                                                recdqty = Convert.ToInt32(qtycheck.Tables[0].Rows[0]["Qty"].ToString());
                                                if (orderqty == recdqty)
                                                {
                                                    int iSuccess11 = dbObj.UpdatePO_GoodReceipt(Convert.ToInt32(ddlPOnumber.SelectedValue), Convert.ToInt32(ddlProductid.SelectedValue), ddlStatus.SelectedItem.Text, 0);
                                                }
                                            }
                                            int iSuccess15 = dbObj.UpdateTraceablity(Convert.ToInt32(ddlPOnumber.SelectedValue), Convert.ToInt32(ddlProductid.SelectedValue), Convert.ToInt32(txtGRNnumber.Text), txtBatch.Text, Convert.ToInt32(ddlSelectapprover.SelectedValue), 0);

                                            Response.Redirect("GoodReceiptGrid.aspx");
                                        }
                                        else
                                        {
                                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Unable to Process, Quantity Mismatch!');", true);
                                            return;
                                        }

                                    }
                                }

                                //string script = "alert('Data Updated')";
                                //ClientScript.RegisterStartupScript(this.GetType(), "UpdateMessage", script, true);
                                Response.Redirect("GoodReceiptGrid.aspx");
                                Response.Redirect("GoodReceiptGrid.aspx");
                            }

                        }
                    }
                }
            }
        }

        protected void SelectOrder_TextChanged(object sender, EventArgs e)
        {
            if (SelectOrder.Text == "POOrder")
            {
                poorder.Visible = true;
                DataSet ds = dbObj.select_Po1();
                ddlPOnumber.DataSource = ds;

                ddlPOnumber.DataTextField = "POPrintno";
                ddlPOnumber.DataValueField = "Poid";
                ddlPOnumber.DataBind();
                ddlPOnumber.Items.Insert(0, "Select PO Number");
                SelectOrder.Visible = false;
            }
            else
            {
                returnorder.Visible = true;
                DataSet ds = dbObj.select_Return();
                ddlReturnnumber.DataSource = ds;

                ddlReturnnumber.DataTextField = "ReturnPrintno";
                ddlReturnnumber.DataValueField = "Returnid";
                ddlReturnnumber.DataBind();
                ddlReturnnumber.Items.Insert(0, "Select Return Number");
                SelectOrder.Visible = false;
            }
        }

        protected void ddlReturnnumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds1 = dbObj.select_TransReturnProduct(Convert.ToInt32(ddlReturnnumber.SelectedValue));
            ddlProductid.DataSource = ds1;

            ddlProductid.DataTextField = "Productname";
            ddlProductid.DataValueField = "Productid";
            ddlProductid.DataBind();
            ddlProductid.Items.Insert(0, "Select Productd");

            txtDosageform.Text = "";
            txtOrderqty.Text = "";
            txtRemqty.Text = "";
            txtStrength.Text = "";
            txtStrength.Text = "";
        }

        protected void lbl0_TextChanged(object sender, EventArgs e)
        {
            if (lbl0.Text != "")
            {
                //lbl0.Text=lbl0.Text.ToUpper();
                DataSet Unitname = dbObj.select_CheckUnitname(lbl0.Text);
                if (Unitname.Tables[0].Rows.Count > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lbl0.Text + ",Given Unitname already Have A Product Please change unitname');", true);
                    lbl0.Text = "";
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please Enter Unit name');", true);

            }


        }

        protected void lbl1_TextChanged(object sender, EventArgs e)
        {
            if (lbl1.Text != "")
            {
                if (lbl1.Text == lbl0.Text)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lbl1.Text + ",Given Same Unitname,Please Change Unit name');", true);
                    lbl1.Text = "";
                }
                else
                {
                    DataSet Unitname = dbObj.select_CheckUnitname(lbl1.Text);
                    if (Unitname.Tables[0].Rows.Count > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lbl1.Text + ",Given Unitname already Have A Product Please change unitname');", true);
                        lbl1.Text = "";
                    }
                }

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please Enter Unit name');", true);

            }
        }

        protected void lbl2_TextChanged(object sender, EventArgs e)
        {
            if (lbl2.Text != "")
            {
                if (lbl2.Text == lbl1.Text || lbl2.Text == lbl0.Text)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lbl2.Text + ",Given Same Unitname,Please Change Unit name');", true);
                    lbl2.Text = "";
                }
                else
                {
                    DataSet Unitname = dbObj.select_CheckUnitname(lbl2.Text);
                    if (Unitname.Tables[0].Rows.Count > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lbl2.Text + ",Given Unitname already Have A Product Please change unitname');", true);
                        lbl2.Text = "";
                    }
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please Enter Unit name');", true);

            }
        }

        protected void lbl3_TextChanged(object sender, EventArgs e)
        {
            if (lbl3.Text != "")
            {
                if (lbl3.Text == lbl2.Text || lbl3.Text == lbl1.Text || lbl3.Text == lbl0.Text)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lbl3.Text + ",Given Same Unitname,Please Change Unit name');", true);
                    lbl3.Text = "";
                }
                else
                {
                    DataSet Unitname = dbObj.select_CheckUnitname(lbl3.Text);
                    if (Unitname.Tables[0].Rows.Count > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lbl3.Text + ",Given Unitname already Have A Product Please change unitname');", true);
                        lbl3.Text = "";
                    }
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please Enter Unit name');", true);

            }
        }

        protected void lbl4_TextChanged(object sender, EventArgs e)
        {
            if (lbl4.Text != "")
            {
                if (lbl4.Text == lbl3.Text || lbl4.Text == lbl2.Text || lbl4.Text == lbl1.Text || lbl4.Text == lbl0.Text)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lbl4.Text + ",Given Same Unitname,Please Change Unit name');", true);
                    lbl4.Text = "";
                }
                else
                {
                    DataSet Unitname = dbObj.select_CheckUnitname(lbl4.Text);
                    if (Unitname.Tables[0].Rows.Count > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lbl4.Text + ",Given Unitname already Have A Product Please change unitname');", true);
                        lbl4.Text = "";
                    }
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please Enter Unit name');", true);

            }
        }

        protected void lbl5_TextChanged(object sender, EventArgs e)
        {
            if (lbl5.Text != "")
            {
                if (lbl5.Text == lbl4.Text || lbl5.Text == lbl3.Text || lbl5.Text == lbl2.Text || lbl5.Text == lbl1.Text || lbl5.Text == lbl0.Text)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lbl5.Text + ",Given Same Unitname,Please Change Unit name');", true);
                    lbl5.Text = "";
                }
                else
                {
                    DataSet Unitname = dbObj.select_CheckUnitname(lbl5.Text);
                    if (Unitname.Tables[0].Rows.Count > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lbl5.Text + ",Given Unitname already Have A Product Please change unitname');", true);
                        lbl5.Text = "";
                    }
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please Enter Unit name');", true);

            }
        }

        protected void lbl6_TextChanged(object sender, EventArgs e)
        {
            if (lbl6.Text != "")
            {
                if (lbl6.Text == lbl5.Text || lbl6.Text == lbl4.Text || lbl6.Text == lbl3.Text || lbl6.Text == lbl2.Text || lbl6.Text == lbl1.Text || lbl6.Text == lbl0.Text)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lbl2.Text + ",Given Same Unitname,Please Change Unit name');", true);
                    lbl6.Text = "";
                }
                else
                {
                    DataSet Unitname = dbObj.select_CheckUnitname(lbl6.Text);
                    if (Unitname.Tables[0].Rows.Count > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lbl6.Text + ",Given Unitname already Have A Product Please change unitname');", true);
                        lbl6.Text = "";
                    }
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please Enter Unit name');", true);

            }
        }

        protected void lbl7_TextChanged(object sender, EventArgs e)
        {
            if (lbl7.Text != "")
            {
                if (lbl7.Text == lbl6.Text || lbl7.Text == lbl5.Text || lbl7.Text == lbl4.Text || lbl7.Text == lbl3.Text || lbl7.Text == lbl2.Text || lbl7.Text == lbl1.Text || lbl7.Text == lbl0.Text)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lbl2.Text + ",Given Same Unitname,Please Change Unit name');", true);
                    lbl7.Text = "";
                }
                else
                {
                    DataSet Unitname = dbObj.select_CheckUnitname(lbl7.Text);
                    if (Unitname.Tables[0].Rows.Count > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lbl7.Text + ",Given Unitname already Have A Product Please change unitname');", true);
                        lbl7.Text = "";
                    }
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please Enter Unit name');", true);

            }

        }

        protected void lbl8_TextChanged(object sender, EventArgs e)
        {
            if (lbl8.Text != "")
            {
                if (lbl8.Text == lbl7.Text || lbl8.Text == lbl6.Text || lbl8.Text == lbl5.Text || lbl8.Text == lbl4.Text || lbl8.Text == lbl3.Text || lbl8.Text == lbl2.Text || lbl8.Text == lbl1.Text || lbl8.Text == lbl0.Text)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lbl2.Text + ",Given Same Unitname,Please Change Unit name');", true);
                    lbl8.Text = "";
                }
                else
                {
                    DataSet Unitname = dbObj.select_CheckUnitname(lbl8.Text);
                    if (Unitname.Tables[0].Rows.Count > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lbl8.Text + ",Given Unitname already Have A Product Please change unitname');", true);
                        lbl8.Text = "";
                    }
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please Enter Unit name');", true);

            }
        }

        protected void lbl9_TextChanged(object sender, EventArgs e)
        {
            if (lbl9.Text != "")
            {
                if (lbl9.Text == lbl8.Text || lbl9.Text == lbl7.Text || lbl9.Text == lbl6.Text || lbl9.Text == lbl5.Text || lbl9.Text == lbl4.Text || lbl9.Text == lbl3.Text || lbl9.Text == lbl2.Text || lbl9.Text == lbl1.Text || lbl9.Text == lbl0.Text)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lbl2.Text + ",Given Same Unitname,Please Change Unit name');", true);
                    lbl9.Text = "";
                }
                else
                {
                    DataSet Unitname = dbObj.select_CheckUnitname(lbl9.Text);
                    if (Unitname.Tables[0].Rows.Count > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lbl9.Text + ",Given Unitname already Have A Product Please change unitname');", true);
                        lbl9.Text = "";
                    }
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please Enter Unit name');", true);

            }
        }

        protected void lbl10_TextChanged(object sender, EventArgs e)
        {
            if (lbl10.Text != "")
            {
                if (lbl10.Text == lbl9.Text || lbl10.Text == lbl8.Text || lbl10.Text == lbl7.Text || lbl10.Text == lbl6.Text || lbl10.Text == lbl5.Text || lbl10.Text == lbl4.Text || lbl10.Text == lbl3.Text || lbl10.Text == lbl2.Text || lbl10.Text == lbl1.Text || lbl10.Text == lbl0.Text)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lbl10.Text + ",Given Same Unitname,Please Change Unit name');", true);
                    lbl10.Text = "";
                }
                else
                {
                    DataSet Unitname = dbObj.select_CheckUnitname(lbl10.Text);
                    if (Unitname.Tables[0].Rows.Count > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lbl10.Text + ",Given Unitname already Have A Product Please change unitname');", true);
                        lbl10.Text = "";
                    }
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please Enter Unit name');", true);

            }
        }

        protected void lbl11_TextChanged(object sender, EventArgs e)
        {
            if (lbl11.Text != "")
            {
                if (lbl11.Text == lbl10.Text || lbl11.Text == lbl9.Text || lbl11.Text == lbl8.Text || lbl11.Text == lbl7.Text || lbl11.Text == lbl6.Text || lbl11.Text == lbl5.Text || lbl11.Text == lbl4.Text || lbl11.Text == lbl3.Text || lbl11.Text == lbl2.Text || lbl11.Text == lbl1.Text || lbl11.Text == lbl0.Text)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lbl11.Text + ",Given Same Unitname,Please Change Unit name');", true);
                    lbl11.Text = "";
                }
                else
                {
                    DataSet Unitname = dbObj.select_CheckUnitname(lbl11.Text);
                    if (Unitname.Tables[0].Rows.Count > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lbl11.Text + ",Given Unitname already Have A Product Please change unitname');", true);
                        lbl11.Text = "";
                    }
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please Enter Unit name');", true);

            }
        }

        protected void lbl12_TextChanged(object sender, EventArgs e)
        {
            if (lbl12.Text != "")
            {
                if (lbl12.Text == lbl11.Text || lbl12.Text == lbl10.Text || lbl12.Text == lbl9.Text || lbl12.Text == lbl8.Text || lbl12.Text == lbl7.Text || lbl12.Text == lbl6.Text || lbl12.Text == lbl5.Text || lbl12.Text == lbl4.Text || lbl12.Text == lbl3.Text || lbl12.Text == lbl2.Text || lbl12.Text == lbl1.Text || lbl12.Text == lbl0.Text)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lbl12.Text + ",Given Same Unitname,Please Change Unit name');", true);
                    lbl12.Text = "";
                }
                else
                {
                    DataSet Unitname = dbObj.select_CheckUnitname(lbl12.Text);
                    if (Unitname.Tables[0].Rows.Count > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lbl12.Text + ",Given Unitname already Have A Product Please change unitname');", true);
                        lbl12.Text = "";
                    }
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please Enter Unit name');", true);

            }
        }

        protected void lbl13_TextChanged(object sender, EventArgs e)
        {
            if (lbl13.Text != "")
            {
                if (lbl13.Text == lbl12.Text || lbl13.Text == lbl11.Text || lbl13.Text == lbl10.Text || lbl13.Text == lbl9.Text || lbl13.Text == lbl8.Text || lbl13.Text == lbl7.Text || lbl13.Text == lbl6.Text || lbl13.Text == lbl5.Text || lbl13.Text == lbl4.Text || lbl13.Text == lbl3.Text || lbl13.Text == lbl2.Text || lbl13.Text == lbl1.Text || lbl13.Text == lbl0.Text)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lbl13.Text + ",Given Same Unitname,Please Change Unit name');", true);
                    lbl13.Text = "";
                }
                else
                {
                    DataSet Unitname = dbObj.select_CheckUnitname(lbl13.Text);
                    if (Unitname.Tables[0].Rows.Count > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lbl13.Text + ",Given Unitname already Have A Product Please change unitname');", true);
                        lbl12.Text = "";
                    }
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please Enter Unit name');", true);

            }
        }

        protected void lbl14_TextChanged(object sender, EventArgs e)
        {
            if (lbl14.Text != "")
            {
                if (lbl14.Text == lbl13.Text || lbl14.Text == lbl12.Text || lbl14.Text == lbl11.Text || lbl14.Text == lbl10.Text || lbl14.Text == lbl9.Text || lbl14.Text == lbl8.Text || lbl14.Text == lbl7.Text || lbl14.Text == lbl6.Text || lbl14.Text == lbl5.Text || lbl14.Text == lbl4.Text || lbl14.Text == lbl3.Text || lbl14.Text == lbl2.Text || lbl14.Text == lbl1.Text || lbl14.Text == lbl0.Text)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lbl14.Text + ",Given Same Unitname,Please Change Unit name');", true);
                    lbl14.Text = "";
                }
                else
                {
                    DataSet Unitname = dbObj.select_CheckUnitname(lbl14.Text);
                    if (Unitname.Tables[0].Rows.Count > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lbl14.Text + ",Given Unitname already Have A Product Please change unitname');", true);
                        lbl14.Text = "";
                    }
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please Enter Unit name');", true);

            }
        }

        protected void lbl15_TextChanged(object sender, EventArgs e)
        {
            if (lbl15.Text != "")
            {
                if (lbl15.Text == lbl14.Text || lbl15.Text == lbl13.Text || lbl15.Text == lbl12.Text || lbl15.Text == lbl11.Text || lbl15.Text == lbl10.Text || lbl15.Text == lbl9.Text || lbl15.Text == lbl8.Text || lbl15.Text == lbl7.Text || lbl15.Text == lbl6.Text || lbl15.Text == lbl5.Text || lbl15.Text == lbl4.Text || lbl15.Text == lbl3.Text || lbl15.Text == lbl2.Text || lbl15.Text == lbl1.Text || lbl15.Text == lbl0.Text)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lbl15.Text + ",Given Same Unitname,Please Change Unit name');", true);
                    lbl15.Text = "";
                }
                else
                {
                    DataSet Unitname = dbObj.select_CheckUnitname(lbl15.Text);
                    if (Unitname.Tables[0].Rows.Count > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lbl15.Text + ",Given Unitname already Have A Product Please change unitname');", true);
                        lbl15.Text = "";
                    }
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please Enter Unit name');", true);

            }
        }

        protected void lbl16_TextChanged(object sender, EventArgs e)
        {
            if (lbl16.Text != "")
            {
                if (lbl16.Text == lbl15.Text || lbl16.Text == lbl14.Text || lbl16.Text == lbl13.Text || lbl16.Text == lbl12.Text || lbl16.Text == lbl11.Text || lbl16.Text == lbl10.Text || lbl16.Text == lbl9.Text || lbl16.Text == lbl8.Text || lbl16.Text == lbl7.Text || lbl16.Text == lbl6.Text || lbl16.Text == lbl5.Text || lbl16.Text == lbl4.Text || lbl16.Text == lbl3.Text || lbl16.Text == lbl2.Text || lbl16.Text == lbl1.Text || lbl16.Text == lbl0.Text)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lbl16.Text + ",Given Same Unitname,Please Change Unit name');", true);
                    lbl16.Text = "";
                }
                else
                {
                    DataSet Unitname = dbObj.select_CheckUnitname(lbl16.Text);
                    if (Unitname.Tables[0].Rows.Count > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lbl16.Text + ",Given Unitname already Have A Product Please change unitname');", true);
                        lbl16.Text = "";
                    }
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please Enter Unit name');", true);

            }
        }
        protected void lbl17_TextChanged(object sender, EventArgs e)
        {
            if (lbl17.Text != "")
            {
                if (lbl17.Text == lbl16.Text || lbl17.Text == lbl15.Text || lbl17.Text == lbl14.Text || lbl17.Text == lbl13.Text || lbl17.Text == lbl12.Text || lbl17.Text == lbl11.Text || lbl17.Text == lbl10.Text || lbl16.Text == lbl9.Text || lbl17.Text == lbl8.Text || lbl17.Text == lbl7.Text || lbl17.Text == lbl6.Text || lbl17.Text == lbl5.Text || lbl17.Text == lbl4.Text || lbl17.Text == lbl3.Text || lbl17.Text == lbl2.Text || lbl17.Text == lbl1.Text || lbl17.Text == lbl0.Text)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lbl17.Text + ",Given Same Unitname,Please Change Unit name');", true);
                    lbl17.Text = "";
                }
                else
                {
                    DataSet Unitname = dbObj.select_CheckUnitname(lbl17.Text);
                    if (Unitname.Tables[0].Rows.Count > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lbl17.Text + ",Given Unitname already Have A Product Please change unitname');", true);
                        lbl16.Text = "";
                    }
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please Enter Unit name');", true);

            }
        }

        protected void lbl18_TextChanged(object sender, EventArgs e)
        {
            if (lbl18.Text != "")
            {
                if (lbl18.Text == lbl17.Text || lbl18.Text == lbl16.Text || lbl18.Text == lbl15.Text || lbl18.Text == lbl14.Text || lbl18.Text == lbl13.Text || lbl18.Text == lbl12.Text || lbl18.Text == lbl11.Text || lbl18.Text == lbl10.Text || lbl18.Text == lbl9.Text || lbl18.Text == lbl8.Text || lbl18.Text == lbl7.Text || lbl18.Text == lbl6.Text || lbl18.Text == lbl5.Text || lbl18.Text == lbl4.Text || lbl18.Text == lbl3.Text || lbl18.Text == lbl2.Text || lbl18.Text == lbl1.Text || lbl18.Text == lbl0.Text)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lbl18.Text + ",Given Same Unitname,Please Change Unit name');", true);
                    lbl18.Text = "";
                }
                else
                {
                    DataSet Unitname = dbObj.select_CheckUnitname(lbl18.Text);
                    if (Unitname.Tables[0].Rows.Count > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lbl18.Text + ",Given Unitname already Have A Product Please change unitname');", true);
                        lbl18.Text = "";
                    }
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please Enter Unit name');", true);

            }
        }

        protected void lbl19_TextChanged(object sender, EventArgs e)
        {
            if (lbl19.Text != "")
            {
                if (lbl19.Text == lbl18.Text || lbl19.Text == lbl17.Text || lbl19.Text == lbl16.Text || lbl19.Text == lbl15.Text || lbl19.Text == lbl14.Text || lbl19.Text == lbl13.Text || lbl19.Text == lbl12.Text || lbl19.Text == lbl11.Text || lbl19.Text == lbl10.Text || lbl19.Text == lbl9.Text || lbl19.Text == lbl8.Text || lbl19.Text == lbl7.Text || lbl19.Text == lbl6.Text || lbl19.Text == lbl5.Text || lbl19.Text == lbl4.Text || lbl19.Text == lbl3.Text || lbl19.Text == lbl2.Text || lbl19.Text == lbl1.Text || lbl19.Text == lbl0.Text)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lbl19.Text + ",Given Same Unitname,Please Change Unit name');", true);
                    lbl19.Text = "";
                }
                else
                {
                    DataSet Unitname = dbObj.select_CheckUnitname(lbl19.Text);
                    if (Unitname.Tables[0].Rows.Count > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + lbl19.Text + ",Given Unitname already Have A Product Please change unitname');", true);
                        lbl19.Text = "";
                    }
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please Enter Unit name');", true);

            }
        }

        protected void txtBatch_TextChanged(object sender, EventArgs e)
        {
            DataSet Batchnumber = dbObj.select_CheckBatchnumber(txtBatch.Text);
            if (Batchnumber.Tables[0].Rows.Count > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + txtBatch.Text + ", Given Batch Number Already Stored,Please Change Batch Number ');", true);
                txtBatch.Text = "";
            }
        }

        protected void txtRecdQty_TextChanged(object sender, EventArgs e)
        {

            iGRId = Convert.ToInt32(Request.QueryString.Get("GRId"));
            if (iGRId != 0) 
            {
                int odrqty = Convert.ToInt32(txtOrderqty.Text);
                int rmdqty = Convert.ToInt32(txtRemqty.Text);
                if (odrqty == rmdqty)
                {
                    //txtRecdQty.Text = odrqty.ToString();
                    int receivedqty = Convert.ToInt32(txtRecdQty.Text);
                    if (receivedqty > odrqty)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Your Received Qty : " + txtRecdQty.Text + ", Given received qty is greater then order qty please change received qty ');", true);
                        txtRecdQty.Text = "";
                    }
                    else
                    {

                    }
                }
                else
                {
                    //txtRecdQty.Text = rcdqty.ToString();
                    int receivedqty = Convert.ToInt32(txtRecdQty.Text);
                    if (receivedqty > rmdqty)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Your Received Qty : " + txtRecdQty.Text + ", Given  qty is greater then Remaining qty please change received qty ');", true);
                        txtRecdQty.Text = "";
                    }
                    else
                    {

                    }

                }
            }
            else
            {
                int odrqty = Convert.ToInt32(txtOrderqty.Text);
                int rmdqty = Convert.ToInt32(txtRemqty.Text);
                if (odrqty == rmdqty)
                {
                    //txtRecdQty.Text = odrqty.ToString();
                    int receivedqty = Convert.ToInt32(txtRecdQty.Text);
                    if (receivedqty > odrqty)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Your Received Qty : " + txtRecdQty.Text + ", Given received qty is greater then order qty please change received qty ');", true);
                        txtRecdQty.Text = "";
                    }
                    else
                    {

                    }
                }
                else
                {
                    //txtRecdQty.Text = rcdqty.ToString();
                    int receivedqty = Convert.ToInt32(txtRecdQty.Text);
                    if (receivedqty > rmdqty)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Your Received Qty : " + txtRecdQty.Text + ", Given received qty is greater then Remaining qty please change received qty ');", true);
                        txtRecdQty.Text = "";
                    }
                    else
                    {

                    }

                }
            }
           
        }

        protected void btnAdd11_Click(object sender,EventArgs e)
        {
            iGRId = Convert.ToInt32(Request.QueryString.Get("GRId"));
            if (iGRId != 0)
            {
                List.Visible = true;
                int add = 1;
                DataSet dsUnits1 = dbObj.Select_Units_Green_Number(add);
                if (dsUnits1.Tables[0].Rows.Count > 0)
                {
                    string unitname= dsUnits1.Tables[0].Rows[0]["Unitname"].ToString();
                    if (lbl0.Text == unitname||lbl1.Text== unitname || lbl2.Text == unitname || lbl3.Text == unitname || lbl4.Text == unitname || lbl5.Text == unitname || lbl6.Text == unitname
                         || lbl7.Text == unitname || lbl8.Text == unitname || lbl9.Text == unitname || lbl10.Text == unitname || lbl11.Text == unitname || lbl12.Text == unitname || lbl13.Text == unitname
                          || lbl14.Text == unitname || lbl15.Text == unitname || lbl16.Text == unitname || lbl17.Text == unitname || lbl18.Text == unitname || lbl19.Text == unitname)
                    {
                        DataSet dsUnits2 = dbObj.Select_Units_Green_Numberforedit(add, unitname);
                        if (txt0.Text == "0")
                        {
                            lbl0.Visible = true;
                            txt0.Visible = true;
                            txtpr0.Visible = true;
                            lbl0.Text = dsUnits2.Tables[0].Rows[0]["Unitname"].ToString();
                            btnAdd0.Visible = true;
                            return;
                        }
                        else if (txt1.Text == "0")
                        {

                            lbl1.Visible = true;
                            txt1.Visible = true;
                            txtpr1.Visible = true;
                            lbl1.Text = dsUnits2.Tables[0].Rows[0]["Unitname"].ToString();
                            btnAdd1.Visible = true;
                            btnAdd0.Visible = false;
                            return;

                        }
                        else if (txt2.Text == "0")
                        {

                            lbl2.Visible = true;
                            txt2.Visible = true;
                            txtpr2.Visible = true;
                            lbl2.Text = dsUnits2.Tables[0].Rows[0]["Unitname"].ToString();
                            btnAdd2.Visible = true;
                            btnAdd1.Visible = false;
                            return;
                        }
                        else if (txt3.Text == "0")
                        {

                            lbl3.Visible = true;
                            txt3.Visible = true;
                            txtpr3.Visible = true;
                            lbl3.Text = dsUnits2.Tables[0].Rows[0]["Unitname"].ToString();
                            btnAdd33.Visible = true;
                            btnAdd2.Visible = false;
                        }
                        else if (txt4.Text == "0")
                        {

                            lbl4.Visible = true;
                            txt4.Visible = true;
                            txtpr4.Visible = true;
                            lbl4.Text = dsUnits2.Tables[0].Rows[0]["Unitname"].ToString();
                            btnAdd4.Visible = true;
                            btnAdd33.Visible = false;

                        }
                        else if (txt5.Text == "0")
                        {

                            lbl5.Visible = true;
                            txt5.Visible = true;
                            txtpr5.Visible = true;
                            lbl5.Text = dsUnits2.Tables[0].Rows[0]["Unitname"].ToString();
                            btnAdd5.Visible = true;
                            btnAdd4.Visible = false;
                        }
                        else if (txt6.Text == "0")
                        {

                            lbl6.Visible = true;
                            txt6.Visible = true;
                            txtpr6.Visible = true;
                            lbl6.Text = dsUnits2.Tables[0].Rows[0]["Unitname"].ToString();
                            btnAdd6.Visible = true;
                            btnAdd5.Visible = false;


                        }
                        else if (txt7.Text == "0")
                        {

                            lbl7.Visible = true;
                            txt7.Visible = true;
                            txtpr7.Visible = true;
                            lbl7.Text = dsUnits2.Tables[0].Rows[0]["Unitname"].ToString();
                            btnAdd7.Visible = true;
                            btnAdd6.Visible = false;

                        }
                        else if (txt8.Text == "0")
                        {

                            lbl8.Visible = true;
                            txt8.Visible = true;
                            txtpr8.Visible = true;
                            lbl8.Text = dsUnits2.Tables[0].Rows[0]["Unitname"].ToString();
                            btnAdd8.Visible = true;
                            btnAdd7.Visible = false;

                        }
                        else if (txt9.Text == "0")
                        {

                            lbl9.Visible = true;
                            txt9.Visible = true;
                            txtpr9.Visible = true;
                            lbl9.Text = dsUnits2.Tables[0].Rows[0]["Unitname"].ToString();
                            btnAdd9.Visible = true;
                            btnAdd8.Visible = false;

                        }
                        else if (txt10.Text == "0")
                        {
                            lbl10.Visible = true;
                            txt10.Visible = true;
                            txtpr10.Visible = true;
                            lbl10.Text = dsUnits2.Tables[0].Rows[0]["Unitname"].ToString();
                            btnAdd10.Visible = true;
                            btnAdd9.Visible = false;

                        }
                        else if (txt11.Text == "0")
                        {

                            lbl11.Visible = true;
                            txt11.Visible = true;
                            txtpr11.Visible = true;
                            lbl11.Text = dsUnits2.Tables[0].Rows[0]["Unitname"].ToString();
                            btnAdd11.Visible = true;
                            btnAdd10.Visible = false;


                        }
                        else if (txt12.Text == "0")
                        {

                            lbl12.Visible = true;
                            txt12.Visible = true;
                            txtpr12.Visible = true;
                            lbl12.Text = dsUnits2.Tables[0].Rows[0]["Unitname"].ToString();
                            btnAdd12.Visible = true;
                            btnAdd11.Visible = false;

                        }
                        else if (txt13.Text == "0")
                        {

                            lbl13.Visible = true;
                            txt13.Visible = true;
                            txtpr13.Visible = true;
                            lbl13.Text = dsUnits2.Tables[0].Rows[0]["Unitname"].ToString();
                            btnAdd13.Visible = true;
                            btnAdd12.Visible = false;


                        }
                        else if (txt14.Text == "0")
                        {

                            lbl14.Visible = true;
                            txt14.Visible = true;
                            txtpr14.Visible = true;
                            lbl14.Text = dsUnits2.Tables[0].Rows[0]["Unitname"].ToString();
                            btnAdd14.Visible = true;
                            btnAdd13.Visible = false;

                        }
                        else if (txt15.Text == "0")
                        {

                            lbl15.Visible = true;
                            txt15.Visible = true;
                            txtpr15.Visible = true;
                            lbl15.Text = dsUnits2.Tables[0].Rows[0]["Unitname"].ToString();
                            btnAdd15.Visible = true;
                            btnAdd14.Visible = false;

                        }
                        else if (txt16.Text == "0")
                        {

                            lbl16.Visible = true;
                            txt16.Visible = true;
                            txtpr16.Visible = true;
                            lbl16.Text = dsUnits2.Tables[0].Rows[0]["Unitname"].ToString();
                            btnAdd16.Visible = true;
                            btnAdd15.Visible = false;

                        }
                        else if (txt17.Text == "0")
                        {

                            lbl17.Visible = true;
                            txt17.Visible = true;
                            txtpr17.Visible = true;
                            lbl17.Text = dsUnits2.Tables[0].Rows[0]["Unitname"].ToString();
                            btnAdd17.Visible = true;
                            btnAdd16.Visible = false;

                        }
                        else if (txt18.Text == "0")
                        {

                            lbl18.Visible = true;
                            txt18.Visible = true;
                            txtpr18.Visible = true;
                            lbl18.Text = dsUnits2.Tables[0].Rows[0]["Unitname"].ToString();
                            btnAdd18.Visible = true;
                            btnAdd17.Visible = false;

                        }
                        else
                        {

                            lbl19.Visible = true;
                            txt19.Visible = true;
                            txtpr19.Visible = true;
                            lbl19.Text = dsUnits2.Tables[0].Rows[0]["Unitname"].ToString();
                            btnAdd18.Visible = false;
                        }
                    }
                    else
                    {
                        if (txt0.Text == "0")
                        {
                            lbl0.Visible = true;
                            txt0.Visible = true;
                            txtpr0.Visible = true;
                            lbl0.Text = dsUnits1.Tables[0].Rows[0]["Unitname"].ToString();
                            btnAdd0.Visible = true;
                            return;
                        }
                        else if (txt1.Text == "0")
                        {

                            lbl1.Visible = true;
                            txt1.Visible = true;
                            txtpr1.Visible = true;
                            lbl1.Text = dsUnits1.Tables[0].Rows[0]["Unitname"].ToString();
                            btnAdd1.Visible = true;
                            btnAdd0.Visible = false;
                            return;

                        }
                        else if (txt2.Text == "0")
                        {

                            lbl2.Visible = true;
                            txt2.Visible = true;
                            txtpr2.Visible = true;
                            lbl2.Text = dsUnits1.Tables[0].Rows[0]["Unitname"].ToString();
                            btnAdd2.Visible = true;
                            btnAdd1.Visible = false;
                            return;
                        }
                        else if (txt3.Text == "0")
                        {

                            lbl3.Visible = true;
                            txt3.Visible = true;
                            txtpr3.Visible = true;
                            lbl3.Text = dsUnits1.Tables[0].Rows[0]["Unitname"].ToString();
                            btnAdd33.Visible = true;
                            btnAdd2.Visible = false;
                        }
                        else if (txt4.Text == "0")
                        {

                            lbl4.Visible = true;
                            txt4.Visible = true;
                            txtpr4.Visible = true;
                            lbl4.Text = dsUnits1.Tables[0].Rows[0]["Unitname"].ToString();
                            btnAdd4.Visible = true;
                            btnAdd33.Visible = false;

                        }
                        else if (txt5.Text == "0")
                        {

                            lbl5.Visible = true;
                            txt5.Visible = true;
                            txtpr5.Visible = true;
                            lbl5.Text = dsUnits1.Tables[0].Rows[0]["Unitname"].ToString();
                            btnAdd5.Visible = true;
                            btnAdd4.Visible = false;
                        }
                        else if (txt6.Text == "0")
                        {

                            lbl6.Visible = true;
                            txt6.Visible = true;
                            txtpr6.Visible = true;
                            lbl6.Text = dsUnits1.Tables[0].Rows[0]["Unitname"].ToString();
                            btnAdd6.Visible = true;
                            btnAdd5.Visible = false;


                        }
                        else if (txt7.Text == "0")
                        {

                            lbl7.Visible = true;
                            txt7.Visible = true;
                            txtpr7.Visible = true;
                            lbl7.Text = dsUnits1.Tables[0].Rows[0]["Unitname"].ToString();
                            btnAdd7.Visible = true;
                            btnAdd6.Visible = false;

                        }
                        else if (txt8.Text == "0")
                        {

                            lbl8.Visible = true;
                            txt8.Visible = true;
                            txtpr8.Visible = true;
                            lbl8.Text = dsUnits1.Tables[0].Rows[0]["Unitname"].ToString();
                            btnAdd8.Visible = true;
                            btnAdd7.Visible = false;

                        }
                        else if (txt9.Text == "0")
                        {

                            lbl9.Visible = true;
                            txt9.Visible = true;
                            txtpr9.Visible = true;
                            lbl9.Text = dsUnits1.Tables[0].Rows[0]["Unitname"].ToString();
                            btnAdd9.Visible = true;
                            btnAdd8.Visible = false;

                        }
                        else if (txt10.Text == "0")
                        {
                            lbl10.Visible = true;
                            txt10.Visible = true;
                            txtpr10.Visible = true;
                            lbl10.Text = dsUnits1.Tables[0].Rows[0]["Unitname"].ToString();
                            btnAdd10.Visible = true;
                            btnAdd9.Visible = false;

                        }
                        else if (txt11.Text == "0")
                        {

                            lbl11.Visible = true;
                            txt11.Visible = true;
                            txtpr11.Visible = true;
                            lbl11.Text = dsUnits1.Tables[0].Rows[0]["Unitname"].ToString();
                            btnAdd11.Visible = true;
                            btnAdd10.Visible = false;


                        }
                        else if (txt12.Text == "0")
                        {

                            lbl12.Visible = true;
                            txt12.Visible = true;
                            txtpr12.Visible = true;
                            lbl12.Text = dsUnits1.Tables[0].Rows[0]["Unitname"].ToString();
                            btnAdd12.Visible = true;
                            btnAdd11.Visible = false;

                        }
                        else if (txt13.Text == "0")
                        {

                            lbl13.Visible = true;
                            txt13.Visible = true;
                            txtpr13.Visible = true;
                            lbl13.Text = dsUnits1.Tables[0].Rows[0]["Unitname"].ToString();
                            btnAdd13.Visible = true;
                            btnAdd12.Visible = false;


                        }
                        else if (txt14.Text == "0")
                        {

                            lbl14.Visible = true;
                            txt14.Visible = true;
                            txtpr14.Visible = true;
                            lbl14.Text = dsUnits1.Tables[0].Rows[0]["Unitname"].ToString();
                            btnAdd14.Visible = true;
                            btnAdd13.Visible = false;

                        }
                        else if (txt15.Text == "0")
                        {

                            lbl15.Visible = true;
                            txt15.Visible = true;
                            txtpr15.Visible = true;
                            lbl15.Text = dsUnits1.Tables[0].Rows[0]["Unitname"].ToString();
                            btnAdd15.Visible = true;
                            btnAdd14.Visible = false;

                        }
                        else if (txt16.Text == "0")
                        {

                            lbl16.Visible = true;
                            txt16.Visible = true;
                            txtpr16.Visible = true;
                            lbl16.Text = dsUnits1.Tables[0].Rows[0]["Unitname"].ToString();
                            btnAdd16.Visible = true;
                            btnAdd15.Visible = false;

                        }
                        else if (txt17.Text == "0")
                        {

                            lbl17.Visible = true;
                            txt17.Visible = true;
                            txtpr17.Visible = true;
                            lbl17.Text = dsUnits1.Tables[0].Rows[0]["Unitname"].ToString();
                            btnAdd17.Visible = true;
                            btnAdd16.Visible = false;

                        }
                        else if (txt18.Text == "0")
                        {

                            lbl18.Visible = true;
                            txt18.Visible = true;
                            txtpr18.Visible = true;
                            lbl18.Text = dsUnits1.Tables[0].Rows[0]["Unitname"].ToString();
                            btnAdd18.Visible = true;
                            btnAdd17.Visible = false;

                        }
                        else
                        {

                            lbl19.Visible = true;
                            txt19.Visible = true;
                            txtpr19.Visible = true;
                            lbl19.Text = dsUnits1.Tables[0].Rows[0]["Unitname"].ToString();
                            btnAdd18.Visible = false;
                        }
                    }
                }
                else
                {
                    string script = "alert('Please Select Product Details')";
                    ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                    txtPallets.Text = "";
                }

            }
            }

        protected void txtnewpallets_TextChanged(object sender, EventArgs e)
        {
            txtPallets_TextChanged(sender, e);
            iGRId = Convert.ToInt32(Request.QueryString.Get("GRId"));
            if (iGRId != 0)
            {

                int pallets = Convert.ToInt32(txtnewpallets.Text) - Convert.ToInt32(txtPallets.Text);

                List.Visible = true;
                int add = 1;
                DataSet dsUnits1 = dbObj.Select_Units_Green_Number(Convert.ToInt32(txtnewpallets.Text));
                if (dsUnits1.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i< Convert.ToInt32(txtnewpallets.Text); i++)
                    {
                        if (lbl0.Text == "" )
                        {
                            lbl0.Visible = true;
                            txt0.Visible = true;
                            txtpr0.Visible = true;
                            lbl0.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();
                            //btnAdd0.Visible = true;
                            //return;
                        }
                        else if (lbl1.Text == "")
                        {

                            lbl1.Visible = true;
                            txt1.Visible = true;
                            txtpr1.Visible = true;
                            lbl1.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();
                            //btnAdd1.Visible = true;
                            //btnAdd0.Visible = false;
                            //return;

                        }
                        else if (lbl2.Text == "")
                        {

                            lbl2.Visible = true;
                            txt2.Visible = true;
                            txtpr2.Visible = true;
                            lbl2.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();
                            //btnAdd2.Visible = true;
                            //btnAdd1.Visible = false;
                            //return;
                        }
                        else if (lbl3.Text == "")
                        {

                            lbl3.Visible = true;
                            txt3.Visible = true;
                            txtpr3.Visible = true;
                            lbl3.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();
                            //btnAdd33.Visible = true;
                            //btnAdd2.Visible = false;
                        }
                        else if (lbl4.Text == "")
                        {

                            lbl4.Visible = true;
                            txt4.Visible = true;
                            txtpr4.Visible = true;
                            lbl4.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();
                            //btnAdd4.Visible = true;
                            //btnAdd33.Visible = false;

                        }
                        else if (lbl5.Text == "")
                        {

                            lbl5.Visible = true;
                            txt5.Visible = true;
                            txtpr5.Visible = true;
                            lbl5.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();
                            //btnAdd5.Visible = true;
                            //btnAdd4.Visible = false;
                        }
                        else if (lbl6.Text == "")
                        {

                            lbl6.Visible = true;
                            txt6.Visible = true;
                            txtpr6.Visible = true;
                            lbl6.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();
                            //btnAdd6.Visible = true;
                            //btnAdd5.Visible = false;


                        }
                        else if (lbl7.Text == "")
                        {

                            lbl7.Visible = true;
                            txt7.Visible = true;
                            txtpr7.Visible = true;
                            lbl7.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();
                            //btnAdd7.Visible = true;
                            //btnAdd6.Visible = false;

                        }
                        else if (lbl8.Text == "")
                        {

                            lbl8.Visible = true;
                            txt8.Visible = true;
                            txtpr8.Visible = true;
                            lbl8.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();
                            //btnAdd8.Visible = true;
                            //btnAdd7.Visible = false;

                        }
                        else if (lbl9.Text == "0")
                        {

                            lbl9.Visible = true;
                            txt9.Visible = true;
                            txtpr9.Visible = true;
                            lbl9.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();
                            //btnAdd9.Visible = true;
                            //btnAdd8.Visible = false;

                        }
                        else if (lbl10.Text == "")
                        {
                            lbl10.Visible = true;
                            txt10.Visible = true;
                            txtpr10.Visible = true;
                            lbl10.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();
                            //btnAdd10.Visible = true;
                            //btnAdd9.Visible = false;

                        }
                        else if (lbl11.Text == "")
                        {

                            lbl11.Visible = true;
                            txt11.Visible = true;
                            txtpr11.Visible = true;
                            lbl11.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();
                            //btnAdd11.Visible = true;
                            //btnAdd10.Visible = false;


                        }
                        else if (lbl12.Text == "")
                        {

                            lbl12.Visible = true;
                            txt12.Visible = true;
                            txtpr12.Visible = true;
                            lbl12.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();
                            //btnAdd12.Visible = true;
                            //btnAdd11.Visible = false;

                        }
                        else if (lbl13.Text == "")
                        {

                            lbl13.Visible = true;
                            txt13.Visible = true;
                            txtpr13.Visible = true;
                            lbl13.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();
                            //btnAdd13.Visible = true;
                            //btnAdd12.Visible = false;


                        }
                        else if (lbl14.Text == "")
                        {

                            lbl14.Visible = true;
                            txt14.Visible = true;
                            txtpr14.Visible = true;
                            lbl14.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();
                            //btnAdd14.Visible = true;
                            //btnAdd13.Visible = false;

                        }
                        else if (lbl15.Text == "")
                        {

                            lbl15.Visible = true;
                            txt15.Visible = true;
                            txtpr15.Visible = true;
                            lbl15.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();
                            //btnAdd15.Visible = true;
                            //btnAdd14.Visible = false;

                        }
                        else if (lbl16.Text == "")
                        {

                            lbl16.Visible = true;
                            txt16.Visible = true;
                            txtpr16.Visible = true;
                            lbl16.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();
                            //btnAdd16.Visible = true;
                            //btnAdd15.Visible = false;

                        }
                        else if (lbl17.Text == "")
                        {

                            lbl17.Visible = true;
                            txt17.Visible = true;
                            txtpr17.Visible = true;
                            lbl17.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();
                            //btnAdd17.Visible = true;
                            //btnAdd16.Visible = false;

                        }
                        else if (lbl18.Text == "")
                        {

                            lbl18.Visible = true;
                            txt18.Visible = true;
                            txtpr18.Visible = true;
                            lbl18.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();
                            //btnAdd18.Visible = true;
                            //btnAdd17.Visible = false;

                        }
                        else
                        {

                            lbl19.Visible = true;
                            txt19.Visible = true;
                            txtpr19.Visible = true;
                            lbl19.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();
                           // btnAdd18.Visible = false;
                        }
                    }
                }
                else
                {
                    string script = "alert('Please Select Product Details')";
                    ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                    txtPallets.Text = "";
                }

            }
        }

        protected void btnClearUnit_Click(object sender, EventArgs e)
        {
            if (txtClearunitname.Text != "")
            {
                DataSet dsunitname = dbObj.Checkunitname(txtClearunitname.Text);
                if (dsunitname.Tables[0].Rows.Count > 0)
                {
                    int isuccess = dbObj.ClearUnitvalue(txtClearunitname.Text);
                    string script = "alert('Unitname : " + txtClearunitname.Text + ",Cleared warehouse values')";
                    ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                    txtClearunitname.Text = "";
                }
                else
                {
                    string script = "alert('Unitname : "+txtClearunitname.Text+",Not available in this warehouse please  change unitname')";
                    ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                }
            }
            else
            {
                string script = "alert('Please Enter Unitname')";
                ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
            }
        }
    }
}