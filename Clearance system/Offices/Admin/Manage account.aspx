<%@ Page Title="" Language="C#" MasterPageFile="~/frontPageOffice.Master" AutoEventWireup="true" CodeBehind="Manage account.aspx.cs" Inherits="ClearanceSystem.Offices.Admin.Manage_account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
       <form id="form1" runat="server">
        <div class="container" style="margin: 0px; padding: 0px; width: 100%; color: steelblue; background-color: #202030; border-radius: 25px;">

            <div class="panel-group" id="accordion">
                <div class="">
                    <div class="panel-heading" style="margin: 0px; border-top-left-radius: 25px; border-top-right-radius: 25px; background-color: rgb(32, 32, 48);">


                        <table>
                            <tr class="success">
                                <th colspan="2" style="color: rgba(243, 225, 225, 1);">
                                        <asp:DropDownList   CssClass="form-control" ID="accountlist" runat="server" Height="31px" Width="124px">
                                            <asp:ListItem Value="30">Student</asp:ListItem>
                                            <asp:ListItem Value="40">Employee</asp:ListItem>
                                        </asp:DropDownList>
                                    </th>
                                <td class="auto-style7">
                                    <asp:TextBox ID="id" runat="server" Height="29px" Width="199px" CssClass="form-control" placeholder="Enter username"></asp:TextBox>
                                </td>

                                <td>&nbsp;&nbsp;
                                    <asp:Button ID="Load" runat="server" Text="Load" CssClass="btn btn-info" Height="32px" Width="126px" OnClick="Load_Click" />

                                    <asp:Label ID="WStudID" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="collapse" class="<%Response.Write(state); %>">
                        
                        <div class="panel-body" style="background-color: #E7E9EA; height: 100%;">
                            <table class="table" style="border-radius: 20px 20px 20px 20px; height: 213px;">
                                <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style1">&nbsp;<asp:Label ID="dep" runat="server" Text="Departement "></asp:Label>
                                    </th>
                                    <td class="auto-style4">
                                        <asp:Label ID="lblDep" runat="server"></asp:Label>
                                    </td>
                                </tr>

                                <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style1">Name</th>
                                    <td class="auto-style4">
                                        <asp:Label ID="lblName" runat="server"></asp:Label>
                                    </td>
                                    <td rowspan="7" class="auto-style3">
                                        <asp:Image ID="photo" runat="server" Height="169px" Width="175px" class="img-thumbnail" BackColor="#669999" BorderStyle="Double" ForeColor="#CCCCCC" ImageAlign="Right" />
                                    </td>
                                </tr>
                                
                                <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="enable" runat="server" Text="Enable" CssClass="btn btn-info" Width="137px" Height="39px" OnClick="enable_Click"  />
                                        <asp:Label ID="ena" runat="server"></asp:Label>
                                    </th>
                                    <td class="auto-style4">
                                        <asp:Button ID="disable" runat="server" Text="Disable" CssClass="btn btn-info" Width="137px" Height="39px" OnClick="disable_Click"   />
                                        <asp:Label ID="dis" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="panel-footer" style="background-color: #202030; width: 715px; height: 29px;">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
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
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
