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
            <li class="nav-item start "><a href="Ticketdetails.aspx" class="nav-link nav-toggle">
                <i class="fa fa-list"></i><span class="title">Ticket Details</span> <span class="arrow">
                </span></a></li>
            <li class="nav-item start "><a href="javascript:;" class="nav-link nav-toggle"><i
                class="fa fa-globe"></i><span class="title">Master</span> <span class="arrow"></span>
            </a>
                <ul class="sub-menu">
                    <li class="nav-item start "><a href="categorymaster.aspx" class="nav-link "><i class="icon-bar-chart">
                    </i><span class="title">Category</span> </a></li>
                     <li class="nav-item start "><a href="customermaster.aspx" class="nav-link "><i class="icon-bar-chart">
                    </i><span class="title">Customer</span> </a></li>
                        <li class="nav-item start "><a href="ProductGrid.aspx" class="nav-link "><i class="icon-bar-chart">
                    </i><span class="title">Product</span> </a></li>
                        <li class="nav-item start "><a href="EmployeeGrid.aspx" class="nav-link "><i class="icon-bar-chart">
                    </i><span class="title">Employee</span> </a></li>
                </ul>
            </li>
                 <li class="nav-item start "><a href="javascript:;" class="nav-link nav-toggle"><i
                class="fa fa-globe"></i><span class="title">Tickets</span> <span class="arrow"></span>
            </a>
                <ul class="sub-menu">
                    <li class="nav-item start "><a href="Ticketgrid.aspx" class="nav-link "><i class="icon-bar-chart">
                    </i><span class="title">New Tickets</span> </a></li>
                     <li class="nav-item start "><a href="ServiceReminder.aspx" class="nav-link "><i class="icon-bar-chart">
                    </i><span class="title">Service Reminders</span> </a></li>
                       
                </ul>
            </li>

            <li class="nav-item start "><a href="Login.aspx" class="nav-link nav-toggle"><i class="fa fa-sign-out">
            </i><span class="title">Signout</span> <span class="arrow"></span></a></li>
        </ul>
        <!-- END SIDEBAR MENU -->
    </div>
    <!-- END SIDEBAR -->
</div>
