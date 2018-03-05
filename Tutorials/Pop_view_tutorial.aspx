<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Pop_view_tutorial.aspx.cs" Inherits="Tutorials_Pop_view_tutorial" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Online - Tutorial</title>
    <link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/layout.css" media="screen" rel="stylesheet" type="text/css" />
    <link rel="Stylesheet" href="support/drplayer.css" type="text/css" />
    <script src="support/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="support/drplayer.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function() {
            $("#playlist").playlist(
                {
                    playerurl: "support/drplayer.swf"
                }
            );
        });
    </script>
    
</head>
<body>
    <form id="form1" runat="server">
    <div >
        <table cellpadding="0" cellspacing="0" border="0" width="100%">
            <tr class="view_detail_title_bg">
                <td class="title_label_value">Tutorials</td>
            </tr>
            <tr align="center">
                <td style="width:95%">
                    <table cellpadding="7" cellspacing="0" border="0" width="95%">
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label16" runat="server" Text="Date" 
                                    CssClass="s_label" Font-Bold="True"></asp:Label></td>
                            <td align="left"><asp:Label ID="lbldate" runat="server" CssClass="s_label"></asp:Label></td>
                            <td align="left"><asp:Label ID="Label1" runat="server" Text="Publish Date" 
                                    CssClass="s_label" Font-Bold="True"></asp:Label></td>
                            <td align="left"><asp:Label ID="lblpublishdate" runat="server" CssClass="s_label"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left"><asp:Label ID="Label2" runat="server" Text="Class & Section" 
                                    CssClass="s_label" Font-Bold="True"></asp:Label></td>
                            <td align="left"><asp:Label ID="lblclass" runat="server"  CssClass="s_label"></asp:Label></td>
                            <td align="left"><asp:Label ID="Label15" runat="server" Text="Teacher" 
                                    CssClass="s_label" Font-Bold="True"></asp:Label></td>
                            <td align="left"><asp:Label ID="lblteacher" runat="server"  CssClass="s_label"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left"><asp:Label ID="Label4" runat="server" Text="Subject" 
                                    CssClass="s_label" Font-Bold="True"></asp:Label></td>
                            <td align="left"><asp:Label ID="lblsubject" runat="server" CssClass="s_label"></asp:Label></td>
                            <td align="left"><asp:Label ID="Label7" runat="server" Text="TextBook" 
                                    CssClass="s_label" Font-Bold="True"></asp:Label></td>
                            <td align="left"><asp:Label ID="lbltextbook" runat="server"  CssClass="s_label"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left"><asp:Label ID="Label9" runat="server" Text="Unit" 
                                    CssClass="s_label" Font-Bold="True"></asp:Label></td>
                            <td align="left"><asp:Label ID="lblunit" runat="server" CssClass="s_label"></asp:Label></td>
                            <td align="left"><asp:Label ID="Label11" runat="server" Text="Lesson" 
                                    CssClass="s_label" Font-Bold="True"></asp:Label></td>
                            <td align="left"><asp:Label ID="lbllesson" runat="server"  CssClass="s_label"></asp:Label></td>
                        </tr>
                        <tr>
                            <td valign="top"><asp:Label ID="Label13" runat="server" Text="Description" 
                                    CssClass="s_label" Font-Bold="True"></asp:Label></td>
                            <td colspan="3"><asp:Label ID="lbldescripton" runat="server" CssClass="s_label" Width="100%" Height="100%"></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                    <tr>
                                        <td valign="top" class="mp3"></td>
                                        <td>&nbsp;<asp:Label ID="Label3" runat="server" Text="Audio :" CssClass="s_label" 
                                                Font-Bold="True"></asp:Label></td>
                                        <td valign="top" class="doc"></td>
                                        <td>&nbsp;<asp:Label ID="Label5" runat="server" Text="Documents :" 
                                                CssClass="s_label" Font-Bold="True"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td valign="top"><asp:Label ID="lblaudio" runat="server" CssClass="s_label"></asp:Label></td>
                                        <td></td>
                                        <td valign="top"><asp:Label ID="lbldocument" runat="server"  CssClass="s_label"></asp:Label></td>
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
