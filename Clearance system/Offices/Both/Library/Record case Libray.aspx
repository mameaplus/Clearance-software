<%@ Page Title="" Language="C#" MasterPageFile="~/frontPageOffice.Master" AutoEventWireup="true" CodeBehind="Record case Libray.aspx.cs" Inherits="ClearanceSystem.Offices.Both.Library.Record_case_Libray" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="sideNav" runat="server">
    <div id='cssmenu' style="margin-top: 25px;">
        <ul>
            <li class=''><a href="Library%20Home.aspx"><span>Home</span></a></li>
            <li class=''><a href="Ignore.aspx"><span>Ignore Case</span></a></li>
            <li class=''><a href='View.aspx'><span dir="ltr">View Case</span></a></li>
            <li class=''><a href=" ../../../changePassword.aspx"><span>Change Password</span></a></li>
            <li class=''><a href="../../../logout.aspx"><span>LogOut</span></a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <form id="Form1" runat="server">
          <div class="container" style="margin: 0px; padding: 0px; width: 100%; color: steelblue; background-color: #202030; border-radius: 25px;">
            <div class="panel-group" id="accordion">
                <div class="">
                    <div class="panel-heading" style="margin: 0px; border-top-left-radius: 25px; border-top-right-radius: 25px; background-color: rgb(32, 32, 48);">
                       <table>
                            <tr class="success">
                                <th class="auto-style3">Book ID:</th>
                                <td>
                                    <asp:TextBox ID="bookID" runat="server" CssClass="form-control" Width="190px" Height="34px"></asp:TextBox></td>
                                <td>&nbsp;                       
                          <asp:Label ID="wBook" runat="server"></asp:Label>
                                    &nbsp;&nbsp;                       
                                </td>
                                <th class="auto-style5">Student ID:</th>
                                <td>
                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" Width="186px" Height="35px"></asp:TextBox>
                                </td>
                                <td>&nbsp;&nbsp;
                       
                        <asp:Button ID="Button1" runat="server" Text="Load" OnClick="Button1_Click1" CssClass="btn btn-info" Height="33px" />
                                </td>
                                <td>&nbsp;&nbsp;                       
                          <asp:Label ID="wStud" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="collapse" class="<% Response.Write(state);%>">
                        <div class="panel-body" style="background-color: #E7E9EA; height:auto; ">
                          <table class="table" style="  ">
                                  <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style4" align="char" dir="rtl">Name</th>
                                    <td class="auto-style1" dir="ltr">
                                        <asp:Label ID="lblName" runat="server"></asp:Label>
                                    </td>
                                    <td rowspan="4">
                                        <asp:Label ID="code" runat="server"></asp:Label>
                                        <asp:Image ID="Image1" runat="server" Height="154px" Width="153px" class="img-thumbnail" BackColor="#669999" BorderStyle="Double" ForeColor="#3333FF" />
                                        &nbsp;</td>
                                </tr>
                                <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style2" align="char" dir="rtl">Departement</th>
                                    <td class="auto-style1" dir="ltr">
                                        <asp:Label ID="lblDep" runat="server"></asp:Label>
                                    </td>

                                </tr>
                                  <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style2" align="char" dir="rtl">Block</th>
                                    <td class="auto-style1" dir="ltr">
                                        <asp:Label ID="lblBlock" runat="server"></asp:Label>
                                    </td>

                                </tr>
                                   <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style2" align="char" dir="rtl">Dorm</th>
                                    <td class="auto-style1" dir="ltr">
                                        <asp:Label ID="lblDorm" runat="server"></asp:Label>
                                    </td>

                                </tr>
                                  <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style2" align="char" dir="rtl">Book Title</th>
                                    <td class="auto-style1" dir="ltr">
                                        <asp:Label ID="lblBookTit" runat="server"></asp:Label>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>


                               <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style2" align="char" dir="rtl">AgreeCode</th>
                                    <td class="auto-style1" dir="ltr">

                                        <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" Height="29px" Width="196px"></asp:TextBox>
                                    </td>
                                    <td class="auto-style1">
                                        <asp:Label ID="Acode" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style2" align="char" dir="rtl">Expiration Date</th>
                                    <td class="auto-style1" dir="ltr">

                                        <asp:TextBox ID="ExpDate" runat="server" CssClass="form-control" Height="26px" Width="193px"></asp:TextBox>
                                    </td>
                                    <td class="auto-style1">
                                        <asp:Label ID="warexpdate" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style2" align="char" dir="rtl">&nbsp;</th>
                                    <td class="auto-style1" dir="ltr">
                                        <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
                                        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="submit" Width="129px" CssClass="btn btn-success" Height="32px" />
                                    </td>
                                    <td class="auto-style1">
                                        <asp:Label ID="RcWarn" runat="server"></asp:Label>
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
