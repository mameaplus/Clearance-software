<%@ Page Title="" Language="C#" MasterPageFile="~/Master Front.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ClearanceSystem.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="sideNav" runat="server">
    <div id='cssmenu' style="margin-top: 25px;">
        <ul>
            <li><a href='#'><span>Home </span></a></li>
            <li class='active has-sub'><a href='#'><span>Create Account</span></a>
                <ul>
                    <li class=''><a href='#'><span>Employee</span></a>
                    </li>
                    <li class=''><a href='#'><span>Student</span></a>
                    </li>
                </ul>
            </li>
            <li class='active has-sub'><a href='#'><span>Login</span></a>
                <ul>
                    <li class=''><a href='#'><span>Employee</span></a>
                    </li>
                    <li class=''><a href='#'><span>Student</span></a>
                    </li>
                </ul>
            </li>
            <li class=''><a href='#'><span>Offices</span></a></li>
            <li class=''><a href='#'><span>Offices</span></a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
