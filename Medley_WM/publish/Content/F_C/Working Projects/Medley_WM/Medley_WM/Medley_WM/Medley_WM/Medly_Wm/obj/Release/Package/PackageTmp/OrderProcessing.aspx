<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderProcessing.aspx.cs" Inherits="Medly_Wm.OrderGoodsPicking1" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/Header.ascx" %>
<%@ Register TagPrefix="usc1" TagName="Sidebar" Src="~/Sidebar.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Order Processing</title>
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
        label{
            font-weight:bold;
        }
    </style>
</head>

<body class="page-header-fixed page-sidebar-closed-hide-logo page-container-bg-solid page-md">

    <usc1:Sidebar ID="Sidebar1" runat="server" />
    <div class="page-container">

        <usc:Header ID="Header1" runat="server" />
        <div class="page-content-wrapper">
            <!-- BEGIN CONTENT BODY -->
            <div class="page-content">
                <form id="form2" runat="server">
                    <div>
                        <div class="row">
                            <div class="col-md-12 ">
                                <!-- BEGIN SAMPLE FORM PORTLET-->
                                <div class="portlet light ">
                                    <div class="portlet-title">
                                        <div class="caption font-red-sunglo">
                                            <i class="icon-settings font-red-sunglo"></i>
                                            <span class="caption-subject bold uppercase">Order Goods Picking</span>
                                        </div>
                                        <div class="actions">
                                            <div class="btn-group">
                                                <%--<a class="btn btn-sm green" href="javascript:;" data-toggle="">New
                                                <i class=""></i>
                                                </a>--%>
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

                                        <div class="col-lg-12">
                                                                      
                                        <div class="col-lg-4" >
                                         
                                            <label>SO Number</label>
                                            
                                            <div class="input-group">
                                                <asp:TextBox ID="txtSOnumber" CssClass="form-control" runat="server"></asp:TextBox>
                                                <asp:TextBox ID="txtSuppid" Visible="false" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            </div>
                                                   <div class="col-lg-4">
                                                         <div class="form-group">
                                                                       <label>Order Qty</label>
                                            
                                            <div class="input-group">
                                                <asp:TextBox ID="txtQty" CssClass="form-control" runat="server"  OnTextChanged="txtQty_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            </div>
                                                             </div>
                                                   <div class="form-group" style="display:none">
                                                <label>Transpot Company</label>
                                                <div class="input-group">
                                                    <span class="input-group-addon input-circle-left">
                                                        <i class="fa fa-truck"></i>
                                                    </span>
                                                    <asp:DropDownList ID="ddltranscmp" CssClass="form-control" runat="server" Visible="false">
                                                    </asp:DropDownList>
                                                </div>
                                                       </div>
                                            </div>
                                            <div class="col-lg-4">
                                                 <label>Remaining</label>
                                                <div class="input-group">
                                                <asp:TextBox ID="txtRemaining"  CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                                            </div>
                                            </div>
                                    </div>
                                    <div class="portlet light">
                                        <div class="col-lg-12">
                                        <div style="overflow: auto">
                                            <%--<asp:GridView ID="gvPo" runat="server"  CssClass="table table-striped table-success table-active  flip-content" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="gvPo_RowCommand">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Sl No">
                                                        <ItemTemplate>
                                                            <%#Container.DataItemIndex+1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                          
                                                       <asp:BoundField HeaderText="Order Qty" DataField="SOQty" Visible="false"/>
                                                    <asp:BoundField HeaderText="ProductId" DataField="ProductId" />
                                                   
                                                    <asp:BoundField HeaderText="Product Name" DataField="Productname" />
                                                     <asp:BoundField HeaderText="Pack size" DataField="Packsize" />
                                                     <asp:BoundField HeaderText="price per pack" DataField="priceperpack" />
                                                  <asp:BoundField HeaderText="VAT %" DataField="VAT" />
                                                    <asp:BoundField HeaderText="Batch number" DataField="Batchnumber" />
                                                   
                                                      <asp:BoundField HeaderText="Unit name" DataField="Unitname" />
                                                     <asp:BoundField HeaderText="Available Qty" DataField="TotalQty" />
                                                     
                                                  <%--  <asp:BoundField HeaderText="Manf Date" DataField="ManfactDate" DataFormatString="{0:dd/MM/yyyy}" />--%>
                                               <%--     <asp:BoundField HeaderText="ExpiryDate" DataField="ExpiryDate" DataFormatString="{0:dd/MM/yyyy}" />
                                                    <asp:TemplateField HeaderText="Picking" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtqty" runat="server" CssClass="form-control" placeholder="Enter text"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                    <%--   <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btndel" runat="server" CommandArgument='<%#Eval("GRId") %>'
                                                                    CommandName="Del" OnClientClick="return confirm('Are you sure to delete this Product?');">

                                                                    <asp:ImageButton ID="imgDel" ImageUrl="~/Images/delete.png" runat="server" Width="20px" CommandArgument='<%#Eval("GRId") %>'
                                                                        CommandName="Del" />
                                                                </asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                               <%-- </Columns>--%>
                                                <%--<EditRowStyle BackColor="#2461BF" />
                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                <RowStyle BackColor="#EFF3FB" />
                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                                <SortedDescendingHeaderStyle BackColor="#4870BE" />--%>
                                           <%-- </asp:GridView>--%>

                                            <asp:GridView ID="gvPo" runat="server" CssClass="table table-striped table-success table-active  flip-content" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="gvPo_RowCommand">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Sl No">
                                                            <ItemTemplate>
                                                                <%#Container.DataItemIndex+1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="ProductId" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                            <ItemTemplate>
                                                                <asp:Label ID="txtProductId" runat="server" CssClass="form-control" Text='<%# Eval("ProductId")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Productname" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                            <ItemTemplate>
                                                                <asp:Label ID="txtProductname" runat="server" CssClass="form-control" Text='<%# Eval("Productname")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Order Qty" ItemStyle-HorizontalAlign="Center" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="txtSOQty" runat="server" CssClass="form-control" Text='<%# Eval("remaining")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Batch Number" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                            <ItemTemplate>
                                                                <asp:Label ID="txtbatchnumber" runat="server" CssClass="form-control" Text='<%# Eval("Batchnumber")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Unit name" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                            <ItemTemplate>
                                                                <asp:Label ID="txtUnitname" runat="server" CssClass="form-control" Text='<%# Eval("Unitname")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Available Qty" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                            <ItemTemplate>
                                                                <asp:Label ID="txtTotalQty" runat="server" CssClass="form-control" Text='<%# Eval("TotalQty")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Pallets Ref No" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                            <ItemTemplate>
                                                                <asp:Label ID="txtPalletsref" runat="server" CssClass="form-control" Text='<%# Eval("Palletsrefno")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="ExpiryDate" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                            <ItemTemplate>
                                                                <asp:Label ID="txtExpiryDate" runat="server" CssClass="form-control" Text='<%# Eval("ExpiryDate")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Picking" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtremarks" runat="server" CssClass="form-control" Text='<%# Eval("Qty")%>' Enabled="false"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <%--   <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btndel" runat="server" CommandArgument='<%#Eval("GRId") %>'
                                                                    CommandName="Del" OnClientClick="return confirm('Are you sure to delete this Product?');">

                                                                    <asp:ImageButton ID="imgDel" ImageUrl="~/Images/delete.png" runat="server" Width="20px" CommandArgument='<%#Eval("GRId") %>'
                                                                        CommandName="Del" />
                                                                </asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                    </Columns>
                                                    <%--<EditRowStyle BackColor="#2461BF" />
                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                <RowStyle BackColor="#EFF3FB" />
                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                                <SortedDescendingHeaderStyle BackColor="#4870BE" />--%>
                                                </asp:GridView>
                                        </div>
                                            </div>
                                        <div class="row">
                                            <center>
                                                <div class="col-lg-12">

                                                    <%--   <asp:Button ID="btnClear" runat="server" BorderColor="SkyBlue" class="btn default" Text="Clear" PostBackUrl="~/CreatePO.aspx" />--%>
                                                    <asp:Button ID="btnSubmit" runat="server" BorderColor="SkyBlue" class="btn btn-success" Text="Save" ValidationGroup="Validation" OnClick="btnSubmit_Click" />
                                                    <asp:Button ID="btnCancel" runat="server" BorderColor="SkyBlue" class="btn btn-danger" Text="Cancel" />
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
</body>
</html>
