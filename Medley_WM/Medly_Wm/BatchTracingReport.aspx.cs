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
    public partial class BatchTracingReport : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        protected void btnGo_Click(object sender, EventArgs e)
        {

            #region Load batchreport
            DataSet dsPO = new DataSet();
            dsPO = dbObj.Batchtracingreport(Convert.ToString(txtBatchno.Text));
            if (dsPO.Tables[0].Rows.Count > 0)
            {
                batchtracingreport.DataSource = dsPO.Tables[0];
                batchtracingreport.DataBind();
            }
            #endregion

        }
    }
}