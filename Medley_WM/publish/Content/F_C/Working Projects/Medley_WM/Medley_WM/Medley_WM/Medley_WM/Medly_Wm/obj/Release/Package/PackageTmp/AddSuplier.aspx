<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddSuplier.aspx.cs" Inherits="Medly_Wm.AddSuplier" %>

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
       
        .auto-style1 {
            vertical-align: middle;
        }
       
        .auto-style2 {
            position: relative;
            display: table;
            border-collapse: separate;
            left: 0px;
            top: 68px;
        }
       
    </style>

</head>

<body class="page-header-fixed page-sidebar-closed-hide-logo page-container-bg-solid page-md">

    <p>
        wa</p>

    <usc1:Sidebar ID="h1" runat="server" />
    <div class="page-container">

        <usc:Header ID="Header" runat="server" />
        <div class="page-content-wrapper">
            <!-- BEGIN CONTENT BODY -->
            <div class="page-content">

                <form id="form1" runat="server">

                    <div class="row">
                        <div class="col-md-12 ">
                            <!-- BEGIN SAMPLE FORM PORTLET-->
                            <div class="portlet light ">
                                <div class="portlet-title">
                                    <div class="caption font-red-sunglo">
                                        <i class="icon-settings font-red-sunglo"></i>
                                        <span class="caption-subject bold uppercase">Add Supplier</span>
                                    </div>
                                    <div class="actions">
                                        <div class="btn-group">
                                            <a class="btn btn-sm green dropdown-toggle" href="javascript:;" data-toggle="dropdown">Update
                                                <%--<i class="fa fa-angle-down"></i>--%>
                                            </a>
                                           <%-- <ul class="dropdown-menu pull-right">
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
                                            </ul>--%>
                                        </div>
                                    </div>
                                </div>
                               


                                <div class="form-body">
                                    <div>
                                        <div class="col-lg-12" <%--style="border:2px solid skyblue"--%>>
                                            <div class="col-lg-3">
                                                <label>Supplier ID</label>
                                                <div class="input-group">
                                                <span class="input-group-addon input-circle-left">
                                                <i class="fa fa-user"></i>
                                                </span>
                                                   
                                                <asp:TextBox ID="txtsupplierid" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                             </div>

                                             <div class="col-lg-3">
                                                     <label>Initial additional date</label>
                                                     <div class="input-group">
                                                    <span class="input-group-addon input-circle-left">
                                                       <i class="fa fa-calendar"></i>
                                                    </span>
                                                   <%-- <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtadditionaldate"
                                                        ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Initial additional date" Style="color: Red" />--%>
                                                    <asp:TextBox ID="txtadditionaldate" runat="server" CssClass="form-control" placeholder="01/01/2023"></asp:TextBox>
                                                     </div>
                                             </div>

                                            
                                             <div class="col-lg-3">
                                                     <label>Company Name</label>
                                                      <div class="input-group">
                                                    <span class="input-group-addon input-circle-left">
                                                        <i class="fa fa-building"></i>
                                                    </span>
                                                    
                                                    <asp:TextBox ID="txtcompanyname" runat="server" CssClass="form-control" placeholder="Enter Name"></asp:TextBox>
                                                  
                                                       </div> 
                                             </div>
                                            <div class="col-lg-6">
                                           
                                            
                                            <div class="col-lg-12" >
                                            

                                                  <div class="col-lg-12">
                                             
                                                <div class="col-lg-12">
                                                    <label>Contact Name</label>
                                                     <div class="input-group">
                                                    <span class="input-group-addon input-circle-left">
                                                        <i class="fa fa-user"></i>
                                                    </span>
                                                   
                                                    <asp:TextBox ID="txtcontactname" runat="server" CssClass="form-control" placeholder="Enter Name"></asp:TextBox>
                                                   <%-- <label style="float: right">0 of 100 characters</label>--%>
                                                          </div>
                                                    </div>
                                                        <%--  <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="txtcontactname"
                                                        ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Contact Name" Style="color: Red" />--%>
                                               
