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
using System.IO;
using System.Net;
using System.Text;
using System.IO.MemoryMappedFiles;

namespace AdminAfforadbleApp
{
    public partial class ProductMaster : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
        string strdoc;
        string strvideo;
        string strpimg;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategory();

                string ProductId = Request.QueryString.Get("ProductId");
                if (ProductId != null)
                {

                    DataSet ds = dbObj.GetEditProduct(ProductId);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string Id = ds.Tables[0].Rows[0]["ProductId"].ToString();
                        // listcategory.Enabled = false;
                        ddlCategory.SelectedValue = ds.Tables[0].Rows[0]["CategoryId"].ToString();

                        txtProductname.Text = ds.Tables[0].Rows[0]["ProductName"].ToString();

                        lblid.Text = ds.Tables[0].Rows[0]["ProductId"].ToString();


                       

                        txtProductmodelno.Text = ds.Tables[0].Rows[0]["ModalNo"].ToString();
                        txtWarrantyyear.Text = ds.Tables[0].Rows[0]["WarrantyYear"].ToString();
                        txtWarrantymonth.Text = ds.Tables[0].Rows[0]["WarrantyMonth"].ToString();
                        lblimgurl1.Text = ds.Tables[0].Rows[0]["ImageURL"].ToString();
                        lblvidurl1.Text = ds.Tables[0].Rows[0]["VideoURL"].ToString();
                        lbldocurl1.Text = ds.Tables[0].Rows[0]["DocumentURL"].ToString();
                        img_Photo.ImageUrl=ds.Tables[0].Rows[0]["ImageURL"].ToString();
                        txtBranname.Text = ds.Tables[0].Rows[0]["BrandName"].ToString();
                        txtSupplierName.Text = ds.Tables[0].Rows[0]["SupplierName"].ToString();
                        lbldocurl1.Text = ds.Tables[0].Rows[0]["Catalogue"].ToString();
                        lblManualDocURL1.Text = ds.Tables[0].Rows[0]["Manual"].ToString();
                        lblFloorDocURL1.Text = ds.Tables[0].Rows[0]["FloorPrepare"].ToString();
                        lblInstallManualURL1.Text = ds.Tables[0].Rows[0]["InstallationManual"].ToString();
                        lblInstallChecklistURL1.Text = ds.Tables[0].Rows[0]["InstallationChecklist"].ToString();
                        lblServiceChecklistURL1.Text = ds.Tables[0].Rows[0]["ServiceChecklist"].ToString();
                        lblWarrantyURL1.Text = ds.Tables[0].Rows[0]["WarrantyTemplate"].ToString();
                        lblvidurl1.Text = ds.Tables[0].Rows[0]["InstallationVideo"].ToString();
                        lblvidurl2.Text = ds.Tables[0].Rows[0]["ServiceVideo"].ToString();
                        ddlAutoTime.SelectedValue = ds.Tables[0].Rows[0]["ServiceSchedule"].ToString();
                       // string vid
                        vdeotag.Attributes["src"]  =ds.Tables[0].Rows[0]["VideoURL"].ToString();
                       // vdeotag.(Server.MapPath(vid));

                       // str(
                       // filectrl.ResolveClientUrl(Server.MapPath(vid));
                      //  filectrl.PostedFile(ds.Tables[0].Rows[0]["VideoURL"].ToString());
                        //  = ds.Tables[0].Rows[0]["VideoURL"].ToString();
                       // imgvid.ImageUrl = ds.Tables[0].Rows[0]["VideoURL"].ToString();
                        ////imgdoc.ImageUrl = ds.Tables[0].Rows[0]["DocumentURL"].ToString();
                        ////lbldocurl.Visible = false;
                        ////lblimgurl.Visible = false;
                        ////lblvidurl.Visible = false;

                        #region PDF
                        Catalogue.Visible = true;
                        Catalogue.HRef = Server.MapPath(lbldocurl1.Text);

                        manual.Visible = true;
                        manual.HRef = Server.MapPath(lblManualDocURL1.Text);

                        floor.Visible = true;
                        floor.HRef = Server.MapPath(lblFloorDocURL1.Text);

                        instmanual.Visible = true;
                        instmanual.HRef = Server.MapPath(lblInstallManualURL1.Text);

                        instchecklist.Visible = true;
                        instchecklist.HRef = Server.MapPath(lblInstallChecklistURL1.Text);

                        servchecklist.Visible = true;
                        servchecklist.HRef = Server.MapPath(lblServiceChecklistURL1.Text);

                        warrantytemp.Visible = true;
                        warrantytemp.HRef = Server.MapPath(lblWarrantyURL1.Text);

                        #endregion

                        btnSave.Visible = true;
                        btnSave.Text = "Update";
                        lbldocurl1.Visible = true;
                    }
                }
                else
                {


                    //  LoadGrid();
                    btnSave.Text = "Save";
                  //  lblvidurl.Visible = false;
                    lblimgurl.Visible = false;
                  //  lbldocurl.Visible = false;
                    Catalogue.Visible = false;
                    manual.Visible = false;
                    floor.Visible = false;
                    instmanual.Visible = false;
                    instchecklist.Visible = false;
                    servchecklist.Visible = false;
                    warrantytemp.Visible = false;
                    Clear();
                }
            }

        }
        protected void LoadCategory()
        {
            DataSet ds = dbObj.BindCategory();
            if (ds != null)
            {
                ddlCategory.DataTextField = "CategoryName";
                ddlCategory.DataValueField = "CategoryId";
                ddlCategory.DataSource = ds;
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, "Select Category");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (ddlCategory.SelectedValue == "Select Category")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Please Select Category');", true);
                    ddlCategory.Focus();
                    return;
                }
                if (txtProductname.Text == "")
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Enter Product Name');", true);
                    txtProductname.Focus();
                    return;
                }
                if (txtProductmodelno.Text == "")
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please Enter Modal No');", true);
                    txtProductmodelno.Focus();
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

                if (btnSave.Text == "Save")
                {



                    int iSuccess = dbObj.insert_Product(ddlCategory.SelectedValue.ToString(), txtProductname.Text, txtProductmodelno.Text, txtWarrantyyear.Text, txtWarrantymonth.Text, lblimgurl1.Text, lblvidurl1.Text, lbldocurl1.Text,txtBranname.Text,txtSupplierName.Text,lbldocurl1.Text,lblManualDocURL1.Text,lblFloorDocURL1.Text,lblInstallManualURL1.Text,lblInstallChecklistURL1.Text,lblServiceChecklistURL1.Text,lblWarrantyURL1.Text,lblvidurl1.Text,lblvidurl2.Text,Convert.ToInt32(ddlAutoTime.SelectedValue));
                    //txtcategoryname.Text = "";
                    //fucategoryimage.FileName.Trim();
                    //LoadGrid();
                    Clear();
                    Response.Redirect("ProductGrid.aspx");
                }
                else if (btnSave.Text == "Update")
                {





                    int iSuccess1 = dbObj.Update_Product(ddlCategory.SelectedValue.ToString(), txtProductname.Text, txtProductmodelno.Text, txtWarrantyyear.Text, txtWarrantymonth.Text, lblimgurl1.Text, lblvidurl1.Text, lbldocurl1.Text, lblid.Text, txtBranname.Text, txtSupplierName.Text, lbldocurl1.Text, lblManualDocURL1.Text, lblFloorDocURL1.Text, lblInstallManualURL1.Text, lblInstallChecklistURL1.Text, lblServiceChecklistURL1.Text, lblWarrantyURL1.Text, lblvidurl1.Text, lblvidurl2.Text, Convert.ToInt32(ddlAutoTime.SelectedValue));
                    //fucategoryimage.FileName.Trim();
                    // LoadGrid();
                    Clear();

                    btnSave.Text = "Save";
                    //lblvidurl.Visible = false;
                    lblimgurl.Visible = false;
                    lbldocurl.Visible = false;
                    Response.Redirect("ProductGrid.aspx");
                }

            }
            catch (Exception ex)
            { throw ex; }
        }


       
       
        

        protected void Clear()
        {
            txtProductname.Text = "";
            txtProductmodelno.Text = "";
            txtWarrantyyear.Text = "";
            txtWarrantymonth.Text = "";
            fuProductimage.FileName.Trim();
          //  fuvideo.FileName.Trim();
            ddlCategory.SelectedIndex = 0;
            fuGuidancedocument.FileName.Trim();
          //  lblvidurl.Text = "";
            lblimgurl.Text = "";
            lbldocurl.Text = "";
            
            lblvidurl1.Text = "";
            lblimgurl1.Text = "";
            lbldocurl1.Text = "";
            btnSave.Text = "Save";
            img_Photo.ImageUrl = "";
          //  imgdoc.ImageUrl = "";
           // imgvid.ImageUrl = "";


        }
        //protected void btnReset_Click(object sender, EventArgs e)
        //{
        //    Clear();
        //}
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductGrid.aspx");
        }

        protected void btnUpload_Clickimg(object sender, EventArgs e)
        {
            if (fuProductimage.HasFile)
            {
                string fileName = Path.GetFileName(fuProductimage.PostedFile.FileName);
                fuProductimage.PostedFile.SaveAs(Server.MapPath("~/Admin/Files/") + fileName);
                lblimgurl1.Text = "Files/" + fuProductimage.PostedFile.FileName;
                img_Photo.ImageUrl = "~/Admin/Files/" + fuProductimage.PostedFile.FileName;
            }
        }
        protected void btnUpload1_Clickimg(object sender, EventArgs e)
        {
           
                HttpPostedFile postedFile = Request.Files[0];
                if (postedFile != null && postedFile != null)
                {
                    string fileName = Path.GetFileName(filectrl.PostedFile.FileName);
                    filectrl.PostedFile.SaveAs(Server.MapPath("~/Admin/Files/") + fileName);
                   // lblfilename.Text = "temp/" + filectrl.PostedFile.FileName;

                   // postedFile.SaveAs(Server.MapPath(str));
                    // postedFile.SaveAs(str);
                 //   txtfilename.Text = str;
                    lblvidurl1.Text = "Files/" + filectrl.PostedFile.FileName; 

                   // ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Video is uploaded');", true);
              
               // else
                  //  ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please upload your Video');", true);
            }
           
            ////if (fuvideo.HasFile)
            ////{
            ////    string fileName = Path.GetFileName(fuvideo.PostedFile.FileName);
            ////    fuvideo.PostedFile.SaveAs(Server.MapPath("~/Admin/Files/") + fileName);
            ////    lblvidurl1.Text = "~/Admin/Files/" + fuvideo.PostedFile.FileName;
            ////    imgvid.ImageUrl = "~/Admin/Files/" + fuvideo.PostedFile.FileName;
            ////}
        }
        protected void btnUpload2_Clickimg(object sender, EventArgs e)
        {

            HttpPostedFile postedFile = Request.Files[0];
            if (postedFile != null && postedFile != null)
            {
                string fileName = Path.GetFileName(filectr2.PostedFile.FileName);
                filectr2.PostedFile.SaveAs(Server.MapPath("~/Admin/Files/") + fileName);
                // lblfilename.Text = "temp/" + filectrl.PostedFile.FileName;

                // postedFile.SaveAs(Server.MapPath(str));
                // postedFile.SaveAs(str);
                //   txtfilename.Text = str;
                lblvidurl2.Text = "Files/" + filectr2.PostedFile.FileName;

                // ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Video is uploaded');", true);

                // else
                //  ScriptManager.RegisterStartupScript(this, this.GetType(), "myscript", "alert('Please upload your Video');", true);
            }

            ////if (fuvideo.HasFile)
            ////{
            ////    string fileName = Path.GetFileName(fuvideo.PostedFile.FileName);
            ////    fuvideo.PostedFile.SaveAs(Server.MapPath("~/Admin/Files/") + fileName);
            ////    lblvidurl1.Text = "~/Admin/Files/" + fuvideo.PostedFile.FileName;
            ////    imgvid.ImageUrl = "~/Admin/Files/" + fuvideo.PostedFile.FileName;
            ////}
        }

        protected void btnuploaddoc_Clickimg(object sender, EventArgs e)
        {
            if (fuGuidancedocument.HasFile)
            {
                string fileName = Path.GetFileName(fuGuidancedocument.PostedFile.FileName);
                fuGuidancedocument.PostedFile.SaveAs(Server.MapPath("~/Admin/Files/") + fileName);
                lbldocurl1.Text = "Files/" + fuGuidancedocument.PostedFile.FileName;
                lbldocurl.Text = "Catalogue Page Uploaded Successfully";
                //imgdoc.ImageUrl = "~/Admin/Files/" + fuGuidancedocument.PostedFile.FileName;
            }
        }
        protected void btnManualDoc_Clickimg(object sender, EventArgs e)
        {
            if (fuManualdocument.HasFile)
            {
                string fileName = Path.GetFileName(fuManualdocument.PostedFile.FileName);
                fuManualdocument.PostedFile.SaveAs(Server.MapPath("~/Admin/Files/") + fileName);
                lblManualDocURL1.Text = "Files/" + fuManualdocument.PostedFile.FileName;
                lblManualDocURL.Text = "Manual Document Uploaded Successfully";
                //imgdoc.ImageUrl = "~/Admin/Files/" + fuGuidancedocument.PostedFile.FileName;
            }
        }

        protected void btnFloorDoc_Clickimg(object sender, EventArgs e)
        {
            if (fuFloordocument.HasFile)
            {
                string fileName = Path.GetFileName(fuFloordocument.PostedFile.FileName);
                fuFloordocument.PostedFile.SaveAs(Server.MapPath("~/Admin/Files/") + fileName);
                lblFloorDocURL1.Text = "Files/" + fuFloordocument.PostedFile.FileName;
                lblFloorDocURL.Text = "Floor Preparation Plan Uploaded Successfully";
                //imgdoc.ImageUrl = "~/Admin/Files/" + fuGuidancedocument.PostedFile.FileName;
            }
        }
        protected void btnInstallManual_Clickimg(object sender, EventArgs e)
        {
            if (fuInstallManualdocument.HasFile)
            {
                string fileName = Path.GetFileName(fuInstallManualdocument.PostedFile.FileName);
                fuInstallManualdocument.PostedFile.SaveAs(Server.MapPath("~/Admin/Files/") + fileName);
                lblInstallManualURL1.Text = "Files/" + fuInstallManualdocument.PostedFile.FileName;
                lblInstallManualURL.Text = "Installation Manual Uploaded Successfully";
                //imgdoc.ImageUrl = "~/Admin/Files/" + fuGuidancedocument.PostedFile.FileName;
            }
        }
        protected void btnInstallChecklist_Clickimg(object sender, EventArgs e)
        {
            if (fuInstallChecklistdocument.HasFile)
            {
                string fileName = Path.GetFileName(fuInstallChecklistdocument.PostedFile.FileName);
                fuInstallChecklistdocument.PostedFile.SaveAs(Server.MapPath("~/Admin/Files/") + fileName);
                lblInstallChecklistURL1.Text = "Files/" + fuInstallChecklistdocument.PostedFile.FileName;
                lblInstallChecklistURL.Text = "Installation Checklist Uploaded Successfully";
                //imgdoc.ImageUrl = "~/Admin/Files/" + fuGuidancedocument.PostedFile.FileName;
            }
        }
        protected void btnServiceChecklist_Clickimg(object sender, EventArgs e)
        {
            if (fuServiceChecklistdocument.HasFile)
            {
                string fileName = Path.GetFileName(fuServiceChecklistdocument.PostedFile.FileName);
                fuServiceChecklistdocument.PostedFile.SaveAs(Server.MapPath("~/Admin/Files/") + fileName);
                lblServiceChecklistURL1.Text = "Files/" + fuServiceChecklistdocument.PostedFile.FileName;
                lblServiceChecklistURL.Text = "Service Checklist Uploaded Successfully";
                //imgdoc.ImageUrl = "~/Admin/Files/" + fuGuidancedocument.PostedFile.FileName;
            }
        }
        protected void btnWarranty_Clickimg(object sender, EventArgs e)
        {
            if (fuWarrantydocument.HasFile)
            {
                string fileName = Path.GetFileName(fuWarrantydocument.PostedFile.FileName);
                fuWarrantydocument.PostedFile.SaveAs(Server.MapPath("~/Admin/Files/") + fileName);
                lblWarrantyURL1.Text = "Files/" + fuWarrantydocument.PostedFile.FileName;
                lblWarrantyURL.Text = "Warranty Template Uploaded Successfully";
                //imgdoc.ImageUrl = "~/Admin/Files/" + fuGuidancedocument.PostedFile.FileName;
            }
        }














        protected void bttnpdf_Click(object sender, EventArgs e)
        {
            string FilePath = Server.MapPath("Files/JesusLift_ServiceApp_Quotation.pdf");
            WebClient User = new WebClient();
            Byte[] FileBuffer = User.DownloadData(FilePath);
            if (FileBuffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", FileBuffer.Length.ToString());
                Response.AddHeader("content-disposition", "inline;filename="+FilePath);
                Response.BinaryWrite(FileBuffer);
             
            }
        }  
    }

}
