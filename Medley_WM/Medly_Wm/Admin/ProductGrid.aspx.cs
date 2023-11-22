using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Text;

namespace HomeAlertsAdmin.Admin
{
    public partial class ProductGrid : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        public static BSClass ObjStatic = new BSClass();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                #region Grid
                DataSet dsOwner;
                dsOwner = objBs.BindProduct();

                StringBuilder spList = new StringBuilder();
                for (int i = 0; i < dsOwner.Tables[0].Rows.Count; i++)
                {
                    string ProductId = dsOwner.Tables[0].Rows[i]["ProductId"].ToString();
                    string CategoryName = dsOwner.Tables[0].Rows[i]["CategoryName"].ToString();
                    string ProductName = dsOwner.Tables[0].Rows[i]["ProductName"].ToString();
                    string ModalNo = dsOwner.Tables[0].Rows[i]["ModalNo"].ToString();
                    string WarrantyYear = dsOwner.Tables[0].Rows[i]["WarrantyYear"].ToString();
                    string WarrantyMonth = dsOwner.Tables[0].Rows[i]["WarrantyMonth"].ToString();
                string videourl=dsOwner.Tables[0].Rows[i]["VideoURL"].ToString();

                   // string status = dsOwner.Tables[0].Rows[i]["status"].ToString();
                    spList.Append("			    	   <tr >" +
                      "  <td  style='display:none'>" +
                                               " <label class='mt-checkbox mt-checkbox-single mt-checkbox-outline' style='display:none'>" +
                                                    "<input type='checkbox' class='checkboxes' value='1' />" +
                                                    "<span></span>" +
                                                "</label>" +
                                           " </td>" +

                                        "                       <td>" + CategoryName  + "</td>" +
                                       "			    		<td>" + ProductName  + "</td>" +
                                        "			    		<td>" + ModalNo  + "</td>" +
                                           "			    	<td>" + WarrantyYear + "</td>" +
                                           "			    	<td>" + WarrantyMonth + "</td>" +
                                           // "			    	<td>" + status + "</td>" +
                                           
                           " <td>"+"<video width='80' height='80' controls controlsList='nodownload'>" +
                               " <source  type='video/mp4'  src=" + videourl + " >" +  
                            "</video> " +"</td>"
                       +
                                       "			    		<td>" +
                        " <div class='btn-group'>" +
                                                         "<button class='btn btn-xs green dropdown-toggle' type='button' data-toggle='dropdown' aria-expanded='false'> Actions" +
                                                             "<i class='fa fa-angle-down'></i>" +
                        " </button>" +

                                                    " <ul class='dropdown-menu pull-left' role='menu'>" +
                        "<li>" +
                            "<a href=ProductMaster.aspx?Productid=" + ProductId + ">" +
                                "<i class='fa fa-pencil'></i> Edit </a>" +
                        "</li>" +
                        "<li>" +
                            "<a><asp:LinkButton ID='btndelete' runat='server' onclick=Delete('" + ProductId + "','" + ProductId + "')> " +
                                "<i class='fa fa-trash-o'></i> Delete </a>" +
                        "</li>" +
                               " </ul>" +
                        "</div>" +
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
            Response.Redirect("ProductMaster.aspx");
        }


    }
}