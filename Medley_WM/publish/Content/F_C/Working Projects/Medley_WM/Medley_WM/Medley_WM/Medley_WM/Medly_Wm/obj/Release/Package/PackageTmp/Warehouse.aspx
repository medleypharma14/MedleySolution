<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Warehouse.aspx.cs" Inherits="Medly_Wm.Warehouse" EnableEventValidation="false" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/Header.ascx" %>
<%@ Register TagPrefix="usc1" TagName="Sidebar" Src="~/Sidebar.ascx" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Ware House</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta content="width=device-width, initial-scale=1" name="viewport" />
    <meta content="Preview page of Metronic Admin Theme #2 for statistics, charts, recent events and reports" name="description" />
    <meta content="" name="author" />
    <!-- BEGIN GLOBAL MANDATORY STYLES -->
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all" rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/simple-line-icons/simple-line-icons.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css" rel="stylesheet" type="text/css" />
    <!-- END GLOBAL MANDATORY STYLES -->
    <!-- BEGIN PAGE LEVEL PLUGINS -->
    <link href="../assets/global/plugins/bootstrap-daterangepicker/daterangepicker.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/morris/morris.css" rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/fullcalendar/fullcalendar.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/jqvmap/jqvmap/jqvmap.css" rel="stylesheet" type="text/css" />
    <!-- END PAGE LEVEL PLUGINS -->
    <!-- BEGIN THEME GLOBAL STYLES -->
    <link href="../assets/global/css/components-md.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/global/css/plugins-md.min.css" rel="stylesheet" type="text/css" />
    <!-- END THEME GLOBAL STYLES -->
    <!-- BEGIN THEME LAYOUT STYLES -->
    <link href="../assets/layouts/layout2/css/layout.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/layouts/layout2/css/themes/blue.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/layouts/layout2/css/custom.min.css" rel="stylesheet" type="text/css" />
    <!-- END THEME LAYOUT STYLES -->
    <link rel="shortcut icon" href="favicon.ico" />
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
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
    </style>
