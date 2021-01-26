using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebBusiness;

namespace DatabaseProject.User.AuthorizedUser
{
    public partial class RemovePost : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            string post_id = Server.UrlDecode(Request.QueryString["id"]);
            //Response.Write(Function.RemovePost(conn, post_id));
            Function.RemovePost(conn, post_id);
            Response.Redirect("PostList.aspx?user_id=" + Server.UrlDecode(Request.QueryString["user_id"]));
        }
    }
}