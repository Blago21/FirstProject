<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegForm.aspx.cs" Inherits="WebApplication2.RegForm" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleRegistration.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            margin-left: 27px;
        }
        .auto-style2 {
            margin-left: 55px;
            margin-top: 30px;
            margin-bottom: 0px;
        }
        .auto-style3 {
            width: 440px;
            height: 830px;
            background: #000;
            color: #fff;
            top: 46%;
            left: 80%;
            bottom: -96%;
            position: absolute;
            transform: translate(-50%, -50%);
            box-sizing: border-box;
            padding: 70px 10px;
            margin-left: 0px;
        }
    </style>
    </head>
<body>
      <form id="form1" runat="server">
        <div class="navbar navbar-inverse navbar-fixed-top" style="left: 0; right: 0; top: 0; height: 74px">
            <div class="container">
                <div class="navbar-collapse collapse">
                    <ul class="nav navbar-nav">
                        <asp:Button ID="btnshow" runat="server" OnClick="btnshow_Click" Text="All registrations" Height="40px" Width="172px" CssClass="auto-style1" />
                        <asp:Button Text="Save" ID="btnsave" runat="server" CssClass="btn" OnClick="btnsave_Click" Height="40px" style="margin-top: 10px" Width="155px" />
                        <asp:Button ID="Update" runat="server" OnClick="Update_Click" Text="Update" Height="40px" Width="155px" />
                        <asp:Button ID="btndelete" runat="server" OnClick="btndelete_Click1" Text="Delete" Height="40px" Width="155px" />
                        <asp:Button ID="btnExit" runat="server" OnClick="btnexit_Click1" Text="Exit" Height="40px" Width="155px" />                    </ul>
                </div>
            </div>
        </div>   
      <div class="auto-style3">
        <h1>Registration</h1>
                <asp:TextBox ID="txtEmployee" runat="server" Visible="false" Width="115px"/>
            
                <p>First Name</p>
                <asp:TextBox ID="txtfirstname" runat="server" />
                   
                <p>Last Name</p>
                <asp:TextBox ID="txtlastname" runat="server" />
                
                <p>Email Address</p>
                <asp:TextBox ID="txtemail" runat="server" />
                
                <p>Gender</p>
                <asp:RadioButtonList ID="txtgender" runat="server">
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:RadioButtonList>         
        <hr />
                <p>User Name</p>
                <asp:TextBox ID="txtusername" runat="server" />
               
                <p>Password</p>   
                <asp:TextBox ID="txtpassword" runat="server" />
                
                <p>Confirm Password</p>
                <asp:TextBox ID="txtconfirmpassword" runat="server" />
                
                <p>Role</p>
                    <asp:DropDownList ID="ddlrole" runat="server" OnSelectedIndexChanged="ddlrole_SelectedIndexChanged">
                    <asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem>Admin</asp:ListItem>
                    <asp:ListItem>Guest</asp:ListItem>
                    <asp:ListItem>Author</asp:ListItem>
                    <asp:ListItem>University editor</asp:ListItem>
                </asp:DropDownList>  
          <hr />
                <p>Assigning Project</p>
                <asp:DropDownList ID="ddlassignedrole" AutoPostBack="True" DataTextField="Name_Project" runat="server" OnSelectedIndexChanged="ddlassignedrole_SelectedIndexChanged">
                </asp:DropDownList>  
       </div>
               <h3><b><asp:Label ID="lblsave" runat="server" BackColor="#66FF33"></asp:Label></b></h3>

        <p>
         <asp:Label ID="lblmessage" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
        </p>

                     <b><asp:Label Text="" ID="lblError" runat="server" ForeColor="Red" />
        <br />
        </b>

        <br />
        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" CssClass="auto-style2" Height="182px" Width="325px">
        <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="lnkEdit" Text="Edit" runat="server" CommandArgument='<%# Eval("IDEmployee") %>' onClick="lnkEdit_Click" />
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
 </form>  
</body>
</html>

