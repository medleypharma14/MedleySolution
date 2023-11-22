<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BatchManagement.aspx.cs" Inherits="Medly_Wm.BatchManagement" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/Header.ascx" %>
<%@ Register TagPrefix="usc1" TagName="Sidebar" Src="~/Sidebar.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Batch Management</title>
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
      /*  .auto-style1 {
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
                    <div class="row">
                        <div class="col-md-12 ">
                            <div class="portlet light ">
                                <div class="portlet-title">
                                    <div class="caption font-red-sunglo">
                                        <i class="fa fa-cogs"></i>
                                        <span class="caption-subject bold uppercase">Batch Management</span>
                                    </div>

                                </div>
                                <div class="portlet-title">
                                    <div class="batch">
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
                                    </div>
                                    <div class="col-lg-12">
                                        <div class="grid" style="overflow: auto">
                                            <asp:GridView ID="gvbatchsamp" runat="server" CssClass="table table-bordered table-striped table-condensed flip-content"  AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Sl No">
                                                        <ItemTemplate>
                                                            <%#Container.DataItemIndex+1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Batch Number" DataField="Batchnumber" />
                                                    <asp:BoundField HeaderText="Product Name" DataField="Productname" />
                                                    <asp:BoundField HeaderText="Strength" DataField="Strength" />
                                                    <asp:BoundField HeaderText="Final Batch Qty" DataField="FinalBatchQty" />
                                                    <asp:BoundField HeaderText="Units" DataField="Unitname" />
                                                    <asp:BoundField HeaderText="Pallets Ref No" DataField="PalletsQty" Visible="false" />
                                                     <asp:BoundField HeaderText="Current Batch Status" DataField="BatchStatus" />
                                                   <asp:TemplateField HeaderText="Batch Status">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="ddlBatchStatus" CssClass="form-control" runat="server">
                                                                <asp:ListItem Text="Qurantine" />
                                                                <asp:ListItem Text="Release" />
                                                                <asp:ListItem Text="Destroyed" Enabled="false" />
                                                                <asp:ListItem Text="Rejected" Enabled="false" />
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%--<asp:TemplateField HeaderText="Remark">
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
                                            </asp:GridView>
                                        </div>
                                    </div>
                                <%--    <div class="col-lg-4">
                                        <div class="form-group">
                                            <label>
                                                <b>Select Approver</b>
                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator14" ControlToValidate="ddlSelectapprover"
                                                    ValidationGroup="Validation" Text="*" ErrorMessage="*" Style="color: Red" />
                                            </label>
                                            <div class="input-group">
                                                <span class="input-group-addon input-circle-left">
                                                    <i class="fa fa-user"></i>
                                                </span>


                                                <asp:DropDownList ID="ddlSelectapprover" runat="server" CssClass="form-control">
                                                    <asp:ListItem Value="">Select</asp:ListItem>
                                                    <asp:ListItem Text="Manager"></asp:ListItem>
                                                    <asp:ListItem Text="Superviser"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>--%>
                                    <div class="col-lg-12" style="margin-top: 10px;">
                                        <center>

                                            <%--<asp:Button ID="btsclear" Text="Clear" runat="server" CssClass="btn default" PostBackUrl="~/Employee.aspx" />--%>
                                            <asp:Button Text="Submit" ID="btnSubmit" Class="btn btn-success" runat="server" OnClick="btnSubmit_Click" />
                                          <%--  <asp:Button Text="Save Draft" ID="btnSavedraft" Class="btn btn-primary" runat="server" />--%>
                                            <asp:Button ID="btncancel" Text="Cancel" runat="server" CssClass="btn btn-danger" />
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


</body>
</html>