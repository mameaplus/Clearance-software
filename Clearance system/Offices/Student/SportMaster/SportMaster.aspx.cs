using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ClearanceSystem
{
    public partial class SportMaster : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Load"].ConnectionString);
        
        public int op; 
        public string name, id, Dep, DormNum, statu, photo, Block, state,btncss;
        public string BookTtl, amount;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            state = "panel-collapse collapse";
          //  btncss = "btn btn-success";
            SetDataSet();
            table();
        }       
        protected void Load_Click(object sender, EventArgs e)
        {        
          //  table( );
          //  SetDataSet();
            Student s = new Student();
            DataItem di = new DataItem();
            di.str1 = (string)StudID.Text;
            Return rtnStudent = s.LoadDetail(di,"sportMaster");

            if (!rtnStudent.Bool)
            {
                wStud.ForeColor = System.Drawing.Color.Red;
                wStud.Text = "Student with this id not exist";
                state = "panel-collapse collapse";
            }
            else
            {
                Session["stud"] = rtnStudent.ds;
                Session["SID"] = StudID.Text;
                readStud((DataSet)Session["stud"]);   
                 
                //sendEmail((string)rtnStudent.ds.Tables[0].Rows[0][6]);
                state = "collapse in";
            }
        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            readStud((DataSet)Session["stud"]);
            Response.Write((string)Session["Code&Email"]);          
             if (AcodeTB.Text == (string)Session["Code&Email"])     //Wrong             
            {             
                for (int i = 0; i < ((DataSet)Session["tblDS"]).Tables[0].Rows.Count ; i++)
                {                   
                DataItem di = new DataItem();
                di.str4 = ((TextBox)MList.FindControl("tb" + i)).Text;                

                 if (di.str4 != "")
                 {
                     di.str1 =( MList.FindControl("id"+i) as TableCell).Text;
                     di.str2 = (string)Session["SID"];
                     di.str3 = "student";
                     di.str5 = DateTime.Now + "";
                     di.str6 = DateTime.Now + "";
                     new Record().SportRecord( di);

                 }
                }                  
          //  new Record().SportRecord(con, di);
            }    
            state = "collapse in";
        }

        protected void Genrate_Click(object sender, EventArgs e)
        {
            readStud((DataSet)Session["stud"]);
            //table();
                   //  DataItem di=new DataItem();
            //for(int i=0;i<max;i++){            
           // Label1.Text=((TextBox)FindControl("tb"+1)).Text;
         //   td1.InnerText= Label1.Text = ViewState["textBox" + i].ToString();
         //   }

                    //????????from sport master ?????????//
         Session["Code&Email"]= new Class().sendEmail((string)Session["Code&Email"],"Sport Master"); //
           state = "collapse in";                                 //???????????????????????????????????//   
           Response.Write(Session["Code&Email"]+"");
        }
        void readStud(DataSet ds)
        {
            name = (string)ds.Tables[0].Rows[0][1];
            Dep = (string)ds.Tables[0].Rows[0][2];
            Block = (string)ds.Tables[0].Rows[0][3];
            DormNum = (string)ds.Tables[0].Rows[0][4];        
            Image1.ImageUrl = (string)ds.Tables[0].Rows[0][5];
            Image1.AlternateText = name;
            Session["Code&Email"] = (string)ds.Tables[0].Rows[0][6];
           // Session["StudDS"] = ds;               
        }
        Return table()
        {
            Return rtn=new Return();
            DataSet ds=(DataSet)Session["tblDS"];
            rtn.ds = ds;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                int max = (int)ds.Tables[0].Rows[i][2];
                TableRow row = new TableRow();
                //    row.CssClass = "success";   
                //FOR MATERIAL ID
                TableCell cell0 = new TableCell();
                cell0.Text = (string)ds.Tables[0].Rows[i][0];
             //   cell0.CssClass = "auto-style4";
                cell0.ID = "id" + i;
                row.Cells.Add(cell0);
                //for name of material
                TableCell cell1 = new TableCell();
                cell1.Text = (string)ds.Tables[0].Rows[i][1];
               // cell1.CssClass = "auto-style4";
                cell1.ID = "nm" + i;
                row.Cells.Add(cell1);
                //for amount of material
                TableCell cell2 = new TableCell();
                //cell2.CssClass = "auto-style4";
                cell2.Text=   max + "";
                cell2.ID = "am" + i;             
                row.Cells.Add(cell2);
                //for users need
                TableCell cell3 = new TableCell();
                TextBox tb = new TextBox();
                tb.CssClass = "form-control";             
                tb.ID = "tb" + i;
                tb.Width = 56;  
                row.Cells.Add(cell3);
                /////////////////////////////////////
                if (max <= 0) tb.Enabled = false;         //
                else tb.Enabled = true;                      //
                cell3.Controls.Add(tb);                   //
                /////////////////////////////////               
                // Add the TableRow to the Table
                MList.Rows.Add(row);
            }
            return rtn;
        }
        Return SetDataSet() {
            Return rtn = new Return();
            con.Open();
            using (con)
            {           
                MList.CssClass = "table";
                DataSet ds = new DataSet();                
                SqlDataAdapter da = new SqlDataAdapter("select * from  SportMaterial ", con);
                da.Fill(ds);
                rtn.ds = ds;
                Session["tblDS"] = ds;     
            }
            return rtn;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ((DataSet)Session["tblDS"]).Tables[0].Rows.Count-1; i++) {
               
            }
        }
    }
}