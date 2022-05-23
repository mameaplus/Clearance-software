using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

namespace ClearanceSystem.Offices.Employee
{
    public partial class Record_Material : System.Web.UI.Page
    {

        public string State1 = "panel-collapse collapse", State2 = "panel-collapse collapse";
        public int TL, TR, BL, BR;
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Session["url"] = HttpContext.Current.Request.Url.AbsolutePath;
            if (Session["username"] != null)
            {
                if (Session["postion"] as string != 5 + "")
                    Response.Redirect("../../../Login.aspx");
            }
            else
                Response.Redirect("../../../Login.aspx");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TL = 0; TR = 0; BL = 0; BR = 0;
                State2 = "collapse in ";
                State1 = "panel-collapse collapse";
            }

        }
        //  border-top-left-radius: <% Response.Write(190);%>px; border-top-right-radius: 25px; 
        //  border-bottom-right-radius:25px ;border-bottom-left-radius:25px;
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            TL = 0; TR = 0; BL = 25; BR = 25;
            State1 = "collapse in ";
            State2 = "panel-collapse collapse";
        }

        protected void Excel_Click(object sender, EventArgs e)
        {
            TL = 0; TR = 0; BL = 0; BR = 0;
            State2 = "collapse in ";
            State1 = "panel-collapse collapse";
        }

        protected void Register_Click(object sender, EventArgs e)
        {
            DataTable dt0 = new DataTable();
            dt0.Columns.AddRange(new DataColumn[3]
            {
                new DataColumn("Name",typeof(string)),
                new DataColumn("Quantity",typeof(string)),
                new DataColumn("Date",typeof(string)),
            });
            DataItem di = new DataItem();
            Session["di"] = di;
            di.dt = dt0;

            string fileLocation = Server.MapPath("~/Excel/excelOne.xlsx");
            string[] val = new string[10];
            //the validator comes from another class or method
            di.Validator[0] = "^[a-zA-Z'.]{1,40}$";
            di.Validator[1] = "";
            di.Validator[2] = "";
            di.Validator[3] = "";
            di.Validator[4] = "";

            di.RealColName[0] = "Name";
            di.RealColName[1] = "Quantity";
            di.RealColName[2] = "Date";

            //Check for exsitensy
            di.VerColName[0] = "Name";

            //di.VerColName[1] = "col3"; 
            di.num4 = 1;
            di.sqlCmdTxt = "insert into Store_Material(Name,Quantity,Date)values(";
            di.str1 = "Store_Material";
            using (OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\""))
            {
                con.Open();
                DataTable dt = new DataTable();
                dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string sheetname = (string)dt.Rows[0]["TABLE_NAME"];
                OleDbDataAdapter da = new OleDbDataAdapter("select * from [" + sheetname + "]", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                di.ds = ds;
                di.RowMax = ds.Tables[0].Rows.Count;
                int ColMax = ds.Tables[0].Columns.Count;
                di.isOK = true;
                if (ColMax != 3)//check number of columns
                {
                    di.isOK = false;
                    di.faild = "invalid column  number";
                }
                else
                {
                    DataItem di0 = new RegisterExcel().ReadAll(di);
                    //  Session["DT"] = di0.dt;
                    GridView1.DataSource = di0.dt;
                    GridView1.DataBind();
                    di0.dt.Clear();
                }

            }
            State2 = "collapse in ";
        }

        protected void Register1_Click(object sender, EventArgs e)
        {
            DataItem di = Session["di"] as DataItem;
            //DataTable dt = Session["DT"] as DataTable;
            DataTable dt= new DataTable();
            dt.Columns.AddRange(new DataColumn[3]
            {
                new DataColumn("Name",typeof(string)),
                new DataColumn("Quantity",typeof(string)),
                new DataColumn("Date",typeof(string)),
            });
            DataSet ds = new DataSet();
           
           
           // di.ds.Tables.Remove(di.ds.Tables[0]);
            Response.Write("Count table object :" + di.ds.Tables.Count + "<br/>");
            foreach (GridViewRow row in GridView1.Rows)
            {
                Response.Write("Row Colu" + row.RowIndex);
                string cell0 = (row.Cells[0].FindControl("TextBox0") as TextBox).Text;
                string cell1 = (row.Cells[1].FindControl("TextBox1") as TextBox).Text;
                string cell2 = (row.Cells[2].FindControl("TextBox2") as TextBox).Text;
                dt.Rows.Add(cell0, cell1, cell2);
            }
            //di.ds.Tables.Add(dt);
            ds.Tables.Add(dt);
            di.ds = ds;
            GridView2.DataSource = di.ds;
            GridView2.DataBind();
            Response.Write("Count table object :" + di.ds.Tables.Count + "<br/>");
            Response.Write("Data Table counter " + di.ds.Tables[0].Rows.Count);
            DataItem di0 = new RegisterExcel().ReadAll(di);
            //Response.Write("Count the data form the Rows  :" + di0.str3);
            //if (di0.dt != null)
           
            ////Session["DT"] = di0.dt;           

            GridView1.DataSource = di0.dt;
            GridView1.DataBind();
            State2 = "collapse in ";
            di0.dt.Clear();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }
    }
}