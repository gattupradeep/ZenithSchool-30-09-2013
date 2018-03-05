<%@ Control Language="C#" AutoEventWireup="true" CodeFile="smscategorymenu.ascx.cs" Inherits="usercontro_smscategorymenu" %>
<table width="100%" cellpadding="0" cellspacing="0" border="0" style="text-align:center">
    <tr>
        <td><asp:Button ID="btnss" runat="server" PostBackUrl="../communication/smsattendance.aspx" Text="Attendance" CssClass="sms_category" Width="100%" /></td>
        <td><asp:Button ID="Button1" runat="server" PostBackUrl="../communication/smshomework.aspx" Text="Homework" CssClass="sms_category" Width="100%" /></td>
        <td><asp:Button ID="Button2" runat="server" PostBackUrl="../communication/smsexamdetails.aspx" Text="Exam Details" CssClass="sms_category" Width="100%"/></td>
        <td><asp:Button ID="Button3" runat="server" PostBackUrl="../communication/smsreportcard.aspx" Text="Report Card" CssClass="sms_category" Width="100%"/></td>
        <td><asp:Button ID="Button4" runat="server" PostBackUrl="../communication/smsgeneral.aspx" Text="General" CssClass="sms_category" Width="100%"/></td>
        <td><asp:Button ID="Button5" runat="server" PostBackUrl="../communication/smsfoodmenu.aspx" Text="Food Menu" CssClass="sms_category" Width="100%" /></td>
    </tr>
    <tr>
        <td><asp:Button ID="Button6" runat="server" PostBackUrl="../communication/smstransfercertificate.aspx" Text="TC" CssClass="sms_category" Width="100%" /></td>
        <td><asp:Button ID="Button13" runat="server" PostBackUrl="../communication/smsleavemanagement.aspx" Text="Leave Status" CssClass="sms_category" Width="100%" /></td>
        <td><asp:Button ID="Button7" runat="server" PostBackUrl="../communication/smsfestival.aspx" Text="Festival" CssClass="sms_category" Width="100%"  /></td>
        <td><asp:Button ID="Button8" runat="server" PostBackUrl="../communication/smsdiscipline.aspx" Text="Discipline" CssClass="sms_category" Width="100%" /></td>
        <td><asp:Button ID="Button9" runat="server" PostBackUrl="../communication/smstransport.aspx" Text="Transport" CssClass="sms_category" Width="100%" /></td>
        <td><asp:Button ID="Button10" runat="server" PostBackUrl="../communication/smsevents.aspx" Text="Events" CssClass="sms_category" Width="100%" /></td>
    </tr>
    <tr>
        <td><asp:Button ID="Button12" runat="server" PostBackUrl="../communication/smskeyword.aspx" Text="Library" CssClass="sms_category" Width="100%" /></td>
        <td><asp:Button ID="Button11" runat="server" PostBackUrl="../communication/smsbirthday.aspx" Text="Birthday" CssClass="sms_category" Width="100%" /></td>
        <td><asp:Button ID="Button14" runat="server" PostBackUrl="../communication/smsfeestatus.aspx" Text="Fee Status" CssClass="sms_category" Width="100%" /></td>
        <td><asp:Button ID="Button15" runat="server" PostBackUrl="../communication/smskeyword.aspx" Text="Results" CssClass="sms_category" Width="100%" /></td>
        <td><asp:Button ID="Button16" runat="server" PostBackUrl="../communication/smsstaffsubstitute.aspx" Text="Substitute Details" CssClass="sms_category" Width="100%" /></td>
        <td><asp:Button ID="Button17" runat="server" PostBackUrl="../communication/smsnoticeboard.aspx" Text="Notice Board" CssClass="sms_category" Width="100%" /></td>
    </tr>
</table>
