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
    public partial class WarehouseReport : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
        int iProductID = 0; int Empid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DataSet Unitdetails = dbObj.Select_Unitdetailforall();
                if (Unitdetails.Tables[0].Rows.Count > 0)
                {
                    WHReportgv.Visible = true;
                    WHReportgv.DataSource = Unitdetails;
                    WHReportgv.DataBind();
                }
                    LoadDDL();
            }

        }

        public void LoadDDL()
        {
            DataSet Productlist = dbObj.Select_UnitProduct();
            if (Productlist.Tables[0].Rows.Count > 0)
            {
                ddlProductname.DataSource = Productlist;
                ddlProductname.DataTextField = "Productname";
                ddlProductname.DataValueField = "Productid";
                ddlProductname.DataBind();
                ddlProductname.Items.Insert(0, "Select Productname");
            }
        }

        protected void ddlProductname_SelectedIndexChanged(object sender, EventArgs e)
        {          
            if (ddlProductname.SelectedIndex == 0)
            {
                WHReportgv.Visible = false;
                ddlBatchNumber.Enabled = false;
            }
            else
            {
                DataSet Unitdetails = dbObj.Select_Unitdetailnew(Convert.ToInt32(ddlProductname.SelectedValue));
                if (Unitdetails.Tables[0].Rows.Count > 0)
                {
                    WHReportgv.Visible = true;
                    WHReportgv.DataSource = Unitdetails;
                    WHReportgv.DataBind();

                    DataSet unitbatch = dbObj.Select_Unitbatchname(Convert.ToInt32(ddlProductname.SelectedValue));
                    ddlBatchNumber.DataSource = unitbatch;
                    ddlBatchNumber.DataTextField = "Batchnumber";
                    ddlBatchNumber.DataBind();
                    ddlBatchNumber.Items.Insert(0, "Select Batch Number");
                }
            }
          
        }

        protected void btnexp_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename= WHReportgv.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            System.IO.StringWriter stringWrite1 = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite1 = new HtmlTextWriter(stringWrite1);
            WHReportgv.RenderControl(htmlWrite1);
            Response.Write(stringWrite1.ToString());
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        protected void ddlBatchNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProductname.SelectedIndex == 0 && ddlBatchNumber.SelectedIndex == 0)
            {
                WHReportgv.Visible = false;
            }
            else
            {
                DataSet Unitbatchdetails = dbObj.Select_UnitBatchdetailnew(Convert.ToInt32(ddlProductname.SelectedValue), ddlBatchNumber.SelectedItem.Text);
                if (Unitbatchdetails.Tables[0].Rows.Count > 0)
                {
                    WHReportgv.Visible = true;
                    WHReportgv.DataSource = Unitbatchdetails;
                    WHReportgv.DataBind();
                }
            }
           
        }
    }
}