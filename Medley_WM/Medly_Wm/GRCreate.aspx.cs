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
    public partial class GRCreate : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
        int iproductID = 0;
        int iPoid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                #region Load Product
                iPoid = Convert.ToInt32(Request.QueryString.Get("Poid"));
                DataSet dsPodetails = new DataSet();
                dsPodetails = dbObj.GRview(iPoid);
                if (dsPodetails.Tables[0].Rows.Count > 0)
                {
                    gvProduct.DataSource = dsPodetails.Tables[0];
                    gvProduct.DataBind();
                }
                #endregion
            }

        }

        protected void txtReceivedqty_TextChanged(object sender, EventArgs e)
        {
           
                iPoid = Convert.ToInt32(Request.QueryString.Get("Poid"));
                DataSet dsPodetails = new DataSet();
                dsPodetails = dbObj.GRview(iPoid);
                if (dsPodetails.Tables[0].Rows.Count > 0)
                {
                    int PoQty = 0;
                    TextBox txtReceivedqty = (TextBox)sender; // Get the reference to the TextBox control
                    GridViewRow row = (GridViewRow)txtReceivedqty.NamingContainer; // Get the reference to the GridView row
                    TextBox txtTotalbatches = (TextBox)row.FindControl("txtTotalbatches"); // Get the reference to the TextBox control for Total Batches
                    int i = row.RowIndex;
                    PoQty = Convert.ToInt32(dsPodetails.Tables[0].Rows[i]["PoQty"].ToString());
                    int receivedQty = 0;
                    int.TryParse(txtReceivedqty.Text, out receivedQty);
                    // Calculate the Total Batches
                    int totalBatches = PoQty - receivedQty;
                    // Set the value of the Total Batches TextBox
                    txtTotalbatches.Text = totalBatches.ToString();

                }
            
        }

        protected void gvProduct_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Session["Total"] = totalBatches;
            //HttpCookie userInfo = new HttpCookie("userInfo");

            //Response.Cookies["UserName"].Value = txtUsername.Text.Trim();
            //if (e.CommandName == "viewGR")
            //{
            //    DataSet dsPrdctid = new DataSet();
            //    dsPrdctid = dbObj.Selecttranspo();

            //    if (dsPrdctid.Tables[0].Rows.Count > 0)
            //    {

            //        int iProductid = Convert.ToInt32(dsPrdctid.Tables[0].Rows[0]["ProductId"].ToString());
            //        int iPoid = Convert.ToInt32(e.CommandArgument);
            //        Response.Redirect("GoodsReceipts.aspx?PoId=" + iPoid + "ProductId=" + iProductid + "Total=" + ));
            //    }
            //}
            if (e.CommandName == "viewGR")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                string Poid =gvProduct.Rows[index].Cells[1].Text.ToString();
                string ProductId = gvProduct.Rows[index].Cells[2].Text;
                string name = gvProduct.Rows[index].Cells[3].Text;
                TextBox myTextBox = (TextBox)(gvProduct.Rows[index].FindControl("txtReceivedqty"));
                string Total = myTextBox.Text;
                string redirectUri = "GoodsReceipts.aspx?Event=viewGR&Poid=" + HttpUtility.UrlEncode(Poid) + "&Productid=" + HttpUtility.UrlEncode(ProductId) + "&name=" + HttpUtility.UrlEncode(name) + "&Total=" + HttpUtility.UrlEncode(Total);
                Response.Redirect(redirectUri);
              //  Response.Redirect("GoodsReceipts.aspx?Event=viewGR&Poid="+Poid+"&Productid="+ProductId+"&name="+name+"&Total="+Total);
            }
            }
            //private void BindProductGrid()
            //{

            //    DataSet dsProduct = new DataSet();
            //    dsProduct = dbObj.GRview(Convert.ToInt32(iPoid));
            //    if (dsProduct.Tables[0].Rows.Count > 0)
            //    {
            //        gvProduct.DataSource = dsProduct.Tables[0];
            //        gvProduct.DataBind();
            //    }
            //}
        }
    }
