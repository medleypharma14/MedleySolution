<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WarehouseUnitchange.aspx.cs" Inherits="Medly_Wm.WraehouseUnitchange" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/Header.ascx" %>
<%@ Register TagPrefix="usc1" TagName="Sidebar" Src="~/Sidebar.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
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
        label{
            font-weight:bold;
        }
    </style>
  <script type="text/javascript">
      function convertToUpperCase(element) {
          element.value = element.value.toUpperCase();
      }
  </script>
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
                     <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="portlet light ">
                                <div class="portlet box green">
                                    <div class="portlet-title">
                                        <div class="caption">
                                            <i class="fa fa-cogs"></i>Warehouse Unit Change
                                        </div>
                                    </div>
                                </div>
                                <div class="actions">
                                </div>
                                <div class="portlet-title">
                                    <div class="form-body">
                                        <div class="col-lg-12">
                                            <div class="col-lg-12">
                                                <div class="col-lg-12">
                                                    <div class="col-lg-6 row">
                                                        <div class="list-group">
                                                            <div class="row">
                                                            <div class="col-lg-8">
                                                                    <label><b>Previous Unit</b></label>
                                                                    <asp:TextBox runat="server" ID="txtPreviousunit" placeholder="Enter Send Unit Name..." MaxLength="5" onkeyup="convertToUpperCase(this);" CssClass="form-control alert-danger" />
                                                                </div>
                                                            <div class="col-lg-4" style="padding-top: 25px;padding-right:0px">
                                                                <asp:Button Text="Check Unit" runat="server" CssClass="btn btn-group-lg green" OnClick="txtPreviousunit_TextChanged" />
                                                            </div>
                                                                </div>
                                                            <br />
                                                            <div class="row">
                                                            <div class="col-lg-7">
                                                                <div class="form-group">
                                                                    <label id="lblprnm" Visible="false" runat="server" >Product Name</label>
                                                                    <asp:Label CssClass="form-control" ID="lblProductname" Visible="false" runat="server" />
                                                                </div>
                                                               </div>
                                                                <div class="col-lg-2">
                                                                    <div class="form-group">
                                                                    <label id="lblqty" Visible="false" runat="server">Quantity</label>
                                                                    <asp:Label CssClass="form-control" ID="lblQuantity" Visible="false" runat="server" />
                                                                        </div>
                                                                </div>
                                                                <div class="col-lg-3">
                                                                    <div class="form-group">
                                                                    <label id="lblExpry" Visible="false" runat="server" >Expirydate</label>
                                                                    <asp:Label CssClass="form-control" ID="lblExpryDate" Visible="false" runat="server" />
                                                                        </div>
                                                                </div>
                                                               </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <div class="list-group">
                                                            <div class="row">
                                                                <div class="col-lg-6">
                                                                    <label><b>Change Unit</b></label>
                                                                    <asp:TextBox runat="server" ID="txtChangeunit" placeholder="Enter Receiving Unit Name..." MaxLength="5" onkeyup="convertToUpperCase(this);" CssClass="form-control alert-info" />
                                                                </div>
                                                            <div class="col-lg-3" style="padding-top: 25px">
                                                                <asp:Button Text="Check Unit" runat="server" CssClass="btn btn-group-lg green" OnClick="txtChangeunit_TextChanged" />
                                                            </div>
                                                            <div class="col-lg-3" style="padding-top: 25px">
                                                                <asp:Button Text="Save" runat="server" CssClass="btn btn-group-lg green"/>
                                                            </div>
                                                        </div>
                                                            <br />
                                                            <div class="row">
                                                                <div class="col-lg-7">
                                                                    <div class="form-group">
                                                                        <label id="lblp" visible="false" runat="server">Product Name</label>
                                                                        <asp:Label CssClass="form-control" ID="lblpn" Visible="false" runat="server" />
                                                                    </div>
                                                                </div>
                                                                <div class="col-lg-2">
                                                                    <div class="form-group">
                                                                        <label id="lblq" visible="false" runat="server">Quantity</label>
                                                                        <asp:Label CssClass="form-control" ID="lblqy" Visible="false" runat="server" />
                                                                    </div>
                                                                </div>
                                                                <div class="col-lg-3">
                                                                    <div class="form-group">
                                                                        <label id="lble" visible="false" runat="server">Expirydate</label>
                                                                        <asp:Label CssClass="form-control" ID="lbled" Visible="false" runat="server" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            </div>
                                                    </div>
                                                </div>
                                                                                          
                                            </div>

                                            <div class="col-lg-6" style="display:none">
                                                <label>Floor No:</label>
                                                <asp:Label ID="lblFloor" runat="server" CssClass="form-control"></asp:Label><br />
                                            </div>

                                            <div class="col-lg-6" style="display:none">
                                                <label>Unitname: </label>
                                                <asp:Label ID="lblUnit" runat="server" CssClass="form-control"></asp:Label><br />
                                            </div>
                                            <div class="container">

                                               
                                                <div class="col-lg-4" style="display:none">
                                                    <label>
                                                        Number Of Aisle
                                                    </label>
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
                                                    <div class="input-group">
                                                        <span class="input-group-addon ">
                                                            <i class="fa fa-user"></i>
                                                        </span>
                                                        <asp:DropDownList ID="ddlNumberoffloors" runat="server" CssClass="form-control" Width="150px">
                                                            <asp:ListItem Value="">Select</asp:ListItem>
                                                            <asp:ListItem Text="1" />
                                                            <asp:ListItem Text="2" />
                                                            <asp:ListItem Text="3" />
                                                            <asp:ListItem Text="4" />
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="col-lg-12">
                                                <div class="col-lg-12" style="margin-left: ; border: 1px solid skyblue; width: ; margin-bottom: 10px;">
                                                    <b>Generate map</b>
                                                    <div class="">   
                                                        <div class="col-lg-12">
                                                            <asp:Label ID="lblDisplay" runat="server" ForeColor="Green" Font-Size="Small"></asp:Label>
                                                        </div>
                                                    </div>
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
                                                    <div class="col-lg-6" style="padding-bottom: 5px;display:none">
                                                        <label>Select Status </label>
                                                        <div class="input-group">
                                                            <span class="input-group-addon input-circle-left">
                                                                <i class="fa fa-user"></i>
                                                            </span>
                                                            <asp:DropDownList ID="ddlSelectapprover" runat="server" CssClass="form-control">
                                                                <asp:ListItem Value="">Select</asp:ListItem>
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
</body>
</html>

