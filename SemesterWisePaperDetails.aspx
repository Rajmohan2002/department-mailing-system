<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SemesterWisePaperDetails.aspx.cs" Inherits="SemesterWisePaperDetails" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border ="2" align="center"   width="60%" cellpadding ="5px">
        <tr>
            <th colspan="2">
                <br /><h1>
                    Semesterwise Paper Details</h1><br />
            </th>
        </tr>
        <tr>
            <td style="text-align: right">
                Year</td>
            <td>
                <asp:RadioButtonList ID="RadioButtonList2" runat="server" Font-Bold="False" 
                    Width="112px" RepeatLayout="Flow">
                    <asp:ListItem>I Year</asp:ListItem>
                    <asp:ListItem>II Year</asp:ListItem>
                    <asp:ListItem>III Year</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td style="text-align: right">
                Semester</td>
            <td>
                <asp:RadioButtonList ID="RadioButtonList3" runat="server" AutoPostBack="True" Font-Bold="False"
                    OnSelectedIndexChanged="RadioButtonList3_SelectedIndexChanged" RepeatColumns="2"
                    RepeatDirection="Horizontal" Width="112px" RepeatLayout="Flow">
                    <asp:ListItem>I</asp:ListItem>
                    <asp:ListItem>II</asp:ListItem>
                    <asp:ListItem>III</asp:ListItem>
                    <asp:ListItem>IV</asp:ListItem>
                    <asp:ListItem>V</asp:ListItem>
                    <asp:ListItem>VI</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td style="height: 23px; text-align: right">
                Total Number Of Paper</td>
            <td style="height: 23px">
                <asp:TextBox ID="TextBox3" runat="server" Font-Bold="False"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="height: 23px; text-align: right">
                Paper Name</td>
            <td style="height: 23px">
                <asp:TextBox ID="TextBox4" runat="server" Font-Bold="False"></asp:TextBox><br />
                <asp:LinkButton ID="LinkButton3" runat="server" Font-Bold="False" 
                    OnClick="LinkButton3_Click" ForeColor="#006600">Add</asp:LinkButton><br />
                <asp:ListBox ID="ListBox1" runat="server" Font-Bold="False" Height="100px" 
                    Width="152px">
                </asp:ListBox></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                &nbsp;<asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="False" 
                    OnClick="LinkButton1_Click" ForeColor="#006600">Insert</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="False" 
                    OnClick="LinkButton2_Click" ForeColor="#006600">Clear</asp:LinkButton></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Label ID="Label1" runat="server" Font-Bold="False" Text="Label"></asp:Label><br />
            </td>
        </tr>
    </table>
</asp:Content>

