<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodsPickGrid.aspx.cs" Inherits="Medly_Wm.GoodsPickGrid" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/Header.ascx" %>
<%@ Register TagPrefix="usc1" TagName="Sidebar" Src="~/Sidebar.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Picking List</title>
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
                <form id="form2" runat="server">
                    <div class="row"> 
                        <div class="portlet box green">
                            <div class="portlet-title">
                                <div class="caption">
                                    <i class="fa fa-cogs"></i>Picking List
                                </div>
                            </div>
                            <div class="portlet-body flip-scroll">
                                <div class="row" id="head" runat="server">
                                    <div class="col-lg-6">
                                        <label></label>
                                        <div class="form-group">
                                            <asp:TextBox CssClass="form-control" Enabled="true" onkeyup="Search_Gridview(this, 'gvpick')"
                                                ID="TextBox1" runat="server" placeholder="Enter Text to Search" Width="250px"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-3">
                                        <label><b>Select Date</b></label>
                                        <asp:TextBox runat="server" Text="Select Date" TextMode="Date" OnTextChanged="txtdate_TextChanged" AutoPostBack="true" CssClass="form-control" ID="txtdate" />

                                    </div>
                                     <%--<div class="col-lg-4" style="float: right; padding-top: 20px">
                                         <label></label>
                                    <div class="form-group">
                                        <asp:Button ID="btnexp" runat="server" class="btn  btn-success" Text="Export To Excel" OnClick="btnexp_Click" />
                                    </div>
                                </div>--%>
                                 <div class="col-lg-2" style="float: right; padding-top: 20px">
                                        <div class="form-group">
                        <asp:Button ID="btnexp" runat="server" class="btn  btn-success" Text="Export To Excel" OnClick="btnexp_Click"  Visible="false"/>
                                               <%--  <asp:Button CssClass="btn btn-success" OnClick="linkprint_Click" Style="background-color: #2672ed" ID="linkprint" runat="server" Text="Print" OnClientClick="return printPage();" Visible="false"></asp:Button>
                                        </div>--%>
                                    </div>
                                    
                                </div>



                                <div class="row">
                                    <div class="col-lg-12">
                                        <div style="overflow: auto">
                                            <asp:GridView ID="gvpick" runat="server" EmptyDataText="No Data Bound" DataKeyNames="Soid" CssClass="table table-bordered table-striped table-condensed flip-content" AutoGenerateColumns="False" CellPadding="4" OnRowDataBound="gvpick_RowDataBound" ForeColor="#333333" GridLines="None" OnRowCommand="gvpick_RowCommand">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Sl No">
                                                        <ItemTemplate>
                                                            <%#Container.DataItemIndex+1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="SO Number">
                                                        <ItemTemplate>
                                                            <%# Eval("SOPrintno") %>
                                                            <a href="JavaScript:divexpandcollapse('div<%# Eval("Soid") %>');">
                                                                <img id="imgdiv<%# Eval("Soid") %>" width="30px" border="0" src="plus.gif" />
                                                            </a>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="20px">
                                                        <ItemTemplate>
                                                            <div id="div<%# Eval("Soid") %>" style="display: none; position: relative; left: 15px; overflow: auto">
                                                                <asp:GridView ID="sopickgrid" runat="server" DataKeyNames="Soid" CssClass="table table-bordered table-striped table-condensed flip-content" AutoGenerateColumns="False" ForeColor="#333333" GridLines="None" Visible="false">
                                                                    <AlternatingRowStyle BackColor="White" />
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Sl No">
                                                                            <ItemTemplate>
                                                                                <%#Container.DataItemIndex+1 %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField HeaderText="Product Name" DataField="Productname" />
                                                                        <%--<asp:BoundField HeaderText="Unit Name" DataField="Unitname" />--%>
                                                                        <asp:BoundField HeaderText="Qty" DataField="Qty" />
                                                                    </Columns>
                                                                </asp:GridView>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Supplier Name" DataField="CompanyName" />
                                                    <asp:BoundField HeaderText="Picking Date" DataField="PickupDate" DataFormatString="{0:yyyy/MM/dd}" />
                                                    <asp:BoundField HeaderText="Total Qty" DataField="TotalQty" />
                                                    <%--<asp:BoundField HeaderText="Total Amount" DataField="Amount" />--%>
                                                    <asp:TemplateField HeaderText="Print" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="print" runat="server" CommandArgument='<%#Eval("Soid") %>'
                                                                CommandName="View">

                                                                <asp:ImageButton ID="btnview" ImageUrl="~/Images/product.png" runat="server" Width="20px" CommandArgument='<%#Eval("Soid") %>'
                                                                    CommandName="View" />
                                                            </asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                </Columns>
                                            </asp:GridView>
                                        </div>

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
