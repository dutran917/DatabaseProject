using Npgsql;
using System;
using System.Data;
using System.Web.Security;
using Data;
using System.Web;
using WebBusiness;

namespace DatabaseProject
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        //protected DataTable ValidAuthentication(string username, string password)
        //{
        //    string cmd = "SELECT user_role FROM public.users WHERE user_account = '" + username + "' AND user_password = '" + password + "'";
        //    DataTable tbl = SqlData.ExeNpSqlToTable(cmd, System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString);

        //    return tbl;
        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (this.Page.User.Identity.IsAuthenticated)
                    FormsAuthentication.SignOut();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(Username.Text != "" && Password.Text != "")
            {
                using (DataTable tbl = Function.ValidAuthentication(System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString, Username.Text, Password.Text))
                {
                    if (tbl.Rows.Count != 0)
                    {
                        string roles = tbl.Rows[0]["user_role"].ToString();
                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, Username.Text, DateTime.Now, DateTime.Now.AddMinutes(2880), false, roles, FormsAuthentication.FormsCookiePath);
                        string hash = FormsAuthentication.Encrypt(ticket);
                        HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);

                        if (ticket.IsPersistent)
                        {
                            cookie.Expires = ticket.Expiration;
                        }
                        Response.Cookies.Add(cookie);
                        Response.Redirect(FormsAuthentication.GetRedirectUrl(Username.Text, false));
                    }
                }
            }
        }

        protected void Register_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignIn.aspx");
        }
    }
}