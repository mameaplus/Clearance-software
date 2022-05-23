



<%@ Page Title="" Language="C#" MasterPageFile="~/frontPageOffice.Master" AutoEventWireup="true" CodeBehind="Record Material.aspx.cs" Inherits="ClearanceSystem.Offices.Employee.Record_Material" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <!-- styles -->
    <link href="css/styles.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="sideNav" runat="server">
    <div id='cssmenu' style="margin-top: 25px;">
        <ul>    
            <li class=''><a href="Store%20Home.aspx"><span>Home</span></a></li>
            <li class=''><a href="Show%20Refers.aspx"><span>Show Refer</span></a></li>            
            <li class=''><a href="View%20Material.aspx"><span>View Material</span></a></li>
            <li class=''><a href="Record%20Material.aspx"><span>Record Material</span></a></li>
            <li class=''><a href=" ../../../changePassword.aspx"><span>Change Password</span></a></li>
            <li class=''><a href="../../../logout.aspx"><span>LogOut</span></a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

    <form id="form1" runat="server">

        <div class="container" style="margin: 0px; padding: 0px; width: 100%; color: steelblue;">

            <div class="panel-group" id="accordion">
                <div class="">
                    <div class="panel-heading" style="margin: 0px; border-top-left-radius: 25px; border-top-right-radius: 25px; background-color: rgb(32, 32, 48);">


                        <table>
                            <tr class="success">
                                <th colspan="2" style="color: rgba(243, 225, 225, 1);" class="auto-style4">
                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Record Manualy</asp:LinkButton>
                                </th>
                            </tr>
                        </table>
                    </div>
                    <div id="collapse" class="<%Response.Write(State1); %>">
                        <div class="panel-body" style="background-color: #E7E9EA; height: 415px;">
                            <asp:GridView ID="GridView2" runat="server">
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="panel-heading" style="margin: 0px; background-color: rgb(32, 32, 48); border-top-left-radius: <% Response.Write(TL); %>px; border-top-right-radius: <% Response.Write(TR); %>px; border-bottom-right-radius: <% Response.Write(BR); %>px; border-bottom-left-radius: <% Response.Write(BL); %>px;">

                        <table>
                            <tr class="success">
                                <th colspan="2" style="color: rgba(243, 225, 225, 1);" class="auto-style4">
                                    <asp:LinkButton ID="Excel" runat="server" OnClick="Excel_Click">Record From excel</asp:LinkButton>
                                </th>
                            </tr>
                        </table>
                    </div>
                    <div id="Div1" class="<%Response.Write(State2); %>">
                        <div class="panel-body" style="background-color: #E7E9EA; height: 415px; border-bottom-right-radius: 25px; border-bottom-left-radius: 25px;">

                            <div>
                                <table>
                                    <tr class="success">
                                        <th colspan="2" style="color: rgba(243, 225, 225, 1);" class="auto-style4"></th>
                                        <td class="auto-style7">
                                            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="" Width="396px" Height="33px" ToolTip="Get Excel File" />
                                        </td>
                                        <td>
                                            <asp:Button ID="Register" runat="server" Text="Register" CssClass="btn btn-info" Height="32px" Width="126px" OnClick="Register_Click" />
                                        </td>
                                    </tr>
                                </table>

                            </div>
                            <div class="alert-warning">
                                <asp:GridView ID="GridView1" AllowPaging="true" AutoGenerateColumns="false" runat="server" Width="651px" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="15">
                                    <Columns>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TextBox0" runat="server" Text='<%#Eval( "Name") %>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%#Eval( "Quantity") %>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TextBox2" runat="server" Text='<%#Eval("Date")%>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                                    <PagerStyle BackColor="#FFFFCC" ForeColor="Fuchsia" HorizontalAlign="Center" />
                                    <RowStyle BackColor="White" ForeColor="#330099" />
                                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                                    <SortedAscendingCellStyle BackColor="#FEFCEB" />
                                    <SortedAscendingHeaderStyle BackColor="#AF0101" />
                                    <SortedDescendingCellStyle BackColor="#F6F0C0" />
                                    <SortedDescendingHeaderStyle BackColor="#7E0000" />
                                </asp:GridView>
                            </div>
                            <br />
                            <div class="alert-warning">
                                <asp:Button ID="Button1" runat="server" Text="Cancel" Width="160px" CssClass="btn btn-info" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="Register1" runat="server" Text="Register" Width="160px" CssClass="btn btn-info" OnClick="Register1_Click" />
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
