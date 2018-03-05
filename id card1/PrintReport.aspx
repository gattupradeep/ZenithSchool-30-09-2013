<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintReport.aspx.cs" Inherits="id_card_PrintReport" %>
<%@ Register src="../usercontrol/topmenu.ascx" tagname="topmenu" tagprefix="uc2" %>

<%@ Register src="../usercontrol/topbanner.ascx" tagname="topbanner" tagprefix="uc3" %>

<%@ Register src="../usercontrol/detailsrecord_student.ascx" tagname="detailsrecord_student" tagprefix="uc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit.HTMLEditor" tagprefix="cc2" %>

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
    <link href="../media/css/calendar.css" rel="Stylesheet" type="text/css" />    
    <link rel="stylesheet" type="text/css" href="../css/main.css" />
    <script type="text/javascript" src="../media/js/jquery.min.js"></script> 
    <style type="text/css">
        .style1
        {
            width: 11%;
        }
        #idcard
        {
            width: 720px;
            margin-left: 29px;
            margin-right: 0px;
        }
        .style2
        {
            width: 1%;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
      <tr>
        <td style="width: 100%; height: 100px; padding-left: 50px" valign="top" align="left">
            <table width="300px" border="1">
              <tr id="trimage1" runat="server"  >
                 <td style="width: 100%; height: 100px; padding-left: 50px" valign="top" align="left">
                <table style="width: 353px" >
                    
                    <tr>
                     
                         <td style="width:250px; height:70px" align="left">
                            
                            <img src = "../media/images/reportcard.png" alt="photo" id="zenith" width="100" height="100" /><br />
                             <br />
                             <br />
                             <asp:Label ID="lblname" runat="server" CssClass="s_label" Text="name"></asp:Label><br />
                                                                                    
                             <asp:Label ID="lblstandard" runat="server" CssClass="s_label" Text="standard"></asp:Label>
                              <br />
                              <asp:Label ID="lblvalidity" runat="server" CssClass="s_label" Text="Validity"></asp:Label>
                            
                                                                         
                         </td>
                         <td style="width:50px; height:70px" align="center">
                              <asp:Label ID="lblstudent" runat="server" CssClass="s_label" Text="STUDENT"></asp:Label>
                              <img  src = "../images/student/.jpg" alt="photo" width="100" height="100" />
                                                                                       
                              
                             <asp:Label ID="lbladmin" runat="server" CssClass="s_label" Text="admin"></asp:Label>
                              <asp:Label ID="lblid" runat="server" CssClass="s_label" Visible="False"></asp:Label>
                              <asp:Label ID="lblline" runat="server" Width="150px" CssClass="s_label" Text="____________________"></asp:Label>
                              <asp:Label ID="lblreg" runat="server" Width="150px" CssClass="s_label" Text="Register"></asp:Label>
                               
                        </td>
                       
                    </tr>
                    <tr>
                        <td></td>
                        <td style="width:30px; height:50px" align="left">
                            <asp:Label ID="Label8" runat="server" Width="150px" CssClass="s_label" Text="Principal Sign"></asp:Label>
                        </td>
                    </tr>
                  
                    </table>
              </td>
              </tr>
            </table>
        </td>
      </tr>
      </table>
    </div>
    </form>
</body>
</html>
