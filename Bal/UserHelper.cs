using Npgsql;
using PayRoll_Practies_Exam_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace PayRoll_Practies_Exam_2.Bal
{
    public class UserHelper : Helper
    {
        public void Register(tblUser user)
        {
            NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO t_user(c_username, c_email, c_gender, c_password) VALUES(@c_username, @c_email, @c_gender, @c_password);", conn);

            cmd.Parameters.AddWithValue("@c_username", user.c_username);
            cmd.Parameters.AddWithValue("@c_email", user.c_email);
            cmd.Parameters.AddWithValue("@c_gender", user.c_gender);
            cmd.Parameters.AddWithValue("@c_password", user.c_password);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public bool Login(tblLogin user)
        {
            bool isUserAuthenticated = false;
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM t_user WHERE c_email = @c_email AND c_password = @c_password;", conn);

            cmd.Parameters.AddWithValue("@c_email", user.Email);
            cmd.Parameters.AddWithValue("@c_password", user.Password);
            conn.Open();
            NpgsqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                HttpContext.Current.Session["username"] = dr["c_username"].ToString();
                HttpContext.Current.Session["userid"] = dr["c_userid"].ToString();
                isUserAuthenticated = true;
            }
            else
            {
                isUserAuthenticated = false;
            }
            dr.Close();
            conn.Close();
            return isUserAuthenticated;
        }

        public bool EmailExists(string email)
        {
            bool isExists = false;
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM t_user WHERE c_email = @c_email;", conn);

            cmd.Parameters.AddWithValue("@c_email", email);
            conn.Open();
            NpgsqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                isExists = true;
            }
            else
            {
                isExists = false;
            }
            dr.Close();
            conn.Close();
            return isExists;
        }

        public bool ValidatePassword(string password)
        {
            var passwordRegex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{3,}$");
            return passwordRegex.IsMatch(password);
        }
        }
    }