using Npgsql;
using PayRoll_Practies_Exam_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayRoll_Practies_Exam_2.Bal
{
    public class EmployeeHelper : Helper
    {
        public List<EmployeModel> GetAll()
        {
            List<EmployeModel> employeelist = new List<EmployeModel>();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Select e.c_empid,c_empname,e.c_gender,e.c_hiredate,e.c_categoryid,e.c_salary,c.c_categoryname from t_payroll e join t_categorytable c on e.c_categoryid = c.c_categoryid";
            conn.Open();
            NpgsqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                var emp = new EmployeModel();
                emp.c_empid = Convert.ToInt32(sdr["c_empid"]);
                emp.c_empname = sdr["c_empname"].ToString();
                emp.c_gender = sdr["c_gender"].ToString();
                emp.c_hiredate = sdr["c_hiredate"].ToString();
                emp.c_salary = Convert.ToInt32(sdr["c_salary"]);
                emp.c_categoryid = Convert.ToInt32(sdr["c_categoryid"]);
                emp.c_categoryname = sdr["c_categoryname"].ToString();
                employeelist.Add(emp);
            }
            conn.Close();
            sdr.Close();
            return employeelist;
        }

        public EmployeModel GetOne(int id)
        {
            var emp = new EmployeModel();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Select e.c_empid,c_empname,e.c_gender,e.c_hiredate,e.c_categoryid,e.c_salary,c.c_categoryname from t_payroll e join t_categorytable c on e.c_categoryid = c.c_categoryid Where c_empid =@c_empid";
            cmd.Parameters.AddWithValue("c_empid", id);
            conn.Open();
            NpgsqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                emp.c_empid = Convert.ToInt32(sdr["c_empid"]);
                emp.c_empname = sdr["c_empname"].ToString();
                emp.c_gender = sdr["c_gender"].ToString();
                emp.c_hiredate = sdr["c_hiredate"].ToString();
                emp.c_salary = Convert.ToInt32(sdr["c_salary"]);
                emp.c_categoryid = Convert.ToInt32(sdr["c_categoryid"]);
                emp.c_categoryname = sdr["c_categoryname"].ToString();
            }
            conn.Close();
            sdr.Close();
            return emp;
        }


        public bool Add(EmployeModel emp)
        {
            bool isadd = false;
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "INSERT INTO t_payroll(c_empname,c_gender,c_hiredate,c_salary,c_categoryid) VALUES(@c_empname,@c_gender,@c_hiredate,@c_salary,@c_categoryid)";
            cmd.Parameters.AddWithValue("@c_empname", emp.c_empname);
            cmd.Parameters.AddWithValue("@c_gender", emp.c_gender);
            cmd.Parameters.AddWithValue("@c_hiredate", emp.c_hiredate);
            cmd.Parameters.AddWithValue("@c_salary", emp.c_salary);
            cmd.Parameters.AddWithValue("@c_categoryid", emp.c_categoryid);
            conn.Open();
            int n = cmd.ExecuteNonQuery();
            if (n > 0)
            {
                isadd = true;
            }
            conn.Close();
            return isadd;

        }

        public bool Edit(EmployeModel emp)
        {
            bool isadd = false;
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "UPDATE t_payroll SET c_empname =  @c_empname,c_gender = @c_gender,c_hiredate = @c_hiredate,c_salary = @c_salary,c_categoryid = @c_categoryid WHERE c_empid = @c_empid";
            cmd.Parameters.AddWithValue("c_empid",emp.c_empid);
            cmd.Parameters.AddWithValue("c_empname", emp.c_empname);
            cmd.Parameters.AddWithValue("c_gender", emp.c_gender);
            cmd.Parameters.AddWithValue("c_hiredate", emp.c_hiredate);
            cmd.Parameters.AddWithValue("c_salary", emp.c_salary);
            cmd.Parameters.AddWithValue("c_categoryid", emp.c_categoryid);
            conn.Open();
            int n = cmd.ExecuteNonQuery();
            if(n > 0)
            {
                isadd = true;
            }
            conn.Close();
            return isadd;

        }
        public bool Delete(EmployeModel emp)
        {
            bool isadd = false;
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Delete From t_payroll  WHERE c_empid = @c_empid";
            cmd.Parameters.AddWithValue("@c_empid",emp.c_empid );
            conn.Open();
            int n = cmd.ExecuteNonQuery();
            if (n > 0)
            {
                isadd = true;
            }
            conn.Close();
            return isadd;

        }

        public EmployeModel GetOnePayRoll(int id)
        {
            var emp = new EmployeModel();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Select * from t_payroll c_empid =@c_empid";
            conn.Open();
            cmd.Parameters.AddWithValue("c_empid", id);
            NpgsqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                emp.c_empid = Convert.ToInt32(sdr["c_empid"]);
                emp.c_salary = Convert.ToInt32(sdr["c_salary"]); 
                emp.c_tax = Convert.ToInt32(sdr["c_tax"]);
                emp.c_hra = Convert.ToInt32(sdr["c_hra"]);
                emp.c_basic = Convert.ToInt32(sdr["c_basic"]);
                emp.c_taxable = Convert.ToInt32(sdr["c_taxable"]);
                emp.c_da = Convert.ToInt32(sdr["c_da"]);
                emp.c_takehome = Convert.ToInt32(sdr["c_takehome"]);
            }
            conn.Close();
            sdr.Close();
            return emp;
        }

        public bool UpdatePayroll(EmployeModel employee)
        {
            bool isupdate = false;
            employee.c_basic = (employee.c_salary * 60) / 100;
            employee.c_da = (employee.c_salary * 25) / 100;
            employee.c_hra = (employee.c_salary * 15) / 100;

            if (employee.c_salary > 25000)
            {
                employee.c_taxable = employee.c_salary - 25000;
                employee.c_tax = (employee.c_taxable * 10) / 100; 
            }
            else
            {
                employee.c_taxable = 0;
                employee.c_tax = 0;
            }

            employee.c_takehome = employee.c_basic + employee.c_da + employee.c_hra - employee.c_tax;

            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "update t_payroll set c_basic =  @c_basic , c_da = @c_da , c_hra =  @c_hra , c_taxable = @c_taxable , c_tax= @c_tax ,c_takehome=@c_takehome  where c_empid = @c_empid";
            cmd.Parameters.AddWithValue("@c_empid", employee.c_empid);
            cmd.Parameters.AddWithValue("@c_basic", employee.c_basic);
            cmd.Parameters.AddWithValue("@c_da", employee.c_da);
            cmd.Parameters.AddWithValue("@c_hra", employee.c_hra);          
            cmd.Parameters.AddWithValue("@c_taxable", employee.c_taxable);
            cmd.Parameters.AddWithValue("@c_tax", employee.c_tax);
            cmd.Parameters.AddWithValue("@c_takehome", employee.c_takehome);


            conn.Open();
            int n = cmd.ExecuteNonQuery();
            if (n > 0)
            {
                isupdate = true;
            }
            conn.Close();
            return isupdate;
        }

    }
}