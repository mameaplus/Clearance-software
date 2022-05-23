using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClearanceSystem.Users
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Log_in_Click(object sender, EventArgs e)
        {
            DataItem di0 = new DataItem();
            di0.str1 = userName.Text;
            di0.str2 = Password.Text;
            di0.str3 = Staff.SelectedValue.ToString();
            DataItem di1 = new Account().UserLogin(di0);
            if (di1.Bool)
            {
                Session["username"] = di0.str1;
                Session["postion"] = di0.str3;
                if (di0.str3 == "30")
                {
                    Session["id"] = di1.ds.Tables[0].Rows[0][0];
                    Session["Dep"] = di1.ds.Tables[0].Rows[0][1];
                    Session["Block"] = di1.ds.Tables[0].Rows[0][2];
                    Session["DormNum"] = di1.ds.Tables[0].Rows[0][3];
                    Session["Photo"] = di1.ds.Tables[0].Rows[0][4];
                    Session["Name"] = di1.ds.Tables[0].Rows[0][5];
                    Response.Redirect("Student/Student.aspx");
                }
                else if (di0.str3 == "40")
                {
                    Session["id"] = di1.ds.Tables[0].Rows[0][0];
                    Session["Photo"] = di1.ds.Tables[0].Rows[0][1];
                    Session["depar"] = di1.ds.Tables[0].Rows[0][2];
                    Session["Empname"] = di1.ds.Tables[0].Rows[0][3] +"  " +di1.ds.Tables[0].Rows[0][4];
                    

                    Response.Redirect("Employee/Employee.aspx");
                }
            }
            else
            {
                wpass.Text = " incorrect username and password";
            }
        }
    }
}