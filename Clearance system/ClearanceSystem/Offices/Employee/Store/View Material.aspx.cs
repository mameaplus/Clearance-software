using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClearanceSystem.Offices.Employee.Store
{
    public partial class View_Material : System.Web.UI.Page
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
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
            Session["url"] = HttpContext.Current.Request.Url.AbsolutePath;
            if (!IsPostBack)
                loadMaterial();
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
                //!= Convert.ToDouble(row.Cells[3].Text) 
                //    //new RegisterExcel().ColIsValid((row.Cells[0].FindControl("updatetxt") as TextBox).Text,"")
                if ((row.Cells[0].FindControl("updatetxt") as TextBox).Text != "")//patern maching
                {                  
                    if (!(Convert.ToDouble((row.Cells[0].FindControl("updatetxt") as TextBox).Text) <= 0))
                    {
                        DataItem di = new DataItem();
                        di.num1 = Convert.ToInt32(row.Cells[3].Text);;
                        di.str3 = (row.Cells[0].FindControl("updatetxt") as TextBox).Text;
                        di.str4 = "update";
                        di.str5 = count + "";          
                        new Record().RecordForClear(di, "store");
                        count++;                   
                    }               

                }             

            }
            loadMaterial();
           
        }
        void loadMaterial()
        {
            DataItem loadM = new Material().LoadMaterial("", "store");
            GridView1.DataSource = loadM.ds;
            GridView1.DataBind();
        }

    }
}
/*
  
 */