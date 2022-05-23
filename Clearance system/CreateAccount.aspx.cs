using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClearanceSystem
{
    public partial class CreateAccount : System.Web.UI.Page
    {
        public string VEmailCode, state;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                state = "panel-collapse collapse";
          
        }

        protected void Load_Click(object sender, EventArgs e)
        {
            DataItem itm=new DataItem();
            itm.str1=Email.Text;
            Return rtn = new Student().LoadDetail(itm, "CreateAccount");
            if (!((int)rtn.ds.Tables[0].Rows[0][0]>0))
            {
                state = "panel-collapse collapse";
            }
            else
                state = "collapse in";
           
        }

         
    }
}