using Data;
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
    public partial class MainPage : System.Web.UI.Page
    {
        protected List<string> district = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            string user_id = Server.UrlDecode(Request.QueryString["user_id"]);
            DataTable tbl;
            tbl = Function.GetDistrict(conn);
            if (!IsPostBack)
            {
                DropDownList1.Items.Add(new ListItem(" ", "0"));
                DropDownList2.Items.Add(new ListItem(" ", "0"));
                DropDownList3.Items.Add(new ListItem(" ", "0"));
                DropDownList4.SelectedValue = "-1";
                DropDownList5.SelectedValue = "-1";
                DropDownList6.SelectedValue = "-1";

                foreach (DataRow r in tbl.Rows)
                {
                    DropDownList1.Items.Add(new ListItem(r["district_name"].ToString(), r["district_id"].ToString()));
                }

                postList.DataSource = Function.GetPostListForUser(conn, DropDownList5.SelectedValue, DropDownList4.SelectedValue, DropDownList6.SelectedValue, user_id);
                postList.DataBind();
            }
            //foreach (DataRow r in tbl.Rows)
            //{
            //    DropDownList1.Items.Add(new ListItem(r["district_name"].ToString(), r["district_id"].ToString()));
            //}

            //if (DropDownList3.SelectedValue != "0")
            //{
            //    tbl = Function.GetPostByStreet(conn, DropDownList3.SelectedValue, DropDownList5.SelectedValue, DropDownList4.SelectedValue, DropDownList6.SelectedValue, user_id);
            //    //Response.Write(Function.GetPostByStreet(conn, DropDownList3.SelectedValue, DropDownList5.SelectedValue, DropDownList4.SelectedValue));
            //}
            //else
            //{
            //    if (DropDownList2.SelectedValue != "0")
            //    {
            //        tbl = Function.GetPostByWard(conn, DropDownList2.SelectedValue, DropDownList5.SelectedValue, DropDownList4.SelectedValue, DropDownList6.SelectedValue, user_id);
            //        //Response.Write(Function.GetPostByWard(conn, DropDownList2.SelectedValue, DropDownList5.SelectedValue, DropDownList4.SelectedValue));
            //    }
            //    else
            //    {
            //        if (DropDownList1.SelectedValue != "0")
            //            tbl = Function.GetPostByDistrict(conn, DropDownList1.SelectedValue, DropDownList5.SelectedValue, DropDownList4.SelectedValue, DropDownList6.SelectedValue, user_id);
            //        //Response.Write(Function.GetPostByDistrict(conn, DropDownList1.SelectedValue, DropDownList5.SelectedValue, DropDownList4.SelectedValue));
            //        else
            //            tbl = Function.GetPostListForUser(conn, DropDownList5.SelectedValue, DropDownList4.SelectedValue, DropDownList6.SelectedValue, user_id);
            //        //Response.Write(Function.GetPostListForUser(conn, DropDownList5.SelectedValue, DropDownList4.SelectedValue, user_id));
            //    }
            //}

            //postList.DataSource = tbl;
            //postList.DataBind();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            string user_id = Server.UrlDecode(Request.QueryString["user_id"]);
            DropDownList2.Items.Clear();
            DropDownList3.Items.Clear();
            DropDownList2.Items.Add(new ListItem(" ", "0"));
            DropDownList3.Items.Add(new ListItem(" ", "0"));
            DropDownList2.SelectedValue = "0";
            DropDownList3.SelectedValue = "0";
            if (DropDownList1.SelectedValue != "0")
            {

                DataTable tbl = Function.GetWard(conn, DropDownList1.SelectedValue);
                foreach (DataRow r in tbl.Rows)
                {
                    DropDownList2.Items.Add(new ListItem(r["ward_name"].ToString(), r["ward_id"].ToString()));
                }

                postList.DataSource = Function.GetPostByDistrict(conn, DropDownList1.SelectedValue, DropDownList5.SelectedValue, DropDownList4.SelectedValue, DropDownList6.SelectedValue, user_id);
                postList.DataBind();
            }
            else
            {
                postList.DataSource = Function.GetPostListForUser(conn, DropDownList5.SelectedValue, DropDownList4.SelectedValue, DropDownList6.SelectedValue, user_id);
                postList.DataBind();
            }
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            string user_id = Server.UrlDecode(Request.QueryString["user_id"]);
            DropDownList3.Items.Clear();
            DropDownList3.Items.Add(new ListItem(" ", "0"));
            DropDownList3.SelectedValue = "0";
            if (DropDownList2.SelectedValue != "0")
            {

                DataTable tbl = Function.GetStreet(conn, DropDownList2.SelectedValue);
                foreach (DataRow r in tbl.Rows)
                {
                    DropDownList3.Items.Add(new ListItem(r["street_name"].ToString(), r["street_id"].ToString()));
                }

                postList.DataSource = Function.GetPostByWard(conn, DropDownList2.SelectedValue, DropDownList5.SelectedValue, DropDownList4.SelectedValue, DropDownList6.SelectedValue, user_id);
                postList.DataBind();
            }
            else
            {
                postList.DataSource = Function.GetPostByDistrict(conn, DropDownList1.SelectedValue, DropDownList5.SelectedValue, DropDownList4.SelectedValue, DropDownList6.SelectedValue, user_id);
                postList.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            string user_id = Server.UrlDecode(Request.QueryString["user_id"]);
            DropDownList1.SelectedValue = "0";
            DropDownList2.SelectedValue = "0";
            DropDownList3.SelectedValue = "0";
            DropDownList4.SelectedValue = "-1";
            DropDownList5.SelectedValue = "-1";
            DropDownList6.SelectedValue = "-1";
            DataTable tbl = Function.GetPostListForUser(conn, DropDownList5.SelectedValue, DropDownList4.SelectedValue, DropDownList6.SelectedValue, user_id);
            postList.DataSource = tbl;
            postList.DataBind();
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            string user_id = Server.UrlDecode(Request.QueryString["user_id"]);
            if (DropDownList3.SelectedValue != "0")
            {
                postList.DataSource = Function.GetPostByStreet(conn, DropDownList3.SelectedValue, DropDownList5.SelectedValue, DropDownList4.SelectedValue, DropDownList6.SelectedValue, user_id);
                postList.DataBind();
            }
            else
            {
                postList.DataSource = Function.GetPostByWard(conn, DropDownList2.SelectedValue, DropDownList5.SelectedValue, DropDownList4.SelectedValue, DropDownList6.SelectedValue, user_id);
                postList.DataBind();
            }
        }

        protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            string user_id = Server.UrlDecode(Request.QueryString["user_id"]);//copy dòng này vào 2 hàm bên dưới
            if (DropDownList3.SelectedValue != "0")
            {
                postList.DataSource = Function.GetPostByStreet(conn, DropDownList3.SelectedValue, DropDownList5.SelectedValue, DropDownList4.SelectedValue, DropDownList6.SelectedValue, user_id);
                postList.DataBind();
            }
            else
            {
                if (DropDownList2.SelectedValue != "0")
                {
                    postList.DataSource = Function.GetPostByWard(conn, DropDownList2.SelectedValue, DropDownList5.SelectedValue, DropDownList4.SelectedValue, DropDownList6.SelectedValue, user_id);
                    postList.DataBind();
                }
                else
                {
                    if (DropDownList1.SelectedValue != "0")
                    {
                        postList.DataSource = Function.GetPostByDistrict(conn, DropDownList1.SelectedValue, DropDownList5.SelectedValue, DropDownList4.SelectedValue, DropDownList6.SelectedValue, user_id);
                        postList.DataBind();
                    }
                    else
                    {
                        postList.DataSource = Function.GetPostListForUser(conn, DropDownList5.SelectedValue, DropDownList4.SelectedValue, DropDownList6.SelectedValue, user_id);
                        postList.DataBind();
                    }
                }
            }
        }

        protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
        {
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            string user_id = Server.UrlDecode(Request.QueryString["user_id"]);
            if (DropDownList3.SelectedValue != "0")
            {
                postList.DataSource = Function.GetPostByStreet(conn, DropDownList3.SelectedValue, DropDownList5.SelectedValue, DropDownList4.SelectedValue, DropDownList6.SelectedValue, user_id);
                postList.DataBind();
            }
            else
            {
                if (DropDownList2.SelectedValue != "0")
                {
                    postList.DataSource = Function.GetPostByWard(conn, DropDownList2.SelectedValue, DropDownList5.SelectedValue, DropDownList4.SelectedValue, DropDownList6.SelectedValue, user_id);
                    postList.DataBind();
                }
                else
                {
                    if (DropDownList1.SelectedValue != "0") //m nhìn thấy có 2 file giống tên nhau đúng ok bên dưới nữa
                    {
                        postList.DataSource = Function.GetPostByDistrict(conn, DropDownList1.SelectedValue, DropDownList5.SelectedValue, DropDownList4.SelectedValue, DropDownList6.SelectedValue, user_id);
                        postList.DataBind();
                    }
                    else
                    {
                        postList.DataSource = Function.GetPostListForUser(conn, DropDownList5.SelectedValue, DropDownList4.SelectedValue, DropDownList6.SelectedValue, user_id);
                        postList.DataBind();
                    }
                }
            }
        }

        protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
        {
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            string user_id = Server.UrlDecode(Request.QueryString["user_id"]);//chay xem nao
            if (DropDownList3.SelectedValue != "0")
            {
                postList.DataSource = Function.GetPostByStreet(conn, DropDownList3.SelectedValue, DropDownList5.SelectedValue, DropDownList4.SelectedValue, DropDownList6.SelectedValue, user_id);
                postList.DataBind();
            }
            else
            {
                if (DropDownList2.SelectedValue != "0")
                {
                    postList.DataSource = Function.GetPostByWard(conn, DropDownList2.SelectedValue, DropDownList5.SelectedValue, DropDownList4.SelectedValue, DropDownList6.SelectedValue, user_id);
                    postList.DataBind();
                }
                else
                {
                    if (DropDownList1.SelectedValue != "0")
                    {
                        postList.DataSource = Function.GetPostByDistrict(conn, DropDownList1.SelectedValue, DropDownList5.SelectedValue, DropDownList4.SelectedValue, DropDownList6.SelectedValue, user_id); // co dung space ko?b
                        postList.DataBind();//been hamf treen nuwax
                    }
                    else
                    {
                        postList.DataSource = Function.GetPostListForUser(conn, DropDownList5.SelectedValue, DropDownList4.SelectedValue, DropDownList6.SelectedValue, user_id);
                        postList.DataBind();
                    }
                }
            }//
        }
    }
}