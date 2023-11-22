<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodsReceipt2.aspx.cs" Inherits="Medly_Wm.GoodsReceipt2" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/Header.ascx" %>
<%@ Register TagPrefix="usc1" TagName="Sidebar" Src="~/Sidebar.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Goods Receipts</title>
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
        label{
            font-weight:bold;
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

                <form id="form1" runat="server">
                    <div class="row">
                        <div class="col-md-12 ">
                                <!-- BEGIN SAMPLE FORM PORTLET-->
                                <div class="portlet light ">
                                    <div class="portlet-title">
                                        <div class="caption font-red-sunglo">
                                            <i class="icon-settings font-red-sunglo"></i>
                                            <span class="caption-subject bold uppercase">Add goods receipt</span>
                                              <div class="pull-right">
                                                <%--    <div class="form-group">
                                                    <label>GRN number</label>--%>
                                                    <asp:TextBox ID="txtGRNnumber" Visible="false" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                                    <%--  </div>--%>
                                                </div>
                                        </div>
                                        <div class="actions">
                                            <div class="btn-group">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="portlet light" style="height:1600px">
                                       
                                            <div class="form-body">
                                                    <div class="row">
                                                        <div class="col-lg-4">
                                                            <div class="form-group">
                                                                <div>
                                                                    <asp:RadioButtonList runat="server" AutoPostBack="true" ID="SelectOrder" RepeatDirection="Horizontal" Width="80%" OnTextChanged="SelectOrder_TextChanged" >
                                                                        <asp:ListItem Text="PO Store" Value="POOrder"/>
                                                                        <asp:ListItem Text="Return Store" Value="ReturnOrder" />
                                                                    </asp:RadioButtonList>
                                                                </div>
                                                                <div id="poorder" runat="server" visible="false">
                                                                    <label>PO Number:</label>
                                                                <asp:DropDownList runat="server" ID="ddlPOnumber" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlPOnumber_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                </div>
                                                                <div id="returnorder" runat="server" visible="false">
                                                                    <label>Return Number:</label>
                                                                    <asp:DropDownList runat="server" ID="ddlReturnnumber" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlReturnnumber_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </div>
                                                                
                                                            </div>
                                                        </div>

                                                        <div class="col-lg-4">
                                                            <label>Product Name:</label>
                                                             <asp:DropDownList runat="server" ID="ddlProductid" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlProductid_SelectedIndexChanged">
                                                          </asp:DropDownList>
                                                        </div>
                                                        <div class="col-lg-4">
                                                            <label>Dosage Form:</label>
                                                             <asp:TextBox ID="txtDosageform" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                                                        </div>

                                                    </div>

                                                    <div class="row">
                                                        <div class="col-lg-4">
                                                            <label>Strength:</label>
                                                             <asp:TextBox ID="txtStrength" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                                                          
                                                        </div>
                                                        <div class="col-lg-2">
                                                            <asp:Label ID="lblordqty" runat="server" Text="Order Quantity:"></asp:Label>
                                                             <asp:TextBox ID="txtOrderqty" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                                                        </div>
                                                        <div class="col-lg-2">
                                                            <asp:Label ID="lblremqty" runat="server" Text="Remaining Quantity:"></asp:Label>
                                                            <asp:TextBox ID="txtRemqty" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                                                        </div>

                                                        <div class="col-lg-4">
                                                            <div class="form-group">
                                                            <label>Total Amount:</label>
                                                             <asp:TextBox ID="txtOrderAmount" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                                                </div>
                                                        </div>
                                                    </div>


                                                    <div class="col-lg-12" style="border: 2px solid skyblue">
                                                       <div>
                                                            <div class="row" style="padding-top: 20px;">
                                                            <div class="col-lg-3">
                                                                <label>Batch Number</label>
                                                                <asp:TextBox ID="txtBatch" OnTextChanged="txtBatch_TextChanged" AutoPostBack="true" runat="server" CssClass="form-control"></asp:TextBox>
                                                            </div>

                                                            <div class="col-lg-2">
                                                                <label>Received quantity</label>
                                                                <asp:TextBox ID="txtRecdQty" AutoPostBack="true" OnTextChanged="txtRecdQty_TextChanged" runat="server" CssClass="form-control"></asp:TextBox>
                                                            </div>
                                                            <div class="col-lg-2">
                                                                <label>Expiry date
                                                                </label>
                                                                <asp:TextBox ID="txtExpDate" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                                                                 
                                                            </div>

                                                                <div class="col-lg-2">
                                                                    <label>No of pallets</label>
                                                                    <asp:TextBox ID="txtPallets" runat="server" CssClass="form-control" AutoPostBack="true"  OnTextChanged="txtPallets_TextChanged"></asp:TextBox>
                                                                </div>
                                                               <%-- <div class="col-lg-2">
                                                                <label>Pallets Ref No</label>
                                                                <asp:TextBox ID="txtpalletsrefno" runat="server" CssClass="form-control" placeholder="Refernce No"></asp:TextBox>
                                                            </div>  --%>                                                     
                                                                <div class="col-lg-3">
                                                                    <div class="form-group">
                                                                <label>Batch status</label>
                                                                <asp:DropDownList ID="ddlbatchstatus" runat="server" CssClass="form-control" Enabled="false">
                                                                    <asp:ListItem Text="Quarantine" Value="Quarantine"></asp:ListItem>
                                                                       <asp:ListItem Text="Release" Value="Release"></asp:ListItem>
                                                                    <asp:ListItem Text="Destroyed" Value="Destroyed"></asp:ListItem>
                                                                    <asp:ListItem Text="Rejected" Value="Rejected"></asp:ListItem>
                                                                </asp:DropDownList>
                                                                        </div>
                                                            </div>
                                                                
                                                                   <div class="col-lg-4" style="padding: 30px;display:none">
                                                                <label>Selected units:- </label>
                                                                <asp:DropDownList ID="ddlSelectedunits" runat="server" CssClass="form-control" AutoPostBack="true">
                                                                        <%--<asp:ListItem Value="">Select</asp:ListItem>
                                                                        <asp:ListItem Value="">MAS</asp:ListItem>
                                                                        <asp:ListItem Value="">MDU</asp:ListItem>--%>
                                                                    </asp:DropDownList>

                                                            </div>

                                                         </div>   

                                                            <div class="col-lg-4" style="padding: 30px;display:none">
                                                                <label>Palate refernce number</label>
                                                                <asp:TextBox ID="txtPlatereferenceno" runat="server" CssClass="form-control" placeholder="Enter Reference Number"></asp:TextBox>
                                                            </div>
                                                               
                                                                 <div class="form-group" style="display:none">
                                                                <center>
                                                                   

                                                                    
                                                                 <div class="col-lg-2" id="lbldisplay" runat="server" ></div>
                                                                       
                                                                <div class="col-lg-4" id ="txtdisplay"  runat="server" ></div>
                                                               </center>
                                                                     </div>
                                                                <div class="portlet" id="List" runat="server" visible="false">
                                                                    <table>
                                                                        <tr>
                                                                            <td>
                                                                                <b><asp:Label ID="TextBox1" runat="server" Text="">Unit Name</asp:Label></b></td>
                                                                            <td>
                                                                                <b><asp:Label ID="TextBox2" runat="server" Text="">Quantity</asp:Label></b></td>
                                                                            <td>
                                                                               <b> <asp:Label ID="TextBox3" runat="server"  Text="">Reference No</asp:Label></b></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:TextBox ID="lbl0" runat="server" Visible="false" placeholder="Enter Unitname" AutoPostBack="true" OnTextChanged="lbl0_TextChanged" CssClass="form-control"></asp:TextBox></td>
                                                                            <td>  <asp:TextBox ID="txt0" runat="server" Visible="false" Text="0" CssClass="form-control"></asp:TextBox></td>
                                                                            <td>  <asp:TextBox ID="txtpr0" runat="server" Visible="false" placeholder="Enter Reference" Text="0" CssClass="form-control"></asp:TextBox></td>
                                                                        </tr>
                                                                        <tr><td> <asp:TextBox ID="lbl1" runat="server" Visible="false" placeholder="Enter Unitname" AutoPostBack="true" OnTextChanged="lbl1_TextChanged" CssClass="form-control"></asp:TextBox></td>
                                                                            <td>  <asp:TextBox ID="txt1" runat="server" Visible="false" Text="0" CssClass="form-control"></asp:TextBox></td>
                                                                            <td>  <asp:TextBox ID="txtpr1" runat="server" Visible="false" Text="0" placeholder="Enter Reference" CssClass="form-control"></asp:TextBox></td>
                                                                        </tr>

                                                                        <tr><td> <asp:TextBox ID="lbl2" runat="server" Visible="false" placeholder="Enter Unitname" AutoPostBack="true" OnTextChanged="lbl2_TextChanged" CssClass="form-control"></asp:TextBox></td>
                                                                            <td>  <asp:TextBox ID="txt2" runat="server" Visible="false" Text="0" CssClass="form-control"></asp:TextBox></td>
                                                                            <td>  <asp:TextBox ID="txtpr2" runat="server" Visible="false" Text="0" placeholder="Enter Reference" CssClass="form-control"></asp:TextBox></td>
                                                                        </tr>

                                                                        <tr><td> <asp:TextBox ID="lbl3" runat="server" Visible="false" placeholder="Enter Unitname" AutoPostBack="true" OnTextChanged="lbl3_TextChanged" CssClass="form-control"></asp:TextBox></td>
                                                                            <td>  <asp:TextBox ID="txt3" runat="server" Visible="false" Text="0" CssClass="form-control"></asp:TextBox></td>
                                                                            <td>  <asp:TextBox ID="txtpr3" runat="server" Visible="false" Text="0" CssClass="form-control"></asp:TextBox></td>
                                                                        </tr>

                                                                        <tr><td> <asp:TextBox ID="lbl4" runat="server" Visible="false" placeholder="Enter Unitname" AutoPostBack="true" OnTextChanged="lbl4_TextChanged" CssClass="form-control"></asp:TextBox></td>
                                                                            <td>  <asp:TextBox ID="txt4" runat="server" Visible="false" Text="0" CssClass="form-control"></asp:TextBox></td>
                                                                            <td>  <asp:TextBox ID="txtpr4" runat="server" Visible="false" Text="0" placeholder="Enter Reference" CssClass="form-control"></asp:TextBox></td>
                                                                        </tr>
                                                                         
                                                                        <tr><td> <asp:TextBox ID="lbl5" runat="server" Visible="false" placeholder="Enter Unitname" AutoPostBack="true" OnTextChanged="lbl5_TextChanged" CssClass="form-control"></asp:TextBox></td>
                                                                            <td>  <asp:TextBox ID="txt5" runat="server" Visible="false" Text="0" CssClass="form-control"></asp:TextBox></td>
                                                                            <td>  <asp:TextBox ID="txtpr5" runat="server" Visible="false" Text="0" placeholder="Enter Reference" CssClass="form-control"></asp:TextBox></td>
                                                                        </tr>

                                                                        <tr><td> <asp:TextBox ID="lbl6" runat="server" Visible="false" placeholder="Enter Unitname" AutoPostBack="true" OnTextChanged="lbl6_TextChanged" CssClass="form-control"></asp:TextBox></td>
                                                                            <td>  <asp:TextBox ID="txt6" runat="server" Visible="false" Text="0" CssClass="form-control"></asp:TextBox></td>
                                                                            <td>  <asp:TextBox ID="txtpr6" runat="server" Visible="false" Text="0" placeholder="Enter Reference" CssClass="form-control"></asp:TextBox></td>
                                                                        </tr>

                                                                        <tr><td> <asp:TextBox ID="lbl7" runat="server" Visible="false" placeholder="Enter Unitname" AutoPostBack="true" OnTextChanged="lbl7_TextChanged" CssClass="form-control"></asp:TextBox></td>
                                                                            <td>  <asp:TextBox ID="txt7" runat="server" Visible="false" Text="0" CssClass="form-control"></asp:TextBox></td>
                                                                            <td>  <asp:TextBox ID="txtpr7" runat="server" Visible="false" Text="0" placeholder="Enter Reference" CssClass="form-control"></asp:TextBox></td>
                                                                        </tr>

                                                                        <tr><td> <asp:TextBox ID="lbl8" runat="server" Visible="false" placeholder="Enter Unitname" AutoPostBack="true" OnTextChanged="lbl8_TextChanged" CssClass="form-control"></asp:TextBox></td>
                                                                            <td>  <asp:TextBox ID="txt8" runat="server" Visible="false" Text="0" CssClass="form-control"></asp:TextBox></td>
                                                                            <td>  <asp:TextBox ID="txtpr8" runat="server" Visible="false" Text="0" placeholder="Enter Reference" CssClass="form-control"></asp:TextBox></td>
                                                                        </tr>

                                                                        <tr><td> <asp:TextBox ID="lbl9" runat="server" Visible="false" placeholder="Enter Unitname" AutoPostBack="true" OnTextChanged="lbl9_TextChanged" CssClass="form-control"></asp:TextBox></td>
                                                                            <td>  <asp:TextBox ID="txt9" runat="server" Visible="false" Text="0" CssClass="form-control"></asp:TextBox></td>
                                                                            <td>  <asp:TextBox ID="txtpr9" runat="server" Visible="false" Text="0" placeholder="Enter Reference" CssClass="form-control"></asp:TextBox></td>
                                                                        </tr>

                                                                       
                                                                    </table>
                                                                   
                                                                  

                                                                    <asp:Button ID="btnCalSubmit" runat="server" Text="Check & Submit" CssClass="btn btn-info" Visible="false" />

                                                                </div>
                                                                

                                                           
                                                       </div>
                                                          
                                                        <div class="row">
                                                             <div class="col-lg-4">
                                                                <label>Select Approver: </label>

                                                                <div class="form-group">
                                                                    <asp:DropDownList ID="ddlSelectapprover" runat="server" CssClass="form-control" placeholder="Select" Width="320px">
                                                                        <asp:ListItem Value="">Select</asp:ListItem>
                                                                        <%--<asp:ListItem Text="Manager"></asp:ListItem>
                                                                    <asp:ListItem Text="Client"></asp:ListItem>--%>
                                                                    </asp:DropDownList>
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
                                                            <div class="col-lg-12">
                                                                <center>

                                                                    <div cl="col-lg-12" style="padding-top: 20px">
                                                                        <!--<button type="submit" class="btn blue">Submit</button>-->

                                                                        <%--   <asp:Button ID="btndraft" runat="server" class="btn yellow" Text="Clear" PostBackUrl="~/GoodsReceipts.aspx" />--%>

                                                                        <asp:Button Text="Submit" ID="btnSubmit" runat="server" class="btn btn-success" ValidationGroup="Validation" OnClick="btnsubmit_Click" />
                                                                        <asp:Button ID="btncancel" runat="server" class="btn btn-danger" Text="Cancel" PostBackUrl="~/GoodsReceipts.aspx" />
                                                                    </div>


                                                                </center>
                                                            </div>
                                                                <div class="col-lg-6" style="display:none">
                                                <label>Floor No:</label>
                                                <%--<div class="input-group">
                                                    <span class="input-group-addon input-circle-left">
                                                        <%--<i class="fa fa-user"></i>
                                                    </span></div>--%>
                                                <asp:Label ID="lblFloor" runat="server" CssClass="form-control"></asp:Label><br />
                                                <%-- <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" placeholder="Enter Address" />--%>
                                            </div>

                                            <div class="col-lg-6" style="display:none">
                                                <%--  Floor No:
                                            <asp:Label ID="lblFloor" runat="server"></asp:Label><br />--%>
                                                <label>Unitname: </label>
                                                <asp:Label ID="lblUnit" runat="server" CssClass="form-control"></asp:Label><br />
                                            </div>
                                                        <div class="col-lg-12" style="margin-top:20px; border:2px solid skyblue">
                                                            <div>
                                                                <div class="col-lg-12" style="padding-top: 10px; display:none">
                                                            <div class="col-lg-6">
                                                                <div class="col-lg-4" style="float: left; padding-top: 10px;">
                                                                    <label>Select Warehouse</label>
                                                                </div>
                                                                <div class="col-lg-8">
                                                                   <%-- <asp:TextBox runat="server"  CssClass="form-control" placeholder="Medly" ReadOnly="true" />--%>
                                                                    <asp:DropDownList ID="ddlwarehouse" runat="server" CssClass="form-control" AutoPostBack="true">
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-4" style="float: right; padding-top: 7px;">
                                                                <label><b>Asile</b></label>
                                                                <asp:LinkButton ID="LinkButton1" runat="server"><< </asp:LinkButton>
                                                                <asp:LinkButton ID="LinkButton2" runat="server">< </asp:LinkButton>

                                                                <asp:LinkButton ID="LinkButton10" runat="server">></asp:LinkButton>
                                                                <asp:LinkButton ID="LinkButton11" runat="server">>></asp:LinkButton>
                                                            </div>
                                                        </div>
                                                        </div>
                                                        

                                                        <div class="col-lg-12">
                                                               <div class="panel-body" align="left" style="overflow: auto">
                                                        <asp:DataList ID="ddUnits1" runat="server" RepeatLayout="Table" RepeatDirection="Horizontal" RepeatColumns="20"
                                                            OnItemDataBound="ddRoomListSecond_ItemDataBound">
                                                            <ItemTemplate>
                                                                <asp:Button CssClass="btn btn-success" ID="btns1" runat="server" ForeColor="White" OnClick="btnClick"
                                                                    Text='<%#  Eval("Unitname")%>' CommandArgument='<%# Eval("UnitId") %>'
                                                                    CommandName='<%# Eval("Isempty") %>' Style="font-size: small; word-wrap: break-word; float: left; white-space: normal; -webkit-transition-duration: 0.4s; transition-duration: 0.4s;" />
                                                            </ItemTemplate>
                                                        </asp:DataList>
                                                      <%--  <asp:DataList ID="ddUnits2" runat="server"
                                                            RepeatLayout="Table" RepeatDirection="Horizontal" RepeatColumns="20"
                                                            OnItemDataBound="ddRoomListSecond_ItemDataBound">
                                                            <ItemTemplate>
                                                                <asp:Button CssClass="btn btn-success" ID="btns1" runat="server" ForeColor="White" OnClick="btnClick"
                                                                    Text='<%#  Eval("Unitname")%>' CommandArgument='<%# Eval("UnitId") %>'
                                                                    CommandName='<%# Eval("Isempty") %>' Style="font-size: small; word-wrap: break-word; float: left; white-space: normal; -webkit-transition-duration: 0.4s; transition-duration: 0.4s;" />
                                                            </ItemTemplate>
                                                        </asp:DataList>
                                                        <asp:DataList ID="ddUnits3" runat="server"
                                                            RepeatLayout="Table" RepeatDirection="Horizontal" RepeatColumns="20"
                                                            OnItemDataBound="ddRoomListSecond_ItemDataBound">
                                                            <ItemTemplate>
                                                                <asp:Button CssClass="btn btn-success" ID="btns1" runat="server" ForeColor="White" OnClick="btnClick"
                                                                    Text='<%#  Eval("Unitname")%>' CommandArgument='<%# Eval("UnitId") %>'
                                                                    CommandName='<%# Eval("Isempty") %>' Style="font-size: small; word-wrap: break-word; float: left; white-space: normal; -webkit-transition-duration: 0.4s; transition-duration: 0.4s;" />
                                                            </ItemTemplate>
                                                        </asp:DataList>
                                                        <asp:DataList ID="ddUnits4" runat="server" RepeatLayout="Table" RepeatDirection="Horizontal" RepeatColumns="20"
                                                            OnItemDataBound="ddRoomListSecond_ItemDataBound">
                                                            <ItemTemplate>
                                                                <asp:Button CssClass="btn btn-success" ID="btns1" runat="server" ForeColor="White" OnClick="btnClick"
                                                                    Text='<%#  Eval("Unitname")%>' CommandArgument='<%# Eval("UnitId") %>'
                                                                    CommandName='<%# Eval("Isempty") %>' Style="font-size: small; word-wrap: break-word; float: left; white-space: normal; -webkit-transition-duration: 0" />
                                                            </ItemTemplate>
                                                        </asp:DataList>--%>



                                                    </div>
  <%--  Floor End--%>
                                                            </div>
                                                     
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
    </div>
    
    <!-- BEGIN CORE PLUGINS -->
    <script src="assets/global/plugins/jquery.min.js" type="text/javascript"></script>
    <script src="assets/global/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="assets/global/plugins/js.cookie.min.js" type="text/javascript"></script>
    <script src="assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js" type="text/javascript"></script>
    <script src="assets/global/plugins/jquery.blockui.min.js" type="text/javascript"></script>
    <script src="assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js" type="text/javascript"></script>
    <!-- END CORE PLUGINS -->
    <!-- BEGIN THEME GLOBAL SCRIPTS -->
    <script src="assets/global/scripts/app.min.js" type="text/javascript"></script>
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
    </script>
  <script type="text/javascript">
      // Attach event listeners to TextBox controls with IDs like "lbl0", "lbl1", etc.
      document.addEventListener("DOMContentLoaded", function () {
          var inputElements = document.querySelectorAll('[id^="lbl"]');
          for (var i = 0; i < inputElements.length; i++)
          {
              inputElements[i].addEventListener('input', function () {
                  this.value = this.value.toUpperCase();
              });
          }
          var inputElementsBatch = document.querySelectorAll('[id^="txtBatch"]');
          for (var i = 0; i < inputElementsBatch.length; i++) {
              inputElementsBatch[i].addEventListener('input', function () {
                  this.value = this.value.toUpperCase();
              });
          }
      });

  </script>
</body>
</html>