</head>
<body class="page-header-fixed page-sidebar-closed-hide-logo page-container-bg-solid page-md">
    <p>
        e</p>
    <usc1:Sidebar ID="Sidebar" runat="server" />
    <div class="page-container">
        <usc:Header ID="Header" runat="server" />
        <div class="page-content-wrapper">
            <div class="page-content">
                <form id="form1" runat="server">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="portlet light ">
                                <div class="portlet box green">
                                    <div class="portlet-title">
                                        <div class="caption">
                                            <i class="fa fa-cogs"></i>Warehouse
                                        </div>
                                    </div>
                                </div>
                                <div class="actions">
                                    <%-- <div class="btn-group">
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
                                        </div>--%>
                                </div>
                                <div class="portlet-title" <%--style="border: 1px solid blue"--%>>
                                    <div class="form-body">
                                        <div class="col-lg-12">
                                            <div class="col-lg-12">
                                               
                                            <div class="col-lg-4">
                                                 <div class="form-group">
                                                <label><b>Select Product</b></label>
                                                <asp:TextBox ID="txtWarehousename" runat="server" CssClass="form-control" ReadOnly="true" placeholder="Medley" Visible="false" />
                                                <asp:DropDownList ID="ddlProductname" AutoPostBack="true" CssClass="form-control" OnTextChanged="ddlProductname_TextChanged" runat="server"></asp:DropDownList>
                                            </div>
                                               </div>      
                                            <div class="col-lg-4">
                                                <label><b>Select Batch Number</b></label>
                                                <asp:TextBox ID="txtWarehousecode" runat="server" CssClass="form-control" ReadOnly="true" placeholder="ME112" Visible="false" />
                                                <asp:DropDownList runat="server" ID="ddlBatchNumber" AutoPostBack="true"  CssClass="form-control" OnTextChanged="ddlBatchNumber_TextChanged">  </asp:DropDownList>

                                         <%--  Select Floors--%>

                                            </div>
                                            <div class="col-lg-4">
                                                    <label>
                                                        Number Of Units
                                                    </label>
                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ControlToValidate="ddlNumberofunits" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                    <div class="input-group">
                                                        <span class="input-group-addon">
                                                            <i class=""></i>
                                                        </span>
                                                        <asp:TextBox ID="txtunity" runat="server" CssClass="form-control" ReadOnly="true" placeholder="403" Width="150px" />
                                                        <%--  <asp:DropDownList ID="ddlNumberofunits" runat="server" CssClass="form-control" Width="150px">
                                                            <asp:ListItem Value="">Select</asp:ListItem>
                                                            <asp:ListItem Text="1" />
                                                            <asp:ListItem Text="2" />
                                                            <asp:ListItem Text="3" />
                                                            <asp:ListItem Text="4" />
                                                        </asp:DropDownList>--%>
                                                    </div>
                                                </div>
                                                   
                                            </div>
                                        
                                            <div class="col-lg-12">
                                                <div style="overflow: auto">
                                                    <asp:GridView ID="gvProductDetails" Visible="false" runat="server" CssClass="table table-bordered table-striped table-condensed flip-content" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                                                        <AlternatingRowStyle BackColor="White" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.no">
                                                                <ItemTemplate>
                                                                    <%#Container.DataItemIndex+1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderText="Unit Name" DataField="Unitname" />
                                                            <asp:BoundField HeaderText="Batch Number" DataField="Batchnumber" />
                                                            <asp:BoundField HeaderText="Expiry Date" DataField="Expirydate" DataFormatString="{0:dd-MM-yyyy}" />
                                                            <asp:BoundField HeaderText="Available Qty" DataField="TotalQty" />
                                                            <asp:BoundField HeaderText="Status" DataField="Status" />
                                                            <asp:BoundField HeaderText="User  Name" DataField="Username" Visible="false" />
                                                            </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </div>

                                            <div class="col-lg-6" style="display:none">
                                                <label>Floor No:</label>
                                                <%--<div class="input-group">
                                                    <span class="input-group-addon input-circle-left">
                                                        <%--<i class="fa fa-user"></i>
                                                    </span></div>--%>
                                                <asp:Label ID="lblFloor" runat="server" CssClass="form-control"></asp:Label><br />
                                                <%-- <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" placeholder="Enter Address" />--%>
                                            </div>

                                            <div class="col-lg-6" style="display:none">
                                                <%--  Floor No:
                                            <asp:Label ID="lblFloor" runat="server"></asp:Label><br />--%>
                                                <label>Unitname: </label>
                                                <asp:Label ID="lblUnit" runat="server" CssClass="form-control"></asp:Label><br />
                                            </div>
                                            <div class="container">

                                               
                                                <div class="col-lg-4" style="display:none">
                                                    <label>
                                                        Number Of Aisle
                                                    </label>
                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ControlToValidate="ddlNumberofaisle" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                    <%-- <div class="input-group">
                                                        <span class="input-group-addon input-circle-left">
                                                            <i class="fa fa-user"></i>
                                                        </span>
                                                        </div>--%>
                                                    <asp:DropDownList ID="ddlNumberofaisle" runat="server" CssClass="form-control" Width="230px" style="display:none">
                                                        <asp:ListItem Value="">Select</asp:ListItem>
                                                        <asp:ListItem Text="1" />
                                                        <asp:ListItem Text="2" />
                                                        <asp:ListItem Text="3" />
                                                        <asp:ListItem Text="4" />
                                                    </asp:DropDownList>

                                                </div>
                                                <div class="col-lg-4" style="display:none">
                                                    <label>
                                                        Select Floors 
                                                    </label>
                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="ddlNumberoffloors" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                    <div class="input-group">
                                                        <span class="input-group-addon ">
                                                            <i class="fa fa-user"></i>
                                                        </span>
                                                        <%--   <asp:TextBox ID="txtNooffloors" runat="server" CssClass="form-control" placeholder="Enter Floor Number" />--%>

                                                        <asp:DropDownList ID="ddlNumberoffloors" runat="server" CssClass="form-control" Width="150px">
                                                            <asp:ListItem Value="">Select</asp:ListItem>
                                                            <asp:ListItem Text="1" />
                                                            <asp:ListItem Text="2" />
                                                            <asp:ListItem Text="3" />
                                                            <asp:ListItem Text="4" />
                                                        </asp:DropDownList>
                                                        <%--<asp:Button ID="Submit" CssClass="btn btn-green" Text="Check" runat="server" OnClick="Check_Click" />--%>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="col-lg-12">
                                                <div class="col-lg-12" style="margin-left: ; border: 1px solid skyblue; width: ; margin-bottom: 10px;">
                                                    <b>Generate map</b>
                                                    <div class="">

                                                        <%--   <div class="col-lg-6">Please select the details above to view the generated Map</div>--%>
                                                        <div class="col-lg-12">
                                                            <asp:Label ID="lblDisplay" runat="server" ForeColor="Green" Font-Size="Small"></asp:Label>
                                                        </div>
                                                        <%--<div class="col-lg-6" style="padding-left: 250px;">
                                                            Aisle     
                                                <asp:HyperLink ID="HyperLink1" runat="server"><</asp:HyperLink>
                                                            <asp:HyperLink ID="HyperLink2" runat="server"><</asp:HyperLink>
                                                            <asp:HyperLink ID="HyperLink3" runat="server"><</asp:HyperLink>
                                                            <asp:HyperLink ID="HyperLink4" runat="server">></asp:HyperLink>
                                                            <asp:HyperLink ID="HyperLink5" runat="server">></asp:HyperLink>
                                                            <asp:HyperLink ID="HyperLink6" runat="server">></asp:HyperLink>


                                                        </div>--%>
                                                    </div>
                                                    <%--floor start --%>
                                                    <div class="panel-body" align="left" style="overflow: auto">
                                                        <asp:DataList ID="ddUnits1" runat="server" RepeatLayout="Table" RepeatDirection="Horizontal" RepeatColumns="20"
                                                            OnItemDataBound="ddRoomListSecond_ItemDataBound">
                                                            <ItemTemplate>
                                                                <asp:Button CssClass="btn btn-success" ID="btns1" runat="server" ForeColor="White" OnClick="btnClick"
                                                                    Text='<%#  Eval("Unitname")%>' CommandArgument='<%# Eval("Unitname") %>'
                                                                    CommandName='<%# Eval("Isempty") %>' Style="font-size: small; word-wrap: break-word; float: left; white-space: normal; -webkit-transition-duration: 0.4s; transition-duration: 0.4s;" />
                                                            </ItemTemplate>
                                                        </asp:DataList>
                                                        <asp:DataList ID="ddUnits2" runat="server" Visible="false"
                                                            RepeatLayout="Table" RepeatDirection="Horizontal" RepeatColumns="20"
                                                            OnItemDataBound="ddRoomListSecond_ItemDataBound">
                                                            <ItemTemplate>
                                                                <asp:Button CssClass="btn btn-success" ID="btns1" runat="server" ForeColor="White" OnClick="btnClick"
                                                                    Text='<%#  Eval("Unitname")%>' CommandArgument='<%# Eval("UnitId") %>'
                                                                    CommandName='<%# Eval("Floor") %>' Style="font-size: small; word-wrap: break-word; float: left; white-space: normal; -webkit-transition-duration: 0.4s; transition-duration: 0.4s;" />
                                                            </ItemTemplate>
                                                        </asp:DataList>
                                                        <asp:DataList ID="ddUnits3" runat="server" Visible="false"
                                                            RepeatLayout="Table" RepeatDirection="Horizontal" RepeatColumns="20"
                                                            OnItemDataBound="ddRoomListSecond_ItemDataBound">
                                                            <ItemTemplate>
                                                                <asp:Button CssClass="btn btn-success" ID="btns1" runat="server" ForeColor="White" OnClick="btnClick"
                                                                    Text='<%#  Eval("Unitname")%>' CommandArgument='<%# Eval("UnitId") %>'
                                                                    CommandName='<%# Eval("Floor") %>' Style="font-size: small; word-wrap: break-word; float: left; white-space: normal; -webkit-transition-duration: 0.4s; transition-duration: 0.4s;" />
                                                            </ItemTemplate>
                                                        </asp:DataList>
                                                        <asp:DataList ID="ddUnits4" Visible="false" runat="server" RepeatLayout="Table" RepeatDirection="Horizontal" RepeatColumns="20"
                                                            OnItemDataBound="ddRoomListSecond_ItemDataBound">
                                                            <ItemTemplate>
                                                                <asp:Button CssClass="btn btn-success" ID="btns1" runat="server" ForeColor="White" OnClick="btnClick"
                                                                    Text='<%#  Eval("Unitname")%>' CommandArgument='<%# Eval("UnitId") %>'
                                                                    CommandName='<%# Eval("Floor") %>' Style="font-size: small; word-wrap: break-word; float: left; white-space: normal; -webkit-transition-duration: 0" />
                                                            </ItemTemplate>
                                                        </asp:DataList>



                                                    </div>
                                                    <%--  Floor End--%>
                                                    <div class="col-lg-6" style="padding-bottom: 5px;display:none">
                                                        <label>Select Status </label>
                                                        <div class="input-group">
                                                            <span class="input-group-addon input-circle-left">
                                                                <i class="fa fa-user"></i>
                                                            </span>
                                                            <asp:DropDownList ID="ddlSelectapprover" runat="server" CssClass="form-control">
                                                                <asp:ListItem Value="">Select</asp:ListItem>
                                                                <%--<asp:ListItem Text="Manager" />
                                                                <asp:ListItem Text="Client" />--%>
                                                                <%-- <asp:ListItem Text="3" />
                                                        <asp:ListItem Text="4" />--%>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-6"  style="padding-bottom: 5px;display:none">
                                                        <label>Select Status </label>
                                                        <div class="form-group">
                                                            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control" placeholder="Select" Enabled="false">
                                                                <asp:ListItem Value="">Select</asp:ListItem>
                                                                <asp:ListItem Text="Draft" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Text="Approved"></asp:ListItem>
                                                                <asp:ListItem Text="Rejected"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <center>
                                                <div class="col-lg-12" runat="server" visible="false">
                                                    <asp:Button ID="btnsave" Text="Save" runat="server" CssClass="btn btn-success" />
                                                    <asp:Button ID="btncancel" Text="Cancel" runat="server" CssClass="btn btn-danger" PostBackUrl="~/WarehouseGridpage.aspx" />
                                                    <%-- <asp:Button ID="btsclear" Text="Clear" runat="server" CssClass="btn btn-warning" PostBackUrl="~/Warehouse.aspx" />--%>
                                                </div>
                                            </center>
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

    <%-- <script src="assets/global/plugins/jquery.min.js" type="text/javascript"></script>
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
    </script>--%>
</body>
</html>
