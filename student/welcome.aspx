<%@ Page Language="C#" AutoEventWireup="true" CodeFile="welcome.aspx.cs" Inherits="student_welcome" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register src="../usercontrol/mainmasters.ascx" tagname="mainmasters" tagprefix="uc1" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
<%@ Register Src="../usercontrol/footer.ascx" TagName="app_footer" TagPrefix="uc6" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The Schools.in - Admin</title>
     <link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/layout.css" media="screen" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../css/main.css" />
    <script type="text/javascript" src="../media/js/jquery.min.js"></script>
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
            <td style="width: 100%; height: 80px" valign="top">
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
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 2%" valign="top">
                        </td>
                        <td style="width: 93%" valign="top" align="left">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td style="width: 100%; height: 50px" align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" width="750">
                                            <tr>
                                                <td style="width: 50px; height: 50px"><img src="../media/images/moduleimg1.jpg" width="50" height="50" /></td>
                                                <td style="width: 685px; height: 50px; font-family: Arial; font-size: 23px; color: #2DA0ED; padding-left: 10px" align="left">
                                                                                                        Students Panel</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 3px; background-image: url(../media/images/bline.jpg)"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; background-image: url(../media/images/dashboardback.jpg); background-repeat: repeat-x" valign="top" align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" width="760">
                                            <tr>
                                                <td style="width: 760px; height: 400px" align="left" valign="top">
                                                    <table cellpadding="0" cellspacing="0" border="0" width="760">
                                                        <tr>
                                                            <td style="width: 560px; height: 400px" valign="top" align="left">
                                                                <table cellpadding="0" cellspacing="0" border="0" width="550">
                                                                    <tr>
                                                                        <td style="width: 550px; height: 40px; padding-left: 20px">
                                                                            <img src="../media/images/welcometotheschools.png" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr><td style="width: 550px; height: 1px; background-color: #b3b3b3"></td></tr>
                                                                    <tr><td style="width: 550px; height: 10px"></td></tr>
                                                                    <tr>
                                                                        <td style="width: 550px; height: 100px" valign="top">
                                                                            <table cellpadding="0" cellspacing="0" border="0" width="550">
                                                                                <tr>
                                                                                    <td style="width: 120px; height: 105px" align="right"><img src="../media/images/icon01.gif" alt="Notice Board" /></td>
                                                                                    <td style="width: 10px; height: 105px"></td>
                                                                                    <td style="width: 420px; height: 105px" valign="top" align="left">
                                                                                        <table cellpadding="0" cellspacing="0" border="0" width="420">
                                                                                            <tr>
                                                                                                <td style="width: 420px; height: 30px" align="left">
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" width="420">
                                                                                                        <tr>
                                                                                                            <td style="width: 300px; height: 30px; padding-left: 20px" class="s_dash_title">Notice Board</td>
                                                                                                            <td style="width: 60px; height: 30px" valign="top" align="right"><img src="../media/images/leftarrow.gif" />&nbsp;&nbsp;
                                                                                                                <br />
                                                                                                                Yesterday&nbsp;&nbsp; </td>
                                                                                                            <td style="width: 60px; height: 30px" valign="top" align="left">
                                                                                                                &nbsp; <img src="../media/images/rightarrow.gif" /><br />&nbsp;Tomorrow
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="width: 420px; height: 50px" colspan="3">
                                                                                                                
                                                                                                            </td>
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
                                                                    <tr><td style="width: 550px; height: 10px"></td></tr>
                                                                    <tr><td style="width: 550px; height: 10px; background-image: url(../media/images/line1.png)"></td></tr>
                                                                    <tr><td style="width: 550px; height: 10px"></td></tr>
                                                                    <tr>
                                                                        <td style="width: 550px; height: 100px" valign="top">
                                                                            <table cellpadding="0" cellspacing="0" border="0" width="550">
                                                                                <tr>
                                                                                    <td style="width: 120px; height: 105px" align="right"><img src="../media/images/icon02.gif" alt="Notice Board" /></td>
                                                                                    <td style="width: 10px; height: 105px"></td>
                                                                                    <td style="width: 420px; height: 105px" valign="top" align="left">
                                                                                        <table cellpadding="0" cellspacing="0" border="0" width="420">
                                                                                            <tr>
                                                                                                <td style="width: 420px; height: 30px" align="left">
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" width="420">
                                                                                                        <tr>
                                                                                                            <td style="width: 300px; height: 30px; background-image:url(../media/images/t_todaystimetable.png); background-repeat: no-repeat">
                                                                                                                &nbsp;</td>
                                                                                                            <td style="width: 60px; height: 30px" valign="top" align="right"><img src="../media/images/leftarrow.gif" />&nbsp;&nbsp;
                                                                                                                <br />
                                                                                                                Yesterday&nbsp;&nbsp; </td>
                                                                                                            <td style="width: 60px; height: 30px" valign="top" align="left">
                                                                                                                &nbsp; <img src="../media/images/rightarrow.gif" /><br />&nbsp;Tomorrow
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="width: 420px; height: 50px" colspan="3">
                                                                                                                
                                                                                                            </td>
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
                                                                    <tr><td style="width: 550px; height: 10px"></td></tr>
                                                                    <tr><td style="width: 550px; height: 10px; background-image: url(../media/images/line1.png)"></td></tr>
                                                                    <tr><td style="width: 550px; height: 10px"></td></tr>
                                                                    <tr>
                                                                        <td style="width: 550px; height: 100px" valign="top">
                                                                            <table cellpadding="0" cellspacing="0" border="0" width="550">
                                                                                <tr>
                                                                                    <td style="width: 120px; height: 105px" align="right"><img src="../media/images/icon03.gif" alt="Notice Board" /></td>
                                                                                    <td style="width: 10px; height: 105px"></td>
                                                                                    <td style="width: 420px; height: 105px" valign="top" align="left">
                                                                                        <table cellpadding="0" cellspacing="0" border="0" width="420">
                                                                                            <tr>
                                                                                                <td style="width: 420px; height: 30px" align="left">
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" width="420">
                                                                                                        <tr>
                                                                                                            <td style="width: 300px; height: 30px; background-image:url(../media/images/t_teachingschedule.png); background-repeat: no-repeat"></td>
                                                                                                            <td style="width: 60px; height: 30px" valign="top" align="right"><img src="../media/images/leftarrow.gif" />&nbsp;&nbsp;
                                                                                                                <br />
                                                                                                                Yesterday&nbsp;&nbsp; </td>
                                                                                                            <td style="width: 60px; height: 30px" valign="top" align="left">
                                                                                                                &nbsp; <img src="../media/images/rightarrow.gif" /><br />&nbsp;Tomorrow
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="width: 420px; height: 50px" colspan="3">
                                                                                                                
                                                                                                            </td>
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
                                                                    <tr><td style="width: 550px; height: 10px"></td></tr>
                                                                    <tr><td style="width: 550px; height: 10px; background-image: url(../media/images/line1.png)"></td></tr>
                                                                    <tr><td style="width: 550px; height: 10px"></td></tr>
                                                                    <tr>
                                                                        <td style="width: 550px; height: 100px" valign="top">
                                                                            <table cellpadding="0" cellspacing="0" border="0" width="550">
                                                                                <tr>
                                                                                    <td style="width: 120px; height: 105px" align="right"><img src="../media/images/icon04.gif" alt="Notice Board" /></td>
                                                                                    <td style="width: 10px; height: 105px"></td>
                                                                                    <td style="width: 420px; height: 105px" valign="top" align="left">
                                                                                        <table cellpadding="0" cellspacing="0" border="0" width="420">
                                                                                            <tr>
                                                                                                <td style="width: 420px; height: 30px" align="left">
                                                                                                    <table cellpadding="0" cellspacing="0" border="0" width="420">
                                                                                                        <tr>
                                                                                                            <td style="width: 300px; height: 30px; background-image:url(../media/images/t_homeworkassigned.png); background-repeat: no-repeat"></td>
                                                                                                            <td style="width: 60px; height: 30px" valign="top" align="right"><img src="../media/images/leftarrow.gif" />&nbsp;&nbsp;
                                                                                                                <br />
                                                                                                                Yesterday&nbsp;&nbsp; </td>
                                                                                                            <td style="width: 60px; height: 30px" valign="top" align="left">
                                                                                                                &nbsp; <img src="../media/images/rightarrow.gif" /><br />&nbsp;Tomorrow
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="width: 420px; height: 50px" colspan="3">
                                                                                                                
                                                                                                            </td>
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
                                                                    <tr><td style="width: 550px; height: 10px"></td></tr>
                                                                    <tr><td style="width: 550px; height: 10px; background-image: url(../media/images/line1.png)"></td></tr>
                                                                </table>
                                                            </td>
                                                            <td style="width: 2px; height: 400px; background-color: #b3b3b3"></td>
                                                            <td style="width: 6px; height: 400px"></td>
                                                            <td style="width: 192px; height: 400px; padding-top: 10px" valign="top" align="left">
                                                                <table cellpadding="0" cellspacing="0" border="0" width="192">
                                                                    <tr>
                                                                        <td>
                                                                            <table cellpadding="0" cellspacing="0" border="0" width="192">
                                                                                <tr>
                                                                                    <td style="width: 52px; height: 52px; background-image: url(../media/images/Reminders.gif)"></td>
                                                                                    <td style="width: 140px; height: 52px" valign="top" align="left">
                                                                                        <table cellpadding="0" cellspacing="0" border="0" width="140">
                                                                                            <tr>
                                                                                                <td style="width: 140px; height: 30px; padding-left: 10px" class="s_dash_title1">Remainder</td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 140px; height:1px; background-color: #000000"></td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="3" style="width: 192px; height: 50px;" class="s_text" valign="top">
                                                                                        sdfsdfdsf sdfd sf dsf ds fds f dsf&nbsp; dsf ds dsf sd g sdg sdg sf g fg fs ga 
                                                                                        fsg sfg fs g f s gs fg fs gsf gf s gs fg sfg sfg s g&nbsp; s g ds </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="3" style="width: 192px; height: 10px;" class="s_text" valign="top">
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <table cellpadding="0" cellspacing="0" border="0" width="192">
                                                                                <tr>
                                                                                    <td style="width: 52px; height: 52px; background-image: url(../media/images/Reminders.gif)"></td>
                                                                                    <td style="width: 140px; height: 52px" valign="top" align="left">
                                                                                        <table cellpadding="0" cellspacing="0" border="0" width="140">
                                                                                            <tr>
                                                                                                <td style="width: 140px; height: 30px; padding-left: 10px" class="s_dash_title1">Remainder</td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 140px; height:1px; background-color: #000000"></td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="3" style="width: 192px; height: 50px;" class="s_text" valign="top">
                                                                                        sdfsdfdsf sdfd sf dsf ds fds f dsf&nbsp; dsf ds dsf sd g sdg sdg sf g fg fs ga 
                                                                                        fsg sfg fs g f s gs fg fs gsf gf s gs fg sfg sfg s g&nbsp; s g ds </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="3" style="width: 192px; height: 10px;" class="s_text" valign="top">
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <table cellpadding="0" cellspacing="0" border="0" width="192">
                                                                                <tr>
                                                                                    <td style="width: 52px; height: 52px; background-image: url(../media/images/Reminders.gif)"></td>
                                                                                    <td style="width: 140px; height: 52px" valign="top" align="left">
                                                                                        <table cellpadding="0" cellspacing="0" border="0" width="140">
                                                                                            <tr>
                                                                                                <td style="width: 140px; height: 30px; padding-left: 10px" class="s_dash_title1">Remainder</td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 140px; height:1px; background-color: #000000"></td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="3" style="width: 192px; height: 50px;" class="s_text" valign="top">
                                                                                        sdfsdfdsf sdfd sf dsf ds fds f dsf&nbsp; dsf ds dsf sd g sdg sdg sf g fg fs ga 
                                                                                        fsg sfg fs g f s gs fg fs gsf gf s gs fg sfg sfg s g&nbsp; s g ds </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="3" style="width: 192px; height: 10px;" class="s_text" valign="top">
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <table cellpadding="0" cellspacing="0" border="0" width="192">
                                                                                <tr>
                                                                                    <td style="width: 52px; height: 52px; background-image: url(../media/images/Reminders.gif)"></td>
                                                                                    <td style="width: 140px; height: 52px" valign="top" align="left">
                                                                                        <table cellpadding="0" cellspacing="0" border="0" width="140">
                                                                                            <tr>
                                                                                                <td style="width: 140px; height: 30px; padding-left: 10px" class="s_dash_title1">Remainder</td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="width: 140px; height:1px; background-color: #000000"></td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="3" style="width: 192px; height: 50px;" class="s_text" valign="top">
                                                                                        sdfsdfdsf sdfd sf dsf ds fds f dsf&nbsp; dsf ds dsf sd g sdg sdg sf g fg fs ga 
                                                                                        fsg sfg fs g f s gs fg fs gsf gf s gs fg sfg sfg s g&nbsp; s g ds </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="3" style="width: 192px; height: 10px;" class="s_text" valign="top">
                                                                                    </td>
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
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr><td class="break"></td></tr>
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
