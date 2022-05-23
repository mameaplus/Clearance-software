<%@ Page Language="C#" MasterPageFile="~/frontPageOffice.Master" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="ClearanceSystem.Registrar" %>

<asp:Content ContentPlaceHolderID="head" runat="server">  

    <title>Registrar</title>
</asp:Content>
<asp:Content ContentPlaceHolderID="sideNav" runat="server">
    <div id='cssmenu' style="margin-top: 25px;">
        <ul>
            <li><a href='#'><span>Home </span></a></li>
            <li class='active has-sub'><a href='#'><span>Create Account</span></a>
                <ul>
                    <li class='has-sub'><a href='#'><span>Employee</span></a>
                    </li>
                    <li class='has-sub'><a href='#'><span>Student</span></a>
                    </li>
                </ul>
            </li>
            <li class='active has-sub'><a href='#'><span>Login</span></a>
                <ul>
                    <li class='has-sub'><a href='#'><span>Users</span></a>
                        <ul>
                            <li class='has-sub'><a href='#'><span>Employee</span></a>

                            </li>
                            <li class='has-sub'><a href='#'><span>Student</span></a>
                            </li>
                        </ul>
                    </li>
                    <li class='has-sub'><a href='#'><span>Office</span></a>
                        <ul>
                            <li class='has-sub'><a href='#'><span>Employee</span></a>

                            </li>
                            <li class='has-sub'><a href='#'><span>Student</span></a>
                            </li>
                        </ul>
                    </li>
                </ul>
            </li>
            <li><a href='#'><span>About</span></a></li>
            <li class='last'><a href='#'><span>Contact</span></a></li>
        </ul>

    </div>
</asp:Content>
<asp:Content ContentPlaceHolderID="body" runat="server">
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" Text="Cancle" Width="100px" Height="37px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Register" runat="server" Text="Register" Width="84px" OnClick="Register_Click" Height="41px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ExcelRegist" runat="server" Text="Register form excel" OnClick="ExcelRegist_Click" Height="32px" />
        </div>
        <div>

            <asp:Button ID="back" runat="server" Text="|&lt;" Width="167px" OnClick="back_Click" Height="28px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="next" runat="server" Text="&gt;|" Width="165px" OnClick="next_Click" Height="27px" />

        </div>
        <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        </asp:GridView>
        <asp:GridView ID="GridView2" runat="server" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None">
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

        <asp:Table ID="Table1" runat="server">
        </asp:Table>
    </form>
</asp:Content>


