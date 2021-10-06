<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Project insert.aspx.cs" Inherits="WebApplication2.Project_insert" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Project</title>
        <link href="StyleLogin.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style2 {
            width: 524px;
        }
        .auto-style4 {
            height: 30px;
            width: 131px;
        }
        .auto-style5 {
            width: 524px;
            height: 30px;
        }
        .auto-style9 {
            height: 42px;
            width: 1431px;
        }
        .auto-style10 {
            height: 589px;
            width: 581px;
            margin-left: 49px;
            margin-right: 0px;
            margin-top: 0px;
        }
        .auto-style29 {
            margin-left: 0px;
            height: 60px;
            margin-right: 3px;
            width: 671px;
            margin-bottom: 0px;
            margin-top: 46px;
        }
        .auto-style30 {
            margin-left: 90px;
            margin-bottom: 0px;
        }
        .auto-style31 {
            margin-left: 941px;
            height: 28px;
            width: 495px;
            margin-top: 0px;
            margin-bottom: 0px;
        }
        .auto-style6 {
           
            margin-top: 0px;
            margin-right: 0px;
            margin-bottom: 0px;
            margin-left: 635px;
        }
        .auto-style32 {
            width: 131px;
        }
        .auto-style33 {
            margin-left: 0px;
        }
        .auto-style34 {
            height: 15px;
            width: 131px;
        }
        .auto-style35 {
            width: 524px;
            height: 15px;
        }
        .auto-style38 {
            height: 28px;
            width: 131px;
        }
        .auto-style39 {
            width: 524px;
            height: 28px;
        }
        .auto-style40 {
            height: 32px;
            width: 131px;
        }
        .auto-style41 {
            width: 524px;
            height: 32px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
        <h1 class="auto-style9"><b>Project</b></h1>
        <div class="auto-style29">
                  &nbsp;<tr><td class="auto-style7"></td><td colspan="2" class="auto-style8"><asp:Button Text="Save" ID="btnsave" runat="server" OnClick="btnsave_Click" Width="90px" CssClass="auto-style30" Height="30px"/>
        <asp:Button ID="Update" runat="server" OnClick="Update_Click" Text="Update" Width="90px" Height="30px" />
        <asp:Button ID="btndelete" runat="server" OnClick="btndelete_Click1" Text="Delete" Width="90px" Height="30px" />
        <asp:Button ID="btnshow" runat="server" OnClick="btnshow_Click" Text="Show" Width="90px" Height="30px" />
        <asp:Button ID="btnaddPM" runat="server" OnClick="btnaddPM_Click" Text="View Project Members" Width="165px" Height="30px" Enabled="False" />
                  &nbsp;&nbsp;&nbsp;&nbsp;<p class="auto-style31">
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:Label ID="lblError" runat="server" ForeColor="Red" Text="Label" Visible="false"></asp:Label>
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; <asp:Label ID="lblName" runat="server" ForeColor="Red" Text="Label" Visible="false"></asp:Label>
                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      <asp:Label ID="lblsave" runat="server" Text="Label" ForeColor="White" Visible="false"></asp:Label>
        </p>
       <table class="auto-style10">
           <tr>
            <td class="auto-style38">
                <asp:Label Text="ID_Project" runat="server" ForeColor="White" Visible="false" />
            </td>
                <td class="auto-style39">
                <asp:TextBox ID="txtID" runat="server" Width="220px" Visible="false" />    
            </td>
        </tr>
         <tr>
            <td class="auto-style40">
                <asp:Label Text= "Name Project" runat="server" ForeColor="White" />
            </td>
                <td class="auto-style41">
                <asp:TextBox ID="txtNP" runat="server" Width="220px" CssClass="auto-style33" Height="25px" />    
            </td>
        </tr>
            <tr>
            <td class="auto-style34">
                <asp:Label Text="Start" runat="server" ForeColor="White" />
            </td>
            <td class="auto-style35">
                <asp:TextBox ID="txtstart" TextMode="Date" runat="server" Width="220px" />
                
            </td>
        </tr>
        <tr>
            <td class="auto-style32">
                <asp:Label Text="Finish" runat="server" ForeColor="White" />
            </td>
            <td class="auto-style2">
                <asp:TextBox ID="txtfinish" TextMode="Date" runat="server" Width="220px" />
                
            </td>
        </tr>
             <tr>
            <td class="auto-style4">
                <asp:Label Text="Type" runat="server" ForeColor="White" />
            </td>
            <td class="auto-style5">
                <asp:TextBox ID="txttype"  runat="server" Width="220px" />
                
            </td>
        </tr>
             <tr>
            <td class="auto-style32">
                <asp:Label Text="Workflow" runat="server" ForeColor="White" />
            </td>
            <td class="auto-style2">
                <asp:TextBox ID="txtworkf"  runat="server" Width="220px" />           
            </td>
        </tr>
             <tr>
            <td class="auto-style32">
                <asp:Label Text="Finance Plane" runat="server" ForeColor="White" />
            </td>
            <td class="auto-style2">
                <asp:TextBox ID="txtfp"  runat="server" Width="220px" />              
            </td>
        </tr>
             <tr>
            <td class="auto-style32">
                <asp:Label Text="Budget" runat="server" ForeColor="White" />
            </td>
            <td class="auto-style2">
                <asp:TextBox ID="txtbudget"  runat="server" Width="220px" />
                <tr>
      <td class="auto-style32">
          <asp:Label ID="lblFR" runat="server" ForeColor="White" Text="Final Report"></asp:Label>
    </td>
       <td class="auto-style2">
      <asp:FileUpload ID="FilesUpload" runat="server"
                        AllowMultiple="true" />
        <br/>
        <asp:Button ID="UploadButton" runat="server"
                    OnClick="UploadButton_Click"
                    Text="Upload File" />
        <br/>
        <asp:Label ID="FileUploadedList" runat="server" ForeColor="White"/>
        </td>
     </tr>
              
   <tr>
      <td class="auto-style32">
      <asp:Label ID="lblMR" runat="server" ForeColor="White" Text="Middle Report"></asp:Label>       
      <td>
      <asp:FileUpload ID="FilesUpload0" runat="server"
                        AllowMultiple="true" />
        <br/>
        <asp:Button ID="Button1" runat="server"
                    OnClick="UploadButton_Click"
                    Text="Upload File" />
        <br/>
        <asp:Label ID="Label2" runat="server" ForeColor="White"/>
        </td>
        </tr>
           </td>
        </tr>      
           <tr>
      <td class="auto-style32">
          <asp:Label ID="lblReview" runat="server" ForeColor="White" Text="Review"></asp:Label>
      <td>
      <asp:FileUpload ID="FilesUpload1" runat="server"
                        AllowMultiple="true" />
        <br/>
        <asp:Button ID="Button4" runat="server"
                    OnClick="UploadButton_Click"
                    Text="Upload File" />
        <br/>
        <asp:Label ID="Label7" runat="server" ForeColor="White"/>
        </td>
           </tr>
           <tr>
      <td class="auto-style32">
          <asp:Label ID="Contract" runat="server" ForeColor="White" Text="Final Report"></asp:Label>
      <td>
      <asp:FileUpload ID="FilesUpload2" runat="server"
                        AllowMultiple="true" />
        <br/>
        <asp:Button ID="Button5" runat="server"
                    OnClick="UploadButton_Click"
                    Text="Upload File" />
        <br/>
        <asp:Label ID="Label8" runat="server" ForeColor="White"/>
        </td>
           </tr>
           <tr>
      <td class="auto-style32">
        </td>
        </tr>
     

        </table>
        </div>
        <div>
        <asp:GridView ID="GridView1" runat="server" Width="838px" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" CssClass="auto-style6" Height="109px">
            <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="lnkEdit" Text="Edit" runat="server" CommandArgument='<%# Eval("ID_Project") %>' onClick="lnkEdit_Click" />
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
        </div>

    </form>
</body>
</html>
