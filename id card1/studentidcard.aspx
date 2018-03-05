<%@ Page Language="C#" AutoEventWireup="true" CodeFile="studentidcard.aspx.cs" Inherits="id_card_studentidcard" %>
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
                                                    <asp:Label ID="Label1" runat="server" CssClass="s_label" Text="ID Card Model"></asp:Label>
                                                </td>
                                                <td style="width: 150px; height: 40px" align="left">
                                                    <asp:DropDownList ID="ddlyear" runat="server" Width="150px" CssClass="s_dropdown" AutoPostBack="true" onselectedindexchanged="ddlyear_SelectedIndexChanged">
                                                         <asp:ListItem Value="0">-Select-</asp:ListItem>
                                                         <asp:ListItem Value="1">Model1</asp:ListItem>
                                                         <asp:ListItem Value="2">Model2</asp:ListItem>
                                                         <asp:ListItem Value="3">Model3</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 150px; height: 40px" align="left"></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 150px; height: 40px" align="left">
                                                    <asp:Label ID="Label3" runat="server" CssClass="s_label" Text="Standard"></asp:Label>
                                                </td>
                                                <td style="width: 150px; height: 40px" align="left">
                                                     <asp:DropDownList ID="ddlstandard" runat="server" Width="150px"  AutoPostBack="true"
                                                         CssClass="s_dropdown" onselectedindexchanged="ddlstandard_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 100px; height: 40px" align="left">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 150px; height: 40px" align="left">
                                                    <asp:Label ID="Label2" runat="server" CssClass="s_label" Text="Student Name"></asp:Label>
                                                </td>
                                                <td style="width: 100px; height: 40px" align="left">
                                                   <asp:DropDownList ID="ddlstudent" runat="server" Width="150px" AutoPostBack="true"
                                                        CssClass="s_dropdown" onselectedindexchanged="ddlstudent_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 100px; height: 40px" align="left">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 150px; height: 40px" align="right"></td>
                                                <td style="width: 200px; height: 40px" align="left"></td>
                                                <td style="width: 200px; height: 40px" align="left"></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 10px"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 50px" valign="top" align="left">
                                        <table width="300px" border="1">
                                          <tr id="trimage1" runat="server"  >
                                             <td style="width: 100%; height: 100px; padding-left: 50px" valign="top" align="left">
                                            <table style="width: 353px" >
                                                <tr class="app_container" >
                                                    <td style="width:70px; height:70px" align="center" colspan="2">
                                                      <img src = "../media/images/reportcard.png" alt="photo" id="zenith" width="100" height="100" />
                                                     
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style=" height:20px"></td>
                                                </tr>
                                                <tr>
                                                 
                                                     <td style="width:250px; height:70px" align="left">
                                                         <asp:Label ID="Label7" runat="server" CssClass="s_label" Text="Student Name:"></asp:Label>
                                                         &nbsp;&nbsp;
                                                         <asp:Label ID="lblname" runat="server" CssClass="s_label" Text="lblname"></asp:Label><br />
                                                         
                                                          <asp:Label ID="Label9" runat="server" CssClass="s_label" Text="Standard:"></asp:Label>
                                                         &nbsp;&nbsp;
                                                         <asp:Label ID="lblstandard" runat="server" CssClass="s_label" Text="lblstandard"></asp:Label><br />
                                                         
                                                          <asp:Label ID="Label10" runat="server" CssClass="s_label" Text="Admission No:"></asp:Label>
                                                         &nbsp;&nbsp;
                                                         <asp:Label ID="lbladmin" runat="server" CssClass="s_label" Text="lbladmin"></asp:Label><br />
                                                         
                                                           <asp:Label ID="Label11" runat="server" CssClass="s_label" Text="ID Card No:"></asp:Label>
                                                         &nbsp;&nbsp;
                                                         <asp:Label ID="lblno" runat="server" CssClass="s_label" Text="lblno"></asp:Label><br />
                                                         <asp:Label ID="Label13" runat="server" CssClass="s_label" Text="Validity:"></asp:Label>
                                                         &nbsp;&nbsp;
                                                         <asp:Label ID="lblvalidity" runat="server" CssClass="s_label" ></asp:Label>
                                                     </td>
                                                     <td style="width:50px; height:70px" align="center">
                                                          <img src = "../images/student/<%Response.Write(lblid.Text); %>.jpg" alt="photo" width="100" height="100" />
                                                          <asp:Label ID="lblid" runat="server" CssClass="s_label" Visible="False"></asp:Label>
                                                           
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td style="width:30px; height:50px" align="left">
                                                        <asp:Label ID="Label8" runat="server" Width="150px" CssClass="s_label" Text="Principal Sign"></asp:Label>
                                                    </td>
                                                </tr>
                                              
                                                <tr>
                                                    <td>
                                                        <asp:FileUpload ID="FileUpload1" runat="server" />
                                                    </td>
                                                    <td style="width:30px; height:50px" align="left">
                                                        <asp:Button ID="btnUpload" runat="server" onclick="btnUpload_Click" 
                                                            Text="Upload" />
                                                    </td>
                                                </tr>
                                              
                                            </table>
                                          </td>
                                          </tr>
                                        </table>
                                    </td>
                                </tr>
                                 <%--<tr id="trtext" runat="server">
                                     <td style="width:50px; height:70px" align="center" colspan="2">
                                        <asp:TextBox runat="server" id="Text" /> 
                                    </td>
                                 </tr>--%>
                                 <tr id="trback" runat="server">
                                    <td style="width:50px; height:70px" align="center" colspan="2">
                                        <asp:dropdownlist runat="server" id="BackgroundColor">
                                            
                                            <asp:ListItem Value="red">Red</asp:ListItem> 
                                            <asp:ListItem Value="green">Green</asp:ListItem> 
                                            <asp:ListItem Value="navy">Navy</asp:ListItem> 
                                            <asp:ListItem Value="orange">Orange</asp:ListItem> 
                                            <asp:ListItem Value="gray">Gray</asp:ListItem>
                                        </asp:dropdownlist> 
                                    </td>
                                 </tr>
                                 <tr id="trfont" runat="server">
                                    <td style="width:50px; height:70px" align="center" colspan="2">
                                        <asp:dropdownlist runat="server" id="Font">
                                            <asp:ListItem Value="Arial">Arial</asp:ListItem>  
                                            <asp:ListItem Value="Verdana">Verdana</asp:ListItem>  
                                            <asp:ListItem Value="Courier">Courier</asp:ListItem>  
                                            <asp:ListItem Value="Times New Roman">Times New Roman</asp:ListItem> 
                                        </asp:dropdownlist> 
                                    </td>
                                </tr>
                                <tr id="trgenerate" runat="server">
                                  <td style="width: 70px; height: 40px" colspan="2" align="center">
                                   <asp:Button runat="Server" id="SubmitButton" Text="Generate Image" 
                                        onclick="SubmitButton_Click" />
                                        
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
