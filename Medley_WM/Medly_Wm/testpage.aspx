<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testpage.aspx.cs" Inherits="Medly_Wm.testpage" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="col-lg-4">
            <label>
                Number Of Floors 
            </label>
            <div class="form-group">
            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="ddlNumberoffloors" ForeColor="Red"></asp:RequiredFieldValidator>--%>
            <div class="input-group">
                <span class="input-group-addon input-circle-left">
                    <i class="fa fa-user"></i>
                </span>
                <%--   <asp:TextBox ID="txtNooffloors" runat="server" CssClass="form-control" placeholder="Enter Floor Number" />--%>

                <asp:DropDownList ID="ddlNumberoffloors" runat="server" CssClass="form-control" Width="150px">
                    <asp:ListItem Value="">Select</asp:ListItem>
                    <asp:ListItem Text="1" />
                    <asp:ListItem Text="2" />
                    <asp:ListItem Text="3" />
                    <asp:ListItem Text="4" />
                </asp:DropDownList>
                
            </div>
                
                </div>
            <asp:Button ID="Submit" CssClass="btn btn-green" Text="Check" runat="server" OnClick="Submit_Click" />
        </div>
        <div>
            Floor No:
            <asp:Label ID="lblFloor" runat="server"></asp:Label><br />
            Unitname:
            <asp:Label ID="lblUnit" runat="server"></asp:Label><br />

            <div class="panel-body" align="left">
                <asp:DataList ID="ddUnits1" runat="server" RepeatLayout="Table" RepeatDirection="Horizontal" RepeatColumns="20"
                    OnItemDataBound="ddRoomListSecond_ItemDataBound">
                    <ItemTemplate>
                        <asp:Button CssClass="btn btn-success" ID="btns1" runat="server" ForeColor="White" OnClick="btnClick"
                            Text='<%#  Eval("Unitname")%>' CommandArgument='<%# Eval("UnitId") %>'
                            CommandName='<%# Eval("Floor") %>' Style="font-size: small; word-wrap: break-word; float: left; white-space: normal; -webkit-transition-duration: 0.4s; transition-duration: 0.4s;" />
                    </ItemTemplate>
                </asp:DataList>
                <asp:DataList ID="ddUnits2" runat="server"
                    RepeatLayout="Table" RepeatDirection="Horizontal" RepeatColumns="20"
                    OnItemDataBound="ddRoomListSecond_ItemDataBound">
                    <ItemTemplate>
                        <asp:Button CssClass="btn btn-success" ID="btns1" runat="server" ForeColor="White" OnClick="btnClick"
                            Text='<%#  Eval("Unitname")%>' CommandArgument='<%# Eval("UnitId") %>'
                            CommandName='<%# Eval("Floor") %>' Style="font-size: small; word-wrap: break-word; float: left; white-space: normal; -webkit-transition-duration: 0.4s; transition-duration: 0.4s;" />
                    </ItemTemplate>
                </asp:DataList>
                <asp:DataList ID="ddUnits3" runat="server"
                    RepeatLayout="Table" RepeatDirection="Horizontal" RepeatColumns="20"
                    OnItemDataBound="ddRoomListSecond_ItemDataBound">
                    <ItemTemplate>
                        <asp:Button CssClass="btn btn-success" ID="btns1" runat="server" ForeColor="White" OnClick="btnClick"
                            Text='<%#  Eval("Unitname")%>' CommandArgument='<%# Eval("UnitId") %>'
                            CommandName='<%# Eval("Floor") %>' Style="font-size: small; word-wrap: break-word; float: left; white-space: normal; -webkit-transition-duration: 0.4s; transition-duration: 0.4s;" />
                    </ItemTemplate>
                </asp:DataList>
                <asp:DataList ID="ddUnits4" runat="server" RepeatLayout="Table" RepeatDirection="Horizontal" RepeatColumns="20"
                    OnItemDataBound="ddRoomListSecond_ItemDataBound">
                    <ItemTemplate>
                        <asp:Button CssClass="btn btn-success" ID="btns1" runat="server" ForeColor="White" OnClick="btnClick"
                            Text='<%#  Eval("Unitname")%>' CommandArgument='<%# Eval("UnitId") %>'
                            CommandName='<%# Eval("Floor") %>' Style="font-size: small; word-wrap: break-word; float: left; white-space: normal; -webkit-transition-duration: 0.4s; transition-duration: 0.4s;" />
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
    </form>1
</body>
</html>





