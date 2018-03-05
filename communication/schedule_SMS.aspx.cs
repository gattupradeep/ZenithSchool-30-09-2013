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

public partial class communication_schedulesms : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public SqlCommand cmd;
    public DataAccess da;
    public DataSet ds,ds1;
    public string strsql;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillcategorygrid();
            filldgsmsschedule();
            //fillmessages();
            lblselectedmsg.Text = "";
        }
    }
    protected void fillcategorygrid()
    {
        da = new DataAccess();
        ds = new DataSet();
        strsql = "select * from tblsmscategory";
        ds = da.ExceuteSql(strsql);
        dgcategory.DataSource = ds;
        dgcategory.DataBind();
    }
    protected void dgcategory_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["categoryID"] = e.Item.Cells[0].Text;
        filltemplate();
    }
    protected void filltemplate()
    {
       
        da = new DataAccess();
        ds = new DataSet();
        strsql = "select intid,strtemplatename,strmessage from tblsmstemplate where intschool = '" + Session["SchoolID"].ToString() + "' and intcategoryid = " + Session["categoryID"].ToString();
        ds = da.ExceuteSql(strsql);
        dgsmstemplate.DataSource = ds;
        dgsmstemplate.DataBind();
        lblselectedmsg.Text = ds.Tables[0].Rows[0]["strmessage"].ToString();
    }

    protected void dgsmstemplate_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        Session["smstemplateid"] = e.Item.Cells[0].Text;
        fillmessages();
        
    }
    protected void fillmessages()
    {
        da = new DataAccess();
        ds = new DataSet();
        strsql = "select intid as templateid ,strtemplatename,strmessage from tblsmstemplate where intschool = '" + Session["SchoolID"].ToString() + "' and intid = " + Session["smstemplateid"].ToString();
        ds = da.ExceuteSql(strsql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblselectedmsg.Text = ds.Tables[0].Rows[0]["strmessage"].ToString();
        }
    }
    // Patron type changed event
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddpatron.SelectedValue == "-Select-")
        {
            chkgroups.Items.Clear();
        }
        if(ddpatron.SelectedValue == "Student")
        {
            da = new DataAccess();
            ds = new DataSet();
            strsql = "select strstandard,strsection, strstandard +' - '+strsection as stdandsec from tblstandard_section_subject where intschoolid =" + Session["SchoolID"].ToString() + " group by strstandard, strsection";
            ds = da.ExceuteSql(strsql);
            chkgroups.Items.Clear();
            ListItem li;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                li = new ListItem(ds.Tables[0].Rows[i]["stdandsec"].ToString(), ds.Tables[0].Rows[i]["stdandsec"].ToString());
                chkgroups.Items.Add(li);
            }
        }
        if (ddpatron.SelectedValue == "Teaching Staff")
        {
            da = new DataAccess();
            ds = new DataSet();
            strsql = "select intid,strfirstname+' '+strmiddlename+' '+strlastname as staffname from tblemployee where intschool=" + Session["SchoolID"].ToString() + " and strtype='Teaching Staff'";
            ds = da.ExceuteSql(strsql);
            chkgroups.Items.Clear();
            ListItem li;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                li = new ListItem(ds.Tables[0].Rows[i]["staffname"].ToString(), ds.Tables[0].Rows[i]["intid"].ToString());
                chkgroups.Items.Add(li);
            }
        }
        if (ddpatron.SelectedValue == "Non Teaching Staff")
        {
            da = new DataAccess();
            ds = new DataSet();
            strsql = "select intid,strfirstname+' '+strmiddlename+' '+strlastname as staffname from tblemployee where intschool=" + Session["SchoolID"].ToString() + " and strtype='Non Teaching Staff'";
            ds = da.ExceuteSql(strsql);
            chkgroups.Items.Clear();
            ListItem li;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                li = new ListItem(ds.Tables[0].Rows[i]["staffname"].ToString(), ds.Tables[0].Rows[i]["intid"].ToString());
                chkgroups.Items.Add(li);
            }
        }
        if (ddpatron.SelectedValue == "All Staff")
        {
            da = new DataAccess();
            ds = new DataSet();
            strsql = "select intid,strfirstname+' '+strmiddlename+' '+strlastname as staffname from tblemployee where intschool=" + Session["SchoolID"].ToString() + " and strtype='Teaching Staff' or strtype='Non Teaching Staff'";
            ds = da.ExceuteSql(strsql);
            chkgroups.Items.Clear();
            ListItem li;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                li = new ListItem(ds.Tables[0].Rows[i]["staffname"].ToString(), ds.Tables[0].Rows[i]["intid"].ToString());
                chkgroups.Items.Add(li);
            }
        }
    }
   // when Save Button click
    protected void btnsave_Click(object sender, EventArgs e)
    {
        string str = "";
        for (int i = 0; i < chkgroups.Items.Count; i++)
        {
            if (chkgroups.Items[i].Selected == true)
            {
                if (str.Length == 0)
                {
                    str = chkgroups.Items[i].Value.ToString();
                }
                else
                {
                    str = str + "," + chkgroups.Items[i].Value.ToString();
                }
            }
        }
        try
        {
            SqlCommand command;
            SqlParameter OutPutParam;
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
            conn.Open();
            command = new SqlCommand("SPsmsschedule", conn);
            command.CommandType = CommandType.StoredProcedure;
            OutPutParam = command.Parameters.Add("@rc", SqlDbType.Int);
            OutPutParam.Direction = ParameterDirection.Output;
            if (btnsave.Text == "Save")
            {
                command.Parameters.Add("@intid", "0");
            }
            else
            {
                command.Parameters.Add("@intid", Session["Editid"].ToString());
            }
            command.Parameters.Add("@intsmscategoryid", Session["categoryID"].ToString());
            command.Parameters.Add("@intmessageid", Session["smstemplateid"].ToString());
            command.Parameters.Add("@strscheduledtime", txtscheduletime.Text.Trim());
            command.Parameters.Add("@strpatron", ddpatron.SelectedValue);
            command.Parameters.Add("@strpatronlist", str);
            command.Parameters.Add("@intschool", Session["SchoolID"].ToString());
            command.ExecuteNonQuery();
            if ((int)(command.Parameters["@rc"].Value) == 0)
            {
                msgbox.alert("Oops! already Exist");
            }
            conn.Close();
            ddpatron.SelectedValue = "-Select-";
            chkgroups.Items.Clear();
            txtscheduletime.Text = "";
            filldgsmsschedule();
            btnsave.Text = "Save";
            filldgsmsschedule();
        }
        catch
        {
            
        }
    }
    protected void filldgsmsschedule()
    {
        da = new DataAccess();
        ds = new DataSet();
        ds1 = new DataSet();
        strsql = "select a.intid,b.strcategory,c.strtemplatename,a.strscheduledtime,a.strpatron from tblsmsschedule a, tblsmscategory b, tblsmstemplate c where a.intschool= " + Session["SchoolID"].ToString() + " and  a.intsmscategoryid=b.intid and a.intmessageid = c.intid";
        ds = da.ExceuteSql(strsql);
        dgsmsSchedule.DataSource = ds;
        dgsmsSchedule.DataBind();
    }

    // for check all checkbox Start here 
    protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkSelectAll = sender as CheckBox;
        foreach (DataGridItem gvr in dgsmsSchedule.Items)
        {
            CheckBox chkSelect = gvr.FindControl("chkselect") as CheckBox;
            if (chkSelect != null)
            {
                chkSelect.Checked = chkSelectAll.Checked;
            }
        }
    }

    protected void deleteall()
    {
        DataAccess da = new DataAccess();
        string str;
        for (int i = 1; i <= dgsmsSchedule.Items.Count; i++)
        {
            DataGridItem dgi = dgsmsSchedule.Items[i - 1];
            CheckBox ch = (CheckBox)dgi.Cells[i - 1].FindControl("chkselect");
            if (ch.Checked == true)
            {
                str = "delete tblsmsschedule where intschool=" + Session["SchoolID"].ToString() + " and intid=" + dgi.Cells[0].Text;
                Functions.UserLogs(Session["UserID"].ToString(), "tblsmsschedule", dgi.Cells[0].Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 217);

                da.ExceuteSqlQuery(str);
            }
            else
            {
                msgbox.alert("Please Select atleast one record to delete");
            }
        }
        filldgsmsschedule();
    }
    protected void btndelall_Click(object sender, EventArgs e)
    {
        deleteall();
    }
    // for check all checkbox End here 

    protected void dgsmsSchedule_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["Editid"] = e.Item.Cells[0].Text;
        da = new DataAccess();
        DataSet ds1 = new DataSet();
        strsql = "select * from tblsmsschedule where intschool = '" + Session["SchoolID"].ToString() + "' and intid = '" + Session["Editid"] + "'";
        ds1 = da.ExceuteSql(strsql);
        Session["categoryID"] = ds1.Tables[0].Rows[0]["intsmscategoryid"].ToString();
        filltemplate();
        Session["smstemplateid"] = ds1.Tables[0].Rows[0]["intmessageid"].ToString();
        fillmessages();
        ddpatron.SelectedValue=ds1.Tables[0].Rows[0]["strpatron"].ToString();
        if (ddpatron.SelectedValue == "Student")
        {
            da = new DataAccess();
            DataSet ds2 = new DataSet();
            strsql = "select strstandard,strsection, strstandard +' - '+strsection as stdandsec from tblstandard_section_subject where intschoolid =" + Session["SchoolID"].ToString() + " group by strstandard, strsection";
            ds2 = da.ExceuteSql(strsql);
            chkgroups.Items.Clear();
            ListItem li;
            for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
            {
                li = new ListItem(ds2.Tables[0].Rows[i]["stdandsec"].ToString(), ds2.Tables[0].Rows[i]["stdandsec"].ToString());
                chkgroups.Items.Add(li);
            }
            string[] patronlist = (ds1.Tables[0].Rows[0]["strpatronlist"].ToString()).Split(',');
            string staffid = "";
            for (int j = 0; j < patronlist.Length; j++)
            {
                staffid = patronlist[j].Trim();
                chkgroups.Items[j].Selected = true;
            }
        }

        if (ddpatron.SelectedValue == "Teaching Staff")
        {
            da = new DataAccess();
            DataSet ds2 = new DataSet();
            strsql = "select intid,strfirstname+' '+strmiddlename+' '+strlastname as staffname from tblemployee where intschool=" + Session["SchoolID"].ToString() + " and strtype='Teaching Staff'";
            ds2 = da.ExceuteSql(strsql);
            chkgroups.Items.Clear();
            ListItem li;
            for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
            {
                li = new ListItem(ds2.Tables[0].Rows[i]["staffname"].ToString(), ds2.Tables[0].Rows[i]["intid"].ToString());
                chkgroups.Items.Add(li);
            }
            string[] patronlist = (ds1.Tables[0].Rows[0]["strpatronlist"].ToString()).Split(',');
            int staffid = 0;
            for (int j = 0; j < patronlist.Length; j++)
            {
                staffid = int.Parse(patronlist[j].Trim());
                chkgroups.Items[j].Selected = true;
            }
        }
        if (ddpatron.SelectedValue == "Non Teaching Staff")
        {
            da = new DataAccess();
            DataSet ds2 = new DataSet();
            strsql = "select intid,strfirstname+' '+strmiddlename+' '+strlastname as staffname from tblemployee where intschool=" + Session["SchoolID"].ToString() + " and strtype='Non Teaching Staff'";
            ds2 = da.ExceuteSql(strsql);
            chkgroups.Items.Clear();
            ListItem li;
            for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
            {
                li = new ListItem(ds2.Tables[0].Rows[i]["staffname"].ToString(), ds2.Tables[0].Rows[i]["intid"].ToString());
                chkgroups.Items.Add(li);
            }
            string[] patronlist = (ds1.Tables[0].Rows[0]["strpatronlist"].ToString()).Split(',');
            int staffid = 0;
            for (int j = 0; j < patronlist.Length; j++)
            {
                staffid = int.Parse(patronlist[j].Trim());
                chkgroups.Items[j].Selected = true;
            }
        }
        if (ddpatron.SelectedValue == "All Staff")
        {
            da = new DataAccess();
            DataSet ds2 = new DataSet();
            strsql = "select intid,strfirstname+' '+strmiddlename+' '+strlastname as staffname from tblemployee where intschool=" + Session["SchoolID"].ToString() + " and strtype='Teaching Staff' or strtype='Non Teaching Staff'";
            ds2 = da.ExceuteSql(strsql);
            chkgroups.Items.Clear();
            ListItem li;
            for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
            {
                li = new ListItem(ds2.Tables[0].Rows[i]["staffname"].ToString(), ds2.Tables[0].Rows[i]["intid"].ToString());
                chkgroups.Items.Add(li);
            }
            string[] patronlist = (ds1.Tables[0].Rows[0]["strpatronlist"].ToString()).Split(',');
            int staffid = 0;
            for (int j = 0; j < patronlist.Length; j++)
            {
                staffid = int.Parse(patronlist[j].Trim());
                chkgroups.Items[j].Selected = true;
            }
        }
        txtscheduletime.Text=ds1.Tables[0].Rows[0]["strscheduledtime"].ToString();
        btnsave.Text = "Update";
    }
    //protected void dgsmsSchedule_DeleteCommand(object source, DataGridCommandEventArgs e)
    //{
    //    DataAccess da = new DataAccess();
    //    string sql = "delete from tblsmsschedule where intid=" + e.Item.Cells[0].Text;
    //    da.ExceuteSqlQuery(sql);
    //    filldgsmsschedule();
    //}
    protected void btndelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton delete = (ImageButton)sender;
        TableCell cell = delete.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        DataAccess da = new DataAccess();
        string sql = "delete from tblsmsschedule where intid=" + item.Cells[0].Text;
        Functions.UserLogs(Session["UserID"].ToString(), "tblsmsschedule", item.Cells[0].Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 217);

        da.ExceuteSqlQuery(sql);
        filldgsmsschedule();
    }
}
