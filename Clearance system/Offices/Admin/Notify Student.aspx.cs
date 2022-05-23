using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClearanceSystem.Offices.Admin
{
    public partial class Notify_Student : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["url"] = HttpContext.Current.Request.Url.AbsolutePath;
            if (Session["username"] != null)
            {
                if (Session["postion"] as string != 20 + "")
                    Response.Redirect("Login.aspx");
            }
            else
                Response.Redirect("Login.aspx");

            if (!IsPostBack)
                ViewState["check"] = false;
        }

        



        protected void CheckAll_Click(object sender, EventArgs e)
        {

            if ((bool)ViewState["check"])
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    (row.Cells[0].FindControl("note") as CheckBox).Checked = false; ;
                }
                ViewState["check"] = false; ;
                CheckAll.Text = "Check All";
            }
            else
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    (row.Cells[0].FindControl("note") as CheckBox).Checked = true; ;
                }
                ViewState["check"] = true; ;
                CheckAll.Text = "Un Check All";
            }
        }

        protected void note_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if ((row.Cells[0].FindControl("note") as CheckBox).Checked)
                {
                    /*
                        // ../../SendTousers/smsin/MsgGetList.txt
          
                 using (System.IO.StreamWriter ofile = new System.IO.StreamWriter(di.str3, true))
                 {
                     ofile.WriteLine(di.str1+" "+ di.str2);
                 }
                     */
                    DataItem Di = new DataItem();//  ../../SendTousers/smsout/
                    Di.str1 = row.Cells[1].Text; Di.str2 = row.Cells[2].Text; Di.str3 = Server.MapPath("../../SendTousers/smsout/MsgGetList.txt");
                    new Message().SendSms(Di);
                }
            }
        }

        protected void home_Click(object sender, EventArgs e)
        {

        }    
        

    }
}