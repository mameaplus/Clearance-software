using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace ClearanceSystem.Offices.Both.Cashier
{
    public partial class ViewCase : System.Web.UI.Page
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
            DataItem di = new DataItem();
            di.sqlcmd = new SqlCommand();
            di.sqlcmd.CommandText = "select distinct [Finance].id , [dbo].[Employee].FName+' '+[dbo].[Employee].[MName]+' '+[dbo].[Employee].[LName] as [Full name],[dbo].[Employee].[Photo],sum([dbo].[Finance].[Credit] ) as Total from [dbo].[Finance] inner join [dbo].[Employee] on [dbo].[Employee].[ID]=[dbo].[Finance].id group by [Finance].id , [dbo].[Employee].FName,[dbo].[Employee].[MName],[dbo].[Employee].[LName],[dbo].[Employee].[Photo]";
            di.di = new Case().LoadCase(di);
            if (di.di.Bool)
            {
                GridView1.DataSource = di.di.ds.Tables[0];
                GridView1.DataBind();
            }
        }

      
        protected void ClearAll_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox chBox = row.Cells[0].FindControl("check") as CheckBox;
                Response.Write(chBox.Text);
                string hiden = (row.Cells[1].FindControl("id") as Label).Text.ToString();
                Response.Write(hiden);
                DataItem di = new DataItem();
                di.sqlcmd = new SqlCommand();
                di.sqlcmd.CommandText = "delete from  [dbo].[Finance] where [id]=@id";
                di.sqlcmd.Parameters.AddWithValue("@id", hiden);
                new Case().ignoreCase(di);
                GridView1.Visible = false;
                state = "panel-collapse collapse";
            }

        }

        protected void Clear_Click1(object sender, EventArgs e)
        {         
            DataItem di = new DataItem();
            foreach (GridViewRow row in GridView1.Rows)
            {              
                di.sqlcmd = new SqlCommand();
                if ((row.Cells[0].FindControl("check") as CheckBox).Checked)
                {                    
                    string hiden = (row.Cells[0].FindControl("id") as Label).Text.ToString();
                    di.sqlcmd.CommandText = "delete from [dbo].[Finance]  where [Id]='" + hiden + "'";                  
                    Response.Write(di.sqlcmd.CommandText);
                    new Case().ignoreCase(di);
                    GridView1.Rows[row.RowIndex].Visible = false;
                }
            }
        }

    }
}