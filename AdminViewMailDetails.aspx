<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminViewMailDetails.aspx.cs" Inherits="AdminViewMailDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="1" width ="70%" align ="center" >
        <tr>
            <th>
                <h1>
                    View Mail</h1>
            </th>
        </tr>
        <tr>
            <td  style ="text-align : center ;">
                <center>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns ="False" 
        BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" 
        CellPadding="4" CellSpacing="2" ForeColor="Black" Width="394px" >
                        <Columns >
                          <asp:BoundField DataField ="femailid" HeaderText ="Email ID" />
                          <asp:BoundField DataField ="mdate" HeaderText ="Message Date" />
                          <asp:BoundField DataField ="mcontent" HeaderText ="Content" />
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
            </td>
        </tr>
        <tr>
            <td  style ="text-align : center ;">
                <center>
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </center>
            </td>
        </tr>
    </table>
</asp:Content>

