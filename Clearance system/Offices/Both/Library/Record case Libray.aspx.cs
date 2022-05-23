using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ClearanceSystem.Offices.Both.Library
{
    public partial class Record_case_Libray : System.Web.UI.Page
    {

        public int op; bool te;
        public string name, id, Dep, DormNum, statu, photo, Block, state;
        public string BookTtl, amount;
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Session["url"] = HttpContext.Current.Request.Url.AbsolutePath;
            if (Session["username"] != null)
            {
                if (Session["postion"] as string != 1 + "")
                    Response.Redirect("../../../Login.aspx");
            }
            else
                Response.Redirect("../../../Login.aspx");
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack)
            {
                state = "collapse in";

            }
            else
            {
                Calendar1.Visible = true;
                state = "panel-collapse collapse";
            }

            if (TextBox1.Text == "" || TextBox3.Text == "")
            {//validation 
                state = "panel-collapse collapse";
            }
            else
            {
                 Image1.ImageUrl = "";
            }

        }
        protected void Button1_Click1(object sender, EventArgs e)
        {
            Session["0"] = "on";
            Book book = new Book();
            Return rtnBook = book.FindBook(bookID.Text, "Library");
            ClearanceSystem.Student s = new ClearanceSystem.Student();
            DataItem di = new DataItem();
            di.str1 = (string)TextBox1.Text;
            Return rtnStudent = s.LoadDetail(di, "Library");
            if (rtnBook.Bool)
            {
                Session["book"] = rtnBook.ds;
                wBook.Text = "";
                if (!rtnStudent.Bool)
                {
                    wStud.ForeColor = System.Drawing.Color.Red;
                    wStud.Text = "Student with this id not exist";
                    state = "panel-collapse collapse";

                }
                else
                {
                    wStud.Text = "";
                    Session["stud"] = rtnStudent.ds;
                    readStud((DataSet)Session["stud"]);
                    BookRead((DataSet)Session["book"]);
                    Dep = (string)rtnStudent.ds.Tables[0].Rows[0][6];                  
                    ViewState["phone"] =rtnStudent.ds.Tables[0].Rows[0][7];
                    Session["rdm"] = new Class().sendEmail("", "");
                    DataItem sms = new DataItem();
                    sms.str1 = ViewState["phone"] as string;
                    sms.str2 = "From Linrary Agreement code :" + Session["rdm"] as string;
                    sms.str3 = "E:\\Final project implemntation Don't Delete it\\ClearanceSystem\\ClearanceSystem\\SendTousers\\smsout\\smsout.txt";
                    new Message().SendSms(sms);


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
 

            if (TextBox3.Text == (string)Session["rdm"])
            {
 
                DataItem DI = new DataItem();
                //"insert into Library values(@TakerId,@postion,@BookID,@agreementCode,@Date,@ExpDate)";
                DI.str1 = TextBox1.Text;
                DI.str2 = "student";//set Student ==>for pastion  col
                DI.str3 = bookID.Text;
                DI.str4 = (string)Session["rdm"];
                DI.str5 = System.DateTime.Now.ToString();
                DI.str6 = System.DateTime.Now.ToString();
                if (new Record().RecordForClear(DI, "library"))
                {
                    Acode.Text = "Record successfully saved";
                    Acode.ForeColor = System.Drawing.Color.DarkOrange;
                    Button2.Enabled = false;
                }
            }
            else
            {
                Acode.Text = "Record not successfully saved  ";
                Acode.ForeColor = System.Drawing.Color.Red;
            }

            readStud((DataSet)Session["stud"]);
            BookRead((DataSet)Session["book"]);
            state = "collapse in";
        }


        void readStud(DataSet ds)
        {
            lblName.Text = (string)ds.Tables[0].Rows[0][1];
            lblDep.Text = (string)ds.Tables[0].Rows[0][2];
            lblBlock.Text = (string)ds.Tables[0].Rows[0][3];
            lblDorm.Text = (string)ds.Tables[0].Rows[0][4];
            Image1.ImageUrl = "~/"+(string)ds.Tables[0].Rows[0][5];
            Image1.AlternateText = name;

        }
        void BookRead(DataSet ds)
        {
            BookTtl = ds.Tables[0].Rows[0][0].ToString();
            amount = ds.Tables[0].Rows[0][1].ToString();
        }

       
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            ExpDate.Text = Calendar1.SelectedDate.ToString();
            state = "collapse in";
        }
        
    }
}