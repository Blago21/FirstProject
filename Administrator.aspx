<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Administrator.aspx.cs" Inherits="WebApplication2.Administrator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Administrtion account</title>
        <link href="StyleLogin.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="Admin">
        <h1><b>Administrtion account</b></h1>
     
            <asp:DropDownList ID="ddladmin" runat="server" OnSelectedIndexChanged="ddladmin_SelectedIndexChanged">
                <asp:ListItem>--Select--</asp:ListItem>
                <asp:ListItem>Project/Science Degree</asp:ListItem>
                <asp:ListItem>Registration</asp:ListItem>
            </asp:DropDownList>
            
            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn" OnClick="Button1_Click" />
            <asp:Label ID="lblName" runat="server" ForeColor="White" Text="Label"></asp:Label>
        </div>
       <br />
       


        <p>
            &nbsp;</p>
       


    </form>
</body>
</html>
