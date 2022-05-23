<%@ Page Title="" Language="C#" MasterPageFile="~/frontPageOffice.Master" AutoEventWireup="true" CodeBehind="changePassword.aspx.cs" Inherits="ClearanceSystem.changePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 417px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
       <form id="form1" runat="server">
        <div class="container" style="margin: 0px; padding: 0px; width: 95%; color: steelblue; background-color: #202030; border-radius: 25px;">

            <div class="panel-group" id="accordion">
                <div class="">
                    <div class="panel-heading" style="margin: 0px; border-top-left-radius: 25px; border-top-right-radius: 25px; background-color: rgb(32, 32, 48);">

                        <table>
                            <tr class="success">

                                <th  style="color: rgba(243, 225, 225, 1);">Change Password </th>
                                <td class="auto-style7">
                                    &nbsp;</td>

                                <td>&nbsp;&nbsp;
                                    
                                    </td>
                            </tr>
                        </table>
                    </div>
                    <div id="collapse" class="">
                        <div class="panel-body" style="background-color: #E7E9EA; height: 420px;">
                            <table class="table" style="border-radius: 20px 20px 20px 20px; height: 158px;">

                                <tr class="" style="background-color: #E7E9EA;">
                              
                                    <td class="auto-style1" dir="ltr" align="center">
                                        &nbsp;</td>
                                     
                                    <td class="auto-style4">
                                        &nbsp;</td>
                                </tr>
                                  <tr class="" style="background-color: #E7E9EA;">
                                   
                                    <td class="auto-style1">
                                  
                                    </td>
                                       <td class="auto-style1" dir="ltr" align="center">
                                       
                                       
                                       
                                    </td>
                                </tr>
                                 <tr class="" style="background-color: #E7E9EA;">
                                   
                                    <td class="auto-style1" dir="ltr" align="center">
                                                   <asp:TextBox ID="oldpass" runat="server" CssClass="form-control" Height="35px" Width="280px" placeholder="Old password"></asp:TextBox>
                                    </td>
                                          <td class="auto-style1" dir="ltr" align="center">
                                              
                                                 <asp:Label ID="woldpass" runat="server"></asp:Label>
                                       
                                    </td>
                                </tr>
                                  <tr class="" style="background-color: #E7E9EA;">
                                   
                                    <td class="auto-style1" dir="ltr" align="center">
                                        <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" Height="35px" Width="280px" placeholder="New password"></asp:TextBox>
                                    </td>
                                          <td class="auto-style1" dir="ltr" align="center">
                                       
                                              <asp:Label ID="newpass" runat="server"></asp:Label>
                                       
                                    </td>
                                </tr>
                                  <tr class="" style="background-color: #E7E9EA;">
                                   
                                    <td class="auto-style1" dir="ltr" align="center">
                                        <asp:TextBox ID="confpass" runat="server" CssClass="form-control" Height="35px" Width="280px" placeholder="Confirm new password"></asp:TextBox>
                                    </td>
                                          <td class="auto-style1" dir="ltr" align="center">
                                       
                                              <asp:Label ID="wconfPass" runat="server"></asp:Label>
                                       
                                    </td>
                                </tr>
                               
                              
                                <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style1" dir="ltr" align="center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<asp:Button ID="submit" runat="server" Text="change" CssClass="btn btn-success" Width="150px" Height="35px" OnClick="submit_Click" />
                                        <asp:Label ID="accstate" runat="server"></asp:Label>
                                        </th>
                                
                                    <td class="auto-style2">
                                        &nbsp;
                                    
                                        <asp:Button ID="back" runat="server" Text="back" Width="114px" CssClass="btn btn-info" OnClick="back_Click"  />
                                    
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="panel-footer" style="background-color: #202030; width: 100%;">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="sideNav" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
</asp:Content>
