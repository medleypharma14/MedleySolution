<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SamplingReport.aspx.cs" Inherits="Medly_Wm.SamplingReport" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/Header.ascx" %>
<%@ Register TagPrefix="usc1" TagName="Sidebar" Src="~/Sidebar.ascx" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Sampling Reports</title>
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
                        <div class="auto-style2">
                            <!-- BEGIN SAMPLE FORM PORTLET-->
                            <div class="portlet light ">
                                <div class="portlet-title">
                                    <div class="caption font-red-sunglo">
                                        <i class="icon-settings font-red-sunglo"></i>
                                        <span class="caption-subject bold uppercase">Sampling Reports</span>
                                    </div>
                                    <div class="actions">
                                        <%-- <div class="btn-group">
                                            <a class="btn btn-sm red dropdown-toggle" href="" data-toggle="dropdown">Home
                                                </a>
                                            </div>--%>
                                        <div class="btn-group">
                                            <%-- <a class="btn btn-sm green dropdown-toggle" href="" data-toggle="dropdown">
                                                <i class="fa fa-angle-down"></i>
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
                             <div class="form-body">
                                   <div class="col-lg-4">
                                            <div class="form-group">
                                                <label><b>Enter Batch No</b></label>
                                                <div class="input-group">
                                                    <span class="input-group-addon input-square-left">
                                                        <i class="fa fa-user"></i>
                                                    </span>

                                                    <%--<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator14" ControlToValidate="txtsupplierid"
                                                        ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Supplier ID" Style="color: Red" />--%>
                                                    <asp:TextBox ID="txtBatchno" runat="server" CssClass="form-control" placeholder="Enter ID..."  ></asp:TextBox>
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
                                                    <asp:Button Text="Go" ID="btnGo" Class="btn btn-success" runat="server" OnClick="btnGo_Click" />
                                                </div>
                                            </div>
                                        </div>
                                  <div class="col-lg-12">
                                        <div class="grid" style="overflow: auto">
                                            <asp:GridView ID="samplingreport" runat="server" CssClass="table table-striped table-success table-active  flip-content"  AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No">
                                                        <ItemTemplate>
                                                            <%#Container.DataItemIndex+1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Unit Name" DataField="Unitname" />
                                                    <asp:BoundField HeaderText="Batch Number" DataField="Batchnumber" />
                                                    <asp:BoundField HeaderText="Product Name" DataField="Productname" />
                                                    <asp:BoundField HeaderText="Strength" DataField="Strength" />
                                                    <asp:BoundField HeaderText="Batch Qty" DataField="OrderQty" />
<%--                                                    <asp:BoundField HeaderText="Expiry Date" DataField="Expirydate" />--%>
                                                     <asp:BoundField HeaderText="Batch Status" DataField="BatchStatus" />
                                                   <%-- <asp:TemplateField HeaderText="Modify Batch Qty">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtSampleqty" CssClass="form-control" runat="server"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                   <%-- <asp:BoundField HeaderText="Final Batch Qty" DataField="PalletsQty" />--%>
                                                     <%-- <asp:TemplateField HeaderText="Current Batch Status">
                                                        <ItemTemplate>
                                                        <asp:TextBox ID="Current Batch Status" CssClass="form-control" runat="server"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                   
                                                    <asp:TemplateField HeaderText="Remark">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtRemark" CssClass="form-control" runat="server" placeholder="Enter Comments"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>


                                                    <%-- <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btndel" runat="server" CommandArgument='<%#Eval("GRId") %>'
                                                                    CommandName="Del" OnClientClick="return confirm('Are you sure to delete this Product?');">

                                                                    <asp:ImageButton ID="imgDel" ImageUrl="~/Images/delete.png" runat="server" Width="20px" CommandArgument='<%#Eval("GRId") %>'
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
                                <div class="row">
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
</body>
</html>