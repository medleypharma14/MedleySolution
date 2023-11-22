<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Traceablity.aspx.cs" EnableEventValidation = "false" Inherits="Medly_Wm.Traceablity" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/Header.ascx" %>
<%@ Register TagPrefix="usc1" TagName="Sidebar" Src="~/Sidebar.ascx" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Traceablity Reports</title>
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
        /*.col-lg-12 {
            padding: 10px;
        }*/
    </style>
     <script type="text/javascript">
         function printPage() {
             window.print();
             return false; // This prevents the server-side click event from being triggered.
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
                    <div class="portlet light">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="fa fa-cogs"></i>Traceablity List
                            </div>
                        </div>
                       <div class="portlet-title">
                        <div class="portlet-body flip-scroll">
                            <div class="col-lg-12" id ="head" runat="server">
                            <div class="col-lg-4">
                                <div class="form-group">
                                    <label><b>Enter Batch No</b></label>
                                    <div class="input-group">
                                        <span class="input-group-addon input-square-left">
                                            <i class="fa fa-user"></i>
                                        </span>

                                        <%--<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator14" ControlToValidate="txtsupplierid"
                                                        ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Supplier ID" Style="color: Red" />--%>
                                        <asp:TextBox ID="txtBatchno" runat="server" CssClass="form-control" placeholder="Enter ID..."></asp:TextBox>
                                    </div>
                                </div>

                            </div>
                            <div class="col-lg-2">
                                <div class="form-group">
                                    <label></label>
                                    <div class="input-group">
                                        <%-- <span class="input-group-addon input-circle-left">
                                                    <i class="fa fa-calendar"></i>
                                                </span>--%>
                                        <asp:Button Text="Search" ID="btnGo" Class="btn btn-success" runat="server" OnClick="btnGo_Click" />
                                    </div>
                                </div>
                            </div>
                                <div class="col-lg-4" style="padding-top:20px">
                                        <div class="form-group">
                                             <asp:Button CssClass="btn btn-success" OnClick="linkprint_Click" style="background-color:#2672ed" ID="linkprint" runat="server"  Text="Print" OnClientClick="return printPage();" Visible="false"></asp:Button>
                                        </div>
                                    </div>
                                  <div class="col-lg-2" style="float:right;padding-top:20px">
                                    <div class="form-group">
                                        <asp:Button ID="btnexp" runat="server" class="btn  btn-success"
                                            Text="Export To Excel" OnClick="btnexp_Click" />
                                    </div>
                                </div>
                                </div>
                            <div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label><b>Batch Name</b></label>
                                    <div class="input-group">
                                        <span class="input-group-addon input-square-left">
                                            <i class="fa fa-user"></i>
                                        </span>

                                        <%--<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator14" ControlToValidate="txtsupplierid"
                                                        ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Supplier ID" Style="color: Red" />--%>
                                        <asp:TextBox ID="txtbatchname" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>

                            </div>
                                  <div class="col-lg-3">
                                <div class="form-group">
                                    <label><b>product  Name</b></label>
                                    <div class="input-group">
                                        <span class="input-group-addon input-square-left">
                                            <i class="fa fa-user"></i>
                                        </span>

                                        <%--<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator14" ControlToValidate="txtsupplierid"
                                                        ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Supplier ID" Style="color: Red" />--%>
                                        <asp:TextBox ID="txtProductName" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>

                            </div>
                             <div class="col-lg-3">
                                <div class="form-group">
                                    <label><b>Supplier  Name</b></label>
                                    <div class="input-group">
                                        <span class="input-group-addon input-square-left">
                                            <i class="fa fa-user"></i>
                                        </span>
                                        <asp:TextBox ID="txtSuppliername" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>

                            </div>
                                <div class="col-lg-3">
                                <div class="form-group">
                                    <label><b>Goods Receipt number</b></label>
                                    <div class="input-group">
                                        <span class="input-group-addon input-square-left">
                                            <i class="fa fa-user"></i>
                                        </span>
                                        <asp:TextBox ID="txtgrnumber" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>

                            </div>
                                 <div class="col-lg-3">
                                <div class="form-group">
                                    <label><b>Goods Received Date</b></label>
                                    <div class="input-group">
                                        <span class="input-group-addon input-square-left">
                                            <i class="fa fa-calenter"></i>
                                        </span>
                                        <asp:TextBox ID="txtgrreceived" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>

                            </div>
                                 <div class="col-lg-3">
                                <div class="form-group">
                                    <label><b>Total Received Qty</b></label>
                                    <div class="input-group">
                                        <span class="input-group-addon input-square-left">
                                            <i class="fa fa-calenter"></i>
                                        </span>
                                        <asp:TextBox ID="txtreceivedqty" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>

                            </div>
                                 <div class="col-lg-3">
                                <div class="form-group">
                                    <label><b>Sample Qty</b></label>
                                    <div class="input-group">
                                        <span class="input-group-addon input-square-left">
                                            <i class="fa fa-calenter"></i>
                                        </span>
                                        <asp:TextBox ID="txtsamqty" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>

                            </div>
                            </div>
                            <div id="excel" runat="server">
                             <div class="col-lg-3">
                                <div class="form-group">
                                    <label><b>Available Qty</b></label>
                                    <div class="input-group">
                                        <span class="input-group-addon input-square-left">
                                            <i class="fa fa-calenter"></i>
                                        </span>
                                        <asp:TextBox ID="txtfinalqty" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>

                            </div>
                            <asp:Label Text="Purchhase Order Details" ID="lblpohead" runat="server" Visible="false" />
                             <div class="row">
                                <asp:GridView ID="traceunit" runat="server" CssClass="table table-bordered table-striped table-condensed flip-content" AutoGenerateColumns="False" ForeColor="#333333" HorizontalAlign="Center" ShowHeaderWhenEmpty="True" CellPadding="4" GridLines="None">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       <asp:BoundField HeaderText="Unit  Name" DataField="Unitname" />
                                        <asp:BoundField HeaderText="Order Qty" DataField="Qty" />
                                        <asp:BoundField HeaderText="Sample Qty" DataField="SampleQty" />
                                        <asp:BoundField HeaderText="Available Qty" DataField="FinalbatchQty" />
                                        <asp:BoundField HeaderText="Pallets Ref No" DataField="Palletsrefno" />
                                        <%--<asp:BoundField HeaderText="Status" DataField="BatchStatus" />--%>
                                    </Columns>
                                    <EditRowStyle BorderStyle="Solid" Width="5px" BackColor="#2461BF" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EFF3FB" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                </asp:GridView>

                            </div>
                            <asp:Label Text="Sales Order Details" ID="lblsohead" runat="server" Visible="false" />
                             <div class="row">
                                <asp:GridView ID="tracesogrid" runat="server" EmptyDataText="Sales Order Not Created" CssClass="table table-bordered table-striped table-condensed flip-content" AutoGenerateColumns="False" ForeColor="#333333" HorizontalAlign="Center" ShowHeaderWhenEmpty="True" CellPadding="4" GridLines="None">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       <asp:BoundField HeaderText="Customer  Name" DataField="CompanyName" />
                                        <asp:BoundField HeaderText="Phone Number" DataField="ContactNumber" />
                                        <asp:BoundField HeaderText="SO Number" DataField="SOPrintno" />
                                        <asp:BoundField HeaderText="SO Date" DataField="SOdatetime" DataFormatString="{0:dd/MM/yyyy}" />
                                        <asp:BoundField HeaderText="GPN Number" DataField="id" />
                                        <asp:BoundField HeaderText="GPN Date" DataField="PickupDate" DataFormatString="{0:dd/MM/yyyy}"/>
                                        <asp:BoundField HeaderText="Sales Qty" DataField="TotalQty" />
                                        <%--<asp:BoundField HeaderText="Status" DataField="BatchStatus" />--%>
                                    </Columns>
                                    <EditRowStyle BorderStyle="Solid" Width="5px" BackColor="#2461BF" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EFF3FB" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                </asp:GridView>

                            </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </form>
            </div>

        </div>

    </div>


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
    <script type="text/javascript">
        function Search_Gridview(strKey, strGV) {


            var strData = strKey.value.toLowerCase().split(" ");

            var tblData = document.getElementById(strGV);

            var rowData;
            for (var i = 1; i < tblData.rows.length; i++) {
                rowData = tblData.rows[i].innerHTML;
                var styleDisplay = 'none';
                for (var j = 0; j < strData.length; j++) {
                    if (rowData.toLowerCase().indexOf(strData[j]) >= 0)

                        styleDisplay = '';
                    else {
                        styleDisplay = 'none';
                        break;
                    }
                }
                tblData.rows[i].style.display = styleDisplay;
            }
        }
    </script>
</body>
</html>
