<%@ Page Title="" Language="C#" MasterPageFile="~/frontPageOffice.Master" AutoEventWireup="true" CodeBehind="View And update.aspx.cs" Inherits="ClearanceSystem.Offices.Student.Proctor.View_And_update" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="sideNav" runat="server">
      <div id='cssmenu' style="margin-top: 25px;">
        <ul>     
             
            <li class=''><a href="Proctor%20HOME.aspx"><span>HOME</span></a></li>
            <li class=''><a href="Record%20Case.aspx"><span>Record Case</span></a></li>
            <li class=''><a href="ignore%20case.aspx"><span>ignore case</span></a></li>
            <li class=''><a href="Record%20Material.aspx"><span>Record Material</span></a></li>
                <li class=''><a href=" ../../../changePassword.aspx"><span>Change Password</span></a></li>
            <li class=''><a href="../../../logout.aspx"><span>Log Out</span></a></li>

        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

        <div class="container" style="margin: 0px; padding: 0px; width: 100%; color: steelblue; background-color: #202030; border-radius: 25px;">
        <form id="fromview" runat="server">
            <div class="panel-group" id="accordion">
                <div class="">
                    <div class="auto-style1" style="margin: 0px; border-top-left-radius: 25px; border-top-right-radius: 25px; background-color: rgb(32, 32, 48); height: 50px; font-style: italic;">

                        <strong>Wollo University Block Matrial List</strong>
                    </div>
                    <div id="collapse" class="collapse in">
                        <div class="panel-body" style="background-color: #E7E9EA; height: 435px;">
                            <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" Height="143px">
                                <AlternatingRowStyle BackColor="White" />
                                  <Columns>
                                        <asp:TemplateField HeaderText="Add =>">
                                            <ItemTemplate>
                                                <asp:TextBox ID="updatetxt" runat="server" Text=''></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                      
                                    </Columns>
                                <EditRowStyle BackColor="#7C6F57" />
                                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#E3EAEB" />
                                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                <SortedAscendingHeaderStyle BackColor="#246B61" />
                                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                <SortedDescendingHeaderStyle BackColor="#15524A" />
                            </asp:GridView>
                            <div class="panel-footer" style="background-color: #202030; border-bottom-left-radius: 25px; border-bottom-right-radius: 25px; width: 100%;">
                                <center>
                                <asp:Button ID="cancel" runat="server" Text="Cancel" Width="160px" OnClick="cancel_Click" CssClass="btn btn-info"/>
                                &nbsp;<asp:Button ID="update" runat="server"  Text="Update" Width="200px" CssClass="btn btn-info" OnClick="update_Click" BorderStyle="Dotted"/>
                                &nbsp;</center>


                            </div>
                        </div>
                        <div class="panel-footer" style="background-color: #202030; border-bottom-left-radius: 25px; border-bottom-right-radius: 25px;">
                        </div>

                    </div>
                </div>
            </div>
        </form>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
