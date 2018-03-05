<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Subject.aspx.cs" Inherits="admin_Subject" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>

<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>
<%@ Register src="../usercontrol/vendormaster.ascx" tagname="vendormaster" tagprefix="uc5" %>
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
            <td style="width: 100%; height: 20px" valign="top">
            </td>
        </tr>
        <tr>
            <td style="width: 100%; height: 400px" align="left" valign="top">
               <%--  <asp:UpdateProgress ID="Updateprocess" runat="server" AssociatedUpdatePanelID="updatepanal" DisplayAfter="1" >
                        <ProgressTemplate>
                            <div id="progressBackgroundFilter"></div>
                                <div id="processMessage">
                                    <img alt="Loading" src="../media/images/Processing.gif" />
                                </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>--%>
                    <asp:UpdatePanel ID="updatepanal" runat="server" >
                                <ContentTemplate>
                                          <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td style="width: 5%" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" width="230">
                                <tr>
                                    <td style="width: 230px" align="right">
                                        <uc5:vendormaster ID="vendormaster1" runat="server" />
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
                                                    Add / Edit Subject</td>
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
                                                    <asp:Label ID="Label1" runat="server" CssClass="s_label" Text="Subject Name:"></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:TextBox ID="txtsubject" runat="server" CssClass="s_textbox" Width="180px"></asp:TextBox>
                                                </td>
                                                <td style="width: 150px; height: 40px" align="right"></td>
                                                <td style="width: 200px; height: 40px" align="left"></td>
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
                                                <td colspan="2" style="width: 350px; height: 40px" align="left">
                                                    <asp:DataGrid ID="dgboard" runat="server" AutoGenerateColumns="False"                                                     
                                                        Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None" 
                                                        ondeletecommand="dgboard_DeleteCommand" oneditcommand="dgboard_EditCommand">
                                                        <AlternatingItemStyle BackColor="White" />
                                                        <ItemStyle BackColor="#DEEDFF" Font-Names="Verdana" Font-Size="11px" 
                                                            Height="25px" />
                                                        <Columns>
                                                            <asp:BoundColumn DataField="intID" HeaderText="ID" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strsubject" HeaderText="Subject">
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
                                                            Font-Size="12px" ForeColor="White" Height="30px" />
                                                    </asp:DataGrid>
                                                </td>
                                                <td style="width: 150px; height: 30px" align="left">&nbsp;</td>
                                                <td style="width: 200px; height: 30px" align="left">&nbsp;</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                                </ContentTemplate>
                    </asp:UpdatePanel>
            </td>
        </tr>
         <tr><td class="break"></td></tr>
        <tr>
            <td style="width: 100%; " align="left" valign="top" >
                    
                 <uc6:app_footer ID="footer" runat="server" />
            </td>
        </tr>
    </table>
    <cc1:MsgBox id="msgbox" runat="server"></cc1:MsgBox>
    </div>
    </form>
</body>
</html>