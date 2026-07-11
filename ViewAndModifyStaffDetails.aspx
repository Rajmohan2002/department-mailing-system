<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewAndModifyStaffDetails.aspx.cs" Inherits="ViewAndModifyStaffDetails" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table  border="2" align="center"   width ="60%" cellpadding ="5px">
        <tr>
            <th>
                <br /><h1>
                    View And Modify Staff Details</h1><br />
            </th>
        </tr>
        <tr>
            <td style="text-align: center">
                <center><asp:FormView ID="FormView1" runat="server" AllowPaging="True" DataKeyNames="staffid"
                    EmptyDataText="Record Not Found!!!" 
                    OnItemDeleting="FormView1_ItemDeleting" OnItemUpdating="FormView1_ItemUpdating"
                    OnModeChanging="FormView1_ModeChanging" OnPageIndexChanging="FormView1_PageIndexChanging"
                    Visible="False" Width="432px" BackColor="#CCCCCC" BorderColor="#999999" 
                        BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" 
                        ForeColor="Black" GridLines="Both">
                    <EditItemTemplate>
                        <table border="2"   width ="100%">
                            <tr>
                                <td>
                                    StaffID</td>
                                <td>
                                    <%#Eval("staffid") %>
                                </td>
                            </tr>
                           
                            <tr>
                                <td>
                                    Staff Name</td>
                                <td>
                                    <asp:TextBox ID="staffname" runat="server"  Text='<%#Bind("staffname") %>'></asp:TextBox></td>
                            </tr>
                             <tr>
                                <td>
                                    Father/Gardian/Husband Name</td>
                                <td>
                                    <asp:TextBox ID="fname" runat="server"  Text='<%#Bind("fname") %>'></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>
                                    Gender</td>
                                <td>
                                    <asp:RadioButtonList ID="gender" runat="server"  RepeatDirection="Horizontal"
                                        Text='<%#Bind("gender") %>'>
                                        <asp:ListItem>Male</asp:ListItem>
                                        <asp:ListItem>Female</asp:ListItem>
                                    </asp:RadioButtonList></td>
                            </tr>
                            <tr>
                                <td>
                                    DateOfBirth</td>
                                <td>
                                    <asp:TextBox ID="dob" runat="server"  Text='<%#Bind("dob","{0:dd-MMM-yyyy}") %>'></asp:TextBox></td>
                            </tr>
                             <tr>
                                <td>
                                    Qualification</td>
                                <td>
                                    <asp:TextBox ID="qualification" runat="server"  Text='<%#Bind("qualification") %>'></asp:TextBox></td>
                            </tr>
                            
                             <tr>
                                <td>
                                    Designation</td>
                                <td>
                                    <asp:TextBox ID="designation" runat="server"  Text='<%#Bind("designation") %>'></asp:TextBox></td>
                            </tr>
                            
                             <tr>
                                <td>
                                    No Of Experience Year</td>
                                <td>
                                    <asp:TextBox ID="expyear" runat="server" Text='<%#Bind("expyear") %>'></asp:TextBox></td>
                            </tr>
                           
                                        <tr>
                                <td>
                                    Contact Number</td>
                                <td>
                                    <asp:TextBox ID="contactno" runat="server"  Text='<%#Bind("contactno") %>'></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>
                                    MailID</td>
                                <td>
                                    <asp:TextBox ID="mailid" runat="server"  Text='<%#Bind("mailid") %>'></asp:TextBox></td>
                            </tr>
                           
                            <tr>
                                <td>
                                    Subject Known</td>
                                <td>
                                    <asp:TextBox ID="sknown" runat="server"  Text='<%#Bind("sknown") %>'></asp:TextBox></td>
                            </tr>
                           
                            <tr>
                                <td>
                                    Staff Photo</td>
                                <td>
                                    <asp:Image ID="i1" runat="server" Height="100" ImageUrl='<%#Eval("staffimage") %>'
                                        Width="100" /></td>
                            </tr>
                            <tr>
                                <td colspan="2" style="text-align: center;">
                                    <asp:LinkButton ID="l1" runat="server" CommandName="Update" Text="Update" ForeColor ="#006600"></asp:LinkButton>
                                    &nbsp;
                                    <asp:LinkButton ID="l2" runat="server" CommandName="Cancel" Text="Cancel" ForeColor ="#006600"></asp:LinkButton></td>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <RowStyle HorizontalAlign="Left" BackColor="White" />
                    <EditRowStyle BackColor="White" Font-Bold="True" ForeColor="Black" />
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <ItemTemplate>
                        <table border="2"  width ="100%">
                            <tr>
                                <td>
                                    StaffID</td>
                                <td>
                                    <%#Eval("staffid") %>
                                </td>
                            </tr>
                            
                            <tr>
                                <td>
                                    Staff Name</td>
                                <td>
                                    <%#Eval("staffname") %>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    FatherName</td>
                                <td>
                                    <%#Eval("fname")%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Gender</td>
                                <td>
                                    <%#Eval("gender") %>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    DateOfBith</td>
                                <td>
                                    <%#Eval("dob","{0:dd-MMM-yyyy}") %>
                                </td>
                            </tr>
                             <tr>
                                <td>
                                    Qualification</td>
                                <td>
                                    <%#Eval("qualification") %>
                                </td>
                            </tr>
                             <tr>
                                <td>
                                    Designation</td>
                                <td>
                                    <%#Eval("Designation") %>
                                </td>
                            </tr>
                             <tr>
                                <td>
                                    No OF Experience Year </td>
                                <td>
                                    <%#Eval("expyear") %>
                                </td>
                            </tr>
                           
                            
                           
                            
                            <tr>
                                <td>
                                    Contact Number</td>
                                <td>
                                    <%#Eval("contactno") %>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    MailID</td>
                                <td>
                                    <%#Eval("mailid") %>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Subject Known</td>
                                <td>
                                    <%#Eval("sknown") %>
                                </td>
                            </tr>
                                                       <tr>
                                <td>
                                    Photo</td>
                                <td>
                                    <asp:Image ID="i1" runat="server" Height="100" ImageUrl='<%#Eval("staffimage") %>'
                                        Width="100" /></td>
                            </tr>
                            <tr>
                                <td colspan="2" style="text-align: center;">
                                    <asp:LinkButton ID="l1" runat="server" CommandName="edit" Text="Edit" ForeColor ="#006600"></asp:LinkButton>
                                    &nbsp;
                                    <asp:LinkButton ID="l2" runat="server" CommandName="delete" OnClientClick='return confirm("Are You Sure.Delete The Record?")'
                                        Text="Delete" ForeColor ="#006600"></asp:LinkButton></td>
                              
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:FormView></center>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></td>
        </tr>
    </table>
</asp:Content>

