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

public partial class communication_compose_message : System.Web.UI.Page
{

    public string strsql;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
            fillstandard();
            ddlsection.Items.Insert(0,"-Select-");
            //filldepartment();
            ddldesig.Items.Insert(0,"-Select-");
            if (ddlpatron.SelectedValue == "Student")
            {
                trdept.Visible = false;
                trdesig.Visible = false;
                trstandard.Visible = true;
                trsection.Visible = true;
            }
            if (ddlpatron.SelectedValue == "Employee")
            {
                trdept.Visible = true;
                trdesig.Visible = true;
                trstandard.Visible = false;
                trsection.Visible = false;
            }
        }
    }
    protected void ddlpatron_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlpatron.SelectedValue == "Student")
        {
            trdept.Visible = false;
            trdesig.Visible = false;
            trstandard.Visible = true;
            trsection.Visible = true;
            chkgroups.Items.Clear();
        }
        if (ddlpatron.SelectedValue == "Teaching Staffs" || ddlpatron.SelectedValue == "Non Teaching Staff" || ddlpatron.SelectedValue == "Admin")
        {
            trdept.Visible = true;
            trdesig.Visible = true;
            trstandard.Visible = false;
            trsection.Visible = false;
            chkgroups.Items.Clear();
            filldepartment();
        }
    }
    protected void fillstandard()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        string sql = "select * from tblschoolstandard where intschoolid=" + Session["SchoolID"].ToString();
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlstd.DataSource = ds;
        ddlstd.DataTextField = "strstandard";
        ddlstd.DataValueField = "strstandard";
        ddlstd.DataBind();
        ddlstd.Items.Insert(0, "-Select-");
        ddlstd.Items.Insert(1, "All");
        chkgroups.Items.Clear();
    }
    protected void fillsection()
    {
        if (ddlstd.SelectedIndex > 1)
        {
            string strsql = "";
            strsql = "select strsection from tblstandard_section_subject where intschoolid=" + Session["SchoolID"].ToString() + " and strstandard='" + ddlstd.SelectedValue + "' group by strsection";
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            ds = da.ExceuteSql(strsql);
            ddlsection.DataSource = ds;
            ddlsection.DataTextField = "strsection";
            ddlsection.DataValueField = "strsection";
            ddlsection.DataBind();
            ddlsection.Items.Insert(0, "-Select-");
            ddlsection.Items.Insert(1, "All");
            chkgroups.Items.Clear();
        }
        if (ddlstd.SelectedIndex == 0)
        {
            ddlsection.Items.Clear();
            ddlsection.Items.Insert(0, "-Select-");
        }
            if(ddlstd.SelectedValue == "All")
            {
                chkgroups.Items.Clear();
                ddlsection.Items.Clear();
                ddlsection.Items.Insert(0, "All");
            }
        
    }
    protected void ddlstd_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlsection.Items.Clear();
        fillsection();
        chkgroups.Items.Clear();
        if(ddlstd.SelectedValue == "All")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            strsql = "select intid, strfirstname+' '+strmiddlename+' '+strlastname as receivername from tblstudent where intschool = " + Session["SchoolID"] ;
            ds = da.ExceuteSql(strsql);
            chkgroups.Items.Clear();
            ListItem li;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                li = new ListItem(ds.Tables[0].Rows[i]["receivername"].ToString(), ds.Tables[0].Rows[i]["intid"].ToString());
                chkgroups.Items.Add(li);
            }
        }
    }
    protected void ddlsection_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlpatron.SelectedValue=="Student")
        {
            if (ddlstd.SelectedIndex > 1)
            {
                if(ddlsection.SelectedIndex > 1)
                {
                    DataAccess da = new DataAccess();
                    DataSet ds = new DataSet();
                    strsql = "select intid, strfirstname+' '+strmiddlename+' '+strlastname as receivername from tblstudent where intschool = " + Session["SchoolID"] + " and strstandard='" + ddlstd.SelectedValue + "' and strsection = '" + ddlsection.SelectedValue + "'";
                    ds = da.ExceuteSql(strsql);
                    chkgroups.Items.Clear();
                    ListItem li;
                    for (int i = 0; i < ds.Tables[0].Rows.Count;i++ )
                    {
                        li = new ListItem(ds.Tables[0].Rows[i]["receivername"].ToString(), ds.Tables[0].Rows[i]["intid"].ToString());
                        chkgroups.Items.Add(li);
                    }
                }
                if (ddlsection.SelectedValue == "All")
                {
                    DataAccess da = new DataAccess();
                    DataSet ds = new DataSet();
                    strsql = "select intid, strfirstname+' '+strmiddlename+' '+strlastname as receivername from tblstudent where intschool = " + Session["SchoolID"] +"  and strstandard='" + ddlstd.SelectedValue + "'";
                    ds = da.ExceuteSql(strsql);
                    chkgroups.Items.Clear();
                    ListItem li;
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        li = new ListItem(ds.Tables[0].Rows[i]["receivername"].ToString(), ds.Tables[0].Rows[i]["intid"].ToString());
                        chkgroups.Items.Add(li);
                    }

                }
            }
        }
    }
    protected void filldepartment()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        strsql = "select a.intdepartment,b.strdepartmentname from tblemployee a,tbldepartment b where a.intdepartment=b.intid and a.strtype='" + ddlpatron.SelectedValue + "' and b.intschool = " + Session["SchoolID"].ToString() +" group by a.intdepartment,b.strdepartmentname";
        ds = da.ExceuteSql(strsql);
        ddldept.DataSource = ds;
        ddldept.DataTextField = "strdepartmentname";
        ddldept.DataValueField = "intdepartment";
        ddldept.DataBind();
        ddldept.Items.Insert(0,"-Select-");
        ddldept.Items.Insert(1,"All");
    }
    protected void filldesignation()
    {
        if (ddldept.SelectedIndex > 1)
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            strsql = "select a.intdesignation,b.strdesignation from tblemployee a,tbldesignation b where a.intdesignation=b.intid and a.strtype='" + ddlpatron.SelectedValue + "' and b.intschool = " + Session["SchoolID"].ToString()+" group by a.intdesignation,b.strdesignation";
            ds = da.ExceuteSql(strsql);
            ddldesig.DataSource = ds;
            ddldesig.DataTextField = "strdesignation";
            ddldesig.DataValueField = "intdesignation";
            ddldesig.DataBind();
            ddldesig.Items.Insert(0, "-Select-");
            ddldesig.Items.Insert(1, "All");
            chkgroups.Items.Clear();
        }
        if (ddldept.SelectedIndex == 0)
        {
            ddldesig.Items.Clear();
            chkgroups.Items.Clear();
            ddldesig.Items.Insert(0, "-Select-");
        }
        if(ddldept.SelectedValue == "All")
        {
            ddldesig.Items.Clear();
            chkgroups.Items.Clear();
            ddldesig.Items.Insert(0,"All");
        }
    }
    protected void ddldept_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddldesig.Items.Clear();
        filldesignation();
        chkgroups.Items.Clear();
        if(ddldept.SelectedValue == "All")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            strsql = "select intid, strfirstname+' '+strmiddlename+' '+strlastname as receivername from tblemployee where intschool = " + Session["SchoolID"] ;
            ds = da.ExceuteSql(strsql);
            chkgroups.Items.Clear();
            ListItem li;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                li = new ListItem(ds.Tables[0].Rows[i]["receivername"].ToString(), ds.Tables[0].Rows[i]["intid"].ToString());
                chkgroups.Items.Add(li);
            }
        }

    }
    protected void ddldesig_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((ddlpatron.SelectedValue == "Teaching Staffs" || ddlpatron.SelectedValue == "Non Teaching Staff" || ddlpatron.SelectedValue == "Admin"))
        {
            if (ddldept.SelectedIndex > 1)
            {
                if (ddldesig.SelectedIndex > 1)
                {
                    DataAccess da = new DataAccess();
                    DataSet ds = new DataSet();
                    strsql = "select intid, strfirstname+' '+strmiddlename+' '+strlastname as receivername from tblemployee where intschool = " + Session["SchoolID"] + " and intDepartment='" + ddldept.SelectedValue + "' and intDesignation = '" + ddldesig.SelectedValue + "'";
                    ds = da.ExceuteSql(strsql);
                    chkgroups.Items.Clear();
                    ListItem li;
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        li = new ListItem(ds.Tables[0].Rows[i]["receivername"].ToString(), ds.Tables[0].Rows[i]["intid"].ToString());
                        chkgroups.Items.Add(li);
                    }
                }
                if (ddldesig.SelectedValue == "All")
                {
                    DataAccess da = new DataAccess();
                    DataSet ds = new DataSet();
                    strsql = "select intid, strfirstname+' '+strmiddlename+' '+strlastname as receivername from tblemployee where intschool = " + Session["SchoolID"] + " and intDepartment='" + ddldept.SelectedValue + "'";
                    ds = da.ExceuteSql(strsql);
                    chkgroups.Items.Clear();
                    ListItem li;
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        li = new ListItem(ds.Tables[0].Rows[i]["receivername"].ToString(), ds.Tables[0].Rows[i]["intid"].ToString());
                        chkgroups.Items.Add(li);
                    }
                }
            }
        }
    }

    protected void btnsend_Click(object sender, EventArgs e)
    {
        string dtdate = DateTime.Now.ToString();
        string str = ",,";
        for (int i = 0; i < chkgroups.Items.Count; i++)
        {
            if (chkgroups.Items[i].Selected == true)
            {
                //if (str.Length == 0)
                //{
                    str = chkgroups.Items[i].Value.ToString();
                    //}
                    //else
                    //{
                    //    str = str + "," + chkgroups.Items[i].Value.ToString();
                    //}

                    SqlCommand command;
                    SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
                    conn.Open();
                    command = new SqlCommand("SPmailbox", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    if (btnsend.Text == "Send Mail")
                    {
                        command.Parameters.Add("@intid", "0");
                    }
                    command.Parameters.Add("@intschool", Session["SchoolID"].ToString());
                    command.Parameters.Add("@intsenderid", Session["UserID"].ToString());
                    command.Parameters.Add("@intreceiverid", str);
                    command.Parameters.Add("@strsubject", txtsubject.Text.Trim());
                    command.Parameters.Add("@strmessage", txtmessage.Content.Trim());
                    command.Parameters.Add("@intviewed", "0");
                    command.Parameters.Add("@strpatrontype", ddlpatron.SelectedValue);
                    command.Parameters.Add("@strsenderpatrontype", Session["PatronType"].ToString());
                    command.Parameters.Add("@dtdate", dtdate);
                    command.ExecuteNonQuery();
                    conn.Close();
                //}
            }
        }
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Message send')", true);
    }
   
}
