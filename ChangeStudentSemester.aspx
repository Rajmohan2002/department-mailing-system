<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ChangeStudentSemester.aspx.cs" Inherits="ChangeStudentSemester" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table    border="2"  width="60%" align="center" cellpadding ="5px" >
        <tr>
            <th colspan="2">
               <br /> <h1>
                    Change Student Semester Details</h1><br />
            </th>
        </tr>
        <tr>
        
        <td style ="text-align :right ;">Batch Year</td>
        <td>
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                onselectedindexchanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:HiddenField ID="HiddenField1" runat="server" />
            </td>
        </tr>
        <tr>
        
        <td style ="text-align :right ;">Total Number of Semester Completed</td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
               <center> 
                   <asp:GridView ID="GridView1" runat="server" 
                    AutoGenerateColumns="False" EmptyDataText="Record Not Found!!!"
                     PageSize="5" 
                       BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" 
                       CellPadding="4" CellSpacing="2" ForeColor="Black" Height="180px" Width="441px" 
                    >
                    <Columns>
                     <asp:BoundField DataField="regno" HeaderText="RollNumber" />
                        <asp:BoundField DataField="Sname" HeaderText="StudentName" />
                      
                       
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
            <td colspan="2" style="text-align: center">
                &nbsp;
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" 
                    Font-Bold="False" ForeColor="#006600">Clear</asp:LinkButton></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Label ID="Label1" runat="server" Font-Bold="False" Text="Label"></asp:Label><br />
            </td>
        </tr>
    </table>
</asp:Content>

