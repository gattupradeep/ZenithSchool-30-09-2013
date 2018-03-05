<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewstaffleaverequest.aspx.cs" Inherits="Leave_viewstaffleaverequest" %>

<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>

<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

<%@ Register src="../usercontrol/mainmasters.ascx" tagname="mainmasters" tagprefix="uc1" %>

<%@ Register src="../usercontrol/footer.ascx" tagname="footer" tagprefix="uc4" %>

<%@ Register TagPrefix="cc1" Namespace="BunnyBear" Assembly="msgBox" %>

<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>

<%@ Register src="../usercontrol/admin_leave.ascx" tagname="admin_leave" tagprefix="uc5" %>

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
                $('#txtgrdriseddate').datepicker({ dateFormat: 'yy/mm/dd',
                constrainDates: true,
                changeMonth: true,
                changeYear: true
                 });
            }
        });
        $(document).ready(function() {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
            function EndRequestHandler(sender, args) {
                $('#txtgrdfromto').datepicker({ dateFormat: 'yy/mm/dd',
                constrainDates: true,
                changeMonth: true,
                changeYear: true
                 });
            }
        });
        $(function() {
        var dates = $("#txtgrdriseddate").datepicker({
                constrainDates: true,
                dateFormat: 'dd/mm/yy',
                changeMonth: true,
                changeYear: true
            });
        });
        $(function() {
        var dates = $("#txtgrdfromto").datepicker({
                constrainDates: true,
                dateFormat: 'dd/mm/yy',
                changeMonth: true,
                changeYear: true
            });
        });
        </script>
        <script type="text/javascript">
        $(document).ready(function() {
            $('#chkall').click(
             function() {
                 $("INPUT[type='checkbox']").attr('checked', $('#chkall').is(':checked'));
             });
         });
        </script><script type="text/javascript">

     </script>
    
