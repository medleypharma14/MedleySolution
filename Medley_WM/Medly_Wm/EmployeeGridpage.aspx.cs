using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Security.Cryptography;

namespace Medly_Wm
{
    public partial class EmployeeGridpage : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
        int iEmployeeId = 0;
        int Desid=0;
        protected void Page_Load(object sender, EventArgs e)
        { 
            if (!IsPostBack)
            {

                if (Request.Cookies["userInfo"]["Designation"] != null && Request.Cookies["userInfo"]["Empname"] != null)
                {
                    Desid = Convert.ToInt32(Request.Cookies["userInfo"]["Designation"]);

                }


                if (iEmployeeId != 0)
                {

                    DataSet dsEmplyId = new DataSet();
                    dsEmplyId = dbObj.SelectDesignation_byId(iEmployeeId);
                    ViewState["vsEmply"] = iEmployeeId;

                   
                }
                #region Load Employee
                DataSet dsEmployee = new DataSet();
                dsEmployee = dbObj.Select_Employee();
                if (dsEmployee.Tables[0].Rows.Count > 0)
                {
                    gvEmployee.DataSource = dsEmployee.Tables[0];
                    gvEmployee.DataBind();
                }
                #endregion
               

            }

        }

        protected void gvEmployee_RowCommand(object sender, GridViewCommandEventArgs e)
        {
          
            DataSet ds = new DataSet();
          

            if (e.CommandName == "edit")
            {
                Response.Redirect("Employee.aspx?Event=Edit&Empid=" + e.CommandArgument.ToString());

            }
            else if (e.CommandName == "Del")
            {
                int iEmployeeId = Convert.ToInt32(e.CommandArgument);
                dbObj.DeleteEmployee(iEmployeeId);
                BindEmployeeGrid();
            }
        }
        private void BindEmployeeGrid()
            {
                DataSet dsEmployee = dbObj.Select_Employee();
                if (dsEmployee.Tables[0].Rows.Count > 0)
                {
                    gvEmployee.DataSource = dsEmployee.Tables[0];
                    gvEmployee.DataBind();
                }
            }

        protected void gvEmployee_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType==DataControlRowType.DataRow&& gvEmployee.EditIndex == -1)
            {
                LinkButton btndel = (LinkButton)e.Row.FindControl("btndel");
                LinkButton btnedit = (LinkButton)e.Row.FindControl("btnedit");
                ImageButton imgDel = (ImageButton)e.Row.FindControl("imgDel");
                ImageButton imgEdit = (ImageButton)e.Row.FindControl("imgEdit");
                if (Desid == 1 || Desid == 2 || Desid == 3)
                {
                    btndel.Enabled = true;
                    imgDel.Enabled = true;
                    btnedit.Enabled = true;
                    imgEdit.Enabled = true;
                }

            }
        }
    }
}
