<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditFormCS.aspx.cs" Inherits="EditFormCS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
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
    <asp:ScriptManager ID="scriptedit" runat="server"></asp:ScriptManager>
    <div>
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
 
        <asp:DetailsView ID="DetailsView1" DataKeyNames="intid" runat="server" AutoGenerateRows="False" HeaderText="LunchMenu Details"
            DataSourceID="AccessDataSource1" Height="50px" Width="300px" OnItemCommand="DetailsView1_ItemCommand">
           <RowStyle CssClass="s_datagrid_item" />
             <HeaderStyle    
               HorizontalAlign="Center" CssClass="view_detail_title_bg"  
                Height="50"  
                />  
             <AlternatingRowStyle CssClass="s_datagrid_alt_item" />
             <FooterStyle CssClass="view_detail_title_bg" />
            <Fields>
            <asp:TemplateField HeaderText="Day">
              <ItemTemplate>
                <%# Eval("strday")%>
              </ItemTemplate>
              <EditItemTemplate>
              <telerik:RadComboBox ID="RadComboBoxTitle" DataSourceID="SqlDataSource2" DataTextField="strday" runat="server" DataValueField="strday" SelectedValue='<%# Bind("strday") %>' ></telerik:RadComboBox>
              </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Type">
              <ItemTemplate>
                <%# Eval("strtype")%>
              </ItemTemplate>
              <EditItemTemplate>
              <telerik:RadComboBox ID="RadComboBoxTitle1" DataSourceID="SqlDataSource3" DataTextField="strtype" runat="server" DataValueField="strtype" SelectedValue='<%# Bind("strtype") %>' ></telerik:RadComboBox>
              </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="MealType">
              <ItemTemplate>
                <%# Eval("strmealstype")%>
              </ItemTemplate>
              <EditItemTemplate>
              <telerik:RadComboBox ID="RadComboBoxTitle2" DataSourceID="SqlDataSource4" DataTextField="strmealstype" runat="server" DataValueField="strmealstype" SelectedValue='<%# Bind("strmealstype") %>' ></telerik:RadComboBox>
              </EditItemTemplate>
            </asp:TemplateField>
                <asp:BoundField DataField="strfoodname" HeaderText="FoodName" SortExpression="strfoodname" />
                <asp:BoundField DataField="strcurryname" HeaderText="CurryName" SortExpression="strcurryname" />
                <asp:BoundField DataField="strsidedish" HeaderText="Sidedish" SortExpression="strsidedish" /> 
                 <asp:BoundField DataField="stradditional" HeaderText="Additional" SortExpression="stradditional" />               
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
            SelectCommand="SELECT intid,strday,strtype,strmealstype,strfoodname,strcurryname,strsidedish,stradditional FROM [tblmenutimetable] WHERE (intid = @intid)"
            UpdateCommand="UPDATE [tblmenutimetable] SET [strday] = @strday, [strtype] = @strtype, [strmealstype] = @strmealstype,strfoodname=@strfoodname,strcurryname=@strcurryname,strsidedish=strsidedish,stradditional=@stradditional WHERE intid = @intid" 
            InsertCommand="INSERT INTO [tblmenutimetable]  VALUES (@strday, @strtype, @strmealstype,@strfoodname,@strcurryname,@strsidedish,@stradditional)"
             
            > 
                          
            <UpdateParameters>
                <asp:Parameter Name="strday" Type="String" />
                <asp:Parameter Name="strtype" Type="String" />
                <asp:Parameter Name="strmealstype" Type="String" />
                <asp:Parameter Name="strfoodname" Type="String" />
                <asp:Parameter Name="strcurryname" Type="String" />
                <asp:Parameter Name="strsidedish" Type="String" />
                <asp:Parameter Name="stradditional" Type="String" />
               
                <asp:Parameter Name="intid" Type="Int32" />
                <asp:SessionParameter Name="SchoolID" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="strday" Type="String" />
                <asp:Parameter Name="strtype" Type="String" />
                <asp:Parameter Name="strmealstype" Type="String" />
                <asp:Parameter Name="strfoodname" Type="String" />
                <asp:Parameter Name="strcurryname" Type="String" />
                <asp:Parameter Name="strsidedish" Type="String" />
                <asp:Parameter Name="stradditional" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:QueryStringParameter Name="intid" QueryStringField="intid" Type="Int32" />
            </SelectParameters>
            </asp:SqlDataSource>
             <asp:SqlDataSource ID="SqlDataSource2" ConnectionString="<%$ AppSettings:conn %>"
                                                                                    ProviderName="System.Data.SqlClient" SelectCommand="select DISTINCT strday from tblmenutimetable where intschool=@SchoolID "
                                                                                    runat="server">
                                                                                    <SelectParameters>
                                                                                         <asp:SessionParameter SessionField="SchoolID" Name="SchoolID" Type="Int32" />
                                                                                    </SelectParameters>
                                                                                    </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource3" ConnectionString="<%$ AppSettings:conn %>"
                 ProviderName="System.Data.SqlClient" SelectCommand="select DISTINCT strtype from tblmenutimetable where intschool=@SchoolID "
                          runat="server">
                                                                                    <SelectParameters>
                                                                                         <asp:SessionParameter SessionField="SchoolID" Name="SchoolID" Type="Int32" />
                                                                                    </SelectParameters>
                                                                                    </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource4" ConnectionString="<%$ AppSettings:conn %>"
                 ProviderName="System.Data.SqlClient" SelectCommand="select DISTINCT strmealstype from tblmenutimetable where intschool=@SchoolID "
                          runat="server">
                                                                                    <SelectParameters>
                                                                                         <asp:SessionParameter SessionField="SchoolID" Name="SchoolID" Type="Int32" />
                                                                                    </SelectParameters>
                                                                                    </asp:SqlDataSource>
      
        </div>             
    </form>
</body>
</html>
