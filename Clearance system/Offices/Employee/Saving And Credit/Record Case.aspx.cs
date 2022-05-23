using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClearanceSystem.Offices.Employee.Saving_And_Credit
{
    public partial class Record_Case : System.Web.UI.Page
    {
        public string state;
        protected void Page_PreLoad(object sender, EventArgs e)
        {

            if (Session["username"] != null)
            {
                if (Session["postion"] as string != 3 + "")
                    Response.Redirect("../../../Login.aspx");
            }
            else
                Response.Redirect("../../../Login.aspx");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["url"] = HttpContext.Current.Request.Url.AbsolutePath;
            if (!IsPostBack)
                state = "panel-collapse collapse";
        }

        protected void Load_Click(object sender, EventArgs e)
        {

            Return rtn = new Return();
            DataItem di = new DataItem();
            ViewState["TakerId"] = di.str1 = EmpID.Text;
            rtn = new ClearanceSystem.Student().LoadDetail(di, "Employee");
            Session["ds"] = rtn.ds;
            if (rtn.Bool)
            {
                wEmp.Text = "";
                submit.Enabled = true;
                EmpID.Enabled = false;
                DataItem di0 = new Class().Detail(rtn.ds);
                //  Fname,Lname,Departement,AcademicR,photo ,Email
                lblName.Text = di0.str1;
                lblDep.Text = di0.str2;
                lblArecord.Text = di0.str3;
                photo.ImageUrl = di0.str4;
                photo.AlternateText = lblName.Text;

 
                    Session["Code"] = new Class().sendEmail(di0.str5, "Finance");
                wEmp.Text = "";
                ViewState["phone"] =  rtn.ds.Tables[0].Rows[0][6];
                Session["rdm"] = new Class().sendEmail("", "");
                DataItem sms = new DataItem();
                sms.str1 = ViewState["phone"] as string;
                sms.str2 = "From Saving and credit Agreement code :" + Session["Code"] as string;
                sms.str3 = "E:\\Final project implemntation Don't Delete it\\ClearanceSystem\\ClearanceSystem\\SendTousers\\smsout\\smsout.txt";
                new Message().SendSms(sms);

                wEmp.ForeColor = System.Drawing.Color.Orange;
                state = "collapse in";
            }
            else
            {
                wEmp.Text = "No Employee with this id number";
                wEmp.ForeColor = System.Drawing.Color.Red;
                state = state = "panel-collapse collapse";
            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            if (Acode.Text == (string)Session["Code"])
            {
                DataItem di = new DataItem();
                di.str1 = ViewState["TakerId"] as string;
                di.str2 = Credit.Text;
                di.str3 = Resone.InnerText;
                //di.str4 = Acode.Text;
                if (new Record().RecordForClear(di, "Saving"))
                {
                    wEmp.Text = "Record saved !!";
                    wEmp.ForeColor = System.Drawing.Color.LawnGreen;
                    submit.Enabled = false;
                }
            }
            else
            {
                wEmp.Text = "Record  not saved !!";
                wEmp.ForeColor = System.Drawing.Color.Orange;
            }
        }
      
    }
}