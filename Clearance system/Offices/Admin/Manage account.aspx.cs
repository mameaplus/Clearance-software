using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClearanceSystem.Offices.Admin
{
    public partial class Manage_account : System.Web.UI.Page
    {
        public string State1 = "panel-collapse collapse", State2 = "panel-collapse collapse",state;
        public int TL, TR, BL, BR;
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            
        }
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

            if (IsPostBack)
            {
                state = "collapse in";

            }
            else
            {

                state = "panel-collapse collapse";
            }
        }
    

        protected void Load_Click(object sender, EventArgs e)
        {
            ena.Text = "";
            dis.Text = "";
            DataItem di0 = new DataItem();
            di0.str3 = accountlist.SelectedValue.ToString();
            di0.str1 = id.Text;
            // employeeaccount   studentaccount
     
            DataItem di = new DataItem();
  
            Return rtn;
            string who = "";
            Response.Write(di0.str3 + "  " + di0.str1);
            rtn = new ClearanceSystem.Student().LoadDetail(di0, "studempaccount");
            if (rtn.Bool)
            {
                if (di0.str3 == "30")
                {
                    dep.Text = "Departement ";
                    who = "Student";
                }
                if (di0.str3 == "40")
                {
                    dep.Text = "Postion ";
                    who = "Employee";
                }
                /*
        if (di.str3== "30")
                            cmd.CommandText = "SELECT  [Photo],[Dep],[Email],[Name] FROM [KiotDBClear].[dbo].[Student] where [ID]='" + di.str1 + "'";
                         else if (di.str3 == "40")
                            cmd.CommandText = "SELECT  [Photo],[Departement],[Email],CONCAT([FName],' ',[MName],' ',[LName]) as fullname FROM [KiotDBClear].[dbo].[Employee] where [ID]='"
      */
                Session["email"] = (string)rtn.ds.Tables[0].Rows[0][2]; 
                lblName.Text = (string)rtn.ds.Tables[0].Rows[0][3];
                lblDep.Text = (string)rtn.ds.Tables[0].Rows[0][1];
                photo.ImageUrl = "~/" + (string)rtn.ds.Tables[0].Rows[0][0];
                photo.AlternateText = lblName.Text;
                WStudID.Text = "";
                state = "collapse in";
            }
            else
            {
                WStudID.Text = "No  " + who + "  with this id number";
                WStudID.ForeColor = System.Drawing.Color.Red;
                state = "panel-collapse collapse";
            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {

        }

        protected void enable_Click(object sender, EventArgs e)
        {//disable
            DataItem di = new DataItem();
            di.str1 = Session["email"] as string;
            di.str2 = "enable";
           
                  
            if (new Record().RecordForClear(di, "stateaccount"))
            {
                ena.Text = "Account enabled !";
                ena.ForeColor = System.Drawing.Color.LightSeaGreen;
                dis.Text = "";
            }

        }

        protected void disable_Click(object sender, EventArgs e)
        {
            //disable
            DataItem di = new DataItem();
            di.str1 = Session["email"] as string;
            di.str2 = "disable";


            if (new Record().RecordForClear(di, "stateaccount"))
            {
                ena.Text = "";
                dis.Text = "Account disabled !";
                dis.ForeColor = System.Drawing.Color.Red;
            }
        }

        
    }
}