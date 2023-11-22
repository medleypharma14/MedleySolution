<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Designation.aspx.cs" Inherits="Medly_Wm.Designation" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/Header.ascx" %>
<%@ Register TagPrefix="usc1" TagName="Sidebar" Src="~/Sidebar.ascx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Designation Master</title>
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
                            <div class="portlet-body form">

                                <div class="row">
                                    <div class="col-md-6 ">
                                        <div class="portlet box green">
                                            <div class="portlet-title">
                                                <div class="caption">
                                                    <i class="fa fa-cogs"></i>Designation List
                                                </div>
                                            </div>
                                            <div class="portlet-body flip-scroll">
                                                <div class="form-group">
                                                    <asp:TextBox CssClass="form-control" Enabled="true" onkeyup="Search_Gridview(this, 'gvDesignation')"
                                                        ID="txtsearch" runat="server" placeholder="Enter Text to Search"></asp:TextBox>
                                                </div>
                                                <asp:GridView  ID="gvDesignation" OnRowCommand="gvDesignation_RowCommand" runat="server" CssClass="table table-bordered table-striped table-condensed flip-content" AutoGenerateColumns="False" ForeColor="#333333" HorizontalAlign="Center" ShowHeaderWhenEmpty="True" CellPadding="4" GridLines="None" OnRowDataBound="gvDesignation_RowDataBound" OnSelectedIndexChanged="gvDesignation_SelectedIndexChanged">
                                                
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.no.">
                                                            <ItemTemplate>
                                                                <%#Container.DataItemIndex+1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField HeaderText="S.No" DataField="DesignationID" Visible="false" />
                                                        <asp:BoundField HeaderText="Designation" DataField="Designation" />
                                                        <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btnedit" runat="server" CommandArgument='<%#Eval("DesignationID") %>'
                                                                    CommandName="edit" Enabled="false" >

                                                                    <asp:ImageButton ID="imgEdit" ImageUrl="~/Images/edit.jpg" runat="server" Width="20px" CommandArgument='<%#Eval("DesignationID") %>' CommandName="edit"  Enabled="false" />
                                                                </asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btndel" runat="server" CommandArgument='<%#Eval("DesignationID") %>'
                                                                    CommandName="Del" OnClientClick="return confirm('Are you sure to delete this ?');" Enabled="false">

                                                                    <asp:ImageButton ID="imgDel" ImageUrl="~/Images/delete.png" runat="server" Width="20px" CommandArgument='<%#Eval("DesignationID") %>' CommandName="Del" Enabled="false" />
                                                                </asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                    </Columns>

                                                </asp:GridView>
                                             
                                            </div>
                                        </div>



                                    </div>


                                    <div class="col-md-6 ">
                                        <div class="portlet box green">
                                            <div class="portlet-title">
                                                <div class="caption">
                                                    <i class="fa fa-cogs"></i>Add Designation
                                                </div>
                                            </div>
                                            <div class="portlet-body flip-scroll">
                                                <div class="form-group">
                                                    <label>
                                                       <b> Enter Designation Name</b>
                                                    </label>
                                                    <div class="input-group">
                                                        <span class="input-group-addon input-square-left">
                                                            <i class="fa fa-graduation-cap"></i>
                                                        </span>
                                                        <asp:TextBox runat="server" CssClass="form-control" ID="txtName" placeholder="Enter Your Designation" />
                                                    </div>
                                                </div>
                                                <center>
                                                    <div class="form-group">
                                                        <asp:Button ID="btnSubmit" CssClass="btn red" Text="Submit" runat="server" OnClick="btnSubmit_Click" />
                                                        <asp:Button ID="btnCancel" CssClass="btn default " Text="Cancel" runat="server" PostBackUrl="~/Designation.aspx" />
                                                    </div>
                                                </center>
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
    <%-- <div class="page-footer">
            <div class="page-footer-inner"> 2016 &copy; Metronic Theme By
                <a target="_blank" href="http://keenthemes.com">Keenthemes</a> &nbsp;|&nbsp;
                <a href="http://themeforest.net/item/metronic-responsive-admin-dashboard-template/4021469?ref=keenthemes" title="Purchase Metronic just for 27$ and get lifetime updates for free" target="_blank">Purchase Metronic!</a>
                <div class="scroll-to-top">
                    <i class="icon-arrow-up"></i>
                </div>
            </div>
            <!-- END FOOTER -->
            <!-- BEGIN QUICK NAV -->
            <nav class="quick-nav">
                <a class="quick-nav-trigger" href="#0">
                    <span aria-hidden="true"></span>
                </a>
                <ul>
                    <li>
                        <a href="https://themeforest.net/item/metronic-responsive-admin-dashboard-template/4021469?ref=keenthemes" target="_blank" class="active">
                            <span>Purchase Metronic</span>
                            <i class="icon-basket"></i>
                        </a>
                    </li>
                    <li>
                        <a href="https://themeforest.net/item/metronic-responsive-admin-dashboard-template/reviews/4021469?ref=keenthemes" target="_blank">
                            <span>Customer Reviews</span>
                            <i class="icon-users"></i>
                        </a>
                    </li>
                    <li>
                        <a href="http://keenthemes.com/showcast/" target="_blank">
                            <span>Showcase</span>
                            <i class="icon-user"></i>
                        </a>
                    </li>
                    <li>
                        <a href="http://keenthemes.com/metronic-theme/changelog/" target="_blank">
                            <span>Changelog</span>
                            <i class="icon-graph"></i>
                        </a>
                    </li>
                </ul>
                <span aria-hidden="true" class="quick-nav-bg"></span>
            </nav>
            <div class="quick-nav-overlay"></div>--%>
    <!-- END QUICK NAV -->
    <!--[if lt IE 9]>
<script src="../assets/global/plugins/respond.min.js"></script>
<script src="../assets/global/plugins/excanvas.min.js"></script> 
<script src="../assets/global/plugins/ie8.fix.min.js"></script> 
<![endif]-->
    <!-- BEGIN CORE PLUGINS -->
    <%--  <script src="../assets/global/plugins/jquery.min.js" type="text/javascript"></script>
            <script src="../assets/global/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
            <script src="../assets/global/plugins/js.cookie.min.js" type="text/javascript"></script>
            <script src="../assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js" type="text/javascript"></script>
            <script src="../assets/global/plugins/jquery.blockui.min.js" type="text/javascript"></script>
            <script src="../assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js" type="text/javascript"></script>
            <!-- END CORE PLUGINS -->
            <!-- BEGIN THEME GLOBAL SCRIPTS -->
            <script src="../assets/global/scripts/app.min.js" type="text/javascript"></script>
            <!-- END THEME GLOBAL SCRIPTS -->
            <!-- BEGIN THEME LAYOUT SCRIPTS -->
            <script src="../assets/layouts/layout2/scripts/layout.min.js" type="text/javascript"></script>
            <script src="../assets/layouts/layout2/scripts/demo.min.js" type="text/javascript"></script>
            <script src="../assets/layouts/global/scripts/quick-sidebar.min.js" type="text/javascript"></script>
            <script src="../assets/layouts/global/scripts/quick-nav.min.js" type="text/javascript"></script>
            <!-- END THEME LAYOUT SCRIPTS -->
            <script>
                $(document).ready(function()
                {
                    $('#clickmewow').click(function()
                    {
                        $('#radio1003').attr('checked', 'checked');
                    });
                })
            </script>--%>
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
