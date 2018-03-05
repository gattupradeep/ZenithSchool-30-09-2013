<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Addtutorial.aspx.cs" Inherits="Tutorials_Addtutorial" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register Src="../usercontrol/footer.ascx" TagName="app_footer" TagPrefix="uc6" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit.HTMLEditor" tagprefix="cc2" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register src="~/usercontrol/tutorial.ascx" tagname="tutorial" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
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
                $('#txtpublishdate').datepicker({ dateFormat: 'yy/mm/dd',
                changeMonth: true,
                constrainDates: true,
                changeYear: true
                 });
            }
        });
        $(function() {
        var dates = $("#txtpublishdate").datepicker({
                constrainDates: true,
                dateFormat: 'yy/mm/dd',
                changeMonth: true,
                changeYear: true
            });
        });
        $(document).ready(function() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
            function EndRequestHandler(sender, args) {
                $('#txtdate').datepicker({ dateFormat: 'yy/mm/dd',
                    changeMonth: true,
                    constrainDates: true,
                    changeYear: true
                });
            }
        });
        $(function() {
            var dates = $("#txtdate").datepicker({
                constrainDates: true,
                dateFormat: 'yy/mm/dd',
                changeMonth: true,
                changeYear: true
            });
        });
        // Added By Prabaa on 03-10-13
        function Validation() {
            if (document.getElementById('txtdate').value == "") {
                alert("Please enter the date to proceed");
                document.getElementById('txtdate').focus();
                return false
            }
            if (document.getElementById('ddlclass').value == "-Select-") {
                alert("Please select Class to proceed");
                document.getElementById('ddlclass').focus();
                return false
            }
            if (document.getElementById('ddlteacher').value == "-Select-") {
                alert("Please select teacher to proceed");
                document.getElementById('ddlteacher').focus();
                return false
            }
            if (document.getElementById('ddlsubject').value == "-Select-") {
                alert("Please select subject to proceed");
                document.getElementById('ddlsubject').focus();
                return false
            }
            if (document.getElementById('ddltextbook').value == "-Select-") {
                alert("Please select text book to proceed");
                document.getElementById('ddltextbook').focus();
                return false
            }
            if (document.getElementById('ddlunit').value == "-Select-") {
                alert("Please select unit to proceed");
                document.getElementById('ddlunit').focus();
                return false
            }
            if (document.getElementById('ddllesson').value == "-Select-") {
                alert("Please select the lession to proceed");
                document.getElementById('ddllesson').focus();
                return false
            }
            if (document.getElementById('txtpublishdate').value == "") {
                alert("Please enter publish date to proceed");
                document.getElementById('txtpublishdate').focus();
                return false
            }
            if (document.getElementById('FileUpload1').value == "" && document.getElementById('FileUpload2').value == "") {
                alert("Please attach audio or documents to proceed");
                document.getElementById('FileUpload1').focus();
                return false
            }
        }
        // Prabaa  -- End --         
	</script>	
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"> </asp:ToolkitScriptManager>
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
                                        <uc1:tutorial ID="tutorial1" runat="server" />
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
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr class="app_container_title">
                                    <td style="width: 100%;" align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" >
                                            <tr>
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/51.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left">Add / Edit Daily Class Notes</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 10px" valign="top" align="left">
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
                                      
                                            <table cellpadding="0" cellspacing="0" border="0" class="app_container">
                                            <tr class="view_detail_title_bg">
                                                <td class="title_label">&nbsp;&nbsp;Add / Edit Daily Class Notes</td>
                                            </tr>
                                            <tr>
                                                <td >
                                                    <table cellpadding="7" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td style="width: 250px; height: 40px" align="left">
                                                                <asp:Label ID="Label1" runat="server" CssClass="s_label" Text="Date"></asp:Label>
                                                             </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:TextBox ID="txtdate" runat="server" CssClass="s_textbox" 
                                                                    Width="150px"></asp:TextBox>
                                                             </td>
                                                            <td style="width: 150px; height: 40px" align="left">
                                                                <asp:Label ID="Label6" runat="server" CssClass="s_label" 
                                                                    Text="Class &amp; Section"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:DropDownList ID="ddlclass" runat="server" AutoPostBack="true" 
                                                                    CssClass="s_dropdown" onselectedindexchanged="ddlclass_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 250px; height: 40px" align="left">
                                                                <asp:Label ID="Label2" runat="server" CssClass="s_label" Text="Teacher"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:DropDownList ID="ddlteacher" runat="server" AutoPostBack="true" 
                                                                    CssClass="s_dropdown" onselectedindexchanged="ddlteacher_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="width: 250px; height: 40px" align="left">
                                                                <asp:Label ID="Label7" runat="server" CssClass="s_label" Text="Subject"></asp:Label>
                                                            </td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:DropDownList ID="ddlsubject" runat="server" AutoPostBack="true" 
                                                                    CssClass="s_dropdown" onselectedindexchanged="ddlsubject_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label3" runat="server" CssClass="s_label" Text="Text Book"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList ID="ddltextbook" runat="server" AutoPostBack="true" 
                                                                    CssClass="s_dropdown" onselectedindexchanged="ddltextbook_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="Label8" runat="server" CssClass="s_label" Text="Unit"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:DropDownList ID="ddlunit" runat="server" AutoPostBack="true" 
                                                                    CssClass="s_dropdown" onselectedindexchanged="ddlunit_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                          
                                                                <asp:Label ID="Label14" runat="server" CssClass="s_label" Text="Lesson"></asp:Label>
                                                                </td>
                                                            <td align="left">
                                                            
                                                               <asp:DropDownList ID="ddllesson" runat="server" CssClass="s_dropdown">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="Label9" runat="server" CssClass="s_label" Text="Publish Date"></asp:Label>
                                                            </td>
                                                            <td align="left">
                                                                <asp:TextBox ID="txtpublishdate" runat="server" CssClass="s_textbox" 
                                                                    Width="150px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr class="view_detail_subtitle_bg">
                                                            <td colspan="4" align="left"><asp:Label ID="Label12" runat="server" Text="Attachments" CssClass="s_label" ></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <asp:Label ID="Label10" runat="server" CssClass="s_label" Text="Attach Audio "></asp:Label><br /><span class="smalllabel">
                                                                (Mp3 format only)</span>
                                                            </td>
                                                            <td align="left">
                                                                <asp:FileUpload ID="FileUpload1" runat="server" multiple="multiple" /><br />
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationExpression="^.*\.(mp3|MP3)$" 
                                                                    ErrorMessage="Please Select MP3 formate file only" ControlToValidate="FileUpload1"></asp:RegularExpressionValidator>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="Label11" runat="server" CssClass="s_label" Text="Attach Documents"></asp:Label>
                                                                <span class="smalllabel">(File Type :jpg | gif | doc | docx | pdf | png | txt 
                                                                |rtf)</span>
                                                            </td>
                                                            <td align="left">
                                                                <asp:FileUpload ID="FileUpload2" runat="server" /><br />
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression="^.*\.(jpg|JPG|gif|GIF|doc|DOC|docx|DOCX|pdf|PDF|png|PNG|txt|TXT|rtf|RTF)$" 
                                                                    ErrorMessage="Please Select PDF file only" ControlToValidate="FileUpload2"></asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="Label13" runat="server" CssClass="s_label" Text="Description"></asp:Label>
                                                            </td>
                                                            <td align="left" colspan="3"> 
                                                                <asp:TextBox TextMode="MultiLine" ID="txtdescription" runat="server" Height="100" Width="500"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">
                                                                <asp:Button ID="btnSave" runat="server" CssClass="s_button" Text="Save" 
                                                                    Width="60px" onclick="btnSave_Click" OnClientClick="return Validation(); "/>
                                                                &nbsp;
                                                                <asp:Button ID="btnClear" runat="server" CssClass="s_button" Text="Clear" 
                                                                    Width="60px" onclick="btnClear_Click" CausesValidation="false"  />
                                                            </td>
                                                            <td style="width: 150px; height: 40px" align="right">&nbsp;</td>
                                                            <td style="width: 200px; height: 40px" align="left">&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:DataGrid ID="dgtutorial" runat="server" AutoGenerateColumns="false" GridLines="None"
                                                        Width="100%" ondeletecommand="dgtutorial_DeleteCommand" 
                                                        oneditcommand="dgtutorial_EditCommand">
                                                        <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                        <ItemStyle CssClass="s_datagrid_item" />
                                                        <Columns>
                                                            <asp:BoundColumn HeaderText="ID" DataField="intid" Visible="false"></asp:BoundColumn>
                                                            <asp:BoundColumn HeaderText="Date" DataField="date"></asp:BoundColumn>
                                                            <asp:BoundColumn HeaderText="Publish Date" DataField="publishdate"></asp:BoundColumn>
                                                            <asp:BoundColumn HeaderText="Class" DataField="strclass"></asp:BoundColumn>
                                                            <asp:BoundColumn HeaderText="Teacher" DataField="teachername"></asp:BoundColumn>
                                                            <asp:BoundColumn HeaderText="Subject" DataField="strsubject"></asp:BoundColumn>
                                                            <asp:BoundColumn HeaderText="Textbook" DataField="strtextbookname"></asp:BoundColumn>
                                                            <asp:BoundColumn HeaderText="Unit" DataField="strunit"></asp:BoundColumn>
                                                            <asp:BoundColumn HeaderText="Lesson" DataField="strlesson"></asp:BoundColumn>
                                                            <asp:TemplateColumn HeaderText="Edit">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="btnedit" runat="server" ImageUrl="~/media/images/edit.gif" CommandName="Edit" />
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                            <asp:TemplateColumn HeaderText="Delete">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="btndelete" runat="server" ImageUrl="~/media/images/delete.gif" 
                                                                    OnClientClick="return confirm('Are you sure you want to delete this Record?');" CommandName="Delete" />
                                                                </ItemTemplate>
                                                            </asp:TemplateColumn>
                                                        </Columns>
                                                        <HeaderStyle CssClass="s_datagrid_header" />
                                                    </asp:DataGrid>
                                                </td>
                                            </tr>
                                        </table>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="btnSave" />
                                        </Triggers>
                                        </asp:UpdatePanel>               
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
            <td style="width: 100%;" align="left" valign="top" >
                <uc6:app_footer ID="footer" runat="server" />
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>