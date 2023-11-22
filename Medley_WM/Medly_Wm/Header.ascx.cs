using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medly_Wm
{
    public partial class Header : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sidebarPage = Request.Cookies["userInfo"]["SidebarPage"];
            if (Request.Cookies["userInfo"]["EmployeeID"] != null && Request.Cookies["userInfo"]["Empname"] != null)
            {
                string name = Request.Cookies["userInfo"]["Empname"];
                string USername= "Welcome : " + name;
            }
            if(Request.Cookies["userInfo"]["EmployeeID"] != null)
            {
                int UserID =Convert.ToInt32(Request.Cookies["userInfo"]["EmployeeID"]);
                int Designation = Convert.ToInt32(Request.Cookies["userInfo"]["Designation"]);
                if (Designation == 1)
                {
                    Dashboard.Visible = true;
                    Master.Visible = true;
                    OrderIn.Visible = true;
                    StockManagement.Visible = true;
                    OrderOut.Visible = true;
                    GPNReport.Visible = true;
                    Orderreturn.Visible=true;
                    Reports.Visible = true;
                }
                else if(Designation == 2|| Designation == 3) 
                {
                    Dashboard.Visible = true;
                    Master.Visible = true;
                    OrderIn.Visible = true;
                    StockManagement.Visible = true;
                    OrderOut.Visible = true;
                    GPNReport.Visible = true;
                    Orderreturn.Visible = true;
                    Reports.Visible = true;
                }
                else if(Designation==4|| Designation == 5|| Designation == 6|| Designation == 7)
                {
                    Dashboard.Visible = true;
                    Master.Visible = true;
                    OrderIn.Visible = true;
                    StockManagement.Visible = true;
                    OrderOut.Visible = true;
                    GPNReport.Visible = true;
                    Orderreturn.Visible = true;
                    Reports.Visible = true;
                    Sampleoverview.Visible = false;
                    Batchmanagement.Visible = false;
                }
                else if (Designation == 15)
                {
                    Dashboard.Visible = true;
                    Master.Visible = true;
                    OrderIn.Visible = true;
                    StockManagement.Visible = true;
                    GPNReport.Visible = true;
                    Reports.Visible = true;
                }

            }
        }
    }
}