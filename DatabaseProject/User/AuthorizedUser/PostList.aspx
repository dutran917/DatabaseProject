<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PostList.aspx.cs" Inherits="DatabaseProject.User.AuthorizedUser.PostList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width:100%;">
        <div>
            <div style="float:left; width:10%">
                <asp:CheckBoxList ID="CheckBoxList1" runat="server" AutoPostBack="True">
                    <asp:ListItem Value="post_view">View</asp:ListItem>
                    <asp:ListItem Value="post_price">Price</asp:ListItem>
                    <asp:ListItem Value="post_time">Date</asp:ListItem>
                </asp:CheckBoxList> 
            </div>
            <div style="float:left;width:10%">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True">
                    <asp:ListItem Value="ASC">Ascending</asp:ListItem>
                    <asp:ListItem Value="DESC">Descending</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div style="float:left;width:10%">
                <asp:RadioButtonList ID="RadioButtonList2" runat="server" AutoPostBack="True">
                    <asp:ListItem Value="0">Hidden</asp:ListItem>
                    <asp:ListItem Value="1">Unhidden</asp:ListItem>
                    <asp:ListItem Value="2">Both</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div style="float:left;width:10%">
                
                <asp:RadioButtonList ID="RadioButtonList3" runat="server" AutoPostBack="True">
                    <asp:ListItem Value="Pending">Pending</asp:ListItem>
                    <asp:ListItem Value="Approve">Approve</asp:ListItem>
                    <asp:ListItem>Both</asp:ListItem>
                </asp:RadioButtonList>
                
            </div>
            
        </div><br /><br />
        <div id="PostList" style="display:table; padding-top:20px; width:70%;float:left">
            <asp:Repeater runat="server" ID="postList">
                <ItemTemplate>
                    <div style="display:table-row">
                        <div style="display:table-cell">
                            <a href="RemovePost.aspx?id=<%#Eval("post_id") %>&user_id=<%#Eval("user_id") %>"><img src="../../Images/x.png" width="20" height="20"/></a>
                        </div>
                        <div style="display:table-cell">
                            <img src="../../Images/<%#Eval("post_image") %>" width="200" height="200"/>
                        </div>
                        <div style="display:table-cell">
                            <h3><%#Eval("post_header") %></h3>
                            <a href="EditPost.aspx?id=<%#Eval("post_id") %>&user_id=<%#Eval("user_id") %>">Xem thêm...</a>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
