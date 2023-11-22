<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="Medly_Wm.Reports" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/Header.ascx" %>
<%@ Register TagPrefix="usc1" TagName="Sidebar" Src="~/Sidebar.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Reports</title>
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

    <%--  <style>
        /*.col-lg-12 {
            padding: 10px;
        }*/
        .auto-style1 {
            font-size: 14px;
            line-height: 1.42857;
            color: #555;
            display: block;
            width: 100%;
            height: 34px;
            border-radius: 4px;
            -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075);
            box-shadow: none!important;
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
            background-image: none;
        }
    </style>--%>
</head>
<body class="page-header-fixed page-sidebar-closed-hide-logo page-container-bg-solid page-md">
    <p>
        tr</p>
    <usc1:Sidebar ID="h1" runat="server" />
    <div class="page-container">
        <usc:Header ID="Header" runat="server" />
        <div class="page-content-wrapper">
            <!-- BEGIN CONTENT BODY -->
            <div class="page-content">
                <form id="form2" runat="server">
                    <div class="row">
                        <div class="col-md-12 ">
                            <div class="portlet light ">
                                <div class="portlet-title">
                                    <div class="caption font-red-sunglo">
                                        <i class="icon-settings font-red-sunglo"></i>
                                        <span class="caption-subject bold uppercase">Po Reports</span>
                                    </div>
                                    <div class="actions">
                                        <%--<div class="btn-group">
                                            <a class="btn btn-sm red dropdown-toggle" href="" data-toggle="dropdown">Home
                                                </a>
                                            </div>--%>
                                     <%--      <div class="btn-group">
                                            <a class="btn btn-sm green dropdown-toggle" href="" data-toggle="dropdown">
                                              <i class="fa fa-angle-down"></i>
                                            </a>--%>

                                            <%--  <ul class="dropdown-menu pull-right">
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

                                <div class="portlet light ">
                                    <div class="form-body">
                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <label>From Date </label>
                                                    <div class="input-group">
                                                        <span class="input-group-addon input-circle-left">
                                                            <i class="fa fa-calendar"></i>
                                                        </span>
                                                        <%--<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator14" ControlToValidate="txtsupplierid"
                                                        ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Supplier ID" Style="color: Red" />--%>
                                                        <asp:TextBox ID="txtFromdate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="form-group">
                                                    <label>To Date</label>
                                                    <div class="input-group">
                                                        <span class="input-group-addon input-circle-left">
                                                            <i class="fa fa-calendar"></i>
                                                        </span>
                                                        <%--<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator14" ControlToValidate="txtsupplierid"
                                                        ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Supplier ID" Style="color: Red" />--%>
                                                        <asp:TextBox ID="txtTodate" runat="server" CssClass="form-control" TextMode="date"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-2">
                                                <div class="form-group">
                                                    <label></label>

                                                    <div class="input-group" style="margin-top:5px;">
                                                        <%--  <span class="input-group-addon input-circle-left">
                                                    <i class="fa fa-calendar"></i>
                                                </span>--%>
                                                        <%--<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator14" ControlToValidate="txtsupplierid"
                                                        ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Supplier ID" Style="color: Red" />--%>
                                                        <asp:Button CssClass="btn btn-sm green" ID="btnsearch" Text="Search"  OnClick="btnsearch_Click" runat="server" />
                                                    </div>

                                                </div>
                                            </div>
                                        <div class="col-lg-12" style="margin-top: 10px;">
                                            <center>

                                                <%--<asp:Button ID="btsclear" Text="Clear" runat="server" CssClass="btn default" PostBackUrl="~/Employee.aspx" />--%>
                                                <asp:Button Text="Excel" ID="btExcel" Class="btn btn-success" runat="server" />
                                                <asp:Button ID="btPdf" Text="Pdf" runat="server" CssClass="btn btn-gray" />
                                            </center>

                                        </div>
                                    </div>
                                    <div class="form-group">
                                    <asp:TextBox CssClass="form-control" Enabled="true" onkeyup="Search_Gridview(this, 'gvreport')"
                                        ID="txtsearch" runat="server" placeholder="Enter Text to Search" Width="250px"></asp:TextBox>
                                </div>
                                <div style="overflow: auto">
                                    <asp:GridView ID="gvreport" runat="server" CssClass="table table-striped table-success table-active  flip-content" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sl No">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="PO No" DataField="Poid" />
                                            <asp:BoundField HeaderText="PO Date" DataField="Podatetime" DataFormatString="{0:dd/MM/yyyy}" />
                                            <asp:BoundField HeaderText="Company Name" DataField="CompanyName" />
                                            <asp:BoundField HeaderText="Supplier Name" DataField="ContactName" />
                                            <asp:BoundField HeaderText="Contact No" DataField="ContactNumber" />
                                            <%-- <asp:BoundField HeaderText="Product Name" DataField="Productname" />--%>
                                            <asp:BoundField HeaderText="Email" DataField="ContactEmail" />
                                            <asp:BoundField HeaderText="Po Amount" DataField="Amount" />
                                            <%--
                                                        <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btnedit" runat="server" CommandArgument='<%#Eval("Poid") %>'
                                                                    CommandName="edit">

                                                                    <asp:ImageButton ID="imgEdit" ImageUrl="~/Images/edit.jpg" runat="server" Width="20px" CommandArgument='<%#Eval("Poid") %>' CommandName="edit" />
                                                                </asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
  <%--                                          <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btndel" runat="server" CommandArgument='<%#Eval("Poid") %>'
                                                        CommandName="Del" OnClientClick="return confirm('Are you sure to delete this Product?');">

                                                        <asp:ImageButton ID="imgDel" ImageUrl="~/Images/delete.png" runat="server" Width="20px" CommandArgument='<%#Eval("Poid") %>'
                                                            CommandName="Del" />
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>

                                        </Columns>
                                        <EditRowStyle BackColor="#2461BF" />
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
</body>
</html>
