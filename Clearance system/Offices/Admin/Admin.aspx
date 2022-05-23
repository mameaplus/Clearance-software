<%@ Page Title="" Language="C#" MasterPageFile="~/frontPageOffice.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="ClearanceSystem.Offices.Admin.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="sideNav" runat="server">
    <div id='cssmenu' style="margin-top: 25px;">
        <ul>
            <li class=''><a href="Create%20Account.aspx"><span>Create account</span></a></li>
            <li class=''><a href="Notify%20Student.aspx"><span>Notify student</span></a></li>
            <li class=''><a href="Service.aspx"><span>Manage service</span></a></li>
            <li class=''><a href="Manage%20account.aspx"><span>Manage account</span></a></li>
                <li class=''><a href="  ../../changePassword.aspx"><span>Change Password</span></a></li>
            <li class=''><a href="../../logout.aspx"><span>LogOut</span></a></li>
              
        </ul>    
    </div>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
