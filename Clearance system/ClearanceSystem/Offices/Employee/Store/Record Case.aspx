<%@ Page Title="" Language="C#" MasterPageFile="~/frontPageOffice.Master" AutoEventWireup="true" CodeBehind="Record Case.aspx.cs" Inherits="ClearanceSystem.Offices.Employee.Store.Record_Case" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 135px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="sideNav" runat="server">
     <div id='cssmenu' style="margin-top: 25px;">
        <ul>            
            <li class=''><a href="Show%20Refers.aspx"><span>Show Refer</span></a></li>
            <li class=''><a href="Store%20Home.aspx"><span>Store Home</span></a></li>
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
                                <th colspan="2" style="color: rgba(243, 225, 225, 1);">Employee ID :</th>
                                <td class="auto-style7">
                                    <asp:TextBox ID="EmpID" runat="server" CssClass="form-control" Width="267px" Height="31px"></asp:TextBox>
                                </td>

                                <td>&nbsp;&nbsp;
                                    
                                    <asp:Label ID="wEmp" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="collapse" class="<%Response.Write(""); %>">
                        <div class="panel-body" style="background-color: #E7E9EA;">
                            <table class="table" style="border-radius: 20px 20px 20px 20px; height: 210px;">
                                <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style1">Name</th>
                                    <td class="auto-style2">
                                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label></td>
                                    <td rowspan="6" class="auto-style3">
                                        <asp:Image ID="photo" runat="server" Height="169px" Width="175px" class="img-thumbnail" BackColor="#669999" BorderStyle="Double" ForeColor="#CCCCCC" />
                                    </td>
                                </tr>
                                <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style1">Departement</th>
                                    <td class="auto-style2"><asp:Label ID="Label2" runat="server" Text=""></asp:Label></td>
                                </tr>
                                <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style1">Academic Record</th>
                                    <td class="auto-style2">
                                        <asp:Label ID="Label3" runat="server" Text=""></asp:Label></td>
                                </tr>
                                    <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style1">Agreement Code</th>
                                    <td class="auto-style2">
                                        <asp:TextBox ID="Acode" runat="server" CssClass="form-control" Width="267px" Height="31px"></asp:TextBox>
                                        </td>
                                </tr>

                             
                            </table>
                        </div>
                        <div class="panel-footer" style="background-color: #202030;width:100%;" >
                            <asp:GridView ID="GridView1" runat="server" Width="100%" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None">
                                <Columns>
                                    <asp:TemplateField HeaderText="Quantity">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBox0" runat="server" Text='' ></asp:TextBox>
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
                            <br/>
                                                        <asp:Button ID="submit" runat="server" Text="Record" CssClass="btn btn-success" Width="271px" Height="38px" OnClick="submit_Click" />
                        
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:Button ID="cancel" runat="server" Text="Cancel" CssClass="btn btn-success" Width="271px" Height="38px" OnClick="submit_Click" />
                        
                        </div>
                        <div class="panel-footer" style="background-color: #7d13a8; width:100%;">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
