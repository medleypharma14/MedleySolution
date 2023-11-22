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
    public partial class SOPrint : System.Web.UI.Page
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

                    DataSet dscreatpo = new DataSet();
                    dscreatpo = dbObj.Select_TransSObyproductid_Print(SoId);
                    if (dscreatpo.Tables[0].Rows.Count > 0)
                    {
                        grvSo.DataSource = dscreatpo;
                        grvSo.DataBind();
                    }

                    #endregion
                }
                #region Load Details

                DataSet dsSoprint = new DataSet();
                dsSoprint = dbObj.Select_SObyproductid_Print(SoId);
                if (dsSoprint.Tables[0].Rows.Count > 0)
                {
                    lblDate.Text = Convert.ToDateTime(dsSoprint.Tables[0].Rows[0]["Sodatetime"]).ToString("yyy/MM/dd");
                    int SupId = Convert.ToInt32(dsSoprint.Tables[0].Rows[0]["SupplierId"].ToString());
                    DataSet dsSupp = dbObj.selectsuplier_bysuplierid(SupId);
                    if (dsSupp.Tables[0].Rows.Count > 0)
                    {
                        lblSuppName.Text = dsSupp.Tables[0].Rows[0]["ContactName"].ToString();
                        lblAdd1.Text = dsSupp.Tables[0].Rows[0]["AddressLine1"].ToString();
                        lblAdd2.Text = dsSupp.Tables[0].Rows[0]["AddressLine2"].ToString();
                        //lblAdd3.Text = dsSupp.Tables[0].Rows[0]["AddessLine3"].ToString();
                        lblEmail.Text = dsSupp.Tables[0].Rows[0]["ContactEmail"].ToString();
                       // lblVAT.Text = dsSupp.Tables[0].Rows[0]["VAT"].ToString();
                    }
                }
                #endregion
            }
        }
    }
}