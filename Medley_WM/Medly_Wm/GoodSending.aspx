<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodSending.aspx.cs" Inherits="Medly_Wm.GoodSending" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/Header.ascx" %>
<%@ Register TagPrefix="usc1" TagName="Sidebar" Src="~/Sidebar.ascx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Good Sending/Picking List</title>
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
        /*.col-lg-12 {
                padding: 10px;
            }*/
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
                                <i class="fa fa-cogs"></i>Goods Picking
                            </div>

                        </div>
                        <div class="portlet-body flip-scroll">
                            <div class="row">
                                <div class="col-lg-4" style="padding-top:5px;display:none">
                                    <label><b>   </b></label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" Enabled="true" onkeyup="Search_Gridview(this, 'gvGoods')"
                                            ID="txtsearch" runat="server" placeholder="Enter Text to Search" Width="250px"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-4">
                                    <label><b>SO Number</b></label>
                                    <div class="form-group">
                                        <asp:DropDownList CssClass="form-control" ID="ddlSo" runat="server" OnSelectedIndexChanged="ddlSo_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                    </div>
                                </div>
                                   <div class="col-lg-4">
                                    <div class="form-group">
                                        <asp:DropDownList CssClass="form-control" ID="ddlProduct" runat="server" OnSelectedIndexChanged="ddlSo_SelectedIndexChanged" AutoPostBack="true" Visible="false"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12">
                                    <div style="overflow: auto">
                                        <asp:GridView ID="gvGoods" runat="server" OnRowDataBound="gvSo_RowDataBound" OnRowCommand="gvSo_RowCommand" CssClass="table table-bordered table-striped table-condensed flip-content" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" >
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="S.no">
                                                    <ItemTemplate>
                                                        <%#Eval("SOPrintno")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                 <asp:BoundField HeaderText="Productid" DataField="Productid" Visible="false"/>
                                                <asp:BoundField HeaderText="Product Name" DataField="ProductName" />
                                                <asp:BoundField HeaderText="License No" DataField="LicenseNo" Visible="false" />
                                                <asp:BoundField HeaderText="Dosage form" DataField="Dosageform" Visible="false" />
                                                <asp:BoundField HeaderText="Strength" DataField="Strength" Visible="false" />
                                                <%--<asp:BoundField HeaderText="Pack type" DataField="Packtype" />
                                                <asp:BoundField HeaderText="Pack size" DataField="Packsize" />--%>
                                                 <asp:BoundField HeaderText="SupplierId" DataField="SupplierId"/>
                                                <%--asp:BoundField HeaderText="Company name" DataField="CompanyName" />--%>
                                                <asp:BoundField HeaderText="Order Qty" DataField="SoQty" />
                                                 <asp:BoundField HeaderText="Pick Qty" DataField="SentQty" />
                                                <asp:BoundField HeaderText="Price per pack" DataField="Priceperpack" Visible="false"/>
                                                 <asp:BoundField HeaderText="VAT%" DataField="VAT" Visible="false"/>
                                                 <asp:BoundField HeaderText="Total Amt" DataField="Totalamount" Visible="false" />
                                                <asp:TemplateField HeaderText="Pick" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnPick" runat="server" CommandArgument='<%#Eval("Productid") +","+ Eval("SoQty")+","+ Eval("SupplierId")+","+ Eval("SentQty") %>'
                                                            CommandName="pick" Text="Pick">

                                                          
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


