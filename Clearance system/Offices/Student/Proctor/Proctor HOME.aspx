<%@ Page Title="" Language="C#" MasterPageFile="~/Master Front.Master" AutoEventWireup="true" CodeBehind="Proctor HOME.aspx.cs" Inherits="ClearanceSystem.Offices.Student.Proctor.Proctor_HOME" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="sideNav" runat="server">
       <div id='cssmenu' style="margin-top: 25px;">
        <ul>
            <%--      <li class=''><a href="Proctor%20HOME.aspx"><span>HOME</span></a></li>--%>
            <li class=''><a href="Record%20Case.aspx"><span>Record Case</span></a></li>
            <li class=''><a href="Ignore%20Case.aspx"><span>Ignore Case</span></a></li>
            <li class=''><a href="Record%20Material.aspx"><span>Record Material</span></a></li>
            <li class=''><a href="View%20And%20update.aspx"><span>View And update</span></a></li>
                <li class=''><a href=" ../../../changePassword.aspx"><span>Change Password</span></a></li>
            <li class=''><a href="../../../logout.aspx"><span>Log Out</span></a></li>

        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
