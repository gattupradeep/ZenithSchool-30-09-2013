<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditformSpecialclass.aspx.cs" Inherits="specialclasses_EditformSpecialclass" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <link rel="stylesheet" href="../jquery-ui-timepicker.css?v=0.2.3" type="text/css" />    
    <script type="text/javascript" src="../jquery.ui.timepicker.js?v=0.2.3"></script>
     <style>
   .s_datagrid_item
{
	 background-image:url('../media/images/rowBg1.gif');
     background-repeat:repeat-x;
	
	font-family:Verdana;
	font-size:11px;
	height:25px;
}

.s_datagrid_alt_item
{
     background-image:url('../media/images/bg.gif');
     background-repeat:repeat-x;
	font-family:Verdana;
	font-size:11px;
	height:25px;
}
.view_detail_title_bg
{ 
	background-image:url('../media/images/header1.gif');
     background-repeat:repeat-y;
	height:45px;
	color:#fff;
	font-family:Tahoma, arial;
    font-size:14px;
    font-weight:bolder;
    letter-spacing:1px;	
    margin-left:5px;	
}
</style>
</head>
<body>
    <form id="form1" runat="server">
   <asp:ScriptManager ID="script"  runat="server"></asp:ScriptManager>
   <telerik:RadCodeBlock ID="radcode" runat="server">
    <script type="text/javascript">
        $(document).ready(function() {
            var id = document.getElementById('<%=DetailsView1.FindControl("txttotime").ClientID%>');
            $('id').timepicker();
        });
        $(document).ready(function() {
            $('#txttotime').timepicker();
        });        
    </script>
   </telerik:RadCodeBlock>
    <script type="text/javascript">
        function CloseAndRebind(args) {

            GetRadWindow().BrowserWindow.refreshGrid(args);
            GetRadWindow().Close();
        }

        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
            else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz as well)

            return oWindow;
        }

        function CancelEdit() {
            GetRadWindow().Close();
        }
        </script>
 
        <asp:DetailsView ID="DetailsView1" DataKeyNames="intid" runat="server" AutoGenerateRows="False"
            DataSourceID="AccessDataSource1" Height="50px" Width="300px" OnItemCommand="DetailsView1_ItemCommand" HeaderText="Specialclass Details">
            <RowStyle CssClass="s_datagrid_item" />
           <HeaderStyle    
               HorizontalAlign="Center" CssClass="view_detail_title_bg"  
                Height="50"  
                />  
             <AlternatingRowStyle CssClass="s_datagrid_alt_item" />
             <FooterStyle CssClass="view_detail_title_bg" />
            <Fields>
              <asp:TemplateField HeaderText="Class">
              <ItemTemplate>
                <%# Eval("str_class")%>
              </ItemTemplate>
              <EditItemTemplate>
              <telerik:RadComboBox ID="RadComboBoxTitle" DataSourceID="SqlDataSource2" DataTextField="str_class" runat="server" DataValueField="str_class" SelectedValue='<%# Bind("str_class") %>' ></telerik:RadComboBox>
              </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Subjects">
              <ItemTemplate>
                <%# Eval("str_subject")%>
              </ItemTemplate>
              <EditItemTemplate>
              <telerik:RadComboBox ID="RadComboBoxTitle1" DataSourceID="SqlDataSource3" DataTextField="str_subject" runat="server" DataValueField="str_subject" SelectedValue='<%# Bind("str_subject") %>' ></telerik:RadComboBox>
              </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="StaffName" >
              <ItemTemplate>
                <%# Eval("strstaffname")%>
              </ItemTemplate>
              <EditItemTemplate>
                <asp:Label ID="txttotime" runat="server" CssClass="s_textbox" Text='<%# Bind("strstaffname") %>'></asp:Label>
               <%--<asp:TextBox ID="txttotime" runat="server" CssClass="s_textbox" Text='<%# Bind("strstaffname") %>' ></asp:TextBox>--%>
              </EditItemTemplate>
            </asp:TemplateField>
                <asp:BoundField DataField="dtdate" HeaderText="Date" SortExpression="dtdate" ReadOnly="true" />
                <asp:BoundField DataField="str_startTime" HeaderText="StartTime" SortExpression="str_startTime" />
                <asp:BoundField DataField="str_endtime" HeaderText="EndTime" SortExpression="str_endtime" />
                <asp:BoundField DataField="strremarks" HeaderText="Remarks" SortExpression="strremarks" />
            </Fields>
             <FooterTemplate>
               <asp:ImageButton ID="btnUpdate" runat="server" CausesValidation="True" CommandName="Update" ImageUrl="~/media/images/UpdateRad.gif" AlternateText="Update"
                 Text="Aktualisieren" />
               <asp:ImageButton ID="btnCancel" runat="server" CausesValidation="False" CommandName="Cancel" ImageUrl="~/media/images/CancelRad.gif"  AlternateText="Cancel" />
              
            </FooterTemplate>
        </asp:DetailsView>
        
        <asp:SqlDataSource  ConnectionString="<%$ AppSettings:conn %>"
            ProviderName="System.Data.SqlClient"
            ID="AccessDataSource1" 
            runat="server" 
            SelectCommand="select a.intid,str_class,str_startTime,str_endtime,convert(varchar(10),dt_date,111) as dtdate,str_subject,a.strremarks,b.strfirstname + ' ' + ltrim(b.strmiddlename) + ' ' + ltrim(b.strlastname) as strstaffname from tblspecialclasses a,tblemployee b where a.int_employee=b.intID and a.intid=@intid "
            UpdateCommand="UPDATE [tblspecialclasses] SET [str_class] = @str_class, [str_startTime] = @str_startTime,str_endtime=@str_endtime,strremarks=@strremarks,str_subject=@str_subject WHERE intid = @intid" 
            > 
                          
            <UpdateParameters>
                <asp:Parameter Name="str_class" Type="String" />
                <asp:Parameter Name="str_startTime" Type="String" />
               <asp:Parameter Name="str_subject" Type="String" />
               <asp:Parameter Name="strremarks" Type="String" />
                <asp:Parameter Name="str_endtime" Type="String" />
                <asp:Parameter Name="intid" Type="Int32" />
                <asp:SessionParameter Name="SchoolID" Type="Int32" />
            </UpdateParameters>
            <SelectParameters>
                <asp:QueryStringParameter Name="intid" QueryStringField="intid" Type="Int32" />
            </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource2" ConnectionString="<%$ AppSettings:conn %>"
                                                                                    ProviderName="System.Data.SqlClient" SelectCommand="select DISTINCT str_class from tblspecialclasses where intschool=@SchoolID "
                                                                                    runat="server">
                                                                                    <SelectParameters>
                                                                                         <asp:SessionParameter SessionField="SchoolID" Name="SchoolID" Type="Int32" />
                                                                                    </SelectParameters>
                                                                                    </asp:SqlDataSource>
           <asp:SqlDataSource ID="SqlDataSource3" ConnectionString="<%$ AppSettings:conn %>"
                     ProviderName="System.Data.SqlClient" SelectCommand="select DISTINCT str_subject from tblspecialclasses where intschool=@SchoolID" runat="server">
                                                                                    <SelectParameters>
                                                                                         <asp:SessionParameter SessionField="SchoolID" Name="SchoolID" Type="Int32" />
                                                                                    </SelectParameters>
                                                                                 </asp:SqlDataSource> 
    </form>
</body>
</html>
