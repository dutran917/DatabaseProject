using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebBusiness;


namespace DatabaseProject.Admin
{
    public partial class Remove : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Server.UrlDecode(Request.QueryString["id"]);
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            Function.RemovePost(conn, id);
            Response.Redirect("MainPage.aspx");
        }
    }
}