<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EditPost.aspx.cs" Inherits="DatabaseProject.User.AuthorizedUser.EditPost" %>
<%@ Register assembly="FreeTextBox" namespace="FreeTextBoxControls" tagprefix="FTB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="padding-top:10px">
            <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Tiêu đề"></asp:Label>
            <br />
            <asp:TextBox ID="header" runat="server" Width="50%"></asp:TextBox>
            <br />
            <asp:Label ID="image" runat="server"></asp:Label>
            <br />
            <asp:FileUpload ID="FileUpload2" runat="server" />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Upload" />
            <asp:Label ID="ImageName" runat="server" Visible="False"></asp:Label>
            <br />
            <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Nội dung"></asp:Label>
            <br />
            
            <FTB:FreeTextBox ID="detail" runat="server">
            </FTB:FreeTextBox>
            <asp:FileUpload ID="FileUpload1" runat="server" />
&nbsp;
            <asp:Button ID="Upload" runat="server" OnClick="Upload_Click" Text="Upload Image" Width="120px" />
            <br />
            <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Diện tích: "></asp:Label>
&nbsp;<asp:TextBox ID="area" runat="server"></asp:TextBox>
            <asp:Label ID="Label1" runat="server" Text="m2" Font-Bold="True"></asp:Label>
            <br />
            <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="Giá: "></asp:Label>
&nbsp;<asp:TextBox ID="price" runat="server" Width="25%"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="tỷ VND" Font-Bold="True"></asp:Label>
            <br />
            <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="Địa chỉ:"></asp:Label>
            <br />
            <asp:DropDownList ID="district" runat="server" Width="150px" OnSelectedIndexChanged="District_SelectedIndexChanged" AutoPostBack="True">
            </asp:DropDownList>
&nbsp;<asp:DropDownList ID="ward" runat="server" Width="150px" OnSelectedIndexChanged="Ward_SelectedIndexChanged" AutoPostBack="True">
            </asp:DropDownList>
&nbsp;<asp:DropDownList ID="street" runat="server" Width="150px">
            </asp:DropDownList>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <asp:Label ID="Label8" runat="server" Font-Bold="True" Text="Hướng:"></asp:Label>
&nbsp;<asp:DropDownList ID="direction" runat="server">
                <asp:ListItem Value="1">Đông Tứ Trạch</asp:ListItem>
                <asp:ListItem Value="2">Tây Tứ Trạch</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Label ID="Label9" runat="server" Font-Bold="True" Text="Số tầng: "></asp:Label>
&nbsp;<asp:DropDownList ID="floors" runat="server">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
            </asp:DropDownList>
            &nbsp;<br />
            <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="Loại nhà: "></asp:Label>
            &nbsp;<asp:DropDownList ID="type" runat="server">
                <asp:ListItem>Chung cư</asp:ListItem>
                <asp:ListItem>Thổ cư</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Label ID="Label11" runat="server" Font-Bold="True" Text="Trạng thái: "></asp:Label>
            <br />
            <asp:RadioButtonList ID="restricted" runat="server">
                <asp:ListItem Value="1">Public</asp:ListItem>
                <asp:ListItem Value="0">Private</asp:ListItem>
            </asp:RadioButtonList>
            <br />
            <asp:Button ID="Post" runat="server" BackColor="#339933" BorderColor="#339933" BorderStyle="Solid" ForeColor="White" Height="50px" OnClick="Post_Click" Text="Button" Width="100px" />
&nbsp;<asp:Button ID="MainPage" runat="server" BackColor="#339933" BorderColor="#339933" BorderStyle="Solid" ForeColor="White" Height="50px" OnClick="MainPage_Click" Text="Main Page" Width="100px" />
            <br />
        </div>
</asp:Content>
