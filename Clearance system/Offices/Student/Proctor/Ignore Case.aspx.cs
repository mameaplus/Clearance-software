using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClearanceSystem.Offices.Student.Proctor
{
    public partial class Ignore_Case : System.Web.UI.Page
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

            DataItem di = new DataItem();
            di.str1 = StudID.Text;          
            di.str3 = Session["block"] as string;
            Return rtn;
            rtn = new ClearanceSystem.Student().LoadDetail(di, "Procter");
            if (rtn.Bool)
            {
                lblname.Text = (string)rtn.ds.Tables[0].Rows[0][1];
                photo.ImageUrl = "~/" + (string)rtn.ds.Tables[0].Rows[0][2];
                photo.AlternateText = photo.ImageUrl;
                LoadMaterial(di);
                state = "collapse in";
                wEmp.Text = "";               
                di.str1= StudID.Text;
                LoadMaterial(di);

            }
            else
            {
            
                state = "panel-collapse collapse";
                wEmp.Text = "No student with this id on this Block";
                wEmp.ForeColor = System.Drawing.Color.Red;
            }

        }

        protected void cancel_Click(object sender, EventArgs e)
        {

        }

        protected void update_Click(object sender, EventArgs e)
        {

        }

        protected void GoCase_Click(object sender, EventArgs e)
        {

        }

        protected void Rcive_Click(object sender, EventArgs e)
        {
            DataItem di = new DataItem();
            for (int i = 0; i < CheckBoxBookList.Items.Count; i++)
            {            
                if (CheckBoxBookList.Items[i].Selected)
                {
                    di.str1 = StudID.Text; 
                    di.str2 = CheckBoxBookList.Items[i].Value.ToString();
                    new Material().ReceiveAll(di);
                }
            }
            di.str1 = StudID.Text;
            di.str3 = Session["block"] as string;
            LoadMaterial(di);
        }
        void LoadMaterial(DataItem di)
        {
            di.str10 = "Proctor";         
            DataItem Dataget = new Material().LoadMaterialAll(di);
            CheckBoxBookList.DataSource = Dataget.ds;
            CheckBoxBookList.DataTextField = "MaterialName";
            CheckBoxBookList.DataValueField = "Id";
            CheckBoxBookList.DataBind();
        }

    }
}