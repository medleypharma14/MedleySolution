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
    public partial class ProductStockSpecific : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            BindEmployeeGrid();
        }

        private void BindEmployeeGrid()
        {
            DataSet dsEmployee = dbObj.ProductStockSpecific();
            if (dsEmployee.Tables[0].Rows.Count > 0)
            {
                gvEmployee.DataSource = dsEmployee.Tables[0];
                gvEmployee.DataBind();
            }
        }
    }
}