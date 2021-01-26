<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="DatabaseProject.Admin.Detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div style="width:100%">

            <asp:CheckBox ID="CheckBox1" runat="server" Text="Approve" />

        <div style="float:left;width:70%;">
            <asp:Label ID="header" runat="server" Text="Label" Font-Size="X-Large"></asp:Label>
            <div style="display:table; padding-left:100px">
                <div style="display:table-cell">
                    <asp:Label ID="image" runat="server"></asp:Label>
                </div>
                <div style="display:table-cell">
                    <asp:Label ID="Label7" runat="server" Text="Địa chỉ: "></asp:Label>
                    <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="Label1" Text="Diện tích: " runat="server"></asp:Label>
                    <asp:Label ID="area" runat="server"></asp:Label>
                    <asp:Label ID="Label3" Text="m2" runat="server"></asp:Label><br />
                    <asp:Label ID="Label2" Text="Giá: " runat="server"></asp:Label>
                    <asp:Label ID="price" runat="server"></asp:Label>
                    <asp:Label ID="Label4" Text="tỷ VND" runat="server"></asp:Label><br />
                    <asp:Label ID="Label5" Text="Người đăng: " runat="server"></asp:Label>
                    <a href="UserInformation.aspx?id=<%=author_id %>"><%=author_name %></a>
                    <br />
                    <asp:Label ID="Label6" runat="server" Text="Lượt xem:"></asp:Label>
                    <asp:Label ID="View" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div>
                <asp:Label ID="detail" runat="server"></asp:Label>
            </div>
        </div>

            <asp:Button ID="Button1" runat="server" BackColor="#339933" BorderColor="#339933" BorderStyle="Solid" ForeColor="White" Height="50px" OnClick="Button1_Click" Text="Save" Width="100px" />

        </div>
    </div>
</asp:Content>
