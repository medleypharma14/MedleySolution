<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GRNReport.aspx.cs" Inherits="Medly_Wm.GRNReport" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/Header.ascx" %>
<%@ Register TagPrefix="usc1" TagName="Sidebar" Src="~/Sidebar.ascx" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>GRN Reports</title>
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
                    <div class="row">
                        <div class="portlet box green">
                            <!-- BEGIN SAMPLE FORM PORTLET-->
                            <div class="portlet-title">
                                <div class="caption">
                                    <i class="fa fa-cogs"></i>GRN Report
                                </div>
                            </div>
                            <div class="portlet-body flip-scroll">
                                <div class="row" id="head" runat="server">
                                    <div class="row">
                                    <div class="col-lg-2" style="padding-top: 5px">
                                        <div class="form-group">
                                            <label></label>
                                            <asp:TextBox CssClass="form-control" Enabled="true" onkeyup="Search_Gridview(this, 'grnreport')"
                                                ID="txtSearchSO" runat="server" placeholder="Enter Text to Search" Width="170px"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="form-group">
                                            <label><b>From Date</b> </label>
                                            <div class="input-group">
                                                <span class="input-group-addon input-square-left">
                                                    <i class="fa fa-calendar"></i>
                                                </span>
                                                <%--<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator14" ControlToValidate="txtsupplierid"
                                                        ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Supplier ID" Style="color: Red" />--%>
                                                <asp:TextBox ID="txtFromdate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="form-group">
                                            <label><b>To Date</b></label>
                                            <div class="input-group">
                                                <span class="input-group-addon input-square-left">
                                                    <i class="fa fa-calendar"></i>
                                                </span>
                                                <%--<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator14" ControlToValidate="txtsupplierid"
                                                        ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Supplier ID" Style="color: Red" />--%>
                                                <asp:TextBox ID="txtTodate" runat="server" CssClass="form-control" TextMode="date"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                   <%-- <div class="col-lg-2" style="padding-top:5px">
                                        <div class="form-group">
                                         <label></label>
                                        <asp:TextBox ID="txtSearchSO" runat="server"  CssClass="form-control"  placeholder="Enter Product ID"></asp:TextBox>
                                    </div>--%>
                                        
                                    <div class="col-lg-2">
                                        <div class="form-group">
                                            <label></label>

                                            <div class="input-group" style="margin-top: 5px;">
                                                <%--  <span class="input-group-addon input-circle-left">
                                                    <i class="fa fa-calendar"></i>
                                                </span>--%>
                                                <%--<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator14" ControlToValidate="txtsupplierid"
                                                        ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Supplier ID" Style="color: Red" />--%>
                                                <asp:Button CssClass="btn btn-sm green" ID="btnsearch" Text="Search" OnClick="btnsearch_Click" runat="server" />
                                            </div>

                                        </div>
                                    </div>
                                     <div class="col-lg-2" style="float:right;padding-top:20px">
                                        <div class="form-group">
                                             <asp:Button CssClass="btn btn-success" OnClick="linkprint_Click" style="background-color:#2672ed" ID="linkprint" runat="server"  Text="Print" OnClientClick="return printPage();"></asp:Button>
                                        </div>
                                    </div>
                                    <div class="col-lg-2" style="float:right;padding-top:20px">
                                    <div class="form-group">
                                         <asp:Button ID="btnexp" runat="server" class="btn  btn-success"
                                            Text="Export To Excel" OnClick="btnexp_Click"/>
                                    </div>
                                </div>
                                        </div>
                                </div>

                                <div class="row" id="excel" runat="server">
                                    <div style="overflow: auto">
                                        <asp:GridView ID="grnreport" runat="server" EmptyDataText="No Data Bound" DataKeyNames="GRId" CssClass="table table-bordered table-striped table-condensed flip-content" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Sl No">
                                                    <ItemTemplate>
                                                        <%#Container.DataItemIndex+1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="ProductId" DataField="ProductId" />
                                                <asp:BoundField HeaderText="Product Name" DataField="Productname" />
                                                <asp:BoundField HeaderText="Order Amt" DataField="OrderAmt" />
                                                <asp:BoundField HeaderText="Batch No" DataField="Batchnumber" />
                                                <asp:BoundField HeaderText="GRN Date" DataField="GoodsReceiveddate" DataFormatString="{0:dd/MM/yyyy}" />
                                                <asp:BoundField HeaderText="Batch Status" DataField="BatchStatus" />
                                            </Columns>
                                            <%--  <EditRowStyle BackColor="#2461BF" />
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
                            </div>
                        </div>
                    </div>
            </form>
        </div>
    </div>
        </div>

   
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
