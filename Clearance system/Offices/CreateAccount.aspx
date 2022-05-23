<%@ Page Title="" Language="C#" MasterPageFile="~/Master Front.Master" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="ClearanceSystem.Offices.CreateAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../WebBeauty/css/bootstrap.min.css" rel="stylesheet" />
    <style type="text/css">
        p.MsoNormal {
            margin-top: 0in;
            margin-right: 0in;
            margin-bottom: 10.0pt;
            margin-left: 0in;
            line-height: 115%;
            font-size: 11.0pt;
            font-family: "Calibri","sans-serif";
        }

        .auto-style1 {
            width: 168px;
        }

        .auto-style2 {
            width: 142px;
        }

        .auto-style3 {
            width: 143px;
        }

        .auto-style4 {
            width: 144px;
        }

        .auto-style6 {
            width: 168px;
            height: 39px;
        }

        .auto-style7 {
            width: 142px;
            height: 39px;
        }

        .auto-style8 {
            width: 101px;
        }
    .auto-style9 {
        width: 215px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="sideNav" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

    <form id="form1" runat="server">

        <div class="container" style="margin: 0px; padding: 0px; width: 100%; color: steelblue;" id="ok">

            <div class="panel-group" id="accordion">
                <div class="">
                    <div class="panel-heading" style="margin: 0px; border-top-left-radius: 25px; border-top-right-radius: 25px; background-color: rgb(32, 32, 48);">


                        <table>
                            <tr class="success">

                                <th style="color: rgba(243, 225, 225, 1);" class="auto-style4">Email </th>
                                 <td class="auto-style7">
                                        <asp:DropDownList   CssClass="form-control" ID="accountlist" runat="server" Height="31px" Width="124px">
                                            <asp:ListItem Value="30">Student</asp:ListItem>
                                            <asp:ListItem Value="40">Employee</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                <td class="auto-style4">
                                    <asp:TextBox ID="email" runat="server" CssClass="form-control" Width="219px" Height="31px"></asp:TextBox>
                                    
                                            <asp:RegularExpressionValidator ID="Isvalid" runat="server" ErrorMessage="" ControlToValidate="email"></asp:RegularExpressionValidator>
                                </td>

                                <td>&nbsp;&nbsp;
                                    <asp:Button ID="LoadEmail" runat="server" Text="Check Email" CssClass="btn btn-info" Height="32px" Width="110px" OnClick="LoadEmail_Click" />

                                    <asp:Label ID="wEmail" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="collapse" class="">
                        <div class="panel-body" style="background-color: #E7E9EA;">
                            <table class="table" style="border-radius: 20px 20px 20px 20px; height: 213px;">
                                <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style9" colspan="3">
                                        <p class="MsoNormal">
                                            <span>Please check &nbsp;your email for verification code<o:p></o:p></span>
                                        </p>
                                    </th>

                                    <td rowspan="3" class="auto-style3">
                                        <asp:Image ID="photo" runat="server" Height="103px" Width="161px" class="img-thumbnail" BackColor="#669999" BorderStyle="Double" ForeColor="#CCCCCC" />
                                    </td>
                                </tr>
                                <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style1" colspan="2">username:<asp:Label ID="lblemail" runat="server" ForeColor="#009933"></asp:Label>
                                    </th>

                                </tr>

                                <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style6">Verification code</th>
                                    <td class="auto-style7">
                                        <asp:TextBox ID="vcode" CssClass="form-control" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style6">Password</th>
                                    <td class="auto-style7">
                                        <asp:TextBox ID="password" CssClass="form-control" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style1"><span>confirm password </span></th>
                                    <td class="auto-style2">

                                        <asp:TextBox ID="confpassword" CssClass="form-control" runat="server"></asp:TextBox>

                                    </td>
                                    <td class="auto-style8" colspan="2">
                                        <asp:FileUpload ID="getPhoto" runat="server" Font-Bold="True" Font-Italic="True" Font-Names="Calibri" Font-Overline="True" Font-Size="Small" Height="27px" Width="206px" />
                                    </td>
                                </tr>
                                
                            </table>
                        </div>
                        <div class="panel-footer" style="background-color: #202030; width: 100%;">
                            <tr class="" style="background-color: #E7E9EA;">
                                    <th class="auto-style1">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="cancel" runat="server" Text="Cancel" CssClass="btn btn-success" Width="137px" Height="33px" OnClick="cancel_Click" />
                                    </th>
                                    <td class="auto-style2" colspan="2">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="create" runat="server" Text="Create Account" CssClass="btn btn-success" Width="137px" Height="33px" OnClick="create_Click" />
                                    </td>
                                    <td class="auto-style8">
                                        <asp:Label ID="isok" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
