<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CategoryMaster.aspx.cs" Inherits="AdminAfforadbleApp.CategoryMaster" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/Admin/Header.ascx" %>
<%@ Register TagPrefix="usc2" TagName="Header2" Src="~/Admin/HeaderTop.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <title>Category Master</title>
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
        $(document).ready(function () {
            $('#<%=gvcategory.ClientID %>').Scrollable({
                ScrollHeight: 300,
                IsInUpdatePanel: true
            });
        });
    </script>
    <%--<script type="text/javascript">
        $(document).on("change", ".file_multi_video", function (evt) {
            debugger;
            var $source = $('#video_here');
            $source[0].src = URL.createObjectURL(this.files[0]);
            $source.parent()[0].load();
            var url = URL.createObjectURL(this.files[0]);

        });

           
    </script>--%>
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
                    Category Master 
                </h1>
    <div class="row">
                    <div class="col-md-8">
                        <!-- BEGIN EXAMPLE TABLE PORTLET-->
                        <div class="portlet light">
                            <div class="portlet-title">
                                <div class="caption font-dark">
                                    <span class="caption-subject bold uppercase">
                                        Category List </span><span class="label label-sm label-info"></span>
                                </div>
                            </div>
                            <div class="portlet-body">
                                <div class="table-toolbar">
                                
                                 <%--  OnRowEditing="gvcategoty_RowEditing"--%>
                                 <div style="overflow:scroll; height:500px;">

                                <asp:GridView ID="gvcategory" runat="server"
                                            CssClass="table table-striped table-bordered table-hover table-checkable order-column"  OnRowCommand="gvcategory_Rowcommand"   OnSelectedIndexChanged="gvcategory_SelectedIndexChanged"   Width="100%" AutoGenerateColumns="false"
                                         
                                             HeaderStyle-CssClass="background: #0F3C5F; color: white;" DataKeyNames="CategoryId"  >
             
                                            
                                            <Columns>
                                                <asp:BoundField HeaderText="categoryid"  DataField="categoryid" Visible="false" />
                                                
                                                    <asp:BoundField  HeaderText="Category Name" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="40%" ItemStyle-HorizontalAlign="Left" ItemStyle-Width ="40%"     DataField="Categoryname" />
                                                    

                                                    <asp:TemplateField HeaderText="Image" >
                      <ItemTemplate>
                      <asp:Image ID="Image1"  runat="server" ImageUrl='<%#Eval("CategoryImagePath") %>' Width="80" Height="80" />
                      </ItemTemplate>
                      </asp:TemplateField>
                                                   
                                                    <asp:BoundField HeaderText="Active " DataField="IsActive" Visible="false" />
                                                   
                                           
               <asp:TemplateField HeaderText="Edit">
    <ItemTemplate><asp:LinkButton ID="lnkedit" runat="server" CommandArgument='<%#Eval("Categoryid") %>'  CommandName="Select" Text="Edit"></asp:LinkButton></ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Delete">
    <ItemTemplate><asp:LinkButton ID="lnkdelete" runat="server" CommandArgument='<%#Eval("Categoryid") %>' CommandName="Del" Text="Delete"></asp:LinkButton></ItemTemplate>
    </asp:TemplateField> </Columns>
                                            </asp:GridView>
                                          
                                </div>
                                </div>
                            </div>
                        </div>
                        <!-- END EXAMPLE TABLE PORTLET-->
                    </div>
                    
                    <div class="col-md-4">
                        <!-- BEGIN EXAMPLE TABLE PORTLET-->
                        <div class="portlet light ">
                            <div class="portlet-title">
                                <div class="caption font-dark">
                                   <span class="caption-subject bold uppercase">
                                        Category Master </span><span class="label label-sm label-info"></span>
                                </div>
                            </div>
                            <div class="portlet-body">

                                <div class="row">
                               <div class="col-lg-12">
                                 
                    <div  class="form-group form-md-line-input has-success">
                        <%--<label>
                            Category Name</label>   --%>
                        <asp:TextBox CssClass="form-control" ID="txtcategoryname" runat="server" placeholder="Enter Category Name"></asp:TextBox>
                        <asp:Label ID="lblid" runat="server" Visible="false"></asp:Label>
                    </div>
                                      <%--  <div class="form-group form-md-line-input form-md-floating-label">
                        <label>
                           Upload Category Image</label>
                       <asp:FileUpload ID="fucategoryimage"  runat="server" /><asp:Label ID="lblfilename" runat="server" Visible="false"></asp:Label>
                       <asp:Label ID="lblfilename1" runat="server" Visible="false"></asp:Label>
                    </div>--%>
                    
                      <div class="form-group boxed">
                            <div class="input-wrapper">
                              Upload Category Image
                                <asp:UpdatePanel ID="UpdatePanel" runat="server">
                                    <ContentTemplate>                                        
                                        <asp:FileUpload ID="fucategoryimage" runat="server" /><br />
                                        <asp:Button ID="btnuploadimg" runat="server" Text="Upload" CssClass="btn btn-primary"
                                            OnClick="btnuploadimg_Clickimg" Width="100px" /> <asp:Image ID="imgcategory" runat="server"
                                                Width="70px" BorderColor="1" />
                                                <asp:Label ID="lblfilename1" runat="server" Visible="false"></asp:Label>
                                        <%--<asp:Label ID="lblFile_Path" runat="server" Visible="false"></asp:Label>--%>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="btnuploadimg" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    <div>
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success" Text="Save" 
                            onclick="btnSave_Click"/>
                     <asp:Button ID="btnReset" runat="server" CssClass="btn btn-danger" Text="Reset" 
                            onclick="btnReset_Click"/>
                    </div>
                    </div>
                    </div>
                     
                   
                               
                            </div>
                        </div>
                        <!-- END EXAMPLE TABLE PORTLET-->
                    </div>
                </div>
                </div>
                </div>
    </div>
    </form>
    </div>
</body>
</html>
