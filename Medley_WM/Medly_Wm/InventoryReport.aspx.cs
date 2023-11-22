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
    public partial class InventoryReport : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
        private object datetime;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindPo();


            }
        }
            private void BindPo()
        {
            DataSet dsPO = new DataSet();
            dsPO = dbObj.Select_Inventory();
            if (dsPO.Tables[0].Rows.Count > 0)
            {
                inventoryreport.DataSource = dsPO.Tables[0];
                inventoryreport.DataBind();
            }
        }
        //protected void gvProduct_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {

        //        DateTime today = DateTime.Now.Date;
        //        if (Convert.ToDateTime(e.Row.Cells[3].Text) <= today)
        //        {

        //            e.Row.Font.Bold = true;
        //            e.Row.BackColor = System.Drawing.Color.LightBlue;

        //        }

        //    }
        //}

        protected void inventoryreport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               int minqty = 10;
               int available=Convert.ToInt32(e.Row.Cells[2].Text);
                int minimum = Convert.ToInt32(e.Row.Cells[3].Text);
                if(available<minimum)
               // if (int.TryParse(e.Row.Cells[2].Text, out int cellValue) && cellValue <= minqty)
                {

                    e.Row.Font.Bold = true;
                    e.Row.BackColor = System.Drawing.Color.LightBlue;

                }

            }
        }

        protected void linkprint_Click(object sender, EventArgs e)
        {
            head.Visible=false;
        }

        protected void btnexp_Click(object sender, EventArgs e)
        {
            //Response.Clear();
            //Response.AddHeader("content-disposition", "attachment;filename= InventaryReport.xls");
            //Response.Charset = "";
            //Response.ContentType = "application/vnd.ms-excel";
            //System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            //System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            //gridexcel.RenderControl(htmlWrite);
            //Response.Write(stringWrite.ToString());
            //Response.End();

            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename= InventaryReport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            System.IO.StringWriter stringWrite1 = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite1 = new HtmlTextWriter(stringWrite1);
            gridexcel.RenderControl(htmlWrite1);
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