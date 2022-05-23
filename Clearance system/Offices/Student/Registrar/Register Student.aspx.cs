using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;


namespace ClearanceSystem.Offices.Student.Registrar
{
    public partial class Register_Student : System.Web.UI.Page
    {

        public string State1 = "panel-collapse collapse", State2 = "panel-collapse collapse";
        public int TL, TR, BL, BR;
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                if (Session["postion"] as string != 9 + "")
                    Response.Redirect("../../../Login.aspx");
            }
            else
                Response.Redirect("../../../Login.aspx");

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["url"] = HttpContext.Current.Request.Url.AbsolutePath;
            if (!IsPostBack)
            {
                TL = 0; TR = 0; BL = 0; BR = 0;
                State2 = "collapse in ";
                State1 = "panel-collapse collapse";
            }
            if (!(GridView1.Rows.Count > 0))
            {
                Register1.Visible = false;
               
            }
            else
            {
                Register1.Visible = true;
               
            }

        }
        //  border-top-left-radius: <% Response.Write(190);%>px; border-top-right-radius: 25px; 
        //  border-bottom-right-radius:25px ;border-bottom-left-radius:25px;
        //protected void LinkButton1_Click(object sender, EventArgs e)
        //{
        //    TL = 0; TR = 0; BL = 25; BR = 25;
        //    State1 = "collapse in ";
        //    State2 = "panel-collapse collapse";
        //}

        //protected void Excel_Click(object sender, EventArgs e)
        //{
        //    TL = 0; TR = 0; BL = 0; BR = 0;
        //    State2 = "collapse in ";
        //    State1 = "panel-collapse collapse";
        //}

        protected void Register_Click(object sender, EventArgs e)
        {
            DataTable dt0 = new DataTable();
            dt0.Columns.AddRange(new DataColumn[7]
            {
                 new DataColumn("ID",typeof(string)),
                new DataColumn("Name",typeof(string)),
                new DataColumn("Dep",typeof(string)),
                new DataColumn("Block",typeof(string)),
                new DataColumn("DormNum",typeof(string)),
                new DataColumn("Email",typeof(string)),
                new DataColumn("PhoneNum",typeof(string)),
            });
            DataItem di = new DataItem();
            Session["di"] = di;
            di.dt = dt0;
            bool isOk = true;

            if (FileUpload1.HasFile)
            {
                string filexe = Path.GetExtension(FileUpload1.FileName);
                if (filexe == ".xlsx")
                {
                    if (FileUpload1.PostedFile.ContentLength > 50000)
                    {
                        isOk = false;
                        wExcel.Text = "The content length is above expected !";
                        wExcel.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        FileUpload1.SaveAs(Server.MapPath("Excel/" + FileUpload1.PostedFile.FileName));
                        isOk = true;
                    }

                }
                else
                {
                    isOk = false;
                    wExcel.Text = "please select only excel file !";
                    wExcel.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                isOk = false;
                wExcel.Text = "First upload excel file please !";
                wExcel.ForeColor = System.Drawing.Color.Red;
            }




            if (isOk)
            {
                string fileLocation = Server.MapPath("Excel/" + FileUpload1.PostedFile.FileName);
                string[] val = new string[10];
                //the validator comes from another class or method//("^[a-zA-Z'.]{1,40}$")
                di.Validator[0] = "\\w{4}(/\\d{4}/\\d{2})?";
                di.Validator[1] = "^[a-zA-Z'.]{1,40}$"; di.Validator[2] = "";
                di.Validator[3] = ""; di.Validator[4] = "";
                di.Validator[5] = ""; di.Validator[6] = "";
                //ID, Name, Dep, Block, DormNum, Photo, Email, PhoneNum
                di.RealColName[0] = "ID";
                di.RealColName[1] = "Name";
                di.RealColName[2] = "Dep";
                di.RealColName[3] = "Block";
                di.RealColName[4] = "DormNum";
                di.RealColName[5] = "Email";
                di.RealColName[6] = "PhoneNum";

                //Check for exsitensy
                di.VerColName[0] = "ID";
                di.VerColName[1] = "Email";
                //  insert into [dbo].[Student](ID, Name, Dep, Block, DormNum, Photo, Email, PhoneNum) values('','','','','','','','');
                //di.VerColName[1] = "col3";       
                di.num4 = 2;
                di.ColNumber = 7;
                di.sqlCmdTxt = " insert into Student(ID, Name, Dep, Block, DormNum,  Email, PhoneNum) values(";
                di.str1 = "Student";
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
                    if (ColMax != 7)//check number of columns
                    {
                        di.isOK = false;
                        di.faild = "invalid column  number";
                    }
                    else
                    {
                        DataItem di0 = new RegisterExcel().ReadAll(di);
                        GridView1.DataSource = di0.dt;
                        GridView1.DataBind();
                        di0.dt.Clear();
                        wExcel.Text = di0.num1 + " Rows are Successfully registered !";
                        wExcel.ForeColor = System.Drawing.Color.LightSeaGreen;
                    }
                }
                State2 = "collapse in ";
            }
 }

        protected void Register1_Click(object sender, EventArgs e)
        {
            DataItem di = Session["di"] as DataItem;
            //DataTable dt = Session["DT"] as DataTable;
            DataTable dt = new DataTable();
            // insert into [dbo].[Student](ID, Name, Dep, Block, DormNum, Email, PhoneNum) values('','','','','','','','');
            dt.Columns.AddRange(new DataColumn[7]
            {
                new DataColumn("ID",typeof(string)),
                new DataColumn("Name",typeof(string)),
                new DataColumn("Dep",typeof(string)),
                new DataColumn("Block",typeof(string)),
                new DataColumn("DormNum",typeof(string)),
                new DataColumn("Email",typeof(string)),
                new DataColumn("PhoneNum",typeof(string)),
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

                dt.Rows.Add(cell0, cell1, cell2, cell3, cell4, cell5, cell6);
            }
            //di.ds.Tables.Add(dt);
            ds.Tables.Add(dt);
            di.ds = ds;
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

       

        bool isValid(string pattern, string data)
        {
            return new RegisterExcel().ColIsValid(data, pattern);
        }
    }
}