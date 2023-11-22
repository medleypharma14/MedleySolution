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

namespace AdminAfforadbleApp
{
    public partial class Ticket : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCustomer();
                //LoadProduct();
                LoadTeamLeader();

                DataSet dsCatcode = dbObj.getTicketNo();
                txtTicketNo.Text = dsCatcode.Tables[0].Rows[0]["TicketNo"].ToString();

                txtTicketDate.Text = DateTime.Today.ToString("dd/MM/yyyy hh:mm:ss");
               
                #region Service To Ticket
                string Today=DateTime.Today.ToString("yyyy-MM-dd");
                string Cid =Request.QueryString.Get("customerid");
                if(Cid != "" || Cid != null)
                {
                LoadProduct();
                DataSet dsTicket = dbObj.NextServiceDetails_Bydate_Byid(Today, Convert.ToInt32(Cid));
                ddlCustomer.SelectedValue = dsTicket.Tables[0].Rows[0]["customerid"].ToString();
                ddlProduct.SelectedValue = dsTicket.Tables[0].Rows[0]["productid"].ToString();
                if (ddlProduct.SelectedItem.Text != "Select Product")
                {
                    DataSet dsProdDet1 = dbObj.getProductDetails(ddlProduct.SelectedValue);
                    if (dsProdDet1.Tables[0].Rows.Count > 0)
                    {
                        txtActualWarranty.Text = dsProdDet1.Tables[0].Rows[0]["Warrantyyear"].ToString() + " Years and " + dsProdDet1.Tables[0].Rows[0]["Warrantymonth"].ToString() + " Months ";
                    }
                    else
                    {
                        txtActualWarranty.Text = "";
                    }


                    DataSet dsProdDet = dbObj.getProductDetails_Date(ddlProduct.SelectedValue, ddlCustomer.SelectedValue);
                    if (dsProdDet.Tables[0].Rows.Count > 0)
                    {
                        txtPurDate.Text = Convert.ToDateTime(dsProdDet.Tables[0].Rows[0]["PurchaseDate"]).ToString("dd/MM/yyyy");
                        DateTime Dob = DateTime.ParseExact(Convert.ToDateTime(dsProdDet.Tables[0].Rows[0]["PurchaseDate"]).ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        //DateTime dob = Convert.ToDateTime(txtMRCDate.Text.ToString("yyyy/MM/dd")); //("1988/12/20");
                        //string text = CalculateYourAge(Dob);

                        DateTime Now = DateTime.Now;
                        int Years = new DateTime(DateTime.Now.Subtract(Dob).Ticks).Year - 1;
                        DateTime PastYearDate = Dob.AddYears(Years);
                        int Months = 0;
                        for (int i = 1; i <= 12; i++)
                        {
                            if (PastYearDate.AddMonths(i) == Now)
                            {
                                Months = i;
                                break;
                            }
                            else if (PastYearDate.AddMonths(i) >= Now)
                            {
                                Months = i - 1;
                                break;
                            }
                        }
                        int Days = Now.Subtract(PastYearDate.AddMonths(Months)).Days;
                        int Hours = Now.Subtract(PastYearDate).Hours;
                        int Minutes = Now.Subtract(PastYearDate).Minutes;
                        int Seconds = Now.Subtract(PastYearDate).Seconds;

                        txtWarrantyyear.Text = Years.ToString();
                        txtWarrantymonth.Text = Months.ToString();


                        //txtWarrantyyear.Text = dsProdDet.Tables[0].Rows[0]["Warrantyyear"].ToString();
                        //txtWarrantymonth.Text = dsProdDet.Tables[0].Rows[0]["Warrantymonth"].ToString();
                    }
                    else
                    {
                        txtPurDate.Text = "";
                        txtWarrantyyear.Text = "";
                        txtWarrantymonth.Text = "";
                    }
                }
                }
                #endregion
            }


        }

        protected void LoadCustomer()
        {
            DataSet dsCustomer = dbObj.BindCustomerTicket();
            if (dsCustomer != null)
            {
                if (dsCustomer.Tables[0].Rows.Count > 0)
                {
                    ddlCustomer.DataSource = dsCustomer;
                    ddlCustomer.DataTextField = "Customername";
                    ddlCustomer.DataValueField = "CustomerId";
                    ddlCustomer.DataBind();
                    ddlCustomer.Items.Insert(0, "Select Customer");
                }
            }
        }

        protected void LoadProduct()
        {
            DataSet dsProduct = dbObj.BindProduct();
            if (dsProduct != null)
            {
                if (dsProduct.Tables[0].Rows.Count > 0)
                {
                    ddlProduct.DataSource = dsProduct;
                    ddlProduct.DataTextField = "ProductName";
                    ddlProduct.DataValueField = "ProductId";
                    ddlProduct.DataBind();
                    ddlProduct.Items.Insert(0, "Select Product");
                }
            }
        }

        protected void LoadTeamLeader()
        {
            DataSet dsTeamLeader = dbObj.BindTeamLeader("1");
            if (dsTeamLeader != null)
            {
                if (dsTeamLeader.Tables[0].Rows.Count > 0)
                {
                    ddlTeamLeader.DataSource = dsTeamLeader;
                    ddlTeamLeader.DataTextField = "EmpName";
                    ddlTeamLeader.DataValueField = "EmployeeId";
                    ddlTeamLeader.DataBind();
                    ddlTeamLeader.Items.Insert(0, "Select TeamLeader");
                }
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ticketgrid.aspx");
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtTicketNo.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Enter Ticket No');", true);
                txtTicketNo.Focus();
                return;
            }
            if (txtTicketDate.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Enter Ticket Date');", true);
                txtTicketDate.Focus();
                return;
            }

            if (ddlTeamLeader.SelectedValue == "Select TeamLeader")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Select TeamLeader');", true);
                ddlTeamLeader.Focus();
                return;
            }

            if (ddlCustomer.SelectedValue == "Select Customer")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Select Customer');", true);
                ddlCustomer.Focus();
                return;
            }

            if (ddlProduct.SelectedValue == "Select Product")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Select Product');", true);
                ddlProduct.Focus();
                return;
            }

            if (txtWarrantyyear.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Enter Year');", true);
                txtWarrantyyear.Focus();
                return;
            }
            if (txtWarrantymonth.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Enter Month');", true);
                txtWarrantymonth.Focus();
                return;
            }

            if (txtTicketDescription.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Enter Ticket Description');", true);
                txtTicketDescription.Focus();
                return;
            }

            int iSuccess = dbObj.insert_Ticket(txtTicketNo.Text, txtTicketDate.Text, ddlCustomer.SelectedValue, ddlProduct.SelectedValue, txtWarrantyyear.Text, txtWarrantymonth.Text, txtTicketDescription.Text, ddlTeamLeader.SelectedValue, "Open");
            Response.Redirect("TicketGrid.aspx");
        }

        protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProduct.SelectedItem.Text != "Select Product")
            {
                DataSet dsProdDet1 = dbObj.getProductDetails(ddlProduct.SelectedValue);
                if (dsProdDet1.Tables[0].Rows.Count > 0)
                {
                    txtActualWarranty.Text =  dsProdDet1.Tables[0].Rows[0]["Warrantyyear"].ToString() + " Years and " + dsProdDet1.Tables[0].Rows[0]["Warrantymonth"].ToString() + " Months ";
                }
                else
                {
                    txtActualWarranty.Text = "";
                }


                DataSet dsProdDet = dbObj.getProductDetails_Date(ddlProduct.SelectedValue,ddlCustomer.SelectedValue);
                if (dsProdDet.Tables[0].Rows.Count > 0)
                {
                    txtPurDate.Text = Convert.ToDateTime(dsProdDet.Tables[0].Rows[0]["PurchaseDate"]).ToString("dd/MM/yyyy");
                    DateTime Dob = DateTime.ParseExact(Convert.ToDateTime(dsProdDet.Tables[0].Rows[0]["PurchaseDate"]).ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    //DateTime dob = Convert.ToDateTime(txtMRCDate.Text.ToString("yyyy/MM/dd")); //("1988/12/20");
                    //string text = CalculateYourAge(Dob);

                    DateTime Now = DateTime.Now;
                    int Years = new DateTime(DateTime.Now.Subtract(Dob).Ticks).Year - 1;
                    DateTime PastYearDate = Dob.AddYears(Years);
                    int Months = 0;
                    for (int i = 1; i <= 12; i++)
                    {
                        if (PastYearDate.AddMonths(i) == Now)
                        {
                            Months = i;
                            break;
                        }
                        else if (PastYearDate.AddMonths(i) >= Now)
                        {
                            Months = i - 1;
                            break;
                        }
                    }
                    int Days = Now.Subtract(PastYearDate.AddMonths(Months)).Days;
                    int Hours = Now.Subtract(PastYearDate).Hours;
                    int Minutes = Now.Subtract(PastYearDate).Minutes;
                    int Seconds = Now.Subtract(PastYearDate).Seconds;

                    txtWarrantyyear.Text = Years.ToString();
                    txtWarrantymonth.Text = Months.ToString();


                    //txtWarrantyyear.Text = dsProdDet.Tables[0].Rows[0]["Warrantyyear"].ToString();
                    //txtWarrantymonth.Text = dsProdDet.Tables[0].Rows[0]["Warrantymonth"].ToString();
                }
                else
                {
                    txtPurDate.Text = "";
                    txtWarrantyyear.Text = "";
                    txtWarrantymonth.Text = "";
                }
            }
        }

        protected void ddlCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCustomer.SelectedItem.Text != "Select Customer")
            {
                DataSet dsProduct = dbObj.BindProduct_Customer(ddlCustomer.SelectedValue);
                if (dsProduct != null)
                {
                    if (dsProduct.Tables[0].Rows.Count > 0)
                    {
                        ddlProduct.DataSource = dsProduct;
                        ddlProduct.DataTextField = "ProductName";
                        ddlProduct.DataValueField = "ProductId";
                        ddlProduct.DataBind();
                        ddlProduct.Items.Insert(0, "Select Product");
                    }
                }
            }
        }
    }
}
