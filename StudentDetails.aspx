<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StudentDetails.aspx.cs" Inherits="StudentDetails" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table  border="2" align="center"   width="60%" cellpadding ="5px">
        <tr>
            <th colspan="2">
               <br /> <h1>
                    Student Details</h1><br />
            </th>
        </tr>
       
        <tr>
            <td style="text-align: right">
                Registration Number</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Font-Bold="False"></asp:TextBox></td>
        </tr>
         <tr>
            <td style="text-align: right">
                Student Name</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" Font-Bold="False"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align: right">
                Gender</td>
            <td>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" Font-Bold="False" 
                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td style="text-align: right">
                Date Of Birth</td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" Font-Bold="False">
                </asp:DropDownList>
                <asp:DropDownList ID="DropDownList2" runat="server" Font-Bold="False">
                <asp:ListItem>Month</asp:ListItem>
                    <asp:ListItem>Jan</asp:ListItem>
                    <asp:ListItem>Feb</asp:ListItem>
                     <asp:ListItem>Mar</asp:ListItem>
                     <asp:ListItem>Apr</asp:ListItem>
                     <asp:ListItem>May</asp:ListItem>
                     <asp:ListItem>Jun</asp:ListItem>
                     <asp:ListItem>Jul</asp:ListItem>
                     <asp:ListItem>Aug</asp:ListItem>
                     <asp:ListItem>Sep</asp:ListItem>
                     <asp:ListItem>Oct</asp:ListItem>
                     <asp:ListItem>Nov</asp:ListItem>
                     <asp:ListItem>Dec</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="DropDownList3" runat="server" Font-Bold="False">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="text-align: right">
                Father/Gardian Name</td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server" Font-Bold="False"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align: right">
                Address</td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server" Font-Bold="False"></asp:TextBox><br />
                <asp:TextBox ID="TextBox5" runat="server" Font-Bold="False"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align: right">
                City</td>
            <td>
                <asp:TextBox ID="TextBox6" runat="server" Font-Bold="False"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align: right">
                Contact Number</td>
            <td>
                <asp:TextBox ID="TextBox7" runat="server" Font-Bold="False"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align: right">
                MailID</td>
            <td>
                <asp:TextBox ID="TextBox8" runat="server" Font-Bold="False"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align: right">
                Medium</td>
            <td>
                <asp:RadioButtonList ID="RadioButtonList2" runat="server" Font-Bold="False" 
                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem>Tamil</asp:ListItem>
                    <asp:ListItem>English</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td style="text-align: right">
                Photo</td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" Font-Bold="False" /><br />
                <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click" 
                    Font-Bold="False">View</asp:LinkButton><br />
                <asp:Image ID="Image1" runat="server" Height="100px" Width="100px" />
                <asp:HiddenField ID="HiddenField2" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                Batch Year</td>
            <td>
                <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="False" 
                    OnClick="LinkButton1_Click" ForeColor="#006600">Insert</asp:LinkButton>&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="False" 
                    OnClick="LinkButton2_Click" ForeColor="#006600">Clear</asp:LinkButton></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Label ID="Label1" runat="server" Font-Bold="False" Text="Label"></asp:Label></td>
        </tr>
    </table>
</asp:Content>

