using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DataLayer;
using System.Data;
using System.Text;
using System.Diagnostics;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.Globalization;

namespace AdminAfforadbleApp
{
    public partial class Dashboard : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();

        protected void Page_Load(object sender, EventArgs e)
        {

            this.ClientTarget = "uplevel";

            if (!IsPostBack)
            {
              
            }
        }

    }
}