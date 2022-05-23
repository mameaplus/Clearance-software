<%@ Page Title="" Language="C#" MasterPageFile="~/frontPageOffice.Master" AutoEventWireup="true" CodeBehind="StudentCafteria.aspx.cs" Inherits="ClearanceSystem.Offices.Employee.StudentCafteria.StudentCafteria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 376px;
        }

        .auto-style2 {
            width: 314px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="sideNav" runat="server">
     <div id='cssmenu' style="margin-top: 25px;">
        <ul>            
            <li class=''><a href="IgnoreCase.aspx"><span>Ignore Case</span></a></li>          
            <li class=''><a href='#'><span>View Case</span></a></li>
            <li class=''><a href='#'><span>LogOut</span></a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

    <form id="form1" runat="server">
         <div class="container" style="margin: 0px; padding: 0px; width: 100%; color:steelblue;" >
            <div class="panel-group" id="accordion">
                <div class="">
                   <div class="panel-heading" style="margin: 0px; border-top-left-radius: 25px; border-top-right-radius: 25px; background-color: rgb(32, 32, 48);">


                        <table>
                            <tr class="success">
                                <th colspan="2" style="color: rgba(243, 225, 225, 1);">Student ID :</th>
                                <td class="auto-style7">
                                    <asp:TextBox ID="StudID" runat="server" Height="29px" Width="199px" CssClass="form-control"></asp:TextBox>
                                </td>

                                <td>&nbsp;&nbsp;
                                    <asp:Button ID="Load" runat="server" Text="Load" CssClass="btn btn-info" Height="32px" Width="126px" OnClick="Load_Click" />

                                    <asp:Label ID="WStudID" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="collapse" class="<%Response.Write(state); %><">
                        <div class="panel-body" style="background-color: #E7E9EA;">
                            <table class="table" style="border-radius: 20px 20px 20px 20px; height: 213px;">
                                <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style1">Departement </th>
                                    <td class="auto-style2"><%Response.Write(Dep); %></td>
                                </tr>
                                <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style1">Name</th>
                                    <td class="auto-style2"><%Response.Write(Name); %></td>
                                    <td rowspan="7" class="auto-style3">
                                        <asp:Image ID="photo" runat="server" Height="169px" Width="175px" class="img-thumbnail" BackColor="#669999" BorderStyle="Double" ForeColor="#CCCCCC" />
                                    </td>
                                </tr>
                                <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style1">Case</th>
                                    <td class="auto-style2">
                                        <textarea id="resone" name="S1" class="form-control" runat="server"></textarea>
                                    </td>
                                </tr>
                                <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style1">Date of Case</th>
                                    <td class="auto-style2">
                                        <asp:TextBox ID="Date" runat="server" Height="29px" Width="199px" CssClass="form-control"></asp:TextBox>
                                        <asp:ImageButton ID="ImageButton1" runat="server" Height="16px" ImageUrl="~/image/PageImage/imageA/calander.gif" OnClick="ImageButton1_Click" Width="21px" />
                                        <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px" OnSelectionChanged="Calendar1_SelectionChanged">
                                            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                                            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                                            <OtherMonthDayStyle ForeColor="#999999" />
                                            <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                                            <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                                            <TodayDayStyle BackColor="#CCCCCC" />
                                        </asp:Calendar>
                                    </td>
                                </tr>
                                <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style1"></th>
                                    <td class="auto-style2">
                                        <asp:Button ID="submit" runat="server" Text="Submit" CssClass="btn btn-success" Width="137px" Height="28px" OnClick="submit_Click" />
                                    </td>
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
