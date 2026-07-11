<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ParentLogin.aspx.cs" Inherits="ParentLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table  align="center"  border="2"  width="60%" cellpadding ="5px">
        <tr>
            <th colspan="2">
               <br /> <h1>
                    Parent Login</h1><br />
            </th>
        </tr>
        <tr>
            <td style="text-align: right">
                LoginID</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox></td>
        </tr>
        <tr>
            <td style=" text-align: right">
                Password</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server"  TextMode="Password" ></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
&nbsp;&nbsp;&nbsp; <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" 
                    ForeColor="#006600">Login</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Label ID="Label1" runat="server"  Text="Label"></asp:Label><br />
            </td>
        </tr>
    </table>

</asp:Content>

