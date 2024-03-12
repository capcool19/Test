<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Project._Default" %>
<%@ Register Src="~/UserControls/LatestFiveProducts.ascx" TagPrefix="uc1" TagName="LatestFiveProducts" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="main-header">
        New Product
    </div>
    <div>
    Welcome, <asp:Label ID="lblUserName" runat="server"></asp:Label>
    </div>

    
    <div class="clear"></div>
    <div class="home-product-list">
        <uc1:LatestFiveProducts runat="server" id="LatestFiveProducts" />
    </div>
    

</asp:Content>

