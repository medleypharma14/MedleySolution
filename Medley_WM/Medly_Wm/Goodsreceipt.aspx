﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Goodsreceipt.aspx.cs" Inherits="Supplier.Goodsreceipt" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/Header.ascx" %>
<%@ Register TagPrefix="usc1" TagName="Sidebar" Src="~/Sidebar.ascx" %>

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
    <title>Metronic Admin Theme #2 | Bootstrap Form Controls</title>
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



</head>

<body class="page-header-fixed page-sidebar-closed-hide-logo page-container-bg-solid page-md">

    <usc1:Sidebar ID="h1" runat="server" />
    <div class="page-container">

        <usc:Header ID="Header" runat="server" />
        <div class="page-content-wrapper">
            <!-- BEGIN CONTENT BODY -->
            <div class="page-content">

                <form id="form1" runat="server">
                    <div>
                        <div class="row">
                            <div class="col-md-12 ">
                                <!-- BEGIN SAMPLE FORM PORTLET-->
                                <div class="portlet light ">
                                    <div class="portlet-title">
                                        <div class="caption font-red-sunglo">
                                            <i class="icon-settings font-red-sunglo"></i>
                                            <span class="caption-subject bold uppercase">Add goods receipt</span>
                                        </div>
                                        <div class="actions">
                                            <div class="btn-group">
                                                <a class="btn btn-sm green dropdown-toggle" href="javascript:;" data-toggle="dropdown">Actions
                                                <i class="fa fa-angle-down"></i>
                                                </a>
                                                <ul class="dropdown-menu pull-right">
                                                    <li>
                                                        <a href="javascript:;">
                                                            <i class="fa fa-pencil"></i>Edit </a>
                                                    </li>
                                                    <li>
                                                        <a href="javascript:;">
                                                            <i class="fa fa-trash-o"></i>Delete </a>
                                                    </li>
                                                    <li>
                                                        <a href="javascript:;">
                                                            <i class="fa fa-ban"></i>Ban </a>
                                                    </li>
                                                    <li class="divider"></li>
                                                    <li>
                                                        <a href="javascript:;">Make admin </a>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="portlet-body form">
                                        <form role="form">
                                            <div class="form-body">
                                                <div class="row" style="float: right;">
                                                    <label>GRN number</label>
                                                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                                </div>

                                                <div class="row" style="padding: 30px">
                                                    <div class="col-lg-12">
                                                        <div class="col-lg-3">
                                                            <label>Purchase order number:PO54320</label>
                                                        </div>

                                                        <div class="col-lg-3">
                                                            <label>Product ID:P43232</label>
                                                        </div>

                                                        <div class="col-lg-3">
                                                            <label>Licence Number:232323</label>
                                                        </div>

                                                        <div class="col-lg-3">
                                                            <label>Dosage Form:PO54320</label>
                                                        </div>
                                                    </div>

                                                    <div class="col-lg-12">
                                                        <div class="col-lg-2">
                                                            <label>Product name:parsacol</label>
                                                        </div>

                                                        <div class="col-lg-2">
                                                            <label>Strength:40mg</label>
                                                        </div>

                                                        <div class="col-lg-2">
                                                            <label>Pack type:Script</label>
                                                        </div>

                                                        <div class="col-lg-2">
                                                            <label>Pack size:10</label>
                                                        </div>

                                                        <div class="col-lg-2">
                                                            <label>Order quantity:20</label>
                                                        </div>

                                                        <div class="col-lg-2">
                                                            <label>Order difference:20</label>
                                                        </div>
                                                    </div>


                                                    <div class="col-lg-12" style="border: 2px solid skyblue">
                                                       <div>
                                                            <div class="col-lg-12" style="padding-top: 50px;">
                                                            <div class="col-lg-2">
                                                                <label>Batch Number</label>
                                                                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
                                                            </div>

                                                            <div class="col-lg-2">
                                                                <label>Received quantity</label>
                                                                <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"></asp:TextBox>
                                                            </div>

                                                            <div class="col-lg-2">
                                                                <label>Manufacturing date</label>
                                                                <asp:TextBox ID="TextBox4" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                                                            </div>

                                                            <div class="col-lg-2">
                                                                <label>Expiry date</label>
                                                                <asp:TextBox ID="TextBox5" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                                                            </div>

                                                            <div class="col-lg-2">
                                                                <label>No of pallets</label>
                                                                <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control"></asp:TextBox>
                                                            </div>

                                                            <div class="col-lg-2">
                                                                <label>Batch status</label>
                                                                <asp:DropDownList ID="ddlbatchstatus" runat="server" CssClass="form-control">
                                                                    <asp:ListItem Value="">Select</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>

                                                        </div>
                                                       </div>

                                                        <div class="col-lg-12" style="margin-top:20px; border:2px solid skyblue">
                                                            <div>
                                                                <div class="col-lg-12" style="padding-top: 10px;">
                                                            <div class="col-lg-6">
                                                                <div class="col-lg-3" style="float: left; padding-top: 10px;">
                                                                    <label>Select warehouse</label>
                                                                </div>
                                                                <div class="col-lg-3">
                                                                    <asp:DropDownList ID="ddlwarehouse" runat="server" CssClass="form-control">
                                                                        <asp:ListItem Value="">Select</asp:ListItem>
                                                                        <asp:ListItem Value="">MAS</asp:ListItem>
                                                                        <asp:ListItem Value="">MDU</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-6" style="float: right; padding-top: 7px;">
                                                                <label><b>Asile</b></label>
                                                                <asp:LinkButton ID="LinkButton1" runat="server"><< </asp:LinkButton>
                                                                <asp:LinkButton ID="LinkButton2" runat="server">< </asp:LinkButton>

                                                                <asp:LinkButton ID="LinkButton10" runat="server">></asp:LinkButton>
                                                                <asp:LinkButton ID="LinkButton11" runat="server">>></asp:LinkButton>
                                                            </div>
                                                        </div>
                                                        </div>
                                                        


                                                        <div class="col-lg-12">
                                                            <div style="height: 200px; overflow-x: scroll;">
                                                            </div>
                                                            <div class="col-lg-4" style="padding: 30px">
                                                                <label>Selected units:- </label>
                                                            </div>

                                                            <div class="col-lg-4" style="padding: 30px">
                                                                <label>Unit quantity</label>
                                                                <asp:TextBox ID="untiquantity" runat="server" placeholder="Enter number"></asp:TextBox>
                                                            </div>

                                                            <div class="col-lg-4" style="padding: 30px">
                                                                <label>Palate refernce number</label>
                                                                <asp:TextBox ID="TextBox7" runat="server" placeholder="Enter number"></asp:TextBox>
                                                            </div>
                                                        </div>

                                                        </div>

                                                        <div class="col-lg-12" style="padding-top: 20px">
                                                            <div class="panel" style="border: 1px solid lightgray">
                                                            </div>

                                                            <div style="float: left; padding-top: 7px; margin-left: 150px;">
                                                                <label>Select Approver: </label>
                                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator8" ControlToValidate="ddlselectapprover"
                                                                    ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Contact Number" Style="color: Red" />
                                                            </div>
                                                            <div style="float: right; margin-right: 695px;">
                                                                <asp:DropDownList ID="ddlselectapprover" runat="server" CssClass="form-control" placeholder="Select" Width="320px">
                                                                    <asp:ListItem Value="">Select</asp:ListItem>
                                                                    <asp:ListItem Text="Manager"></asp:ListItem>
                                                                    <asp:ListItem Text="Client"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>

                                                        </div>
                                                    
                                                </div>
                                                <div class="row">
                                                    <center>
                                                        <div class="col-lg-12" style="padding-top: 10px">
                                                            <div cl="col-lg-12" style="padding-top: 20px">
                                                                <!--<button type="submit" class="btn blue">Submit</button>-->
                                                                <asp:Button ID="btncancel" runat="server" class="btn grey" Text="Cancel" Style="float: left" />
                                                                <asp:Button ID="btndraft" runat="server" class="btn yellow" Text="Save as Draft" Style="float: left" Width="160px" />

                                                                <asp:Button ID="btnsubmit" runat="server" class="btn blue" Text="Submit" Style="float: right" ValidationGroup="Validation" />
                                                            </div>

                                                        </div>
                                                    </center>
                                                </div>
                                        </form>
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
    <!-- BEGIN CORE PLUGINS -->
    <script src="assets/global/plugins/jquery.min.js" type="text/javascript"></script>
    <script src="assets/global/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="assets/global/plugins/js.cookie.min.js" type="text/javascript"></script>
    <script src="assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js" type="text/javascript"></script>
    <script src="assets/global/plugins/jquery.blockui.min.js" type="text/javascript"></script>
    <script src="assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js" type="text/javascript"></script>
    <!-- END CORE PLUGINS -->
    <!-- BEGIN THEME GLOBAL SCRIPTS -->
    <script src="assets/global/scripts/app.min.js" type="text/javascript"></script>
    <!-- END THEME GLOBAL SCRIPTS -->
    <!-- BEGIN THEME LAYOUT SCRIPTS -->
    <script src="assets/layouts/layout2/scripts/layout.min.js" type="text/javascript"></script>
    <script src="assets/layouts/layout2/scripts/demo.min.js" type="text/javascript"></script>
    <script src="assets/layouts/global/scripts/quick-sidebar.min.js" type="text/javascript"></script>
    <script src="assets/layouts/global/scripts/quick-nav.min.js" type="text/javascript"></script>
    <!-- END THEME LAYOUT SCRIPTS -->
    <script>
        $(document).ready(function () {
            $('#clickmewow').click(function () {
                $('#radio1003').attr('checked', 'checked');
            });
        })
    </script>
</body>
</html>
