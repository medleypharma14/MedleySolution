we<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCustomer.aspx.cs" Inherits="Medly_Wm.AddCustomer" %>

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

    <style>
        .row {
            padding: 10px;
        }
    </style>

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
                            <div class="col-lg-12 ">
                                <!-- BEGIN SAMPLE FORM PORTLET-->
                                <div class="portlet light ">
                                    <div class="portlet-title">
                                        <div class="caption font-red-sunglo">
                                            <i class="icon-settings font-red-sunglo"></i>
                                            <span class="caption-subject bold uppercase">Add Customer</span>
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
                                    </div>
                                    <%--<div class="row" style="border: 1px solid skyblue">--%>
                                    <div class="col-lg-12">
                                        <div class="col-lg-6">
                                            
                                                <div class="col-lg-6">
                                                    <label>Customer ID</label>
                                                    <div class="input-group">
                                                        <span class="input-group-addon input-circle-left">
                                                            <i class="fa fa-user font-light skyblue"></i>
                                                        </span>
                                                        <%--<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator14" ControlToValidate="txtCustomerid"
                                                            ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Customer ID" Style="color: Red" />--%>
                                                        <asp:TextBox ID="txtCustomerid" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>

                                                <div class="col-lg-6">
                                                    <label>Initial addition date</label>
                                                    <div class="input-group">
                                                        <span class="input-group-addon input-circle-left">
                                                            <i class="fa fa-calendar"></i>
                                                        </span>
                                                        <%--<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtInitialadditiondate"
                                                            ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Initial additional date" Style="color: Red" />--%>
                                                        <asp:TextBox ID="txtInitialadditiondate" runat="server" CssClass="form-control" placeholder="06/02/2023" TextMode="Date"></asp:TextBox>
                                                    </div>
                                                </div>
                                           

                                           
                                                <div class="col-lg-12">
                                                    <label>Customer Name</label>
                                                    <div class="input-group">
                                                        <span class="input-group-addon input-circle-left">
                                                            <i class="fa fa-user font-light skyblue"></i>
                                                        </span>
                                                        <%--<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtCustomername"
                                                            ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Customer Name" Style="color: Red" />--%>
                                                        <asp:TextBox ID="txtCustomername" runat="server" CssClass="form-control" placeholder="Enter Name"></asp:TextBox>
                                                        <%--<label style="float: right">0 of 100 characters</label>--%>
                                                    </div>
                                                </div>
                                            

                                            
                                                <div class="col-lg-12">
                                                    <label>Contact Name</label>
                                                    <div class="input-group">
                                                        <span class="input-group-addon input-circle-left">
                                                            <i class="fa fa-user font-light skyblue"></i>
                                                        </span>
                                                        <%--<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="txtContactname"
                                                            ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Contact Name" Style="color: Red" />--%>
                                                        <asp:TextBox ID="txtContactname" runat="server" CssClass="form-control" placeholder="Enter Name"></asp:TextBox>
                                                        <%--<label style="float: right">0 of 100 characters</label>--%>
                                                    </div>
                                                </div>
                                            

                                            
                                                <div class="col-lg-12">
                                                    <label>Contact Email</label>
                                                    <div class="input-group">
                                                        <span class="input-group-addon">
                                                            <i class="fa fa-envelope"></i>
                                                        </span>
                                                        <%--<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" ControlToValidate="txtContactemail"
                                                            ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Contact Email" Style="color: Red" />--%>
                                                        <asp:TextBox ID="txtContactemail" runat="server" CssClass="form-control" placeholder="user@email.com"></asp:TextBox>
                                                    </div>
                                                </div>
                                           

                                            
                                                <div class="col-lg-4">
                                                    <label>Contact Number</label>
                                                    <div class="input-group">
                                                        <span class="input-group-addon input-circle-left">
                                                            <i class="fa fa-user font-light skyblue"></i>
                                                        </span>
                                                        <%--<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator5" ControlToValidate="ddlNumber"
                                                            ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Contact Number" Style="color: Red" />--%>
                                                        <asp:DropDownList ID="ddlNumber" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="">Country</asp:ListItem>
                                                            <asp:ListItem Text="1"></asp:ListItem>
                                                            <asp:ListItem Text="2"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-lg-8">
                                                    <label></label>
                                                    <div class="input-group">
                                                        <span class="input-group-addon input-circle-left">
                                                            <i class="fa fa-mobile"></i>
                                                        </span>
                                                        <asp:TextBox ID="txtContactNumber" runat="server" CssClass="form-control" placeholder="Enter Number" />
                                                    </div>
                                                </div>                                          
                                                <div class="col-lg-12">
                                                    <div class="col-lg-6">
                                                    <label>Valid till</label>
                                                    <div class="input-group">
                                                        <span class="input-group-addon input-circle-left">
                                                            <i class="fa fa-calendar"></i>
                                                        </span>
                                                        <%--<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator6" ControlToValidate="txtValidtill"
                                                            ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Valid Till" Style="color: Red" />--%>
                                                        <asp:TextBox ID="txtValidtill" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                                    </div>
                                                </div>

                                                <div class="col-lg-6">
                                                    <label>Default currency</label>
                                                    <div class="input-group">
                                                        <span class="input-group-addon input-circle-left">
                                                            <i class="fa fa-dollar"></i>
                                                        </span>
                                                    <%--<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator7" ControlToValidate="ddlDefaultcurrency"
                                                            ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Contact Number" Style="color: Red" />--%>
                                                    <asp:DropDownList ID="ddlDefaultcurrency" runat="server" CssClass="form-control">
                                                        <asp:ListItem Value="">Select</asp:ListItem>
                                                        <asp:ListItem Text="1"></asp:ListItem>
                                                        <asp:ListItem Text="2"></asp:ListItem>
                                                    </asp:DropDownList>
                                                        </div>
                                                </div>
                                                </div>
                                            
                                        </div>

                                        <div class="col-lg-6">
                                            
                                                <div class="col-lg-6">
                                                    <label>Customer Status</label>
                                                    <div class="input-group">
                                                        <span class="input-group-addon input-circle-left">
                                                            <i class="fa fa-user font-light skyblue"></i>
                                                        </span>
                                                        <%--<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator9" ControlToValidate="ddlCustomerstatus"
                                                            ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Customer Status" Style="color: Red" />--%>
                                                        <asp:DropDownList ID="ddlCustomerstatus" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="">Select</asp:ListItem>
                                                            <asp:ListItem Text="1"></asp:ListItem>
                                                            <asp:ListItem Text="2"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>

                                                <div class="col-lg-6">
                                                    <label>Customer Qualification</label>
                                                    <div class="input-group">
                                                        <span class="input-group-addon input-circle-left">
                                                            <i class="fa fa-user font-light skyblue"></i>
                                                        </span>
                                                        <%--<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator10" ControlToValidate="ddlCustomerqualification"
                                                            ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Customer Qualification" Style="color: Red" />--%>
                                                        <asp:DropDownList ID="ddlCustomerqualification" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="">Select</asp:ListItem>
                                                            <asp:ListItem Text="1"></asp:ListItem>
                                                            <asp:ListItem Text="2"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            

                                            <div class="col-lg-12">
                                                <label>Address Line 1</label>
                                                <div class="input-group">
                                                    <span class="input-group-addon input-circle-left">
                                                        <i class="fa fa-user font-light skyblue"></i>
                                                    </span>
                                                    <%--<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator11" ControlToValidate="txtAddressline1"
                                                        ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Address Line 1" Style="color: Red" />--%>
                                                    <asp:TextBox ID="txtAddressline1" runat="server" CssClass="form-control" Placeholder="Enter Name"></asp:TextBox>
                                                    <%--<label style="float: right">0 of 50 characters</label>--%>
                                                </div>
                                            </div>

                                            <div class="col-lg-12">
                                                <label>Address Line 2</label>
                                                <div class="input-group">
                                                    <span class="input-group-addon input-circle-left">
                                                        <i class="fa fa-user font-light skyblue"></i>
                                                    </span>
                                                    <asp:TextBox ID="txtAddressline2" runat="server" CssClass="form-control" Placeholder="Enter Name"></asp:TextBox>
                                                    <%--<label style="float: right">0 of 50 characters</label>--%>
                                                </div>
                                            </div>

                                            <div class="col-lg-12">
                                                <label>Address Line 3</label>
                                                <div class="input-group">
                                                    <span class="input-group-addon input-circle-left">
                                                        <i class="fa fa-user font-light skyblue"></i>
                                                    </span>
                                                    <asp:TextBox ID="txtAddressline3" runat="server" CssClass="form-control" Placeholder="Enter Name"></asp:TextBox>
                                                    <%--<label style="float: right">0 of 50 characters</label>--%>
                                                </div>
                                            </div>

                                           
                                                <div class="col-lg-6">
                                                    <label>Town</label>
                                                    <div class="input-group">
                                                        <span class="input-group-addon input-circle-left">
                                                            <i class="fa fa-user font-light skyblue"></i>
                                                        </span>
                                                        <%--<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator15" ControlToValidate="txtTown"
                                                            ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Town" Style="color: Red" />--%>
                                                        <asp:TextBox ID="txtTown" runat="server" CssClass="form-control" placeholder="Enter Text"></asp:TextBox>
                                                    </div>
                                                </div>

                                                <div class="col-lg-6">
                                                    <label>Country</label>
                                                    <div class="input-group">
                                                        <span class="input-group-addon input-circle-left">
                                                            <i class="fa fa-user font-light skyblue"></i>
                                                        </span>
                                                        <%--<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator16" ControlToValidate="ddlCountry"
                                                            ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Country" Style="color: Red" />--%>
                                                        <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="">Select</asp:ListItem>
                                                            <asp:ListItem Text="1"></asp:ListItem>
                                                            <asp:ListItem Text="2"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                           

                                            <div class="col-lg-12">
                                                <label>Post code</label>
                                                <div class="input-group">
                                                    <span class="input-group-addon input-circle-left">
                                                        <i class="fa fa-user font-light skyblue"></i>
                                                    </span>
                                                    <%--<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator17" ControlToValidate="txtPostcode"
                                                        ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Post Code" Style="color: Red" />--%>
                                                    <asp:TextBox ID="txtPostcode" runat="server" CssClass="form-control" placeholder="Enter Number"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <%--<div class="" style="border: 1px solid lightgray">
                                                </div>--%>
                                   
                                        <div class="col-lg-6">
                                           
                                                <label>Select Approver</label> 

                                                    <%--<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator8" ControlToValidate="ddlSelectapprover"
                                                        ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Contact Number" Style="color: Red" />--%>
                                            
                                           
                                                <div class="input-group">
                                                    <span class="input-group-addon input-circle-left">
                                                        <i class="fa fa-user font-light skyblue"></i>
                                                    </span>
                                                    <asp:DropDownList ID="ddlSelectapprover" runat="server" CssClass="form-control" placeholder="Select">
                                                        <asp:ListItem Value="">Select</asp:ListItem>
                                                        <asp:ListItem Text="1"></asp:ListItem>
                                                        <asp:ListItem Text="2"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                </div>

                                    <%-- </div>--%>

                                    <div class="row">
                                        <center>
                                            <div class="col-lg-12">
                                                    <asp:Button ID="btnCancel" runat="server" class="btn red" Text="Cancel"/>
                                                    <asp:Button ID="btnClear" runat="server" class="btn default" Text="Clear" />
                                                    <asp:Button ID="btnSave" runat="server" class="btn blue" Text="Save" ValidationGroup="Validation" OnClick="btnSave_Click"  />
                                            </div>
                                        </center>
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

