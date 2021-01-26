using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebBusiness;
using Data;

namespace DatabaseProject.User.InAuthorizedUser
{
    public partial class MainPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
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

                postList.DataSource = Function.GetPostListForUser(conn, DropDownList5.SelectedValue, DropDownList4.SelectedValue, DropDownList6.SelectedValue, null);
                postList.DataBind();
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
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

                postList.DataSource = Function.GetPostByDistrict(conn, DropDownList1.SelectedValue, DropDownList5.SelectedValue, DropDownList4.SelectedValue, DropDownList6.SelectedValue, null);
                postList.DataBind();
            }
            else
            {
                postList.DataSource = Function.GetPostListForUser(conn, DropDownList5.SelectedValue, DropDownList4.SelectedValue, DropDownList6.SelectedValue, null);
                postList.DataBind();
            }
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
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

                postList.DataSource = Function.GetPostByWard(conn, DropDownList2.SelectedValue, DropDownList5.SelectedValue, DropDownList4.SelectedValue, DropDownList6.SelectedValue, null);
                postList.DataBind();
            }
            else
            {
                postList.DataSource = Function.GetPostByDistrict(conn, DropDownList1.SelectedValue, DropDownList5.SelectedValue, DropDownList4.SelectedValue, DropDownList6.SelectedValue, null);
                postList.DataBind();
            }
            DropDownList3.Items[0].Selected = true;

            DropDownList3.SelectedValue = "0";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            DropDownList1.SelectedValue = "0";
            DropDownList2.SelectedValue = "0";
            DropDownList3.SelectedValue = "0";
            DropDownList4.SelectedValue = "-1";
            DropDownList5.SelectedValue = "-1";
            DropDownList6.SelectedValue = "-1";
            DataTable tbl = Function.GetPostListForUser(conn, DropDownList5.SelectedValue, DropDownList4.SelectedValue, DropDownList6.SelectedValue, null);
            postList.DataSource = tbl;
            postList.DataBind();
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            if (DropDownList3.SelectedValue != "0")
            {
                postList.DataSource = Function.GetPostByStreet(conn, DropDownList3.SelectedValue, DropDownList5.SelectedValue, DropDownList4.SelectedValue, DropDownList6.SelectedValue, null);
                postList.DataBind();
            }
            else
            {
                postList.DataSource = Function.GetPostByWard(conn, DropDownList2.SelectedValue, DropDownList5.SelectedValue, DropDownList4.SelectedValue, DropDownList6.SelectedValue, null);
                postList.DataBind();
            }
        }

        protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            if (DropDownList3.SelectedValue != "0")
            {
                postList.DataSource = Function.GetPostByStreet(conn, DropDownList3.SelectedValue, DropDownList5.SelectedValue, DropDownList4.SelectedValue, DropDownList6.SelectedValue, null);
                postList.DataBind();
            }
            else
            {
                if(DropDownList2.SelectedValue != "0")
                {
                    postList.DataSource = Function.GetPostByWard(conn, DropDownList2.SelectedValue, DropDownList5.SelectedValue, DropDownList4.SelectedValue, DropDownList6.SelectedValue, null);
                    postList.DataBind();
                }
                else
                {
                    if(DropDownList1.SelectedValue != "0")
                    {
                        postList.DataSource = Function.GetPostByDistrict(conn, DropDownList1.SelectedValue, DropDownList5.SelectedValue, DropDownList4.SelectedValue, DropDownList6.SelectedValue, null);
                        postList.DataBind();
                    }
                    else
                    {
                        postList.DataSource = Function.GetPostListForUser(conn, DropDownList5.SelectedValue, DropDownList4.SelectedValue, DropDownList6.SelectedValue, null);
                        postList.DataBind();
                    }
                }
            }
        }

        protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
        {
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            if (DropDownList3.SelectedValue != "0")
            {
                postList.DataSource = Function.GetPostByStreet(conn, DropDownList3.SelectedValue, DropDownList5.SelectedValue, DropDownList4.SelectedValue, DropDownList6.SelectedValue, null);
                postList.DataBind();
            }
            else
            {
                if (DropDownList2.SelectedValue != "0")
                {
                    postList.DataSource = Function.GetPostByWard(conn, DropDownList2.SelectedValue, DropDownList5.SelectedValue, DropDownList4.SelectedValue, DropDownList6.SelectedValue, null);
                    postList.DataBind();
                }
                else
                {
                    if (DropDownList1.SelectedValue != "0") //m nhìn thấy có 2 file giống tên nhau đúng k
                    {
                        postList.DataSource = Function.GetPostByDistrict(conn, DropDownList1.SelectedValue, DropDownList5.SelectedValue, DropDownList4.SelectedValue, DropDownList6.SelectedValue, null);
                        postList.DataBind();
                    }
                    else
                    {
                        postList.DataSource = Function.GetPostListForUser(conn, DropDownList5.SelectedValue, DropDownList4.SelectedValue, DropDownList6.SelectedValue, null);
                        postList.DataBind();
                    }
                }
            }
        }

        protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
        {
            string conn = System.Configuration.ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            if (DropDownList3.SelectedValue != "0")
            {
                postList.DataSource = Function.GetPostByStreet(conn, DropDownList3.SelectedValue, DropDownList5.SelectedValue, DropDownList4.SelectedValue, DropDownList6.SelectedValue, null);
                postList.DataBind();
            }
            else
            {
                if (DropDownList2.SelectedValue != "0")
                {
                    postList.DataSource = Function.GetPostByWard(conn, DropDownList2.SelectedValue, DropDownList5.SelectedValue, DropDownList4.SelectedValue, DropDownList6.SelectedValue, null);
                    postList.DataBind();
                }
                else
                {
                    if (DropDownList1.SelectedValue != "0")
                    {
                        postList.DataSource = Function.GetPostByDistrict(conn, DropDownList1.SelectedValue, DropDownList5.SelectedValue, DropDownList4.SelectedValue, DropDownList6.SelectedValue, null);
                        postList.DataBind();
                    }
                    else
                    {
                        postList.DataSource = Function.GetPostListForUser(conn, DropDownList5.SelectedValue, DropDownList4.SelectedValue, DropDownList6.SelectedValue, null);
                        postList.DataBind();
                    }
                }
            }
        }
    }
}