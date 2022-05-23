<%@ Page Title="" Language="C#" MasterPageFile="~/frontPageOffice.Master" AutoEventWireup="true" CodeBehind="Manual Registration.aspx.cs" Inherits="ClearanceSystem.Offices.Employee.HRM.Manual_Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 244px;
        }
        .auto-style2 {
            width: 248px;
        }
        .auto-style3 {
            width: 259px;
        }
        .auto-style4 {
            width: 278px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    
    <form id="form1" runat="server">
        <div class="container" style="margin: 0px; padding: 0px; width: 100%; color: steelblue; background-color: #202030; border-radius: 25px;">

            <div class="panel-group" id="accordion">
                <div class="">
                    <div class="panel-heading" style="margin: 0px; border-top-left-radius: 25px; border-top-right-radius: 25px; background-color: rgb(32, 32, 48);">
                                             
                    </div>
                    <div id="collapse" class="">
                        <div class="panel-body" style="background-color: #E7E9EA; height: 100%;">
                           <table class="table" style="border-radius: 20px 20px 20px 20px; height: 203px;">
                        <tr class="" style="background-color: #E7E9EA;">
                            <th class="auto-style4">First Name</th>
                            <td class="auto-style3" dir="rtl">

                                <asp:TextBox ID="TextBox1" runat="server" Height="29px" Width="200px" CssClass="form-control"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid name" ValidationExpression="^[a-zA-Z'.]{1,40}$" ControlToValidate="StudId" ForeColor="Red"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Name Required !" ForeColor="#CC0000" ControlToValidate="StudId"></asp:RequiredFieldValidator>
                            </td>
                            <th class="auto-style1"><span>Middle </span>Name</th>
                            <td class="auto-style1" dir="ltr">
                                <asp:TextBox ID="TextBox2" runat="server" Height="29px" Width="151px" CssClass="form-control"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Invalid name" ValidationExpression="^[a-zA-Z'.]{1,40}$" ControlToValidate="Dep" ForeColor="Red"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Name Required !" ForeColor="#CC0000" ControlToValidate="Dep"></asp:RequiredFieldValidator>
                            </td>

                        </tr>
                        <tr class="" style="background-color: #E7E9EA;">
                            <th class="auto-style4">Last Name</th>
                            <td class="auto-style3" dir="rtl">

                                <asp:TextBox ID="StudId" runat="server" Height="29px" Width="200px" CssClass="form-control"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="ValidStudid" runat="server" ErrorMessage="Invalid name" ValidationExpression="^[a-zA-Z'.]{1,40}$" ControlToValidate="StudId" ForeColor="Red"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Name Required !" ForeColor="#CC0000" ControlToValidate="StudId"></asp:RequiredFieldValidator>
                            </td>
                            <th class="auto-style1">ID</th>
                            <td class="auto-style1" dir="ltr">
                                <asp:TextBox ID="Dep" runat="server" Height="29px" Width="151px" CssClass="form-control"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="validDep" runat="server" ErrorMessage="Invalid name" ValidationExpression="^[a-zA-Z'.]{1,40}$" ControlToValidate="Dep" ForeColor="Red"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Name Required !" ForeColor="#CC0000" ControlToValidate="Dep"></asp:RequiredFieldValidator>
                            </td>

                        </tr>
                        <tr class="" style="background-color: #E7E9EA;">
                            <th class="auto-style4">Phone number</th>
                            <td class="auto-style3" dir="rtl">
                                <asp:TextBox ID="Phone" runat="server" Height="29px" Width="200px" CssClass="form-control"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="validPhone" runat="server" ErrorMessage="Invalid name" ValidationExpression="^[a-zA-Z'.]{1,40}$" ControlToValidate="Phone" ForeColor="Red"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Name Required !" ForeColor="#CC0000" ControlToValidate="Phone"></asp:RequiredFieldValidator>
                            </td>
                            <th class="auto-style6">Email</th>
                            <td class="auto-style2" dir="ltr">
                                <asp:TextBox ID="Email" runat="server" Height="29px" Width="152px" CssClass="form-control"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="validEmail" runat="server" ErrorMessage="Invalid name" ValidationExpression="^[a-zA-Z'.]{1,40}$" ControlToValidate="Email" ForeColor="Red"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Name Required !" ForeColor="#CC0000" ControlToValidate="Email"></asp:RequiredFieldValidator>
                            </td>

                        </tr>
                        <tr class="" style="background-color: #E7E9EA;">
                            <th class="auto-style4">Position&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </th>
                            <td class="auto-style3" dir="rtl">

                                <asp:TextBox ID="Block" runat="server" Height="29px" Width="200px" CssClass="form-control"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="validBlock" runat="server" ErrorMessage="Invalid name" ValidationExpression="^[a-zA-Z'.]{1,40}$" ControlToValidate="Block" ForeColor="Red"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Name Required !" ForeColor="#CC0000" ControlToValidate="Block"></asp:RequiredFieldValidator>
                            </td>
                            <th class="auto-style6">Qualification&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </th>
                            <td class="auto-style2" dir="ltr">
                                <asp:TextBox ID="DormNum" runat="server" Height="29px" Width="151px" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Name Required !" ForeColor="#CC0000" ControlToValidate="DormNum"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="validDormNum" runat="server" ErrorMessage="Invalid name" ValidationExpression="^[a-zA-Z'.]{1,40}$" ControlToValidate="DormNum" ForeColor="Red"></asp:RegularExpressionValidator>
                            </td>

                        </tr>
                        <tr class="" style="background-color: #E7E9EA;">
                            <th class="auto-style4">&nbsp;</th>
                            <td class="auto-style3" dir="rtl">

                                <asp:Button ID="Cancel" runat="server" Text="Cancel" CssClass="btn btn-info" Width="200px" Height="33px"  />
                            </td>
                            <th class="auto-style6">
                                <asp:Button ID="Regist" runat="server" Text="Register" CssClass="btn btn-info" Width="200px" Height="33px" OnClick="submit_Click" />
                            </th>
                            <td class="auto-style2" dir="ltr">&nbsp;</td>

                        </tr>
                    </table>
                        </div>
                        <div class="panel-footer" style="background-color: #202030; width: 100%;">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="sideNav" runat="server">
      <div id='cssmenu' style="margin-top: 25px;">
        <ul>          
 
               <li class=''><a href='Register.aspx'><span>Register from excel</span></a></li>
               <li class=''><a href='Manual%20Registration.aspx'><span>Regular  Registration</span></a></li>
               <li class=''><a href='../../../changePassword.aspx'><span>Change Password</span></a></li>
            <li class=''><a href='../../../logout.aspx'><span>LogOut</span></a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
