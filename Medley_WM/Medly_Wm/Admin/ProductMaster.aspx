<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductMaster.aspx.cs" Inherits="AdminAfforadbleApp.ProductMaster" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/Admin/Header.ascx" %>
<%@ Register TagPrefix="usc2" TagName="Header2" Src="~/Admin/HeaderTop.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <title>Product Master</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta content="width=device-width, initial-scale=1" name="viewport" />
    <meta content="Preview page of Metronic Admin Theme #2 for statistics, charts, recent events and reports"
        name="description" />
    <meta content="" name="author" />
    <!-- BEGIN GLOBAL MANDATORY STYLES -->
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all"
        rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../assets/global/plugins/simple-line-icons/simple-line-icons.min.css"
        rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css"
        rel="stylesheet" type="text/css" />
    <!-- END GLOBAL MANDATORY STYLES -->
    <!-- BEGIN PAGE LEVEL PLUGINS -->
    <link href="../assets/global/plugins/datatables/datatables.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.css"
        rel="stylesheet" type="text/css" />
    <!-- END PAGE LEVEL PLUGINS -->
    <!-- BEGIN THEME GLOBAL STYLES -->
    <link href="../assets/global/css/components-md.min.css" rel="stylesheet" id="style_components"
        type="text/css" />
    <link href="../assets/global/css/plugins-md.min.css" rel="stylesheet" type="text/css" />
    <!-- END THEME GLOBAL STYLES -->
    <!-- BEGIN THEME LAYOUT STYLES -->
    <link href="../assets/layouts/layout2/css/layout.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/layouts/layout2/css/themes/blue.min.css" rel="stylesheet" type="text/css"
        id="style_color" />
    <link href="../assets/layouts/layout2/css/custom.min.css" rel="stylesheet" type="text/css" />
    <script src="https://cdn.amcharts.com/lib/4/core.js"></script>
    <script src="https://cdn.amcharts.com/lib/4/charts.js"></script>
    <script src="https://cdn.amcharts.com/lib/4/themes/animated.js"></script>
    <!-- END THEME LAYOUT STYLES -->
    <link rel="shortcut icon" href="favicon.ico" />
    <script type="text/javascript">
        function goBack() {
            window.history.back();
        }
    </script>
         <script type="text/javascript">


             function NOTIFICA(msg, title) {

                 toastr.options = {
                     "closeButton": false,
                     "debug": true,
                     "newestOnTop": false,
                     "progressBar": false,
                     "positionClass": "toast-bottom-right",
                     "preventDuplicates": false,
                     "showDuration": "300",
                     "hideDuration": "1000",
                     "timeOut": "12000",
                     "extendedTimeOut": "1000",
                     "showEasing": "swing",
                     "hideEasing": "linear",
                     "showMethod": "fadeIn",
                     "hideMethod": "fadeOut"
                 }
                 // toastr['success'](msg, title);
                 var d = Date();
                 toastr.success(msg, title);
                 return false;
             }

             function ReportPrint() {

                 var gridData = document.getElementById('testid');

                 var windowUrl = 'about:blank';
                 //set print document name for gridview
                 var uniqueName = new Date();
                 var windowName = 'Print_' + uniqueName.getTime();

                 var prtWindow = window.open(windowUrl, windowName,
           'left=100,top=100,right=100,bottom=100,width=700,height=500');
                 prtWindow.document.write('<html><head></head>');
                 prtWindow.document.write('<body style="background:none !important">');

                 prtWindow.document.write(gridData.outerHTML);
                 prtWindow.document.write('</body></html>');
                 prtWindow.document.close();
                 prtWindow.focus();
                 prtWindow.print();
                 prtWindow.close();

             }

             //        $(function () {
             //            $('.upload-video-file').on('change', function () {
             //                if (isVideo($(this).val())) {
             //                    $('.video-preview').attr('src', URL.createObjectURL(this.files[0]));
             //                    $('.video-prev').show();
             //                }
             //                else {
             //                    $('.upload-video-file').val('');
             //                    $('.video-prev').hide();
             //                    alert("Only video files are allowed to upload.")
             //                }
             //            });
             //        });

             $(document).on("change", ".file_multi_video", function (evt) {
                 debugger;
                 var $source = $('#video_here');
                 $source[0].src = URL.createObjectURL(this.files[0]);
                 $source.parent()[0].load();
                 var url = URL.createObjectURL(this.files[0]);

             });

           
    </script>
        <script type="text/javascript">
            $(document).ready(function () {
                $("#dvProduct").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
            });  
