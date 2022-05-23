<%@ Page Title="" Language="C#" MasterPageFile="~/Master Front.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ClearanceSystem.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="WebBeauty/css/login.css" rel="stylesheet" />
    <link href="WebBeauty/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="sideNav" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <form id="Login" runat="server">
        <div class="login">
           
            <center>
                <br/><br/><br/> 
                 <hr />
                <p class="glyphicon-font" aria-required="True" style="margin: inherit; padding: inherit; font-family: 'Segoe Script'; background-image: none; font-size: larger; color: #00CCFF; font-weight: 700;">Login</p>
            <asp:TextBox  CssClass="form-control" ID="userName" Text="User Name" runat="server" Width="427px"></asp:TextBox><br />
            <asp:TextBox CssClass="form-control" ID="Password" runat="server" Width="426px" TextMode="Password">Password</asp:TextBox><br />
            <asp:Button CssClass="btn-info" ID="Log_in" runat="server" Text="Login" Width="136px" /></center>
            <hr/>
        </div>
    </form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
