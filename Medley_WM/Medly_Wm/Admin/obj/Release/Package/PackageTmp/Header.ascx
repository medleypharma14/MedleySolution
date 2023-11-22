<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="FoodAdminReports.Header" %>

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
        <ul class="page-sidebar-menu  page-header-fixed page-sidebar-menu-hover-submenu "
            data-keep-expanded="false" data-auto-scroll="true" data-slide-speed="200">
            <li class="nav-item start "><a href="Dashboard.aspx" class="nav-link nav-toggle"><i
                class="icon-home"></i><span class="title">Dashboard</span> <span class="arrow"></span>
            </a></li>
            <li class="nav-item start "><a href="javascript:;" class="nav-link nav-toggle"><i
                class="fa fa-globe"></i><span class="title">Buyer Order Reports</span> <span class="arrow">
                </span></a>
                <ul class="sub-menu">
                    <li class="nav-item start "><a href="Homepage.aspx" class="nav-link "><i class="icon-bar-chart">
                    </i><span class="title">Latest Costing Details</span> </a></li>
                    <li class="nav-item start "><a href="BuyerOrderReport.aspx" class="nav-link "><i
                        class="icon-graph"></i><span class="title">Buyer Order Report</span> </a></li>
                    <li class="nav-item start "><a href="BuyerOrderSummaryReport.aspx" class="nav-link ">
                        <i class="icon-graph"></i><span class="title">Buyer Order Summary Report</span>
                    </a></li>
                    <li class="nav-item start "><a href="BuyerOrderWiseShipmentDetails.aspx" class="nav-link ">
                        <i class="icon-graph"></i><span class="title">Buyer Order Wise Shipment Details Report</span>
                    </a></li>
                    <li class="nav-item start "><a href="PurchaseOrderPendingReport.aspx" class="nav-link ">
                        <i class="icon-graph"></i><span class="title">Purchase Order Pending Report</span>
                    </a></li>
                    <li class="nav-item start "><a href="CurrentFabricStatusReport.aspx" class="nav-link ">
                        <i class="icon-graph"></i><span class="title">Current Fabric Status Report</span>
                    </a></li>
                    <li class="nav-item start "><a href="StockStatementReport.aspx" class="nav-link "><i
                        class="icon-graph"></i><span class="title">Stock Statement Report</span> </a>
                    </li>
                    <li class="nav-item start "><a href="RequirementSheetDetails.aspx" class="nav-link ">
                        <i class="icon-graph"></i><span class="title">RequirementSheet Details Report</span>
                    </a></li>
                </ul>
            </li>
             <li class="nav-item start "><a href="DailyProductionReport.aspx" class="nav-link nav-toggle"><i class="fa fa-globe">
            </i><span class="title">Daily Production Report</span> <span class="arrow"></span></a></li>

              <li class="nav-item start "><a href="ChangePassword.aspx" class="nav-link nav-toggle"><i class="fa fa-globe">
            </i><span class="title">Change Password</span> <span class="arrow"></span></a></li>

            <li class="nav-item start "><a href="Login.aspx" class="nav-link nav-toggle"><i class="fa fa-sign-out">
            </i><span class="title">Signout</span> <span class="arrow"></span></a></li>
        </ul>
        <!-- END SIDEBAR MENU -->
    </div>
    <!-- END SIDEBAR -->
</div>
