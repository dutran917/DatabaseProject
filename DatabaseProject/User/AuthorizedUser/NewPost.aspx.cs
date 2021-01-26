using Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebBusiness;

namespace DatabaseProject.User.AuthorizedUser
{
    public partial class NewPost : System.Web.UI.Page
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
        protected void Page_Load(object sender, EventArgs e)
        {
            restricted.Items[0].Selected = true;
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            string cmd = "SELECT w.ward_name, w.ward_id FROM public.ward AS w, public.district AS d WHERE w.district_id = d.district_id AND d.district_name = '" + district.SelectedValue + "'";
            DataTable tbl = SqlData.ExeNpSqlToTable(cmd, System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString);

            foreach (DataRow r in tbl.Rows)
            {
                ListItem new_item = new ListItem(r["ward_name"].ToString(), r["ward_id"].ToString());
                ward.Items.Add(new_item);
            }

            if(!IsPostBack)
            {
                district.Items.Add(new ListItem(" ", "0"));
                ward.Items.Add(new ListItem(" ", "0"));
                street.Items.Add(new ListItem(" ", "0"));
                DataTable tbl2 = Function.GetDistrict(conn);
                foreach(DataRow r in tbl2.Rows)
                {
                    district.Items.Add(new ListItem(r["district_name"].ToString(), r["district_id"].ToString()));
                }
            }
        }

        protected void MainPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainPage.aspx");
        }

        protected void Post_Click(object sender, EventArgs e)
        {
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            List<string> input = new List<string>
            {
                Function.GetUserId(conn, HttpContext.Current.User.Identity.Name),
                area.Text,
                street.SelectedValue,
                price.Text,
                direction.SelectedValue,
                floors.SelectedValue,
                type.SelectedValue,
                HttpUtility.HtmlEncode(detail.Text),
                restricted.SelectedValue,
                header.Text,
                ImageName.Text
            };

            int res = Function.NewPost(conn, input);
            if(res == 1)
            {
                Response.Redirect("UserInformation.aspx?id=" + input[0]);
            }
            else
            {
                Alert.Text = "Vượt quá số bài quy định";
            }
        }

        protected void Upload_Click(object sender, EventArgs e)
        {
            string fileName = Server.MapPath("../../Images/") + FileUpload1.FileName;
            FileUpload1.SaveAs(fileName);
            string htmlcode = "<img src=\"" + "../../Images/" + FileUpload1.FileName + "\" width=\"200\" height=\"200\">";
            detail.Text += HttpUtility.HtmlDecode(htmlcode);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string cmd = "SELECT w.ward_name, w.ward_id FROM public.ward AS w, public.district AS d WHERE w.district_id = d.district_id AND d.district_id = '" + district.SelectedValue + "'";
            DataTable tbl = SqlData.ExeNpSqlToTable(cmd, System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            ward.Items.Clear();
            foreach (DataRow r in tbl.Rows)
            {
                ListItem new_item = new ListItem(r["ward_name"].ToString(), r["ward_id"].ToString());
                ward.Items.Add(new_item);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string cmd = "SELECT s.street_name, s.street_id FROM public.street AS s, public.ward AS w WHERE s.ward_id = w.ward_id AND w.ward_id = '" + ward.SelectedValue + "'";
            DataTable tbl = SqlData.ExeNpSqlToTable(cmd, System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
            street.Items.Clear();
            foreach (DataRow r in tbl.Rows)
            {
                ListItem new_item = new ListItem(r["street_name"].ToString(), r["street_id"].ToString());
                street.Items.Add(new_item);
            }
        }

        protected void ImageUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload2.FileName != "")
            {
                string fileName = Server.MapPath("../../Images/") + FileUpload2.FileName;
                FileUpload2.SaveAs(fileName);
                string htmlcode = "<img src=\"" + "../../Images/" + FileUpload2.FileName + "\" width=\"200\" height=\"200\">";
                image.Text = HttpUtility.HtmlDecode(htmlcode);
                ImageName.Text = FileUpload2.FileName;
            }
        }

        protected void District_SelectedIndexChanged(object sender, EventArgs e)
        {
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            DataTable tbl = Function.GetWard(conn, district.SelectedValue);
            ward.Items.Clear();
            ward.Items.Add(new ListItem(" ", "0"));
            street.Items.Clear();
            foreach(DataRow r in tbl.Rows)
            {
                ward.Items.Add(new ListItem(r["ward_name"].ToString(), r["ward_id"].ToString()));
            }
        }

        protected void Ward_SelectedIndexChanged(object sender, EventArgs e)
        {
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            DataTable tbl = Function.GetStreet(conn, ward.SelectedValue);
            street.Items.Clear();
            street.Items.Add(new ListItem(" ", "0"));
            foreach(DataRow r in tbl.Rows)
            {
                street.Items.Add(new ListItem(r["street_name"].ToString(), r["street_id"].ToString()));
            }
        }
    }
}