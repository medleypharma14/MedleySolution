<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DailyProductionReport.aspx.cs"
    Inherits="AdminAfforadbleApp.DailyProductionReport" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/Header.ascx" %>
<%@ Register TagPrefix="usc2" TagName="Header2" Src="~/HeaderTop.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en">
<!--<![endif]-->
<!-- BEGIN HEAD -->
<head runat="server" />
<style type="text/css">
    body
    {
        font-family: Arial;
        font-size: 10pt;
    }
    .modalBackground
    {
        background-color: Black;
        filter: alpha(opacity=40);
        opacity: 0.4;
    }
    .modalPopup
    {
        background-color: #FFFFFF;
        width: 900px;
        text-align: center;
        border: 3px solid #0DA9D0;
    }
    .modalPopup .header
    {
        background-color: #2FBDF1;
        height: 40px;
        color: White;
        line-height: 30px;
        text-align: center;
        font-weight: bold;
    }
    .modalPopup .body
    {
        min-height: 50px;
        line-height: 30px;
        text-align: center;
        padding: 5px;
    }
    .modalPopup .footer
    {
        padding: 3px;
    }
    .modalPopup .button
    {
        height: 23px;
        color: White;
        line-height: 23px;
        text-align: center;
        font-weight: bold;
        cursor: pointer;
        background-color: #9F9F9F;
        border: 1px solid #5C5C5C;
    }
    .modalPopup td
    {
        text-align: left;
    }
    
    .pad
    {
        padding-top: 50px;
    }
    
    .autocomplete_completionListElement
    {
        background-color: white;
        color: windowtext;
        border-width: 1px;
        border-style: solid;
        overflow: auto;
        max-height: 100px;
        text-align: left;
        list-style-type: none;
        padding: 0px;
    }
</style>
<meta charset="utf-8" />
<title>Building Details Report</title>
<link rel="icon" href="http://bigdbiz.com/../assets/images/favicon.ico">
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta content="width=device-width, initial-scale=1" name="viewport" />
<meta content="Preview page of Metronic Admin Theme #2 for supports searching, remote data sets, and infinite scrolling of results"
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
<script type="text/javascript">

    function Delete(BuildingMasterID, UserID) {


        if (BuildingMasterID == "" || BuildingMasterID == null && UserID == "" || UserID == null) {

        }

        else {

            PageMethods.GoDeleteBuildingMaster(BuildingMasterID, UserID, ongoacceptsuccess);

        }
        function ongoacceptsuccess(data) {

            if (data == "200") {

                var url = location.protocol + '//' + location.host + "/../Admin/BuildingMasterGrid.aspx";
                window.location.href = url;

            }


        }
        return false;
    }
    function Search_Gridview(strKey, strGV) {
        var strData = strKey.value.toLowerCase().split(" ");
        var tblData = document.getElementById(strGV);
        var rowData;
        for (var i = 1; i < tblData.rows.length; i++) {
            rowData = tblData.rows[i].innerHTML;
            var styleDisplay = 'none';
            for (var j = 0; j < strData.length; j++) {
                if (rowData.toLowerCase().indexOf(strData[j]) >= 0)

                    styleDisplay = '';
                else {
                    styleDisplay = 'none';
                    break;
                }
            }
            tblData.rows[i].style.display = styleDisplay;
        }
    } 
</script>
<script type="text/javascript">
    function goBack() {
        window.history.back();
    }
