using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ClearanceSystem.Offices.Both.Library
{
    public partial class View : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                if (Session["postion"] as string != 1 + "")
                    Response.Redirect("../../../Login.aspx");
            }
            else
                Response.Redirect("../../../Login.aspx");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["url"] = HttpContext.Current.Request.Url.AbsolutePath;
            //DateLoad           
            GridView1.DataSource = new ClearanceSystem.Student().LoadDetail(new DataItem(), "l").ds;
            GridView1.DataBind();
           // Response.Write("DateTime :"+DateTime.Now.ToShortDateString());
            if( !IsPostBack)
                   ViewState["check"] = false;
         }

        protected void GridView1_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

 

        protected void CheckAll_Click(object sender, EventArgs e)
        {
         
            if ((bool)ViewState["check"])
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    (row.Cells[0].FindControl("note") as CheckBox).Checked = false; ;
                }
                ViewState["check"] = false; ;
                CheckAll.Text = "Check All";
            }
            else
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    (row.Cells[0].FindControl("note") as CheckBox).Checked = true; ;
                }
                ViewState["check"] = true; ;
                CheckAll.Text = "unCheck All";
            }                   
        }

        protected void note_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if ((row.Cells[0].FindControl("note") as CheckBox).Checked)
                {
                    Response.Write("");//send message
                }
            }
        }

        protected void home_Click(object sender, EventArgs e)
        {

        }    
         
    }
}