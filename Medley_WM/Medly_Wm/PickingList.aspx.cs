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
    public partial class PickingList : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
        int iPickid = 0;
        string totalamount;
        protected void Page_Load(object sender, EventArgs e)
        {
            iPickid = Convert.ToInt32(Request.QueryString.Get("Pickid"));
            //totalamount = Request.QueryString.Get("totalamount").ToString();
            if (iPickid != 0)
            {
                DataSet dspickdetail = new DataSet();
                dspickdetail = dbObj.Select_Pickvalues(Convert.ToInt32(iPickid));
                if (dspickdetail.Tables[0].Rows.Count>0)
                {
                    lblDatepick.Text = Convert.ToDateTime(dspickdetail.Tables[0].Rows[0]["PickupDate"]).ToString("dd/MM/yyyy");
                    lblCustname.Text = dspickdetail.Tables[0].Rows[0]["CompanyName"].ToString();
                    lblDeladdress.Text = dspickdetail.Tables[0].Rows[0]["Address"].ToString();
                    lblSOnumber.Text = dspickdetail.Tables[0].Rows[0]["SOPrintno"].ToString();
                   // lblPickedby.Text = dspickdetail.Tables[0].Rows[0]["PersonName"].ToString();
                    lblOrderref.Text = dspickdetail.Tables[0].Rows[0]["Refno"].ToString();
                    //lblproducts.Text = dspickdetail.Tables[0].Rows[0]["Productname"].ToString();
                    //lblqty.Text = dspickdetail.Tables[0].Rows[0]["Qty"].ToString();
                    //lblamount.Text = totalamount.ToString();
                    lblDateprinted.Text = Convert.ToDateTime(dspickdetail.Tables[0].Rows[0]["PickupDate"]).ToString("dd/MM/yyyy");
                    DataSet Expirydate = dbObj.Select_PickvaluesExpirydate(Convert.ToInt32(iPickid));
                    // lblexpirydate.Text = Convert.ToDateTime(Expirydate.Tables[0].Rows[0]["Expirydate"]).ToString("yyyy/MM/dd");

                    //sopickgrid.Visible = true;
                    //sopickgrid.DataSource = dspickdetail.Tables[0];
                    //sopickgrid.DataBind();

                    DataSet dstd = new DataSet();
                    DataTable dtddd = new DataTable();


                    DataTable dttt;
                    DataRow drNew;
                    DataColumn dct;
                    dttt = new DataTable();

                    dct = new DataColumn("Productname");
                    dttt.Columns.Add(dct);
                    dct = new DataColumn("Unitname");
                    dttt.Columns.Add(dct);
                    dct = new DataColumn("Qty");
                    dttt.Columns.Add(dct);
                    dct = new DataColumn("totalQty");
                    dttt.Columns.Add(dct);
                    dct = new DataColumn("Batchnumber");
                    dttt.Columns.Add(dct);
                    dct = new DataColumn("ExpiryDate");
                    dttt.Columns.Add(dct);
                    //dct = new DataColumn("Qty");
                    //dttt.Columns.Add(dct);
                    //dct = new DataColumn("UOM");
                    //dttt.Columns.Add(dct);

                    //dct = new DataColumn("Delaydays");
                    //dttt.Columns.Add(dct);
                    //dct = new DataColumn("qtytype");
                    //dttt.Columns.Add(dct);


                    dstd.Tables.Add(dttt);

                    if (dspickdetail.Tables[0].Rows.Count > 0)
                    {
                        
                        for (int i =0; i < dspickdetail.Tables[0].Rows.Count; i ++)
                        {
                            int totqty = 0;
                            string Productname = dspickdetail.Tables[0].Rows[i]["Productname"].ToString();
                            string Unitname = dspickdetail.Tables[0].Rows[i]["Unitname"].ToString();
                            int Qty = Convert.ToInt32(dspickdetail.Tables[0].Rows[i]["Qty"]);
                            string Batchnumber = dspickdetail.Tables[0].Rows[i]["Batchnumber"].ToString();
                            string ExpiryDate = dspickdetail.Tables[0].Rows[i]["ExpiryDate"].ToString();

                            drNew = dttt.NewRow();
                            drNew["Productname"] = Productname;
                            drNew["Unitname"] = Unitname;
                            drNew["Qty"] = Qty.ToString();
                            for (int ii = 0; ii < dspickdetail.Tables[0].Rows.Count; ii++)
                            {
                                string preProductname = dspickdetail.Tables[0].Rows[ii]["Productname"].ToString();
                                
                                int preQty = Convert.ToInt32(dspickdetail.Tables[0].Rows[ii]["Qty"]);

                                if(Productname == preProductname)
                                {
                                    totqty += preQty;
                                }


                            }
                                drNew["totalQty"] = totqty.ToString();
                            drNew["Batchnumber"] = Batchnumber;
                            drNew["ExpiryDate"] =Convert.ToDateTime(ExpiryDate).ToString("dd/MM/yyyy");
                            dstd.Tables[0].Rows.Add(drNew);

                        }

                    }
                    sopickgrid.Visible = true;
                    sopickgrid.DataSource = dstd.Tables[0];
                    sopickgrid.DataBind();
                }
                else
                {
                    sopickgrid.DataSource = null;
                    sopickgrid.DataBind();
                }

            }
        }

        //protected void sopickgrid_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    int totalQty = 0;

        //    foreach (GridViewRow row in sopickgrid.Rows)
        //    {
        //        if (row.RowType == DataControlRowType.DataRow)
        //        {
        //            Label txtqtyLabel = row.FindControl("txtqty") as Label;

        //            if (txtqtyLabel != null)
        //            {
        //                int qty = 0;
        //                if (int.TryParse(txtqtyLabel.Text, out qty))
        //                {
        //                    totalQty += qty;
        //                }
        //            }
        //        }
        //    }
            //decimal totalQuantity = 0; // Initialize outside the loop
            //string currentProductName = null; // Initialize the current product name

            //for (int i = 0; i < sopickgrid.Rows.Count; i++)
            //{
            //    GridViewRow eRow = sopickgrid.Rows[i];

            //    if (eRow.RowType == DataControlRowType.DataRow)
            //    {
            //        string productName = eRow.Cells[0].Text;
            //        decimal quantity = decimal.Parse(eRow.Cells[3].Text);
            //        DataRowView rowView = eRow.DataItem as DataRowView; // Direct cast without null check
            //        Label prname = (Label)eRow.FindControl("txtproductname");
            //        if (prname != null) // Check if the rowView is not null
            //        {
            //            string rowProductName = prname.ToString();

            //            if (currentProductName == null)
            //            {
            //                currentProductName = rowProductName; // Use the rowProductName
            //            }

            //            if (currentProductName != rowProductName)
            //            {
            //                // Update the previous row's quantity with the total
            //                GridViewRow prevRow = sopickgrid.Rows[i - 1];
            //                prevRow.Cells[1].Text = totalQuantity.ToString();

            //                totalQuantity = 0;
            //                currentProductName = rowProductName; // Update to the new product name
            //            }

            //            totalQuantity += quantity;
            //        }
            //    }

            //    // Update the last row's quantity with the total
            //    if (i == sopickgrid.Rows.Count - 1)
            //    {
            //        eRow.Cells[1].Text = totalQuantity.ToString();
            //    }
            //}
      //  }

        protected void sopickgrid_DataBound(object sender, EventArgs e)
        {
            for (int i = sopickgrid.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = sopickgrid.Rows[i];
                GridViewRow previousRow = sopickgrid.Rows[i - 1];
                for (int j = 0; j < row.Cells.Count; j++)
                {
                    if (j == 6 || j == 7 || j == 2 ||j==5)
                    {
                    }
                    else
                    {

                        if (j == 3)
                        {

                            if (row.Cells[j].Text == previousRow.Cells[j].Text && row.Cells[0].Text == previousRow.Cells[0].Text)
                            {
                                if (previousRow.Cells[j].RowSpan == 0)
                                {
                                    if (row.Cells[j].RowSpan == 0)
                                    {
                                        previousRow.Cells[j].RowSpan += 2;
                                    }
                                    else
                                    {
                                        previousRow.Cells[j].RowSpan = row.Cells[j].RowSpan + 1;
                                    }
                                    row.Cells[j].Visible = false;
                                }
                            }
                        }
                        else if(j == 2)
                        {
                            if (row.Cells[j].Text == previousRow.Cells[j].Text && row.Cells[0].Text == previousRow.Cells[0].Text)
                            {
                                if (previousRow.Cells[j].RowSpan == 0)
                                {
                                    if (row.Cells[j].RowSpan == 0)
                                    {
                                        previousRow.Cells[j].RowSpan += 2;
                                    }
                                    else
                                    {
                                        previousRow.Cells[j].RowSpan = row.Cells[j].RowSpan + 1;
                                    }
                                    row.Cells[j].Visible = false;
                                }
                            }
                        }
                        else if(j == 5)
                        {
                            if (row.Cells[j].Text == previousRow.Cells[j].Text && row.Cells[0].Text == previousRow.Cells[0].Text)
                            {
                                if (previousRow.Cells[j].RowSpan == 0)
                                {
                                    if (row.Cells[j].RowSpan == 0)
                                    {
                                        previousRow.Cells[j].RowSpan += 2;
                                    }
                                    else
                                    {
                                        previousRow.Cells[j].RowSpan = row.Cells[j].RowSpan + 1;
                                    }
                                    row.Cells[j].Visible = false;
                                }
                            }
                        }
                        else
                        {

                            if (row.Cells[j].Text == previousRow.Cells[j].Text)
                            {
                                if (previousRow.Cells[j].RowSpan == 0)
                                {
                                    if (row.Cells[j].RowSpan == 0)
                                    {
                                        previousRow.Cells[j].RowSpan += 2;
                                    }
                                    else
                                    {
                                        previousRow.Cells[j].RowSpan = row.Cells[j].RowSpan + 1;
                                    }
                                    row.Cells[j].Visible = false;
                                }
                            }
                        }
                    }
                }
            }
            //int sumOfQuantities = 0;

            //for (int i = 0; i < sopickgrid.Rows.Count; i++)
            //{
            //    GridViewRow row = sopickgrid.Rows[i];
            //    // Assuming the quantity column is at index 2, adjust it accordingly if it's at a different index
            //    int quantity;
            //    if (int.TryParse(row.Cells[2].Text, out quantity))
            //    {
            //        sumOfQuantities += quantity;
            //    }
            //}
        }
    }
}