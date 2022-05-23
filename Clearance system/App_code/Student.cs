using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ClearanceSystem
{
    public class Student
    {


        public Return LoadDetail(DataItem di, String Who)
        {
            Return rtn = new Return();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["load"].ConnectionString))
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                //  cmd.CommandText = "select * from Student where id='" + di.str1 + "'";
                if (Who == "sportMaster" || Who == "Library")
                    cmd.CommandText = "select * from Student where id='" + di.str1 + "'";
                else if (Who == "Procter")
                    cmd.CommandText = "select id ,name,photo from Student where Block='" + di.str1 + "' and DormNum='" + di.str2 + "'";
                else if (Who == "Employee")
                    cmd.CommandText = "select  Fname,Lname,Departement,AcademicR,photo ,Email from Employee  where id='" + di.str1 + "'";
                else if (Who == "Cafe" || Who == "CostSharing" || Who == "police" || Who == "Academic")
                    cmd.CommandText = "select  [Name] ,[Dep] , [Photo] from Student where id='" + di.str1 + "'";
                else if (Who == "CreateAccount")
                    cmd.CommandText = "select count(Email) from student where Email='" + di.str1 + "'";
                else if (Who == "ReceiveBook") ;
                //cmd.Parameters.AddWithValue("@id", TextBox1.Text);
                else if (Who == "DateLoad")
                    cmd.CommandText = "  SELECT * FROM [dbo].[Library]  WHERE [ExpDate] <= GETDATE() order by [ExpDate] ";
               // cmd.CommandText = " SELECT * FROM [dbo].[Library] WHERE  [ExpDate]='" + DateTime.Now.ToShortDateString() + "' or [ExpDate] < '" + DateTime.Now.ToShortDateString() + "' order by [ExpDate] ";
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd.CommandText, con);
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    rtn.ds = ds;
                    rtn.Bool = true;
                }
                else
                    rtn.Bool = false;
            }
            return rtn;
        }


    }
}