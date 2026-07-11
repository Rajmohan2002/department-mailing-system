<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ParentViewStudentFeedback.aspx.cs" Inherits="ParentViewStudentFeedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="1" width ="70%" align ="center" >
        <tr>
            <th colspan ="2">
                <h1>
                    Student Feedback</h1>
            </th>
        </tr>
        <tr>
        <td style ="text-align :right ;">Registration Number</td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
         <tr>
        <td style ="text-align :right ;">Student Name</td>
        <td>
            <asp:TextBox ID="TextBox2" runat="server" ReadOnly="True"></asp:TextBox>
             </td>
        </tr>
        <tr>
            <td  style ="text-align : center ;"  colspan="2">
   <center> <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns ="False" 
        BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" 
        CellPadding="4" CellSpacing="2" ForeColor="Black" Width="409px" >
    <Columns >
  
    <asp:BoundField DataField ="fdate" HeaderText ="Feedback Date" />
    <asp:BoundField DataField ="fdesc" HeaderText ="Description" />
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
    </asp:GridView></center>
            </td>
        </tr>
        <tr>
            <td  style ="text-align : center ;" colspan="2">
                <center>
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </center>
            </td>
        </tr>
    </table>
</asp:Content>

