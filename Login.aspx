<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication2.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="StyleLogin.css" rel="stylesheet" />
</head>
<body>
    <div class="loginbox">
        <h1>Login</h1>
            <form id="form1" runat="server">
                <p>Login</p>
                <asp:TextBox ID="txtUserName" runat="server" placeholder="Enter User Name" />
                <p>Password</p>
                <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" placeholder="Enter Password" />
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="btn" Height="32px" Width="77px"/>
                <br />
                <asp:Label ID="lblmessage" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
            </form>
    </div>

</body>
</html>
