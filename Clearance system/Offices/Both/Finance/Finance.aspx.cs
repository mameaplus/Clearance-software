using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClearanceSystem
{
    public partial class Finance : System.Web.UI.Page
    {
        public string state, Dep, name, Arecord;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            state = "panel-collapse collapse";
        }

        protected void Load_Click(object sender, EventArgs e)
        {

            Return rtn = new Return();
            DataItem di = new DataItem();
            di.str1 = EmpID.Text;
            rtn = new Student().LoadDetail(di, "Employee");
            Session["ds"] = rtn.ds;
            if (rtn.Bool)
            {
                DataItem di0 = new Class().Detail(rtn.ds);
                //  Fname,Lname,Departement,AcademicR,photo ,Email
                name = di0.str1;
                Dep = di0.str2;
                Arecord = di0.str3;
                photo.ImageUrl = di0.str4;
                photo.AlternateText = name = di0.str1; 
                
                if (Session["Code"] == null)
                    Session["Code"] = new Class().sendEmail(di0.str5, "Distance Education ");
                state = "collapse in";
            }
            else
            {
                wEmp.Text = "No Employee with this id number";
                wEmp.ForeColor = System.Drawing.Color.Red;
              
            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            if (Acode.Text == (string)Session["Code"]) {
            wEmp.Text="Record";
            wEmp.ForeColor = System.Drawing.Color.Orange;
            }
        }
    }
}