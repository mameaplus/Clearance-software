using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ClearanceSystem
{
    public class Material
    {
        public DataItem LoadMaterial(string StudId, string from)
        {
            DataItem di;

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["load"].ConnectionString))
            {
                di = new DataItem();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                if (from == "Library")
                    cmd.CommandText = "Select BookLibrary.[Title] ,[dbo].[Library].BookID from BookLibrary INNER JOIN  [dbo].[Library] On BookLibrary.[BookID]=[Library].[BookId] where [Library].TakerId='" + StudId + "' and [BookLibrary].[staff]='l';";
                else if (from =="bookstore")
                        cmd.CommandText = "Select BookLibrary.[Title] ,[dbo].[Library].BookID from BookLibrary INNER JOIN  [dbo].[Library] On BookLibrary.[BookID]=[Library].[BookId] where  [Library].TakerId='" + StudId + "' and [BookLibrary].[staff]='B';";
                else if (from == "store")
                    cmd.CommandText = "select  [Quantity],[Name],[ID] from [dbo].[Store_Material]";
                else if (from == "BlockMaterial")
                    cmd.CommandText = "select [Name] ,[Quantity] ,[id] from [dbo].[BlockMaterial] where [BlockID]='" + StudId + "'";//use studid as blockid
                else if (from == "sportMaterial")
                    cmd.CommandText = "select  [Quantity],[Name],[ID] from [dbo].[StudSportMaterial]";
                di.ds = new DataSet();
                new SqlDataAdapter(cmd.CommandText, con).Fill(di.ds);
                //SqlDataAdapter da = new SqlDataAdapter(cmd.CommandText, con);
                //da.Fill(di.ds);

            }
            return di;
        }
        public DataItem LoadMaterialAll(DataItem di)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["load"].ConnectionString))
            {
                /*         
Select [dbo].[BlockMaterial].Name, [dbo].[BlockMaterial].[id] ,[dbo].[Student].Name ,[dbo].[Student].id from [dbo].[BlockMaterial]
inner join [dbo].[BlockMaterialTaker] on [dbo].[BlockMaterial].[id] =[dbo].[BlockMaterialTaker].[MaterialID]
inner join  [dbo].[Student] on [dbo].[BlockMaterialTaker].[TackerID]=[dbo].[Student].ID   and [dbo].[Student].DormNum='214' and
[dbo].[Student].[Block]='15'
          */
                //di = new DataItem();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                if (true)
                {
                    //di.str1 = StudID.Text;  di.str2 = DormNum.Text; di.str3 = "15";
                    cmd.CommandText = "Select [dbo].[BlockMaterial].Name as [MaterialName] , [dbo].[BlockMaterial].[id] ,[dbo].[Student].Name as StudentName ,[dbo].[Student].id from [dbo].[BlockMaterial]";
                    cmd.CommandText += " inner join [dbo].[BlockMaterialTaker] on [dbo].[BlockMaterial].[id] =[dbo].[BlockMaterialTaker].[MaterialID]";
                    cmd.CommandText += "inner join  [dbo].[Student] on [dbo].[BlockMaterialTaker].[TackerID]=[dbo].[Student].ID  ";
                    cmd.CommandText += "  and [dbo].[Student].[Block]='" + di.str3 + "' and [dbo].[Student].ID='" + di.str1 + "'";
                }
                di.ds = new DataSet();
                new SqlDataAdapter(cmd.CommandText, con).Fill(di.ds);
            }
            return di;
        }
        public DataItem Receive(string id, string ReceivItemid,string from )
        {
            DataItem di;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["load"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                //update  [dbo].[BookLibrary]  set Amount=Amount-1 where BookId='"+ReceivItemid+"'; delete from [Library] where bookid='Rec'
                if (from =="l")
                    cmd.CommandText = "update  [dbo].[BookLibrary]  set Amount=Amount+1 where    staff='l' and BookId='" + ReceivItemid + "';delete from [Library] where bookid='" + ReceivItemid + "' and TakerId='" + id + "' and staff='l'";
                else if (from=="b")
                    cmd.CommandText = "update  [dbo].[BookLibrary]  set Amount=Amount+1 where  staff='B' and  BookId='" + ReceivItemid + "';delete from [Library] where bookid='" + ReceivItemid + "' and TakerId='" + id + "' and staff='B'";
                cmd.ExecuteNonQuery();
            }
            return null;
        }
        public DataItem ReceiveAll(DataItem di)
        {

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["load"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                // di.str1 = StudID.Text; di.str2 = CheckBoxBookList.Items[i].Value.ToString(); 
                //update  [dbo].[BlockMaterial]  set [Quantity]=[Quantity]-1 where [BlockID]='15';
                if (di.str10 == "TakeBlockMaterial")
                    cmd.CommandText = "update  [dbo].[BlockMaterial]  set [Quantity]=[Quantity]-1 where [BlockID]='" + di.str1+"' and id='"+di.str2+"'";
                else
                    cmd.CommandText = "  Delete from [dbo].[BlockMaterialTaker] where [TackerID]=@TID and [MaterialID]=@MID";
                cmd.Parameters.AddWithValue("@TID", di.str1);
                cmd.Parameters.AddWithValue("@MID", di.str2);
                di.num1 = cmd.ExecuteNonQuery();
            }
            return di;
        }
    }

}
