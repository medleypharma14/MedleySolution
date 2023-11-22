using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Globalization;
using System.Data.SqlClient;
using System.Text;
using System.IO;


namespace AdminAfforadbleApp
{
    public partial class TicketHistory : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string iTicketid = Request.QueryString.Get("iTicketid");

                if (iTicketid != null)
                {
                    #region TicketHistory
                    DataSet dsOwner;
                    dsOwner = dbObj.GetTicketHistory(iTicketid);
                     if (dsOwner.Tables[0].Rows.Count > 0)
            {
               GVTicketview.DataSource = dsOwner;
                GVTicketview.DataBind();
            }
            else
            {
                GVTicketview.DataSource = null;
                GVTicketview.DataBind();
            }

                    #endregion

                     DataSet ds1 = dbObj.BindTicketsDetailed(iTicketid);
                    if (ds1 != null)
                    {
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            hdTicketID.Value = ds1.Tables[0].Rows[0]["ticketid"].ToString();
                            txtTicketNo.Text = ds1.Tables[0].Rows[0]["ticketno"].ToString();
                            txtTicketDate.Text = ds1.Tables[0].Rows[0]["ticketdatetime"].ToString();
                            txtCustomerName.Text = ds1.Tables[0].Rows[0]["customername"].ToString();
                            txtProductName.Text = ds1.Tables[0].Rows[0]["productname"].ToString();
                            txtWarrantyYear.Text = ds1.Tables[0].Rows[0]["warrantyyear"].ToString();
                            txtWarrantyMonth.Text = ds1.Tables[0].Rows[0]["warrantymonth"].ToString();
                            txtDescription.Text = ds1.Tables[0].Rows[0]["description"].ToString();
                            txtTeamLeader.Text = ds1.Tables[0].Rows[0]["TeamLeader"].ToString();
                            txtServiceengineername.Text = ds1.Tables[0].Rows[0]["Serviceengineername"].ToString();
                            ddlStatus.SelectedValue = ds1.Tables[0].Rows[0]["status"].ToString();
                        }
                    }
                }
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ticketdetails.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (hdTicketID.Value == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('TicketID is Empty');", true);
                hdTicketID.Focus();
                return;
            }
            else
            {
                int i = dbObj.UpdateTicketStatus(hdTicketID.Value, ddlStatus.SelectedValue);
                Response.Redirect("Ticketdetails.aspx");
            }
        }

        protected void GVTicketview_Rowcommand(object sender, GridViewCommandEventArgs e)
        {
           

            if (e.CommandName == "Download")
            {
                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("Content-Disposition", "filename=" + e.CommandArgument);
                Response.TransmitFile(Server.MapPath("~/") + e.CommandArgument);
                Response.End();
            }


        }
       
        }
    
}
