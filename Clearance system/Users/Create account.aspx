<%@ Page Title="" Language="C#" MasterPageFile="~/LoginMaster.Master" AutoEventWireup="true" CodeBehind="Create account.aspx.cs" Inherits="ClearanceSystem.Users.Create_account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../WebBeauty/css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Hnav" runat="server">


    <ul class="menu">
        <li><a href="../Help.aspx">HELP</a></li>
        <li><a href="#s1">Login</a>
            <ul class="submenu">
                <li><a href="../Login.aspx">Offices</a></li>
                <li><a href="Login.aspx">Users</a></li>
            </ul>
            
        </li>
<li class="active"><a href="../Offices/Admin/Login.aspx">Admin</a></li>
            <li class="active"><a href="../Offices/Student/Proctor/Login.aspx">Proctor</a></li>


    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="form1" runat="server">

        <div class="container" style="margin: 0px; padding: 0px; width: 100%; color: steelblue; background-color: #202030; border-radius: 25px;">

            <div class="container" style="margin: 0px; padding: 0px; width: 100%; color: steelblue; background-color: #202030; border-radius: 25px;">
                <div class="">
                    <div class="panel-heading" style="margin: 0px; border-top-left-radius: 25px; border-top-right-radius: 25px; background-color: rgb(32, 32, 48);">


                        <table>
                            <tr class="success">
                                <th style="color: rgba(243, 225, 225, 1);" class="auto-style4"> </th>
                                <td class="auto-style7">
                                    <asp:DropDownList CssClass="form-control" ID="accountlist" runat="server" Height="31px" Width="124px">
                                        <asp:ListItem Value="30">Student</asp:ListItem>
                                        <asp:ListItem Value="40">Employee</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="auto-style4">
                                    <asp:TextBox ID="email" runat="server" CssClass="form-control" Width="267px" placeholder="Enter Registered  Email"/>


                                    <%--  <asp:RegularExpressionValidator ValidationExpression="" ID="Isvalid" runat="server" ErrorMessage="" ControlToValidate="email" ></asp:RegularExpressionValidator>--%>
                                </td>

                                <td>&nbsp;&nbsp;
                                    <asp:Button ID="LoadEmail" runat="server" Text="OK" CssClass="btn btn-info" Height="32px" Width="110px" OnClick="LoadEmail_Click" />

                                    <asp:Label ID="wEmail" runat="server" ForeColor="Red"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="email  required" ControlToValidate="email" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid email id" ControlToValidate="email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="collapse" class="<% Response.Write(state);%>">
                        <div class="panel-body" style="background-color: #E7E9EA;">
                            <table class="table" style="border-radius: 20px 20px 20px 20px; height: 213px; width: 78%;">
                                <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style9" colspan="3">
                                            <span>Please check &nbsp;your email for verification code<o:p></o:p></span>
                                        </th>

                                    <td rowspan="3" class="auto-style3" dir="ltr">
                                        <asp:Image ID="photo" runat="server" Height="103px" Width="161px" class="img-thumbnail" BackColor="#669999" BorderStyle="Double" ForeColor="#CCCCCC" />
                                    </td>
                                </tr>
                                <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style1" colspan="2">username:<asp:Label ID="lblemail" runat="server" ForeColor="#009933"></asp:Label>
                                    </th>

                                </tr>

                                <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style6">Verification code</th>
                                    <td class="auto-style7">
                                        <asp:TextBox ID="vcode" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:Label ID="wvcode" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style6">Password</th>
                                    <td class="auto-style7">
                                        <asp:TextBox ID="password" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style1"><span>confirm password </span></th>
                                    <td class="auto-style2">

                                        <asp:TextBox ID="confpassword" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>

                                        <asp:CompareValidator ID="match" runat="server" ControlToCompare="password" ControlToValidate="confpassword" ErrorMessage="Password not match" ForeColor="Red"></asp:CompareValidator>

                                    </td>
                                    <td class="auto-style8" colspan="2" dir="ltr">
                                        <asp:FileUpload ID="getPhoto" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Calibri" Font-Overline="True" Font-Size="Small" Height="27px" Width="206px" />
                                        <asp:Label ID="wgetph" runat="server"></asp:Label>
                                    </td>
                                </tr>

                            </table>
                        </div>
                        <div class="panel-footer" style="background-color: #202030; width: 95%;">
                            <tr class="" style="background-color: #E7E9EA;">
                                <th class="auto-style1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="cancel" runat="server" Text="Cancel" CssClass="btn btn-success" Width="137px" Height="33px" OnClick="cancel_Click" />
                                </th>
                                <td class="auto-style2" colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="create" runat="server" Text="Create Account" CssClass="btn btn-success" Width="137px" Height="33px" OnClick="create_Click" />
                                </td>
                                <td class="auto-style8">
                                    <asp:Label ID="isok" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
