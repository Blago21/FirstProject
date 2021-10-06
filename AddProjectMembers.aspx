<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProjectMembers.aspx.cs" Inherits="WebApplication2.AddProjectMembers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Projectg Members</title>
    <link href="StyleLogin.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style2 {
            height: 38px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
         <h1>Add Project members</h1>
         <asp:Label ID="lblinfo" runat="server" ForeColor="White" Text="Label"></asp:Label>

        <div class="auto-style2">
            <asp:DropDownList ID="ddlPerson" runat="server" Height="25px" Width="187px"></asp:DropDownList>
            <asp:DropDownList ID="ddlSM" runat="server" Height="25px" Width="187px"></asp:DropDownList>
            <asp:Button ID="btnadd" runat="server" Text="Add" Width="95px" OnClick="btnadd_Click" Height="30px" />
            <asp:Button ID="btndelete" runat="server" Text="Delete" Width="95px" Height="30px" OnClick="btndelete_Click" />
        </div>
        <div>
            <asp:ListBox ID="lbmembers" Width="369px" runat="server" Height="117px"></asp:ListBox>
        </div>
    </form>
</body>
</html>
