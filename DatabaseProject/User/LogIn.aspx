<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="DatabaseProject.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align:center">
            Username:
            <asp:TextBox ID="Username" runat="server" Width="300px"></asp:TextBox>
            <br />
            Password:
            <asp:TextBox ID="Password" runat="server" TextMode="Password" Width="300px"></asp:TextBox>
            <br />
            <asp:Label ID="Alert" runat="server"></asp:Label>
            <br />
            <asp:Button ID="LogIn" runat="server" BackColor="#339933" BorderColor="#339933" BorderStyle="Solid" ForeColor="White" Height="50px" OnClick="Button1_Click" Text="Log In" Width="100px" />
&nbsp;
            <asp:Button ID="Register" runat="server" BackColor="#339933" BorderColor="#339933" BorderStyle="Solid" ForeColor="White" Height="50px" Text="Register" Width="100px" OnClick="Register_Click" />

        </div>
    </form>
</body>
</html>
