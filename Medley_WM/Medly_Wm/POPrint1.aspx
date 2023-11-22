<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="POPrint1.aspx.cs" Inherits="Medly_Wm.POPrint1" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/Header.ascx" %>
<%@ Register TagPrefix="usc1" TagName="Sidebar" Src="~/Sidebar.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Po Print1</title>
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
        
    </style>

</head>
<body class="page-header-fixed page-sidebar-closed-hide-logo page-container-bg-solid page-md">
    <usc1:Sidebar ID="h1" runat="server" />
    <div class="page-container">
        <usc:Header ID="Header" runat="server" />
        <div class="page-content-wrapper">
            <!-- BEGIN CONTENT BODY -->
            <div class="page-content">
                <form id="form2" runat="server">
                    <div class="row">
                        <div class="col-md-12 ">
                            <div class="portlet light ">

                                <div class="portlet light ">
                                    <div class="form-body" style="width:90%">
                                        <div>
                                            <h1 style="font-family: 'Times New Roman', Times, serif; height: 50px; text-align: center">Purchase Order</h1>
                                        </div>
                                        <div class="col-lg-12">
                                            <div style="float: left; padding-top: 10px">
                                                <asp:Image ID="Image1" runat="server" ImageUrl="logo.jpg" />
                                                <h3><b>
                                                    <asp:Label Text="Medley Pharma LTD" runat="server" ForeColor="#33ccff" /></b></h3>
                                            </div>
                                            <%-- <div style="float:right;margin-right:200px" ><b>Date:
                                                         </b><asp:Label id="lblDate" runat="server"></asp:Label>
                                                    </div>--%>
                                            <br />
                                            <div style="float: right; margin-left:90px;">
                                                <h4>
                                                    <b>Po No:  </b>
                                                    <asp:Label ID="lblponumber" runat="server"></asp:Label>
                                                </h4>
                                            </div>
                                        </div>
                                        <div class="">
                                            <div style="float: left; padding-top: 10px">
                                                <table>
                                                    <tr>
                                                        <td class=""><b>
                                                            <asp:Label ID="lblSuppName" runat="server"></asp:Label></b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblAdd1" runat="server" Visible="false"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <div style="width: 120px">
                                                                <asp:Label Text="Medley House D2, MIDC Area Andheri (East) Mumbai 400 093 India"
                                                                    runat="server"></asp:Label>
                                                            </div>

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblAdd3" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblEmail" runat="server" Visible="false"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>

                                            <div style="float: right;margin-left:90px; margin-top: 10px">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <h4><b>Date:</b>
                                                                <asp:Label ID="lblDate" runat="server"></asp:Label></h4>
                                                        </td>
                                                    </tr>
                                                </table>

                                            </div>

                                        </div>
                                         <div class="col-lg-12">
                                                        <asp:GridView ID="grvPo" runat="server" Width="100%" CssClass="table table-bordered table-striped table-condensed flip-content" AutoGenerateColumns="False" ForeColor="#333333" HorizontalAlign="Center" ShowHeaderWhenEmpty="True" CellPadding="4" GridLines="None">
                                                            <AlternatingRowStyle BackColor="White" />
                                                            <Columns>
                                                                <asp:BoundField HeaderText="Productname"  DataField="Productname" />
                                                                <asp:BoundField HeaderText="Pack" DataField="" Visible="false" />
                                                                <asp:BoundField HeaderText="Quantity" DataField="PoQty" />
                                                                <asp:BoundField HeaderText="Price" DataField="Priceperpack" />
                                                               <%-- <asp:BoundField HeaderText="VAT" DataField="VAT" />--%>
                                                                <asp:BoundField HeaderText="Amount" DataField="Productamt" />
                                                            </Columns>
                                                        </asp:GridView>
                                             </div>
                                             <div>
                                                    <table>
                                                <tr>
                                                    <td align="left" style="padding-left: 100px" runat="server" visible="false"><b>250 Days from BOL</b>
                                                    </td>
                                                    <td align="left" style="padding-left: 500px">
                                                        <b>Total Qty:
                                                        <asp:Label ID="txttotalqty" runat="server" /></b>
                                                    </td>
                                                    <td style="float:right;padding-right:70px;margin-left:100px">
                                                       <b> Total Amount:
                                                        <asp:Label ID="lbltotal" runat="server" /></b>
                                                    </td>
                                                </tr>
                                           
                                                <tr>
                                                    <td style="padding: 5px; margin-left: 20px">
                                                        <b>Delivery Terms:
                                                    <asp:Label ID="lbldelveryterm" runat="server" /></b>
                                                    </td>
                                                    <td style="margin-right: 80px; padding: 7px">
                                                        <b>ASAP</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <b>Company Registration :</b> 09196622
                                                        <asp:Label ID="lblCR" runat="server" />
                                                    </td>
                                                    <td style="float: right; padding: 7px">
                                                        <b>VAT :</b> 203 0049 75
                                                        <asp:Label ID="lblVAT" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr style="margin-top:10px">
                                                    <td>
                                                        <b>Registered Office:</b> Unit 2A, Olympic Way,Sefton Business Park,Aintree, Liverpool, L30 1RD
                                                    </td>
                                                </tr>
                                                <tr style="padding-top: 5px">
                                                    <td style="padding-top: 5px">
                                                        <b>Tel:</b>
                                                        <asp:Label ID="lbltelNo" Text="00 44 151 521 4527" runat="server" />
                                                    </td>
                                                    <td></td>
                                                </tr>
                                            </table>
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
