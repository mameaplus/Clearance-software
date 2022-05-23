using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
namespace ClearanceSystem.Offices.Admin
{
    public partial class Create_Account : System.Web.UI.Page
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
            {
                staff.DataSource = new Account().loadDropDownList().ds;
                staff.DataValueField = "id";
                staff.DataTextField = "StaffName";
                staff.DataBind();
            }
          
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            //disable
            DataItem di = new DataItem();
            di.str1 = uname.Text;
            di.str2 = new Class().sendEmail("", "");
            di.str3 = staff.SelectedValue;

          
       


            string uxname = "[staffid]='" + di.str3 + "' and   [username] ";

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Load"].ConnectionString.ToString());
            con.Open();
            if (new RegisterExcel().ColDataIsExist(con, uname.Text, uxname, "   [KiotDBClear].[dbo].[Account]  ").Bool)
            {
                if (new Record().RecordForClear(di, "EmpAccount"))
                {
                    DataItem sms = new DataItem();
                    sms.str1 = phone.Text;
                    sms.str2 = "your user name :" + di.str1 + " your password :" + di.str2;
                    sms.str3 = "E:\\Final project implemntation Don't Delete it\\ClearanceSystem\\ClearanceSystem\\SendTousers\\smsout\\smsout.txt";
                    new Message().SendSms(sms);
                    accstate.Text = "Account successfully sent !!";
                    accstate.ForeColor = System.Drawing.Color.LightSeaGreen;
                    lbluname.Text = "";
                }
            }
            else
            {
                lbluname.ForeColor = System.Drawing.Color.Red;
                lbluname.Text = "User name exist";
            }
        }

        protected void Load_Click(object sender, EventArgs e)
        {

        }

    }
}