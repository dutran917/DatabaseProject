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
    public partial class EditPost : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            string post_id = Server.UrlDecode(Request.QueryString["id"]);
            DataTable tbl = Function.GetPostDetail(conn, post_id);

            if(!IsPostBack)
            {
                district.Items.Add(new ListItem(" ", "0"));
                ward.Items.Add(new ListItem(" ", "0"));
                street.Items.Add(new ListItem(" ", "0"));
                DataTable tbl4 = Function.GetDistrict(conn);
                foreach (DataRow r in tbl4.Rows)
                {
                    district.Items.Add(new ListItem(r["district_name"].ToString(), r["district_id"].ToString()));
                }
                header.Text = tbl.Rows[0]["post_header"].ToString();
                image.Text = "<img src=\"../../Images/" + tbl.Rows[0]["post_image"] + "\" width=\"200\" heigh=\"200\" />";
                ImageName.Text = tbl.Rows[0]["post_image"].ToString();
                detail.Text = HttpUtility.HtmlDecode(tbl.Rows[0]["post_detail"].ToString());
                area.Text = tbl.Rows[0]["post_area"].ToString();
                price.Text = tbl.Rows[0]["post_price"].ToString();
                restricted.SelectedValue = tbl.Rows[0]["post_restricted"].ToString();
                type.SelectedValue = tbl.Rows[0]["post_type"].ToString();
                floors.SelectedValue = tbl.Rows[0]["post_floors"].ToString();
                DataTable tbl2 = Function.GetAddress(conn, tbl.Rows[0]["post_address"].ToString());
                district.SelectedValue = tbl2.Rows[0]["district_id"].ToString();
                DataTable tbl3 = Function.GetWard(conn, district.SelectedValue);
                foreach(DataRow r in tbl3.Rows)
                {
                    ward.Items.Add(new ListItem(r["ward_name"].ToString(), r["ward_id"].ToString()));
                }

                ward.SelectedValue = tbl2.Rows[0]["ward_id"].ToString();
                tbl3 = Function.GetStreet(conn, ward.SelectedValue);
                foreach(DataRow r in tbl3.Rows)
                {
                    street.Items.Add(new ListItem(r["street_name"].ToString(), r["street_id"].ToString()));
                }
                street.SelectedValue = tbl.Rows[0]["post_address"].ToString();
                
            }
        }

        protected void MainPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("PostList.aspx?user_id=" + Server.UrlDecode(Request.QueryString["user_id"]));
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string fileName = Server.MapPath("../../Images/") + FileUpload2.FileName;
            FileUpload2.SaveAs(fileName);
            string htmlcode = "<img src=\"" + "../../Images/" + FileUpload2.FileName + "\" width=\"200\" height=\"200\">";
            image.Text = HttpUtility.HtmlDecode(htmlcode);
            ImageName.Text = FileUpload2.FileName;
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
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            DataTable tbl = Function.GetWard(conn, district.SelectedValue);
            ward.Items.Clear();
            foreach (DataRow r in tbl.Rows)
            {
                ListItem new_item = new ListItem(r["ward_name"].ToString(), r["ward_id"].ToString());
                ward.Items.Add(new_item);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            DataTable tbl = Function.GetStreet(conn, ward.SelectedValue);
            street.Items.Clear();
            foreach (DataRow r in tbl.Rows)
            {
                ListItem new_item = new ListItem(r["street_name"].ToString(), r["street_id"].ToString());
                street.Items.Add(new_item);
            }
        }

        protected void Post_Click(object sender, EventArgs e)
        {
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            List<string> input = new List<string>();
            input.Add(header.Text);
            input.Add(ImageName.Text);
            input.Add(HttpUtility.HtmlEncode(detail.Text));
            input.Add(area.Text);
            input.Add(price.Text);
            input.Add(street.SelectedValue);
            input.Add(direction.SelectedValue);
            input.Add(floors.SelectedValue);
            input.Add(type.SelectedValue);
            input.Add(restricted.SelectedValue);
            //Response.Write(Function.EditPost(conn, Server.UrlDecode(Request.QueryString["id"]), input));
            Function.EditPost(conn, Server.UrlDecode(Request.QueryString["id"]), input);
        }

        protected void District_SelectedIndexChanged(object sender, EventArgs e)
        {
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            DataTable tbl = Function.GetWard(conn, district.SelectedValue);
            ward.Items.Clear();
            ward.Items.Add(new ListItem(" ", "0"));
            street.Items.Clear();
            foreach (DataRow r in tbl.Rows)
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
            foreach (DataRow r in tbl.Rows)
            {
                street.Items.Add(new ListItem(r["street_name"].ToString(), r["street_id"].ToString()));
            }
        }
    }
}