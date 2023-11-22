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
    public partial class Sampling : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            Bindsampling();
        }
        private void Bindsampling()
        {
            DataSet dssamp = new DataSet();
            dssamp = dbObj.Selectsampling();
            if (dssamp.Tables[0].Rows.Count > 0)
            {
                gvsampling.DataSource = dssamp.Tables[0];
                gvsampling.DataBind();
            }
        }
    }
}