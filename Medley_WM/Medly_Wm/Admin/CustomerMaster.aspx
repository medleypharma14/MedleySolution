<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerMaster.aspx.cs"
    Inherits="AdminAfforadbleApp.CustomerMaster" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/Admin/Header.ascx" %>
<%@ Register TagPrefix="usc2" TagName="Header2" Src="~/Admin/HeaderTop.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Customer Master</title>
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
    <div class="clearfix">
    </div>
    <div class="page-container">
        <usc:Header ID="Header" runat="server" />
        <form id="form1" runat="server">
        <asp:ScriptManager ID="sc1" runat="server">
        </asp:ScriptManager>
        <div>
            <div class="page-content-wrapper">
                <!-- BEGIN CONTENT BODY -->
                <div class="page-content">
                    <!-- BEGIN PAGE HEADER-->
                    <!-- BEGIN THEME PANEL -->
                    <!-- END THEME PANEL -->
                    <h1 class="page-title">
                        Customer Master
                    </h1>
                    <div class="row">
                        <div class="col-md-6">
                            <!-- BEGIN EXAMPLE TABLE PORTLET-->
                            <div class="portlet light">
                                <div class="portlet-title">
                                    <div class="caption font-dark">
                                        <span class="caption-subject bold uppercase">Customer List </span>
                                       
                                    </div>
                                </div>
                                <div class="portlet-body">
                                    <div class="table-toolbar">
                                        <asp:GridView ID="gvCustomer" DataKeyNames="CustomerId" AutoGenerateColumns="false"
                                            Width="100%" OnSelectedIndexChanged="gvCustomer_SelectedIndexChanged" CssClass="table table-striped table-bordered table-hover table-checkable order-column"
                                            runat="server">
                                            <Columns>
                                                <asp:BoundField HeaderText="Customerid" DataField="Customerid" Visible="false" />
                                                <asp:BoundField HeaderText="Customer Name" DataField="CustomerName" />
                                                <asp:BoundField HeaderText="MobileNo" DataField="MobileNo" />
                                                <%--  <asp:BoundField HeaderText="EmailId" DataField="Email" />
                                <asp:BoundField HeaderText="Address" DataField="Address" />--%>
                                                <asp:TemplateField HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" CommandArgument='<%#Eval("CustomerId") %>'
                                                            CommandName="Select"></asp:LinkButton></ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkdelete" runat="server" Text="Delete" CommandArgument='<%#Eval("CustomerId") %>'
                                                            CommandName="Del"></asp:LinkButton></ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                            <!-- END EXAMPLE TABLE PORTLET-->
                        </div>
                        <div class="col-md-6">
                            <!-- BEGIN EXAMPLE TABLE PORTLET-->
                            <div class="portlet light ">
                                <div class="portlet-title">
                                    <div class="caption font-dark">
                                        <span class="caption-subject bold uppercase">Customer Master </span>
                                       
                                    </div>
                                </div>
                                <div class="portlet-body">
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="form-group form-md-line-input has-success">
                                                <asp:Label ID="lblid" runat="server" Visible="false"></asp:Label>
                                                <asp:TextBox CssClass="form-control" ID="txtCustomername" runat="server" placeholder="Enter Customer Name"></asp:TextBox>
                                            </div>
                                            <div class="form-group form-md-line-input has-success">
                                                <asp:TextBox CssClass="form-control" ID="txtAddress" runat="server" placeholder="Enter Address"></asp:TextBox>
                                            </div>
                                            <div class="form-group form-md-line-input has-success">
                                                <asp:TextBox CssClass="form-control" ID="txtMobileno" MaxLength="10" runat="server" placeholder="Enter Mobile No"></asp:TextBox>
                                            </div>
                                            <div class="form-group form-md-line-input has-success">
                                                <asp:TextBox CssClass="form-control" ID="txtEmail" runat="server" placeholder="Enter Email Id"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div id="Div1" runat="server" style="overflow: auto; height: 150px">
                                        <asp:UpdatePanel  runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="gvForum" AutoGenerateColumns="False" ShowFooter="True" OnRowDataBound="gvForum_RowDataBound"
                                                OnRowDeleting="gvForum_RowDeleting" CssClass="chzn-container" GridLines="None"
                                                Width="100%" runat="server">
                                                <HeaderStyle BackColor="#32c5d2" BorderStyle="Solid" BorderWidth="1px" BorderColor="Gray"
                                                    Font-Names="arial" Font-Size="Smaller" HorizontalAlign="Center" />
                                                <RowStyle BorderStyle="Solid" BorderWidth="0.5px" BorderColor="Gray" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No" ControlStyle-Width="100%" ItemStyle-Width="1%"
                                                        Visible="false" HeaderStyle-Width="1%">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtno" Text="<%#Container.DataItemIndex+1 %>" Height="30px" runat="server"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText=" Product " ControlStyle-Width="100%" HeaderStyle-Width="5%"
                                                        ItemStyle-Width="45%">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="drpProduct" data-width="100%" Class="form-control select2"
                                                                data-filter="true" runat="server" Height="35px" Width="100%" AppendDataBoundItems="true">
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText=" Purchase Date " ControlStyle-Width="100%" HeaderStyle-Width="2%"
                                                        ItemStyle-Width="20%" Visible="true">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtPurchasedate" Text="" Enabled="true" Height="30px" runat="server"></asp:TextBox>
                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server"  CssClass="cal_Theme1"
                                                                Format="dd/MM/yyyy" TargetControlID="txtPurchasedate">
                                                            </ajaxToolkit:CalendarExtender>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Next Service Date" ControlStyle-Width="100%" HeaderStyle-Width="2%"
                                                        ItemStyle-Width="20%" Visible="true">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtServicedate" Text="" Enabled="true" Height="30px" runat="server"></asp:TextBox>
                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server"  CssClass="cal_Theme1"
                                                                Format="dd/MM/yyyy" TargetControlID="txtServicedate">
                                                            </ajaxToolkit:CalendarExtender>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="1%">
                                                        <ItemTemplate>
                                                            <asp:Button ID="ButtonAdd1" runat="server" AutoPostback="false" EnableTheming="false"
                                                                Height="30px" OnClick="ButtonAdd1_Click" Text="Add New" Visible="true" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
                                                </Columns>
                                            </asp:GridView>
                                            </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div>
                                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success" Text="Save" OnClick="btnSave_Click" />
                                        <asp:Button ID="btnReset" runat="server" CssClass="btn btn-danger" Text="Reset" OnClick="btnReset_Click" />
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
