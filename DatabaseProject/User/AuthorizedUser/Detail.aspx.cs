using Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebBusiness;

namespace DatabaseProject.User.AuthorizedUser
{
    public partial class Detail : System.Web.UI.Page
    {
        //protected string GetUserId()
        //{
        //    string cmd = "SELECT user_id FROM public.users WHERE user_account = '" + HttpContext.Current.User.Identity.Name + "'";
        //    string res = "";
        //    DataTable tbl = SqlData.ExeNpSqlToTable(cmd, System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString);

        //    foreach (DataRow r in tbl.Rows)
        //    {
        //        res = r["user_id"].ToString();
        //    }
        //    return res;
        //}
        protected string author_id;
        protected string author_name;
        protected void Page_Load(object sender, EventArgs e)
        {
            string post_id = Server.UrlDecode(Request.QueryString["id"]);
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

            DataTable tbl = Function.GetPostDetail(conn, post_id);
            header.Text = tbl.Rows[0]["post_header"].ToString();
            image.Text = "<img src=\"../../Images/" + tbl.Rows[0]["post_image"] + "\" width=\"200\" height=\"200\"/>";
            area.Text = tbl.Rows[0]["post_area"].ToString();
            price.Text = tbl.Rows[0]["post_price"].ToString();
            detail.Text = HttpUtility.HtmlDecode(tbl.Rows[0]["post_detail"].ToString());
            author_id = tbl.Rows[0]["user_id"].ToString();
            author_name = Function.GetUserInfor(conn, author_id)[3];
            View.Text = tbl.Rows[0]["post_view"].ToString();

            Function.UpdateHistory(conn, post_id, Function.GetUserId(conn, HttpContext.Current.User.Identity.Name));
            

            TopPostList.DataSource = Function.GetTopViewPost(conn);
            TopPostList.DataBind();

            Repeater1.DataSource = Function.GetRecentPost(conn, Function.GetUserId(conn, HttpContext.Current.User.Identity.Name));
            Repeater1.DataBind();
        }
    }
}