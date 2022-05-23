<%@ Page Title="" Language="C#" MasterPageFile="~/LoginMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ClearanceSystem.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../WebBeauty/css/login.css" rel="stylesheet" />
    <link href="../WebBeauty/css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Hnav" runat="server">


     <ul class="menu">
         
                <li><a href="Help.aspx">HELP</a></li>
                <li><a href="#s1">Login</a> 
                    <ul class="submenu">
                     
                        
                         
                        <li><a href="Users/Login.aspx">Users</a></li>

                    </ul>
                </li>
             
                <li class="active"><a href="Users/Create%20account.aspx">Create Account</a>
                    
                </li>
          

        <li class="active"><a href="../Offices/Admin/Login.aspx">Admin</a></li>
         <li class="active"><a href="Offices/Student/Proctor/Login.aspx">Proctor</a></li>
         
             
            </ul>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <form id="form1" runat="server">
      
        <div class="login">

            <center>
                <br/> 
                 <hr />
                <strong>Login</strong><br/>
                  <asp:DropDownList ID="Staff" runat="server" Width="146px" CssClass="form-control" >
                                 </asp:DropDownList>
                        <br/>
            <asp:TextBox  CssClass="form-control" placeholder="User name" ID="userName" Text="User Name" runat="server" Width="427px"></asp:TextBox> 
                <asp:RequiredFieldValidator ID="uname" runat="server" ErrorMessage="User name Required !" ForeColor="Red" ControlToValidate="userName"></asp:RequiredFieldValidator>
                <br />
            <asp:TextBox CssClass="form-control" ID="Password" runat="server" Width="426px" TextMode="Password" ></asp:TextBox>
 
                <asp:RequiredFieldValidator  ID="RequiredFieldValidator1" ForeColor="Red" placeholder="Password" ControlToValidate="Password"  runat="server" ErrorMessage="password Required"></asp:RequiredFieldValidator>
           
                <br />
            <asp:Button CssClass="btn btn-info" ID="Log_in" runat="server" Text="Login" Width="136px" OnClick="Log_in_Click" />
                <asp:Label ID="wpass" runat="server" BorderStyle="None" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
            </center>
            <hr />
        </div>
    </form>
</asp:Content>
 