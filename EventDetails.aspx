<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EventDetails.aspx.cs" Inherits="EventDetails" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table  border="2" align="center"   width="60%" cellpadding ="5px">
        <tr>
            <th colspan="2">
                <br /><h1>
                    Event Details</h1><br />
            </th>
        </tr>
        <tr>
            <td style="text-align: right">
                Event Name</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Font-Bold="False"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align: right">
                Event Type</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" Font-Bold="False"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align: right">
                Event&nbsp; Description</td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server" Font-Bold="False" 
                    TextMode="MultiLine"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align: right">
                Venue</td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server" Font-Bold="False"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align: right">
                Date</td>
            <td align="left" >
                &nbsp;<asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" Visible="False">
                </asp:Calendar>
                <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click" 
                    ForeColor="#006600">Show Calendar</asp:LinkButton>
                <br />
                <asp:TextBox ID="TextBox5" runat="server" Font-Bold="False"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:LinkButton ID="LinkButton1" runat="server"  OnClick="LinkButton1_Click" 
                    ForeColor="#006600">Insert</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="LinkButton2" runat="server"  OnClick="LinkButton2_Click" 
                    ForeColor="#006600">Clear</asp:LinkButton></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Label ID="Label1" runat="server" Font-Bold="False" Text="Label"></asp:Label></td>
        </tr>
    </table>
</asp:Content>

