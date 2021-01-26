using Data;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebBusiness;

namespace DatabaseProject
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            List<string> input = new List<string>();
            input.Add(Account.Text);
            input.Add(Password.Text);
            input.Add(Username.Text);
            input.Add(Address.Text);
            input.Add(Day.Text);
            input.Add(Month.SelectedValue);
            input.Add(Year.SelectedValue);
            input.Add(Identify.Text);
            input.Add(Phone_number.Text);
            input.Add(Subscription.SelectedValue);
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

            Function.UserRegister(conn, input);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogIn.aspx");
        }
    }
}