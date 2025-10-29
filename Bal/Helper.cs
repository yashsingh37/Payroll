using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using System.Configuration;

namespace PayRoll_Practies_Exam_2.Bal
{
    public class Helper
    {
        public NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
    }
}