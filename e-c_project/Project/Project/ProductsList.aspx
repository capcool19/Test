<%@ Page Title="Product Listing" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductsList.aspx.cs" Inherits="Project.ProductsList" %>
<%@ Register Src="~/UserControls/ProductList.ascx" TagPrefix="uc1" TagName="ProductList" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="main-header">
        <%: Title%>
    </div>
    <div class="home-product-list">
        <uc1:ProductList runat="server" id="ProductList" />
    </div>
</asp:Content>

