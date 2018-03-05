<%@ Page Language="C#" AutoEventWireup="true" CodeFile="view_approvalrequest.aspx.cs" Inherits="admission_view_approvalrequest" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register src="../usercontrol/internal_messaging.ascx" tagname="internal_messaging" tagprefix="uc1" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
<%@ Register src="../usercontrol/admission.ascx" tagname="admission" tagprefix="uc1" %>
<%@ Register src="../usercontrol/footer.ascx" tagname="footer" tagprefix="uc4" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The Schools.in - Communication</title>
     <link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/layout.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/calendar.css" rel="Stylesheet" type="text/css" />    
    <link rel="stylesheet" type="text/css" href="../css/main.css" />
    <script type="text/javascript" src="../media/js/jquery.min.js"></script>
    
    <script type="text/javascript">
        $(document).ready(function() {

            $("ul#topnav li").hover(function() { //Hover over event on list item
                $(this).css({ 'background': '#88BB00 url(topnav_active.gif) repeat-x' }); //Add background color + image on hovered list item
                $(this).find("span").show(); //Show the subnav
            }, function() { //on hover out...
                $(this).css({ 'background': 'none' }); //Ditch the background
                $(this).find("span").hide(); //Hide the subnav
            });

        });
    </script>
    <link rel="stylesheet" href="../include/jquery-ui-1.8.14.custom.css" type="text/css" />
    <link rel="stylesheet" href="../jquery-ui-timepicker.css?v=0.2.3" type="text/css" />
    <script type="text/javascript" src="../include/jquery-1.5.1.min.js"></script>
    <script type="text/javascript" src="../include/jquery.ui.core.min.js"></script>
    <script type="text/javascript" src="../include/jquery.ui.widget.min.js"></script>
    <script type="text/javascript" src="../include/jquery.ui.tabs.min.js"></script>
    <script type="text/javascript" src="../jquery.ui.timepicker.js?v=0.2.3"></script>    
    <script type="text/javascript">
        $(document).ready(function() {
            $('#txtscheduletime').timepicker();
        });
    </script>
    </head>
  <body>
    <form id="form1" runat="server">
    <div>
        <ajaxtoolkit:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server">
         </ajaxtoolkit:toolkitscriptmanager>
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td style="width: 100%; height: 144px" align="left">
                <uc3:topbanner ID="topbanner1" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="width: 100%" valign="top">
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
                                        <uc1:admission ID="admission1" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 230px; height: 15PX" align="right">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 230px" align="right">
                                        <uc4:school_info ID="school_info1" runat="server" />
                                    </td>
                                </tr>
                            
                            </table>
                        </td>
                        <td style="width: 2%" valign="top">
                        </td>
                        <td style="width: 93%" valign="top" align="left">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr class="app_container_title">
                                    <td style="width: 100%; height: 50px" align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" width="750">
                                            <tr>
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/76.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td style="width: 550px; height: 50px">
                                                    View Registered Student Details</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <%--<tr>
                                    <td style="width: 100%; height: 8px; background-image: url(../media/images/bline.jpg)"></td>
                                </tr>--%>
                                <tr>
                                    <td style="width: 100%; height: 10px"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 20px" valign="top" align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" width="710">
                                            <tr>
                                                <td>
                                                    <table cellpadding="5" cellspacing="0" border="0" width="100%" class="app_container">
                                                       <tr class="view_detail_title_bg">
                                                            <td  style="height: 30px" align="left" colspan="4"><asp:Label ID="Labelname" runat="server" CssClass="title_label">Registered Student Details</asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="Label1" runat="server" CssClass="s_label" 
                                                                    Text="Application Date" Font-Bold="True"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:Label ID="lbldate" runat="server" CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td style="height: 40px" align="left">
                                                                 <asp:Label ID="Label8" runat="server" CssClass="s_label" Text="Application No" 
                                                                     Font-Bold="True"></asp:Label>
                                                            </td>
                                                            <td style="height: 40px" align="left">
                                                                <asp:Label ID="lblno" runat="server" CssClass="s_label"></asp:Label>
                                                            </td>
                                                        </tr>
                                                       <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="Label2" runat="server" CssClass="s_label" Text="Student Name" 
                                                                    Font-Bold="True"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:Label ID="lblstudentname" runat="server" CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td style="height: 40px" align="left">
                                                                 <asp:Label ID="Label14" runat="server" CssClass="s_label" Text="Father Name" 
                                                                     Font-Bold="True"></asp:Label>
                                                            </td>
                                                             <td style="height: 40px" align="left">
                                                                 <asp:Label ID="lblfathername" runat="server" CssClass="s_label"></asp:Label>
                                                            </td>
                                                        </tr>
                                                       <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                    
                                                    <asp:Label ID="Label36" runat="server" CssClass="s_label" 
                                                                    Text="Student Birth/Passport/IC NO"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:Label ID="lblstudentbirth" runat="server" CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td style="height: 40px" align="left">
                                                                <asp:Label ID="Label10" runat="server" CssClass="s_label" Text="Date Of Birth" 
                                                                    Font-Bold="True"></asp:Label>
                                                            </td>
                                                            <td style="height: 40px" align="left">
                                                                <asp:Label ID="lbldateofbirth" runat="server" CssClass="s_label"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="Label5" runat="server" CssClass="s_label" Text="Age" 
                                                                    Font-Bold="True"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:Label ID="lblage" runat="server" CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td style="height: 40px" align="left">
                                                                    <asp:Label ID="Label15" runat="server" CssClass="s_label" Text="Gender" Font-Bold="True"></asp:Label>
                                                                </td>
                                                                 <td style="height: 40px" align="left">
                                                                         <asp:Label ID="lblgender" runat="server" CssClass="s_label"></asp:Label>
                                                                 </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="Label7" runat="server" CssClass="s_label" Text="Applied For" 
                                                                    Font-Bold="True"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:Label ID="lblappliedfor" runat="server" CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td style="height: 40px" align="left">
                                                                <asp:Label ID="Label33" runat="server" CssClass="s_label" 
                                                                    Text="Second Language" Font-Bold="True"></asp:Label>
                                                                </td>
                                                                 <td style="height: 40px" align="left">
                                                                <asp:Label ID="lblseclanguage" runat="server" CssClass="s_label"></asp:Label>
                                                                     </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="Label17" runat="server" CssClass="s_label" 
                                                                    Text="Father/Guardian Qualification" Font-Bold="True"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:Label ID="lblfatherqualification" runat="server" CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td style="height: 40px" align="left">
                                                                <asp:Label ID="Label19" runat="server" CssClass="s_label" 
                                                                    Text="Mother Qualification" Font-Bold="True"></asp:Label>
                                                                </td>
                                                                 <td style="height: 40px" align="left">
                                                                <asp:Label ID="lblmotherqualification" runat="server" CssClass="s_label"></asp:Label>
                                                                     </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="Label21" runat="server" CssClass="s_label" 
                                                                    Text="Father/Guardian Occupation" Font-Bold="True"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:Label ID="lblfatheroccupation" runat="server" CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td style="height: 40px" align="left">
                                                                <asp:Label ID="Label23" runat="server" CssClass="s_label" 
                                                                    Text="Mother Occupation" Font-Bold="True"></asp:Label>
                                                                </td>
                                                                 <td style="height: 40px" align="left">
                                                                <asp:Label ID="lblmotheroccupation" runat="server" CssClass="s_label"></asp:Label>
                                                                     </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="Label25" runat="server" CssClass="s_label" Text="Third Language" 
                                                                    Font-Bold="True"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:Label ID="lblthirdlanguage" runat="server" CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td style="height: 40px" align="left">
                                                                <asp:Label ID="Label27" runat="server" CssClass="s_label" Text="Hostel" 
                                                                    Font-Bold="True"></asp:Label>
                                                                </td>
                                                                 <td style="height: 40px" align="left">
                                                                <asp:Label ID="lblhostel" runat="server" CssClass="s_label"></asp:Label>
                                                                     </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="Label29" runat="server" CssClass="s_label" Text="Transport" 
                                                                    Font-Bold="True"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:Label ID="lbltransport" runat="server" CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td style="height: 40px" align="left">
                                                                <asp:Label ID="Label11" runat="server" CssClass="s_label" Text="Department" 
                                                                    Font-Bold="True"></asp:Label>
                                                                </td>
                                                                 <td style="height: 40px" align="left">
                                                                <asp:Label ID="lbldepartment" runat="server" CssClass="s_label"></asp:Label>
                                                                     </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="Label6" runat="server" CssClass="s_label" Text="Staff Name" 
                                                                    Font-Bold="True"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:Label ID="lblstaffname" runat="server" CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td style="height: 40px" align="left">
                                                                <asp:Label ID="Label13" runat="server" CssClass="s_label" Text="Designation" 
                                                                    Font-Bold="True"></asp:Label>
                                                                </td>
                                                                 <td style="height: 40px" align="left">
                                                                <asp:Label ID="lbldesignation" runat="server" CssClass="s_label"></asp:Label>
                                                                     </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="Label35" runat="server" CssClass="s_label" Text="Email ID" 
                                                                    Font-Bold="True"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:Label ID="lblemail" runat="server" CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td style="height: 40px" align="left">
                                                                <asp:Label ID="Label16" runat="server" CssClass="s_label" Text="Mobile Number" 
                                                                    Font-Bold="True"></asp:Label>
                                                            </td>
                                                                 <td style="height: 40px" align="left">
                                                                <asp:Label ID="lblmobile" runat="server" CssClass="s_label"></asp:Label>
                                                            </td>
                                                          </tr>
                                                          <tr>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="Label9" runat="server" CssClass="s_label" Text="Phone Number" 
                                                                    Font-Bold="True"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:Label ID="lblphone" runat="server" CssClass="s_label"></asp:Label>
                                                            </td>
                                                            <td style="height: 40px" align="left">
                                                                &nbsp;</td>
                                                                 <td style="height: 40px" align="left">
                                                                     &nbsp;</td>
                                                          </tr>
                                                          <tr>
                                                            <td align="center" style="height: 40px" colspan="4">
                                                                <asp:Button ID="btnback" runat="server" Text="Back" CssClass="s_button"  Width="70px" onclick="btnback_Click" />
                                                            </td>
                                                            
                                                          </tr>
                                                       </table>
                                                    </td>                                                
                                                </tr>
                                             <tr>
                                                <td align="center" style="width: 710px; height: 20px">
                                                    &nbsp;</td>
                                            </tr>
                                       </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
             <td style="width: 100%; height: 50px" align="left" valign="top">
                <uc4:footer ID="footer1" runat="server" />
            </td>
        </tr>
    </table>
     <cc1:MsgBox id="msgbox" runat="server"></cc1:MsgBox>
    </div>
    </form>
</body>
</html>
