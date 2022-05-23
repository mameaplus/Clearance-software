using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClearanceSystem.Offices.Student.Proctor
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
            di0.str3 = "B.No" + bnum.Text;
            Response.Write(userName.Text);
            Response.Write(Password.Text);
            Response.Write("B.No" + bnum.Text);

            DataItem di1 = new Account().UserLogin(di0);
            if (di1.Bool)
            {
                Session["username"] = di0.str1;
                Session["block"] = di0.str3;
                Response.Redirect("Proctor HOME.aspx");
            }
            else
            {
                wpass.Text = " incorrect username and password";
            }
        }
    }
}