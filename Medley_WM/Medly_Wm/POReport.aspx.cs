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
    public partial class POReport : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
        int iPoid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime Today = DateTime.Now;
                txtFromdate.Text = Today.ToString("yyyy-MM-dd");
                txtTodate.Text = Today.ToString("yyyy-MM-dd");
                BindPo();
            }
        }

        private void BindPo()
        {
            DataSet dsPOR = new DataSet();
            dsPOR = dbObj.POReport();
            if (dsPOR.Tables[0].Rows.Count > 0)
            {
                PoReport.DataSource = dsPOR.Tables[0];
                PoReport.DataBind();
            }
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            if ((txtFromdate.Text == "") || (txtTodate.Text == ""))
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
                    PoReport.DataSource = dsreport.Tables[0];
                    PoReport.DataBind();
                }
                else
                {
                    string script = "alert('PO Not Available')";
                    ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                }
            }
           

        }

        protected void btnexp_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename= POReport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            System.IO.StringWriter stringWrite1 = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite1 = new HtmlTextWriter(stringWrite1);
            PoReport.RenderControl(htmlWrite1);
            Response.Write(stringWrite1.ToString());
            Response.End();


        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        protected void PoReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                GridView gv = (GridView)e.Row.FindControl("productgrid");
                //  GridView gvPO = (GridView)sender;
                string ab = PoReport.DataKeys[e.Row.RowIndex].Value.ToString();
                if (PoReport.DataKeys[e.Row.RowIndex].Value.ToString() != "")
                {

                    string a = PoReport.DataKeys[e.Row.RowIndex].Values[0].ToString();
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
            }
        }
    }
}