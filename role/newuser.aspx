<%@ Page Language="C#" AutoEventWireup="true" CodeFile="newuser.aspx.cs" Inherits="admin_newuser" %>

<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>

<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>

<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>

<%@ Register src="../usercontrol/admin_role.ascx" tagname="admin_role" tagprefix="uc1" %>
<%@ Register Src="../usercontrol/footer.ascx" TagName="app_footer" TagPrefix="uc6" %>
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
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
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
                                        <uc1:admin_role ID="admin_role1" runat="server" />
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
                                <tr>
                                    <td style="width: 100%; height: 50px" align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" width="750">
                                            <tr>
                                                <td style="width: 50px; height: 50px"><img src="../images/icons/50X50/79.png" width="50" height="50" /></td>
                                                <td style="width: 685px; height: 50px; font-family: Arial; font-size: 23px; color: #2DA0ED; padding-left: 10px" align="left">
                                                    Add / Edit Admin User</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 8px; background-image: url(../media/images/bline.jpg)"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 10px"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 50px" valign="top" align="left">
                                         <asp:UpdateProgress ID="Updateprocess" runat="server" AssociatedUpdatePanelID="updatepanal" DisplayAfter="1" >
                                                <ProgressTemplate>
                                                    <div id="progressBackgroundFilter"></div>
                                                        <div id="processMessage">
                                                            <img alt="Loading" src="../media/images/Processing.gif" />
                                                        </div>
                                                </ProgressTemplate>
                                         </asp:UpdateProgress>
                                        <asp:UpdatePanel ID="updatepanal" runat="server" >
                                                <ContentTemplate>
                                                        <table cellpadding="0" cellspacing="0" border="0" width="710">
                                            <tr>
                                                <td style="width: 710px" align="center">
                                                    <table cellpadding="0" cellspacing="0" border="0" width="710">
                                                        <tr>
                                                            <td colspan="4" align="left" style="width: 710px; height: 40px" class="s_label">
                                                                <strong>Enter Staff Details : </strong>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label1" runat="server" CssClass="s_label" Text="User Type :  "></asp:Label>
                                                                </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="s_dropdown" 
                                                                        Width="130px">
                                                                        <asp:ListItem>Staffs</asp:ListItem>
                                                                        <asp:ListItem>Others</asp:ListItem>
                                                                    </asp:DropDownList>
                                                            </td>
                                                            <td align="left" style="width: 30px; height: 40px"></td>
                                                            <td align="left" style="width: 125px; height: 40px"></td>
                                                            <td align="left" style="width: 200px; height: 40px"></td>
                                                            <td align="left" style="width: 30px; height: 40px"></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label2" runat="server" CssClass="s_label" Text="Username :  "></asp:Label>
                                                                </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                    <input id="txtUserName" runat="server" class="s_textbox" maxlength="40" 
                                                                        name="strUsername" style="border: 1px solid #0099FF; width: 130px" /></td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName"
                                                                        ErrorMessage="*" Width="7px" CssClass="style10"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label9" runat="server" CssClass="s_label" Text="Address :  "></asp:Label>
                                                                </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <input id="txtAddress" runat="server" class="frmfield" maxlength="150" 
                                                                    name="strAdress1" style="border: 1px solid #0099FF;width: 130px" size="20" /></td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                <asp:RequiredFieldValidator ID="Requiredfieldvalidator4" runat="server" ControlToValidate="txtAddress"
                                                                    Display="Dynamic" Enabled="False" ErrorMessage="*" Visible="False" 
                                                                    Width="7px" CssClass="style10"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label3" runat="server" CssClass="s_label" Text="Password :  "></asp:Label>
                                                                </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:TextBox ID="txtPassword" runat="server" CssClass="frmfield" MaxLength="40"
                                                                    TextMode="Password" Width="130px" BorderColor="#0099FF" 
                                                                BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                </td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword"
                                                                    ErrorMessage="*" Width="7px"></asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="Min. 6 Char." Height="2px" Text="Min 5 Characters." ValidationExpression=".{6,16}"></asp:RegularExpressionValidator>
                                                            </td>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label10" runat="server" CssClass="s_label" Text="Country :  "></asp:Label>
                                                                </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <input id="txtCounty" runat="server" class="frmfield" maxlength="150" name="strCounty"
                                                                    size="21" style="border: 1px solid #0099FF;width: 130px" /></td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                <asp:RequiredFieldValidator ID="Requiredfieldvalidator8" runat="server" ControlToValidate="txtCounty"
                                                                    Display="Dynamic" Enabled="False" ErrorMessage="*" Visible="False" 
                                                                    Width="7px" CssClass="style10"></asp:RequiredFieldValidator></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label4" runat="server" CssClass="s_label" 
                                                                    Text="Confirm Password :  "></asp:Label>
                                                                </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="frmfield"
                                                                    MaxLength="40" TextMode="Password" Width="130px" BorderColor="#0099FF" 
                                                                    BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                                                </td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                <asp:RequiredFieldValidator ID="Requiredfieldvalidator10" runat="server" ControlToValidate="txtConfirmPassword"
                                                                    ErrorMessage="*" Width="7px"></asp:RequiredFieldValidator>
                                                                <asp:CompareValidator
                                                                        ID="cvPassword" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword"
                                                                        Display="Dynamic" ErrorMessage="Password Mismatch" Operator="Equal" Text="Password Mismatch"
                                                                        Type="String" CssClass="style10"></asp:CompareValidator>
                                                                <asp:RegularExpressionValidator ID="valCPasswordLength" runat="server" ControlToValidate="txtConfirmPassword"
                                                                    Display="Dynamic" ErrorMessage="Min 6 Characters." 
                                                                    Text="Min 5 Characters." ValidationExpression=".{6,16}" CssClass="style10"></asp:RegularExpressionValidator>
                                                            </td>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label11" runat="server" CssClass="s_label" Text="Area :  "></asp:Label>
                                                                </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <input id="txtArea" runat="server" class="frmfield" maxlength="150" name="strAdress"
                                                                    size="21" style="border: 1px solid #0099FF;width: 130px" /></td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                <asp:RequiredFieldValidator ID="ReqArea" runat="server" ControlToValidate="txtArea"
                                                                    Display="Dynamic" Enabled="False" ErrorMessage="*" Visible="False" 
                                                                    Width="7px" CssClass="style10"></asp:RequiredFieldValidator></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label5" runat="server" CssClass="s_label" Text="First Name :  "></asp:Label>
                                                                </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <input id="txtFirstName" runat="server" class="frmfield" maxlength="40" name="strFirstName"
                                                                    size="16" style="border: 1px solid #0099FF;width: 130px" /></td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFirstName"
                                                                    ErrorMessage="*" Width="7px" CssClass="style10"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label12" runat="server" CssClass="s_label" Text="Town :  "></asp:Label>
                                                                </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <label>
                                                                    <input id="city" runat="server" class="frmfield" maxlength="40" name="City" size="21"
                                                                        style="border: 1px solid #0099FF;width: 130px" /></label></td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                <label>
                                                                    <asp:RequiredFieldValidator ID="Requiredfieldvalidator3" runat="server" ControlToValidate="city"
                                                                        Display="Dynamic" Enabled="False" ErrorMessage="*" Visible="False" 
                                                                    Width="7px" CssClass="style10"></asp:RequiredFieldValidator></label></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label6" runat="server" CssClass="s_label" Text="Last Name : "></asp:Label>
                                                                </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <input id="txtLastName" runat="server" class="frmfield" maxlength="40" name="strLastName"
                                                                    size="16" style="border: 1px solid #0099FF;width: 130px" /></td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtLastName"
                                                                    ErrorMessage="*" Width="7px" CssClass="style10"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label13" runat="server" CssClass="s_label" Text="Post Code :  "></asp:Label>
                                                                </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <input id="txtPin" runat="server" class="frmfield" maxlength="10" name="strPin" size="20"
                                                                    style="border: 1px solid #0099FF;width: 130px" /></td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                <asp:RequiredFieldValidator ID="Pinvalidator" runat="server" ControlToValidate="txtPin"
                                                                    Enabled="False" ErrorMessage="*" Visible="False" Width="7px" 
                                                                    CssClass="style10"></asp:RequiredFieldValidator></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label7" runat="server" CssClass="s_label" Text="Phone No :  "></asp:Label>
                                                                </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <input id="txtPh" runat="server" class="frmfield" maxlength="15" name="txtPh" size="20"
                                                                    style="border: 1px solid #0099FF;width: 130px" type="text" /></td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                <asp:RequiredFieldValidator ID="Requiredfieldvalidator9" runat="server" ControlToValidate="txtPh"
                                                                    Enabled="False" ErrorMessage="*" Visible="False" Width="7px" 
                                                                    CssClass="style10"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label14" runat="server" CssClass="s_label" Text="Email :  "></asp:Label>
                                                                </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <input id="txtEMail" runat="server" class="frmfield" maxlength="60" name="strEmail1"
                                                                    size="21" style="border: 1px solid #0099FF;width: 130px" /></td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtEMail"
                                                                    ErrorMessage="*" 
                                                                    ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                                                    CssClass="style10"></asp:RegularExpressionValidator>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtEMail"
                                                                    ErrorMessage="*" Width="7px" CssClass="style10"></asp:RequiredFieldValidator></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label8" runat="server" CssClass="s_label" Text="Mobile No :  "></asp:Label>
                                                                </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <input id="txtMobile" runat="server" class="frmfield" maxlength="15" name="txtMobile"
                                                                    size="20" style="border: 1px solid #0099FF;width: 130px" type="text" /></td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                <asp:RequiredFieldValidator ID="Requiredfieldvalidator11" runat="server" ControlToValidate="txtMobile"
                                                                    Enabled="False" ErrorMessage="*" Visible="False" Width="7px" 
                                                                    CssClass="style10"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                <asp:Label ID="Label15" runat="server" CssClass="s_label" Text="Fax :  "></asp:Label>
                                                                </td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <input id="txtFax1" runat="server" class="frmfield" maxlength="15" name="strEmail"
                                                                    size="21" style="border: 1px solid #0099FF;width: 130px" /></td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                <asp:RequiredFieldValidator ID="Requiredfieldvalidator12" runat="server" ControlToValidate="txtFax1"
                                                                    Enabled="False" ErrorMessage="*" Visible="False" Width="7px" 
                                                                    CssClass="style10"></asp:RequiredFieldValidator></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" style="width: 125px; height: 40px">
                                                                &nbsp;</td>
                                                            <td align="left" style="width: 200px; height: 40px">
                                                                <asp:RadioButton ID="optactive" runat="server" Checked="True" 
                                                                    CssClass="s_label" GroupName="active" Text="Active" />
                                                                <asp:RadioButton ID="optdeactive" runat="server" CssClass="s_label" 
                                                                    GroupName="active" Text="Deactive" />
                                                                </td>
                                                            <td align="left" style="width: 30px; height: 40px">
                                                                &nbsp;</td>
                                                            <td align="left" style="width: 125px; height: 40px">&nbsp;</td>
                                                            <td align="left" style="width: 200px; height: 40px">&nbsp;</td>
                                                            <td align="left" style="width: 30px; height: 40px">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="border" colspan="6" valign="top">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="s_label" colspan="6" valign="top">
                                                                <strong>Choose Modules</strong></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" colspan="6" valign="top">
                                                                <asp:Panel ID="Panel1" runat="server" CssClass="frmlabel" HorizontalAlign="Justify"
                                                                    Width="710px">
                                                                </asp:Panel>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="border" colspan="6" valign="top">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 700px; height: 40px;" align="center">
                                                    <asp:Button ID="btnsave" runat="server" Font-Bold="False"
                                                        Height="25px" OnClick="btnsave_Click" Text="Save User" 
                                                        CssClass="s_button" />
                                                </td>
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
            <td style="width: 100%;" align="left" valign="top">
                <uc6:app_footer ID="footer" runat="server" />
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
