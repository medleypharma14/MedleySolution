<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateSO.aspx.cs" Inherits="Medly_Wm.CreateSO" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/Header.ascx" %>
<%@ Register TagPrefix="usc1" TagName="Sidebar" Src="~/Sidebar.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Create SO</title>
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
        th {
            /*  background-color:#507CD1;
          border:1px solid  white;*/
            font-size: 14px;
        }
        label{
            font-weight:bold;
        }
    </style>
     <script type="text/javascript">
         function isNumberKey(evt) {
             var charCode = (evt.which) ? evt.which : event.keyCode;
             if (charCode < 48 || charCode > 57) {
                 // Allow the dot (decimal point)
                 if (charCode !== 46) {
                     return false;
                 }
             }
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
                 <asp:ScriptManager ID="script" runat="server" EnablePartialRendering="true">
                    </asp:ScriptManager>
                    <div class="row">
                        <div class="col-md-12 ">
                            <!-- BEGIN SAMPLE FORM PORTLET-->
                            <div class="portlet light ">
                                <asp:UpdatePanel ID="updatepanel" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <div class="portlet-title">
                                    <div class="caption font-red-sunglo">
                                        <i class="icon-settings font-red-sunglo"></i>
                                        <span class="caption-subject bold uppercase">Create SO</span>
                                    </div>
                                    <div class="actions">
                                        <div class="btn-group">
                                        </div>
                                    </div>
                                </div>

                                <div class="portlet-body form">
                                </div>
                                <div class="col-lg-12">
                                     <div class="col-lg-3">
                                        <label>Comapny Name</label>
                                        <asp:DropDownList ID="ddlCompanyname" runat="server" CssClass="form-control" OnTextChanged="ddlCompanyname_TextChanged" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>
                                     <div class="col-lg-3">
                                        <label>Customer Name</label>
                                        <asp:DropDownList ID="ddlSuppliername" runat="server" CssClass="form-control" OnTextChanged="ddlSuppliername_TextChanged" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>
                                       <div class="col-lg-3" style="float: right">
                                        <label>SO Date</label>
                                        <asp:TextBox ID="txtSOdate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                    </div>
                                      <div class="col-lg-3" style="float: right">
                                        <div class="form-group">
                                            <label>SO Number</label>
                                            <asp:TextBox ID="txtSOnumber" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                        </div>

                                    </div>
                                </div>
                                <div class="col-lg-12">
                                    <div class="col-lg-6">
                                        <label>Delivery Address</label>
                                        <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control"/>
                                       <%-- <asp:DropDownList runat="server" ID="ddlAddress" CssClass="form-control">
                                        </asp:DropDownList>--%>
                                    </div>
                                     <div class="col-lg-3">
                                        <div class="form-group">
                                            <label>Reference No
                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtRefno"
                                                   ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Reference No" Style="color: Red" />
                                            </label>
                                            <asp:TextBox runat="server" ID="txtRefno" CssClass="form-control" placeholder="Enter Ref No" />
                                        </div>

                                    </div>
                                    <div class="col-lg-3" style="float: right">
                                        <div class="form-group">
                                            <label>Delivery  Date
                                                <asp:RequiredFieldValidator runat="server" ID="dojcheck" ControlToValidate="txtDeliverydate"
                                                   ValidationGroup="Validation" Text="*" ErrorMessage="Please select Deliverydate" Style="color: Red" />
                                            </label>
                                            <asp:TextBox runat="server" ID="txtDeliverydate" CssClass="form-control" TextMode="Date" />
                                        </div>

                                    </div>

                                </div>
                                <div class="col-lg-12" id="table" runat="server" visible="true">
                                    <div class="col-lg-12" style="overflow: auto">
                                        <div class="form-group">
                                            <table>
                                                <tr>
                                                    <th>Product</th>
                                                    <%--<th>License No</th>--%>
                                                    <th>Product Name</th>
                                                    <th>Dosage Form</th>
                                                    <th>Strength</th>
                                                    <%--  <th>Pack Type</th>
                                                    <th>Pack Size</th>--%>
                                                    <th>SO Qty</th>
                                                    <th>Price</th>
                                                    <th>VAT%</th>
                                                    <th>Total Amount</th>
                                                </tr>

                                                <tr>

                                                    <td>
                                                        <asp:DropDownList ID="ddlProductname" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlProductname_SelectedIndexChanged">
                                                        </asp:DropDownList></td>
                                                    <%--<td>
                                                        <asp:TextBox ID="txtLicenseno" runat="server" placeholder="Licenseno" CssClass="form-control" Visible="false"></asp:TextBox>
                                                    </td>--%>

                                                    <td>
                                                        <asp:TextBox ID="txtProductname" runat="server" placeholder="Productname" CssClass="form-control"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtDosageform" runat="server" placeholder="Dosageform" CssClass="form-control"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtStrength" runat="server" placeholder="Strength" CssClass="form-control"></asp:TextBox>
                                                    </td>
                                                    <%-- <td>
                                                        <asp:TextBox ID="txtPacktype" runat="server" placeholder="Packtype" CssClass="form-control"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPacksize" runat="server" placeholder="Packsize" CssClass="form-control"></asp:TextBox>
                                                    </td>--%>
                                                    <td>
                                                        <asp:TextBox ID="txtSoqty" runat="server" placeholder="SoQty" AutoPostBack="true" CssClass="form-control" onkeypress="return isNumberKey(event)" Text="0" OnTextChanged="txtSoqty_TextChanged"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPriceperpack" runat="server" AutoPostBack="true" placeholder="Priceperpack" onkeypress="return isNumberKey(event)" Text="0" OnTextChanged="txtSoqty_TextChanged" CssClass="form-control"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtVAT" runat="server" AutoPostBack="true" OnTextChanged="txtVAT_TextChanged" onkeypress="return isNumberKey(event)" placeholder="VAT%" Text="0" CssClass="form-control"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txttotalamt" Text="0" runat="server" placeholder="Productamt" CssClass="form-control" Enabled="false"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:ImageButton ImageUrl="Images/plusbtn1.png" ID="btnAddrows" runat="server" OnClick="btnAddrows_Click" Height="30px" Width="30px" />
                                                        <%--<asp:Button ID="btnAddrows" runat="server" Text="Addnew" OnClick="btnAddrows_Click" />--%>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="col-lg-12">
                                    <div class="col-lg-12" id="Div1" runat="server" style="overflow: auto;">
                                        <asp:GridView ID="grvCreateSo" EmptyDataText=""  runat="server" CssClass="table table-striped  flip-content" OnRowCommand="grvCreateSo_RowCommand" AutoGenerateColumns="False" ForeColor="#333333" HorizontalAlign="Center" ShowHeaderWhenEmpty="True" CellPadding="4" GridLines="None" OnRowDataBound="grvCreateSo_RowDataBound">

                                            <%--<asp:GridView ID="grvCreatePo" runat="server" CssClass="table table-striped  flip-content" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false" OnRowCommand="grvCreatePo_RowCommand">--%>
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                <asp:BoundField HeaderText="Soid" DataField="Soid" />
                                                <asp:BoundField HeaderText="ProductId" DataField="Productid" />
                                                <asp:BoundField HeaderText="LicenseNo" DataField="Licenseno" Visible="false" />
                                                <asp:BoundField HeaderText="ProductName" DataField="Productname" />
                                                <asp:BoundField HeaderText="DosageForm" DataField="Dosageform" />
                                                <asp:BoundField HeaderText="Strength" DataField="Strength" />
                                                <%--<asp:BoundField HeaderText="PackType" DataField="Packtype" />
                                                    <asp:BoundField HeaderText="PackSize" DataField="Packsize" />--%>
                                                <asp:BoundField HeaderText="Qty" DataField="SoQty" />
                                                <asp:BoundField HeaderText="PricePerPack" DataField="Priceperpack" />
                                                <asp:BoundField HeaderText="VAT%" DataField="VAT" />
                                                <asp:BoundField HeaderText="Total Amount" DataField="Totalamount" />
                                                <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                    <ItemTemplate>
                                                            <asp:LinkButton ID="btnedit" runat="server" CommandArgument='<%#Eval("Productid") %>'
                                                            CommandName="editt">
                                                            <asp:ImageButton ID="imgEdit" ImageUrl="~/Images/edit.jpg" runat="server" Width="20px" CommandArgument='<%#Eval("Productid") %>' CommandName="editt" />
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btndel" runat="server" CommandArgument='<%#Eval("Soid") %>'
                                                            CommandName="Del">
                                                            <asp:ImageButton ID="imgDel" ImageUrl="~/Images/delete.png" runat="server" Width="20px" CommandArgument='<%#Eval("Soid")+";"+Eval("Productid") %>' OnClientClick="return confirm('Are you sure to delete this Product?');"
                                                                CommandName="Del" />
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                                <div class="col-lg-12">
                                    <div class="col-md-4">
                                        <div>
                                            <label>Select Approver  </label>
                                           </div>
                                        <div>
                                            <asp:DropDownList ID="ddlSelectapprover" runat="server" CssClass="form-control">
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
                                    <div class="col-lg-4">
                                        <div class="form-group">
                                            <label>Total SO Amount</label>
                                            <asp:TextBox ID="txtTotalSOamount" CssClass="form-control" runat="server" Text="0" placeholder="0.00" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>

                                </div>


                                <br />
                                  </ContentTemplate>

                        </asp:UpdatePanel>
                                <asp:Label Text="" runat="server" ID="vat" Visible="false" />
                                <div class="row">
                                    <center>
                                        <div class="col-lg-12">

                                            <%--   <asp:Button ID="btnClear" runat="server" BorderColor="SkyBlue" class="btn default" Text="Clear" PostBackUrl="~/CreatePO.aspx" />--%>
                                            <asp:Button ID="btnSubmit" ValidationGroup="Validation" runat="server" BorderColor="SkyBlue" Text="Submit" class="btn btn-success" OnClick="btnSubmit_Click" />
                                            <asp:Button ID="btnCancel" runat="server" BorderColor="SkyBlue" class="btn btn-danger" Text="Cancel" PostBackUrl="~/SOGrid.aspx" />
                                        </div>
                                    </center>
                                </div>
                               
                            </div>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>

    <%-- <!-- BEGIN CORE PLUGINS -->
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
    </script>--%>
</body>
</html>
