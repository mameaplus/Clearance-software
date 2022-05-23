using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClearanceSystem.ClearanceForm
{
    public partial class Uncleared_offices : System.Web.UI.Page
    {
        public string page;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["postion"] as string == "student")
                page = "../Users/Student/Student.aspx";                    
            else if (Session["postion"] as string == "Employee")
                page = "../Users/Employee/Employee.aspx";
            string[] list = (Session["unclearedoff"] as string[]);
            int  last=(int)Session["last"];
            DataItem di = new DataItem();
            for (int i = 0; i < last; i++)
            {
                di.str1 = list[i];
                GridView grid = new GridView();
                grid.BackColor = System.Drawing.Color.NavajoWhite;
                grid.ForeColor = System.Drawing.Color.CadetBlue;
                grid.BorderColor = System.Drawing.Color.Chocolate;
                grid.DataSource=new Clearance().GetUncleared(di).ds;
                grid.DataBind();
                grid.Width=700;
                unclear.Controls.Add(grid);
               
            }
        }
    }
}