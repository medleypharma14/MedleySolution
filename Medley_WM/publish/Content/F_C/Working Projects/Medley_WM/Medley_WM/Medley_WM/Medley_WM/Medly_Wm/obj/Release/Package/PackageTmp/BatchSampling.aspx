we<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BatchSampling.aspx.cs" Inherits="Medly_Wm.BatchSampling" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/Header.ascx" %>
<%@ Register TagPrefix="usc1" TagName="Sidebar" Src="~/Sidebar.ascx" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Batch Sampling</title>
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
        .auto-style1 {
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
            background-image: none;
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
                    <div class="row">
                        <div class="col-md-12 ">
                            <div class="portlet light ">
                                <div class="portlet-title">
                                    <div class="caption font-red-sunglo">
                                        <i class="icon-settings font-red-sunglo"></i>
                                        <span class="caption-subject bold uppercase">Create Sample
                                        </span>
                                    </div>
                                    <br />
                                    <br />
                                    <br />
                                    <div class="row">
                                        <div class="col-lg-3" id="dd" runat="server" visible="false">
                                            <div class="form-group">
                                                <label><b>Create Sample No</b></label>
                                                <div class="input-group">
                                                    <span class="input-group-addon input-square-left">
                                                        <i class="fa fa-user"></i>
                                                    </span>
                                                    <asp:TextBox ID="txtSamNo" runat="server" CssClass="form-control" placeholder="Enter New Sample No" OnTextChanged="txtSamNo_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label><b>Enter Batch No</b></label>
                                                <div class="input-group">
                                                    <span class="input-group-addon input-square-left">
                                                        <i class="fa fa-user"></i>
                                                    </span>

                                                    <%--<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator14" ControlToValidate="txtsupplierid"
                     ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Supplier ID" Style="color: Red" />--%>
                                                    <asp:TextBox ID="txtBatchno" runat="server" CssClass="form-control" placeholder="Search Batch No"></asp:TextBox>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="col-lg-2" style="padding-top:20px">
                                            <div class="form-group">
                                                <label></label>
                                                <div class="input-group">
                                                    <%-- <span class="input-group-addon input-circle-left">
                 <i class="fa fa-calendar"></i>
             </span>--%>
                                                    <asp:Button Text="Search Batch" ID="btnGo" Class="btn red" runat="server" OnClick="btnGo_Click" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>


                                    <div class="col-lg-12">
                                        <div class="grid" style="overflow: auto">
                                            <asp:GridView ID="gvbatchsamp" runat="server" CssClass="table table-bordered table-striped table-condensed flip-content" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Sl No">
                                                        <ItemTemplate>
                                                            <%#Container.DataItemIndex+1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Unit name" DataField="Unitname" />
                                                    <asp:BoundField HeaderText="Product Name" DataField="Productname" />
                                                    <asp:BoundField HeaderText="Batch Qty" DataField="FinalbatchQty" />
                                                    <%--<asp:BoundField HeaderText="Units" DataField="Unitname" />--%>
                                                    <asp:BoundField HeaderText="No of Pallets" DataField="PalletsQty" Visible="false" />
                                                    <asp:TemplateField HeaderText="Sample Qty">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtSampleqty" CssClass="form-control" AutoPostBack="true" Text="0" runat="server" OnTextChanged="txtSampleqty_TextChanged1"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Final Batch Qty">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtFinalbatchqty" CssClass="form-control" AutoPostBack="true" runat="server"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Batch Status" DataField="BatchStatus" />
                                                       </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                    <div id="sampnot" runat="server" visible="false">
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>
                                                    <b>Select Approver</b>
                                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator14" ControlToValidate="ddlSelectapprover"
                                                        ValidationGroup="Validation" Text="*" ErrorMessage="*" Style="color: Red" />
                                                </label>
                                                <div class="input-group">
                                                    <span class="input-group-addon input-square-left">
                                                        <i class="fa fa-user"></i>
                                                    </span>


                                                    <asp:DropDownList ID="ddlSelectapprover" runat="server" CssClass="form-control">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <label>Select Status </label>
                                            <div class="form-group">
                                                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control" placeholder="Select" Enabled="false">
                                                    <asp:ListItem Value="">Select</asp:ListItem>
                                                    <asp:ListItem Text="Draft" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="Approved"></asp:ListItem>
                                                    <asp:ListItem Text="Rejected"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>

                                    <%--  <div class="col-lg-4">
                                               <label>Select Status </label>
                                                          <div class="form-group">
                                                              <asp:TextBox ID="totalSampleQty" CssClass="form-control" runat="server" />
                                         </div>
                                                          </div>--%>
                                    <div class="col-lg-12" style="margin-top: 10px;">
                                        <center>

                                            <%--<asp:Button ID="btsclear" Text="Clear" runat="server" CssClass="btn default" PostBackUrl="~/Employee.aspx" />--%>
                                            <asp:Button Text="Submit" ID="btnSubmit" Class="btn btn-success" runat="server" OnClick="btnSubmit_Click" />
                                            <asp:Button Text="Save Draft" ID="btnSavedraft" Class="btn btn-primary" runat="server" Visible="false" />
                                            <asp:Button ID="btncancel" Text="Cancel" runat="server" CssClass="btn btn-danger" PostBackUrl="~/BatchSampling.aspx" />
                                        </center>

                                    </div>
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
</body>
</html>
