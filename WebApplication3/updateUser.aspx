<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="updateUser.aspx.cs" Inherits="WebApplication3.updateUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="stylecode.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="container" style="text-align: center;">
                <asp:DropDownList ID="updateFields" runat="server" CssClass="dropdown">
                    <asp:ListItem Value="uName">שם משתמש</asp:ListItem>
                    <asp:ListItem Value="fName">שם פרטי</asp:ListItem>
                    <asp:ListItem Value="lName">שם משפחה</asp:ListItem>
                    <asp:ListItem Value="email">אימייל</asp:ListItem>
                    <asp:ListItem Value="password">סיסמא</asp:ListItem>
                </asp:DropDownList>
                <label for="updateTxt" class="label">אנא הזינו ערך עדכני </label>
                <asp:TextBox runat="server" ID="updateTxt" CssClass="textbox"></asp:TextBox>
                <asp:Button ID="UpdateButton" runat="server" Text="Update" OnClick="update_Click" class="button" />
                <asp:Literal ID="ltlresult" runat="server"></asp:Literal>
                <br />
                <asp:Button ID="back_all" runat="server" Text="Back" OnClick="back_Click" class="button" />
            </div>
        </div>
    </form>
</body>
</html>
