<%@ Page Language="C#" AutoEventWireup="true" CodeFile="employeedetails.aspx.cs" Inherits="school_employeedetails" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>

<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>

<%@ Register src="../usercontrol/detailsrecord_staff.ascx" tagname="detailsrecord_staff" tagprefix="uc1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit.HTMLEditor" tagprefix="cc2" %>

<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>

<%@ Register src="../usercontrol/footer.ascx" tagname="app_footer" tagprefix="uc6" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The Schools.in - Admin</title>
    <link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/layout.css" media="screen" rel="stylesheet" type="text/css" />
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
    <script type="text/javascript">
        function ShowMenu1(MenuID) {
            var SelMenu = document.getElementById(MenuID);
            var Menu00 = document.getElementById('menu00');
            var Menu01 = document.getElementById('menu01');
            var Menu02 = document.getElementById('menu02');
            var Menu03 = document.getElementById('menu03');
            var Menu04 = document.getElementById('menu04');
            var Menu05 = document.getElementById('menu05');
            var Menu11 = document.getElementById('menu11');
            var Menu22 = document.getElementById('menu22');
            var Menu33 = document.getElementById('menu33');
            var Menu44 = document.getElementById('menu44');
            var Menu55 = document.getElementById('menu55');

            if (MenuID == 'menu1') {
                Menu00.style.visibility = 'hidden';
                Menu00.style.display = 'none';

                Menu01.style.visibility = 'visible';
                Menu01.style.display = 'block';
                Menu11.style.visibility = 'visible';
                Menu11.style.display = 'block';

                Menu02.style.visibility = 'hidden';
                Menu02.style.display = 'none';
                Menu22.style.visibility = 'hidden';
                Menu22.style.display = 'none';

                Menu03.style.visibility = 'hidden';
                Menu03.style.display = 'none';
                Menu33.style.visibility = 'hidden';
                Menu33.style.display = 'none';

                Menu04.style.visibility = 'hidden';
                Menu04.style.display = 'none';
                Menu44.style.visibility = 'hidden';
                Menu44.style.display = 'none';

                Menu05.style.visibility = 'hidden';
                Menu05.style.display = 'none';
                Menu55.style.visibility = 'hidden';
                Menu55.style.display = 'none';
            }

            if (MenuID == 'menu2') {
                Menu00.style.visibility = 'hidden';
                Menu00.style.display = 'none';

                Menu02.style.visibility = 'visible';
                Menu02.style.display = 'block';
                Menu22.style.visibility = 'visible';
                Menu22.style.display = 'block';

                Menu01.style.visibility = 'hidden';
                Menu01.style.display = 'none';
                Menu11.style.visibility = 'hidden';
                Menu11.style.display = 'none';

                Menu03.style.visibility = 'hidden';
                Menu03.style.display = 'none';
                Menu33.style.visibility = 'hidden';
                Menu33.style.display = 'none';

                Menu04.style.visibility = 'hidden';
                Menu04.style.display = 'none';
                Menu44.style.visibility = 'hidden';
                Menu44.style.display = 'none';

                Menu05.style.visibility = 'hidden';
                Menu05.style.display = 'none';
                Menu55.style.visibility = 'hidden';
                Menu55.style.display = 'none';
            }
            if (MenuID == 'menu3') {
                Menu00.style.visibility = 'hidden';
                Menu00.style.display = 'none';

                Menu03.style.visibility = 'visible';
                Menu03.style.display = 'block';
                Menu33.style.visibility = 'visible';
                Menu33.style.display = 'block';

                Menu02.style.visibility = 'hidden';
                Menu02.style.display = 'none';
                Menu22.style.visibility = 'hidden';
                Menu22.style.display = 'none';

                Menu01.style.visibility = 'hidden';
                Menu01.style.display = 'none';
                Menu11.style.visibility = 'hidden';
                Menu11.style.display = 'none';

                Menu04.style.visibility = 'hidden';
                Menu04.style.display = 'none';
                Menu44.style.visibility = 'hidden';
                Menu44.style.display = 'none';

                Menu05.style.visibility = 'hidden';
                Menu05.style.display = 'none';
                Menu55.style.visibility = 'hidden';
                Menu55.style.display = 'none';
            }

            if (MenuID == 'menu4') {
                Menu00.style.visibility = 'hidden';
                Menu00.style.display = 'none';

                Menu04.style.visibility = 'visible';
                Menu04.style.display = 'block';
                Menu44.style.visibility = 'visible';
                Menu44.style.display = 'block';

                Menu02.style.visibility = 'hidden';
                Menu02.style.display = 'none';
                Menu22.style.visibility = 'hidden';
                Menu22.style.display = 'none';

                Menu03.style.visibility = 'hidden';
                Menu03.style.display = 'none';
                Menu33.style.visibility = 'hidden';
                Menu33.style.display = 'none';

                Menu01.style.visibility = 'hidden';
                Menu01.style.display = 'none';
                Menu11.style.visibility = 'hidden';
                Menu11.style.display = 'none';

                Menu05.style.visibility = 'hidden';
                Menu05.style.display = 'none';
                Menu55.style.visibility = 'hidden';
                Menu55.style.display = 'none';
            }

            if (MenuID == 'menu5') {
                Menu00.style.visibility = 'hidden';
                Menu00.style.display = 'none';

                Menu05.style.visibility = 'visible';
                Menu05.style.display = 'block';
                Menu55.style.visibility = 'visible';
                Menu55.style.display = 'block';

                Menu02.style.visibility = 'hidden';
                Menu02.style.display = 'none';
                Menu22.style.visibility = 'hidden';
                Menu22.style.display = 'none';

                Menu03.style.visibility = 'hidden';
                Menu03.style.display = 'none';
                Menu33.style.visibility = 'hidden';
                Menu33.style.display = 'none';

                Menu04.style.visibility = 'hidden';
                Menu04.style.display = 'none';
                Menu44.style.visibility = 'hidden';
                Menu44.style.display = 'none';

                Menu01.style.visibility = 'hidden';
                Menu01.style.display = 'none';
                Menu11.style.visibility = 'hidden';
                Menu11.style.display = 'none';
            }
        }	
	</script>
    <script type="text/javascript">
        function HideMenus(MenuID) {
            var SelMenu = document.getElementById(MenuID);
            var Menu00 = document.getElementById('menu00');
            var Menu01 = document.getElementById('menu01');
            var Menu02 = document.getElementById('menu02');
            var Menu03 = document.getElementById('menu03');
            var Menu04 = document.getElementById('menu04');
            var Menu05 = document.getElementById('menu05');
            var Menu11 = document.getElementById('menu11');
            var Menu22 = document.getElementById('menu22');
            var Menu33 = document.getElementById('menu33');
            var Menu44 = document.getElementById('menu44');
            var Menu55 = document.getElementById('menu55');

            Menu00.style.visibility = 'visible';
            Menu00.style.display = 'block';
            if (MenuID == 'menu1') {
                Menu01.style.visibility = 'hidden';
                Menu01.style.display = 'none';
                Menu11.style.visibility = 'hidden';
                Menu11.style.display = 'none';
            }
            if (MenuID == 'menu2') {
                Menu02.style.visibility = 'hidden';
                Menu02.style.display = 'none';
                Menu22.style.visibility = 'hidden';
                Menu22.style.display = 'none';
            }
            if (MenuID == 'menu3') {
                Menu03.style.visibility = 'hidden';
                Menu03.style.display = 'none';
                Menu33.style.visibility = 'hidden';
                Menu33.style.display = 'none';
            }
            if (MenuID == 'menu4') {
                Menu04.style.visibility = 'hidden';
                Menu04.style.display = 'none';
                Menu44.style.visibility = 'hidden';
                Menu44.style.display = 'none';
            }
            if (MenuID == 'menu5') {
                Menu05.style.visibility = 'hidden';
                Menu05.style.display = 'none';
                Menu55.style.visibility = 'hidden';
                Menu55.style.display = 'none';
            }
        }
    </script>
     <script type="text/javascript">
         function autowidth() {
             var screenW = 640, screenH = 480;
             if (parseInt(navigator.appVersion) > 3) {
                 screenW = screen.width;
                 currentwidth = screenW - 280;
             }
             var searchtable = document.getElementById("searchtable").style.width = currentwidth + "px";
             var assignwidth = document.getElementById("mwidth").style.width = currentwidth + "px";
             var panelwidth = document.getElementById("paneltd").style.width = currentwidth + "px";
             var panelwidth1 = document.getElementById("panelid").style.width = currentwidth + "px";
             
             //alert(panelwidth1);
         }
    </script>
