using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
namespace ClearanceSystem.Users
{
    public partial class Create_account : System.Web.UI.Page
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
            dii.str1 = email.Text + "";
            ViewState["email"] = lblemail.Text = dii.str1;

            ViewState["postion"] = accountlist.SelectedValue.ToString();
            dii.str3 = ViewState["postion"] as string;
            Return di = new ClearanceSystem.Student().LoadDetail(dii, "StudEmail");
            if (!di.Bool)
            {
                wEmail.Text = "You have no permission to create this account !!";
                wEmail.ForeColor = System.Drawing.Color.Red;
                state = "panel-collapse collapse";
            }
            else
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Load"].ConnectionString.ToString());
                con.Open();
                string uname="";
                if(accountlist.SelectedValue=="40")
                    uname="[postion]='40' and   [username] ";
                else if(accountlist.SelectedValue=="30")
                     uname="[postion]='30' and   [username] ";


                DataItem dss = new RegisterExcel().ColDataIsExist(con, email.Text, uname, "  [KiotDBClear].[dbo].[User]  ");

                if (!dss.Bool)
                {
                    wEmail.Text = "User name exist !";
                    wEmail.ForeColor = System.Drawing.Color.Red;
                    state = "panel-collapse collapse";
                }
                else
                {
                    //vcode ??wEmail mus
                    wEmail.Text = "";

                    ViewState["Id"] = di.ds.Tables[0].Rows[0][1].ToString();
                    Session["Code"] = new Class().sendEmail(di.ds.Tables[0].Rows[0][0].ToString(), "");
                    ViewState["email"] = email.Text;
                    dii.str2 = Session["Code"] as string;
                    DataItem sms = new DataItem();
                    sms.str1 = di.ds.Tables[0].Rows[0][2].ToString();
                    sms.str2 = "(FROM REGISTRAR :)) create your account by using this verification code  :" + Session["Code"] as string;
                    new Message().SendSms(sms);
                    new Record().RecordForClear(dii, "RegisterVcode");//re
                    state = "collapse in";
                }
                con.Close();
            }
        }

        protected void cancel_Click(object sender, EventArgs e)
        {

        }

        protected void create_Click(object sender, EventArgs e)
        {
            bool isOk = true;
            DataItem di = new DataItem();
            if (getPhoto.HasFile)
            {
                string filexe = Path.GetExtension(getPhoto.FileName);
                if (filexe == ".jpg" || filexe == ".png" || filexe == ".jpeg")
                {//    ../image/Identity/StudentPhoto/
                    if (getPhoto.PostedFile.ContentLength > 50000)
                    {
                        isOk = false;
                        wgetph.Text = "The content length is above expected !";
                        wgetph.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        di.str9 ="image/Identity/StudentPhoto/" + getPhoto.PostedFile.FileName;
                        getPhoto.SaveAs(Server.MapPath("../image/Identity/StudentPhoto/" + getPhoto.PostedFile.FileName));
                        isOk = true;
                    }

                }
                else
                {
                    isOk = false;
                    wgetph.Text = "please select only image file !";
                    wgetph.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                isOk = false;
                wgetph.Text = "First upload you photo file please !";
                wgetph.ForeColor = System.Drawing.Color.Red;
            }
            if (!(vcode.Text == Session["Code"] as string))
            {
                isOk = false;
                wvcode.ForeColor = System.Drawing.Color.Red;
                wvcode.Text = "Verification code not match";
                
            }
             
           
            
            if (isOk)
            {
                wvcode.Text = "";
                wgetph.Text = "";
                di.sqlcmd = new SqlCommand();
                if (accountlist.SelectedValue == "30")
                    di.sqlcmd.CommandText = "update [dbo].[Student] set [Photo]=@photo  where [Email]=@email";
                if (accountlist.SelectedValue == "40")
                    di.sqlcmd.CommandText = "update  [dbo].[Employee] set [Photo]=@photo where [Email]=@email";
                di.sqlcmd.Parameters.AddWithValue("@photo", di.str9);
                di.sqlcmd.Parameters.AddWithValue("@email", ViewState["email"] as string);
                Response.Write(di.sqlcmd.CommandText);
                new Case().ignoreCase(di);
                di.str1 = ViewState["email"] as string;//user email
                di.str2 = vcode.Text;//verfication code
                di.str3 = ViewState["postion"] as string;//postion
                di.str4 = confpassword.Text;
                di.str5 = ViewState["Id"] as string;
                di = new Account().createAccount(di);
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
}