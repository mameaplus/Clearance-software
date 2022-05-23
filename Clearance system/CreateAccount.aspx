<%@ Page Title="" Language="C#" MasterPageFile="~/Master Front.Master" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="ClearanceSystem.CreateAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
 <link href="WebBeauty/css/bootstrap.min.css" rel="stylesheet" />
     
    <script src="WebBeauty/js/bootstrap.min.js"></script>
    <script src="WebBeauty/js/jquery.min.js"></script>
    <style type="text/css">
        .auto-style1 {
            font-weight: normal;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="sideNav" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
     <form id="form1" runat="server">
        <div class="container" style="margin: 0px; padding: 0px; width: 100%; color:steelblue;" >
            <div class="panel-group" id="accordion">
                <div class="" style="">
                    <div class="panel-heading" style="margin: 0px; border-top-left-radius: 25px; border-top-right-radius: 25px; background-color: rgb(32, 32, 48);">
                        <table>
                            <tr class="success">

                                <th colspan="2" style="color: rgba(243, 225, 225, 1);"><span class="auto-style1" ><strong>Email </strong></span>  :</th>
                                <td class="auto-style7">
                                    <asp:TextBox ID="Email" runat="server" CssClass="form-control" Width="267px" Height="31px" ></asp:TextBox>
                                </td>

                                <td>&nbsp;&nbsp;
                                    <asp:Button ID="Load" Text="Get V.Code" runat="server" CssClass="btn btn-info"  Height="32px" Width="126px" OnClick="Load_Click" />

                                    <asp:Label ID="WVEmail" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="collapse" class="<%Response.Write(state); %>">
                        <div class="panel-body" style="background-color: #E7E9EA;">
                            <table class="table" style="border-radius: 20px 20px 20px 20px; height: 276px;">
                                <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style1">User Name</th>
                                    <td class="auto-style2">
                                        <asp:TextBox ID="Univer2" runat="server" CssClass="form-control" Height="32px" Width="222px"></asp:TextBox>
                                    </td>
                                    <td rowspan="7" class="auto-style3">
                                        &nbsp;</td>
                                </tr>
                                <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style1">Password</th>
                                    <td class="auto-style2">
                                        <asp:TextBox ID="Univer1" runat="server" CssClass="form-control" Height="32px" Width="222px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style1">Confirm Password</th>
                                    <td class="auto-style2">
                                        <asp:TextBox ID="Univer0" runat="server" CssClass="form-control" Height="32px" Width="222px"></asp:TextBox>
                                    </td>
                                </tr>
                             
                               
                                <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style1">Agreement Code</th>
                                    <td class="auto-style2">
                                        <asp:TextBox ID="Acode" runat="server" CssClass="form-control" Height="35px" Width="222px"></asp:TextBox>
                                    </td>
                                </tr>
                               
                                <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style1"> </th>
                                    <td class="auto-style2">
                                        <asp:Button ID="Cancel" runat="server" Text="Cancel" CssClass="btn btn-success" Width="113px" Height="35px" />
                                    &nbsp;&nbsp;
                                        <asp:Button ID="SignUp" runat="server" Text="Sign Up" CssClass="btn btn-info" Width="107px" Height="35px" />
                                    </td>
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
