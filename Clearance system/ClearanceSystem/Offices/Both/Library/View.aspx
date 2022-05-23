<%@ Page Title="" Language="C#" MasterPageFile="~/frontPageOffice.Master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="ClearanceSystem.Offices.Both.Library.View" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="sideNav" runat="server">
    <div id='cssmenu' style="margin-top: 25px;">
        <ul>
            <li class=''><a href="Library%20Home.aspx"><span>Home</span></a></li>
            <li class=''><a href="Ignore.aspx"><span>Ignore Case</span></a></li>         
              <li class=''> <a href="Record%20case%20Libray.aspx"><span>Record Case</span></a></li>
            <li class=''><a href=" ../../../changePassword.aspx"><span>Change Password</span></a></li>
            <li class=''><a href="../../../logout.aspx"><span>LogOut</span></a></li>
            
        </ul>
       
       
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <form di="form1" runat="server">

        <div class="container" style="margin: 0px; padding: 0px; width: 100%; color: steelblue;">

            <div class="panel-group" id="accordion">
                <div class="">
                    <div class="panel-heading" style="margin: 0px; border-top-left-radius: 25px; border-top-right-radius: 25px; background-color: rgb(32, 32, 48); height:60px">
                </div>
                    <div id="collapse" class="">
                        <div class="panel-body" style="background-color: #E7E9EA; height: 390px">
                              <asp:GridView ID="GridView1" runat="server" CellPadding="3" GridLines="Horizontal" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="100%" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" Height="143px">
            <AlternatingRowStyle BackColor="#F7F7F7" />
            <Columns>
                <asp:TemplateField HeaderText="Anounce">
                    <ItemTemplate>
                        <asp:CheckBox ID="note" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7"/>
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <SortedAscendingCellStyle BackColor="#F4F4FD" />
            <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
            <SortedDescendingCellStyle BackColor="#D8D8F0" />
            <SortedDescendingHeaderStyle BackColor="#3E3277" />
        </asp:GridView>
                             <div class="panel-footer" style="background-color: #4A3C8C; width: 100%;; height:60px; border-bottom-left-radius: 25px; border-bottom-right-radius: 25px;">

                                    <asp:Button ID="CheckAll" runat="server" Text="Check All" CssClass="btn btn-info" Height="39px" Width="236px" OnClick="CheckAll_Click"    />                                  
                                &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="note" runat="server" Text="Anounce" CssClass="btn btn-info" Height="39px" Width="156px" OnClick="note_Click"   />                                  
                                &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="home" runat="server" Text="Go To Home" CssClass="btn btn-info" Height="39px" Width="236px" OnClick="home_Click"  />                                  

                        </div>
                        </div>
                        <div class="panel-footer" style="background-color: #202030; width: 100%;; height:45px; border-bottom-left-radius: 25px; border-bottom-right-radius: 25px;">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>



</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
