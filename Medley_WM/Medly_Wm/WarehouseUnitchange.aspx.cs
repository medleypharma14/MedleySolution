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
    public partial class WraehouseUnitchange : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
        int iProductID = 0; int Empid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                #region
                DataSet dsUnits1 = new DataSet();
                dsUnits1 = dbObj.Select_Units1();
                if (dsUnits1.Tables[0].Rows.Count > 0)
                {
                    ddUnits1.DataSource = dsUnits1.Tables[0];
                    ddUnits1.DataBind();
                }
                DataSet dsUnits2 = new DataSet();
                dsUnits2 = dbObj.Select_Units2();
                if (dsUnits2.Tables[0].Rows.Count > 0)
                {
                    ddUnits2.DataSource = dsUnits2.Tables[0];
                    ddUnits2.DataBind();
                }
                DataSet dsUnits3 = new DataSet();
                dsUnits3 = dbObj.Select_Units3();
                if (dsUnits3.Tables[0].Rows.Count > 0)
                {
                    ddUnits3.DataSource = dsUnits3.Tables[0];
                    ddUnits3.DataBind();
                }
                DataSet dsUnits4 = new DataSet();
                dsUnits4 = dbObj.Select_Units4();
                if (dsUnits4.Tables[0].Rows.Count > 0)
                {
                    ddUnits4.DataSource = dsUnits4.Tables[0];
                    ddUnits4.DataBind();
                }
                #endregion
                #region Dropdown Approver
                DataSet dsApprovar = new DataSet();
                dsApprovar = dbObj.Select_Employeename();
                if (dsApprovar.Tables[0].Rows.Count > 0)
                {
                    ddlSelectapprover.DataSource = dsApprovar;
                    ddlSelectapprover.DataTextField = "EmployeeName";
                    ddlSelectapprover.DataValueField = "EmployeeID";
                    ddlSelectapprover.DataBind();
                    ddlSelectapprover.Items.Insert(0, "Select Approver");
                }
                #endregion
                if (Request.Cookies["userInfo"]["EmployeeID"] != null && Request.Cookies["userInfo"]["Empname"] != null)
                {
                    Empid = Convert.ToInt32(Request.Cookies["userInfo"]["EmployeeID"]);


                }
            }
        }
        protected void ddRoomListSecond_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            int count = ddUnits1.Items.Count;
            //foreach (DataListItem dl in ddRoomListALL.Items)
            // for (int i = 0; i < count; i++)
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                Button btn = (Button)e.Item.FindControl("btns1");
                if (btn.CommandName == "0")
                {
                    btn.BackColor = System.Drawing.Color.Gray;
                    btn.ForeColor = System.Drawing.Color.White;
                }
                else if (btn.CommandName == "1")
                {
                    btn.BackColor = System.Drawing.Color.Green;
                    btn.ForeColor = System.Drawing.Color.White;

                    //btn.Enabled = false;
                }

            }
        }
        protected void btnClick(object sender, EventArgs e)
        {

            Button Btn = (sender as Button);
            Session["UnitId"] = Btn.CommandArgument.ToString();
            DataSet dsUnit = dbObj.Select_UnitsQty_byname(Session["UnitId"].ToString());
            if (dsUnit.Tables[0].Rows.Count > 0)
            {
                string FinalQty = dsUnit.Tables[0].Rows[0]["FinalbatchQty"].ToString();
                if (FinalQty != "0")
                {
                    int Grid = Convert.ToInt32(dsUnit.Tables[0].Rows[0]["GRId"].ToString());
                    DataSet dsUnit1 = dbObj.LoadGoodReceiptbyID(Grid);
                    if (dsUnit1.Tables[0].Rows.Count > 0)
                    {
                        string Code = dsUnit1.Tables[0].Rows[0]["ProductCode"].ToString();
                        string Name = dsUnit1.Tables[0].Rows[0]["ProductName"].ToString();
                        string Qty = dsUnit.Tables[0].Rows[0]["Qty"].ToString();
                        string SamQty = dsUnit.Tables[0].Rows[0]["SampleQty"].ToString();
                        string batch = dsUnit.Tables[0].Rows[0]["Batchnumber"].ToString();
                        string Bind = "Product Code: " + Code + ", Product Name: " + Name + ", Order Quantity: " + Qty + ", Sample Quantity: " + SamQty + ", Final Batch Quantity: " + FinalQty + ",  Batch Number: " + batch;
                        lblDisplay.Text = Bind;
                        string script = "alert('" + Bind + "');";
                        ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                        // ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert("+ Qty + ");", true);
                    }
                }
                else
                {
                    string script = "alert('Product Mismatch');";
                    ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                }
            }

        }

        protected void txtPreviousunit_TextChanged(object sender, EventArgs e)
        {
            if (txtPreviousunit.Text != "")
            {
                DataSet dsPrevUnit = dbObj.CheckPreviousunit(txtPreviousunit.Text);
                if (dsPrevUnit != null)
                {
                    if (dsPrevUnit.Tables[0].Rows.Count > 0)
                    {
                        int isempty = Convert.ToInt32(dsPrevUnit.Tables[0].Rows[0]["Isempty"].ToString());
                        if (isempty == 0)
                        {
                            lblprnm.Visible = true;
                            lblProductname.Visible = true;
                            lblProductname.Text = dsPrevUnit.Tables[0].Rows[0]["Productname"].ToString();
                            lblqty.Visible = true;
                            lblQuantity.Visible = true;
                            lblQuantity.Text = dsPrevUnit.Tables[0].Rows[0]["TotalQty"].ToString();
                            lblExpry.Visible = true;
                            lblExpryDate.Visible = true;
                            lblExpryDate.Text =((DateTime)dsPrevUnit.Tables[0].Rows[0]["Expirydate"]).ToString("yyyy-MM-dd");
                        }
                        else
                        {
                            string script = "alert('Given Unit don't have a product');";
                            ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                        }

                    }
                    else
                    {
                        string script = "alert('Given Unit don't have a product');";
                        ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                    }
                }
                else
                {
                    string script = "alert('Given Unitname Not avalable in Warehouse');";
                    ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                }

            }
            else
            {
                string script = "alert(' please  Enter Previous  Unitname');";
                ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
            }
        }

        protected void txtChangeunit_TextChanged(object sender, EventArgs e)
        {
            if (txtChangeunit.Text != "")
            {
                DataSet dsChangUnit = dbObj.CheckChangeunit(txtChangeunit.Text);
                if (dsChangUnit != null)
                {
                    if (dsChangUnit.Tables[0].Rows.Count > 0)
                    {
                        int isempty = Convert.ToInt32(dsChangUnit.Tables[0].Rows[0]["Isempty"].ToString());
                        if (isempty != 0)
                        {
                            lblp.Visible = true;
                            lblpn.Visible = true;
                            lblpn.Text = dsChangUnit.Tables[0].Rows[0]["ProductId"].ToString();
                            lblq.Visible = true;
                            lblqy.Visible = true;
                            lblqy.Text = dsChangUnit.Tables[0].Rows[0]["TotalQty"].ToString();
                            lble.Visible = true;
                            lbled.Visible = true;
                            lbled.Text = ((DateTime)dsChangUnit.Tables[0].Rows[0]["Expirydate"]).ToString("yyyy-MM-dd");
                        }
                        else
                        {
                            string script = "alert('Given Unit Already have a product');";
                            ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                        }

                    }
                    else
                    {
                        string script = "alert('Given Unitname Not avalable in Warehouse');";
                        ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                    }
                }
                else
                {
                    string script = "alert('Given Unitname Not avalable in Warehouse');";
                    ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                }
            }
            else
            {
                string script = "alert('please  Enter Change  Unitname');";
                ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
            }
        }
    }
}