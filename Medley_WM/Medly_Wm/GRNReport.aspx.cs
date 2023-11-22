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
    public partial class GRNReport : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DateTime Today = DateTime.Now;
                txtFromdate.Text = Today.ToString("yyyy-MM-dd");
                txtTodate.Text = Today.ToString("yyyy-MM-dd");
                BindGRNreport();
            }
        }
        private void BindGRNreport()
        {
            DataSet dsPO = new DataSet();
            dsPO = dbObj.GRNreport();
            if (dsPO.Tables[0].Rows.Count > 0)
            {
                grnreport.DataSource = dsPO.Tables[0];
                grnreport.DataBind();
            }
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            
           if(txtSearchSO.Text!="")
            {
                string searchSO = txtSearchSO.Text.Trim();
                DataSet dsPO = new DataSet();
                dsPO = dbObj.GRNreport();
                grnreport.DataSource = dsPO.Tables[0];

                DataView dv = new DataView(dsPO.Tables[0]); // Corrected this line to use dsPO.Tables[0] as the data source.
                dv.RowFilter = "ProductId = '" + searchSO + "'";

                // Bind the filtered data to the GridView.
                grnreport.DataSource = dv;
                grnreport.DataBind();
            }
            else if ((txtFromdate.Text == "") || (txtTodate.Text == ""))
            {
                string script = "alert('Select From Date and To Date')";
                ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
            }
            else
            {
                DataSet dsreport = new DataSet();
                dsreport = dbObj.GRNdatesearch(Convert.ToDateTime(txtFromdate.Text).Date, Convert.ToDateTime(txtTodate.Text).Date);
                if (dsreport.Tables[0].Rows.Count > 0)
                {
                    grnreport.DataSource = dsreport.Tables[0];
                    grnreport.DataBind();
                }
                else
                {
                    string script = "alert('GRN Not Available')";
                    ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                }
            }
           

        }

        protected void linkprint_Click(object sender, EventArgs e)
        {
            head.Visible=false;
        }

        protected void btnexp_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename= GRNReport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            System.IO.StringWriter stringWrite1 = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite1 = new HtmlTextWriter(stringWrite1);
            excel.RenderControl(htmlWrite1);
            Response.Write(stringWrite1.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
    }
}