﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewClass_section_subject_details.aspx.cs" Inherits="school_viewClass_section_subject_details" %>

<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>

<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>

<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>

<%@ Register src="../usercontrol/school_profile.ascx" tagname="school_profile" tagprefix="uc5" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

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
    <ajaxtoolkit:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server">
    </ajaxtoolkit:toolkitscriptmanager>
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td align="left">
                <uc3:topbanner ID="topbanner1" runat="server" />
            </td>
        </tr>
        <tr>
            <td valign="top">
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
                                        <uc5:school_profile ID="school_profile1" runat="server" />
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
                        <td style="width: 94%" valign="top" align="left">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                 <tr class="app_container_title">
                                    <td style="width: 100%; height: 50px" align="left">
                                        <table cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/25.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left" >
                                                    Available Classes, Sections, Subjects and Activities</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td style="padding-left: 5px" valign="top" align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" class="app_container">
                                            <tr class="view_detail_title_bg" >
                                                <td align="left">
                                                   <asp:Label CssClass="title_label" ID="lbltit" runat="server" Text="Classes, Sections, Subjects and Activities Available" ></asp:Label>
                                                </td>
                                                <td style="width: 85px" >
                                                    <asp:Button ID="btnedit" runat="server" CssClass="s_button" Text="Edit" 
                                                         onclick="btnedit_Click"/>
                                                </td>
                                            </tr> 
                                            <tr style="height:10px;">
                                                <td  colspan="2"></td>
                                            </tr> 
                                            <tr>
                                            <td align="left" colspan="2">
                                                <table cellspacing="0" cellpadding="3" width="100%" >
                                                    <tr class="s_datagrid_header">
                                                        <td>
                                                           Classes Available
                                                        </td>                                                                                                  
                                                    </tr>
                                                    <tr>
                                                        <td >
                                                             <asp:DataList ID= "dlclasses" runat="server" RepeatColumns="2" GridLines="None" 
                                                                 Width="100%" CellSpacing="1">                                                             
                                                                 <AlternatingItemStyle CssClass="s_datagrid_item" />
                                                                 <ItemStyle CssClass="s_datagrid_item"  Width="50%" />
                                                               <ItemTemplate>
                                                               <%# DataBinder.Eval(Container.DataItem, "strstandard") %>
                                                               </ItemTemplate>                                                               
                                                             </asp:DataList>
                                                        </td>                                                       
                                                                                                               
                                                    </tr>
                                                    <tr class="s_datagrid_header">
                                                        <td >
                                                            Sections Available</td>                                                                                                  
                                                    </tr>
                                                    <tr>
                                                        <td >
                                                             <asp:DataList ID= "dlsection" runat="server" RepeatColumns="2" GridLines="None" 
                                                                 Width="100%" CellSpacing="1">                                                             
                                                                 <AlternatingItemStyle CssClass="s_datagrid_item" />
                                                                 <ItemStyle CssClass="s_datagrid_item"  Width="50%" />
                                                               <ItemTemplate >
                                                               <%# DataBinder.Eval(Container.DataItem, "strsection")%>
                                                               </ItemTemplate>                                                               
                                                             </asp:DataList>
                                                        </td>                                                       
                                                                                                               
                                                    </tr>
                                                    <tr class="s_datagrid_header">
                                                        <td>
                                                            Subjects Available</td>                                                                                                  
                                                    </tr>
                                                    <tr>
                                                        <td >
                                                             <asp:DataList ID= "dlsubject" runat="server" RepeatColumns="2" GridLines="None" Width="100%" CellSpacing="1">                                                             
                                                                 <AlternatingItemStyle CssClass="s_datagrid_item" />
                                                                 <ItemStyle CssClass="s_datagrid_item" Width="50%" />
                                                               <ItemTemplate>
                                                               <%# DataBinder.Eval(Container.DataItem, "strsubject")%>
                                                               </ItemTemplate>                                                               
                                                             </asp:DataList>
                                                        </td>                                                       
                                                                                                               
                                                    </tr>
                                                    <tr class="s_datagrid_header">
                                                        <td>
                                                            Languages Available</td>                                                                                                  
                                                    </tr>
                                                    <tr>
                                                        <td >
                                                             <asp:DataList ID= "dlsecondlang" runat="server" RepeatColumns="2" GridLines="None" CellSpacing="1" 
                                                                 Width="100%" >                                                             
                                                                 <AlternatingItemStyle CssClass="s_datagrid_item" />
                                                                 <ItemStyle CssClass="s_datagrid_item"  Width="50%" />
                                                               <ItemTemplate >
                                                               <%# DataBinder.Eval(Container.DataItem, "strlanguagename")%>
                                                               </ItemTemplate>                                                               
                                                             </asp:DataList>
                                                        </td>                                                       
                                                                                                               
                                                    </tr>
                                                    <tr class="s_datagrid_header">
                                                        <td>
                                                            Extra Curricular Activities</td>                                                                                                  
                                                    </tr>
                                                    <tr>
                                                        <td >
                                                             <asp:DataList ID= "dlextra" runat="server" RepeatColumns="2" GridLines="None" CellSpacing="1"
                                                                 Width="100%">                                                             
                                                                 <AlternatingItemStyle CssClass="s_datagrid_item" />
                                                                 <ItemStyle CssClass="s_datagrid_item"  Width="50%" />
                                                               <ItemTemplate >
                                                               <%# DataBinder.Eval(Container.DataItem, "strextracurricular")%>
                                                               </ItemTemplate>                                                               
                                                             </asp:DataList>
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
                <uc6:app_footer ID="app_footer" runat="server" />
            </td>
        </tr>
    </table>
    <cc1:MsgBox id="msgbox" runat="server"></cc1:MsgBox>
    </div>
    </form>
</body>
</html>
