<%@ Page Title="Manage Orders" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageOrders.aspx.cs" Inherits="Project.ManageOrders" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="main-header">
        <%: Title %>
    </div>
    <div class="top-button">
    </div>
    <div class="main-data" id="divGridview" runat="server">
        <asp:GridView ID="grvListData" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="False" Width="281px" OnRowCommand="grvListData_RowCommand">
            <Columns>
                <asp:TemplateField HeaderText="No.">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:HyperLinkField DataNavigateUrlFields="OrderId" DataTextField="CustomerName" HeaderText="Cus.Name" DataNavigateUrlFormatString="~/ManageOrders.aspx?id={0}" NavigateUrl="~/ManageOrders.aspx" />
                <asp:BoundField DataField="CustomerPhone" HeaderText="Cus.Phone" />
                <asp:BoundField DataField="CustomerEmail" HeaderText="Cus.Email" />
                <asp:BoundField DataField="CustomerAddress" HeaderText="Cus.Address" />
                <asp:BoundField DataField="OrderDate" HeaderText="OrderDate" DataFormatString="{0: MM/dd/yyyy}" />
                <asp:TemplateField HeaderText="Dlelete">
                    <ItemTemplate>
                        <asp:ImageButton ID="btnDelete" runat="server" CommandArgument='<%# Eval("OrderId") %>' CommandName="_delete" Height="24px" ImageUrl="~/images/Delete.png" Width="24px" OnClientClick="return confirm('Are you sure you wnat to delete ?');" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
    </div>
    <br />
    <div id="divContentDetail" runat="server">
        <table style="width: 60%; border-collapse: collapse; border-style: solid; border-width: 1px">
            <tr>
                <td colspan="2" style="height: 16px" class="text-center"><strong>View C Detail</strong></td>
            </tr>
            </tr>
            <tr>
                <td style="width: 147px">OrderId:</td>
                <td>
                    <asp:Label ID="lblOrderId" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 147px">Customer Name:</td>
                <td>
                    <asp:Label ID="lblCustomerName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 147px; height: 21px;">Customer Phone:</td>
                <td style="height: 21px">
                    <asp:Label ID="lblCustomerPhone" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 147px">Customer Email:</td>
                <td>
                    <asp:Label ID="lblCustomerEmail" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 147px; height: 21px;">Customer Address:</td>
                <td style="height: 21px">
                    <asp:Label ID="lblCustomerAddress" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 147px; height: 21px;">Order Date:</td>
                <td style="height: 21px">
                    <asp:Label ID="lblOrderDate" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 147px">&nbsp;</td>
                <td>
                    <asp:Button ID="btnGoBack" runat="server" Text="Go Back" OnClick="btnGoBack_Click" />

                </td>
            </tr>
        </table>
    </div>
    <asp:HiddenField ID="hiddenfile_value" runat="server" />
    <asp:Label ID="lblDisplay" runat="server" Text="Label" ForeColor="Red" Visible="False"></asp:Label>
</asp:Content>