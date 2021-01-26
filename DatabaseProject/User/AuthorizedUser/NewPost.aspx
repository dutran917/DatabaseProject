<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="NewPost.aspx.cs" Inherits="DatabaseProject.User.AuthorizedUser.NewPost" %>
<%@ Register assembly="FreeTextBox" namespace="FreeTextBoxControls" tagprefix="FTB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
            Tiêu đề:<br />
            <asp:TextBox ID="header" runat="server" Width="70%" Rows="3" TextMode="MultiLine"></asp:TextBox>
            <br />
            <asp:Label ID="image" runat="server"></asp:Label>
            <br />
            <asp:FileUpload ID="FileUpload2" runat="server" />
            <asp:Button ID="ImageUpload" runat="server" Text="Upload" OnClick="ImageUpload_Click" />
            <asp:Label ID="ImageName" runat="server" Visible="False"></asp:Label>
            <br />
            Nội dung:<br />
            <FTB:FreeTextBox ID="detail" runat="server" Text="">
            </FTB:FreeTextBox>
            <asp:FileUpload ID="FileUpload1" runat="server" />
&nbsp;
            <asp:Button ID="Upload" runat="server" OnClick="Upload_Click" Text="Upload Image" Width="120px" />
            <br />
            Diện tích:
            <asp:TextBox ID="area" runat="server"></asp:TextBox>
            <asp:Label ID="Label1" runat="server" Text="m2"></asp:Label>
            <br />
            Giá:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="price" runat="server" Width="25%"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="tỷ VND"></asp:Label>
            <br />
            Địa chỉ:<br />
            <asp:DropDownList ID="district" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="District_SelectedIndexChanged">
            </asp:DropDownList>
&nbsp;<asp:DropDownList ID="ward" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="Ward_SelectedIndexChanged">
            </asp:DropDownList>
&nbsp;<asp:DropDownList ID="street" runat="server" Width="150px" AutoPostBack="True">
            </asp:DropDownList>
            <br /><br />
            Hướng:
            <asp:DropDownList ID="direction" runat="server">
                <asp:ListItem Value="1">Đông Tứ Trạch</asp:ListItem>
                <asp:ListItem Value="2">Tây Tứ Trạch</asp:ListItem>
            </asp:DropDownList>
            <br />
            Số tầng:
            <asp:DropDownList ID="floors" runat="server">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
            </asp:DropDownList>
&nbsp;&nbsp;&nbsp; Loại nhà:
&nbsp;<asp:DropDownList ID="type" runat="server">
                <asp:ListItem>Chung cư</asp:ListItem>
                <asp:ListItem>Thổ cư</asp:ListItem>
            </asp:DropDownList>
            <br />
            Dạng bài đăng:<br />
            <asp:RadioButtonList ID="restricted" runat="server">
                <asp:ListItem Value="1">Public</asp:ListItem>
                <asp:ListItem Value="2">Private</asp:ListItem>
            </asp:RadioButtonList>
            <asp:Label ID="Alert" runat="server"></asp:Label>
            <br />
            <asp:Button ID="Post" runat="server" BackColor="#339933" BorderColor="#339933" BorderStyle="Solid" ForeColor="White" Height="50px" OnClick="Post_Click" Text="Button" Width="100px" />
&nbsp;<asp:Button ID="MainPage" runat="server" BackColor="#339933" BorderColor="#339933" BorderStyle="Solid" ForeColor="White" Height="50px" OnClick="MainPage_Click" Text="Main Page" Width="100px" />
            <br />
        </div>
</asp:Content>
