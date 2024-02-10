<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllUsers.aspx.cs" Inherits="WebApplication3.AllUsers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="stylecode.css" />


</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Literal ID="ltluName" runat="server"></asp:Literal>
            <asp:Button ID="logOutButton" runat="server" Text="Log-Out" OnClick="logOut_Click" class="button" />
            <asp:Button ID="update_Button" runat="server" Text="update User" OnClick="update_Click" class="button" />
            <div class="container" style="text-align: center;">


                <label for="searchField" class="label">Choose a field to search:</label>
                <asp:DropDownList ID="searchField" runat="server" CssClass="dropdown">
                    <asp:ListItem Value="UserId">מזהה משתמש</asp:ListItem>
                    <asp:ListItem Value="uName">שם משתמש</asp:ListItem>
                    <asp:ListItem Value="fName">שם פרטי</asp:ListItem>
                    <asp:ListItem Value="lName">שם משפחה</asp:ListItem>
                    <asp:ListItem Value="email">אימייל</asp:ListItem>
                    <asp:ListItem Value="password">סיסמא</asp:ListItem>
                </asp:DropDownList>
                <label for="searchQuery" class="label">Enter search query:</label>
                <asp:TextBox ID="searchQuery" runat="server" class="textbox"></asp:TextBox>
                <asp:Button ID="searchButton" runat="server" Text="Search" OnClick="SearchButton_Click" class="button" />
                <asp:Button ID="cancelButton" runat="server" Text="Cancel" OnClick="CancelButton_Click" class="button" />

            </div>
            <br />
            <asp:Repeater ID="UsersRepeater" runat="server">
                <HeaderTemplate>
                    <table border="1" class="table">
                        <tr>
                            <th class="header">מזהה משתמש</th>
                            <th class="header">שם משתמש</th>
                            <th class="header">שם פרטי</th>
                            <th class="header">שם משפחה</th>
                            <th class="header">אימייל</th>
                            <th class="header">סיסמא</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td class="cell"><%# Eval("UserId") %></td>
                        <td class="cell"><%# Eval("uName") %></td>
                        <td class="cell"><%# Eval("fName") %></td>
                        <td class="cell"><%# Eval("lName") %></td>
                        <td class="cell"><%# Eval("email") %></td>
                        <td class="cell"><%# Eval("password") %></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>


</html>
