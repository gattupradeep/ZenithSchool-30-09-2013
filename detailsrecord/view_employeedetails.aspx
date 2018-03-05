<%@ Page Language="C#" AutoEventWireup="true" CodeFile="view_employeedetails.aspx.cs" Inherits="detailsrecord_view_employeedetails" %>

<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>

<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>

<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

<%@ Register src="../usercontrol/detailsrecord_staff.ascx" tagname="detailsrecord_staff" tagprefix="uc1" %>

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
</head>
<body>
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
                                <tr id="trsidemenu" runat="server">
                                    <td style="width: 230px" align="right">
                                        <uc1:detailsrecord_staff ID="detailsrecord_staff1" runat="server" />
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
                        <td style="width:1%" valign="top">
                        </td>
                        <td style="width: 95%;" valign="top" align="left">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr class="app_container_title">
                                    <td style="width: 100%; " align="left">
                                        <table cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/18.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left" id="tdtitle" runat="server" >View Employee Details</td>
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
                                        <table cellpadding="7" cellspacing="0" border="0" class="app_container_auto">
                                            <tr class="view_detail_title_bg" >
                                                <td colspan="3"  align="left">
                                                   <asp:Label CssClass="title_label" ID="lbltit" runat="server" Text="Employee Details" ></asp:Label>
                                                </td>
                                                <td style="width: 155px">
                                                    <asp:Button ID="btnedit" runat="server" onclick="btnedit_Click" Text="Edit" 
                                                        CssClass="s_button" />
                                                    &nbsp;<asp:Button ID="btnback" runat="server" Text="Back" CssClass="s_button" onclick="btnback_Click"  />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 50px" align="left" colspan="4">
                                                    <img src = "../images/staff/<%=strempid%>.jpg" alt="photo" width="100" height="100" />
                                                    <asp:Label ID="lblid" runat="server" CssClass="s_label" Visible="False"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr class="view_detail_subtitle_bg">
                                                <td style="height: 25px" align="left" colspan="4">
                                                    <asp:Label ID="Label21" runat="server" CssClass="subtitle_label" Text="Personal Details" ></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:Label ID="Label22" runat="server" CssClass="s_label" Text="Name"></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:Label ID="lblname" runat="server" CssClass="s_label_value"></asp:Label>
                                                </td>                                                    
                                                <td style="width: 100px; height: 40px" align="left">
                                                    <asp:Label ID="Label1" runat="server" CssClass="s_label" Text="Gender"></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:Label ID="lblgender" runat="server" CssClass="s_label_value"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 200px; height: 40px;" align="left">
                                                    <asp:Label ID="Label4" runat="server" CssClass="s_label" Text="Date of Birth"></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:Label ID="lbldob" runat="server" CssClass="s_label_value"></asp:Label>
                                                </td>                                                    
                                                <td style="width: 100px; height: 40px" align="left">
                                                    <asp:Label ID="Label13" runat="server" CssClass="s_label" Text="Age"></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:Label ID="lblage" runat="server" CssClass="s_label_value"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label2" runat="server" CssClass="s_label" Text="Staff Type"></asp:Label>
                                                </td>
                                                <td align="left" >
                                                    <asp:Label ID="lblstafftype" runat="server" CssClass="s_label_value"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label29" runat="server" CssClass="s_label" Text="Gaurdian"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblguardian" runat="server" CssClass="s_label_value"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:Label ID="Label30" runat="server" CssClass="s_label" Text="Guardian Name"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblguardname" runat="server" CssClass="s_label_value"></asp:Label>
                                                </td>
                                               
                                                <td align="left" style="width:100px">
                                                    <asp:Label ID="Label36" runat="server" CssClass="s_label" Text="Religion"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblreligion" runat="server" CssClass="s_label_value"></asp:Label>
                                                </td>
                                            </tr>                                            
                                            <tr>
                                                <%--<td align="left">
                                                    <asp:Label ID="Label32" runat="server" CssClass="s_label" Text="Community"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblcommunity" runat="server" CssClass="s_label_value"></asp:Label>
                                                </td>--%>
                                               
                                                <td align="left" style="width:100px">
                                                    <asp:Label ID="Label33" runat="server" CssClass="s_label" Text="Nationality"></asp:Label>
                                                </td>
                                                <td align="left">
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
                                                
                                                <td align="left" style="width:100px">
                                                    <asp:Label ID="Label34" runat="server" CssClass="s_label" Text="Country"></asp:Label>
                                                </td>
                                                <td align="left">
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
                                                <td align="left" style="width:100px">
                                                    <asp:Label ID="Label35" runat="server" CssClass="s_label" Text="City"></asp:Label>
                                                </td>
                                                <td align="left">
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
                                                <td align="left" style="width:100px">
                                                    <asp:Label ID="Label31" runat="server" CssClass="s_label" Text="Email"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblemail" runat="server" CssClass="s_label_value"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label37" runat="server" CssClass="s_label" Text="Address Proof"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lbladdproof" runat="server" CssClass="s_label_value"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width:100px">
                                                    <asp:Label ID="Label42" runat="server" CssClass="s_label" Text="Mobile Number"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblpmobile" runat="server" CssClass="s_label_value"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="Label43" runat="server" CssClass="s_label" 
                                                        Text="Residence Phone Number"></asp:Label>
                                                </td>
                                                <td align="left" >
                                                    <asp:Label ID="lblphoneno" runat="server" CssClass="s_label_value"></asp:Label>
                                                </td>
                                            </tr>
                                            <%--<tr>
                                                
                                                <td align="left" style="width:100px">
                                                    &nbsp;</td>
                                                <td align="left">
                                                    &nbsp;</td>
                                            </tr>--%>
                                            <tr class="view_detail_subtitle_bg">
                                                <td style="height: 25px" align="left" colspan="4">
                                                    <asp:Label ID="Label23" runat="server" CssClass="subtitle_label" Text="Administration Details"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:Label ID="Label24" runat="server" CssClass="s_label" Text="Date of Joining"></asp:Label>
                                                </td>
                                                <td style="width: 220px; height: 40px" align="left">
                                                    <asp:Label ID="lbljoindate" runat="server" CssClass="s_label_value"></asp:Label>
                                                </td>
                                                
                                                <td style="width: 100px; height: 40px" align="left">
                                                    <asp:Label ID="Labelstate" runat="server" CssClass="s_label" Text="Department"></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    &nbsp;&nbsp;<asp:Label ID="lbldept" runat="server" CssClass="s_label_value"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:Label ID="Label25" runat="server" CssClass="s_label" Text="Designation"></asp:Label>
                                                </td>
                                                <td style="width: 220px; height: 40px" align="left">
                                                    <asp:Label ID="lbldesig" runat="server" CssClass="s_label_value"></asp:Label>
                                                </td>
                                               
                                                <td style="width: 100px; height: 40px" align="left">
                                                    <asp:Label ID="Label44" runat="server" CssClass="s_label" Text="Salary"></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    &nbsp;&nbsp;<asp:Label ID="lblsalary" runat="server" CssClass="s_label_value"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:Label ID="Label45" runat="server" CssClass="s_label" Text="Experience"></asp:Label>
                                                </td>
                                                <td style="width: 220px; height: 40px" align="left">
                                                    <asp:Label ID="lblexperience" runat="server" CssClass="s_label_value"></asp:Label>
                                                </td>
                                                <td style="width: 100px; height: 40px" align="left">
                                                    &nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                </td>
                                            </tr>
                                            <tr class="view_detail_subtitle_bg">
                                                <td style="height: 25px" align="left" colspan="4">
                                                    <asp:Label ID="Label27" runat="server" CssClass="subtitle_label" Text="General Details"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 150px; height: 40px" align="left" >
                                                    <asp:Label ID="Label96" runat="server" CssClass="s_label" Text="Teaching Subjects"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblteachsubject" runat="server" CssClass="s_label_value" 
                                                        valign="top"></asp:Label>
                                                </td>
                                                <td style="width: 100px; height: 40px" align="left" valign="top">
                                                    <asp:Label ID="Label97" runat="server" CssClass="s_label" Text="Teaching Standards"></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:Label ID="lblteachclass" runat="server" CssClass="s_label_value"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 150px; height: 40px" align="left">
                                                     <asp:Label ID="Label98" runat="server" CssClass="s_label" Text="Home Standard and Sec"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblhomeclass" runat="server" CssClass="s_label_value" 
                                                        valign="top"></asp:Label>
                                                </td>
                                                <td style="width: 100px; height: 40px" align="left">
                                                    <asp:Label ID="Label46" runat="server" CssClass="s_label" Text="Mobile No for Sms"></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:Label ID="lblmobileforsms" runat="server" CssClass="s_label_value" 
                                                        valign="top"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 150px; height: 40px" align="left" valign="top">
                                                    <asp:Label ID="Label48" runat="server" CssClass="s_label" Text="Login User ID"></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblloginuserid" runat="server" CssClass="s_label_value" 
                                                        valign="top"></asp:Label>
                                                </td>
                                                <td style="width: 100px; height: 40px" align="left">
                                                    <asp:Label ID="Label86" runat="server" CssClass="s_label" Text="Transport"></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:Label ID="lbltransport" runat="server" CssClass="s_label_value" 
                                                        valign="top"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr class="view_detail_subtitle_bg">
                                                <td style="height: 25px" align="left" colspan="4">
                                                    <asp:Label ID="Label5" runat="server" CssClass="subtitle_label" Text="Health Details"></asp:Label>
                                                </td>
                                            </tr>
                                             <tr>
                                                <%--<td style="width: 150px; height: 40px" align="left" valign="top">
                                                    <asp:Label ID="Label69" runat="server" CssClass="s_label" Text="Height"></asp:Label>
                                                </td>
                                                <td align="left">
                                                <asp:Label ID="lblheight" runat="server" CssClass="s_label_value" valign="top"></asp:Label>
                                                </td>--%>
                                                <td style="width: 150px; height: 40px" align="left" valign="top">
                                                    <asp:Label ID="Label68" runat="server" CssClass="s_label" Text="Blood Group"></asp:Label>
                                                </td>
                                                <td align="left">
                                                <asp:Label ID="lblblood" runat="server" CssClass="s_label_value" valign="top"></asp:Label>
                                                </td>
                                                <td style="width: 100px; height: 40px" align="left">
                                                    <asp:Label ID="Label70" runat="server" CssClass="s_label" 
                                                        Text="Identification Mark "></asp:Label>
                                                 </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                <asp:Label ID="lblidentification" runat="server" CssClass="s_label_value" 
                                                        valign="top"></asp:Label>
                                                 </td>
                                            </tr>
                                            <%--<tr>
                                                
                                                <td style="width: 100px; height: 40px" align="left">
                                                    &nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    &nbsp;</td>
                                            </tr>--%>
                                            <tr id="treducation1" runat="server" class="view_detail_subtitle_bg">
                                                <td style="height: 25px" align="left" colspan="4">
                                                    <asp:Label ID="Label3" runat="server" CssClass="subtitle_label" Text="Education Details"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr id="treducation2" runat="server">
                                                <td style="height: 25px" align="left" colspan="4">
                                                    <asp:DataGrid ID="dgeducation" runat="server" AutoGenerateColumns="False" Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None">
                                                        <AlternatingItemStyle CssClass="s_datagrid_alt_item" Font-Size="11px"/>
                                                        <ItemStyle Font-Size="11px" CssClass="s_datagrid_item"/>
                                                        <Columns>
                                                            <asp:BoundColumn DataField="intid" HeaderText="ID" Visible="false"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="intemployee" HeaderText="Employee ID" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strmode" HeaderText="Education Mode"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strdegree" HeaderText="Degree"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strmajor" HeaderText="Major"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strinstitution" HeaderText="Institution Name"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="intyearpass" HeaderText="Passed Out"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="intpercent" HeaderText="Percentage(%)"></asp:BoundColumn>
                                                        </Columns>
                                                        <HeaderStyle CssClass="s_datagrid_header" Font-Size="12px"/>
                                                     </asp:DataGrid>
                                                </td>
                                            </tr>
                                            <tr id="trexprience1" runat="server" class="view_detail_subtitle_bg">
                                                <td style="height: 25px" align="left" colspan="4">
                                                    <asp:Label ID="Label7" runat="server" CssClass="subtitle_label" Text="Experience Details"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr id="trexprience2" runat="server">
                                                <td style="height: 25px" align="left" colspan="4">
                                                    <asp:DataGrid ID="dgexperience" runat="server" AutoGenerateColumns="False" 
                                                     Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None">
                                                     <AlternatingItemStyle CssClass="s_datagrid_alt_item" Font-Size="11px"/>
                                                     <ItemStyle CssClass="s_datagrid_item" Font-Size="11px"/>
                                                     <Columns>
                                                     <asp:BoundColumn DataField="intid" HeaderText="ID" Visible="false"></asp:BoundColumn>
                                                     <asp:BoundColumn DataField="intemployee" HeaderText="Employee ID" Visible="False"></asp:BoundColumn>
                                                     <asp:BoundColumn DataField="strorganization" HeaderText="Organization"></asp:BoundColumn>
                                                     <asp:BoundColumn DataField="dtperiodfrom1" HeaderText="Period From"></asp:BoundColumn>
                                                     <asp:BoundColumn DataField="dtperiodto1" HeaderText="Period To"></asp:BoundColumn>
                                                     <asp:BoundColumn DataField="strdepartment" HeaderText="Department"></asp:BoundColumn>
                                                     <asp:BoundColumn DataField="strdesignation" HeaderText="Designation"></asp:BoundColumn>
                                                     </Columns>
                                                     <HeaderStyle CssClass="s_datagrid_header" Font-Size="12px"/>
                                                    </asp:DataGrid>
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
