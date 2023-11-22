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
    public partial class SoReportNew : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
        int iSoid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime Today = DateTime.Now;
                txtFromdate.Text = Today.ToString("yyyy-MM-dd");
                txtTodate.Text = Today.ToString("yyyy-MM-dd");
                #region Load Po
                BindSo();
                #endregion
            }
        }
        private void BindSo()
        {
            DataSet dsPO = new DataSet();
            dsPO = dbObj.Select_SoGridnew();
            if (dsPO.Tables[0].Rows.Count > 0 || dsPO.Tables.Count > 0)
            {
                DataTable DBsodt = dsPO.Tables[0];
                DataSet dstdrp = new DataSet();
                DataTable dtrp;
                DataColumn dct;
                dtrp = new DataTable();
                dct = new DataColumn("SOPrintno");
                dtrp.Columns.Add(dct);
                dct = new DataColumn("Soid");
                dtrp.Columns.Add(dct);
                dct = new DataColumn("Productname");
                dtrp.Columns.Add(dct);
                dct = new DataColumn("SoQty");
                dtrp.Columns.Add(dct);
                dct = new DataColumn("Priceperpack");
                dtrp.Columns.Add(dct);
                dct = new DataColumn("Totalamount");
                dtrp.Columns.Add(dct);
                dct = new DataColumn("CompanyName");
                dtrp.Columns.Add(dct);
                dct = new DataColumn("PersonName");
                dtrp.Columns.Add(dct);
                dct = new DataColumn("Sodatetime");
                dtrp.Columns.Add(dct);
                dct = new DataColumn("Phone");
                dtrp.Columns.Add(dct);
                dct = new DataColumn("Amount");
                dtrp.Columns.Add(dct);
                dct = new DataColumn("Deliverydate");
                dtrp.Columns.Add(dct);
                dct = new DataColumn("Status");
                dtrp.Columns.Add(dct);

                string currentSO = string.Empty;
                string currentCompany = string.Empty;
                string currentPerson = string.Empty;
                string currentDate = string.Empty;
                string currentdeliveryDate = string.Empty;
                string currentPhone = string.Empty;
                string currentAmount = string.Empty;
                string currentStatus = string.Empty;

                foreach (DataRow row in DBsodt.Rows)
                {
                    DataRow newRow = dtrp.NewRow();
                    newRow["Soid"] = row["Soid"];
                    newRow["SOPrintno"] = row["SOPrintno"];
                    newRow["ProductName"] = row["ProductName"];
                    newRow["SoQty"] = row["SoQty"];
                    newRow["Priceperpack"] = row["Priceperpack"];
                    newRow["Totalamount"] = row["Totalamount"];
                    if ( row["CompanyName"].ToString() != currentCompany || row["PersonName"].ToString() != currentPerson || row["Sodatetime"].ToString() != currentDate || row["Phone"].ToString() != currentPhone || row["Amount"].ToString() != currentAmount || row["Status"].ToString() != currentStatus || row["Deliverydate"].ToString() != currentdeliveryDate)
                    {
                        //newRow["SOPrintno"] = row["SOPrintno"];
                        newRow["CompanyName"] = row["CompanyName"];
                        newRow["PersonName"] = row["PersonName"];
                        newRow["Sodatetime"] = Convert.ToDateTime(row["Sodatetime"]).ToString("dd/MM/yyyy");
                        newRow["Phone"] = row["Phone"];
                        newRow["Amount"] = row["Amount"];
                        newRow["Status"] = row["Status"];
                        if (Convert.IsDBNull(row["Deliverydate"]))
                        {
                            newRow["Deliverydate"] = "N/A";
                        }
                        else
                        {
                            newRow["Deliverydate"] = Convert.ToDateTime(row["Deliverydate"]).ToString("dd/MM/yyyy");
                        }


                       // currentSO = row["SOPrintno"].ToString();
                        currentCompany = row["CompanyName"].ToString();
                        currentPerson = row["PersonName"].ToString();
                        currentDate = row["Sodatetime"].ToString();
                        currentPhone = row["Phone"].ToString();
                        currentAmount = row["Amount"].ToString();
                        currentStatus = row["Status"].ToString();
                        currentdeliveryDate = row["Deliverydate"].ToString();
                    }
                    dtrp.Rows.Add(newRow);
                }
                gvSo.DataSource = dtrp;
                gvSo.DataBind();
            }
            else
            {
                gvSo.DataSource = null;
                gvSo.DataBind();
            }
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            BindSoby_date();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("SOReport.aspx");
        }

        protected void btnexp_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=SOReport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            System.IO.StringWriter stringWrite1 = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite1 = new HtmlTextWriter(stringWrite1);

            // Render only the GridView you want to export
            gvSo.RenderControl(htmlWrite1);

            Response.Write(stringWrite1.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        //protected void gvSo_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {

        //        GridView gv = (GridView)e.Row.FindControl("productgrid");
        //        //  GridView gvPO = (GridView)sender;
        //        string ab = gvSo.DataKeys[e.Row.RowIndex].Value.ToString();
        //        if (gvSo.DataKeys[e.Row.RowIndex].Value.ToString() != "")
        //        {

        //            string a = gvSo.DataKeys[e.Row.RowIndex].Values[0].ToString();
        //            //int iPoid = Convert.ToInt32(e.Row.Cells[1].va.Text);
        //            DataSet dspsoproduct = new DataSet();

        //            dspsoproduct = dbObj.Select_SOProduct(Convert.ToInt32(a));
        //            if (dspsoproduct.Tables[0].Rows.Count > 0)
        //            {
        //                gv.Visible = true;
        //                gv.DataSource = dspsoproduct.Tables[0];
        //                gv.DataBind();
        //            }
        //            //int iPoid = Convert.ToInt32(e.Row.Cells[1].Text);
        //        }

        //    }
        //}

        protected void txtsearch_TextChanged(object sender, EventArgs e)
        {
            BindSoby_Search();
        }

        protected void ddlsts_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSoby_Status();
        }

        public void BindSoby_date()
        {
            if (txtsearch.Text != "")
            {
                string searchSO = txtsearch.Text.Trim();
                DataSet dsPO = new DataSet();
                dsPO = dbObj.Select_SoGrid();
                gvSo.DataSource = dsPO.Tables[0];

                DataView dv = new DataView(dsPO.Tables[0]); // Corrected this line to use dsPO.Tables[0] as the data source.
                dv.RowFilter = "SOPrintno = '" + searchSO + "'";

                // Bind the filtered data to the GridView.
                gvSo.DataSource = dv;
                gvSo.DataBind();
            }
            else if ((txtFromdate.Text == "") || (txtTodate.Text == ""))
            {
                string script = "alert('Select From Date and To Date')";
                ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
            }
            else
            {
                DataSet dsreport;
                if (ddlsts.SelectedIndex == 0)
                {
                    dsreport = dbObj.SOdatesearchnew(Convert.ToDateTime(txtFromdate.Text).Date, Convert.ToDateTime(txtTodate.Text).Date);
                    if (dsreport.Tables[0].Rows.Count > 0 || dsreport.Tables.Count > 0)
                    {
                        DataTable DBsodt = dsreport.Tables[0];
                        DataSet dstdrp = new DataSet();
                        DataTable dtrp;
                        DataColumn dct;
                        dtrp = new DataTable();
                        dct = new DataColumn("SOPrintno");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Soid");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Productname");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("SoQty");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Priceperpack");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Totalamount");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("CompanyName");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("PersonName");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Sodatetime");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Phone");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Amount");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Deliverydate");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Status");
                        dtrp.Columns.Add(dct);

                        string currentSO = string.Empty;
                        string currentCompany = string.Empty;
                        string currentPerson = string.Empty;
                        string currentDate = string.Empty;
                        string currentdeliveryDate = string.Empty;
                        string currentPhone = string.Empty;
                        string currentAmount = string.Empty;
                        string currentStatus = string.Empty;

                        foreach (DataRow row in DBsodt.Rows)
                        {
                            DataRow newRow = dtrp.NewRow();
                            newRow["Soid"] = row["Soid"];
                            newRow["SOPrintno"] = row["SOPrintno"];
                            newRow["ProductName"] = row["ProductName"];
                            newRow["SoQty"] = row["SoQty"];
                            newRow["Priceperpack"] = row["Priceperpack"];
                            newRow["Totalamount"] = row["Totalamount"];
                            if (row["CompanyName"].ToString() != currentCompany || row["PersonName"].ToString() != currentPerson || row["Sodatetime"].ToString() != currentDate || row["Phone"].ToString() != currentPhone || row["Amount"].ToString() != currentAmount || row["Status"].ToString() != currentStatus || row["Deliverydate"].ToString() != currentdeliveryDate)
                            {
                                //newRow["SOPrintno"] = row["SOPrintno"];
                                newRow["CompanyName"] = row["CompanyName"];
                                newRow["PersonName"] = row["PersonName"];
                                newRow["Sodatetime"] = Convert.ToDateTime(row["Sodatetime"]).ToString("dd/MM/yyyy");
                                newRow["Phone"] = row["Phone"];
                                newRow["Amount"] = row["Amount"];
                                newRow["Status"] = row["Status"];
                                if (Convert.IsDBNull(row["Deliverydate"]))
                                {
                                    newRow["Deliverydate"] = "N/A";
                                }
                                else
                                {
                                    newRow["Deliverydate"] = Convert.ToDateTime(row["Deliverydate"]).ToString("dd/MM/yyyy");
                                }


                                //currentSO = row["SOPrintno"].ToString();
                                currentCompany = row["CompanyName"].ToString();
                                currentPerson = row["PersonName"].ToString();
                                currentDate = row["Sodatetime"].ToString();
                                currentPhone = row["Phone"].ToString();
                                currentAmount = row["Amount"].ToString();
                                currentStatus = row["Status"].ToString();
                                currentdeliveryDate = row["Deliverydate"].ToString();
                            }
                            dtrp.Rows.Add(newRow);
                        }
                        gvSo.DataSource = dtrp;
                        gvSo.DataBind();
                    }
                    else
                    {
                        string script = "alert('SO Not Available')";
                        ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                    }
                }
                else
                {
                    dsreport = dbObj.SOdatesearchby_DateinSts(Convert.ToDateTime(txtFromdate.Text).Date, Convert.ToDateTime(txtTodate.Text).Date, ddlsts.SelectedItem.Text);
                    if (dsreport.Tables[0].Rows.Count > 0 || dsreport.Tables.Count > 0)
                    {
                        DataTable DBsodt = dsreport.Tables[0];
                        DataSet dstdrp = new DataSet();
                        DataTable dtrp;
                        DataColumn dct;
                        dtrp = new DataTable();
                        dct = new DataColumn("SOPrintno");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Soid");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Productname");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("SoQty");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Priceperpack");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Totalamount");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("CompanyName");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("PersonName");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Sodatetime");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Phone");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Amount");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Deliverydate");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Status");
                        dtrp.Columns.Add(dct);

                        string currentSO = string.Empty;
                        string currentCompany = string.Empty;
                        string currentPerson = string.Empty;
                        string currentDate = string.Empty;
                        string currentdeliveryDate = string.Empty;
                        string currentPhone = string.Empty;
                        string currentAmount = string.Empty;
                        string currentStatus = string.Empty;

                        foreach (DataRow row in DBsodt.Rows)
                        {
                            DataRow newRow = dtrp.NewRow();
                            newRow["Soid"] = row["Soid"];
                            newRow["SOPrintno"] = row["SOPrintno"];
                            newRow["ProductName"] = row["ProductName"];
                            newRow["SoQty"] = row["SoQty"];
                            newRow["Priceperpack"] = row["Priceperpack"];
                            newRow["Totalamount"] = row["Totalamount"];
                            if (row["CompanyName"].ToString() != currentCompany || row["PersonName"].ToString() != currentPerson || row["Sodatetime"].ToString() != currentDate || row["Phone"].ToString() != currentPhone || row["Amount"].ToString() != currentAmount || row["Status"].ToString() != currentStatus || row["Deliverydate"].ToString() != currentdeliveryDate)
                            {
                                //newRow["SOPrintno"] = row["SOPrintno"];
                                newRow["CompanyName"] = row["CompanyName"];
                                newRow["PersonName"] = row["PersonName"];
                                newRow["Sodatetime"] = Convert.ToDateTime(row["Sodatetime"]).ToString("dd/MM/yyyy");
                                newRow["Phone"] = row["Phone"];
                                newRow["Amount"] = row["Amount"];
                                newRow["Status"] = row["Status"];
                                if (Convert.IsDBNull(row["Deliverydate"]))
                                {
                                    newRow["Deliverydate"] = "N/A";
                                }
                                else
                                {
                                    newRow["Deliverydate"] = Convert.ToDateTime(row["Deliverydate"]).ToString("dd/MM/yyyy");
                                }


                                //currentSO = row["SOPrintno"].ToString();
                                currentCompany = row["CompanyName"].ToString();
                                currentPerson = row["PersonName"].ToString();
                                currentDate = row["Sodatetime"].ToString();
                                currentPhone = row["Phone"].ToString();
                                currentAmount = row["Amount"].ToString();
                                currentStatus = row["Status"].ToString();
                                currentdeliveryDate = row["Deliverydate"].ToString();
                            }
                            dtrp.Rows.Add(newRow);
                        }
                        gvSo.DataSource = dtrp;
                        gvSo.DataBind();
                    }
                    else
                    {
                        string script = "alert('SO Not Available')";
                        ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                    }
                }
            }
        }

        public void BindSoby_Status()
        {
            if (ddlsts.SelectedIndex == 0)
            {
                BindSo();
            }
            else
            {
                DataSet ds = dbObj.Selectbysts_SoGrid(ddlsts.SelectedItem.Text); 
                if (ds.Tables[0].Rows.Count > 0 || ds.Tables.Count > 0)
                {
                    DataTable DBsodt = ds.Tables[0];
                    DataSet dstdrp = new DataSet();
                    DataTable dtrp;
                    DataColumn dct;
                    dtrp = new DataTable();
                    dct = new DataColumn("SOPrintno");
                    dtrp.Columns.Add(dct);
                    dct = new DataColumn("Soid");
                    dtrp.Columns.Add(dct);
                    dct = new DataColumn("Productname");
                    dtrp.Columns.Add(dct);
                    dct = new DataColumn("SoQty");
                    dtrp.Columns.Add(dct);
                    dct = new DataColumn("Priceperpack");
                    dtrp.Columns.Add(dct);
                    dct = new DataColumn("Totalamount");
                    dtrp.Columns.Add(dct);
                    dct = new DataColumn("CompanyName");
                    dtrp.Columns.Add(dct);
                    dct = new DataColumn("PersonName");
                    dtrp.Columns.Add(dct);
                    dct = new DataColumn("Sodatetime");
                    dtrp.Columns.Add(dct);
                    dct = new DataColumn("Phone");
                    dtrp.Columns.Add(dct);
                    dct = new DataColumn("Amount");
                    dtrp.Columns.Add(dct);
                    dct = new DataColumn("Deliverydate");
                    dtrp.Columns.Add(dct);
                    dct = new DataColumn("Status");
                    dtrp.Columns.Add(dct);

                    string currentSO = string.Empty;
                    string currentCompany = string.Empty;
                    string currentPerson = string.Empty;
                    string currentDate = string.Empty;
                    string currentdeliveryDate = string.Empty;
                    string currentPhone = string.Empty;
                    string currentAmount = string.Empty;
                    string currentStatus = string.Empty;

                    foreach (DataRow row in DBsodt.Rows)
                    {
                        DataRow newRow = dtrp.NewRow();
                        newRow["Soid"] = row["Soid"];
                        newRow["SOPrintno"] = row["SOPrintno"];
                        newRow["ProductName"] = row["ProductName"];
                        newRow["SoQty"] = row["SoQty"];
                        newRow["Priceperpack"] = row["Priceperpack"];
                        newRow["Totalamount"] = row["Totalamount"];
                        if ( row["CompanyName"].ToString() != currentCompany || row["PersonName"].ToString() != currentPerson || row["Sodatetime"].ToString() != currentDate || row["Phone"].ToString() != currentPhone || row["Amount"].ToString() != currentAmount || row["Status"].ToString() != currentStatus || row["Deliverydate"].ToString() != currentdeliveryDate)
                        {
                           // newRow["SOPrintno"] = row["SOPrintno"];
                            newRow["CompanyName"] = row["CompanyName"];
                            newRow["PersonName"] = row["PersonName"];
                            newRow["Sodatetime"] = Convert.ToDateTime(row["Sodatetime"]).ToString("dd/MM/yyyy");
                            newRow["Phone"] = row["Phone"];
                            newRow["Amount"] = row["Amount"];
                            newRow["Status"] = row["Status"];
                            if (Convert.IsDBNull(row["Deliverydate"]))
                            {
                                newRow["Deliverydate"] = "N/A";
                            }
                            else
                            {
                                newRow["Deliverydate"] = Convert.ToDateTime(row["Deliverydate"]).ToString("dd/MM/yyyy");
                            }


                            //currentSO = row["SOPrintno"].ToString();
                            currentCompany = row["CompanyName"].ToString();
                            currentPerson = row["PersonName"].ToString();
                            currentDate = row["Sodatetime"].ToString();
                            currentPhone = row["Phone"].ToString();
                            currentAmount = row["Amount"].ToString();
                            currentStatus = row["Status"].ToString();
                            currentdeliveryDate = row["Deliverydate"].ToString();
                        }
                        dtrp.Rows.Add(newRow);
                    }
                    gvSo.DataSource = dtrp;
                    gvSo.DataBind();
                }
                else
                {
                    gvSo.DataSource = null;
                    gvSo.DataBind();
                }
            }
        }

        public void BindSoby_Search()
        {
            string searchText = txtsearch.Text;
            DataSet ds;
            if (searchText == "")
            {
                BindSo();
            }
            else
            {
                if (int.TryParse(searchText, out int intValue))
                {
                    ds = dbObj.Selectby_SOPrintno(intValue);
                    if (ds.Tables[0].Rows.Count > 0 || ds.Tables.Count > 0)
                    {
                        DataTable DBsodt = ds.Tables[0];
                        DataSet dstdrp = new DataSet();
                        DataTable dtrp;
                        DataColumn dct;
                        dtrp = new DataTable();
                        dct = new DataColumn("SOPrintno");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Soid");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Productname");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("SoQty");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Priceperpack");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Totalamount");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("CompanyName");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("PersonName");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Sodatetime");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Phone");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Amount");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Deliverydate");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Status");
                        dtrp.Columns.Add(dct);

                        string currentSO = string.Empty;
                        string currentCompany = string.Empty;
                        string currentPerson = string.Empty;
                        string currentDate = string.Empty;
                        string currentdeliveryDate = string.Empty;
                        string currentPhone = string.Empty;
                        string currentAmount = string.Empty;
                        string currentStatus = string.Empty;

                        foreach (DataRow row in DBsodt.Rows)
                        {
                            DataRow newRow = dtrp.NewRow();
                            newRow["Soid"] = row["Soid"];
                            newRow["SOPrintno"] = row["SOPrintno"];
                            newRow["ProductName"] = row["ProductName"];
                            newRow["SoQty"] = row["SoQty"];
                            newRow["Priceperpack"] = row["Priceperpack"];
                            newRow["Totalamount"] = row["Totalamount"];
                            if (row["CompanyName"].ToString() != currentCompany || row["PersonName"].ToString() != currentPerson || row["Sodatetime"].ToString() != currentDate || row["Phone"].ToString() != currentPhone || row["Amount"].ToString() != currentAmount || row["Status"].ToString() != currentStatus || row["Deliverydate"].ToString() != currentdeliveryDate)
                            {
                                //newRow["SOPrintno"] = row["SOPrintno"];
                                newRow["CompanyName"] = row["CompanyName"];
                                newRow["PersonName"] = row["PersonName"];
                                newRow["Sodatetime"] = Convert.ToDateTime(row["Sodatetime"]).ToString("dd/MM/yyyy");
                                newRow["Phone"] = row["Phone"];
                                newRow["Amount"] = row["Amount"];
                                newRow["Status"] = row["Status"];
                                if (Convert.IsDBNull(row["Deliverydate"]))
                                {
                                    newRow["Deliverydate"] = "N/A";
                                }
                                else
                                {
                                    newRow["Deliverydate"] = Convert.ToDateTime(row["Deliverydate"]).ToString("dd/MM/yyyy");
                                }


                                //currentSO = row["SOPrintno"].ToString();
                                currentCompany = row["CompanyName"].ToString();
                                currentPerson = row["PersonName"].ToString();
                                currentDate = row["Sodatetime"].ToString();
                                currentPhone = row["Phone"].ToString();
                                currentAmount = row["Amount"].ToString();
                                currentStatus = row["Status"].ToString();
                                currentdeliveryDate = row["Deliverydate"].ToString();
                            }
                            dtrp.Rows.Add(newRow);
                        }
                        gvSo.DataSource = dtrp;
                        gvSo.DataBind();
                    }
                    else
                    {
                        BindSo();
                    }

                }
                else
                {
                    ds = dbObj.Selectby_SoPersonname(searchText);
                    if (ds.Tables[0].Rows.Count > 0 || ds.Tables.Count > 0)
                    {
                        DataTable DBsodt = ds.Tables[0];
                        DataSet dstdrp = new DataSet();
                        DataTable dtrp;
                        DataColumn dct;
                        dtrp = new DataTable();
                        dct = new DataColumn("SOPrintno");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Soid");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Productname");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("SoQty");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Priceperpack");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Totalamount");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("CompanyName");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("PersonName");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Sodatetime");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Phone");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Amount");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Deliverydate");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Status");
                        dtrp.Columns.Add(dct);

                        string currentSO = string.Empty;
                        string currentCompany = string.Empty;
                        string currentPerson = string.Empty;
                        string currentDate = string.Empty;
                        string currentdeliveryDate = string.Empty;
                        string currentPhone = string.Empty;
                        string currentAmount = string.Empty;
                        string currentStatus = string.Empty;

                        foreach (DataRow row in DBsodt.Rows)
                        {
                            DataRow newRow = dtrp.NewRow();
                            newRow["Soid"] = row["Soid"];
                            newRow["SOPrintno"] = row["SOPrintno"];
                            newRow["ProductName"] = row["ProductName"];
                            newRow["SoQty"] = row["SoQty"];
                            newRow["Priceperpack"] = row["Priceperpack"];
                            newRow["Totalamount"] = row["Totalamount"];
                            if (row["SOPrintno"].ToString() != currentSO || row["CompanyName"].ToString() != currentCompany || row["PersonName"].ToString() != currentPerson || row["Sodatetime"].ToString() != currentDate || row["Phone"].ToString() != currentPhone || row["Amount"].ToString() != currentAmount || row["Status"].ToString() != currentStatus || row["Deliverydate"].ToString() != currentdeliveryDate)
                            {
                               // newRow["SOPrintno"] = row["SOPrintno"];
                                newRow["CompanyName"] = row["CompanyName"];
                                newRow["PersonName"] = row["PersonName"];
                                newRow["Sodatetime"] = Convert.ToDateTime(row["Sodatetime"]).ToString("dd/MM/yyyy");
                                newRow["Phone"] = row["Phone"];
                                newRow["Amount"] = row["Amount"];
                                newRow["Status"] = row["Status"];
                                if (Convert.IsDBNull(row["Deliverydate"]))
                                {
                                    newRow["Deliverydate"] = "N/A";
                                }
                                else
                                {
                                    newRow["Deliverydate"] = Convert.ToDateTime(row["Deliverydate"]).ToString("dd/MM/yyyy");
                                }

                                //currentSO = row["SOPrintno"].ToString();
                                currentCompany = row["CompanyName"].ToString();
                                currentPerson = row["PersonName"].ToString();
                                currentDate = row["Sodatetime"].ToString();
                                currentPhone = row["Phone"].ToString();
                                currentAmount = row["Amount"].ToString();
                                currentStatus = row["Status"].ToString();
                                currentdeliveryDate = row["Deliverydate"].ToString();
                            }
                            dtrp.Rows.Add(newRow);
                        }
                        gvSo.DataSource = dtrp;
                        gvSo.DataBind();
                    }
                    else
                    {
                        BindSo();
                    }
                }
            }
        }
    }
}