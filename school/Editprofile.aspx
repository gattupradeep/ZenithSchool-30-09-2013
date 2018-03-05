<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Editprofile.aspx.cs" Inherits="school_viewprofile" EnableEventValidation="false" %>

<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>

<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>

<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>

<%@ Register src="../usercontrol/school_profile.ascx" tagname="school_profile" tagprefix="uc5" %>

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
    
     <script type="text/javascript" language="javascript">        
         $(function() {
             $('#slider').anythingSlider();
         });
         var objChkd;

         function HandleOnCheck() {
             var chkLst = document.getElementById('chkschooltype');
             if (objChkd && objChkd.checked)
                 objChkd.checked = false; objChkd = event.srcElement;
         }
         $(function() {
             function checkboxclicked() {
                 var n = $("#list input:checked").length;
                 $("input:#txtcheckbox").val(n == 0 ? "" : n);
             }
             $(":checkbox").click(checkboxclicked);
         });
	</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td>
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
                        <td style="width: 2%" valign="top">
                        </td>
                        <td style="width: 93%" valign="top" align="left">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr class="app_container_title">
                                    <td style="width: 100%; height: 50px" align="left">
                                        <table cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td class="app_cont_title_img_td"><img src="../media/images/moduleimg1.jpg" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left" > School Profile</td>
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
                                    <td style="width: 100%; height: 100px; padding-left: 5px" valign="top" align="left">
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
                                                 <table cellpadding="0" cellspacing="0" border="0" class="app_container">
                                            <tr class="view_detail_title_bg" >
                                                <td align="left" colspan="6" >
                                                   <asp:Label CssClass="title_label" ID="lbltit" runat="server" Text="Edit School Profile" ></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 175px; height: 40px">
                                                    <asp:Label ID="Label11" runat="server" CssClass="s_label" 
                                                        Text="Your School Name"></asp:Label>
                                                </td>
                                                <td colspan="3" align="left" style="width: 375px; height: 40px">
                                                    <asp:TextBox ID="txtschoolname" runat="server" CssClass="s_textbox" 
                                                        Width="350px"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" 
                                                        ControlToValidate="txtschoolname" ErrorMessage="*" Height="16px" Width="16px"></asp:RequiredFieldValidator>
                                                </td>
                                                <td align="center" style="width: 150px; height: 40px">
                                                    &nbsp;</td>
                                                <td align="left" style="width: 50px; height: 40px"></td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 175px; height: 40px">
                                                    <asp:Label ID="Label12" runat="server" CssClass="s_label" 
                                                        Text="Your Name"></asp:Label>
                                                </td>
                                                <td colspan="3" align="left" style="width: 375px; height: 40px">
                                                    <asp:TextBox ID="txtname" runat="server" CssClass="s_textbox" Width="190px"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" 
                                                        ControlToValidate="txtemail" ErrorMessage="*" Height="16px" Width="16px"></asp:RequiredFieldValidator>
                                                </td>
                                                <td align="center" style="width: 150px; height: 40px">
                                                    &nbsp;</td>
                                                <td align="left" style="width: 50px; height: 40px">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 175px; height: 40px">
                                                    <asp:Label ID="Label13" runat="server" CssClass="s_label" 
                                                        Text="Email ID"></asp:Label>
                                                </td>
                                                <td colspan="3" align="left" style="width: 375px; height: 40px">
                                                    <asp:TextBox ID="txtemail" runat="server" Width="190px" CssClass="s_textbox"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                                                        ControlToValidate="txtemail" ErrorMessage="*" Height="16px" Width="16px"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator 
                                                                        ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtemail" 
                                                                        ErrorMessage="Invalid Email ID" 
                                                                        
                                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">Invalid Email ID</asp:RegularExpressionValidator>
                                                </td>
                                                <td colspan="2" align="left" style="width: 200px; height: 40px">
                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Label ID="lblemailmsg" runat="server" Font-Bold="True" ForeColor="Red" 
                                                                CssClass="s_label"></asp:Label>
                                                            <asp:ImageButton ID="chkemail" runat="server" CausesValidation="false" 
                                                                onclick="chkemail_Click" Width="1px" Height="1px" 
                                                                ImageUrl="~/media/images/1.jpg"/>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 175px; height: 40px">
                                                    <asp:Label ID="Label14" runat="server" CssClass="s_label" 
                                                        Text="Phone Number"></asp:Label>
                                                </td>
                                                <td colspan="3" align="left" style="width: 375px; height: 40px">
                                                    <asp:TextBox ID="txtphone" runat="server" CssClass="s_textbox" Width="190px"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                                                        ControlToValidate="txtphone" ErrorMessage="*" Height="16px" Width="16px"></asp:RequiredFieldValidator>
                                                </td>
                                                <td align="center" style="width: 150px; height: 40px">
                                                    &nbsp;</td>
                                                <td align="left" style="width: 50px; height: 40px">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 175px; height: 40px">
                                                    <asp:Label ID="Label15" runat="server" CssClass="s_label" 
                                                        Text="Address"></asp:Label>
                                                </td>
                                                <td colspan="3" align="left" style="width: 375px; height: 40px">
                                                    <asp:TextBox ID="txtaddress" runat="server" Width="350px" CssClass="s_textbox"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                                                        ControlToValidate="txtaddress" ErrorMessage="*" Height="16px" Width="16px"></asp:RequiredFieldValidator>
                                                </td>
                                                <td align="center" style="width: 150px; height: 40px">
                                                    &nbsp;</td>
                                                <td align="left" style="width: 50px; height: 40px">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 175px; height: 40px">
                                                    <asp:Label ID="Label16" runat="server" CssClass="s_label" 
                                                        Text="Country"></asp:Label>
                                                </td>
                                                <td colspan="3" align="left" style="width: 375px; height: 40px">
                                                    <asp:DropDownList ID="ddlcountry" runat="server" 
                                                        onselectedindexchanged="ddlcountry_SelectedIndexChanged" Width="140px" 
                                                        CssClass="s_textbox">
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="center" style="width: 150px; height: 40px">
                                                    &nbsp;</td>
                                                <td align="left" style="width: 50px; height: 40px">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 175px; height: 40px">
                                                    <asp:Label ID="Label17" runat="server" CssClass="s_label" 
                                                        Text="State"></asp:Label>
                                                </td>
                                                <td colspan="3" align="left" style="width: 375px; height: 40px">
                                                    <asp:DropDownList ID="ddlstate" runat="server" 
                                                        onselectedindexchanged="ddlstate_SelectedIndexChanged" Width="140px" 
                                                        CssClass="s_textbox"></asp:DropDownList>
                                                </td>
                                                <td align="center" style="width: 150px; height: 40px">
                                                    &nbsp;</td>
                                                <td align="left" style="width: 50px; height: 40px">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 175px; height: 40px">
                                                    <asp:Label ID="Label18" runat="server" CssClass="s_label" Text="City"></asp:Label>
                                                </td>
                                                <td colspan="3" align="left" style="width: 375px; height: 40px">
                                                    <asp:DropDownList ID="ddlcity" runat="server" Width="140px" 
                                                        CssClass="s_textbox"></asp:DropDownList>
                                                </td>
                                                <td align="center" style="width: 150px; height: 40px">
                                                    &nbsp;</td>
                                                <td align="left" style="width: 50px; height: 40px">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 175px; height: 40px">
                                                    <asp:Label ID="Label19" runat="server" CssClass="s_label" 
                                                        Text="Zipcode"></asp:Label>
                                                </td>
                                                <td colspan="3" align="left" style="width: 375px; height: 40px">
                                                    <asp:TextBox ID="txtpincode" runat="server" Width="140px" CssClass="s_textbox"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                                                        ControlToValidate="txtpincode" ErrorMessage="*" Height="16px" Width="16px"></asp:RequiredFieldValidator>
                                                </td>
                                                <td align="center" style="width: 150px; height: 40px">
                                                    &nbsp;</td>
                                                <td align="left" style="width: 50px; height: 40px">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 175px; height: 40px">
                                                    <asp:Label ID="Label20" runat="server" CssClass="s_label" 
                                                        Text="Password"></asp:Label>
                                                </td>
                                                <td colspan="3" align="left" style="width: 375px; height: 40px">
                                                    <asp:TextBox ID="txtpassword" runat="server" TextMode="Password" Width="140px" 
                                                        CssClass="s_textbox"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtpassword" ErrorMessage="*" Height="16px" Width="16px"></asp:RequiredFieldValidator>
                                                </td>
                                                <td align="center" style="width: 150px; height: 40px">
                                                    &nbsp;</td>
                                                <td align="left" style="width: 50px; height: 40px">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 175px; height: 40px">
                                                    <asp:Label ID="Label1" runat="server" CssClass="s_label" Text="Confirm Password"></asp:Label>
                                                </td>
                                                <td colspan="3" align="left" style="width: 375px; height: 40px">
                                                    <asp:TextBox ID="txtcpassword" runat="server" TextMode="Password" Width="140px" 
                                                        CssClass="s_textbox"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtcpassword" ErrorMessage="*" Height="16px" Width="16px"></asp:RequiredFieldValidator>
                                                 <asp:CompareValidator ID="cmp" runat="server" ControlToValidate="txtcpassword" ControlToCompare="txtpassword"></asp:CompareValidator>
                                                </td>
                                                <td align="center" style="width: 150px; height: 40px">
                                                    &nbsp;</td>
                                                <td align="left" style="width: 50px; height: 40px">&nbsp;</td>
                                            </tr>
                                            <tr id="trsubdomain" runat="server">
                                                <td align="left" style="width: 175px; height: 40px">
                                                    <asp:Label ID="Label21" runat="server" CssClass="s_label" 
                                                        Text="Your Subdomain"></asp:Label>
                                                </td>
                                                <td colspan="3" align="left" style="width: 375px; height: 40px" class="s_label">
                                                    http://<asp:TextBox ID="txtweb" runat="server" CssClass="s_textbox" Width="190px"></asp:TextBox>.theschools.in<asp:RequiredFieldValidator 
                                                        ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtcpassword" 
                                                        ErrorMessage="*" Height="16px" Width="16px"></asp:RequiredFieldValidator></td>
                                                <td align="left" style="width: 150px; height: 40px">
                                                </td>
                                                <td align="left" style="width: 50px; height: 40px">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 175px; height: 40px">
                                                    <asp:Label ID="Label22" runat="server" CssClass="s_label" 
                                                        Text="School is a"></asp:Label>
                                                </td>
                                                <td colspan="3" align="left" style="width: 375px; height: 40px">
                                                    <asp:CheckBoxList ID="chkschooltype" runat="server" ValidationGroup="testgroup" 
                                                    RepeatColumns="2" CssClass="s_label" 
                                                        onselectedindexchanged="chkschooltype_SelectedIndexChanged">
                                                    </asp:CheckBoxList>
                                                </td>
                                                <td align="center" style="width: 150px; height: 40px">
                                                    <asp:Label ID="lbltypemsg" runat="server" Font-Bold="True" ForeColor="Red" 
                                                        CssClass="s_label"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 50px; height: 40px">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 175px; height: 40px">
                                                    <asp:Label ID="Label23" runat="server" CssClass="s_label" 
                                                        Text="Number of Students"></asp:Label>
                                                </td>
                                                <td colspan="3" align="left" style="width: 375px; height: 40px">
						                                            <asp:DropDownList ID="ddlnoofstudents" runat="server" Height="20px" 
                                                                        style="text-align:center">
                                                                        <asp:ListItem>-Select-</asp:ListItem>
						                                                <asp:ListItem Value="1">1-100</asp:ListItem>
                                                                        <asp:ListItem Value="2">101-500</asp:ListItem>
                                                                        <asp:ListItem Value="3">501-1000</asp:ListItem>
                                                                        <asp:ListItem Value="4">1001-2000</asp:ListItem>
                                                                        <asp:ListItem Value="5">2001-3000</asp:ListItem>
                                                                        <asp:ListItem Value="6">3001-4000</asp:ListItem>
                                                                        <asp:ListItem Value="7">4001-5000</asp:ListItem>
                                                                        <asp:ListItem Value="8">5001-6000</asp:ListItem>
                                                                        <asp:ListItem Value="9">6001-7000</asp:ListItem>
                                                                        <asp:ListItem Value="10">7001-8000</asp:ListItem>
                                                                        <asp:ListItem Value="11">8001-9000</asp:ListItem>
                                                                        <asp:ListItem Value="12">9001-10000</asp:ListItem>
                                                                        <asp:ListItem Value="13">10001-15000</asp:ListItem>
                                                                        <asp:ListItem Value="14">15001-20000</asp:ListItem>                                                                        
                                                                        </asp:DropDownList>
                                                </td>
                                                <td align="center" style="width: 150px; height: 40px">
                                                    &nbsp;</td>
                                                <td align="left" style="width: 50px; height: 40px">&nbsp;</td>
                                            </tr>
                                            <tr>&nbsp;&nbsp;
                                                <td align="left" style="width: 175px; height: 40px">
                                                    &nbsp;</td>
                                                <td align="left" style="width: 150px; height: 40px">
	                                                <asp:Button ID="btnupdate" runat="server" Text="Update" 
                                                        onclick="btnupdate_Click" CssClass="s_button" Width="70px" />
                                                    &nbsp; 
                                                    <asp:Button ID="btncancel" runat="server" Text="Cancel" 
                                                        onclick="btncancel_Click" CssClass="s_button" Width="70px" />
                                                </td>
                                                <td align="left" style="width: 50px; height: 40px"> 
                                                    &nbsp;</td>
                                                <td align="center" style="width: 175px; height: 40px">
						                                            &nbsp;</td>
                                                <td align="center" style="width: 150px; height: 40px">                                                                                                                                                                                                      
                                                    &nbsp;</td>
                                                <td align="left" style="width: 50px; height: 40px">
                                                        &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="6" style="width: 710px; height: 40px">
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
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
            <td style="width: 100%; " align="left" valign="top" >
                <uc6:app_footer ID="app_footer" runat="server" />
            </td>
        </tr>
    </table>
    <cc1:MsgBox id="msgbox" runat="server"></cc1:MsgBox>
    </div>
    </form>
</body>
</html>

