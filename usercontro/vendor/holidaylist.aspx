<%@ Page Language="C#" AutoEventWireup="true" CodeFile="holidaylist.aspx.cs" Inherits="school_holidaylist" %>

<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>

<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>

<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>

<%@ Register src="../usercontrol/vendormaster.ascx" tagname="vendormaster" tagprefix="uc1" %>

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
                                        <uc1:vendormaster ID="vendormaster1" runat="server" />
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
                                                    Academic Holidays</td>
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
                                                    <asp:Label ID="Label1" runat="server" CssClass="s_label" Text="Year"></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                    <asp:DropDownList ID="ddlyear" runat="server" CssClass="s_dropdown">
                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 150px; height: 40px" align="right"></td>
                                                <td style="width: 200px; height: 40px" align="left"></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 150px; height: 40px" align="left">
                                                    <asp:Label ID="Label4" runat="server" CssClass="s_label" Text="Date"></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
      <asp:DropDownList ID="ddlday" runat="server" AutoPostBack="True" CssClass="s_dropdown">
                     <asp:ListItem Value="1">01</asp:ListItem>
                     <asp:ListItem Value="2">02</asp:ListItem>
                     <asp:ListItem Value="3">03</asp:ListItem>
                     <asp:ListItem Value="4">04</asp:ListItem>
                     <asp:ListItem Value="5">05</asp:ListItem>
                     <asp:ListItem Value="6">06</asp:ListItem>
                     <asp:ListItem Value="7">07</asp:ListItem>
                     <asp:ListItem Value="8">08</asp:ListItem>
                     <asp:ListItem Value="9">09</asp:ListItem>
                     <asp:ListItem Value="10">10</asp:ListItem>
                     <asp:ListItem Value="11">11</asp:ListItem>
                     <asp:ListItem Value="12">12</asp:ListItem>
                     <asp:ListItem Value="13">13</asp:ListItem>
                     <asp:ListItem Value="14">14</asp:ListItem>
                     <asp:ListItem Value="15">15</asp:ListItem>
                     <asp:ListItem Value="16">16</asp:ListItem>
                     <asp:ListItem Value="17">17</asp:ListItem>
                     <asp:ListItem Value="18">18</asp:ListItem>
                     <asp:ListItem Value="19">19</asp:ListItem>
                     <asp:ListItem Value="20">20</asp:ListItem>
                     <asp:ListItem Value="21">21</asp:ListItem>
                     <asp:ListItem Value="22">22</asp:ListItem>
                     <asp:ListItem Value="23">23</asp:ListItem>
                     <asp:ListItem Value="24">24</asp:ListItem>
                     <asp:ListItem Value="25">25</asp:ListItem>
                     <asp:ListItem Value="26">26</asp:ListItem>
                     <asp:ListItem Value="27">27</asp:ListItem>
                     <asp:ListItem Value="28">28</asp:ListItem>
                     <asp:ListItem Value="29">29</asp:ListItem>
                     <asp:ListItem Value="30">30</asp:ListItem>
                     <asp:ListItem Value="31">31</asp:ListItem>                     
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlmonth" runat="server" CssClass="s_dropdown">
                        <asp:ListItem Value="1">Jan</asp:ListItem>
                        <asp:ListItem Value="2">Feb</asp:ListItem>
                        <asp:ListItem Value="3">Mar</asp:ListItem>
                        <asp:ListItem Value="4">Apr</asp:ListItem>
                        <asp:ListItem Value="5">May</asp:ListItem>
                        <asp:ListItem Value="6">Jun</asp:ListItem>
                        <asp:ListItem Value="7">Jul</asp:ListItem>
                        <asp:ListItem Value="8">Aug</asp:ListItem>
                        <asp:ListItem Value="9">Sep</asp:ListItem>
                        <asp:ListItem Value="10">Oct</asp:ListItem>
                        <asp:ListItem Value="12">Nov</asp:ListItem>
                        <asp:ListItem Value="13">Dec</asp:ListItem>                        
                    </asp:DropDownList> 
                    <asp:DropDownList ID="ddlyear0" runat="server" CssClass="s_dropdown">
                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 150px; height: 40px" align="left">
                                                    <asp:Label ID="Label3" runat="server" CssClass="s_label" Text="Detail"></asp:Label>
                                                </td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:TextBox ID="txtdescription" runat="server" TextMode="MultiLine" 
                                                        Width="180px" CssClass="s_textbox"></asp:TextBox> 
                                                </td>
                                                <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 150px; height: 40px" align="left">
                                                    &nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">
                                                    <asp:CheckBox ID="chkpay" runat="server" CssClass="s_label" 
                                                        Text="Pay Leave" />    
                                                </td>
                                                <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
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
                                                <td colspan="2" style="width: 350px; height: 40px" align="left">
                                                    <asp:DataGrid ID="dgcalender" runat="server" AutoGenerateColumns="False" 
                                                        OnDeleteCommand="dgcalender_DeleteCommand" OnEditCommand="dgcalender_EditCommand" 
                                                        Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None">
                                                        <AlternatingItemStyle BackColor="White" />
                                                        <ItemStyle BackColor="#DEEDFF" Font-Names="Verdana" Font-Size="11px" 
                                                            Height="25px" />
                                                        <Columns>
                                                            <asp:BoundColumn DataField="ID" HeaderText="ID" Visible="false"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="dtdate" HeaderText="Date" HeaderStyle-HorizontalAlign="Center"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strdescription" HeaderText="Description" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">              
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="intpay" HeaderText="Pay" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"></asp:BoundColumn>
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
                                                <td style="width: 150px; height: 40px" align="left">&nbsp;</td>
                                                <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
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
