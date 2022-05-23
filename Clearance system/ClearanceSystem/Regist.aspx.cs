using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ClearanceSystem
{
    public partial class Regist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataItem di = new DataItem();
            di.str1 = "1659";
            Return rtn;
            rtn = new ClearanceSystem.Student().LoadDetail(di, "Cafe");

            //"insert into SportMaster values(@amount,@TakerId,@postion,@sportMID,@acode,@date,@ExpDate)";
            di.str2 = "select [dbo].[SportMaterial].[MaterialID] as mid,[dbo].[SportMaterial].[Name] as name,";
            di.str2 += "[dbo].[SportMaster].[amount] as amount  ";
            di.str2 += "from  [dbo].[SportMaster]  inner join [dbo].[SportMaterial] ";
            di.str2 += "on [dbo].[SportMaster].[SportMaterialID]=[dbo].[SportMaterial].[MaterialID]";
            di.str2 += "where [dbo].[SportMaster].[TakerId]='" + di.str1 + "'";
            di.sqlcmd = new SqlCommand();
            di.sqlcmd.CommandText = di.str2;
            di.di = new Case().LoadCase(di);
            if (di.di.Bool)
            {
                GridView1.DataSource = di.di.ds;
                GridView1.DataBind();
            }
           
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Response.Write("Index :"+e.NewEditIndex.ToString());
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                Response.Write((row.Cells[0].FindControl("TextBox0") as TextBox).Text+"    ");
                Response.Write((row.Cells[1].FindControl("TextBox1") as TextBox).Text + "     ");
                Response.Write((row.Cells[2].FindControl("TextBox2") as TextBox).Text + "<br>");
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    if (!new Register().ColIsValid((row.Cells[i].FindControl("TextBox"+i) as TextBox).Text, "^[a-zA-Z'.]{1,40}$"))
                    {
                        GridView1.Visible = false;
                    }
                    else
                        row.Visible = true;
                }                   
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //GridView1.DeleteRow(e.RowIndex);
        }
    }
}