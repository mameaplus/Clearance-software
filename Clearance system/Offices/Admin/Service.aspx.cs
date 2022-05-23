using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClearanceSystem.Offices.Admin
{
    public partial class Service : System.Web.UI.Page
    {
        DataItem di = new DataItem();
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
        }

        protected void start_Click(object sender, EventArgs e)
        {         
            di.str1 = "clearance";
            di.str2="1";
            di.str3="0";
            new Record().RecordForClear(di, "admin");
        }

        protected void stop_Click(object sender, EventArgs e)
        {
            di.str1 = "clearance";
            di.str2 = "0";
            di.str3 = "1";
            new Record().RecordForClear(di, "admin");
        }
    }
}