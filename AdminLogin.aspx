<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminLogin.aspx.cs" Inherits="AdminLogin" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table  border="2" width ="60%" align="center" cellpadding ="5px"   >
        <tr>
            <th colspan="2">
             <br /> <h1>
                    Admin Login</h1> <br />
            </th>
        </tr>
        <tr>
            <td style="text-align: right; ">
                User Name</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Font-Bold="False"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align: right; ">
                Password</td>
            <td >
                <asp:TextBox ID="TextBox2" runat="server" Font-Bold="False" TextMode="Password" 
                    Width="144px"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                &nbsp;<asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" 
                    OnClick="LinkButton1_Click" ForeColor="#006600">Login</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Label"></asp:Label><br />
            </td>
        </tr>
    </table>
</asp:Content>