</script>  
 
    <style>
        .button
        {
            background-color: #217EBD; /* Green */
            border: none;
            color: white;
            padding: 5px 12px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 17px;
            font-weight: bolder;
            margin: 4px 2px;
            cursor: pointer;
        }
    </style>
</head>
<body class="page-header-fixed page-sidebar-closed-hide-logo page-container-bg-solid page-md">
    <usc2:Header2 ID="Header2" runat="server" />
    <div class="clearfix"></div>
        <div class="page-container">
        <usc:Header ID="Header" runat="server" />
    <form id="form1" runat="server">

     <asp:ScriptManager ID="ScriptManager" runat="server" EnablePageMethods="true" ScriptMode="Release">
    </asp:ScriptManager>
    <asp:HiddenField runat="server" ID="Cookies" EnableViewState="true" />
    <asp:Label ID="lblCookie" Visible="false" runat="server"></asp:Label>
    <div>
          <div class="page-content-wrapper">
            <!-- BEGIN CONTENT BODY -->
            <div class="page-content">
                <!-- BEGIN PAGE HEADER-->
                <!-- BEGIN THEME PANEL -->
                <!-- END THEME PANEL -->
                <h1 class="page-title">
                    Product Master 
                </h1>
                <div class="row">
                        <div class="col-md-12">
                            <div class="tabbable-line boxless tabbable-reversed">
                                <ul class="nav nav-tabs">
                                    <li class="active">
                                        <a href="#tab_0" data-toggle="tab"> Main Section</a>
                                    </li>
                                    <li>
                                        <a href="#tab_1" data-toggle="tab"> Documents Upload </a>
                                    </li>
                                    <li>
                                        <a href="#tab_2" data-toggle="tab"> Video Upload </a>
                                    </li>
                                   
                                </ul>
                                <div class="tab-content">
                                    <div class="tab-pane active" id="tab_0">
                                        <div class="portlet box green">
                                            <div class="portlet-title">
                                                <div class="caption">
                                                    <i class="fa fa-gift"></i>Main Section </div>
                                          
                                            </div>
                                            <div class="portlet-body form">
                                                <!-- BEGIN FORM-->
                                                <form action="#" class="form-horizontal">
                                                    <div class="form-body">
                                                      <div class="portlet-body">

                                <div class="row">
                               <div class="col-lg-12">
                                    <div class="row">
                                                            <div class="col-md-6">
                    <div class="form-group form-md-line-input form-md-floating-label  has-success">
                        <%--<label>
                            Category Name</label>   --%>
                       <label>Select Category</label>
                       <asp:DropDownList ID="ddlCategory" AutoPostBack="true" runat="server" CssClass="form-control" ></asp:DropDownList>
                    </div>
                      <div class="form-group form-md-line-input has-success">
                        <label>Product Name</label>
                       <asp:TextBox CssClass="form-control" ID="txtProductname" runat="server" placeholder="Enter Product Name"></asp:TextBox>

                    </div>
                          <div class="form-group form-md-line-input has-success">
                   <asp:Label ID="lblid" runat="server" Visible="false"></asp:Label>
                     <label>Product Model</label>
                       <asp:TextBox CssClass="form-control" ID="txtProductmodelno" runat="server" placeholder="Enter Product Model No"></asp:TextBox>

                    </div>
                       <div class="form-group form-md-line-input has-success">
                   <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
                     <label>Auto Schedule for Service</label>
                       <asp:DropDownList ID="ddlAutoTime" runat="server" CssClass="form-control">
                       <asp:ListItem Text="3 Months" Value="3"></asp:ListItem>
                       <asp:ListItem Text="6 Months" Value="6"></asp:ListItem>
                       <asp:ListItem Text="9 Months" Value="9"></asp:ListItem>
                       <asp:ListItem Text="12 Months" Value="12"></asp:ListItem>
                       </asp:DropDownList>

                    </div>
              
                       </div>
              
                                                            <div class="col-md-6">
    <div class="form-group form-md-line-input has-success">
             
                     <label>Brand name</label>
                       <asp:TextBox CssClass="form-control" ID="txtBranname" runat="server" placeholder="Enter Brand Name"></asp:TextBox>

                    </div>
                       <div class="form-group form-md-line-input has-success">
             
                     <label>Supplier name</label>
                       <asp:TextBox CssClass="form-control" ID="txtSupplierName" runat="server" placeholder="Enter Supplier Name"></asp:TextBox>

                    </div>
                           <div  class="form-group form-md-line-input has-success">
                     <label>Warranty</label>
                     <div class="row">
                      <div class="col-md-6">
                       <asp:TextBox CssClass="form-control" ID="txtWarrantyyear" MaxLength="2" runat="server" placeholder="Enter Year"></asp:TextBox>
                         </div>
                         <div class="col-md-6">
                          <asp:TextBox CssClass="form-control" ID="txtWarrantymonth" MaxLength="2" runat="server" placeholder="Enter Month"></asp:TextBox>
                          </div>
                          </div>
                    </div>

                     <div class="form-group boxed has-success">
                            <div class="input-wrapper  has-success">
                            <h3>   Upload Product Image</h3>
                                <asp:UpdatePanel ID="UpdatePanel" runat="server">
                                    <ContentTemplate>                                        
                                        <asp:FileUpload ID="fuProductimage" runat="server" /><br />
                                        <asp:Button ID="btnUpload123" ValidationGroup="fileimage" runat="server" Text="Upload" CssClass="btn btn-primary"
                                            OnClick="btnUpload_Clickimg" Width="100px" /><asp:Image ID="img_Photo" runat="server"
                                                Width="70px" BorderColor="1" />
                                             


                                                 <asp:Label ID="lblimgurl" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lblimgurl1" runat="server" Visible="false"></asp:Label>
                                        <%--<asp:Label ID="lblFile_Path" runat="server" Visible="false"></asp:Label>--%>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="btnUpload123" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                    </div>
                      <div class="row">
                                                            <div class="col-md-4">
                                                                
                  
                     

                               <div class="form-group boxed">

                          
                                <div  class="form-group form-md-line-input has-success">
                     <h3> Catalogue Page</h3>
                           
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>                                        
                                        <asp:FileUpload ID="fuGuidancedocument" runat="server" /><br />
                                        <asp:Button ID="btnuploaddoc" runat="server" Text="Upload" CssClass="btn btn-primary"
                                            OnClick="btnuploaddoc_Clickimg" Width="100px" /><a id="Catalogue" runat="server" class="btn btn-danger"> PREVIEW </a><br />
                                                 <asp:Label ID="lbldocurl" runat="server" Visible="true" CssClass="label-success"></asp:Label>
                        <asp:Label ID="lbldocurl1" runat="server" Visible="false"></asp:Label> 
                                        <%--<asp:Label ID="lblFile_Path" runat="server" Visible="false"></asp:Label>--%>
                                        
                                    </ContentTemplate>
                                    <Triggers>

                                        <asp:PostBackTrigger ControlID="btnuploaddoc" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>  
                        </div>
                        </div>
                                              <div class="col-md-4">
                                              <div class="form-group boxed">

                          
                                <div  class="form-group form-md-line-input has-success">
                     <h3> Manual Document</h3>
                           
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>                                        
                                        <asp:FileUpload ID="fuManualdocument" runat="server" /><br />
                                        <asp:Button ID="btnManualDoc" runat="server" Text="Upload" CssClass="btn btn-primary"
                                            OnClick="btnManualDoc_Clickimg" Width="100px" /><a id="manual" runat="server" class="btn btn-danger"> PREVIEW </a><br />
                                                 <asp:Label CssClass="label-success" ID="lblManualDocURL" runat="server" Visible="true"></asp:Label>
                        <asp:Label ID="lblManualDocURL1" runat="server" Visible="false"></asp:Label>
                                        <asp:Button ID="bttnpdf" runat="server" Text="Click for Preview PDF" Font-Bold="True" OnClick="bttnpdf_Click" Visible="false" />  
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="btnManualDoc" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>  
                        </div>
                       
                        </div>
                                              <div class="col-md-4">
                    <div class="form-group boxed">

                          
                                <div  class="form-group form-md-line-input has-success">
                     <h3> Floor Preparation Plan</h3>
                           
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>                                        
                                        <asp:FileUpload ID="fuFloordocument" runat="server" /><br />
                                        <asp:Button ID="btnFloorDoc" runat="server" Text="Upload" CssClass="btn btn-primary"
                                            OnClick="btnFloorDoc_Clickimg" Width="100px" /><a id="floor" runat="server" class="btn btn-danger"> PREVIEW </a><br />
                                                 <asp:Label ID="lblFloorDocURL" runat="server" Visible="true" CssClass="label-success"></asp:Label>
                        <asp:Label ID="lblFloorDocURL1" runat="server" Visible="false"></asp:Label>
                                        <%--<asp:Label ID="lblFile_Path" runat="server" Visible="false"></asp:Label>--%>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="btnFloorDoc" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>  
                        </div>
                                                            </div>
                                                           
                                                        </div>
                                                <div class="row">
                                                            <div class="col-md-4">
                                                                
                  
                     

                               <div class="form-group boxed">

                          
                                <div  class="form-group form-md-line-input has-success">
                     <h3>Installation Manual</h3>
                           
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>                                        
                                        <asp:FileUpload ID="fuInstallManualdocument" runat="server" /><br />
                                        <asp:Button ID="btnInstallManualDoc" runat="server" Text="Upload" CssClass="btn btn-primary"
                                            OnClick="btnInstallManual_Clickimg" Width="100px" /><a id="instmanual" runat="server" class="btn btn-danger"> PREVIEW </a><br />
                                                 <asp:Label ID="lblInstallManualURL" runat="server" Visible="true" CssClass="label-success"></asp:Label>
                        <asp:Label ID="lblInstallManualURL1" runat="server" Visible="false"></asp:Label>
                                        <%--<asp:Label ID="lblFile_Path" runat="server" Visible="false"></asp:Label>--%>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="btnInstallManualDoc" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>  
                        </div>
                        </div>
                                              <div class="col-md-4">
                        <div class="form-group boxed">

                          
                                <div  class="form-group form-md-line-input has-success">
                     <h3> Installation checklist</h3>
                           
                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                    <ContentTemplate>                                        
                                        <asp:FileUpload ID="fuInstallChecklistdocument" runat="server" /><br />
                                        <asp:Button ID="btnInstallChecklistDoc" runat="server" Text="Upload" CssClass="btn btn-primary"
                                            OnClick="btnInstallChecklist_Clickimg" Width="100px" /><a id="instchecklist" runat="server" class="btn btn-danger"> PREVIEW </a><br />
                                                 <asp:Label ID="lblInstallChecklistURL" runat="server" Visible="true" CssClass="label-success"></asp:Label>
                        <asp:Label ID="lblInstallChecklistURL1" runat="server" Visible="false"></asp:Label>
                                        <%--<asp:Label ID="lblFile_Path" runat="server" Visible="false"></asp:Label>--%>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="btnInstallChecklistDoc" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>  
                        </div>
                        </div>
                                              <div class="col-md-4">
                    <div class="form-group boxed">

                          
                                <div  class="form-group form-md-line-input has-success">
                     <h3>Service checklist</h3>
                           
                                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                    <ContentTemplate>                                        
                                        <asp:FileUpload ID="fuServiceChecklistdocument" runat="server" /><br />
                                        <asp:Button ID="btnServiceChecklistDoc" runat="server" Text="Upload" CssClass="btn btn-primary"
                                            OnClick="btnServiceChecklist_Clickimg" Width="100px" /><a id="servchecklist" runat="server" class="btn btn-danger"> PREVIEW </a><br />
                                                 <asp:Label ID="lblServiceChecklistURL" runat="server" Visible="true" CssClass="label-success"></asp:Label>
                        <asp:Label ID="lblServiceChecklistURL1" runat="server" Visible="false"></asp:Label>
                                        <%--<asp:Label ID="lblFile_Path" runat="server" Visible="false"></asp:Label>--%>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="btnServiceChecklistDoc" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>  
                        </div>
                                                            </div>
                                                           
                                                        </div>

                                                        <div class="row">
                                                            <div class="col-md-4">
                                                                
                  
                     

                               <div class="form-group boxed">

                          
                                <div  class="form-group form-md-line-input has-success">
                     <h3>Warranty template</h3>
                           
                                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                    <ContentTemplate>                                        
                                        <asp:FileUpload ID="fuWarrantydocument" runat="server" /><br />
                                        <asp:Button ID="btnWarrantyDoc" runat="server" Text="Upload" CssClass="btn btn-primary"
                                            OnClick="btnWarranty_Clickimg" Width="100px" /><a id="warrantytemp" runat="server" class="btn btn-danger"> PREVIEW </a><br />
                                                 <asp:Label ID="lblWarrantyURL" runat="server" Visible="true" CssClass="label-success"></asp:Label>
                        <asp:Label ID="lblWarrantyURL1" runat="server" Visible="false"></asp:Label>
                                        <%--<asp:Label ID="lblFile_Path" runat="server" Visible="false"></asp:Label>--%>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="btnWarrantyDoc" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>  
                        </div>
                        </div>
                                   <div class="col-md-4">              
                            <div class="form-group boxed">
                        <video width="200" controls runat="server" id="vdeotag">

  <source src="" id="video_here">
    Your browser does not support HTML5 video.
