using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medly_Wm
{
    public partial class ProductGridpage : System.Web.UI.Page
    {
       
        BSClass dbObj = new BSClass();
        int iproductID =0;
        int Desid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                if (Request.Cookies["userInfo"]["Designation"] != null && Request.Cookies["userInfo"]["Empname"] != null)
                {
                    Desid = Convert.ToInt32(Request.Cookies["userInfo"]["Designation"]);

                }

                #region Load Product
                DataSet dsProduct = new DataSet();
                dsProduct = dbObj.Select_Product();
                if (dsProduct.Tables[0].Rows.Count > 0)
                {
                    gvProduct.DataSource = dsProduct.Tables[0];
                    gvProduct.DataBind();
                }
                #endregion
            }

        }

        protected void gvProduct_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && gvProduct.EditIndex == -1)
            {
               
                LinkButton btnEdit = (LinkButton)e.Row.FindControl("btnedit");
                ImageButton imgEdit = (ImageButton)e.Row.FindControl("imgEdit");

                LinkButton btndel = (LinkButton)e.Row.FindControl("btndel");
                ImageButton imgDel = (ImageButton)e.Row.FindControl("imgDel");

                DataRowView drv = (DataRowView)e.Row.DataItem;
                string Status = Convert.ToString(drv["Status"]);

                
                if (Desid == 1 || Desid == 2 || Desid == 3)
                {
                    btnEdit.Enabled = true;
                    imgEdit.Enabled = true;
                    btndel.Enabled = true;
                    imgDel.Enabled = true;
                }
            }
        }
        protected void gvProduct_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            DataSet ds = new DataSet();
            if (e.CommandName == "edit")
            {
                Response.Redirect("Addproduct.aspx?Event=Edit&iProductID=" + e.CommandArgument.ToString());

            }
            else if (e.CommandName == "Del")
            {
                int iProductID = Convert.ToInt32(e.CommandArgument);
                dbObj.deleteProduct(iProductID);
                BindProductGrid();
            }

        }
        private void BindProductGrid()
        {
            DataSet dsProduct = new DataSet();
            dsProduct = dbObj.Select_Product();
            if (dsProduct.Tables[0].Rows.Count > 0)
            {
                gvProduct.DataSource = dsProduct.Tables[0];
                gvProduct.DataBind();
            } 
        }

      

        //protected void rbexpirydate_TextChanged(object sender, EventArgs e)
        //{
        //    if (rbexpirydate.SelectedValue == "0")
        //    {
        //        string year1 = "2023";
        //        string year2 = "2024";
        //        #region Load Product
        //        DataSet dsProduct = new DataSet();
        //        dsProduct = dbObj.Select_ExpiryThisyear(year1, year2);
        //        if (dsProduct.Tables[0].Rows.Count > 0)
        //        {
        //            gvProduct.DataSource = dsProduct.Tables[0];
        //            gvProduct.DataBind();
        //        }
        //        #endregion
        //    }
        //    else if (rbexpirydate.SelectedValue == "1")
        //    {
        //        string year1 = "2024";
        //        string year2 = "2025";
        //        #region Load Product
        //        DataSet dsProduct = new DataSet();
        //        dsProduct = dbObj.Select_ExpiryThisyear(year1, year2);
        //        if (dsProduct.Tables[0].Rows.Count > 0)
        //        {
        //            gvProduct.DataSource = dsProduct.Tables[0];
        //            gvProduct.DataBind();
        //        }
        //        #endregion
        //    }
            //#region Load Product
            //DataSet dsProduct = new DataSet();
            //dsProduct = dbObj.Select_ExpiryThisyear(year1,year2);
            //if (dsProduct.Tables[0].Rows.Count > 0)
            //{
            //    gvProduct.DataSource = dsProduct.Tables[0];
            //    gvProduct.DataBind();
            //}
            //#endregion


            //if (rbexpirydate.SelectedValue == "0")
            //{
            //#region Load Product
            //DataSet dsProduct = new DataSet();
            //dsProduct = dbObj.Select_ExpiryThisyear();
            //if (dsProduct.Tables[0].Rows.Count > 0)
            //{
            //    gvProduct.DataSource = dsProduct.Tables[0];
            //    gvProduct.DataBind();
            //}
            //#endregion
            //}
            //else if(rbexpirydate.SelectedValue == "1")
            //{
            //    #region Load Product
            //    DataSet dsProduct = new DataSet();
            //    dsProduct = dbObj.Select_ExpiryNextyear();
            //    if (dsProduct.Tables[0].Rows.Count > 0)
            //    {
            //        gvProduct.DataSource = dsProduct.Tables[0];
            //        gvProduct.DataBind();
            //}
            //    }

        }
    }
