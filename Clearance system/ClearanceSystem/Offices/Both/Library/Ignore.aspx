<%@ Page Title="" Language="C#" MasterPageFile="~/frontPageOffice.Master" AutoEventWireup="true" CodeBehind="Ignore.aspx.cs" Inherits="ClearanceSystem.Offices.Both.Library.Ignore" %>
 
<asp:Content ID="Content2" ContentPlaceHolderID="sideNav" runat="server">
    <div id='cssmenu' style="margin-top: 25px;">
        <ul>
            <li class=''><a href="Library%20Home.aspx"><span>Home</span></a></li>
            <li class=''> <a href="Record%20case%20Libray.aspx"><span>Record Case</span></a></li>
            <li class=''><a href='View.aspx'><span>View Case</span></a></li>
              <li class=''><a href=" ../../../changePassword.aspx"><span>Change Password</span></a></li>
            <li class=''><a href='../../../logout.aspx'><span>LogOut</span></a></li>
        </ul>
    </div>
       
  
 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <form id="form1" runat="server">
     <div class="container" style="margin: 0px; padding: 0px; width: 100%; color: steelblue; background-color: #202030; border-radius: 25px;">
            <div class="panel-group" id="accordion">
                <div class="">
                    <div class="panel-heading" style="margin: 0px; border-top-left-radius: 25px; border-top-right-radius: 25px; background-color: rgb(32, 32, 48);">
                        <table>
                            <tr class="success">
                                <th colspan="2" style="color: rgba(243, 225, 225, 1);">Student ID :</th>
                                <td class="auto-style7">
                                    <asp:TextBox ID="StudID" runat="server" CssClass="form-control" Width="152px" Height="31px"></asp:TextBox>
                                </td>

                                <td class="auto-style7">&nbsp;</td>

                                <td>&nbsp;
                                    <asp:Button ID="Load" runat="server" Text="Load" CssClass="btn btn-info" Height="32px" Width="126px" OnClick="Load_Click" />

                                    <asp:Label ID="wEmp" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="collapse" class="<% Response.Write(state);%>">
                        <div class="panel-body" style="background-color: #E7E9EA;">
                            <table class="table" style="border-radius: 20px 20px 20px 20px; height: 213px;background-color: #E7E9EA;">
                                <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style1">Name</th>
                                    <td class="auto-style2">
                                        <asp:Label ID="lblname" runat="server" Text=""></asp:Label></td>
                                    <td rowspan="7" class="auto-style3">
                                        <asp:Image ID="photo" runat="server" Height="169px" Width="175px" class="img-thumbnail" BackColor="#669999" BorderStyle="Double" ForeColor="#CCCCCC" />
                                    </td>
                                </tr>
                                <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style1">Departement</th>
                                    <td class="auto-style2">
                                        <asp:Label ID="lblDep" runat="server" Text=""></asp:Label></td>
                                </tr>
                                <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style1">List of book</th>
                                    <td class="auto-style2">
                                        <asp:CheckBoxList ID="CheckBoxBookList" runat="server" Width="141px">
                                        </asp:CheckBoxList>
                                    </td>
                                </tr>
                                <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style1"></th>
                                    <td class="auto-style2">
                                        <asp:Button ID="Rcive" runat="server" Text="I Receive  the book" CssClass="btn btn-info" Width="151px" Height="42px" OnClick="Rcive_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="panel-footer" style="background-color: #202030;width:100%;">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
