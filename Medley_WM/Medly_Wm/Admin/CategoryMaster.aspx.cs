using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DataLayer;
using CommonLayer;
using System.Data;
using System.Net;
using System.IO;
using System.Text;
using System.Globalization;

namespace AdminAfforadbleApp
{
    public partial class CategoryMaster : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
        string Strname;
        string Id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnSave.Text = "Save";
                txtcategoryname.Focus();
                DataSet ds = dbObj.BindCategory();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvcategory.DataSource = ds;
                    gvcategory.DataBind();
                }
                else
                {
                    gvcategory.DataSource = null;
                    gvcategory.DataBind();
                }
            }


        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                if (btnSave.Text.ToString() == "Save")
                {



                    if (txtcategoryname.Text == "")
                    {

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Enter Category Name');", true);
                        txtcategoryname.Focus();
                        return;
                    }
                    else
                    {
                        DataSet ds = dbObj.CheckCategoryName(txtcategoryname.Text);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Category Name Already Exist ');", true);
                            txtcategoryname.Text = "";
                            txtcategoryname.Focus();
                            return;
                        }
                        else
                        {
                        }
                    }

                    ////if (!fucategoryimage.HasFile)
                    ////{
                    ////    ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Upload Image');", true);
                    ////    return;
                    ////}
                    ////else
                    ////{

                    ////    Strname = fucategoryimage.FileName.ToString();
                    ////    fucategoryimage.PostedFile.SaveAs(Server.MapPath("~/images/") + Strname);

                    ////}

                    string active = "Yes";
                    int iSuccess = dbObj.insert_category(txtcategoryname.Text, lblfilename1.Text , active);

                    txtcategoryname.Text = "";
                    imgcategory.ImageUrl = "";
                    fucategoryimage.FileName.Trim();
                    LoadGrid();


                }
                else if (btnSave.Text == "Update")
                {
                    // string active = "Yes";


                    ////Strname = Path.GetFileName(fucategoryimage.PostedFile.FileName);

                    //////   lblfilename1.Text = Strname;
                    //////  lblfilename.Text=


                    ////if (fucategoryimage.FileName.ToString() == "")
                    ////{
                    ////    lblfilename1.Text = lblfilename.Text;

                    ////}
                    ////else
                    ////{
                    ////    lblfilename1.Text = Path.GetFileName(fucategoryimage.PostedFile.FileName);
                    ////    fucategoryimage.PostedFile.SaveAs(Server.MapPath("~/images/") + lblfilename1.Text);
                    ////    lblfilename.Text = lblfilename1.Text;
                    ////    lblfilename1.Visible = false;

                    ////}



                    int iSuccess = dbObj.Update_category(txtcategoryname.Text, lblfilename1.Text, lblid.Text);

                    //   }
                    txtcategoryname.Text = "";
                   // lblfilename.Visible = false;
                    fucategoryimage.FileName.Trim();
                    imgcategory.ImageUrl = "";
                    btnSave.Text = "Save";
                   // lblfilename.Text = "";
                    lblfilename1.Text = "";
                    LoadGrid();

                }

            }
            catch (Exception ex)
            { throw ex; }
      
        }

        public void LoadGrid()
        {
            DataSet ds = dbObj.BindCategory();
            if (ds.Tables[0].Rows.Count > 0)
            {
               gvcategory.DataSource = ds;
                gvcategory.DataBind();
            }
            else
            {
                gvcategory.DataSource = null;
                gvcategory.DataBind();
            }
        }


        protected void gvcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
           // lblName.Text = "Update UOM";

            if (gvcategory.SelectedDataKey.Value != null && gvcategory.SelectedDataKey.Value.ToString() != "")
             
            {
                Id = gvcategory.SelectedDataKey.Value.ToString();
                DataSet ds = dbObj.GetEditCategory (Id);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Id = ds.Tables[0].Rows[0]["CategoryId"].ToString();
                   // listcategory.Enabled = false;
                    txtcategoryname.Text = ds.Tables[0].Rows[0]["CategoryName"].ToString();

                    lblfilename1.Text = ds.Tables[0].Rows[0]["CategoryImagePath"].ToString();
                    imgcategory.ImageUrl = ds.Tables[0].Rows[0]["CategoryImagePath"].ToString();
                    lblid.Text = ds.Tables[0].Rows[0]["CategoryId"].ToString();
                   
                  //  lblfilename.Visible = true;
                    btnSave.Visible = true;
                    btnSave.Text = "Update";
                    txtcategoryname.Focus();
                }
            }
        }


        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtcategoryname.Text = "";
            fucategoryimage.FileName.Trim();
            imgcategory.ImageUrl = "";
            btnSave.Text = "Save";
          //  lblfilename.Visible = false;
          //  lblfilename.Text = "";
            lblfilename1.Text = "";
            txtcategoryname.Focus();
        }

     


        protected void gvcategory_Rowcommand(object sender, GridViewCommandEventArgs e)
        {


            if (e.CommandName == "Del")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    dbObj.delete_category(e.CommandArgument.ToString());
                    LoadGrid();
                    //Response.Redirect("categorygrid.aspx");
                }
            }

        }

        protected void btnuploadimg_Clickimg(object sender, EventArgs e)
        {
            if (fucategoryimage.HasFile)
            {
                string fileName = Path.GetFileName(fucategoryimage.PostedFile.FileName);
                fucategoryimage.PostedFile.SaveAs(Server.MapPath("~/Admin/Files/") + fileName);
                lblfilename1.Text = "~/Admin/Files/" + fucategoryimage.PostedFile.FileName;
                imgcategory.ImageUrl = "~/Admin/Files/" + fucategoryimage.PostedFile.FileName;
            }
        }
        //protected void gvcategory_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    gvcategory.PageIndex = e.NewPageIndex;
        //    this.DataBind();
        //}
    }
}