using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ClearanceSystem.Offices.Student.StudentCafteria
{
    public partial class IgnoreCase : System.Web.UI.Page
    {
        public string state;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["url"] = HttpContext.Current.Request.Url.AbsolutePath;
            Response.Write("sdfas");
            if (!IsPostBack)
                state = "panel-collapse collapse";
            else
                state = "collapse in";
            if (GridView1.Rows.Count == 0)
                GridView1.Visible = false;
            else
                GridView1.Visible = true;

        }
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                if (Session["postion"] as string != 11 + "")
                    Response.Redirect("../../../Login.aspx");
            }
            else
                Response.Redirect("../../../Login.aspx");
        }
        protected void Load_Click(object sender, EventArgs e)
        {
            DataItem di = new DataItem();
          ViewState["id"]=  di.str1 = StudID.Text;
            Return rtn;
            rtn = new ClearanceSystem.Student().LoadDetail(di, "Cafe");

            if (rtn.Bool)
            {
              
                lblName.Text = (string)rtn.ds.Tables[0].Rows[0][0];
                lblDep.Text = (string)rtn.ds.Tables[0].Rows[0][1];
                //photo.ImageUrl = (string)rtn.ds.Tables[0].Rows[0][2];
                //photo.AlternateText = lblName.Text;
                state = "collapse in";
            }
            else
            {
                state = "panel-collapse collapse";
                WStudID.Text = "No student with this id number";
                WStudID.ForeColor = System.Drawing.Color.Red;

            }
            di.str2 = "select [case] ,Record from StudentCafe where id='" + di.str1 + "'";
            SqlCommand cmd = new SqlCommand();
            di.sqlcmd = cmd;
            cmd.CommandText = di.str2;
            di.di = new Case().LoadCase(di);
            if (di.di.Bool)
            {

                GridView1.DataSource = di.di.ds;
                GridView1.DataBind();
            }

        }
        protected void Clear_Click(object sender, EventArgs e)
        {

        }

        protected void ClearAll_Click(object sender, EventArgs e)
        {
            DataItem di = new DataItem();
            di.sqlcmd = new SqlCommand();
            di.sqlcmd.CommandText = "delete from  [StudentCafe] where  id=@StudID";
            di.sqlcmd.Parameters.AddWithValue("@StudID", ViewState["id"] as string);           
            new Case().ignoreCase(di);
            
        }

        protected void Clear_Click1(object sender, EventArgs e)
        {
            DataItem di = new DataItem();
            int count = 0;
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox chBox = row.Cells[0].FindControl("check") as CheckBox;
                if (chBox.Checked)
                {
                    // delete from  [StudentCafe] where [Record]='1'
                    di.str1 = " delete from  [dbo].[SportMaster] where Record=@Record";
                    SqlCommand cmd = new SqlCommand();
                    di.sqlcmd = cmd;
                    cmd.CommandText = di.str1;
                    di.num1 = Convert.ToInt32(row.Cells[2].Text);
                    Response.Write(row.Cells[2].Text);
                    cmd.Parameters.AddWithValue("@Record", di.num1);
                    new Case().ignoreCase(di);
                    GridView1.Rows[count].Visible = false;
                    /*
                     * Deleting row of the GridView is better than postbaking to the database;                                    
                     */
                }
                count++;
            }
        }


    }
}