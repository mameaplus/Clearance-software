using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClearanceSystem.Offices.Employee.CostSharing
{
    public partial class CostSharing : System.Web.UI.Page
    {
        public string Name, Dep, state;
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Session["url"] = HttpContext.Current.Request.Url.AbsolutePath;
            if (Session["username"] != null)
            {
                if (Session["postion"] as string != 8 + "")
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
 

        protected void Load_Click1(object sender, EventArgs e)
        {
            DataItem di = new DataItem();
            di.str1 = StudID.Text;
            Return rtn;
            rtn = new ClearanceSystem.Student().LoadDetail(di, "CostSharing");
            if (rtn.Bool)
            {
                lblName.Text = (string)rtn.ds.Tables[0].Rows[0][0];
                lblDep.Text = (string)rtn.ds.Tables[0].Rows[0][1];
                photo.ImageUrl ="~/"+ (string)rtn.ds.Tables[0].Rows[0][2];
                photo.AlternateText = Name;
                WStudID.Text = "";
                state = "collapse in";
            }
            else
            { 
                state = "panel-collapse collapse";
                WStudID.Text = "No student with this id number";
                WStudID.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            DataItem di = new DataItem();
            di.str1 = StudID.Text;
            di.str2 = resone.InnerText;

            if (new Record().RecordForClear(di, "CostSharing"))
            {
                error.ForeColor = System.Drawing.Color.LightSeaGreen;
                error.Text = "record Successfully recorded !! ";
            }
        }

        
    }
}