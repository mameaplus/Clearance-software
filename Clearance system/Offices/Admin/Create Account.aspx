<%@ Page Title="" Language="C#" MasterPageFile="~/frontPageOffice.Master" AutoEventWireup="true" CodeBehind="Create Account.aspx.cs" Inherits="ClearanceSystem.Offices.Admin.Create_Account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 113px;
        }

        .auto-style2 {
            height: 102px;
            width: 275px;
        }

        .auto-style4 {
            height: 31px;
        }
        .auto-style5 {
            height: 31px;
            width: 275px;
        }
        .auto-style6 {
            height: 44px;
            width: 275px;
        }
    </style>
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
    <form id="form1" runat="server">
        <div class="container" style="margin: 0px; padding: 0px; width: 100%; color: steelblue; background-color: #202030; border-radius: 25px;">

            <div class="panel-group" id="accordion">
                <div class="">
                    <div class="panel-heading" style="margin: 0px; border-top-left-radius: 25px; border-top-right-radius: 25px; background-color: rgb(32, 32, 48);">

                        <table>
                            <tr class="success">

                                <th colspan="2" style="color: rgba(243, 225, 225, 1);">Create Account for&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </th>
                                <td class="auto-style7">
                                    <asp:DropDownList ID="staff"  CssClass="form-control"  runat="server"></asp:DropDownList>
                                </td>

                                <td>&nbsp;&nbsp;
                                    
                                    </td>
                            </tr>
                        </table>
                    </div>
                    <div id="collapse" class="">
                        <div class="panel-body" style="background-color: #E7E9EA; height: 420px;">
                            <table class="table" style="border-radius: 20px 20px 20px 20px; height: 158px;">

                                <tr class="" style="background-color: #E7E9EA;">
                              
                                    <td class="auto-style5" dir="ltr" align="center">
                                       <asp:TextBox ID="phone" runat="server" CssClass="form-control" Height="35px" Width="281px" placeholder="Enter his/her phone(not recommended )"></asp:TextBox>
                                         </td>
                                     
                                    <td class="auto-style4">
                                        <asp:Label ID="lbluname" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr class="" style="background-color: #E7E9EA;">
                                   
                                    <td class="auto-style6" dir="ltr" align="center">
                                        <asp:TextBox ID="uname" runat="server" CssClass="form-control" Height="35px" Width="280px" placeholder="Enter his/her Username"></asp:TextBox>
                                    </td>
                                </tr>
                              
                                <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style1" dir="ltr" align="center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<asp:Button ID="submit" runat="server" Text="create and Send" CssClass="btn btn-success" Width="159px" Height="35px" OnClick="submit_Click" />
                                        <asp:Label ID="accstate" runat="server"></asp:Label>
                                        </th>
                                
                                    <td class="auto-style2">
                                        &nbsp;
                                    <asp:Button ID="Load" runat="server" Text="Back" CssClass="btn btn-info" OnClick="Load_Click" Height="34px" Width="126px" />

                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="panel-footer" style="background-color: #202030; width: 100%;">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
