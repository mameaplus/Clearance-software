using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ClearanceSystem.Offices.Student.CostSharing
{
    public partial class IgnoreCostSharing : System.Web.UI.Page
    {
        public string state;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["url"] = HttpContext.Current.Request.Url.AbsolutePath;
            if (IsPostBack)
            {
                state = "collapse in";

            }
            else
            {

                state = "panel-collapse collapse";
            }
        }
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                if (Session["postion"] as string != 8 + "")
                    Response.Redirect("../../../Login.aspx");
            }
            else
                Response.Redirect("../../../Login.aspx");
        }
        protected void Load_Click(object sender, EventArgs e)
        {
            DataItem di = new DataItem();
            di.str1 = StudID.Text;
            Return rtn;
            rtn = new ClearanceSystem.Student().LoadDetail(di, "Cafe");
            if (rtn.Bool)
            {
                GridView1.Visible = true;
                lblName.Text = (string)rtn.ds.Tables[0].Rows[0][0];
                lblDep.Text = (string)rtn.ds.Tables[0].Rows[0][1];
                photo.ImageUrl = "~/"+(string)rtn.ds.Tables[0].Rows[0][2];
                photo.AlternateText = photo.ImageUrl;
                state = "collapse in";
                WStudID.Text = "";
            }
            else
            {    
                state = "panel-collapse collapse";
                WStudID.Text = "No student with this id number";
                WStudID.ForeColor = System.Drawing.Color.Red;
            }
            di.sqlcmd = new SqlCommand();
            di.sqlcmd.CommandText = "select [case] from [dbo].[CostSharing] where [id]='" + StudID.Text + "'";
           // di.sqlcmd.Parameters.AddWithValue("@id", StudID.Text);
            di.di = new Case().LoadCase(di);
            if (di.di.Bool)
            {
                GridView1.DataSource = di.di.ds;
                GridView1.DataBind();
            }
        }

        protected void ClearAll_Click(object sender, EventArgs e)
        {
            DataItem di = new DataItem();
            di.sqlcmd = new SqlCommand();
            di.sqlcmd.CommandText = "delete from  [dbo].[CostSharing] where [id]=@studId";
            di.sqlcmd.Parameters.AddWithValue("@studId", StudID.Text);
            Response.Write(StudID.Text);
            new Case().ignoreCase(di);
            GridView1.Visible = false;
        }
        
    }
}