<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditformforHomework.aspx.cs" Inherits="student_EditformforHomework" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <style type="text/css">          
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
            DataSourceID="AccessDataSource1" Height="50px" Width="300px" OnItemCommand="DetailsView1_ItemCommand" HeaderText="Discipline Details">
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
                <%# Eval("strstandard")%>
              </ItemTemplate>
              <EditItemTemplate>
              <telerik:RadComboBox ID="RadComboBoxTitle" DataSourceID="SqlDataSource2" DataTextField="strstandard" runat="server" DataValueField="strstandard" SelectedValue='<%# Bind("strstandard") %>' ></telerik:RadComboBox>
              </EditItemTemplate>
            </asp:TemplateField>
                <asp:BoundField DataField="strsubject" SortExpression="strsubject" HeaderText="Subject" ReadOnly="true"/>
                <asp:BoundField DataField="strstaffname" HeaderText="StaffName" SortExpression="strstaffname"  ReadOnly="true"/>
                 <asp:BoundField DataField="strassigndate" HeaderText="AssignDate" SortExpression="strassigndate" ReadOnly="true"/>
                <asp:BoundField DataField="strduedate" HeaderText="DueDate" SortExpression="strduedate" ReadOnly="true" />
                <asp:BoundField DataField="strpublishdate" HeaderText="PublishDate" SortExpression="strpublishdate"  ReadOnly="true"/>
                <asp:BoundField DataField="strtopic" HeaderText="Topics" SortExpression="strtopic" />
                <asp:BoundField DataField="strdescription" HeaderText="Discription" SortExpression="strdescription" />
               
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
            SelectCommand="select a.intid,b.strstandard, c.strfirstname + ' ' + ltrim(c.strmiddlename) + ' ' + ltrim(c.strlastname) as strstaffname,b.strsubject,a.strtopic,a.strdescription,convert(varchar(10),dtassigndate,103) as strassigndate,convert(varchar(10),dtduedate,103) as strduedate,convert(varchar(10),dtpublishdate,103) as strpublishdate from tblhomework a, tblhomeworktopics b, tblemployee c where b.intid=a.inttopic and a.intemployee=c.intid  and a.intschool=@SchoolID and a.intid=@intid "
            UpdateCommand="UPDATE [tblhomework] SET strtopic=@strtopic,strdescription=@strdescription WHERE intid = @intid" 
            > 
                          
            <UpdateParameters>
                <asp:Parameter Name="strtopic" Type="String" />
                <asp:Parameter Name="strdescription" Type="String" />
                <asp:Parameter Name="intid" Type="Int32" />
            </UpdateParameters>
            <SelectParameters>
                <asp:SessionParameter Name="SchoolID" SessionField="SchoolID" Type="Int32" />
                <asp:QueryStringParameter Name="intid" QueryStringField="intid" Type="Int32" />
            </SelectParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource2" ConnectionString="<%$ AppSettings:conn %>"
                  ProviderName="System.Data.SqlClient" SelectCommand="select distinct strstandard from tblhomeworktopics where intschool=@SchoolID group by strstandard" runat="server">
                       <SelectParameters>
                             <asp:SessionParameter SessionField="SchoolID" Name="SchoolID" Type="Int32" />
                      </SelectParameters>
            </asp:SqlDataSource>
           <asp:SqlDataSource ID="SqlDataSource3" ConnectionString="<%$ AppSettings:conn %>"
                     ProviderName="System.Data.SqlClient" SelectCommand="select DISTINCT strsection from tbldiscipline where intschool=@SchoolID" runat="server">
                <SelectParameters>
                   <asp:SessionParameter SessionField="SchoolID" Name="SchoolID" Type="Int32" />
                </SelectParameters>                                                                                                                                          
           </asp:SqlDataSource> 
    </form>
</body>
</html>
