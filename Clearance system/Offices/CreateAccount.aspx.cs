using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClearanceSystem.Offices
{
    public partial class CreateAccount : System.Web.UI.Page
    {
        public string state;
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
        protected void LoadEmail_Click(object sender, EventArgs e)
        {
            DataItem dii = new DataItem();
            //email
            dii.str1 = email.Text + "";
            ViewState["email"] = lblemail.Text = dii.str1;
            ViewState["postion"] = accountlist.SelectedValue.ToString();
            dii.str3 = ViewState["postion"] as string;
            Return di = new ClearanceSystem.Student().LoadDetail(dii, "StudEmail");
            if (!di.Bool)
            {
                wEmail.Text = "You have no permission to create this account !!";
                wEmail.ForeColor = System.Drawing.Color.Red;
            }
            else
            {   //vcode ??wEmail mus
                wEmail.Text = "";
                ViewState["Id"] = di.ds.Tables[0].Rows[0][1].ToString();
                wEmail.Text = dii.str2 = new Class().sendEmail(di.ds.Tables[0].Rows[0][0].ToString(), "(FROM REGISTRAR :)) create your account by using this verification code");
                new Record().RecordForClear(dii, "RegisterVcode");//re
                
            }
        }

        protected void cancel_Click(object sender, EventArgs e)
        {

        }

        protected void create_Click(object sender, EventArgs e)
        {
            DataItem di = new DataItem();
            di.str1 = ViewState["email"] as string;//user email
            di.str2 = vcode.Text;//verfication code
            di.str3 = ViewState["postion"] as string;//postion
            di.str4 = confpassword.Text;
            di.str5 = ViewState["Id"] as string;
            Response.Write(di.str1 + "<br/>");
            Response.Write(di.str2 + "<br/>");
            Response.Write(di.str3 + "<br/>");
            Response.Write(di.str4 + "<br/>");
            Response.Write(di.str5 + "<br/>");
            di=new Account().createAccount(di);
            if (di.Bool)
            {
                isok.Text = " Account has been created successfully !! ";
                isok.ForeColor = System.Drawing.Color.LightSeaGreen;
            }
            else
            {
                if (di.str10 != "")
                    isok.Text = di.str10;
               // isok.Text = " Account not created successfully !! ";
                isok.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}