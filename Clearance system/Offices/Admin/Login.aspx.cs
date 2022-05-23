using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClearanceSystem.Offices.Admin
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
            di0.str3 = "20";
            Response.Write(di0.str1 + "   " + di0.str2 + "  " + di0.str3);
            DataItem di1 = new Account().login(di0);
            if (di1.Bool)
            {
                Session["username"] = di0.str1;
                Session["postion"] = di0.str3;
                Response.Redirect("Admin.aspx");
            }
            else
            {
                wpass.Text = " incorrect username and password";
            }
        }
    }
}