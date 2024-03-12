<%@ Page Title="Shopping Cart" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="Project.ShoppingCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="main-header">
        <%: Title%>
    </div>
    <div class="home-product-list" id="divProductList" runat="server">
        <table class="shopping-cart" style="width: 60%; border: 1px solid #808080;">
            <tr>
                <th>Name</th>
                <th>Price</th>
                <th>Quantity</th>
                <th>Sub Total</th>
            </tr>

            <asp:Repeater ID="rptProductList" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:HyperLink ID="HyperLink1" runat="server" ToolTip='<%# Eval("ProductName") %>'
                                NavigateUrl='<%# Eval("ProductId","~/Product.aspx?id={0}") %>'>
                                <%# Eval("ProductName") %>
                            </asp:HyperLink></td>
                        <asp:Label ID="lblProductId" runat="server" Text='<%# Eval("ProductId") %>' Visible="false"/>
                        <td><%# Eval("Price","{0:#,###}") %></td>
                        <td>
                            <%--<input type="text" name="quantity" id="quantity" value='<%# Eval("Quantity")%>' />--%>
                            <asp:TextBox ID="txtQuantity" runat="server" Text='<%# Eval("Quantity")%>' />
                        </td>
                        <td>
                            <asp:Label ID="lblSubTotal" runat="server" Text='<%# Eval("SubTotal","{0:#,###}") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:LinkButton ID="lnkDelete" runat="server" OnClick="lnkDelete_Click" OnClientClick="return confirm('Do you want to delete this?');">Delete</asp:LinkButton>
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
        </table><br />
        want to add more items<a href="Default.aspx">Continue shopping</a>
        &nbsp;<br />&nbsp;<br />
        <div >
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/CheckOut" style="text-align: left;padding: 10px;font-weight: bold;background-color: black;color: white;text-transform: uppercase; text-decoration:none">Check-Out</asp:HyperLink>
        </div>
        <asp:Label ID="lblNoData" runat="server" ForeColor="Red" Text="lblNoData" Visible="False"></asp:Label>
    </div>
</asp:Content>
