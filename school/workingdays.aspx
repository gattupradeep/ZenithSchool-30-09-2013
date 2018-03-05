<%@ Page Language="C#" AutoEventWireup="true" CodeFile="workingdays.aspx.cs" Inherits="school_workingdays" %>

<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>

<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

<%@ Register src="../usercontrol/school_profile.ascx" tagname="school_profile" tagprefix="uc4" %>

<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>

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
    
    <link rel="stylesheet" href="../include/jquery-ui-1.8.14.custom.css" type="text/css" />
    <link rel="stylesheet" href="../jquery-ui-timepicker.css?v=0.2.3" type="text/css" />
    <script type="text/javascript" src="../include/jquery-1.5.1.min.js"></script>
    <script type="text/javascript" src="../include/jquery.ui.core.min.js"></script>
    <script type="text/javascript" src="../include/jquery.ui.widget.min.js"></script>
    <script type="text/javascript" src="../include/jquery.ui.tabs.min.js"></script>
    <script type="text/javascript" src="../jquery.ui.timepicker.js?v=0.2.3"></script>    
    <script type="text/javascript">

        $(document).ready(function() {
        
        $('#txtstarttime').timepicker();
    });

    $(document).ready(function() {

    $('#txtendtime').timepicker();
        
        });
        
    </script>
    <script type="text/javascript">
    function load()
    {
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
    }
    </script>
