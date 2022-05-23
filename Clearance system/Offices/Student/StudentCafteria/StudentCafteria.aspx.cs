using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ClearanceSystem.Offices.Employee.StudentCafteria
{
    public partial class StudentCafteria : System.Web.UI.Page
    {
        public string Dep, Name,state;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) 
               state = "panel-collapse collapse";
            else
            state="collapse in";
        }      

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar1.Visible)
            {
                Calendar1.Visible = false;
            }
            else
                Calendar1.Visible = true;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            Date.Text = Calendar1.SelectedDate.ToShortDateString().ToString();
            Calendar1.Visible = false;

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            DataItem di = new DataItem();
            di.str1 =StudID.Text;
            di.str2 =  resone.InnerText;
            di.str3 = Date.Text;
            if (new Record().RecordForClear(di, "Cafe")) 
            {
            }
        }

        protected void Load_Click(object sender, EventArgs e)
        {
           DataItem di=new DataItem();
            di.str1=StudID.Text;
            Return rtn;
            rtn = new ClearanceSystem.Student().LoadDetail(di, "Cafe");
            if (rtn.Bool)
            {
                 Name= (string)rtn.ds.Tables[0].Rows[0][0];
                 Dep= (string)rtn.ds.Tables[0].Rows[0][1];
                 photo.ImageUrl= (string)rtn.ds.Tables[0].Rows[0][2];
                 photo.AlternateText = Name;
                 state = "panel-collapse collapse";
            }
            else
            {
                WStudID.Text = "No student with this id number";
                WStudID.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}