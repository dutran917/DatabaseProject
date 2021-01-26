using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebBusiness;

namespace DatabaseProject.Admin
{
    public partial class MainPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            List<string> orderBy = new List<string>();
            if(!IsPostBack)
            {
                CheckBoxList1.SelectedValue = "post_view";
                RadioButtonList1.SelectedValue = "DESC";
                RadioButtonList2.SelectedValue = "2";
            }
            foreach(ListItem item in CheckBoxList1.Items)
            {
                if(item.Selected)
                {
                    orderBy.Add(item.Value);
                }
            }
            string order = RadioButtonList1.SelectedValue;
            string state = RadioButtonList2.SelectedValue;
            string approve = RadioButtonList3.SelectedValue;

            //Response.Write(Function.GetPostListForAdmin(conn, orderBy, order, state));
            postList.DataSource = Function.GetPostListForAdmin(conn, orderBy, order, state, approve);
            postList.DataBind();
        }
    }
}