<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Menu_Left.ascx.cs" Inherits="Project.UserControls.Menu_Left" %>
<div class="div-left">
    <div class="left-title">
        Category
    </div>
    <div class="left-menu">
        <ul>
            <asp:Repeater ID="rptCategoryMenu" runat="server">
                <ItemTemplate>
                    <li>
                        <asp:HyperLink ID="HyperLink1" runat="server" ToolTip='<%#Eval("Name") %>' NavigateUrl='<%# Eval("CategoryId","~/ProductsList.aspx?cat={0}")%>'>
                                            <%#DataBinder.Eval(Container.DataItem,"Name") %>
                        </asp:HyperLink>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
    
</div>
