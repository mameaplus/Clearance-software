using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ClearanceSystem
{
    public partial class Distance_Education : System.Web.UI.Page
    {
        public string state,name,Arecord,Dep;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                state = "panel-collapse collapse";
            else
                state = "collapse in";
           
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
                readStud(rtn.ds);
            }
            else
            {
                wEmp.Text = "No Employee with this id number";
                wEmp.ForeColor = System.Drawing.Color.Red;
                state = "panel-collapse collapse";
            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            readStud(((DataSet)Session["ds"]));
            Response.Write((string)Session["Code"]+"</br>");
            Response.Write(Acode.Text);
            if (Acode.Text == (string)Session["Code"]) //((string)Session["Code&Email"])
            {
                wEmp.Text = "Recording";
                wEmp.ForeColor = System.Drawing.Color.Orange;
            }

        }
        void readStud(DataSet ds)
        {
            name = (string)ds.Tables[0].Rows[0][0] + " " + (string)ds.Tables[0].Rows[0][1];
            Dep = (string)ds.Tables[0].Rows[0][2];
            Arecord = (string)ds.Tables[0].Rows[0][3];
            photo.AlternateText = name;
            photo.ImageUrl = "~/"+(string)ds.Tables[0].Rows[0][4];                         
           if(Session["Code"]==null)
               Session["Code"] = new Class().sendEmail((string)ds.Tables[0].Rows[0][5], "Distance Education ");
        }

      

        
    }
}