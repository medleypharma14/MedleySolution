using BusinessLayer;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Medly_Wm
{
    public partial class Transpot : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
        int iTranspot = 0;
        int Desid = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["userInfo"]["Designation"] != null && Request.Cookies["userInfo"]["Empname"] != null)
                {
                    Desid = Convert.ToInt32(Request.Cookies["userInfo"]["Designation"]);

                }
                txtdoj.Text = DateTime.Now.ToString("yyyy-MM-dd");
                #region Edit
                iTranspot = Convert.ToInt32(Request.QueryString.Get("id"));

                //if (iTranspot != 0)
                //{

                //    DataSet transpotid = new DataSet();
                //    transpotid = dbObj.SelectTranspot_byId(iTranspot);
                //    ViewState["vstrans"] = iTranspot;

                //    if (transpotid.Tables[0].Rows.Count > 0)
                //    {
                //        txtTranspot.Text = transpotid.Tables[0].Rows[0]["transpot"].ToString();
                //        //txtdoj.Text =((DateTime)transpotid.Tables[0].Rows[0]["DOJ"]).ToString("yyyy/MM/dd");
                //        txtdoj.Text = Convert.ToDateTime(transpotid.Tables[0].Rows[0]["DOJ"]).ToString("dd/MM/yyyy");
                //        txtvalidtill.Text =((DateTime)transpotid.Tables[0].Rows[0]["ExpiryDate"]).ToString("yyyy/MM/dd");
                //        txtContactnum.Text = transpotid.Tables[0].Rows[0]["ContactNum"].ToString();
                //        txtAddress.Text = transpotid.Tables[0].Rows[0]["Address"].ToString();
                //       //txtTranspot.Text = transpotid.Tables[0].Rows[0]["transpot"].ToString();
                //        btnSubmit.Text = "Update";
                //        oop.Update();
                //    }
                //}
                #endregion
                #region Load transpot
                DataSet dsTranspot = new DataSet();
                dsTranspot = dbObj.SelectTranspot();
                if (dsTranspot.Tables[0].Rows.Count > 0)
                {
                    gridtranspot.DataSource = dsTranspot.Tables[0];
                    gridtranspot.DataBind();
                }
                #endregion
            }
            //string username = Request.QueryString["username"];
        }

        private void BindTranspotGrid()
        {
            DataSet transpotid = new DataSet();
            transpotid = dbObj.SelectTranspot();
            if (transpotid.Tables[0].Rows.Count > 0)
            {
                gridtranspot.DataSource = transpotid.Tables[0];
                gridtranspot.DataBind();
            }
        }
        protected void gvTranspot_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        //protected void gvTranspot_RowCommand(object sender, GridViewCommandEventArgs e)
        //{

        //}

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtTranspot.Text == "")
            {
                string script = "alert('Please Enter Transport')";
                ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
            }
           else  if (txtvalidtill.Text == "")
            {
                string script = "alert('Please Expiry Date ')";
                ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
            }
            else if (txtContactnum.Text == "")
            {
                string script = "alert('Please Enter Contact number ')";
                ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
            }
            else
            {
                if (btnSubmit.Text == "Submit")
                {
                    int isucess = 0;
                    DataSet Transname=dbObj.CheckTranspotname(txtTranspot.Text);
                    if (Transname.Tables[0].Rows.Count > 0)
                    {
                        string script1 = "alert('Transpot name Already Stored ,Please Change Transpot name')";
                        ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script1, true);
                    }
                    else
                    {
                        isucess = dbObj.InsertTranspot(txtTranspot.Text,Convert.ToDateTime(txtdoj.Text),Convert.ToDateTime(txtvalidtill.Text),txtContactnum.Text,txtAddress.Text);
                        string script = "alert('Data Saved');window.location.href='Transpot.aspx';";
                        ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                    }
                   

                }
                #region Edit
                else if (btnSubmit.Text == "Update")
                {
                        int isucess = 0;
                        isucess = dbObj.UpdateTranspot(Convert.ToInt32(id.Text), txtTranspot.Text,txtdoj.Text,txtvalidtill.Text, txtContactnum.Text, txtAddress.Text);
                        string script = "alert('Data Updated'); window.location.href = 'Transpot.aspx';";
                        ClientScript.RegisterStartupScript(this.GetType(), "UpdateMessage", script, true);
                   
                }
                #endregion
               
            }
            oop.Update();
        }
        protected void gridtranspot_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region Edit

            if (e.CommandName == "edit123")
            {
                int transid = Convert.ToInt32(e.CommandArgument);
                id.Text=transid.ToString();
                if (transid != 0)
                {

                    DataSet transpotid = new DataSet();
                    transpotid = dbObj.SelectTranspot_byId(transid);
                    ViewState["vstrans"] = iTranspot;

                    if (transpotid.Tables[0].Rows.Count > 0)
                    {
                        txtTranspot.Text = transpotid.Tables[0].Rows[0]["transpot"].ToString();
                        txtdoj.Text = ((DateTime)transpotid.Tables[0].Rows[0]["DOJ"]).ToString("yyyy-MM-dd");

                        //txtdoj.Text =((DateTime)transpotid.Tables[0].Rows[0]["DOJ"]).ToString("yyyy/MM/dd");
                       // txtdoj.Text = Convert.ToDateTime(transpotid.Tables[0].Rows[0]["DOJ"]).ToString("dd/MM/yyyy");
                        txtvalidtill.Text = ((DateTime)transpotid.Tables[0].Rows[0]["ExpiryDate"]).ToString("yyyy-MM-dd");
                        txtContactnum.Text = transpotid.Tables[0].Rows[0]["ContactNum"].ToString();
                        txtAddress.Text = transpotid.Tables[0].Rows[0]["Address"].ToString();
                        //txtTranspot.Text = transpotid.Tables[0].Rows[0]["transpot"].ToString();
                        btnSubmit.Text = "Update";
                        
                    }
                }
                // Response.Redirect("Transpot.aspx?Event=Edit&id=" + e.CommandArgument.ToString());

            }
            else if (e.CommandName == "Del")
            {
                int iDesignationId = Convert.ToInt32(e.CommandArgument);
                dbObj.DeleteTranspot(iDesignationId);
                BindTranspotGrid();
            }
            #endregion
            oop.Update();
        }

        protected void gridtranspot_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
            if (e.Row.RowType == DataControlRowType.DataRow && gridtranspot.EditIndex == -1)
            {
                LinkButton btndel = (LinkButton)e.Row.FindControl("btndel");
                LinkButton btnedit = (LinkButton)e.Row.FindControl("btnedit");
                ImageButton imgdel = (ImageButton)e.Row.FindControl("imgdel");
                ImageButton imgEdit = (ImageButton)e.Row.FindControl("imgEdit");
                if (Desid == 1 || Desid == 2 || Desid == 3)
                {
                    btndel.Enabled = true;
                    imgdel.Enabled = true;
                    btnedit.Enabled=true;
                    imgEdit.Enabled=true;
                }
            }

        }

        protected void txtContactnum_TextChanged(object sender, EventArgs e)
        {
            iTranspot = Convert.ToInt32(Request.QueryString.Get("id"));

            if (iTranspot != 0)
            {
                DataSet pnocheck = dbObj.Check_Transnumberupdate(txtContactnum.Text, iTranspot);
                if (pnocheck.Tables[0].Rows.Count > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Msg", "alert('Given Number Already Stored!');", true);
                    txtContactnum.Text = "";
                }
            }
            else
            {
                DataSet pnocheck = dbObj.Check_Transnumber(txtContactnum.Text);
                if (pnocheck.Tables[0].Rows.Count > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Msg", "alert('Given Number Already Stored!');", true);
                    txtContactnum.Text = "";
                }
            }
        }

        protected void txtvalidtill_TextChanged(object sender, EventArgs e)
        {
            DateTime today=DateTime.Now;
            if (txtvalidtill.Text != "")
            {
                DateTime validate = Convert.ToDateTime(txtvalidtill.Text);
                if (validate < today)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(),"Msg", "alert('Please select Valid expiry date !');", true);
                    txtvalidtill.Text = "";
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Msg", "alert('Please select expiry date !');", true);
            }
        }
    }
}