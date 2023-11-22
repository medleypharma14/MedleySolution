<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeGrid.aspx.cs" Inherits="HomeAlertsAdmin.Admin.EmployeeGrid" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/Admin/Header.ascx" %>
<%@ Register TagPrefix="usc2" TagName="Header2" Src="~/Admin/HeaderTop.ascx" %>
<%--<%@ Register TagPrefix="usc2" TagName="Header2" Src="ThemeHeader.ascx" %>--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en">
<!--<![endif]-->
<!-- BEGIN HEAD -->
<head>
    <meta charset="utf-8" />
    <title>Employee List</title>
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
    <script type="text/javascript">
        function Delete(PropertyTypeID) {

            var selectedText = $(PropertyTypeID).find("option:selected").text();

            if (confirm("Do You Want To Delete " + selectedText + " ?")) {
                $("#hfResponse").val('Yes');

                PageMethods.GoDeletePropertyType(PropertyTypeID, ongoacceptsuccess);

            } else {

                $("#hfResponse").val('No');
            }

            //            if (PropertyTypeID == "" || PropertyTypeID == null && UserID == "" || UserID == null) {

            //            }

            //            else {

            //                PageMethods.GoDeletePropertyType(PropertyTypeID, UserID, ongoacceptsuccess);

            //            }
            function ongoacceptsuccess(data) {

                if (data == "200") {

                    var url = location.protocol + '//' + location.host + "/../Admin/EmployeeGrid.aspx";
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
</head>
<!-- END HEAD -->
<%--<body class="page-container-bg-solid page-header-fixed page-sidebar-closed-hide-logo page-md page-sidebar-closed">--%>
<%--<body class="page-sidebar-closed-hide-logo page-container-bg-solid page-md">--%>
<body class="page-header-fixed page-sidebar-closed-hide-logo page-container-bg-solid page-md">
    <usc2:Header2 ID="Header1" runat="server" />
    <div class="clearfix">
    </div>
    <div class="page-container">
      <usc:Header ID="Header" runat="server" />
        <!-- BEGIN CONTENT -->
        <form id="f1" runat="server">
        <asp:ValidationSummary runat="server" HeaderText="Category Validation Messages:-"
            ValidationGroup="Validation" ID="val1" ShowMessageBox="true" ShowSummary="false" />
        <asp:ScriptManager ID="SM" runat="server" EnablePageMethods="true">
        </asp:ScriptManager>
        <div class="page-content-wrapper">
            <!-- BEGIN CONTENT BODY -->
            <div class="page-content">
                <div class="row">
                    <div class="col-md-12">
                        <!-- BEGIN VALIDATION STATES-->
                        <div class="portlet light portlet-fit portlet-form">
                            <div class="portlet-title">                                
                                <div class="pull-right">
                                    <asp:Button ID="btnSubmit" runat="server" Visible="true" class="btn blue" Text="Add New"
                                        OnClick="btnadd_OnClick" />
                                </div>
                            </div>
                            <div class="portlet-body">
                                <div class="portlet box green">
                                    <div class="portlet-title">
                                        <div class="caption font-dark">
                                            <i class="icon-settings font-dark"></i><span class="caption-subject bold uppercase">
                                                Employee List</span>
                                        </div>
                                    </div>
                                    <div class="portlet-body">
                                        <div class="table-toolbar">
                                        </div>
                                        <table class="table table-striped table-bordered table-hover table-checkable order-column"
                                            id="sample_2">
                                            <thead>
                                                <tr>
                                                    <th style="display: none">
                                                        <label class="mt-checkbox mt-checkbox-single mt-checkbox-outline">
                                                            <input type="checkbox" class="group-checkable" data-set="#sample_2 .checkboxes" />
                                                            <span></span>
                                                        </label>
                                                    </th>
                                                    <th>
                                                        Employee Name
                                                    </th>
                                                    <th>
                                                        Designation
                                                    </th>
                                                    <th>
                                                       User Name
                                                    </th>
                                                    <th>
                                                      Mobile
                                                    </th>
                                                    <th>
                                                       Email
                                                    </th>
                                                    <th>
                                                       Edit
                                                    </th>                                                 
                                                 <%-- <th>
                                                       Delete
                                                    </th>--%>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Label ID="lblTable" runat="server"></asp:Label>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- END VALIDATION STATES-->
                    </div>
                </div>
            </div>
            <!-- END CONTENT BODY -->
        </div>
        <!-- END CONTENT -->
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
    </div> </form>
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
    <!-- END PAGE LEVEL PLUGINS -->
    <!-- BEGIN THEME GLOBAL SCRIPTS -->
    <script src="../assets/global/scripts/app.min.js" type="text/javascript"></script>
    <!-- END THEME GLOBAL SCRIPTS -->
    <!-- BEGIN PAGE LEVEL SCRIPTS -->
    <script src="../assets/pages/scripts/components-select2.min.js" type="text/javascript"></script>
    <script src="../assets/pages/scripts/components-select2.min.js" type="text/javascript"></script>
    <script src="../assets/global/scripts/datatable.js" type="text/javascript"></script>
    <script src="../assets/global/plugins/datatables/datatables.min.js" type="text/javascript"></script>
    <script src="../assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.js"
        type="text/javascript"></script>
    <script src="../assets/pages/scripts/table-datatables-managed.min.js" type="text/javascript"></script>
    <!-- END PAGE LEVEL PLUGINS -->
    <!-- BEGIN THEME GLOBAL SCRIPTS -->
    <script src="../assets/global/scripts/app.min.js" type="text/javascript"></script>
    <!-- END THEME GLOBAL SCRIPTS -->
    <!-- BEGIN PAGE LEVEL SCRIPTS -->
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
