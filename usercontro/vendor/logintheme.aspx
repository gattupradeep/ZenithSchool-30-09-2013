<%@ Page Language="C#" AutoEventWireup="true" CodeFile="logintheme.aspx.cs" Inherits="vendor_logintheme" %>

<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>

<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>

<%@ Register src="../usercontrol/vendormaster.ascx" tagname="vendormaster" tagprefix="uc4" %>

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
    <div>
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td style="width: 100%; height: 144px" align="left">
                <uc3:topbanner ID="topbanner1" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="width: 100%; height: 20px" valign="top">
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
                                        <uc4:vendormaster ID="vendormaster1" runat="server" />
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
                                                <td style="width: 50px; height: 50px"><img src="../media/images/moduleimg1.jpg" width="50" height="50" /></td>
                                                <td style="width: 685px; height: 50px; font-family: Arial; font-size: 23px; color: #2DA0ED; padding-left: 10px" align="left">
                                                    Add / Edit Theme</td>
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
                                        <table cellpadding="0" cellspacing="0" border="0" width="700">
                                            <tr>
                                                <td colspan="4" style="width: 700px; height: 20px" align="right">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 150px; height: 40px" align="left">
                                                    <asp:Label ID="Label2" runat="server" CssClass="s_label" 
                                                        Text="Background Color :"></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:TextBox ID="txtbackground" runat="server" CssClass="s_textbox" Width="120px"></asp:TextBox>
                                                    &nbsp;eg. FFFFFF</td>
                                                <td style="width: 150px; height: 40px" align="left">
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                                        CssClass="s_label" ErrorMessage="Invalid Color Code" 
                                                        ValidationExpression="^[a-zA-Z0-9]{1,6}$" 
                                                        ControlToValidate="txtbackground"></asp:RegularExpressionValidator>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left"></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 150px; height: 40px" align="left">
                                                    <asp:Label ID="Label3" runat="server" CssClass="s_label" 
                                                        Text="Navigation Color :"></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:TextBox ID="txtnavigation" runat="server" CssClass="s_textbox" Width="120px"></asp:TextBox>
                                                    &nbsp;e.g FFFFFF</td>
                                                <td style="width: 150px; height: 40px" align="left">
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                                        CssClass="s_label" ErrorMessage="Invalid Color Code" 
                                                        ValidationExpression="^[a-zA-Z0-9]{1,6}$" 
                                                        ControlToValidate="txtnavigation"></asp:RegularExpressionValidator>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 150px; height: 40px" align="left">
                                                    <asp:Label ID="Label4" runat="server" CssClass="s_label" Text="Footer Color :"></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:TextBox ID="txtfooter" runat="server" CssClass="s_textbox" Width="120px"></asp:TextBox>
                                                    &nbsp;e.g FFFFFF</td>
                                                <td style="width: 150px; height: 40px" align="left">
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                                                        CssClass="s_label" ErrorMessage="Invalid Color Code" 
                                                        ValidationExpression="^[a-zA-Z0-9]{1,6}$" ControlToValidate="txtfooter"></asp:RegularExpressionValidator>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 150px; height: 40px" align="left">
                                                    <asp:Label ID="Label5" runat="server" CssClass="s_label" 
                                                        Text="Image Gallery Title :"></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:TextBox ID="txttitle" runat="server" CssClass="s_textbox" Width="120px"></asp:TextBox>
                                                    &nbsp;e.g FFFFFF</td>
                                                <td style="width: 150px; height: 40px" align="left">
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                                                        CssClass="s_label" ErrorMessage="Invalid Color Code" 
                                                        ValidationExpression="^[a-zA-Z0-9]{1,6}$" ControlToValidate="txttitle"></asp:RegularExpressionValidator>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:Button ID="btnSave" runat="server" CssClass="s_button" Text="Save" 
                                                        Width="60px" onclick="btnSave_Click"/>
                                                    &nbsp;
                                                    <asp:Button ID="btnClear" runat="server" CssClass="s_button" Text="Clear" 
                                                        Width="60px" onclick="btnClear_Click" />
                                                </td>
                                                <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="width: 700px; height: 40px" align="left">
                                                    <asp:DataGrid ID="dgdesig" runat="server" AutoGenerateColumns="False" 
                                                        Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None" 
                                                        ondeletecommand="dgdesig_DeleteCommand" oneditcommand="dgdesig_EditCommand">
                                                        <AlternatingItemStyle BackColor="White" />
                                                        <ItemStyle BackColor="#DEEDFF" Font-Names="Verdana" Font-Size="11px" 
                                                            Height="70px" HorizontalAlign="Center" />
                                                        <Columns>
                                                            <asp:BoundColumn DataField="intid" HeaderText="ID" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strbackground" HeaderText="Background" 
                                                                Visible="False">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strnavigation" HeaderText="Navigation" 
                                                                Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strfooter" HeaderText="Footer" Visible="False">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strimagestitle" HeaderText="Image Title " 
                                                                Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strback" HeaderText="Background Color">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strnav" HeaderText="Navigation Back Color">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strfoot" HeaderText="Footer Color">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strtitle" HeaderText="Image Gallery Title">
                                                            </asp:BoundColumn>
                                                            <asp:ButtonColumn CommandName="edit" HeaderText="Edit" 
                                                                Text="&lt;img src=&quot;../media/images/edit.gif&quot; alt=&quot;Edit&quot; border=&quot;0&quot; /&gt;">
                                                                <ItemStyle Width="40px" />
                                                            </asp:ButtonColumn>
                                                            <asp:ButtonColumn CommandName="delete" HeaderText="Delete" 
                                                                Text="&lt;img src=&quot;../media/images/delete.gif&quot; alt=&quot;Delete&quot; border=&quot;0&quot; /&gt;">
                                                                <ItemStyle Width="50px" />
                                                            </asp:ButtonColumn>
                                                        </Columns>
                                                        <HeaderStyle BackColor="#6694DF" Font-Bold="True" Font-Names="Verdana" 
                                                            Font-Size="12px" ForeColor="White" Height="30px" 
                                                            HorizontalAlign="Center" />
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
        <tr>
            <td style="width: 100%; height: 50px" align="left" valign="top" class="footer">
            </td>
        </tr>
    </table>
    <cc1:MsgBox id="msgbox" runat="server"></cc1:MsgBox>
    </div>
    </form>
</body>
</html>
