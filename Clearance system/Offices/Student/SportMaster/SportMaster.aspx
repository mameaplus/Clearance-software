<%@ Page Language="C#" MasterPageFile="~/frontPageOffice.Master" AutoEventWireup="true" CodeBehind="SportMaster.aspx.cs" Inherits="ClearanceSystem.SportMaster" ViewStateMode="Enabled" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- JavaScript-->
    <script src="WebBeauty/MasterJS/jquery-latest.min.js"></script>
    <script src="WebBeauty/MasterJS/script.js"></script>
    <script src="WebBeauty/js/bootstrap.min.js"></script>
    <script src="WebBeauty/js/jquery.min.js"></script>
    <!-- CSS style sheet-->
    <link href="WebBeauty/css/bootstrap.min.css" rel="stylesheet" />
    <link href="WebBeauty/css/Mycss.css" rel="stylesheet" />
    <link href="WebBeauty/MasterCss/CssA1.css" rel="stylesheet" />
    <link href="WebBeauty/MasterCss/styles.css" rel="stylesheet" />

    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 330px;
        }

        .auto-style2 {
            width: 125px;
        }

        .auto-style4 {
            width: 125px;
            height: 5px;
        }

        .auto-style5 {
            width: 100px;
            height: 5px;
        }
        .body {
            height:<% Response.Write(60+"%");%>
        }
        .auto-style6 {
            width: 325px;
        }
        .auto-style7 {
            width: 317px;
        }
        .auto-style8 {
            width: 257px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="sideNav" runat="server">
     <div id='cssmenu' style="margin-top: 25px;">
        <ul>  
           
            <li class=''> <a href="IgnoreMaterial.aspx"><span>Ignore Case</span></a></li>          
            <li class=''><a href='#'><span>View Case</span></a></li>
            <li class=''><a href='#'><span>LogOut</span></a></li>
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
                                <th colspan="2">Student ID  </th>
                                <td class="auto-style7">
                                    <asp:TextBox ID="StudID" runat="server" CssClass="form-control" Width="267px" Height="33px"></asp:TextBox>
                                </td>

                                <td>&nbsp;&nbsp;
                       
                          <asp:Label ID="wStud" runat="server"></asp:Label>
                                    <asp:Button ID="Load" runat="server" Text="Load" CssClass="btn btn-info" OnClick="Load_Click" Width="152px" Height="37px" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="collapse" class="<%Response.Write(state);%>">
                        <div class="panel-body">
                            <table class="table" style="border-radius: 20px 20px 20px 20px">
                                <tr class="success">
                                    <th class="auto-style1">Name</th>
                                    <td class="auto-style8"><%Response.Write(name); %></td>
                                    <td rowspan="4" class="auto-style5">
                                        <asp:Image ID="Image1" runat="server" Height="169px" Width="175px" class="img-thumbnail" BackColor="#336699" BorderStyle="Dotted" ForeColor="#3333FF" BorderColor="#FFCC99" />
                                        &nbsp;</td>
                                </tr>
                                <tr class="success">
                                    <th class="auto-style2">Departement</th>
                                    <td class="auto-style8"><%Response.Write(Dep); %></td>
                                </tr>
                                <tr class="success">
                                    <th>Block</th>
                                    <td class="auto-style8"><%Response.Write(Block); %></td>
                                </tr>
                                <tr class="success">
                                    <th>Dorm</th>
                                    <td class="auto-style8"><%Response.Write(DormNum); %></td>
                                </tr>
                            </table>
                         
                        </div>
                        <div class="panel-footer">
                               <h1 style="color: #000066; background-color: #669900; font-family: 'Bell MT'; width: 579px;">All Sport Materials list </h1>
                            <asp:Table ID="MList" runat="server" BackColor="#DFF0D8" BorderColor="#9900CC" CellPadding="12" CellSpacing="12" Height="16px" Width="100%"></asp:Table>
                            <table>
                                <tr class="success">
                                    <td class="auto-style9">
                                        <asp:Button ID="Genrate" runat="server" Text="Get Agreement Code" CssClass="btn btn-success" Width="179px" OnClick="Genrate_Click" Height="42px" />
                                    </td>
                                    <th class="auto-style5">Agreement Code</th>
                                    <td class="auto-style4">
                                        <asp:TextBox ID="AcodeTB" runat="server" Width="289px" CssClass="form-control" Height="36px"></asp:TextBox>
                                    </td>
                                    <td class="auto-style6">
                                        <asp:Button ID="Submit" runat="server" Text="submit" CssClass="btn btn-success" Width="167px" OnClick="Submit_Click" Height="43px" />

                                    </td>
                                    <td class="auto-style6">
                                        <asp:Label ID="Label1" runat="server"></asp:Label>

                                    </td>

                                </tr>
                            </table>
                            <br />
                        </div>
                         <div class="panel-footer">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
