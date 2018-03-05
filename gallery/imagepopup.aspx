<%@ Page Language="C#" AutoEventWireup="true" CodeFile="imagepopup.aspx.cs" Inherits="gallery_imagepopup" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The Schools.in</title>
    <link href="../media/css/styles.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="../media/css/layout.css" media="screen" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../media/js/jquery.min.js"></script>
    <link rel="stylesheet" type="text/css" href="../Media_front/Css/abtModal.css" />
	<script type="text/javascript" src="../Media_front/Js/abtModal.js"></script>
	
	<link href="../css/cropcss/jquery.Jcrop.css" media="screen" rel="stylesheet" type="text/css" />
	<script type="text/javascript" src="../media/js/cropjs/jquery.min.js"></script>
    <script type="text/javascript"  src="../media/js/cropjs/jquery.Jcrop.min.js"></script>
    <script type="text/javascript"  language="Javascript">

        jQuery(function() {
        jQuery('#image').Jcrop({
                aspectRatio: 1,
                onSelect: updateCoords
            });

        });

        function updateCoords(c) {
            jQuery('#X').val(c.x);
            jQuery('#Y').val(c.y);
            jQuery('#W').val(c.w);
            jQuery('#H').val(c.h);
        };

        function checkCoords() {
            if (parseInt(jQuery('#w').val()) > 0) return true;
            alert('Please select a crop region then press submit.');
            return false;
        };

        jQuery(function() {
            jQuery('#showcode').FieldsetToggle('Code for this demo');
        });

        </script>
    
    </head>
<body>
    <form id="form1" runat="server">
    <div>
        <table cellpadding="0" cellspacing="0" border="0" style="margin-left:15px; margin-right:15px; max-width:1000px; margin-bottom:50px; margin-top:20px">
            <tr>
                <td colspan="3" align="center" style="width:100%; height:10%">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td align="right" style="width:100%; height:40px"> 
                                <asp:Label ID="lblname" runat="server" Multiline="True" Width="100px" CssClass="s_gridlabel"></asp:Label>
                                <asp:Label ID="lblnextback" runat="server"  CssClass="s_gridlabel" Visible="false"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center" style="width:80%; height:70%">
                    <asp:Panel ID="imgCropped" runat="server">
                        <img alt="Processing..." id="image" runat="server" src="" style="max-width:1000px"  />
                    </asp:Panel>
                </td>
            </tr>
            <tr id="trdescriptiontxt" runat="server">
                <td colspan="3" align="center" style="width:100%; height:40px">
                    <asp:Label ID="lbldescription" runat="server" CssClass="s_label"></asp:Label>
                </td>
            </tr>
            <tr id="trtagcropchange" runat="server">
                <td runat="server" align="center" style="width:100%; height:10%">
                    <asp:Button ID="btntag" runat="server" Text="Tag Image" CssClass="s_grdbutton" Visible="false" />
                    <asp:HiddenField ID="X" runat="server" />
                     <asp:HiddenField ID="Y" runat="server" />
                     <asp:HiddenField ID="W" runat="server" />
                     <asp:HiddenField ID="H" runat="server" />
                    <asp:Button ID="btncrop" runat="server" Text="Crop Image" CssClass="s_grdbutton" 
                        onclick="btncrop_Click" />
                    <asp:Button ID="btnchange" runat="server" Text="Change Image" CssClass="s_grdbutton" 
                        onclick="btnchange_Click" />
                    <asp:Button ID="btncancel" runat="server" Text="Cancel" CssClass="s_grdbutton" onclick="btncancel_Click" 
                    />
                </td>
            </tr>
            <tr class="break">
                <td></td>
            </tr>
            <tr id="trupload" visible="false" runat="server">
                <td colspan="3" align="left" style="width:100%; height:10%">
                    <asp:FileUpload ID="uploadimage" runat="server" />
                    <asp:Button ID="btnupload" runat="server" Text="Upload Image" CssClass="s_grdbutton" 
                    onclick="btnupload_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
