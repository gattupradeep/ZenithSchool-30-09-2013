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

public partial class attendance_staffattendance : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public SqlCommand cmd;
    public DataAccess da;
    public DataSet ds;
    public string strsql;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillstafftype();
            fillday();
            fillyear();
            ddlmonth2.SelectedValue = DateTime.Now.Month.ToString();
            ddlday2.SelectedValue = DateTime.Now.Day.ToString();
            ddlyear2.SelectedValue = DateTime.Now.Year.ToString();
        }
    }

    protected void fillstafftype()
    {
        DataAccess da = new DataAccess();
        string sql = "select strtype from tblemployee where intschool= '" + Session["SchoolID"].ToString() + "' group by strtype ";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        ddlstafftype.DataSource = ds;
        ddlstafftype.DataTextField = "strtype";
        ddlstafftype.DataValueField = "strtype";
        ddlstafftype.DataBind();
        ListItem list = new ListItem("-select-", "0");
        ddlstafftype.Items.Insert(0, list);
    }

    protected void fillday()
    {
        int j = 0;
        for (int i = 1; i < 32; i++)
        {
            ListItem li;
            li = new ListItem(i.ToString(), i.ToString());
            ddlday2.Items.Insert(j, li);
            j++;
        }
    }
    protected void fillyear()
    {
        int j = 0;
        for (int i = DateTime.Now.Year - 1; i <= DateTime.Now.Year; i++)
        {
            ListItem li;
            li = new ListItem(i.ToString(), i.ToString());
            ddlyear2.Items.Insert(j, li);
            j++;
        }
    }

    protected void fillstudent()
    {
        if (DateTime.Parse(ddlmonth2.SelectedValue + "/" + ddlday2.SelectedValue + "/" + ddlyear2.SelectedValue) <= DateTime.Today)
            //if (DateTime.Parse(ddlday2.SelectedValue + "/" + ddlmonth2.SelectedValue + "/" + ddlyear2.SelectedValue) <= DateTime.Today)
            {
            if (ddlstafftype.SelectedIndex > 0)
            {
                btnsave.Text = "Save";
                da = new DataAccess();
                strsql = "select strfirstname + ' ' + strmiddlename + ' ' + strlastname as staffname,a.intid,strdesignation from tblemployee a, tbldesignation b where a.intdesignation=b.intid and a.strtype='" + ddlstafftype.SelectedValue + "' and a.intschool=" + Session["SchoolID"].ToString();
                DataSet ds = new DataSet();
                ds = da.ExceuteSql(strsql);
                dgstudentattend.DataSource = ds;
                dgstudentattend.DataBind();
                trgrid.Visible = true;
                trbutton.Visible = true;
            }
            else
            {
                trgrid.Visible = false;
                trbutton.Visible = false;
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Attendance Can Be Assigned Only For Current And Previous Dates')", true);
            ddlmonth2.SelectedValue = DateTime.Now.Month.ToString();
            ddlday2.SelectedValue = DateTime.Now.Day.ToString();
            ddlyear2.SelectedValue = DateTime.Now.Year.ToString();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int err = 0;
        try
        {
            DateTime sdt = DateTime.Parse(ddlmonth2.SelectedValue + "/" + ddlday2.SelectedValue + "/" + ddlyear2.SelectedValue);
        }
        catch
        {
            err = 1;
        }
        if (err == 0)
        {
            if (ddlstafftype.SelectedIndex > 0)
            {
                DataSet ds2 = new DataSet();
                DataAccess da2 = new DataAccess();
                string strsql = "select intid from tblstaffattendance where dtdate='" + ddlmonth2.SelectedValue + "/" + ddlday2.SelectedValue + "/" + ddlyear2.SelectedValue + "' and strtype='" + ddlstafftype.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + "";
                ds2 = da2.ExceuteSql(strsql);
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                    {
                        Functions.UserLogs(Session["UserID"].ToString(), "tblstaffattendance", ds2.Tables[0].Rows[i]["intid"].ToString(), "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),56);
                    }
                }
                da = new DataAccess();
                string str = "delete tblstaffattendance where dtdate='" + ddlmonth2.SelectedValue + "/" + ddlday2.SelectedValue + "/" + ddlyear2.SelectedValue + "' and strtype='" + ddlstafftype.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + "";
                da.ExceuteSqlQuery(str);
                foreach (DataGridItem dgit in dgstudentattend.Items)
                {
                    DataRowView drd = (DataRowView)dgit.DataItem;
                    RadioButton rbtnpresent = (RadioButton)dgit.FindControl("rbtnpresent");
                    RadioButton rbtnabsent = (RadioButton)dgit.FindControl("rbtnabsent");
                    TextBox txtreason = (TextBox)dgit.FindControl("txtreason");
                    DropDownList ddlsession = (DropDownList)dgit.FindControl("ddlseasion");
                    DropDownList ddlleavetype = (DropDownList)dgit.FindControl("ddlleavetype");
                    if (rbtnabsent.Checked)
                    {
                        SqlCommand RegCommand;
                        SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
                        Conn.Open();
                        RegCommand = new SqlCommand("spstaffattendance", Conn);
                        RegCommand.CommandType = CommandType.StoredProcedure;
                        RegCommand.Parameters.Add("@intID", "0");
                        RegCommand.Parameters.Add("@intschool", Session["SchoolID"].ToString());
                        RegCommand.Parameters.Add("@intstaff", dgit.Cells[0].Text);
                        RegCommand.Parameters.Add("@strtype", ddlstafftype.SelectedValue);
                        RegCommand.Parameters.Add("@dtdate", ddlmonth2.SelectedValue + "/" + ddlday2.SelectedValue + "/" + ddlyear2.SelectedValue);
                        RegCommand.Parameters.Add("@strsession", ddlsession.SelectedValue);
                        RegCommand.Parameters.Add("@intleavetype", ddlleavetype.SelectedValue);
                        RegCommand.Parameters.Add("@strreason", txtreason.Text.Trim());
                        RegCommand.ExecuteNonQuery();
                        Conn.Close();
                        
                    }
                }
                //Response.Redirect("staffattendance.aspx");
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "redirect script", "alert('Details Saved Successfully!'); location.href='staffattendance.aspx';", true);
            }
            else
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please Select Class!')", true);
        }
        else
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Invalid Date')", true);

    }


    protected void dgstudentattend_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        try
        {
            DropDownList ddlsession = (DropDownList)e.Item.FindControl("ddlseasion");
            DropDownList ddlleavetype = (DropDownList)e.Item.FindControl("ddlleavetype");
            RadioButton rbtnpresent = (RadioButton)e.Item.FindControl("rbtnpresent");
            RadioButton rbtnabsent = (RadioButton)e.Item.FindControl("rbtnabsent");
            TextBox txtreason = (TextBox)e.Item.FindControl("txtreason");
            DataRowView dr = (DataRowView)e.Item.DataItem;

            da = new DataAccess();
            strsql = "select * from tblstaffattendance where strtype='" + ddlstafftype.SelectedValue + "' and dtdate='" + ddlmonth2.SelectedValue + "/" + ddlday2.SelectedValue + "/" + ddlyear2.SelectedValue + "' and intstaff=" + dr["intid"].ToString();
            ds = new DataSet();
            ds = da.ExceuteSql(strsql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlsession.SelectedValue = ds.Tables[0].Rows[0]["strsession"].ToString();
                ddlleavetype.SelectedValue = ds.Tables[0].Rows[0]["intleavetype"].ToString();
                txtreason.Text = ds.Tables[0].Rows[0]["strreason"].ToString();
                rbtnabsent.Checked = true;
                rbtnpresent.Checked = false;
                btnsave.Text = "Update";
            }
            else
            {
                rbtnabsent.Checked = false;
                rbtnpresent.Checked = true;
            }

            strsql = "";
            strsql = strsql + "select * from (select c.intid,c.strleavetype,intnoofdays-ct as avail,intnoofdays from tblassignstaffleave a, ";
            strsql = strsql + "(select intstaff,intleavetype,sum(ct) as ct from ";
            strsql = strsql + "(select intstaff,intleavetype,count(*) as ct from tblstaffattendance ";
            strsql = strsql + "where intstaff=" + dr["intid"].ToString() + " and strsession='Full Day' and intschool=" + Session["SchoolID"].ToString() + " ";
            strsql = strsql + " group by intstaff,intleavetype ";
            strsql = strsql + "union all ";
            strsql = strsql + "select intstaff,intleavetype,count(*)*.5 as ct from tblstaffattendance ";
            strsql = strsql + "where intstaff=" + dr["intid"].ToString() + " and strsession like 'Half Day%' and intschool=" + Session["SchoolID"].ToString() + " ";
            strsql = strsql + "group by intstaff,intleavetype) as a ";
            strsql = strsql + "group by intstaff,intleavetype) as b,tblschoolleavecategory c ";
            strsql = strsql + "where a.intstaffid=b.intstaff and a.intleavecategory=b.intleavetype and a.intleavecategory=c.intid ";
            strsql = strsql + "and a.intschool=" + Session["SchoolID"].ToString() + " ";
            strsql = strsql + "union all ";
            strsql = strsql + "select b.intid,b.strleavetype,intnoofdays as avail,intnoofdays ";
            strsql = strsql + "from tblassignstaffleave a, tblschoolleavecategory b where ";
            strsql = strsql + "a.intleavecategory=b.intid and a.intschool=" + Session["SchoolID"].ToString() + " and a.intstaffid=" + dr["intid"].ToString() + " ";
            strsql = strsql + "and b.intid not in( ";
            strsql = strsql + "select intleavetype from tblstaffleaves a, tblleaverequest b ";
            strsql = strsql + "where a.intleaverequest=b.intid and b.intstaff=" + dr["intid"].ToString() + " and b.intschool=" + Session["SchoolID"].ToString() + " group by intleavetype)) as d1 where avail>0 ";
            da = new DataAccess();
            ds = new DataSet();
            ds = da.ExceuteSql(strsql);
            ddlleavetype.DataSource = ds;
            ddlleavetype.DataTextField = "strleavetype";
            ddlleavetype.DataValueField = "intid";
            ddlleavetype.DataBind();
            ListItem li = new ListItem("-Select-", "-1");
            ddlleavetype.Items.Insert(0, li);
            li = new ListItem("Paid Leave", "0");
            ddlleavetype.Items.Add(li);
        }
        catch { }
    }
    protected void ddlday2_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillstudent();
    }
    protected void ddlmonth2_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillstudent();

    }
    protected void ddlyear2_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillstudent();
    }
    protected void ddlstafftype_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillstudent();
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("staffattendance.aspx");
    }
}
