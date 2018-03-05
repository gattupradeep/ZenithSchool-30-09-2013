<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewWithdrawalList.aspx.cs" Inherits="student_ViewWithdrawalList" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register src="../usercontrol/activities_homework.ascx" tagname="activities_homework" tagprefix="uc1" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
<%@ Register src="../usercontrol/admin_tc.ascx" tagname="admin_tc" tagprefix="uc5" %>
<%@ Register Src="../usercontrol/footer.ascx" TagName="app_footer" TagPrefix="uc6" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The Schools.in - Admin</title>
    <link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/layout.css" media="screen" rel="stylesheet" type="text/css" />
        <link href="../media/css/calendar.css" rel="Stylesheet" type="text/css" />   
    <script type="text/javascript" src="../media/js/jquery.min.js"></script>
    <script type="text/javascript">
        function popup(url) {
            var width = 500;
            var height = 300;
            var left = (screen.width - width) / 2;
            var top = (screen.height - height) / 2;
            var params = 'width=' + width + ', height=' + height;
            params += ', top=' + top + ', left=' + left;
            params += ', directories=no';
            params += ', location=no';
            params += ', menubar=no';
            params += ', resizable=no';
            params += ', scrollbars=no';
            params += ', status=no';
            params += ', toolbar=no';
            newwin = window.open(url, 'windowname5', params);
            if (window.focus) { newwin.focus() }
            return false;
        }
</script>
<script type="text/javascript">

    var showflag = 1;
    // Function to hide and unhide second datagrid.
    function makeVisible(ch, show, img) {
        if (document.getElementById(ch).innerHTML != "") {
            if (show == 1) {
                if (document.getElementById(ch).style.visibility == "visible") {
                    document.getElementById(ch).style.visibility = "hidden";
                    img.src = "../images/add_new.png";
                    document.getElementById(ch).style.display = 'none';
                }
                else {
                    document.getElementById(ch).style.visibility = "visible";
                    document.getElementById(ch).style.display = '';
                    img.src = "../images/details_close.png";
                }
                showflag = 0;
            }
            else {
                if (document.getElementById(ch).style.visibility == "visible") {
                    document.getElementById(ch).style.visibility = "hidden";
                    img.src = "../images/add_new.png";
                    document.getElementById(ch).style.display = 'none';
                }
                else {
                    document.getElementById(ch).style.visibility = "visible";
                    document.getElementById(ch).style.display = '';
                    img.src = "../images/details_close.png";
                }
                showflag = 1;
            }
        }
    }
		</script>
 </head>
