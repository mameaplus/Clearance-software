using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
namespace ClearanceSystem
{
    public class Account
    {
        public DataItem login(DataItem di)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["load"].ConnectionString))
            {
                string staffid = di.str3;
                using (SqlCommand cmd = new SqlCommand())
                {
                    con.Open();
                    cmd.CommandText = "select top 17  *  from [dbo].[Account]  where CONVERT(VARCHAR,[UserName]) =@username and CONVERT(VARCHAR,[password])=@password and  [StaffId]=@staffid";
                    cmd.Parameters.AddWithValue("@username", di.str1);
                    cmd.Parameters.AddWithValue("@password", di.str2);
                    cmd.Parameters.AddWithValue("@staffid", di.str3);
                    cmd.Connection = con;
                    di.Bool = false;
                    if (cmd.ExecuteReader().HasRows)
                    {
                        di.ds = new DataSet();
                        con.Close();
                        con.Open();
                        cmd.CommandText = "select  [Page] from [KiotDBClear].[dbo].[Signature] where id='" + staffid + "'";
                        cmd.Parameters.AddWithValue("@id", staffid);
                        new SqlDataAdapter(cmd.CommandText, con).Fill(di.ds);
                        di.Bool = true;

                    }
                }
            }
            return di;
        }
        public DataItem UserLogin(DataItem di)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["load"].ConnectionString))
            {
                string staffid = di.str3;
                using (SqlCommand cmd = new SqlCommand())
                {
                    con.Open();
                    cmd.CommandText = "select  [Id],[postion],[IsClear]  from [dbo].[User] where CONVERT(VARCHAR, [password])=@password and [username]=@username and [postion]=@postion and [IsClear] =1";
                    cmd.Parameters.AddWithValue("@username", di.str1);
                    cmd.Parameters.AddWithValue("@password", di.str2);
                    cmd.Parameters.AddWithValue("@postion", di.str3);
                    cmd.Connection = con;
                    di.Bool = false;
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        string id = rdr[0] as string;

                        di.ds = new DataSet();
                        con.Close();
                        con.Open();
                        SqlCommand cmd1 = new SqlCommand();
                        if (di.str3 == "30" || di.str3 == "40")
                        {
                            if (di.str3 == "30")
                                cmd1.CommandText = "SELECT  [ID] , [Dep],[Block],[DormNum],[Photo],[Name] FROM [KiotDBClear].[dbo].[Student] where [ID]='" + id + "'";
                            else if (di.str3 == "40")
                                cmd1.CommandText = "SELECT   [ID] ,[Photo],[Departement] ,[FName],[MName] FROM [KiotDBClear].[dbo].[Employee] where[ID]='" + id + "'";
                            new SqlDataAdapter(cmd1.CommandText, con).Fill(di.ds);
                        
                        }
                        else
                        {

                        }
                       
                        di.Bool = true;
                    }
                }
            }
            return di;
        }
        public DataItem loadDropDownList()
        {
            DataItem di = new DataItem();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["load"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = " select  [StaffName],[id] ,[page]from [KiotDBClear].[dbo].[Signature]";
                    cmd.Connection = con;
                    con.Open();
                    di.ds = new DataSet();
                    new SqlDataAdapter(cmd.CommandText, con).Fill(di.ds);
                }
            }
            return di;
        }
        public DataItem createAccount(DataItem di)
        {

            if (new Student().LoadDetail(di, "checkpass").Bool)
            {
                new Record().RecordForClear(di, "createacc");
                di.Bool = true;
            }
            else
            {
                di.Bool = false;
                di.str10 = "Invalid Verification code and email";
            }
            return di;
        }
        public Boolean checkEntity(DataItem di)
        {

            return new ClearanceSystem.Student().LoadDetail(di, "checkpass").Bool;
        }

    }

}