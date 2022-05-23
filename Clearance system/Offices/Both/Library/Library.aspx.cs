using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Net.Mail;

namespace ClearanceSystem
{
    public partial class Library : System.Web.UI.Page
    {
      

        public int op; bool te;
        public string name, id, Dep, DormNum, statu, photo, Block, state;
        public string BookTtl, amount;

        protected void Page_Load(object sender, EventArgs e)
        {
         
            if (IsPostBack)
            {
                state = "collapse in";

            }
            else
                state = "panel-collapse collapse";

            if (TextBox1.Text == "" || TextBox3.Text == "")
            {//validation 
                state = "panel-collapse collapse";
            }
            else
            {
                state = "collapse in"; Image1.ImageUrl = "";
            }

        }
        protected void Button1_Click1(object sender, EventArgs e)
        {
            Session["0"] = "on";
            Book book = new Book();
            Return rtnBook = book.FindBook(bookID.Text);
            Student s = new Student();
            DataItem di = new DataItem()  ;
            di.str1 = (string)TextBox1.Text;
            Return rtnStudent = s.LoadDetail( di, "Library");
            if (rtnBook.Bool)
            {
                Session["book"]=rtnBook.ds;
                if (!rtnStudent.Bool)
                {
                    wStud.ForeColor = System.Drawing.Color.Red;
                    wStud.Text = "Student with this id not exist";
                    state = "panel-collapse collapse";
                    
                }
                else
                {
                    Session["stud"] = rtnStudent.ds;
                    readStud((DataSet)Session["stud"]);
                    BookRead((DataSet)Session["book"]);
                    Dep = (string)rtnStudent.ds.Tables[0].Rows[0][6];

                    Session["rdm"]=new Class().sendEmail(Dep, "Library");
                    Response.Write((string)Session["rdm"]);
                    state = "collapse in";
                }
            }
            else
            {
                wBook.ForeColor = System.Drawing.Color.Red;
                wBook.Text = "Book not exist";
                state = "panel-collapse collapse";
            }

            Button2.Enabled = true;
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Label2.Text = (string)Session["rdm"];
            Label2.ForeColor = System.Drawing.Color.Red;

            if (TextBox3.Text == (string)Session["rdm"])
            {
                Label2.Text = (string)Session["rdm"];
                DataItem DI = new DataItem();
                //"insert into Library values(@TakerId,@postion,@BookID,@agreementCode,@Date,@ExpDate)";
                DI.str1 = TextBox1.Text;
                DI.str2 = "student";//set Student ==>for pastion  col
                DI.str3 = bookID.Text;
                DI.str4 = (string)Session["rdm"];
                DI.str5 = System.DateTime.Now.ToString();
                DI.str6 = System.DateTime.Now.ToString();
                if (new Record().RecordForClear(DI,"library"))
                {
                    Acode.Text = "record successfully saved";
                    Acode.ForeColor = System.Drawing.Color.DarkOrange;
                    Button2.Enabled = false;
                }
            }
            else
            {
               RcWarn.Text= "not Record recorder";
               RcWarn.ForeColor = System.Drawing.Color.Red;
            }

            readStud((DataSet)Session["stud"]);
            BookRead((DataSet)Session["book"]);
            state = "collapse in";
        }

   
        void readStud(DataSet ds)
        {
            name = (string)ds.Tables[0].Rows[0][1];
            Dep = (string)ds.Tables[0].Rows[0][2];
            Block = (string)ds.Tables[0].Rows[0][3];
            DormNum = (string)ds.Tables[0].Rows[0][4];
            Image1.ImageUrl = (string)ds.Tables[0].Rows[0][5];
            Image1.AlternateText = name;
         
        }
        void BookRead(DataSet ds)
        {
            BookTtl = ds.Tables[0].Rows[0][0].ToString();
            amount = ds.Tables[0].Rows[0][1].ToString();
        }
        

    }
}