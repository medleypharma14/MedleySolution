using BusinessLayer;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medly_Wm
{
    public partial class GoodReceiptGrid : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
        int GRId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region Load GR 
                DataSet dsPO = new DataSet();
                dsPO = dbObj.LoadGoodReceipt();
                if (dsPO.Tables[0].Rows.Count > 0)
                {
                    gvPo.DataSource = dsPO.Tables[0];
                    gvPo.DataBind();
                }
                #endregion

            }
        }
        private void BindGR()
        {
            DataSet dsPO = new DataSet();
            dsPO = dbObj.LoadGoodReceipt();
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
                Response.Redirect("GoodReceiptNew.aspx?Event=Edit&GRId=" + e.CommandArgument.ToString());

            }
            if (e.CommandName == "Del")
            {
                int GRId = Convert.ToInt32(e.CommandArgument);
                dbObj.deleteGRGird(GRId);
                BindGR();
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

                    dspoproduct = dbObj.Select_UnitsQty(Convert.ToInt32(a));
                    if (dspoproduct.Tables[0].Rows.Count > 0)
                    {
                        gv.Visible = true;
                        gv.DataSource = dspoproduct.Tables[0];
                        gv.DataBind();
                    }
                    //int iPoid = Convert.ToInt32(e.Row.Cells[1].Text);
                }




            }

            if (e.Row.RowType == DataControlRowType.DataRow && gvPo.EditIndex == -1)
            {
                LinkButton btnEdit = (LinkButton)e.Row.FindControl("btnedit");
                ImageButton imgEdit = (ImageButton)e.Row.FindControl("imgEdit");

                //  LinkButton btndel = (LinkButton)e.Row.FindControl("btndel");
                //  ImageButton imgDel = (ImageButton)e.Row.FindControl("imgDel");

                DataRowView drv = (DataRowView)e.Row.DataItem;
                string Status = Convert.ToString(drv["Status"]);


                if (Status == "Approved")
                {
                    btnEdit.Enabled = false;
                    imgEdit.Enabled = false;

                    // btndel.Enabled = false;
                    // imgDel.Enabled = false;
                    //  imgEdit.ImageUrl = "~/Images/edit_disabled.jpg"; // Optional: Replace with a disabled image
                }
            }



        }

        protected void poret_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (poret.SelectedValue == "Return Order")
            {
                gvPo.Columns[0].HeaderText = "Return NO";

                #region Load GR 
                DataSet dsPO = new DataSet();
                dsPO = dbObj.LoadGoodReceiptret();
                if (dsPO.Tables[0].Rows.Count > 0)
                {
                    gvPo.DataSource = dsPO.Tables[0];
                    gvPo.DataBind();
                }
                else
                {
                    gvPo.DataSource = null;
                    gvPo.DataBind();
                }
                #endregion
            }
            else
            {
                gvPo.Columns[0].HeaderText = "PO NO";

                #region Load GR 
                DataSet dsPO = new DataSet();
                dsPO = dbObj.LoadGoodReceipt();
                if (dsPO.Tables[0].Rows.Count > 0)
                {
                    gvPo.DataSource = dsPO.Tables[0];
                    gvPo.DataBind();
                }
                else
                {
                    gvPo.DataSource = null;
                    gvPo.DataBind();
                }
                #endregion
            }
        }
    }
}