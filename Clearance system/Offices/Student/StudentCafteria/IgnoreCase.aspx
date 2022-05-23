<%@ Page Title="" Language="C#" MasterPageFile="~/frontPageOffice.Master" AutoEventWireup="true" CodeBehind="IgnoreCase.aspx.cs" Inherits="ClearanceSystem.Offices.Student.StudentCafteria.IgnoreCase" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 379px;
        }
        .auto-style2 {
            width: 516px;
        }
        .auto-style3 {
            width: 375px;
        }
        .auto-style4 {
            width: 372px;
        }
        .auto-style5 {
            width: 325px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="sideNav" runat="server">
     <div id='cssmenu' style="margin-top: 25px;">
        <ul>  
            <li class=''>  <a href="StudentCafteria.aspx"><span>Record Case</span></a></li>    
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

                                <th style="color: rgba(243, 225, 225, 1);" >Student ID :</th>
                                <td>
                                    <asp:TextBox ID="StudID" runat="server" CssClass="form-control" Width="267px" Height="31px"></asp:TextBox>
                                </td>

                                <td>
                                    <asp:Button ID="Load" runat="server" Text="Load" CssClass="btn btn-info" Height="32px" Width="126px" OnClick="Load_Click"  />                                  
                                </td>
                                <td> <asp:Label ID="WStudID" runat="server"></asp:Label></td>
                            </tr>
                        </table>
                    </div>
                    <div id="collapse" class="">
                        <div class="panel-body" style="background-color: #E7E9EA;">
                            <table class="table" style="border-radius: 20px 20px 20px 20px; height: 213px;">
                                <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style5">Name</th>
                                    <td class="auto-style2">
                                        <asp:Label ID="lblName" runat="server"></asp:Label>
                                    </td>
                                    <td rowspan="7" class="auto-style3">
                                        <asp:Image ID="photo" runat="server" Height="169px" Width="175px" class="img-thumbnail" BackColor="#669999" BorderStyle="Double" ForeColor="#CCCCCC" />
                                    </td>
                                </tr>
                                <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style5">Departement</th>
                                    <td class="auto-style2">
                                        <asp:Label ID="lblDep" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                
                              
                                <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style1" colspan="2" style="color: #FF0000">Warning : becarefull when ignoring all cases</th>                                 
                                                                     
                                </tr>
                                  <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style1"  colspan="2" style="padding: 12px">

                                         <asp:GridView ID="GridView1" runat="server" CellPadding="4" Width="460px" ForeColor="#333333" GridLines="None" Height="82px">
                                             <AlternatingRowStyle BackColor="White" />
                                             <Columns>
                                                  <asp:TemplateField>
                                                      <ItemTemplate>
                                                          <asp:CheckBox ID="check" runat="server"  />
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
                                    <th class="auto-style5">
                                        <asp:Button ID="ClearAll" runat="server" Text="Clear All" CssClass="btn  btn-danger" Width="146px" Height="35px" OnClick="ClearAll_Click" />
                                      </th>
                                    <td class="auto-style2">
                                        <asp:Button ID="Clear" runat="server" Text="Clear selected" CssClass="btn btn-info" Width="146px" Height="35px" OnClick="Clear_Click" />
                                    </td>
                                </tr>
                                <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style5"></th>
                                    <td class="auto-style2">
                                        &nbsp;</td>
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
