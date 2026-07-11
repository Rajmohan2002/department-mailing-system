<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SubjectAllotment.aspx.cs" Inherits="SubjectAllotment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table   border="2" style="font-weight: bold" width ="100%">
        <tr>
            <th colspan="2">
                <h1>
                    Subject Allotment</h1>
            </th>
        </tr>
        <tr>
            <td style="text-align: right">
                Year</td>
            <td>
                <asp:RadioButtonList ID="RadioButtonList2" runat="server" AutoPostBack="True" Font-Bold="False"
                    OnSelectedIndexChanged="RadioButtonList2_SelectedIndexChanged" 
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
                <asp:RadioButtonList ID="RadioButtonList3" runat="server" Font-Bold="False" RepeatColumns="2"
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
            <td style="text-align: right">
                Paper Name</td>
            <td>
                <asp:ListBox ID="ListBox1" runat="server" AutoPostBack="True" Font-Bold="False" Height="100px"
                    OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" Width="152px"></asp:ListBox></td>
        </tr>
        <tr>
            <td style="text-align: right">
                Staff ID</td>
            <td>
                <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" Font-Bold="False"
                    OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" Width="152px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="text-align: right">
                Staff Name</td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server" Font-Bold="False" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align: right">
                Handled Paper</td>
            <td>
                <asp:ListBox ID="ListBox2" runat="server" Font-Bold="False" Height="100px" 
                    Width="152px">
                </asp:ListBox></td>
        </tr>
        <tr>
            <td style="text-align: right">
                Allotment Paper&nbsp;</td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server" Font-Bold="False" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align: right">
                Paper Code</td>
            <td>
                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                &nbsp;<asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" OnClick="LinkButton1_Click">Insert</asp:LinkButton>
                <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="True" OnClick="LinkButton2_Click">Clear</asp:LinkButton></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Label"></asp:Label><br />
            </td>
        </tr>
    </table>
</asp:Content>

