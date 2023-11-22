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
    public partial class SOPrint1 : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
        int SoId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                SoId = Convert.ToInt32(Request.QueryString.Get("SoId"));
                if (SoId != 0)
                {

                    #region LoadGrid CreatePO

                    DataSet dsso = new DataSet();
                    dsso = dbObj.Select_TransSObyproductid_Print(SoId);
                    if (dsso.Tables[0].Rows.Count > 0)
                    {
                        grvSo.DataSource = dsso;
                        grvSo.DataBind();
                    }

                    #endregion
                }
                #region Load Details

                DataSet dssoprint = new DataSet();
                dssoprint = dbObj.Select_TransSObyproductid_Print(SoId);
                if (dssoprint.Tables[0].Rows.Count > 0)
                {
                    lblDate.Text = Convert.ToDateTime(dssoprint.Tables[0].Rows[0]["Sodatetime"]).ToString("dd/MM/yyyy");
                    lblSonumber.Text = dssoprint.Tables[0].Rows[0]["SOPrintno"].ToString();
                    lbltotal.Text = dssoprint.Tables[0].Rows[0]["Amount"].ToString();
                    int SupId = Convert.ToInt32(dssoprint.Tables[0].Rows[0]["SupplierId"].ToString());
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
                DataSet Totalqty = dbObj.Select_SOTotalqty(SoId);
                if (Totalqty.Tables[0].Rows.Count > 0)
                {
                    txtTotalqty.Text = Totalqty.Tables[0].Rows[0]["TottalQty"].ToString();
                }
                #endregion
            }

        }
    }
}