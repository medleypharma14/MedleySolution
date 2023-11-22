using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medly_Wm
{
    public partial class GoodSending : System.Web.UI.Page
    {
        BSClass objBS = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                DataSet ds = objBS.SoList_new();
                ddlSo.DataSource = ds;

                ddlSo.DataTextField = "SOPrintno";
                ddlSo.DataValueField = "Soid";
                ddlSo.DataBind();
                ddlSo.Items.Insert(0, "Select SO Number");
            }
        }

        protected void ddlSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds1 = objBS.SoGrid(Convert.ToInt32(ddlSo.SelectedValue)); 
            gvGoods.DataSource = ds1;
            gvGoods.DataBind();

        }
        protected void gvSo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int SoID=Convert.ToInt32(ddlSo.SelectedValue);
            
            if (e.CommandName == "pick")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                string Productid = commandArgs[0];
                string SoQty = commandArgs[1];
                string SuppId = commandArgs[2];
                string SentQty = commandArgs[3];
                Response.Redirect("OrderProcessing.aspx?SuppId=" + SuppId + "&SoID=" + SoID + "&SoQty=" + SoQty + "&ProId=" + Productid+ "&SentQty=" + SentQty);

            }
        }
        protected void gvSo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Assuming the Productid and sentqty columns are at index 0 and 3, respectively
              string check= e.Row.Cells[7].Text;
                int orderqty = Convert.ToInt32(e.Row.Cells[7].Text);
                int sentQty = Convert.ToInt32(e.Row.Cells[8].Text);

                // Condition to hide the row
                if (orderqty<=sentQty)
                {
                    e.Row.Visible = false;
                }
            }
        }


    }
}