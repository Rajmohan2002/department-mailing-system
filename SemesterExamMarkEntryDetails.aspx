<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SemesterExamMarkEntryDetails.aspx.cs" Inherits="SemesterExamMarkEntryDetails" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table  border="2"  width="60%" align="center" cellpadding ="5px" >
        <tr>
            <th colspan="2">
                <br /><h1>
                    Semester Exam Mark Entry Details</h1><br />
            </th>
        </tr>
        <tr>
            <td style="text-align: right">
                Select Year</td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" Font-Bold="False" 
                    Width="144px" AutoPostBack="True" 
                    OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                </asp:DropDownList></td>
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
                </asp:RadioButtonList></td>
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
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td style="height: 26px; text-align: right">
                Paper Name</td>
            <td style="height: 26px">
                <asp:DropDownList ID="DropDownList2" runat="server" Font-Bold="False" 
                    Width="144px" AutoPostBack="True" 
                    OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="height: 26px; text-align: right">
                Paper Code</td>
            <td style="height: 26px">
                <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 26px; text-align: right">
                Staff ID</td>
            <td style="height: 26px">
                <asp:TextBox ID="TextBox2" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 26px; text-align: right">
                Staff Name</td>
            <td style="height: 26px">
                <asp:TextBox ID="TextBox3" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <center><asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    EmptyDataText="Record Not Found" 
                    PageSize="5" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" 
                        BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" 
                        Width="489px" >
                    <Columns>
                        <asp:BoundField DataField="regno" HeaderText="RegNo" />
                        <asp:BoundField DataField="sname" HeaderText="StudName" />
                        <asp:TemplateField HeaderText="I Internal">
                            <ItemTemplate>
                                <asp:TextBox ID="FIMark" runat="server" Font-Bold="true" Text="0"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="I Quiz">
                            <ItemTemplate>
                                <asp:TextBox ID="FQuiz" runat="server" Font-Bold="true" Text="0"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>

                          <asp:TemplateField HeaderText="I Assesment">
                            <ItemTemplate>
                                <asp:TextBox ID="FAss" runat="server" Font-Bold="true" Text="0"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="II Internal">
                            <ItemTemplate>
                                <asp:TextBox ID="SIMark" runat="server" Font-Bold="true" Text="0"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="II Quiz">
                            <ItemTemplate>
                                <asp:TextBox ID="SQuiz" runat="server" Font-Bold="true" Text="0"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>

                          <asp:TemplateField HeaderText="II Assesment">
                            <ItemTemplate>
                                <asp:TextBox ID="SAss" runat="server" Font-Bold="true" Text="0"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="External">
                            <ItemTemplate>
                                <asp:TextBox ID="Ext" runat="server" Font-Bold="true" Text="0"></asp:TextBox>
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
                </asp:GridView></center>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                &nbsp;<asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" 
                    OnClick="LinkButton1_Click" ForeColor="#006600">Update</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click" 
                    ForeColor="#006600">Clear</asp:LinkButton></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Label"></asp:Label><br />
            </td>
        </tr>
    </table>
</asp:Content>

