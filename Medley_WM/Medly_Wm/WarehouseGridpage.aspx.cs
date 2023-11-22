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
    public partial class WarehouseGridpage : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
        int iWarehouseId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                if (iWarehouseId != 0)
                {

                    DataSet dswarehouseid1= new DataSet();
                    dswarehouseid1 = dbObj.select_byWarehouseId(iWarehouseId);
                    ViewState["vsEmply"] = dswarehouseid1;


                }
                #region Load warehouse
                DataSet dswarehouseid = new DataSet();
                dswarehouseid = dbObj.Select_Warehouse();
                if (dswarehouseid.Tables[0].Rows.Count > 0)
                {
                    gvWarehouse.DataSource = dswarehouseid.Tables[0];
                    gvWarehouse.DataBind();
                }
                #endregion


            }

        }
    }
}