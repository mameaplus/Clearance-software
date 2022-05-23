



<%@ Page Language="C#"  MasterPageFile="~/Master Front.Master" AutoEventWireup="true" CodeBehind="Library.aspx.cs" Inherits="ClearanceSystem.Library" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <title></title>  
    <style type="text/css">
        .auto-style1 {
            width: 330px;
        }
        .auto-style2 {
            width: 125px;
        }
        .auto-style3 {
            width: 100px;
        }
        .auto-style4 {
            width: 125px;
            height: 5px;
        }
        .auto-style5 {
            width: 100px;
            height: 5px;
        }
    </style>  
 
    <link href="../../WebBeauty/css/Mycss.css" rel="stylesheet" />
    <link href="../../WebBeauty/css/bootstrap.min.css" rel="stylesheet" />
    <script src="../../WebBeauty/js/bootstrap.min.js"></script>
    <script src="../../WebBeauty/js/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="sideNav" runat="server">
    <div id='cssmenu' style="margin-top: 25px;">
        <ul>  
             <li class=''> <a href="Library%20Home.aspx"><span>Home</span></a></li>          
            <li class=''><a href="Ignore.aspx"><span>Ignore Case</span></a></li>          
            <li class=''><a href='#'><span>View Case</span></a></li>
            <li class=''><a href='#'><span>LogOut</span></a></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
      <form id="Form1" runat="server">

          <div class="container" style="width:100%; margin:10px;">
            <div class="panel-group" id="accordion">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <table>
                            <tr class="success">
                                <th>Book ID:</th>
                                <td>
                                    <asp:TextBox ID="bookID" runat="server" CssClass="form-control" Width="190px" Height="34px"></asp:TextBox></td>
                                <td>&nbsp;
                       
                          <asp:Label ID="wBook" runat="server"></asp:Label>


                                    &nbsp;&nbsp;
                       

                                </td>
                                <th>Student ID:</th>
                                <td>
                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" Width="186px" Height="35px"></asp:TextBox>
                                </td>
                                <td>&nbsp;&nbsp;
                       
                        <asp:Button ID="Button1" runat="server" Text="Load" OnClick="Button1_Click1" CssClass="btn btn-success" Height="33px" />


                                </td>
                                <td>&nbsp;&nbsp;
                       
                          <asp:Label ID="wStud" runat="server"></asp:Label>


                                </td>

                            </tr>
                        </table>

                    </div>
                    <div id="collapse" class="<% Response.Write(state);%>">
                        <div class="panel-body">

                            <table class="table">
                                <tr class="success">
                                    <th class="auto-style4">Name</th>
                                    <td class="auto-style5"><%Response.Write(name); %></td>
                                    <td rowspan="4">
                                        <asp:Image ID="Image1" runat="server" Height="154px" Width="153px" class="img-thumbnail" BackColor="#FF5050" BorderStyle="Double" ForeColor="#3333FF" />
                                        &nbsp;</td>
                                </tr>
                                <tr class="success">
                                    <th class="auto-style2">Departement</th>
                                    <td class="auto-style3"><%Response.Write(Dep); %></td>

                                </tr>
                                <tr class="success">
                                    <th class="auto-style2">Block</th>
                                    <td class="auto-style3"><%Response.Write(Block); %></td>

                                </tr>
                                <tr class="success">
                                    <th class="auto-style2">Dorm</th>
                                    <td class="auto-style3"><%Response.Write(DormNum); %></td>

                                </tr>
                                <tr class="success">
                                    <th class="auto-style2">Book Title</th>
                                    <td class="auto-style3"><%Response.Write(BookTtl); %></td>
                                    <td>&nbsp;</td>
                                </tr>

                                <tr class="success">
                                    <th class="auto-style2">Amount </th>
                                    <td class="auto-style3"><%Response.Write(amount);%></td>
                                    <td class="auto-style1">
                                        <asp:Label ID="Label2" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr class="success">
                                    <th class="auto-style2">AgreeCode</th>
                                    <td class="auto-style3">

                                        <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" Height="29px"></asp:TextBox>
                                    </td>
                                    <td class="auto-style1">
                                        <asp:Label ID="Acode" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr class="success">
                                    <th class="auto-style2">Expiration Date</th>
                                    <td class="auto-style3">

                                        <asp:TextBox ID="ExpDate" runat="server" CssClass="form-control" Height="26px"></asp:TextBox>
                                    </td>
                                    <td class="auto-style1">
                                        <asp:Label ID="warexpdate" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr class="success">
                                    <th class="auto-style2">&nbsp;</th>
                                    <td class="auto-style3">
                                        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="submit" Width="129px" CssClass="btn btn-success" Height="32px" />
                                    </td>
                                    <td class="auto-style1">
                                        <asp:Label ID="RcWarn" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr class="success">
                                    <th class="auto-style2"></th>
                                    <td class="auto-style3"></td>
                                    <td class="auto-style1"></td>
                                </tr>

                            </table>



                        </div>
                        <div class="panel-footer">&nbsp; </div>
                    </div>
                </div>
            </div>
        </div>

        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>

    </form>
</asp:Content>
