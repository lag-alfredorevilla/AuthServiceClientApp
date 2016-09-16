<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AuthServiceClientApp.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:PlaceHolder runat="server" Visible="<%# this.User.Identity.IsAuthenticated %>">
                <%# this.Context.User.Identity.Name %>"
            </asp:PlaceHolder>

            <asp:Repeater runat="server" ItemType="AuthServiceClientApp.Models.AuthProviderConfig" ID="authProvidersRepeater1" OnItemCommand="authProvidersRepeater1_ItemCommand" DataSource="<%# this.Model.AuthProviders.OrderBy(o=>o.DisplayName) %>" Visible="<%# !this.User.Identity.IsAuthenticated %>">
                <HeaderTemplate>
                    <h3>oAuth2 Providers</h3>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:LinkButton Text='<%# this.GetAuthProviderDisplayName(Item, "de") %>' runat="server" CommandArgument="<%# Item.Identifier %>" CommandName="Login" /><br />
                </ItemTemplate>
            </asp:Repeater>

        </div>
    </form>
</body>
</html>
