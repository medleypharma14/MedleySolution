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
    public partial class PurchaseOrder : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
        int iPoid = 0;
        int iProductID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string controlId = "Del";
                string validationArgument = "grvCreatePo_RowCommand";
                Page.ClientScript.RegisterForEventValidation(controlId, validationArgument);

                txtPodate.Text = DateTime.Now.ToString("yyyy-MM-dd");
               string todaydate =DateTime.Now.ToString("yyyy-MM-dd");

                #region Edit
                iPoid = Convert.ToInt32(Request.QueryString.Get("Poid"));

                if (iPoid != 0)
                {

                    DataSet dsPoid = new DataSet();
                    dsPoid = dbObj.selectPO_byPOid(iPoid);
                    ViewState["vsPoid"] = iPoid;

                    if (dsPoid.Tables[0].Rows.Count > 0)
                    {
                        txtLicenseno.Text = dsPoid.Tables[0].Rows[0]["Licenseno"].ToString();
                        txtProductname.Text = dsPoid.Tables[0].Rows[0]["Productname"].ToString();
                        txtDosageform.Text = dsPoid.Tables[0].Rows[0]["Dosageform"].ToString();
                        txtStrength.Text = dsPoid.Tables[0].Rows[0]["Strength"].ToString();
                        txtPacktype.Text = dsPoid.Tables[0].Rows[0]["Packtype"].ToString();
                        txtPacksize.Text = dsPoid.Tables[0].Rows[0]["Packsize"].ToString();
                        txtPoqty.Text = dsPoid.Tables[0].Rows[0]["PoQty"].ToString();
                        txtPriceperpack.Text = dsPoid.Tables[0].Rows[0]["Priceperpack"].ToString();
                        txtproductamt.Text = dsPoid.Tables[0].Rows[0]["Productamt"].ToString();
                        btnSubmit.Text = "Update";
                    }
                }
                #endregion
            }
            if (!IsPostBack)
            {
                string todaydate = DateTime.Now.ToString("yyyy-MM-dd");
                DataSet ds = dbObj.getSuppliername(todaydate);
                ddlSuppliername.DataSource = ds;

                ddlSuppliername.DataTextField = "ContactName";
                ddlSuppliername.DataValueField = "SupplierID";
                ddlSuppliername.DataBind();
                ddlSuppliername.Items.Insert(0, "Select SupplierName");

            }
            if (!IsPostBack)
            {
                DataSet ds = dbObj.getProductname();
                ddlProductname.DataSource = ds;

                ddlProductname.DataTextField = "Productname";
                ddlProductname.DataValueField = "ProductID";
                ddlProductname.DataBind();
                ddlProductname.Items.Insert(0, "Productname");

            }

            #region product details


            #endregion

            #region LoadGrid CreatePO

            DataSet dscreatpo = new DataSet();
            dscreatpo = dbObj.Select_CreatePO();
            if (dscreatpo.Tables[0].Rows.Count > 0)
            {
                grvCreatePo.DataSource = dscreatpo.Tables[0];
                grvCreatePo.DataBind();
            }
            #endregion


        }


        protected void btnAddrows_Click(object sender, EventArgs e)
        {
            int isucess = 0;
           // isucess = dbObj.InsertProducts(Convert.ToInt32(ddlProductname.Text),txtProductname.Text, txtDosageform.Text, txtStrength.Text, txtPoqty.Text, txtPriceperpack.Text,txtva, txtproductamt.Text);
            string script = "alert('Row added')";
            ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
            DataSet dscreatpo = new DataSet();
            dscreatpo = dbObj.Select_CreatePO();
            if (dscreatpo.Tables[0].Rows.Count > 0)
            {
                grvCreatePo.DataSource = dscreatpo.Tables[0];
                grvCreatePo.DataBind();
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int isucess = 0;

           // isucess = dbObj.InsertDetails(ddlSuppliername.SelectedValue, DateTime.Parse(txtPodate.Text), ddlSelectapprover.SelectedItem,ddl, txtTotalpoamount.Text);

            #region GetMAxPO
            DataSet dsPO = dbObj.GetMaxPO();
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
                    string Packtype = dsTempPO.Tables[0].Rows[i]["Packtype"].ToString();
                    string Packsize = dsTempPO.Tables[0].Rows[i]["Packsize"].ToString();
                    string Packqty = dsTempPO.Tables[0].Rows[i]["PoQty"].ToString();
                    string Priceperpack = dsTempPO.Tables[0].Rows[i]["Priceperpack"].ToString();
                    string VAT = dsTempPO.Tables[0].Rows[i]["VAT"].ToString();
                    string Productamnt = dsTempPO.Tables[0].Rows[i]["Productamt"].ToString();
                    int iSuccess1 = dbObj.InsertTransPOProducts(iPOMax, Convert.ToInt32(productname), Licenseno, Productname, Dosageform, Strength, Packqty, Priceperpack, VAT, Productamnt);
                }
            }
            #endregion
            #region Clear Temp Table
            int iDelete = dbObj.ClearTempPO();
            #endregion

            string script = "alert('Row added')";
            ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
            Response.Redirect("POGrid.aspx");

        }

        protected void ddlProductname_SelectedIndexChanged(object sender, EventArgs e)
        {



            DataSet dsProdId = new DataSet();
            dsProdId = dbObj.selectProduct_byProductId(Convert.ToInt32(ddlProductname.SelectedValue));
            ViewState["vsPrdct"] = iProductID;

            if (dsProdId.Tables[0].Rows.Count > 0)
            {
                txtLicenseno.Text = dsProdId.Tables[0].Rows[0]["Licenseno"].ToString();
                txtProductname.Text = dsProdId.Tables[0].Rows[0]["Productname"].ToString();
                txtDosageform.Text = dsProdId.Tables[0].Rows[0]["Dosageform"].ToString();
                txtStrength.Text = dsProdId.Tables[0].Rows[0]["Strength"].ToString();
                txtPacktype.Text = dsProdId.Tables[0].Rows[0]["Packtype"].ToString();
                txtPacksize.Text = dsProdId.Tables[0].Rows[0]["Packsize"].ToString();
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
        }
        public override void VerifyRenderingInServerForm(Control control)
        {

        }
        protected void grvCreatePo_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            #region Edit
            if (e.CommandName == "editt")
            {
                Response.Redirect("CreatePO.aspx?Event=Edit&Poid=" + e.CommandArgument.ToString());
            }

            if (e.CommandName == "Del")
            {
                int iPoid = Convert.ToInt32(e.CommandArgument);
                dbObj.deletePO(iPoid);
                BindPo();
            }
            #endregion

        }
    }
    
}