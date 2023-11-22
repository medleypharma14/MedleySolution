<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="Medly_Wm.AddProduct" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/Header.ascx" %>
<%@ Register TagPrefix="usc1" TagName="Sidebar" Src="~/Sidebar.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>

    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
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
    <link href="../assets/global/css/plugins-md.min.css" rel="stylesheet" type="text/css" />
    <!-- END THEME GLOBAL STYLES -->
    <!-- BEGIN THEME LAYOUT STYLES -->
    <link href="../assets/layouts/layout2/css/layout.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/layouts/layout2/css/custom.min.css" rel="stylesheet" type="text/css" />
    <!-- END THEME LAYOUT STYLES -->
    <link rel="shortcut icon" href="favicon.ico" />
    <meta charset="utf-8" />
    <title>Product Master</title>
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
                            <div class="col-lg-12">
                                <!-- BEGIN SAMPLE FORM PORTLET-->
                                <div class="portlet light ">
                                    <div class="portlet-title">
                                        <div class="caption font-red-sunglo">
                                            <i class="icon-settings font-red-sunglo"></i>
                                            <span class="caption-subject bold uppercase">Add Product</span>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="col-lg-12">
                                            <div class="col-lg-6">
                                                <div class="col-lg-6">
                                                    <div class="form-group">
                                                        <label>
                                                            Product Code
                                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ValidationGroup="Validation" runat="server" ErrorMessage="*" ControlToValidate="txtProductCode" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </label>
                                                        <div class="input-group">
                                                            <span class="input-group-addon input-square-left">
                                                                <i class="fa fa-user"></i>
                                                            </span>
                                                            <asp:TextBox ID="txtProductCode" runat="server" CssClass="form-control" placeholder="Enter Product Code" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-6">
                                                    <div class="form-group">
                                                        <label>
                                                            Inintial addition date
                                                               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Validation" runat="server" ErrorMessage="*" ControlToValidate="txtInitialadditiondate" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </label>
                                                        <div class="input-group">
                                                            <span class="input-group-addon input-square-left">
                                                                <i class="fa fa-calendar"></i>
                                                            </span>
                                                            <asp:TextBox runat="server" type="date" ID="txtInitialadditiondate" CssClass="form-control" placeholder=" Selet Date" TextMode="Date" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-6">
                                                    <div class="form-group">
                                                        <label>
                                                            Product Name
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="Validation" runat="server" ErrorMessage="*" ControlToValidate="txtProductname" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </label>
                                                        <div class="input-group">
                                                            <span class="input-group-addon input-square-left">
                                                                <i class="fa fa-user"></i>
                                                            </span>
                                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtProductname" placeholder=" Enter Product Name " />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-6">
                                                    <div class="form-group">

                                                        <label>
                                                            License No.
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="Validation" runat="server" ErrorMessage="*" ControlToValidate="txtLicenseno" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </label>
                                                        <div class="input-group">
                                                            <span class="input-group-addon input-square-left">
                                                                <i class="fa fa-user"></i>
                                                            </span>
                                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtLicenseno" placeholder="Enter License Name" />

                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-6">
                                                    <label>Dosage Form</label>
                                                    <div class="input-group">
                                                        <span class="input-group-addon input-square-left">
                                                            <i class="fa fa-plus-square"></i>
                                                        </span>
                                                        <asp:DropDownList ID="ddlDosageform" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="">Select</asp:ListItem>
                                                            <asp:ListItem Text="Tablet" />
                                                            <asp:ListItem Text="Capsule" />
                                                            <asp:ListItem Text="Gel" />
                                                            <asp:ListItem Text="Drops" />
                                                            <asp:ListItem Text="Solution" />
                                                            <asp:ListItem Text="Suspension" />
                                                            <asp:ListItem Text="Caplet" />
                                                            <asp:ListItem Text="Effervescent Tablets" />

                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-lg-6">
                                                    <div class="form-group">
                                                        <label>
                                                            Pack Size
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ValidationGroup="Validation" runat="server" ErrorMessage="*" ControlToValidate="txtPacksize" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </label>

                                                        <div class="input-group">
                                                            <span class="input-group-addon input-square-left">
                                                                <i class="fa fa-bar-chart"></i>
                                                            </span>
                                                            <asp:TextBox ID="txtPacksize" runat="server" CssClass="form-control" placeholder="Enter Size"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div>
                                                </div>
                                                <div class="col-lg-12">
                                                </div>
                                            </div>
                                            <div class="">
                                                <div class="col-lg-6">
                                                    <div class="col-lg-6">
                                                        <label>
                                                            Strength
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ValidationGroup="Validation" runat="server" ErrorMessage="*" ControlToValidate="txtStrength" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </label>
                                                        <div class="input-group">
                                                            <span class="input-group-addon input-square-left">
                                                                <i class="fa fa-adjust"></i>
                                                            </span>
                                                            <asp:TextBox ID="txtStrength" runat="server" CssClass="form-control" placeholder=" Enter Strength"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <div class="form-group">
                                                            <label>PIP Code</label>
                                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator11" ControlToValidate="txtPIPcode"
                                                        ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Contact Number" Style="color: Red" />
                                                    <div class="input-group">
                                                        <span class="input-group-addon input-square-left">
                                                            <i class="fa fa-fa fa-adjust"></i>
                                                        </span>
                                                        <asp:TextBox runat="server" CssClass="form-control" ID="txtPIPcode"  placeholder="Enter PIP Code"/>
                                                    </div>
                                                            <div id="tax" runat="server" visible="false">
                                                                  <label>Taxation Type</label>
                                                            <div class="input-group">
                                                                <span class="input-group-addon input-square-left">
                                                                    <i class="fa fa-fa fa-bitcoin"></i>
                                                                </span>
                                                                <asp:DropDownList ID="ddlTaxationtype" runat="server" CssClass="form-control">
                                                                    <asp:ListItem Value="">Select</asp:ListItem>
                                                                    <asp:ListItem Text="Cash" />
                                                                    <asp:ListItem Text="Cheque" />
                                                                </asp:DropDownList>
                                                            </div>
                                                            </div>
                                                          
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <div class="form-group">
                                                            <label>
                                                                Product Manufacturer
                                                            </label>
                                                            <div class="input-group">
                                                                <span class="input-group-addon input-square-left">
                                                                    <i class="fa fa-industry"></i>
                                                                </span>
                                                                <asp:DropDownList ID="ddlProductanufacture" runat="server" CssClass="form-control">
                                                                    <asp:ListItem Value="">Select</asp:ListItem>
                                                                    <asp:ListItem Text="Medley" />
                                                                    <asp:ListItem Text="Wholesale" />
                                                                    <asp:ListItem Text="Others" />
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <div class="form-group">
                                                            <label>
                                                                Product Category
                                                            </label>
                                                            <div class="input-group">
                                                                <span class="input-group-addon input-square-left">
                                                                    <i class="fa fa-industry"></i>
                                                                </span>
                                                                <asp:DropDownList ID="ddlproductcatogory" runat="server" CssClass="form-control">
                                                                    <asp:ListItem Value="">Select</asp:ListItem>
                                                                    <asp:ListItem Text="POM" />
                                                                    <asp:ListItem Text="FOOD SUPLEMENT" />
                                                                    <asp:ListItem Text="P" />
                                                                    <asp:ListItem Text="GSL" />
                                                                    <asp:ListItem Text="NA" />
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <div class="form-group">
                                                            <label>
                                                                GTIN Barcode
                                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="Validation" runat="server" ErrorMessage="*" ControlToValidate="txtGTINBarcode" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            </label>
                                                            <div class="input-group">
                                                                <span class="input-group-addon input-square-left">
                                                                    <i class="fa fa-user"></i>
                                                                </span>
                                                                <asp:TextBox ID="txtGTINBarcode" runat="server" CssClass="form-control" placeholder="Enter Bracode Code" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <div class="form-group">
                                                            <label>
                                                                Minimum Stock Qty
                                                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="Validation" runat="server" ErrorMessage="*" ControlToValidate="txtminimumqty" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            </label>
                                                            <div class="input-group">
                                                                <span class="input-group-addon input-square-left">
                                                                    <i class="fa fa-size"></i>
                                                                </span>
                                                                <asp:TextBox ID="txtminimumqty" runat="server" CssClass="form-control" placeholder="Product Quanity" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                 </div>
                                            </div>
                                            <div class="col-lg-12">
                                                 <div id="pip" runat="server" visible="false"> 
                                                 <div class="col-lg-4">
                                                    
                                                    <label>PIP Code</label>
                                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtPIPcode"
                                                        ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Contact Number" Style="color: Red" />
                                                    <div class="input-group">
                                                        <span class="input-group-addon input-square-left">
                                                            <i class="fa fa-fa fa-adjust"></i>
                                                        </span>
                                                        <asp:TextBox runat="server" CssClass="form-control" ID="TXT1"  placeholder="Enter PIP Code"/>
                                                    </div>
                                                         </div>

                                                </div>
                                                <div class="hideapprov" id="hideapprov" runat="server" visible="false">
                                                    <div class="col-lg-6">
                                                    <label>Select Approver </label>
                                                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator8" ControlToValidate="ddlselectapprover"
                                                        ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Contact Number" Style="color: Red" />
                                                    <div class="input-group">
                                                        <span class="input-group-addon input-square-left">
                                                            <i class="fa fa-fa fa-bitcoin"></i>
                                                        </span>
                                                        <asp:DropDownList ID="ddlSelectapprover" runat="server" CssClass="form-control" placeholder="Select">
                                                            <asp:ListItem Value="">Select</asp:ListItem>
                                                            <asp:ListItem Text="Manager"></asp:ListItem>
                                                            <asp:ListItem Text="Client"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>

                                                </div>
                                                <div class="col-lg-6 row">
                                                    <label>Select Status </label>
                                                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control" placeholder="Select" Enabled="false">
                                                        <asp:ListItem Value="">Select</asp:ListItem>
                                                        <asp:ListItem Text="Draft" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Text="Approved"></asp:ListItem>
                                                        <asp:ListItem Text="Rejected"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                </div>
                                                
                                            </div>
                                            <div class="col-lg1-12">
                                                <div class="col-lg-6">
                                                <div class="col-lg-6">
                                                    <div class="form-group">
                                                        <label>
                                                            Status
                                                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ValidationGroup="Validation" runat="server" ErrorMessage="*" ControlToValidate="ddlProductStatus" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </label>
                                                        <div class="input-group">
                                                            <span class="input-group-addon input-square-left">
                                                                <i class="fa fa-bar-chart"></i>
                                                            </span>
                                                            <asp:DropDownList runat="server" ID="ddlProductStatus" CssClass="form-control">
                                                                <asp:ListItem Text="Select" Value="Select" />
                                                                <asp:ListItem Text="Active" />
                                                                <asp:ListItem Text="Not Active" />
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                </div>
                                            </div>  
                                        </div>
                                        <div class="col-lg-12">
                                            <center>
                                                <div class="form-group">
                                                    <div class="col-lg-12" style="padding-top: 20px">
                                                        <%--  <asp:Button ID="btsclear" Text="Clear" runat="server" CssClass="btn default" PostBackUrl="~/AddProduct.aspx"  />--%>
                                                        <asp:Button ID="btnSubmit" Text="Submit" ValidationGroup="Validation" runat="server" CssClass="btn btn-success" OnClick="btnSubmit_Click" />
                                                        <asp:Button ID="btncancel" Text="Cancel" runat="server" CssClass="btn btn-danger" PostBackUrl="~/ProductGridpage.aspx" />
                                                    </div>
                                                </div>
                                            </center>
                                        </div>
                                        <div class="row">
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

