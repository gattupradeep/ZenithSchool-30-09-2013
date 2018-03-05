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
    <script language="javascript" type="text/javascript">
        function doPrint() {
            bdhtml = window.document.body.innerHTML;
            sprnstr = "<!--startprint-->";
            eprnstr = "<!--endprint-->";
            prnhtml = bdhtml.substr(bdhtml.indexOf(sprnstr) + 17);
            prnhtml = prnhtml.substring(0, prnhtml.indexOf(eprnstr));
            window.document.body.innerHTML = prnhtml;
            window.print();
        }
    </script>
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
                                <tr>
                                    <td style="width: 100%; height: 10px"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 50px" valign="top" align="left">
                                        <table width="300px" border="1">
                                          <tr id="trimage1" runat="server"  >
                                             <td style="width: 100%; height: 100px; padding-left: 50px" valign="top" align="left">
                                                <table width="350px" >
                                                    
                                                   <tr class="app_container" >
                                                       <td style="width:70px; height:70px" align="center" colspan="2">
                                                           <img id="text1" runat="server" src= "../media/images/reportcard.png" alt="photo" width="100" height="100"  />
                                                       </td>
                                                  </tr>
                                                <tr>
                                                    <td colspan="2" style=" height:20px"></td>
                                                </tr>
                                                
                                                <tr>
                                                 
                                                     <td style="width:250px; height:70px" align="left">
                                                         <asp:Label ID="lblname" runat="server" CssClass="s_label" Text="lblname"></asp:Label><br />
                                                         <asp:Label ID="lblidnocard" runat="server" CssClass="s_label" Text="I.D.No:"></asp:Label>&nbsp;&nbsp;
                                                         <asp:Label ID="lblidno" runat="server" CssClass="s_label" Text="lblidno"></asp:Label><br />
                                                         <asp:Label ID="lblstandard" runat="server" CssClass="s_label" Text="lblstandard"></asp:Label><br />
                                                         <asp:Label ID="Label4" runat="server" CssClass="s_label" Text="Validity:"></asp:Label>
                                                         &nbsp;&nbsp;
                                                         <asp:Label ID="lblvalidity" runat="server" CssClass="s_label" ></asp:Label>
                                                     </td>
                                                     <td style="width:50px; height:70px" align="center">
                                                          <asp:Label ID="Label5" runat="server" CssClass="s_label" Text="STUDENT"></asp:Label>
                                                          <img src = "../images/student/<%Response.Write(lblid.Text); %>.jpg" alt="photo" width="100" height="100" />
                                                          <asp:Label ID="lblid" runat="server" CssClass="s_label" Visible="False"></asp:Label>
                                                           <asp:Label ID="lbladmin" runat="server" CssClass="s_label" Text="lbladmin"></asp:Label><br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="width: 435px; height: 40px" >
                                                        <asp:FileUpload ID="FileUpload1" runat="server" />
                                                    </td>
                                                    <td align="left" style="width: 200px; height: 40px">
                                                        <asp:Button ID="btnupload" runat="server" Text="Upload" CssClass="s_button" onclick="btnupload_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td style="width:30px; height:50px" align="left">
                                                        <asp:Label ID="Label6" runat="server" Width="150px" CssClass="s_label" Text="____________________"></asp:Label>
                                                        <asp:Label ID="Label7" runat="server" Width="150px" CssClass="s_label" Text="Registrar"></asp:Label>
                                                    </td>
                                                </tr>
                                              
                                            </table>
                                             </td>
                                          </tr>
                                          <tr id="trbackside" runat="server">
                                            <td style="width: 100%; height: 100px; padding-left: 50px" valign="top" align="left">
                                                <table width="350px" >
                                                    <tr class="app_container" >
                                                         <td style="width:350px; height:40px" align="left">
                                                            <asp:Label ID="Label8" runat="server" CssClass="s_label" Text=" If found, please return to:"></asp:Label><br />
                                                            <asp:Label ID="Label9" runat="server" CssClass="s_label" Text=" Zenith International School"></asp:Label><br />
                                                            <asp:Label ID="Label10" runat="server" CssClass="s_label" Text=" 1388, Jalan RK 3/1, Rasah Kemayan,70300 Seremban"></asp:Label><br />
                                                            <asp:Label ID="Label11" runat="server" CssClass="s_label" Text=" Phone : 06-6011388 | Email:info@zenith.edu.my"></asp:Label>
                                                         </td>
                                                    </tr>
                                                   <tr>
                                                       <td style="width:350px; height:40px" align="left">
                                                            <asp:Label ID="Label12" runat="server" CssClass="s_label" Text="________________________________________________________"></asp:Label>
                                                       </td>
                                                   </tr>
                                                   <tr>
                                                       <td style="width:380px; height:40px" align="left">
                                                            <asp:Label ID="Label13" runat="server" CssClass="s_label" Text="1. The holder of this card is a registered student of "></asp:Label>
                                                            <asp:Label ID="Label14" runat="server" CssClass="s_label" Text="    Zenith International School."></asp:Label>
                                                       </td>
                                                   </tr>
                                                   <tr>
                                                       <td style="width:380px; height:40px" align="left">
                                                            <asp:Label ID="Label15" runat="server" CssClass="s_label" Text="2. By this registration, the holder agrees to abide by the Rules and "></asp:Label>
                                                            <asp:Label ID="Label16" runat="server" CssClass="s_label" Text="    Regulations of the School."></asp:Label>
                                                       </td>
                                                   </tr>     
                                                   <tr>
                                                       <td style="width:380px; height:40px" align="left">
                                                            <asp:Label ID="Label17" runat="server" CssClass="s_label" Text="3. This card is for individual use only and is NOT transferable."></asp:Label>
                                                       </td>
                                                   </tr>
                                                   <tr>
                                                       <td style="width:380px; height:40px" align="left">      
                                                            <asp:Label ID="Label18" runat="server" CssClass="s_label" Text="4. Cards which are damaged or defaced will be deemed invalid,"></asp:Label>
                                                            <asp:Label ID="Label19" runat="server" CssClass="s_label" Text="    and a replacement will have to be sought from the school."></asp:Label>
                                                       </td>
                                                   </tr>
                                                </table>
                                            </td>   
                                         </tr>
                                        <tr id="trgenerate" runat="server">
                                           <td style="width: 70px; height: 40px" colspan="2" align="center">
                                            <asp:Button runat="Server" id="SubmitButton" Text="Generate Image" CssClass="s_button" onclick="SubmitButton_Click" />
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
