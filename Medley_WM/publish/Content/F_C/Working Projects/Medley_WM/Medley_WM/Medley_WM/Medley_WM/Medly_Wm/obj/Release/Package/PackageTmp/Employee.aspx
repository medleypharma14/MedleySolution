<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="Medly_Wm.Employee" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/Header.ascx" %>
<%@ Register TagPrefix="usc1" TagName="Sidebar" Src="~/Sidebar.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Employee Master</title>
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
        .auto-style1 {
            font-size: 14px;
            line-height: 1.42857;
            color: #555;
            display: block;
            width: 100%;
            height: 34px;
            border-radius: 4px;
            -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075);
            box-shadow: none !important;
            -webkit-transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
            -o-transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
            transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
            outline-width: 0;
            outline-style: none;
            outline-color: invert;
            left: 0px;
            top: 0px;
            border: 1px solid #c2cad8;
            padding: 6px 12px;
            background-color: #fff;
            background-image: none;
        }
        label{
            font-weight: bold;
        }
    </style>
   <script type="text/javascript">
       function isNumberKey(evt) {
           var charCode = (evt.which) ? evt.which : event.keyCode;
           if (charCode > 31 && (charCode < 48 || charCode > 57))
               return false;
           return true;
       }
   </script>
</head>
<body class="page-header-fixed page-sidebar-closed-hide-logo page-container-bg-solid page-md">
    <usc1:Sidebar ID="h1" runat="server" />
    <div class="page-container">
        <usc:Header ID="Header" runat="server" />
        <div class="page-content-wrapper">
            <!-- BEGIN CONTENT BODY --> 
            <div class="page-content">
                <form id="form2" runat="server">
                            <div class="portlet box green">
                                <div class="portlet-title">
                                    <div class="caption">
                                        <i class="fa fa-cogs"></i>Create New Employee
                                    </div>

                                </div>
                                <div class="portlet-body flip-scroll">

                                    <div class="portlet light " style="height: 800px">
                                        <div class="form-body">
                                            <div class="col-lg-12">

                                                <div class="col-lg-6">
                                                    <div class="form-group">
                                                        <label>Employee ID</label>
                                                        <div class="input-group">
                                                            <span class="input-group-addon input-square-left">
                                                                <i class="fa fa-user"></i>
                                                            </span>

                                                            <%--<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator14" ControlToValidate="txtsupplierid"
                                                        ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Supplier ID" Style="color: Red" />--%>
                                                            <asp:TextBox ID="txtEmployeeid" runat="server" CssClass="form-control" placeholder="EmployeeID" ReadOnly="True"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-6">
                                                    <div class="form-group">
                                                        <label>
                                                            Employee Name
                                                         <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator14" ControlToValidate="txtEmployeename"
                                                             ValidationGroup="Validation" Text="*" ErrorMessage="*" Style="color: Red" />
                                                        </label>
                                                        <div class="input-group">
                                                            <span class="input-group-addon input-square-left">
                                                                <i class="fa fa-user"></i>
                                                            </span>
                                                            <asp:TextBox ID="txtEmployeename"  runat="server" CssClass="form-control" placeholder="Enter Your Name..."></asp:TextBox>
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>

                                        </div>
                                        <div class="col-lg-12">

                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label>
                                                        Date Of Birth
                                                   <asp:RequiredFieldValidator runat="server" ID="dobcheck" ControlToValidate="txtDob"
                                                       ValidationGroup="Validation" Text="*" ErrorMessage="*" Style="color: Red" />
                                                    </label>
                                                    <div class="input-group">
                                                        <span class="input-group-addon input-square-left">
                                                            <i class="fa fa-calendar"></i>
                                                        </span>

                                                        <asp:TextBox ID="txtDob" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>



                                            <div class="col-lg-3">
                                                <label>
                                                    Date Of Joining
                                               <asp:RequiredFieldValidator runat="server" ID="dojcheck" ControlToValidate="txtDoj"
                                                   ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Supplier ID" Style="color: Red" />
                                                </label>
                                                <div class="input-group">
                                                    <span class="input-group-addon input-square-left">
                                                        <i class="fa fa-calendar"></i>
                                                    </span>


                                                    <asp:TextBox ID="txtDoj" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                                </div>

                                            </div>


                                            <div class="col-lg-6">
                                                <label>
                                                    Gender
                                                  <asp:RequiredFieldValidator runat="server" ID="gendercheck" ControlToValidate="rbgender"
                                                      ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Supplier ID" Style="color: Red" />
                                                </label>
                                                <div class="input-group">
                                                    <%-- <span class="input-group-addon input-circle-left">
                                                    <i class="fa fa-user"></i>
                                                </span>--%>
                                                    <asp:RadioButtonList ID="rbgender" runat="server" RepeatDirection="Horizontal">
                                                        <asp:ListItem>Male</asp:ListItem>
                                                        <asp:ListItem>Female</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>

                                            </div>

                                        </div>

                                        <div class="col-lg-12">
                                            <div class="col-lg-6">
                                                <div class="form-group">
                                                    <label>Designation</label>
                                                   <asp:CompareValidator ID="CompareValidator4" runat="server" ValidationGroup="Validation"
                                                    Text="*" Style="color: Red" InitialValue="0" ControlToValidate="ddlDesignation" ValueToCompare="Select"
                                                    Operator="NotEqual" Type="String" ErrorMessage="Please Select Designation."></asp:CompareValidator>
                                                    <div class="input-group">
                                                        <span class="input-group-addon input-square-left">
                                                            <i class="fa fa-graduation-cap"></i>
                                                        </span>
                                                        <asp:DropDownList ID="ddlDesignation" runat="server" CssClass="form-control"
                                                            placeholder="Select">
                                                            <asp:ListItem Value="">Select</asp:ListItem>
                                                            <asp:ListItem Text="Manager"></asp:ListItem>
                                                            <asp:ListItem Text="Supervisor"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="form-group">
                                                    <label>
                                                        Email
                                                    <asp:RegularExpressionValidator ValidationGroup="Validation" runat="server" ID="regexEmail" ControlToValidate="txtEmail"
                                                         ValidationExpression="^[\w\.-]+@[\w\.-]+\.\w{2,4}$" Text="*"
                                                         ErrorMessage="Please enter a valid email address" Style="color: Red" />
                                                    </label>
                                                    <div class="input-group">
                                                        <span class="input-group-addon input-square-left">
                                                            <i class="fa fa-envelope"></i>
                                                        </span>
                                                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Enter Your Email..."></asp:TextBox>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>

                                        <div class="col-lg-12">
                                            <div class="col-lg-6">
                                                <label>
                                                    Phone Number
                                                 <asp:RequiredFieldValidator ID="regexValidator" runat="server" ControlToValidate="txtPhonenumber" ValidationExpression="^\d+$"
                                                      ValidationGroup="Validation" Text="*" ErrorMessage="*" Style="color: Red" />
                                                </label>
                                                <div class="input-group">
                                                    <span class="input-group-addon input-square-left">
                                                        <i class="fa fa-phone"></i>
                                                    </span>
                                                    <asp:TextBox ID="txtPhonenumber" AutoPostBack="true" OnTextChanged="txtPhonenumber_TextChanged" runat="server" CssClass="form-control" MaxLength="10" placeholder="Enter Your Phone Number..." onkeypress="return isNumberKey(event)"></asp:TextBox>
                                                </div>
                                                   </div>
                                            <div class="col-lg-6">
                                                <label>Address
                                                     <asp:RequiredFieldValidator runat="server" ID="checkaddress" ControlToValidate="txtAddress"
                                                        ValidationGroup="Validation" Text="*" ErrorMessage="*" Style="color: Red" />
                                                </label>
                                                <div class="input-group">
                                                    <span class="input-group-addon input-square-left">
                                                        <i class="fa-solid fa-address-card"></i>
                                                    </span>
                                                    <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" placeholder="Enter Your Address..." TextMode="MultiLine"></asp:TextBox>
                                                </div>

                                            </div>
                                        </div>
                                        <div class="col-lg-12">
                                            <div class="col-lg-6">
                                                <label>Create User Name
                                                     <asp:RequiredFieldValidator runat="server" ID="checkusername" ControlToValidate="txtUsername"
                                                        ValidationGroup="Validation" Text="Please Enter Username" ErrorMessage="Please Enter Username" Style="color: Red" />
                                                </label>
                                                <div class="input-group">
                                                    <span class="input-group-addon input-square-left">
                                                        <i class="fa fa-user"></i>
                                                    </span>                                              
                                                    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Create User Name..."></asp:TextBox>
                                                </div>

                                            </div>
                                            <div class="col-lg-6">
                                                <label>Create Password
                                                     <asp:RequiredFieldValidator runat="server" ID="checkpassword" ControlToValidate="txtPassword"
                                                        ValidationGroup="Validation" Text="Create Password" ErrorMessage="Create Password" Style="color: Red" />
                                                </label>
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        <i class="fa fa-key"></i>
                                                    </span>
                                                   <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Create Password..." TextMode="Password"></asp:TextBox>
                                                </div>

                                            </div>
                                        </div>


                                        <div class="col-lg-12" style="margin-top: 10px;">
                                            <center>

                                                <%--<asp:Button ID="btsclear" Text="Clear" runat="server" CssClass="btn default" PostBackUrl="~/Employee.aspx" />--%>
                                                <asp:Button Text="Submit" ID="btnSubmit" Class="btn red" ValidationGroup="Validation" runat="server" OnClick="btnSubmit_Click" />
                                                <asp:Button ID="btncancel" Text="Cancel" runat="server" CssClass="btn default" PostBackUrl="~/EmployeeGridpage.aspx" />
                                            </center>

                                        </div>
                                    </div>
                                </div>

                            </div>
                </form>
            </div>
        </div>

    </div>

    <!-- BEGIN CORE PLUGINS -->
    <%-- <script src="assets/global/plugins/jquery.min.js" type="text/javascript"></script>
    <script src="assets/global/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="assets/global/plugins/js.cookie.min.js" type="text/javascript"></script>
    <script src="assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js" type="text/javascript"></script>
    <script src="assets/global/plugins/jquery.blockui.min.js" type="text/javascript"></script>
    <script src="assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js" type="text/javascript"></script>
    <!-- END CORE PLUGINS -->
    <!-- BEGIN THEME GLOBAL SCR -->
    <script src="assets/global/scripts/app.js" type="text/javascript"></script>
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
    </script> --%>
</body>
</html>
