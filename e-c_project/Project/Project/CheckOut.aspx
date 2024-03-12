<%@ Page Title="Check-Out" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CheckOut.aspx.cs" Inherits="Project.Purchase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="main-header">
        <%: Title%>
    </div>
    <div ID="divProductList" class="home-product-list"  runat="server">
        <table class="shopping-cart" style="width: 60%; border: 1px solid #808080;" >
            <tr>
                <th>Name</th>
                <th>Price</th>
                <th>Quantity</th>
                <th>Sub Total</th>
            </tr>

            <asp:Repeater ID="rptProductList" runat="server" >
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:HyperLink ID="HyperLink1" runat="server" ToolTip='<%# Eval("ProductName") %>'
                                NavigateUrl='<%# Eval("ProductId","~/Product.aspx?id={0}") %>'>
                                <%# Eval("ProductName") %>
                            </asp:HyperLink></td>
                        <asp:Label ID="lblProductId" runat="server" Text='<%# Eval("ProductId") %>' Visible="false" />
                        <td><%# Eval("Price","{0:#,###}") %></td>
                        <td>
                            <%--<input type="text" name="quantity" id="quantity" value='<%# Eval("Quantity")%>' />--%>
                            <asp:TextBox ID="txtQuantity" runat="server" Text='<%# Eval("Quantity")%>' ReadOnly="true" />
                        </td>
                        <td>
                            <asp:Label ID="lblSubTotal" runat="server" Text='<%# Eval("SubTotal","{0:#,###}") %>'></asp:Label>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr>
                <td colspan="3" class="total-price-text">Total:</td>
                <td class="total-price-digit">
                    <asp:Label ID="lblTotalPrices" runat="server" />
                </td>
            </tr>
        </table>
        want to add more items<a href="Default.aspx">Continue shopping</a>
        &nbsp;<br />
        <div id="divClientInfo" runat="server" style="margin-top:10px;text-align:center;">
            <table>
                <tr>
                    <td colspan="2" style="height: 21px"><b>Customer Information</b></td>
                </tr>
                <tr>
                    <td>Name:</td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" style="width:200px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtName" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td>Phone:</td>
                    <td>
                        <asp:TextBox ID="txtPhone" runat="server" style="width:200px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPhone" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td>Email:</td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" style="width:200px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator><br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please enter a valid Email Id" ControlToValidate="txtEmail" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        
                    </td>
                </tr>

                <tr>
                    <td>Address:</td>
                    <td>
                        <asp:TextBox ID="txtAddress" runat="server" style="width:200px" TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAddress" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnCheckOut" runat="server" Text="Check-Out" OnClick="btnCheckOut_Click" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                    </td>
                </tr>

            </table>
        </div>
    </div>
   <asp:Label ID="lblNoData" runat="server"></asp:Label>
</asp:Content>

