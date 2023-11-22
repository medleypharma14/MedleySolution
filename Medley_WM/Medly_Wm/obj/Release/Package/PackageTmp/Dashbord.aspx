<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashbord.aspx.cs" Inherits="Medly_Wm.Dashbord" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/Header.ascx" %>
<%@ Register TagPrefix="usc1" TagName="Sidebar" Src="~/Sidebar.ascx" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Dashboard</title>
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
    <link href="../assets/global/plugins/bootstrap-daterangepicker/daterangepicker.min.css"
        rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/morris/morris.css" rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/fullcalendar/fullcalendar.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../assets/global/plugins/jqvmap/jqvmap/jqvmap.css" rel="stylesheet" type="text/css" />
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
    <!-- END THEME LAYOUT STYLES -->
    <link rel="shortcut icon" href="favicon.ico" />
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta content="width=device-width, initial-scale=1" name="viewport" />
    <meta content="Preview page of Metronic Admin Theme #2 for bootstrap inputs, input groups, custom checkboxes and radio controls and more" name="description" />
    <meta content="" name="author" />
    <!-- BEGIN GLOBAL MANDATORY STYLES -->
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all" rel="stylesheet" type="text/css" />
    <link href="assets/global/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/global/plugins/simple-line-icons/simple-line-icons.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/global/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css" rel="stylesheet" type="text/css" />
    <!-- END GLOBAL MANDATORY STYLES -->
    <!-- BEGIN THEME GLOBAL STYLES -->
    <link href="assets/global/css/components-md.min.css" rel="stylesheet" id="style_components" type="text/css" />
    <link href="assets/global/css/plugins-md.min.css" rel="stylesheet" type="text/css" />
    <!-- END THEME GLOBAL STYLES -->
    <!-- BEGIN THEME LAYOUT STYLES -->
    <link href="assets/layouts/layout2/css/layout.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/layouts/layout2/css/themes/blue.min.css" rel="stylesheet" type="text/css" id="style_color" />
    <link href="assets/layouts/layout2/css/custom.min.css" rel="stylesheet" type="text/css" />
    <!-- END THEME LAYOUT STYLES -->
    <link rel="shortcut icon" href="favicon.ico" />

    <style>
        /*.col-lg-12 {
                padding: 10px;
            }*/
    </style>

