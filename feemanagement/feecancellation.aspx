<%@ Page Language="C#" AutoEventWireup="true" CodeFile="feecancellation.aspx.cs" EnableEventValidation="false" ValidateRequest="false" Inherits="feemanagement_feecancellation" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>
<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>
<%@ Register src="../usercontrol/mainmasters.ascx" tagname="mainmasters" tagprefix="uc1" %>
<%@ Register src="../usercontrol/footer.ascx" tagname="footer" tagprefix="uc4" %>
<%@ Register src="../usercontrol/school_info.ascx" tagname="school_info" tagprefix="uc4" %>
<%@ Register src="../usercontrol/feemanagement.ascx" tagname="feemanagement" tagprefix="uc5" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register Src="../usercontrol/footer.ascx" TagName="app_footer" TagPrefix="uc6" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The Schools.in - Admin</title>
    <link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/layout.css" media="screen" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../media/js/jquery.min.js"></script> 
    <link rel="stylesheet" type="text/css" href="../Media_front/Css/abtModal.css" />
	<script type="text/javascript" src="../Media_front/Js/abtModal.js"></script>    
    <script type="text/javascript">
        function showModal(url, w, h) {
            showabtModal('mothersMedicals', w, h);
            document.getElementById('trendsFrame').style.height = h + 'px';
            document.getElementById('trendsFrame').style.width = w + 'px';
            document.getElementById('trendsFrame').src = url;
        }
        function closeModal() {
            document.getElementById('trendsFrame').src = "";
            hideabtModal('mothersMedicals')
            window.parent.location = "feecancellation.aspx";
        }
    </script>
    <script type="text/javascript">
       function Validatation() {
            if (document.getElementById('txtadmno').value == "") {
                alert("Please enter the student admission number");
                document.getElementById('txtadmno').focus();
                return false
            }
        }
        function Clear() {
            document.getElementById('txtadmno').value = "";
            trstudent.style.display = "none";
            trGrid.style.display = "none";
            document.getElementById('txtadmno').focus();            
            return false
        }
        function Hide() {
            if (document.getElementById('txtadmno').value == "") {
                document.getElementById('txtadmno').value = "";
                trstudent.style.display = "none";
                trGrid.style.display = "none";
                return false
            }
        }
    </script> 
