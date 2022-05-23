<%@ Page Title="" Language="C#" MasterPageFile="~/frontPageOffice.Master" AutoEventWireup="true" CodeBehind="Service.aspx.cs" Inherits="ClearanceSystem.Offices.Admin.Service" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    
    <link href="../../WebBeauty/css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<%--#footer
{   border-radius:25px;
    clear: both;
    padding: 10px;    
    width: auto;
    height: 40px;
    text-align:center;
    border: 3px solid #E3E3E3;
    color: #008cc4;
    font-size:20px;
    background-image: url(../Images/black.jpg);
}--%>
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
      <form id="form1" runat="server">
       <div id="footer" style="left:300px; height: 73px; width: 723px;">
           Clearance service
           <asp:Button ID="start" runat="server" Text="Start" CssClass="btn  btn-info" Width="134px" OnClick="start_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
           <asp:Button ID="stop" runat="server" Text="Stop" CssClass="btn btn-danger" Width="134px" OnClick="stop_Click" />
       </div>
          </form>
</asp:Content>
 
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
