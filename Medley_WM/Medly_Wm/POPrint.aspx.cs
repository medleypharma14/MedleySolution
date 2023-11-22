using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Medly_Wm
{
    public partial class POPrint : System.Web.UI.Page
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
                    lblDate.Text =Convert.ToDateTime( dscreatpo1.Tables[0].Rows[0]["Podatetime"]).ToString("yyy/MM/dd");
                    lblponumber.Text =dscreatpo1.Tables[0].Rows[0]["Poid"].ToString();
                    int SupId = Convert.ToInt32(dscreatpo1.Tables[0].Rows[0]["SupplierId"].ToString());
                    DataSet dsSupp = dbObj.selectsuplier_bysuplierid(SupId);
                    if (dsSupp.Tables[0].Rows.Count > 0)
                    {
                        lblSuppName.Text = dsSupp.Tables[0].Rows[0]["CompanyName"].ToString();
                        lblAdd1.Text = dsSupp.Tables[0].Rows[0]["AddressLine1"].ToString();
                        lblAdd2.Text = dsSupp.Tables[0].Rows[0]["AddressLine2"].ToString();
                        //lblAdd3.Text = dsSupp.Tables[0].Rows[0]["AddessLine3"].ToString();
                        lblEmail.Text = dsSupp.Tables[0].Rows[0]["ContactEmail"].ToString();
                    }
                }
                    #endregion
                }

        }
    }
}