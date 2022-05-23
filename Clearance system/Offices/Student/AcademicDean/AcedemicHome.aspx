<%@ Page Title="" Language="C#" MasterPageFile="~/Master Front.Master" AutoEventWireup="true" CodeBehind="AcedemicHome.aspx.cs" Inherits="ClearanceSystem.Offices.Student.AcademicDean.AcedemicHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="sideNav" runat="server">
    <div id='cssmenu' style="margin-top: 25px;">
        <ul>       
         <%--   <li class=''><a href="AcedemicHome.aspx"><span>Acedemic Home</span></a></li>--%>             
        <li class=''><a href="AcademicDean.aspx"><span>Academic Dean</span></a></li> 
            <li class=''><a href=" ../../../changePassword.aspx"><span>Change Password</span></a></li>
            <li class=''><a href="../../../logout.aspx"><span>LogOut</span></a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
