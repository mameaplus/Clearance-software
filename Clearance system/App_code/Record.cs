using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ClearanceSystem
{
    public class Record
    {
      public bool RecordForClear(DataItem di ,string from){
          using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Load"].ConnectionString))
          {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                if (from == "library")
              {
                  cmd.CommandText += "update [dbo].[BookLibrary] set Amount=Amount-1 where [BookId]='"+di.str3+"'; ";
                  cmd.CommandText += "insert into Library values(@TakerId,@postion,@BookID,@agreementCode,@Date,@ExpDate)";
                  cmd.Parameters.AddWithValue("@TakerId", di.str1);                  
                  cmd.Parameters.AddWithValue("@postion", di.str2);
                  cmd.Parameters.AddWithValue("@BookID", di.str3);
                  cmd.Parameters.AddWithValue("@agreementCode", di.str4);
                  cmd.Parameters.AddWithValue("@Date", di.str5);
                  cmd.Parameters.AddWithValue("@ExpDate", di.str6);
              }
              
              else if (from == "Procter")
                  cmd.CommandText = "insert into DistanceEdu values(@id,@Univ,@country)";
              else if (from == "Distance")
              {
                  cmd.CommandText = "insert into DistanceEdu values(@id,@Univ,@country)";
                  cmd.Parameters.AddWithValue("@id", di.str1);
                  cmd.Parameters.AddWithValue("@Univ", di.str2);
                  cmd.Parameters.AddWithValue("@country", di.str3);
              }
              else if (from == "Cafe")
              {
                  cmd.CommandText = "insert into studentCafe values(@id,@Case,@Date) ";
                  cmd.Parameters.AddWithValue("@id", di.str1);
                  cmd.Parameters.AddWithValue("@Case", di.str2);
                  cmd.Parameters.AddWithValue("@Date", di.str3);

              } 
              else if (from == "police")
              {
                  cmd.CommandText = "insert into police values(@id,@Case,@Date) ";
                  cmd.Parameters.AddWithValue("@id", di.str1);
                  cmd.Parameters.AddWithValue("@Case", di.str2);
                  cmd.Parameters.AddWithValue("@Date", di.str3);

              }
              else if (from == "CostSharing")
              {
                  cmd.CommandText = "insert into CostSharing values(@id,@Case)";
                  cmd.Parameters.AddWithValue("@id", di.str1);
                  cmd.Parameters.AddWithValue("@Case", di.str2);          

              }
              else if (from == "Academic")
              {
                  cmd.CommandText = "insert into AcademicDean values(@id,@Case,@Date) ";
                  cmd.Parameters.AddWithValue("@id", di.str1);
                  cmd.Parameters.AddWithValue("@Case", di.str2);
                  cmd.Parameters.AddWithValue("@Date", di.str3);

              }     
              //
         

                cmd.ExecuteNonQuery();     
               
            }
          return true;
               
            }
      public bool SportRecord( DataItem di)
      {
         //use try catch block
          using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Load"].ConnectionString))
          {
              con.Open();
              SqlCommand cmd = new SqlCommand();
              cmd.Connection = con;
              //count down number of material that taken by the student 
              cmd.CommandText = "update  [dbo].[SportMaterial] set amount=amount-" + di.str4 + " where MaterialID='" + di.str1 + "';";
              cmd.CommandText += "insert into SportMaster values(@amount,@TakerId,@postion,@sportMID,@acode,@date,@ExpDate)";
              cmd.Parameters.AddWithValue("@amount", di.str4);
              cmd.Parameters.AddWithValue("@TakerId", di.str2);
              cmd.Parameters.AddWithValue("@postion", di.str3);
              cmd.Parameters.AddWithValue("@sportMID", di.str1);
              cmd.Parameters.AddWithValue("@date", di.str5);
              cmd.Parameters.AddWithValue("@acode", "no");
              cmd.Parameters.AddWithValue("@ExpDate", di.str6);
              cmd.ExecuteNonQuery();
          }
          return true;
      }
          
    }
}