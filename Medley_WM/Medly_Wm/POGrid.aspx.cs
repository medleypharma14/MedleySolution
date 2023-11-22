using BusinessLayer;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medly_Wm
{
    public partial class POGrid : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass(); 
        int iPoid = 0;
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
                dsPO = dbObj.Select_PoGrid();
                if (dsPO.Tables[0].Rows.Count > 0)
                {
                    gvPo.DataSource = dsPO.Tables[0];
                    gvPo.DataBind();
                }
                #endregion

            }


        }
        private void BindPo()
        {
            DataSet dsPO = new DataSet();
            dsPO = dbObj.Select_PoGrid();
            if (dsPO.Tables[0].Rows.Count > 0)
            {
                gvPo.DataSource = dsPO.Tables[0];
                gvPo.DataBind();
            }
        }
        protected void gvPo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            DataSet ds = new DataSet();
            if (e.CommandName == "edit")
            {
                Response.Redirect("CreatePO.aspx?Event=Edit&Poid=" + e.CommandArgument.ToString());
            }

            if (e.CommandName == "Del")
            {
                int iPoid = Convert.ToInt32(e.CommandArgument);
                dbObj.deletePoGrid(iPoid);
                BindPo();
            }
          else if (e.CommandName == "Print")
            {
                int iPoid = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("POPrint1.aspx?PoId=" + iPoid);
            }
            else if (e.CommandName == "viewGR")
            {
                int iPoid = Convert.ToInt32(e.CommandArgument);
                dbObj.GRview(iPoid);
                BindPo();
                Response.Redirect("GRCreate.aspx?PoId=" + iPoid);
            }
        }

        protected void gvPo_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                GridView gv = (GridView)e.Row.FindControl("productgrid");
                //  GridView gvPO = (GridView)sender;
                string ab = gvPo.DataKeys[e.Row.RowIndex].Value.ToString();
                if (gvPo.DataKeys[e.Row.RowIndex].Value.ToString() != "")
                {
                   
                    string a = gvPo.DataKeys[e.Row.RowIndex].Values[0].ToString();
                    //int iPoid = Convert.ToInt32(e.Row.Cells[1].va.Text);
                    DataSet dspoproduct = new DataSet();

                dspoproduct = dbObj.Select_POProduct(Convert.ToInt32(a));
                if (dspoproduct.Tables[0].Rows.Count > 0)
                {
                        gv.Visible = true;
                    gv.DataSource = dspoproduct.Tables[0];
                    gv.DataBind();
                }
                //int iPoid = Convert.ToInt32(e.Row.Cells[1].Text);
            }

                if (e.Row.RowType == DataControlRowType.DataRow && gvPo.EditIndex == -1)
                {

                    LinkButton btnEdit = (LinkButton)e.Row.FindControl("btnedit");
                    ImageButton imgEdit = (ImageButton)e.Row.FindControl("imgEdit");

                    LinkButton btndel = (LinkButton)e.Row.FindControl("btndel");
                    ImageButton imgDel = (ImageButton)e.Row.FindControl("imgDel");

                    DataRowView drv = (DataRowView)e.Row.DataItem;
                    string Status = Convert.ToString(drv["Status"]);

                    if(Status== "Approved")
                    {
                        btndel.Enabled = false;
                        imgDel.Enabled = false;
                        btnEdit.Enabled = false;
                        imgEdit.Enabled = false;
                    }


                    if (Desid==1)
                    {
                        //btnEdit.Enabled = true;
                        //imgEdit.Enabled = true;

                        btndel.Enabled = true;
                        imgDel.Enabled = true;
                    }
                }



            }
            }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            if (txtsearch.Text != "")
            {
                string searchSO = txtsearch.Text.Trim();
                DataSet dsPO = new DataSet();
                dsPO = dbObj.Select_PoGrid();
                gvPo.DataSource = dsPO.Tables[0];

                DataView dv = new DataView(dsPO.Tables[0]); // Corrected this line to use dsPO.Tables[0] as the data source.
                dv.RowFilter = "Poid = '" + searchSO + "'";

                // Bind the filtered data to the GridView.
                gvPo.DataSource = dv;
                gvPo.DataBind();
            }
            else if ((txtFromdate.Text=="")||(txtTodate.Text==""))
            {
                string script = "alert('Select From Date and To Date')";
                ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
            }
            else
            {
                DataSet dsreport = new DataSet();
                dsreport = dbObj.Podatesearch(Convert.ToDateTime(txtFromdate.Text).Date, Convert.ToDateTime(txtTodate.Text).Date);
                if (dsreport.Tables[0].Rows.Count > 0)
                {
                    gvPo.DataSource = dsreport.Tables[0];
                    gvPo.DataBind();
                }
                else
               {
                    string script = "alert('PO Not Available')";
                    ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                }
            }
            

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("POGrid.aspx");
        }
    }
}