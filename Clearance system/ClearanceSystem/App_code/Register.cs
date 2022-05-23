/***************************************************************************************************
 * This Script  is Developed  by Muhammed Abdurahman For reading an excel file                                        *
 * we can send validator for each table columen in order to validated and the other is we can                       *
 * check the existency of the data from previosly data                                                                                      *
 *  Register().excelRead(fileLocation, VerMaxCol,RealMaxCol, val, RealColName, VerColName, "");                    *
 *  >fileLocation      ::: is the path of the excle file                                                                                               *
 *  >VerMaxCol        ::: is the maximum of the columen to be checked for excistancy                                      *
 *  >RealMaxCol      ::: is the maximum columen number of the sql datatable                                                  *
 *  >val                       ::: is the validator for each columen                                                                                *
 *  >RealColName   ::: is the column name of the sqlDataTable                                                                         *
 *  >VerColName    ::: is  the Vertual columen name of the sqlDataTable                                                          *
 ***************************************************************************************************/
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
    public class Register
    {
        public DataItem excelRead(string fileLocation, int VerMaxCol, int maxCol, string[] val, string[] RealColName, string[] VerColName, string sqlCmdTxt, int start, int RowMax, HtmlForm form,string tblName)
        {
            DataItem conf = new DataItem();
            conf.VerMaxCol = VerMaxCol;
            conf.maxCol = maxCol;
            conf.val = val;
            conf.RealColName = RealColName;
            conf.VerColName = VerColName;
            conf.sqlCmdTxt = sqlCmdTxt;
            conf.str10 = tblName;
            using (OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\""))
            {
                con.Open();
                DataTable dt = new DataTable();
                dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string sheetname = (string)dt.Rows[0]["TABLE_NAME"];
                OleDbDataAdapter da = new OleDbDataAdapter("select * from [" + sheetname + "]", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                conf.ds = ds;
                conf.RowMax = ds.Tables[0].Rows.Count;
                int ColMax = ds.Tables[0].Columns.Count;
                conf.isOK = true;
                if (ColMax != maxCol)//check number of columns
                {
                    conf.isOK = false;
                    conf.faild = "invalid column  number";
                }
                else
                {
                    DataItem di = ReadAll(ds, conf, null, start, RowMax, form);
                }
                //     check(form, ds);
                //  ReadAll(ds, conf, null, RowMax, form);
            }
            return conf;
        }
        public DataItem ReadAll(DataSet ds, DataItem conf, Table tblsrc, int start, int RowMax, HtmlForm form)
        {
            using (SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["Load"].ConnectionString.ToString()))
            {
                SqlCommand cmd = new SqlCommand();
                sqlcon.Open();
                cmd.Connection = sqlcon;
                string ColmData = "";
                int good = 0; int colm = 0;
                int i = 0; int last = 0;
                bool end = false;
                Table tbl = new  Table();
                if (tblsrc == null)
                    RowMax = conf.RowMax;
                int TbCount = 0; int sqlCount = 0;
                for (int y = start; y < RowMax; y++)
                {
                    string cmdString = "";
                    for (int cmdstr = 0; cmdstr < 4; cmdstr++)
                    {
                        if (cmdstr == 0)
                            cmdString += "@" + conf.RealColName[cmdstr] + sqlCount;
                        else
                            cmdString += ",@" + conf.RealColName[cmdstr] + sqlCount;
                    }
                    cmdString += ")";
                    conf.str4 = cmdString;
                    conf.str5 = "" + conf.VerColName.Length;
                    cmd.CommandText = conf.sqlCmdTxt + cmdString;
                    bool lastBool = true;
                    colm = 0;
                    TextBox tb = null;
                    for (int x = 0; x < conf.maxCol; x++)
                    {
                        if (tblsrc != null)
                        {
                            tb = ((TextBox)form.FindControl("tb" + TbCount + x));
                            ColmData = tb.Text;
                        }
                        else
                            ColmData = (string)ds.Tables[0].Rows[y][x]; //if the datasource is dataset
                        cmd.Parameters.AddWithValue("@col" + x + y, ColmData);
                        if (ColIsValid(ColmData, conf.val[x]))//j is the col number
                        {
                            for (int findcol = 0; findcol < conf.VerMaxCol; findcol++)
                            {
                                if (conf.RealColName[x] == conf.VerColName[findcol])
                                {
                                    DataItem di = ColDataIsExist(sqlcon, "" + ColmData, conf.RealColName[x],conf.str10);
                                    if (!di.Bool)
                                    {
                                        lastBool = false;
                                    }
                                }
                            }
                        }
                        else
                        {
                            lastBool = false;
                        }
                        colm = y;
                    }
                    if (lastBool)//execute the valid rows
                    {
                        last = good++;//count valid row that not recored as invalid row
                        cmd.ExecuteNonQuery();
                        if (tblsrc != null)
                        {
                            tblsrc.Rows.Remove(tblsrc.Rows[y]);
                            y--;
                            RowMax--;
                            if (tblsrc.Rows.Count < RowMax)
                                RowMax = tblsrc.Rows.Count;
                        }
                       // if the row is valid that come from table src then delete the row form the table and assign to session table
                    }
                    else
                    {
                        colm = y;
                        y = y - good;
                        if (tblsrc != null)
                        {
                            for (int j = 0; j < conf.maxCol; j++)
                            {
                                TextBox tbx = (TextBox)form.FindControl("tb" + TbCount + j);
                                ////  CELL.InnerText = ColmData + "append";
                                tbx.Text = ColmData + "append";
                                //   tblsrc.Rows[y].Cells[j].InnerText = ColmData;
                            }
                            // tb.Text = ColmData;
                        }
                        else
                        {
                         TableRow row = new  TableRow();
                            for (int j = 0; j < conf.maxCol; j++)
                            {
                                TableCell cell = new  TableCell();
                                // tb = (TextBox)form.FindControl("tb" + i + j);
                                //   tb.Text = (string)ds.Tables[0].Rows[colm][j];
                                cell.ID = "cell" + i + j;////?????
                                cell.Text = ColmData;
                                row.Controls.Add(cell);
                            }
                            tbl.Controls.Add(row);
                            i++;
                        }
                        y = colm;
                        conf.num2 = colm;
                        conf.str6 = conf.RowMax + "";
                        conf.str7 = y + "";
                    }
                    TbCount++;    
                    sqlCount++;      
                }
                conf.num4 = last;
                conf.num3 = tbl.Rows.Count;
                conf.num1 = i;
                conf.tbll = tbl;
                //conf.tbl2 = tblsrc;
            }
            return conf;
        }
        //columen data validation
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
            //get postion
            return rtn;
        }
        public DataItem ColDataIsExist(SqlConnection con, string ColData, string ColName, string tblName)
        {
            //select coldata from the table 
            using (SqlCommand cmd = new SqlCommand())
            {
                DataItem di = new DataItem();
                di.Bool = true;
                cmd.CommandText = "select count (*) from tbl1"  + " where  " + ColName + " = @colData";
                cmd.Parameters.AddWithValue("@colData", ColData);
                cmd.Connection = con;
                di.str1 = ColName;
                int val = (int)cmd.ExecuteScalar();
                if (val != 0)
                    di.Bool = false;
                return di;

            }

        }
        public TextBox check(int y, int x, string data, HtmlForm form)
        {
            TextBox tb = (TextBox)form.FindControl("tb" + y + x);
            tb.Text = data;
            return tb;
        }
        public DataItem LoadToTextBox(int Current, int terminator, Table tbl, HtmlForm form, bool IsNext, bool isRegister)
        {
            //current state //table  //
            DataItem di = new DataItem();
            int first = 0, last = 0;
            if (isRegister)
            {
                first = 0;
                last = 10;
            }
            else
            {
                if (IsNext)
                {
                    first = Current + 10;
                    last = first + 10;
                }
                else
                {
                    first = Current - 10;
                    last = Current;
                }
            }
            int tmp = last;
            if (terminator < 10)
                last = terminator;
            if (terminator < last)
                last = terminator;
            int tbint = 0;
            for (int i = first; i < last; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    ((TableRow)form.FindControl("row" + tbint)).Visible = true;
                    TextBox tb = (TextBox)form.FindControl("tb" + tbint + j);
                    tb.Text = tbl.Rows[i].Cells[j].Text + tbint + j;
                }
                tbint++;
            }

            di.num2 = tbint;
            if (tbint < 10)
            {
                for (; tbint < 10; )
                {
                    ((TableRow)form.FindControl("row" + tbint)).Visible = false;
                    tbint++;
                }
                //in case of visiblity it will hide all the an wanted tbl rows
            }
            di.num1 = first;
            return di;
        }
    }
}
