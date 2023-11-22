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
    public partial class Reports : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
        int iPoid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime Today = DateTime.Now;
            txtFromdate.Text = Today.ToString("yyyy-MM-dd");
            txtTodate.Text = Today.ToString("yyyy-MM-dd");
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
          
                DataSet dsreport = new DataSet();
                dsreport = dbObj.Select_Reports(Convert.ToDateTime(txtFromdate.Text).Date, Convert.ToDateTime(txtTodate.Text).Date);
                if (dsreport.Tables[0].Rows.Count > 0)
                {
                    gvreport.DataSource = dsreport.Tables[0];
                    gvreport.DataBind();
                }
           
        }
    }
}