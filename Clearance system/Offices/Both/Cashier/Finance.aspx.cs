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
        public string state;

        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Session["url"] = HttpContext.Current.Request.Url.AbsolutePath;
            if (Session["username"] != null)
            {
                if (Session["postion"] as string != 0 + "")
                    Response.Redirect("../../../Login.aspx");
            }
            else
                Response.Redirect("../../../Login.aspx");
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Session["id"] != null)
                {
                    state = "collapse in";
                    Return rtn = new Return();
                    DataItem di = new DataItem();
                    ViewState["TakerId"] = di.str1 = EmpID.Text = Session["id"] as string;//((Page.PreviousPage.FindControl("GridView1") as GridView).SelectedRow.Cells[0].FindControl("id") as Label).Text;

                    Credit.Text = Session["Credit"] as string;
                    Resone.InnerText = Session["Reson"] as string;
                    Credit.Enabled = EmpID.Enabled = false;
                    rtn = new Student().LoadDetail(di, "Employee");
                    Session["ds"] = rtn.ds;
                    if (rtn.Bool)
                    {
                        wEmp.Text = "";
                        submit.Enabled = true;
                        DataItem di0 = new Class().Detail(rtn.ds);
                        //  Fname,Lname,Departement,AcademicR,photo ,Email
                        lblName.Text = di0.str1;
                        lblDep.Text = di0.str2;
                        lblArecord.Text = di0.str3;
                        photo.ImageUrl = di0.str4;
                        photo.AlternateText = lblName.Text;
                        ViewState["phone"] = rtn.ds.Tables[0].Rows[0][6];
                        Session["Code"] = new Class().sendEmail("", "");
                        DataItem sms = new DataItem();
                        sms.str1 = ViewState["phone"] as string;
                        sms.str2 = "From Cashire Agreement code :" + Session["Code"] as string;
                        sms.str3 = "E:\\Final project implemntation Don't Delete it\\ClearanceSystem\\ClearanceSystem\\SendTousers\\smsout\\smsout.txt";
                        new Message().SendSms(sms);

                        wEmp.Text = "";
                        wEmp.ForeColor = System.Drawing.Color.Orange;
                        state = "collapse in";
                    }
                    else
                        Response.Redirect("Add Case.aspx");
                }
                else
                    Response.Redirect("Add Case.aspx");
            }
        }

        protected void Load_Click(object sender, EventArgs e)
        {
            Response.Redirect("Add Case.aspx");
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            if (Acode.Text == (string)Session["Code"])
            {
                DataItem di = new DataItem();
                di.str1 = ViewState["TakerId"] as string;
                di.str2 = Credit.Text;
                di.str3 = Resone.InnerText;
                di.str4 = Session["Caseid"] as string;//Start from here and delete referd to cashir after giving the birrrrrrrrrr
                //di.str4 = Acode.Text;
                wEmp.Text = "Record saved !!";
                if (new Record().RecordForClear(di, "Finance"))
                {                
                    wEmp.ForeColor = System.Drawing.Color.LightSeaGreen;
                    submit.Enabled = false;
                    Session["id"] = null;
                }
            }
        }
    }
}