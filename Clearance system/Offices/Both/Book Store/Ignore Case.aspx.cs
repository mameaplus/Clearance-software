using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClearanceSystem.Offices.Both.Book_Store
{
    public partial class Ignore_Case : System.Web.UI.Page
    {
        public string state;
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            Session["url"] = HttpContext.Current.Request.Url.AbsolutePath;
            if (Session["username"] != null)
            {
                if (Session["postion"] as string != 14 + "")
                    Response.Redirect("../../../Login.aspx");
            }
            else
                Response.Redirect("../../../Login.aspx");
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            state = "panel-collapse collapse";

        }
        protected void Load_Click(object sender, EventArgs e)
        {
            DataItem distr = new DataItem();
            distr.str1 = StudID.Text;
            Return rtn = new ClearanceSystem.Student().LoadDetail(distr, "Library");
            if (rtn.Bool)
            {
                lblname.Text = (string)rtn.ds.Tables[0].Rows[0][1];
                lblDep.Text = (string)rtn.ds.Tables[0].Rows[0][2];
                photo.ImageUrl = "~/" + (string)rtn.ds.Tables[0].Rows[0][5];
                photo.AlternateText = (string)rtn.ds.Tables[0].Rows[0][1];
                state = "collapse in";


            }
            LoadMaterial();
        }
        protected void Rcive_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < CheckBoxBookList.Items.Count; i++)
            {
                if (CheckBoxBookList.Items[i].Selected)
                {
                    new Material().Receive(StudID.Text, CheckBoxBookList.Items[i].Value.ToString(),"b");
                }
            }
            LoadMaterial();
            state = "collapse in";
        }
        void LoadMaterial()
        {
            DataItem di = new Material().LoadMaterial(StudID.Text, "Library");
            CheckBoxBookList.DataSource = di.ds;
            CheckBoxBookList.DataTextField = "title";
            CheckBoxBookList.DataValueField = "BookId";
            CheckBoxBookList.DataBind();
        }
    }
}