</head>
<body>
    <form id="form1" runat="server">
        <div id="mothersMedicals" class="dialog">
        <div style="text-align:center"><span onclick="closeModal();" style="float:right;clear:both;"  class="closeModal"></span></div>
        <iframe id="trendsFrame" src="" style="width:960px;height:300px;border:none;" scrolling='no' marginwidth='0' marginheight='0' frameborder='0'>some problem</iframe>
        </div>    
    <div>
     <asp:ToolkitScriptManager ID="ToolkitScriptManager" runat="server">
        </asp:ToolkitScriptManager>
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td style="width: 100%;" align="left">
                <uc3:topbanner ID="topbanner" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="width: 100%;" valign="top">
                <uc2:topmenu ID="topmenu" runat="server" />
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
                                        <%--<uc1:admin_leave ID="admin_leave" runat="server" />--%>
                                        <uc5:feemanagement ID="feemanagement1" runat="server" />
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
                                                <td class="app_cont_title_img_td"><img src="../images/icons/50X50/120.png" class="app_cont_title_img" alt="icon" /></td>
                                                <td align="left">Student fee Cancellation</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="break"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 100px; padding-left: 10px" valign="top" align="left">
                                       <%--<asp:UpdateProgress ID="Updateprocess" runat="server" AssociatedUpdatePanelID="updatepanal" DisplayAfter="1" >
                                         <ProgressTemplate>
                                            <div id="progressBackgroundFilter"></div>
                                            <div id="processMessage">
                                                <img alt="Loading" src="../media/images/Processing.gif" />
                                            </div>
                                         </ProgressTemplate>
                                       </asp:UpdateProgress>--%>
                                       <%--<asp:UpdatePanel ID="updatepanal" runat="server" UpdateMode="Conditional" >
                                       <ContentTemplate> --%>
                                        <table cellpadding="7" cellspacing="0" border="0" class="app_container">
                                            <tr class="view_detail_title_bg"><td colspan="4" style="width: 700px; height: 20px" align="left"><asp:Label CssClass="title_label" ID="lbltit" runat="server" Text="Student Fee Cancellation" ></asp:Label></td></tr>
                                            <tr>
                                                <td align="left" class="s_label">Admission number:</td>
                                                <td colspan="2" align="left"><asp:TextBox ID="txtadmno" runat="server" CssClass="s_textbox" onblur="return Hide();" MaxLength="10" AutoPostBack="true" ontextchanged="txtadmno_TextChanged"></asp:TextBox><a href="javascript: void(0)" onclick="showModal('searchstudentpopup.aspx?Mode=<% Response.Write(lblCancel.Text); %>','420','280')"/>&nbsp<input type="button" id="Search" value="Find" class="s_button" onclick="return Search_onclick()" /></td><td align="left"><asp:Label ID="lblCancel" runat="server" CssClass="s_label" Font-Bold="True" Visible="false" Text="FeeCancel"></asp:Label></td>
                                            </tr>
                                            <tr>
                                               <td align="left" style="width: 175px; height: 40px"></td>
                                                 <td align="left" style="width: 175px; height: 40px"><asp:Button ID="btnsearch" runat="server" CssClass="s_button" onclick="btnsearch_Click" OnClientClick="javascripts:return Validatation();" Text="View" />&nbsp;<asp:Button ID="btnclear" runat="server" CssClass="s_button" OnClientClick="return Clear();" Text="Clear" /></td>
                                                 <td align="left" style="width: 175px; height: 40px"></td><td align="left" style="width: 175px; height: 40px"></td>                                            
                                            </tr>
                                            <tr id="trstudent" runat="server" visible="false"><td style="width: 175px; height: 40px" align="left" class="s_label">Student Name</td><td ID="tdnametxt" runat="server" style="width: 175px; height: 40px" align="left"></td><td align="left" style="width:175px;" class="s_label">Class</td><td id="tdClasstxt" runat="server" align="left" style="width:175px"></td></tr>
                                            <tr id="trGrid" runat="server">
                                                <td colspan="4" align="left" style="width:100%; height: 40px">
                                                    <asp:DataGrid ID="grd_trasaction" runat="server" AutoGenerateColumns="False" Width="100%" BorderStyle="None" BorderWidth="0px" GridLines="None" CellPadding="4"><AlternatingItemStyle CssClass="s_datagrid_alt_item"/><ItemStyle CssClass="s_datagrid_item"/>
                                                        <Columns>
                                                            <asp:BoundColumn DataField="ID" HeaderText="ID" Visible="false"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="TransactionID" HeaderText="intid" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="PayMode" HeaderText="Mode"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="Paid" HeaderText="Amount"></asp:BoundColumn>                                                            
                                                            <asp:BoundColumn DataField="FromLedger" HeaderText="From Ledger"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="ToLedger" HeaderText="To Ledger"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="ChequeORddNo" HeaderText="Cheque/DD No"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="PaidDate" HeaderText="Paid Date"></asp:BoundColumn>                                                            
                                                            <asp:TemplateColumn HeaderText="Status"><ItemTemplate><asp:Button id="Cancel"  runat="server" CssClass="s_grdbutton" CausesValidation="false" CommandName="button" Text="Cancel" onclick="Cancel_Click" OnClientClick="return confirm('Are you sure you want to Cancel?')"  /></ItemTemplate></asp:TemplateColumn>
                                                    </Columns>
                                                <HeaderStyle CssClass="s_datagrid_header"/>
                                            </asp:DataGrid>
                                            </td>                                                
                                            </tr>
                                        </table>
                                        <%--</ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="txtadmno" />
                                            <asp:PostBackTrigger ControlID="btnsearch" />
                                        </Triggers>
                                        </asp:UpdatePanel>--%>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr><td style="width: 100%;" align="left" valign="top"><uc6:app_footer ID="footer" runat="server" /></td></tr>
    </table>
    </div>
    </form>
</body>
</html>
