<%@ Page Title="" Language="C#" MasterPageFile="~/Offices/Registrar.Master" AutoEventWireup="true" CodeBehind="Uncleared offices.aspx.cs" Inherits="ClearanceSystem.ClearanceForm.Uncleared_offices" %>

<asp:Content ID="Content2" ContentPlaceHolderID="sideNav" runat="server">
    <div id='cssmenu' style="margin-top: 25px;">
        <ul>
            <li class=''><a href="<%Response.Write(page);%>"><span>back</span></a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <div runat="server" id="unclear" style="height: 154px; width: 755px">

       

    </div>


</asp:Content>
