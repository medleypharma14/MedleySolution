using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medly_Wm
{
    public partial class GoodsReturn : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
        int Desid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Request.Cookies["userInfo"]["Designation"] != null && Request.Cookies["userInfo"]["Empname"] != null)
                {
                    Desid = Convert.ToInt32(Request.Cookies["userInfo"]["Designation"]);

                }
                #region Load Return
                DataSet dsPO = new DataSet();
                dsPO = dbObj.Select_Returngrid();
                if (dsPO.Tables[0].Rows.Count > 0)
                {
                    gvReturn.DataSource = dsPO.Tables[0];
                    gvReturn.DataBind();
                }
                #endregion
            }

        }

        protected void gvReturn_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                GridView gv = (GridView)e.Row.FindControl("productgrid");
                string ab = gvReturn.DataKeys[e.Row.RowIndex].Value.ToString();
                if (gvReturn.DataKeys[e.Row.RowIndex].Value.ToString() != "")
                {

                    string a = gvReturn.DataKeys[e.Row.RowIndex].Values[0].ToString();
                    DataSet dsreturnproduct = new DataSet();
                    dsreturnproduct = dbObj.Select_ReturnProduct(Convert.ToInt32(a));
                    if (dsreturnproduct.Tables[0].Rows.Count > 0)
                    {
                        gv.Visible = true;
                        gv.DataSource = dsreturnproduct.Tables[0];
                        gv.DataBind();
                    }
                }
                if (e.Row.RowType == DataControlRowType.DataRow && gvReturn.EditIndex == -1)
                {

                    LinkButton btnEdit = (LinkButton)e.Row.FindControl("btnedit");
                    ImageButton imgEdit = (ImageButton)e.Row.FindControl("imgEdit");

                    LinkButton btndel = (LinkButton)e.Row.FindControl("btndel");
                    ImageButton imgDel = (ImageButton)e.Row.FindControl("imgDel");

                    DataRowView drv = (DataRowView)e.Row.DataItem;
                    string Status = Convert.ToString(drv["Status"]);

                    if (Status == "Approved")
                    {
                        btndel.Enabled = false;
                        imgDel.Enabled = false;
                    }


                    if (Desid == 1)
                    {
                        //btnEdit.Enabled = true;
                        //imgEdit.Enabled = true;

                        btndel.Enabled = true;
                        imgDel.Enabled = true;
                    }
                }
            }
        }

        protected void gvReturn_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            if (e.CommandName == "edit")
            {
                Response.Redirect("ReturnSales.aspx?Event=Edit&Returnid=" + e.CommandArgument.ToString());
            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {

            {
                if (txtsearch.Text != "")
                {
                    string searchSO = txtsearch.Text.Trim();
                    DataSet dsPO = new DataSet();
                    dsPO = dbObj.Select_ReturnGrid();
                    gvReturn.DataSource = dsPO.Tables[0];

                    DataView dv = new DataView(dsPO.Tables[0]); // Corrected this line to use dsPO.Tables[0] as the data source.
                    dv.RowFilter = "ReturnPrintno = '" + searchSO + "'";

                    // Bind the filtered data to the GridView.
                    gvReturn.DataSource = dv;
                    gvReturn.DataBind();
                }
                else if ((txtFromdate.Text == "") || (txtTodate.Text == ""))
                {
                    string script = "alert('Select From Date and To Date')";
                    ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                }
                else
                {
                    DataSet dsreport = new DataSet();
                    dsreport = dbObj.Returndatesearch(Convert.ToDateTime(txtFromdate.Text).Date, Convert.ToDateTime(txtTodate.Text).Date);
                    if (dsreport.Tables[0].Rows.Count > 0)
                    {
                        gvReturn.DataSource = dsreport.Tables[0];
                        gvReturn.DataBind();
                    }
                    else
                    {
                        string script = "alert('Return Not Available')";
                        ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                    }
                }

            }
        }
    }
}   