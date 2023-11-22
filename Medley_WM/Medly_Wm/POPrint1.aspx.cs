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
    public partial class POPrint1 : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
        int PoId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                PoId = Convert.ToInt32(Request.QueryString.Get("PoId"));
                if (PoId != 0)
                {
                    //#region chech Poprint Number
                    //DataSet poprint = new DataSet();
                    //poprint = dbObj.Select_POPrintNumberchech(PoId.ToString());

                    //#endregion
                    #region LoadGrid CreatePO

                    DataSet dscreatpo = new DataSet();
                    dscreatpo = dbObj.Select_TransPObyproductid_Print(PoId);
                    if (dscreatpo.Tables[0].Rows.Count > 0)
                    {
                        grvPo.DataSource = dscreatpo;
                        grvPo.DataBind();
                    }

                    #endregion
                }
                #region Load Details

                DataSet dscreatpo1 = new DataSet();
                dscreatpo1 = dbObj.Select_PObyproductid_Print(PoId);
                if (dscreatpo1.Tables[0].Rows.Count > 0)
                {
                    lblDate.Text = Convert.ToDateTime(dscreatpo1.Tables[0].Rows[0]["Podatetime"]).ToString("dd/MM/yyyy");
                    lblponumber.Text = dscreatpo1.Tables[0].Rows[0]["POPrintno"].ToString();
                    lbltotal.Text = dscreatpo1.Tables[0].Rows[0]["Amount"].ToString();
                    int SupId = Convert.ToInt32(dscreatpo1.Tables[0].Rows[0]["SupplierId"].ToString());
                    DataSet dsSupp = dbObj.selectsuplier_bysuplierid(SupId);
                    if (dsSupp.Tables[0].Rows.Count > 0)
                    {
                        lblSuppName.Text = dsSupp.Tables[0].Rows[0]["CompanyName"].ToString();
                        lblAdd1.Text = dsSupp.Tables[0].Rows[0]["AddressLine1"].ToString();
                        //lblAdd2.Text = dsSupp.Tables[0].Rows[0]["AddressLine2"].ToString();
                        //lblAdd3.Text = dsSupp.Tables[0].Rows[0]["AddessLine3"].ToString();
                        lblEmail.Text = dsSupp.Tables[0].Rows[0]["ContactEmail"].ToString();
                    }
                }
               DataSet Totalqty = dbObj.Select_POTotalqty(PoId);
                if (Totalqty.Tables[0].Rows.Count > 0)
                {
                    txttotalqty.Text = Totalqty.Tables[0].Rows[0]["TottalQty"].ToString();
                }
                #endregion
            }

        }

    }  
}