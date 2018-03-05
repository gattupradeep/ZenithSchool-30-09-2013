<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RequestWithdrawalForm.aspx.cs" Inherits="student_RequestWithdrawalForm" %>
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
    <script type="text/javascript" src="../media/js/jquery.min.js"></script>
    <link rel="stylesheet" href="../css/ui_datepicker.css" type="text/css" />
    <link rel="stylesheet" href="../css/ui.daterangepicker.css" type="text/css" />
	<script type="text/javascript" src="../js/jquery-ui.min.js"></script>
    <script type="text/javascript" src="../js/date.js"></script>
	<script type="text/javascript" src="../js/daterangepicker.jQuery.js"></script>
	
    <script type="text/javascript">
        $(document).ready(function() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
            function EndRequestHandler(sender, args) {
                $('#txtTcRequested').datepicker({ dateFormat: 'yy/mm/dd' });
            }
        });
        $(function() {
        var dates = $("#txtTcRequested").datepicker({
                constrainDates: true,
                dateFormat: 'dd/mm/yy',
                changeMonth: true,
                changeYear: true
            });
        });
        $(document).ready(function() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
            function EndRequestHandler(sender, args) {
                $('#txtstudentleft').datepicker({ dateFormat: 'yy/mm/dd' });
            }
        });
        $(function() {
        var dates = $("#txtstudentleft").datepicker({
                constrainDates: true,
                dateFormat: 'dd/mm/yy',
                changeMonth: true,
                changeYear: true
            });
        });
        $(document).ready(function() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
            function EndRequestHandler(sender, args) {
                $('#txtTcissued').datepicker({ dateFormat: 'yy/mm/dd' });
            }
        });
        $(function() {
        var dates = $("#txtTcissued").datepicker({
                constrainDates: true,
                dateFormat: 'dd/mm/yy',
                changeMonth: true,
                changeYear: true
            });
        });
        
     </script>
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
                    img.src = "../images/hide.png";
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
                    img.src = "../images/hide.png";
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
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr class="app_container_title">
                                    <td style="width: 100%; " align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" >
                                            <tr>
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/279.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left">Request / Issue Tc</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 10px" valign="top" align="left">
                                         <%--<asp:UpdateProgress ID="Updateprocess" runat="server" AssociatedUpdatePanelID="updatepanal" DisplayAfter="1" >
                                                    <ProgressTemplate>
                                                        <div id="progressBackgroundFilter"></div>
                                                            <div id="processMessage">
                                                                <img alt="Loading" src="../media/images/Processing.gif" />
                                                            </div>
                                                    </ProgressTemplate>
                                        </asp:UpdateProgress>--%>
                                        <asp:UpdatePanel ID="updatepanal" runat="server">
                                            <ContentTemplate>
                                            <table cellpadding="0" cellspacing="0" border="0" class="app_container">
                                            <tr class="view_detail_title_bg">
                                                <td colspan="4" class="title_label">School Leaving Certificate</td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 175px; height: 40px">
                                                    <asp:Label ID="Label11" runat="server" CssClass="s_label" Text="Admission No"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 250px; height: 40px">
                                                    <asp:TextBox ID="txtadmissionno" runat="server" CssClass="s_textbox" AutoPostBack="true"
                                                        Width="160px" ontextchanged="txtadmissionno_TextChanged"></asp:TextBox>
                                                    &nbsp;&nbsp;&nbsp;<asp:Button ID="Button1" runat="server" Text="Ok" CssClass="s_button" onclick="Button1_Click" />
                                                </td>
                                                <td align="left" style="height: 40px" colspan="2">
                                                    <a href="javascript: void(0)" onclick="popup('withdrawalpopup.aspx')">
                                                    <asp:Button ID="btnfind" runat="server" CssClass="s_button" 
                                                        Text="Find admission No"/></a>
                                                </td>
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
                                                                        <asp:Label ID="Label1" runat="server" Text="FeeType:" CssClass="s_label"></asp:Label>                                                                    
                                                                    </td>
                                                                     <td>
                                                                        <asp:Label ID="lblfeetype" runat="server" CssClass="s_label"></asp:Label>                                                                    
                                                                    </td>
                                                                </tr>                                                            
                                                            </table>
                                                            <table>
                                                                <tr>
                                                                    <td>
                                                                        <%--<asp:Label ID="Label2" runat="server" Text="Library" CssClass="s_label"></asp:Label> --%> 
                                                                        <asp:Label ID="Label2" runat="server" Text="Dues" CssClass="s_label"></asp:Label>                                                                   
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblfee" runat="server" CssClass="s_label"></asp:Label>                                                                    
                                                                    </td>
                                                                </tr>                                                            
                                                            </table>
                                                        </asp:Panel>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="height: 40px" colspan="2">&nbsp;
                                                    <asp:Label ID="Label12" runat="server" CssClass="s_label" Text="Name of Student"></asp:Label>
                                                </td>
                                                <td align="left" style="height: 40px" colspan="2">
                                                    <asp:Label ID="lblstudentname" runat="server" CssClass="s_label"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="height: 40px" colspan="2">&nbsp;
                                                    <asp:Label ID="Label13" runat="server" CssClass="s_label" Text="Admission No"></asp:Label>
                                                </td>
                                                <td align="left" style="height: 40px" colspan="2">
                                                    <asp:Label ID="lbladmission" runat="server" CssClass="s_label"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="4" style="height: 40px;" class="s_dash_title1">Personal Details</td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="height: 40px" colspan="2">&nbsp;
                                                    <asp:Label ID="Label14" runat="server" CssClass="s_label" Text="Birth Certificate/Identity Card/Passport No"></asp:Label>
                                                </td>
                                                <td align="left" style="height: 40px" colspan="2">
                                                    <asp:Label ID="lblbirthcertificateno" runat="server" CssClass="s_label"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="height: 40px" colspan="2">&nbsp;
                                                    <asp:Label ID="Label23" runat="server" CssClass="s_label" Text="Date of Birth"></asp:Label>
                                                </td>
                                                <td align="left" style="height: 40px" colspan="2">
                                                    <asp:Label ID="lbldateofbirth" runat="server" CssClass="s_label"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="4" style="height: 40px;" class="s_dash_title1">School Details</td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="height: 40px" colspan="2">&nbsp;
                                                    <asp:Label ID="Label39" runat="server" CssClass="s_label" Text="Previous School (if any)"></asp:Label>
                                                </td>
                                                <td align="left" style="height: 40px" colspan="2">
                                                    <asp:Label ID="lblpreviousschool" runat="server" CssClass="s_label"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="height: 40px" colspan="2">&nbsp;
                                                    <asp:Label ID="Label40" runat="server" CssClass="s_label" Text="Enrollment Date"></asp:Label>
                                                </td>
                                                <td align="left" style="height: 40px" colspan="2">
                                                    <asp:Label ID="lbladmissiondate" runat="server" CssClass="s_label"></asp:Label>
                                                </td>     
                                            </tr>
                                            <tr>
                                                <td align="left" style="height: 40px" colspan="2">&nbsp;
                                                    <asp:Label ID="Label15" runat="server" CssClass="s_label" Text="Class enrolled"></asp:Label>
                                                </td>
                                                <td align="left" style="height: 40px" colspan="2">
                                                    <asp:Label ID="lblclass" runat="server" CssClass="s_label"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="height: 40px" colspan="2">&nbsp;
                                                    <asp:Label ID="lblclasscompleted" runat="server" CssClass="s_label" Text="Highest Level Completed"></asp:Label>
                                                </td>
                                                <td align="left" style="height: 40px" colspan="2">
                                                    <asp:Label ID="lblhighestlevelcompleted" runat="server" CssClass="s_label"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="height: 40px" colspan="2">&nbsp;
                                                    <asp:Label ID="Label17" runat="server" CssClass="s_label" Text="Attendance"></asp:Label>
                                                </td>
                                                <td align="left" style="height: 40px" colspan="2">
                                                    <asp:Label ID="lblattendance" runat="server" CssClass="s_label"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="height: 40px" colspan="2">&nbsp;
                                                    <asp:Label ID="Label16" runat="server" CssClass="s_label" Text="Conduct"></asp:Label>
                                                </td>
                                                <td align="left" style="height: 40px" colspan="2">
                                                    <asp:TextBox ID="txtconduct" runat="server" CssClass="s_textbox" Width="160px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr id="trsubdomain" runat="server">
                                                <td align="left" style="height: 40px" colspan="2">&nbsp;
                                                    <asp:Label ID="Label33" runat="server" CssClass="s_label" Text="Date on which transfer certificate is requested" ></asp:Label>
                                                </td>
                                                <td align="left" style="height: 40px" colspan="2">
                                                    <asp:TextBox ID="txtTcRequested" runat="server" CssClass="s_textbox" Width="160px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="height: 40px" colspan="2">&nbsp;
                                                    <asp:Label ID="Label34" runat="server" CssClass="s_label" Text="Date on which student left or leaving the school"></asp:Label>
                                                <td align="left" style="height: 40px" colspan="2">                                                
                                                    <asp:TextBox ID="txtstudentleft" runat="server" CssClass="s_textbox" Width="160px"></asp:TextBox></td>
                                                </td>
                                            </tr>
                                            <%--<tr>
                                                <td align="left" style="height: 40px" colspan="2">&nbsp;
                                                    <asp:Label ID="Label35" runat="server" CssClass="s_label" Text="Date on which transfer certificate is issued" ></asp:Label>
                                                </td>
                                                <td align="left" style="height: 40px">
                                                    <asp:TextBox ID="txtTcissued" runat="server" CssClass="s_textbox" Width="160px"></asp:TextBox>
                                                </td>
                                            </tr>--%>
                                            <tr>
                                                <td align="left" style="width:270px" colspan="2">&nbsp;
                                                    <asp:Label ID="Label37" runat="server" CssClass="s_label" Text="Reason for Leaving"></asp:Label>                                                    
                                                </td>
                                                <td align="left" style="height: 50px" colspan="2">
                                                    <asp:TextBox ID="txtreason" runat="server" CssClass="s_textbox" Width="160px" TextMode="MultiLine" Height="40px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="height: 40px" colspan="2">&nbsp;
                                                    <asp:Label ID="Label3" runat="server" CssClass="s_label" Text="Extra Curricular Activities"></asp:Label>
                                                </td>
                                                <td align="left" style="height: 40px" colspan="2">
                                                    <asp:TextBox ID="txtextracurricular" runat="server" CssClass="s_textbox" TextMode="MultiLine" Width="160px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="3" style="height:40px">
                                                    <asp:Button ID="btnsave" runat="server" CssClass="s_button" Text="Save" onclick="btnsave_Click" />
                                                    &nbsp;&nbsp;&nbsp;<asp:Button ID="btncancel" runat="server" CssClass="s_button" Text="Cancel" onclick="btncancel_Click" />
                                                    &nbsp;&nbsp;&nbsp;</td>
                                                <td align="left" style="height:40px"></td>
                                            </tr>
                                        </table> 
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100%;" align="left" valign="top">
                <uc6:app_footer ID="footer" runat="server" />
            </td>
        </tr>
    </table>
    <cc1:MsgBox id="msgbox" runat="server"></cc1:MsgBox>
    </div>
    </form>
</body>
</html>
