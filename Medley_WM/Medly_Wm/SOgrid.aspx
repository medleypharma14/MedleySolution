<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SOgrid.aspx.cs" Inherits="Medly_Wm.SalesOrderoverview" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/Header.ascx" %>
<%@ Register TagPrefix="usc1" TagName="Sidebar" Src="~/Sidebar.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>SO Grid</title>
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
    <link href="assets/layouts/layout2/css/themes/blue.min.css" rel="stylesheet" type="text/css" id="style_color1" />
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
    <usc1:Sidebar ID="h1" runat="server" />
    <div class="page-container">
        <usc:Header ID="Header" runat="server" />
        <div class="page-content-wrapper">
            <!-- BEGIN CONTENT BODY -->
            <div class="page-content">
                <form id="form2" runat="server">
                    <div class="portlet box green">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="fa fa-cogs"></i>SO  List
                            </div>
                        </div>
                        <div class="portlet-body flip-scroll">
                            <div class="row">
                                <div class="col-lg-2" style="margin-top: 5px;">
                                    <div class="list-group">
                                         <label></label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" Enabled="true" onkeyup="Search_Gridview(this, 'gvSo')"
                                            ID="txtsearch" runat="server" placeholder="Enter Text to Search" Width="170px"></asp:TextBox>
                                    </div>
                                        <div class="form-group">
                                            <label style="padding-top:30px">Search Delivery Dates </label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-3">
                                    <div class="list-group">
                                        <div class="form-group">
                                            <label>From Date </label>
                                            <div class="input-group">
                                                <span class="input-group-addon input-square-left">
                                                    <i class="fa fa-calendar"></i>
                                                </span>
                                                <%--<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator14" ControlToValidate="txtsupplierid"
                                                        ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Supplier ID" Style="color: Red" />--%>
                                                <asp:TextBox ID="txtFromdate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                            </div>
                                        </div>
                                         <div class="row">
                                        <div class="form-group">
                                           
                                            <div class="col-lg-6">
                                                 <label>Select Month</label>
                                            <asp:DropDownList runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtMonth_TextChanged" ID="ddlmonth">
                                                <asp:ListItem Text="January " Value="1" />
                                                <asp:ListItem Text="February " Value="2" />
                                                <asp:ListItem Value="3">March </asp:ListItem>
                                                <asp:ListItem Value="4">April</asp:ListItem>
                                                <asp:ListItem Value="5">May</asp:ListItem>
                                                <asp:ListItem Value="6">June</asp:ListItem>
                                                <asp:ListItem Value="7">July</asp:ListItem>
                                                <asp:ListItem Value="8">August </asp:ListItem>
                                                <asp:ListItem Value="9">September </asp:ListItem>
                                                <asp:ListItem Value="10">October </asp:ListItem>
                                                <asp:ListItem Value="11">November </asp:ListItem>
                                                <asp:ListItem Value="12">December </asp:ListItem>
                                            </asp:DropDownList>
                                            </div>
                                             <div class="col-lg-6">
                                                 <label>Select Year</label>
                                            <asp:DropDownList runat="server" CssClass="form-control" OnTextChanged="txtMonth_TextChanged" AutoPostBack="true" ID="ddlyear">
                                                <asp:ListItem Text="2023" />
                                                <asp:ListItem Text="2024" />
                                                <asp:ListItem>2025</asp:ListItem>
                                                <asp:ListItem>2026</asp:ListItem>
                                                <asp:ListItem>2027</asp:ListItem>
                                                <asp:ListItem>2028</asp:ListItem>
                                                <asp:ListItem>2029</asp:ListItem>
                                                <asp:ListItem>2030</asp:ListItem>
                                                <asp:ListItem>20231</asp:ListItem>
                                                <asp:ListItem>20232</asp:ListItem>
                                                <asp:ListItem>2033</asp:ListItem>
                                            </asp:DropDownList>
                                            </div>

                                        </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-3">
                                    <div class="form-group">
                                        <label>To Date</label>
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
                                        <asp:TextBox ID="txtSearchSO" runat="server"  CssClass="form-control"  placeholder="Enter SO No" Width="110px"></asp:TextBox>
                                    </div>
                                        </div>--%>
                                <div></div>
                                <div class="col-lg-1">
                                    <div class="form-group">
                                        <label></label>

                                        <div class="input-group" style="margin-top: 5px;">
                                            <%--  <span class="input-group-addon input-circle-left">
                                                    <i class="fa fa-calendar"></i>
                                                </span>--%>
                                            <%--<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator14" ControlToValidate="txtsupplierid"
                                                        ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Supplier ID" Style="color: Red" />--%>
                                            <asp:Button CssClass="btn btn-md green" ID="btnsearch" Text="Search" OnClick="btnsearch_Click" runat="server" />
                                        </div>

                                    </div>
                                </div>
                                <div class="col-lg-1">
                                    <div class="form-group">
                                        <label></label>

                                        <div class="input-group" style="margin-top: 5px;">
                                            <%--  <span class="input-group-addon input-circle-left">
                                                    <i class="fa fa-calendar"></i>
                                                </span>--%>
                                            <%--<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator14" ControlToValidate="txtsupplierid"
                                                        ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Supplier ID" Style="color: Red" />--%>
                                            <asp:Button CssClass="btn btn-md gray" ID="Button2" Text="Clear" OnClick="Button2_Click" runat="server" />
                                        </div>

                                    </div>
                                </div>
                                <div class="col-lg-1">
                                    <div class="form-group">
                                        <label></label>

                                        <div class="input-group" style="margin-top: 5px;">
                                            <%--  <span class="input-group-addon input-circle-left">
                                                    <i class="fa fa-calendar"></i>
                                                </span>--%>
                                            <%--<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator14" ControlToValidate="txtsupplierid"
                                                        ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Supplier ID" Style="color: Red" />--%>
                                            <asp:Button CssClass="btn btn-md red" ID="Button1" Text="ADD SO" PostBackUrl="~/CreateSO.aspx" runat="server" />
                                        </div>

                                    </div>
                                </div>
                            </div>
                            <div style="overflow: auto">
                                <asp:GridView ID="gvSo" runat="server" DataKeyNames="Soid" EmptyDataText="No Data Bound" CssClass="table table-bordered table-striped table-condensed flip-content" AutoGenerateColumns="False" CellPadding="4" OnRowDataBound="gvSo_RowDataBound" ForeColor="#333333" GridLines="None" OnRowCommand="gvSo_RowCommand">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="SO NO">
                                            <ItemTemplate>
                                                <%# Eval("SOPrintno") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="20px">
                                            <ItemTemplate>
                                                <a href="JavaScript:divexpandcollapse('div<%# Eval("Soid") %>');">
                                                    <img id="imgdiv<%# Eval("Soid") %>" width="30px" border="0" src="plus.gif" />
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="20px">
                                            <ItemTemplate>
                                                <div id="div<%# Eval("Soid") %>" style="display: none; position: relative; left: 15px; overflow: auto">
                                                    <asp:GridView ID="productgrid" runat="server" DataKeyNames="Productid" CssClass="table table-striped table-success" AutoGenerateColumns="False" ForeColor="#333333" GridLines="None" Visible="false">
                                                        <AlternatingRowStyle BackColor="White" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Sl No">
                                                                <ItemTemplate>
                                                                    <%#Container.DataItemIndex+1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderText="ProductName" DataField="Productname" />
                                                            <asp:BoundField HeaderText="PackSize" DataField="Packsize" Visible="false" />
                                                            <asp:BoundField HeaderText="SoQty" DataField="SoQty" />
                                                            <asp:BoundField HeaderText="PricePerPack" DataField="Priceperpack" />
                                                            <asp:BoundField HeaderText="Productamt" DataField="Totalamount" />
                                                        </Columns>
                                                    </asp:GridView>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Company Name" DataField="CompanyName" />
                                        <asp:BoundField HeaderText="SO Date" DataField="Sodatetime" DataFormatString="{0:dd/MM/yyyy}" />
                                        <asp:BoundField HeaderText="Delivery Date" DataField="Deliverydate" DataFormatString="{0:dd/MM/yyyy}" />
                                        <asp:BoundField HeaderText="Supplier Name" DataField="PersonName" />
                                        <asp:BoundField HeaderText="Contact No" DataField="Phone" />
                                        <asp:BoundField HeaderText="Email" DataField="EmailId" Visible="false" />
                                        <asp:BoundField HeaderText="So Amount" DataField="Amount" />
                                        <asp:BoundField HeaderText="Status" DataField="Status" />
                                        <asp:TemplateField HeaderText="View" ItemStyle-HorizontalAlign="Center" Visible="true">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnedit" runat="server" CommandArgument='<%#Eval("Soid") %>'
                                                    CommandName="edit">

                                                    <asp:ImageButton ID="imgEdit" ImageUrl="~/Images/edit.jpg" runat="server" Width="20px" CommandArgument='<%#Eval("Soid") %>' CommandName="edit" />
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" Visible="true">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btndel" runat="server" CommandArgument='<%#Eval("Soid") %>'
                                                    CommandName="Del" OnClientClick="return confirm('Are you sure to delete this Product?');" Enabled="false">

                                                    <asp:ImageButton ID="imgDel" ImageUrl="~/Images/delete.png" runat="server" Width="20px" CommandArgument='<%#Eval("Soid") %>'
                                                        CommandName="Del" Enabled="false" />
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Print" ItemStyle-HorizontalAlign="Center" Visible="true">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnPrint" runat="server" CommandArgument='<%#Eval("Soid") %>'
                                                    CommandName="Print">

                                                    <asp:ImageButton ID="imgPrint" ImageUrl="print.png" runat="server" Width="20px" CommandArgument='<%#Eval("Soid") %>'
                                                        CommandName="Print" />
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>

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
                    </div>
                </form>
            </div>
        </div>

    </div>

    <!-- BEGIN CORE PLUGINS -->
    <%-- <script src="assets/global/plugins/jquery.min.js" type="text/javascript"></script>
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
    </script> --%>
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
    <script language="javascript" type="text/javascript">
        function divexpandcollapse(divname) {
            var div = document.getElementById(divname);
            var img = document.getElementById('img' + divname);
            if (div.style.display == "none") {
                div.style.display = "inline";
                img.src = "minus.gif";
            } else {
                div.style.display = "none";
                img.src = "plus.gif";
            }
        }
    </script>
</body>
</html>
