using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Medly_Wm
{
    public partial class PoReportNew : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
        int iPoid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtFromdate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtTodate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                BindPo();
            }
        }

        private void BindPo()
        {
            DataSet dsPOR = new DataSet();
            dsPOR = dbObj.POReportnew(Convert.ToDateTime(txtFromdate.Text),Convert.ToDateTime(txtTodate.Text));
            if (dsPOR.Tables.Count > 0)
            {
                DataTable DBdatatable = dsPOR.Tables[0];
                DataSet dstdrp = new DataSet();
                DataTable dtrp;
                DataColumn dct;
                dtrp = new DataTable();
                dct = new DataColumn("Poid");
                dtrp.Columns.Add(dct);
                dct = new DataColumn("POPrintno");
                dtrp.Columns.Add(dct);
                dct = new DataColumn("Productid");
                dtrp.Columns.Add(dct);
                dct = new DataColumn("ProductName");
                dtrp.Columns.Add(dct);
                dct = new DataColumn("PoQty");
                dtrp.Columns.Add(dct);
                dct = new DataColumn("Priceperpack");
                dtrp.Columns.Add(dct);
                dct = new DataColumn("Productamt");
                dtrp.Columns.Add(dct);
                dct = new DataColumn("CompanyName");
                dtrp.Columns.Add(dct);
                dct = new DataColumn("ContactName");
                dtrp.Columns.Add(dct);
                dct = new DataColumn("Podatetime");
                dtrp.Columns.Add(dct);
                dct = new DataColumn("ContactNumber");
                dtrp.Columns.Add(dct);
                dct = new DataColumn("Amount");
                dtrp.Columns.Add(dct);
                dct = new DataColumn("Status");
                dtrp.Columns.Add(dct);

                string currentPO = string.Empty;
                string currentCompany = string.Empty;
                string currentSupplier = string.Empty;
                string currentDate = string.Empty;
                string currentContactNo = string.Empty;
                string currentAmount = string.Empty;
                string currentStatus = string.Empty;

                foreach (DataRow row in DBdatatable.Rows)
                {
                    DataRow newRow = dtrp.NewRow();
                    newRow["Poid"] = row["Poid"];
                    newRow["POPrintno"] = row["POPrintno"];
                    newRow["Productid"] = row["Productid"];
                    newRow["ProductName"] = row["ProductName"];
                    newRow["PoQty"] = row["PoQty"];
                    newRow["PricePerPack"] = row["PricePerPack"];
                    newRow["Productamt"] = row["Productamt"];
                    if (row["CompanyName"].ToString() != currentCompany || row["ContactName"].ToString() != currentSupplier || row["Podatetime"].ToString() != currentDate || row["ContactNumber"].ToString() != currentContactNo || row["Amount"].ToString() != currentAmount || row["Status"].ToString() != currentStatus)
                    {
                        //newRow["POPrintno"] = row["POPrintno"];
                        newRow["CompanyName"] = row["CompanyName"];
                        newRow["ContactName"] = row["ContactName"];
                        newRow["Podatetime"] = Convert.ToDateTime(row["Podatetime"]).ToString("dd/MM/yyyy");
                        newRow["ContactNumber"] = row["ContactNumber"];
                        newRow["Amount"] = row["Amount"];
                        newRow["Status"] = row["Status"];

                        //currentPO = row["POPrintno"].ToString();
                        currentCompany = row["CompanyName"].ToString();
                        currentSupplier = row["ContactName"].ToString();
                        currentDate = row["Podatetime"].ToString();
                        currentContactNo = row["ContactNumber"].ToString();
                        currentAmount = row["Amount"].ToString();
                        currentStatus = row["Status"].ToString();
                    }
                    dtrp.Rows.Add(newRow);
                }
                PoReport.DataSource = dtrp;
                PoReport.DataBind();
            }
            else
            {
                PoReport.DataSource = null;
                PoReport.DataBind();
            }
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            BindPoby_date();
        }

        protected void btnexp_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename= POReport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            System.IO.StringWriter stringWrite1 = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite1 = new HtmlTextWriter(stringWrite1);
            PoReport.RenderControl(htmlWrite1);
            Response.Write(stringWrite1.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        protected void txtsearch_TextChanged(object sender, EventArgs e)
        {
            BindPoby_Search();
        }

        protected void ddlsts_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindPoby_Status();
        }

        public void BindPoby_Status()
        {
            DataSet ds = dbObj.select_DDLSts(ddlsts.SelectedItem.Text,Convert.ToDateTime(txtFromdate.Text),Convert.ToDateTime(txtTodate.Text));
            if (ddlsts.SelectedIndex == 0)
            {
                BindPo();
            }
            else
            {
                if (ds.Tables.Count > 0 || ds.Tables[0].Rows.Count > 0)
                {
                    DataTable DBdatatable = ds.Tables[0];
                    DataSet dstdrp = new DataSet();
                    DataTable dtrp;
                    DataColumn dct;
                    dtrp = new DataTable();
                    dct = new DataColumn("Poid");
                    dtrp.Columns.Add(dct);
                    dct = new DataColumn("POPrintno");
                    dtrp.Columns.Add(dct);
                    dct = new DataColumn("Productid");
                    dtrp.Columns.Add(dct);
                    dct = new DataColumn("Productname");
                    dtrp.Columns.Add(dct);
                    dct = new DataColumn("PoQty");
                    dtrp.Columns.Add(dct);
                    dct = new DataColumn("Priceperpack");
                    dtrp.Columns.Add(dct);
                    dct = new DataColumn("Productamt");
                    dtrp.Columns.Add(dct);
                    dct = new DataColumn("CompanyName");
                    dtrp.Columns.Add(dct);
                    dct = new DataColumn("ContactName");
                    dtrp.Columns.Add(dct);
                    dct = new DataColumn("Podatetime");
                    dtrp.Columns.Add(dct);
                    dct = new DataColumn("ContactNumber");
                    dtrp.Columns.Add(dct);
                    dct = new DataColumn("Amount");
                    dtrp.Columns.Add(dct);
                    dct = new DataColumn("Status");
                    dtrp.Columns.Add(dct);

                    string currentPO = string.Empty;
                    string currentCompany = string.Empty;
                    string currentSupplier = string.Empty;
                    string currentDate = string.Empty;
                    string currentContactNo = string.Empty;
                    string currentAmount = string.Empty;
                    string currentStatus = string.Empty;

                    foreach (DataRow row in DBdatatable.Rows)
                    {
                        DataRow newRow = dtrp.NewRow();
                        newRow["Poid"] = row["Poid"];
                        newRow["POPrintno"] = row["POPrintno"];
                        newRow["Productid"] = row["Productid"];
                        newRow["ProductName"] = row["ProductName"];
                        newRow["PoQty"] = row["PoQty"];
                        newRow["PricePerPack"] = row["PricePerPack"];
                        newRow["Productamt"] = row["Productamt"];
                        if (row["CompanyName"].ToString() != currentCompany || row["ContactName"].ToString() != currentSupplier || row["Podatetime"].ToString() != currentDate || row["ContactNumber"].ToString() != currentContactNo || row["Amount"].ToString() != currentAmount || row["Status"].ToString() != currentStatus)
                        {
                            //newRow["POPrintno"] = row["POPrintno"];
                            newRow["CompanyName"] = row["CompanyName"];
                            newRow["ContactName"] = row["ContactName"];
                            newRow["Podatetime"] = Convert.ToDateTime(row["Podatetime"]).ToString("dd/MM/yyyy");
                            newRow["ContactNumber"] = row["ContactNumber"];
                            newRow["Amount"] = row["Amount"];
                            newRow["Status"] = row["Status"];

                            //currentPO = row["POPrintno"].ToString();
                            currentCompany = row["CompanyName"].ToString();
                            currentSupplier = row["ContactName"].ToString();
                            currentDate = row["Podatetime"].ToString();
                            currentContactNo = row["ContactNumber"].ToString();
                            currentAmount = row["Amount"].ToString();
                            currentStatus = row["Status"].ToString();
                        }
                        dtrp.Rows.Add(newRow);
                    }
                    PoReport.DataSource = dtrp;
                    PoReport.DataBind();
                }
                else
                {
                    PoReport.DataSource = null;
                    PoReport.DataBind();
                }
            }
        }
        public void BindPoby_date()
        {
            DataSet dsreport;
            if ((txtFromdate.Text == "") || (txtTodate.Text == ""))
            {
                string script = "alert('Select From Date and To Date')";
                ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
            }
            else
            {
                if (ddlsts.SelectedIndex == 0)
                {
                    dsreport = dbObj.Podatesearchnew(Convert.ToDateTime(txtFromdate.Text).Date, Convert.ToDateTime(txtTodate.Text).Date);
                    if (dsreport.Tables.Count > 0 || dsreport.Tables[0].Rows.Count > 0)
                    {
                        DataTable DBdatatable = dsreport.Tables[0];
                        DataSet dstdrp = new DataSet();
                        DataTable dtrp;
                        DataColumn dct;
                        dtrp = new DataTable();
                        dct = new DataColumn("Poid");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("POPrintno");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Productid");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Productname");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("PoQty");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Priceperpack");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Productamt");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("CompanyName");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("ContactName");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Podatetime");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("ContactNumber");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Amount");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Status");
                        dtrp.Columns.Add(dct);

                        string currentPO = string.Empty;
                        string currentCompany = string.Empty;
                        string currentSupplier = string.Empty;
                        string currentDate = string.Empty;
                        string currentContactNo = string.Empty;
                        string currentAmount = string.Empty;
                        string currentStatus = string.Empty;

                        foreach (DataRow row in DBdatatable.Rows)
                        {
                            DataRow newRow = dtrp.NewRow();
                            newRow["Poid"] = row["Poid"];
                            newRow["POPrintno"] = row["POPrintno"];
                            newRow["Productid"] = row["Productid"];
                            newRow["ProductName"] = row["ProductName"];
                            newRow["PoQty"] = row["PoQty"];
                            newRow["PricePerPack"] = row["PricePerPack"];
                            newRow["Productamt"] = row["Productamt"];
                            if (row["CompanyName"].ToString() != currentCompany || row["ContactName"].ToString() != currentSupplier || row["Podatetime"].ToString() != currentDate || row["ContactNumber"].ToString() != currentContactNo || row["Amount"].ToString() != currentAmount || row["Status"].ToString() != currentStatus)
                            {
                                //newRow["POPrintno"] = row["POPrintno"];
                                newRow["CompanyName"] = row["CompanyName"];
                                newRow["ContactName"] = row["ContactName"];
                                newRow["Podatetime"] = Convert.ToDateTime(row["Podatetime"]).ToString("dd/MM/yyyy");
                                newRow["ContactNumber"] = row["ContactNumber"];
                                newRow["Amount"] = row["Amount"];
                                newRow["Status"] = row["Status"];

                                //currentPO = row["POPrintno"].ToString();
                                currentCompany = row["CompanyName"].ToString();
                                currentSupplier = row["ContactName"].ToString();
                                currentDate = row["Podatetime"].ToString();
                                currentContactNo = row["ContactNumber"].ToString();
                                currentAmount = row["Amount"].ToString();
                                currentStatus = row["Status"].ToString();
                            }
                            dtrp.Rows.Add(newRow);
                        }
                        PoReport.DataSource = dtrp;
                        PoReport.DataBind();
                    }
                    else
                    {
                        string script = "alert('PO Not Available')";
                        ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                    }
                }
                else
                {
                    dsreport = dbObj.Podatesearchby_sts(Convert.ToDateTime(txtFromdate.Text).Date, Convert.ToDateTime(txtTodate.Text).Date, ddlsts.SelectedItem.Text);
                    if (dsreport.Tables.Count > 0 || dsreport.Tables[0].Rows.Count > 0)
                    {
                        DataTable DBdatatable = dsreport.Tables[0];
                        DataSet dstdrp = new DataSet();
                        DataTable dtrp;
                        DataColumn dct;
                        dtrp = new DataTable();
                        dct = new DataColumn("Poid");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("POPrintno");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Productid");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Productname");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("PoQty");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Priceperpack");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Productamt");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("CompanyName");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("ContactName");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Podatetime");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("ContactNumber");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Amount");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Status");
                        dtrp.Columns.Add(dct);

                        string currentPO = string.Empty;
                        string currentCompany = string.Empty;
                        string currentSupplier = string.Empty;
                        string currentDate = string.Empty;
                        string currentContactNo = string.Empty;
                        string currentAmount = string.Empty;
                        string currentStatus = string.Empty;

                        foreach (DataRow row in DBdatatable.Rows)
                        {
                            DataRow newRow = dtrp.NewRow();
                            newRow["Poid"] = row["Poid"];
                            newRow["POPrintno"] = row["POPrintno"];
                            newRow["Productid"] = row["Productid"];
                            newRow["ProductName"] = row["ProductName"];
                            newRow["PoQty"] = row["PoQty"];
                            newRow["PricePerPack"] = row["PricePerPack"];
                            newRow["Productamt"] = row["Productamt"];
                            if (row["CompanyName"].ToString() != currentCompany || row["ContactName"].ToString() != currentSupplier || row["Podatetime"].ToString() != currentDate || row["ContactNumber"].ToString() != currentContactNo || row["Amount"].ToString() != currentAmount || row["Status"].ToString() != currentStatus)
                            {
                                //newRow["POPrintno"] = row["POPrintno"];
                                newRow["CompanyName"] = row["CompanyName"];
                                newRow["ContactName"] = row["ContactName"];
                                newRow["Podatetime"] = Convert.ToDateTime(row["Podatetime"]).ToString("dd/MM/yyyy");
                                newRow["ContactNumber"] = row["ContactNumber"];
                                newRow["Amount"] = row["Amount"];
                                newRow["Status"] = row["Status"];

                                //currentPO = row["POPrintno"].ToString();
                                currentCompany = row["CompanyName"].ToString();
                                currentSupplier = row["ContactName"].ToString();
                                currentDate = row["Podatetime"].ToString();
                                currentContactNo = row["ContactNumber"].ToString();
                                currentAmount = row["Amount"].ToString();
                                currentStatus = row["Status"].ToString();
                            }
                            dtrp.Rows.Add(newRow);
                        }
                        PoReport.DataSource = dtrp;
                        PoReport.DataBind();
                    }
                    else
                    {
                        string script = "alert('PO Not Available')";
                        ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                    }
                }

            }
        }
        public void BindPoby_Search()
        {
            string searchText = txtsearch.Text;
            DataSet ds;
            if (searchText == "")
            {
                BindPo();
            }
            else
            {
                if (int.TryParse(searchText, out int intValue))
                {
                    ds = dbObj.POReportby_Poid(intValue);
                    if (ds.Tables.Count > 0 || ds.Tables[0].Rows.Count > 0)
                    {
                        DataTable DBdatatable = ds.Tables[0];
                        DataSet dstdrp = new DataSet();
                        DataTable dtrp;
                        DataColumn dct;
                        dtrp = new DataTable();
                        dct = new DataColumn("Poid");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("POPrintno");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Productid");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Productname");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("PoQty");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Priceperpack");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Productamt");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("CompanyName");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("ContactName");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Podatetime");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("ContactNumber");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Amount");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Status");
                        dtrp.Columns.Add(dct);

                        string currentPO = string.Empty;
                        string currentCompany = string.Empty;
                        string currentSupplier = string.Empty;
                        string currentDate = string.Empty;
                        string currentContactNo = string.Empty;
                        string currentAmount = string.Empty;
                        string currentStatus = string.Empty;

                        foreach (DataRow row in DBdatatable.Rows)
                        {
                            DataRow newRow = dtrp.NewRow();
                            newRow["Poid"] = row["Poid"];
                            newRow["POPrintno"] = row["POPrintno"];
                            newRow["Productid"] = row["Productid"];
                            newRow["ProductName"] = row["ProductName"];
                            newRow["PoQty"] = row["PoQty"];
                            newRow["PricePerPack"] = row["PricePerPack"];
                            newRow["Productamt"] = row["Productamt"];
                            if (row["CompanyName"].ToString() != currentCompany || row["ContactName"].ToString() != currentSupplier || row["Podatetime"].ToString() != currentDate || row["ContactNumber"].ToString() != currentContactNo || row["Amount"].ToString() != currentAmount || row["Status"].ToString() != currentStatus)
                            {
                                //newRow["POPrintno"] = row["POPrintno"];
                                newRow["CompanyName"] = row["CompanyName"];
                                newRow["ContactName"] = row["ContactName"];
                                newRow["Podatetime"] = Convert.ToDateTime(row["Podatetime"]).ToString("dd/MM/yyyy");
                                newRow["ContactNumber"] = row["ContactNumber"];
                                newRow["Amount"] = row["Amount"];
                                newRow["Status"] = row["Status"];

                                //currentPO = row["POPrintno"].ToString();
                                currentCompany = row["CompanyName"].ToString();
                                currentSupplier = row["ContactName"].ToString();
                                currentDate = row["Podatetime"].ToString();
                                currentContactNo = row["ContactNumber"].ToString();
                                currentAmount = row["Amount"].ToString();
                                currentStatus = row["Status"].ToString();
                            }
                            dtrp.Rows.Add(newRow);
                        }
                        PoReport.DataSource = dtrp;
                        PoReport.DataBind();
                    }
                    else
                    {
                        BindPo();
                    }

                }
                else
                {
                    ds = dbObj.PoReportby_SuplierName(searchText);
                    if (ds.Tables.Count > 0 || ds.Tables[0].Rows.Count > 0)
                    {
                        DataTable DBdatatable = ds.Tables[0];
                        DataSet dstdrp = new DataSet();
                        DataTable dtrp;
                        DataColumn dct;
                        dtrp = new DataTable();
                        dct = new DataColumn("Poid");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("POPrintno");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Productid");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Productname");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("PoQty");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Priceperpack");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Productamt");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("CompanyName");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("ContactName");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Podatetime");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("ContactNumber");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Amount");
                        dtrp.Columns.Add(dct);
                        dct = new DataColumn("Status");
                        dtrp.Columns.Add(dct);

                        string currentPO = string.Empty;
                        string currentCompany = string.Empty;
                        string currentSupplier = string.Empty;
                        string currentDate = string.Empty;
                        string currentContactNo = string.Empty;
                        string currentAmount = string.Empty;
                        string currentStatus = string.Empty;

                        foreach (DataRow row in DBdatatable.Rows)
                        {
                            DataRow newRow = dtrp.NewRow();
                            newRow["Poid"] = row["Poid"];
                            newRow["POPrintno"] = row["POPrintno"];
                            newRow["Productid"] = row["Productid"];
                            newRow["ProductName"] = row["ProductName"];
                            newRow["PoQty"] = row["PoQty"];
                            newRow["PricePerPack"] = row["PricePerPack"];
                            newRow["Productamt"] = row["Productamt"];
                            if (row["CompanyName"].ToString() != currentCompany || row["ContactName"].ToString() != currentSupplier || row["Podatetime"].ToString() != currentDate || row["ContactNumber"].ToString() != currentContactNo || row["Amount"].ToString() != currentAmount || row["Status"].ToString() != currentStatus)
                            {
                                // newRow["POPrintno"] = row["POPrintno"];
                                newRow["CompanyName"] = row["CompanyName"];
                                newRow["ContactName"] = row["ContactName"];
                                newRow["Podatetime"] = Convert.ToDateTime(row["Podatetime"]).ToString("dd/MM/yyyy");
                                newRow["ContactNumber"] = row["ContactNumber"];
                                newRow["Amount"] = row["Amount"];
                                newRow["Status"] = row["Status"];

                                // currentPO = row["POPrintno"].ToString();
                                currentCompany = row["CompanyName"].ToString();
                                currentSupplier = row["ContactName"].ToString();
                                currentDate = row["Podatetime"].ToString();
                                currentContactNo = row["ContactNumber"].ToString();
                                currentAmount = row["Amount"].ToString();
                                currentStatus = row["Status"].ToString();
                            }
                            dtrp.Rows.Add(newRow);
                        }
                        PoReport.DataSource = dtrp;
                        PoReport.DataBind();
                    }
                    else
                    {
                        BindPo();
                    }
                }
            }

        }

        protected void PoReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (ddlsts.SelectedItem.Value == "4")
                {

                    PoReport.Columns[6].Visible= true;
                    Label lblRemainQty = (Label)e.Row.FindControl("lblRemainQty");
                    lblRemainQty.Visible = true;
                    Label rdetails = (Label)e.Row.FindControl("rdetails");
                    Label lblQty = (Label)e.Row.FindControl("lblQty");
                    if (rdetails != null && lblQty != null)
                    {
                        int Qty = Convert.ToInt32(lblQty.Text);
                        int Remainqty;
                        string combinedIds = rdetails.Text;
                        string[] idsArray = combinedIds.Split(';');


                        if (idsArray.Length == 2)
                        {
                            string poid = idsArray[0];
                            string productid = idsArray[1];
                            int poidInt = Convert.ToInt32(poid);
                            int productidInt = Convert.ToInt32(productid);

                            DataSet remainqty = dbObj.PoReportby_Receivedqtycheck(poidInt, productidInt);
                            if (remainqty.Tables[0].Rows.Count > 0)
                            {
                                int Remqty = Convert.ToInt32(remainqty.Tables[0].Rows[0]["receivedqty"].ToString());
                                if (Remqty == Qty)
                                {
                                    lblRemainQty.Text = "GR Status";
                                }
                                else
                                {
                                    Remainqty = Qty - Remqty;
                                    lblRemainQty.Text = Remainqty.ToString();
                                }

                            }
                            else
                            {
                                lblRemainQty.Text = lblQty.Text;
                            }
                        }
                    }

                }
                else
                {
                    PoReport.Columns[6].Visible = false;
                }
            }
        }
    }
}