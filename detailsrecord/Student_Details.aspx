<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Student_Details.aspx.cs" Inherits="school_Student_Details" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>

<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>

<%@ Register src="../usercontrol/detailsrecord_student.ascx" tagname="detailsrecord_student" tagprefix="uc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit.HTMLEditor" tagprefix="cc2" %>

<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>

<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>

<%@ Register src="../usercontrol/footer.ascx" tagname="app_footer" tagprefix="uc6" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"><html xmlns="http://www.w3.org/1999/xhtml"><head id="Head1" runat="server"><meta http-equiv="Content-Type" content="text/html; charset=utf-8" /><title>
    The Schools.in - Admin</title>
    <link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/layout.css" media="screen" rel="stylesheet" type="text/css" />
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

	        if (MenuID == 'menu1') 
	        {
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

	        if (MenuID == 'menu2') 
	        {
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
	        if (MenuID == 'menu3') 
	        {
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

	        if (MenuID == 'menu4') 
	        {
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

	        if (MenuID == 'menu5') 
	        {
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
            var assignwidth = document.getElementById("mwidth").style.width = currentwidth + "px";
            var assignwidth1 = document.getElementById("container").style.width = currentwidth + "px";
            var panelwidth = document.getElementById("paneltd").style.width = currentwidth + "px";
            var panelwidth1 = document.getElementById("panelid").style.width = currentwidth + "px";
            var searchtable = document.getElementById("searchtable").style.width = currentwidth + "px";
            //alert(panelwidth);
        }
    </script>
</head>
<body onload="autowidth();" >
    <form id="form1" runat="server">
    <div>
        <ajaxtoolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </ajaxtoolkit:ToolkitScriptManager>
        <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
        <table cellpadding="0" cellspacing="0" border="0" width="100%">
            <tr>
                <td style="width: 100%;" align="left">
                    <uc3:topbanner ID="topbanner1" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="width: 100%; " valign="top">
                    <uc2:topmenu ID="topmenu1" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="width: 100%;" align="left" valign="top">
                  
                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                            <tr>
                                <td style="width: 5%" valign="top">
                                    <table cellpadding="0" cellspacing="0" border="0" width="230">
                                        <tr id="trsidemenu" runat="server">
                                            <td style="width: 230px" align="right">
                                                <uc1:detailsrecord_student ID="detailsrecord_student1" runat="server" />
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
                                        <tr><td style="height:40px"></td></tr>
                                    </table>
                                </td>
                                <td style="width:2%" valign="top">
                                </td>
                                <td style="width: 93%" valign="top" align="left">
                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                         <tr class="app_container_title">
                                            <td style="width: 100%; " align="left">
                                                <table cellpadding="0" cellspacing="0" border="0" >
                                                    <tr>
                                                        <td class="app_cont_title_img_td"><img src="../images/icons/50X50/17.png" class="app_cont_title_img" alt="icon" /></td>
                                                        <td align="left" >Search/View Student Details</td>                                                                                                                                   
                                                    </tr>
                                                </table>                                                   
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="break"></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%; height: 50px" align="center" id="mwidth">
                                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                    <tr >
                                                        <td align="left">
                                                            <table cellpadding="0" cellspacing="0" border="0" id="searchtable" class="thick_curve" style="margin-left:5px;">
                                                                <tr class="view_detail_subtitle_bg">
                                                                    <td colspan="6" style="width: 230px; height: 30px" align="left">&nbsp;&nbsp;
                                                                        <asp:Label ID="Label4" runat="server" CssClass="subtitle_label" 
                                                                            Text="Search"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="6">
                                                                        <table cellpadding="7" cellspacing="0" border="0" width="100%">
                                                                            <tr>                                                                 
                                                                                <td style="height: 50px" align="left">
                                                                                    <asp:Label ID="Label" runat="server" CssClass="s_label" Text="Class"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlstandard" runat="server" CssClass="s_dropdown" Width="105px" AutoPostBack="True" onselectedindexchanged="ddlstandard_SelectedIndexChanged">
                                                                                    </asp:DropDownList>
                                                                                </td>                                                          
                                                                                <td style="height: 50px" align="left">
                                                                                    <asp:Label runat="server" ID="lbl" Text="Section" CssClass="s_label"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlsection" runat="server" CssClass="s_dropdown" Width="75px" AutoPostBack="True" onselectedindexchanged="ddlsection_SelectedIndexChanged">
                                                                                    </asp:DropDownList>
                                                                                </td>                                                               
                                                                                <td style="height: 50px" align="left">
                                                                                    <asp:Label runat="server" ID="lblg" Text="Student name" CssClass="s_label"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtname" runat="server" CssClass="s_textbox" AutoPostBack="true" Width="250px"
                                                                                        ontextchanged="txtname_TextChanged"></asp:TextBox>
                                                                                    <ajaxtoolkit:AutoCompleteExtender runat="server" ID="autocomplete1" TargetControlID="txtname"  
                                                                                     ServiceMethod="Getstudentname" MinimumPrefixLength="1" EnableCaching="true" ServicePath="~/WebService.asmx"
                                                                                     CompletionSetCount="10" UseContextKey="true" CompletionInterval="500"></ajaxtoolkit:AutoCompleteExtender>
                                                                                </td>
                                                                            </tr>    
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr id="trtag" runat="server">
                                                                    <td colspan="0">
                                                                        <table cellpadding="0" cellspacing="0" width="100%">  
                                                                            <tr class="view_detail_subtitle_bg">
                                                                                <td colspan="6" style="width: 230px; height: 30px" align="left">&nbsp;&nbsp;
                                                                                    <asp:Label ID="Label1" runat="server" CssClass="subtitle_label" 
                                                                                        Text="Sort By"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 115px; height: 30px" align="left">&nbsp;&nbsp;
                                                                                    <asp:Label ID="Label2" runat="server" CssClass="s_label" Text="Admission No"></asp:Label>
                                                                                </td>
                                                                                <td style="width: 115px; height: 30px" align="left">
                                                                                    <asp:TextBox ID="txtadmissionno" runat="server" CssClass="s_textbox" AutoPostBack="true"
                                                                                        ontextchanged="txtadmissionno_TextChanged" ></asp:TextBox>
                                                                                    <ajaxtoolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txtadmissionno" UseContextKey="true"
                                                                                     EnableCaching="true" MinimumPrefixLength="1" CompletionInterval="500" CompletionSetCount="10"
                                                                                     ServiceMethod="GetAdmissionNo" ServicePath="~/WebService.asmx"></ajaxtoolkit:AutoCompleteExtender>
                                                                                </td>
                                                                                <td style="width: 115px; height: 30px" align="left">&nbsp;&nbsp;
                                                                                    <asp:Label ID="Label5" runat="server" CssClass="s_label" Text="Gender"></asp:Label>
                                                                                </td>
                                                                                <td style="width: 115px; height: 30px" align="left">
                                                                                    <asp:DropDownList ID="searchbygender" runat="server" CssClass="s_dropdown" 
                                                                                        Width="115px" AutoPostBack="True" onselectedindexchanged="searchbygender_SelectedIndexChanged">
                                                                                        <asp:ListItem Value="0" Text="All"></asp:ListItem>
                                                                                        <asp:ListItem Value="Male" Text="Male"></asp:ListItem>
                                                                                        <asp:ListItem Value="Female" Text="Female"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                                <td style="width: 115px; height: 30px" align="left">&nbsp;&nbsp;
                                                                                    <asp:Label ID="Label6" runat="server" CssClass="s_label" Text="Transport"></asp:Label>
                                                                                </td>
                                                                                <td style="width: 115px; height: 30px" align="left">
                                                                                    <asp:DropDownList ID="searchbytransport" runat="server" CssClass="s_dropdown" 
                                                                                        Width="115px" AutoPostBack="True" 
                                                                                        onselectedindexchanged="searchbytransport_SelectedIndexChanged">
                                                                                        <asp:ListItem>All</asp:ListItem>
                                                                                        <asp:ListItem>School Transport</asp:ListItem>
                                                                                        <asp:ListItem>Own</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 115px; height: 30px" align="left">&nbsp;&nbsp;
                                                                                    <asp:Label ID="Label7" runat="server" CssClass="s_label" Text="Accomodation"></asp:Label>
                                                                                </td>
                                                                                <td style="width: 115px; height: 30px" align="left">
                                                                                    <asp:DropDownList ID="searchbyhostler" runat="server" CssClass="s_dropdown" 
                                                                                        Width="115px" AutoPostBack="True" onselectedindexchanged="searchbyhostler_SelectedIndexChanged">
                                                                                       <asp:ListItem Value="-1" Text="All"></asp:ListItem>
                                                                                        <asp:ListItem Value="1" Text="Hostler"></asp:ListItem>
                                                                                        <asp:ListItem Value="0" Text="Dayscholor"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                                <%--<td style="width: 115px; height: 30px" align="left">&nbsp;&nbsp;
                                                                                    <asp:Label ID="Label8" runat="server" CssClass="s_label" Text="Community"></asp:Label>
                                                                                </td>
                                                                                <td style="width: 115px; height: 30px" align="left">
                                                                                    <asp:DropDownList ID="searchbycommunity" runat="server" CssClass="s_dropdown" Width="115px" AutoPostBack="True" 
                                                                                        onselectedindexchanged="searchbycommunity_SelectedIndexChanged"> 
                                                                                         <asp:ListItem Value="0" Text="All"></asp:ListItem>
                                                                                        <asp:ListItem Value="FC">FC</asp:ListItem>
                                                                                        <asp:ListItem Value="BC">BC</asp:ListItem>                                                        
                                                                                        <asp:ListItem Value="BC">MBC</asp:ListItem>                                                        
                                                                                        <asp:ListItem Value="OBC">OBC</asp:ListItem>
                                                                                        <asp:ListItem Value="OC">OC</asp:ListItem>
                                                                                        <asp:ListItem Value="SC/ST">SC/ST</asp:ListItem>
                                                                                        <asp:ListItem Value="Others">Others</asp:ListItem>                                                       
                                                                                    </asp:DropDownList>
                                                                                </td>--%>
                                                                                <td style="width: 115px; height: 30px" align="left">&nbsp;&nbsp;
                                                                                    <asp:Label ID="Label9" runat="server" CssClass="s_label" Text="Religion"></asp:Label>
                                                                                </td>
                                                                                <td style="width: 115px; height: 30px" align="left">
                                                                                    <asp:DropDownList ID="searchbyreligion" runat="server" CssClass="s_dropdown" 
                                                                                        Width="115px" AutoPostBack="True" 
                                                                                        onselectedindexchanged="searchbyreligion_SelectedIndexChanged">
                                                                                         <asp:ListItem Value="0" Text="All"></asp:ListItem>
                                                                                        <asp:ListItem Value="Hindu" >Hindu</asp:ListItem>
                                                                                        <asp:ListItem Value="Muslim">Muslim</asp:ListItem>
                                                                                        <asp:ListItem Value="Christian">Christian</asp:ListItem>
                                                                                        <asp:ListItem Value="Others">Others</asp:ListItem>                                                                                        
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                                <td style="width: 115px; height: 30px" align="left">&nbsp;&nbsp;
                                                                                    <asp:Label ID="Label10" runat="server" CssClass="s_label" Text="Birthday"></asp:Label>
                                                                                </td>
                                                                                <td style="width: 115px; height: 30px" align="left">
                                                                                    <asp:DropDownList ID="searchbybirthday" runat="server" CssClass="s_dropdown" 
                                                                                        Width="115px" AutoPostBack="True" 
                                                                                        onselectedindexchanged="searchbybirthday_SelectedIndexChanged">                                                                           
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 115px; height: 30px" align="left">
                                                                                    &nbsp;&nbsp;
                                                                                    <asp:Label ID="Label12" runat="server" CssClass="s_label" Text="Blood Group"></asp:Label>
                                                                                </td>
                                                                                <td style="width: 115px; height: 30px" align="left">
                                                                                    <asp:DropDownList ID="searchbyblood" runat="server" AutoPostBack="True" 
                                                                                        CssClass="s_dropdown" 
                                                                                        onselectedindexchanged="searchbyblood_SelectedIndexChanged" Width="115px">
                                                                                        <asp:ListItem Text="All" Value="0"></asp:ListItem>
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
                                                                                <td style="width: 115px; height: 30px" align="left">&nbsp;&nbsp;
                                                                                    <asp:Label ID="Label13" runat="server" CssClass="s_label" Text="House"></asp:Label>
                                                                                </td>
                                                                                <td style="width: 115px; height: 30px" align="left">
                                                                                    <asp:DropDownList ID="searchbyhouse" runat="server" CssClass="s_dropdown" 
                                                                                        Width="115px" AutoPostBack="True" 
                                                                                        onselectedindexchanged="searchbyhouse_SelectedIndexChanged">                                                                      
                                                                                    </asp:DropDownList>
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
                                                    <tr>
                                                        <td style="width: 100%; height: 100px; padding-left: 5px" valign="top" align="left" id="container">
                                                            <table cellpadding="0" cellspacing="0" border="0" class="app_container"  >
                                                                <tr class="view_detail_title_bg" >
                                                                    <td align="left" >
                                                                       <asp:Label CssClass="title_label" ID="lbltit" runat="server" Text="Student's Details" ></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <%--<tr id="menu00" style="DISPLAY: block; VISIBILITY: visible" runat="server">
                                                                    <td align="left" style="width: 100%">
                                                                        <table cellpadding="0" cellspacing="0" border="0">
                                                                            <tr>
                                                                                <td style="background-image: url(../media/images/1_70_36.png)" class="s_nmenu" onclick="ShowMenu1('menu1')">
                                                                                    SMS</td>
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
                                                                    <table cellpadding="5" cellspacing="0" border="0" class="curve" style="margin:10px;height: 40px; width: 100%">
                                                                            <tr class="s_datagrid_header">
                                                                                <td  style="height: 30px" align="left" colspan="3"><asp:Label ID="Label18" runat="server" CssClass="s_label" ForeColor="White">Send SMS</asp:Label></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 150px; height: 30px">
                                                                                    <asp:Label ID="Label14" runat="server" CssClass="s_label" Text="Message"></asp:Label>
                                                                                </td>
                                                                                <td colspan="2" style="width: 250px; height: 30px">
                                                                                    <asp:TextBox ID="txtmessage" runat="server" Height="100px" TextMode="MultiLine" 
                                                                                        Width="240px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 150px; height: 40px">
                                                                                    &nbsp;</td>
                                                                                <td style="width: 150px; height: 40px">
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
                                                                        <table cellpadding="5" cellspacing="0" border="0" width="749" class="curve" style="margin:10px;height: 40px; width:500px">
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
                                                                                    <asp:Label ID="Label3" runat="server" CssClass="s_label" Text="Message"></asp:Label>
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
                                                                    </td>
                                                                    <td align="left" style="height: 40px; width: 100%; background-color: #CC3333; padding: 20px">
                                                                        E-Mail
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
                                                                </tr>--%>
                                                                <tr id="trmsg" runat="server" visible="false">
                                                                    <td align="center" style="height: 40px; width: 100%">
                                                                        <asp:Label ID="lblmsg" runat="server" CssClass="s_label"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center" style="height:100px;" id="paneltd">
                                                                    <div ID="panelid" runat="server" style="overflow:auto">
                                                                        <asp:DataGrid ID="dgstudetails" runat="server" AutoGenerateColumns="False" Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None" ondeletecommand="dgstudetails_DeleteCommand" oneditcommand="dgstudetails_EditCommand" CellSpacing="1" CellPadding="3">
                                                                        <AlternatingItemStyle Font-Size="11px" BackColor="White"/>
                                                                        <ItemStyle CssClass="s_datagrid_item"/>
                                                                        <Columns>
                                                                        <asp:BoundColumn DataField="intID" HeaderText="ID" Visible="false"></asp:BoundColumn>
                                                                        <asp:TemplateColumn>
                                                                            <ItemTemplate>
                                                                                <asp:CheckBox ID="chkselect" runat="server"/>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn>
                                                                            <ItemTemplate>                                                            
                                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                                    <tr>
                                                                                        <td rowspan="2">
                                                                                            <table cellpadding="0" cellspacing="0" border="0" width="125">
                                                                                                <tr>
                                                                                                    <td style="width: 125px; height:100px" valign="top" align="left">
                                                                                                    <img src = "../images/student/<%#DataBinder.Eval(Container.DataItem,"intid") %>.jpg" alt="photo" width="100" height="100" />
                                                                                                    </td>
                                                                                                    </tr>                                                                           
                                                                                            </table>
                                                                                        </td>
                                                                                        <td colspan="8">
                                                                                            <table cellpadding="0" cellspacing="0" border="0" >
                                                                                                <tr valign="top">                                                                    
                                                                                                    <td valign="top">                                                                    
                                                                                                        <table cellpadding="0" cellspacing="0" border="0" width="130">
                                                                                                          <tr>
                                                                                                                <td style=" height: 30px"  align="left" class="s_gridlabel">Admission No</td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td style=" height: 30px" class="s_gridtext" align="left"><%#DataBinder.Eval(Container.DataItem,"intadmitno") %></td>
                                                                                                            </tr>    
                                                                                                                                                                                                                                                                  
                                                                                                        </table>
                                                                                                    </td>
                                                                                                    <td valign="top">
                                                                                                        <table cellpadding="0" cellspacing="0" border="0" width="130px">
                                                                                                            <tr>
                                                                                                                <td style=" height: 30px" class="s_gridlabel" align="left">Name</td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td style=" height: 30px" class="s_gridtext" align="left"><%#DataBinder.Eval(Container.DataItem,"name") %></td>
                                                                                                            </tr>                                                                            
                                                                                                        </table>
                                                                                                    </td>
                                                                                                    <td valign="top">
                                                                                                        <table cellpadding="0" cellspacing="0" border="0" width="90px">
                                                                                                            <tr>
                                                                                                                <td style=" height: 30px" class="s_gridlabel" align="left">Class</td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td style=" height: 30px" class="s_gridtext" align="left"><%#DataBinder.Eval(Container.DataItem, "strstandard")%></td>
                                                                                                            </tr>                                                                            
                                                                                                        </table>
                                                                                                    </td>
                                                                                                    <td  valign="top">
                                                                                                        <table cellpadding="0" cellspacing="0" border="0" width="90px">
                                                                                                            <tr>
                                                                                                                <td style=" height: 30px" class="s_gridlabel" align="left">DOB:</td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td style=" height: 30px" class="s_gridtext" align="left"><%#DataBinder.Eval(Container.DataItem,"strdateofbirth") %></td>
                                                                                                            </tr>                                                                            
                                                                                                        </table>
                                                                                                    </td>                                                          
                                                                                                    <td  valign="top">
                                                                                                        <table cellpadding="0" cellspacing="0" border="0" width="90">
                                                                                                            <tr>
                                                                                                                <td style=" height: 30px" class="s_gridlabel" align="left">House Phone</td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td style="height: 30px" class="s_gridtext" align="left"><%#DataBinder.Eval(Container.DataItem, "strphone")%></td>
                                                                                                            </tr>                                                                            
                                                                                                         </table>
                                                                                                    </td>
                                                                                                    <td  valign="top">
                                                                                                        <table cellpadding="0" cellspacing="0" border="0" width="110px">
                                                                                                            <tr>
                                                                                                                <td style=" height: 30px" class="s_gridlabel" align="left">Parent Phone</td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td style=" height: 30px" class="s_gridtext" align="left"><%#DataBinder.Eval(Container.DataItem,"fathermobileno") %></td>
                                                                                                            </tr>                                                                            
                                                                                                        </table>                                                                        
                                                                                                    </td>
                                                                                                    <td  valign="top" >
                                                                                                        <table cellpadding="0" cellspacing="0" border="0" >
                                                                                                            <tr>
                                                                                                                <td style=" height: 30px" class="s_gridlabel" align="left">Address</td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td style="height: 30px" class="s_gridtext" align="left"><%#DataBinder.Eval(Container.DataItem,"strresidanceaddress") %></td>
                                                                                                            </tr>                                                                            
                                                                                                        </table>
                                                                                                    </td>                                                                                                                                              
                                                                                                    </tr>
                                                                                                    <tr valign="top">
                                                                                                    <td valign="top">
                                                                                                        <table cellpadding="0" cellspacing="0" border="0" width="130">                                                                            
                                                                                                             <tr>
                                                                                                                <td style=" height: 30px" class="s_gridlabel" align="left">Father's Name</td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td style=" height: 30px" class="s_gridtext" align="left"><%#DataBinder.Eval(Container.DataItem,"strfatherorguardname") %></td>
                                                                                                            </tr>                                                                      
                                                                                                        </table>
                                                                                                    </td>
                                                                                                    <td valign="top">
                                                                                                        <table cellpadding="0" cellspacing="0" border="0" width="110px">
                                                                                                            <tr>
                                                                                                                <td style=" height: 30px" class="s_gridlabel" align="left">Sec</td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td style=" height: 30px" class="s_gridtext" align="left"><%#DataBinder.Eval(Container.DataItem, "strsection")%></td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                    <td valign="top">
                                                                                                        <table cellpadding="0" cellspacing="0" border="0" width="90px">
                                                                                                           <tr>
                                                                                                                <td style=" height: 30px" class="s_gridlabel" align="left">Gender</td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td style=" height: 30px" class="s_gridtext" align="left"><%#DataBinder.Eval(Container.DataItem,"strgender") %></td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                    <td valign="top">
                                                                                                        <table cellpadding="0" cellspacing="0" border="0" width="90px">                                                                            
                                                                                                             <tr>
                                                                                                                <td style=" height: 30px" class="s_gridlabel" align="left">Cell No</td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td style="height: 30px" class="s_gridtext" align="left"><%#DataBinder.Eval(Container.DataItem,"strmobile") %></td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                    <td valign="top">
                                                                                                        <table cellpadding="0" cellspacing="0" border="0" width="110">                                                                           
                                                                                                             <tr>
                                                                                                                <td style=" height: 30px" class="s_gridlabel" align="left">User Name</td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td style=" height: 30px" class="s_gridtext" align="left"><%#DataBinder.Eval(Container.DataItem,"strstudentusername") %></td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                    <td valign="top">
                                                                                                        <table cellpadding="0" cellspacing="0" border="0" width="110px">                                                                           
                                                                                                          <tr>
                                                                                                                <td style="height: 30px" class="s_gridlabel" align="left">Blood Group</td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td style="height: 30px" class="s_gridtext" align="left"><%#DataBinder.Eval(Container.DataItem, "strbloodgroup")%></td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>                                                                 
                                                                                                    <td valign="top">
                                                                                                        <table cellpadding="0" cellspacing="0" border="0" >                                                                            
                                                                                                            <%--<tr>
                                                                                                                <td style=" height: 30px" class="s_gridlabel" align="left">Roll No</td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td style=" height: 30px" class="s_gridtext" align="left"><%# DataBinder.Eval(Container.DataItem, "introllno") %></td>
                                                                                                            </tr>  --%>  
                                                                                                        </table>
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
                                                                        <asp:ButtonColumn Visible="false" CommandName="edit" HeaderText="Edit" Text="&lt;img src=&quot;../media/images/edit.gif&quot; alt=&quot;Edit&quot; border=&quot;0&quot; /&gt;" HeaderStyle-HorizontalAlign="Right" >                                                                                            
                                                                            <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                                                        </asp:ButtonColumn>
                                                                        <asp:ButtonColumn Visible="false" CommandName="delete" HeaderText="Delete" Text="&lt;img src=&quot;../media/images/delete.gif&quot; alt=&quot;Delete&quot; border=&quot;0&quot; /&gt;">                                                                                                                
                                                                        </asp:ButtonColumn>
                                                                        </Columns>                                                
                                                                        <HeaderStyle Font-Bold="True" Font-Names="Verdana" Font-Size="12px" 
                                                                                ForeColor="White" Height="30px" CssClass="s_datagrid_header" />
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
                                        <tr>
                                            <td class="break"></td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="height: 10px; width: 100%">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                     
                </td>
            </tr>
            <tr>
                <td style="width: 100%; height: 50px" align="left" valign="top" class="footer">
                    <uc6:app_footer ID="app_footer" runat="server" />
                </td>
            </tr>
        </table>
        <cc1:MsgBox id="msgbox" runat="server"></cc1:MsgBox>
    </div>
    </form>
</body>
</html>
