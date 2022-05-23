<%@ Page Title="" Language="C#" MasterPageFile="~/Master Front.Master" AutoEventWireup="true" CodeBehind="RegistrarHome.aspx.cs" Inherits="ClearanceSystem.Offices.Student.Registrar.RegistrarHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="sideNav" runat="server">
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
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
</asp:Content>
 