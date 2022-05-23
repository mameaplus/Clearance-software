<%@ Page Title="" Language="C#" MasterPageFile="~/frontPageOffice.Master" AutoEventWireup="true" CodeBehind="Book Store.aspx.cs" Inherits="ClearanceSystem.Offices.Both.Book_Store.Book_Store" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="sideNav" runat="server">
    <div id='cssmenu' style="margin-top: 25px;">
        <ul>
            <li class=''><a href="Record%20Case.aspx"><span>Record Case</span></a></li>
            <li class=''><a href="Ignore%20Case.aspx"><span>Ignore Case</span></a></li>
            <li class=''><a href='View.aspx'><span>View Case</span></a></li>
              <li class=''><a href='../../../changePassword.aspx'><span>changePassword</span></a></li>
    
            <li class=''><a href="../../../logout.aspx"><span>LogOut</span></a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
