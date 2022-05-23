using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ClearanceSystem.ClearanceForm
{
    /* <a href="../Users/Employee/Employee.aspx">.
  * ./Users/Employee/Employee.aspx</a><a href="../Users/Student/Student.aspx">../Users/Student/Student.aspx</a>*/
    public partial class Clearance_From : System.Web.UI.Page
    {
        bool IcanPrint = true; public string disable = ""; public int uncleared = 0;
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            DataItem val = new DataItem();
            val.str3 = Session["id"] as string;
        
            bool statuse = !new Student().LoadDetail(new DataItem(), "clearState").Bool;
            //new Student().LoadDetail(val, "AD").Bool
            if (!new Student().LoadDetail(val, "AD").Bool) //if service is stop
            {
                if (statuse)
                {
                    Session["msg"] = "Service not started";
                    Response.Redirect("../Users/Student/Student.aspx");
                }

            }
            else
                Session["msg"] = null;
        

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            DataItem val = new DataItem();
            val.str3 = Session["id"] as string;
            Session["postion"] = "student";
            DataItem di = new ClearanceSystem.Clearance().checkclearness(val);
            string[] offices = new string[10];
            string[] unclearedOffice = new string[10];
            DataTable clearancetbl = new DataTable();

            clearancetbl.Columns.AddRange(new DataColumn[3]
            {              
                new DataColumn("ID",typeof(string)),
                new DataColumn("StaffName",typeof(string)),
                new DataColumn("sign",typeof(string)),                                                                                                                                                  
            });
            int count = 0; string[] cmdlist = new string[10]; string[] cmduncleared = new string[10];
            string studId = Session["id"] as string;
            offices[0] = "Student"; offices[1] = "Library"; offices[2] = "BookStore"; offices[3] = "SportMaster"; offices[4] = "StudentCafe"; offices[5] = "dormitory";
            offices[6] = "police"; offices[7] = "CostSharing";
            //this is not more important 
            cmdlist[0] = "";//student
            cmdlist[1] = "select    [dbo].[Library].BookID ,[dbo].[BookLibrary].[Title] from [dbo].[Library] inner join [dbo].[BookLibrary] on [dbo].[Library].BookID=[dbo].[BookLibrary].[BookId]   where  [dbo].[Library].TakerId='" + studId + "' and  [dbo].[Library].[staff]='l'";
            cmdlist[2] = "select    [dbo].[Library].BookID ,[dbo].[BookLibrary].[Title] from [dbo].[Library] inner join [dbo].[BookLibrary] on [dbo].[Library].BookID=[dbo].[BookLibrary].[BookId]   where  [dbo].[Library].TakerId='" + studId + "' and  [dbo].[Library].[staff]='B'";
            cmdlist[3] = "select    [dbo].[SportMaster].SportMaterialID ,[dbo].[StudSportMaterial].[Name] from [dbo].[SportMaster]inner join [dbo].[StudSportMaterial] on [dbo].[StudSportMaterial].[id]=[dbo].[SportMaster].SportMaterialID where [dbo].[SportMaster].[TakerId]='" + studId + "'";
            cmdlist[4] = "select    [dbo].[StudentCafe].[Case] as [StudentCafe]from [dbo].[StudentCafe] where [dbo].[StudentCafe].[ID]='" + studId + "'";
            cmdlist[5] = "select    [dbo].[BlockMaterialTaker].MaterialID ,[dbo].[BlockMaterial].[Name] from [dbo].[BlockMaterialTaker]inner join [dbo].[BlockMaterial] on [dbo].[BlockMaterialTaker].MaterialID=[dbo].[BlockMaterial].id where [dbo].[BlockMaterialTaker].TackerID='" + studId + "'";
            cmdlist[6] = "";
            cmdlist[7] = "select    [dbo].[police].[Case] as [police] from [dbo].[police] where [dbo].[police].[ID]='" + studId + "'";
            cmdlist[8] = "select    [dbo].[CostSharing].[case]  as[CostSharing] from [dbo].[CostSharing] where [dbo].[CostSharing].[id]='" + studId + "'";

            foreach (DataTable dt in di.ds.Tables)
            {    //record based clearness 
                if (!(dt.Rows.Count <= 0))//if the student is cleared from  the office sign for him or her
                {
                    if (count == 0)
                    {
                        dt.Rows[0][1] = "Departement Head";
                    }
                    clearancetbl.ImportRow(dt.Rows[0]);
                }
                else
                {
                    if (count != 6) //if not clear check if the student is contact to AD
                    {
                        IcanPrint = false;
                        cmduncleared[uncleared] = cmdlist[count];
                        uncleared++;
                    }

                }

                if (!IcanPrint)
                    btnPrint.Enabled = false;
                count++;
            }
            if (uncleared == 0)
            {
                DataRow Finance = clearancetbl.NewRow();
                Finance[0] = "5";
                Finance[1] = "Financial Information";
                Finance[2] = "sign.png";
                clearancetbl.Rows.Add(Finance);
                DataRow DeanStud = clearancetbl.NewRow();
                DeanStud[0] = " 55";
                DeanStud[1] = "Dean of student ";
                DeanStud[2] = "sign.png";
                clearancetbl.Rows.Add(DeanStud);
                DataRow Regist = clearancetbl.NewRow();
                Regist[0] = " 55";
                Regist[1] = "Registrar";
                Regist[2] = "sign.png";
                clearancetbl.Rows.Add(Regist);
            }
            Session["unclearedoff"] = cmduncleared;
            Session["last"] = uncleared;
            GridView1.DataSource = clearancetbl;
            GridView1.DataBind();
        }
    }
}
