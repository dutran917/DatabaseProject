<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EditInfor.aspx.cs" Inherits="DatabaseProject.User.AuthorizedUser.EditInfor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
&nbsp;<asp:Label ID="Label1" runat="server" Text="Username" Width="130px" Font-Bold="True"></asp:Label>
    <asp:TextBox ID="Username" runat="server" Width="50%"></asp:TextBox>
    <br />
    <br />
&nbsp;<asp:Label ID="Label2" runat="server" Text="Password" Width="130px" Font-Bold="True"></asp:Label>
    <asp:TextBox ID="Password" runat="server" Width="50%" TextMode="Password"></asp:TextBox>
    <asp:Label ID="Label8" runat="server" Visible="False"></asp:Label>
    <br />
    <br />
&nbsp;<asp:Label ID="Label3" runat="server" Text="Confirm Password" Width="130px" Font-Bold="True"></asp:Label>
    <asp:TextBox ID="ConfirmPassword" runat="server" Width="50%" TextMode="Password"></asp:TextBox>
    <asp:Label ID="Alert" runat="server" ForeColor="Red"></asp:Label>
    <br />
    <br />
&nbsp;<asp:Label ID="Label4" runat="server" Text="Address" Width="130px" Font-Bold="True"></asp:Label>
    <asp:TextBox ID="Address" runat="server" Width="50%"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label5" runat="server" Text="Date of Birth" Width="130px" Font-Bold="True"></asp:Label>
    <asp:DropDownList ID="Day" runat="server">
    </asp:DropDownList>
    <asp:DropDownList ID="Month" runat="server">
    </asp:DropDownList>
    <asp:DropDownList ID="Year" runat="server">
    </asp:DropDownList>
    <br />
    <br />
&nbsp;<asp:Label ID="Label6" runat="server" Text="Phone number" Width="130px" Font-Bold="True"></asp:Label>
    <asp:TextBox ID="Phonenumber" runat="server" Width="50%"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label7" runat="server" Text="Subscription" Width="130px" Font-Bold="True"></asp:Label>
    <asp:DropDownList ID="Subscription" runat="server">
        <asp:ListItem>1</asp:ListItem>
        <asp:ListItem>2</asp:ListItem>
        <asp:ListItem>3</asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Save" runat="server" BackColor="#339933" BorderColor="#339933" BorderStyle="Solid" ForeColor="White" Height="50px" OnClick="Save_Click" Text="Save" Width="100px" />
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="MainPage" runat="server" BackColor="#339933" BorderColor="#339933" BorderStyle="Solid" ForeColor="White" Height="50px" Text="MainPage" Width="100px" OnClick="MainPage_Click" />
    <br />

</asp:Content>