</head><body><form id="form1" runat="server">
    <div>
    <ajaxtoolkit:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server">
    </ajaxtoolkit:toolkitscriptmanager>
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
                                        <uc5:admin_leave ID="admin_leave1" runat="server" />
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
                                    <td style="width: 100%; " align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" >
                                            <tr>
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/55.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left" >View Staff &#39;s Leave Request</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 10px" valign="top" align="left">
                                        <table cellpadding="0" cellspacing="0" border="0" class="app_container_auto">
                                            <tr class="view_detail_title_bg" style="height:30px">
                                                <td align="center" style="width:12%;">
                                                    <asp:Label ID="lblgrdriseddate" runat="server" CssClass="header_lable" Text="Request Rised Date" ></asp:Label>
                                                </td>
                                                <td  align="center" style="width: 28%;">
                                                    <asp:Label ID="lblgrdfromto" runat="server" CssClass="header_lable" Text="Leave Required On From and To"></asp:Label>
                                                </td>
                                                <td  align="center" style="width: 20%;">
                                                    <asp:Label ID="lblgrdname" runat="server" CssClass="header_lable" Text="Name"></asp:Label>
                                                </td>
                                                <td align="center" style="width: 20%;">
                                                    <asp:Label ID="lblgrdleavetype" runat="server" CssClass="header_lable" Text="Leave Type"></asp:Label>
                                                </td>
                                                <td align="center" style="width: 10%;">
                                                    <asp:Label ID="lblgrstatus" runat="server" CssClass="header_lable" Text="Leave Status"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr class="view_detail_title_bg" style="height:30px">
                                                <td align="center">
                                                    <asp:TextBox ID="txtgrdriseddate" runat="server" AutoPostBack="true" 
                                                        Width="75px" ontextchanged="txtgrdriseddate_TextChanged">
                                                    </asp:TextBox>
                                                    
                                                    </td>
                                                <td align="center">
                                                    <asp:TextBox ID="txtgrdfromto" runat="server" AutoPostBack="true" Width="100px" 
                                                        ontextchanged="txtgrdfromto_TextChanged"></asp:TextBox>
                                                    
                                                    </td>
                                                <td align="center">
                                                    <asp:TextBox ID="txtgrdname" runat="server" AutoPostBack="true" Width="120px" OnTextChanged="txtgrdname_OnTextChanged">
                                                    </asp:TextBox>
                                                      <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"
                                                                  EnableCaching="true"
                                                                  BehaviorID="AutoCompleteEx"
                                                                  MinimumPrefixLength="2"
                                                                  TargetControlID="txtgrdname"
                                                                  ServicePath="autofillforleavecategory.asmx"
                                                                  ServiceMethod="GetCompletionList1" 
                                                                  CompletionListCssClass="autocomplete_completionListElement"
                                                                  CompletionListItemCssClass="autocomplete_listItem"
                                                                  CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                                                  CompletionInterval="1000"  
                                                                  CompletionSetCount="20"
                                                                  ShowOnlyCurrentWordInCompletionListItem="true">
                                                                  <Animations>
                                                                  <OnShow>
                                                                  <Sequence>
                                                                  <OpacityAction Opacity="0" />
                                                                  <HideAction Visible="true" />

                                                                  <ScriptAction Script="// Cache the size and setup the initial size
                                                                                                var behavior = $find('AutoCompleteEx');
                                                                                                if (!behavior._height) {
                                                                                                    var target = behavior.get_completionList();
                                                                                                    behavior._height = target.offsetHeight - 2;
                                                                                                    target.style.height = '0px';
                                                                                                }" />
                                                                  <Parallel Duration=".4">
                                                                  <FadeIn />
                                                                  <Length PropertyKey="height" StartValue="0" 
                                                                    EndValueScript="$find('AutoCompleteEx')._height" />
                                                                  </Parallel>
                                                                  </Sequence>
                                                                  </OnShow>
                                                                  <OnHide>
                                                                  <Parallel Duration=".4">
                                                                  <FadeOut />
                                                                  <Length PropertyKey="height" StartValueScript=
                                                                    "$find('AutoCompleteEx')._height" EndValue="0" />
                                                                  </Parallel>
                                                                  </OnHide>
                                                                  </Animations>
                                                                  </ajaxToolkit:AutoCompleteExtender>
                                                    </td>
                                                     <td align="center" >
                                                    <asp:TextBox ID="txtgrdleavetype" runat="server" AutoPostBack="true" Width="120px" 
                                                             ontextchanged="txtgrdleavetype_TextChanged"></asp:TextBox>
                                                    </td>
                                                     <td align="center">
                                                    <asp:TextBox ID="txtstatus" runat="server" AutoPostBack="true" Width="80px" 
                                                             ontextchanged="txtstatus_TextChanged">
                                                    </asp:TextBox>
                                                    </td>
                                            </tr>
                                            <tr>        
                                                <td align="left" colspan="5" style="width: 90%; height: 40px">
                                                    <asp:DataGrid ID="grdstaffleaverequest" runat="server" CellPadding="3" CellSpacing="1"
                                                        AutoGenerateColumns="False" ShowHeader="false" 
                                                    Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None" AllowPaging="true"  
                                                        onpageindexchanged="grdstaffleaverequest_PageIndexChanged">                                                            
                                                                        <AlternatingItemStyle CssClass="s_datagrid_alt_item" />
                                                                        <ItemStyle CssClass="s_datagrid_item" />
                                                        <Columns>
                                                            <asp:BoundColumn DataField="requestdate" ItemStyle-Width="12%" >
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="leavedays" ItemStyle-Width="25%" >
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="name" ItemStyle-Width="25%">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="strleavetype" ItemStyle-Width="15%">                                                                                                                                                                                
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="Status" ItemStyle-Width="8%">                                                                                                                                                                                
                                                            </asp:BoundColumn>
                                                        </Columns>
                                                        <PagerStyle Mode="NumericPages" Font-Underline="true" NextPageText="Next" Position="Bottom" PrevPageText="Previous" Font-Bold="true"  />
                                                        <HeaderStyle CssClass="s_datagrid_header" />
                                                        </asp:DataGrid>
                                                </td>
                                            </tr>
                                            
                                            <tr>
                                                <td align="center" colspan="5" >
                                                    </td>
                                            </tr>
                                             
                                        </table> 
                                        <tr id="tr1" runat="server">
                                          <td style="width: 100%; height: 100px; padding-left: 10px" valign="top" align="left">
                                             <asp:Label ID="errormessage" runat="server" CssClass="nodatatodisplay"></asp:Label>
                                          </td>
                                       </tr>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
       
            </td>
        </tr>
        <tr>
            <td style="width: 100%; height: 50px" align="left" valign="top">
                &nbsp;</td>
        </tr>
    </table>
   <cc1:msgBox id="MsgBox" style="Z-INDEX: 103; LEFT: 536px; POSITION: absolute; TOP: 184px" runat="server"></cc1:msgBox>
    </div>
    </form>
</body>
</html>

