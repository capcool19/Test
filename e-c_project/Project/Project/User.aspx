<%@ Page Title="User" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="Project.User" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="main-header">
        <%: Title %>
    </div>
    <div class="top-button">
        <asp:Button ID="btnAddNew" runat="server" Text="Add New" OnClick="btnAddNew_Click" />
    </div>
    <div class="main-data" id="divGridview" runat="server">
        <asp:GridView ID="grvListData" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="False" Width="281px" OnRowCommand="grvListData_RowCommand">
            <Columns>
                <asp:TemplateField HeaderText="No.">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:HyperLinkField DataNavigateUrlFields="UserId" DataTextField="Username" HeaderText="Username" DataNavigateUrlFormatString="~/User.aspx?id={0}" NavigateUrl="~/User.aspx" />
                <asp:TemplateField HeaderText="Edit">
                    <ItemTemplate>
                        <asp:ImageButton ID="btnEdit" runat="server" CommandArgument='<%# Eval("UserId") %>' CommandName="_edit" Height="24px" ImageUrl="~/images/Edit.png" Width="24px" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Dlelete">
                    <ItemTemplate>
                        <asp:ImageButton ID="btnDelete" runat="server" CommandArgument='<%# Eval("UserId") %>' CommandName="_delete" Height="24px" ImageUrl="~/images/Delete.png" Width="24px" OnClientClick="return confirm('Are you sure you wnat to delete ?');" />
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
    <div id="divAdd_Edit" runat="server">
        <table style="width: 60%; border: 1px solid #808080">
            <tr>
                <td colspan="2" style="height: 16px" class="text-center"><strong>Add/Edit Form</strong></td>
            </tr>
            <tr>
                <td>Username: </td>
                <td>
                    <asp:TextBox ID="txtUsername" runat="server" Width="177px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Password: </td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" Width="177px" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" />
                    <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Style="margin-bottom: 0" Text="Cancel" />
                </td>
            </tr>
        </table>
    </div>
    <div id="divContentDetail" runat="server">
        <table style="width: 60%; border-collapse: collapse; border-style: solid; border-width: 1px">
            <tr>
                <td colspan="2" style="height: 16px" class="text-center"><strong>View Content Detail</strong></td>
            </tr>
            </tr>
            <tr>
                <td style="width: 147px">Username:</td>
                <td>
                    <asp:Label ID="lblUsername" runat="server"></asp:Label>
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