<%@ Page Title="" Language="C#" MasterPageFile="~/frontPageOffice.Master" AutoEventWireup="true" CodeBehind="ViewCase.aspx.cs" Inherits="ClearanceSystem.Offices.Both.Cashier.ViewCase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="sideNav" runat="server">
     <div id='cssmenu' style="margin-top: 25px;">
        <ul>
                <li class=''> <a href="Add Case.aspx">  <span>Record Case</span></a></li>
            <li class=''><a href="IgnoreCase.aspx"><span>Ignore Case</span></a></li>
          <li class=''><a href="../../../changePassword.aspx"><span>change password</span></a></li>
            <li class=''><a href="../../../logout.aspx"><span>LogOut</span></a></li>          

        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <form id="form1" runat="server">
        <div class="container" style="margin: 0px; padding: 0px; width: 100%; color: steelblue; background-color: #202030; border-radius: 25px;">

            <div class="panel-group" id="accordion">
                <div class="">
                    <div class="panel-heading" style="margin: 0px; border-top-left-radius: 25px; border-top-right-radius: 25px; background-color: rgb(32, 32, 48);height:50px;">
                      
                    </div>
                     <div id="collapse" class="<%Response.Write(state); %>" style="height: auto;">
                        <div class="panel-body" style="background-color: #E7E9EA; height: auto;">
                            <table class="table" style="border-radius: 20px 20px 20px 20px; height: 213px;">
                               
                                <tr class="" style="background-color: #E7E9EA;"> 
                                    <th class="auto-style1" colspan="2" style="padding: 12px">
                                        <asp:GridView ID="GridView1" AutoGenerateColumns="false" runat="server" CellPadding="4" Width="100%" ForeColor="#333333" GridLines="None" Height="82px">
                                            <AlternatingRowStyle BackColor="White" />
                                            <Columns>
                                                 
                                                 <asp:TemplateField HeaderText="Employee ID">
                                                    <ItemTemplate>
                                                          <asp:CheckBox ID="check" runat="server" Text=""/>          
                                                        <asp:Label ID="id" runat="server" Text='<%#Eval("id")%>'/> 
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Full name">
                                                    <ItemTemplate >
                                                     <asp:Label ID="name" runat="server" Text='<%#Eval("Full name")%>'/> 
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField  HeaderText="Photo">
                                                    <ItemTemplate>
                                                      <asp:Image ID="photo" runat="server" Height="74px" Width="63px" ImageUrl='<%#"~/"+Eval("photo") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField  HeaderText="TOTAL">
                                                    <ItemTemplate >
                                                      <asp:Label ID="total" runat="server" Text='<%#Eval("Total")%>'/> 
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>

                                            <EditRowStyle BackColor="#7C6F57" />
                                            <FooterStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True" />
                                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                            <RowStyle BackColor="#E3EAEB" />
                                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                            <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                            <SortedAscendingHeaderStyle BackColor="#246B61" />
                                            <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                            <SortedDescendingHeaderStyle BackColor="#15524A" />
                                        </asp:GridView>
                                    </th>
                                </tr>
                                    
                      
                                <tr class="" style="background-color: #E7E9EA;">                                   
                                   
                                    <td class="auto-style2">
                                          <div class="panel-footer" style="background-color: #1C5E55; width: 100%; border-bottom-left-radius: 25px; border-bottom-right-radius: 25px;">                                                  
                         
                                        <asp:Button ID="ClearAll" runat="server" Text="Clear All" CssClass="btn  btn-danger" Width="146px" Height="35px" OnClick="ClearAll_Click"   />
                              
                              
                                        &nbsp;<asp:Button ID="Clear" runat="server" Text="Clear selected" CssClass="btn btn-info" Width="146px" Height="35px" OnClick="Clear_Click1"/>
                           

                                                </div>
                                        
                                    </td>
                                    
                                </tr>
                                          
                            </table>
                       
                        </div>
                        <div class="panel-footer" style="background-color: #202030; width: 100%; border-bottom-left-radius: 25px; border-bottom-right-radius: 25px;">
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
