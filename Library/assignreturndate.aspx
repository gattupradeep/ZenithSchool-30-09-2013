<%@ Page Language="C#" AutoEventWireup="true" CodeFile="assignreturndate.aspx.cs" Inherits="Library_assignreturndate" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>

<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>

<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox" %>

<%@ Register src="../usercontrol/admin_library.ascx" tagname="admin_library" tagprefix="uc1" %>

<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>

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


    <style type="text/css">
        .style1
        {
            height: 20px;
        }
        .style2
        {
            height: 31px;
        }
        .style3
        {
            height: 33px;
        }
        .style4
        {
            height: 35px;
        }
        .style5
        {
            height: 41px;
        }
        .style6
        {
            height: 43px;
        }
        .style7
        {
            height: 45px;
        }
        .style8
        {
            height: 48px;
        }
        </style>


</head>
<body>
    <p>
        <br />
    </p>
    <form id="form1" runat="server">
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
                                        <uc1:admin_library ID="admin_library1" runat="server" />
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
                                                <td style="width: 50px; height: 50px"><img src="../media/images/moduleimg1.jpg" width="50" height="50" /></td>
                                                <td style="width: 685px; height: 50px; font-family: Arial; font-size: 23px; color: #2DA0ED; padding-left: 10px" align="left">
                                                    Issue Media</td>
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
                                                <td style="width: 700px; height: 20px" align="right">&nbsp;</td>
                                                <td style="width: 700px; height: 20px" align="right">&nbsp;</td>
                                                <td style="width: 700px; height: 20px" align="right">&nbsp;</td>
                                                <td style="width: 700px; height: 20px" align="right">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="style1">
                                                    <asp:Label ID="pat1" runat="server" CssClass="s_label" Text="Patron Type"></asp:Label>
                                                </td>
                                                <td align="left" class="style2">
                                                    <asp:DropDownList ID="ddl3" runat="server" Width="150px" 
                                                        CssClass="s_dropdown" AutoPostBack="True" 
                                                         >
                                                         <asp:ListItem Value= "employee" Text="employee"></asp:ListItem>
                                                         <asp:ListItem Value="student" Text="student"></asp:ListItem>
                                                    </asp:DropDownList>
                                                     </td>
                                                <td align="right" class="style7"></td>
                                                <td align="left" class="style8"></td>
                                                <td align="left" class="style8">&nbsp;</td>
                                                <td align="left" class="style8">&nbsp;</td>
                                                <td align="left" class="style8">&nbsp;</td>
                                                <td align="left" class="style8">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="style1">
                                                    <asp:Label ID="lablname" runat="server" Text="Name" CssClass="s_label"></asp:Label>
                                                </td>
                                                <td align="left" >
                                                    
                                                    
                                                    <asp:Label ID="lablnam" runat="server" CssClass="s_label"></asp:Label>
                                                </td>
                                                <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="style1">
                                                    <asp:Label ID="Lablstan" runat="server" Text="Standard" CssClass="s_label"></asp:Label>
                                                </td>
                                                <td align="left" >
                                                    
                                                    <asp:Label ID="Lablstd" runat="server" CssClass="s_label"></asp:Label>
                                                </td>
                                                <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="style1">
                                                    <asp:Label ID="Lablsec" runat="server" Text="Section" 
                                                        CssClass="s_label"></asp:Label>
                                                </td>
                                                <td align="left" class="style2">
                                                    
                                                    
                                                    <asp:Label ID="labsec" runat="server" CssClass="s_label"></asp:Label>
                                                </td>
                                                <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="style1">
                                                    <asp:Label ID="Label7" runat="server" Text="Media Type" CssClass="s_label"></asp:Label>
                                                </td>
                                                <td align="left" class="style2">
                                                   
                                                     
                                                    
                                                    <asp:DropDownList ID="ddlmt" runat="server" Width="150px" 
                                                        CssClass="s_dropdown">
                                                    </asp:DropDownList>
                                                    
                                                </td>
                                                <td align="left" class="style7"></td>
                                                <td align="left" class="style8"></td>
                                                <td align="left" class="style8">&nbsp;</td>
                                                <td align="left" class="style8">&nbsp;</td>
                                                <td align="left" class="style8">&nbsp;</td>
                                                <td align="left" class="style8">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="style3">
                                                    <asp:Label ID="Label8" runat="server" Text="Media Category" CssClass="s_label"></asp:Label>
                                                </td>
                                                <td align="left" class="style4">
                                                   
                                                         
                                                    <asp:DropDownList ID="ddlmc" runat="server" Width="150px" 
                                                        CssClass="s_dropdown">
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="right" class="style5"></td>
                                                <td align="left" class="style6"></td>
                                                <td align="left" class="style6">&nbsp;</td>
                                                <td align="left" class="style6">&nbsp;</td>
                                                <td align="left" class="style6">&nbsp;</td>
                                                <td align="left" class="style6">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="style3">
                                                    <asp:Label ID="Label9" runat="server" Text="No of Days" CssClass="s_label"></asp:Label>
                                                </td>
                                                <td align="left" class="style4">
                                                   
                                                         
                                                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                                </td>
                                                <td align="right" class="style5">&nbsp;</td>
                                                <td align="left" class="style6">&nbsp;</td>
                                                <td align="left" class="style6">&nbsp;</td>
                                                <td align="left" class="style6">&nbsp;</td>
                                                <td align="left" class="style6">&nbsp;</td>
                                                <td align="left" class="style6">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="style3">
                                                    <asp:Label ID="Label10" runat="server" Text="Upto" CssClass="s_label"></asp:Label>
                                                </td>
                                                <td align="left" class="style4">
                                                   
                                                         
                                                    <asp:TextBox ID="idupto1" runat="server"></asp:TextBox>
                                                </td>
                                                <td align="right" class="style5">
                                                    <asp:Label ID="Label11" runat="server" Text="Fine amount" CssClass="s_label"></asp:Label>
                                                </td>
                                                <td align="left" class="style6">
                                                    <asp:TextBox ID="idfine1" runat="server"></asp:TextBox>
                                                </td>
                                                <td align="left" class="style6">
                                                    <asp:Label ID="Label12" runat="server" Text="Upto" CssClass="s_label"></asp:Label>
                                                </td>
                                                <td align="left" class="style6">
                                                    <asp:TextBox ID="idupto2" runat="server"></asp:TextBox>
                                                </td>
                                                <td align="left" class="style6">
                                                    <asp:Label ID="Label13" runat="server" Text="Fine amount" CssClass="s_label"></asp:Label>
                                                </td>
                                                <td align="left" class="style6">
                                                    <asp:TextBox ID="idfine2" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td  style="height: 40px" align="right">
                                                    &nbsp;</td>
                                                <td align="left">
                                                    <asp:Button ID="Btnsave" runat="server" CssClass="s_button" 
                                                        Text="Save" />
                                                         &nbsp;
                                                    <asp:Button ID="btnclear" runat="server"  Text="Clear" />
                                                </td>
                                                <td style="width: 150px; height: 30px" align="left">&nbsp;</td>
                                                <td style="width: 200px; height: 30px" align="left">&nbsp;</td>
                                                <td style="width: 200px; height: 30px" align="left">&nbsp;</td>
                                                <td style="width: 200px; height: 30px" align="left">&nbsp;</td>
                                                <td style="width: 200px; height: 30px" align="left">&nbsp;</td>
                                                <td style="width: 200px; height: 30px" align="left">&nbsp;</td>
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
    <cc1:msgBox id="MsgBox1" style="Z-INDEX: 103; LEFT: 536px; POSITION: absolute; TOP: 184px" runat="server"></cc1:msgBox>
    </div>
    </form>
</body>
</html>
