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
                    cmd.CommandText = "Select BookLibrary.[Title] ,[dbo].[Library].BookID from BookLibrary INNER JOIN  [dbo].[Library] On BookLibrary.[BookID]=[Library].[BookId] and [Library].TakerId='"+StudId+"';";
                di.ds = new DataSet();
                new SqlDataAdapter(cmd.CommandText, con).Fill(di.ds);
                //SqlDataAdapter da = new SqlDataAdapter(cmd.CommandText, con);
                //da.Fill(di.ds);

            }
            return di;
        }
        public DataItem Receive(string id, string ReceivItemid)
        {
            DataItem di;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["load"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                //update  [dbo].[BookLibrary]  set Amount=Amount-1 where BookId='"+ReceivItemid+"'; delete from [Library] where bookid='Rec'
                cmd.CommandText = "update  [dbo].[BookLibrary]  set Amount=Amount+1 where BookId='" + ReceivItemid + "';delete from [Library] where bookid='" + ReceivItemid + "'";
                cmd.ExecuteNonQuery();
            }
            return null;
        }
    }
}