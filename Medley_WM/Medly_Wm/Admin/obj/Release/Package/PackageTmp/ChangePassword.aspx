<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs"
    Inherits="AdminAfforadbleApp.ChangePassword" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/Header.ascx" %>
<%@ Register TagPrefix="usc2" TagName="Header2" Src="~/HeaderTop.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en">
<!--<![endif]-->
<!-- BEGIN HEAD -->
<head id="Head1" runat="server" />
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
<link rel="shortcut icon" href="favicon.ico" />
</head>
<!-- END HEAD -->
<body class="page-header-fixed page-sidebar-closed-hide-logo page-container-bg-solid page-md">
 <usc2:Header2 ID="Header1" runat="server" />
    <form id="fg1" runat="server">
    <asp:ScriptManager ID="sm1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <!-- BEGIN HEADER & CONTENT DIVIDER -->
    <div class="clearfix">
    </div>
    <!-- END HEADER & CONTENT DIVIDER -->
    <!-- BEGIN CONTAINER -->
    <div class="page-container">
     <usc:Header ID="Header" runat="server" />
        <!-- BEGIN SIDEBAR -->
        <!-- END SIDEBAR -->
        <!-- BEGIN CONTENT -->
        <div class="page-content-wrapper">
            <!-- BEGIN CONTENT BODY -->
            <div class="page-content">
                <!-- BEGIN PAGE HEADER-->
                <!-- BEGIN THEME PANEL -->
                <!-- END THEME PANEL -->
                <!-- END PAGE HEADER-->
                <!-- BEGIN DASHBOARD STATS 1-->
                <div class="row">
                    <asp:ValidationSummary ID="val1" runat="server" HeaderText="Validation Messages"
                        ShowMessageBox="true" ShowSummary="false" ValidationGroup="val1" />
                    <div class="col-sm-12 col-lg-6 offset-lg-3">
                        <br />
                        <br />
                        <br />
                        <div class="login_form inner_page">
                            <form action="#">
                            <div class="heading">
                                <h3 class="text-center">
                                    Forgot Password</h3>
                            </div>
                            <div class="form-group">

                            <asp:TextBox ID="txtCurrentPassword" runat="server" CssClass="form-control" placeholder="Enter Your Current Password"
                                    AutoComplete="off"></asp:TextBox>

                                <asp:TextBox ID="txtNewPassword" runat="server" CssClass="form-control" placeholder="Enter Your New Password"
                                    AutoComplete="off"></asp:TextBox>
                                <br />
                                <asp:Label ID="lblMessage" Text="Please Enter Your Valied Current Password!" runat="server" Visible="false" style="     margin-left: 10px;" />
                                <asp:Label ID="lblMessage1" Text="Password Changed Sussfully. Thank You!" runat="server" Visible="false" style="     margin-left: 10px;" />
                            </div>
                            <div class="row">
                                <div class="col-sm-6 col-lg-6">
                                    <asp:Button runat="server" ID="btnlogin" OnClick="btnlogin_Click" class="btn btn-log btn-block btn-thm1" Style="background-color: teal;"
                                        Text="Submit" />
                                </div>
                                <div class="col-sm-6 col-lg-6">
                                    <input type="button" onclick="history.back()" value="Back" class="btn btn-log btn-block btn-thm2" />
                                </div>
                            </div>
                            </form>
                        </div>
                    </div>
                </div>
                <!-- END CONTENT BODY -->
            </div>
        </div>
    </div>
    </form>
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
        <script src="../assets/pages/scripts/components-date-time-pickers.min.js" type="text/javascript"></script>
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