</div>
                                                <div class="col-lg-12">
                                                    <label>Contact Email</label>
                                                     <div class="input-group">
                                                    <span class="input-group-addon input-circle-left">
                                                        <i class="fa fa-envelope"></i>
                                                    </span>
                                                 <%--   <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" ControlToValidate="txtcontactemail"
                                                        ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Contact Email" Style="color: Red" />--%>
                                                    <asp:TextBox ID="txtcontactemail" runat="server" CssClass="form-control" placeholder="user@email.com"></asp:TextBox>
                                                </div>
                                                      </div>

                                                <div class="col-lg-12"><label>Contact Number</label> 
                                                    <div class="row"> 
                                                        <div class="col-lg-3">
                                                           
                                                            
                                                           
                                                            <%--<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator5" ControlToValidate="ddlNumber"
                                                            ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Contact Number" Style="color: Red" />--%>
                                                            <asp:DropDownList ID="ddlNumber" runat="server" CssClass="form-control" placeholder="Country">
                                                                <asp:ListItem Text="Code"></asp:ListItem>
                                                                <asp:ListItem Text="+1"></asp:ListItem>
                                                                <asp:ListItem Text="+44"></asp:ListItem>  
                                                                 <asp:ListItem Text="+91"></asp:ListItem>
                                                            </asp:DropDownList>
                                                                 </div>
                                                       
                                                        <div class="col-lg-9">
                                                          <div class="input-group">
                                                    <span class="input-group-addon input-circle-left">
                                                        <i class="fa fa-globe"></i>
                                                    </span>
                                                            <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" placeholder="Enter Number" />
                                                        </div>
                                                    </div>
                                                        </div>
                                                </div>



                                                <div class="col-lg-12">
                                                    <div class="row">
                                                        <div class="col-lg-6">
                                                            <label>Valid Till</label>
                                                             <div class="input-group">
                                                    <span class="input-group-addon input-circle-left">
                                                        <i class="fa fa-calendar"></i>
                                                    </span>
                                                            
                                                            <%--<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator6" ControlToValidate="txtvalidtill"
                                                                ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Contact Number" Style="color: Red" />--%>
                                                            <asp:TextBox ID="txtvalidtill" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                                        </div>
                                                            </div>
                                                        <div class="col-lg-6">
                                                            <label>Default Currency</label>
                                                             <div class="input-group">
                                                    <span class="input-group-addon input-circle-left">
                                                        <i class="fa fa-envelope"></i>
                                                    </span>
                                                          <%--  <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator7" ControlToValidate="ddldefaultcurrency"
                                                                ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Contact Number" Style="color: Red" />--%>
                                                            <asp:DropDownList ID="ddldefaultcurrency" runat="server" CssClass="form-control" placeholder="Select">
                                                                <asp:ListItem value="">Select</asp:ListItem>
                                                                <asp:ListItem Text="GBP"></asp:ListItem>
                                                                <asp:ListItem Text="INR"></asp:ListItem>
                                                                <asp:ListItem Text="USD"></asp:ListItem>
                                                            </asp:DropDownList>
                                                                 </div>
                                                        </div>
                                                    </div>
                                                </div>


                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                                <div class="col-lg-12">
                                            <div class="col-lg-6">
                                                <label>Supplier Status</label>
                                               <div class="input-group">
                                                    <span class="input-group-addon input-circle-left">
                                                        <i class="fa fa-user"></i>
                                                    </span>
                                                <%--<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator9" ControlToValidate="ddlsuplierstatus"
                                                    ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Supplier Status" Style="color: Red" />--%>
                                                <asp:DropDownList ID="ddlsuplierstatus" runat="server" CssClass="form-control" Width="200px">
                                                    <asp:ListItem value="">Select</asp:ListItem>
                                                    <asp:ListItem Text="Active"></asp:ListItem>
                                                    <asp:ListItem Text="Not Active"></asp:ListItem>
                                                </asp:DropDownList>
                                                </div>
                                            </div>

                                            <div class="col-lg-6">
                                                <label>Supplier Qualification</label>
                                                <div class="input-group">
                                                    <span class="input-group-addon input-circle-left">
                                                        <i class="fa fa-graduation-cap"></i>
                                                    </span>
                                               <%-- <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator10" ControlToValidate="ddlsuplierqualification"
                                                    ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Supplier Qualification" Style="color: Red" />--%>
                                                <asp:DropDownList ID="ddlsuplierqualification" runat="server" CssClass="form-control">
                                                    <asp:ListItem value="">Select</asp:ListItem>
                                                    <asp:ListItem Text="Degree/MBA"></asp:ListItem>
                                                    <asp:ListItem Text="Diplomo"></asp:ListItem>
                                                </asp:DropDownList>
                                                    </div>
                                            </div></div>

                                            <div class="col-lg-12">
                                                <div class="col-lg-12">
                                                <label>Address Line 1</label>
                                                     <div class="input-group">
                                                    <span class="input-group-addon input-circle-left">
                                                        <i class="fa fa-user"></i>
                                                    </span>
                                              <%--  <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator11" ControlToValidate="txtaddressline1"
                                                    ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Address Line 1" Style="color: Red" />--%>
                                                <asp:TextBox ID="txtaddressline1" runat="server" CssClass="form-control" Placeholder="Enter Name"></asp:TextBox>
                                               <%-- <label style="float: right">0 of 50 characters</label>--%>
                                                         </div>
                                            </div>

                                            <div class="col-lg-12">
                                                <label>Address Line 2</label>
                                                 <div class="input-group">
                                                    <span class="input-group-addon input-circle-left">
                                                        <i class="fa fa-user"></i>
                                                    </span>
                                                <asp:TextBox ID="txtaddressline2" runat="server" CssClass="form-control" Placeholder="Enter Name"></asp:TextBox>
                                              <%--  <label style="float: right">0 of 50 characters</label>--%>
                                                     </div>
                                            </div>

                                            <div class="col-lg-12">
                                                <label>Address Line 3</label>
                                                 <div class="input-group">
                                                    <span class="input-group-addon input-circle-left">
                                                        <i class="fa fa-user"></i>
                                                    </span>
                                                <asp:TextBox ID="txtaddressline3" runat="server" CssClass="form-control" Placeholder="Enter Name"></asp:TextBox>
                                               <%-- <label style="float: right">0 of 50 characters</label>--%>
                                                     </div>
                                            </div></div>


                                            <div class="col-lg-6">
                                                <label>Town</label>
                                                <div class="input-group">
                                                    <span class="input-group-addon input-circle-left">
                                                        <i class="fa fa-map"></i>
                                                    </span>
                                               <%-- <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator15" ControlToValidate="txttown"
                                                    ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Town" Style="color: Red" />--%>
                                                <asp:TextBox ID="txttown" runat="server" CssClass="form-control" placeholder="Enter Text"></asp:TextBox>
                                                    </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <label>Country</label>
                                                <div class="input-group">
                                                    <span class="input-group-addon input-circle-left">
                                                        <i class="fa fa-globe"></i>
                                                    </span>
                                                <%--<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator16" ControlToValidate="ddlcountry"
                                                    ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Country" Style="color: Red" />--%>
                                                <asp:DropDownList ID="ddlcountry" runat="server" CssClass="form-control" placeholder="Select">
                                                    <asp:ListItem value="">Select</asp:ListItem>
                                                    <asp:ListItem Text="India"></asp:ListItem>
                                                    <asp:ListItem Text="USA"></asp:ListItem>
                                                </asp:DropDownList>
                                                    </div>
                                            </div>

                                            <div class="col-lg-6" style="padding-top: 10px">
                                                <label>Post Code</label>
                                                <div class="input-group">
                                                    <span class="input-group-addon input-circle-left">
                                                        <i class="fa fa-map"></i>
                                                    </span>
                                               <%-- <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator17" ControlToValidate="txtposcode"
                                                    ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Post Code" Style="color: Red" />--%>
                                                <asp:TextBox ID="txtposcode" runat="server" CssClass="form-control" placeholder="Enter Number"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        </div>
                                   




                                    <div class="col-lg-12" style="padding-top: 20px">
                          

                                        <div>
                                           
                                           <%-- <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator8" ControlToValidate="ddlselectapprover"
                                                ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Contact Number" Style="color: Red" />--%>
                                        </div>
                                        <div style="float: right; margin-right: 695px;">
                                           Select Approver:  
                                            <div class="auto-style2">
                                                    <span class="input-group-addon input-circle-left">
                                                        <i class="fa fa-user"></i>
                                                    </span>
                                                <asp:DropDownList ID="ddlselectapprover" runat="server" CssClass="form-control" placeholder="Select" Width="320px">
                                               <asp:ListItem value="">Select</asp:ListItem>
                                                <asp:ListItem Text="Manager"></asp:ListItem>
                                                <asp:ListItem Text="Client"></asp:ListItem>
                                            </asp:DropDownList>
                                                </div>
                                        </div>

                                    </div>


                                </div>
                                     </div>

                                </>
                        <div class="row">
                            <center>
                                <div cl="col-lg-12" style="padding-top: 20px">
                                    <!--<button type="submit" class="btn blue">Submit</button>-->
                                    <asp:Button ID="btncancel" runat="server" class="btn blue" Text="Cancel" PostBackUrl="~/SuplierGridpage.aspx"  />
                                    <span class="auto-style1"></span><asp:Button ID="btnsave" runat="server" class="btn btn-success" Text="Save"  ValidationGroup="Validation" />
                                </div>
                            </center>
                        </div>
                            </div>

                        </div>
                    </div>
                    </form>
            </div>
            
        </div>

    </div>

    </div>

    <%--</div>
</div>--%>

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
    </script>
</body>
</html>