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
    public partial class EmployeeGrid : System.Web.UI.Page
    {
        BSClass objBs = new BSClass();
        public static BSClass ObjStatic = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                #region Grid
                DataSet dsOwner;
                dsOwner = objBs.BindEmployee();

                StringBuilder spList = new StringBuilder();
                for (int i = 0; i < dsOwner.Tables[0].Rows.Count; i++)
                {
                    string EmployeeName = dsOwner.Tables[0].Rows[i]["EmpName"].ToString();
                    string Designation = dsOwner.Tables[0].Rows[i]["Designation"].ToString();
                    string UserName = dsOwner.Tables[0].Rows[i]["UserName"].ToString();
                    string MobileNo = dsOwner.Tables[0].Rows[i]["MobileNo"].ToString();
                    string Email = dsOwner.Tables[0].Rows[i]["Email"].ToString();
                    string EmployeeId = dsOwner.Tables[0].Rows[i]["EmployeeId"].ToString();

                    // string status = dsOwner.Tables[0].Rows[i]["status"].ToString();
                    spList.Append("			    	   <tr >" +
                      "  <td  style='display:none'>" +
                                               " <label class='mt-checkbox mt-checkbox-single mt-checkbox-outline' style='display:none'>" +
                                                    "<input type='checkbox' class='checkboxes' value='1' />" +
                                                    "<span></span>" +
                                                "</label>" +
                                           " </td>" +

                                        "                       <td>" + EmployeeName + "</td>" +
                                       "			    		<td>" + Designation + "</td>" +
                                        "			    		<td>" + UserName + "</td>" +
                                           "			    	<td>" + MobileNo + "</td>" +
                                           "			    	<td>" + Email + "</td>" +
                        // "			    	<td>" + status + "</td>" +
                                       "			    		<td>" +
                        " <div class='btn-group'>" +
                                                         "<button class='btn btn-xs green dropdown-toggle' type='button' data-toggle='dropdown' aria-expanded='false'> Actions" +
                                                             "<i class='fa fa-angle-down'></i>" +
                        " </button>" +

                                                    " <ul class='dropdown-menu pull-left' role='menu'>" +
                        "<li>" +
                            "<a href=EmployeeMaster.aspx?EmployeeId=" + EmployeeId + ">" +
                                "<i class='fa fa-pencil'></i> Edit </a>" +
                        "</li>" +
                        "<li>" +
                            "<a><asp:LinkButton ID='btndelete' runat='server' onclick=Delete('" + EmployeeId + "','" + EmployeeId + "')> " +
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
        public static string GoDeletePropertyType(string PropertyTypeID)
        {
            var data = "200";
           int iUpdate = ObjStatic.delete_Employee(PropertyTypeID);
            return data;
        }

        protected void btnadd_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeMaster.aspx");
        }

    }
}