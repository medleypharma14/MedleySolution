using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;
using System.Text;
using System.Net;
using System.IO;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;
using System.Management;
using DataLayer;
using System.Data.OleDb;
using System.Configuration;


namespace FoodAdminReports
{
    public partial class Login : System.Web.UI.Page
    {
        DBAccess db = new DBAccess();
        DataSet dsLogin = new DataSet();
        BSClass objBs = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {
           

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            HttpCookie userInfo = new HttpCookie("userInfo");

            if (txtpassword.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Enter Password');", true);
            }

            if (txtUsername.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Enter Username');", true);
            }
            else
            {
                dsLogin = objBs.Login(txtUsername.Text, txtpassword.Text);
                if (dsLogin.Tables[0].Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Login Failed');", true);
                }
                else
                {  
                    Response.Redirect("Dashboard.aspx");
                }
            }
        }
    }
}