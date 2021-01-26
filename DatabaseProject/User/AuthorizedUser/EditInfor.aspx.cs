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
    public partial class EditInfor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            for(int i = 1; i < 32; i++)
            {
                ListItem new_item = new ListItem(i.ToString());
                Day.Items.Add(new_item);
            }
            for (int i = 1; i < 12; i++)
            {
                ListItem new_item = new ListItem(i.ToString());
                Month.Items.Add(new_item);
            }
            for (int i = 1990; i < 2002; i++)
            {
                ListItem new_item = new ListItem(i.ToString());
                Year.Items.Add(new_item);
            }
            if (!IsPostBack)
            {
                string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
                string user_id = Server.UrlDecode(Request.QueryString["id"]);
                List<string> infor = Function.GetUserInfor(conn, user_id);
                Day.SelectedValue = infor[0];
                Month.SelectedValue = infor[1];
                Year.SelectedValue = infor[2];
                Username.Text = infor[3];
                //Password.Text = infor[4];
                Label8.Text = infor[4];
                Address.Text = infor[5];
                Phonenumber.Text = infor[6];
                Subscription.SelectedValue = infor[7];
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            string dob = Day.SelectedValue + "/" + Month.SelectedValue + "/" + Year.SelectedValue;
            string user_id = Server.UrlDecode(Request.QueryString["id"]);
            List<string> input = new List<string>();
            if(Password.Text == ConfirmPassword.Text)
            {
                input.Add(Username.Text);
                input.Add(Address.Text);
                input.Add(dob);
                input.Add(Phonenumber.Text);
                input.Add(Subscription.SelectedValue);
                if (Password.Text != null)
                    input.Add(Password.Text);
                else
                    input.Add(Label8.Text);
                Function.UpdateUserInfor(conn, input, user_id);
            }
            else
            {
                Alert.Text = "Confirm password does not match with password";
            }
        }

        protected void MainPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserInformation.aspx?id=" + Server.UrlDecode(Request.QueryString["id"]));
        }
    }
}