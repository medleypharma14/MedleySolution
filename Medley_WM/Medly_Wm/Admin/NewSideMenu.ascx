<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewSideMenu.ascx.cs" Inherits="AdminTradingApp.NewSideMenu" %>
<html>
<head>
       <!-- BEGIN GLOBAL MANDATORY STYLES -->
        <link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all" rel="stylesheet" type="text/css" />
        <link href="../assets/global/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
        <link href="../assets/global/plugins/simple-line-icons/simple-line-icons.min.css" rel="stylesheet" type="text/css" />
        <link href="../assets/global/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
        <link href="../assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css" rel="stylesheet" type="text/css" />
        <!-- END GLOBAL MANDATORY STYLES -->
        <!-- BEGIN PAGE LEVEL PLUGINS -->
        <link href="../assets/global/plugins/bootstrap-daterangepicker/daterangepicker.min.css" rel="stylesheet" type="text/css" />
        <link href="../assets/global/plugins/morris/morris.css" rel="stylesheet" type="text/css" />
        <link href="../assets/global/plugins/fullcalendar/fullcalendar.min.css" rel="stylesheet" type="text/css" />
        <link href="../assets/global/plugins/jqvmap/jqvmap/jqvmap.css" rel="stylesheet" type="text/css" />
        <!-- END PAGE LEVEL PLUGINS -->
        <!-- BEGIN THEME GLOBAL STYLES -->
        <link href="../assets/global/css/components-md.min.css" rel="stylesheet" id="style_components" type="text/css" />
        <link href="../assets/global/css/plugins-md.min.css" rel="stylesheet" type="text/css" />
        <!-- END THEME GLOBAL STYLES -->
        <!-- BEGIN THEME LAYOUT STYLES -->
        <link href="../assets/layouts/layout2/css/layout.min.css" rel="stylesheet" type="text/css" />
        <link href="../assets/layouts/layout2/css/themes/blue.min.css" rel="stylesheet" type="text/css" id="style_color" />
        <link href="../assets/layouts/layout2/css/custom.min.css" rel="stylesheet" type="text/css" />
        <!-- END THEME LAYOUT STYLES -->
         <!-- BEGIN PAGE LEVEL PLUGINS -->
        <link href="../assets/global/plugins/datatables/datatables.min.css" rel="stylesheet" type="text/css" />
        <link href="../assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.css" rel="stylesheet" type="text/css" />
        <!-- END PAGE LEVEL PLUGINS -->
        <link rel="shortcut icon" href="favicon.ico" />
               <!-- BEGIN GLOBAL MANDATORY STYLES -->
        <link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all" rel="stylesheet" type="text/css" />
        <link href="../assets/global/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
        <link href="../assets/global/plugins/simple-line-icons/simple-line-icons.min.css" rel="stylesheet" type="text/css" />
        <link href="../assets/global/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
        <link href="../assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css" rel="stylesheet" type="text/css" />
        <!-- END GLOBAL MANDATORY STYLES -->
        <!-- BEGIN PAGE LEVEL PLUGINS -->
        <link href="../assets/global/plugins/bootstrap-fileinput/bootstrap-fileinput.css" rel="stylesheet" type="text/css" />
        <link href="../assets/global/plugins/datatables/datatables.min.css" rel="stylesheet" type="text/css" />
        <link href="../assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.css" rel="stylesheet" type="text/css" />
        <!-- END PAGE LEVEL PLUGINS -->
        <!-- BEGIN THEME GLOBAL STYLES -->
        <link href="../assets/global/css/components-md.min.css" rel="stylesheet" id="Link1" type="text/css" />
        <link href="../assets/global/css/plugins-md.min.css" rel="stylesheet" type="text/css" />
        <!-- END THEME GLOBAL STYLES -->
        <!-- BEGIN PAGE LEVEL STYLES -->
        <link href="../assets/pages/css/profile.min.css" rel="stylesheet" type="text/css" />
        <link href="../assets/apps/css/ticket.min.css" rel="stylesheet" type="text/css" />
        <!-- END PAGE LEVEL STYLES -->
        <!-- BEGIN THEME LAYOUT STYLES -->
        <link href="../assets/layouts/layout2/css/layout.min.css" rel="stylesheet" type="text/css" />
        <link href="../assets/layouts/layout2/css/themes/blue.min.css" rel="stylesheet" type="text/css" id="Link2" />
        <link href="../assets/layouts/layout2/css/custom.min.css" rel="stylesheet" type="text/css" />
        <!-- END THEME LAYOUT STYLES -->
