<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="AdminAfforadbleApp.Homepage"
    MaintainScrollPositionOnPostback="true" EnableEventValidation="false" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/Header.ascx" %>
<%@ Register TagPrefix="usc2" TagName="Header2" Src="~/HeaderTop.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en">
<!--<![endif]-->
<!-- BEGIN HEAD -->
<head>
    <meta charset="utf-8" />
    <title>Dashboard</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta content="width=device-width, initial-scale=1" name="viewport" />
    <meta content="Preview page of Metronic Admin Theme #2 for statistics, charts, recent events and reports"
        name="description" />
    <meta content="" name="author" />
    <!-- BEGIN GLOBAL MANDATORY STYLES -->
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all"
        rel="stylesheet" type="text/css" />
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
    <link href="../assets/global/plugins/select2/css/select2.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../assets/global/plugins/select2/css/select2-bootstrap.min.css" rel="stylesheet"
        type="text/css" />

          <link href="../assets/global/plugins/bootstrap-daterangepicker/daterangepicker.min.css"
        rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/bootstrap-datepicker/css/bootstrap-datepicker3.min.css"
        rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/bootstrap-timepicker/css/bootstrap-timepicker.min.css"
        rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/bootstrap-datetimepicker/css/bootstrap-datetimepicker.min.css"
        rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/clockface/css/clockface.css" rel="stylesheet"
        type="text/css" />

    <!-- END GLOBAL MANDATORY STYLES -->
    <!-- BEGIN PAGE LEVEL PLUGINS -->
    <link href="../assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.css"
        rel="stylesheet" type="text/css" />
    <!-- END PAGE LEVEL PLUGINS -->
    <!-- BEGIN THEME GLOBAL STYLES -->
    <link href="../assets/global/css/components-md.min.css" rel="stylesheet" id="style_components"
        type="text/css" />
    <link href="../assets/global/css/plugins-md.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/pages/css/profile.min.css" rel="stylesheet" type="text/css" />
    <!-- END THEME GLOBAL STYLES -->
    <!-- BEGIN THEME LAYOUT STYLES -->
    <link href="../assets/layouts/layout2/css/layout.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/layouts/layout2/css/themes/blue.min.css" rel="stylesheet" type="text/css"
        id="style_color" />
    <link href="../assets/layouts/layout2/css/custom.min.css" rel="stylesheet" type="text/css" />
    <!-- END THEME LAYOUT STYLES -->
    <script src="https://cdn.amcharts.com/lib/4/core.js"></script>
    <script src="https://cdn.amcharts.com/lib/4/charts.js"></script>
    <script src="https://cdn.amcharts.com/lib/4/themes/animated.js"></script>
    <link rel="shortcut icon" href="favicon.ico" />
