<%@ Page Language="C#" AutoEventWireup="true" CodeFile="schooldetails.aspx.cs" Inherits="school_schooldetails" EnableEventValidation="false" %>

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
    <ajaxtoolkit:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server"></ajaxtoolkit:toolkitscriptmanager>
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td >
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
                                                    School Information</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 5px" valign="top" align="left">
                                       <%-- <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="up1" DisplayAfter="1">
                                            <ProgressTemplate>
                                                <table cellpadding="0" cellspacing="0" border="0" width="710">
                                                    <tr>
                                                        <td style="width: 710px" align="center"><img src="../media/images/Processing.gif" /></td>
                                                    </tr>
                                                </table>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>--%>
                                      <%--  <asp:UpdatePanel ID="up1" runat="server">
                                            <ContentTemplate>--%>
                                                <table cellpadding="5" cellspacing="0" border="0" class="app_container">
                                                    <tr class="view_detail_title_bg" >
                                                        <td align="left" >
                                                           <asp:Label CssClass="title_label" ID="lbltit" runat="server" Text="Edit School Information" ></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table cellspacing="5" cellpadding="0" border="0">
                                                                <tr>
                                                                    <td style="width: 200px; height: 40px" align="left" valign="top">
                                                                        <asp:Label ID="Label21" runat="server" CssClass="s_label" 
                                                                            Text="Name of the school" Height="40px" ></asp:Label>
                                                                    </td>
                                                                    <td style="width: 200px; height: 40px" align="left">
                                                                        <asp:TextBox ID="txtschoolname" runat="server"  CssClass="s_textbox" Width="180px"/>                                                    
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                                                            ControlToValidate="txtschoolname" ErrorMessage="*" Height="16px" Width="16px"></asp:RequiredFieldValidator>
                                                                    </td> 
                                                                    <td style="width:30px"></td>
                                                                    <td style="width: 150px; height: 40px" align="left" valign="top">
                                                                        <asp:Label ID="Label22" runat="server" CssClass="s_label" Text="Branch" Height="40px"></asp:Label>
                                                                    </td>
                                                                    <td style="width: 200px; height: 40px" align="left" valign="middle">
                                                                        <asp:TextBox ID="txtbranch" runat="server"  CssClass="s_textbox" Width="180px"/>                                                    
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                                                            ControlToValidate="txtbranch" ErrorMessage="*" Height="16px" Width="16px"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 200px; height: 40px" align="left">
                                                                            <asp:Label ID="Label1" runat="server" CssClass="s_label" Text="Year Established"></asp:Label>
                                                                        </td>
                                                                        <td style="width: 200px; height: 40px" align="left">
                                                                            <asp:TextBox ID="txtyear" runat="server"  CssClass="s_textbox" Width="100px"/>                                                    
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtyear" ErrorMessage="*" Height="16px" Width="16px"></asp:RequiredFieldValidator>
                                                                        </td>  
                                                                        <td style="width:30px"></td>                                                   
                                                                        <td style="width: 150px; height: 40px" align="left">
                                                                            <asp:Label ID="Label2" runat="server" CssClass="s_label" Text="Board / Medium"></asp:Label>
                                                                        </td>                                                                                                  
                                                                        <td style="width: 200px; height: 40px" align="left">                                                
                                                                              <asp:DropDownList ID="ddlboard" runat="server" CssClass="s_dropdown"  
                                                                                  Width="90px"></asp:DropDownList>                                                      
                                                                              <asp:DropDownList ID="ddlmedium" runat="server" CssClass="s_dropdown" 
                                                                                  Width="90px">
                                                                                  <asp:ListItem>English</asp:ListItem>
                                                                                  <asp:ListItem>Hindi</asp:ListItem>
                                                                                  <asp:ListItem>Tamil</asp:ListItem>
                                                                                  <asp:ListItem>Kannada</asp:ListItem>
                                                                                  <asp:ListItem>Malayalam</asp:ListItem>
                                                                                  <asp:ListItem>Telugu</asp:ListItem>
                                                                              </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 200px; height: 40px" align="left">
                                                                            <asp:Label ID="Label4" runat="server" CssClass="s_label" Text="Academic Year Start"></asp:Label>
                                                                        </td>
                                                                        <td style="width: 200px; height: 40px" align="left">
                                                                            <ajaxtoolkit:CalendarExtender ID="Calendarextender2" runat="server" CssClass="cal_Theme1" Format="yyyy/MM/dd" PopupButtonID="txtstart" TargetControlID="txtstart"></ajaxtoolkit:CalendarExtender >
                                                                            <asp:TextBox ID="txtstart" runat="server"  CssClass="s_textbox" Width="180px"/>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                                                                ControlToValidate="txtstart" ErrorMessage="*" Height="16px" Width="16px"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td style="width:30px"></td>                                                    
                                                                        <td style="width: 150px; height: 40px" align="left">
                                                                            <asp:Label ID="Label13" runat="server" CssClass="s_label" Text="Academic Year End"></asp:Label>
                                                                        </td>
                                                                        <td style="width: 200px; height: 40px" align="left">
                                                                            <ajaxtoolkit:CalendarExtender ID="Calendarextender1" runat="server" CssClass="cal_Theme1" Format="yyyy/MM/dd" PopupButtonID="txtend" TargetControlID="txtend"></ajaxtoolkit:CalendarExtender >
                                                                            <asp:TextBox ID="txtend" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                                                                                ControlToValidate="txtaddr" ErrorMessage="*" Height="16px" Width="16px"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                   <tr>
                                                                        <td style="width: 140px; height: 40px" align="left">
                                                                            <asp:Label ID="Label9" runat="server" CssClass="s_label" Text="Country"></asp:Label>
                                                                        </td>
                                                                        <td style="width: 180px; height: 40px" align="left">
                                                                            <asp:DropDownList ID="ddlcountry" runat="server" CssClass="s_dropdown" Width="150px" AutoPostBack="True" onselectedindexchanged="ddlcountry_SelectedIndexChanged">
                                                                            </asp:DropDownList>                                                                              
                                                                        </td>
                                                                        <td style="width:30px"></td>          
                                                                        <td style="width: 150px; height: 40px" align="left">
                                                                            <asp:Label ID="Label7" runat="server" CssClass="s_label" Text="State"></asp:Label>
                                                                        </td>
                                                                        <td style="width: 200px; height: 40px" align="left">                                                
                                                                            <asp:DropDownList ID="ddlstate" runat="server" CssClass="s_dropdown" Width="150px" AutoPostBack="True"  onselectedindexchanged="ddlstate_SelectedIndexChanged">
                                                                            </asp:DropDownList>                                                    
                                                                        </td>                                                                       
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 140px; height: 40px" align="left">
                                                                            <asp:Label ID="Label6" runat="server" CssClass="s_label" Text="City"></asp:Label>
                                                                            <asp:Label ID="lblcitycheck" runat="server" CssClass="s_label" Visible="False"></asp:Label>
                                                                        </td>
                                                                        <td style="width: 180px; height: 40px" align="left">
                                                                           <asp:DropDownList ID="ddlcity" runat="server" CssClass="s_dropdown"  
                                                                                Width="150px" onselectedindexchanged="ddlcity_SelectedIndexChanged" 
                                                                                AutoPostBack="True">
                                                                           </asp:DropDownList>
                                                                        </td> 
                                                                        <td style="width:30px"></td>                                                                
                                                                        <td style="width: 150px; height: 40px" align="left">
                                                                            <asp:Label ID="Label20" runat="server" CssClass="s_label" Text="Address"></asp:Label>
                                                                        </td>
                                                                        <td style="width: 200px; height: 40px" align="left">
                                                                        <asp:TextBox ID="txtaddr" runat="server" CssClass="s_textbox" TextMode="MultiLine" 
                                                                                Width="150px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                                                                ControlToValidate="txtEmail" ErrorMessage="*" Height="16px" Width="16px"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                        
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 200px; height: 40px" align="left">
                                                                            <asp:Label ID="Label8" runat="server" CssClass="s_label" Text="Pincode"></asp:Label>
                                                                        </td>
                                                                        <td style="width: 200px; height: 40px" align="left">
                                                                            <asp:TextBox ID="txtzip" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                                                                                ControlToValidate="txtzip" ErrorMessage="*" Height="16px" Width="16px"></asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td style="width:30px"></td> 
                                                                        <td style="width: 150px; height: 40px" align="left">
                                                                            <asp:Label ID="Label10" runat="server" CssClass="s_label" Text="Phone"></asp:Label>
                                                                        </td>
                                                                        <td style="width: 200px; height: 40px" align="left">
                                                                            <asp:TextBox ID="txtcountrycode" runat="server" CssClass="s_textbox" Width="30px" Font-Size="11px"></asp:TextBox>                                                       
                                                                            <asp:TextBox ID="txtcitycode" runat="server" CssClass="s_textbox" Width="30px" Font-Size="11px"></asp:TextBox>                                                       
                                                                            <asp:TextBox ID="txtphone" runat="server" CssClass="s_textbox" Width="100px"></asp:TextBox>                                                    
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 200px; height: 40px" align="left">
                                                                            <asp:Label ID="Label14" runat="server" CssClass="s_label" Text="Email ID"></asp:Label>
                                                                            <br />
                                                                            <asp:Label ID="lblemailmsg" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                                                            <asp:ImageButton ID="chkemail" runat="server" CausesValidation="false" 
                                                                                onclick="chkemail_Click" Width="21px" Height="21px" ImageUrl="../media/images/1.jpg"/>
                                                                        </td>
                                                                        <td style="width: 200px; height: 40px" align="left">
                                                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>                                                       
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                                                ControlToValidate="txtEmail" ErrorMessage="*" Height="16px" Width="16px"></asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                                                                                ControlToValidate="txtEmail" ErrorMessage="Invalid Email ID" 
                                                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">Invalid Email ID</asp:RegularExpressionValidator>
                                                                        </td>
                                                                        <td style="width:30px"></td> 
                                                                        <td style="width: 150px; height: 40px" align="left">
                                                                            <asp:Label ID="Label15" runat="server" CssClass="s_label" Text="Website"></asp:Label>
                                                                        </td>
                                                                        <td style="width: 200px; height: 40px" align="left">
                                                                            <asp:TextBox ID="txtweb" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
                                                                                ControlToValidate="txtweb" ErrorMessage="Invalid URL" 
                                                                                ValidationExpression="([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left"  style="height:40px">
                                                                            <asp:Label ID="Label11" runat="server" CssClass="s_label" Text="Fax"></asp:Label>
                                                                        </td>
                                                                        <td align="left" style="height:40px" >
                                                                            <asp:TextBox ID="txtfax" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" 
                                                                                ControlToValidate="txtfax" ErrorMessage="Only Numbers" 
                                                                                ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>
                                                                        </td>
                                                                        <td style="width:30px; height:40px">&nbsp;</td> 
                                                                        <td align="left" style="height:40px">
                                                                            <asp:Label ID="Label3" runat="server" CssClass="s_label" Text="Class Type"></asp:Label>
                                                                        </td>
                                                                        <td align="left"  style="height:40px">
                                                                              <asp:DropDownList ID="ddlclasstype" runat="server" CssClass="s_dropdown"  
                                                                                Width="150px">
                                                                              </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="height: 40px" align="left" colspan="5">
                                                                            <asp:Label ID="Label17" runat="server" CssClass="s_label" Text="School Transport"></asp:Label>
                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="rbty" runat="server" GroupName="transport" Text="Yes" CssClass="s_label" />
                                                                            <asp:RadioButton ID="rbtn" runat="server" GroupName="transport" Text="No" CssClass="s_label" />
                                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label16" runat="server" CssClass="s_label" Text="Hostel Facility"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="rbhy" runat="server" GroupName="hostel" Text="Yes" CssClass="s_label" />
                                                                            <asp:RadioButton ID="rbhn" runat="server" GroupName="hostel" Text="No" CssClass="s_label" />
                                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label5" runat="server" CssClass="s_label" Text="Library Facility"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="rbLy" runat="server" GroupName="library" Text="Yes" CssClass="s_label" />
                                                                            <asp:RadioButton ID="rbLn" runat="server" GroupName="library" Text="No" CssClass="s_label" />
                                                                        </td>
                                                                        
                                                                    </tr>
                                                                    <tr id="trgroup"  runat="server">
                                                                        <td style="width: 150px; height: 110px" align="left">
                                                                            <asp:Label ID="Label18" runat="server" CssClass="s_label" Text="Groups Available"></asp:Label>
                                                                        </td>
                                                                        <td align="left">                                                    
                                                                            <asp:Panel ID="pan" runat="server" Width="180px" BorderWidth="1px" BackColor="#F7F7F7" BorderColor="#1874CD" Height="100px" ScrollBars="Vertical" >
                                                                            <asp:CheckBoxList ID="chkgroups" runat="server" ></asp:CheckBoxList>
                                                                            </asp:Panel>
                                                                        </td>
                                                                        <td style="width:30px"></td> 
                                                                        <td style="width: 150px; height: 40px" align="left">
                                                                          <asp:Label ID="lblgroup" runat="server" Text="Add New Group" CssClass="s_label"></asp:Label>                                                        
                                                                        </td>
                                                                        <td style="width: 200px; height: 40px" align="left">
                                                                        <asp:TextBox ID="txtgroup" runat="server" CssClass="s_textbox" Width="130px"></asp:TextBox>
                                                                            &nbsp;&nbsp;<asp:Button ID="btngroup" runat="server" Text="Save" 
                                                                                onclick="btngroup_Click1" CssClass="s_button" /></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" style="width: 150px; height: 40px">
                                                                            &nbsp;</td>
                                                                        <td align="left">
                                                                            <asp:Button ID="btnSave" runat="server" CssClass="s_button" 
                                                                                onclick="btnSave_Click" Text="Next.." Width="60px" />
                                                                            &nbsp;<asp:Button ID="btnCancel" runat="server" CssClass="s_button" 
                                                                                Text="Cancel" Width="60px" CausesValidation="False" 
                                                                                Visible="False" onclick="btnCancel_Click" />
                                                                        </td>
                                                                        <td style="width:30px"></td> 
                                                                        <td align="left" style="width: 80px; height: 40px">
                                                                            &nbsp;</td>
                                                                        <td align="left" style="width: 200px; height: 40px">
                                                                            &nbsp;</td>
                                                                    </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height:5px;"></td>
                                                    </tr>
                                                </table>   
                                            <%--</ContentTemplate>
                                        </asp:UpdatePanel> --%> 
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
    <cc1:MsgBox id="msgbox" runat="server"></cc1:MsgBox>
    </div>
    </form>
</body>
</html>
