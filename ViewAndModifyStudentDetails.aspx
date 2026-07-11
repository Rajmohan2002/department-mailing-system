<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewAndModifyStudentDetails.aspx.cs" Inherits="ViewAndModifyStudentDetails" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table  border="2" align="center"   width ="60%" cellpadding ="5px">
        <tr>
            <th>
                <br /><h1>
                    View And Modify
                    Student Details</h1><br />
            </th>
        </tr>
    <tr>
        <td style="text-align: center">
            <center><asp:FormView ID="FormView1" runat="server" OnPageIndexChanging="FormView1_PageIndexChanging" Visible="False" OnModeChanging="FormView1_ModeChanging" DataKeyNames="regno" EmptyDataText="Record Not Found!!!" OnItemUpdating="FormView1_ItemUpdating" OnItemDeleting="FormView1_ItemDeleting" AllowPaging="True" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" GridLines="Both" Width="384px">
                <EditRowStyle BackColor="White" Font-Bold="True" ForeColor="Black" />
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
  <ItemTemplate>
  
  <table border="2"   width ="100%">
  
  <tr>
  <td>Registration Number</td>
  <td><%#Eval("regno") %></td>
  </tr>
  
  
  <tr>
  <td>Student Name</td>
  <td><%#Eval("sname") %></td>
  </tr>
  
  <tr>
  <td>Gender</td>
  <td><%#Eval("gender") %></td>
  </tr>
  
  <tr>
  <td>DateOfBith</td>
  <td><%#Eval("dob","{0:dd-MMM-yyyy}") %></td>
  </tr>
  
  <tr>
  <td>FatherName</td>
  <td><%#Eval("fname")%></td>
  </tr>
  
  
  
  <tr>
  <td>Address</td>
  <td><%#Eval("address1") %><br /><%#Eval("address2") %></td>
  </tr>
  <tr>
  <td>City</td>
  <td><%#Eval("city") %></td>
  </tr>
  
  <tr>
  <td>Contact Number</td>
  <td><%#Eval("contactno") %></td>
  </tr>
  
  <tr>
  <td>MailID</td>
  <td><%#Eval("mailid") %></td>
  </tr>
  
  <tr>
  <td>Medium</td>
  <td><%#Eval("medium") %></td>
  </tr>
  
  
  
  <tr>
  <td>Photo</td>
  <td><asp:Image ID="i1" runat ="server" ImageUrl ='<%#Eval("studphoto") %>' Width ="100" Height ="100" /></td>
  </tr>
  
  <tr>
  <td colspan ="2" style ="text-align :center ; "><asp:LinkButton ID="l1" runat ="server" Text ="Edit"  CommandName ="edit" ForeColor ="#006600"></asp:LinkButton>&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="l2" runat ="server" Text ="Delete"  CommandName ="delete" OnClientClick ='return confirm("Are You Sure.Delete The Rrcord?")' ForeColor ="#006600" ></asp:LinkButton></td>
  
  </tr>
  
  
  </table>
  </ItemTemplate>
  <EditItemTemplate>
  
  <table border="2"   width ="100%">
  
  <tr>
  <td>Registration Number</td>
  <td><%#Eval("regno") %></td>
  </tr>
  
 
  <tr>
  <td>Student Name</td>
  <td><asp:TextBox ID="sname" runat ="server" Text ='<%#Bind("sname") %>'  /></td>
  </tr>
   <tr>
  <td>Gender</td>
  <td><asp:RadioButtonList ID="gender" runat ="server" RepeatDirection ="Horizontal"  Text='<%#Bind("gender") %>' >
  <asp:ListItem>Male</asp:ListItem>
  <asp:ListItem>Female</asp:ListItem>
  </asp:RadioButtonList></td>
  </tr>
  <tr>
  <td>DateOfBirth</td>
  <td><asp:TextBox ID="dob" runat ="server" Text ='<%#Bind("dob","{0:dd-MMM-yyyy}") %>'   /></td>
  </tr>
  <tr>
  <td>Father/Gardian Name</td>
  <td><asp:TextBox ID="fname" runat ="server" Text ='<%#Bind("fname") %>'  /></td>
  </tr>
  <tr>
  <td>Address</td>
  <td><asp:TextBox ID="address1" runat ="server" Text ='<%#Bind("address1") %>'   /><br /><asp:TextBox ID="address2" runat ="server" Text ='<%#Bind("address2") %>'  /></td>
  </tr>
  <tr>
  <td>City</td>
  <td><asp:TextBox ID="city" runat ="server" Text ='<%#Bind("City") %>' /></td>
  </tr>
  <tr>
  <td>Contact Number</td>
  <td><asp:TextBox ID="contactno" runat ="server" Text ='<%#Bind("contactno") %>'   /></td>
  </tr>
  <tr>
  <td>MailID</td>
  <td><asp:TextBox ID="mailid" runat ="server" Text ='<%#Bind("mailid") %>'   /></td>
  </tr>
   <tr>
  <td>Medicum</td>
  <td><asp:RadioButtonList ID="medium" runat ="server" RepeatDirection ="Horizontal" Text='<%#Bind("Medium") %>' >
  <asp:ListItem>Tamil</asp:ListItem>
  <asp:ListItem>English</asp:ListItem>
  </asp:RadioButtonList></td>
  </tr>
  
  <tr>
  <td>Student Photo</td>
  <td><asp:Image ID="i1" runat ="server" ImageUrl ='<%#Eval("studphoto") %>' Width ="100" Height ="100" /></td>
  </tr>
   <tr>
  <td colspan ="2" style ="text-align :center ; "><asp:LinkButton ID="l1" runat ="server" Text ="Update"  CommandName ="Update" ForeColor ="#006600"></asp:LinkButton>&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="l2" runat ="server" Text ="Cancel"  CommandName ="Cancel" ForeColor ="#006600" ></asp:LinkButton></td>
  <td></td>
  </tr>
  </table> 
  </EditItemTemplate>
                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                <RowStyle HorizontalAlign="Left" BackColor="White" />
               
                
            </asp:FormView></center>
        </td>
    </tr>
    <tr>
        <td style="text-align: center">
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></td>
    </tr>
        </table>
</asp:Content>

