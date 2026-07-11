<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewStudentDetails.aspx.cs" Inherits="ViewStudentDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table  border="2" align="center"   width ="60%" cellpadding ="5px">
        <tr>
            <th>
                <br /><h1>
                    View 
                    Student Details</h1><br />
            </th>
        </tr>
        <tr>
            <td>
            
               <center ><asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" 
                       Width="384px" BackColor="#CCCCCC" BorderColor="#999999" 
                       BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" 
                       ForeColor="Black" >
                   <EditRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
               <Fields >
                <asp:BoundField DataField ="regno" HeaderText ="RegistrationNo" />
                   <asp:BoundField DataField ="sname" HeaderText ="StudentName" />
                    <asp:BoundField DataField ="gender" HeaderText ="Gender" />
                     <asp:BoundField DataField ="dob" HeaderText ="DateOfBirth" HtmlEncode ="false" DataFormatString ="{0:dd-MMM-yyyy}" />
        
                <asp:BoundField DataField ="byear" HeaderText ="BatchYear" />
             
                 
                      <asp:BoundField DataField ="fname" HeaderText ="FatherName" />
                      <asp:TemplateField HeaderText ="Address">
                      <ItemTemplate >
                      <%#Eval("address1") %>
                      <br />
                      <%#Eval("address2") %>
                      <br />
                      <%#Eval("city") %>
                      </ItemTemplate>
                      </asp:TemplateField>
                      
                      <asp:BoundField DataField ="contactno" HeaderText ="ContactNo" />
                       <asp:BoundField DataField ="mailid" HeaderText ="MailID" />
                        <asp:BoundField DataField ="medium" HeaderText ="Medium" />

                           <asp:BoundField DataField ="year" HeaderText ="CurrentYear" />
                            <asp:BoundField DataField ="semester" HeaderText ="CurrentSemester" />
                            <asp:ImageField DataImageUrlField ="studphoto" DataImageUrlFormatString ="UploadPhoto\{0}" HeaderText ="Photo">
                            <ControlStyle Width ="100" Height ="100" />
                            </asp:ImageField>
                      
               </Fields>
                   <FooterStyle BackColor="#CCCCCC" />
                   <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                   <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                   <RowStyle HorizontalAlign="Left" BackColor="White" />
                </asp:DetailsView>
                </center> 
              </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
              </td>
        </tr>
        </table> 
</asp:Content>