</head>
<body class="page-header-fixed page-sidebar-closed-hide-logo page-container-bg-solid page-md">
    <usc1:Sidebar ID="h1" runat="server" />
    <div class="page-container">
        <usc:Header ID="Header" runat="server" />
        <div class="page-content-wrapper">
            <!-- BEGIN CONTENT BODY -->
            <div class="page-content">
                <form id="form2" runat="server">
                    <div class="row">
                    <div class="col-lg-12">
                        <div class="portlet light" style="height:600px">
                               
                            <div class="portlet light row ">
                                <div class="form-body">
                                    <div class="first" style="background-color: lightblue;">
                                        
                                         <div class="col-md-4">
                            <!-- BEGIN WIDGET THUMB -->
                            <div class="widget-thumb widget-bg-color-white text-uppercase margin-bottom-20 ">
                                <h4 class="widget-thumb-heading">Supplier</h4>
                                <div class="widget-thumb-wrap">
                                    <i class="widget-thumb-icon bg-purple icon-screen-desktop"></i>
                                    <div class="widget-thumb-body">
                                        <span class="widget-thumb-subtitle">Total Suppliers: <asp:Label Text="text" CssClass="align-content-lg-end" ID="lblTotalsuppliers" runat="server" /></span>
                                        <span class="widget-thumb-subtitle"> Qualified Suppliers:  <asp:Label Text="text" ID="lblQualifiedsuppliers" runat="server" /></span>
                                        <span class="widget-thumb-subtitle">Expired Suppliers:  <asp:Label Text="text" ID="lblNqsuppliers" runat="server" /></span>
                                        <span class="widget-thumb-subtitle">Not Active Suppliers:  <asp:Label Text="text" ID="lblNotacivesuppliers" runat="server" /></span>
                                    </div>
                                </div>
                            </div>
                            <!-- END WIDGET THUMB -->
                        </div>

                                            <div class="col-md-4"> 
                            <!-- BEGIN WIDGET THUMB -->
                            <div class="widget-thumb widget-bg-color-white text-uppercase margin-bottom-20 ">
                                <h4 class="widget-thumb-heading">Warehouse</h4>
                                <div class="widget-thumb-wrap">
                                    <i class="widget-thumb-icon bg-red icon-layers"></i>
                                    <div class="widget-thumb-body">
                                        <span class="widget-thumb-subtitle"> Total Units:   <asp:Label Text="text" ID="lblTotalunits" runat="server" /></span>
                                        <span class="widget-thumb-subtitle">  Occupied Units:    <asp:Label Text="text" ID="lblOccupiedunits" runat="server" /></span>
                                        <span class="widget-thumb-subtitle">  Available Units: <asp:Label Text="text" ID="lblAvailableuniuts" runat="server" /></span>
                                    </div>
                                </div>
                            </div>
                            <!-- END WIDGET THUMB -->
                        </div>
                                                <div class="col-md-4">
                                           
                                           
                            <!-- BEGIN WIDGET THUMB -->
                            <div class="widget-thumb widget-bg-color-white text-uppercase margin-bottom-20 ">
                                <h4 class="widget-thumb-heading">Stocks</h4>
                                <div class="widget-thumb-wrap">
                                    <i class="widget-thumb-icon bg-green icon-bulb"></i>
                                    <div class="widget-thumb-body">
                                        <span class="widget-thumb-subtitle">Total Quantity:   <asp:Label Text="text" ID="lblTotalqty" runat="server" /> </span>
                                        <span class="widget-thumb-subtitle">Sample Quantiy:    <asp:Label Text="text" ID="lblSampleqty" runat="server" /> </span>
                                       <span class="widget-thumb-subtitle">Quarantine Batch:   <asp:Label Text="text" ID="lblquarantinebatch" runat="server" /> </span>
                                        <span class="widget-thumb-subtitle">Released Batch:   <asp:Label Text="text" ID="lblReleasedbatch" runat="server" /> </span>
                                         <span class="widget-thumb-subtitle">Rejected Batch:   <asp:Label Text="text" ID="lblRejectedbatch" runat="server" /> </span>
                                    </div>
                                </div>
                            </div>
                            <!-- END WIDGET THUMB -->
                                               
                        </div> 
                                        
                                        
                                    </div>

                                    <div class="row">
                        <div class="col-lg-4 col-xs-12 col-sm-12">
                            <div class="portlet light ">
                                <div class="portlet-title">
                                    <div class="caption">
                                        <span class="caption-subject bold uppercase font-dark">Purchase Order</span>
                                        <span class="caption-helper"></span>
                                    </div>
                                    
                                </div>
                                <div class="portlet-body widget-thumb-body">
                                    <span class="widget-thumb-subtitle">
                                                Total Purchase:
                                                                                           <asp:Label Text="text" ID="lblTotalPO" runat="server" />
                                            </span><br /><br />
                                            <span class="widget-thumb-subtitle">
                                                Closed Purchase:

                                            
                                                <asp:Label Text="text" ID="lblClosedPO" runat="server" />
                                            </span>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-8 col-xs-12 col-sm-12">
                            <div class="portlet light ">
                                <div class="portlet-title">
                                    <div class="caption ">
                                        <span class="caption-subject font-dark bold uppercase">Sales Order</span>
                                       
                                    </div>
                                    <div class="actions">
                                        <div class="btn-group">
                                             
                                                 <asp:DropDownList runat="server" ID="txtpo" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtpo_TextChanged">
                                                     <asp:ListItem Text="Select" Value="" />
                                                     <asp:ListItem Text="Today" />
                                                     <asp:ListItem Text="Yesterday" />
                                                     <asp:ListItem Text="TotalPo" />
                                                 </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="portlet-body ">
                                    <div class="row">
                                    <div class="col-lg-4">
                                   <label>From Date</label>
                                                <asp:TextBox runat="server" ID="txtfromate" TextMode="Date" CssClass="form-control"/>
                                        </div>
                                    <div class="col-lg-4">
                                         <label>To Date</label>
                                                <asp:TextBox runat="server" ID="txttodate" TextMode="Date" CssClass="form-control" /> 
                                        </div>
                                    <div class="col-lg-4"><br />
                                       <asp:Button Text="Check" ID="check" CssClass="btn btn-success" OnClick="check_Click" runat="server" />
                                        </div>
                                        </div>
                                     <div class="row widget-thumb-body">
                                   <div class="col-lg-12"><br />
                                        <span class="widget-thumb-subtitle">
                                         Total Sales Orders: <asp:Label Text="text" ID="lblTotalSo" runat="server" />
                                            </span><br /><br />
                                         <span class="widget-thumb-subtitle">
                                             Total Sales Order Amount:  <asp:Label Text="text" ID="lbltotalamount" runat="server" />
                                             </span>
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
                </div>
                </form>
            </div>
            </div>
        </div>
</body>
</html>
