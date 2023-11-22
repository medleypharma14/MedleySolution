using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medly_Wm
{
    public partial class AddCustomer : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int isucess = 0;
            isucess = dbObj.InsertAddCustomer(Convert.ToDateTime(txtInitialadditiondate.Text), txtCustomername.Text, txtContactname.Text,txtContactemail.Text,txtContactNumber.Text, Convert.ToDateTime(txtValidtill.Text),ddlDefaultcurrency.SelectedItem.Text, ddlCustomerstatus.SelectedItem.Text, ddlCustomerqualification.SelectedItem.Text, txtAddressline1.Text, txtAddressline2.Text, txtAddressline3.Text, txtTown.Text, ddlCountry.SelectedItem.Text,txtPostcode.Text, ddlSelectapprover.SelectedItem.Text);
            //Response.Redirect("../Accountsbootstrap/viewbranch.aspx");
            string script = "alert('Data Saved')";
            ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
        }
    }
}