using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ClearanceSystem
{
    public class Book
    {
       public Return FindBook(string BookID)
        {
            Return rtn=new Return();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["load"].ConnectionString))
            {
                
                SqlCommand cmd = new SqlCommand();
                DataSet ds = new DataSet();               
                con.Open();
                cmd.CommandText = "select title,amount from BookLibrary where BookID='" + BookID + "'";
               // cmd.Parameters.AddWithValue("@bookid", BookID);
                SqlDataAdapter da = new SqlDataAdapter(cmd.CommandText,con);
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