using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClearanceSystem.Offices.Student.Proctor
{
    public partial class Record_Case : System.Web.UI.Page
    {

        public string state;
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Response.Write(Session["username"]);
            Response.Write(Session["block"]);
            //if (Session["username"] != null)
            //{
            //    if (Session["postion"] as string != 4 + "")
            //        Response.Redirect("../../../Login.aspx");
            //}
            //else
            //    Response.Redirect("../../../Login.aspx");
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
            Return rtn = new Return();
            DataItem di = new DataItem();
            di.str1 = StudId.Text;
            di.str2 = Session["block"] as string;
            rtn = new ClearanceSystem.Student().LoadDetail(di, "BlockStud");
            Session["ds"] = rtn.ds;
            if (rtn.Bool)
            { //SELECT [Name],[DormNum],[Photo] FROM [KiotDBClear].[dbo].[Student] where [ID]='"+di.str1+"' and [Block]='"+di.str2+"'";
                lblName.Text = (string)rtn.ds.Tables[0].Rows[0][0];
                lblDorm.Text = (string)rtn.ds.Tables[0].Rows[0][1];
                photo.ImageUrl = "~/" + (string)rtn.ds.Tables[0].Rows[0][2]; ;
                photo.AlternateText = lblName.Text;
                loadGrid();
                state = "collapse in";
            }
            else
            {
                wStud.Text = "";
                state = "panel-collapse collapse";
                wStud.Text = "No student with this id number on this block";                
                wStud.ForeColor = System.Drawing.Color.Red;

            }

        }

        protected void submit_Click(object sender, EventArgs e)
        {

            foreach (GridViewRow row in GridView1.Rows)
            {
                if ((row.Cells[0].FindControl("CheckBox1") as CheckBox).Checked &&  Convert.ToInt64(row.Cells[2].Text)>0 )
                {
                    DataItem di = new DataItem();
                    //"update  [dbo].[BlockMaterial]  set [Quantity]=[Quantity]-1 where [BlockID]='" + di.str1+"' and id='"+di.str2+"'";
                    //    di.str1 = EmpID.Text;
                    di.str1 = Session["block"] as string;//change the block with logedin session
                    di.str2 = row.Cells[3].Text;//materila id
                    di.str3 = "1";//quantity
                    di.str4 = StudId.Text;//student id
                        // Response.Write("ID" + di.str1);
                    new Record().RecordForClear(di, "BlockMaterialTaker");
                    di.str10 = "down";
                    new Record().RecordForClear(di, "updateBlockMaterial");

                    //updateQuantity update block material

                loadGrid();
                }
                else
                    if (Convert.ToInt64(row.Cells[2].Text) > 0)
                    {
                        Response.Write("<javascript>Alter()");
                    }
            }
        }
        void loadGrid()
        {
            DataItem loadM = new Material().LoadMaterial(Session["block"] as string, "BlockMaterial");
            GridView1.DataSource = loadM.ds;
            GridView1.DataBind();
        }
    }
}