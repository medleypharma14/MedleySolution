<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Transpot.aspx.cs" Inherits="Medly_Wm.Transpot" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/Header.ascx" %>
<%@ Register TagPrefix="usc1" TagName="Sidebar" Src="~/Sidebar.ascx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Transport Master</title>
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
        /*.col-lg-12 {
            padding: 10px;
        }*/
        /*        .auto-style1 {
            position: relative;
            min-height: 1px;
            float: left;
            width: 50%;
            left: 0px;
            top: 0px;
            padding-left: 15px;
            padding-right: 15px;
        }
        .auto-style2 {
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
            left: 3px;
            top: -1px;
            border: 1px solid #c2cad8;
            padding: 6px 12px;
            background-color: #fff;
            background-image: none;
        }*/
    </style>
    <script type="text/javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
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
                    <asp:ScriptManager ID="scr1" runat="server"></asp:ScriptManager>
                    <div class="row">
                        <div class="col-md-12 ">
                            <div class="portlet-body form">

                                <div class="row">
                                            <div class="col-md-8 ">
                                                <div class="portlet box green">
                                                    <div class="portlet-title">
                                                        <div class="caption">
                                                            <i class="fa fa-cogs"></i>Transport List
                                                        </div>
                                                    </div>
                                                    <div class="portlet-body flip-scroll">
                                                        <div style="overflow: auto;">
                                                            <asp:GridView ID="gridtranspot" OnRowCommand="gridtranspot_RowCommand"
                                                                OnRowDataBound="gridtranspot_RowDataBound" runat="server"
                                                                CssClass="table table-bordered table-striped table-condensed flip-content"
                                                                AutoGenerateColumns="False" ForeColor="#333333" HorizontalAlign="Center" CellPadding="4" GridLines="None">
                                                                <AlternatingRowStyle BackColor="White" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="S.no.">
                                                                        <ItemTemplate>
                                                                            <%#Container.DataItemIndex+1 %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField HeaderText="S.No" DataField="id" Visible="false" />
                                                                    <asp:BoundField HeaderText="Transport" DataField="Transpot" />
                                                                    <asp:BoundField HeaderText="DOJ" DataField="DOJ" DataFormatString="{0:dd/MM/yyyy}" />
                                                                    <asp:BoundField HeaderText="Expiry" DataField="ExpiryDate" DataFormatString="{0:dd/MM/yyyy}" />
                                                                    <asp:BoundField HeaderText="Contact No" DataField="ContactNum" />
                                                                    <asp:BoundField HeaderText="Address" DataField="Address" />
                                                                    <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="btnedit" runat="server" CommandArgument='<%#Eval("id") %>'
                                                                                CommandName="edit" Enabled="false">

                                                                                <asp:ImageButton ID="imgEdit" ImageUrl="~/Images/edit.jpg" runat="server" Width="20px" CommandArgument='<%#Eval("id") %>' CommandName="edit123" Enabled="false" />
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="btndel" runat="server" CommandArgument='<%#Eval("id") %>'
                                                                                CommandName="Del" OnClientClick="return confirm('Are you sure to delete this Product?');" Enabled="false">

                                                                                <asp:ImageButton ID="imgDel" ImageUrl="~/Images/delete.png" runat="server" Width="20px" CommandArgument='<%#Eval("id") %>' CommandName="Del" Enabled="false" />
                                                                            </asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-4 ">
                                               
                                                <div class="portlet box green">
                                                    <div class="portlet-title">
                                                        <div class="caption">
                                                            <i class="fa fa-cogs"></i>Add Transport Name
                                                        </div>
                                                    </div>
                                                    <div class="portlet-body flip-scroll">
                                                         <asp:UpdatePanel ID="oop" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                                        <div class="row">
                                                             <div class="col-lg-12">
                                                            <div class="form-group">
                                                                <label><b>Enter Transport Name
                                                                       </b>
                                                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" ControlToValidate="txtTranspot"
                                                                            ValidationGroup="Validation"  ErrorMessage=" Enter Transport name" Style="color: Red" />
                                                                </label>
                                                                <div class="input-group">
                                                                    <span class="input-group-addon input-square-left">
                                                                        <i class="fa fa-truck"></i>
                                                                    </span>
                                                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtTranspot" placeholder="Transport" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-lg-6">
                                                                <div class="form-group">
                                                                    <label>
                                                                        <b>Date Of Joining</b>
                                                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="txtvalidtill"
                                                                            ValidationGroup="Validation" ErrorMessage="*" Style="color: Red" />
                                                                    </label>
                                                                        <asp:TextBox ID="txtdoj" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>

                                                                    <%--   <asp:TextBox runat="server" ID="txtdoj" CssClass="form-control" type="date" TextMode="Date" />--%>
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-6">
                                                                <label>
                                                                    <b>Valid Till</b>
                                                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtvalidtill"
                                                                            ValidationGroup="Validation" ErrorMessage="*" Style="color: Red" />
                                                                </label>
                                                                <asp:TextBox runat="server" OnTextChanged="txtvalidtill_TextChanged" AutoPostBack="true" ID="txtvalidtill" type="date" CssClass="form-control" TextMode="Date" />
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-lg-12">
                                                                <div class="form-group">
                                                                    <label>
                                                                        <b>Contact Number</b>
                                                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtContactnum"
                                                                            ValidationGroup="Validation" Text="Enter Contact Number" ErrorMessage="*" Style="color: Red" />
                                                                    </label>
                                                                    <asp:TextBox runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtContactnum_TextChanged" MaxLength="10" ID="txtContactnum" placeholder="Enter Contact Number" onkeypress="return isNumberKey(event)" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-lg-12">
                                                                <div class="form-group">
                                                                    <label>
                                                                        <b>Address</b>
                                                                        <asp:RequiredFieldValidator runat="server" ID="checkaddress" ControlToValidate="txtAddress"
                                                                            ValidationGroup="Validation" Text="*" ErrorMessage="*" Style="color: Red" />
                                                                    </label>
                                                                    <asp:TextBox runat="server" Placeholder="Enter Your Address" TextMode="MultiLine" ID="txtAddress" CssClass="form-control" />
                                                                </div>
                                                            </div>

                                                        </div>
                                                         </ContentTemplate>
                                    </asp:UpdatePanel> 
                                                    <div class="row">
                                                        <asp:Label ID="id" Visible="false" runat="server" />
                                                        <center>
                                                            <div class="form-group">
                                                                <asp:Button ID="btnSubmit" CssClass="btn red" Text="Submit" ValidationGroup="Validation" runat="server" OnClick="btnSubmit_Click" />
                                                                <asp:Button ID="btnCancel" CssClass="btn default " Text="Cancel" runat="server" PostBackUrl="~/Transpot.aspx" />
                                                            </div>
                                                        </center>
                                                    </div>
                                                    </div>
                                                    </div>
                                                </div>
                                                                         
                                </div>
                            </div>


                            <br />

                        </div>
                    </div>
                    </form>
            </div>
        </div>
    </div>
</body>
</html>