<body>
<form id="form2" runat="server">
<div>
                        <asp:GridView ID="gvParentGrid" runat="server" DataKeyNames="CountryId" Width="300"
                        AutoGenerateColumns="false" OnRowDataBound="gvUserInfo_RowDataBound" GridLines="None" BorderStyle="Solid" BorderWidth="1px"  BorderColor="#df5015">
                        <HeaderStyle BackColor="#df5015" Font-Bold="true" ForeColor="White" />
                        <RowStyle BackColor="#E1E1E1" />
                        <AlternatingRowStyle BackColor="White" />
                        <HeaderStyle BackColor="#df5015" Font-Bold="true" ForeColor="White" />
                        <Columns>
                        <asp:TemplateField ItemStyle-Width="20px">
                        <ItemTemplate>
                        <a href="JavaScript:divexpandcollapse('div<%# Eval("CountryID") %>');">
                        <img id="imgdiv<%# Eval("CountryID") %>" width="9px" border="0" src="plus.gif" />
                        </a>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="CountryId" HeaderText="CountryId" HeaderStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="CountryName" HeaderText="CountryName" HeaderStyle-HorizontalAlign="Left" />
                        <asp:TemplateField>
                        <ItemTemplate>
                        <tr>
                        <td colspan="100%">
                        <div id="div<%# Eval("CountryID") %>" style="display: none; position: relative; left: 15px; overflow: auto">
                        <asp:GridView ID="gvChildGrid" runat="server" AutoGenerateColumns="false" BorderStyle="Double"  BorderColor="#df5015" GridLines="None" Width="250px">
                        <HeaderStyle BackColor="#df5015" Font-Bold="true" ForeColor="White" />
                        <RowStyle BackColor="#E1E1E1" />
                        <AlternatingRowStyle BackColor="White" />
                        <HeaderStyle BackColor="#df5015" Font-Bold="true" ForeColor="White" />
                        <Columns>
                        <asp:BoundField DataField="StateID" HeaderText="StateID" HeaderStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="StateName" HeaderText="StateName" HeaderStyle-HorizontalAlign="Left" />
                        </Columns>
                        </asp:GridView>
                        </div>
                        </td>
                        </tr>
                        </ItemTemplate>
                        </asp:TemplateField>
                        </Columns>
                        </asp:GridView>
                        </div>



       <div class="col-lg-12" style="border-inline:medium" id="divContact4" runat="server">
                                         
                                        <div class="col-lg-12">
                                              <div class="col-lg-3">
                                                     <div class="form-group">
                                                        <label>Contact Name - 3</label>
                                                        <div class="input-group">
                                                            <span class="input-group-addon input-circle-left">
                                                                <i class="fa fa-user"></i>
                                                            </span>

                                                            <asp:TextBox ID="txtCName3" runat="server" CssClass="form-control" placeholder="Enter Name"></asp:TextBox>
                                                           
                                                        </div>
                                                    </div>
                                            </div>
                                            <div class="col-lg-3"> <div class="form-group">
                                                        <label>Contact Email</label>
                                                        <div class="input-group">
                                                            <span class="input-group-addon input-circle-left">
                                                                <i class="fa fa-envelope"></i>
                                                            </span>
                                                          
                                                            <asp:TextBox ID="txtCEmail3" runat="server" CssClass="form-control" placeholder="user@email.com"></asp:TextBox>
                                                        </div>
                                                    </div></div>
                                              <div class="col-lg-2">
                                                  <div class="form-group">
                                                        <label>Contact Number</label>
                                                        <div class="input-group">
                                                            <span class="input-group-addon input-circle-left">
                                                                <i class="fa fa-globe"></i>
                                                            </span>
                                                       
                                                            <asp:DropDownList ID="ddlCCode3" runat="server" CssClass="form-control" placeholder="Country">
                                                                <asp:ListItem Text="Code"></asp:ListItem>
                                                                <asp:ListItem Text="+1"></asp:ListItem>
                                                                <asp:ListItem Text="+44"></asp:ListItem>
                                                                <asp:ListItem Text="+91"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                  </div>
                                              <div class="col-lg-3">

                                                  <label></label>
                                                    <div class="input-group">
                                                        <span class="input-group-addon input-circle-left">
                                                            <i class="fa fa-globe"></i>
                                                        </span>
                                                        <asp:TextBox ID="txtCNumber3" runat="server" CssClass="form-control" placeholder="Enter Number" />
                                                    </div>
                                              </div>
                                           
                                            </div>
                                        <div class="col-lg-12">
                                                  <div class="col-lg-6">
                                                        <div class="form-group">
                                                            <label>Address Line</label>
                                                            <div class="input-group">
                                                                <span class="input-group-addon input-circle-left">
                                                                    <i class="fa fa-address-card"></i>
                                                                </span>
                                                              
                                                                <asp:TextBox ID="txtCAddress3" runat="server" TextMode="MultiLine" CssClass="form-control" AutoPostBack="false" Placeholder="Address"></asp:TextBox>
                                                            
                                                            </div>
                                                        </div>
                                                    </div>
                                            <div class="col-lg-2">
                                                        <div class="form-group">
                                                        <label>Country</label>
                                                        <div class="input-group">
                                                            <span class="input-group-addon input-circle-left">
                                                                <i class="fa fa-globe"></i>
                                                            </span>
                                                     
                                                            <asp:DropDownList ID="ddlCCountry3" runat="server" CssClass="form-control" placeholder="Select">
                                                         
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>

                                            </div>
                                            <div class="col-lg-3">     <label>Post Code</label>
                                                    <div class="input-group">
                                                        <span class="input-group-addon input-circle-left">
                                                            <i class="fa fa-map"></i>
                                                        </span>
                                                 
                                                        <asp:TextBox ID="txtCPost3" runat="server" CssClass="form-control" placeholder="Enter Number"></asp:TextBox>
                                                    </div>
                              
                                            </div>
                                              <div class="col-lg-1"  >
                                                        <div class="form-group">
                                                            <label></label>
                                                            <div class="input-group">
                                                             
                                                           
                                                                 <asp:ImageButton ImageUrl="Images/plusbtn1.png" ID="ImageButton4" runat="server"  OnClick="addname_Click"  Height="30px" Width="30px" />
                                                           
                                                            </div>
                                                        </div>
                                                    </div>

                                            </div>
                                          </div>

                        </form>
                        </body>