</video>
                                               <%-- <asp:TextBox ID="txtfilename" runat="server" Enabled="false"></asp:TextBox>--%>
                                                <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Always" runat="server">
                                                    <ContentTemplate>
                                                        <input type="file" name="file[]" class="file_multi_video" accept="video/*" runat="server"
                                                            id="filectrl" />
                                                        <asp:Button ID="btnUpload1" Text="Upload" CssClass="btn btn-primary" runat="server" Width="105px" OnClick="btnUpload1_Clickimg" />

                                                          <asp:Label ID="lblvidurl1" runat="server" Visible="false"></asp:Label>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:PostBackTrigger ControlID="btnUpload1" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </div>    
                                            </div>
                                               <div class="col-md-4">
                                               <div class="form-group boxed">
                        <video width="200" controls runat="server" id="vdeotag1">

  <source src="" id="video_here">
    Your browser does not support HTML5 video.
</video>
                                               <%-- <asp:TextBox ID="txtfilename" runat="server" Enabled="false"></asp:TextBox>--%>
                                                <asp:UpdatePanel ID="UpdatePanel10" UpdateMode="Always" runat="server">
                                                    <ContentTemplate>
                                                        <input type="file" name="file[]" class="file_multi_video" accept="video/*" runat="server"
                                                            id="filectr2" />
                                                        <asp:Button ID="btnUpload2" Text="Upload" CssClass="btn btn-primary" runat="server" Width="105px" OnClick="btnUpload2_Clickimg" />

                                                          <asp:Label ID="lblvidurl2" runat="server" Visible="false"></asp:Label>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:PostBackTrigger ControlID="btnUpload2" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </div>
                                               </div>              
                                                           
                                                        </div>
                    <div>
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success" Text="Save" 
                            onclick="btnSave_Click"/>
                    <%-- <asp:Button ID="btnReset" runat="server" OnClick="btnReset_Click" CssClass="btn btn-danger" Text="Reset"/>--%>
                     
                      <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" CssClass="btn btn-danger" Text="Back"/>
                     
                    </div>
                    </div>
                    </div>
                    </div>
                    
                                                    </div>
                                                  
                                                </form>
                                                <!-- END FORM-->
                                            </div>
                                        </div>
                                
                                    </div>
                                    <div class="tab-pane" id="tab_1">
                                        <div class="portlet box blue">
                                            <div class="portlet-title">
                                                <div class="caption">
                                                    <i class="fa fa-gift"></i> Documents Upload  </div>
                                              
                                            </div>
                                            <div class="portlet-body form">
                                                <!-- BEGIN FORM-->
                                                <form action="#" class="horizontal-form">
                                                    <div class="form-body">
                                                       <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                    <ContentTemplate>  
                                                      

                                                        </ContentTemplate>
                                                        </asp:UpdatePanel>



                                                    </div>
                                                    <div class="form-actions right">
                                                        <button type="button" class="btn default">Cancel</button>
                                                        <button type="submit" class="btn blue">
                                                            <i class="fa fa-check"></i> Save</button>
                                                    </div>
                                                </form>
                                                <!-- END FORM-->
                                            </div>
                                        </div>
                                        
                                    </div>
                                    <div class="tab-pane" id="tab_2">
                                        <div class="portlet box green">
                                            <div class="portlet-title">
                                                <div class="caption">
                                                    <i class="fa fa-gift"></i>Video Upload </div>
                                                
                                            </div>
                                            <div class="portlet-body form">
                                                <!-- BEGIN FORM-->
                                                <form action="#" class="form-horizontal">
                                                    <div class="form-body">
                                                        <h3 class="form-section">Video Upload</h3>
                                                        <div class="row">
                                                            <div class="col-md-6">
                                                                <div class="form-group">
                                                              
                                                                </div>
                                                            </div>
                                                            <!--/span-->
                                                            
                                                            <!--/span-->
                                                        </div>
                                             
                                                    </div>
                                                    <div class="form-actions">
                                                        <div class="row">
                                                            <div class="col-md-6">
                                                                <div class="row">
                                                                    <div class="col-md-offset-3 col-md-9">
                                                                        <button type="submit" class="btn green">Submit</button>
                                                                        <button type="button" class="btn default">Cancel</button>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6"> </div>
                                                        </div>
                                                    </div>
                                                </form>
                                                <!-- END FORM-->
                                            </div>
                                        </div>
                                     
                                    </div>
                                   
                                </div>
                            </div>
                        </div>
                    </div>
    
                </div>
                </div>
               
   </div>
    </form>
    </div>
     <!-- BEGIN CORE PLUGINS -->
            <script src="../assets/global/plugins/jquery.min.js" type="text/javascript"></script>
            <script src="../assets/global/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
            <script src="../assets/global/plugins/js.cookie.min.js" type="text/javascript"></script>
            <script src="../assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js" type="text/javascript"></script>
            <script src="../assets/global/plugins/jquery.blockui.min.js" type="text/javascript"></script>
            <script src="../assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js" type="text/javascript"></script>
            <!-- END CORE PLUGINS -->
            <!-- BEGIN PAGE LEVEL PLUGINS -->
            <!-- END PAGE LEVEL PLUGINS -->
            <!-- BEGIN THEME GLOBAL SCRIPTS -->
            <script src="../assets/global/scripts/app.min.js" type="text/javascript"></script>
            <!-- END THEME GLOBAL SCRIPTS -->
            <!-- BEGIN PAGE LEVEL SCRIPTS -->
            <script src="../assets/pages/scripts/form-samples.min.js" type="text/javascript"></script>
            <!-- END PAGE LEVEL SCRIPTS -->
            <!-- BEGIN THEME LAYOUT SCRIPTS -->
            <script src="../assets/layouts/layout2/scripts/layout.min.js" type="text/javascript"></script>
            <script src="../assets/layouts/layout2/scripts/demo.min.js" type="text/javascript"></script>
            <script src="../assets/layouts/global/scripts/quick-sidebar.min.js" type="text/javascript"></script>
            <script src="../assets/layouts/global/scripts/quick-nav.min.js" type="text/javascript"></script>
            <!-- END THEME LAYOUT SCRIPTS -->
            <script>
                $(document).ready(function () {
                    $('#clickmewow').click(function () {
                        $('#radio1003').attr('checked', 'checked');
                    });
                })
            </script>
</body>
</html>
