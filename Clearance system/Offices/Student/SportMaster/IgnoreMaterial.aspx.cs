using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ClearanceSystem.Offices.Student.SportMaster
{
    public partial class IgnoreMaterial : System.Web.UI.Page
    {
        public string state;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Load_Click(object sender, EventArgs e)
        {
            DataItem di = new DataItem();
            di.str1 = StudID.Text;
            Return rtn;
            rtn = new ClearanceSystem.Student().LoadDetail(di, "Cafe");

            if (rtn.Bool)
            {
                lblName.Text = (string)rtn.ds.Tables[0].Rows[0][0];
                lblDep.Text = (string)rtn.ds.Tables[0].Rows[0][1];
                photo.ImageUrl = (string)rtn.ds.Tables[0].Rows[0][2];
                photo.AlternateText = lblName.Text;
                state = "panel-collapse collapse";
            }
            else
            {
                WStudID.Text = "No student with this id number";
                WStudID.ForeColor = System.Drawing.Color.Red;
            }
            //"insert into SportMaster values(@amount,@TakerId,@postion,@sportMID,@acode,@date,@ExpDate)";

            di.str2 = "select [dbo].[SportMaterial].[MaterialID],[dbo].[SportMaterial].[Name],";
            di.str2 += "[dbo].[SportMaster].[amount]";
            di.str2 += "from  [dbo].[SportMaster]  inner join [dbo].[SportMaterial] ";
            di.str2 += "on [dbo].[SportMaster].[SportMaterialID]=[dbo].[SportMaterial].[MaterialID]";
            di.str2 += "where [dbo].[SportMaster].[TakerId]='" + di.str1 + "'";

            di.di = new Case().LoadCase(di);
            if (di.di.Bool)
            {

                Mlist.DataSource = di.di.ds;
                Mlist.DataBind();
            }

        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            DataItem di = new DataItem();
            int count = 0;
            foreach (GridViewRow row in Mlist.Rows)
            {
                CheckBox chBox = row.FindControl("checkall") as CheckBox;
                di.sqlcmd = new SqlCommand();
                if (chBox.Checked)
                {
                    di.sqlcmd.CommandText = "delete from [dbo].[SportMaster] where [TakerId]=@studId and SportMaterialID=@Mid;";
                    di.sqlcmd.Parameters.AddWithValue("@studId", StudID.Text);
                    di.sqlcmd.Parameters.AddWithValue("@Mid", row.Cells[2].Text.ToString());
                    new Case().ignoreCase(di);
                    row.Visible = false;
                    Mlist.Rows[count].Visible = false;
                }
                else
                {
                    TextBox tbox = row.FindControl("txtBox") as TextBox;
                    if (tbox.Text != "") //in here we have to use real validation like only number 
                    {
                        di.sqlcmd.CommandText = "update [dbo].[SportMaster] set  amount=amount-@amount where [TakerId]=@studid and SportMaterialID=@Mid; ";
                        di.sqlcmd.Parameters.AddWithValue("@studId", StudID.Text);
                        di.sqlcmd.Parameters.AddWithValue("@Mid", row.Cells[2].Text.ToString());
                        di.sqlcmd.Parameters.AddWithValue("@amount", tbox.Text);
                        Response.Write(tbox.Text);
                        new Case().ignoreCase(di);            
                        row.Cells[4].Text = (Convert.ToInt32(row.Cells[4].Text) - Convert.ToInt32(tbox.Text)) + "";
                        if (Convert.ToInt32(row.Cells[4].Text) < 1)
                        {
                            di.sqlcmd.CommandText = "delete from [dbo].[SportMaster] where [TakerId]=@studId0 and SportMaterialID=@Mid0;";
                            di.sqlcmd.Parameters.AddWithValue("@studId0", StudID.Text);
                            di.sqlcmd.Parameters.AddWithValue("@Mid0", row.Cells[2].Text.ToString());
                            new Case().ignoreCase(di);
                            row.Visible = false;
                        }
                    }
                }
                count++;
            }
        }
    }
}