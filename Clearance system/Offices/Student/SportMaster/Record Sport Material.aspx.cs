using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClearanceSystem.Offices.Student.SportMaster
{
    public partial class Record_Sport_Material : System.Web.UI.Page
    {

        public string State1 = "panel-collapse collapse", State2 = "panel-collapse collapse";
        public int TL, TR, BL, BR;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                TL = 0; TR = 0; BL = 0; BR = 0;
                State2 = "collapse in ";
                State1 = "panel-collapse collapse";
            }

        }
        //  border-top-left-radius: <% Response.Write(190);%>px; border-top-right-radius: 25px; 
        //  border-bottom-right-radius:25px ;border-bottom-left-radius:25px;
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            TL = 0; TR = 0; BL = 25; BR = 25;
            State1 = "collapse in ";
            State2 = "panel-collapse collapse";
        }

        protected void Excel_Click(object sender, EventArgs e)
        {
            TL = 0; TR = 0; BL = 0; BR = 0;
            State2 = "collapse in ";
            State1 = "panel-collapse collapse";
        }

        protected void Register_Click(object sender, EventArgs e)
        {

        }

        protected void Register1_Click(object sender, EventArgs e)
        {

        }

      

    }
}