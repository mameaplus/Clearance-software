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
                //   di.str1 = StudID.Text;  di.str2 = DormNum.Text; di.str3 = "15";
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                //  cmd.CommandText = "select * from Student where id='" + di.str1 + "'";
                if (Who == "sportMaster" || Who == "Library")
                    cmd.CommandText = "select * from Student where id='" + di.str1 + "'";
                else if(Who=="AD")
                    cmd.CommandText = "SELECT *  FROM [KiotDBClear].[dbo].[AcademicDean] where [ID]='" + di.str3 + "'";
                else if (Who == "Procter")
                    cmd.CommandText = "select id ,name,photo from Student where Block='" + di.str3 + "'  and id='" + di.str1 + "'";
                else if (Who == "Employee")
                    cmd.CommandText = "select  Fname,Lname,Departement,AcademicR,photo ,Email,PhoneNum from Employee  where id='" + di.str1 + "'";
                else if (Who == "Cafe" || Who == "CostSharing" || Who == "police" || Who == "Academic")
                    cmd.CommandText = "select  [Name] ,[Dep] , [Photo] from Student where id='" + di.str1 + "'";
                else if (Who == "CreateAccount")
                    cmd.CommandText = "select count(Email) from student where Email='" + di.str1 + "'";
                else if (Who == "ReceiveBook") ;
                //cmd.Parameters.AddWithValue("@id", TextBox1.Text);
                else if (Who == "B")
                    cmd.CommandText = "SELECT * FROM [dbo].[Library]  WHERE staff='B' and  [ExpDate] <= GETDATE() order by [ExpDate] ";
                else if (Who == "l")
                    cmd.CommandText = "SELECT * FROM [dbo].[Library]  WHERE staff='l' and  [ExpDate] <= GETDATE() order by [ExpDate] ";
                else if (Who == "BlockStud")
                    cmd.CommandText = "SELECT [Name],[DormNum],[Photo] FROM [KiotDBClear].[dbo].[Student] where [ID]='" + di.str1 + "' and [Block]='" + di.str2 + "'";
                // cmd.CommandText = " SELECT * FROM [dbo].[Library] WHERE  [ExpDate]='" + DateTime.Now.ToShortDateString() + "' or [ExpDate] < '" + DateTime.Now.ToShortDateString() + "' order by [ExpDate] ";
                else if (Who == "refer")
                    cmd.CommandText = "   select [dbo].[Employee].[ID], [dbo].[Employee].[FName],[dbo].[Employee].[MName],[dbo].[Employee].[AcademicR],[dbo].[Employee].[Photo],[dbo].[Refer].[date] from [dbo].[Employee]  inner join  [dbo].[Refer] on [dbo].[Refer].[StudentId]=[dbo].[Employee].ID where [dbo].[Refer].[to]='"+di.str1+"' ";
                else if (Who == "All")
                {
                    //testing for sendgin sms   
                    cmd.CommandText = "SELECT TOP 8 [ID] ,[Name],[Dep],[Block],[DormNum] ,[Photo],[Email] ,[PhoneNum] FROM [KiotDBClear].[dbo].[Student]";
                }
                else if ("StudEmail" == Who)
                {
                    if(di.str3=="30")
                        cmd.CommandText = "select email ,ID, PhoneNum from [dbo].[Student] where email='" + di.str1 + "'";
                    else if (di.str3 == "40")
                        cmd.CommandText = "select email,ID,PhoneNum  from [dbo].[Employee] where email='" + di.str1 + "'";
                }

                else if ("checkpass" == Who)
                {
                    if(di.str3=="30")
                        cmd.CommandText = "  select count(Email) from [dbo].[Student] where CONVERT(varchar, email )='"+di.str1+"' and CONVERT(varchar,vCode)='"+di.str2+"'";
                    else if(di.str3=="40")
                        cmd.CommandText = "  select count(Email) from [dbo].[Employee] where CONVERT(varchar, email )='" + di.str1 + "' and CONVERT(varchar,vCode)='" + di.str2 + "'";
                }
                else if ("clearState" == Who)
                {
                    cmd.CommandText = "  select [Name] from [dbo].[Service] where [Name]='clear' and [statuse]=1 ";
                    
                }

                else if ("studempaccount" == Who)
                {
                    if (di.str3== "30")
                        cmd.CommandText = "SELECT  [Photo],[Dep],[Email],[Name] FROM [KiotDBClear].[dbo].[Student] where [ID]='" + di.str1 + "'";
                     else if (di.str3 == "40")
                        cmd.CommandText = "SELECT  [Photo],[Departement],[Email],CONCAT([FName],' ',[MName],' ',[LName]) as fullname FROM [KiotDBClear].[dbo].[Employee] where [ID]='" + di.str1 + "'";
             
                }            
               
                //  SELECT [UserName],[password],[status] FROM [KiotDBClear].[dbo].[Account] where [StaffId]='20'
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