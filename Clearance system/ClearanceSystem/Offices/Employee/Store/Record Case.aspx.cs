using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClearanceSystem.Offices.Employee.Store
{
    public partial class Record_Case : System.Web.UI.Page
    {
        public string state;
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
                Return rtn = new Return();
                DataItem di = new DataItem();
                di.str1 = EmpID.Text = Session["id"] as string;
                rtn = new ClearanceSystem.Student().LoadDetail(di, "Employee");
                Session["ds"] = rtn.ds;
                if (rtn.Bool)
                {
                    EmpID.Enabled = false;
                    //DataItem di0 = new Class().Detail(rtn.ds);
                    //  Fname,Lname,Departement,AcademicR,photo ,Email
                    Label1.Text = (string)rtn.ds.Tables[0].Rows[0][0] + " " + (string)rtn.ds.Tables[0].Rows[0][1];
                    Label2.Text = (string)rtn.ds.Tables[0].Rows[0][2];
                    Label3.Text = (string)rtn.ds.Tables[0].Rows[0][2];
                    photo.ImageUrl = "~/" + (string)rtn.ds.Tables[0].Rows[0][4];
                    photo.AlternateText = Label1.Text;
                    loadGrid();
                    Session["Code"] = new Class().sendEmail("", "");
                    ViewState["phone"] = rtn.ds.Tables[0].Rows[0][6];
                    DataItem sms = new DataItem();
                    sms.str1 = ViewState["phone"] as string;
                    sms.str2 = "From Store Agreement code :" + Session["Code"] as string;
                    sms.str3 = "E:\\Final project implemntation Don't Delete it\\ClearanceSystem\\ClearanceSystem\\SendTousers\\smsout\\smsout.txt";
                    new Message().SendSms(sms);
                    state = "collapse in";
                }
                else
                {
                    Response.Redirect("Show Refers.aspx");
                }
            }
        }



        protected void submit_Click(object sender, EventArgs e)
        {
            
            if (Acode.Text == Session["Code"] as string)
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    TextBox tb=(row.Cells[0].FindControl("TextBox0") as TextBox);
                    if (tb.Text != "")
                    {                       
                        DataItem di = new DataItem();
                        di.str1 = EmpID.Text;
                        di.str2 = row.Cells[3].Text;
                        di.str3 = (row.Cells[0].FindControl("TextBox0") as TextBox).Text;
                        new Record().RecordForClear(di, "store");
                        loadGrid();
                    }
                }
            }
        }
        void loadGrid()
        {
            DataItem loadM = new Material().LoadMaterial("", "store");
            GridView1.DataSource = loadM.ds;
            GridView1.DataBind();
        }

    }
}