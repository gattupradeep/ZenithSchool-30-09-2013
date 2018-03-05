<%@ Page Language="C#" AutoEventWireup="true" CodeFile="homework.aspx.cs" Inherits="school_homework" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register src="../usercontrol/activities_homework.ascx" tagname="activities_homework" tagprefix="uc1" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
<%@ Register Src="../usercontrol/footer.ascx" TagName="app_footer" TagPrefix="uc6" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The Schools.in - Admin</title>
    <link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/layout.css" media="screen" rel="stylesheet" type="text/css" /> 
       
    <script type="text/javascript" src="../media/js/jquery.min.js"></script>
    <link rel="stylesheet" href="../css/ui_datepicker.css" type="text/css" />
    <link rel="stylesheet" href="../css/ui.daterangepicker.css" type="text/css" />
	<script type="text/javascript" src="../js/jquery-ui.min.js"></script>
    <script type="text/javascript" src="../js/date.js"></script>
	<script type="text/javascript" src="../js/daterangepicker.jQuery.js"></script>
	
    <script type="text/javascript">
        $(document).ready(function() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
            function EndRequestHandler(sender, args) {
                $('#txtassign').datepicker({ dateFormat: 'yy/mm/dd',
                    changeMonth: true,
                    constrainDates: true,
                    changeYear: true
                });
            }
        });
        $(document).ready(function() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
            function EndRequestHandler(sender, args) {
                $('#txtduedate').datepicker({ dateFormat: 'yy/mm/dd',
                    changeMonth: true,
                    constrainDates: true,
                    changeYear: true
                });
            }
        });
        $(document).ready(function() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
            function EndRequestHandler(sender, args) {
                $('#txtpublish').datepicker({ dateFormat: 'yy/mm/dd',
                    changeMonth: true,
                    constrainDates: true,
                    changeYear: true
                });
            }
        });
        $(function() {
            var dates = $("#txtassign").datepicker({
                constrainDates: true,
                dateFormat: 'mm/dd/yy',
                changeMonth: true,
                changeYear: true
            });
        });
        
        $(function() {
            var dates = $("#txtduedate").datepicker({
                constrainDates: true,
                dateFormat: 'mm/dd/yy',
                changeMonth: true,
                changeYear: true
            });
        });
       
        $(function() {
        var dates = $("#txtpublish").datepicker({
                constrainDates: true,
                dateFormat: 'mm/dd/yy',
                changeMonth: true,
                changeYear: true
            });
        });
        

	</script>
    <style type="text/css">
        .style1
        {
            width: 175px;
            height: 35px;
        }
        .style2
        {
            width: 200px;
            height: 35px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <ajaxtoolkit:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server"></ajaxtoolkit:toolkitscriptmanager>
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td style="width: 100%;" align="left">
                <uc3:topbanner ID="topbanner1" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="width: 100%;" valign="top">
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
                                        <uc1:activities_homework ID="activities_homework1" runat="server" />
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
                        <td style="width: 93%" valign="top" align="left">
                        <%--<asp:UpdateProgress ID="Updateprocess" runat="server" AssociatedUpdatePanelID="updatepanal" DisplayAfter="1" >
                            <ProgressTemplate>
                                <div id="progressBackgroundFilter"></div>
                                    <div id="processMessage">
                                        <img alt="Loading" src="../media/images/Processing.gif" />
                                    </div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>--%>
                        <asp:UpdatePanel ID="updatepanal" runat="server" >
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnsave" />
                            <asp:PostBackTrigger ControlID="btnupload" />                            
                        </Triggers>
                        
                        <ContentTemplate>
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr class="app_container_title">
                                    <td style="width: 100%; " align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" >
                                            <tr>
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/49.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left" >Assign Homework</td>
                                                <td style="width: 100px; height: 50px"> 
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr><td>
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                            ValidationGroup="homework" DisplayMode="BulletList" 
                                            HeaderText="Please fill the following errors" EnableClientScript="true" 
                                            ShowMessageBox="true" CssClass="s_label" Height="100%" /> </td></tr> 
                                <tr>
                                    <td style="width: 100%; height: 8px; background-image: url(../media/images/bline.jpg)"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 10px"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 10px" valign="top" align="left">
                                        <table cellpadding="0" cellspacing="0" class="app_container">
                                            <tr>
                                                <td align="left" style="width: 175px; height: 40px">
                                                    &nbsp;&nbsp;
                                                    <asp:Label ID="Label11" runat="server" CssClass="s_label" 
                                                        Text="Teacher"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:DropDownList ID="ddlteacher" runat="server"  Width="140px" 
                                                        CssClass="s_textbox" AutoPostBack="True" 
                                                        onselectedindexchanged="ddlteacher_SelectedIndexChanged">
                                                         </asp:DropDownList>&nbsp;&nbsp;
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlteacher" InitialValue="0" 
                                                    ValidationGroup="homework" ErrorMessage="Please select the Teacher" Width="16px">*</asp:RequiredFieldValidator>
                                                </td>
                                                <td align="left" style="width: 175px; height: 40px">
                                                    &nbsp;
                                                    <asp:Label ID="Label12" runat="server" CssClass="s_label" 
                                                        Text="Standard"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:DropDownList ID="ddlstandard" runat="server" Width="140px" 
                                                        CssClass="s_dropdown" AutoPostBack="True" 
                                                        onselectedindexchanged="ddlstandard_SelectedIndexChanged">
                                                         </asp:DropDownList>
                                                    &nbsp;&nbsp;
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlstandard" InitialValue="0" 
                                                    ValidationGroup="homework" ErrorMessage="Please select the standard" Width="16px">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="style1">
                                                    &nbsp;&nbsp;
                                                    <asp:Label ID="Label14" runat="server" CssClass="s_label" 
                                                        Text="Subject"></asp:Label>
                                                </td>
                                                <td align="left" class="style2">
                                                    <asp:DropDownList ID="ddlsubject" runat="server"  Width="140px" 
                                                        CssClass="s_dropdown" AutoPostBack="True" 
                                                        onselectedindexchanged="ddlsubject_SelectedIndexChanged">
                                                         </asp:DropDownList>
                                                    &nbsp;&nbsp;
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlsubject" InitialValue="0" 
                                                    ValidationGroup="homework" ErrorMessage="Please select the subject" Width="16px">*</asp:RequiredFieldValidator>
                                                </td>
                                                <td align="left" class="style1">&nbsp;
                                                    <asp:Label ID="Label38" runat="server" Text="Homework From" CssClass="s_label"></asp:Label>
                                                </td>
                                                <td align="left" class="style2">
                                                    <asp:RadioButton ID="RdbTextBook" runat="server" Text="TextBook" 
                                                        AutoPostBack="True" GroupName="grphomework" 
                                                        oncheckedchanged="RdbTextBook_CheckedChanged" Checked="True" />
                                                    <br />
                                                    <asp:RadioButton ID="RdbGeneral" runat="server" Text="General" 
                                                        AutoPostBack="True" GroupName="grphomework" 
                                                        oncheckedchanged="RdbGeneral_CheckedChanged" />
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr id="trtextbook" runat="server">
                                                <td align="left" style="width: 175px; height: 40px">
                                                    &nbsp;&nbsp; <asp:Label ID="Label35" runat="server" CssClass="s_label" 
                                                        Text="Textbook"></asp:Label></td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:DropDownList ID="ddltextbook" runat="server"  Width="140px" 
                                                        CssClass="s_dropdown" AutoPostBack="True" 
                                                        onselectedindexchanged="ddltextbook_SelectedIndexChanged" >
                                                         </asp:DropDownList>
                                                </td>
                                                <td align="left" style="width: 175px; height: 40px">
                                                    &nbsp;</td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr id="trunit" runat="server">
                                                <td align="left" style="width: 175px; height: 40px">
                                                    &nbsp;&nbsp;&nbsp;<asp:Label ID="Label34" runat="server" CssClass="s_label" Text="Unit"></asp:Label></td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:DropDownList ID="ddlunit" runat="server" AutoPostBack="True" 
                                                        onselectedindexchanged="ddlunit_SelectedIndexChanged" Width="140px">
                                                     </asp:DropDownList>
                                                </td>
                                                <td align="left" style="width: 175px; height: 40px">
                                                    &nbsp;</td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr id="trlessionname" runat="server">
                                                <td align="left" style="width: 175px; height: 40px">
                                                    &nbsp;&nbsp;&nbsp;<asp:Label ID="Label33" runat="server" CssClass="s_label" 
                                                        Text="Lesson Name"></asp:Label></td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:DropDownList ID="ddllessonname" runat="server"  AutoPostBack="True" 
                                                        Width="140px" onselectedindexchanged="ddllessonname_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="left" style="width: 175px; height: 40px">
                                                    &nbsp;</td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr id="trddloldtopics" runat="server">
                                                <td align="left" style="width: 175px; height: 40px">
                                                    &nbsp;&nbsp;
                                                    <asp:Label ID="Label32" runat="server" CssClass="s_label" 
                                                        Text="Select Topic"></asp:Label>
                                                </td>
                                                <td colspan="2" align="left" style="width: 375px; height: 40px">
                                                    <asp:DropDownList ID="ddloldtopics" runat="server"  Width="350px" 
                                                        CssClass="s_dropdown" AutoPostBack="True" onselectedindexchanged="ddloldtopics_SelectedIndexChanged">
                                                     <asp:ListItem Value="0" Text="New Topic"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 175px; height: 40px">
                                                    &nbsp;&nbsp;
                                                    <asp:Label ID="Label15" runat="server" CssClass="s_label" 
                                                        Text="Topic Name"></asp:Label>
                                                </td>
                                                <td colspan="2" align="left" style="width: 375px; height: 40px">
                                                    <asp:TextBox ID="txttopic" runat="server" Width="350px" CssClass="s_textbox"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txttopic" 
                                                    ValidationGroup="homework" ErrorMessage="Please enter topic" Width="16px">*</asp:RequiredFieldValidator>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:Label ID="lblid" runat="server" CssClass="s_label" Visible="false">0</asp:Label>
                                                    <asp:Label ID="lblhid" runat="server" CssClass="s_label" Visible="false">0</asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 175px; height: 40px">
                                                    &nbsp;&nbsp;
                                                    <asp:Label ID="Label22" runat="server" CssClass="s_label" 
                                                        Text="Description"></asp:Label>
                                                </td>
                                                <td colspan="2" align="left" style="width: 375px; height: 40px">
                                                    <asp:TextBox ID="txtdescrip" runat="server" Width="350px" CssClass="s_textbox" 
                                                        TextMode="MultiLine"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtdescrip" 
                                                    ValidationGroup="homework" ErrorMessage="Please enter topic description" Width="16px">*</asp:RequiredFieldValidator>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 175px; height: 40px">
                                                    &nbsp;&nbsp;
                                                    <asp:Label ID="Label26" runat="server" CssClass="s_label" 
                                                        Text="Attach Homework"></asp:Label>
                                                </td>
                                                <td colspan="2" align="left" style="width: 375px; height: 40px">
                                                    <asp:FileUpload ID="FileUpload1" runat="server" Width="349px"/>

                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">

                                                    <asp:Button ID="btnupload" runat="server" Text="Upload" CssClass="s_button" onclick="btnupload_Click" />

                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="width: 750px" colspan="4">
                                                    <table cellpadding="0" cellspacing="0" border="0" width="740">
                                                        <tr id="trattachments" runat="server">
                                                            <td id="tdattachments" runat="server" style="width: 350px; height: 30px" align="left">
                                                                &nbsp;&nbsp;&nbsp;<asp:Label ID="Label39" runat="server" CssClass="s_label" 
                                                        Text="Attach Homework"></asp:Label></td>
                                                            <td style="width: 40px; height: 30px" align="center">
                                                                &nbsp;</td>
                                                            <td style="width: 350px; height: 30px" align="left">
                                                                &nbsp;
                                                                <asp:Label ID="lblattached" runat="server" CssClass="s_label" Text=""></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr id="trattachs" runat="server">
                                                            <td id="tdattachs" runat="server" style="width: 350px; height: 30px" align="left">
                                                                &nbsp;&nbsp;
                                                    <asp:Button ID="btnPrevious" runat="server" CssClass="s_button" 
                                                        Text="Previous Attachment" onclick="btnPrevious_Click" />
                                                            </td>
                                                            <td style="width: 40px; height: 30px" align="center">
                                                                &nbsp;</td>
                                                            <td style="width: 350px; height: 30px" align="left">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr id="trattachment" runat="server">
                                                            <td id="tdattachment" runat="server" style="width: 350px; height: 30px" align="left">
                                                                &nbsp;&nbsp; <asp:Label ID="Label36" runat="server" CssClass="s_label" 
                                                                Text="Attachments Available"></asp:Label></td>
                                                            <td style="width: 40px; height: 30px" align="center">
                                                                &nbsp;</td>
                                                            <td style="width: 350px; height: 30px" align="left">
                                                                &nbsp;&nbsp;<asp:Label ID="Label37" runat="server" CssClass="s_label" 
                                                                Text="Attachments Selected"></asp:Label></td>
                                                        </tr>
                                                        <tr id="trattachment1" runat="server">
                                                            <td id="tdattach" runat="server" style="width: 350px; height: 150px" align="left" valign="top">
                                                                <asp:Panel ID="pnl1" runat="server" Width="340px" Height="150px" BorderStyle="Solid" BorderWidth="1px">
                                                                    <asp:CheckBoxList ID="chkoldattachments" runat="server"></asp:CheckBoxList>
                                                                </asp:Panel>
                                                            </td>
                                                            <td style="width: 40px; height: 150px" align="center">
                                                                <asp:Button ID="btnadd" runat="server" CssClass="s_button" Text="&gt;&gt;" 
                                                                    onclick="btnadd_Click" />
                                                                <br />
                                                                <br />
                                                                <asp:Button ID="btnremove" runat="server" CssClass="s_button" Text="&lt;&lt;" 
                                                                    onclick="btnremove_Click" />
                                                            </td>
                                                            <td style="width: 350px; height: 150px" align="left" valign="top">
                                                                <asp:Panel ID="Panel1" runat="server" Width="340px" Height="150px" BorderStyle="Solid" BorderWidth="1px">
                                                                    <asp:CheckBoxList ID="chknewattachments" runat="server"></asp:CheckBoxList>
                                                                </asp:Panel>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 175px; height: 40px">
                                                    &nbsp;&nbsp;
                                                    <asp:Label ID="Label23" runat="server" CssClass="s_label" Text="Assign Date"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:TextBox ID="txtassign" runat="server" CssClass="s_textbox"></asp:TextBox>
                                                    
                                                </td>
                                                <td align="left" style="width: 175px; height: 40px">
                                                    &nbsp;&nbsp;
                                                    <asp:Label ID="Label24" runat="server" CssClass="s_label" Text="Due Date"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:TextBox ID="txtduedate" runat="server" CssClass="s_textbox"></asp:TextBox>
                                                     
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 175px; height: 40px">
                                                    &nbsp;&nbsp;
                                                    <asp:Label ID="Label25" runat="server" CssClass="s_label" Text="Publish Date"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:TextBox ID="txtpublish" runat="server" CssClass="s_textbox"></asp:TextBox>
                                                     
                                                </td>
                                                <td align="left" style="width: 175px; height: 40px">
                                                    &nbsp;&nbsp;
                                                    <asp:Label ID="Label27" runat="server" CssClass="s_label" 
                                                        Text="Status"></asp:Label>
                                                </td>
                                                <td align="left" style="width: 200px; height: 40px">
                                                    <asp:RadioButton ID="rbactive" runat="server" CssClass="s_label" 
                                                        Text="Active" GroupName="status" Checked="True" />
                                                    <asp:RadioButton ID="rbinactive" runat="server" CssClass="s_label" 
                                                        Text="Inactive" GroupName="status" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="4" style="width: 750px; height: 40px">
	                                                <asp:Button ID="btnsave" runat="server" Text="Save" CssClass="s_button" ValidationGroup="homework"
                                                        Width="70px" onclick="btnsave_Click" />
                                                </td>
                                            </tr>
                                        </table>      
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                            </table>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100%;" align="left" valign="top">
                <uc6:app_footer ID="footer" runat="server" />
            </td>
        </tr>
    </table>
    <cc1:MsgBox id="msgbox" runat="server"></cc1:MsgBox>
    </div>
    </form>
</body>
</html>

