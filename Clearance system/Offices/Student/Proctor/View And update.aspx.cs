using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClearanceSystem.Offices.Student.Proctor
{
    public partial class View_And_update : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["url"] = HttpContext.Current.Request.Url.AbsolutePath;
            if (!IsPostBack)
                loadMaterial();

        }

        protected void Page_PreLoad(object sender, EventArgs e)
        {
            //if (Session["username"] != null)
            //{
            //    if (Session["postion"] as string != 4 + "")
            //        Response.Redirect("../../../Login.aspx");
            //}
            //else
            //    Response.Redirect("../../../Login.aspx");
        }
        protected void cancel_Click(object sender, EventArgs e)
        {
            // Response.Redirect("");
        }

        protected void update_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach (GridViewRow row in GridView1.Rows)
            {
                if ((row.Cells[0].FindControl("updatetxt") as TextBox).Text != "")//patern maching is bests
                {
                    if (!(Convert.ToDouble((row.Cells[0].FindControl("updatetxt") as TextBox).Text) <= 0))//if it is not less than or eqal to '0'
                    {
                        DataItem di = new DataItem();
                        di.str1 = (row.Cells[0].FindControl("updatetxt") as TextBox).Text;
                        di.str2 = row.Cells[3].Text;
                        di.str3 = Session["block"] as string;
                        di.str5 = count + "";
                        new Record().RecordForClear(di, "updateQuantity");
                        count++;
                    }

                }

            }
            loadMaterial();

        }
        void loadMaterial()
        {
            DataItem loadM = new Material().LoadMaterial(Session["block"] as string, "BlockMaterial");
            GridView1.DataSource = loadM.ds;
            GridView1.DataBind();
        }

    }
}