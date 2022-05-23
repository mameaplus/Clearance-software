using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System;

namespace ClearanceSystem.HRM
{
    public partial class Register : System.Web.UI.Page
    {
        public string State1 = "panel-collapse collapse", State2 = "panel-collapse collapse";
        public int TL, TR, BL, BR;
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                if (Session["postion"] as string != 2 + "")
                    Response.Redirect("../../../Login.aspx");
            }
            else
                Response.Redirect("../../../Login.aspx");
        }
        protected void Page_Load(object sender, System.EventArgs e)
        {
            Session["url"] = HttpContext.Current.Request.Url.AbsolutePath;
            if (!IsPostBack)
            {
                TL = 0; TR = 0; BL = 0; BR = 0;
                State2 = "collapse in ";
                State1 = "panel-collapse collapse";
            }
        }
      
        protected void LinkButton1_Click(object sender, System.EventArgs e)
        {
            TL = 0; TR = 0; BL = 25; BR = 25;
            State1 = "collapse in ";
            State2 = "panel-collapse collapse";
          
        }

        protected void Excel_Click(object sender, System.EventArgs e)
        {
            TL = 0; TR = 0; BL = 0; BR = 0;
            State2 = "collapse in ";
            State1 = "panel-collapse collapse";
        }

        protected void RegisterExcel_Click(object sender, System.EventArgs e)
        {
            DataTable dt0 = new DataTable();
            dt0.Columns.AddRange(new DataColumn[9]
            {              
                new DataColumn("ID",typeof(string)),
                new DataColumn("FName",typeof(string)),
                new DataColumn("MName",typeof(string)),
                new DataColumn("LName",typeof(string)),
                new DataColumn("AcademicR",typeof(string)),
                new DataColumn("Salary",typeof(string)),
                new DataColumn("Email",typeof(string)),
                new DataColumn("PhoneNum",typeof(string)),
                new DataColumn("Departement",typeof(string)),
            });
            DataItem di = new DataItem();
            Session["di"] = di;
            di.dt = dt0;

            string fileLocation = Server.MapPath("~/Excel/Employee.xlsx");
            string[] val = new string[10];
            //the validator comes from another class or method//("^[a-zA-Z'.]{1,40}$")
            di.Validator[0] = "";
            di.Validator[1] = ""; di.Validator[2] = ""; di.Validator[7] = "";
            di.Validator[3] = ""; di.Validator[4] = ""; di.Validator[8] = "";
            di.Validator[5] = ""; di.Validator[6] = "";
            //ID, Name, Dep, Block, DormNum, Photo, Email, PhoneNum
            di.RealColName[0] = "ID";
            di.RealColName[1] = "FName";
            di.RealColName[2] = "MName";
            di.RealColName[3] = "LName";
            di.RealColName[4] = "AcademicR";
            di.RealColName[5] = "Salary";
            di.RealColName[6] = "Email";
            di.RealColName[7] = "PhoneNum";
            di.RealColName[8] = "Departement";

            //Check for exsitensy
            di.VerColName[0] = "ID";
            di.VerColName[1] = "Email";
            //  insert into [dbo].[Student](ID, Name, Dep, Block, DormNum, Photo, Email, PhoneNum) values('','','','','','','','');
            //di.VerColName[1] = "col3";       
            di.num4 = 2;
            di.ColNumber = 9;
            di.sqlCmdTxt = " insert into Employee( ID,FName ,MName ,LName ,AcademicR  ,Salary,PhoneNum  ,Email ,Departement) values(";
            di.str1 = "Employee";
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
               
                Response.Write("Max Col :" + ColMax);
                if (ColMax != 9)//check number of columns
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
                    Response.Write("Commande good  :  " + di0.num1);
                    Response.Write("Commande notGoodexist  :  " + di0.num2);
                    Response.Write("Commande notGoodInvalid  :  " + di0.num3);
                    Response.Write("Commande text  :  " + di0.str3);
                }

            }
            State2 = "collapse in ";
        }

        protected void Register1_Click(object sender, System.EventArgs e)
        {
            DataItem di = Session["di"] as DataItem;
            //DataTable dt = Session["DT"] as DataTable;
            DataTable dt = new DataTable();
            // insert into [dbo].[Student](ID, Name, Dep, Block, DormNum, Email, PhoneNum) values('','','','','','','','');
            dt.Columns.AddRange(new DataColumn[9]
            {
                new DataColumn("ID",typeof(string)),
                new DataColumn("FName",typeof(string)),
                new DataColumn("MName",typeof(string)),
                new DataColumn("LName",typeof(string)),
                new DataColumn("AcademicR",typeof(string)),
                new DataColumn("Salary",typeof(string)),
                new DataColumn("Email",typeof(string)),
                new DataColumn("PhoneNum",typeof(string)),
                new DataColumn("Departement",typeof(string)),
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
                string cell3 = (row.Cells[3].FindControl("TextBox3") as TextBox).Text;
                string cell4 = (row.Cells[4].FindControl("TextBox4") as TextBox).Text;
                string cell5 = (row.Cells[5].FindControl("TextBox5") as TextBox).Text;
                string cell6 = (row.Cells[6].FindControl("TextBox6") as TextBox).Text;
                string cell7 = (row.Cells[4].FindControl("TextBox7") as TextBox).Text;
                string cell8 = (row.Cells[5].FindControl("TextBox8") as TextBox).Text;             
                dt.Rows.Add(cell0, cell1, cell2, cell3, cell4, cell5, cell6,cell7,cell8);
            }
            //di.ds.Tables.Add(dt);
            ds.Tables.Add(dt);
            di.ds = ds;
            
            Response.Write("Count table object :" + di.ds.Tables.Count + "<br/>");
            Response.Write("Data Table counter " + di.ds.Tables[0].Rows.Count);
            DataItem di0 = new RegisterExcel().ReadAll(di);
            //Response.Write("Count the data form the Rows  :" + di0.str3);
            //if (di0.dt != null)

            ////Session["DT"] = di0.dt;           

            GridView1.DataSource = di0.dt;
            GridView1.DataBind();
            if (di0.dt == null)
            {
                Register1.Visible = false;
                Button1.Visible = false;
            }
            else
            {
                Register1.Visible = true;
                Button1.Visible = true;
            }

            State2 = "collapse in ";
            di0.dt.Clear();
        }

       
    }
}