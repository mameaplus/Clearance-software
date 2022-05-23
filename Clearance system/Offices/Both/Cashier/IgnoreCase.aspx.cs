using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ClearanceSystem.Offices.Both.Cashier
{
    public partial class IgnoreCase : System.Web.UI.Page
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
                state = "panel-collapse collapse";
        }

        protected void Load_Click(object sender, EventArgs e)
        {
            Return rtn = new Return();
            DataItem di = new DataItem();
            ViewState["TakerId"] = di.str1 = EmpID.Text; 
            rtn = new  ClearanceSystem.Student().LoadDetail(di, "Employee");
            Session["ds"] = rtn.ds;
            if (rtn.Bool)
            {
                wEmp.Text = "";
                DataItem di0 = new Class().Detail(rtn.ds);              
                lblName.Text = di0.str1;
                lblDep.Text = di0.str2;             
                photo.ImageUrl = di0.str4;
                photo.AlternateText = lblName.Text;  
                state = "collapse in";
                di.sqlcmd = new SqlCommand();
                di.sqlcmd.CommandText = "select [FId] ,[Reason],[Credit],[Date] from [dbo].[Finance] where [Id]='" + ViewState["TakerId"] as string + "';";
              
                di.di = new Case().LoadCase(di);
                if (di.di.Bool)
                {
                    GridView1.DataSource = di.di.ds.Tables[0];
               
                    GridView1.DataBind();
                    total();
                }
            }
            else
            {
                wEmp.Text = "No Employee with this id number";
                wEmp.ForeColor = System.Drawing.Color.Red;
              state = "panel-collapse collapse";
            }
        }
 
      
        protected void Clear_Click1(object sender, EventArgs e)
        {
            DataItem di = new DataItem();
            int count = 0;
            foreach (GridViewRow row in GridView1.Rows)
            {
                di.sqlcmd = new SqlCommand();
                CheckBox chBox = row.Cells[0].FindControl("check") as CheckBox;
                if (chBox.Checked)
                {
                    string hiden = (row.Cells[0].FindControl("HideId") as HiddenField).Value.ToString();
                    // delete from  [StudentCafe] where [Record]='1'
                    di.sqlcmd.CommandText = "delete from [dbo].[Finance]  where [Id]=@id and [FId]=@CaseId";
                    di.sqlcmd.Parameters.AddWithValue("@id", ViewState["TakerId"] as string);
                    di.sqlcmd.Parameters.AddWithValue("@CaseId", hiden);
                    new Case().ignoreCase(di);
                    GridView1.Rows[count].Visible = false;
                    total();
                }
                count++;
            }
        }

        protected void ClearAll_Click1(object sender, EventArgs e)
        {
            DataItem di = new DataItem();
            di.sqlcmd = new SqlCommand();
            di.sqlcmd.CommandText = "delete from  [dbo].[Finance] where [id]=@id";
            di.sqlcmd.Parameters.AddWithValue("@id", ViewState["TakerId"] as string);
            new Case().ignoreCase(di);
            GridView1.Visible = false;
            total();
        }
        void total()
        {
            DataItem di = new DataItem();
            di.sqlcmd = new SqlCommand();          
            di.sqlcmd.CommandText = "select 'Total Values :' as [__] ,sum([Credit]) as Total      from [dbo].[Finance] where [Id]='" + ViewState["TakerId"] as string + "'";
            di.di = new Case().LoadCase(di);
            if (di.di.Bool)
            {
                GridView2.DataSource = di.di.ds;
                GridView2.DataBind();
            }
        }
    }
}