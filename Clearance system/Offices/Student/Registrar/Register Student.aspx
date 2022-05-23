<%@ Page Title="" Language="C#" MasterPageFile="~/frontPageOffice.Master" AutoEventWireup="true" CodeBehind="Register Student.aspx.cs" Inherits="ClearanceSystem.Offices.Student.Registrar.Register_Student" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <!-- styles -->
    <link href="css/styles.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 231px;
        }

        .auto-style2 {
            width: 206px;
        }

        .auto-style3 {
            width: 107px;
        }

        .auto-style4 {
            width: 204px;
        }

        .auto-style5 {
            width: 184px;
        }

        .auto-style6 {
            width: 83px;
        }
    </style>
    <script type="text/javascript">
        function move() {
            if (document.getElementById("collapse").className == "collapes in")
                document.getElementById("collapse").className = "panel-collapse collapse";
            else if (document.getElementById("collapse").className == " panel-collapse collapse")
                document.getElementById("collapse").className = " collapes in";
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="sideNav" runat="server">
    <div id='cssmenu' style="margin-top: 25px;">
        <ul>
          
             <li class=''><a href="RegistrarHome.aspx"><span>Home</span></a></li>
             <li class=''><a href="ManualRegistration.aspx"><span>Register Manualy</span></a></li>
             <li class=''><a href="Register%20Student.aspx"><span>Register from excel</span></a></li>
                 <li class=''><a href=" ../../../changePassword.aspx"><span>Change Password</span></a></li>
            <li class=''><a href="../../../logout.aspx"><span>LogOut</span></a></li>
        </ul>
    </div>
     
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
     
    <form id="form1" runat="server">
        <div class="container" style="margin: 0px; padding: 0px; width: 100%; color: steelblue; background-color: #202030; border-radius: 25px;">

            <div class="panel-group" id="accordion">
                <div class="">
                    <div class="panel-heading" style="margin: 0px; border-top-left-radius: 25px; border-top-right-radius: 25px; background-color: rgb(32, 32, 48);">


                      
                    </div>
                    <div id="collapse" class="">
                        <div class="panel-body" style="background-color: #E7E9EA; height: 100%;">
                            


           <div id="Div1" class="">
                        <div class="panel-body" style="background-color: #E7E9EA; height: 415px; border-bottom-right-radius: 25px; border-bottom-left-radius: 25px; height:auto">

                            <div>
                                <table>
                                    <tr class="success">
                                        <th colspan="2" style="color: rgba(243, 225, 225, 1);" class="auto-style4">&nbsp;</th>
                                        <td class="auto-style7">
                                            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="" Width="199px" Height="33px" ToolTip="Get Excel File" />
                                        </td>
                                        <td>
                                            <asp:Button ID="Register" runat="server" Text="Register" CssClass="btn btn-info" Height="32px" Width="126px" OnClick="Register_Click" />
                                            <asp:Label ID="wExcel" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>

                            </div>
                             
                                <asp:GridView ID="GridView1" AllowPaging="true" AutoGenerateColumns="false" runat="server" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="15" Width="829px">
                                    <%--   (ID, Name, Dep, Block, DormNum, Email, PhoneNum)--%>
                                    <Columns>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TextBox0" runat="server" Text='<%#Eval( "ID") %>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%#Eval( "Name") %>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TextBox2" runat="server" Text='<%#Eval("Dep")%>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TextBox3" runat="server" Text='<%#Eval( "Block") %>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TextBox4" runat="server" Text='<%#Eval( "DormNum") %>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TextBox5" runat="server" Text='<%#Eval( "Email") %>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TextBox6" runat="server" Text='<%#Eval( "PhoneNum") %>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                                    <PagerStyle BackColor="#FFFFCC" ForeColor="Fuchsia" HorizontalAlign="Center" />
                                    <RowStyle BackColor="White" ForeColor="#330099" />
                                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                                    <SortedAscendingCellStyle BackColor="#FEFCEB" />
                                    <SortedAscendingHeaderStyle BackColor="#AF0101" />
                                    <SortedDescendingCellStyle BackColor="#F6F0C0" />
                                    <SortedDescendingHeaderStyle BackColor="#7E0000" />
                                </asp:GridView>
                        
                            <br />

                            <asp:Button ID="Button1" runat="server" Text="Cancel" Width="160px" CssClass="btn btn-info" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="Register1" runat="server" Text="Register" Width="160px" CssClass="btn btn-info" OnClick="Register1_Click" />

                        </div>
                    </div>
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
