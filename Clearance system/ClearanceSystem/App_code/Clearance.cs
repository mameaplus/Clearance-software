using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ClearanceSystem
{
    public class Clearance
    {
        public DataItem LoadUncleared(DataItem di)
        {

            DataSet ds = new DataSet();
            string[] cmdlist = new string[10]; int cmdlistlast = 0;
            cmdlist[0] = "select * from [dbo].[Signature] where (select COUNT( [dbo].[Library].TakerId) as [Library]  from [dbo].[Library]where  [dbo].[Library].TakerId='" + di.str3 + "' and  [dbo].[Library].[staff]='B' and postion='Emp')='0' and [dbo].[Signature].id='14' ;";
            cmdlist[1] = "";
            cmdlist[2] = "";
            cmdlist[3] = "";
            cmdlist[4] = "";
            cmdlistlast = 3;
            for (int i = 0; i < cmdlistlast; i++)
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["load"].ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        new SqlDataAdapter(cmdlist[i], con).Fill(ds, "Library");
                        di.ds = ds;
                    }
                    con.Close();
                }
            }
            return di;
        }
        public DataItem checkclearness(DataItem di)
        {
            DataSet ds = new DataSet();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["load"].ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {            
                    cmd.CommandText = "select id,StaffName,sign from [dbo].[Signature] where (select count(*) from Student where ID= '"+di.str3+"' and Dep='IT')>=0 and [dbo].[Signature].id='16';";//this for now we have to change
                    cmd.CommandText += "select * from [dbo].[Signature] where (select COUNT( [dbo].[Library].TakerId) as [Library]  from [dbo].[Library]where  [dbo].[Library].TakerId='" + di.str3 + "' and  [dbo].[Library].[staff]='l' )='0' and [dbo].[Signature].id='1';";
                    cmd.CommandText += "select * from [dbo].[Signature] where (select COUNT( [dbo].[Library].TakerId) as [Library]  from [dbo].[Library]where  [dbo].[Library].TakerId='" + di.str3 + "' and  [dbo].[Library].[staff]='B' and postion='student')='0' and [dbo].[Signature].id='14';";
                    cmd.CommandText += "select * from [dbo].[Signature] where  (select  COUNT( [dbo].[SportMaster].[TakerId]) as [SportMaster]from [dbo].[SportMaster] where [dbo].[SportMaster].[TakerId]='" + di.str3 + "') ='0'and [dbo].[Signature].id='10';";
                    cmd.CommandText += "select * from [dbo].[Signature] where (select  COUNT( [dbo].[StudentCafe].[ID]) as [StudentCafe]from [dbo].[StudentCafe] where [dbo].[StudentCafe].[ID]='" + di.str3 + "')='0' and [dbo].[Signature].id='11';";
                    cmd.CommandText += "select * from [dbo].[Signature] where( select count(1) from [KiotDBClear].[dbo].[BlockMaterialTaker] where  [TackerID]='" + di.str3 + "')='0' and [dbo].[Signature].id='4';";
                    cmd.CommandText += "select id,StaffName,sign from [dbo].[Signature] where (select count(*) from [dbo].[AcademicDean] where [ID]='" + di.str3 + "')>0 and [dbo].[Signature].id='6';";
                    cmd.CommandText += "select * from [dbo].[Signature] where (select  COUNT( [dbo].[police].[ID]) as [police] from [dbo].[police] where [dbo].[police].[ID]='" + di.str3 + "')='0' and [dbo].[Signature].id='7';";
                    cmd.CommandText += "select * from [dbo].[Signature] where (select  COUNT( [dbo].[CostSharing].[id]) as [CostSharing] from [dbo].[CostSharing] where [dbo].[CostSharing].[id]='" + di.str3 + "')='0' and [dbo].[Signature].id='8';";
                    cmd.Parameters.Add("@id", SqlDbType.VarChar, 40, di.str3);

                 

                    new SqlDataAdapter(cmd.CommandText, con).Fill(ds);
                    di.ds = ds;
                }
                con.Close();
            }


            return di;
        }

 
        public DataItem checkclearnessEmployee(DataItem di)
        {
            DataSet ds = new DataSet();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["load"].ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {                  

                    cmd.CommandText = " select * from [dbo].[Signature] where (select count([Id])from  [dbo].[Finance] where id='"+di.str1+"')='0' and [dbo].[Signature].id='15';;";
                    cmd.CommandText += "select * from [dbo].[Signature] where (select count( [dbo].[Library].TakerId) as [Library]  from [dbo].[Library]where  [dbo].[Library].TakerId='" + di.str1 + "'  and  [dbo].[Library].[staff]='l' )='0' and [dbo].[Signature].id='1';";
                    cmd.CommandText += "select * from [dbo].[Signature] where (select count([TakerId]) from [dbo].[StoreCaseRecord]where [TakerId]='" + di.str1 + "' )='0' and [dbo].[Signature].id='5';";
                    cmd.CommandText += "select * from [dbo].[Signature] where (select count([ID]) as ID from [dbo].[SavingCreditA] where[ID]='" + di.str1 + "' )='0' and [dbo].[Signature].id='3';;";
                    new SqlDataAdapter(cmd.CommandText, con).Fill(ds);
                    di.ds = ds;
                }
                con.Close();
            }


            return di;
        }

        public DataItem GetUncleared(DataItem di)
        {

            DataSet ds = new DataSet();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["load"].ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    new SqlDataAdapter(di.str1, con).Fill(ds);
                    di.ds = ds;
                }
                con.Close();
            }

            return di;
        }
    }
}