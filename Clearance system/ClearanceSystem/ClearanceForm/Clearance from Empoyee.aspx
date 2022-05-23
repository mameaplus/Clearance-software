<%@ Page Title="" Language="C#" MasterPageFile="~/Offices/Registrar.Master" AutoEventWireup="true" CodeBehind="Clearance from Empoyee.aspx.cs" Inherits="ClearanceSystem.ClearanceForm.Clearance_from_Empoyee" %>

<asp:Content ID="Content2" ContentPlaceHolderID="sideNav" runat="server">
    <div id='cssmenu' style="margin-top: 25px;">
        <ul>         
            <li class=''><a href="Uncleared%20offices.aspx"><span>Uncleared office(s) <%Response.Write("<b style=\"color:red;\"> (" + uncleared + ") </b>"); %></span></a></li>
            <li class=''><a href="../logout.aspx"><span>LogOut</span></a></li>
            <li class=''> <span> <asp:Button ID="btnPrint" runat="server" Text="Print" OnClientClick="return PrintPanel();" Width="159px" CssClass="btn btn-info" />
            &nbsp;</span></li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("printme");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title>DIV Contents</title>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }
    </script>
   
    
        <div id="printme">
        <div style="width:auto; height:auto; background-color:rgb(255, 255, 255); border:2px solid " >
           <div style="width:100%; height:280px; background-color:rgb(255, 255, 255);  border:2px solid">
                           <div style="border-style: solid; border-color: inherit; border-width: 2px; width: 100%; height: 236px; background-color: rgb(255, 255, 255); direction: ltr;">

                               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                    <img alt="wollo" src="../WebBeauty/MasterImage/wollo.jpg" style="width: 125px; height: 93px; margin-bottom: 0px;" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                               <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;WOLLO UNIVERSITY&nbsp;&nbsp;&nbsp;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Kombolcha institute of thechnology Human Resource Management Office</strong><br />
            
                <hr style="border: thick solid #000000; background-color: #000000; width: auto; height: auto; top: auto; right: auto; bottom: auto; left: auto; width:98%;"/>
 Ato /W/ro/W/rt &nbsp;<b><%  Response.Write(Session["Empname"] as string); %></b>
in wollo university institute of Technology were an employee as a&nbsp;&nbsp;<b><%  Response.Write(Session["depar"] as string); %></b>
                                and has returned all the properties he received from the universit
            </div>
           </div>
            <asp:GridView AutoGenerateColumns="false" ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Height="141px" Width="100%">
                <AlternatingRowStyle BackColor="White" />
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

                <Columns>
                    <%-- <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%#Eval("Dep")%>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                    <%--                   <asp:TemplateField HeaderText="Signature">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("id")%>' ></asp:Label>                       
                    </ItemTemplate>
                </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("StaffName")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Signature">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("sign")%>' Height="50px" Width="80px" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        
        </div>
            With Best Regards
            <br/>
                <hr/>
     </div>
</asp:Content>
 
