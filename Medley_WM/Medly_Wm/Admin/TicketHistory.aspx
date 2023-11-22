<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TicketHistory.aspx.cs"
    Inherits="AdminAfforadbleApp.TicketHistory" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/Admin/Header.ascx" %>
<%@ Register TagPrefix="usc2" TagName="Header2" Src="~/Admin/HeaderTop.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <title>Ticket History</title>
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

        $(document).on("change", ".file_multi_video", function (evt) {
            debugger;
            var $source = $('#video_here');
            $source[0].src = URL.createObjectURL(this.files[0]);
            $source.parent()[0].load();
            var url = URL.createObjectURL(this.files[0]);

        });
    </script>
    <%--     <script type="text/javascript">
             $(document).on("change", ".file_multi_video", function (evt) {
                 debugger;
                 var $source = $('#video_here');
                 $source[0].src = URL.createObjectURL(this.files[0]);
                 $source.parent()[0].load();
                 var url = URL.createObjectURL(this.files[0]);

             });

           
        </script>--%>
     <%-- $(document).ready(function () {
      $("#link").click(function (e) {
          e.preventDefault();
          window.location.href = "File/randomfile.docx";
      });
});--%>

      
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
    <div class="clearfix">
    </div>
    <div class="page-container">
        <usc:Header ID="Header" runat="server" />
        <form id="form1" runat="server">
        <div>
            <div class="page-content-wrapper">
                <!-- BEGIN CONTENT BODY -->
                <div class="page-content">
                    <!-- BEGIN PAGE HEADER-->
                    <!-- BEGIN THEME PANEL -->
                    <!-- END THEME PANEL -->
                    <h1 class="page-title">
                        Ticket Details
                    </h1>
                    <div class="row">
                        <div class="col-md-6">
                           <div class="portlet light portlet-fit portlet-form">
                           <%-- <div class="portlet-title">                                
                                <div class="pull-right">
                                    <asp:Button ID="btnSubmit" runat="server" Visible="true" class="btn blue" Text="Add New"
                                        OnClick="btnadd_OnClick" />
                                </div>
                            </div>--%>
                            <div class="portlet-body">
                                <div class="portlet box green">
                                    <div class="portlet-title">
                                        <div class="caption font-dark">
                                            <i class="icon-settings font-dark"></i><span class="caption-subject bold uppercase">
                                                Ticket List</span>
                                        </div>
                                    </div>
                                    <div class="portlet-body">
                                        <div class="table-toolbar">
                                          <asp:GridView ID="GVTicketview" runat="server"
                                            CssClass="table table-striped table-bordered table-hover table-checkable order-column" OnRowCommand="GVTicketview_Rowcommand"   Width="100%" AutoGenerateColumns="false"
                                         
                                             HeaderStyle-CssClass="background: #0F3C5F; color: white;" DataKeyNames="Transticketid">
             
                                            
                                            <Columns>
                                             <asp:TemplateField HeaderText="Video" HeaderStyle-Width="20%">  
                        <ItemTemplate>  
                            <video width="80" height="80" controls controlsList="nodownload">  
                                <source id="video_here" src='<%#Eval("VideoPath")%>' type="video/mp4">  
                            </video>  
                        </ItemTemplate>  
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Document" >  
                                    <ItemTemplate>  
                                        <asp:LinkButton ID="lnkDownload1" runat="server" Text="Download" CausesValidation="False" CommandArgument='<%# Eval("DocumentPath") %>'  
                                            CommandName="Download" >  
                                           
                                          
                                            </asp:LinkButton>
                                    </ItemTemplate>  
                                </asp:TemplateField> 
                      <asp:TemplateField HeaderText="Image" >
                      <ItemTemplate>
                      <asp:Image  runat="server" ImageUrl='<%#Eval("ImagePath") %>' Width="80" Height="80" />
                      </ItemTemplate>
                      </asp:TemplateField>
                                                <asp:BoundField HeaderText="Update Date"  DataField="UpdateDate"  />
                                                
                                                  
                </Columns>
                                            </asp:GridView>
                                
                                </div>
                            </div>
                                        </div>
                                        <%--<table class="table table-striped table-bordered table-hover table-checkable order-column"
                                            id="sample_2">
                                            <thead>
                                                <tr>
                                                    <th style="display: none">
                                                        <label class="mt-checkbox mt-checkbox-single mt-checkbox-outline">
                                                            <input type="checkbox" class="group-checkable" data-set="#sample_2 .checkboxes" />
                                                            <span><asp:Label ID="lbldownload" runat="server" Visible="false"></asp:Label></span>
                                                        </label>
                                                    </th>
                                                    <th>
                                                        Document
                                                    </th>
                                                    <th>
                                                        Image
                                                    </th>
                                                    <th>
                                                        Update Date
                                                    </th>                                                   
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Label ID="lblTable" runat="server"></asp:Label>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>--%>
                                
                            </div>
                        </div>
                        </div>
                        <div class="col-md-6">
                            <!-- BEGIN EXAMPLE TABLE PORTLET-->
                            <div class="portlet light ">
                                <div class="portlet-title">
                                    <div class="caption font-dark">
                                        <span class="caption-subject bold uppercase">Ticket Details</span>
                                    </div>
                                </div>
                                <div class="portlet-body">
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <asp:HiddenField ID="hdTicketID" runat="server" />
                                            <div class="form-group form-md-line-input form-md-floating-label">
                                                <label>
                                                    Ticket No</label>
                                                <asp:TextBox CssClass="form-control" ID="txtTicketNo" runat="server" placeholder="Enter Ticket No"
                                                    ReadOnly="true"></asp:TextBox>
                                            </div>
                                            <div class="form-group form-md-line-input form-md-floating-label">
                                                <label>
                                                    Ticket Date&Time</label>
                                                <asp:TextBox CssClass="form-control" ID="txtTicketDate" runat="server" placeholder="Enter Ticket Date"
                                                    ReadOnly="true"></asp:TextBox>
                                            </div>
                                            <div class="form-group form-md-line-input form-md-floating-label">
                                                <label>
                                                    TeamLeader</label><br />
                                                <asp:TextBox CssClass="form-control" ID="txtTeamLeader" runat="server" placeholder="Enter TeamLeader"
                                                    ReadOnly="true"></asp:TextBox>
                                            </div>
                                            <div class="form-group form-md-line-input form-md-floating-label">
                                                <label>
                                                    Service Engineer Name</label><br />
                                                <asp:TextBox CssClass="form-control" ID="txtServiceengineername" runat="server" placeholder="Enter Service Engineer Name"
                                                    ReadOnly="true"></asp:TextBox>
                                            </div>
                                            <div class="form-group form-md-line-input form-md-floating-label">
                                                <label>
                                                    Product</label><br />
                                                <asp:TextBox CssClass="form-control" ID="txtProductName" runat="server" placeholder="Enter Product"
                                                    ReadOnly="true"></asp:TextBox>
                                            </div>
                                            <div class="form-group form-md-line-input form-md-floating-label">
                                                <label>
                                                    Customer</label><br />
                                                <asp:TextBox CssClass="form-control" ID="txtCustomerName" runat="server" placeholder="Enter Customer"
                                                    ReadOnly="true"></asp:TextBox>
                                            </div>
                                            <div class="form-group form-md-line-input form-md-floating-label">
                                                <label>
                                                    Warranty Year</label><br />
                                                <asp:TextBox CssClass="form-control" ID="txtWarrantyYear" runat="server" placeholder="Enter Warranty Year"
                                                    ReadOnly="true"></asp:TextBox>
                                            </div>
                                            <div class="form-group form-md-line-input form-md-floating-label">
                                                <label>
                                                    Warranty Month</label><br />
                                                <asp:TextBox CssClass="form-control" ID="txtWarrantyMonth" runat="server" placeholder="Enter Warranty Month"
                                                    ReadOnly="true"></asp:TextBox>
                                            </div>
                                            <div class="form-group form-md-line-input form-md-floating-label">
                                                <label>
                                                    Description</label><br />
                                                <asp:TextBox CssClass="form-control" ID="txtDescription" runat="server" placeholder="Enter Description"
                                                    ReadOnly="true"></asp:TextBox>
                                            </div>
                                            <div class="form-group boxed">
                                                Status
                                                <asp:DropDownList ID="ddlStatus" runat="server" class="form-control">
                                                    <asp:ListItem Text="Open" Value="Open"></asp:ListItem>
                                                    <asp:ListItem Text="Assigned" Value="Assigned"></asp:ListItem>
                                                    <asp:ListItem Text="Completed" Value="Completed"></asp:ListItem>
                                                    <asp:ListItem Text="NotSatisfied" Value="NotSatisfied"></asp:ListItem>
                                                    <asp:ListItem Text="ReAssigned" Value="ReAssigned"></asp:ListItem>
                                                    <asp:ListItem Text="Closed" Value="Closed"></asp:ListItem>
                                                </asp:DropDownList>
                                                <i class="clear-input">
                                                    <ion-icon name="close-circle"></ion-icon>
                                                </i>
                                            </div>
                                            <div>
                                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success" Text="Save" OnClick="btnSave_Click" />
                                                <asp:Button ID="btnReset" runat="server" CssClass="btn btn-danger" Text="Back" OnClick="btnReset_Click" />
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
