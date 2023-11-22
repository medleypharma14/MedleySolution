<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReturnSales.aspx.cs" Inherits="Medly_Wm.ReturnSales" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/Header.ascx" %>
<%@ Register TagPrefix="usc1" TagName="Sidebar" Src="~/Sidebar.ascx" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Batch Return Reports</title>
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
    <link href="assets/global/css/components-md.min.css" rel="stylesheet" id="style_components1" type="text/css" />
    <link href="assets/global/css/plugins-md.min.css" rel="stylesheet" type="text/css" />
    <!-- END THEME GLOBAL STYLES -->
    <!-- BEGIN THEME LAYOUT STYLES -->
    <link href="assets/layouts/layout2/css/layout.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/layouts/layout2/css/themes/blue.min.css" rel="stylesheet" type="text/css" id="style_color1" />
    <link href="assets/layouts/layout2/css/custom.min.css" rel="stylesheet" type="text/css" />
    <!-- END THEME LAYOUT STYLES -->
    <link rel="shortcut icon" href="favicon.ico" />
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
                    <div class="row">
                        <div class="col-md-12 ">
                            <div class="portlet box green">
                                <div class="portlet-title">
                                    <div class="caption">
                                        <i class="fa fa-cogs"></i>Sales Return
                                    </div>
                                </div>
                                <div class="portlet-body">
                                    <div class="row">
                                        <div class="form-group">
                                              <div class="col-lg-3">
                                        <label><b>Company Name</b></label>
                                        <asp:DropDownList ID="ddlCompanyname" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="ddlCompanyname_TextChanged">
                                        </asp:DropDownList>
                                    </div>
                                          <div class="col-lg-3">
                                        <label><b>Customer Name</b></label>
                                        <asp:DropDownList ID="ddlSuppliername" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="ddlSuppliername_TextChanged">
                                        </asp:DropDownList>
                                    </div>
                                         <div class="col-lg-2">
                                        <label><b>SO Number</b></label>
                                        <asp:DropDownList ID="ddlSONumber" AutoPostBack="true" runat="server" CssClass="form-control" OnTextChanged="ddlSONumber_TextChanged">
                                        </asp:DropDownList>
                                    </div>
                                         <div class="col-lg-2">
                                        <label><b>Return Date</b></label>
                                        <asp:TextBox ID="txtReturndate" runat="server" CssClass="form-control" TextMode="Date" Enabled="false"></asp:TextBox>
                                    </div>
                                         <div class="col-lg-2">
                                        <label><b>Return No</b></label>
                                        <asp:TextBox ID="txtReturnNo" runat="server" text="5001" CssClass="form-control" Enabled="false"></asp:TextBox>
                                    </div>
                                            </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div id="returngrid" runat="server" visible="false" style="padding:10px;overflow:auto">
                                            <asp:GridView ID="gvReturn" runat="server" CssClass="table table-bordered table-striped table-condensed flip-content" AutoGenerateColumns="False"  ForeColor="#333333" HorizontalAlign="Center" ShowHeaderWhenEmpty="True" CellPadding="4" OnRowDataBound="gvReturn_RowDataBound" GridLines="None">
                                               <Columns>
                                                 <asp:BoundField HeaderText="Soid" DataField="Soid" Visible="false"/>
                                                   <asp:BoundField HeaderText="ProductId" DataField="Productid"  Visible="false"/>
                                                   <asp:TemplateField>
                                                       <ItemTemplate>
                                                           <asp:HiddenField ID="Hidden" runat="server"
                                                               Value='<%#Eval("Productid")%>' />
                                                       </ItemTemplate>
                                                   </asp:TemplateField>
                                                   <asp:BoundField HeaderText="LicenseNo" DataField="Licenseno" Visible="false" />
                                                <asp:BoundField HeaderText="ProductName" DataField="Productname" />
                                                <asp:BoundField HeaderText="DosageForm" DataField="Dosageform" Visible="false"/>
                                                <asp:BoundField HeaderText="Strength" DataField="Strength" Visible="false"/>
                                                <asp:BoundField HeaderText="PricePerPack" DataField="Priceperpack" Visible="false" />
                                                    <asp:TemplateField HeaderText="Price Per Pack" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="110px">
                                                       <ItemTemplate>
                                                           <asp:Label Text='<%#Eval("Priceperpack") %>' runat="server" ID="txtPriceperpack"  CssClass="form-control" Width="110px" />
                                                       </ItemTemplate>
                                                   </asp:TemplateField>
                                                <asp:BoundField HeaderText="VAT%" DataField="VAT"  Visible="false"/>
                                                   <asp:TemplateField HeaderText="VAT" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="110px">
                                                       <ItemTemplate>
                                                           <asp:Label Text='<%#Eval("VAT") %>' runat="server" ID="txtVAT"  CssClass="form-control" Width="110px" />
                                                       </ItemTemplate>
                                                   </asp:TemplateField>
                                                <asp:BoundField HeaderText="Total Amount" DataField="Totalamount" />
                                               <asp:BoundField HeaderText="Sales Qty" DataField="SoQty" />
                                                   <asp:TemplateField HeaderText="Return Qty" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="150px">
                                                       <ItemTemplate>
                                                           <asp:TextBox runat="server" ID="txtReturnQty" CssClass="form-control" Width="110px" Text="0" AutoPostBack="true"  onkeypress="return isNumberKey(event)" OnTextChanged="txtReturnQty_TextChanged" />
                                                       </ItemTemplate>
                                                   </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Return Amount" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="150px">
                                                       <ItemTemplate>
                                                           <asp:TextBox runat="server" ID="txtReturnAmnt" Text="0" CssClass="form-control" AutoPostBack="true"  Width="110px" OnTextChanged="txtReturnAmnt_TextChanged" />
                                                       </ItemTemplate>
                                                   </asp:TemplateField>
                                               </Columns> 
                                            </asp:GridView>
                                        </div>
                                        <div id="EditReturngrid" runat="server" visible="false" style="padding:10px;overflow:auto">
                                            <asp:GridView ID="Vieweditgrid" runat="server" CssClass="table table-bordered table-striped table-condensed flip-content" AutoGenerateColumns="False"  ForeColor="#333333" HorizontalAlign="Center" ShowHeaderWhenEmpty="True" CellPadding="4" GridLines="None">
                                               <Columns>
                                                 <asp:BoundField HeaderText="Soid" DataField="Soid"/>
                                                   <asp:BoundField HeaderText="ProductId" DataField="Productid" />
                                                   <asp:BoundField HeaderText="LicenseNo" DataField="Licenseno" Visible="false" />
                                                <asp:BoundField HeaderText="ProductName" DataField="Productname" />
                                                <asp:BoundField HeaderText="DosageForm" DataField="Dosageform" Visible="false"/>
                                                <asp:BoundField HeaderText="Strength" DataField="Strength" Visible="false"/>
                                                <asp:BoundField HeaderText="PricePerPack" DataField="Priceperpack" />
                                                <asp:BoundField HeaderText="VAT%" DataField="VAT" />
                                                <asp:BoundField HeaderText="Total Amount" DataField="Totalamount" />
                                               <asp:BoundField HeaderText="Sales Qty" DataField="SoQty" />
                                                   <asp:BoundField HeaderText="Return Qty" DataField="ReturnQty"/>
                                                   <asp:BoundField HeaderText="Return Amount" DataField="ReturnAmount1"/>
                                               </Columns> 
                                            </asp:GridView>
                                        </div>
                                    </div>
                                    <div class="row">
                                      <div class="col-lg-4" id="apprvr" runat="server" visible="true">
                                        <label><b>Select Approver</b></label>
                                        <asp:DropDownList ID="ddlApprover" runat="server" CssClass="form-control" AutoPostBack="true">
                                        </asp:DropDownList>
                                       </div>
                                         <div class="col-lg-4" id="stts" runat="server" visible="true">
                                        <label><b>Select Status</b> </label>
                                        <div class="form-group">
                                            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control" placeholder="Select" Enabled="false">
                                                <asp:ListItem Value="">Select</asp:ListItem>
                                                <asp:ListItem Text="Draft" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="Approved"></asp:ListItem>
                                                <asp:ListItem Text="Rejected"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                         <div class="col-lg-2" style="float:right;padding-left:10px">
                                        <label><b>Total Return Amount</b></label>
                                        <asp:TextBox ID="txtTotalReturnamnt" runat="server" CssClass="form-control" Text="0"  Enabled="false" style="text-align: right;"></asp:TextBox>
                                    </div>
                                    </div>
                                    <div class="row">
                                    <center>
                                        <div class="col-lg-12" id="btns" runat="server" visible="true">
                                            <%--   <asp:Button ID="btnClear" runat="server" BorderColor="SkyBlue" class="btn default" Text="Clear" PostBackUrl="~/CreatePO.aspx" />--%>
                                            <asp:Button ID="btnSubmit" runat="server" BorderColor="SkyBlue" Text="Submit" class="btn btn-success" OnClick="btnSubmit_Click"  />
                                            <asp:Button ID="btnCancel" runat="server" BorderColor="SkyBlue" class="btn btn-danger" Text="Cancel" PostBackUrl="~/ReturnSales.aspx" />
                                        </div>
                                    </center>
                                        <asp:Label Text="text" ID="lblsoid" runat="server" Visible="false" />
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
