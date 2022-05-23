using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClearanceSystem.Offices.Student.Proctor
{
    public partial class Record_Material : System.Web.UI.Page
    {
        public string state;
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
        protected void Page_PreLoad(object sender, EventArgs e)
        {
        //    if (Session["username"] != null)
        //    {
        //        if (Session["postion"] as string != 4 + "")
        //            Response.Redirect("../../../Login.aspx");
        //    }
        //    else
        //        Response.Redirect("../../../Login.aspx");
       }
        protected void submit_Click(object sender, EventArgs e)
        {
            /*
                    cmd.Parameters.AddWithValue("@NAME,", di.str1);
                    cmd.Parameters.AddWithValue("@Quantity", di.str2);
                    cmd.Parameters.AddWithValue("@BlockId", di.str3);              
             */
            DataItem di = new DataItem();
            di.str1 = MName.Text;
            di.str2 = MQ.Text;
            di.str3 = Session["block"] as string;
            new Record().RecordForClear(di, "RecordBlockMaterial");
        }

        protected void Date_TextChanged(object sender, EventArgs e)
        {

        }
    }
}