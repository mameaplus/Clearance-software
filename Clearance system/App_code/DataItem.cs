using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ClearanceSystem
{
    public class DataItem
    {
        public string str1, str2, str3, str4, str5, str6, str7, str8, str9, str10;
        public int num1, num2, num3,num4;
        public string faild;
        public string secc;
        public DataSet ds;
        public HtmlTable tbl,tbl2;
        public Table tbll;
        public string[] List = new string[10];
        public bool isOK, Bool;
        public int VerMaxCol, maxCol, RowMax;
        public string[] val = new string[10];
        public string[] RealColName = new string[3];
        public string[] VerColName = new string[1];
        public string[] Validator = new string[10];
        public string sqlCmdTxt;
        public DataItem di;
        public DataTable dt;
        public SqlCommand sqlcmd;
        
    }
}