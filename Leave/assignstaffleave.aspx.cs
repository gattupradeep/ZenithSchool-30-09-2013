using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Leave_assignstaffleave : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public DataAccess da;
    public DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {            
            dept();
            designation();
            staffname();
            leavecategory();
            fillleave();
        }
    }
    protected void drpdesignation_SelectedIndexChanged(object sender, EventArgs e)
    {
        staffname();
        fillleave();
    }
   protected void fillleave()
   {
       DataAccess da = new DataAccess();
       DataSet ds = new DataSet();
       string sql = "select a.intid as id, a.intleavecategory,a.intnoofdays,a.intstaffid,b.intid,b.strleavetype,c.strfirstname + '' + c.strmiddlename + '' + c.strlastname as staffname,c.intDepartment,c.intDesignation,d.strdepartmentname,e.strdesignation from tblassignstaffleave a,tblschoolleavecategory b,tblemployee c,tbldepartment d,tbldesignation e where b.intid=a.intleavecategory and c.intdepartment=d.intid and c.intdesignation=e.intid and a.intstaffid=c.intid and a.intstaffid='" + drpstaffname.SelectedValue + "' and a.intschool='"+Session["schoolID"].ToString()+"'";
       ds = da.ExceuteSql(sql);
       if (ds.Tables[0].Rows.Count > 0)
       {
           grdleavecategory.DataSource = ds.Tables[0];
           grdleavecategory.DataBind();
           grdleavecategory.Visible = true;
       }
       else
       {
           grdleavecategory.Visible = false;
       }

   }
    protected void dept()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string sql = "select * from tbldepartment where intschool=" + Session["schoolID"].ToString() + " and intid in(select intdepartment from tblemployee where intschool=" + Session["schoolID"].ToString() + " group by intdepartment)";
        ds = da.ExceuteSql(sql);
        drpdept.DataTextField = "strdepartmentname";
        drpdept.DataValueField = "intid";
        drpdept.DataSource = ds;
        drpdept.DataBind();
        ListItem li=new ListItem("-select-","0");
        drpdept.Items.Insert(0,li);
    }

    protected void designation()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string sql = "select * from tbldesignation where intschool='" + Session["schoolID"].ToString() + "' and intid in(select intdesignation from tblemployee where intdepartment=" + drpdept.SelectedValue + " and intschool='" + Session["schoolID"].ToString() + "' group by intdesignation)";
        ds = da.ExceuteSql(sql);
        drpdesignation.DataTextField = "strdesignation";
        drpdesignation.DataValueField = "intid";
        drpdesignation.DataSource = ds;
        drpdesignation.DataBind();
        ListItem li = new ListItem("-select-", "0");
        drpdesignation.Items.Insert(0, li);
    }

    protected void leavecategory()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string sql = "select intid,strleavetype from tblschoolleavecategory where intschool='" + Session["schoolID"].ToString() + "' group by intid,strleavetype";
        ds = da.ExceuteSql(sql);
        drpleavecategory.DataTextField = "strleavetype";
        drpleavecategory.DataValueField = "intid";
        drpleavecategory.DataSource = ds;
        drpleavecategory.DataBind();
        ListItem li = new ListItem("-select-", "0");
        drpleavecategory.Items.Insert(0, li);
    }
    protected void staffname()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string sql = "select strfirstname + '' + strmiddlename + '' + strlastname as strstaffname,intid from tblemployee where intDepartment='" + drpdept.SelectedValue + "' and intDesignation='" + drpdesignation.SelectedValue + "' and intschool='" + Session["schoolID"].ToString() + "'";
        ds = da.ExceuteSql(sql);
        drpstaffname.DataSource = ds;
        drpstaffname.DataTextField = "strstaffname";
        drpstaffname.DataValueField = "intid";        
        drpstaffname.DataBind();
        ListItem li = new ListItem("-select-", "0");
        drpstaffname.Items.Insert(0, li);
    }
    protected void clear()
    {
        drpleavecategory.SelectedIndex = 0;
        txtnoofdays.Text = "";
        btnSave.Text = "Save";
        drpdept.Enabled = true;
        drpdesignation.Enabled = true;
        drpstaffname.Enabled = true;
    }
    protected void addclear()
    {
        leavecategory();
        txtnoofdays.Text = "";
        btnSave.Text = "Save";
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (drpdept.SelectedIndex > 0)
        {
            if (drpdesignation.SelectedIndex > 0)
            {
                if (drpstaffname.SelectedIndex > 0)
                {
                    try
                    {
                        DataAccess da = new DataAccess();
                        DataSet ds = new DataSet();
                        string sql = "select * from tblassignstaffleave where intstaffid='" + drpstaffname.SelectedValue + "' and intleavecategory='" + drpleavecategory.SelectedValue + "' and intschool='" + Session["schoolID"].ToString() + "'";
                        ds = da.ExceuteSql(sql);
                        if ((ds.Tables[0].Rows.Count > 0) && (btnSave.Text == "Save"))
                        {
                            MsgBox.alert("Selected Leave Category Already Assigned");
                        }
                        else
                        {
                            SqlCommand RegCommand;
                            SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
                            Conn.Open();
                            RegCommand = new SqlCommand("spassignstaffleave", Conn);
                            RegCommand.CommandType = CommandType.StoredProcedure;
                            if (btnSave.Text == "Save")
                            {
                                RegCommand.Parameters.Add("@intid", "0");
                            }
                            else
                            {
                                RegCommand.Parameters.Add("@intid", Session["intid"].ToString());
                            }
                            RegCommand.Parameters.Add("@intschool", Session["schoolID"].ToString());
                            RegCommand.Parameters.Add("@intstaffid", drpstaffname.SelectedValue.ToString());
                            RegCommand.Parameters.Add("@intleavecategory", drpleavecategory.SelectedValue.Trim());
                            RegCommand.Parameters.Add("@intnoofdays", txtnoofdays.Text.Trim());
                            RegCommand.ExecuteNonQuery();
                            Conn.Close();
                            fillleave();
                            addclear();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Details Saved Successfully')", true);
                        }
                    }
                    catch
                    {
                        MsgBox.alert("Please Enter Numeric Values Only");
                    }
                }
                else
                MsgBox.alert("Please Select The Staff");
            }
            else
            MsgBox.alert("Please Select The Designation");
        }
        else
        MsgBox.alert("Please Select the Department");

    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        clear();
    }
    //protected void grdleavecategory_DeleteCommand(object source, DataGridCommandEventArgs e)
    //{
    //    DataAccess da = new DataAccess();
    //    string sql = "delete tblassignstaffleave where intid=" + e.Item.Cells[0].Text;
    //    da.ExceuteSqlQuery(sql);
    //    fillleave();
    //}
    protected void grdleavecategory_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["intid"] = e.Item.Cells[0].Text;
        dept();
        drpdept.SelectedValue = e.Item.Cells[5].Text;
        designation();
        drpdesignation. SelectedValue = e.Item.Cells[6].Text;
        staffname();
        drpstaffname.SelectedValue = e.Item.Cells[1].Text;
        leavecategory();
        drpleavecategory.SelectedValue = e.Item.Cells[2].Text;
        txtnoofdays.Text = e.Item.Cells[4].Text;
        btnSave.Text = "update";
        drpdept.Enabled = false;
        drpdesignation.Enabled = false;
        drpstaffname.Enabled = false;
    }
    protected void drpdept_SelectedIndexChanged(object sender, EventArgs e)
    {
        designation();
        staffname();
    }
    protected void drpstaffname_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillleave();
    }

    protected void btndelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton delete = (ImageButton)sender;
        TableCell cell = delete.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        DataAccess da = new DataAccess();
        string sql = "delete tblassignstaffleave where intid=" + item.Cells[0].Text;
        Functions.UserLogs(Session["UserID"].ToString(), "tblassignstaffleave", item.Cells[0].Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),63);
        da.ExceuteSqlQuery(sql);
        fillleave();
    }
}
