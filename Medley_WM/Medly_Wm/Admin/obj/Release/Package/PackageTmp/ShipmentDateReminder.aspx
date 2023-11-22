<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShipmentDateReminder.aspx.cs" Inherits="AdminAfforadbleApp.ShipmentDateReminder" %>

 <%@ Register TagPrefix="usc" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="usc2" TagName="Header2" Src="~/HeaderTop.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!--[if IE 8]> <html lang="en" class="ie8 no-js"> <![endif]-->
<!--[if IE 9]> <html lang="en" class="ie9 no-js"> <![endif]-->
<!--[if !IE]><!-->
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
    <link href="../assets/global/plugins/select2/css/select2.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../assets/global/plugins/select2/css/select2-bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../assets/global/plugins/datatables/datatables.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.css"
        rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/fancybox/source/jquery.fancybox.css" rel="stylesheet"
        type="text/css" />
    <link href="../assets/global/plugins/bootstrap-modal/css/bootstrap-modal-bs3patch.css"
        rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/bootstrap-modal/css/bootstrap-modal.css" rel="stylesheet"
        type="text/css" />
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


   <%-- <script src="../assets/global/plugins/amcharts/amcharts/amcharts.js" type="text/javascript"></script>
    <script src="../assets/global/plugins/amcharts/amcharts/serial.js" type="text/javascript"></script>
    <script src="../assets/global/plugins/amcharts/amcharts/pie.js" type="text/javascript"></script>
    <script src="../assets/global/plugins/amcharts/amcharts/radar.js" type="text/javascript"></script>
    <script src="../assets/global/plugins/amcharts/amcharts/themes/light.js" type="text/javascript"></script>
    <script src="../assets/global/plugins/amcharts/amcharts/themes/patterns.js" type="text/javascript"></script>
    <script src="../assets/global/plugins/amcharts/amcharts/themes/chalk.js" type="text/javascript"></script>
    <script src="../assets/global/plugins/amcharts/ammap/ammap.js" type="text/javascript"></script>
    <script src="../assets/global/plugins/amcharts/ammap/maps/js/worldLow.js" type="text/javascript"></script>
    <script src="../assets/global/plugins/amcharts/amstockcharts/amstock.js" type="text/javascript"></script>--%>

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

    <style>
        .button {
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
<!-- END HEAD -->
<%--<body class="page-container-bg-solid page-header-fixed page-sidebar-closed-hide-logo page-md page-sidebar-closed">--%>
<%--<body class="page-sidebar-closed-hide-logo page-container-bg-solid page-md">--%>
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
                 <div class="row">
                                <div class="col-md-12">
                                    <!-- BEGIN EXAMPLE TABLE PORTLET-->
                                    <div class="portlet light ">
                                        <div class="portlet-title">
                                            <div class="caption font-dark">
                                                <i class="icon-settings font-dark"></i><span class="caption-subject bold uppercase">
                                                   Buyer Order Shipment Reminder List</span>
                                                   
                                            </div>
                                            
                                        </div>
                                          <div class="form-body">
                                
                            </div>
                                        <div class="portlet-body">
                                            <div class="table-toolbar">
                                            </div>
                                            <table class="table table-striped table-bordered table-hover table-checkable order-column"
                                                id="sample_1">
                                                <thead>
                                                    <tr>
                                                        <th style="display: none">
                                                            <label class="mt-checkbox mt-checkbox-single mt-checkbox-outline">
                                                                <input type="checkbox" class="group-checkable" data-set="#sample_1 .checkboxes" />
                                                                <span></span>
                                                            </label>
                                                        </th>
                                                    
                                                        <th>
                                                            Exc No
                                                        </th>
                                                         <th>
                                                            Order Date
                                                        </th>
                                                        <th>
                                                            Shipment Date
                                                        </th>
                                                         <th>
                                                            Delivery Date
                                                        </th>
                                                        <th>
                                                            Buyer Name
                                                        </th>
                                                        
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <asp:Label ID="lblTable" runat="server"></asp:Label>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                    <!-- END EXAMPLE TABLE PORTLET-->
                                </div>
                            </div>
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


        <!-- END CONTAINER -->
        <!-- BEGIN FOOTER -->
        <!-- BEGIN PAGE LEVEL PLUGINS -->
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
    <script src="../assets/global/plugins/fancybox/source/jquery.fancybox.pack.js" type="text/javascript"></script>
    <script src="../assets/global/plugins/plupload/js/plupload.full.min.js" type="text/javascript"></script>
    <!-- END PAGE LEVEL PLUGINS -->
    <!-- BEGIN THEME GLOBAL SCRIPTS -->
    <script src="../assets/global/scripts/app.min.js" type="text/javascript"></script>
    <!-- END THEME GLOBAL SCRIPTS -->
    <!-- BEGIN PAGE LEVEL SCRIPTS -->
    <script src="../assets/pages/scripts/components-select2.min.js" type="text/javascript"></script>
    <script src="../assets/global/scripts/datatable.js" type="text/javascript"></script>
    <script src="../assets/global/plugins/datatables/datatables.min.js" type="text/javascript"></script>
    <script src="../assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.js"
        type="text/javascript"></script>
    <!-- END PAGE LEVEL PLUGINS -->
    <!-- BEGIN THEME GLOBAL SCRIPTS -->
    <script src="../assets/global/scripts/app.min.js" type="text/javascript"></script>
    <!-- END THEME GLOBAL SCRIPTS -->
    <!-- BEGIN PAGE LEVEL SCRIPTS -->
 
     <script src="../assets/pages/scripts/table-datatables-managed.min.js" type="text/javascript"></script>
    <!-- END PAGE LEVEL SCRIPTS -->
     <script src="../assets/layouts/layout2/scripts/layout.min.js" type="text/javascript"></script>
    <script src="../assets/layouts/layout2/scripts/demo.min.js" type="text/javascript"></script>
    <script src="../assets/layouts/global/scripts/quick-sidebar.min.js" type="text/javascript"></script>
    <script src="../assets/layouts/global/scripts/quick-nav.min.js" type="text/javascript"></script>
    <script>
        $(document).ready(function () {
            $('#clickmewow').click(function () {
                $('#radio1003').attr('checked', 'checked');
            });
        })
            </script>
        <!-- END PAGE LEVEL SCRIPTS -->

</body>
</html>
