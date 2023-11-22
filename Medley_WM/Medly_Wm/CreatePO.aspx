<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreatePO.aspx.cs" Inherits="Medly_Wm.CreatePO" EnableEventValidation="true" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/Header.ascx" %>
<%@ Register TagPrefix="usc1" TagName="Sidebar" Src="~/Sidebar.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Create Po</title>
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
            /*background-color:#507CD1;
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

                    <!-- BEGIN SAMPLE FORM PORTLET-->
                    <div class="portlet light ">
                          <asp:UpdatePanel ID="updatepanel" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                            <ContentTemplate>
                        <div class="portlet-title">
                            <div class="caption font-red-sunglo">
                                <i class="icon-settings font-red-sunglo"></i>
                                <span class="caption-subject bold uppercase">Create PO</span>
                            </div>
                            <div class="actions">
                                <div class="btn-group">
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="portlet light">
                                <div class="row">

                                    <div class="col-lg-12">

                                        <div class="col-lg-4">
                                            <label>Company Name</label>
                                            <asp:DropDownList ID="ddlSuppliername" runat="server" CssClass="form-control">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-lg-4">
                                            <label>PO Date</label>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPodate" ErrorMessage="Select Po Date" ForeColor="Red">Select PO Date</asp:RequiredFieldValidator>
                                            <asp:TextBox ID="txtPodate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-2" style="float: right">
                                            <div class="form-group">
                                                <label>PO Number</label>
                                                <asp:TextBox ID="txtPonumber" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                            </div>

                                        </div>

                                    </div>

                                    <div class="col-lg-12" id="tble" runat="server" visible="true">
                                        <div class="col-lg-12">
                                            <div class="form-group">
                                                <table>
                                                    <tr>
                                                        <th>Product</th>
                                                        <th>Product Name</th>
                                                        <th>Dosage Form</th>
                                                        <th>Strength</th>
                                                        <th>Po Qty</th>
                                                        <th>Price Per Pack</th>
                                                        <th>VAT</th>
                                                        <th>Total Amount</th>
                                                    </tr>
                                                    <tr>

                                                        <td>
                                                            <asp:DropDownList ID="ddlProductname" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlProductname_SelectedIndexChanged">
                                                            </asp:DropDownList></td>
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
                                                        <asp:TextBox ID="txtPacktype" runat="server" placeholder="Packtype" CssClass="form-control" Visible="false"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPacksize" runat="server" placeholder="Packsize" CssClass="form-control" Visible="false"></asp:TextBox>
                                                    </td>--%>
                                                        <td>
                                                            <asp:TextBox ID="txtPoqty" runat="server" placeholder="PoQty" AutoPostBack="true" CssClass="form-control" OnTextChanged="txtPoqty_TextChanged" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <ajaxToolkit:Filtertext></ajaxToolkit:Filtertext>
                                                            <asp:TextBox ID="txtPriceperpack" runat="server" placeholder="Priceperpack" AutoPostBack="true" CssClass="form-control" OnTextChanged="txtPoqty_TextChanged" onkeypress="return isNumberKey(event)">0</asp:TextBox>
                                                        </td>
                                                          <td>
                                                            <asp:TextBox ID="txtVAT" runat="server" placeholder="VAT" AutoPostBack="true" CssClass="form-control" OnTextChanged="txtVAT_TextChanged" onkeypress="return isNumberKey(event)">0</asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtproductamt" runat="server" Text="0" placeholder="Productamt" CssClass="form-control" Enabled="false"></asp:TextBox>
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
                                    <asp:label ID="vat" runat="server" visible="false"></asp:label>
                                    <br />
                                    
                                    <div class="col-lg-12">
                                        <div class="col-lg-12" id="Div1" runat="server" style="overflow: auto;">
                                            <asp:GridView ID="grvCreatePo" EmptyDataText=""   OnRowCommand="grvCreatePo_RowCommand" OnRowDataBound="grvCreatePo_RowDataBound" runat="server" CssClass="table table-striped  flip-content" AutoGenerateColumns="False" ForeColor="#333333" HorizontalAlign="Center" ShowHeaderWhenEmpty="True" CellPadding="4" GridLines="None">

                                                <%--<asp:GridView ID="grvCreatePo" runat="server" CssClass="table table-striped  flip-content" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="false" OnRowCommand="grvCreatePo_RowCommand">--%>
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
<%--                                                    <asp:EmptyDataTemplate >
                                                        <div class="alert alert-info">
                                                            No data available.
                                                        </div>
                                                    </asp:EmptyDataTemplate>--%>
                                                    <asp:TemplateField HeaderText="So ID" Visible="false">
                                                        <ItemTemplate>
                                                            <%#Eval("Poid") %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="S.No" DataField="Poid" Visible="false"/>
                                                    <asp:BoundField HeaderText="ProductId" DataField="Productid" />

                                                    <%--<asp:BoundField HeaderText="LicenseNo" DataField="Licenseno" />--%>
                                                    <asp:BoundField HeaderText="ProductName" DataField="Productname" />
                                                    <asp:BoundField HeaderText="DosageForm" DataField="Dosageform" />
                                                    <asp:BoundField HeaderText="Strength" DataField="Strength" />
                                                    <%--<asp:BoundField HeaderText="PackType" DataField="Packtype" />
                                                            <asp:BoundField HeaderText="PackSize" DataField="Packsize" />--%>
                                                    <asp:BoundField HeaderText="PoQty" DataField="PoQty" />
                                                    <asp:BoundField HeaderText="PricePerPack" DataField="Priceperpack" />
                                                    <asp:BoundField HeaderText="VAT" DataField="VAT" />
                                                    <asp:BoundField HeaderText="Productamt" DataField="Productamt" />
                                                    <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnedit" runat="server" CommandArgument='<%#Eval("Productid") %>'
                                                                CommandName="editt">
                                                                <asp:ImageButton ID="imgEdit" ImageUrl="~/Images/edit.jpg" runat="server" Width="20px" CommandArgument='<%#Eval("Productid") %>' CommandName="editt" />
                                                            </asp:LinkButton>
                                                            <asp:HiddenField runat="server" ID="hiden" Value='<%#Eval("Productid") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btndel" runat="server" CommandArgument='<%#Eval("Poid") %>'
                                                                CommandName="Del">
                                                                
                                                                <asp:ImageButton ID="imgDel" ImageUrl="~/Images/delete.png" runat="server" Width="20px"
                                                                    CommandArgument='<%#Eval("Poid")+";"+Eval("Productid") %>' OnClientClick="return confirm('Are you sure to delete this Product?');"
                                                                    CommandName="Del" />
                                                            </asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                </Columns>
                                            </asp:GridView>
                                        </div>

                                    </div>
                                    <div class="update" runat="server">
                                        <div id="updategv" runat="server" style="overflow: auto;" visible="false">
                                            <%--<asp:GridView ID="updategrid" runat="server" CssClass="table table-striped  flip-content" OnRowDataBound="updategrid_RowDataBound" OnRowCommand="grvCreatePo_RowCommand" AutoGenerateColumns="False" ForeColor="#333333" HorizontalAlign="Center"  ShowHeaderWhenEmpty="True" CellPadding="4" GridLines="None" >
                                                        <AlternatingRowStyle BackColor="White" />
                                                        <Columns>
                                                             <asp:BoundField HeaderText="TransID" DataField="Transpo" Visible="false" />
                                                             <asp:BoundField HeaderText="PoID" DataField="Poid"  />
                                                           <asp:BoundField HeaderText="ProductId" DataField="Productid" Visible="false" />
                                                            <asp:BoundField HeaderText="ProductName" DataField="Productname" />
                                                            <asp:BoundField HeaderText="DosageForm" DataField="Dosageform" />   
                                                            <asp:BoundField HeaderText="Strength" DataField="Strength" />
                                                            <asp:BoundField HeaderText="PoQty" DataField="PoQty"  Visible="false"/>
                                                             <asp:BoundField HeaderText="PricePerPack" DataField="Priceperpack" Visible="false"/>
                                                            <asp:BoundField HeaderText="Productamt" DataField="Productamt" Visible="false"/>
                                                       <asp:TemplateField HeaderText="PO Qty" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px" Visible="true">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtPoqty1" runat="server" Text='<%#Eval("PoQty") %>' OnTextChanged="txtPoqty1_TextChanged" AutoPostBack="true"   CssClass="form-control"/>
                                                                </ItemTemplate>
                                                            </asp:TemplateField> 
                                                            <asp:TemplateField HeaderText="Price Per Pack" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px" Visible="true">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtPriceperpack1" runat="server" Text='<%#Eval("Priceperpack") %>' OnTextChanged="txtPriceperpack1_TextChanged" AutoPostBack="true"   CssClass="form-control"/>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Product Amount" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px" Visible="true">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtproductamt" runat="server" Text='<%#Eval("Productamt") %>' Width="100px"  CssClass="form-control"/>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="btnedit" runat="server" CommandArgument='<%#Eval("TransPo") %>'
                                                                        CommandName="editt">
                                                                        <asp:ImageButton ID="imgEdit" ImageUrl="~/Images/edit.jpg" runat="server" Width="20px" CommandArgument='<%#Eval("TransPo") %>' CommandName="editt" />
                                                                    </asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>

                                                    </asp:GridView>--%>
                                        </div>
                                    </div>

                                    <%--<div class="col-lg-2  col-xs-12" style="margin-top: 50px">
                                                <asp:Button ID="btnAddrow" runat="server" CssClass="form-control" Text="AddRow" />
                                            </div>--%>
                                    <div class="col-lg-12">
                                        <div class="col-md-4">
                                            <label>
                                                Select Approver
                                                  <%--  <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator8" ControlToValidate="ddlselectapprover"
                                                        ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Contact Number" Style="color: Red" />--%>
                                            </label>
                                            <div>
                                                <asp:DropDownList ID="ddlSelectapprover" runat="server" CssClass="form-control">
                                                    <%--   <asp:ListItem Value="">Select</asp:ListItem>
                                                            <asp:ListItem Text="Manager"></asp:ListItem>
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
                                        <div class="col-lg-4">
                                            <div class="form-group">
                                                <label>Total PO Amount</label>
                                                <asp:TextBox ID="txtTotalpoamount" CssClass="form-control" runat="server" Text="0" placeholder="0.00" Enabled="false"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <br />
                                     </ContentTemplate>
                        </asp:UpdatePanel>
                                    <div class="row">
                                        <center>
                                            <div class="col-lg-12">

                                                <%--   <asp:Button ID="btnClear" runat="server" BorderColor="SkyBlue" class="btn default" Text="Clear" PostBackUrl="~/CreatePO.aspx" />--%>
                                                <asp:Button ID="btnSubmit" runat="server" BorderColor="SkyBlue" class="btn btn-success" Text="Submit" ValidationGroup="Validation" OnClick="btnSubmit_Click" />
                                                <asp:Button ID="btnCancel" runat="server" BorderColor="SkyBlue" class="btn btn-danger" Text="Cancel" PostBackUrl="~/POGrid.aspx" />
                                            </div>
                                        </center>
                                    </div>
                        <asp:Label runat="server" ID="prodel" Visible="false"></asp:Label>
                               
                            
                    </div>
                        </div>

                </form>
            </div>
        </div>
    </div>


</body>
</html>

