<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RequirementSheetDetails.aspx.cs"
    Inherits="AdminAfforadbleApp.RequirementSheetDetails" %>


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
    <!-- BEGIN PAGE LEVEL PLUGINS -->
    <link href="../assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.css"
        rel="stylesheet" type="text/css" />
    <!-- END PAGE LEVEL PLUGINS -->
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
                                <div class="portlet light " style="height: 1300px; padding-left: 3px;">
                                      <div class="portlet-title">
                                <div class="caption font-green">
                                    <i class="icon-pin font-green"></i><span class="caption-subject bold uppercase" style=" font-size:15px">Requirement Sheet Details Report</span>
                                </div>
                            </div>

                                    <div class="col-md-12 col-sm-12 col-xs-12">
                                    <div class="col-lg-2">


                                                <div class="stat-right">
                                                    <div class="stat-number">
                                                        <div class="title" style="    font-weight: bold;">
                                                          Item Head</div>
                                                        <asp:CheckBoxList ID="chkItemHead" CssClass="chkChoice1" runat="server">
                                    </asp:CheckBoxList>
                                                    </div>
                                                </div>
                                            </div>
                                             <div class="col-lg-3">

                                               <div class="form-group">
                                                    <label for="form_control_1" style="    font-weight: bold;">
                                                        Buyer Code</label>
                                                    <asp:DropDownList ID="ddlBuyerCode" runat="server" AutoPostBack="true" OnSelectedIndexChanged="buyer_code" Class="form-control select2">
                                                    </asp:DropDownList>
                                                </div>

                                                
                                            </div>
                                             <div class="col-lg-3">

                                              <div class="form-group">
                                                    <label for="form_control_1" style="    font-weight: bold;">
                                                        Type</label>
                                                    <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="buyer_code" Class="form-control select2">
                                                    <asp:ListItem Text="With Color" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="WithOut Color" Value="2"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>

                                                
                                            </div>
                                                    <div class="col-lg-2" >
                                                <div class="stat-right">
                                                    <div class="stat-number">
                                                        <div class="title" style="    font-weight: bold;">
                                                            Find Exc No</div>
                                                       
                                                            <asp:TextBox ID="txtfabcontrast" Width="256px" runat="server"  CssClass="form-control" placeholder="Find ExcNo" onkeyup="SearchEmployees(this,'#chkExcNo');">
                                                            </asp:TextBox>
                                                            <div style="overflow-y: scroll; height: 100px">
                                                                <div class="panel panel-default" style="width: 250px">
                                                                    <asp:CheckBoxList ID="chkExcNo"  CssClass="chkChoice1" runat="server" RepeatLayout="Table"
                                                                        Style="overflow: auto">
                                                                    </asp:CheckBoxList>
                                                                </div>
                                                            </div>
                                                        
                                                    </div>
                                                </div>
                                            </div>
                                             <div class="col-lg-4" id="FromDate" runat="server">
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
                                                            </span><asp:TextBox CssClass="form-control" ID="txtToDate" runat="server" Width="212px"
                                                                autocomplete="off"></asp:TextBox>
                                                            
                                                        </div>
                                                    </div>
                                                </div>

                                                 <div class="col-lg-1">
                                               
                                                        <asp:Button ID="btnSearch" runat="server" style="" CssClass="btn btn-success" Text="Search"
                                                            OnClick="btnSearch_OnClick" Width="125px" />
                                                 
                                            </div>
                                            </div>
                                   
                                        
                                  
                                    <div class="col-lg-12" style="padding-left: 4px; padding-top: 10px; overflow: scroll">
                                        <asp:GridView ID="gvRequirementSheetDetails" runat="server" ShowHeader="false" GridLines="none" OnPageIndexChanging="gvBuyerOrder_PageIndexChanging"
                                            CssClass="table table-striped table-bordered table-hover" Width="100%" AutoGenerateColumns="true"
                                            AllowPaging="True" PagerSettings-FirstPageText="First" PagerSettings-LastPageText="Last"
                                            PagerSettings-Mode="NumericFirstLast" PagerSettings-PageButtonCount="4" EmptyDataText="No Records"
                                            PageSize="6">
                                              <%--<Columns>
                                              <asp:BoundField HeaderText="PONo " DataField="FullPONo" />
                                                    <asp:BoundField HeaderText="OrderDate " DataField="OrderDate" DataFormatString="{0:dd/MM/yyyy}" />
                                                    <asp:BoundField HeaderText="Party " DataField="Party" />
                                                    <asp:BoundField HeaderText="Type " DataField="purchasefortype" />
                                                    <asp:BoundField HeaderText="Item " DataField="Item" />
                                                    <asp:BoundField HeaderText="Color " DataField="Color" />
                                                    <asp:BoundField HeaderText="Units " DataField="Units" />
                                                    <asp:BoundField HeaderText="Qty " DataField="Qty" />
                                                    <asp:BoundField HeaderText="RecQty " DataField="RecQty" />
                                                    <asp:BoundField HeaderText="BalQty " DataField="BalQty" />
                                                    <asp:BoundField HeaderText="CompanyCode " DataField="CompanyCode" />
                                            </Columns>--%>
                                            <FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                            <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                        </asp:GridView>
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
