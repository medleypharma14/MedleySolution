using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using Antlr.Runtime.Tree;
using System.Data.SqlTypes;

namespace Medly_Wm
{
    public partial class Designation : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
        int iDesignationId = 0;
        int Desid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["userInfo"]["Designation"] != null && Request.Cookies["userInfo"]["Empname"] != null)
                {
                    Desid = Convert.ToInt32(Request.Cookies["userInfo"]["Designation"]);

                }
                #region Edit
                iDesignationId = Convert.ToInt32(Request.QueryString.Get("Desgid"));

                if (iDesignationId != 0)
                {

                    DataSet dsDesgnId = new DataSet();
                    dsDesgnId = dbObj.SelectDesignation_byId(iDesignationId);
                    ViewState["vsDesg"] = iDesignationId;

                    if (dsDesgnId.Tables[0].Rows.Count > 0)
                    {
                        txtName.Text = dsDesgnId.Tables[0].Rows[0]["Designation"].ToString();
                        btnSubmit.Text = "Update";
                    }
                }
                #endregion
                #region Load Designation
                DataSet dsDesignation = new DataSet();
                dsDesignation = dbObj.SelectDesignation();
                if (dsDesignation.Tables[0].Rows.Count > 0)
                {
                    gvDesignation.DataSource = dsDesignation.Tables[0];
                    gvDesignation.DataBind();
                }
                #endregion
            }
            string username = Request.QueryString["username"];
        }
        protected void DataPager1_PreRender(object sender, EventArgs e)
        {
            #region Load Designation
            DataSet dsDesignation = new DataSet();
            dsDesignation = dbObj.SelectDesignation();
            if (dsDesignation.Tables[0].Rows.Count > 0)
            {
                gvDesignation.DataSource = dsDesignation.Tables[0];
                gvDesignation.DataBind();
            }
            #endregion
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // Set the new page index
            gvDesignation.PageIndex = e.NewPageIndex;

            // Re-bind the GridView with the updated page index
            DataSet dsDesignation = new DataSet();
            dsDesignation = dbObj.SelectDesignation();
            if (dsDesignation.Tables[0].Rows.Count > 0)
            {
                gvDesignation.DataSource = dsDesignation.Tables[0];
                gvDesignation.DataBind();
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                string script = "alert('Please Enter Designation')";
                ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
            }
            else
            {

                if (btnSubmit.Text == "Submit")
                {
                    int isucess = 0;
                    DataSet desname = dbObj.CheckDesignation(txtName.Text);
                    if (desname.Tables[0].Rows.Count > 0)
                    {
                        int isdel =Convert.ToInt32(desname.Tables[0].Rows[0]["IsDel"]);
                        if (isdel == 0)
                        {
                            string script1 = "alert('Given Name Already Stored ,Please Change Designation')";
                            ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script1, true);
                        }
                        else
                        {
                            isucess = dbObj.UpdateDesignationinsert(txtName.Text);
                        }
                        
                    }
                    else
                    {
                        isucess = dbObj.InsertDesignation(txtName.Text);
                        //Response.Redirect("../Accountsbootstrap/viewbranch.aspx");
                        string script = "alert('Data Saved')";
                        ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                        Response.Redirect("Designation.aspx");
                    }

                }
                #region Edit
                else if (btnSubmit.Text == "Update")
                {
                    int isucess = 0;
                    DataSet desname = dbObj.CheckDesignation(txtName.Text);
                    if (desname.Tables[0].Rows.Count > 0)
                    {
                        string script1 = "alert('Given Designation Already Stored ,Please Change Designation')";
                        ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script1, true);
                    }
                    else
                    {

                        isucess = dbObj.UpdateDesignation(Convert.ToInt32(ViewState["vsDesg"].ToString()), txtName.Text);
                        string script = "alert('Data Updated')";
                        ClientScript.RegisterStartupScript(this.GetType(), "UpdateMessage", script, true);
                        Response.Redirect("Designation.aspx");
                    }

                }
                #endregion
                BindDesignationGrid();
            }
        }
        protected void gvDesignation_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region Edit

            if (e.CommandName == "edit")
            {
                Response.Redirect("Designation.aspx?Event=Edit&Desgid=" + e.CommandArgument.ToString());

            }
            else if (e.CommandName == "Del")
            {
                int iDesignationId = Convert.ToInt32(e.CommandArgument);
                dbObj.DeleteDesignation(iDesignationId);
                BindDesignationGrid();
            }
            #endregion
        }
        private void BindDesignationGrid()
        {
            DataSet dsDesignation = new DataSet();
            dsDesignation = dbObj.SelectDesignation();
            if (dsDesignation.Tables[0].Rows.Count > 0)
            {
                gvDesignation.DataSource = dsDesignation.Tables[0];
                gvDesignation.DataBind();
            }
        }

        protected void gvDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvDesignation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && gvDesignation.EditIndex == -1)
            {
                LinkButton btnedit=(LinkButton)e.Row.FindControl("btnedit");
                ImageButton imedit = (ImageButton)e.Row.FindControl("imgEdit");
                LinkButton btndel = (LinkButton)e.Row.FindControl("btndel");
                ImageButton imgdel = (ImageButton)e.Row.FindControl("imgDel");
                if (Desid == 1 || Desid==2 || Desid==3)
                {
                    btnedit.Enabled = true;
                    imedit.Enabled = true;
                    btndel.Enabled = true;
                    imgdel.Enabled = true;
                }
            }
        }
    }
}