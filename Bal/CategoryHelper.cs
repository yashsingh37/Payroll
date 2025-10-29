using PayRoll_Practies_Exam_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;

namespace PayRoll_Practies_Exam_2.Bal
{
    public class CategoryHelper :Helper
    {
        public List<CategoryModel> GetAllCategory()
        {
            List<CategoryModel> catelist = new List<CategoryModel>();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Select * from t_categorytable";
            conn.Open();
            NpgsqlDataReader sdr = cmd.ExecuteReader();
            while(sdr.Read())
            {
                var cate = new CategoryModel();
                cate.c_categoryid = Convert.ToInt32(sdr["c_categoryid"]);
                cate.c_categoryname = sdr["c_categoryname"].ToString();
                catelist.Add(cate);
            }
            conn.Close();
            sdr.Close();
            return catelist;
        }
    }
}