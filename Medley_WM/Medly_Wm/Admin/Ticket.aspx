<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ticket.aspx.cs" Inherits="AdminAfforadbleApp.Ticket" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/Admin/Header.ascx" %>
<%@ Register TagPrefix="usc2" TagName="Header2" Src="~/Admin/HeaderTop.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <title>Ticket</title>
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
    <link href="../assets/global/plugins/datatables/datatables.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.css"
        rel="stylesheet" type="text/css" />
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
    <script src="https://cdn.amcharts.com/lib/4/core.js"></script>
    <script src="https://cdn.amcharts.com/lib/4/charts.js"></script>
    <script src="https://cdn.amcharts.com/lib/4/themes/animated.js"></script>
    <!-- END THEME LAYOUT STYLES -->
    <link rel="shortcut icon" href="favicon.ico" />
    <script type="text/javascript">
        function goBack() {
            window.history.back();
        }
    </script>
    <%--     <script type="text/javascript">
             $(document).on("change", ".file_multi_video", function (evt) {
                 debugger;
                 var $source = $('#video_here');
                 $source[0].src = URL.createObjectURL(this.files[0]);
                 $source.parent()[0].load();
                 var url = URL.createObjectURL(this.files[0]);

             });

           
        </script>--%>
    <style>
        .button
        {
            background-color: #217EBD; /* Green */
            border: none;
            color: white;
            padding: 5px 12px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 17px;
            font-weight: bolder;
            margin: 4px 2px;
            cursor: pointer;
        }
    </style>
</head>
<body class="page-header-fixed page-sidebar-closed-hide-logo page-container-bg-solid page-md">
    <usc2:Header2 ID="Header2" runat="server" />
    <div class="clearfix">
    </div>
    <div class="page-container">
        <usc:Header ID="Header" runat="server" />
        <form id="form1" runat="server">
        <div>
            <div class="page-content-wrapper">
                <!-- BEGIN CONTENT BODY -->
                <div class="page-content">
                    <!-- BEGIN PAGE HEADER-->
                    <!-- BEGIN THEME PANEL -->
                    <!-- END THEME PANEL -->
                    <h1 class="page-title">
                        Raise Ticket
                    </h1>
                    <div class="row">
                        <div class="col-md-12">
                            <!-- BEGIN EXAMPLE TABLE PORTLET-->
                            <div class="portlet light ">
                                <div class="portlet-title">
                                    <div class="caption font-dark">
                                        <span class="caption-subject bold uppercase">Raise Ticket</span>
                                        </span>
                                    </div>
                                </div>
                                <div class="portlet-body">
                                    <div class="row">
                                        <div class="col-lg-4">
                                            <div class="form-group form-md-line-input form-md-floating-label">
                                                <label>
                                                    Ticket No</label>
                                                <asp:TextBox CssClass="form-control" ID="txtTicketNo" runat="server" placeholder="Enter Ticket No" ReadOnly="true"></asp:TextBox>
                                            </div>
                                            <div class="form-group form-md-line-input form-md-floating-label">
                                                <label>
                                                    Ticket Date&Time</label>
                                                <asp:TextBox CssClass="form-control" ID="txtTicketDate" runat="server" placeholder="Enter Ticket Date" ReadOnly="true"></asp:TextBox>
                                            </div>
                                            <div class="form-group form-md-line-input form-md-floating-label">
                                                <label>
                                                    Select TeamLeader</label><br />
                                                <asp:DropDownList ID="ddlTeamLeader" AutoPostBack="true" runat="server" Width="100%">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group form-md-line-input form-md-floating-label">
                                                <label>
                                                    Select Customer</label><br />
                                                <asp:DropDownList ID="ddlCustomer" AutoPostBack="true" runat="server" Width="100%" OnSelectedIndexChanged="ddlCustomer_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="form-group form-md-line-input form-md-floating-label">
                                                <label>
                                                    Select Product</label><br />
                                                <asp:DropDownList ID="ddlProduct" AutoPostBack="true" runat="server" Width="100%" OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged" >
                                                </asp:DropDownList>
                                            </div>
                                             <div class="form-group form-md-line-input form-md-floating-label">
                                                <label>
                                                    </label>
                                               Purchased Date: <asp:TextBox CssClass="form-control" ID="txtPurDate" runat="server" placeholder="Enter Year" ReadOnly="true"></asp:TextBox>    
                                               Actual Warranty: <asp:TextBox CssClass="form-control" ID="txtActualWarranty" runat="server" placeholder="Enter Year" ReadOnly="true"></asp:TextBox>                                               
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="form-group form-md-line-input form-md-floating-label">
                                                <label>
                                                    </label>
                                               Warranty Years: <asp:TextBox CssClass="form-control" ID="txtWarrantyyear" runat="server" placeholder="Enter Year" ReadOnly="true"></asp:TextBox>
                                                Warranty Months: <asp:TextBox CssClass="form-control" ID="txtWarrantymonth" runat="server" placeholder="Enter Month" ReadOnly="true"></asp:TextBox>
                                            </div>
                                            <div class="form-group form-md-line-input form-md-floating-label">
                                                <label>
                                                    Ticket Description</label>
                                                <asp:TextBox CssClass="form-control" ID="txtTicketDescription" runat="server" placeholder="Enter Ticket Description" TextMode="MultiLine"></asp:TextBox>
                                            </div>
                                             
                                        </div>
                                        <div>
                                            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success" Text="Save" OnClick="btnSave_Click" />
                                            <asp:Button ID="btnReset" runat="server" CssClass="btn btn-danger" Text="Back" OnClick="btnReset_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- END EXAMPLE TABLE PORTLET-->
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form> </div>
</body>
</html>
