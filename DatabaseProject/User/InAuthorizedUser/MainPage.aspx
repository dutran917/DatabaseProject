<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="DatabaseProject.User.InAuthorizedUser.MainPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width:100%">
        <div style="width:28%; float:left;padding-left:2%; padding-top:20px">
        <asp:Label ID="Label1" runat="server" Text="Quận" Width="100px"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="100px">
            
        </asp:DropDownList>
            
        <br />
    
            <asp:Label ID="Label2" runat="server" Text="Phường" Width="100px"></asp:Label>
            <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" Width="100px">
            </asp:DropDownList>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Phố" Width="100px"></asp:Label>
            <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True" Width="100px" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Diện tích" Width="100px"></asp:Label>
            <asp:DropDownList ID="DropDownList4" runat="server" AutoPostBack="True" Width="100px" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged">
                <asp:ListItem Value="-1">Blank</asp:ListItem>
                <asp:ListItem Value="20">Nhỏ hơn 30m2</asp:ListItem>
                <asp:ListItem Value="40">30 - 50 m2</asp:ListItem>
                <asp:ListItem Value="65">50 - 80 m2</asp:ListItem>
                <asp:ListItem Value="90">80 - 100 m2</asp:ListItem>
                <asp:ListItem Value="100">Lớn hơn 100m2</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Giá" Width="100px"></asp:Label>
            <asp:DropDownList ID="DropDownList5" runat="server" AutoPostBack="True" Width="100px" OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged">
                <asp:ListItem Value="-1">Blank</asp:ListItem>
                <asp:ListItem Value="1">Dưới 1 tỷ</asp:ListItem>
                <asp:ListItem Value="2">1 - 3 tỷ</asp:ListItem>
                <asp:ListItem Value="4">3 - 5 tỷ</asp:ListItem>
                <asp:ListItem Value="6">5 - 7 tỷ</asp:ListItem>
                <asp:ListItem Value="8.5">7 - 10 tỷ</asp:ListItem>
                <asp:ListItem Value="10">Trên 10 tỷ</asp:ListItem>
            </asp:DropDownList>
            
            <br />
            <asp:Label ID="Label6" runat="server" Text="Loại nhà" Width="100px"></asp:Label>
            <asp:DropDownList ID="DropDownList6" runat="server" Width="100px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList6_SelectedIndexChanged">
                <asp:ListItem Value="-1">Blank</asp:ListItem>
                <asp:ListItem>Chung cư</asp:ListItem>
                <asp:ListItem>Thổ cư</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Button ID="Button1" runat="server" BackColor="#339933" BorderColor="#339933" BorderStyle="Solid" Font-Bold="True" ForeColor="White" Height="50px" OnClick="Button1_Click" Text="Clear" Width="100px" />
            
        </div>
    <div style="display:table; width:70%; float:left">
        <asp:Repeater runat="server" ID="postList">
            <ItemTemplate>
                <div style="display:table-row;">
                    <div style="display:table-cell">
                        <img src="../../Images/<%#Eval("post_image") %>" width="200" height="200" style="padding-bottom:10px"/>
                    </div>
                    <div style="display:table-cell">
                        <h3><%#Eval("post_header") %></h3>
                        <a href="Detail.aspx?id=<%#Eval("post_id") %>">Xem thêm...</a>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    </div>
</asp:Content>
