using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medly_Wm
{
    public partial class Siderbar : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sidebarPage = Request.Cookies["userInfo"]["SidebarPage"];
            if (Request.Cookies["userInfo"]["EmployeeID"] != null && Request.Cookies["userInfo"]["Empname"] != null)
            {
                string name = Request.Cookies["userInfo"]["Empname"];
                string Designation = Request.Cookies["userInfo"]["Designation"];
                lblusername.Text ="Welcome : "+ name;
            }
           
        }
    }
}