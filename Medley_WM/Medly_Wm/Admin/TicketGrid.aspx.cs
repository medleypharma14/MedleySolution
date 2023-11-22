using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;
using System.Text;
using System.IO;
using System.Data.OleDb;

namespace BFEcommerce
{
    public partial class TicketGrid : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        public static BSClass ObjStatic = new BSClass();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                #region Grid
                DataSet dsOwner;
                dsOwner = objBs.BindTickets();

                StringBuilder spList = new StringBuilder();
                for (int i = 0; i < dsOwner.Tables[0].Rows.Count; i++)
                {
                    string Ticketid = dsOwner.Tables[0].Rows[i]["Ticketid"].ToString();
                    string ticketno = dsOwner.Tables[0].Rows[i]["ticketno"].ToString();
                    string ticketdatetime = dsOwner.Tables[0].Rows[i]["ticketdatetime"].ToString();
                    string customername = dsOwner.Tables[0].Rows[i]["customername"].ToString();
                    string productname = dsOwner.Tables[0].Rows[i]["productname"].ToString();
                    string TeamLeader = dsOwner.Tables[0].Rows[i]["TeamLeader"].ToString();
                    string status = dsOwner.Tables[0].Rows[i]["status"].ToString();
                    spList.Append("			    	   <tr >" +
                      "  <td  style='display:none'>" +
                                               " <label class='mt-checkbox mt-checkbox-single mt-checkbox-outline' style='display:none'>" +
                                                    "<input type='checkbox' class='checkboxes' value='1' />" +
                                                    "<span></span>" +
                                                "</label>" +
                                           " </td>" +

                                        "                       <td>" + ticketno + "</td>" +
                                       "			    		<td>" + ticketdatetime + "</td>" +
                                        "			    		<td>" + customername + "</td>" +
                                           "			    	<td>" + productname + "</td>" +
                                           "			    	<td>" + TeamLeader + "</td>" +
                                            "			    	<td>" + status + "</td>" +
                                    //   "			    		<td>" +
                  //" <div class='btn-group'>" +
                  //                                  "<button class='btn btn-xs green dropdown-toggle' type='button' data-toggle='dropdown' aria-expanded='false'> Actions" +
                  //                                      "<i class='fa fa-angle-down'></i>" +
                                                   //" </button>" +

                                                    //" <ul class='dropdown-menu pull-left' role='menu'>" +
                                                    //    "<li>" +
                                                    //        "<a href=ticket.aspx?iProductid=" + Ticketid + ">" +
                                                    //            "<i class='fa fa-pencil'></i> Status Update </a>" +
                                                    //    "</li>" +
                                                        //"<li>" +
                                                        //    "<a><asp:LinkButton ID='btndelete' runat='server' onclick=Delete('" + Ticketid + "','" + Ticketid + "')> " +
                                                        //        "<i class='fa fa-trash-o'></i> Delete </a>" +
                                                        //"</li>" +
                                                   //       " </ul>" +
                                                   //"</div>" +
                            "			    		</td>" +

                                    "			    	</tr>");

                }


                lblTable.Text = spList.ToString();
                #endregion
            }
        }

        [System.Web.Services.WebMethod]
        public static string GoDeletePropertyType(string PropertyTypeID, string UserID)
        {
            var data = "200";
            //int iUpdate = ObjStatic.ProductDelete(Convert.ToInt32(PropertyTypeID));
            return data;
        }

        protected void btnadd_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Ticket.aspx");
        }


    }
}