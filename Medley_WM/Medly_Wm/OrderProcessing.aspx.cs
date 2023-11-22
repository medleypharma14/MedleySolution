using BusinessLayer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace Medly_Wm
{
    public partial class OrderGoodsPicking1 : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
        int iSOid; int iProId; int OrderQty;int SuppId; int Sentqty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                iSOid = Convert.ToInt32(Request.QueryString.Get("SoID"));
                iProId = Convert.ToInt32(Request.QueryString.Get("ProId"));
                OrderQty = Convert.ToInt32(Request.QueryString.Get("SoQty"));
                SuppId = Convert.ToInt32(Request.QueryString.Get("SuppId"));
                Sentqty = Convert.ToInt32(Request.QueryString.Get("SentQty"));
                ViewState["Sentqty"] = Sentqty;
                #region Load GR 
                DataSet dsPO = new DataSet();
                dsPO = dbObj.SelectProducts_UnitsAvailable(iSOid, iProId,Sentqty);
                string batchnumber = dsPO.Tables[0].Rows.Count.ToString("Batchnumber");
                if (dsPO.Tables[0].Rows.Count > 0)
                {
                    txtRemaining.Text = dsPO.Tables[0].Rows[0]["remaining"].ToString();
                    gvPo.DataSource = dsPO.Tables[0];
                    gvPo.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('No Stock available or Set Status to Release!');", true);
                }
                #endregion
                txtSOnumber.Text = iSOid.ToString();
                txtSOnumber.Enabled = false;
                txtQty.Enabled = false;
                txtQty.Text = OrderQty.ToString();
                txtSuppid.Text = SuppId.ToString();

                #region Dropdown Transpot
                DataSet dstranspot = new DataSet();
                dstranspot = dbObj.Select_Transpotname();
                if (dstranspot.Tables[0].Rows.Count > 0)
                {
                    ddltranscmp.DataSource = dstranspot;
                    ddltranscmp.DataTextField = "transpot";
                    ddltranscmp.DataValueField = "id";
                    ddltranscmp.DataBind();
                    ddltranscmp.Items.Insert(0, "Select Transpot");
                }
                #endregion
                txtQty_TextChanged(sender, e);
            }

        }
        private void BindPo()
        {
            DataSet dsPO = new DataSet();
            // dsPO = dbObj.Selectgoodrecieporder();
            dsPO = dbObj.SelectProducts_UnitsAvailable(iSOid, iProId,Convert.ToInt32(ViewState["Sentqty"]));
          
            if (dsPO.Tables[0].Rows.Count > 0)
            {
                gvPo.DataSource = dsPO.Tables[0];
                gvPo.DataBind();
            }
        }
        protected void gvPo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            DataSet ds = new DataSet();
            //if (e.CommandName == "edit")
            //{
            //    Response.Redirect("SupplierMaster.aspx?Event=Edit&Supid=" + e.CommandArgument.ToString());

            //}
            if (e.CommandName == "Del")
            {
                int iPoid = Convert.ToInt32(e.CommandArgument);
                dbObj.deletePoGrid(iPoid);
                BindPo();
            }

        }
        protected void txtQty_TextChanged(object sender, EventArgs e)
        {
            double adtotal=0;
            double adtotal1 = 0;
            if (txtQty.Text == "0" || txtRemaining.Text == "")
            {
               adtotal = 0;
                adtotal1 = 0;
            }
            else
            {


                if (txtQty.Text == txtRemaining.Text)
                {
                    adtotal = Convert.ToDouble(txtQty.Text);

                }
                else
                {
                    adtotal1 = Convert.ToDouble(txtRemaining.Text);

                }

                if (gvPo.Rows.Count > 0)
                {
                    DataTable dttt;
                    DataRow drNew;
                    DataColumn dct;
                    DataSet dstd = new DataSet();
                    dttt = new DataTable();

                    dct = new DataColumn("ProductId");
                    //dct = new DataColumn(Convert.ToString(iProId));
                    dttt.Columns.Add(dct);

                    dct = new DataColumn("Productname");
                    dttt.Columns.Add(dct);

                    dct = new DataColumn("remaining");
                    dttt.Columns.Add(dct);

                    dct = new DataColumn("Batchnumber");
                    dttt.Columns.Add(dct);

                    dct = new DataColumn("Unitname");
                    dttt.Columns.Add(dct);

                    dct = new DataColumn("TotalQty");
                    dttt.Columns.Add(dct);

                    dct = new DataColumn("Palletsrefno");
                    dttt.Columns.Add(dct);

                    dct = new DataColumn("ExpiryDate");
                    dttt.Columns.Add(dct);

                    dct = new DataColumn("Qty");
                    dttt.Columns.Add(dct);

                    dstd.Tables.Add(dttt);

                    for (int vLoop = 0; vLoop < gvPo.Rows.Count; vLoop++)
                    {
                        Label txtProductId = (Label)gvPo.Rows[vLoop].FindControl("txtProductId");
                        // Label txtProductId = (Label)gvPo.Rows[vLoop].FindControl("iProId");
                        Label txtProductname = (Label)gvPo.Rows[vLoop].FindControl("txtProductname");
                        Label txtSOQty = (Label)gvPo.Rows[vLoop].FindControl("txtSOQty");
                        Label txtbatchnumber = (Label)gvPo.Rows[vLoop].FindControl("txtbatchnumber");
                        Label txtUnitname = (Label)gvPo.Rows[vLoop].FindControl("txtUnitname");
                        Label txtTotalQty = (Label)gvPo.Rows[vLoop].FindControl("txtTotalQty");
                        Label txtPalletsrefno = (Label)gvPo.Rows[vLoop].FindControl("txtPalletsref");
                        Label txtExpiryDate = (Label)gvPo.Rows[vLoop].FindControl("txtExpiryDate");
                        TextBox txtremarks = (TextBox)gvPo.Rows[vLoop].FindControl("txtremarks");


                        drNew = dttt.NewRow();
                        drNew["ProductId"] = txtProductId.Text;
                        drNew["Productname"] = txtProductname.Text;
                        drNew["remaining"] = txtSOQty.Text;
                        drNew["Batchnumber"] = txtbatchnumber.Text;
                        drNew["Unitname"] = txtUnitname.Text;
                        drNew["TotalQty"] = txtTotalQty.Text;
                        drNew["Palletsrefno"] = txtPalletsrefno.Text;
                        drNew["ExpiryDate"] = Convert.ToDateTime(txtExpiryDate.Text).ToString("dd/MM/yyyy");

                        if (txtQty.Text == txtRemaining.Text)
                        {
                            if (adtotal > Convert.ToDouble(txtTotalQty.Text))
                            {
                                drNew["Qty"] = Convert.ToDouble(txtTotalQty.Text);
                                adtotal = adtotal - Convert.ToDouble(txtTotalQty.Text);
                            }
                            else if (adtotal < Convert.ToDouble(txtTotalQty.Text))
                            {
                                drNew["Qty"] = adtotal;
                                adtotal = 0;
                            }
                            else if (adtotal == Convert.ToDouble(txtTotalQty.Text))
                            {
                                drNew["Qty"] = adtotal;
                                adtotal = 0;
                            }
                        }
                        else
                        {
                            if (adtotal1 > Convert.ToDouble(txtTotalQty.Text))
                            {
                                drNew["Qty"] = Convert.ToDouble(txtTotalQty.Text);
                                adtotal1 = adtotal1 - Convert.ToDouble(txtTotalQty.Text);
                            }
                            else if (adtotal1 < Convert.ToDouble(txtTotalQty.Text))
                            {
                                drNew["Qty"] = adtotal1;
                                adtotal1 = 0;
                            }
                            else if (adtotal1 == Convert.ToDouble(txtTotalQty.Text))
                            {
                                drNew["Qty"] = adtotal1;
                                adtotal1 = 0;
                            }
                        }



                        dstd.Tables[0].Rows.Add(drNew);
                    }
                    gvPo.DataSource = dstd;
                    gvPo.DataBind();
                }
                else
                {
                    gvPo.DataSource = null;
                    gvPo.DataBind();
                }
            }
            //txtNarration.Focus();
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string sToday = DateTime.Today.ToString("dd/MM/yyyy");
            
            
            int isuccess = dbObj.InsertGPN(DateTime.Parse(sToday), Convert.ToInt32(txtSOnumber.Text), Convert.ToInt32(txtSuppid.Text), Convert.ToInt32(txtQty.Text));
            DataSet ds = dbObj.MaxGPN();
            int GPNID = Convert.ToInt32(ds.Tables[0].Rows[0]["Id"].ToString());
            //for (int i = 0; i <= gvPo.Rows.Count; i++)
            //{
            //    int ProdId = Convert.ToInt32(gvPo.Rows[i].Cells[1].Text);
            //    int Packsize = Convert.ToInt32(gvPo.Rows[i].Cells[3].Text);
            //    int PPP = Convert.ToInt32(gvPo.Rows[i].Cells[4].Text);
            //    TextBox txtQty = (TextBox)gvPo.FindControl("txtqty");
            //    int Qty = Convert.ToInt32(txtQty.Text);
            //    int VAT = Convert.ToInt32(gvPo.Rows[i].Cells[5].Text);
            //    double Amt = Convert.ToInt32(gvPo.Rows[i].Cells[8].Text);
            //    string Batch = gvPo.Rows[i].Cells[6].Text;
            //    string Unit =gvPo.Rows[i].Cells[7].Text;

                for (int vLoop = 0; vLoop < gvPo.Rows.Count; vLoop++)
                {
                    Label txtProductId = (Label)gvPo.Rows[vLoop].FindControl("txtProductId");
                    Label txtProductname = (Label)gvPo.Rows[vLoop].FindControl("txtProductname");
                    Label txtSOQty = (Label)gvPo.Rows[vLoop].FindControl("txtSOQty");
                    Label txtbatchnumber = (Label)gvPo.Rows[vLoop].FindControl("txtbatchnumber");
                    Label txtUnitname = (Label)gvPo.Rows[vLoop].FindControl("txtUnitname");
                    Label txtTotalQty = (Label)gvPo.Rows[vLoop].FindControl("txtTotalQty");
                    Label txtPalletsrefno = (Label)gvPo.Rows[vLoop].FindControl("txtPalletsref");
                    Label txtExpiryDate = (Label)gvPo.Rows[vLoop].FindControl("txtExpiryDate");
                    TextBox txtremarks = (TextBox)gvPo.Rows[vLoop].FindControl("txtremarks");

                    int isuccess1 = dbObj.InsertTransGPN(GPNID, Convert.ToInt32(txtProductId.Text), 0, Convert.ToInt32(txtremarks.Text), 0, 0, 0,txtbatchnumber.Text, txtUnitname.Text, txtPalletsrefno.Text,txtExpiryDate.Text);
                //int FinalBatchQty = Convert.ToInt32(txtremarks.Text) - Convert.ToInt32(txtTotalQty.Text);
                int FinalBatchQty = Convert.ToInt32(txtTotalQty.Text) - Convert.ToInt32(txtremarks.Text);
                int status = 0;
                if (FinalBatchQty == 0)
                {
                    status = 1;
                    int iSuccess3 = dbObj.UpdateUnitvalue1(txtUnitname.Text, FinalBatchQty.ToString(), status);
                }
                else
                {
                    int iSuccess3 = dbObj.UpdateUnitvalue(txtUnitname.Text, FinalBatchQty.ToString(), status);
                }
                int iSuccess5 = dbObj.Updatetrancegrforgp(txtUnitname.Text, FinalBatchQty.ToString());
                int isuccess2 = dbObj.Updatetraceablity(GPNID, Convert.ToInt32(txtSOnumber.Text), 0, txtbatchnumber.Text);
                int isuccess4 = dbObj.UpdateTrancetraceablity(FinalBatchQty,txtUnitname.Text);
                DataSet Dispatch = dbObj.checkDispatchdtails(txtSOnumber.Text, txtProductId.Text);
                if (Dispatch.Tables[0].Rows.Count > 0)
                {
                    int sentQty =Convert.ToInt32(Dispatch.Tables[0].Rows[0]["SoQty"].ToString());
                    int PickQty =Convert.ToInt32(Dispatch.Tables[0].Rows[0]["PickeQty"].ToString());
                    if (sentQty == PickQty)
                    {
                         int isuccess6 = dbObj.UpdateDipatchinsales(txtSOnumber.Text, txtProductId.Text);
                    }
                    else
                    {

                    }

                }



            }
            string script = "alert('Order Picked')";
            ClientScript.RegisterStartupScript(this.GetType(), "UpdateMessage", script, true);
            Response.Redirect("GoodSending.aspx");
        }
    }
}