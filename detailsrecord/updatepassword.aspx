<%@ Page Language="C#" AutoEventWireup="true" CodeFile="updatepassword.aspx.cs" Inherits="detailsrecord_updatepassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnupdatepassword" runat="server" Text="Update Password" 
            Font-Names="Verdana" onclick="btnupdatepassword_Click" />
    &nbsp;<asp:Button ID="btnsendemail" runat="server" Text="Send Email" 
            Font-Names="Verdana" onclick="btnsendemail_Click"/>
    </div>
    </form>
</body>
</html>