</head>
<body onload="load()">
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
                                        <uc4:school_profile ID="school_profile1" runat="server" />
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
                                                <td><img src="../media/images/moduleimg1.jpg" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left" >
                                                    Set Weekly Working Days &amp; Holidays</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 5px" valign="top" align="left">
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
                                                         <table cellpadding="7" cellspacing="0" border="0" class="app_container">
                                                            <tr class="view_detail_title_bg" >
                                                                <td colspan="6"  align="left" >
                                                                   <asp:Label CssClass="title_label" ID="lbltit" runat="server" Text="Set Weekly Working Days & Holidays" ></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6">
                                                                    <%-- <asp:UpdatePanel ID="up1" runat="server">
                                                                     <ContentTemplate>--%>
                                                                    <table cellpadding="5" cellspacing="0" border="0">
                                                                        <tr>
                                                                            <td align="left" style="width: 175px; height: 40px">
                                                                                <asp:Label ID="Label1" runat="server" CssClass="s_label" Text="Weekly holidays"></asp:Label>
                                                                            </td>
                                                                            <td align="left" style="width: 150px; height: 40px">
                                                                                <asp:DropDownList ID="ddlday" runat="server" CssClass="s_dropdown">
                                                                                <asp:ListItem Value ="-Select-">-Select-</asp:ListItem>
                                                                                    <asp:ListItem Value="Sunday">Sunday</asp:ListItem>
                                                                                    <asp:ListItem Value="Monday">Monday</asp:ListItem>
                                                                                    <asp:ListItem Value="Tuesday">Tuesday</asp:ListItem>
                                                                                    <asp:ListItem Value="Wednesday">Wednesday</asp:ListItem>
                                                                                    <asp:ListItem Value="Thursday">Thursday</asp:ListItem>
                                                                                    <asp:ListItem Value="Friday">Friday</asp:ListItem>
                                                                                    <asp:ListItem Value="Saturday">Saturday</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td align="left" style="width: 50px; height: 40px"></td>
                                                                            <td align="left" style="height: 40px">
                                                                                <asp:RadioButton ID="rbholiday" runat="server" Text="Holiday" Checked="True" GroupName="day" oncheckedchanged="rbholiday_CheckedChanged" AutoPostBack="True" CssClass="s_label" />
                                                                                <asp:RadioButton ID="rbhalfday" runat="server" Text="Halfday" AutoPostBack="True" GroupName="day" oncheckedchanged="rbhalfday_CheckedChanged" CssClass="s_label" />                                                                
                                                                            </td>
                                                                             <td align="left" style="width: 50px; height: 40px"></td>
                                                                        </tr>
                                                                    </table>
                                                               <%-- </ContentTemplate>
                                                                </asp:UpdatePanel>--%>
                                                                </td>
                                                            </tr>
                                                            <tr id="trtag" runat="server">
                                                                <td align="left" style="width: 175px; height: 40px">
                                                                    <asp:Label ID="Label10" runat="server" CssClass="s_label" 
                                                                        Text="Half day start time"></asp:Label>
                                                                    </td>
                                                                <td align="left" style="width: 150px; height: 40px">
                                                                   <asp:TextBox ID="txtstarttime" runat="server"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                                        ControlToValidate="txtstarttime" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <td align="left" style="width: 50px; height: 40px">
                                                                        &nbsp;</td>
                                                                <td align="left" style="width: 175px; height: 40px">
                                                                    <asp:Label ID="Label11" runat="server" CssClass="s_label" 
                                                                        Text="Half day end time"></asp:Label>
                                                                    </td>
                                                                <td align="left" style="width: 150px; height: 40px">
                                                                    <asp:TextBox ID="txtendtime" runat="server"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                                        ControlToValidate="txtendtime" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <td align="left" style="width: 50px; height: 40px">
                                                                    &nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6" align="center" style="width: 710px; height: 40px">
                                                                    <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" 
                                                                        CssClass="s_button"/>
                                                                    &nbsp; 
                                                                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Next.." 
                                                                        CssClass="s_button" Width="70px" CausesValidation="False" />
                                                                    &nbsp;
                                                                    <asp:Label ID="lblerror" runat="server" Font-Bold="True" Font-Names="Verdana" 
                                                                        Font-Size="12px" ForeColor="Red"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr class="view_detail_subtitle_bg">
                                                                 <td style="height: 25px" align="left" colspan="6" >
                                                                    <asp:Label ID="Label2" runat="server" CssClass="subtitle_label" Text="Holidays"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                            <td align="center" style="height: 40px" colspan="6">                                     
                                                                <asp:DataGrid ID="dgholidays" runat="server" AutoGenerateColumns="False" CellPadding="5"                                                        
                                                                        Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None"  
                                                                    oneditcommand="dgholidays_EditCommand" 
                                                                     CssClass="s_datagrid_alt_item">
                                                                        <ItemStyle CssClass="s_datagrid_item" />
                                                                        <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                                        <Columns>
                                                                            <asp:BoundColumn DataField="intworkingdaysid"  HeaderText="ID" Visible="false"></asp:BoundColumn>
                                                                            <asp:BoundColumn DataField="strweekholidays"  HeaderText="Day"></asp:BoundColumn>
                                                                            <asp:BoundColumn DataField="strmode"  HeaderText="Details"></asp:BoundColumn>
                                                                            <asp:BoundColumn DataField="strhstarttime"  HeaderText="Start Time"></asp:BoundColumn>
                                                                            <asp:BoundColumn DataField="strhendtime"  HeaderText="End Time"></asp:BoundColumn>
                                                                            <asp:ButtonColumn CommandName="edit" HeaderText="Edit" Text="&lt;img src=&quot;../media/images/edit.gif&quot; alt=&quot;Edit&quot; border=&quot;0&quot; /&gt;">
                                                                                <ItemStyle Width="40px" />
                                                                            </asp:ButtonColumn>
                                                                            <asp:TemplateColumn HeaderText="Delete">
                                                                                <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                                                <ItemTemplate>
                                                                                    <asp:ImageButton ID="btndelete" runat="server" 
                                                                                        ImageUrl="../media/images/delete.gif" CausesValidation="false" 
                                                                                    OnClientClick="return confirm('Are you sure you want to delete this record?')" 
                                                                                        onclick="btndelete_Click"  />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateColumn>
                                                                            <%--<asp:ButtonColumn CommandName="delete" HeaderText="Delete" Text="&lt;img src=&quot;../media/images/delete.gif&quot; alt=&quot;Delete&quot; border=&quot;0&quot; /&gt;">
                                                                                <ItemStyle Width="50px" />
                                                                            </asp:ButtonColumn>--%>
                                                                        </Columns>
                                                                        <HeaderStyle CssClass="s_datagrid_header"/>
                                                                    </asp:DataGrid> </td>             
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="width: 175px; height: 40px">
                                                                    &nbsp;</td>
                                                                <td align="center" style="width: 150px; height: 40px">
                                                                    &nbsp;</td>
                                                                <td align="left" style="width: 50px; height: 40px">
                                                                    &nbsp;</td>
                                                                <td align="center" style="width: 175px; height: 40px">
                                                                     &nbsp;</td>
                                                                <td align="left" style="width: 150px; height: 40px">                                                    
                                                                    
                                                                    &nbsp;</td>
                                                                <td align="left" style="width: 50px; height: 40px">
                                                                    &nbsp;</td>
                                                            </tr>
                                                            <tr class="view_detail_subtitle_bg">
                                                                <td style="height: 25px" align="left" colspan="6" >
                                                                    <asp:Label ID="Label21" runat="server" CssClass="subtitle_label" Text="Working days "></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" style="height: 40px" colspan="6">
                                                                <asp:DataGrid ID="dgworkingdays" runat="server" AutoGenerateColumns="False" CellPadding="5"                                                        
                                                                        Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None">
                                                                        <ItemStyle CssClass="s_datagrid_item" />
                                                                        <AlternatingItemStyle CssClass="s_datagrid_alt_item"  />
                                                                        <Columns>                                                            
                                                                            <asp:BoundColumn DataField="strweekholidays"  HeaderText="Day"></asp:BoundColumn>
                                                                            <asp:BoundColumn DataField="strmode"  HeaderText="Details"></asp:BoundColumn>
                                                                            <asp:BoundColumn DataField="strstarttime"  HeaderText="Start Time"></asp:BoundColumn>
                                                                            <asp:BoundColumn DataField="strendtime"  HeaderText="End Time"></asp:BoundColumn>                                                            
                                                                        </Columns>
                                                                        <HeaderStyle CssClass="s_datagrid_header" />
                                                                    </asp:DataGrid> 
                                                                </td>
                                                            </tr>
                                                        </table>   
                                                </ContentTemplate>
                                        </asp:UpdatePanel>                                     
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="6" style="width: 710px; height: 40px">
                                        &nbsp;</td>
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
