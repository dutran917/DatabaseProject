using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace WebBusiness
{
    public static class Function
    {
        public static DataTable ValidAuthentication(string conn, string username, string password)
        {
            string cmd = "SELECT user_role FROM public.users WHERE user_account = '" + username + "' AND user_password = '" + password + "'";
            DataTable tbl = SqlData.ExeNpSqlToTable(cmd, conn);

            if(tbl.Rows.Count != 0)
            {
                UpdateLogIn(conn, username);
            }

            return tbl;
        }

        private static void UpdateLogIn(string conn, string username)
        {
            string cmd = "UPDATE public.users SET user_lastseen = now() WHERE user_account = '" + username + "'";
            SqlData.ExeNpSqlCmd(cmd, conn);
        }
        public static DataTable GetPostListForAdmin(string conn, List<string> orderBy, string order, string state, string approve)
        {
            StringBuilder sb = new StringBuilder();
            string approve_cmd;
            foreach(string s in orderBy)
            {
                if(sb.Length > 0)
                {
                    sb.Append(',');
                }
                sb.Append(s);
            }
            string listOfOrder = sb.ToString(); ;
            if(state == "2")
            {
                state = "(post_restricted = 0 OR post_restricted = 1)";
            }
            else
            {
                state = "(post_restricted = " + state + ")";
            }

            if(approve == "Pending")
            {
                approve_cmd = " post_approve = false AND ";
            }
            else
            {
                if (approve == "Approve")
                {
                    approve_cmd = " post_approve = true AND ";
                }
                else
                {
                    approve_cmd = " (post_approve = true OR post_approve = false) AND ";
                }
            }
            string cmd = "SELECT * FROM public.post WHERE " + approve_cmd + state + " ORDER BY (" + listOfOrder + ") " + order;

            return SqlData.ExeNpSqlToTable(cmd, conn);
        }

        public static DataTable GetPostListForUser(string conn, string price, string area, string type, string user_id)
        {
            string price_cmd;
            string area_cmd;
            string type_cmd;
            if (price == "-1")
            {
                price_cmd = " post_price > -1 ";
            }
            else
            {
                if(price == "10")
                {
                    price_cmd = " post_price >= 10 ";
                }
                else
                {
                    price_cmd = " post_price >= (" + price + " - 1) AND post_price <= (" + price + " + 1) ";
                }
            }

            if(area == "-1")
            {
                area_cmd = " post_area > -1 ";
            }
            else
            {
                if(area == "100")
                {
                    area_cmd = " post_area >= 100 ";
                }
                else
                {
                    area_cmd = " post_area >= (" + area + " - 10) AND post_area <= (" + area + " + 10) ";
                }
            }

            if(type == "-1")
            {
                type_cmd = " (post_type = 'Chung cư' OR post_type = 'Thổ cư') ";
            }
            else
            {
                type_cmd = " post_type = '" + type + "' ";
            }
            if (user_id != null)
                user_id = " AND public.post.user_id = " + user_id;
            string cmd = "SELECT * FROM public.post, public.users WHERE public.post.post_approve = true " + user_id + " AND public.post.user_id = public.users.user_id AND" + price_cmd + "AND" + area_cmd + "AND" + type_cmd + "ORDER BY (user_subscription) DESC";
            //return cmd;
            return SqlData.ExeNpSqlToTable(cmd, conn);
        }

        public static DataTable GetPostDetail(string conn, string post_id)
        {
            string cmd = "UPDATE public.post SET post_view = post_view + 1 WHERE post_id = " + post_id;
            SqlData.ExeNpSqlCmd(cmd, conn);
            cmd = "SELECT * FROM public.post WHERE post_id = '" + post_id + "'";
            return SqlData.ExeNpSqlToTable(cmd, conn);
        }

        public static DataTable GetAddress(string conn, string street_id)
        {
            string cmd = "SELECT a.district_id, b.ward_id FROM public.district AS a INNER JOIN public.ward AS b ON a.district_id = b.district_id INNER JOIN public.street AS c ON b.ward_id = c.ward_id WHERE c.street_id = " + street_id;
            return SqlData.ExeNpSqlToTable(cmd, conn);
        }
        public static DataTable GetTopViewPost(string conn)
        {
            string cmd = "WITH tmp AS (SELECT * FROM public.post WHERE post_view != 0 ORDER BY(post_view) DESC) SELECT* FROM tmp, public.users WHERE tmp.post_approve = true AND tmp.user_id = public.users.user_id ORDER BY(user_subscription, post_view) DESC limit 5";
            return SqlData.ExeNpSqlToTable(cmd, conn);
        }

        public static DataTable GetRecentPost(string conn, string user_id)
        {
            string cmd = "SELECT * FROM public.post AS post RIGHT JOIN (SELECT * FROM public.history WHERE user_id = " + user_id + ") AS history ON post.post_id = history.post_id ORDER BY (visit_time) DESC LIMIT 5";
            return SqlData.ExeNpSqlToTable(cmd, conn);
        }

        public static DataTable GetPostByUser(string conn, string user_id, List<string> orderBy, string order, string state, string approve)
        {
            StringBuilder sb = new StringBuilder();
            string approve_cmd;
            foreach (string s in orderBy)
            {
                if (sb.Length > 0)
                {
                    sb.Append(',');
                }
                sb.Append(s);
            }
            string listOfOrder = sb.ToString(); ;
            if (state == "2")
            {
                state = "(post_restricted = 0 OR post_restricted = 1)";
            }
            else
            {
                state = "(post_restricted = " + state + ")";
            }

            if (approve == "Pending")
            {
                approve_cmd = " post_approve = false AND ";
            }
            else
            {
                if (approve == "Approve")
                {
                    approve_cmd = " post_approve = true AND ";
                }
                else
                {
                    approve_cmd = " (post_approve = true OR post_approve = false) AND ";
                }
            }


            string cmd = "SELECT * FROM public.post WHERE user_id = " + user_id + " AND " + approve_cmd + state + " ORDER BY (" + listOfOrder + ") " + order;
            //return cmd;
            return SqlData.ExeNpSqlToTable(cmd, conn);
        }

        public static DataTable GetDistrict(string conn)
        {
            string cmd = "SELECT * FROM public.district";
            return SqlData.ExeNpSqlToTable(cmd, conn);
        }

        public static DataTable GetWard(string conn, string district_id)
        {
            string cmd = "SELECT * FROM public.ward WHERE district_id = '" + district_id + "'";
            return SqlData.ExeNpSqlToTable(cmd, conn);
        }

        public static DataTable GetStreet(string conn, string ward_id)
        {
            string cmd = "SELECT * FROM public.street WHERE ward_id = '" + ward_id + "'";
            return SqlData.ExeNpSqlToTable(cmd, conn);
        }

        public static DataTable GetUserList(string conn)
        {
            string cmd = "SELECT user_id, user_name, user_lastseen AS lastseen, user_posts FROM public.users WHERE user_role = 2 ORDER BY (user_id) ASC";
            return SqlData.ExeNpSqlToTable(cmd, conn);
        }

        public static List<string> GetUserInfor(string conn, string user_id)
        {
            List<string> result = new List<string>();
            string cmd = "SELECT EXTRACT(DAY FROM user_dob) AS day FROM public.users WHERE user_id = '" + user_id + "'";
            result.Add(SqlData.ExeNpSqlToTable(cmd, conn).Rows[0]["day"].ToString());
            cmd = "SELECT EXTRACT(MONTH FROM user_dob) AS month FROM public.users WHERE user_id = '" + user_id + "'";
            result.Add(SqlData.ExeNpSqlToTable(cmd, conn).Rows[0]["month"].ToString());
            cmd = "SELECT EXTRACT(YEAR FROM user_dob) AS year FROM public.users WHERE user_id = '" + user_id + "'";
            result.Add(SqlData.ExeNpSqlToTable(cmd, conn).Rows[0]["year"].ToString());
            cmd = "SELECT * FROM public.users WHERE user_id = '" + user_id + "'";
            using (DataTable tbl = SqlData.ExeNpSqlToTable(cmd, conn))
            {
                result.Add(tbl.Rows[0]["user_name"].ToString());
                result.Add(tbl.Rows[0]["user_password"].ToString());
                result.Add(tbl.Rows[0]["user_address"].ToString());
                result.Add(tbl.Rows[0]["user_phonenumber"].ToString());
                result.Add(tbl.Rows[0]["user_subscription"].ToString());
                result.Add(tbl.Rows[0]["user_identify"].ToString());
            }

            return result;
        }

        public static DataTable GetPostByStreet(string conn, string street_id, string price, string area, string type, string user_id)
        {
            string price_cmd;
            string area_cmd;
            string type_cmd;

            if (price == "-1")
            {
                price_cmd = " post_price > -1 ";
            }
            else
            {
                if (price == "10")
                {
                    price_cmd = " post_price >= 10 ";
                }
                else
                {
                    price_cmd = " post_price >= (" + price + " - 1) AND post_price <= (" + price + " + 1) ";
                }
            }

            if (area == "-1")
            {
                area_cmd = " post_area > -1 ";
            }
            else
            {
                if (area == "100")
                {
                    area_cmd = " post_area >= 100 ";
                }
                else
                {
                    area_cmd = " post_area >= (" + area + " - 10) AND post_area <= (" + area + " + 10) ";
                }
            }

            if (type == "-1")
            {
                type_cmd = " (post_type = 'Chung cư' OR post_type = 'Thổ cư') ";
            }
            else
            {
                type_cmd = " post_type = '" + type + "' ";
            }
            if (user_id != null)
                user_id = " AND p.user_id = " + user_id;
            else
                user_id = "";
            string cmd = "SELECT p.* FROM public.post AS p,public.street AS s, public.users AS u WHERE u.user_id = p.user_id AND s.street_id = " + street_id + " " + user_id + " AND s.street_id = p.post_address AND" + area_cmd + "AND" + price_cmd + "AND" + type_cmd + " ORDER BY (u.user_subscription) DESC";
            //return cmd;
            return SqlData.ExeNpSqlToTable(cmd, conn);
        }

        public static DataTable GetPostByWard(string conn, string ward_id, string price, string area, string type, string user_id)
        {
            string price_cmd;
            string area_cmd;
            string type_cmd;

            if (price == "-1")
            {
                price_cmd = " post_price > -1 ";
            }
            else
            {
                
                if (price == "10")
                {
                    price_cmd = " post_price >= 10 ";
                }
                else
                {
                    if (price == "1")
                        price_cmd = " post_price < 1 ";
                    else
                        price_cmd = " post_price >= (" + price + " - 1) AND post_price <= (" + price + " + 1) ";
                }
            }

            if (area == "-1")
            {
                area_cmd = " post_area > -1 ";
            }
            else
            {
                if (area == "100")
                {
                    area_cmd = " post_area >= 100 ";
                }
                else
                {
                    if (area == "20")
                        area_cmd = " post_area < 20 ";
                    else
                        area_cmd = " post_area >= (" + area + " - 10) AND post_area <= (" + area + " + 10) ";
                }
            }

            if (type == "-1")
            {
                type_cmd = " (post_type = 'Chung cư' OR post_type = 'Thổ cư') ";
            }
            else
            {
                type_cmd = " post_type = '" + type + "' ";
            }
            if (user_id != null)
                user_id = " AND p.user_id = " + user_id;
            else
                user_id = "";
            string cmd = "SELECT p.* FROM public.post AS p,public.street AS s,public.ward AS w, public.users AS u WHERE u.user_id = p.user_id AND w.ward_id = " + ward_id + " " + user_id + " and w.ward_id = s.ward_id and s.street_id = p.post_address AND" + area_cmd + "AND" + price_cmd + "AND" + type_cmd + " ORDER BY (u.user_subscription) DESC";
            //return cmd;
            return SqlData.ExeNpSqlToTable(cmd, conn);
        }

        public static DataTable GetPostByDistrict(string conn, string district_id, string price, string area, string type, string user_id)
        {
            string price_cmd;
            string area_cmd;
            string type_cmd;
            if (price == "-1")
            {
                price_cmd = " post_price > -1 ";
            }
            else
            {
                if (price == "10")
                {
                    price_cmd = " post_price >= 10 ";
                }
                else
                {
                    price_cmd = " post_price >= (" + price + " - 1) AND post_price <= (" + price + " + 1) ";
                }
            }

            if (area == "-1")
            {
                area_cmd = " post_area > -1 ";
            }
            else
            {
                if (area == "100")
                {
                    area_cmd = " post_area >= 100 ";
                }
                else
                {
                    area_cmd = " post_area >= (" + area + " - 10) AND post_area <= (" + area + " + 10) ";
                }
            }

            if (type == "-1")
            {
                type_cmd = " (post_type = 'Chung cư' OR post_type = 'Thổ cư') ";
            }
            else
            {
                type_cmd = " post_type = '" + type + "' ";
            }
            if (user_id != null)
                user_id = " AND p.user_id = " + user_id;
            else
                user_id = "";
            string cmd = "SELECT p.* FROM public.post AS p,public.district AS d,public.street AS s,public.ward AS w, public.users AS u WHERE u.user_id = p.user_id AND d.district_id = " + district_id + " " + user_id + " and d.district_id = w.district_id and w.ward_id = s.ward_id and p.post_address = s.street_id AND" + area_cmd + "AND" + price_cmd + "AND" + type_cmd + " ORDER BY (u.user_subscription) DESC";
            //return cmd;
            return SqlData.ExeNpSqlToTable(cmd, conn);
        }

        public static string GetUserId(string conn, string username)
        {
            string cmd = "SELECT user_id FROM public.users WHERE user_account = '" + username + "'";
            string res = "";
            DataTable tbl = SqlData.ExeNpSqlToTable(cmd, conn);

            foreach (DataRow r in tbl.Rows)
            {
                res = r["user_id"].ToString();
            }
            return res;
        }
        public static int NewPost(string conn, List<string> input)
        {
            if(Avalable(conn, input[0]))
            {
                string insert = "INSERT INTO public.post (user_id, post_area, post_address, post_price, post_direction, post_floors, post_type, post_detail, post_restricted, post_header, post_image, post_view) VALUES ";
                string values = "";

                foreach (string s in input)
                {
                    if (values.Length > 0)
                    {
                        values += ", ";
                    }
                    values += "'" + s + "'";
                }

                values = "(" + values + ", 0)";

                string cmd = insert + values;

                SqlData.ExeNpSqlToTable(cmd, conn);
                return 1;
            }
            else
            {
                return 0;
            }
            
        }

        public static void UpdateUserInfor(string conn, List<string> input, string user_id)
        {
            string cmd = "UPDATE public.users SET user_name = '" + input[0] + "', user_address = '" + input[1] + "', user_dob = '" + input[2] + "', user_phonenumber = '" + input[3] + "', user_subscription = '" + input[4] + "', user_password = '" + input[5] + "' WHERE user_id = '" + user_id + "'";
            SqlData.ExeNpSqlCmd(cmd, conn);
        }

        public static void UserRegister(string conn, List<string> input)
        {
            string Dob = input[4] + "/" + input[5] + "/" + input[6];
            //string cmd1 = "CALL register('" + input[0] + "', '" + input[1] + "', '" + input[2] + "', '" + input[3] + "', '" + Dob + "', '" + input[7] + "', '" + input[8] + "', '" + input[9] + "', CURRENT_DATE)";
            string values = "'" + input[0] + "', '" + input[1] + "', '" + input[2] + "', '" + input[3] + "', '" + Dob + "', '" + input[7] + "', '" + input[8] + "', " + input[9] + ", CURRENT_DATE" + ", false, 2, 0";
            string cmd = "INSERT INTO public.users (user_account, user_password, user_name, user_address, user_dob, user_identify, user_phonenumber, user_subscription, user_lastseen, user_drop, user_role, user_posts) VALUES (" + values + ")";
            SqlData.ExeNpSqlCmd(cmd, conn);

            //return cmd;
        }

        public static void UpdateHistory(string conn, string post_id, string user_id)
        {
            string cmd = "INSERT INTO public.history VALUES (" + user_id + ", " + post_id + ", CURRENT_TIME)";
            SqlData.ExeNpSqlCmd(cmd, conn);
        }

        public static void ApprovePost(string conn, string post_id, string post_approve)
        {
            string cmd = "UPDATE public.post SET post_approve = " + post_approve + " WHERE post_id = " + post_id;
            SqlData.ExeNpSqlCmd(cmd, conn);
        }

        public static void RemovePost(string conn, string post_id)
        {
            string cmd = "DELETE FROM public.history WHERE post_id = " + post_id;
            SqlData.ExeNpSqlCmd(cmd, conn);
            cmd = "DELETE FROM public.post WHERE post_id = " + post_id;
            SqlData.ExeNpSqlCmd(cmd, conn);

            //return "DELETE FROM public.history WHERE post_id = " + post_id + " " + "DELETE FROM public.post WHERE post_id = " + post_id;
        }

        public static void EditPost(string conn, string post_id, List<string> input)
        {
            string cmd = "UPDATE public.post SET post_header = '" + input[0] + "', post_image = '" + input[1] + "', post_detail = '" + input[2] + "', post_area = " + input[3] + ", post_price = (SELECT TO_NUMBER('" + input[4] + "', 'FM9G999D99S')), post_address = " + input[5] + ", post_direction = " + input[6] + ", post_floors = " + input[7] + ", post_type = '" + input[8] + "', post_restricted = " + input[9] + ", post_approve = false, post_time = CURRENT_DATE WHERE post_id = " + post_id;
            SqlData.ExeNpSqlCmd(cmd, conn);
            //return cmd;
        }

        public static void RemoveMember(string conn, string user_id)
        {
            string cmd = "DELETE FROM public.history WHERE user_id = " + user_id;
            SqlData.ExeNpSqlCmd(cmd, conn);
            cmd = "DELETE FROM public.history AS h WHERE h.post_id IN (SELECT post_id FROM public.post WHERE user_id = " + user_id + ")";
            SqlData.ExeNpSqlCmd(cmd, conn);

            cmd = "DELETE FROM public.post WHERE user_id = " + user_id;
            SqlData.ExeNpSqlCmd(cmd, conn);

            cmd = "DELETE FROM public.users WHERE user_id = " + user_id;
            SqlData.ExeNpSqlCmd(cmd, conn);
            //return cmd;
        }

        public static string GetMess(string conn, string user_id)
        {
            string cmd = "SELECT noti FROM public.notifications WHERE user_id = " + user_id;
            DataTable tbl = SqlData.ExeNpSqlToTable(cmd, conn);
            if(tbl.Rows.Count != 0)
                return tbl.Rows[0]["noti"].ToString();
            else
            {
                return "";
            }
        }

        private static bool Avalable(string conn, string user_id)
        {
            string cmd1 = "SELECT user_posts FROM public.users WHERE user_id = " + user_id;
            string cmd2 = "SELECT subscription_limited FROM public.users, public.user_subscription WHERE user_subscription = subscription_id AND user_id = " + user_id;
            int x = Convert.ToInt32(SqlData.ExeNpSqlToTable(cmd1, conn).Rows[0]["user_posts"].ToString());
            int y = Convert.ToInt32(SqlData.ExeNpSqlToTable(cmd2, conn).Rows[0]["subscription_limited"].ToString());
            
            return x < y;
        }
    }
}
