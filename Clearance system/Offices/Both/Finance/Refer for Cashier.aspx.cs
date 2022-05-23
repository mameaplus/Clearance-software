using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClearanceSystem.Offices.Both.Finance
{
    public partial class Refer_for_Cashier : System.Web.UI.Page
    {
        public string state;
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Session["url"] = HttpContext.Current.Request.Url.AbsolutePath;
            if (Session["username"] != null)
            {
                if (Session["postion"] as string != 15 + "")
                    Response.Redirect("../../../Login.aspx");
            }
            else
                Response.Redirect("../../../Login.aspx");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
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
            Return rtn = new Return();
            DataItem di = new DataItem();
            di.str1 = EmpID.Text;
            rtn = new ClearanceSystem.Student().LoadDetail(di, "Employee");
            Session["ds"] = rtn.ds;
            if (rtn.Bool)
            {
                ViewState["id"] = EmpID.Text;
                ViewState["postion"] = "0";
                wEmp.Text = "";
                DataItem di0 = new Class().Detail(rtn.ds);
                //  Fname,Lname,Departement,AcademicR,photo ,Email
                lblName.Text = di0.str1;
                lblDep.Text = di0.str2;
                lblArecord.Text = di0.str3;
                photo.ImageUrl = di0.str4;
                photo.AlternateText = lblName.Text;
                //if (Session["Code"] == null)
                //    Session["Code"] = new Class().sendEmail(di0.str5, "Finance");
                state = "collapse in";
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
            DataItem di = new DataItem();          
            
            di.str1 = ViewState["id"] as string;
            di.str2 = "store";
            di.str3 = Credit.Text;
            di.str4 = Resone.InnerText;

            new Record().RecordForClear(di, "Refer");
        }
    }
}