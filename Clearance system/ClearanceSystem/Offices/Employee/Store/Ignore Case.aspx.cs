using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


namespace ClearanceSystem.Offices.Employee.Store
{
    public partial class Ignore_Case : System.Web.UI.Page
    {

        public string state;
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Session["url"] = HttpContext.Current.Request.Url.AbsolutePath;
            if (Session["username"] != null)
            {
                if (Session["postion"] as string != 5 + "")
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

        protected void Load_Click(object sender, EventArgs e)
        {
            DataItem di = new DataItem();
            di.str1 = StudID.Text;
            Return rtn;
            rtn = new ClearanceSystem.Student().LoadDetail(di, "Employee");

            if (rtn.Bool)
            {
                lblName.Text = (string)rtn.ds.Tables[0].Rows[0][0];
                lblDep.Text = (string)rtn.ds.Tables[0].Rows[0][1];
                photo.ImageUrl = "~/" + (string)rtn.ds.Tables[0].Rows[0][2];
                photo.AlternateText = lblName.Text;
                state = "collapse in";
                WStudID.Text = "";
            }
            else
            {
                WStudID.Text = "No student with this id number";
                WStudID.ForeColor = System.Drawing.Color.Red;
                state = "panel-collapse collapse";
            }
            //"insert into SportMaster values(@amount,@TakerId,@postion,@sportMID,@acode,@date,@ExpDate)";

            di.str2 = "select [dbo].[Store_Material].[ID],[dbo].[Store_Material].[Name],[dbo].[StoreCaseRecord].[Quantity]";
            di.str2 += "from  [dbo].[StoreCaseRecord] inner join [dbo].[Store_Material]";
            di.str2 += "on  [dbo].[Store_Material].[ID]=[dbo].[StoreCaseRecord].[MaterialID] ";
            di.str2 += "where [dbo].[StoreCaseRecord].[TakerId]='" + di.str1 + " '";
            di.sqlcmd = new SqlCommand();
            di.sqlcmd.CommandText = di.str2;
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
                    di.sqlcmd.CommandText = " update [dbo].[Store_Material] set  [Quantity]=[Quantity]+@amount where  [id]=@Mid;";
                    di.sqlcmd.CommandText += "delete from [dbo].[StoreCaseRecord] where [TakerId]=@studId and [MaterialID]=@Mid;";
                    di.sqlcmd.Parameters.AddWithValue("@studId", StudID.Text);
                    di.sqlcmd.Parameters.AddWithValue("@Mid", row.Cells[2].Text.ToString());
                    di.sqlcmd.Parameters.AddWithValue("@amount", row.Cells[4].Text);
                    new Case().ignoreCase(di);
                    row.Visible = false;
                    Mlist.Rows[count].Visible = false;
                }
                else
                {
                    TextBox tbox = row.FindControl("txtBox") as TextBox;
                    if (tbox.Text != "") //in here we have to use real validation like only number 
                    {
                        di.sqlcmd.CommandText = " update [dbo].[StudSportMaterial] set  [Quantity]=[Quantity]+@amount where  [id]=@Mid;";
                        di.sqlcmd.CommandText += " update [dbo].[StoreCaseRecord] set  [Quantity]=[Quantity]-@amount where [TakerId]=@studid and MaterialID=@Mid;";
                        di.sqlcmd.Parameters.AddWithValue("@studId", StudID.Text);
                        di.sqlcmd.Parameters.AddWithValue("@Mid", row.Cells[2].Text.ToString());
                        di.sqlcmd.Parameters.AddWithValue("@amount", tbox.Text);                       
                        new Case().ignoreCase(di);
                        row.Cells[4].Text = (Convert.ToInt32(row.Cells[4].Text) - Convert.ToInt32(tbox.Text)) + "";
                        if (Convert.ToInt32(row.Cells[4].Text) < 1)
                        {
                            di.sqlcmd.CommandText = "delete from [dbo].[StoreCaseRecord] where [TakerId]=@studId0 and MaterialID=@Mid0;";
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
