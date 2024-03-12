<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductList.ascx.cs" Inherits="Project.UserControls.ProductList" %>
<asp:Repeater ID="rptProductList" runat="server">
    <ItemTemplate>
        <div class="home-product-list">
    <div class="product-content">
        <div class="product-image">
            <asp:HyperLink ID="HyperLink1" runat="server" ToolTip='<%# Eval("ProductName") %>' NavigateUrl='<%# Eval("ProductId","~/Product.aspx?id={0}") %>'>
                <img src="<%# ResolveUrl(Convert.ToString(Eval("Image"))) %>" alt='<%#Eval("ProductName") %>'/>
            </asp:HyperLink>
        </div>
        <div class="product-title">
            <asp:HyperLink ID="HyperLink2" runat="server" ToolTip='<%# Eval("ProductName") %>'
                NavigateUrl='<%# Eval("ProductId","~/Product.aspx?id={0}") %>'>
                <%# Eval("ProductName") %>
            </asp:HyperLink>
        </div>
        <div class="product-price">
            Price:&#8377 <%# Eval("Price","{0:#,###}") %>
        </div>
        <div class="product-add-to-cart">
            <asp:HyperLink ID="hplAddToCart" runat="server"  NavigateUrl='<%# Eval("ProductId","~/ShoppingCart.aspx?proId={0}") %>'>
               Add to Cart
            </asp:HyperLink>
        </div>
    </div>
    <!--product-content-->
    </ItemTemplate>
</asp:Repeater>
<asp:Label ID="lblNoData" runat="server"></asp:Label>

