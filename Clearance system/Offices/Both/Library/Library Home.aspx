<%@ Page Title="" Language="C#" MasterPageFile="~/Master Front.Master" AutoEventWireup="true" CodeBehind="Library Home.aspx.cs" Inherits="ClearanceSystem.Offices.Both.Library.Library_Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="sideNav" runat="server">
       <div id='cssmenu' style="margin-top: 25px;">
        <ul>  
             <li class=''> <a href="Library%20Home.aspx"><span>Home</span></a></li>
            <li class=''>  <a href="Library.aspx"> <span>Record Case</span></a></li>
            <li class=''><a href="Ignore.aspx"><span>Ignore Case</span></a></li>          
            <li class=''><a href='#'><span>View Case</span></a></li>
            <li class=''><a href='#'><span>LogOut</span></a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
