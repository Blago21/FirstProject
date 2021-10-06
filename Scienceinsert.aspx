<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Scienceinsert.aspx.cs" Inherits="WebApplication2.Scienseinsert" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Science Degree</title>
        <link href="StyleLogin.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 483px;
        }
        .auto-style2 {
            width: 947px;
        }
        .auto-style3 {
            width: 473px;
            height: 200px;
            margin-bottom: 0px;
        }
        .auto-style4 {
            margin-top: 0px;
            margin-left: 666px;
        }
        .auto-style5 {
            height: 40px;
        }
        .auto-style6 {
            height: 28px;
            margin-top: 0px;
        }
        .auto-style7 {
            height: 27px;
            margin-left: 47px;
            margin-bottom: 34px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1 class="auto-style5"><b>Science Degree</b></h1>
        <div class="auto-style7">
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<table class="auto-style3">
            <tr>
            <td class="auto-style2">
                &nbsp;
                <asp:Label Text="ID" runat="server" ForeColor="White" Visible="false"  />
            </td>
                <td class="auto-style1">
                <asp:TextBox ID="txtIDProject" runat="server" Width="300px" Visible="false" />           
            </td>
        </tr>
         <tr>
            <td class="auto-style2">
                &nbsp;
                <asp:Label Text="Science name" runat="server" ForeColor="White" />
            </td>
                <td class="auto-style1">
                <asp:TextBox ID="txtName" runat="server" Width="300px" />           
            </td>
        </tr>
            <tr>
            <td class="auto-style2">
                &nbsp;
                <asp:Label Text="Start" runat="server" ForeColor="White" />
            </td>
            <td class="auto-style1">
                <asp:TextBox ID="txtstart" TextMode="Date" runat="server" Width="300px" />             
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                &nbsp;
                <asp:Label Text="Finish" runat="server" ForeColor="White" />
            </td>
            <td class="auto-style1">
                <asp:TextBox ID="txtfinish" TextMode="Date" runat="server" Width="300px" />             
            </td>
        </tr>
           <tr>
         <td class="auto-style2"></td>
         <td class="auto-style1">
        <asp:Button Text="Save" ID="btnsave" runat="server" OnClick="btnsave_Click"/>
        <asp:Button ID="Update" runat="server" OnClick="Update_Click" Text="Update" />
        <asp:Button ID="btndelete" runat="server" OnClick="btndelete_Click1" Text="Delete" />
        <asp:Button ID="btnshow" runat="server" OnClick="btnshow_Click" Text="Show" />
        </td>
      </tr>

        </table>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </div>
        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" CssClass="auto-style4" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="425px">
         <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="lnkEdit" Text="Edit" runat="server" CommandArgument='<%# Eval("IDProject") %>' onClick="lnkEdit_Click" />
            </ItemTemplate>
        </asp:TemplateField>
        </Columns>
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SortedAscendingCellStyle BackColor="#EDF6F6" />
            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
            <SortedDescendingCellStyle BackColor="#D6DFDF" />
            <SortedDescendingHeaderStyle BackColor="#002876" />
        </asp:GridView>

         <p>
         <asp:Label ID="lblError" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
        </p>
         <p class="auto-style6">
         <asp:Label ID="lblsave" runat="server" ForeColor="Green" Text="Label" Visible="False"></asp:Label>
        </p>

    </form>
</body>
</html>
