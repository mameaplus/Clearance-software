using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
namespace ClearanceSystem
{
    public partial class Registrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Table tbl = new Table();
            tbl.ID = "table";
            for (int i = 0; i < 10; i++)
            {
                TableRow row = new TableRow();
                row.ID = "row" + i;
                for (int j = 0; j < 4; j++)
                {
                   TableCell cell = new TableCell();
                    //cell.BgColor = "#5bc0de";
                    cell.ID = "cell" + i + j;
                    TextBox tb = new TextBox();
                    tb.ID = "tb" + i + j;
                    tb.Text = "tb" + i + j;
                    cell.Controls.Add(tb);
                    row.Controls.Add(cell);
                }
                tbl.Controls.Add(row);
            }

            form1.Controls.Add(tbl);
        }
        protected void ExcelRegist_Click(object sender, EventArgs e)
        {
            ViewState["count"] = 0;
            string fileLocation = Server.MapPath("~/Excel/excelOne.xlsx");
            string[] val = new string[10];
            //the validator comes from another class or method
            val[0] = "^[a-zA-Z'.]{1,40}$"; val[1] = "^[a-zA-Z'.]{1,40}$"; val[2] = "^[a-zA-Z'.]{1,40}$"; val[3] = "^[a-zA-Z'.]{1,40}$";
            val[4] = "^[a-zA-Z'.]{1,40}$"; val[5] = "^[a-zA-Z'.]{1,40}$"; val[6] = "^[a-zA-Z'.]{1,40}$";
            string[] RealColName = new string[10];
            RealColName[0] = "col0";
            RealColName[1] = "col1";
            RealColName[2] = "col2";
            RealColName[3] = "col3";
            ViewState["Num2"] = 4;
            string[] VerColName = new string[10];
            //VerColName[0] = "col0";
            //VerColName[0] = "col3";
            VerColName[0] = "col1";
            VerColName[1] = "col3";
            ViewState["val"] = val;
            ViewState["RealColName"] = RealColName;
            ViewState["VerColName"] = VerColName;
            int VerMaxCol = 2;
            string sqlCmdTxt = "insert into  tbl1(col0,col1,col2,col3)  values(";
            string tblName = "tbl1";
            DataItem di = new Register().excelRead(fileLocation, VerMaxCol, (int)ViewState["Num2"], val, RealColName, VerColName, sqlCmdTxt, 0, 0, form1,tblName);
            Session["tableRtn"] = di.tbl;
            GridView2.Controls.Add(di.tbll); 
            //GridView2.DataBind();

            //  form1.Controls.Add((HtmlTable)Session["tableRtn"]);
            //  Response.Write( di.tbl.Rows[0].Cells[0].InnerText);
            ViewState["start"] = di.num2;
            ViewState["Terminal"] = (int)di.num1;
            ViewState["Current"] = new Register().LoadToTextBox(0, (int)ViewState["Terminal"], (Table)Session["tableRtn"], form1, false, true).num1;
            Response.Write(di.str4);
            Response.Write(di.str10);
            Response.Write(di.str1);
            Response.Write(di.num2 + "");
            Response.Write("Terminal :" + ViewState["Terminal"] + "");
            Session["start"] = di.num2;
            Session["di"] = di;
            form1.Controls.Add((HtmlTable)Session["tableRtn"]);

            if (di.isOK)//colum number is valid
            {
                //Session["tbl"] = di.tbl;
                //divTbl1.Controls.Add((HtmlTable)Session["tbl"]);
                //// Response.Write(di.str4 + "The length of the item :-  " + di.str6);
                //Session["DataItem"] = di;
            }
            else
                Response.Write(di.faild);
        }
        protected void back_Click(object sender, EventArgs e)
        {
            if (0 == (int)ViewState["Current"])
                ViewState["Current"] = (int)ViewState["Current"] + 10;
            Response.Write("Current pointer :" + ViewState["Current"]);
            Response.Write("Terminal :" + ViewState["Terminal"] + "");
            ViewState["Current"] = new Register().LoadToTextBox((int)ViewState["Current"], (int)ViewState["Terminal"], (Table)Session["tableRtn"], form1, false, false).num1;
            // ViewState["Current"] = new Register().LoadToTextBox(0, (int)ViewState["Terminal"], (HtmlTable)Session["tableRtn"], form1, false, true).num1;
        }
        protected void next_Click(object sender, EventArgs e)
        {
            if ((int)ViewState["Terminal"] <= (int)ViewState["Current"])
                ViewState["Current"] = (int)ViewState["Current"] - 10;
            Response.Write("Current pointer :" + ViewState["Current"]);
            Response.Write("Terminal :" + ViewState["Terminal"] + "");
            DataItem di = new Register().LoadToTextBox((int)ViewState["Current"], (int)ViewState["Terminal"], (Table)Session["tableRtn"], form1, true, false);
            ViewState["Current"] = di.num1;
            Response.Write("Start from here  :" + di.num2 + "");
        }
        protected void Register_Click(object sender, EventArgs e)
        {
            Register Rg = new Register();
            if (Session["tableRtn"] != null && ((Table)Session["tableRtn"]).Rows.Count > 0)
            {
                DataItem di = (DataItem)Session["DataItem"];
                int start = (int)ViewState["Current"];
                int end = (int)ViewState["Current"] + 10;
                Session["tableRtn"] = Rg.ReadAll(null, (DataItem)Session["di"], (Table)Session["tableRtn"], start, end, form1).tbl2;
                ViewState["Terminal"] = ((Table)Session["tableRtn"]).Rows.Count;
                Response.Write("Current Session" + ViewState["Current"] + "</br>");
                Response.Write("Current Terminal " + ViewState["Terminal"]);
                ViewState["Current"] = new Register().LoadToTextBox(0, (int)ViewState["Terminal"], (Table)Session["tableRtn"], form1, false, true).num1;
                form1.Controls.Add((Table)Session["tableRtn"]);
            }
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
