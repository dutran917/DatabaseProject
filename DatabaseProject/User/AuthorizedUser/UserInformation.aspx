<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserInformation.aspx.cs" Inherits="DatabaseProject.User.AuthorizedUser.UserInformation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width:100%">
        <div style="float:left; width:30%;">
            <a href="NewPost.aspx" id="newpost" >New Post</a><br />
            <a href="PostList.aspx?user_id=<%=Server.UrlDecode(Request.QueryString["id"]) %>" id="yourPost">Yours posts</a><br />
            <a href="MainPage.aspx?user_id=<%=Server.UrlDecode(Request.QueryString["id"]) %>" id="hisPost">Posts by this User</a><br />
        </div>
        <div style="float:left; width:70%;">
            <asp:Label ID="Label1" runat="server" Text="Username: " Font-Bold="True" Width="100px"></asp:Label>
            <asp:Label ID="Username" runat="server" Text="Label"></asp:Label>
            <br /><br />
            <asp:Label ID="Label2" runat="server" Text="Địa chỉ: " Font-Bold="True" Width="100px"></asp:Label>
            <asp:Label ID="Address" runat="server" Text="Label"></asp:Label>
            <br /><br />
            <asp:Label ID="Label3" runat="server" Text="Ngày sinh: " Font-Bold="True" Width="100px"></asp:Label>
            <asp:Label ID="DoB" runat="server" Text="Label"></asp:Label>
            <br /><br />
            <asp:Label ID="Label4" runat="server" Text="CMND: " Font-Bold="True" Width="100px"></asp:Label>
            <asp:Label ID="Identify" runat="server" Text="Label"></asp:Label>
            <br /><br />
            <asp:Label ID="Label5" runat="server" Text="Số điện thoại: " Font-Bold="True" Width="100px"></asp:Label>
            <asp:Label ID="Phonenumber" runat="server" Text="Label"></asp:Label>
            <br /><br />
            <asp:Label ID="Label6" runat="server" Text="Gói: " Font-Bold="True" Width="100px"></asp:Label>
            <asp:Label ID="Subscription" runat="server" Text="Label"></asp:Label>
            <br /><br />
            <asp:Label ID="Label7" runat="server" Text="Số bài viết: " Font-Bold="True" Width="100px"></asp:Label>
            <asp:Label ID="PostNum" runat="server" Text="Label"></asp:Label>
            <br /><br />
            <div style="text-align:center">
                <asp:Button ID="EditInfor" runat="server" BackColor="#339933" BorderColor="#339933" BorderStyle="Solid" ForeColor="White" Height="50px" OnClick="EditInfor_Click" Text="Edit Information" Width="120px" />
            </div>
        </div>
    </div>

    <script>
        var newpost = document.getElementById("newpost");
        if (<%=Server.UrlDecode(Request.QueryString["id"]) %> != <%=WebBusiness.Function.GetUserId(System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString, HttpContext.Current.User.Identity.Name)%>) {
            newpost.setAttribute("href", "");
            yourPost.setAttribute("hidden", "true");
        } else {
            hisPost.setAttribute("hidden", "true");
            
        }
    </script>
</asp:Content>
