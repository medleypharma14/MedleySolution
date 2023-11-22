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
    public partial class SOReport : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
        int iSoid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime Today = DateTime.Now;
                txtFromdate.Text = Today.ToString("yyyy-MM-dd");
                txtTodate.Text = Today.ToString("yyyy-MM-dd");
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
            Response.Redirect("SOReport.aspx");
        }

        protected void btnexp_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=SOReport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            System.IO.StringWriter stringWrite1 = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite1 = new HtmlTextWriter(stringWrite1);
            gvSo.RenderControl(htmlWrite1);
            Response.Write(stringWrite1.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
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
        }
    }
}