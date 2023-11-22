<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SOReport.aspx.cs" Inherits="Medly_Wm.SOReport" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/Header.ascx" %>
<%@ Register TagPrefix="usc1" TagName="Sidebar" Src="~/Sidebar.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>SO Report</title>
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
        /*.auto-style1 {
            font-size: 14px;
            line-height: 1.42857;
            color: #555;
            display: block;
            width: 100%;
            height: 34px;
            border-radius: 4px;
            -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075);
            box-shadow: none !important;
            -webkit-transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
            -o-transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
            transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
            outline-width: 0;
            outline-style: none;
            outline-color: invert;
            left: 0px;
            top: 0px;
            border: 1px solid #c2cad8;
            padding: 6px 12px;
            background-color: #fff;
            backgrou*/ nd-image: none;
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
                                <i class="fa fa-cogs"></i>SO Report
                            </div>
                        </div>
                        <div class="portlet-body flip-scroll">
                            <div class="row">
                                <div class="col-lg-2" style="margin-top: 5px;">
                                    <label></label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" Enabled="true" onkeyup="Search_Gridview(this, 'gvSo')"
                                            ID="txtsearch" runat="server" placeholder="Enter Text to Search" Width="170px"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-3">
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
                                <div class="col-lg-3">
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
                                 <div class="col-lg-2" style="float:right;padding-top:20px">
                                    <div class="form-group">
                                         <asp:Button ID="btnexp" runat="server" class="btn  btn-success"
                                            Text="Export To Excel" OnClick="btnexp_Click"/>
                                    </div>
                                </div>
                            </div>
                            <div style="overflow: auto" id="excel" runat="server">
                                <asp:GridView ID="gvSo" runat="server" EmptyDataText="No Data Bound" OnRowDataBound="gvSo_RowDataBound" DataKeyNames="Soid" CssClass="table table-bordered table-striped table-condensed flip-content" AutoGenerateColumns="False" CellPadding="4"  ForeColor="#333333" GridLines="None">
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
                                                            <asp:BoundField HeaderText="Price Per Pack" DataField="Priceperpack" />
                                                            <asp:BoundField HeaderText="Productamt" DataField="Totalamount" />
                                                        </Columns>
                                                    </asp:GridView>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="SO No" DataField="SOPrintno" />
                                         <asp:BoundField HeaderText="Company Name" DataField="CompanyName" />
                                       <asp:BoundField HeaderText="Supplier Name" DataField="PersonName" />
                                        <asp:BoundField HeaderText="SO Date" DataField="Sodatetime" DataFormatString="{0:dd/MM/yyyy}" />
                                        <asp:BoundField HeaderText="Contact No" DataField="Phone" />
                                        <%--<asp:BoundField HeaderText="Email" DataField="ContactEmail" />--%>
                                        <asp:BoundField HeaderText="So Amount" DataField="Amount" />
                                        <asp:BoundField HeaderText="Delivery Date" DataField="Deliverydate" DataFormatString="{0:dd/MM/yyyy}" />
                                        <asp:BoundField HeaderText="Status" DataField="Status" Visible="false" />
                                    </Columns>
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