</head>
<body class="page-header-fixed page-sidebar-closed-hide-logo page-container-bg-solid page-md">
    <usc2:Header2 ID="Header2" runat="server" />
    <div class="clearfix">
    </div>
    <!-- BEGIN HEADER -->
    <!-- END HEADER -->
    <!-- BEGIN HEADER & CONTENT DIVIDER -->
    <div class="clearfix">
    </div>
    <!-- END HEADER & CONTENT DIVIDER -->
    <!-- BEGIN CONTAINER -->
    <div class="page-container">
        <usc:Header ID="Header" runat="server" />
        <form id="f1" runat="server">
        <asp:ScriptManager ID="SM" runat="server">
        </asp:ScriptManager>
        <!-- BEGIN SIDEBAR -->
        <!-- END SIDEBAR -->
        <!-- BEGIN CONTENT -->
        <div class="page-content-wrapper">
            <!-- BEGIN CONTENT BODY -->
            <div class="page-content">
                <!-- BEGIN PAGE HEADER-->
                <asp:UpdatePanel ID="UP" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="row"    >
                            <div class="col-lg-12 col-xs-12 col-sm-12">
                                <div class="portlet light " style="height: 1800px; padding-left: 3px;">
                                     <div class="portlet-title">
                                <div class="caption font-green">
                                    <i class="icon-pin font-green"></i><span class="caption-subject bold uppercase" style=" font-size:15px">Latest Costing Details Report</span>
                                </div>
                            </div>
                                    <div class="portlet-body">
                                     <div class="row number-stats margin-bottom-30">
                                        <div class="col-lg-12 col-xs-12 col-sm-12">
                                           <div class="col-lg-2">
                                                <div class="form-group">
                                                    <label for="form_control_1" style="    font-weight: bold;">
                                                        Style No</label>
                                                    <asp:DropDownList ID="ddlStyleNo" runat="server" AutoPostBack="true"  Width="240px" 
                                                        Class="form-control select2">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                             <div class="col-lg-3" id="Div33" runat="server">
                                                    <div class="form-group">
                                                        <label for="form_control_1" style="    font-weight: bold;">
                                                            From Date</label>
                                                        <div class="input-group input-medium date date-picker" data-date-format="dd/mm/yyyy"
                                                            data-date-viewmode="years">
                                                            <span class="input-group-btn">
                                                                <button class="btn default" type="button">
                                                                    <i class="fa fa-calendar"></i>
                                                                </button>
                                                            </span> <asp:TextBox CssClass="form-control" ID="txtFromDate" runat="server" Width="212px"
                                                                autocomplete="off"></asp:TextBox>
                                                           
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="col-lg-3" id="Div1" runat="server">
                                                    <div class="form-group">
                                                        <label for="form_control_1" style="    font-weight: bold;">
                                                            To Date</label>
                                                        <div class="input-group input-medium date date-picker" data-date-format="dd/mm/yyyy"
                                                            data-date-viewmode="years">
                                                            <span class="input-group-btn">
                                                                <button class="btn default" type="button">
                                                                    <i class="fa fa-calendar"></i>
                                                                </button>
                                                            </span><asp:TextBox CssClass="form-control" ID="txtToDate" runat="server" Width="212px"
                                                                autocomplete="off"></asp:TextBox>
                                                            
                                                        </div>
                                                    </div>
                                                </div>
                                            <div class="col-md-3 col-sm-3 col-xs-3">
                                                <br />
                                                <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-success" Text="Search"
                                                    OnClick="btnSearch_OnClick" Width="125px" />
                                            </div>
                                        </div>
                                       </div>
                                        <div class="portlet box green">
                                            <div class="portlet-title" style="width: 332px">
                                                <div class="caption">
                                                    <i class="fa fa-globe"></i>Costing Details
                                                </div>
                                                <%-- <div class="tools"> <span class="caption-helper"><asp:Label ID="lbldetails" runat="server"></asp:Label>...</span> </div>--%>
                                            </div>
                                        </div>
                                        <div class="col-lg-12" style="padding-left: 4px;">
                                            <div class="col-lg-6" style="padding-left: 4px;">
                                                <asp:GridView runat="server" ID="gvCostingDetails2" Width="318px" CssClass="table table-striped table-bordered table-hover"
                                                    AutoGenerateColumns="false" ShowHeader="false">
                                                    <Columns>
                                                        <asp:BoundField HeaderText="" DataField="Item" ItemStyle-Font-Bold="true" ItemStyle-Font-Size="12px" />
                                                        <asp:BoundField HeaderText="Avg" DataField="Avg" DataFormatString="{0:f3}" ItemStyle-HorizontalAlign="Right" />
                                                        <asp:BoundField HeaderText="Rate" DataField="Rate" DataFormatString="{0:f3}" ItemStyle-HorizontalAlign="Right" />
                                                        <asp:BoundField HeaderText="Amount" DataField="Price" ItemStyle-Font-Bold="true"
                                                            ItemStyle-Font-Size="15px" DataFormatString="{0:f3}" ItemStyle-HorizontalAlign="Right" />
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                            <div class="col-lg-6" style="padding-left: 4px;">
                                                <asp:GridView ID="gvCostingDetails1" runat="server" EmptyDataText="No Records Found"
                                                    Caption='Sketch Details' AutoGenerateColumns="false" ShowHeader="false">
                                                    <Columns>
                                                        <%--<asp:ImageField DataImageUrlField="Sketch"  HeaderStyle-Width="50%"  HeaderText="Sketch" ItemStyle-HorizontalAlign="Center" />--%>
                                                        <asp:TemplateField HeaderText="Sketch">
                                                            <ItemTemplate>
                                                                <asp:Image ID="Image1" runat="server" Height="300px" Width="316px" ImageUrl='<%# Eval("Sketch") %>' />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <!-- END CONTENT BODY -->
        </div>
        <!-- END CONTENT -->
        <!-- BEGIN QUICK SIDEBAR -->
        <!-- END QUICK SIDEBAR -->
        </form>
    </div>
    <!-- END CONTAINER -->
    <!-- BEGIN FOOTER -->
    <div class="page-footer">
        <div class="page-footer-inner">
            2021 &copy; Bigdbiz Solutions Pvt Ltd
            <div class="scroll-to-top">
                <i class="icon-arrow-up"></i>
            </div>
        </div>
        <!-- END FOOTER -->
        <!-- BEGIN QUICK NAV -->
        <!-- END QUICK NAV -->
        <!--[if lt IE 9]>
