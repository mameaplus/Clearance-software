using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClearanceSystem.Offices.Both.Library
{
    public partial class Ignore : System.Web.UI.Page
    {
        public string state;
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void Load_Click(object sender, EventArgs e)
        {
            DataItem distr = new DataItem();
            distr.str1 = StudID.Text;
          Return rtn=   new ClearanceSystem.Student().LoadDetail(distr, "Library");
          if (rtn.Bool)
          {
              lblname.Text = (string)rtn.ds.Tables[0].Rows[0][1] ;
              lblDep.Text = (string)rtn.ds.Tables[0].Rows[0][2];
              photo.ImageUrl = (string)rtn.ds.Tables[0].Rows[0][5]; 
              photo.AlternateText=(string)rtn.ds.Tables[0].Rows[0][1] ;            
          }
          LoadMaterial();
        }
        protected void Rcive_Click(object sender, EventArgs e)
        {
           
            for (int i = 0; i < CheckBoxBookList.Items.Count; i++)
            {
                if (CheckBoxBookList.Items[i].Selected)
                {
                    new Material().Receive(StudID.Text, CheckBoxBookList.Items[i].Value.ToString());
                }
            }
            LoadMaterial();
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