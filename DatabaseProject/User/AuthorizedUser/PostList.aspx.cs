using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebBusiness;

namespace DatabaseProject.User.AuthorizedUser
{
    public partial class PostList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            string user_id = Server.UrlDecode(Request.QueryString["user_id"]);
            List<string> orderBy = new List<string>();
            if (!IsPostBack)
            {
                CheckBoxList1.SelectedValue = "post_view";
                RadioButtonList1.SelectedValue = "DESC";
                RadioButtonList2.SelectedValue = "2";
                RadioButtonList3.SelectedValue = "Approve";
            }
            foreach (ListItem item in CheckBoxList1.Items)
            {
                if (item.Selected)
                {
                    orderBy.Add(item.Value);
                }
            }
            string order = RadioButtonList1.SelectedValue;
            string state = RadioButtonList2.SelectedValue;
            string approve = RadioButtonList3.SelectedValue;
            //Response.Write(user_id);
            //Response.Write(Function.GetPostByUser(conn, user_id, orderBy, order, state, approve));
            postList.DataSource = Function.GetPostByUser(conn, user_id, orderBy, order, state, approve);
            postList.DataBind();
        }
    }
}