<script src="../assets/global/plugins/respond.min.js"></script>
<script src="../assets/global/plugins/excanvas.min.js"></script> 
<script src="../assets/global/plugins/ie8.fix.min.js"></script> 
<![endif]-->
        <!-- BEGIN CORE PLUGINS -->
        <script src="../assets/global/plugins/jquery.min.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/js.cookie.min.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js"
            type="text/javascript"></script>
        <script src="../assets/global/plugins/jquery.blockui.min.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js"
            type="text/javascript"></script>
        <!-- END CORE PLUGINS -->
        <!-- BEGIN PAGE LEVEL PLUGINS -->
        
        <script src="../assets/global/plugins/amcharts/amcharts/amcharts.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/amcharts/amcharts/serial.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/amcharts/amcharts/pie.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/amcharts/amcharts/radar.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/amcharts/amcharts/themes/light.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/amcharts/amcharts/themes/patterns.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/amcharts/amcharts/themes/chalk.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/amcharts/ammap/ammap.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/amcharts/ammap/maps/js/worldLow.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/amcharts/amstockcharts/amstock.js" type="text/javascript"></script>
        <!-- END PAGE LEVEL PLUGINS -->
        <!-- BEGIN THEME GLOBAL SCRIPTS -->
        <script src="../assets/global/plugins/flot/jquery.flot.min.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/flot/jquery.flot.resize.min.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/flot/jquery.flot.categories.min.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/jquery-easypiechart/jquery.easypiechart.min.js"
            type="text/javascript"></script>
        <script src="../assets/global/plugins/jquery.sparkline.min.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/jqvmap/jqvmap/jquery.vmap.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/jqvmap/jqvmap/maps/jquery.vmap.russia.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/jqvmap/jqvmap/maps/jquery.vmap.world.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/jqvmap/jqvmap/maps/jquery.vmap.europe.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/jqvmap/jqvmap/maps/jquery.vmap.germany.js"
            type="text/javascript"></script>
        <script src="../assets/global/plugins/jqvmap/jqvmap/maps/jquery.vmap.usa.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/jqvmap/jqvmap/data/jquery.vmap.sampledata.js"
            type="text/javascript"></script>

             <script src="../assets/global/plugins/select2/js/select2.full.min.js" type="text/javascript"></script>

               <script src="../assets/global/plugins/moment.min.js" type="text/javascript"></script>
    <script src="../assets/global/plugins/bootstrap-daterangepicker/daterangepicker.min.js"
        type="text/javascript"></script>
    <script src="../assets/global/plugins/bootstrap-datepicker/js/bootstrap-datepicker.min.js"
        type="text/javascript"></script>
    <script src="../assets/global/plugins/bootstrap-timepicker/js/bootstrap-timepicker.min.js"
        type="text/javascript"></script>
    <script src="../assets/global/plugins/bootstrap-datetimepicker/js/bootstrap-datetimepicker.min.js"
        type="text/javascript"></script>
    <script src="../assets/global/plugins/clockface/js/clockface.js" type="text/javascript"></script>

        <script src="../assets/global/scripts/app.min.js" type="text/javascript"></script>
        <script src="../assets/pages/scripts/charts-amcharts.min.js" type="text/javascript"></script>
          <script src="../assets/pages/scripts/components-date-time-pickers.min.js" type="text/javascript"></script>
        <!-- END THEME GLOBAL SCRIPTS -->
        <!-- BEGIN PAGE LEVEL SCRIPTS -->
        <script src="../assets/pages/scripts/components-select2.min.js" type="text/javascript"></script>
        <script src="../assets/global/scripts/datatable.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/datatables/datatables.min.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.js"
            type="text/javascript"></script>
        <script src="../assets/pages/scripts/table-datatables-rowreorder.min.js" type="text/javascript"></script>
        <!-- END PAGE LEVEL PLUGINS -->
    
        <script src="../assets/global/plugins/bootstrap-fileinput/bootstrap-fileinput.js"
            type="text/javascript"></script>
        <script src="../assets/global/plugins/jquery.sparkline.min.js" type="text/javascript"></script>
        <script src="http://maps.google.com/maps/api/js?sensor=false" type="text/javascript"></script>
        <script src="../assets/global/plugins/gmaps/gmaps.min.js" type="text/javascript"></script>
        <!-- BEGIN THEME GLOBAL SCRIPTS -->
        <script src="../assets/global/scripts/app.min.js" type="text/javascript"></script>
        <!-- END THEME GLOBAL SCRIPTS -->
        <!-- BEGIN PAGE LEVEL SCRIPTS -->
        <script src="../assets/pages/scripts/table-datatables-managed.min.js" type="text/javascript"></script>
        <script src="../assets/pages/scripts/profile.min.js" type="text/javascript"></script>
        <script src="../assets/pages/scripts/timeline.min.js" type="text/javascript"></script>
</body>
</html>
