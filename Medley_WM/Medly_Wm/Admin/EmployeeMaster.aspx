<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeMaster.aspx.cs"  Inherits="AdminAfforadbleApp.EmployeeMaster" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/Admin/Header.ascx" %>
<%@ Register TagPrefix="usc2" TagName="Header2" Src="~/Admin/HeaderTop.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
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
<body class="page-header-fixed page-sidebar-closed-hide-logo page-container-bg-solid page-md">
    <usc2:Header2 ID="Header2" runat="server" />
    <div class="clearfix"></div>
        <div class="page-container">
        <usc:Header ID="Header" runat="server" />
    <form id="form1" runat="server">
    <asp:ScriptManager ID="Script" runat="server"></asp:ScriptManager>
   <div>
          <div class="page-content-wrapper">
            <!-- BEGIN CONTENT BODY -->
            <div class="page-content">
                <!-- BEGIN PAGE HEADER-->
                <!-- BEGIN THEME PANEL -->
                <!-- END THEME PANEL -->
                <h1 class="page-title">
                    Employee Master 
                </h1>
    <div class="row">
                    
                    
                    <div class="col-md-6">
                        <!-- BEGIN EXAMPLE TABLE PORTLET-->
                        <div class="portlet light ">
                            <div class="portlet-title">
                                <div class="caption font-dark">
                                   <span class="caption-subject bold uppercase">
                                        Employee Master </span><span class="label label-sm label-info"></span>
                                </div>
                            </div>
                            <div class="portlet-body">

                                <div class="row">
                               <div class="col-lg-12">
                                 
                   
                      <div  class="form-group form-md-line-input has-success">
                       <asp:TextBox CssClass="form-control" ID="txtemployeename" runat="server" placeholder="Enter Employee Name"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="EmpName" ControlToValidate="txtemployeename"
                                                            ErrorMessage="Please Enter Employee Name!" Style="color: Red" />
                    </div>
                     <div class="form-group form-md-line-input form-md-floating-label">
                     <label>Designation</label>
                      <asp:DropDownList ID="ddldesignation" AutoPostBack="true" runat="server">
                      <asp:ListItem Value="1">Team Leader</asp:ListItem>
                      <asp:ListItem Value="2">Service Technicians</asp:ListItem>
                      </asp:DropDownList>

                    </div>

                          <div  class="form-group form-md-line-input has-success">
                   <asp:Label ID="lbleid" runat="server" Visible="false"></asp:Label>
                       <asp:TextBox CssClass="form-control" ID="txtMobileno" MaxLength="10"   runat="server" placeholder="Enter Mobile No"></asp:TextBox>
                      <%--   <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="mobno" ControlToValidate="txtMobileno"
                                                            ErrorMessage="Please enter your Mobile No!" Style="color: Red" /><br />
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                                            FilterType="Numbers,Custom" ValidChars=" -," TargetControlID="txtMobileno" />
                                                        <asp:RegularExpressionValidator runat="server" ID="rexNumber" ValidationGroup="val1"
                                                            ControlToValidate="txtMobileno" ValidationExpression="^[0-9]{10}$" ErrorMessage="Please enter a 10 digit number!"
                                                            Style="color: Red" />--%>
                    </div>
                     <div  class="form-group form-md-line-input has-success">
                    
                       <asp:TextBox CssClass="form-control" ID="txtEmailid" runat="server"  placeholder="Enter Email Id"></asp:TextBox>
                          <%-- <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="email" ControlToValidate="txtEmailid"
                                                            ErrorMessage="Please enter your Email!" Style="color: Red" />
                                                        <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator2" ValidationGroup="val1"
                                                            ControlToValidate="txtEmailid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                            ErrorMessage="Please enter a correct Email Id!" Style="color: Red" />--%>
                    </div>
                                        <div  class="form-group form-md-line-input has-success">
                       
                        <asp:TextBox CssClass="form-control" ID="txtusername" runat="server" placeholder="Enter User Name"></asp:TextBox>
                        <%--  <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="username" ControlToValidate="txtusername"
                                                            ErrorMessage="Please Enter UserName!" Style="color: Red" />--%>
                    </div>
                      <div  class="form-group form-md-line-input has-success">
                         <asp:TextBox CssClass="form-control" ID="txtPassword" runat="server" placeholder="Enter Password"></asp:TextBox>
                         <%--  <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="pass" ControlToValidate="txtPassword"
                                                            ErrorMessage="Please Enter Password!" Style="color: Red" />--%>
                   </div>
                    <div>
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success" Text="Save" 
                            onclick="btnSave_Click"/>
                   <%--  <asp:Button ID="btnReset" runat="server" OnClick="btnReset_Click" CssClass="btn btn-danger" Text="Reset"/>--%>
                      <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" CssClass="btn btn-danger" Text="Back"/>
                    </div>
                    </div>
                    </div>
                     
                   
                                
                            </div>
                        </div>
                        <!-- END EXAMPLE TABLE PORTLET-->
                    </div>
                </div>
                </div>
                </div>
    </div>
    </form>
    </div>
</body>
</html>
