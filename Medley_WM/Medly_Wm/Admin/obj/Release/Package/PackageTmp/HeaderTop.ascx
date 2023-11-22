<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HeaderTop.ascx.cs" Inherits="AdminAfforadbleApp.HeaderTop" %>

<div class="page-header navbar navbar-fixed-top">
            <!-- BEGIN HEADER INNER -->
            <div class="page-header-inner ">
                <!-- BEGIN LOGO -->
                <div class="page-logo">
                    <a href="Login.aspx" >
                       Affordable </a>
                    <div class="menu-toggler sidebar-toggler">
                        <!-- DOC: Remove the above "hide" to enable the sidebar toggler button on header -->
                    </div>
                </div>
                <!-- END LOGO -->
                <!-- BEGIN RESPONSIVE MENU TOGGLER -->
                <a href="javascript:;" class="menu-toggler responsive-toggler" data-toggle="collapse" data-target=".navbar-collapse"> </a>
                <!-- END RESPONSIVE MENU TOGGLER -->
                <!-- BEGIN PAGE ACTIONS -->
                <!-- DOC: Remove "hide" class to enable the page header actions -->
               
                <!-- END PAGE ACTIONS -->
                <!-- BEGIN PAGE TOP -->
                <div class="page-top" >
                  

                     
                    <!-- BEGIN HEADER SEARCH BOX -->
                    <!-- DOC: Apply "search-form-expanded" right after the "search-form" class to have half expanded search box -->
                 
                    <div class="col-md-3">
                    
                    </div>
                     <div class="col-md-4">
                         <center> <h2 >Affordable  MIS Reports</h2></center>
                     </div>
                    <!-- END HEADER SEARCH BOX -->
                    <!-- BEGIN TOP NAVIGATION MENU -->
                    <div class="col-md-3">
                    <div class="top-menu">
                    
                        <ul class="nav navbar-nav pull-right">
                            <!-- BEGIN NOTIFICATION DROPDOWN -->
                            <!-- DOC: Apply "dropdown-dark" class below "dropdown-extended" to change the dropdown styte -->
                            <!-- DOC: Apply "dropdown-hoverable" class after below "dropdown" and remove data-toggle="dropdown" data-hover="dropdown" data-close-others="true" attributes to enable hover dropdown mode -->
                            <!-- DOC: Remove "dropdown-hoverable" and add data-toggle="dropdown" data-hover="dropdown" data-close-others="true" attributes to the below A element with dropdown-toggle class -->
                            <li class="dropdown dropdown-extended dropdown-notification" id="header_notification_bar">
                                <a href="javascript:;" class="dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-close-others="true">
                                    <i class="icon-bell"></i>
                                    <span class="badge badge-default"> <asp:Label ID="txtTotalCount" runat="server"></asp:Label></span>
                                </a>
                                <ul class="dropdown-menu">
                                    <li class="external">
                                       <center>   <h3>
                                            <span class="bold">Notifications</span> </h3></center>
                                        
                                    </li>
                                    <li>
                                        <ul class="dropdown-menu-list scroller" style="height: 250px;" data-handle-color="#637283">
                                            
                                             
                                            <li>
                                                <a href="ShipmentDateReminder.aspx">
                                                    
                                                    <span class="details">
                                                        <span class="label label-sm label-icon label-warning">
                                                            <i class="fa fa-bell-o"></i>
                                                        </span> Buyer Order Shipment Reminder </span> <span class="badge badge-default" style="background-color: teal;"><asp:Label ID="TotalTaxCount" runat="server"></asp:Label></span>
                                                </a>
                                            </li>
                                            
                                            
                                            
                                        </ul>
                                    </li>
                                </ul>
                            </li>
                            
                            <!-- END QUICK SIDEBAR TOGGLER -->
                        </ul>
                    </div>
                    </div>
                    <!-- END TOP NAVIGATION MENU -->
               
                </div>
                <!-- END PAGE TOP -->
            </div>
            <!-- END HEADER INNER -->
        </div>