<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Members.aspx.cs" Inherits="DatabaseProject.Admin.Members" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width:100%; display:table">
        <div style="display:table; width:100%">
            <div style="display:table-cell; width:3%; float:left">
                <p>Xóa</p>
            </div>
            <div style="display:table-cell; width:10%; float:left">
                <p>ID</p>
            </div>
            <div style="display:table-cell; width:20%; float:left">
                <p>Tên người dùng</p>
            </div>
            <div style="display:table-cell; width:10%; float:left">
                <p>Số bài đăng</p>
            </div>
            <div style="display:table-cell; width:24%; float:left">
                <p>Thời gian đăng nhập cuối cùng</p>
            </div>
        </div>
        <asp:Repeater runat="server" ID="memList">
            <ItemTemplate>
                <div style="display:table-row">
                    <div style="width:100%">
                        <div style="width:3%; float:left; display:table-cell">
                            <a href="RemoveMember.aspx?id=<%#Eval("user_id") %>"><img src="../Images/x.png" width="20" height="20"/></a>
                        </div>
                        <div style="width:10%; float:left; display:table-cell">
                            <%#Eval("user_id") %>
                        </div>
                        <div style="width:20%; float:left; display:table-cell">
                            <a href="../User/AuthorizedUser/UserInformation.aspx?id=<%#Eval("user_id") %>"><%#Eval("user_name") %></a>
                        </div>
                        <div style="width:10%; float:left; display:table-cell">
                            <%#Eval("user_posts") %>
                        </div>
                        <div style="width:20%; float:left; display:table-cell; text-align:center">
                            <%#Eval("lastseen") %>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        
    </div>
</asp:Content>
