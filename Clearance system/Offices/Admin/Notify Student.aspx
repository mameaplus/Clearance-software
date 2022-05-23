<%@ Page Title="" Language="C#" MasterPageFile="~/Offices/Registrar.Master" AutoEventWireup="true" CodeBehind="Notify Student.aspx.cs" Inherits="ClearanceSystem.Offices.Admin.Notify_Student" %>


<asp:Content ID="Content1" ContentPlaceHolderID="sideNav" runat="server">
 <div id='cssmenu' style="margin-top: 25px;">
        <ul>
            <li class=''><a href="Create%20Account.aspx"><span>Create account</span></a></li>
            <li class=''><a href="Notify%20Student.aspx"><span>Notify student</span></a></li>
            <li class=''><a href="Service.aspx"><span>Manage service</span></a></li>
            <li class=''><a href="Manage%20account.aspx"><span>Manage account</span></a></li>
                <li class=''><a href="  ../../changePassword.aspx"><span>Change Password</span></a></li>
            <li class=''><a href="../../logout.aspx"><span>LogOut</span></a></li>
        </ul>    
    </div>
</asp:Content><asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">


    <div class="container" style="margin: 0px; padding: 0px; width: 100%; color: steelblue;">

        <div class="panel-group" id="accordion">
            <div class="">
                <div class="panel-heading" style="height: 84px; border-top-left-radius: 25px; border-top-right-radius: 25px; background-color: rgb(32, 32, 48);">
                </div>
                <div id="collapse" class="">
                    <div class="panel-body" style="background-color: #E7E9EA; height: 1047px; height: auto; width: auto;">
                        <asp:GridView ID="GridView1" Width="100%" runat="server" DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField HeaderText="To">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="note" runat="server" />
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
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:KiotDBClearConnectionString %>" SelectCommand="SELECT   [Phone number],CONCAT( [name],[Message] )FROM [KiotDBClear].[dbo].[SendToStudent]"></asp:SqlDataSource>
                         <div class="panel-footer" style="background-color: #4A3C8C; width: 100%;; height:60px; border-bottom-left-radius: 25px; border-bottom-right-radius: 25px;">

                                    <asp:Button ID="CheckAll" runat="server" Text="Check All" CssClass="btn btn-info" Height="39px" Width="236px" OnClick="CheckAll_Click"    />                                  
                                &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="note" runat="server" Text="Anounce" CssClass="btn btn-info" Height="39px" Width="156px" OnClick="note_Click"   />                                  
                                &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="home" runat="server" Text="Go To Home" CssClass="btn btn-info" Height="39px" Width="236px" OnClick="home_Click"  />                                  

                        </div>
                        <br />
                        <br />
                        <center>
                            <%--     ../../SendTousers/smsin/MsgGetList.txt--%>
                            &nbsp;</center>
                    </div>
                    <div class="panel-footer" style="background-color: #202030; width: 100%; height: 65px; border-bottom-left-radius: 25px; border-bottom-right-radius: 25px;">
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

