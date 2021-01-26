using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Data;
using WebBusiness;

namespace DatabaseProject.User.AuthorizedUser
{
    public partial class UserInformation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            List<string> userInfor = Function.GetUserInfor(conn, Server.UrlDecode(Request.QueryString["id"]));

            DoB.Text = userInfor[0] + "/" + userInfor[1] + "/" + userInfor[2];
            Username.Text = userInfor[3];
            Address.Text = userInfor[5];
            Phonenumber.Text = userInfor[6];
            Subscription.Text = userInfor[7];
            Identify.Text = userInfor[8];

            string cmd = "SELECT COUNT(post_id) AS post_num FROM public.post WHERE user_id = '" + Server.UrlDecode(Request.QueryString["id"]) + "'";
            PostNum.Text = SqlData.ExeNpSqlToTable(cmd, conn).Rows[0]["post_num"].ToString();
        }

        protected void EditInfor_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditInfor.aspx?id=" + Server.UrlDecode(Request.QueryString["id"]));
        }
    }
}