using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace ClearanceSystem
{
    public partial class changePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

 
        protected void submit_Click(object sender, EventArgs e)
        {
       
            DataItem di = new DataItem();
            di.sqlcmd = new SqlCommand();
            Response.Write(Session["username"] as string + "       " + Session["postion"] as string);
            di.sqlcmd.CommandText = "update [dbo].[Account] set [password]=@pass  where convert(varchar(100),[password])='" + oldpass .Text+ "' and [UserName]=@uname and staffid=@staffid";
            di.sqlcmd.Parameters.AddWithValue("@uname", Session["username"] as string);
            di.sqlcmd.Parameters.AddWithValue("@pass", confpass.Text);
            di.sqlcmd.Parameters.AddWithValue("@staffid",Session["postion"] as string);
            new Case().ignoreCase(di);
        }

        

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Response.Write(Session["url"] as string);
            Response.Redirect(Session["url"] as string);
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Write(Session["url"] as string);
            Response.Redirect(Session["url"] as string);
        }

     
    }
}