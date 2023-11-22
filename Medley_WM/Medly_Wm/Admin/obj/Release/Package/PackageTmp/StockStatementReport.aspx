﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockStatementReport.aspx.cs"
    Inherits="AdminAfforadbleApp.StockStatementReport" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/Header.ascx" %>
 <%@ Register TagPrefix="usc2" TagName="Header2" Src="~/HeaderTop.ascx" %>
 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html lang="en">
    <!--<![endif]-->
    <!-- BEGIN HEAD -->

    <head id="Head1" runat="server">
        <meta charset="utf-8" />
        <title>Dashboard</title>
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta content="width=device-width, initial-scale=1" name="viewport" />
        <meta content="Preview page of Metronic Admin Theme #2 for statistics, charts, recent events and reports" name="description" />
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
    <!-- END GLOBAL MANDATORY STYLES -->
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
    <link rel="shortcut icon" href="favicon.ico" />
    </head>

 <body class="page-header-fixed page-sidebar-closed-hide-logo page-container-bg-solid page-md">

    <usc2:Header2 ID="Header1" runat="server" />
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
        <asp:Label runat="server" ID="lblMaximumRows" ForeColor="White" CssClass="label"
        Visible="false" Text="5"> </asp:Label>

         <asp:Label runat="server" ID="lblInitialDate" ForeColor="White" CssClass="label"
        Visible="false" Text="01/04/2020"> </asp:Label>
         <asp:Label runat="server" ID="lblContactTypeId" ForeColor="White" CssClass="label"
        Visible="false" Text="1"> </asp:Label>
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
                        <div class="row">
                            <div class="col-lg-12 col-xs-12 col-sm-12">
                                <div class="portlet light " style="height: 1700px; padding-left: 3px;">
                                    
                                     <div class="portlet-title">
                                <div class="caption font-green">
                                    <i class="icon-pin font-green"></i><span class="caption-subject bold uppercase" style=" font-size:15px">Stock Statement Report</span>
                                </div>
                            </div>
                                 
                                   
                                        <div class="col-md-12 col-sm-12 col-xs-12">
                                         <div class="row">
                                            <div class="col-lg-4">

                                             <div class="form-group">
                                                    <label for="form_control_1" style="    font-weight: bold;">
                                                        Company</label>
                                                    <asp:DropDownList ID="ddlCompany" runat="server" AutoPostBack="true" Class="form-control select2">
                                                    </asp:DropDownList>
                                                </div>
 
                                            </div>
                                            <div class="col-lg-4">

                                              <div class="form-group">
                                                    <label for="form_control_1" style="    font-weight: bold;">
                                                        Item Head</label>
                                                    <asp:DropDownList ID="ddlItemHead" runat="server" AutoPostBack="true"  OnSelectedIndexChanged="ddlItemHead_OnSelectedIndexChanged" Class="form-control select2">
                                                    </asp:DropDownList>
                                                </div>
 
                                            </div>
                                            <div class="col-lg-4">

                                             <div class="form-group">
                                                    <label for="form_control_1" style="    font-weight: bold;">
                                                        Item Group</label>
                                                    <asp:DropDownList ID="ddlItemGroup" runat="server" AutoPostBack="true"  OnSelectedIndexChanged="ddlItemGroup_OnSelectedIndexChanged" Class="form-control select2">
                                                    </asp:DropDownList>
                                                </div>

                                                
                                            </div>
                                            </div>

                                             <div class="row">
                                            <div class="col-lg-4">
                                            <div class="form-group" id="FromDate" runat="server" visible="true">
                                                 <label for="form_control_1" style="    font-weight: bold;">
                                                            From Date</label>
                                                             <div class="input-group input-medium date date-picker" data-date-format="dd/mm/yyyy"
                                                            data-date-viewmode="years">
                                                            <span class="input-group-btn">
                                                                <button class="btn default" type="button">
                                                                    <i class="fa fa-calendar"></i>
                                                                </button>
                                                            </span> <asp:TextBox CssClass="form-control" ID="txtFromDate" runat="server" Width="242px"
                                                                autocomplete="off"></asp:TextBox>
                                                           
                                                        </div>
                                                 
                                            </div>
                                        </div>
                                           <div class="col-lg-4" id="ToDate" runat="server">
                                                    <div class="form-group">
                                                        <label for="form_control_1" style="    font-weight: bold;">
                                                            To Date</label>
                                                        <div class="input-group input-medium date date-picker" data-date-format="dd/mm/yyyy"
                                                            data-date-viewmode="years">
                                                            <span class="input-group-btn">
                                                                <button class="btn default" type="button">
                                                                    <i class="fa fa-calendar"></i>
                                                                </button>
                                                            </span><asp:TextBox CssClass="form-control" ID="txtToDate" runat="server" Width="242px"
                                                                autocomplete="off"></asp:TextBox>
                                                            
                                                        </div>
                                                    </div>
                                                </div>
                                            <div class="col-lg-4">

                                             <div class="form-group">
                                                    <label for="form_control_1" style="    font-weight: bold;">
                                                        Item</label>
                                                    <asp:DropDownList ID="ddlItem" runat="server" AutoPostBack="true" Class="form-control select2">
                                                    </asp:DropDownList>
                                                </div>

                                                
                                            </div>
                                            </div>
                                             <div class="row">
                                            <div class="col-lg-4">

                                              <div class="form-group">
                                                    <label for="form_control_1" style="    font-weight: bold;">
                                                        Color</label>
                                                    <asp:DropDownList ID="ddlColor" runat="server" AutoPostBack="true" Class="form-control select2">
                                                    </asp:DropDownList>
                                                </div>

                                               
                                            </div>
                                            <br />
                                            <div class="col-lg-4">
                                               
                                                        <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-success" Text="Search"
                                                            OnClick="btnSearch_OnClick" Width="125px" />
                                                   
                                            </div>
                                             <div class="row">
                                        </div>
                                    </div>
                                    <br />
                                    <div class="portlet box green" >
                                        <div class="portlet-title" style="width: 307px">
                                            <div class="caption">
                                                <i class="fa fa-globe"></i>Material Stock Report</div>
                                          
                                        </div>
                                    </div>
                                    <div class="col-lg-12" style="padding-left: 4px; overflow: scroll">
                                        <asp:GridView ID="gvMaterialStockEntry" runat="server" OnPageIndexChanging="gvMaterialStockEntry_PageIndexChanging" CssClass="table table-striped table-bordered table-hover"
                                            EmptyDataText="No Records Found" Width="100%" AutoGenerateColumns="false" AllowPaging="True"  PageSize="11">
                                            <HeaderStyle BackColor="White" />
                                            <EmptyDataRowStyle HorizontalAlign="Center" BackColor="White" ForeColor="Black" />
                                            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                                NextPageText="Next" PreviousPageText="Previous" />
                                            <Columns>
                                                <asp:BoundField HeaderText="ItemCode" DataField="ItemCode" />
                                                <asp:BoundField HeaderText="ItemDescription" DataField="ItemDescription" />
                                                <asp:BoundField HeaderText="Color" DataField="Color" />
                                                <asp:BoundField HeaderText="Opening" DataField="OP" DataFormatString="{0:f2}" HeaderStyle-HorizontalAlign="Right"
                                                    ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right" />
                                                <asp:BoundField HeaderText="Closing" DataField="CL" DataFormatString="{0:f2}" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField HeaderText="" DataField="Units" />
                                                <asp:BoundField HeaderText="Last Rate" DataField="Rate" DataFormatString="{0:f2}"
                                                    ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right" />
                                                <asp:BoundField HeaderText="Value" DataField="Value" DataFormatString="{0:f2}" ItemStyle-HorizontalAlign="Right"
                                                    FooterStyle-HorizontalAlign="Right" />
                                            </Columns>
                                            <FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                            <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                        </asp:GridView>
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
        <script src="../assets/global/plugins/select2/js/select2.full.min.js" type="text/javascript"></script>
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
            <script src="../assets/global/plugins/jquery-easypiechart/jquery.easypiechart.min.js" type="text/javascript"></script>
            <script src="../assets/global/plugins/jquery.sparkline.min.js" type="text/javascript"></script>
        
            <script src="../assets/global/plugins/jqvmap/jqvmap/jquery.vmap.js" type="text/javascript"></script>
            <script src="../assets/global/plugins/jqvmap/jqvmap/maps/jquery.vmap.russia.js" type="text/javascript"></script>
            <script src="../assets/global/plugins/jqvmap/jqvmap/maps/jquery.vmap.world.js" type="text/javascript"></script>
            <script src="../assets/global/plugins/jqvmap/jqvmap/maps/jquery.vmap.europe.js" type="text/javascript"></script>
            <script src="../assets/global/plugins/jqvmap/jqvmap/maps/jquery.vmap.germany.js" type="text/javascript"></script>
            <script src="../assets/global/plugins/jqvmap/jqvmap/maps/jquery.vmap.usa.js" type="text/javascript"></script>
            <script src="../assets/global/plugins/jqvmap/jqvmap/data/jquery.vmap.sampledata.js" type="text/javascript"></script>
        <script src="../assets/global/scripts/app.min.js" type="text/javascript"></script>
        <script src="../assets/pages/scripts/charts-amcharts.min.js" type="text/javascript"></script>
        <!-- END THEME GLOBAL SCRIPTS -->
        <!-- BEGIN PAGE LEVEL SCRIPTS -->
        <script src="../assets/pages/scripts/components-select2.min.js" type="text/javascript"></script>
        <script src="../assets/global/scripts/datatable.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/datatables/datatables.min.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.js"
            type="text/javascript"></script>
        <script src="../assets/pages/scripts/table-datatables-rowreorder.min.js" type="text/javascript"></script>
        <!-- END PAGE LEVEL PLUGINS -->
        <script src="../assets/global/plugins/select2/js/select2.full.min.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/bootstrap-fileinput/bootstrap-fileinput.js"
            type="text/javascript"></script>

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

        <script src="../assets/global/plugins/jquery.sparkline.min.js" type="text/javascript"></script>
        <script src="http://maps.google.com/maps/api/js?sensor=false" type="text/javascript"></script>
        <script src="../assets/global/plugins/gmaps/gmaps.min.js" type="text/javascript"></script>
        <!-- BEGIN THEME GLOBAL SCRIPTS -->
        <script src="../assets/global/scripts/app.min.js" type="text/javascript"></script>
          <script src="../assets/pages/scripts/components-date-time-pickers.min.js" type="text/javascript"></script>
        <!-- END THEME GLOBAL SCRIPTS -->
        <!-- BEGIN PAGE LEVEL SCRIPTS -->

        <script src="../assets/pages/scripts/table-datatables-managed.min.js" type="text/javascript"></script>
        <script src="../assets/pages/scripts/profile.min.js" type="text/javascript"></script>
        <script src="../assets/pages/scripts/timeline.min.js" type="text/javascript"></script>
</body>

</html>