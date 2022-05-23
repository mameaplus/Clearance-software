using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClearanceSystem
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
        
            string user = Session["postion"] as string;
            if (user == "30" || user == "40")
                Response.Redirect("Users/Login.aspx");
            if (user == "20" )
                Response.Redirect("Offices/Admin/Login.aspx");
            else
                Response.Redirect("~/Login.aspx");
            Session.RemoveAll();
        }
    }
}