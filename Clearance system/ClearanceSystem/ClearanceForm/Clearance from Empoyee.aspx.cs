using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ClearanceSystem.ClearanceForm
{
    public partial class Clearance_from_Empoyee : System.Web.UI.Page
    {

        bool IcanPrint = true; public string disable = ""; public int uncleared = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["postion"] = "Employee";
            DataItem val = new DataItem();
            val.str1 = Session["id"] as string;
            DataItem di = new ClearanceSystem.Clearance().checkclearnessEmployee(val);
         
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
            cmdlist[1] = "select  [dbo].[Library].BookID ,[dbo].[BookLibrary].[Title] from [dbo].[Library] inner join [dbo].[BookLibrary] on [dbo].[Library].BookID=[dbo].[BookLibrary].[BookId]   where  [dbo].[Library].TakerId='" + val.str1 + "'";//Employee
            cmdlist[0] = "select [Credit],[Reason], [Date] from [dbo].[Finance]  where [dbo].[Finance].Id='" + val.str1 + "'";
            cmdlist[3] = "select [Credit],[Resone], [Date] from [dbo].[SavingCreditA] where [dbo].[SavingCreditA].[ID]='" + val.str1 + "'";
            cmdlist[2] = "select [dbo].[StoreCaseRecord].MaterialID , [dbo].[Store_Material].[Name],[dbo].[StoreCaseRecord].[Quantity] from [dbo].[StoreCaseRecord] inner join [dbo].[Store_Material] on [dbo].[Store_Material].[ID]=[dbo].[StoreCaseRecord].MaterialID    where [dbo].[StoreCaseRecord].TakerId='" + val.str1 + "'";
            foreach (DataTable dt in di.ds.Tables)
            {    //record based clearness 
                if (!(dt.Rows.Count <= 0))//if the Employe is cleared from  the office
                {
                    if (count == 0)
                    {
                        dt.Rows[0][1] = "cashier";
                    }
                    if (count == 1)
                    {
                       dt.Rows[0][1] = "Book Store (stack disk)";
                    }
                    if (count == 3)
                    {
                        dt.Rows[0][1] = "Saving and credit Assocation";
                    }
                    clearancetbl.ImportRow(dt.Rows[0]);
                }
                else
                {
                    if (count != 6)//if not clear check if the student is contact to AD
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
                DataRow fainance = clearancetbl.NewRow();
                fainance[0] = "5";
                fainance[1] = "Fainance";
                fainance[2] = "sign.png";
                clearancetbl.Rows.Add(fainance);
                DataRow property = clearancetbl.NewRow();
                property[0] = "5";
                property[1] = "property Administration";
                property[2] = "sign.png";
                clearancetbl.Rows.Add(property);
                DataRow Managing = clearancetbl.NewRow();
                Managing[0] = "5";
                Managing[1] = "Managing Director";
                Managing[2] = "sign.png";
                clearancetbl.Rows.Add(Managing);
                DataRow Scientific = clearancetbl.NewRow();
                Scientific[0] = " 55";
                Scientific[1] = "Scientific Director ";
                Scientific[2] = "sign.png";
                clearancetbl.Rows.Add(Scientific);
                DataRow student = clearancetbl.NewRow();
                student[0] = " 55";
                student[1] = "student Director ";
                student[2] = "sign.png";
                clearancetbl.Rows.Add(student);
                DataRow Register = clearancetbl.NewRow();
                Register[0] = " 55";
                Register[1] = "Registrar Office";
                Register[2] = "sign.png";
                clearancetbl.Rows.Add(Register);
            }
            Session["unclearedoff"] = cmduncleared;
            Session["last"] = uncleared;

            GridView1.DataSource = clearancetbl;
            GridView1.DataBind();
        }
    }
}