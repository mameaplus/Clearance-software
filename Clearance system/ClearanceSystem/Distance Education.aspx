<%@ Page Language="C#"  MasterPageFile="~/kiotClearMaster.Master"  AutoEventWireup="true" CodeBehind="Distance Education.aspx.cs" Inherits="ClearanceSystem.Distance_Education" %>



       <asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
        <link href="WebBeauty/css/bootstrap.min.css" rel="stylesheet" />
      <script src="WebBeauty/js/jquery.min.js"></script> 
           
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 196px;
        }
        .auto-style3 {
            width: 196px;
            height: 42px;
        }
        .auto-style5 {
            width: 196px;
            height: 32px;
        }
        .auto-style6 {
            width: 201px;
        }
        .auto-style7 {
            width: 197px;
            height: 32px;
        }
        .auto-style8 {
            width: 201px;
            height: 32px;
        }
        </style>

           </asp:Content>


   <asp:Content ID="DistanceForm" ContentPlaceHolderID="Body" runat="server">
       <div class="container">
            <div class="panel-group" id="accordion">
                <div class="panel panel-default">
                    <div class="panel-heading">
                         <table>
                            <tr class="success">                          
                                                             
                                <th colspan="2">Student ID:</th>
                                <td class="auto-style7">
                                    <asp:TextBox ID="EmpID" runat="server" CssClass="form-control" Width="267px" Height="31px" ></asp:TextBox>
                                </td>
                                
                                <td> 
                       
                          &nbsp;&nbsp;
                                    <asp:Button ID="Load" runat="server" Text="Load"  CssClass="btn btn-info" OnClick="Load_Click" Height="38px" />
                       
                          <asp:Label ID="wEmp" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="collapse" class="<%Response.Write(state); %>">
                        <div class="panel-body">
                              <table class="table" style="border-radius: 20px 20px 20px 20px; height: 213px;">
                                <tr class="success">
                                    <th class="auto-style1">Name</th>
                                    <td class="auto-style6"><% Response.Write(name); %></td>
                                    <td rowspan="7" class="auto-style3">
                                        <asp:Image ID="photo" runat="server" Height="169px" Width="175px" class="img-thumbnail" BackColor="#FF5050" BorderStyle="Double" ForeColor="#3333FF" />
                                        </td>
                                </tr>
                                <tr class="success">
                                    <th class="auto-style1">Departement</th>
                                    <td class="auto-style6"><%   Response.Write(Dep); %></td>
                                </tr>
                                 <tr class="success">
                                    <th class="auto-style1">Academic Record</th>
                                    <td class="auto-style6"><% Response.Write(Arecord); %></td>
                                </tr>
                               
                                <tr class="success">
                                    <th class="auto-style1">scholarship university</th>
                                    <td class="auto-style6"> 
                                        <asp:TextBox ID="Univer" runat="server" CssClass="form-control" Height="30px" Width="208px" ></asp:TextBox>
                                    </td>
                               </tr>
                                   <tr class="success">
                                    <th class="auto-style1">Country </th>
                                    <td class="auto-style6"> 
                                        <asp:TextBox ID="Country" runat="server" CssClass="form-control" Height="29px" Width="208px" ></asp:TextBox>
                                       </td>
                               </tr>
                                   <tr class="success">
                                    <th class="auto-style5">Agreement Code</th>
                                    <td class="auto-style8"  > 
                                        <asp:TextBox ID="Acode" runat="server" CssClass="form-control" Height="29px" Width="206px" ></asp:TextBox>
                                       </td>
                               </tr>
                                   <tr class="success">
                                    <th class="auto-style1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        </th>
                                    <td class="auto-style6"> 
                                       <asp:Button ID="submit" runat="server" Text="Submit" CssClass="btn btn-success"  Width="137px" Height="31px" OnClick="submit_Click" />
                                       </td>
                               </tr>
                            </table>
                         
                        </div>
                        <div class="panel-footer">
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>

