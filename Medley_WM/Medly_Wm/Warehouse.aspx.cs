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
    public partial class Warehouse : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
        int iProductID = 0; int Empid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region Product Dropdown
                DataSet Productlist = dbObj.Select_UnitProduct();
                if (Productlist.Tables[0].Rows.Count > 0)
                {
                    ddlProductname.DataSource = Productlist;
                    ddlProductname.DataTextField = "Productname";
                    ddlProductname.DataValueField = "Productid";
                    ddlProductname.DataBind();
                    ddlProductname.Items.Insert(0, "Select Productname");
                }


                #endregion

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
                //DataSet dsProdId = new DataSet();
                //dsProdId = dbObj.selectProduct_byProductId(iProductID);
                //int ApproverId = Convert.ToInt32(dsProdId.Tables[0].Rows[0]["Approvarid"].ToString());
                //if (ApproverId == Empid)
                //{
                //    ddlStatus.Enabled = true;
                //}
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

                //if (btn.CommandName == "1")
                //{
                //    btn.BackColor = System.Drawing.Color.Red;
                //    btn.ForeColor = System.Drawing.Color.White;
                //}
                //else if (btn.CommandName == "2")
                //{
                //    btn.BackColor = System.Drawing.Color.Blue;
                //    btn.ForeColor = System.Drawing.Color.White;

                //    //btn.Enabled = false;
                //}
                //else if (btn.CommandName == "3")
                //{
                //    btn.BackColor = System.Drawing.Color.Green;
                //    btn.ForeColor = System.Drawing.Color.White;

                //    //btn.Enabled = false;
                //}
                //else
                //{
                //    btn.BackColor = System.Drawing.Color.Yellow;
                //    btn.ForeColor = System.Drawing.Color.White;

                //    //btn.Enabled = false;
                //}

            }
        }
        protected void btnClick(object sender, EventArgs e)
        {

            //    Button cat = (sender as Button);
            //
             
            //    if (cat.BackColor == System.Drawing.Color.Blue)
            //    {
            //        ScriptManager.RegisterStartupScript(upan, upan.GetType(), "myFunctions", "myFunctions();", true);
            //        Button roomNo = (sender as Button);
            //string testRoomNo = Convert.ToString(roomNo.Text);
            ////string result = testRoomNo.Substring(0, testRoomNo.IndexOf("-"));
            //string result = testRoomNo;
            //DataSet ds = Rmc.UnCleanedRoomsToCleanedRooms(result);
            //Response.Redirect("Reception.aspx");
            //    };

            Button Btn = (sender as Button);
            Session["UnitId"] = Btn.CommandArgument.ToString();
            //DataSet dsUnit = dbObj.Select_UnitsCheck(Convert.ToInt32(Session["UnitId"].ToString()));
            //if (dsUnit.Tables[0].Rows.Count > 0)
            //{
            //    lblFloor.Text = dsUnit.Tables[0].Rows[0]["Floor"].ToString();
            //    lblUnit.Text = dsUnit.Tables[0].Rows[0]["Unitname"].ToString();


            //}
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
                        string Qty = dsUnit.Tables[0].Rows[0]["TotalQty"].ToString();
                        string SamQty = dsUnit.Tables[0].Rows[0]["SampleQty"].ToString();
                        string batch = dsUnit.Tables[0].Rows[0]["Batchnumber"].ToString();
                        string Expryday =dsUnit.Tables[0].Rows[0]["Expirydate"].ToString();
                        string Bind = "Product Code: " + Code + ", Product Name: " + Name + ", Order Quantity: " + Qty + ", Sample Quantity: " + SamQty + ", Final Batch Quantity: " + FinalQty + ",  Batch Number: " + batch+",Expiry Date:"+Convert.ToDateTime(Expryday).Date.ToString("dd-MM-yyyy");
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

        protected void ddlProductname_TextChanged(object sender, EventArgs e)
        {
            if (ddlProductname.SelectedValue != "0" && ddlProductname.SelectedValue != "Select Productname")
            {
                DataSet Unitdetails = dbObj.Select_Unitdetail(Convert.ToInt32(ddlProductname.SelectedValue));
                if (Unitdetails.Tables[0].Rows.Count > 0)
                {
                    gvProductDetails.Visible = true;
                    gvProductDetails.DataSource = Unitdetails;
                    gvProductDetails.DataBind();

                    DataSet unitbatch = dbObj.Select_Unitbatchname(Convert.ToInt32(ddlProductname.SelectedValue));
                    ddlBatchNumber.DataSource = unitbatch;
                    ddlBatchNumber.DataTextField = "Batchnumber";
                    ddlBatchNumber.DataBind();
                    ddlBatchNumber.Items.Insert(0, "Select Batch Number");

                }
                else
                {
                    gvProductDetails.Visible = false; gvProductDetails.DataSource = null;
                    string script = "alert('No Product Available...')";
                    ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                }
            }
            else
            {
                gvProductDetails.Visible = false; gvProductDetails.DataSource = null;
                string script = "alert('Please Slecet Product Name ...')";
                ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                //ddlBatchNumber.SelectedValue = "";
            }
        }

        protected void ddlBatchNumber_TextChanged(object sender, EventArgs e)
        {
            if (ddlBatchNumber.SelectedValue != "0" && ddlBatchNumber.SelectedValue != "Select Batch Number")
            {
                DataSet Unitbatchdetails = dbObj.Select_UnitBatchdetail(Convert.ToInt32(ddlProductname.SelectedValue), ddlBatchNumber.SelectedItem.Text);
                if (Unitbatchdetails.Tables[0].Rows.Count > 0)
                {
                    gvProductDetails.Visible = true;
                    gvProductDetails.DataSource = Unitbatchdetails;
                    gvProductDetails.DataBind();
                }
                else
                {
                    gvProductDetails.Visible = false; gvProductDetails.DataSource = null;
                    string script = "alert('No Batch Available...')";
                    ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                }
            }
            else
            {
                gvProductDetails.Visible = false; gvProductDetails.DataSource = null;
                string script = "alert('Please Select Batch Number...')";
                ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                //ddlBatchNumber.SelectedValue = "";
            }
        }

        //protected void Check_Click(object sender, EventArgs e)
        //{
        //    if (ddlNumberoffloors.SelectedValue == "1")
        //    {
        //        DataSet dsUnits1 = new DataSet();
        //        dsUnits1 = dbObj.Select_Units1();
        //        if (dsUnits1.Tables[0].Rows.Count > 0)
        //        {
        //            ddUnits1.DataSource = dsUnits1.Tables[0];
        //            ddUnits1.DataBind();
        //        }
        //    }

        //    if (ddlNumberoffloors.SelectedValue == "2")
        //    {
        //        DataSet dsUnits2 = new DataSet();
        //        dsUnits2 = dbObj.Select_Units2();
        //        if (dsUnits2.Tables[0].Rows.Count > 0)
        //        {
        //            ddUnits2.DataSource = dsUnits2.Tables[0];
        //            ddUnits2.DataBind();
        //        }
        //    }

        //    else if (ddlNumberoffloors.SelectedValue == "3")
        //    {
        //        DataSet dsUnits3 = new DataSet();
        //        dsUnits3 = dbObj.Select_Units3();
        //        if (dsUnits3.Tables[0].Rows.Count > 0)
        //        {
        //            ddUnits3.DataSource = dsUnits3.Tables[0];
        //            ddUnits3.DataBind();
        //        }
        //    }
        //    else if (ddlNumberoffloors.SelectedValue == "4")
        //    {
        //        DataSet dsUnits4 = new DataSet();
        //        dsUnits4 = dbObj.Select_Units4();
        //        if (dsUnits4.Tables[0].Rows.Count > 0)
        //        {
        //            ddUnits4.DataSource = dsUnits4.Tables[0];
        //            ddUnits4.DataBind();
        //        }
        //    }
        //}

        //protected void btnsave_Click(object sender, EventArgs e)
        //{
        //    int isucess = 0;
        //    isucess = dbObj.Insert_Warehouse(txtWarehousename.Text,txtWarehousecode.Text,lblFloor.Text, lblUnit.Text, txtunity.Text, ddlSelectapproval.SelectedItem.Text);
        //    //Response.Redirect("../Accountsbootstrap/viewbranch.aspx");
        //    string script = "alert('Data Saved')";
        //    ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
        //    Response.Redirect("WareHouseGridpage.aspx");
        //}
    }
}