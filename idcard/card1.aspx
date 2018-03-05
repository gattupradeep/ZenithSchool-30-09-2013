﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="card1.aspx.cs" Inherits="id_card_card1" %>

<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>

<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>

<%@ Register src="../usercontrol/detailsrecord_student.ascx" tagname="detailsrecord_student" tagprefix="uc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit.HTMLEditor" tagprefix="cc2" %>

<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>

<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>

<%@ Register src="../usercontrol/footer.ascx" tagname="app_footer" tagprefix="uc6" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The Schools.in - Admin</title>
    <link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/layout.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/calendar.css" rel="Stylesheet" type="text/css" />    
    <link rel="stylesheet" type="text/css" href="../css/main.css" />
    <script type="text/javascript" src="../media/js/jquery.min.js"></script> 
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <table cellpadding="0" cellspacing="0" border="0" width="100%" >
        <tr>
            <td style="width: 100%;" align="left">
                <uc3:topbanner ID="topbanner1" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="width: 100%;" valign="top">
                <uc2:topmenu ID="topmenu1" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="width: 100%; height: 400px" align="left" valign="top">
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td style="width: 5%" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" width="230">
                                <tr>
                                    <td style="width: 230px" align="right">
                                       <%-- <uc2:mainmasters ID="mainmasters1" runat="server" />--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 230px; height: 15px" align="right">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 230px" align="right">
                                        <uc4:school_info ID="school_info1" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 1%" valign="top">
                        </td>
                        <td style="width: 93%" valign="top" align="left">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%" >
                                <tr class="app_container_title">
                                    <td style="width: 100%; " align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" >
                                            <tr>
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/86.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left">Student ID Card</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 8px; background-image: url(../media/images/bline.jpg)"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 10px"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 50px" valign="top" align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" width="700px" class="app_container">
                                           <tr>
                                                <td style="width: 150px; height: 40px" align="left">
                                                    &nbsp;
                                                    <asp:Label ID="Label20" runat="server" CssClass="s_label" Text="Patron Type"></asp:Label>
                                                    &nbsp;</td>
                                                <td style="width: 150px; height: 40px" align="left">
                                                    <asp:DropDownList ID="ddlpatrontype" runat="server" Width="150px"  AutoPostBack="true" CssClass="s_dropdown" onselectedindexchanged="ddlpatrontype_SelectedIndexChanged">
                                                         <asp:ListItem Value="-Select-">-Select-</asp:ListItem>
                                                          <asp:ListItem Value="Student">Student</asp:ListItem>
                                                         <asp:ListItem Value="Staffs">Staffs</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 150px; height: 40px" align="left">&nbsp;&nbsp;</td>
                                                <td style="width: 150px; height: 40px" align="left"></td>
                                            </tr>
                                            <tr id="trstudent" runat="server">
                                                <td style="width: 150px; height: 40px" align="left">
                                                    &nbsp;
                                                    <asp:Label ID="Label3" runat="server" CssClass="s_label" Text="Standard"></asp:Label>
                                                    &nbsp;</td>
                                                <td style="width: 150px; height: 40px" align="left">
                                                     <asp:DropDownList ID="ddlstandard" runat="server" Width="150px"  AutoPostBack="true"
                                                         CssClass="s_dropdown" onselectedindexchanged="ddlstandard_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 150px; height: 40px" align="left">
                                                    &nbsp;&nbsp;<asp:Label ID="Label2" runat="server" CssClass="s_label" Text="Student Name"></asp:Label></td>
                                                <td style="width: 100px; height: 40px" align="left">
                                                   <asp:DropDownList ID="ddlstudent" runat="server" Width="150px" AutoPostBack="true" CssClass="s_dropdown" onselectedindexchanged="ddlstudent_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr id="trstaff" runat="server">
                                                <td style="width: 150px; height: 40px" align="left">
                                                    &nbsp;&nbsp;<asp:Label ID="Label21" runat="server" CssClass="s_label" Text="Staff Type"></asp:Label></td>
                                                <td style="width: 100px; height: 40px" align="left">
                                                     <asp:DropDownList ID="ddlstaff" runat="server" Width="150px" CssClass="s_dropdown" AutoPostBack="true" onselectedindexchanged="ddlstaff_SelectedIndexChanged">
                                                         <asp:ListItem Value="-Select-">-Select-</asp:ListItem>
                                                         <asp:ListItem Value="Teaching Staffs">Teaching Staffs</asp:ListItem>
                                                         <asp:ListItem Value="Non Teachinf Staff">Non Teachinf Staff</asp:ListItem>
                                                     </asp:DropDownList>
                                                </td>
                                                <td style="width: 150px; height: 40px" align="left">
                                                    &nbsp;&nbsp;<asp:Label ID="Label22" runat="server" CssClass="s_label" Text="Staff Name"></asp:Label></td>
                                                <td style="width: 100px; height: 40px" align="left">
                                                    <asp:DropDownList ID="ddlstaffname" runat="server" Width="150px" AutoPostBack="true" CssClass="s_dropdown" onselectedindexchanged="ddlstaffname_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 150px; height: 40px" align="left">
                                                    &nbsp;
                                                    <asp:Label ID="Label1" runat="server" CssClass="s_label" Text="ID Card Design"></asp:Label>
                                                    &nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:DropDownList ID="ddlyear" runat="server" Width="150px" CssClass="s_dropdown" AutoPostBack="true" onselectedindexchanged="ddlyear_SelectedIndexChanged">
                                                         <asp:ListItem Value="0">-Select-</asp:ListItem>
                                                         <asp:ListItem Value="1">Design1</asp:ListItem>
                                                         <asp:ListItem Value="2">Design2</asp:ListItem>
                                                         <asp:ListItem Value="3">Design3</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 150px; height: 40px" align="right">
                                                    &nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                              
                                 <tr id="trimage1" runat="server">
                                    <td colspan="4" style="width: 100%" valign="top" align="left">
                                     <table cellpadding="2" cellspacing="2" border="0" 
                                            style="width: 72%; margin-left: 0px">
                                            <tr>
                                      <td style="width: 100%" align="center" >
                                      
                                          <asp:DataGrid ID="GridIDCard" runat="server" AutoGenerateColumns="false" 
                                           ShowHeader="false" ShowFooter="false" Width="100%" 
                                              onitemdatabound="GridIDCard_ItemDataBound">
                                                <ItemStyle CssClass="s_datagrid_item"/>
                                                  <Columns>
                                                    <asp:BoundColumn DataField="intid" Visible="false"></asp:BoundColumn>
                                                   
                                                      <asp:TemplateColumn ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                   
                                                                    <tr>
                                                                        <td>
                                                                            <asp:DataList ID="dlIdCard" runat="server" RepeatColumns="2" CellSpacing="2" CellPadding="2" 
                                                                                AlternatingItemStyle-HorizontalAlign="Left" 
                                                                                onitemdatabound="dlIdCard_ItemDataBound"> 
                                                                              
                                                                                <AlternatingItemStyle HorizontalAlign="Left" />
                                                                                <ItemStyle CssClass="s_datagrid_item" />
                                                                                
                                                                                <ItemTemplate>
                                                                                   <table cellpadding="0" cellspacing="0" border="1px" 
                                                                                        style="width: 97%; height: 292px;">
                                                                                   <tr>
                                                                                        <td align="left">
                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img ID="text1" runat="server" alt="photo" height="100" 
                                                                                                src="../media/images/reportcard.png" width="100" /><br />
                                                                                            <br />
                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                                                                             <asp:Label ID="lblname" runat="server" Width="260px" 
                                                                                                 Text='<%# DataBinder.Eval(Container.DataItem, "name") %>' CssClass="s_label" 
                                                                                                 Height="20px"></asp:Label> 
                                                                                             <br />
                                                                                            &nbsp;
                                                                                            <asp:Label ID="lblstandard" runat="server"  CssClass="s_label" 
                                                                                                 Text='<%# DataBinder.Eval(Container.DataItem, "standard") %>' 
                                                                                                Width="130px" Height="18px"></asp:Label>
                                                                                                 
                                                                                            <br />
                                                                                             <asp:Label ID="lblidcardno" runat="server" CssClass="s_label" Text="I.D.No:"></asp:Label> 
                                                                                             <asp:Label ID="Label4" runat="server"  CssClass="s_label" Text='<%# DataBinder.Eval(Container.DataItem, "studentbirth") %>' Width="130px" Height="18px"></asp:Label>
                                                                                              <br />
                                                                                            <asp:Label ID="lblvalidity" runat="server" CssClass="s_label" Text="Validity:"></asp:Label>
                                                                                            <asp:Label ID="lblstartdate" runat="server" CssClass="s_label" 
                                                                                                Text='<%# DataBinder.Eval(Container.DataItem,"year") %>' Width="75px" 
                                                                                                Height="23px"></asp:Label>
                                                                                                &nbsp;&nbsp;
                                                                                                <asp:Label ID="lblto" runat="server" CssClass="s_label" Text="to:"></asp:Label>
                                                                                            &nbsp;
                                                                                            <asp:Label ID="lblenddate" runat="server" CssClass="s_label" 
                                                                                                Text='<%# DataBinder.Eval(Container.DataItem,"year1") %>' Width="75px" 
                                                                                                Height="21px"></asp:Label>
                                                                                            &nbsp;&nbsp; 
                                                                                        </td>
                                                                                                
                                                                                        <td align="center">
                                                                                              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                              <br />
                                                                                              <br />
                                                                                              &nbsp;<asp:Label ID="Label5" runat="server" CssClass="s_label" Text="STUDENT"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                              <br />
                                                                                              <img  src = "../images/student/<%#DataBinder.Eval(Container.DataItem,"intid") %>.jpg" 
                                                                                                  alt="photo" width="100" height="100" />
                                                                                               <asp:Label ID="lbladmin" runat="server" CssClass="s_label" Height="32px" 
                                                                                                  Text='<%# DataBinder.Eval(Container.DataItem, "intadmitno") %>' 
                                                                                                  Width="146px"></asp:Label>
                                                                                              
                                                                                             
                                                                                              <asp:Label ID="lblid" runat="server" CssClass="s_label" Visible="False"></asp:Label>
                                                                                              <asp:Label ID="lblline" runat="server" Width="150px" CssClass="s_label" 
                                                                                                Text="____________________"></asp:Label>
                                                                                            <asp:Label ID="lblreg" runat="server" Width="150px" CssClass="s_label" 
                                                                                                Text="Register"></asp:Label>
                                                                                                                                                                                                                                                             
                                                                                        </td>
                                                                                   </tr>
                                                                                     <%--<tr>
                                                                                        <td></td>
                                                                                        <td style="width:30px; height:50px" align="left">
                                                                                            <asp:Label ID="Label8" runat="server" Width="150px" CssClass="s_label" Text="Principal Sign"></asp:Label>
                                                                                        </td>
                                                                                    </tr>--%>
                                                                                      <tr>
                                                                                        <td align="left">
                                                                                            <asp:FileUpload ID="FileUpload1" runat="server" />
                                                                                            
                                                                                        </td>
                                                                                        <td style="width:200px; height:40px" align="left">
                                                                                            <asp:Button ID="btnupload" runat="server" Text="Upload" CssClass="s_button" 
                                                                                                onclick="btnupload_Click" />
                                                                                                                                                                            
                                                                                        </td>
                                                                                    
                                                                                     </tr>
                                                                                   </table>
                                                                                   <tr align="right">
                                                                                        <td>
                                                                                           <asp:Button ID="Button1" runat="server" cssClass="s_button" Text="Print" 
                                                                                          onclick="Button1_Click" /> 
                                                                                        </td>
                                                                                   </tr>
                                                                                    
                                                                                </ItemTemplate>
                                                                               
                                                                                
                                                                                     
                                                                               
                                                      
                                                                              </asp:DataList>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>

                                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                           
                                                        </asp:TemplateColumn>
                                                       <%--   <asp:ButtonColumn HeaderText="Printer" Text="&lt;img src=&quot;../media/images/Printer.png&quot; alt=&quot;&quot; border=&quot;0&quot;/&gt;" CommandName="edit"></asp:ButtonColumn>--%>
                                                      
                                                  </Columns>
                                                 
                                                <PagerStyle HorizontalAlign="Left" Mode="NumericPages" />  
                                           </asp:DataGrid>
                                            
                                            
                                           </td>
                                           </tr>
                                           </table>
                                           </td>
                                           </tr>
                                                          
                               
                           </table>
                       </td>
                    </tr>    
                    <tr>
                         <td class="break"></td>
                    </tr>
                    
                                       
                </table>
            </td>
        </tr>
               
           
       <tr>
        <td style="width: 100%" align="left" valign="top" class="footer">
            <uc6:app_footer ID="app_footer" runat="server" />
        </td>
      </tr>
     
    </table>
    <cc1:MsgBox id="msgbox" runat="server"></cc1:MsgBox>
    </div>
    </form>
</body>
</html>

  