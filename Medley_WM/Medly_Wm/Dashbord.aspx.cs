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
    public partial class Dashbord : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime Today = DateTime.Now;
            txtfromate.Text = Today.ToString("yyyy-MM-dd");
            txttodate.Text = Today.ToString("yyyy-MM-dd");
            #region Total Supplier
            DataSet dssupplier = new DataSet();
            dssupplier = dbObj.TotalSupplier();
            if (dssupplier.Tables[0].Rows.Count > 0)
            {
                lblTotalsuppliers.Text= dssupplier.Tables[0].Rows[0]["TotalSuppliers"].ToString();
            }
            else
            {
                lblTotalsuppliers.Text = "No Suppliers";
            }
            #endregion

            #region Qualified Supplier
            string date = DateTime.Now.ToString("yyyy/MM/dd");
            DataSet dsqusup = new DataSet();
            dsqusup = dbObj.QualifiedSupplier(date);
            if (dsqusup.Tables[0].Rows.Count > 0)
            {
                lblQualifiedsuppliers.Text = dsqusup.Tables[0].Rows[0]["TotalSuppliers"].ToString();
            }
            else
            {
                lblQualifiedsuppliers.Text = "No Qualified Suppliers";
            }
            #endregion

            #region Non Qualified Supplier
            string date1 = DateTime.Now.ToString("yyyy/MM/dd");
            DataSet dsnqusup = new DataSet();
            dsnqusup = dbObj.NonQualifiedSupplier(date1);
            if (dsnqusup.Tables[0].Rows.Count > 0)
            {
                lblNqsuppliers.Text = dsnqusup.Tables[0].Rows[0]["TotalSuppliers"].ToString();
            }
            else
            {
                lblNqsuppliers.Text = "No Non Qualified Suppliers";
            }
            #endregion

            #region Not Active Supplier
            string date3 = DateTime.Now.ToString("yyyy/MM/dd");
            DataSet dsnausup = new DataSet();
            dsnausup = dbObj.NotActiveSupplier();
            if (dsnausup.Tables[0].Rows.Count > 0)
            {
                lblNotacivesuppliers.Text = dsnausup.Tables[0].Rows[0]["TotalSuppliers"].ToString();
            }
            else
            {
                lblNotacivesuppliers.Text = "No Not Active Suppliers";
            }
            #endregion

            #region Warehouse Occupied units
            lblTotalunits.Text = "473";
            #endregion

            #region Occupied Warehouse
            DataSet dsoccupied = new DataSet();
            dsoccupied = dbObj.Occupiedunits();
            if (dsoccupied.Tables[0].Rows.Count > 0)
            {
                lblOccupiedunits.Text = dsoccupied.Tables[0].Rows[0]["unitqty"].ToString();
            }
            else
            {
                lblOccupiedunits.Text = "No Occupied Units";
            }
            #endregion

            #region Available Warehouse
            DataSet dsavailable = new DataSet();
            dsavailable = dbObj.Availableunit();
            if (dsavailable.Tables[0].Rows.Count > 0)
            {
                lblAvailableuniuts.Text = dsavailable.Tables[0].Rows[0]["unitqty"].ToString();
            }
            else
            {
                lblAvailableuniuts.Text = "No Occupied Units";
            }
            #endregion

            #region Total Unit qty
            DataSet dsunitqty = new DataSet();
            dsunitqty = dbObj.Totalunitqty();
            if (dsunitqty.Tables[0].Rows.Count > 0)
            {
                lblTotalqty.Text = dsunitqty.Tables[0].Rows[0]["totalunitqty"].ToString();
            }
            else
            {
                lblTotalqty.Text = "No Quantity in That units";
            }
            #endregion

            #region Sample Quantity
            DataSet dssampleqty = new DataSet();
            dssampleqty = dbObj.SampleQty();
            if (dssampleqty.Tables[0].Rows.Count > 0)
            {
                lblSampleqty.Text = dssampleqty.Tables[0].Rows[0]["SamQty"].ToString();
            }
            else
            {
                lblSampleqty.Text = "No Quantity in That Samples";
            }
            #endregion

            #region Quarantine Batches
            DataSet dsquarantine = new DataSet();
            dsquarantine = dbObj.Quarntine();
            if (dsquarantine.Tables[0].Rows.Count > 0)
            {
                lblquarantinebatch.Text = dsquarantine.Tables[0].Rows[0]["Batchstatus"].ToString();
            }
            else
            {
                lblquarantinebatch.Text = "No Quarantine batches availabe in Units";
            }
            #endregion

            #region Rejected Batches
            DataSet dsrejected = new DataSet();
            dsrejected = dbObj.Rejected();
            if (dsrejected.Tables[0].Rows.Count > 0)
            {
                lblRejectedbatch.Text = dsrejected.Tables[0].Rows[0]["Batchstatus"].ToString();
            }
            else
            {
                lblRejectedbatch.Text = "No Rejected batches availabe in Units";
            }
            #endregion

            #region Released  Batches
            DataSet dsreleased = new DataSet();
            dsreleased = dbObj.Released();
            if (dsreleased.Tables[0].Rows.Count > 0)
            {
                lblReleasedbatch.Text = dsreleased.Tables[0].Rows[0]["Batchstatus"].ToString();
            }
            else
            {
                lblReleasedbatch.Text = "No Rejected batches availabe in Units";
            }
            #endregion

            #region Total PO
            DataSet dstotalPO = new DataSet();
            dstotalPO = dbObj.TotalPO();
            if (dstotalPO.Tables[0].Rows.Count > 0)
            {
                lblTotalPO.Text = dstotalPO.Tables[0].Rows[0]["totalpo"].ToString();
            }
            else
            {
                lblTotalPO.Text = "NO Po available";
            }
            #endregion

            #region Closed PO
            DataSet dsclosedPO = new DataSet();
            dsclosedPO = dbObj.ClosedPO();
            if (dsclosedPO.Tables[0].Rows.Count > 0)
            {
                lblClosedPO.Text = dsclosedPO.Tables[0].Rows[0]["closedgr"].ToString();
            }
            else
            {
                lblClosedPO.Text = "There is no closed Po";
            }
            #endregion

            #region Sales Order

            DataSet dstotalso = new DataSet();
            dstotalso = dbObj.TotalSO();
            if (dstotalso.Tables[0].Rows.Count > 0)
            {
                lblTotalSo.Text = dstotalso.Tables[0].Rows[0]["totalso"].ToString();
                lbltotalamount.Text = dstotalso.Tables[0].Rows[0]["totalamount"].ToString();
            }
            else
            {
                lblTotalSo.Text = "PO Not Created";
                lbltotalamount.Text = "";
            }
            #endregion
        }
        protected void txtpo_TextChanged(object sender, EventArgs e)
        {
            if (txtpo.Text == "Today")
            {
                #region PO Select
                DateTime date = DateTime.Now;
                DataSet dstodaypo = new DataSet();
                dstodaypo = dbObj.TodaySO(Convert.ToDateTime(date).Date);
                if (dstodaypo.Tables[0].Rows.Count > 0)
                {
                    lblTotalSo.Text = dstodaypo.Tables[0].Rows[0]["totalso"].ToString();
                    lbltotalamount.Text = dstodaypo.Tables[0].Rows[0]["totalamount"].ToString();
                }
                else
                {
                    lblTotalSo.Text = "SO Not Created";
                    lbltotalamount.Visible = false;
                }
                #endregion
            }
            else if(txtpo.Text == "Yesterday")
            {
                #region PO Select
                DateTime date = DateTime.Now;
                date = date.AddDays(-1);
                DataSet dstodaypo = new DataSet();
                dstodaypo = dbObj.TodaySO(Convert.ToDateTime(date).Date);
                if (dstodaypo.Tables[0].Rows.Count > 0)
                {
                    lblTotalSo.Text = dstodaypo.Tables[0].Rows[0]["totalso"].ToString();
                    lbltotalamount.Text = dstodaypo.Tables[0].Rows[0]["totalamount"].ToString();
                }
                else
                {
                    lblTotalSo.Text = "SO Not Created";
                    lbltotalamount.Text ="";
                }
                #endregion
            }
            else
            {
                DataSet dstotalso = new DataSet();
                dstotalso = dbObj.TotalSO();
                if (dstotalso.Tables[0].Rows.Count > 0)
                {
                    lblTotalSo.Text = dstotalso.Tables[0].Rows[0]["totalso"].ToString();
                    lbltotalamount.Text = dstotalso.Tables[0].Rows[0]["totalamount"].ToString();
                }
                else
                {
                    lblTotalSo.Text = "PO Not Created";
                    lbltotalamount.Text = "";
                }
            }
        }
        protected void check_Click(object sender, EventArgs e)
        {
            DataSet dssaleorder = new DataSet();
            dssaleorder = dbObj.Salesorder(Convert.ToDateTime(txtfromate.Text).Date, Convert.ToDateTime(txttodate.Text).Date);
            if (dssaleorder.Tables[0].Rows.Count > 0)
            {
                lblTotalSo.Text = dssaleorder.Tables[0].Rows[0]["totalso"].ToString();
                lbltotalamount.Text = dssaleorder.Tables[0].Rows[0]["totalamount"].ToString();
            }
            else
            {

            }
        }
    }
}