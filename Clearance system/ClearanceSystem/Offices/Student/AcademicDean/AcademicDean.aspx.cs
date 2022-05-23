using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClearanceSystem.Offices.Employee.AcademicDean
{
    public partial class AcademicDean : System.Web.UI.Page
    {
        public string Dep, Name, state;
        protected void Page_PreLoad(object sender, EventArgs e)
        {

            if (Session["username"] != null)
            {
                if (Session["postion"] as string != 6 + "")
                    Response.Redirect("../../../Login.aspx");
            }
            else
                Response.Redirect("../../../Login.aspx");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["url"] = HttpContext.Current.Request.Url.AbsolutePath;
            Calendar1.TodaysDate = DateTime.Now.AddDays(5);

            if (IsPostBack)
            {
                state = "collapse in";

            }
            else
            {
                state = "panel-collapse collapse";
            }
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
            di.str1 = StudID.Text;
            di.str2 = resone.InnerText;
            di.str3 = Date.Text;
            if (new Record().RecordForClear(di, "Academic"))
            {
            }
        }

        protected void Load_Click(object sender, EventArgs e)
        {
            DataItem di = new DataItem();
            di.str1 = StudID.Text;
            Return rtn;
            rtn = new ClearanceSystem.Student().LoadDetail(di, "Academic");
            if (rtn.Bool)
            {
           lblName.Text=    (string)rtn.ds.Tables[0].Rows[0][0];
            lblDep.Text=   (string)rtn.ds.Tables[0].Rows[0][1];
                photo.ImageUrl = "~/"+(string)rtn.ds.Tables[0].Rows[0][2];
                photo.AlternateText = Name;
                state = "collapse in"; WStudID.Text = "";
            }
            else
            {
                state = "panel-collapse collapse";
                WStudID.Text = "No student with this id number";
                WStudID.ForeColor = System.Drawing.Color.Red;
            }
        }

    }
}