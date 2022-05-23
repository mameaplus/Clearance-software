using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace ClearanceSystem
{
    public class Case
    {
        public DataItem ignoreCase(DataItem di)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Load"].ConnectionString))
            {
                con.Open();              
                di.sqlcmd.Connection = con;
              di.str1= di.sqlcmd.ExecuteNonQuery().ToString();
            }
            return di;
        }
        public DataItem LoadCase(DataItem diLoad)
        {
            DataItem di = new DataItem();
            di.ds = new System.Data.DataSet();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Load"].ConnectionString))
            {
                con.Open();
                //diLoad.sqlcmd.CommandText
                SqlDataAdapter da = new SqlDataAdapter(diLoad.sqlcmd.CommandText, con);
                da.Fill(di.ds);
                if (di.ds.Tables[0].Rows.Count > 0)
                {
                    di.Bool = true;
                }
                else
                    di.Bool = false;
            }
            return di;
        }

    }
}