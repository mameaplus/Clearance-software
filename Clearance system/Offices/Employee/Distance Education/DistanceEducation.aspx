<%@ Page Title="" Language="C#" MasterPageFile="~/frontPageOffice.Master" AutoEventWireup="true" CodeBehind="DistanceEducation.aspx.cs" Inherits="ClearanceSystem.Offices.Employee.Distance_Education.DistanceEducation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="sideNav" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <form id="form1" runat="server">
          <div class="container" style="margin: 0px; padding: 0px; width: 100%; color:steelblue;" >
            <div class="panel-group" id="accordion">
                <div class="">
                  <div class="panel-heading" style="margin: 0px; border-top-left-radius: 25px; border-top-right-radius: 25px; background-color: rgb(32, 32, 48);">
                        <table>
                            <tr class="success">

                                <th colspan="2">Student ID:</th>
                                <td class="auto-style7">
                                    <asp:TextBox ID="EmpID" runat="server" CssClass="form-control" Width="267px" Height="31px"></asp:TextBox>
                                </td>

                                <td>&nbsp;&nbsp;
                                    <asp:Button ID="Load" runat="server" Text="Load" CssClass="btn btn-info" OnClick="Load_Click" Height="38px" />

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
                                        <asp:TextBox ID="Univer" runat="server" CssClass="form-control" Height="30px" Width="208px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr class="success">
                                    <th class="auto-style1">Country </th>
                                    <td class="auto-style6">
                                        <asp:TextBox ID="Country" runat="server" CssClass="form-control" Height="29px" Width="208px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr class="success">
                                    <th class="auto-style5">Agreement Code</th>
                                    <td class="auto-style8">
                                        <asp:TextBox ID="Acode" runat="server" CssClass="form-control" Height="29px" Width="206px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr class="success">
                                    <th class="auto-style1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </th>
                                    <td class="auto-style6">
                                        <asp:Button ID="submit" runat="server" Text="Submit" CssClass="btn btn-success" Width="137px" Height="31px" OnClick="submit_Click" />
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
    </form>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
