using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medly_Wm
{
    public partial class SalesOrderoverview : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
        int iSoid = 0;
        int Desid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime Today = DateTime.Now;
                txtFromdate.Text = Today.ToString("yyyy-MM-dd");
                txtTodate.Text = Today.ToString("yyyy-MM-dd");

                if (Request.Cookies["userInfo"]["Designation"] != null && Request.Cookies["userInfo"]["Empname"] != null)
                {
                    Desid = Convert.ToInt32(Request.Cookies["userInfo"]["Designation"]);

                }
                #region Load Po
                DataSet dsPO = new DataSet();
                dsPO = dbObj.Select_SoGrid();
                if (dsPO.Tables[0].Rows.Count > 0)
                {
                    gvSo.DataSource = dsPO.Tables[0];
                    gvSo.DataBind();
                }
                #endregion
            }
        } 
        private void BindSo()
        {
            DataSet dsPO = new DataSet();
            dsPO = dbObj.Select_SoGrid();
            if (dsPO.Tables[0].Rows.Count > 0)
            {
                gvSo.DataSource = dsPO.Tables[0];
                gvSo.DataBind();
            }
        }
        protected void gvSo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            DataSet ds = new DataSet();
            if (e.CommandName == "edit")
            {
                Response.Redirect("CreateSO.aspx?Event=Edit&Soid=" + e.CommandArgument.ToString());
            }
            if (e.CommandName == "Del")
            {
                int iSoid = Convert.ToInt32(e.CommandArgument);
                dbObj.deleteSoGrid(iSoid);
                BindSo();
            }
            else if (e.CommandName == "Print")
            {
                int iSoid = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("SOPrint1.aspx?Soid=" + iSoid);
            }

        }

        protected void gvSo_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                GridView gv = (GridView)e.Row.FindControl("productgrid");
                //  GridView gvPO = (GridView)sender;
                string ab = gvSo.DataKeys[e.Row.RowIndex].Value.ToString();
                if (gvSo.DataKeys[e.Row.RowIndex].Value.ToString() != "")
                {

                    string a = gvSo.DataKeys[e.Row.RowIndex].Values[0].ToString();
                    //int iPoid = Convert.ToInt32(e.Row.Cells[1].va.Text);
                    DataSet dspsoproduct = new DataSet();

                    dspsoproduct = dbObj.Select_SOProduct(Convert.ToInt32(a));
                    if (dspsoproduct.Tables[0].Rows.Count > 0)
                    {
                        gv.Visible = true;
                        gv.DataSource = dspsoproduct.Tables[0];
                        gv.DataBind();
                    }
                    //int iPoid = Convert.ToInt32(e.Row.Cells[1].Text);
                }

            }

            if (e.Row.RowType == DataControlRowType.DataRow && gvSo.EditIndex == -1)
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

                if (Desid==1)
                {
                    //btnEdit.Enabled = false;
                    //imgEdit.Enabled = false;

                    btndel.Enabled = true;
                    imgDel.Enabled = true;
                    //  imgEdit.ImageUrl = "~/Images/edit_disabled.jpg"; // Optional: Replace with a disabled image
                }
            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            if (txtsearch.Text != "")
            {
                string searchSO = txtsearch.Text.Trim();
                DataSet dsPO = new DataSet();
                dsPO = dbObj.Select_SoGrid();
                gvSo.DataSource = dsPO.Tables[0];

                DataView dv = new DataView(dsPO.Tables[0]); // Corrected this line to use dsPO.Tables[0] as the data source.
                dv.RowFilter = "SOPrintno = '" + searchSO + "'";

                // Bind the filtered data to the GridView.
                gvSo.DataSource = dv;
                gvSo.DataBind();
            }
           else if ((txtFromdate.Text == "") || (txtTodate.Text == ""))
            {
                string script = "alert('Select From Date and To Date')";
                ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
            }
            else
            {
                DataSet dsreport = new DataSet();
                dsreport = dbObj.SOdatesearch(Convert.ToDateTime(txtFromdate.Text).Date, Convert.ToDateTime(txtTodate.Text).Date);
                if (dsreport.Tables[0].Rows.Count > 0)
                {
                    gvSo.DataSource = dsreport.Tables[0];
                    gvSo.DataBind();
                }
                else
                {
                    string script = "alert('SO Not Available')";
                    ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                }
            }
           
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("SOgrid.aspx");
        }

        protected void txtMonth_TextChanged(object sender, EventArgs e)
        {
            DateTime currentDate = DateTime.Now;
            //ddlmonth.SelectedValue =currentDate.Month.ToString();
            //ddlyear.SelectedValue=currentDate.Year.ToString();
            DataSet dsreport = new DataSet();
            dsreport = dbObj.SOMonthsearch(Convert.ToInt32(ddlmonth.SelectedValue),Convert.ToInt32(ddlyear.SelectedValue));
            if (dsreport.Tables[0].Rows.Count > 0)
            {
                gvSo.DataSource = dsreport.Tables[0];
                gvSo.DataBind();
            }
            else
            {
                string script = "alert('SO Not Available')";
                ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
            }
        }
    }
}