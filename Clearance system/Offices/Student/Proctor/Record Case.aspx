<%@ Page Title="" Language="C#" MasterPageFile="~/frontPageOffice.Master" AutoEventWireup="true" CodeBehind="Record Case.aspx.cs" Inherits="ClearanceSystem.Offices.Student.Proctor.Record_Case" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="sideNav" runat="server">
    <div id='cssmenu' style="margin-top: 25px;">
        <ul>
            <li class=''><a href="Proctor%20HOME.aspx"><span>HOME</span></a></li>
           <%-- <li class=''><a href="Record%20Case.aspx"><span>Record Case</span></a></li>--%>
            <li class=''><a href="Ignore%20Case.aspx"><span>Ignore Case</span></a></li>            
            <li class=''><a href="Record%20Material.aspx"><span>Record Material</span></a></li>
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
                        <table>
                            <tr class="success">
                                <th colspan="2" style="color: rgba(243, 225, 225, 1);"></th>
                                <td class="auto-style7">
                                    <asp:TextBox placeholder="Student ID" ID="StudId" runat="server" CssClass="form-control" Width="267px" Height="31px"></asp:TextBox>
                                </td>

                                <td>&nbsp;&nbsp;
                                    <asp:Button ID="Load" runat="server" Text="Load" CssClass="btn btn-info" OnClick="Load_Click" Height="32px" Width="126px" />

                                    <asp:Label ID="wStud" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="collapse" class="<%Response.Write(state); %>">
                        <div class="panel-body" style="background-color: #E7E9EA;">
                            <table class="table" style="border-radius: 20px 20px 20px 20px; height: 210px;">
                                <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style1">Name</th>
                                    <td class="auto-style2">
                                        <asp:Label ID="lblName" runat="server"></asp:Label></td>
                                    <td rowspan="6" class="auto-style3">
                                        <asp:Image ID="photo" runat="server" Height="169px" Width="175px" class="img-thumbnail" BackColor="#669999" BorderStyle="Double" ForeColor="#CCCCCC" />
                                    </td>
                                </tr>


                                <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style1">Dorm Number</th>
                                    <td class="auto-style2">
                                        <asp:Label ID="lblDorm" runat="server"></asp:Label></td>
                                </tr>

                                <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style1"></th>
                                    <td class="auto-style2">&nbsp;</td>
                                </tr>
                            </table>
                        </div>
                        <div class="panel-footer" style="background-color: #202030; width: 721px;">
                            <asp:GridView ID="GridView1" runat="server" Width="100%" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None">
                                <Columns>
                                    <asp:TemplateField HeaderText="Give">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox1" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                <FooterStyle BackColor="Tan" />
                                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                <SortedAscendingCellStyle BackColor="#FAFAE7" />
                                <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                                <SortedDescendingCellStyle BackColor="#E1DB9C" />
                                <SortedDescendingHeaderStyle BackColor="#C2A47B" />
                            </asp:GridView>
                            <asp:Button ID="submit" runat="server" Text="Submit" CssClass="btn btn-success" Width="152px" Height="28px" OnClick="submit_Click" />

                        </div>
                        <div class="panel-footer" style="background-color: #7d13a8; width: 718px;">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
