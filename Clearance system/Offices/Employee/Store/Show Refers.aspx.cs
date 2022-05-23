using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClearanceSystem.Offices.Employee.Store
{
    public partial class Show_Refers : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Session["url"] = HttpContext.Current.Request.Url.AbsolutePath;
            if (Session["username"] != null)
            {
                if (Session["postion"] as string != 5 + "")
                    Response.Redirect("../../../Login.aspx");
            }
            else
                Response.Redirect("../../../Login.aspx");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            Session["id"] = (GridView1.SelectedRow.Cells[0].FindControl("id") as Label).Text;
            Session["Caseid"] = (GridView1.SelectedRow.Cells[0].FindControl("HiddenField1") as HiddenField).Value;

            if (GridView1.SelectedRow != null)
                Server.Transfer("Record Case.aspx");     
        }
    }
}