</head>
<body onload="autowidth();" >
    <form id="form1" runat="server">
   <div>
       <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
       </asp:ToolkitScriptManager>
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td style="width: 100%;" align="left">
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
                                    <td style="width: 230px; margin-left: 120px;" align="right">
                                        <uc1:detailsrecord_staff ID="detailsrecord_staff1" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 230px" align="right">
                                        <uc4:school_info ID="school_info1" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td  style="width:2%"></td>
                        <td style="width: 93%" valign="top" align="left">
                           
                              <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr class="app_container_title">
                                    <td style="width: 100%; height: 50px" align="left">
                                        <table cellpadding="0" cellspacing="0" border="0">
                                            <tr >
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/18.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left" >
                                                Search/View Staff Details
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 8px; background-image: url(../media/images/bline.jpg)"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; padding-left: 5px" valign="top" align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" class="thick_curve" id="searchtable">
                                            <tr class="view_detail_subtitle_bg">
                                                <td colspan="6" style="height: 30px" align="left">&nbsp;&nbsp;
                                                    <asp:Label ID="Label8" runat="server" CssClass="subtitle_label" Text="Search" ></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 50px" align="left" >&nbsp;&nbsp;
                                                    <asp:Label ID="lbl1" runat="server" Text="Staff Type" CssClass="s_label"></asp:Label><br />
                                                    &nbsp;&nbsp;<asp:DropDownList ID="ddlstaff" runat="server" CssClass="s_dropdown" Width="150px" onselectedindexchanged="ddlstaff_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                                </td>
                                                <td style="height: 50px" align="left">
                                                    <asp:Label ID="Label2" runat="server" Text="Department" CssClass="s_label"></asp:Label><br />
                                                    <asp:DropDownList ID="ddldepart" runat="server" CssClass="s_dropdown" 
                                                        Width="150px" onselectedindexchanged="ddldepart_SelectedIndexChanged" 
                                                        AutoPostBack="True" Enabled="False">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="height: 50px" align="left">
                                                    <asp:Label ID="Label3" runat="server" Text="Designation" CssClass="s_label"></asp:Label><br />
                                                    <asp:DropDownList ID="ddldesignation" runat="server" CssClass="s_dropdown" 
                                                        Width="140px" onselectedindexchanged="ddldesignation_SelectedIndexChanged" 
                                                        AutoPostBack="True" Enabled="False">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="height: 50px" align="left">
                                                    <asp:Label ID="Label10" runat="server" Text="Staff Name" CssClass="s_label"></asp:Label><br />
                                                    <asp:DropDownList ID="ddlstaffname" runat="server" CssClass="s_dropdown" 
                                                        Width="140px" onselectedindexchanged="ddlstaffname_SelectedIndexChanged" 
                                                        AutoPostBack="True" Enabled="False">
                                                    </asp:DropDownList>
                                                </td>
                                                <td></td>
                                                <td></td>
                                            </tr>
                                            <tr id="trtag" runat="server">
                                                <td colspan="6">
                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                        <tr class="view_detail_subtitle_bg">
                                                            <td colspan="6" style="height: 30px" align="left">&nbsp;&nbsp;
                                                                <asp:Label ID="Label1" runat="server" CssClass="subtitle_label" Text="Sort by" ></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 115px; height: 30px" align="left">&nbsp;&nbsp;
                                                                <asp:Label ID="Label4" runat="server" CssClass="s_label" Text="Gender"></asp:Label>
                                                            </td>
                                                            <td style="width: 115px; height: 30px" align="left">
                                                                <asp:DropDownList ID="searchbygender" runat="server" CssClass="s_dropdown" 
                                                                    Width="115px" onselectedindexchanged="searchbygender_SelectedIndexChanged" 
                                                                    AutoPostBack="True">
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                    <asp:ListItem Value="Male">Male</asp:ListItem>
                                                                    <asp:ListItem Value="Female">Female</asp:ListItem>
                                                                    
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="width: 115px; height: 30px" align="left">&nbsp;&nbsp;
                                                                <asp:Label ID="Label5" runat="server" CssClass="s_label">Transport</asp:Label>
                                                            </td>
                                                            <td style="width: 115px; height: 30px" align="left">
                                                                <asp:DropDownList ID="searchbytransport" runat="server" CssClass="s_dropdown" Width="115px" onselectedindexchanged="searchbytransport_SelectedIndexChanged" AutoPostBack="True">
                                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                <asp:ListItem Value="School">School</asp:ListItem>
                                                                <asp:ListItem Value="Own">Own</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <%--<td style="width: 115px; height: 30px" align="left">&nbsp;&nbsp;
                                                                <asp:Label ID="Label6" runat="server" CssClass="s_label" Text="Community"></asp:Label>
                                                            </td>
                                                            <td style="width: 115px; height: 30px" align="left">
                                                                <asp:DropDownList ID="searchbycommunity" runat="server" CssClass="s_dropdown" Width="115px" onselectedindexchanged="searchbycommunity_SelectedIndexChanged" AutoPostBack="True">                                                         
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                    <asp:ListItem Value="FC">FC</asp:ListItem>
                                                                    <asp:ListItem Value="BC">BC</asp:ListItem>                                                        
                                                                    <asp:ListItem Value="OBC">OBC</asp:ListItem>
                                                                    <asp:ListItem Value="OC">OC</asp:ListItem>
                                                                    <asp:ListItem Value="SC/ST">SC/ST</asp:ListItem>
                                                                    <asp:ListItem Value="Others">Others</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>--%>
                                                            <td style="width: 115px; height: 30px" align="left">&nbsp;&nbsp;
                                                                <asp:Label ID="Label7" runat="server" CssClass="s_label" Text="Religion"></asp:Label>
                                                            </td>
                                                            <td style="width: 115px; height: 30px" align="left">
                                                                <asp:DropDownList ID="searchbyreligion" runat="server" CssClass="s_dropdown" 
                                                                    Width="115px" 
                                                                    onselectedindexchanged="searchbyreligion_SelectedIndexChanged" 
                                                                    AutoPostBack="True">
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                    <asp:ListItem Value="Hindu" >Hindu</asp:ListItem>
                                                                    <asp:ListItem Value="Muslim">Muslim</asp:ListItem>
                                                                    <asp:ListItem Value="Christian">Christian</asp:ListItem>
                                                                    <asp:ListItem Value="Others">Others</asp:ListItem>                                      
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 115px; height: 30px" align="left">&nbsp;&nbsp;
                                                                <asp:Label ID="Label12" runat="server" CssClass="s_label" Text="Birthday"></asp:Label>
                                                            </td>
                                                            <td style="width: 115px; height: 30px" align="left">
                                                                <asp:DropDownList ID="searchbybirthday" runat="server" CssClass="s_dropdown" 
                                                                    Width="115px" 
                                                                    onselectedindexchanged="searchbybirthday_SelectedIndexChanged" 
                                                                    AutoPostBack="True">
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                    <asp:ListItem Value="Today">Today</asp:ListItem>
                                                                    <asp:ListItem Value="This Week">This Week</asp:ListItem>
                                                                    <asp:ListItem Value="This Month">This Month</asp:ListItem>
                                                                    
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="width: 115px; height: 30px" align="left">&nbsp;&nbsp;
                                                                <asp:Label ID="Label13" runat="server" CssClass="s_label" Text="Blood group"></asp:Label>
                                                            </td>
                                                            <td style="width: 115px; height: 30px" align="left">
                                                                <asp:DropDownList ID="searchbyblood" runat="server" CssClass="s_dropdown" 
                                                                    Width="115px" onselectedindexchanged="searchbyblood_SelectedIndexChanged" 
                                                                    AutoPostBack="True"> 
                                                                      <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                      <asp:ListItem Value="O +ve">O +ve</asp:ListItem>
                                                                      <asp:ListItem Value="A +ve">A +ve</asp:ListItem>
                                                                      <asp:ListItem Value="O -ve">O -ve</asp:ListItem>
                                                                      <asp:ListItem Value="A -ve">A -ve</asp:ListItem>
                                                                      <asp:ListItem Value="B +ve">B +ve</asp:ListItem>
                                                                      <asp:ListItem Value="AB +ve">AB +ve</asp:ListItem>
                                                                      <asp:ListItem Value="AB -ve">AB -ve</asp:ListItem>
                                                                      <asp:ListItem Value="B -ve">B -ve</asp:ListItem>                                                                     
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>                                            
                                                        <tr id="trteachingclasssubject" runat="server">
                                                            <td style="width: 115px; height: 30px" align="left">&nbsp;&nbsp;
                                                                <asp:Label ID="Label9" runat="server" CssClass="s_label" Text="Teaching class"></asp:Label>
                                                            </td>
                                                            <td style="width: 115px; height: 30px" align="left">
                                                                <asp:DropDownList ID="searchbystandard" runat="server" CssClass="s_dropdown" 
                                                                    Width="115px" 
                                                                    onselectedindexchanged="searchbystandard_SelectedIndexChanged" 
                                                                    AutoPostBack="True">                                                                                       
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="width: 115px; height: 30px" align="left">&nbsp;&nbsp;
                                                                <asp:Label ID="Label11" runat="server" CssClass="s_label" Text="Teaching "></asp:Label>
                                                                &nbsp;&nbsp;&nbsp;<asp:Label ID="lbls" runat="server" CssClass="s_label" Text="subject"></asp:Label></td>
                                                            <td style="width: 115px; height: 30px" align="left">
                                                                <asp:DropDownList ID="searchbyteachsubject" runat="server" CssClass="s_dropdown" 
                                                                    Width="115px" 
                                                                    onselectedindexchanged="searchbyteachsubject_SelectedIndexChanged" 
                                                                    AutoPostBack="True">                                                                                     
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td></td><td></td>
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
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 5px" valign="top" align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" class="app_container" id="mwidth">
                                            <tr class="view_detail_title_bg" >
                                                <td align="left" >
                                                   <asp:Label CssClass="title_label" ID="lbltit" runat="server" Text="Staff Details" ></asp:Label>
                                                </td>
                                            </tr>
                                            <%--<tr id="trcommunication" runat="server">
                                                <td style="width: 100%; padding-left: 5px" valign="top" align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%" >
                                                        <tr id="menu00" style="DISPLAY: block; VISIBILITY: visible" runat="server">
                                                            <td align="left" style="width: 100%">
                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                    <tr>
                                                                        <td style="background-image: url(../media/images/1_70_36.png)" class="s_nmenu" onclick="ShowMenu1('menu1')">SMS</td>
                                                                        <td style="width: 3px; height: 36px"></td>
                                                                        <td style="background-image: url(../media/images/2_70_36.png)" class="s_nmenu" onclick="ShowMenu1('menu2')">
                                                                            E-Mail</td>
                                                                        <td style="width: 3px; height: 36px"></td>
                                                                        <td style="background-image: url(../media/images/3_70_36.png)" class="s_nmenu" onclick="ShowMenu1('menu3')">
                                                                            ID Card</td>
                                                                        <td style="width: 3px; height: 36px"></td>
                                                                        <td style="background-image: url(../media/images/4_70_36.png)" class="s_nmenu" onclick="ShowMenu1('menu4')">
                                                                            Promote</td>
                                                                        <td style="width: 3px; height: 36px"></td>
                                                                        <td style="background-image: url(../media/images/5_70_36.png)" class="s_nmenu" onclick="ShowMenu1('menu5')">
                                                                            Report</td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr id="menu01" style="DISPLAY: none; VISIBILITY: hidden">
                                                            <td align="left" style="width: 100%">
                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                    <tr>
                                                                        <td style="background-image: url(../media/images/1_70_50.png)" class="s_omenu" onclick="ShowMenu1('menu1')">
                                                                            SMS</td>
                                                                        <td style="width: 3px; height: 50px"></td>
                                                                        <td style="background-image: url(../media/images/2_70_36.png)" class="s_nmenu" onclick="ShowMenu1('menu2')">
                                                                            E-Mail</td>
                                                                        <td style="width: 3px; height: 50px"></td>
                                                                        <td style="background-image: url(../media/images/3_70_36.png)" class="s_nmenu" onclick="ShowMenu1('menu3')">
                                                                            ID Card</td>
                                                                        <td style="width: 3px; height: 50px"></td>
                                                                        <td style="background-image: url(../media/images/4_70_36.png)" class="s_nmenu" onclick="ShowMenu1('menu4')">
                                                                            Promote</td>
                                                                        <td style="width: 3px; height: 50px"></td>
                                                                        <td style="background-image: url(../media/images/5_70_36.png)" class="s_nmenu" onclick="ShowMenu1('menu5')">
                                                                            Report</td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr id="menu11" style="DISPLAY: none; VISIBILITY: hidden">
                                                            <td align="left" >
                                                                <table cellpadding="5" cellspacing="0" border="0" width="400" class="curve" style="height: 40px; margin:5px;">
                                                                    <tr class="s_datagrid_header">
                                                                        <td  style="height: 30px" align="left" colspan="3"><asp:Label ID="Label18" runat="server" CssClass="s_label" ForeColor="White">Send SMS</asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 150px; height: 30px">
                                                                            <asp:Label ID="Label16" runat="server" CssClass="s_label" Text="Message"></asp:Label>
                                                                        </td>
                                                                        <td colspan="2" style="width: 250px; height: 30px">
                                                                            <asp:TextBox ID="txtmessage" runat="server" Height="100px" TextMode="MultiLine" 
                                                                                Width="240px"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 150px; height: 40px">
                                                                        </td>
                                                                        <td style="width: 150px; height: 40px" align="left">
                                                                            <asp:Button ID="btnsendmsg" runat="server" CssClass="s_button" Text="Send" 
                                                                                onclick="btnsendmsg_Click" />
                                                                        </td>
                                                                        <td style="width: 100px; height: 40px" align="right">
                                                                            <img src="../media/images/close.png" onclick="HideMenus('menu1')" alt="Close" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr id="menu02" style="DISPLAY: none; VISIBILITY: hidden">
                                                            <td align="left" style="width: 100%">
                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                    <tr>
                                                                        <td style="background-image: url(../media/images/1_70_36.png)" class="s_nmenu" onclick="ShowMenu1('menu1')">
                                                                            SMS</td>
                                                                        <td style="width: 3px; height: 50px"></td>
                                                                        <td style="background-image: url(../media/images/2_70_50.png)" class="s_omenu" onclick="ShowMenu1('menu2')">
                                                                            E-Mail</td>
                                                                        <td style="width: 3px; height: 50px"></td>
                                                                        <td style="background-image: url(../media/images/3_70_36.png)" class="s_nmenu" onclick="ShowMenu1('menu3')">
                                                                            ID Card</td>
                                                                        <td style="width: 3px; height: 50px"></td>
                                                                        <td style="background-image: url(../media/images/4_70_36.png)" class="s_nmenu" onclick="ShowMenu1('menu4')">
                                                                            Promote</td>
                                                                        <td style="width: 3px; height: 50px"></td>
                                                                        <td style="background-image: url(../media/images/5_70_36.png)" class="s_nmenu" onclick="ShowMenu1('menu5')">
                                                                            Report</td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr id="menu22" style="DISPLAY: none; VISIBILITY: hidden">
                                                            <td align="left" style="width: 100%">
                                                                <asp:UpdatePanel ID="up1" runat="server">
                                                                    <ContentTemplate>
                                                                        <table cellpadding="5" cellspacing="0" border="0" width="749" class="curve" style="height: 40px; margin:5px;">
                                                                            <tr class="s_datagrid_header">
                                                                                <td  style="height: 30px" align="left" colspan="3"><asp:Label ID="Labelname" runat="server" CssClass="s_label" ForeColor="White">Send Mail</asp:Label></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 100px; height: 40px" align="left" valign="top">
                                                                                <asp:Label ID="lblsubject" runat="server" CssClass="s_label" Height="23px" 
                                                                                    Text="Subject"></asp:Label>
                                                                                </td>
                                                                                <td colspan="2" style="width: 100px; height: 40px" align="left">
                                                                                    <asp:TextBox ID="txtsubject" runat="server" CssClass="s_textbox" width="520"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td >
                                                                                    <asp:Label ID="Label17" runat="server" CssClass="s_label" Text="Message"></asp:Label>
                                                                                </td>
                                                                                <td colspan="2">
                                                                                    <cc2:Editor ID="txtmail" runat="server" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td >
                                                                                    &nbsp;</td>
                                                                                <td>
                                                                                    <asp:Button ID="btnsendmail" runat="server" CssClass="s_button" Text="Send Mail" 
                                                                                        onclick="btnsendmail_Click" />
                                                                                </td>
                                                                                <td style="width: 100px; height: 40px" align="right">
                                                                                    <img src="../media/images/close.png" onclick="HideMenus('menu2')" alt="Close" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                        <tr id="menu03" style="DISPLAY: none; VISIBILITY: hidden">
                                                            <td align="left" style="width: 100%">
                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                    <tr>
                                                                        <td style="background-image: url(../media/images/1_70_36.png)" class="s_nmenu" onclick="ShowMenu1('menu1')">
                                                                            SMS</td>
                                                                        <td style="width: 3px; height: 50px"></td>
                                                                        <td style="background-image: url(../media/images/2_70_36.png)" class="s_nmenu" onclick="ShowMenu1('menu2')">
                                                                            E-Mail</td>
                                                                        <td style="width: 3px; height: 50px"></td>
                                                                        <td style="background-image: url(../media/images/3_70_50.png)" class="s_omenu" onclick="ShowMenu1('menu3')">
                                                                            ID Card</td>
                                                                        <td style="width: 3px; height: 50px"></td>
                                                                        <td style="background-image: url(../media/images/4_70_36.png)" class="s_nmenu" onclick="ShowMenu1('menu4')">
                                                                            Promote</td>
                                                                        <td style="width: 3px; height: 50px"></td>
                                                                        <td style="background-image: url(../media/images/5_70_36.png)" class="s_nmenu" onclick="ShowMenu1('menu5')">
                                                                            Report</td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr id="menu33" style="DISPLAY: none; VISIBILITY: hidden">
                                                            <td align="left" style="height: 40px; width: 100%; background-color: #CC3399; padding: 20px">
                                                                Generate ID Card
                                                            </td>
                                                        </tr>
                                                        <tr id="menu04" style="DISPLAY: none; VISIBILITY: hidden">
                                                            <td align="left" style="width: 100%">
                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                    <tr>
                                                                        <td style="background-image: url(../media/images/1_70_36.png)" class="s_nmenu" onclick="ShowMenu1('menu1')">
                                                                            SMS</td>
                                                                        <td style="width: 3px; height: 50px"></td>
                                                                        <td style="background-image: url(../media/images/2_70_36.png)" class="s_nmenu" onclick="ShowMenu1('menu2')">
                                                                            E-Mail</td>
                                                                        <td style="width: 3px; height: 50px"></td>
                                                                        <td style="background-image: url(../media/images/3_70_36.png)" class="s_nmenu" onclick="ShowMenu1('menu3')">
                                                                            ID Card</td>
                                                                        <td style="width: 3px; height: 50px"></td>
                                                                        <td style="background-image: url(../media/images/4_70_50.png)" class="s_omenu" onclick="ShowMenu1('menu4')">
                                                                            Promote</td>
                                                                        <td style="width: 3px; height: 50px"></td>
                                                                        <td style="background-image: url(../media/images/5_70_36.png)" class="s_nmenu" onclick="ShowMenu1('menu5')">
                                                                            Report</td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr id="menu44" style="DISPLAY: none; VISIBILITY: hidden">
                                                            <td align="left" style="height: 40px; width: 100%; background-color: #CC33FF; padding: 20px">
                                                                Promote
                                                            </td>
                                                        </tr>
                                                        <tr id="menu05" style="DISPLAY: none; VISIBILITY: hidden">
                                                            <td align="left" style="width: 100%">
                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                    <tr>
                                                                        <td style="background-image: url(../media/images/1_70_36.png)" class="s_nmenu" onclick="ShowMenu1('menu1')">
                                                                            SMS</td>
                                                                        <td style="width: 3px; height: 50px"></td>
                                                                        <td style="background-image: url(../media/images/2_70_36.png)" class="s_nmenu" onclick="ShowMenu1('menu2')">
                                                                            E-Mail</td>
                                                                        <td style="width: 3px; height: 50px"></td>
                                                                        <td style="background-image: url(../media/images/3_70_36.png)" class="s_nmenu" onclick="ShowMenu1('menu3')">
                                                                            ID Card</td>
                                                                        <td style="width: 3px; height: 50px"></td>
                                                                        <td style="background-image: url(../media/images/4_70_36.png)" class="s_nmenu" onclick="ShowMenu1('menu4')">
                                                                            Promote</td>
                                                                        <td style="width: 3px; height: 50px"></td>
                                                                        <td style="background-image: url(../media/images/5_70_50.png)" class="s_omenu" onclick="ShowMenu1('menu5')">
                                                                            Report</td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr id="menu55" style="DISPLAY: none; VISIBILITY: hidden">
                                                            <td align="left" style="height: 40px; width: 100%; background-color: #9933FF; padding: 20px">
                                                                Reports
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>--%>
                                            <tr>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr id="trmsg" runat="server" visible="false">
                                                            <td align="center" style="height: 40px; ">
                                                                <asp:Label ID="lblmsg" runat="server" CssClass="s_label"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr id="trgrid" runat="server">
                                                            <td valign="top" align="left">
                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                    <tr>
                                                                        <td align="left" id="paneltd">
                                                                            <div id="panelid" style="overflow:auto">
                                                                                <asp:DataGrid ID="dgemployee" runat="server" AutoGenerateColumns="False" BorderStyle="None" BorderWidth="0px" GridLines="None" 
                                                                                    ondeletecommand="dgemployee_DeleteCommand" 
                                                                                    oneditcommand="dgemployee_EditCommand" CellSpacing="1" CellPadding="3" >
                                                                                    <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                                                    <ItemStyle Font-Names="Verdana"  Height="25px" VerticalAlign="Top" CssClass="s_datagrid_item"/>
                                                                                    <Columns>
                                                                                        <asp:BoundColumn DataField="intID" HeaderText="ID" Visible="false"></asp:BoundColumn>
                                                                                        <asp:TemplateColumn >
                                                                                            <ItemTemplate>
                                                                                                <asp:CheckBox ID="chkselect" runat="server"/>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateColumn>
                                                                                        <asp:TemplateColumn >
                                                                                            <ItemTemplate>                                                            
                                                                                                <table cellpadding="3" cellspacing="0" border="0">
                                                                                                    <tr>
                                                                                                        <td style="width: 125px; height: 125px"  align="left" valign="top">
                                                                                                            <img src = "../images/staff/<%#DataBinder.Eval(Container.DataItem,"intid") %>.jpg" alt="photo" width="100" height="100" />
                                                                                                        </td>                                                                                 
                                                                                                        <td style="height: 125px" align="left">
                                                                                                            <table cellpadding="0" cellspacing="0" border="0" >
                                                                                                                <tr>
                                                                                                                    <td style="width: 125px; height: 25px" class="s_gridlabel">
                                                                                                                        Staff ID
                                                                                                                    </td>
                                                                                                                    <td style="width: 125px; height: 25px" class="s_gridlabel">
                                                                                                                        Department
                                                                                                                    </td>
                                                                                                                    <td style="width: 125px; height: 25px" class="s_gridlabel">
                                                                                                                        Name
                                                                                                                    </td>
                                                                                                                    <td style="width: 125px; height: 25px" class="s_gridlabel">
                                                                                                                        Home Class and Sec
                                                                                                                    </td>
                                                                                                                    <td style="width: 125px; height: 25px" class="s_gridlabel">
                                                                                                                        Teaching Subjects
                                                                                                                    </td>
                                                                                                                    <td style="width: 125px; height: 25px" class="s_gridlabel">
                                                                                                                        Class
                                                                                                                    </td>
                                                                                                                    <td style="width: 125px; height: 25px" class="s_gridlabel">
                                                                                                                        House phone
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td style="width: 125px; height: 25px" class="s_gridtext" valign="top">
                                                                                                                        <%# DataBinder.Eval(Container.DataItem, "intid") %>
                                                                                                                    </td>
                                                                                                                    <td style="width: 125px; height: 25px" class="s_gridtext" valign="top">
                                                                                                                        <%#DataBinder.Eval(Container.DataItem,"strdepartmentname") %>
                                                                                                                    </td>
                                                                                                                    <td style="width: 125px; height: 25px" class="s_gridtext" valign="top">
                                                                                                                        <%#DataBinder.Eval(Container.DataItem,"name") %>
                                                                                                                    </td>
                                                                                                                    <td style="width: 125px; height: 25px" class="s_gridtext" valign="top">
                                                                                                                        <%#DataBinder.Eval(Container.DataItem,"strhomeclass") %>
                                                                                                                    </td>
                                                                                                                    <td style="width: 125px; height: 25px" class="s_gridtext" valign="top">
                                                                                                                        <%#DataBinder.Eval(Container.DataItem, "strteachsubject")%>
                                                                                                                    </td>
                                                                                                                    <td style="width: 125px; height: 25px" class="s_gridtext" valign="top">
                                                                                                                        <%#DataBinder.Eval(Container.DataItem, "strteachclass")%>
                                                                                                                    </td>
                                                                                                                    <td style="width: 125px; height: 25px" class="s_gridtext" valign="top">
                                                                                                                        <%#DataBinder.Eval(Container.DataItem, "strPhone")%>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td style="width: 125px; height: 25px" class="s_gridlabel">
                                                                                                                        Staff Type
                                                                                                                    </td>
                                                                                                                    <td style="width: 125px; height: 25px" class="s_gridlabel">
                                                                                                                        Designation
                                                                                                                    </td>
                                                                                                                    <td style="width: 125px; height: 25px" class="s_gridlabel">
                                                                                                                        Father Name
                                                                                                                    </td>
                                                                                                                    <td style="width: 125px; height: 25px" class="s_gridlabel">
                                                                                                                        Gender
                                                                                                                    </td>
                                                                                                                    <td style="width: 125px; height: 25px" class="s_gridlabel">
                                                                                                                        Experience
                                                                                                                    </td>
                                                                                                                    <td style="width: 125px; height: 25px" class="s_gridlabel">
                                                                                                                        Cell No
                                                                                                                    </td>
                                                                                                                    <td style="width: 125px; height: 25px" class="s_gridlabel">
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td style="width: 125px; height: 25px" class="s_gridtext" valign="top">
                                                                                                                        <%#DataBinder.Eval(Container.DataItem,"strtype") %>
                                                                                                                    </td>
                                                                                                                    <td style="width: 125px; height: 25px" class="s_gridtext" valign="top">
                                                                                                                        <%#DataBinder.Eval(Container.DataItem,"strdesignation") %>
                                                                                                                    </td>
                                                                                                                    <td style="width: 125px; height: 25px" class="s_gridtext" valign="top">
                                                                                                                        <%#DataBinder.Eval(Container.DataItem, "strguardianname")%>
                                                                                                                    </td>
                                                                                                                    <td style="width: 125px; height: 25px" class="s_gridtext" valign="top">
                                                                                                                        <%#DataBinder.Eval(Container.DataItem,"strgender") %>
                                                                                                                    </td>
                                                                                                                    <td style="width: 125px; height: 25px" class="s_gridtext" valign="top">
                                                                                                                        <%#DataBinder.Eval(Container.DataItem,"intexpyear") %>Year(s) <%#DataBinder.Eval(Container.DataItem,"intexpmonth") %>Month(s)
                                                                                                                    </td>
                                                                                                                    <td style="width: 125px; height: 25px" class="s_gridtext" valign="top">
                                                                                                                        <%#DataBinder.Eval(Container.DataItem,"strmobile") %>
                                                                                                                    </td>
                                                                                                                    <td style="width: 125px; height: 25px" class="s_gridtext" valign="top">
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                            </table>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateColumn>
                                                                                        <asp:TemplateColumn HeaderText="View">
                                                                                            <ItemTemplate>
                                                                                                <asp:ImageButton ID="btnview" runat="server" ImageUrl="~/media/images/view.png" AlternateText="view" onclick="btnview_Click"/>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateColumn>
                                                                                        <asp:ButtonColumn CommandName="edit" HeaderText="Edit" Text="&lt;div style=&quot;width:25px;&quot;&gt;&lt;img src=&quot;../media/images/edit.gif&quot; alt=&quot;Edit&quot; border=&quot;0&quot; /&gt;&lt;/div&gt;" HeaderStyle-HorizontalAlign="center" Visible="false" >
                                                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                                        </asp:ButtonColumn>
                                                                                        <asp:ButtonColumn CommandName="delete" HeaderText="Del" Text="&lt;div style=&quot;width:25px;&quot;&gt;&lt;img src=&quot;../media/images/delete.gif&quot; alt=&quot;Delete&quot; border=&quot;0&quot; /&gt;&lt;/div&gt;" HeaderStyle-HorizontalAlign="center" Visible="false" >
                                                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                                        </asp:ButtonColumn>
                                                                                    </Columns>                                                
                                                                                    <HeaderStyle CssClass="s_datagrid_header" />
                                                                                </asp:DataGrid>
                                                                            </div>
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
                <uc6:app_footer ID="app_footer" runat="server" />
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
