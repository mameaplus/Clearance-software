using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ClearanceSystem.Offices.Student.CampusePolice
{
    public partial class IgnorePoliceRecord : System.Web.UI.Page
    {
        public string state;
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                if (Session["postion"] as string != 7 + "")
                    Response.Redirect("../../../Login.aspx");
            }
            else
                Response.Redirect("../../../Login.aspx");
        }
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

        protected void Load_Click(object sender, EventArgs e)
        {
            GridView1.Visible = true;
            DataItem di = new DataItem();
            di.str1 = StudID.Text;
            Return rtn;
            rtn = new ClearanceSystem.Student().LoadDetail(di, "Cafe");

            if (rtn.Bool)
            {
                lblName.Text = (string)rtn.ds.Tables[0].Rows[0][0];
                lblDep.Text = (string)rtn.ds.Tables[0].Rows[0][1];
                photo.ImageUrl = "~/"+(string)rtn.ds.Tables[0].Rows[0][2];
                photo.AlternateText = lblName.Text;
                state = "panel-collapse collapse";
                WStudID.Text = "";
                state = "collapse in";
            }
            else
            {
                WStudID.Text = "No student with this id number";
                WStudID.ForeColor = System.Drawing.Color.Red;
                state = "panel-collapse collapse";
            }
            di.sqlcmd=new SqlCommand();
            di.sqlcmd.CommandText = "select [case] , [caseid]  from [dbo].[police] where id='" + di.str1 + "'";
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
            di.sqlcmd .CommandText= "delete from  [dbo].[police] where [id]='" + StudID.Text + "'";
            new Case().ignoreCase(di);
            GridView1.Visible = false;
        }
        protected void Clear_Click(object sender, EventArgs e)
        {
            DataItem di = new DataItem();
            int count = 0;
            foreach (GridViewRow row in GridView1.Rows)
            {
                di.sqlcmd= new SqlCommand();
                CheckBox chBox = row.Cells[0].FindControl("check") as CheckBox;
                if (chBox.Checked)
                {
                    // delete from  [StudentCafe] where [Record]='1'
                    di.sqlcmd.CommandText = "delete from  [dbo].[police] where [id]=@id and CaseId=@CaseId";
                    di.sqlcmd.Parameters.AddWithValue("@id",StudID.Text);
                    di.sqlcmd.Parameters.AddWithValue("@CaseId", row.Cells[2].Text);
                    new Case().ignoreCase(di);
                    GridView1.Rows[count].Visible = false;
                }
                count++;
            }
        }
    }
}