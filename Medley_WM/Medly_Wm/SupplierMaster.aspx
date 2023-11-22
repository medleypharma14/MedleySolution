<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupplierMaster.aspx.cs" Inherits="Medly_Wm.SupplierMaster" %>


<%@ Register TagPrefix="usc" TagName="Header" Src="~/Header.ascx" %>
<%@ Register TagPrefix="usc1" TagName="Sidebar" Src="~/Sidebar.ascx" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Supplier/Cutomer Master</title>
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
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
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
       label{
           font-weight:bold;
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

                <form id="form1" runat="server">

                    <div class="row">
                        <div class="auto-style2">
                            <!-- BEGIN SAMPLE FORM PORTLET-->
                            <div class="portlet light ">
                                <div class="portlet-title">
                                    <div class="caption font-red-sunglo">
                                        <i class="icon-settings font-red-sunglo"></i>
                                        <span class="caption-subject bold uppercase">Add Supplier / Customer</span>
                                    </div>

                                </div>
                                <div class="form-body">
                                    <div>
                                        <div class="col-lg-12">
                                            <div class="col-lg-2">
                                                <div class="form-group">
                                                    <label>
                                                        Supplier ID
                                                    </label>
                                                    <div class="input-group">
                                                        <span class="input-group-addon input-square-left">
                                                            <i class="fa fa-user"></i>
                                                        </span>
                                                        <%--<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator14" ControlToValidate="txtsupplierid"
                                                        ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Supplier ID" Style="color: Red" />--%>
                                                        <asp:TextBox ID="txtsupplierid" runat="server" CssClass="form-control" placeholder="SupplierID" ReadOnly="True"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-3">
                                                <label>
                                                    Initial additional date
                                                       <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtadditionaldate"
                                                           ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Initial additional date" Style="color: Red" />
                                                </label>
                                                <div class="form-group">
                                                    <div class="input-group">
                                                        <span class="input-group-addon input-square-left">
                                                            <i class="fa fa-calendar"></i>
                                                        </span>

                                                        <asp:TextBox ID="txtadditionaldate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <label>
                                                        Company Name
                                                           <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="txtcompanyname"
                                                               ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Initial additional date" Style="color: Red" />
                                                    </label>
                                                    <div class="input-group">
                                                        <span class="input-group-addon input-square-left">
                                                            <i class="fa fa-building"></i>
                                                        </span>
                                                        <asp:TextBox ID="txtcompanyname" runat="server" CssClass="form-control" placeholder="Enter Name"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label>
                                                        Valid Till
                                                         <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator6" ControlToValidate="txtvalidtill"
                                                             ValidationGroup="Validation" Text="Select Expiry Date" ErrorMessage="Please Enter Contact Number" Style="color: Red" />
                                                    </label>
                                                    <div class="input-group">
                                                        <span class="input-group-addon input-square-left">
                                                            <i class="fa fa-calendar"></i>
                                                        </span>

                                                        <asp:TextBox ID="txtvalidtill" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="portlet-title">
                                            <div class="caption font-red-sunglo">
                                                <i class="icon-settings font-red-sunglo"></i>
                                                <span class="caption-subject bold uppercase">Add Contact Person</span><br />
                                            </div>

                                        </div>
                                        <br />
                                        <div class="" style="border-inline: medium" id="divContact1" runat="server">

                                            <div class="col-lg-12">
                                                <div class="col-lg-3">
                                                    <div class="form-group">
                                                        <label>
                                                            Primary Contact Name
                                                             <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator9" ControlToValidate="txtcontactname"
                                                                 ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Contact Number" Style="color: Red" />
                                                        </label>
                                                        <div class="input-group">
                                                            <span class="input-group-addon input-square-left">
                                                                <i class="fa fa-user"></i>
                                                            </span>

                                                            <asp:TextBox ID="txtcontactname" runat="server" CssClass="form-control" placeholder="Enter Name"></asp:TextBox>
                                                            <%-- <label style="float: right">0 of 100 characters</label>--%>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-3">
                                                    <div class="form-group">
                                                        <label>
                                                            Contact Email
                                                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtcontactemail"
                                                                ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Contact Number" Style="color: Red" />
                                                        </label>
                                                        <div class="input-group">
                                                            <span class="input-group-addon input-square-left">
                                                                <i class="fa fa-envelope"></i>
                                                            </span>
                                                            <%--   <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" ControlToValidate="txtcontactemail"
                                                        ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Contact Email" Style="color: Red" />--%>
                                                            <asp:TextBox ID="txtcontactemail" runat="server" CssClass="form-control" placeholder="user@email.com"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <label>Contact Number</label>
                                                        <div class="input-group">
                                                            <span class="input-group-addon input-square-left">
                                                                <i class="fa fa-globe"></i>
                                                            </span>
                                                            <%--<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator5" ControlToValidate="ddlNumber"
                                                            ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Contact Number" Style="color: Red" />--%>
                                                            <asp:DropDownList ID="ddlNumber" runat="server" CssClass="form-control" placeholder="Country">
                                                                <asp:ListItem Text="Code"></asp:ListItem>
                                                                <asp:ListItem Text="+1"></asp:ListItem>
                                                                <asp:ListItem Text="+44"></asp:ListItem>
                                                                <asp:ListItem Text="+91"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-3">

                                                    <label>
                                                          <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator5" ControlToValidate="txtContactnumber"
                                                            ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Contact Number" Style="color: Red" />
                                                    </label>
                                                    <div class="input-group">
                                                        <span class="input-group-addon input-square-left">
                                                            <i class="fa fa-globe"></i>
                                                        </span>
                                                        <asp:TextBox ID="txtContactnumber" runat="server" CssClass="form-control" AutoPostBack="true" placeholder="Enter Number" MaxLength="10"  onkeypress="return isNumberKey(event)" OnTextChanged="txtContactnumber_TextChanged"/>
                                                    </div>
                                                </div>

                                            </div>
                                            <div class="col-lg-12">
                                                <div class="col-lg-6">
                                                    <div class="form-group">
                                                        <label>Address Line 1
                                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator11" ControlToValidate="txtaddressline1"
                                                    ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Address Line 1" Style="color: Red" />
                                                        </label>
                                                        <div class="input-group">
                                                            <span class="input-group-addon input-square-left">
                                                                <i class="fa fa-address-card"></i>
                                                            </span>
                                                            <asp:TextBox ID="txtaddressline1" runat="server" TextMode="MultiLine" CssClass="form-control" AutoPostBack="false" Placeholder="Address"></asp:TextBox>
                                                            <%-- <label style="float: right">0 of 50 characters</label>--%>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <label>Country</label>
                                                        <div class="input-group">
                                                            <span class="input-group-addon input-square-left">
                                                                <i class="fa fa-globe"></i>
                                                            </span>

                                                            <asp:DropDownList ID="ddlcountry" runat="server" CssClass="form-control" placeholder="Select">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>

                                                </div>
                                                <div class="col-lg-2">
                                                    <label>Post Code
                                                         <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" ControlToValidate="txtposcode"
                                                    ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Address Line 1" Style="color: Red" />
                                                    </label>
                                                    <div class="input-group">
                                                        <span class="input-group-addon input-square-left">
                                                            <i class="fa fa-map"></i>
                                                        </span>

                                                        <asp:TextBox ID="txtposcode" runat="server" CssClass="form-control" placeholder="Enter Number"></asp:TextBox>
                                                    </div>


                                                </div>
                                                <div class="col-lg-1">
                                                    <div class="form-group">
                                                        <label></label>
                                                        <div class="input-group">

                                                            <asp:ImageButton ImageUrl="Images/plusbtn1.png" ID="addname" runat="server" OnClick="addname_Click" Height="35px" Width="35px" />

                                                        </div>
                                                    </div>
                                                </div>
                                               <%-- <div class="col-lg-1">
                                                    <div class="form-group">
                                                        <label></label>
                                                        <div class="input-group">

                                                            <asp:ImageButton ImageUrl="Images/minus.png" ID="minesname" runat="server" OnClick="minesname_Click" Height="30px" Width="30px" />

                                                        </div>
                                                    </div>
                                                </div>--%>

                                            </div>
                                        </div>

                                        <div class="" style="border-inline: medium" id="divContact2" runat="server" visible="false">

                                            <div class="col-lg-12">
                                                <div class="col-lg-3">
                                                    <div class="form-group">
                                                        <label>Contact Name - 2
                                                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator7" ControlToValidate="txtCName1"
                                                    ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Address Line 1" Style="color: Red" />
                                                        </label>
                                                        <div class="input-group">
                                                            <span class="input-group-addon input-square-left">
                                                                <i class="fa fa-user"></i>
                                                            </span>

                                                            <asp:TextBox ID="txtCName1" runat="server" CssClass="form-control" placeholder="Enter Name"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-3">
                                                    <div class="form-group">
                                                        <label>Contact Email
                                                             <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator8" ControlToValidate="txtCEmail1"
                                                    ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Address Line 1" Style="color: Red" />
                                                        </label>
                                                        <div class="input-group">
                                                            <span class="input-group-addon input-square-left">
                                                                <i class="fa fa-envelope"></i>
                                                            </span>

                                                            <asp:TextBox ID="txtCEmail1" runat="server" CssClass="form-control" placeholder="user@email.com"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <label>Contact Number 2
                                                        </label>
                                                        <div class="input-group">
                                                            <span class="input-group-addon input-square-left">
                                                                <i class="fa fa-globe"></i>
                                                            </span>

                                                            <asp:DropDownList ID="ddlCCode1" runat="server" CssClass="form-control" placeholder="Country">
                                                                <asp:ListItem Text="Code"></asp:ListItem>
                                                                <asp:ListItem Text="+1"></asp:ListItem>
                                                                <asp:ListItem Text="+44"></asp:ListItem>
                                                                <asp:ListItem Text="+91"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-3">

                                                    <label>
                                                          <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator10" ControlToValidate="txtCNumber1"
                                                    ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Address Line 1" Style="color: Red" />
                                                    </label>
                                                    <div class="input-group">
                                                        <span class="input-group-addon input-square-left">
                                                            <i class="fa fa-globe"></i>
                                                        </span>
                                                        <asp:TextBox ID="txtCNumber1" runat="server" CssClass="form-control" AutoPostBack="true" placeholder="Enter Number"  MaxLength="10"  onkeypress="return isNumberKey(event)" OnTextChanged="txtCNumber1_TextChanged"/>
                                                    </div>
                                                </div>

                                            </div>
                                            <div class="col-lg-12">
                                                <div class="col-lg-6">
                                                    <div class="form-group">
                                                        <label>Address Line
                                                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator12" ControlToValidate="txtCAddress1"
                                                    ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Address Line 1" Style="color: Red" />
                                                        </label>
                                                        <div class="input-group">
                                                            <span class="input-group-addon input-square-left">
                                                                <i class="fa fa-address-card"></i>
                                                            </span>

                                                            <asp:TextBox ID="txtCAddress1" runat="server" TextMode="MultiLine" CssClass="form-control" AutoPostBack="false" Placeholder="Address"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <label>Country</label>
                                                        <div class="input-group">
                                                            <span class="input-group-addon input-square-left">
                                                                <i class="fa fa-globe"></i>
                                                            </span>

                                                            <asp:DropDownList ID="ddlCCountry1" runat="server" CssClass="form-control" placeholder="Select">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>

                                                </div>
                                                <div class="col-lg-2">
                                                    <label>Post Code
                                                         <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator13" ControlToValidate="txtCPost1"
                                                    ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Address Line 1" Style="color: Red" />
                                                    </label>
                                                    <div class="input-group">
                                                        <span class="input-group-addon input-square-left">
                                                            <i class="fa fa-map"></i>
                                                        </span>

                                                        <asp:TextBox ID="txtCPost1" runat="server" CssClass="form-control" placeholder="Enter Number"></asp:TextBox>
                                                    </div>

                                                </div>
                                                <div class="col-lg-1">
                                                    <div class="form-group">
                                                        <label></label>
                                                        <div class="input-group">


                                                            <asp:ImageButton ImageUrl="Images/plusbtn1.png" ID="ImageButton4" runat="server" OnClick="addname1_Click" Height="35px" Width="35px" />

                                                        </div>
                                                    </div>
                                                </div> 
                                                <div class="col-lg-1">
                                                    <div class="form-group">
                                                        <label></label>
                                                        <div class="input-group">

                                                            <asp:ImageButton ImageUrl="Images/minus.png" ID="minusname2" runat="server" OnClick="minusname2_Click" Height="30px" Width="30px" />

                                                        </div>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>


                                        <div class="" style="border-inline: medium" id="divContact3" runat="server" visible="false">

                                            <div class="col-lg-12">
                                                <div class="col-lg-3">
                                                    <div class="form-group">
                                                        <label>Contact Name - 3
                                                              <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator14" ControlToValidate="txtCName2"
                                                    ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Address Line 1" Style="color: Red" />
                                                        </label>
                                                        <div class="input-group">
                                                            <span class="input-group-addon input-square-left">
                                                                <i class="fa fa-user"></i>
                                                            </span>

                                                            <asp:TextBox ID="txtCName2" runat="server" CssClass="form-control" placeholder="Enter Name"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-3">
                                                    <div class="form-group">
                                                        <label>Contact Email
                                                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator15" ControlToValidate="txtCEmail2"
                                                    ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Address Line 1" Style="color: Red" />
                                                        </label>
                                                        <div class="input-group">
                                                            <span class="input-group-addon input-square-left">
                                                                <i class="fa fa-envelope"></i>
                                                            </span>

                                                            <asp:TextBox ID="txtCEmail2" runat="server" CssClass="form-control" placeholder="user@email.com"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <label>Contact Number 3
                                                        </label>
                                                        <div class="input-group">
                                                            <span class="input-group-addon input-square-left">
                                                                <i class="fa fa-globe"></i>
                                                            </span>

                                                            <asp:DropDownList ID="ddlCCode2" runat="server" CssClass="form-control" placeholder="Country">
                                                                <asp:ListItem Text="Code"></asp:ListItem>
                                                                <asp:ListItem Text="+1"></asp:ListItem>
                                                                <asp:ListItem Text="+44"></asp:ListItem>
                                                                <asp:ListItem Text="+91"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-3">

                                                    <label>
                                                          <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator16" ControlToValidate="txtCNumber2"
                                                    ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Address Line 1" Style="color: Red" />
                                                    </label>
                                                    <div class="input-group">
                                                        <span class="input-group-addon input-square-left">
                                                            <i class="fa fa-globe"></i>
                                                        </span>
                                                        <asp:TextBox ID="txtCNumber2" runat="server" CssClass="form-control" placeholder="Enter Number" MaxLength="10" onkeypress="return isNumberKey(event)" AutoPostBack="true" OnTextChanged="txtCNumber2_TextChanged"/>
                                                    </div>
                                                </div>

                                            </div>
                                            <div class="col-lg-12">
                                                <div class="col-lg-6">
                                                    <div class="form-group">
                                                        <label>Address Line
                                                              <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator17" ControlToValidate="txtCAddress2"
                                                    ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Address Line 1" Style="color: Red" />
                                                        </label>
                                                        <div class="input-group">
                                                            <span class="input-group-addon input-square-left">
                                                                <i class="fa fa-address-card"></i>
                                                            </span>

                                                            <asp:TextBox ID="txtCAddress2" runat="server" TextMode="MultiLine" CssClass="form-control" AutoPostBack="false" Placeholder="Address"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <label>Country</label>
                                                        <div class="input-group">
                                                            <span class="input-group-addon input-square-left">
                                                                <i class="fa fa-globe"></i>
                                                            </span>

                                                            <asp:DropDownList ID="ddlCCountry2" runat="server" CssClass="form-control" placeholder="Select">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>

                                                </div>
                                                <div class="col-lg-2">
                                                    <label>Post Code
                                                         <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator18" ControlToValidate="txtCPost2"
                                                    ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Address Line 1" Style="color: Red" />
                                                    </label>
                                                    <div class="input-group">
                                                        <span class="input-group-addon input-square-left">
                                                            <i class="fa fa-map"></i>
                                                        </span>

                                                        <asp:TextBox ID="txtCPost2" runat="server" CssClass="form-control" placeholder="Enter Number"></asp:TextBox>
                                                    </div>

                                                </div>
                                                <div class="col-lg-1">
                                                    <div class="form-group">
                                                        <label></label>
                                                        <div class="input-group">


                                                            <asp:ImageButton ImageUrl="Images/plusbtn1.png" ID="ImageButton1" runat="server" OnClick="addname2_Click" Height="35px" Width="35px" />

                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-1">
                                                    <div class="form-group">
                                                        <label></label>
                                                        <div class="input-group">

                                                            <asp:ImageButton ImageUrl="Images/minus.png" ID="minusname3" runat="server" OnClick="minusname3_Click" Height="30px" Width="30px" />

                                                        </div>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>

                                        <div class="" style="border-inline: medium" id="divContact4" runat="server" visible="false">

                                            <div class="col-lg-12">
                                                <div class="col-lg-3">
                                                    <div class="form-group">
                                                        <label>Contact Name - 4
                                                             <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator19" ControlToValidate="txtCName3"
                                                    ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Address Line 1" Style="color: Red" />
                                                        </label>
                                                        <div class="input-group">
                                                            <span class="input-group-addon input-square-left">
                                                                <i class="fa fa-user"></i>
                                                            </span>

                                                            <asp:TextBox ID="txtCName3" runat="server" CssClass="form-control" placeholder="Enter Name"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-3">
                                                    <div class="form-group">
                                                        <label>Contact Email
                                                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator20" ControlToValidate="txtCEmail3"
                                                    ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Address Line 1" Style="color: Red" />
                                                        </label>
                                                        <div class="input-group">
                                                            <span class="input-group-addon input-square-left">
                                                                <i class="fa fa-envelope"></i>
                                                            </span>

                                                            <asp:TextBox ID="txtCEmail3" runat="server" CssClass="form-control" placeholder="user@email.com"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <label>Contact Number 4</label>
                                                        <div class="input-group">
                                                            <span class="input-group-addon input-square-left">
                                                                <i class="fa fa-globe"></i>
                                                            </span>

                                                            <asp:DropDownList ID="ddlCCode3" runat="server" CssClass="form-control" placeholder="Country">
                                                                <asp:ListItem Text="Code"></asp:ListItem>
                                                                <asp:ListItem Text="+1"></asp:ListItem>
                                                                <asp:ListItem Text="+44"></asp:ListItem>
                                                                <asp:ListItem Text="+91"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-3">

                                                    <label>
                                                         <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator21" ControlToValidate="txtCNumber3"
                                                    ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Address Line 1" Style="color: Red" />
                                                    </label>
                                                    <div class="input-group">
                                                        <span class="input-group-addon input-square-left">
                                                            <i class="fa fa-globe"></i>
                                                        </span>
                                                        <asp:TextBox ID="txtCNumber3" runat="server" CssClass="form-control" placeholder="Enter Number" MaxLength="10" onkeypress="return isNumberKey(event)"  AutoPostBack="true" OnTextChanged="txtCNumber3_TextChanged" />
                                                    </div>
                                                </div>

                                            </div>
                                            <div class="col-lg-12">
                                                <div class="col-lg-6">
                                                    <div class="form-group">
                                                        <label>Address Line
                                                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator22" ControlToValidate="txtCAddress3"
                                                    ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Address Line 1" Style="color: Red" />
                                                        </label>
                                                        <div class="input-group">
                                                            <span class="input-group-addon input-square-left">
                                                                <i class="fa fa-address-card"></i>
                                                            </span>

                                                            <asp:TextBox ID="txtCAddress3" runat="server" TextMode="MultiLine" CssClass="form-control" AutoPostBack="false" Placeholder="Address"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <label>Country</label>
                                                        <div class="input-group">
                                                            <span class="input-group-addon input-square-left">
                                                                <i class="fa fa-globe"></i>
                                                            </span>

                                                            <asp:DropDownList ID="ddlCCountry3" runat="server" CssClass="form-control" placeholder="Select">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>

                                                </div>
                                                <div class="col-lg-3">
                                                    <label>Post Code
                                                          <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator23" ControlToValidate="txtCPost3"
                                                    ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Address Line 1" Style="color: Red" />
                                                    </label>
                                                    <div class="input-group">
                                                        <span class="input-group-addon input-square-left">
                                                            <i class="fa fa-map"></i>
                                                        </span>

                                                        <asp:TextBox ID="txtCPost3" runat="server" CssClass="form-control" placeholder="Enter Number"></asp:TextBox>
                                                    </div>

                                                </div>
                                                <div class="col-lg-1" style="display: none">
                                                    <div class="form-group">
                                                        <label></label>
                                                        <div class="input-group">


                                                            <asp:ImageButton ImageUrl="Images/plusbtn1.png" ID="ImageButton2" runat="server" OnClick="addname_Click" Height="35px" Width="35px" />

                                                        </div>
                                                    </div>
                                                </div>
                                                              <div class="col-lg-1">
                                                    <div class="form-group">
                                                        <label></label>
                                                        <div class="input-group">

                                                            <asp:ImageButton ImageUrl="Images/minus.png" ID="minusname4" runat="server" OnClick="minusname4_Click" Height="30px" Width="30px" />

                                                        </div>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>

                                        <div class="col-lg-12">
                                            <div class="col-lg-6">
                                                <div class="form-group">
                                                    <label>Status</label>
                                                    <div class="input-group">
                                                        <span class="input-group-addon input-square-left">
                                                            <i class="fa fa-user"></i>
                                                        </span>

                                                        <asp:DropDownList ID="ddlsuplierstatus" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="">Select</asp:ListItem>
                                                            <asp:ListItem Text="Active"></asp:ListItem>
                                                            <asp:ListItem Text="Not Active"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-lg-6">
                                                <label>Supplier Type</label>
                                                <div class="input-group">
                                                    <span class="input-group-addon input-square-left">
                                                        <i class="fa fa-graduation-cap"></i>
                                                    </span>
                                                    <%-- <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator10" ControlToValidate="ddlsuplierqualification"
                                                    ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Supplier Qualification" Style="color: Red" />--%>
                                                    <asp:DropDownList ID="ddlsuplierqualification" runat="server" CssClass="form-control">
                                                        <asp:ListItem Value="">Select</asp:ListItem>
                                                        <asp:ListItem Text="Wholesaler"></asp:ListItem>
                                                        <asp:ListItem Text="Pharmacy"></asp:ListItem>
                                                        <asp:ListItem Text="Manufacturer"></asp:ListItem>
                                                        <asp:ListItem Text="Laboratory"></asp:ListItem>
                                                        <%--<asp:ListItem Text="GASTROENTEROLOGY"></asp:ListItem>
                                                            <asp:ListItem Text="CARDIOLOGY "></asp:ListItem>--%>
                                                    </asp:DropDownList>
                                                </div>

                                            </div>
                                            <div id="hideapprov" runat="server" visible="false">                                           
                                            <div class="col-lg-3">
                                                <label>Select Approver </label>

                                                <div class="input-group">
                                                    <span class="input-group-addon input-square-left">
                                                        <i class="fa fa-fa fa-bitcoin"></i>
                                                    </span>
                                                    <asp:DropDownList ID="ddlSelectapprover" runat="server" CssClass="form-control" placeholder="Select">
                                                        <asp:ListItem Value="">Select</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="col-lg-3">
                                                <label>Select Status </label>
                                                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control" placeholder="Select" Enabled="false">
                                                    <asp:ListItem Value="">Select</asp:ListItem>
                                                    <asp:ListItem Text="Draft" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="Approved"></asp:ListItem>
                                                    <asp:ListItem Text="Rejected"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                                 </div>
                                        </div>

                                        <div class="row">

                                            <center>
                                                <div cl="col-lg-12" style="padding-top: 20px">

                                                    <asp:Button ID="btnSubmit" runat="server" class="btn btn-success" Text="Submit" ValidationGroup="Validation" OnClick="btnSubmit_Click" />
                                                    <asp:Button ID="btncancel" runat="server" class="btn btn-danger" Text="Cancel" PostBackUrl="~/SuplierGridpage.aspx" />
                                                </div>
                                            </center>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>


                    <div class="col-lg-3" style="display: none">
                        <div class="form-group">
                            <label></label>
                            <div class="input-group">
                                <%-- <span class="input-group-addon input-square-left">
                                                                <i class="fa fa-address-card"></i>
                                                            </span>--%>
                                <asp:Button ID="addtextbox" runat="server" class="btn btn-success" Text="Add Address" AutoPostBack="true" ValidationGroup="Validation" OnClick="addtextbox_Click" />
                            </div>
                        </div>
                    </div>
                    <div id="textBoxContainer" runat="server" visible="false">
                        <div class="col-lg-9">
                            <label>Address Line 2</label>
                            <div class="input-group">
                                <span class="input-group-addon input-square-left">
                                    <i class="fa fa-address-card"></i>
                                </span>
                                <asp:TextBox ID="Addres2" runat="server" TextMode="singleline" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label></label>
                                <div class="input-group">
                                    <%-- <span class="input-group-addon input-square-left">
                                                                <i class="fa fa-address-card"></i>
                                                            </span>--%>
                                    <asp:Button ID="addtextbox2" runat="server" class="btn btn-success" Text="Add Address" AutoPostBack="true" ValidationGroup="Validation" OnClick="addtextbox2_Click" />
                                </div>
                            </div>
                        </div>
                    </div>


                    <div id="textBoxContainer1" runat="server" visible="false">
                        <div class="col-lg-9">
                            <label>Address Line 3</label>
                            <div class="input-group">
                                <span class="input-group-addon input-square-left">
                                    <i class="fa fa-address-card"></i>
                                </span>
                                <asp:TextBox ID="Addres3" runat="server" TextMode="singleline" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label></label>
                                <div class="input-group">
                                    <%-- <span class="input-group-addon input-square-left">
                                                                <i class="fa fa-address-card"></i>
                                                            </span>--%>
                                    <asp:Button ID="addtextbox3" runat="server" class="btn btn-success" Text="Add Address" AutoPostBack="true" ValidationGroup="Validation" OnClick="addtextbox3_Click" />
                                </div>
                            </div>
                        </div>
                    </div>

                    <div id="textBoxContainer2" runat="server" visible="false">
                        <div class="col-lg-9">
                            <label>Address Line 4</label>
                            <div class="input-group">
                                <span class="input-group-addon input-square-left">
                                    <i class="fa fa-address-card"></i>
                                </span>
                                <asp:TextBox ID="Addres4" runat="server" TextMode="singleline" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label></label>
                                <div class="input-group">
                                    <%-- <span class="input-group-addon input-square-left">
                                                                <i class="fa fa-address-card"></i>
                                                            </span>--%>
                                    <asp:Button ID="addtextbox4" runat="server" class="btn btn-success" Text="Add Address" AutoPostBack="true" ValidationGroup="Validation" OnClick="addtextbox4_Click" />
                                </div>
                            </div>
                        </div>
                    </div>

                    <div id="textBoxContainer3" runat="server" visible="false">
                        <div class="col-lg-9">
                            <div class="form-group">
                                <label>Address Line 5</label>
                                <div class="input-group">
                                    <span class="input-group-addon input-square-left">
                                        <i class="fa fa-address-card"></i>
                                    </span>
                                    <asp:TextBox ID="Addres5" runat="server" TextMode="singleline" CssClass="form-control"></asp:TextBox>
                                </div>

                            </div>
                        </div>
                    </div>

                    <div class="col-lg-12">



                        <div id="name1container" runat="server" visible="false">
                            <div class="col-lg-9">
                                <label>Contact Name 1</label>
                                <div class="input-group">
                                    <span class="input-group-addon input-square-left">
                                        <i class="fa fa-user"></i>
                                    </span>
                                    <asp:TextBox ID="txtcontactname1" runat="server" TextMode="singleline" placeholder="Enter Name" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-3" style="margin-top: 1px">
                                <div class="form-group">
                                    <label></label>
                                    <div class="input-group">
                                        <%-- <span class="input-group-addon input-square-left">
                                                                <i class="fa fa-address-card"></i>
                                                            </span>--%>
                                        <asp:ImageButton ImageUrl="Images/plusbtn1.png" ID="addname1" runat="server" OnClick="addname_Click" Height="40px" Width="40px" />
                                        <%--     <asp:Button ID="addname1" runat="server" class="btn btn-success" Text="Add Name" AutoPostBack="true" ValidationGroup="Validation" OnClick="addname1_Click" />--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div>
                            <div id="name2container" runat="server" visible="false">
                                <div class="col-lg-9">
                                    <label>Contact Name 2</label>
                                    <div class="input-group">
                                        <span class="input-group-addon input-square-left">
                                            <i class="fa fa-user"></i>
                                        </span>
                                        <asp:TextBox ID="txtcontactname2" runat="server" TextMode="singleline" placeholder="Enter Name" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-2" style="margin-top: 1px">
                                    <div class="form-group">
                                        <label></label>
                                        <div class="input-group">
                                            <%-- <span class="input-group-addon input-square-left">
                                                                <i class="fa fa-address-card"></i>
                                                            </span>--%>
                                            <asp:ImageButton ImageUrl="Images/plusbtn1.png" ID="addname2" runat="server" OnClick="addname2_Click" Height="40px" Width="40px" />
                                            <%--<asp:Button ID="addname2" runat="server" class="btn btn-success" Text="Add Name" AutoPostBack="true" ValidationGroup="Validation" OnClick="addname2_Click" />--%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div>
                            <div id="name3container" runat="server" visible="false">
                                <div class="col-lg-9">
                                    <label>Contact Name 3</label>
                                    <div class="input-group">
                                        <span class="input-group-addon input-square-left">
                                            <i class="fa fa-user"></i>
                                        </span>
                                        <asp:TextBox ID="txtcontactname3" runat="server" TextMode="singleline" placeholder="Enter Name" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-3" style="margin-top: 1px">
                                    <div class="form-group">
                                        <label></label>
                                        <div class="input-group">
                                            <%-- <span class="input-group-addon input-square-left">
                                                                <i class="fa fa-address-card"></i>
                                                            </span>--%>
                                            <asp:ImageButton ImageUrl="Images/plusbtn1.png" ID="addname3" runat="server" OnClick="addname3_Click" Height="40px" Width="40px" />
                                            <%--<asp:Button ID="addname3" runat="server" class="btn btn-success" Text="Add Name" AutoPostBack="true" ValidationGroup="Validation" OnClick="addname3_Click" />--%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div>
                            <div id="name4container" runat="server" visible="false">
                                <div class="col-lg-9">
                                    <div class="form-group">
                                        <label>Contact Name 4</label>
                                        <div class="input-group">
                                            <span class="input-group-addon input-square-left">
                                                <i class="fa fa-user"></i>
                                            </span>
                                            <asp:TextBox ID="txtcontactname4" runat="server" TextMode="singleline" placeholder="Enter Name" CssClass="form-control"></asp:TextBox>
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


    <script>
        function showTextBoxes() {
            document.getElementById('<%= textBoxContainer.ClientID %>').style.display = 'block';
        }
    </script>
    <%--</div>
</div>

    <!-- BEGIN CORE PLUGINS -->
    <script src="assets/global/plugins/jquery.min.js" type="text/javascript"></script>
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
    </script>--%>
</body>
</html>
