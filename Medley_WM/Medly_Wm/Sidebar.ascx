<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Sidebar.ascx.cs" Inherits="Medly_Wm.Siderbar" %>
<%--<form runat="server">
<div class="sidebar">
  <a ><asp:Menu ID="Menu1" runat="server" StaticSubMenuIndent="16px">
        <Items>
            <asp:MenuItem Text="Master" Value="Master">
                <asp:MenuItem Text="Contact Master" Value="Contact Master"></asp:MenuItem>
                <asp:MenuItem Text="Product Master" Value="Product Master"></asp:MenuItem>
                <asp:MenuItem Text="Employee Master" Value="Employee Master"></asp:MenuItem>
            </asp:MenuItem>
        </Items>
    </asp:Menu></a>
  
    <a >
    <asp:Menu ID="Menu2" runat="server" StaticSubMenuIndent="16px">
        <Items>
            <asp:MenuItem Text="Contact" Value="Contact">
                <asp:MenuItem Text="Email" Value="Email"></asp:MenuItem>
                <asp:MenuItem Text="Whatasapp" Value="Whatasapp"></asp:MenuItem>
                <asp:MenuItem Text="FaceBook" Value="FaceBook"></asp:MenuItem>
                  <asp:MenuItem Text="Instagram" Value="Instagram"></asp:MenuItem>
            </asp:MenuItem>
        </Items>
    </asp:Menu>
        </a>
    <a>

    
    <asp:Menu ID="Menu3" runat="server" StaticSubMenuIndent="16px">
        <Items>
            <asp:MenuItem Text="Product" Value="">
                <asp:MenuItem Text="Milk" Value="Contact Master"></asp:MenuItem>
                <asp:MenuItem Text="CURD" Value="Product Master"></asp:MenuItem>
                <asp:MenuItem Text="Biscuts" Value="Employee Master"></asp:MenuItem>
            </asp:MenuItem>
        </Items>
    </asp:Menu>
        </a>
    <a>
    <asp:Menu ID="Menu4" runat="server" StaticSubMenuIndent="16px">
        <Items>
            <asp:MenuItem Text="Service" Value="">
                <asp:MenuItem Text="Vehicle Service" Value="Contact Master"></asp:MenuItem>
                <asp:MenuItem Text="Bus Service" Value="Product Master"></asp:MenuItem>
                <asp:MenuItem Text="Car Service" Value="Employee Master"></asp:MenuItem>
            </asp:MenuItem>
        </Items>
    </asp:Menu>
        </a>
</div>
    </form>
   --%>

   <div class="page-header navbar navbar-fixed-top">
            <!-- BEGIN HEADER INNER -->
            <div class="page-header-inner ">
                <!-- BEGIN LOGO -->
                <div class="page-logo">
                  <%--  <img src="logo.jpg" style="border-radius:5px" width="190px" height="68px" alt="Alternate Text" />--%>
                    <a href="Designation.aspx">  <h4>Medley Pharma</h4> 
                    </a>
                  <%--  <div class="menu-toggler sidebar-toggler">
                        <!-- DOC: Remove the above "hide" to enable the sidebar toggler button on header -->
                    </div>--%>
                </div>
                <!-- END LOGO -->
                <!-- BEGIN RESPONSIVE MENU TOGGLER -->
                <a href="javascript:;" class="menu-toggler responsive-toggler" data-toggle="collapse" data-target=".navbar-collapse"> </a>
                <!-- END RESPONSIVE MENU TOGGLER -->
                <!-- BEGIN PAGE ACTIONS -->
                <!-- DOC: Remove "hide" class to enable the page header actions -->
                <div class="page-actions">
                    <div class="btn-group">
               
                      
                    </div>
                </div>
                <!-- END PAGE ACTIONS -->
                <!-- BEGIN PAGE TOP -->
                <div class="page-top">
                    <div class="page-actions" style="float:right;margin-right:50px;">
                   
                      <h4> <asp:Label ID="lblusername"  runat="server" /></h4>  
                  </div>
                    <!-- BEGIN HEADER SEARCH BOX -->
                    <!-- DOC: Apply "search-form-expanded" right after the "search-form" class to have half expanded search box -->
            
                    <!-- END HEADER SEARCH BOX -->
                    <!-- BEGIN TOP NAVIGATION MENU -->
                    
                    <!-- END TOP NAVIGATION MENU -->
                </div>
                <!-- END PAGE TOP -->
            </div>
            <!-- END HEADER INNER -->
        </div>
        <!-- END HEADER -->
        <!-- BEGIN HEADER & CONTENT DIVIDER -->