<body>
    <form id="form1" runat="server">
    <div>
    <ajaxtoolkit:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server"></ajaxtoolkit:toolkitscriptmanager>
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
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
                                        <uc5:admin_tc ID="admin_tc1" runat="server" />
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
                            <%-- <asp:UpdateProgress ID="Updateprocess" runat="server" AssociatedUpdatePanelID="updatepanal" DisplayAfter="1" >
                                            <ProgressTemplate>
                                                <div id="progressBackgroundFilter"></div>
                                                    <div id="processMessage">
                                                        <img alt="Loading" src="../media/images/Processing.gif" />
                                                    </div>
                                            </ProgressTemplate>
                            </asp:UpdateProgress>--%>
                            <asp:UpdatePanel ID="updatepanal" runat="server" >
                                <ContentTemplate>
                                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr class="app_container_title">
                                    <td style="width: 100%; " align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" >
                                            <tr>
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/279.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left">View Withdrawal details</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 10px" valign="top" align="left">
                                     <table cellpadding="7" cellspacing="0" border="0" class="app_container">
                                            <tr class="view_detail_title_bg">
                                                <td colspan="4" align="left" class="title_label">View Withdrawal details</td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="height: 40px" colspan="4">
                                                    <img src="../images/add_new.png" id="imgOpen" onclick="makeVisible('submenu',showflag,this);" alt="" />
                                                    <asp:Label ID="lblun" runat="server" CssClass="s_label" Text="Unpaid dues details"></asp:Label>
                                                    <div style="display:none;" id="submenu">
                                                        <asp:Panel ID="pan" runat="server" ScrollBars="Vertical" BorderWidth="1px">
                                                            <table>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="Label1" runat="server" Text="Fee" CssClass="s_label"></asp:Label>                                                                    
                                                                    </td>
                                                                </tr>                                                            
                                                            </table>
                                                            <table>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="Label2" runat="server" Text="Library" CssClass="s_label"></asp:Label>                                                                    
                                                                    </td>
                                                                </tr>                                                            
                                                            </table>
                                                            <table>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="Label3" runat="server" Text="Transport" CssClass="s_label"></asp:Label>                                                                    
                                                                    </td>
                                                                </tr>                                                            
                                                            </table>
                                                            <table>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="Label4" runat="server" Text="Hostel" CssClass="s_label"></asp:Label>                                                                    
                                                                    </td>
                                                                </tr>                                                            
                                                            </table>
                                                            </asp:Panel>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 175px; height: 40px">
                                                    <asp:Label ID="Label12" runat="server" CssClass="s_label" Text="Admission No :" Font-Bold="true"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="lbladmission" runat="server" CssClass="s_label"></asp:Label>
                                                </td>
                                                <td align="left" style="height: 40px" colspan="2">
                                                    <asp:Label ID="Label13" runat="server" CssClass="s_label" Text="Admission Date :" Font-Bold="true"></asp:Label>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbladmissiondate" runat="server" CssClass="s_label"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 175px; height: 40px">
                                                    <asp:Label ID="Label14" runat="server" CssClass="s_label" Text="Student Name :" Font-Bold="true"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="lblstudentname" runat="server" CssClass="s_label"></asp:Label>
                                                </td>
                                                <td  align="left" style="height: 40px" colspan="2">
                                                    <asp:Label ID="Label23" runat="server" CssClass="s_label" Text="Father/Guardian Name :" Font-Bold="true"></asp:Label>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblfathername" runat="server" CssClass="s_label"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 175px; height: 40px">
                                                    <asp:Label ID="Label39" runat="server" CssClass="s_label" Text="Standard :" Font-Bold="true"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="lblstandard" runat="server" CssClass="s_label"></asp:Label>
                                                </td>
                                                <td  align="left" style="height: 40px" colspan="2">
                                                    <asp:Label ID="Label40" runat="server" CssClass="s_label" Text="Section :" Font-Bold="true"></asp:Label>
                                                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblsection" runat="server" CssClass="s_label"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 175px; height: 40px">
                                                    <asp:Label ID="Label15" runat="server" CssClass="s_label" Text="Date of birth :" Font-Bold="true"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="lbldateofbirth" runat="server" CssClass="s_label"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 275px; height: 40px">
                                                    <asp:Label ID="Label22" runat="server" CssClass="s_label" Text="Gender :" Font-Bold="true"></asp:Label>
                                                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblgender" 
                                                        runat="server" CssClass="s_label"></asp:Label></td>
                                                <td align="left" style="width: 50px; height: 40px">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 175px; height: 40px">
                                                    <asp:Label ID="Label17" runat="server" CssClass="s_label" Font-Bold="true" 
                                                        Text="Nationality :"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="lblnationality" runat="server" CssClass="s_label"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 275px; height: 40px">
                                                    <asp:Label ID="Label16" runat="server" CssClass="s_label" Font-Bold="true" 
                                                        Text="Religion :"></asp:Label>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="lblreligion" runat="server" CssClass="s_label"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 50px; height: 40px">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 175px; height: 40px">
                                                    <asp:Label ID="Label18" runat="server" CssClass="s_label" Font-Bold="true" 
                                                        Text="Second Language :"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="lblsecondlang" runat="server" CssClass="s_label"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 275px; height: 40px">
                                                    <asp:Label ID="Label19" runat="server" CssClass="s_label" Font-Bold="true" 
                                                        Text="Third Language :"></asp:Label>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblthirdlang" runat="server" CssClass="s_label"></asp:Label></td>
                                                <td align="left" style="width: 50px; height: 40px">&nbsp;</td>
                                            </tr>
                                           <%-- <tr>
                                                <td align="left" style="width: 175px; height: 40px">
                                                    &nbsp;</td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    &nbsp;</td>
                                                <td align="left" style="width: 275px; height: 40px">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                                <td align="left" style="width: 50px; height: 40px">&nbsp;</td>
                                            </tr>--%>
                                            <tr>
                                                <td align="left" style="width: 175px; height: 40px">
                                                    <asp:Label ID="Label42" runat="server" CssClass="s_label" 
                                                        Text="Previous Standard :"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="lblpreviousclass" runat="server" CssClass="s_label"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 275px; height: 40px">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                                <td align="left" style="width: 50px; height: 40px">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="height: 40px" colspan="3">
                                                    <asp:Label ID="Label26" runat="server" CssClass="s_label" Text="Personal Identification Marks :" Font-Bold="true"></asp:Label>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblidentificationmark" runat="server" CssClass="s_label"></asp:Label></td>
                                                <td align="left" style="width: 50px; height: 40px">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="3" style="height:40px">
                                                    <asp:Label ID="Label27" runat="server" CssClass="s_label" Text="Class &amp; year in which student is first admitted :" Font-Bold="true"></asp:Label>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblfirstclass" runat="server" CssClass="s_label"></asp:Label></td>
                                                <td align="left"></td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="height: 40px" colspan="3">
                                                    <asp:Label ID="Label28" runat="server" CssClass="s_label" Text="Original documents submitted at the  time of admission :" Font-Bold="true"></asp:Label>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbldocuments" runat="server" CssClass="s_label"></asp:Label></td>
                                                <td align="left" style="width: 50px; height: 40px">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="height: 40px" colspan="3">
                                                    <asp:Label ID="Label29" runat="server" CssClass="s_label" Text="Whether student  qualified for promotion :" Font-Bold="true"></asp:Label>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblpromotion" 
                                                        runat="server" CssClass="s_label"></asp:Label></td>
                                                <td align="left" style="width: 50px; height: 40px">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="height: 40px" colspan="2">
                                                    <asp:Label ID="Label30" runat="server" CssClass="s_label" Text="Scholarship if any :" Font-Bold="true"></asp:Label>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblscholarship" 
                                                        runat="server" CssClass="s_label"></asp:Label></td>
                                                <td align="left" colspan="2">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="height: 40px" colspan="2">
                                                    <asp:Label ID="Label31" runat="server" CssClass="s_label" Text="Concession if any :" Font-Bold="true"></asp:Label>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblconcession" 
                                                        runat="server" CssClass="s_label"></asp:Label></td>
                                                <td align="left" style="height: 40px; width:275px" colspan="2">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="height: 40px" colspan="2">
                                                    <asp:Label ID="Label32" runat="server" CssClass="s_label" Text="Conduct and Character :" Font-Bold="true"></asp:Label>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblconduct" 
                                                        runat="server" CssClass="s_label"></asp:Label></td>
                                                <td align="left" style="width: 275px; height: 40px">
                                                    &nbsp;</td>
                                                <td align="left" style="width: 50px; height: 40px">&nbsp;</td>
                                            </tr>
                                            <tr id="trsubdomain" runat="server">
                                                <td align="left" style="height: 40px" colspan="3">
                                                    <asp:Label ID="Label33" runat="server" CssClass="s_label" Text="Date on which transfer certificate is requested :" Font-Bold="true"></asp:Label>
                                                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbltcrequest" 
                                                        runat="server" CssClass="s_label"></asp:Label></td>
                                                <td align="left" style="width: 50px; height: 40px">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="height: 40px" colspan="3">
                                                    <asp:Label ID="Label34" runat="server" CssClass="s_label" Text="Date on which student left or leaving the school  :" Font-Bold="true"></asp:Label>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblLeavingschool" 
                                                        runat="server" CssClass="s_label"></asp:Label></td>
                                                <td align="left" style="width: 50px; height: 40px">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="height: 40px" colspan="3">
                                                    <asp:Label ID="Label35" runat="server" CssClass="s_label" Text="Date on which transfer certificate is issued :" Font-Bold="true"></asp:Label>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbltcissued" 
                                                        runat="server" CssClass="s_label"></asp:Label></td>
                                                <td align="left" style="width: 50px; height: 40px">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="height: 40px" colspan="3">
                                                    <asp:Label ID="Label36" runat="server" CssClass="s_label" Text="Transfer certificate number :" Font-Bold="true"></asp:Label>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbltcnumber" 
                                                        runat="server" CssClass="s_label"></asp:Label></td>
                                                <td align="left" style="width: 50px; height: 40px">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width:270px">
                                                    <asp:Label ID="Label37" runat="server" CssClass="s_label" Text="Reason for leaving the school :" Font-Bold="true"></asp:Label>                                                    
                                                </td>
                                                <td align="left" style="height: 50px" colspan="2">
                                                    <asp:Label ID="lblreasonforleavingschool" runat="server" CssClass="s_label"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 50px; height: 40px">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label38" runat="server" CssClass="s_label" Text="Other remarks :" Font-Bold="true"></asp:Label>                                                   
                                                </td>
                                                <td  align="left" colspan="3" valign="middle" style="height:50px">
                                                    <asp:Label ID="lblremarks" runat="server" CssClass="s_label"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label41" runat="server" CssClass="s_label" Text="Status :" 
                                                        Font-Bold="True"></asp:Label>                                                   
                                                </td>
                                                <td  align="left" colspan="3" valign="middle" style="height:50px">
                                                    <asp:Label ID="lblstatus" runat="server" CssClass="s_label"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="3" style="height:40px">
                                                    <input type ="button" value="Back" class="s_button" onclick="javascript:history.go(-1)" />
                                                </td>
                                                <td align="left" style="height:40px"></td>
                                            </tr>
                                        </table>   
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                            </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100%;" align="left" valign="top" >
                <uc6:app_footer ID="footer" runat="server" />
            </td>
        </tr>
    </table>
    <cc1:MsgBox id="msgbox" runat="server"></cc1:MsgBox>
    </div>
    </form>
</body>
</html>
