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
    public partial class ProductStockReport : System.Web.UI.Page
    {

        BSClass dbObj = new BSClass();
        int iproductID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region Load Product
                DataSet dsProduct = new DataSet();
                dsProduct = dbObj.Select_Product();
                if (dsProduct.Tables[0].Rows.Count > 0)
                {
                    gvProduct.DataSource = dsProduct.Tables[0];
                    gvProduct.DataBind();
                }
                #endregion
            }

        }
        private void BindProductGrid()
        {
            DataSet dsProduct = new DataSet();
            dsProduct = dbObj.Select_Product();
            if (dsProduct.Tables[0].Rows.Count > 0)
            {
                gvProduct.DataSource = dsProduct.Tables[0];
                gvProduct.DataBind();
            }
        }
        protected void gvProduct_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

               
                if (Convert.ToInt32(e.Row.Cells[5].Text) <= 50)
                {

                    e.Row.Font.Bold = true;
                    e.Row.BackColor = System.Drawing.Color.Red;

                }

            }
        }
    }
}