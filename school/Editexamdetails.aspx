<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Editexamdetails.aspx.cs" Inherits="school_Editexamdetails" %>

<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>

<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>

<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>

<%@ Register src="../usercontrol/school_profile.ascx" tagname="school_profile" tagprefix="uc1" %>

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
    
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
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
                 <%--<asp:UpdateProgress ID="Updateprocess" runat="server" AssociatedUpdatePanelID="updatepanal" DisplayAfter="1" >
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
                                        <uc1:school_profile ID="school_profile1" runat="server" />
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
                                    <td style="width: 100%; " align="left">
                                        <table cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td class="app_cont_title_img_td"><img src="../media/images/moduleimg1.jpg" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left" > Exam Details Settings</td>
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
                                        <table cellpadding="0" cellspacing="0" border="0" class="app_container">
                                           <tr class="view_detail_title_bg" >
                                                <td align="left" colspan="2">
                                                   <asp:Label CssClass="title_label" ID="lbltit" runat="server" Text="Exam Papers" ></asp:Label> 
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <table cellpadding="7" cellspacing="0" border="0" width="100%">
                                                        <tr>
                                                            <td style="width:20%" valign="top">
                                                                <asp:Label ID="Label1" runat="server" CssClass="s_label" Text="Class"></asp:Label>
                                                            </td>
                                                            <td valign="top">
                                                                <asp:DropDownList ID="ddlstandard" runat="server" AutoPostBack="True" 
                                                                    CssClass="s_dropdown" onselectedindexchanged="ddlstandard_SelectedIndexChanged" 
                                                                    Width="170px" Height="43px">
                                                                </asp:DropDownList>
                                                            </td>
                                                           </tr>
                                                        <tr>
                                                            <td  valign="top">
                                                                <asp:Label ID="Label8" runat="server" CssClass="s_label" Text="Exam Types"></asp:Label>
                                                            </td>
                                                            <td  valign="top">
                                                                <asp:DropDownList ID="ddlexamtype" runat="server" AutoPostBack="True" 
                                                                    CssClass="s_dropdown"  Width="170px" Height="29px">
                                                                </asp:DropDownList>
                                                            </td>
                                                           </tr>
                                                        </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="width: 100%" align="left">
                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td align="left" style="padding-left: 20px">
                                                                <asp:DataGrid ID="dgsubjects" runat="server" AutoGenerateColumns="False" Width="100%"                                                     
                                                                    BorderStyle="None" BorderWidth="0px" GridLines="None" CellPadding="0" 
                                                                    onitemdatabound="dgsubjects_ItemDataBound" >
                                                                    <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                                    <ItemStyle 
                                                                        Height="25px" CssClass="s_datagrid_item" />
                                                                    <Columns>
                                                                        <asp:BoundColumn DataField="strsubject" HeaderText="Subject" 
                                                                            Visible="False"></asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="active" HeaderText="Active" 
                                                                            Visible="False"></asp:BoundColumn>
                                                                        <asp:TemplateColumn>
                                                                            <ItemStyle Width="150px" />
                                                                            <ItemTemplate>
                                                                                <asp:CheckBox ID="chksubject" runat="server"  Checked="true" 
                                                                                    Text='<%# DataBinder.Eval(Container.DataItem, "strsubject")%>' 
                                                                                    AutoPostBack="True" oncheckedchanged="chksubject_CheckedChanged" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn>
                                                                            <ItemTemplate>
                                                                                <asp:DataGrid ID="dgexamsettings" runat="server" AutoGenerateColumns="False" Width="100%"                                                     
                                                                                    BorderStyle="None" BorderWidth="0px" GridLines="None" CellPadding="0"  
                                                                                    onitemdatabound="dgexamsettings_ItemDataBound">
                                                                                    <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                                                    <ItemStyle 
                                                                                        Height="25px" CssClass="s_datagrid_item" />
                                                                                    <Columns>
                                                                                        <asp:BoundColumn DataField="strexampaper" HeaderText="Paper Name" Visible="false">
                                                                                            <ItemStyle Width="150px" />
                                                                                        </asp:BoundColumn>
                                                                                        <asp:BoundColumn DataField="active" HeaderText="Active" Visible="false">
                                                                                        </asp:BoundColumn>
                                                                                        <asp:TemplateColumn>
                                                                                            <ItemStyle Width="150px" />
                                                                                            <ItemTemplate>
                                                                                                <asp:CheckBox ID="chkpaper" runat="server" Checked="true" Text='<%# DataBinder.Eval(Container.DataItem, "strexampaper")%>' />
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateColumn>
                                                                                        <asp:BoundColumn DataField="intmaxmark" HeaderText="Min" Visible="False">
                                                                                        </asp:BoundColumn>
                                                                                        <asp:BoundColumn DataField="intpassmark" HeaderText="Min" Visible="False">
                                                                                        </asp:BoundColumn>
                                                                                        <asp:BoundColumn DataField="timedurationmin" HeaderText="Min" Visible="False">
                                                                                        </asp:BoundColumn>
                                                                                        <asp:BoundColumn DataField="timedurationhour" HeaderText="Hour" Visible="False">
                                                                                        </asp:BoundColumn>
                                                                                        <asp:TemplateColumn HeaderText="Max Marks">
                                                                                            <ItemStyle Width="120px"/>
                                                                                            <ItemTemplate>
                                                                                                <asp:TextBox ID="txtmaxmarks" runat="server" CssClass= " s_textbox" Width="100px" Text='<%# DataBinder.Eval(Container.DataItem, "intmaxmark")%>'>
                                                                                                </asp:TextBox>                                                                    
                                                                                            </ItemTemplate>                                                                
                                                                                        </asp:TemplateColumn>
                                                                                        <asp:TemplateColumn HeaderText="Pass Mark">
                                                                                            <ItemStyle Width="120px"/>
                                                                                            <ItemTemplate>
                                                                                                <asp:TextBox ID="txtpassmark" runat="server" CssClass= " s_textbox" Width="100px" Text='<%# DataBinder.Eval(Container.DataItem, "intpassmark")%>'>
                                                                                                </asp:TextBox>                                                                    
                                                                                            </ItemTemplate>                                                                
                                                                                        </asp:TemplateColumn>
                                                                                        <asp:TemplateColumn HeaderText="Time Duration">
                                                                                            <ItemStyle Width="150px"/>
                                                                                            <ItemTemplate>
                                                                                                <asp:DropDownList ID="ddlhour" runat="server" CssClass="s_dropdown" Width="40px">                                                                        
                                                                                                </asp:DropDownList>
                                                                                                <asp:Label ID="lblhour" runat="server" CssClass="s_label" Text="Hour"></asp:Label>
                                                                                                <asp:DropDownList ID="ddlmin" runat="server" CssClass="s_dropdown" Width="40px">
                                                                                                </asp:DropDownList>
                                                                                                <asp:Label ID="Label3" runat="server" CssClass="s_label" Text="min"></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateColumn>
                                                                                    </Columns>
                                                                                    <HeaderStyle CssClass="s_datagrid_header" />
                                                                                </asp:DataGrid>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateColumn>
                                                                    </Columns>
                                                                </asp:DataGrid>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>                                                
                                            </tr>
                                            <tr>
                                                <td colspan="6" style="height: 40px" align="center">
                                                    <asp:Button ID="btnSave" runat="server" CssClass="s_button" Text="Save" 
                                                        Width="60px" onclick="btnSave_Click"/>
                                                    <asp:Button ID="btnClear" runat="server" CssClass="s_button" Text="Cancel" 
                                                        Width="60px" onclick="btnClear_Click" />
                                                </td>
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