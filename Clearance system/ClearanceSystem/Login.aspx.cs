using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClearanceSystem
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // new Account().login(new DataItem());
            if (!IsPostBack)
            {
                Staff.DataSource = new Account().loadDropDownList().ds;
                Staff.DataValueField = "id";
                Staff.DataTextField = "StaffName";
                Staff.DataBind();
            }
            //if (Request.Cookies["postion"] != null)
            //{
            //    userName.Text = Request.Cookies["username"].Value;
            //    //Staff.SelectedIndex = Convert.ToInt32(Response.Cookies["postion"].Value.ToString());               
            //}
            //else
            //{

            //}

        }

        protected void Log_in_Click(object sender, EventArgs e)
        {
            DataItem di0 = new DataItem();
            di0.str1 = userName.Text;
            di0.str2 = Password.Text;
            di0.str3 = Staff.SelectedValue.ToString();
 
            Response.Write("Selected staff Values :"+di0.str3);
            DataItem di1 = new Account().login(di0);
            if (di1.Bool)
            {
                Session["username"] = di0.str1;
                Session["postion"] = di0.str3;
                Response.Redirect(di1.ds.Tables[0].Rows[0][0].ToString());
               
            }
            else
            {
                wpass.Text = " incorrect username and password";
            }
            //Response.Cookies["username"].Expires = DateTime.Now.AddMinutes(20);
            //Response.Cookies["postion"].Expires = DateTime.Now.AddMinutes(20);
            //Response.Cookies["username"].Value = userName.Text;
            //Response.Cookies["postion"].Value = Staff.SelectedIndex.ToString();
        }
    }
}