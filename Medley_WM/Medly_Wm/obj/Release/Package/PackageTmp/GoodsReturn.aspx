<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodsReturn.aspx.cs" Inherits="Medly_Wm.GoodsReturn" EnableEventValidation="true" %>
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

    <usc1:Sidebar ID="h1" runat="server" />
    <div class="page-container">

        <usc:Header ID="Header" runat="server" />
        <div class="page-content-wrapper">
            <!-- BEGIN CONTENT BODY -->
            <div class="page-content">

                <form id="form1" runat="server">
                    <div class="row">
                        <div class="col-md-12 ">
                            <div class="portlet box green">
                                <div class="portlet-title">
                                    <div class="caption">
                                        <i class="fa fa-cogs"></i>Sales Return Grid
                                    </div>
                                </div>
                                <div class="portlet-body">
                                    <div class="row">
                                        <div class="col-lg-2" style="margin-top:5px;">
                                             <label></label>
                                        <div class="form-group">
                                        <asp:TextBox CssClass="form-control" Enabled="true" onkeyup="Search_Gridview(this, 'gvReturn')"
                                            ID="txtsearch" runat="server" placeholder="Enter Text to Search" Width="170px"></asp:TextBox>
                                    </div>
                                        </div>
                                         <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label>From Date </label>
                                                    <div class="input-group">
                                                        <span class="input-group-addon input-square-left">
                                                            <i class="fa fa-calendar"></i>
                                                        </span>
                                                        <asp:TextBox ID="txtFromdate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
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
                                                        <asp:TextBox ID="txtTodate" runat="server" CssClass="form-control" TextMode="date"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-1">
                                                <div class="form-group">
                                                    <label></label>

                                                    <div class="input-group" style="margin-top:5px;">
                                                        <asp:Button CssClass="btn btn-md green" ID="btnsearch" Text="Search" OnClick="btnsearch_Click"   runat="server" />
                                                    </div>

                                                </div>
                                            </div>
                                         <div class="col-lg-1">
                                                <div class="form-group">
                                                    <label></label>

                                                    <div class="input-group" style="margin-top:5px;">
                                                        <asp:Button CssClass="btn btn-md gray" ID="Button2" Text="Clear" PostBackUrl="~/GoodsReturn.aspx" runat="server" />
                                                    </div>

                                                </div>
                                            </div>
                                          <div class="col-lg-1">
                                               <div class="form-group">
                                                    <label></label>

                                                    <div class="input-group" style="margin-top:5px;">
                                                        <asp:Button CssClass="btn btn-md red" ID="Button1" Text="ADD Return" PostBackUrl="~/ReturnSales.aspx" runat="server" />
                                                    </div>

                                                </div>
                                            </div>
                                    </div>
                                    <div class="row">
                                        <div style="overflow: auto;padding:10px">
                                            <asp:GridView ID="gvReturn" runat="server" EmptyDataText="No Data Bound" DataKeyNames="Returnid" OnRowCommand="gvReturn_RowCommand" CssClass="table table-bordered table-striped table-condensed flip-content" AutoGenerateColumns="False" CellPadding="4" OnRowDataBound="gvReturn_RowDataBound" ForeColor="#333333" GridLines="None">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Return NO">
                                                        <ItemTemplate>
                                                            <%# Eval("ReturnPrintno") %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="20px">
                                                        <ItemTemplate>
                                                            <a href="JavaScript:divexpandcollapse('div<%# Eval("Returnid") %>');">
                                                                <img id="imgdiv<%# Eval("Returnid") %>" width="30px" border="0" src="plus.gif" />
                                                            </a>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="20px">
                                                        <ItemTemplate>
                                                            <div id="div<%# Eval("Returnid") %>" style="display: none; position: relative; left: 15px; overflow: auto">
                                                                <asp:GridView ID="productgrid" runat="server" DataKeyNames="Productid" CssClass="table table-bordered table-striped table-condensed flip-content" 
                                                                    AutoGenerateColumns="False" ForeColor="#333333" GridLines="None" Visible="false">
                                                                    <AlternatingRowStyle BackColor="White" />
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Sl No">
                                                                            <ItemTemplate>
                                                                                <%#Container.DataItemIndex+1 %>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField HeaderText="ProductName" DataField="Productname" />
                                                                        <asp:BoundField HeaderText="PackSize" DataField="Packsize" Visible="false"/>
                                                                        <asp:BoundField HeaderText="Return Qty" DataField="ReturnQty" />
                                                                        <asp:BoundField HeaderText="PricePerPack" DataField="Priceperpack" Visible="false"/>
                                                                        <asp:BoundField HeaderText="Return Amount" DataField="ReturnAmount" />
                                                                        <asp:TemplateField>
                                                                            <ItemTemplate>
                                                                                <asp:HiddenField ID="Hidden" runat="server"
                                                                                    Value='<%#Eval("Soid")%>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Return Date" DataField="Returndatetime" DataFormatString="{0:dd/MM/yyyy}" />
                                                    <asp:BoundField HeaderText="Company Name" DataField="CompanyName" />
                                                    <asp:BoundField HeaderText="Supplier Name" DataField="PersonName" />
                                                    <asp:BoundField HeaderText="Contact No" DataField="Phone" />
                                                    <asp:BoundField HeaderText="Email" DataField="EmailId" />
                                                    <asp:BoundField HeaderText="Return Amount" DataField="ReturnAmount" />
                                                    <asp:BoundField HeaderText="Status" DataField="Status" />
                                                    <asp:TemplateField HeaderText="View" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnedit" runat="server" CommandArgument='<%#Eval("Returnid") %>'
                                                                CommandName="edit">
                                                                <asp:ImageButton ID="imgEdit" ImageUrl="~/Images/edit.jpg" runat="server" Width="20px" CommandArgument='<%#Eval("Returnid") %>' CommandName="edit" />
                                                            </asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btndel" runat="server" CommandArgument='<%#Eval("Returnid") %>'
                                                                CommandName="Del" OnClientClick="return confirm('Are you sure to delete this Product?');">
                                                                <asp:ImageButton ID="imgDel" ImageUrl="~/Images/delete.png" runat="server" Width="20px" CommandArgument='<%#Eval("Returnid") %>'
                                                                    CommandName="Del" />
                                                            </asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Print" ItemStyle-HorizontalAlign="Center" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnPrint" runat="server" CommandArgument='<%#Eval("Returnid") %>'
                                                                CommandName="Print">
                                                                <asp:ImageButton ID="imgPrint" ImageUrl="print.png" runat="server" Width="20px" CommandArgument='<%#Eval("Returnid") %>'
                                                                    CommandName="Print" />
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