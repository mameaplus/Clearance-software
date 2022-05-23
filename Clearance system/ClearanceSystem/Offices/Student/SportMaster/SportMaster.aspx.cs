using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ClearanceSystem
{
    public partial class SportMaster : System.Web.UI.Page
    {
        public string state;
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                if (Session["postion"] as string != 10 + "")
                    Response.Redirect("../../../Login.aspx");
            }
            else
                Response.Redirect("../../../Login.aspx");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["url"] = HttpContext.Current.Request.Url.AbsolutePath;
            if (IsPostBack)
            {
                state = "collapse in";

            }
            else
            {

                state = "panel-collapse collapse";
            }
        }

        protected void Load_Click(object sender, EventArgs e)
        {
            Return rtn = new Return();
            DataItem di = new DataItem();
            di.str1 = EmpID.Text;
            rtn = new ClearanceSystem.Student().LoadDetail(di, "sportMaster");
            Session["ds"] = rtn.ds;
            if (rtn.Bool)
            {
                ViewState["phone"] = (string)rtn.ds.Tables[0].Rows[0][7];
                EmpID.Enabled = false;
                Label1.Text = " " + (string)rtn.ds.Tables[0].Rows[0][1];
                Label2.Text = (string)rtn.ds.Tables[0].Rows[0][2];
                Label3.Text = (string)rtn.ds.Tables[0].Rows[0][2];
                 photo.ImageUrl = "~/" + (string)rtn.ds.Tables[0].Rows[0][5];
                photo.AlternateText  =Label1.Text;
                     loadGrid();

                ////if (Session["Code"] == null)    ofile.WriteLine(di.str1+" "+ di.str2);
              //  Session["Code"] = new Class().sendEmail(di0.str5, "Distance Education ");
                Session["Code"] = new Class().sendEmail("", "");
                DataItem sms=new DataItem();            
                sms.str1=ViewState["phone"] as string;
                sms.str2="From Sport master Agreement code  :"+Session["Code"]  as string;
             //   sms.str3="E:\\Final project implemntation Don't Delete it\\ClearanceSystem\\ClearanceSystem\\SendTousers\\smsout\\smsout.txt";
                new Message().SendSms(sms);
                state = "collapse in";
                wEmp.Text = "";
            }
            else
            {
                state = "panel-collapse collapse";
                wEmp.Text = "No Employee with this id number";
                wEmp.ForeColor = System.Drawing.Color.Red;

            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            if (Acode.Text == Session["Code"] as string)
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    if ((row.Cells[0].FindControl("TextBox0") as TextBox).Text != "")
                    {
                        DataItem di = new DataItem();
                        di.str1 = EmpID.Text;
                        di.str3 = row.Cells[3].Text;
                        di.str2 = (row.Cells[0].FindControl("TextBox0") as TextBox).Text;
                        di.str4 = Session["Code"] as string;
                        Response.Write("di.str1" + di.str1 + "di.str3  " + di.str3 + "di.str2  " + di.str2 + "di.str4  " + di.str4);
                        new Record().RecordForClear(di, "sportmaterail");
                        loadGrid();
                        wrnAcode.Text = "";
                    }
                }
            }
            else
            {
                wrnAcode.Text = "Incorrect Agreement  code !!";
                wrnAcode.ForeColor = System.Drawing.Color.Red;
            }

        }
        void loadGrid()
        {
            DataItem loadM = new Material().LoadMaterial("", "sportMaterial");
            GridView1.DataSource = loadM.ds;
            GridView1.DataBind();
        }

    }
    /*
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
     */
}