<%@ Page Title="" Language="C#" MasterPageFile="~/LoginMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ClearanceSystem.Offices.Student.Proctor.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../WebBeauty/css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Hnav" runat="server">
    <ul class="menu">
        <li><a href="#">Home</a></li>
        <li><a href="#s1">Login</a>
            <ul class="submenu">
                <li><a href="../../../Login.aspx">Offices</a></li>
                <li><a href="../../../Users/Login.aspx">users</a></li>
            </ul>
 
        </li>
        <li class="active"><a href="../../../Users/Create%20account.aspx">Create Account</a></li>
        <li class="active"><a href="../../Admin/Login.aspx">admin</a>  </li>


    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="login">
            <center>
                <br />
                <br />
                <br />
                <hr />
                    <em>Login</em><br />
                 <asp:TextBox ID="bnum" runat="server" CssClass="form-control" placeholder="Block Number" Width="427px"></asp:TextBox>
                 <asp:RequiredFieldValidator  ID="RequiredFieldValidator1" ForeColor="Red"  ControlToValidate="bnum"  runat="server" ErrorMessage="Block Required"></asp:RequiredFieldValidator>
                <br />
                <asp:TextBox ID="userName" runat="server" CssClass="form-control" placeholder="User Name"  Width="427px"></asp:TextBox>
                <asp:RequiredFieldValidator  ID="RequiredFieldValidator2" ForeColor="Red"  ControlToValidate="userName"  runat="server" ErrorMessage="User name Required"></asp:RequiredFieldValidator>
                <br />
                <asp:TextBox ID="Password" runat="server" CssClass="form-control" placeholder="password "   Width="426px" TextMode="Password"></asp:TextBox>
                 <asp:RequiredFieldValidator  ID="RequiredFieldValidator3" ForeColor="Red"  ControlToValidate="Password"  runat="server" ErrorMessage="Password Required"></asp:RequiredFieldValidator>
                <br />
                <asp:Button ID="Log_in" runat="server" CssClass="btn btn-info" OnClick="Log_in_Click" Text="Login" Width="136px" />
                <asp:Label ID="wpass" runat="server" BorderStyle="None" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
            </center>
            <hr />
        </div>
    </form>
</asp:Content>
