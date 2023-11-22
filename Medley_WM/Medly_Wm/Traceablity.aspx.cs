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
    public partial class Traceablity : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
        int iTransGRId = 0;
        int isoid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTrace();


            }
        }
        private void BindTrace()
        {
            DataSet dsTrace = new DataSet();
            dsTrace = dbObj.Select_Traceablity();
            if (dsTrace.Tables[0].Rows.Count > 0)
            {
                if (!IsPostBack)
                {
                    iTransGRId = Convert.ToInt32(Request.QueryString.Get("TransGRId"));

                }
            }
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {

            #region PO Detail
            DataSet dsTraceablity = new DataSet();
            dsTraceablity = dbObj.LoadTraceablity1(Convert.ToString(txtBatchno.Text));
            if (dsTraceablity.Tables[0].Rows.Count > 0)
            {
                txtbatchname.Text = dsTraceablity.Tables[0].Rows[0]["Batchnumber"].ToString();
                txtProductName.Text = dsTraceablity.Tables[0].Rows[0]["Productname"].ToString();
                txtgrnumber.Text = dsTraceablity.Tables[0].Rows[0]["GRId"].ToString();
                txtSuppliername.Text = dsTraceablity.Tables[0].Rows[0]["CompanyName"].ToString();
                txtgrreceived.Text = dsTraceablity.Tables[0].Rows[0]["GoodsReceiveddate"].ToString();
                txtreceivedqty.Text = dsTraceablity.Tables[0].Rows[0]["totalqty"].ToString();
                txtsamqty.Text = dsTraceablity.Tables[0].Rows[0]["sampleqty"].ToString();
                txtfinalqty.Text = dsTraceablity.Tables[0].Rows[0]["finalqty"].ToString();
                string isoid = dsTraceablity.Tables[0].Rows[0]["Soid"].ToString();
                if (isoid != null)
                {
                    DataSet dssodetails = new DataSet();
                    dssodetails = dbObj.checkProdid(txtbatchname.Text);// dbObj.Loadsodetails(isoid);
                    if (dssodetails.Tables[0].Rows.Count > 0)
                    {
                        lblsohead.Visible = true;
                        tracesogrid.DataSource = dssodetails.Tables[0];
                        tracesogrid.DataBind();
                    }
                }
                else
                {
                    tracesogrid.Visible = false;
                    tracesogrid = null;
                    string script = "alert('Sales Order not Available given batch')";
                    ClientScript.RegisterStartupScript(this.GetType(), "UpdateMessage", script, true);
                }

            }
            else
            {
                tracesogrid = null;
                string script = "alert('Please Complete Sampling for given Batch')";
                ClientScript.RegisterStartupScript(this.GetType(), "UpdateMessage", script, true);
            }
            #endregion

            #region Po unit Stored
            DataSet dsgrunits = new DataSet();
            dsgrunits = dbObj.Loadgrunits(Convert.ToString(txtBatchno.Text));
            if (dsgrunits.Tables[0].Rows.Count > 0)
            {
                lblpohead.Visible = true;
                traceunit.DataSource = dsgrunits.Tables[0];
                traceunit.DataBind();
            }
            #endregion
        }

        protected void linkprint_Click(object sender, EventArgs e)
        {
            head.Visible=false;
        }

        protected void btnexp_Click(object sender, EventArgs e)
        {
          
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename= TraceablityReport.xls");
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
