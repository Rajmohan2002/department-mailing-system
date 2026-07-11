<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MonthlyAttendanceForm.aspx.cs" Inherits="MonthlyAttendanceForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table  border="2"  width="60%" align="center" cellpadding ="5px" >
        <tr>
            <th colspan="2">
                <br /><h1>
                    Monthly Attendance Details</h1><br />
            </th>
        </tr>
        <tr>
            <td style="text-align: right">
                Select Year</td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                Year</td>
            <td>
                <asp:RadioButtonList ID="RadioButtonList2" runat="server" Font-Bold="False" 
                    Width="112px" AutoPostBack="True" 
                    OnSelectedIndexChanged="RadioButtonList2_SelectedIndexChanged" 
                    RepeatLayout="Flow">
                    <asp:ListItem>I Year</asp:ListItem>
                    <asp:ListItem>II Year</asp:ListItem>
                    <asp:ListItem>III Year</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td style="height: 26px; text-align: right">
                Semester</td>
            <td style="height: 26px">
                <asp:RadioButtonList ID="RadioButtonList3" runat="server" AutoPostBack="True" Font-Bold="False"
                    OnSelectedIndexChanged="RadioButtonList3_SelectedIndexChanged" RepeatColumns="2"
                    RepeatDirection="Horizontal" Width="112px" RepeatLayout="Flow">
                    <asp:ListItem>I</asp:ListItem>
                    <asp:ListItem>II</asp:ListItem>
                    <asp:ListItem>III</asp:ListItem>
                    <asp:ListItem>IV</asp:ListItem>
                    <asp:ListItem>V</asp:ListItem>
                    <asp:ListItem>VI</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td style="height: 26px; text-align: right">
                Select Month</td>
            <td style="height: 26px">
                <asp:DropDownList ID="DropDownList3" runat="server" Font-Bold="False" 
                    Width="144px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="height: 26px; text-align: right">
                Total No Of Working Days</td>
            <td style="height: 26px">
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 26px; text-align: center" colspan="2">
                <asp:LinkButton ID="LinkButton3" runat="server" onclick="LinkButton3_Click" 
                    ForeColor="#006600">View</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <center>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                    EmptyDataText="Record Not Found"
                    PageSize="5" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" 
                        BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" 
                        Width="401px" >
                        <Columns>
                            <asp:BoundField DataField="regno" HeaderText="RegistrationNumber" />
                            <asp:BoundField DataField="sname" HeaderText="StudentName" />
                            <asp:TemplateField HeaderText="TotalDays">
                                <ItemTemplate>
                                    <asp:TextBox ID="tday" runat="server" Text="0"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
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
                </center>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                &nbsp;<asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="False" 
                    OnClick="LinkButton1_Click" ForeColor="#006600">Update</asp:LinkButton>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click" 
                    ForeColor="#006600">Clear</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Label ID="Label1" runat="server" Font-Bold="False" Text="Label"></asp:Label>
                <br />
            </td>
        </tr>
    </table>
</asp:Content>

