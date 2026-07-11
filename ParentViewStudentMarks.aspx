<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ParentViewStudentMarks.aspx.cs" Inherits="ParentViewStudentMarks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border="1" align ="center" width ="70%">
<tr>
<th colspan ="2"><h1>Mark Details</h1></th>
</tr>
<tr>
<td style ="text-align :right ;">Registration Number</td><td>
    <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True"></asp:TextBox>
    </td>
</tr>
<tr>
<td style ="text-align :right ;">Student Name</td><td>
    <asp:TextBox ID="TextBox2" runat="server" ReadOnly="True"></asp:TextBox>
    </td>
</tr>
<tr>
<td style ="text-align : right ; ">Select Semester</td>
<td>
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
        onselectedindexchanged="DropDownList1_SelectedIndexChanged">
        <asp:ListItem>Select</asp:ListItem>
        <asp:ListItem>I</asp:ListItem>
        <asp:ListItem>II</asp:ListItem>
        <asp:ListItem>III</asp:ListItem>
        <asp:ListItem>IV</asp:ListItem>
        <asp:ListItem>V</asp:ListItem>
        <asp:ListItem>VI</asp:ListItem>
        <asp:ListItem>All</asp:ListItem>
    </asp:DropDownList>
    </td>
</tr>
<tr>
<td style ="text-align : right ; " colspan="2"><center>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns ="False" 
        BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" 
        CellPadding="4" CellSpacing="2" ForeColor="Black" >
    <Columns >
    <asp:BoundField DataField ="papername"  HeaderText ="PaperName" />
    <asp:BoundField DataField ="pcode"  HeaderText ="PaperCode" />
    <asp:BoundField DataField ="fimark"  HeaderText ="I Internal Mark" />
    <asp:BoundField DataField ="fquiz"  HeaderText ="I Quiz Mark" />
    <asp:BoundField DataField ="fass"  HeaderText ="I Assesment Mark" />
    <asp:BoundField DataField ="simark"  HeaderText ="II Internal Mark" />
    <asp:BoundField DataField ="squiz"  HeaderText ="II Quiz Mark" />
    <asp:BoundField DataField ="sass"  HeaderText =" II Assesment Mark" />
    <asp:BoundField DataField ="emark"  HeaderText ="External Mark" />
   
    <asp:BoundField DataField ="percentage"  HeaderText ="Percentage" />
    </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
        <RowStyle BackColor="White" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>
    </center></td>
</tr>
<tr>
<td style ="text-align : center ; " colspan="2">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </td>
</tr>
</table>
</asp:Content>

