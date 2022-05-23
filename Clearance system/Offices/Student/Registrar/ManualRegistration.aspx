<%@ Page Title="" Language="C#" MasterPageFile="~/frontPageOffice.Master" AutoEventWireup="true" CodeBehind="ManualRegistration.aspx.cs" Inherits="ClearanceSystem.Offices.Student.Registrar.ManualRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 101px;
        }

        .auto-style2 {
            height: 101px;
            width: 74px;
        }

        .auto-style4 {
            height: 101px;
            width: 117px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="sideNav" runat="server">
    <div id='cssmenu' style="margin-top: 25px;">
        <ul>

            <li class=''><a href="RegistrarHome.aspx"><span>Home</span></a></li>
            <li class=''><a href="ManualRegistration.aspx"><span>Register Manualy</span></a></li>
            <li class=''><a href="Register%20Student.aspx"><span>Register from excel</span></a></li>
            <li class=''><a href=" ../../../changePassword.aspx"><span>Change Password</span></a></li>
            <li class=''><a href="../../../logout.aspx"><span>LogOut</span></a></li>
        </ul>
    </div>
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
                            <table class="table" style="border-radius: 20px 20px 20px 20px; height: 587px;">
                                <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style4">First Name</th>
                                    <td class="auto-style1">
                                        <asp:TextBox ID="Name" runat="server" Height="29px" Width="201px" CssClass="form-control"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="ValidName" runat="server" ErrorMessage="Invalid First Name" ValidationExpression="^[A-Z][a-zA-Z]*$" ControlToValidate="Name" ForeColor="Red"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="First Name Required !" ForeColor="#CC0000" ControlToValidate="Name"></asp:RequiredFieldValidator>
                                    </td>
                                    <th class="auto-style1">Last Name</th>
                                    <td class="auto-style1">
                                        <asp:TextBox ID="txtlast" runat="server" Height="29px" Width="201px" CssClass="form-control"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Last Name" ValidationExpression="^[A-Z][a-zA-Z]*$" ControlToValidate="txtlast" ForeColor="Red" EnableTheming="False"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Last Name Required !" ForeColor="#CC0000" ControlToValidate="txtlast"></asp:RequiredFieldValidator>
                                    </td>

                                </tr>
                                <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style1">ID</th>
                                    <td class="auto-style1">

                                        <asp:TextBox ID="StudId" runat="server" Height="29px" Width="200px" CssClass="form-control"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="ValidStudid" runat="server" ErrorMessage="Invalid Id Number" ValidationExpression="\w{4}(/\d{4}/\d{2})?" ControlToValidate="StudId" ForeColor="Red"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="ID number required !" ForeColor="#CC0000" ControlToValidate="StudId"></asp:RequiredFieldValidator>
                                    </td>
                                    <th class="auto-style1">Departement</th>
                                    <td class="auto-style1">
                                        <asp:TextBox ID="Dep" runat="server" Height="29px" Width="151px" CssClass="form-control" ></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="validDep" runat="server" ErrorMessage="Departement entry Invalid" ValidationExpression="^[a-zA-Z'.]{1,40}$" ControlToValidate="Dep" ForeColor="Red"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Departement Required" ForeColor="#CC0000" ControlToValidate="Dep"></asp:RequiredFieldValidator>
                                    </td>

                                </tr>
                                <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style4">Phone number</th>
                                    <td class="auto-style5">
                                        <asp:TextBox ID="Phone" runat="server" Height="29px" Width="200px" CssClass="form-control"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="validPhone" runat="server" ErrorMessage="Invalid Phone Number !" ValidationExpression="^[+][2][5][1][9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]{1,14}$" ControlToValidate="Phone" ForeColor="Red"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Name Required !" ForeColor="#CC0000" ControlToValidate="Phone"></asp:RequiredFieldValidator>
                                    </td>
                                    <th class="auto-style6">Email</th>
                                    <td class="auto-style2">
                                        <asp:TextBox ID="Email" runat="server" Height="29px" Width="152px" CssClass="form-control"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="validEmail" runat="server" ErrorMessage="Invalid Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="Email" ForeColor="Red"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Email Required !" ForeColor="#CC0000" ControlToValidate="Email"></asp:RequiredFieldValidator>
                                    </td>

                                </tr>
                                <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style4">Block number</th>
                                    <td class="auto-style5">

                                        <asp:TextBox ID="Block" runat="server" Height="29px" Width="200px" CssClass="form-control"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="validBlock" runat="server" ErrorMessage="Invalid Block number " ValidationExpression="^[0-9'.]{1,4}$" ControlToValidate="Block" ForeColor="Red"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Block number Required !" ForeColor="#CC0000" ControlToValidate="Block"></asp:RequiredFieldValidator>
                                    </td>
                                    <th class="auto-style6">Dorm Number</th>
                                    <td class="auto-style2">
                                        <asp:TextBox ID="DormNum" runat="server" Height="29px" Width="151px" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Dorm Number Required !" ForeColor="#CC0000" ControlToValidate="DormNum"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="validDormNum" runat="server" ErrorMessage="Invalid  Dorm Number" ValidationExpression="^[0-9'.]{1,4}$" ControlToValidate="DormNum" ForeColor="Red"></asp:RegularExpressionValidator>
                                    </td>

                                </tr>
                                <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style4">&nbsp;</th>
                                    <td class="auto-style5">

                                        <asp:Button ID="Cancel" runat="server" Text="Cancel" CssClass="btn btn-info" Width="200px" Height="33px" OnClick="submit_Click" />
                                    </td>
                                    <th class="auto-style6">
                                        <asp:Button ID="Regist" runat="server" Text="Register" CssClass="btn btn-info" Width="200px" Height="33px" OnClick="submit_Click" />
                                    </th>
                                    <td class="auto-style2">
                                        <asp:Label ID="isreg" runat="server"></asp:Label>
                                    </td>

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

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
