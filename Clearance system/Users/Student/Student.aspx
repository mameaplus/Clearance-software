<%@ Page Title="" Language="C#" MasterPageFile="~/Master Front.Master" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="ClearanceSystem.Users.Student" %>





<asp:Content ID="Content3" ContentPlaceHolderID="sideNav" runat="server">
    <div id='cssmenu' style="margin-top: 25px;">
        <ul>
            <li class=''><a href="../../ClearanceForm/Clearance%20From.aspx"><span>Get Clearance</span></a></li>
            <li class=''><a href="../../logout.aspx"><span>LogOut</span></a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="body" runat="server">
    <h3 id="err" runat="server"></h3>
</asp:Content>