</script>
<script type="text/javascript">
    function ReportPrint() {

        var gridData = document.getElementById('gvPartyWiseProductionStatus');

        var windowUrl = 'about:blank';
        //set print document name for gridview
        var uniqueName = new Date();
        var windowName = 'Print_' + uniqueName.getTime();

        var prtWindow = window.open(windowUrl, windowName,
           'left=100,top=100,right=100,bottom=100,width=1100,height=1200');
        prtWindow.document.write('<html><head></head>');
        prtWindow.document.write('<body style="background:none !important">');

        prtWindow.document.write(gridData.outerHTML);
        prtWindow.document.write('</body></html>');
        prtWindow.document.close();
        prtWindow.focus();
        prtWindow.print();
        prtWindow.close();


    }
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
<!-- END HEAD -->
<%--<body class="page-container-bg-solid page-header-fixed page-sidebar-closed-hide-logo page-md page-sidebar-closed">--%>
<%--<body class="page-sidebar-closed-hide-logo page-container-bg-solid page-md">--%>
<body class="page-header-fixed page-sidebar-closed-hide-logo page-container-bg-solid page-md">
    <usc2:Header2 ID="Header2" runat="server" />
    <div class="clearfix">
    </div>
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
                <div class="row">
                    <div class="col-lg-12 col-xs-12 col-sm-12">
                        <div class="portlet light " style="height: 1300px; padding-left: 3px;">
                            <div class="portlet-title" style="width: 333px;">
                                <div class="caption caption-md">
                                    <i class="icon-pin font-green"></i><span class="caption-subject font-dark bold uppercase">
                                        Daily Production Report</span>
                                </div>
                            </div>
                            <div class="col-lg-12">
                                <div class="col-lg-2" style="display: none">
                                    <div class="form-group">
                                        <asp:CheckBoxList ID="chkItemHead" CssClass="chkChoice1" runat="server">
                                            <asp:ListItem>Cutting</asp:ListItem>
                                            <asp:ListItem>Stitching</asp:ListItem>
                                            <asp:ListItem>Washing</asp:ListItem>
                                            <asp:ListItem>Buttoning</asp:ListItem>
                                            <asp:ListItem>Finishing</asp:ListItem>
                                            <asp:ListItem>Packing</asp:ListItem>
                                        </asp:CheckBoxList>
                                    </div>
                                </div>
                                <div class="col-lg-2" style="display: none">
                                    <div class="form-group">
                                        <label>
                                            Jobwork Ledger
                                        </label>
                                        <asp:DropDownList ID="ddlProcessLedger" runat="server" CssClass="chzn-select" Style="height: 30px"
                                            Width="100%">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label>
                                            Buyer Code:</label>
                                        <asp:DropDownList ID="ddlBuyerCode" runat="server" CssClass="chzn-select" Width="100%">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-lg-2" style="display: none">
                                    <div class="form-group" id="ExcNo" runat="server" visible="true">
                                        <asp:TextBox ID="txtfabcontrast" runat="server" Width="100%" placeholder="Find ExcNo"
                                            onkeyup="SearchEmployees(this,'#chkExcNo');">
                                        </asp:TextBox>
                                        <div style="overflow-y: scroll; height: 100px">
                                            <div class="panel panel-default" style="width: 350px">
                                                <asp:CheckBoxList ID="chkExcNo" CssClass="chkChoice1" runat="server" RepeatLayout="Table"
                                                    Style="overflow: auto">
                                                </asp:CheckBoxList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-1" style="display: none">
                                    <div class="form-group" id="Date" runat="server" visible="true">
                                        <asp:Label ID="lblDate" runat="server" Text="Shipment Date" Width="110px" Style="font-weight: bold">
                                        </asp:Label>
                                        <br />
                                        <asp:CheckBox ID="chkUseDate" runat="server" />
                                    </div>
                                </div>
                                <div class="col-lg-4">
                                    <div class="form-group">
                                        <label for="form_control_1">
                                            From Date</label>
                                        <div class="input-group input-medium date date-picker" data-date-format="dd/mm/yyyy"
                                            data-date-viewmode="years">
                                            <asp:TextBox CssClass="form-control" ID="txtFromDate" runat="server" Width="200px"
                                                autocomplete="off"></asp:TextBox>
                                            <span class="input-group-btn">
                                                <button class="btn default" type="button" style="    height: 34px;">
                                                    <i class="fa fa-calendar"></i>
                                                </button>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-4">

                                 <div class="form-group">
                                        <label for="form_control_1">
                                            To Date</label>
                                        <div class="input-group input-medium date date-picker" data-date-format="dd/mm/yyyy"
                                            data-date-viewmode="years">
                                            <asp:TextBox CssClass="form-control" ID="txtToDate" runat="server" Width="200px"
                                                autocomplete="off"></asp:TextBox>
                                            <span class="input-group-btn">
                                                <button class="btn default" type="button" style="    height: 34px;">
                                                    <i class="fa fa-calendar"></i>
                                                </button>
                                            </span>
                                        </div>
                                    </div>

                                    
                                </div>
                                <div class="col-lg-1">
                                    <br />
                                    <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary" Text="Search"
                                        OnClick="btnSearch_OnClick" Width="110px" />
                                </div>
                                <div class="col-lg-1">
                                    <br />
                                    <asp:Button ID="btnExcel" runat="server" Visible="false" CssClass="btn btn-warning"
                                        Text="Excel" Width="110px" OnClick="btnExcel_OnClick" />
                                </div>
                                <div class="col-lg-1">
                                    <br />
                                    <asp:Button ID="btn" runat="server" Text="Print" Visible="false" CssClass="btn btn-info"
                                        OnClientClick="ReportPrint()" Width="110px" />
                                </div>
                            </div>
                            <div id="Excel" runat="server">
                                <div class="col-md-12">
                                    <!-- BEGIN EXAMPLE TABLE PORTLET-->
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
                                                </th>
                                                <th>
                                                </th>
                                                <th colspan="2" style="padding-left: 18px;">
                                                    OrderDetails
                                                </th>
                                                <th colspan="2" style="padding-left: 55px;">
                                                    CUTTING
                                                </th>
                                                <th colspan="3" style="padding-left: 85px;">
                                                    STITCHING
                                                </th>
                                                <th>
                                                    WASHING
                                                </th>
                                                <th>
                                                    BUTTONING
                                                </th>
                                                <th>
                                                    FINISHING
                                                </th>
                                                <th>
                                                    PACKED
                                                </th>
                                            </tr>
                                            <tr>
                                                <th style="display: none">
                                                    <label class="mt-checkbox mt-checkbox-single mt-checkbox-outline">
                                                        <input type="checkbox" class="group-checkable" data-set="#sample_1 .checkboxes" />
                                                        <span></span>
                                                    </label>
                                                </th>
                                                <th rowspan="2" style="padding-bottom: 30px;">
                                                    ExcNo
                                                </th>
                                                <th rowspan="2" style="padding-bottom: 30px;">
                                                    Color
                                                </th>
                                                <th style="width: 82px;">
                                                    Order
                                                </th>
                                                <th style="width: 82px;">
                                                    Order
                                                </th>
                                                <th style="width: 12%;">
                                                    TODAY'S
                                                </th>
                                                <th style="width: 13%;">
                                                    TOTAL
                                                </th>
                                                <th style="width: 12%;">
                                                    TODAY'S
                                                </th>
                                                <th style="width: 13%;">
                                                    TOTAL
                                                </th>
                                                <th style="width: 13%;">
                                                    BAL
                                                </th>
                                                <th style="width: 13%;">
                                                    TODAY'S
                                                </th>
                                                <th style="width: 13%;">
                                                    TODAY'S
                                                </th>
                                                <th style="width: 13%;">
                                                    TOTAL
                                                </th>
                                                <th style="width: 13%;">
                                                    TOTAL
                                                </th>
                                                <th style="width: 13%;">
                                                    BAL
                                                </th>
                                            </tr>
                                            <tr>
                                                <th style="width: 82px;">
                                                    Qty
                                                </th>
                                                <th style="width: 82px;">
                                                    Qty(%)
                                                </th>
                                                <th>
                                                    CUTTING
                                                </th>
                                                <th style="width: 18%;">
                                                    CUTTINGTILL
                                                </th>
                                                <th style="width: 12%;">
                                                    PROD'N
                                                </th>
                                                <th>
                                                    PROD'N
                                                </th>
                                                <th>
                                                    PROD'N
                                                </th>
                                                <th>
                                                    LOADING
                                                </th>
                                                <th>
                                                    LOADING
                                                </th>
                                                <th>
                                                </th>
                                                <th>
                                                </th>
                                                <th>
                                                    PACKED
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Label ID="lblTable" runat="server"></asp:Label>
                                        </tbody>
                                    </table>
                                    <!-- END EXAMPLE TABLE PORTLET-->
                                </div>
                            </div>
                        </div>
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
<script src="../../assets/global/plugins/respond.min.js"></script>
<script src="../../assets/global/plugins/excanvas.min.js"></script> 
<script src="../../assets/global/plugins/ie8.fix.min.js"></script> 
<![endif]-->
    </div>
    </form>
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
    <!-- END PAGE LEVEL PLUGINS -->
    <!-- BEGIN THEME GLOBAL SCRIPTS -->
    <script src="../assets/global/scripts/app.min.js" type="text/javascript"></script>
    <script src="../assets/pages/scripts/components-date-time-pickers.min.js" type="text/javascript"></script>
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
</body>
</html>
