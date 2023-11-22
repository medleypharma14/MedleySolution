<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SOPrint.aspx.cs" Inherits="Medly_Wm.SOPrint" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/Header.ascx" %>
<%@ Register TagPrefix="usc1" TagName="Sidebar" Src="~/Sidebar.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>SO Print</title>
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
        /*.col-lg-12 {
                padding: 10px;
            }*/
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
                                
                                <div class="portlet light " style="height: 800px">
                                    <div class="form-body">
                                        <div >
                                            <h1 style="font-family: 'Times New Roman', Times, serif; height: 50px; text-align: center">Sales Order</h1>
                                            </div>
                                           <div class="col-lg-12">
                                                    <div style="float:left;padding-top:10px">
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="logo.jpg"   />
                                                    </div>
                                                    <div style="float:right;margin-right:200px" ><b>Date:
                                                                                                 </b><asp:Label id="lblDate" runat="server"></asp:Label>
                                                    </div>
                                                </div>
                                            <div class="col-lg-12">
                                            <div style="float:left;padding-top:10px">
                                                <table>
                                                    <tr>
                                                        <td class=""><b><asp:Label ID="lblSuppName" runat="server"></asp:Label></b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                          <asp:Label ID="lblAdd1" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                              <asp:Label ID="lblAdd2" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                          <asp:Label ID="lblAdd3" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblEmail" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                                </div>
                                           
                                                <div style="float:right;margin-right:200px">
                                                    <table >
                                                        <tr>
                                                            <td><b>Medley Pharma Limited</b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Unit 2A, Olympic Way,
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                               Sefton Business Park,
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                               Bootle, Merseyside, L30 1RD
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                VAT: 203004975
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                                </div>

                                        <asp:GridView ID="grvSo"  runat="server" CssClass="table table-bordered table-striped table-condensed flip-content" AutoGenerateColumns="False" ForeColor="#333333" HorizontalAlign="Center" ShowHeaderWhenEmpty="True" CellPadding="4" GridLines="None" >

                                                  
                                                        <AlternatingRowStyle BackColor="White" />
                                                        <Columns>
                                                           
                                                            <asp:BoundField HeaderText="Productname" DataField="Productname" />
                                                            <%--<asp:BoundField HeaderText="Pack size" DataField="Packsize" />--%>
                                                            <asp:BoundField HeaderText="Quantity" DataField="SoQty" />
                                                            <asp:BoundField HeaderText="Price" DataField="Priceperpack" />
                                                            <asp:BoundField HeaderText="Amount" DataField="Totalamount" />
                                                          
                                       

                                                        </Columns>
                                                        <%--<EditRowStyle BackColor="#2461BF" />
                                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                        <RowStyle BackColor="#EFF3FB" />
                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                                        <SortedDescendingHeaderStyle BackColor="#4870BE" />--%>
                                                    </asp:GridView>                                       
                                            <table style="margin-left: 550px;">
                                                <tr>
                                                    <td>TotalGBP
                                                    </td>

                                                    <td>
                                                        <asp:PlaceHolder ID="PlaceHolder9" runat="server">xxxx</asp:PlaceHolder>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>VAT
                                                    </td>
                                                    <td>
                                                        <asp:label ID="lblVAT" runat="server">xxxx</asp:label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Delivery Charges
                                                    </td>
                                                    <td>
                                                        <asp:PlaceHolder ID="PlaceHolder11" runat="server">xxxx</asp:PlaceHolder>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Total NOs
                                                    </td>
                                                    <td>
                                                        <asp:PlaceHolder ID="PlaceHolder12" runat="server">xxxx</asp:PlaceHolder>
                                                    </td>
                                                </tr>
                                            </table>


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