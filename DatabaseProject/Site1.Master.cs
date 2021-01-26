using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Data;

namespace DatabaseProject
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = "";
            string cmd = "SELECT user_id FROM public.users WHERE user_account = '" + HttpContext.Current.User.Identity.Name + "'";
            DataTable tbl = SqlData.ExeNpSqlToTable(cmd, System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            if(tbl.Rows.Count != 0)
            {
                id = tbl.Rows[0]["user_id"].ToString();
            }
            userInfor.Attributes.Add("href", "User/AuthorizedUser/UserInformation.aspx?id=" + id);
        }
    }
}