<%@ Page Language="C#" AutoEventWireup="true" CodeFile="view_studentdetails.aspx.cs" Inherits="detailsrecord_view_studentdetails" %>


<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>

<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>

<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

<%@ Register src="../usercontrol/detailsrecord_student.ascx" tagname="detailsrecord_student" tagprefix="uc1" %>

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
        function autowidth() {
            var screenW = 640, screenH = 480;
            if (parseInt(navigator.appVersion) > 3) {
                screenW = screen.width;
                currentwidth = screenW - 300;
            }
            var assignwidth = document.getElementById("mwidth").style.width = currentwidth + "px";
            var panelwidth = document.getElementById("paneltd").style.width = currentwidth + "px";
            var panelwidth1 = document.getElementById("panelid").style.width = currentwidth + "px";
            var searchtable = document.getElementById("searchtable").style.width = currentwidth + "px";
            //alert(panelwidth);
        }
    </script>
</head>
<body onload="autowidth();">
    <form id="form1" runat="server">
    <div>
    <ajaxtoolkit:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server">
    </ajaxtoolkit:toolkitscriptmanager>
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
                                <tr id="trsidemenu1" runat="server">
                                    <td style="width: 230px" align="right">
                                        <uc1:detailsrecord_student ID="detailsrecord_student1" runat="server" />
                                    </td>
                                </tr>
                                <tr id="trsidemenu2" runat="server">
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
                        <td style="width:1%" valign="top">
                        </td>
                        <td style="width: 94%" valign="top" align="left">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr class="app_container_title">
                                    <td style="width: 100%; " align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" >
                                            <tr>
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/17.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left" > Student View Details</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 8px; background-image: url(../media/images/bline.jpg)"></td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td style="padding-left: 5px" valign="top" align="left">
                                        <table cellpadding="7" cellspacing="0" border="0" class="app_container">
                                            <tr class="view_detail_title_bg" >
                                                <td align="left" colspan="3">
                                                   <asp:Label CssClass="title_label" ID="lbltit" runat="server" Text="Student Details" ></asp:Label>
                                                </td>
                                                <td style="width: 150px">
                                                <asp:Button ID="btnedit" runat="server" onclick="btnedit_Click" Text="Edit" 
                                                CssClass="s_button" />
                                                    &nbsp;<asp:Button ID="btnback" runat="server" Text="Back" 
                                                CssClass="s_button" onclick="btnback_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 1px" align="left" colspan="4"></td>
                                            </tr>
                                            <tr>
                                                <td style="height: 50px" align="left" colspan="4">
                                                    <img src = "../images/student/<%Response.Write(lblid.Text); %>.jpg" alt="photo" width="100" height="100" />
                                                    <asp:Label ID="lblid" runat="server" CssClass="s_label" Visible="False"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr class="view_detail_subtitle_bg">
                                                <td style="height: 25px" align="left" colspan="4">
                                                    <asp:Label ID="Label21" runat="server" CssClass="s_label" 
                                                        Text="Personal Details" Font-Bold="True"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:Label ID="Label22" runat="server" CssClass="s_label" Text="Name"></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    
                                                    <asp:Label ID="lblname" runat="server" CssClass="s_label_value"></asp:Label>
                                                    
                                                </td>                                                    
                                                <td style="width: 120px; height: 40px" align="left">
                                                    <asp:Label ID="Label1" runat="server" CssClass="s_label" Text="Gender"></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:Label ID="lblgender" runat="server" CssClass="s_label_value"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 200px; height: 40px;" align="left">
                                                    <asp:Label ID="Label4" runat="server" CssClass="s_label" Text="Date of Birth"></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:Label ID="lbldob" runat="server" CssClass="s_label_value"></asp:Label>
                                                    </td>                                                    
                                                <td style="width: 120px; height: 40px" align="left">
                                                    <asp:Label ID="Label13" runat="server" CssClass="s_label" Text="Age"></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:Label ID="lblage" runat="server" CssClass="s_label_value"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 200px; height: 40px;" align="left">
                                                    <asp:Label ID="Label14" runat="server" CssClass="s_label" Text="Birth/Passport/IC No"></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:Label ID="lblbirthno" runat="server" CssClass="s_label_value"></asp:Label>
                                                    </td>                                                    
                                                <td style="width: 120px; height: 40px" align="left">
                                                   
                                                    <asp:Label ID="Label29" runat="server" CssClass="s_label" Text="Admission No"></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:Label ID="lbladmissionno" runat="server" CssClass="s_label_value"></asp:Label></td>
                                            </tr>
                                            <tr id="trroll" runat="server">
                                                <td align="left">
                                                    <asp:Label ID="Label2" runat="server" CssClass="s_label" Text="Roll No"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblrollno" runat="server" CssClass="s_label_value"></asp:Label>
                                                </td>
                                               
                                                <td align="left">
                                               <asp:Label ID="Label26" runat="server" CssClass="s_label" Text="Student Passport/IC No"></asp:Label>
                                                    &nbsp;</td>
                                                <td align="left">
                                               <asp:Label ID="lblstudentpassport" runat="server" CssClass="s_label_value"></asp:Label>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label30" runat="server" CssClass="s_label" 
                                                        Text="Date of Admission"></asp:Label>
                                                </td>
                                                <td align="left" class="style1">
                                                    <asp:Label ID="lbldateofadmiss" runat="server" CssClass="s_label_value"></asp:Label>
                                                </td>
                                               
                                                <td align="left">
                                                    <asp:Label ID="Label36" runat="server" CssClass="s_label" Text="Religion"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblreligion" runat="server" CssClass="s_label_value"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label31" runat="server" CssClass="s_label" Text="Standard"></asp:Label>
                                                </td>
                                                <td align="left" class="style1">
                                                    <asp:Label ID="lblstandard" runat="server" CssClass="s_label_value"></asp:Label>
                                                </td>
                                               
                                                <td align="left">
                                                    <asp:Label ID="Label37" runat="server" CssClass="s_label" Text="Section"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblsection" runat="server" CssClass="s_label_value"></asp:Label>
                                                </td>
                                            </tr>
                                            <%--<tr>
                                                <td align="left">
                                                    <asp:Label ID="Label32" runat="server" CssClass="s_label" Text="Community"></asp:Label>
                                                </td>
                                                <td align="left" class="style1">
                                                    <asp:Label ID="lblcommunity" runat="server" CssClass="s_label"></asp:Label>
                                                </td>
                                               
                                                <td align="left">
                                                    <asp:Label ID="Label38" runat="server" CssClass="s_label" Text="Caste"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblcaste" runat="server" CssClass="s_label"></asp:Label>
                                                </td>
                                            </tr>--%>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label33" runat="server" CssClass="s_label" Text="Nationality"></asp:Label>
                                                </td>
                                                <td align="left" class="style1">
                                                    <asp:Label ID="lblnationality" runat="server" CssClass="s_label_value"></asp:Label>
                                                </td>
                                               
                                                <td align="left">
                                                    <asp:Label ID="Label39" runat="server" CssClass="s_label" Text="Address"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lbladdrs" runat="server" CssClass="s_label_value"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label34" runat="server" CssClass="s_label" Text="Country"></asp:Label>
                                                </td>
                                                <td align="left" class="style1">
                                                    <asp:Label ID="lblpcountry" runat="server" CssClass="s_label_value"></asp:Label>
                                                </td>
                                               
                                                <td align="left">
                                                    <asp:Label ID="Label40" runat="server" CssClass="s_label" Text="State"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblpstate" runat="server" CssClass="s_label_value"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label35" runat="server" CssClass="s_label" Text="City"></asp:Label>
                                                </td>
                                                <td align="left" class="style1">
                                                    <asp:Label ID="lblpcity" runat="server" CssClass="s_label_value"></asp:Label>
                                                </td>
                                               
                                                <td align="left">
                                                    <asp:Label ID="Label41" runat="server" CssClass="s_label" Text="Zipcode"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblzip" runat="server" CssClass="s_label_value"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label42" runat="server" CssClass="s_label" Text="Mobile Number"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblpmobile" runat="server" CssClass="s_label_value"></asp:Label>
                                                </td>
                                               
                                                <td align="left">
                                                    <asp:Label ID="Label43" runat="server" CssClass="s_label" 
                                                        Text="Residence Phone No"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblphoneno" runat="server" CssClass="s_label_value"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr class="view_detail_subtitle_bg">
                                                <td style="height: 25px" align="left" colspan="4">
                                                    <asp:Label ID="Label23" runat="server" CssClass="s_label" 
                                                        Text="Parents Details" Font-Bold="True"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr id="Ftag" runat="server">
                                                <td colspan="4">
                                                    <table width="100%">
                                                        <tr>
                                                            <td style="width: 180px; height: 40px" align="left">
                                                                <asp:Label ID="Label24" runat="server" CssClass="s_label" 
                                                                    Text="Father Name"></asp:Label>
                                                            </td>
                                                            <td style="width: 220px; height: 40px" align="left">
                                                                <asp:Label ID="lblfathername" runat="server" CssClass="s_label_value"></asp:Label>
                                                            </td>
                                                            
                                                            <td style="width: 120px; height: 40px" align="left">
                                                                <asp:Label ID="Labelstate" runat="server" CssClass="s_label" 
                                                                    Text="Father Occupation"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                &nbsp;&nbsp;<asp:Label ID="lblfatheroccupation" runat="server" CssClass="s_label_value"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 180px; height: 40px" align="left">
                                                                <asp:Label ID="Label25" runat="server" CssClass="s_label" 
                                                                    Text="Father Designation"></asp:Label>
                                                            </td>
                                                            <td style="width: 220px; height: 40px" align="left">
                                                                <asp:Label ID="lbldesig" runat="server" CssClass="s_label_value"></asp:Label>
                                                            </td>
                                                           
                                                            <td style="width: 120px; height: 40px" align="left">
                                                                <asp:Label ID="Label44" runat="server" CssClass="s_label" 
                                                                    Text="Organisation Name"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                &nbsp;&nbsp;<asp:Label ID="lblorgname" runat="server" CssClass="s_label_value"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 180px; height: 40px" align="left">
                                                                <asp:Label ID="Label45" runat="server" CssClass="s_label" Text="Work Address"></asp:Label>
                                                            </td>
                                                            <td style="width: 220px; height: 40px" align="left">
                                                                <asp:Label ID="lblworkadds" runat="server" CssClass="s_label_value"></asp:Label>
                                                            </td>
                                                            
                                                            <td style="width: 120px; height: 40px" align="left">
                                                                <asp:Label ID="Label85" runat="server" CssClass="s_label" Text="Country"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                &nbsp;&nbsp;<asp:Label ID="lblcountry" runat="server" CssClass="s_label_value"></asp:Label></td>
                                                       </tr>
                                                        <tr>
                                                            <td style="width: 180px; height: 40px" align="left">
                                                                <asp:Label ID="Label86" runat="server" CssClass="s_label" Text="State"></asp:Label>
                                                            </td>
                                                            <td style="width: 220px; height: 40px; font-size:13px" align="left">
                                                                <asp:Label ID="lblstate" runat="server" CssClass="s_label_value"></asp:Label>
                                                            </td>
                                                            
                                                            <td style="width: 120px; height: 40px" align="left">
                                                                <asp:Label ID="Label87" runat="server" CssClass="s_label" Text="City"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">                                                    
                                                                &nbsp;&nbsp;<asp:Label ID="lblcity" runat="server" CssClass="s_label_value"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 180px; height: 40px" align="left">
                                                                <asp:Label ID="lblzip0" runat="server" CssClass="s_label">Zipcode</asp:Label>
                                                            </td>
                                                            <td style="width: 220px; height: 40px; font-size:13px" align="left">
                                                                <asp:Label ID="lblzipcode" runat="server" CssClass="s_label_value"></asp:Label>
                                                            </td>
                                                            
                                                            <td style="width: 120px; height: 40px" align="left">
                                                                <asp:Label ID="Label52" runat="server" CssClass="s_label" 
                                                                    Text="Father Mobile Number"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">                                                    
                                                                &nbsp;&nbsp;<asp:Label ID="lblfathermobile" runat="server" CssClass="s_label_value"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 180px; height: 40px" align="left">
                                                                <asp:Label ID="Label8" runat="server" CssClass="s_label">Father office number</asp:Label>
                                                            </td>
                                                            <td style="width: 220px; height: 40px; font-size:13px" align="left">
                                                                <asp:Label ID="lblFofficenumber" runat="server" CssClass="s_label_value"></asp:Label>
                                                            </td>
                                                            
                                                            <td style="width: 120px; height: 40px" align="left">
                                                                <asp:Label ID="Label10" runat="server" CssClass="s_label" 
                                                                    Text="Father email"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">                                                    
                                                                &nbsp;&nbsp;<asp:Label 
                                                                    ID="lblFemail" runat="server" CssClass="s_label_value"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 180px; height: 40px" align="left">
                                                               <asp:Label ID="Label111" runat="server" CssClass="s_label" Text="Parent Passport or I.C No"></asp:Label>
                                                            </td>
                                                            <td style="width: 220px; height: 40px; font-size:13px" align="left">
                                                               <asp:Label ID="lblparentpassport" runat="server" CssClass="s_label_value"></asp:Label>
                                                            </td>
                                                            <td id="tdfincome" runat="server">
                                                           
                                                               <asp:Label ID="Label12" runat="server" CssClass="s_label">Father/Guardian Annual Income</asp:Label>
                                                                <asp:Label ID="lblFannualincome" runat="server" CssClass="s_label_value"></asp:Label>
                                                             </td>
                                                             </tr
                                                        </tr>
                                                    </table>
                                                </td>                                                
                                            </tr>                                         
                                            <tr id="Mtag" runat="server">
                                                <td colspan="4">
                                                    <table width="100%">
                                                        <tr>
                                                           <td style="width: 180px; height: 40px" align="left">
                                                                 <asp:Label ID="Label88" runat="server" CssClass="s_label">Mother&apos;s Name</asp:Label>
                                                            </td>
                                                            <td style="width: 220px; height: 40px; font-size:13px" align="left">
                                                                 <asp:Label ID="lblmothername" runat="server" CssClass="s_label_value"></asp:Label>
                                                            </td>                                                                    
                                                            <td style="width: 120px; height: 40px" align="left">
                                                                <asp:Label ID="Label109" runat="server" CssClass="s_label" 
                                                                    Text="Mother's Mobile Number"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">                                                    
                                                                <asp:Label ID="lblmothermobile" runat="server" CssClass="s_label_value"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 180px; height: 40px" align="left">
                                                                <asp:Label ID="Label89" runat="server" CssClass="s_label">Mother&apos;s Occupation</asp:Label>
                                                            </td>
                                                            <td style="width: 220px; height: 40px; font-size:13px" align="left">
                                                                <asp:Label ID="lblmotheroccup" runat="server" CssClass="s_label_value"></asp:Label>
                                                            </td>                                               
                                                            <td style="width: 120px; height: 40px" align="left">
                                                                <asp:Label ID="lblmotherdesignation" runat="server" CssClass="s_label">Mother&apos;s Designation</asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:Label ID="lblmotherdesig" runat="server" CssClass="s_label_value"></asp:Label>
                                                            </td>
                                                        </tr>
                                                         <tr id="trtag1" runat="server">
                                                            <td style="width: 180px; height: 40px" align="left">
                                                                <asp:Label ID="Label97" runat="server" CssClass="s_label" 
                                                                    Text="Organization Name"></asp:Label>
                                                            </td>
                                                            <td style="width: 220px; height: 40px; font-size:13px" align="left">
                                                                <asp:Label ID="lblMorganization" runat="server" CssClass="s_label_value"></asp:Label>
                                                            </td>                                               
                                                            <td style="width: 120px; height: 40px" align="left">
                                                                <asp:Label ID="Label98" runat="server" CssClass="s_label" Text="Work Address"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:Label ID="lblMworkaddress" runat="server" CssClass="s_label_value"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr id="trtag2" runat="server">
                                                            <td style="width: 180px; height: 40px" align="left">
                                                                <asp:Label ID="Label99" runat="server" CssClass="s_label" Text="Country"></asp:Label>
                                                            </td>
                                                            <td style="width: 220px; height: 40px; font-size:13px" align="left">
                                                                <asp:Label ID="lblMcountry" runat="server" CssClass="s_label_value"></asp:Label>
                                                            </td>                                               
                                                            <td style="width: 120px; height: 40px" align="left">
                                                                <asp:Label ID="Label100" runat="server" CssClass="s_label" Text="State"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:Label ID="lblMstate" runat="server" CssClass="s_label_value"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr id="trtag3" runat="server">
                                                            <td style="width: 180px; height: 40px" align="left">
                                                                <asp:Label ID="Label101" runat="server" CssClass="s_label" Text="City"></asp:Label>
                                                            </td>
                                                            <td style="width: 220px; height: 40px; font-size:13px" align="left">
                                                                <asp:Label ID="lblMcity" runat="server" CssClass="s_label_value"></asp:Label>
                                                            </td>                                               
                                                            <td style="width: 120px; height: 40px" align="left">
                                                                <asp:Label ID="Label15" runat="server" CssClass="s_label" 
                                                                    Text="Mother office number"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:Label ID="lblMofficenumber" runat="server" CssClass="s_label_value"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr id="trtag4" runat="server">
                                                            <td style="width: 180px; height: 40px" align="left">
                                                                <asp:Label ID="Label19" runat="server" CssClass="s_label" 
                                                                    Text="Mother Email address"></asp:Label>
                                                            </td>
                                                            <td style="width: 220px; height: 40px; font-size:13px" align="left">
                                                                <asp:Label ID="lblMemail" runat="server" CssClass="s_label_value"></asp:Label>
                                                            </td> 
                                                            <td id="tdmincome" runat="server">                                             
                                                            
                                                                <asp:Label ID="Label17" runat="server" CssClass="s_label" 
                                                                    Text="Mother's Annual Income"></asp:Label>
                                                            
                                                                <asp:Label ID="lblMannualincome" runat="server" CssClass="s_label_value"></asp:Label>
                                                            </td>
                                                           
                                                        </tr>
                                                    </table>
                                                </td>                                               
                                            </tr>
                                            
                                           
                                            
                                            <tr id="trincome" runat="server">
                                                <td style="width: 150px; height: 40px" align="left">
                                                    <asp:Label ID="Label54" runat="server" CssClass="s_label" 
                                                        Text="Family Annual  Income"></asp:Label>
                                                </td>
                                                <td style="width: 220px; height: 40px; font-size:13px" align="left">
                                                    <asp:Label ID="lblannualfamincome" runat="server" CssClass="s_label_value"></asp:Label>
                                                </td>                                               
                                                <td style="width: 120px; height: 40px" align="left">
                                                    &nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr class="view_detail_subtitle_bg">
                                                <td style="height: 25px" align="left" colspan="4">
                                                    <asp:Label ID="Label9" runat="server" CssClass="s_label" 
                                                        Text="Parents/Guardain Details For Emergency" Font-Bold="True"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr id="Tr1" runat="server">
                                                <td colspan="4">
                                                    <table width="100%">
                                                        <tr>
                                                            <td style="width: 180px; height: 40px" align="left">
                                                                <asp:Label ID="Label11" runat="server" CssClass="s_label" 
                                                                    Text="Name"></asp:Label>
                                                            </td>
                                                            <td style="width: 220px; height: 40px" align="left">
                                                                <asp:Label ID="lblname1" runat="server" CssClass="s_label_value"></asp:Label>
                                                            </td>
                                                            
                                                            <td style="width: 120px; height: 40px" align="left">
                                                                <asp:Label ID="Label51" runat="server" CssClass="s_label" Text="Office Number"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                &nbsp;&nbsp;<asp:Label ID="lblofficeno" runat="server" CssClass="s_label_value"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 180px; height: 40px" align="left">
                                                                <asp:Label ID="Label20" runat="server" CssClass="s_label" 
                                                                    Text="Passport or I.C No"></asp:Label>
                                                            </td>
                                                            <td style="width: 220px; height: 40px" align="left">
                                                                <asp:Label ID="lblpassport" runat="server" CssClass="s_label_value"></asp:Label>
                                                            </td>
                                                           
                                                            <td style="width: 120px; height: 40px" align="left">
                                                                <asp:Label ID="Label28" runat="server" CssClass="s_label" 
                                                                    Text="Home Number"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                &nbsp;&nbsp;<asp:Label ID="lblhomeno" runat="server" CssClass="s_label_value"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 180px; height: 40px" align="left">
                                                                <asp:Label ID="Label47" runat="server" CssClass="s_label" Text="Relationship to student"></asp:Label>
                                                            </td>
                                                            <td style="width: 220px; height: 40px" align="left">
                                                                <asp:Label ID="lblrelation" runat="server" CssClass="s_label_value"></asp:Label>
                                                            </td>
                                                            
                                                            <td style="width: 120px; height: 40px" align="left">
                                                                <asp:Label ID="Label49" runat="server" CssClass="s_label" Text="Mobile Number"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                &nbsp;&nbsp;<asp:Label ID="lblmobileno" runat="server" CssClass="s_label_value"></asp:Label></td>
                                                       </tr>
                                                        <tr>
                                                            <td style="width: 180px; height: 40px" align="left">
                                                                &nbsp;</td>
                                                            <td style="width: 220px; height: 40px; font-size:13px" align="left">
                                                                &nbsp;</td>
                                                            
                                                        </tr>
                                                   </table>
                                                </td>                                                
                                            </tr>                     
                                            <tr class="view_detail_subtitle_bg">
                                                <td style="height: 25px" align="left" colspan="4">
                                                    <asp:Label ID="Label27" runat="server" CssClass="s_label" Text="Communication Details" 
                                                        Font-Bold="True"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 150px; height: 40px" align="left" >
                                                    <asp:Label ID="Label58" runat="server" CssClass="s_label" Text="Mobile Number For SMS"></asp:Label>
                                                </td>
                                                <td align="left">
                                                <asp:Label ID="lblmobilesms" runat="server" CssClass="s_label_value" valign="top"></asp:Label>
                                                </td>
                                                <td style="width: 120px; height: 40px" align="left" valign="top">
                                                    <asp:Label ID="Label60" runat="server" CssClass="s_label" Text="Parent's User Name"></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                <asp:Label ID="lblparentusername" runat="server" CssClass="s_label_value"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 150px; height: 40px" align="left">
                                                    <asp:Label ID="Label61" runat="server" CssClass="s_label" Text="Student User Name"></asp:Label>
                                                </td>
                                                <td align="left">
                                                <asp:Label ID="lblstudentusername" runat="server" CssClass="s_label_value" valign="top"></asp:Label>
                                                </td>
                                                <td style="width: 120px; height: 40px" align="left">
                                                    <asp:Label ID="Label59" runat="server" CssClass="s_label" 
                                                        Text="Parent's Personal Email "></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                <asp:Label ID="lblparentemail" runat="server" CssClass="s_label_value" valign="top"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 150px; height: 40px" align="left" valign="top">
                                                    <asp:Label ID="Label62" runat="server" CssClass="s_label" Text="Correspondence Address"></asp:Label>
                                                </td>
                                                <td align="left">
                                                <asp:Label ID="lblcorradds" runat="server" CssClass="s_label_value" valign="top"></asp:Label>
                                                </td>
                                                <td style="width: 120px; height: 40px" align="left">&nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                            </tr>
                                            <tr class="view_detail_subtitle_bg">
                                                <td style="height: 25px" align="left" colspan="4">
                                                    <asp:Label ID="Label3" runat="server" CssClass="s_label" Text="Subject Details" 
                                                        Font-Bold="True"></asp:Label>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td style="width: 150px; height: 40px" align="left" valign="top">
                                                    <asp:Label ID="Label90" runat="server" CssClass="s_label" 
                                                        Text="Second Language"></asp:Label>
                                                </td>
                                                <td align="left">
                                                <asp:Label ID="lblseclanguage" runat="server" CssClass="s_label_value" valign="top"></asp:Label>
                                                </td>
                                                <td style="width: 120px; height: 40px" align="left">
                                                    <asp:Label ID="Label75" runat="server" CssClass="s_label" Text="Third Language"></asp:Label>
                                                 </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                <asp:Label ID="lblthirdlanguage" runat="server" CssClass="s_label_value" valign="top"></asp:Label>
                                                 </td>
                                            </tr>
                                             <tr>
                                                <td style="width: 150px; height: 40px" align="left" valign="top">
                                                    <asp:Label ID="Label76" runat="server" CssClass="s_label" Text="Extra Curricular Activities"></asp:Label>
                                                </td>
                                                <td align="left">
                                                <asp:Label ID="lblextracurricular" runat="server" CssClass="s_label_value" valign="top"></asp:Label>
                                                </td>
                                                <td style="width: 120px; height: 40px" align="left">&nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                            </tr>
                                            <tr class="view_detail_subtitle_bg">
                                                <td style="height: 25px" align="left" colspan="4">
                                                    <asp:Label ID="Label5" runat="server" CssClass="s_label" Text="Health Details" 
                                                        Font-Bold="True"></asp:Label>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td style="width: 150px; height: 40px" align="left" valign="top">
                                                    <asp:Label ID="Label69" runat="server" CssClass="s_label" Text="Height"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblheight" runat="server" CssClass="s_label_value" valign="top"></asp:Label>
                                                    <asp:Label ID="cms" runat="server" Text="cms" CssClass="s_label_value"></asp:Label>
                                                </td>
                                                <td style="width: 120px; height: 40px" align="left">
                                                    <asp:Label ID="Label96" runat="server" CssClass="s_label" Text="Weight"></asp:Label>
                                                 </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:Label ID="lblweight" runat="server" CssClass="s_label_value"></asp:Label>
                                                 </td>
                                            </tr>
                                             <tr>
                                                <td style="width: 150px; height: 40px" align="left" valign="top">
                                                    <asp:Label ID="Label68" runat="server" CssClass="s_label" Text="Blood Group"></asp:Label>
                                                </td>
                                                <td align="left">
                                                <asp:Label ID="lblblood" runat="server" CssClass="s_label_value" valign="top"></asp:Label>
                                                </td>
                                                <td style="width: 120px; height: 40px" align="left">
                                                    <asp:Label ID="Label70" runat="server" CssClass="s_label" 
                                                        Text="Identification Mark "></asp:Label>
                                                 </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:Label ID="lblidentification" runat="server" CssClass="s_label_value" valign="top"></asp:Label>
                                                 </td>
                                            </tr>
                                             <tr>
                                                <td style="width: 150px; height: 40px" align="left" valign="top">
                                                    <asp:Label ID="Label110" runat="server" CssClass="s_label" 
                                                        Text="Allergies (If any)"></asp:Label>
                                                </td>
                                                <td align="left">
                                                <asp:Label ID="lblallergies" runat="server" CssClass="s_label_value" valign="top"></asp:Label>
                                                </td>
                                                <td style="width: 120px; height: 40px" align="left">
                                                    &nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    &nbsp;</td>
                                            </tr>
                                             <tr class="view_detail_subtitle_bg">
                                                <td style="height: 25px" align="left" colspan="4">
                                                    <asp:Label ID="Label6" runat="server" CssClass="s_label" Text="Transport Details" 
                                                        Font-Bold="True"></asp:Label>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td style="width: 150px; height: 40px" align="left" valign="top">
                                                    <asp:Label ID="Label102" runat="server" CssClass="s_label" Text="Hostler"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblhosteler" runat="server" CssClass="s_label_value"></asp:Label>
                                                </td>
                                                <td style="width: 120px; height: 40px" align="left">
                                                    <asp:Label ID="Label103" runat="server" CssClass="s_label" Text="Transport"></asp:Label>
                                                 </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:Label ID="lbltransport" runat="server" CssClass="s_label_value"></asp:Label>
                                                 </td>
                                            </tr>
                                             <tr id="tag1" runat="server">
                                                <td style="width: 150px; height: 40px" align="left" valign="top">
                                                    <asp:Label ID="Label77" runat="server" CssClass="s_label" Text="Route"></asp:Label>
                                                </td>
                                                <td align="left">
                                                <asp:Label ID="lblroute" runat="server" CssClass="s_label_value" valign="top"></asp:Label>
                                                </td>
                                                <td style="width: 120px; height: 40px" align="left">
                                                    <asp:Label ID="Label104" runat="server" CssClass="s_label" Text="Vehicle No"></asp:Label>
                                                 </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:Label ID="lblvehicleno" runat="server" CssClass="s_label_value"></asp:Label>
                                                 </td>
                                            </tr>
                                             <tr id="tag2" runat="server">
                                                <td style="width: 150px; height: 40px" align="left" valign="top">
                                                    <asp:Label ID="Label84" runat="server" CssClass="s_label" Text="Driver Name"></asp:Label>
                                                 </td>
                                                <td align="left">
                                                <asp:Label ID="lbldrivername" runat="server" CssClass="s_label_value" valign="top"></asp:Label>
                                                 </td>
                                                <td style="width: 120px; height: 40px" align="left">
                                                    <asp:Label ID="Label105" runat="server" CssClass="s_label" 
                                                        Text="Pickup &amp; dropping point"></asp:Label>
                                                 </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:Label ID="lblpickpoint" runat="server" CssClass="s_label_value"></asp:Label>
                                                 </td>
                                            </tr>
                                             <tr id="tag3" runat="server">
                                                <td style="width: 150px; height: 40px" align="left" valign="top">
                                                    <asp:Label ID="Label106" runat="server" CssClass="s_label" Text="Pickup Time"></asp:Label>
                                                 </td>
                                                <td align="left">
                                                    <asp:Label ID="lblpicktime" runat="server" CssClass="s_label_value"></asp:Label>
                                                 </td>
                                                <td style="width: 120px; height: 40px" align="left">
                                                    <asp:Label ID="Label108" runat="server" CssClass="s_label" Text="Dropping Time"></asp:Label>
                                                 </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:Label ID="lbldroptime" runat="server" CssClass="s_label_value"></asp:Label>
                                                 </td>
                                            </tr>
                                            <tr class="view_detail_subtitle_bg">
                                                <td style="height: 25px" align="left" colspan="4">
                                                    <asp:Label ID="Label7" runat="server" CssClass="s_label" Text="Other Details" 
                                                        Font-Bold="True"></asp:Label>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td style="width: 150px; height: 40px" align="left" valign="top">
                                                    <asp:Label ID="Label78" runat="server" CssClass="s_label" Text="Original Documents Recieved"></asp:Label>
                                                </td>
                                                <td align="left">
                                                <asp:Label ID="lbloriginaldoc" runat="server" CssClass="s_label_value" valign="top"></asp:Label>
                                                </td>
                                                <td style="width: 120px; height: 40px" align="left">
                                                    <asp:Label ID="Label80" runat="server" CssClass="s_label" 
                                                        Text="Remarks / Notes"></asp:Label>
                                                 </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                <asp:Label ID="lblremark" runat="server" CssClass="s_label_value" valign="top"></asp:Label>
                                                 </td>
                                            </tr>
                                             <tr>
                                                <td style="width: 150px; height: 40px" align="left" valign="top">
                                                    <asp:Label ID="Label95" runat="server" CssClass="s_label" 
                                                        Text="Previous Institution"></asp:Label>
                                                </td>
                                                <td align="left">
                                                <asp:Label ID="previousinstitute" runat="server" CssClass="s_label_value" valign="top"></asp:Label>
                                                </td>
                                                <td style="width: 120px; height: 40px" align="left">
                                                    &nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">
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
        <tr><td style="height:40px"></td></tr>
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
