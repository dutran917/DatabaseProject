using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebBusiness;

namespace DatabaseProject.Admin
{
    public partial class Members : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            memList.DataSource = Function.GetUserList(conn);
            memList.DataBind();
        }
    }
}