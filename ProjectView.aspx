<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectView.aspx.cs" Inherits="WebApplication2.GuestViwe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="StyleRegistration.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style2 {
            margin-left: 0px;
        }
        .auto-style4 {
            margin-left: 423px;
        }
        .auto-style5 {
            width: 1256px;
            height: 44px;
            margin-left: 0px;
            margin-top: 21;
        }
        .auto-style7 {
            height: 27px;
            width: 582px;
        }
        .auto-style8 {
            margin-left: 0px;
            margin-top: 0px;
        }
        .auto-style9 {
            margin-left: 37px;
        }
        .auto-style10 {
            height: 10px;
            width: 1644px;
            margin-bottom: 0px;
        }
        .auto-style11 {
            height: 25px;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style10">
            <tr>
                <td class="auto-style7"><h1 class="auto-style5"><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Search&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </b></h1>
                </td>
                <td class="auto-style11">&nbsp;&nbsp; 
                    <asp:Label ID="lblName" runat="server" ForeColor="White" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>
        
        <p>&nbsp;</p>
        <div class="auto-style4">
            &nbsp;<asp:DropDownList ID="ddlchoice" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlchoice_SelectedIndexChanged" CssClass="auto-style8" Height="25px" Width="187px">
                <asp:ListItem>--Select--</asp:ListItem>
                <asp:ListItem>Project</asp:ListItem>
                <asp:ListItem>ScienceDegree</asp:ListItem>
            </asp:DropDownList>
           <asp:DropDownList ID="ddlparamet" runat="server" Height="25px" Width="187px" OnSelectedIndexChanged="ddlparamet_SelectedIndexChanged">
               
            </asp:DropDownList>
            
            <asp:TextBox ID="txtparam" runat="server" Height="19px" Width="187px"></asp:TextBox>
            <asp:Button ID="btnsearch" runat="server" width="80px" Text="Search" OnClick="btnsearch_Click" Height="27px" />    
            <asp:Button ID="btnexit" runat="server" width="80px" Text="Exit" OnClick="btnexit_Click" CssClass="auto-style2" Height="27px" />
            <asp:Button ID="btnupdate" runat="server" width="82px" OnClick="btnupdate_Click" Text="Update" Height="27px" />
            <br />
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" CssClass="auto-style9" Height="211px" Width="684px">
                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                <RowStyle BackColor="White" ForeColor="#003399" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                <SortedDescendingHeaderStyle BackColor="#002876" />
            </asp:GridView>
        </div>
          
        <br />
        
        <div>

        &nbsp;</div>
    </form>
</body>
</html>
