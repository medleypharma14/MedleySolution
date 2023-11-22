using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Globalization;
using System.Data;


namespace AdminAfforadbleApp
{
    public partial class CustomerMaster : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
                Clear();
                btnSave.Text = "Save";
                FirstGridViewRow();
            }

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerMaster.aspx");
            //Clear();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (txtCustomername.Text == "")
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Enter Customer Name');", true);
                txtCustomername.Focus();
                return;
            }

            if (txtMobileno.Text == "")
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Enter MobileNo');", true);
                txtMobileno.Focus();
                return;
            }
            if (txtEmail.Text == "")
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Enter Email ID');", true);
                txtEmail.Focus();
                return;
            }

            if (txtAddress.Text == "")
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Enter Address');", true);
                txtAddress.Focus();
                return;
            }
            if (btnSave.Text == "Save")
            {
                int iSuccess = dbObj.insert_Customer(txtCustomername.Text, txtMobileno.Text, txtEmail.Text, txtAddress.Text);

                for (int i = 0; i < gvForum.Rows.Count; i++)
                {
                    TextBox txtno = (TextBox)gvForum.Rows[i].Cells[0].FindControl("txtno");
                    DropDownList drpProduct = (DropDownList)gvForum.Rows[i].Cells[0].FindControl("drpProduct");
                    TextBox txtPurchasedate = (TextBox)gvForum.Rows[i].Cells[0].FindControl("txtPurchasedate");
                    TextBox txtServicedate = (TextBox)gvForum.Rows[i].Cells[0].FindControl("txtServicedate");
                    if (drpProduct.SelectedValue != "Select Product")
                    {
                        DateTime purdate = DateTime.ParseExact(txtPurchasedate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        DateTime servicedate = DateTime.ParseExact(txtServicedate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        int iStatus2 = dbObj.insert_TransCustomer(Convert.ToInt32(drpProduct.SelectedValue), purdate, servicedate);
                    }

                }

                LoadGrid();
                Clear();
            }
            else if (btnSave.Text == "Update")
            {
                int iSuccess = dbObj.Update_Customer(txtCustomername.Text, txtMobileno.Text, txtEmail.Text, txtAddress.Text, lblid.Text);

                int iss2 = dbObj.TransCustomerDelete(Convert.ToInt32(lblid.Text));

                for (int i = 0; i < gvForum.Rows.Count; i++)
                {
                    TextBox txtno = (TextBox)gvForum.Rows[i].Cells[0].FindControl("txtno");
                    DropDownList drpProduct = (DropDownList)gvForum.Rows[i].Cells[0].FindControl("drpProduct");
                    TextBox txtPurchasedate = (TextBox)gvForum.Rows[i].Cells[0].FindControl("txtPurchasedate");
                    TextBox txtServicedate = (TextBox)gvForum.Rows[i].Cells[0].FindControl("txtServicedate");


                    if (drpProduct.SelectedValue != "Select Product")
                    {
                        DateTime purdate = DateTime.ParseExact(txtPurchasedate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        DateTime servicedate = DateTime.ParseExact(txtServicedate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        int iStatus2 = dbObj.Update_TransCustomer(Convert.ToInt32(lblid.Text), Convert.ToInt32(drpProduct.SelectedValue), purdate, servicedate);
                    }

                }

                LoadGrid();
                Clear();
            
         
           
              
            }




            Response.Redirect("Customermaster.aspx");
        }


        private void FirstGridViewRow()
        {
            DataTable dtt = new DataTable();
            DataRow dr = null;
            dtt.Columns.Add(new DataColumn("SNo", typeof(string)));
            dtt.Columns.Add(new DataColumn("Product", typeof(string)));
            dtt.Columns.Add(new DataColumn("Date", typeof(string)));
            dtt.Columns.Add(new DataColumn("ServiceDate", typeof(string)));


            dr = dtt.NewRow();
            dr["SNo"] = string.Empty;
            dr["Product"] = string.Empty;
            dr["Date"] = string.Empty;
            dr["ServiceDate"] = string.Empty;

            dtt.Rows.Add(dr);

            ViewState["CurrentTable1"] = dtt;

            gvForum.DataSource = dtt;
            gvForum.DataBind();

            DataTable dttt;
            DataRow drNew;
            DataColumn dct;
            DataSet dstd = new DataSet();
            dttt = new DataTable();

            dct = new DataColumn("SNo");
            dttt.Columns.Add(dct);

            dct = new DataColumn("Product");
            dttt.Columns.Add(dct);

            dct = new DataColumn("Date");
            dttt.Columns.Add(dct);

            dct = new DataColumn("ServiceDate");
            dttt.Columns.Add(dct);

            dstd.Tables.Add(dttt);

            drNew = dttt.NewRow();

            drNew["SNo"] = 0;
            drNew["Product"] = "";
            drNew["Date"] = "";
            drNew["ServiceDate"] = "";

            dstd.Tables[0].Rows.Add(drNew);

            gvForum.DataSource = dstd;
            gvForum.DataBind();
        }

        private void SetPreviousData()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable1"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable1"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TextBox txtno = (TextBox)gvForum.Rows[rowIndex].Cells[2].FindControl("txtno");
                        DropDownList drpProduct = (DropDownList)gvForum.Rows[rowIndex].Cells[2].FindControl("drpProduct");
                        TextBox txtPurchasedate = (TextBox)gvForum.Rows[rowIndex].Cells[2].FindControl("txtPurchasedate");
                        TextBox txtServicedate = (TextBox)gvForum.Rows[rowIndex].Cells[2].FindControl("txtServicedate");

                        txtno.Text = dt.Rows[i]["SNo"].ToString();
                        drpProduct.SelectedValue = dt.Rows[i]["Product"].ToString();
                        txtPurchasedate.Text = dt.Rows[i]["Date"].ToString();
                        txtServicedate.Text = dt.Rows[i]["ServiceDate"].ToString();

                        rowIndex++;
                    }
                }
            }
        }

        private void SetRowData()
        {
            int rowIndex = 0;

            if (ViewState["CurrentTable1"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable1"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        TextBox txtno = (TextBox)gvForum.Rows[rowIndex].Cells[2].FindControl("txtno");
                        DropDownList drpProduct = (DropDownList)gvForum.Rows[rowIndex].Cells[2].FindControl("drpProduct");
                        TextBox txtPurchasedate = (TextBox)gvForum.Rows[rowIndex].Cells[2].FindControl("txtPurchasedate");
                        TextBox txtServicedate = (TextBox)gvForum.Rows[rowIndex].Cells[2].FindControl("txtServicedate");

                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["SNo"] = i + 1;
                        dtCurrentTable.Rows[i - 1]["Product"] = drpProduct.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["Date"] = txtPurchasedate.Text;
                        dtCurrentTable.Rows[i - 1]["ServiceDate"] = txtServicedate.Text;
                        rowIndex++;
                    }

                    ViewState["CurrentTable1"] = dtCurrentTable;
                    gvForum.DataSource = dtCurrentTable;
                    gvForum.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
            SetPreviousData();
        }

        protected void gvForum_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataSet dsDesignation = new DataSet();

            dsDesignation = dbObj.BindProduct();

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var ddl = (DropDownList)e.Row.FindControl("drpProduct");
                ddl.DataSource = dsDesignation;
                ddl.DataTextField = "ProductName";
                ddl.DataValueField = "ProductId";
                ddl.DataBind();
                ddl.Items.Insert(0, "Select Product");
            }
        }

        protected void gvForum_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SetRowData();

            if (ViewState["CurrentTable1"] != null)
            {
                DataSet ds = new DataSet();
                DataTable dt = (DataTable)ViewState["CurrentTable1"];
                DataRow drCurrentRow = null;
                int rowIndex = Convert.ToInt32(e.RowIndex);
                if (dt.Rows.Count > 1)
                {
                    ds.Merge(dt);

                    dt.Rows.Remove(dt.Rows[rowIndex]);
                    drCurrentRow = dt.NewRow();

                    ViewState["CurrentTable1"] = dt;
                    gvForum.DataSource = dt;
                    gvForum.DataBind();

                    SetPreviousData();

                    for (int i = 0; i < gvForum.Rows.Count; i++)
                    {
                        TextBox txtno = (TextBox)gvForum.Rows[i].FindControl("txtno");
                        txtno.Text = Convert.ToString(i + 1);
                    }
                }
                else if (dt.Rows.Count == 1)
                {
                    dt.Rows.Remove(dt.Rows[rowIndex]);
                    drCurrentRow = dt.NewRow();
                    ViewState["CurrentTable1"] = dt;
                    gvForum.DataSource = dt;
                    gvForum.DataBind();

                    SetPreviousData();
                    FirstGridViewRow();
                }
            }

        }

        protected void ButtonAdd1_Click(object sender, EventArgs e)
        {
            int No = 0;
            for (int vLoop = 0; vLoop < gvForum.Rows.Count; vLoop++)
            {
                TextBox txtno = (TextBox)gvForum.Rows[vLoop].FindControl("txtno");
                DropDownList drpProduct = (DropDownList)gvForum.Rows[vLoop].FindControl("drpProduct");
                TextBox txtForum = (TextBox)gvForum.Rows[vLoop].FindControl("txtForum");

                if (drpProduct.SelectedValue == "Select Product")
                {
                    No = 0;
                    break;
                }
                else
                {
                    No = 1;
                }
            }

            if (No == 1)
            {

                AddNewRow();
            }
            else
            {

            }
            //for (int vLoop = 0; vLoop < gvcustomerorder.Rows.Count; vLoop++)
            //{
            //    TextBox txtno = (TextBox)gvcustomerorder.Rows[vLoop].FindControl("txtno");

            //    txtno.Focus();
            //}


        }

        private void AddNewRow()
        {
            for (int vLoop = 0; vLoop < gvForum.Rows.Count; vLoop++)
            {
                TextBox txtno = (TextBox)gvForum.Rows[vLoop].FindControl("txtno");
                DropDownList drpProduct = (DropDownList)gvForum.Rows[vLoop].FindControl("drpProduct");
                TextBox txtForum = (TextBox)gvForum.Rows[vLoop].FindControl("txtForum");

                int col = vLoop + 1;


                txtno.Focus();

            }

            int rowIndex = 0;

            if (ViewState["CurrentTable1"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable1"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        TextBox txtno = (TextBox)gvForum.Rows[rowIndex].Cells[2].FindControl("txtno");
                        DropDownList drpProduct = (DropDownList)gvForum.Rows[rowIndex].Cells[2].FindControl("drpProduct");
                        TextBox txtPurchasedate = (TextBox)gvForum.Rows[rowIndex].Cells[2].FindControl("txtPurchasedate");
                        TextBox txtServicedate = (TextBox)gvForum.Rows[rowIndex].Cells[2].FindControl("txtServicedate");

                        drCurrentRow = dtCurrentTable.NewRow();
                        //  drCurrentRow["SNo"] = i + 1;

                        drCurrentRow = dtCurrentTable.NewRow();

                        drCurrentRow["SNo"] = i + 1;
                        dtCurrentTable.Rows[i - 1]["Date"] = txtPurchasedate.Text;
                        dtCurrentTable.Rows[i - 1]["ServiceDate"] = txtServicedate.Text;
                        dtCurrentTable.Rows[i - 1]["Product"] = drpProduct.SelectedValue;
                        rowIndex++;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable1"] = dtCurrentTable;

                    gvForum.DataSource = dtCurrentTable;
                    gvForum.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
            SetPreviousData();
        }


        protected void LoadGrid()
        {

            DataSet ds = dbObj.BindCustomer();
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvCustomer.DataSource = ds;
                gvCustomer.DataBind();
            }
            else
            {
                gvCustomer.DataSource = null;
                gvCustomer.DataBind();
            }

        }
        protected void Clear()
        {
            txtCustomername.Text = "";
            txtMobileno.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";

            txtCustomername.Focus();

        }

        protected void gvCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            // lblName.Text = "Update UOM";

            if (gvCustomer.SelectedDataKey.Value != null && gvCustomer.SelectedDataKey.Value.ToString() != "")
            {
                string Id = gvCustomer.SelectedDataKey.Value.ToString();
                DataSet ds = dbObj.GetEditCustomer(Id);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Id = ds.Tables[0].Rows[0]["CustomerId"].ToString();
                    // listcategory.Enabled = false;
                    txtCustomername.Text = ds.Tables[0].Rows[0]["CustomerName"].ToString();

                    lblid.Text = ds.Tables[0].Rows[0]["CustomerId"].ToString();

                    txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();

                    txtMobileno.Text = ds.Tables[0].Rows[0]["MobileNo"].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();


                    btnSave.Visible = true;
                    btnSave.Text = "Update";

                    #region ProductSize
                    DataSet ds2 = dbObj.GetEditTransCustomer(Id);
                    {
                        if (ds2.Tables[0].Rows.Count > 0)
                        {
                            int Tpo = ds2.Tables[0].Rows.Count;

                            DataTable dttt;
                            DataRow drNew;
                            DataColumn dct;
                            DataSet dstd = new DataSet();
                            dttt = new DataTable();

                            dct = new DataColumn("SNo");
                            dttt.Columns.Add(dct);

                            dct = new DataColumn("Product");
                            dttt.Columns.Add(dct);

                            dct = new DataColumn("Date");
                            dttt.Columns.Add(dct);

                            dct = new DataColumn("ServiceDate");
                            dttt.Columns.Add(dct);

                            dstd.Tables.Add(dttt);

                            foreach (DataRow dr in ds2.Tables[0].Rows)
                            {
                                drNew = dttt.NewRow();
                                drNew["SNo"] = "1";
                                drNew["Product"] = dr["ProductID"];
                                drNew["Date"] = dr["PurchaseDate"];
                                drNew["ServiceDate"] = dr["NextServiceDate"]; 
                                dstd.Tables[0].Rows.Add(drNew);
                            }

                            ViewState["CurrentTable1"] = dttt;

                            gvForum.DataSource = dstd;
                            gvForum.DataBind();


                            for (int vLoop = 0; vLoop < gvForum.Rows.Count; vLoop++)
                            {
                                TextBox txtno = (TextBox)gvForum.Rows[vLoop].FindControl("txtno");
                                DropDownList drpProduct = (DropDownList)gvForum.Rows[vLoop].FindControl("drpProduct");
                                TextBox txtPurchasedate = (TextBox)gvForum.Rows[vLoop].FindControl("txtPurchasedate");
                                TextBox txtServicedate = (TextBox)gvForum.Rows[vLoop].FindControl("txtServicedate");

                                txtno.Text = Convert.ToString(Convert.ToInt32(vLoop + 1));
                                drpProduct.SelectedValue = dstd.Tables[0].Rows[vLoop]["Product"].ToString();
                                txtPurchasedate.Text = Convert.ToDateTime(dstd.Tables[0].Rows[vLoop]["Date"]).ToString("dd/MM/yyyy");
                                txtServicedate.Text = Convert.ToDateTime(dstd.Tables[0].Rows[vLoop]["ServiceDate"]).ToString("dd/MM/yyyy");                               
                            }
                        }
                        else
                        {
                            FirstGridViewRow();
                            ButtonAdd1_Click(sender, e);
                        }
                    }
                    ButtonAdd1_Click(sender, e);
                    #endregion
                }
            }
        }
    }
}