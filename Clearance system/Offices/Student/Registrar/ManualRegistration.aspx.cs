using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
namespace ClearanceSystem.Offices.Student.Registrar
{
    public partial class ManualRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["url"] = HttpContext.Current.Request.Url.AbsolutePath;
        }
        protected void submit_Click(object sender, EventArgs e)
        {



            DataItem di = new DataItem();
            di.str1 = Name.Text+" "+txtlast.Text;
            di.str2 = StudId.Text;
            di.str3 = Dep.Text;
            di.str4 = Phone.Text;
            di.str5 = Email.Text;
            di.str6 = "B.No"+Block.Text; 
            di.str7 = DormNum.Text;
            new Record().RecordForClear(di, "StudRegister");
            isreg.Text = "Successfully registered ! ";
            isreg.ForeColor = System.Drawing.Color.LightSeaGreen;
        }

        protected void Dep_TextChanged(object sender, EventArgs e)
        {

        }

        //
    }


}
