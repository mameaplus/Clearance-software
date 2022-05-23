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
        public bool RecordForClear(DataItem di, string from)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Load"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                if (from == "library")
                {
                    cmd.CommandText += "update [dbo].[BookLibrary] set Amount=Amount-1 where [BookId]='" + di.str3 + "' and  staff='l' and Amount>0;";//l stands for library
                    cmd.CommandText += "insert into Library values(@TakerId,@postion,@BookID,@agreementCode,@Date,@ExpDate,'l')";//l stands for library
                    cmd.Parameters.AddWithValue("@TakerId", di.str1);
                    cmd.Parameters.AddWithValue("@postion", di.str2);
                    cmd.Parameters.AddWithValue("@BookID", di.str3);
                    cmd.Parameters.AddWithValue("@agreementCode", di.str4);
                    cmd.Parameters.AddWithValue("@Date", di.str5);
                    cmd.Parameters.AddWithValue("@ExpDate", di.str6);
                }
                if (from == "Bookstore")
                {
                    cmd.CommandText += "update [dbo].[BookLibrary] set Amount=Amount-1 where [BookId]='" + di.str3 + "' and  staff='B' and Amount>0 ;";//B stands for bookstore
                    cmd.CommandText += "insert into Library values(@TakerId,@postion,@BookID,@agreementCode,@Date,@ExpDate,'B')";
                    cmd.Parameters.AddWithValue("@TakerId", di.str1);
                    cmd.Parameters.AddWithValue("@postion", di.str2);
                    cmd.Parameters.AddWithValue("@BookID", di.str3);
                    cmd.Parameters.AddWithValue("@agreementCode", di.str4);
                    cmd.Parameters.AddWithValue("@Date", di.str5);
                    cmd.Parameters.AddWithValue("@ExpDate", di.str6);
                }
                if (from == "EmpAccount")
                {

                    cmd.CommandText += "insert into  [dbo].[Account]([UserName],[password],[StaffId]) values(@uname,@pass,@postion)";
                    cmd.Parameters.AddWithValue("@uname", di.str1);
                    cmd.Parameters.AddWithValue("@pass", di.str2);
                    cmd.Parameters.AddWithValue("@postion", di.str3);
                    
                }
                //EmpAccount
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
                //stateaccount
                else if (from == "stateaccount")
                {

                    if(di.str2=="enable")
                        cmd.CommandText = "update [dbo].[User]  set [IsClear]=1 where  [username]=@uname";
                    if (di.str2 == "disable")
                        cmd.CommandText = "update [dbo].[User]  set [IsClear]=0 where  [username]=@uname";
                    cmd.Parameters.AddWithValue("@uname", di.str1);
                  

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
                else if (from == "store")
                {
                    if (di.str4 == "update")
                    {
                        cmd.CommandText = "update [dbo].[Store_Material] set [Quantity]=[Quantity]+" + di.str3 + " where  ID=" + di.num1 + "";
                        //cmd.Parameters.AddWithValue("@MID" + di.str5, di.num1);
                        //cmd.Parameters.AddWithValue("@quantity"+di.str5, di.str3);
                    }
                    else
                    {
                        cmd.CommandText += "delete from [dbo].[Refer] where [dbo].[Refer].[id]='" + di.str1 + "'  and [To]='F'; ";
                        cmd.CommandText += "update [dbo].[Store_Material] set [Quantity]=[Quantity]-@quantity where  ID=@MID ";
                        cmd.CommandText += "insert into [dbo].[StoreCaseRecord] values(@id,@MID,@quantity,GETDATE())";
                        cmd.Parameters.AddWithValue("@id", di.str1);
                        cmd.Parameters.AddWithValue("@quantity", di.str3);
                        cmd.Parameters.AddWithValue("@MID", di.str2);
                    }
                }
                else if (from == "sportmaterail")
                {
                    cmd.CommandText = "update [dbo].[StudSportMaterial] set [Quantity]=[Quantity]-@quantity where  ID=@MID ; ";
                    cmd.CommandText += "insert into [dbo].[SportMaster](TakerId,SportMaterialID,amount,Date,postion,AgreeCode) values(@id,@MID,@quantity,GETDATE(),'student',@acode)";
                    cmd.Parameters.AddWithValue("@id", di.str1);
                    cmd.Parameters.AddWithValue("@quantity", di.str2);
                    cmd.Parameters.AddWithValue("@MID", di.str3);
                    cmd.Parameters.AddWithValue("@acode", di.str4);
                }
                else if (from == "BlockMaterialRecord")
                {
                    cmd.CommandText = "insert into AcademicDean values(@id,@Case,@Date) ";
                    cmd.Parameters.AddWithValue("@id", di.str1);
                    cmd.Parameters.AddWithValue("@Case", di.str2);
                    cmd.Parameters.AddWithValue("@Date", di.str3);

                }
                if (from == "updateQuantity")//update BLOCK MATRIAL QUANTITY
                {
                    cmd.CommandText = "  update [dbo].[BlockMaterial] set [Quantity]=[Quantity]+@quantity" + di.str5 + "  where [id]=@MID" + di.str5 + "  and [BlockID]=@Bid" + di.str5 + "";
                    cmd.Parameters.AddWithValue("@quantity" + di.str5, di.str1);
                    cmd.Parameters.AddWithValue("@MID" + di.str5, di.str2);
                    cmd.Parameters.AddWithValue("@Bid" + di.str5, di.str3);
                }
                else if (from == "updateBlockMaterial")
                {
                    if(di.str10=="up")
                    cmd.CommandText = " update [dbo].[BlockMaterial] set [Quantity]=[Quantity]+@quantity  where [id]=@MID  and [BlockID]=@Bid;";
                    else if (di.str10 == "down")
                        cmd.CommandText = " update [dbo].[BlockMaterial] set [Quantity]=[Quantity]-@quantity  where [id]=@MID  and [BlockID]=@Bid;";
                    cmd.Parameters.AddWithValue("@quantity", "1");
                    cmd.Parameters.AddWithValue("@MID", di.str2);
                    cmd.Parameters.AddWithValue("@Bid", di.str1);
                }  
                else if (from == "BlockMaterialTaker")
                {
                    cmd.CommandText = "insert into [dbo].[BlockMaterialTaker] values(@sid,@mid,@block)";
                    cmd.Parameters.AddWithValue("@sid", di.str4);
                    cmd.Parameters.AddWithValue("@mid", di.str2);      
                    cmd.Parameters.AddWithValue("@block", di.str1);  
                }    
                else if (from == "RecordBlockMaterial")
                {
                    cmd.CommandText = "insert into [dbo].[BlockMaterial] values(@NAME,GETDATE(),@Quantity,@BlockId)";
                    cmd.Parameters.AddWithValue("@NAME", di.str1);
                    cmd.Parameters.AddWithValue("@Quantity", di.str2);
                    cmd.Parameters.AddWithValue("@BlockId", di.str3);
                }      //
                else if ("Refer" == from)
                {
                    cmd.CommandText = "insert into [KiotDBClear].[dbo].[Refer](id,[to],Credit,reson,[date]) ";
                    cmd.CommandText += "values(@id,@to,@credit,@reson,GETDATE());";
                    cmd.Parameters.AddWithValue("@id", di.str1);
                    cmd.Parameters.AddWithValue("@to", di.str2);
                    cmd.Parameters.AddWithValue("@credit", di.str3);
                    cmd.Parameters.AddWithValue("@reson", di.str4);

                }
                else if ("referTostore" == from)
                {
                    cmd.CommandText = "insert into[dbo].[Refer]( [ID],[To],[Date]) values(@id,@to,GETDATE()); ";
                    cmd.Parameters.AddWithValue("@id", di.str1);
                    cmd.Parameters.AddWithValue("@to", di.str2);


                }
                else if ("RegisterVcode" == from)
                {
                    if (di.str3 == "30")
                    {
                        cmd.CommandText = " update [dbo].[Student] set [VCode]=@vcode  where  email=@email";
                        cmd.Parameters.AddWithValue("@vcode", di.str2);
                        cmd.Parameters.AddWithValue("@email", di.str1);
                    }
                    else if (di.str3 == "40")
                    {
                        cmd.CommandText = " update [dbo].[Employee] set [VCode]=@vcode  where  email=@email";
                        cmd.Parameters.AddWithValue("@vcode", di.str2);
                        cmd.Parameters.AddWithValue("@email", di.str1);
                    }

                }
                else if ("createacc" == from)
                {
                    cmd.CommandText = "insert into [dbo].[User]([Id],[postion],[username],[password],[IsClear]) values(@id,@postion,@username,@password,'1');";
                    cmd.Parameters.AddWithValue("@username", di.str1);
                    cmd.Parameters.AddWithValue("@postion", di.str3);
                    cmd.Parameters.AddWithValue("@password", di.str4);
                    cmd.Parameters.AddWithValue("@id", di.str5);
                }
                else if (from == "Finance")
                {//di.str4
                    cmd.CommandText = "delete from [dbo].[Refer] where [dbo].[Refer].[id]=@takerId and caseid=@caseid  and [To]='store'; ";
                    cmd.CommandText += "INSERT INTO [dbo].[Finance] VALUES(@takerId,@Credit,@Reason,GETDATE());";
                    cmd.Parameters.AddWithValue("@takerId", di.str1);
                    cmd.Parameters.AddWithValue("@Credit", di.str2);
                    cmd.Parameters.AddWithValue("@Reason", di.str3);
                    cmd.Parameters.AddWithValue("@caseid", di.str4);

                }
                else if (from == "Saving")
                {

                    cmd.CommandText = "insert into [dbo].[SavingCreditA] values(@takerId,@Credit,@Reason,GETDATE())";
                    cmd.Parameters.AddWithValue("@takerId", di.str1);
                    cmd.Parameters.AddWithValue("@Credit", di.str2);
                    cmd.Parameters.AddWithValue("@Reason", di.str3);

                }
                else if (from == "StudRegister")
                {
 
                    cmd.CommandText = "insert into [dbo].[Student]([ID],[Name],[Dep],[Block],[DormNum],[Email],[PhoneNum])values(@id,@name,@dep,@block,@dormnum,@email,@phone)";
                    cmd.Parameters.AddWithValue("@id", di.str2);
                    cmd.Parameters.AddWithValue("@name", di.str1);
                    cmd.Parameters.AddWithValue("@dep", di.str3);
                    cmd.Parameters.AddWithValue("@block", di.str6);
                    cmd.Parameters.AddWithValue("@dormnum", di.str7);
                    cmd.Parameters.AddWithValue("@email", di.str5);
                    cmd.Parameters.AddWithValue("@phone", di.str4);

                }
                else if (from == "admin")
                {
                    if (di.str1 == "clearance")
                    {
                        cmd.CommandText = "update [KiotDBClear].[dbo].[Service] set [statuse]=@updatestatuse where [Name]='clear' and [statuse]=@condstatuse ";
                        cmd.Parameters.AddWithValue("@updatestatuse", di.str2);
                        cmd.Parameters.AddWithValue("@condstatuse", di.str3);                        
                    }

                }
                ////insert into [dbo].[SavingCreditA] values('','','',GETDATE())
                cmd.ExecuteNonQuery();

            }
            return true;

        }
        public bool SportRecord(DataItem di)
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