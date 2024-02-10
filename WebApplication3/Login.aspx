<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication3.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <link rel="stylesheet" type="text/css" href="stylecode.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 style="text-align:center">בדיקת התחברות </h1>

               <table>
                <tr>
                    <td>שם משתמש</td>
                    <td>
                        <input type="text" id="uName" name="uName" /></td>
                </tr>
                <tr>
                    <td>כתובת דוא"ל</td>
                    <td>
                        <input type="text" id="email" name="email" /></td>
                </tr>
                <tr>
                    <td>סיסמה</td>
                    <td>
                        <input type="password" id="password" name="password" /></td>
                </tr>

                <tr>
                    <td colspan="2" style="text-align: center;">
                        <input type="submit" name="submit" value="שלח" />
                    </td>
                </tr>
            </table>

              <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>

            <a style="text-decoration:none; margin-left:10%; font-size:15px; border-radius:10px;  background-color: #007bff; color: #fff;" href="Register.aspx"> לא רשומים עדיין? הרשמה כאן</a> <br />
            
        </div>
    </form>
</body>
</html>
