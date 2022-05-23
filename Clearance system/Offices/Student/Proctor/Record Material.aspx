<%@ Page Title="" Language="C#" MasterPageFile="~/frontPageOffice.Master" AutoEventWireup="true" CodeBehind="Record Material.aspx.cs" Inherits="ClearanceSystem.Offices.Student.Proctor.Record_Material" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 123px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="sideNav" runat="server">
    <div id='cssmenu' style="margin-top: 25px;">
        <ul>
            <li class=''><a href="Proctor%20HOME.aspx"><span>HOME</span></a></li>
            <li class=''><a href="Record%20Case.aspx"><span>Record Case</span></a></li>
            <li class=''><a href="ignore%20case.aspx"><span>ignore case</span></a></li>
            <%-- <li class=''><a href="Record%20Material.aspx"><span>Record Material</span></a></li>--%>
            <li class=''><a href="View%20And%20update.aspx"><span>View And update</span></a></li>
            <li class=''><a href=" ../../../changePassword.aspx"><span>Change Password</span></a></li>
            <li class=''><a href="../../../logout.aspx"><span>Log Out</span></a></li>

        </ul>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

    <form id="form1" runat="server">

        <div class="container" style="margin: 0px; padding: 0px; width: 100%; color: steelblue; background-color: #202030; border-radius: 25px;">

            <div class="panel-group" id="accordion">
                <div class="">
                    <div class="panel-heading" style="margin: 0px; border-top-left-radius: 25px; border-top-right-radius: 25px; background-color: rgb(32, 32, 48);">
                    </div>
                    <div id="collapse" class="">
                        <div class="panel-body" style="background-color: #E7E9EA; height: 415px;">
                            <table class="table" style="border-radius: 20px 20px 20px 20px; height: 203px;">
                                <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style1">Material Name</th>
                                    <td class="auto-style2">
                                        <asp:TextBox ID="MName" runat="server" Height="29px" Width="200px" CssClass="form-control"></asp:TextBox>
                                    </td>

                                </tr>
                                <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style1">Quntity</th>
                                    <td class="auto-style2">
                                        <asp:TextBox ID="MQ" runat="server" Height="29px" Width="200px" CssClass="form-control"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style1">&nbsp;</th>
                                    <td class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="submit" runat="server" Text="Submit" CssClass="btn btn-info" Width="200px" Height="33px" OnClick="submit_Click" />
                                    </td>
                                </tr>
                                <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style1"></th>
                                    <td class="auto-style2">&nbsp;</td>
                                </tr>
                            </table>
                        </div>
                        <div class="panel-footer" style="background-color: #202030">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
