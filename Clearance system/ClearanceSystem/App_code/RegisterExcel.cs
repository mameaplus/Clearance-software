using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace ClearanceSystem
{
    public class RegisterExcel
    {
        public DataItem ReadAll(DataItem di)
        {

            DataItem d = new DataItem();
            DataTable dt = di.dt;
            d.str3 = di.ds.Tables[0].Rows.Count + "";
            //dt.Clear();
            d.dt = dt; int good = 0; int notGoodexist = 0, notGoodInvalid = 0;
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["Load"].ConnectionString.ToString()))
                {
                    SqlCommand cmd = new SqlCommand();
                    sqlcon.Open();
                    cmd.Connection = sqlcon;
                    int sqlCount = 0;
                    for (int y = 0; y < di.ds.Tables[0].Rows.Count; y++)
                    {
                        string cmdString = "";
                        for (int cmdstr = 0; cmdstr < di.ds.Tables[0].Columns.Count; cmdstr++)
                        {
                            if (cmdstr == 0)
                                cmdString += "@" + di.RealColName[cmdstr] + sqlCount;
                            else
                                cmdString += ",@" + di.RealColName[cmdstr] + sqlCount;
                        }
                        cmdString += ")";

                        cmd.CommandText = di.sqlCmdTxt + cmdString;//half from other class we get and the last we get from cmdstring
                        d.str3 = cmd.CommandText;
                        bool lastBool = true;
                        d.str10 = cmd.CommandText;

                        for (int x = 0; x < di.ds.Tables[0].Columns.Count; x++)
                        {
                            cmd.Parameters.AddWithValue(di.RealColName[x] + y, (string)di.ds.Tables[0].Rows[y][x]);
                         
                            if (ColIsValid((string)di.ds.Tables[0].Rows[y][x], di.Validator[x]))//Validate ColmData with respect to its validator
                            {
                                //set the maximum colomun in the registration di.num1=max_col
                                for (int findcol = 0; findcol < di.num4; findcol++)
                                {
                                    if (di.RealColName[x] == di.VerColName[findcol])
                                    {
                                        DataItem di0 = ColDataIsExist(sqlcon, "" + (string)di.ds.Tables[0].Rows[y][x], di.RealColName[x], di.str1);
                                        if (!di0.Bool)
                                        {
                                            lastBool = false;
                                            notGoodexist++;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                lastBool = false; notGoodInvalid++;
                            }
                        }

                        //Registration makeing in the next instration or code
                        if (lastBool)//execute the valid rows
                        {
                          
                            cmd.ExecuteNonQuery();
                            good++;
                        }
                        else
                        {
                            // dt.Rows.Add(cell0, cell1, cell2, cell3, cell4, cell5, cell6);
                            if (di.ColNumber == 7)
                                dt.Rows.Add(di.ds.Tables[0].Rows[y][0], di.ds.Tables[0].Rows[y][1], di.ds.Tables[0].Rows[y][2], di.ds.Tables[0].Rows[y][3], di.ds.Tables[0].Rows[y][4], di.ds.Tables[0].Rows[y][5], di.ds.Tables[0].Rows[y][6]);
                            if (di.ColNumber == 9)
                                dt.Rows.Add(di.ds.Tables[0].Rows[y][0], di.ds.Tables[0].Rows[y][1], di.ds.Tables[0].Rows[y][2], di.ds.Tables[0].Rows[y][3], di.ds.Tables[0].Rows[y][4], di.ds.Tables[0].Rows[y][5], di.ds.Tables[0].Rows[y][6], di.ds.Tables[0].Rows[y][7], di.ds.Tables[0].Rows[y][8]);
                            if (di.ColNumber != 9 && di.ColNumber != 7)
                                dt.Rows.Add(di.ds.Tables[0].Rows[y][0], di.ds.Tables[0].Rows[y][1], di.ds.Tables[0].Rows[y][2]);

                        }
                        sqlCount++;
                    }
                }
            }
            catch (Exception ex){ 
            
            }
            d.num1 = good;
            d.num2 = notGoodexist;
            d.num3 = notGoodInvalid;
            d.dt = dt;
            return d;
        }
        public bool ColIsValid(string colData, string validater)
        {

            bool rtn = false;
            if (Regex.IsMatch((string)colData, validater))
            {
                rtn = true;
            }
            else
            {
                rtn = false;
            }
            return rtn;
        }
        public DataItem ColDataIsExist(SqlConnection con, string ColData, string ColName, string tblName)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                DataItem di = new DataItem();
                di.Bool = true;
                cmd.CommandText = "select count (*) from  " + tblName + "  where  " +ColName + " = @colData";
                cmd.Parameters.AddWithValue("@colData", ColData);
                cmd.Connection = con;
                di.str1 = ColName;
                int val = (int)cmd.ExecuteScalar();
                if (val != 0)
                    di.Bool = false;
                di.str2 = cmd.CommandText;
                return di;
            }
        }
    }
}