</head>
<body>

            <marquee direction="right"> <asp:Label ID="lblmessege" runat="server" ForeColor="White" Font-Bold="false" ></asp:Label></marquee>
  <div id="Div1" align="right" runat="server" visible="false">
                        <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label">Welcome : </asp:Label>
                        <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label" Style="font-size: large;
                            text-decoration: blink; border-color: Gray" Visible="true"> </asp:Label>
                        <asp:Label runat="server" ID="Label2" ForeColor="White" CssClass="label">: </asp:Label>
                        <asp:Label runat="server" ID="lblstore" ForeColor="White" Style="font-size: large;
                            text-decoration: blink; border-color: Gray" Visible="true"> </asp:Label>
                        <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false  "> </asp:Label><br />
                        <asp:Label ID="lblscreenname" Style="font-size: larger; color: White" runat="server"
                            CssClass="label"></asp:Label>
                    </div>
       <!-- BEGIN SIDEBAR -->
            <div class="page-sidebar-wrapper">
                <!-- END SIDEBAR -->
                <!-- DOC: Set data-auto-scroll="false" to disable the sidebar from auto scrolling/focusing -->
                <!-- DOC: Change data-auto-speed="200" to adjust the sub menu slide up/down speed -->
                <div class="page-sidebar navbar-collapse collapse">
                    <!-- BEGIN SIDEBAR MENU -->
                    <!-- DOC: Apply "page-sidebar-menu-light" class right after "page-sidebar-menu" to enable light sidebar menu style(without borders) -->
                    <!-- DOC: Apply "page-sidebar-menu-hover-submenu" class right after "page-sidebar-menu" to enable hoverable(hover vs accordion) sub menu mode -->
                    <!-- DOC: Apply "page-sidebar-menu-closed" class right after "page-sidebar-menu" to collapse("page-sidebar-closed" class must be applied to the body element) the sidebar sub menu mode -->
                    <!-- DOC: Set data-auto-scroll="false" to disable the sidebar from auto scrolling/focusing -->
                    <!-- DOC: Set data-keep-expand="true" to keep the submenues expanded -->
                    <!-- DOC: Set data-auto-speed="200" to adjust the sub menu slide up/down speed -->
                    <ul class="page-sidebar-menu  page-header-fixed page-sidebar-menu-hover-submenu " data-keep-expanded="false" data-auto-scroll="true" data-slide-speed="200">
                      

                      

                        <li class="nav-item  " id="MasterMenu"  runat="server">
                            <a href="javascript:;" class="nav-link nav-toggle">
                                <i class="icon-settings"></i>
                                <span class="title">Sales Report</span>
                                <span class="arrow"></span>
                            </a>
                            <ul class="sub-menu">
                               
                                <li class="nav-item  " id="tablemaster" runat="server" visible="true">
                                    <a href="Homepage.aspx" class="nav-link ">
                                        <span class="title">Sales Report</span>
                                    </a>
                                </li>
                                 <li class="nav-item  " id="Li1" runat="server" visible="true">
                                    <a href="Category.aspx" class="nav-link ">
                                        <span class="title">Category Report</span>
                                    </a>
                                </li>
                                 <li class="nav-item" id="Li2" runat="server" visible="true">
                                    <a href="SalesProduct.aspx" class="nav-link ">
                                        <span class="title">Sales Product Report</span>
                                    </a>
                                </li>
                                   <li class="nav-item" id="Li3" runat="server" visible="true">
                                    <a href="SalesExpense.aspx" class="nav-link ">
                                        <span class="title">Sales Expense Report</span>
                                    </a>
                                </li>
                                   <li class="nav-item" id="Li4" runat="server" visible="true">
                                    <a href="SalesTimewise.aspx" class="nav-link ">
                                        <span class="title">Houres Wise Sales Report</span>
                                    </a>
                                </li>
                                   <li class="nav-item" id="Li5" runat="server" visible="true">
                                    <a href="SalesOutStandingReport.aspx" class="nav-link ">
                                        <span class="title">Sales OutStanding Report</span>
                                    </a>
                                </li>
                                   <li class="nav-item" id="Li6" runat="server" visible="true">
                                    <a href="ReceiptReport.aspx" class="nav-link ">
                                        <span class="title">Receipt Report</span>
                                    </a>
                                </li>
                                 <li class="nav-item " id="notificationmsg" runat="server" >
                                    <a href="PaymentReport.aspx" class="nav-link ">
                                        <span class="title"> Payment Report</span>
                                    </a>
                                </li>
                                <li class="nav-item" id="Li7" runat="server" visible="true">
                                    <a href="PDCIssueReport.aspx" class="nav-link ">
                                        <span class="title">PDCIssue Report</span>
                                    </a>
                                </li>
                                <li class="nav-item" id="Li8" runat="server" visible="true">
                                    <a href="PDCReceiveReport.aspx" class="nav-link ">
                                        <span class="title">PDCReceive Report</span>
                                    </a>
                                </li>
                                <li class="nav-item" id="Li9" runat="server" visible="true">
                                    <a href="SalesNonAccountReport.aspx" class="nav-link ">
                                        <span class="title">Sales NonAccount Report</span>
                                    </a>
                                </li>
                                  <li class="nav-item" id="Li10" runat="server" visible="true">
                                    <a href="SalesDcReport.aspx" class="nav-link ">
                                        <span class="title">Sales Dc Report</span>
                                    </a>
                                </li>
                                  <li class="nav-item" id="Li11" runat="server" visible="true">
                                    <a href="SalesReturnReport.aspx" class="nav-link ">
                                        <span class="title">Sales Return Report</span>
                                    </a>
                                </li>
                                <li class="nav-item" id="Li12" runat="server" visible="true">
                                    <a href="SalesPerformaReport.aspx" class="nav-link ">
                                        <span class="title">Sales Performa Report</span>
                                    </a>
                                </li>
                                 <li class="nav-item  " id="attender" runat="server" visible="false"><a href="../Accountsbootstrap/AttenderMaster.aspx" class="nav-link ">
                       <span class="title">  Attender Master</span></a></li>
                        <li class="nav-item  " id="IBSM" runat="server" visible="false"><a href="../Accountsbootstrap/InterBranchSetting.aspx" class="nav-link ">
                        <span class="title"> Intet Branch Setting Master</span></a></li>
                        
                    <li class="nav-item  " id="UOM" runat="server" visible="false"><a href="../Accountsbootstrap/Uom.aspx" class="nav-link ">
                        <span class="title"> Uom Master</span></a></li>
                    <li class="nav-item  " id="TAX" runat="server" visible="false"><a href="../Accountsbootstrap/Tax.aspx" class="nav-link ">
                        <span class="title"> Tax Master</span></a></li>
                    <li class="nav-item  " id="Category" runat="server" visible="false"><a href="../Accountsbootstrap/categorygrid.aspx" class="nav-link ">
                        <span class="title"> Group Master</span></a></li>
                        <li class="nav-item  " id="Msetting" runat="server" visible="false"><a href="../Accountsbootstrap/MarginSetting.aspx" class="nav-link ">
                        <span class="title"> Margin Setting</span></a></li>
                    <li class="nav-item  " id="subcategory" runat="server" visible="false"><a href="../Accountsbootstrap/SubCategory.aspx" class="nav-link ">
                        <span class="title"> Sub Category Master</span></a></li>
                    <li class="nav-item  " id="Item" runat="server" visible="false"><a href="../Accountsbootstrap/Descriptiongrid.aspx" class="nav-link ">
                        <span class="title"> Item Master</span></a></li>
                        <li class="nav-item  " id="itemupdate" runat="server" visible="false"><a href="../Accountsbootstrap/itemupdatescreen.aspx" class="nav-link ">
                        <span class="title"> Quick Item Update</span></a></li>
                        

                    <li class="nav-item  " id="saletypemaster" runat="server" visible="false"><a href="../Accountsbootstrap/SalesType.aspx" class="nav-link ">
                        <span class="title"> Sales Type Master</span></a></li>
                    <li class="nav-item  " id="Ingcategory" runat="server" visible="false"><a href="../Accountsbootstrap/ProdCategoryGrid.aspx" class="nav-link ">
                        <span class="title"> Ingridients Category Master</span></a></li>
                    <li class="nav-item  " id="Online" runat="server" visible="false"><a href="../Accountsbootstrap/OnlineMaster.aspx" class="nav-link ">
                        <span class="title"> Online Master</span></a></li>
                    <li class="nav-item  " id="BranchSetting" runat="server" visible="false"><a href="../Accountsbootstrap/BranchSetting.aspx" class="nav-link ">
                        <span class="title"> Branch-Production Setting</span></a></li>
                    <li id="Ingridients" runat="server" visible="false"><a href="../Accountsbootstrap/Ingridients.aspx" class="nav-link ">
                       <span class="title">  Ingridients Master</span></a></li>
                    <li class="nav-item  " id="Customer" runat="server" visible="false"><a href="../Accountsbootstrap/viewcustomer.aspx" class="nav-link ">
                       <span class="title">  Contact Master</span></a></li>
                    <li class="nav-item  " id="SemiRaw" runat="server" visible="false"><a href="../Accountsbootstrap/SemiRawSetting.aspx" class="nav-link ">
                        <span class="title"> Recepie Settings</span></a></li>
                    <li class="nav-item  " id="Ledger" runat="server" visible="false"><a href="../Accountsbootstrap/LedgerMasterGrid.aspx" class="nav-link ">
                         <span class="title">Ledger Master</span></a></li>
                    <li class="nav-item  " id="Dealer" visible="false" runat="server"><a href="../Accountsbootstrap/ReceiptReport.aspx" class="nav-link ">
                       <span class="title">  Dealer Creation</span></a></li>
                    <li class="nav-item  " id="MinimumQty" runat="server" visible="false"><a href="../Accountsbootstrap/MinQty.aspx class="nav-link ">
                        <span class="title"> Minimum Qty Set</span> </a></li>
                    <li class="nav-item  " id="ChangeRate" visible="false" runat="server"><a href="../Accountsbootstrap/ChangeRate.aspx" class="nav-link ">
                        <span class="title"> Change Rate</span></a></li>
                    <li class="nav-item  " id="Waiter" runat="server" visible="false"><a href="../Accountsbootstrap/Waiter.aspx" class="nav-link ">
                       <span class="title">  Waiter</span></a></li>

                            </ul>
                        </li>
                       
                    
                        
                        <li class="nav-item  ">
                            <a href="../Accountsbootstrap/newlogin.aspx" class="nav-link nav-toggle">
                                <i class=" icon-wrench"></i>
                                <span class="title">Sign Out</span>
                                <span class="arrow"></span>
                            </a>
                            
                        </li>
                   
                
                    </ul>
                    <!-- END SIDEBAR MENU -->
                </div>
                <!-- END SIDEBAR -->
            </div>
            <!-- BEGIN CORE PLUGINS -->
            <script src="../assets/global/plugins/jquery.min.js" type="text/javascript"></script>
            <script src="../assets/global/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
            <script src="../assets/global/plugins/js.cookie.min.js" type="text/javascript"></script>
            <script src="../assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js" type="text/javascript"></script>
            <script src="../assets/global/plugins/jquery.blockui.min.js" type="text/javascript"></script>
            <script src="../assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js" type="text/javascript"></script>
            <!-- END CORE PLUGINS -->
            <!-- BEGIN PAGE LEVEL PLUGINS -->
            <script src="../assets/global/plugins/bootstrap-fileinput/bootstrap-fileinput.js" type="text/javascript"></script>
            <script src="../assets/global/plugins/jquery.sparkline.min.js" type="text/javascript"></script>
            <script src="../assets/global/scripts/datatable.js" type="text/javascript"></script>
            <script src="../assets/global/plugins/datatables/datatables.min.js" type="text/javascript"></script>
            <script src="../assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.js" type="text/javascript"></script>
            <!-- END PAGE LEVEL PLUGINS -->
            <!-- BEGIN THEME GLOBAL SCRIPTS -->
            <script src="../assets/global/scripts/app.min.js" type="text/javascript"></script>
            <!-- END THEME GLOBAL SCRIPTS -->
            <!-- BEGIN PAGE LEVEL SCRIPTS -->
            <script src="../assets/pages/scripts/profile.min.js" type="text/javascript"></script>
            <script src="../assets/pages/scripts/table-datatables-managed.min.js" type="text/javascript"></script>
            <!-- END PAGE LEVEL SCRIPTS -->
            <!-- BEGIN THEME LAYOUT SCRIPTS -->
            <script src="../assets/layouts/layout2/scripts/layout.min.js" type="text/javascript"></script>
            <script src="../assets/layouts/layout2/scripts/demo.min.js" type="text/javascript"></script>
            <script src="../assets/layouts/global/scripts/quick-sidebar.min.js" type="text/javascript"></script>
            <script src="../assets/layouts/global/scripts/quick-nav.min.js" type="text/javascript"></script>
            <!-- END THEME LAYOUT SCRIPTS -->
                <!-- BEGIN CORE PLUGINS -->
            <script src="../assets/global/plugins/jquery.min.js" type="text/javascript"></script>
            <script src="../assets/global/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
            <script src="../assets/global/plugins/js.cookie.min.js" type="text/javascript"></script>
            <script src="../assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js" type="text/javascript"></script>
            <script src="../assets/global/plugins/jquery.blockui.min.js" type="text/javascript"></script>
            <script src="../assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js" type="text/javascript"></script>
            <!-- END CORE PLUGINS -->
            <!-- BEGIN PAGE LEVEL PLUGINS -->
            <script src="../assets/global/plugins/bootstrap-fileinput/bootstrap-fileinput.js" type="text/javascript"></script>
            <script src="../assets/global/plugins/jquery.sparkline.min.js" type="text/javascript"></script>
            <script src="../assets/global/scripts/datatable.js" type="text/javascript"></script>
            <script src="../assets/global/plugins/datatables/datatables.min.js" type="text/javascript"></script>
            <script src="../assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.js" type="text/javascript"></script>
            <!-- END PAGE LEVEL PLUGINS -->
            <!-- BEGIN THEME GLOBAL SCRIPTS -->
            <script src="../assets/global/scripts/app.min.js" type="text/javascript"></script>
            <!-- END THEME GLOBAL SCRIPTS -->
            <!-- BEGIN PAGE LEVEL SCRIPTS -->
            <script src="../assets/pages/scripts/profile.min.js" type="text/javascript"></script>
            <script src="../assets/pages/scripts/table-datatables-managed.min.js" type="text/javascript"></script>
            <!-- END PAGE LEVEL SCRIPTS -->
            <!-- BEGIN THEME LAYOUT SCRIPTS -->
            <script src="../assets/layouts/layout2/scripts/layout.min.js" type="text/javascript"></script>
            <script src="../assets/layouts/layout2/scripts/demo.min.js" type="text/javascript"></script>
            <script src="../assets/layouts/global/scripts/quick-sidebar.min.js" type="text/javascript"></script>
            <script src="../assets/layouts/global/scripts/quick-nav.min.js" type="text/javascript"></script>
            <!-- END THEME LAYOUT SCRIPTS -->
</body>
</html>