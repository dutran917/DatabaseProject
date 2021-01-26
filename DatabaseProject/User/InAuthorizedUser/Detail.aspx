<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="DatabaseProject.User.InAuthorizedUser.Detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width:100%">
        <div style="width:70%;float:left;">
            <asp:Label ID="header" runat="server" Text="Label" Font-Size="X-Large"></asp:Label>
            <div style="display:table; padding-left:100px">
                <div style="display:table-cell;">
                    <asp:Label ID="image" runat="server"></asp:Label>
                </div>
                <div style="display:table-cell">
                    <asp:Label ID="Label1" Text="Diện tích: " runat="server"></asp:Label>
                    <asp:Label ID="area" runat="server"></asp:Label>
                    <asp:Label ID="Label3" Text="m2" runat="server"></asp:Label><br />
                    <asp:Label ID="Label2" Text="Giá: " runat="server"></asp:Label>
                    <asp:Label ID="price" runat="server"></asp:Label>
                    <asp:Label ID="Label4" Text="tỷ VND" runat="server"></asp:Label><br />
                    <asp:Label ID="Label5" Text="Người đăng: " runat="server"></asp:Label>
                    <asp:Label ID="Label7" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="Label6" runat="server" Text="Lượt xem:"></asp:Label>
                    <asp:Label ID="View" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div>
                <asp:Label ID="detail" runat="server"></asp:Label>
            </div>
        </div>

        <div style="width:30%; float:left">
            <h3>Top view posts</h3>
            <div style="display:table">
                <asp:Repeater runat="server" ID="TopPostList">
                    <ItemTemplate>
                        <a href="Detail.aspx?id=<%#Eval("post_id") %>">
                            <div style="display:table-cell">
                                <img src="../../Images/<%#Eval("post_image") %>" width="100" height="100"/>
                            </div>
                            <div style="display:table-cell">
                                <h4><%#Eval("post_header") %></h4>
                            </div>
                        </a>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
