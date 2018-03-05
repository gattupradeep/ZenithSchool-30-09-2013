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

public partial class admin_School_Syllabus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillstandard();
            ddlsubject.Items.Insert(0, "-Select-");
            ddlunitno.Items.Insert(0, "-Select-");
            btnaddlesson.Visible = false;
            if (Request["text"] != null)
            {
                ddlstandard.SelectedValue = Session["std"].ToString();
                fillsubject();
                datagridedit();
                btnaddlesson.Visible = false;
            }
            if (Request["stand"] != null)
            {
                ddlstandard.SelectedValue = Session["stand"].ToString();
                
                fillsubject();
                subgridedit();
                btnaddlesson.Visible = false;
            }
        }
    }

    protected void datagridedit()
    {
        hiddentxtlessonname.Text = "";
        string strsql="";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        strsql = "select strstandard,strsubject,strunitname,strtextbook,strauthor,intunits,strunitno from dbo.tblschoolsyllabus where intschool=" + Session["SchoolID"].ToString() + " and strstandard='" + Session["std"].ToString() + "' and strsubject='" + Session["sub"].ToString() + "' and strtextbook='" + Session["text"].ToString() + "' group by strstandard,strsubject,strtextbook,strauthor,intunits,strunitno,strunitname";        
        ds = da.ExceuteSql(strsql);
        txttextbookname.Text = ds.Tables[0].Rows[0]["strtextbook"].ToString();
        txtauthor.Text = ds.Tables[0].Rows[0]["strauthor"].ToString();
        ddlnumberofunits.SelectedValue = ds.Tables[0].Rows[0]["intunits"].ToString();
        ddlsubject.SelectedValue = ds.Tables[0].Rows[0]["strsubject"].ToString();
        ddlstandard.SelectedValue = ds.Tables[0].Rows[0]["strstandard"].ToString();
        lessontag.Visible = false;
        btnaddlesson.Visible = true;
        fillunitno();
        ddlunitno.SelectedValue = ds.Tables[0].Rows[0]["strunitno"].ToString();
        txtunitname.Text = ds.Tables[0].Rows[0]["strunitname"].ToString();
        Btnadd.Text = "update";
        datagrid.DataSource = ds;
        datagrid.DataBind();
        datagrid.Visible = true;
        dgsyllabus.Visible = false;
    }
    protected void subgridedit()
    {
        hiddentxtlessonname.Text = "";
        string strsql = "";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        strsql = "select strstandard,strsubject,strtextbook,strauthor,strunitno+' - '+strunitname as unit,'' as strlessonName,strunitno,strunitname,intunits from dbo.tblschoolsyllabus where intschool=" + Session["SchoolID"].ToString() + " and strstandard='" + Session["stand"].ToString() + "' and strsubject='" + Session["subj"].ToString() + "' and strtextbook='" + Session["txt"].ToString() + "' and strunitno='" + Session["unit"].ToString() + "' group by strstandard,strsubject,strtextbook,strauthor,strunitno,strunitname,intunits";
        ds = da.ExceuteSql(strsql);
        ddlstandard.SelectedValue = ds.Tables[0].Rows[0]["strstandard"].ToString();
        ddlsubject.SelectedValue = ds.Tables[0].Rows[0]["strsubject"].ToString();
        txttextbookname.Text = ds.Tables[0].Rows[0]["strtextbook"].ToString();
        txtauthor.Text = ds.Tables[0].Rows[0]["strauthor"].ToString();
        ddlnumberofunits.SelectedValue = ds.Tables[0].Rows[0]["intunits"].ToString();
        //txtlessonName.Text = ds.Tables[0].Rows[0]["strlessonName"].ToString();
        //hiddentxtlessonname.Text = ds.Tables[0].Rows[0]["strlessonName"].ToString(); 
        txtunitname.Text = ds.Tables[0].Rows[0]["strunitname"].ToString();
        lessontag.Visible = false;
        btnaddlesson.Visible = false;
        Btnadd.Text = "update";        
        datagrid.Visible = false;
        dgsyllabus.DataSource = ds;
        dgsyllabus.DataBind();
        dgsyllabus.Visible = true;
        strsql = "select intunits,strunitno from dbo.tblschoolsyllabus where intschool=" + Session["SchoolID"].ToString() + " and strstandard='" + Session["stand"].ToString() + "' and strsubject='" + Session["subj"].ToString() + "' and strtextbook='" + Session["txt"].ToString() + "' and strunitno='" + Session["unit"].ToString() + "' group by intunits,strunitno";
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddlnumberofunits.SelectedValue = ds.Tables[0].Rows[0]["intunits"].ToString();
        fillunitno();
        ddlunitno.SelectedValue = ds.Tables[0].Rows[0]["strunitno"].ToString();
    }
    private void fillstandard()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        string sql = "select strstandard,strsection from tblstandard_section_subject where intschoolid=" + Session["SchoolID"].ToString()+" group by strstandard,strsection";
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ListItem li;
        for (int i = 0; i <= ds.Tables[0].Rows.Count; i++)
        {
            if (i == 0)
                li = new ListItem("-Select-", "0");
            else
                li = new ListItem(ds.Tables[0].Rows[i - 1]["strstandard"].ToString() + " - " + ds.Tables[0].Rows[i - 1]["strsection"].ToString(), ds.Tables[0].Rows[i - 1]["strstandard"].ToString()+" - "+ ds.Tables[0].Rows[i - 1]["strsection"].ToString());

            ddlstandard.Items.Add(li);
        }
    }
    private void fillsubject()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        //string sql = "select strstandard+' - '+strsection as class, strsubject from tblstandard_section_subject where intschool=" + Session["SchoolID"].ToString() + " and strstandard+' - '+strsection ='" + ddlstandard.SelectedValue + "' group by strstandard+' - '+strsection,strsubject";
        string sql = "select strsubject from (select strstandard+' - '+strsection as class, strsubject from tblstandard_section_subject where";
        sql += " intschoolid=" + Session["SchoolID"].ToString() + " and strsubject !='Second Language' and strsubject!='Third language' and strstandard+' - '+strsection ='" + ddlstandard.SelectedValue + "' group by strstandard+' - '+strsection,strsubject";
        sql += " UNION ALL select strstandard+' - '+strsection as class,strsecondlanguage as strsubject from tblstudent where intschool=" + Session["SchoolID"].ToString() + " and strstandard+' - '+strsection = '" + ddlstandard.SelectedValue + "' and strsecondlanguage !=''";
        sql += "  group by strsecondlanguage,strstandard+' - '+strsection UNION ALL";
        sql += " select strstandard+' - '+strsection as class,strthirdlanguage as strsubject from tblstudent where intschool=" + Session["SchoolID"].ToString() + " and strstandard+' - '+strsection = '" + ddlstandard.SelectedValue + "' and strthirdlanguage !=''";
        sql += " group by strthirdlanguage,strstandard+' - '+strsection) a group by strsubject";
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ListItem li;
        ddlsubject.Items.Clear();
        for (int i = 0; i <= ds.Tables[0].Rows.Count; i++)
        {
            if (i == 0)
                li = new ListItem("-Select-", "0");
            else
                li = new ListItem(ds.Tables[0].Rows[i - 1]["strsubject"].ToString(), ds.Tables[0].Rows[i - 1]["strsubject"].ToString());

            ddlsubject.Items.Add(li);
        }
    }
    protected void fillunitno()
    {
        ListItem li;
        ddlunitno.Items.Clear();
        for (int i = 0; i <= int.Parse(ddlnumberofunits.SelectedValue); i++)
        {
            if (i == 0)
                li = new ListItem("--select--", i.ToString());
            else
                li = new ListItem("Unit" + i.ToString(), "Unit" + i.ToString());
            ddlunitno.Items.Add(li);
        }
        ddlunitno.Items.Insert(1, "Overview");
    }
    protected void filldatagrid()
    {
        string strsql = "";
        if (ddlstandard.SelectedIndex > 0 && ddlsubject.SelectedIndex > 0)
            strsql = "select strstandard,strsubject,strunitname,strunitno,strtextbook,strauthor,intunits from dbo.tblschoolsyllabus where strstandard='" + ddlstandard.SelectedValue + "'and strsubject='" + ddlsubject.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + "group by strstandard,strsubject,strtextbook,strauthor,intunits,strunitname,strunitno";
        else if (ddlstandard.SelectedIndex > 0)
            strsql = "select strstandard,strsubject,strunitname,strunitno,strtextbook,strauthor,intunits from dbo.tblschoolsyllabus where strstandard='" + ddlstandard.SelectedValue + "'and intschool=" + Session["SchoolID"].ToString() + "group by strstandard,strsubject,strtextbook,strauthor,intunits,strunitname,strunitno";
        else if(ddlsubject.SelectedIndex>0)
            strsql = "select strstandard,strsubject,strunitname,strunitno,strtextbook,strauthor,intunits from dbo.tblschoolsyllabus where strsubject='" + ddlsubject.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + "group by strstandard,strsubject,strtextbook,strauthor,intunits,strunitname,strunitno";
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            ds = da.ExceuteSql(strsql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                datagrid.DataSource = ds;
                datagrid.DataBind();
                dgsyllabus.Visible = false;
                datagrid.Visible = true;
            }
    }
    protected void clear()
    {
        ddlnumberofunits.SelectedIndex = 0;
        ddlunitno.SelectedIndex = 0;
        txttextbookname.Text = "";
        txtauthor.Text = "";
        txtlessonName.Text = "";
        txtunitname.Text = "";
        btnaddlesson.Visible = false;
        lessontag.Visible = true;
        Btnadd.Text = "Add";
        filldatagrid();
        dgsyllabus.Visible = false;
        datagrid.Visible = true;
    }
    protected void fillgrid()
    {
        DataSet ds, ds1;
        string strsql="";
        strsql = "select strstandard,strsubject,strtextbook,strauthor,strunitno+' - '+strunitname as unit,'' as strlessonName,strunitno,strunitname from dbo.tblschoolsyllabus where strstandard='" + ddlstandard.SelectedValue + "'and strsubject='" + ddlsubject.SelectedValue + "'and strtextbook='" + txttextbookname.Text + "'and strauthor='" + txtauthor.Text + "'and strunitno='" +ddlunitno.SelectedValue+"' and   intschool=" + Session["SchoolID"].ToString() + " group by strstandard,strsubject,strtextbook,strauthor,strunitno,strunitname";
        DataAccess da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            strsql = "select strlessonName from tblschoolsyllabus where strstandard='" + ds.Tables[0].Rows[i]["strstandard"].ToString() + "' and strsubject='" + ds.Tables[0].Rows[i]["strsubject"].ToString() + "' and strtextbook='" + ds.Tables[0].Rows[i]["strtextbook"].ToString() + "' and strauthor='" + ds.Tables[0].Rows[i]["strauthor"].ToString() + "' and strunitno='" + ds.Tables[0].Rows[i]["strunitno"].ToString() + "' and strunitname='" + ds.Tables[0].Rows[i]["strunitname"].ToString() + "' and intschool=" + Session["SchoolID"].ToString();
            ds1 = new DataSet();
            ds1 = da.ExceuteSql(strsql);
            string lesson = "";
            for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
            {
                if (lesson == "")
                    lesson = ds1.Tables[0].Rows[j]["strlessonName"].ToString();
                else
                    lesson = lesson + "<br />" + ds1.Tables[0].Rows[j]["strlessonName"].ToString();
            }
            ds.Tables[0].Rows[i]["strlessonName"] = lesson;
        }
        dgsyllabus.DataSource = ds;
        dgsyllabus.DataBind();
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        clear();
    }
    protected void ddlnumberofunits_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Btnadd.Text != "update")
        {
            DataAccess da = new DataAccess();
            string str;
            DataSet ds = new DataSet();
            da = new DataAccess();
            str = "select * from dbo.tblschoolsyllabus where strtextbook='" + txttextbookname.Text.Trim() + "' and strstandard='" + ddlstandard.SelectedValue + "' and strsubject='" + ddlsubject.SelectedValue + "'";
            ds = da.ExceuteSql(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                msgbox.alert("textbook is already assigned");
                ddlnumberofunits.SelectedIndex = 0;
            }
            else
            {
                //msgbox.alert("textbook is available");
                fillunitno();
            }
        }
        else
        {
            fillunitno();
        }
        
    }
    
    protected void Btnadd_Click(object sender, EventArgs e)
    {
        if (Btnadd.Text == "update")
        {
            updatedatagrid();
            clear();
        }
        else
        {
            SqlCommand command;
            SqlParameter OutPutParam;
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
            conn.Open();
            command = new SqlCommand("SPschoolsyllabus", conn);
            command.CommandType = CommandType.StoredProcedure;
            OutPutParam = command.Parameters.Add("@rc", SqlDbType.Int);
            OutPutParam.Direction = ParameterDirection.Output;            
            if (Btnadd.Text == "Add")
            {
                command.Parameters.Add("@intID", "0");
            }
            else if (Btnadd.Text == "Update")
            {
                command.Parameters.Add("@intID", Session["ID"].ToString());
            }
            command.Parameters.Add("@strstandard", ddlstandard.SelectedValue);
            command.Parameters.Add("@strsubject", ddlsubject.SelectedValue);
            command.Parameters.Add("@strtextbook", txttextbookname.Text.Trim());
            command.Parameters.Add("@intunits", ddlnumberofunits.SelectedValue);
            command.Parameters.Add("@strunitno", ddlunitno.SelectedValue);
            command.Parameters.Add("@strunitname", txtunitname.Text.Trim());
            command.Parameters.Add("@strlessonName", txtlessonName.Text.Trim());
            command.Parameters.Add("@strauthor", txtauthor.Text.Trim());
            command.Parameters.Add("@intschool", Session["SchoolID"].ToString());
            command.ExecuteNonQuery();

            if ((command.Parameters["@rc"].Value).ToString() == "0")
            {
                msgbox.alert("Lesson Already assigned to this unit");
            }            
            conn.Close();
            string id = Convert.ToString(OutPutParam.Value);
            if (Btnadd.Text == "Add")
            {
                Functions.UserLogs(Session["UserID"].ToString(), "tblschoolsyllabus", id, "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 101);
            }
            else if (Btnadd.Text == "Update")
            {
                Functions.UserLogs(Session["UserID"].ToString(), "tblschoolsyllabus", id, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 101);
            }
            txtlessonName.Text = "";
            fillgrid();
            Btnadd.Text = "Add";
            datagrid.Visible = false;
            dgsyllabus.Visible = true;
        }
    }
    protected void updatedatagrid()
    {
        string strsql = "";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        if (hiddentxtlessonname.Text == "")
        {
            strsql = "select intid from tblschoolsyllabus where strstandard='" + ddlstandard.SelectedValue + "' and strsubject='" + ddlsubject.SelectedValue + "' and strtextbook='" + Session["text"].ToString() + "' and strunitno='" + ddlunitno.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString();
            ds = da.ExceuteSql(strsql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Functions.UserLogs(Session["UserID"].ToString(), "tblschoolsyllabus", ds.Tables[0].Rows[i]["intid"].ToString(), "updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),101);

                }
            }

            strsql = "update tblschoolsyllabus set strstandard='" + ddlstandard.SelectedValue + "',strsubject='" + ddlsubject.SelectedValue + "', strtextbook='" + txttextbookname.Text + "',strauthor='" + txtauthor.Text + "',";
            strsql = strsql + " intunits=" + ddlnumberofunits.SelectedValue + ",strunitname='" + txtunitname.Text.Trim() + "' where strstandard='" + ddlstandard.SelectedValue + "' and strsubject='" + ddlsubject.SelectedValue + "' and strtextbook='" + Session["text"].ToString() + "' and strunitno='"+ddlunitno.SelectedValue+"' and intschool=" + Session["SchoolID"].ToString();
        }
        else
        {
            strsql = "select intid from tblschoolsyllabus where strstandard='" + ddlstandard.SelectedValue + "' and strsubject='" + ddlsubject.SelectedValue + "' and strtextbook='" + Session["txt"].ToString() + "' and strlessonName='" + hiddentxtlessonname.Text + "' and intschool=" + Session["SchoolID"].ToString();
            ds = da.ExceuteSql(strsql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Functions.UserLogs(Session["UserID"].ToString(), "tblschoolsyllabus", ds.Tables[0].Rows[i]["intid"].ToString(), "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),101);

                }
            }

            strsql = "update tblschoolsyllabus set strstandard='" + ddlstandard.SelectedValue + "',strsubject='" + ddlsubject.SelectedValue + "', strtextbook='" + txttextbookname.Text + "',strauthor='" + txtauthor.Text + "',";
            strsql = strsql + " intunits=" + ddlnumberofunits.SelectedValue + ",strunitname='" + txtunitname.Text.Trim() + "' where strstandard='" + ddlstandard.SelectedValue + "' and strsubject='" + ddlsubject.SelectedValue + "' and strtextbook='" + Session["txt"].ToString() + "' and strlessonName='" + hiddentxtlessonname.Text + "' and intschool=" + Session["SchoolID"].ToString();
        }
        da = new DataAccess();
        da.ExceuteSqlQuery(strsql);
        filldatagrid();
        Btnadd.Text = "Add";
        lessontag.Visible = true;
    }
    protected void ddlstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlstandard.SelectedIndex > 0 && ddlsubject.SelectedIndex > 0)
        filldatagrid();
        clear();
        dgsyllabus.Visible = false;
        fillsubject();
    }
    protected void ddlsubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlstandard.SelectedIndex > 0 && ddlsubject.SelectedIndex > 0)
        filldatagrid();
        clear();
        dgsyllabus.Visible = false;
    }    
    protected void dgsub_EditCommand(object source, DataGridCommandEventArgs e)
    {
        try
        {
            Session["ID"] = e.Item.Cells[0].Text;
            DataGrid dg = (DataGrid)e.Item.FindControl("dgsub");
            txtlessonName.Text=e.Item.Cells[1].Text;
            lessontag.Visible = true;
            Btnadd.Text = "Update";

        }
        catch { }
    }
    //protected void dgsub_DeleteCommand(object source, DataGridCommandEventArgs e)
    //{
    //    string strsql = "";
    //    strsql = "delete tblschoolsyllabus where intid='" + e.Item.Cells[0].Text + "' and strlessonName='" + e.Item.Cells[1].Text + "'  and intschool=" + Session["SchoolID"].ToString();
    //    DataAccess da = new DataAccess();
    //    da.ExceuteSqlQuery(strsql);
    //    fillgrid();
    //}
    protected void datagrid_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["text"] = e.Item.Cells[2].Text;
        Session["author"] = e.Item.Cells[3].Text;
        txttextbookname.Text = e.Item.Cells[2].Text;
        txtauthor.Text = e.Item.Cells[3].Text;
        ddlnumberofunits.SelectedValue = e.Item.Cells[4].Text;
        ddlsubject.SelectedValue = e.Item.Cells[1].Text;
        ddlstandard.SelectedValue = e.Item.Cells[0].Text;
        lessontag.Visible = false;
        btnaddlesson.Visible = true;
        fillunitno();
        ddlunitno.SelectedValue = e.Item.Cells[5].Text;
        txtunitname.Text = e.Item.Cells[6].Text;
        Btnadd.Text = "update";       
    }
    //protected void datagrid_DeleteCommand(object source, DataGridCommandEventArgs e)
    //{
    //    string strsql = "";
    //    strsql = "delete tblschoolsyllabus where strstandard='" + e.Item.Cells[0].Text + "' and strsubject='" + e.Item.Cells[1].Text + "' and strtextbook='" + e.Item.Cells[2].Text + "' and strauthor='" + e.Item.Cells[3].Text + "'and strunitno='" + e.Item.Cells[5].Text + "'and strunitname='" + e.Item.Cells[6].Text + "'  and intschool=" + Session["SchoolID"].ToString();
    //    DataAccess da = new DataAccess();
    //    da.ExceuteSqlQuery(strsql);
    //    filldatagrid();
    //}
    protected void ddlunitno_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strsql = ""; 
        strsql = "select strstandard,strsubject,strtextbook,strauthor,strunitno+' - '+strunitname as unit,strunitname,strunitno,'' as strlessonName from dbo.tblschoolsyllabus where strstandard='" + ddlstandard.SelectedValue + "' and strsubject='" + ddlsubject.SelectedValue + "' and strtextbook='" + txttextbookname.Text.Trim() + "'";
        strsql = strsql + "and strauthor='" + txtauthor.Text.Trim() + "' and strunitno='"+ddlunitno.SelectedValue+"' and intschool=" + Session["SchoolID"].ToString() + " group by strsubject,strtextbook,strauthor,strunitno,strunitname,strstandard";
        DataAccess da = new DataAccess();
        DataSet ds,ds1 = new DataSet();
        ds = da.ExceuteSql(strsql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtunitname.Text = ds.Tables[0].Rows[0]["strunitname"].ToString();
            dgsyllabus.DataSource = ds;
            dgsyllabus.DataBind();
            dgsyllabus.Visible = true;
            datagrid.Visible = false;
        }
        else
        {
            Btnadd.Text = "Add";
            //btnaddlesson.Visible = true;
            lessontag.Visible = true;
            txtunitname.Text = "";
            txtlessonName.Text = "";
        }
    }
    protected void btnaddlesson_Click(object sender, EventArgs e)
    {
        lessontag.Visible = true;
        Btnadd.Text = "Add";
    }
    protected void dgsyllabus_ItemDataBound1(object sender, DataGridItemEventArgs e)
    {
        try
        {
            
                DataAccess da = new DataAccess();
                string str;
                DataSet ds1, ds = new DataSet();
                da = new DataAccess();
                if (Request["stand"] == null)
                {
                    str = "select strlessonName,intid from tblschoolsyllabus where strstandard='" + ddlstandard.SelectedValue + "' and strsubject='" + ddlsubject.SelectedValue + "' and strtextbook='" + txttextbookname.Text.Trim() + "' and strauthor='" + txtauthor.Text.Trim() + "' and strunitno='" + ddlunitno.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString();

                }
                else
                {
                    str = "select strlessonName,intid from tblschoolsyllabus where intschool=" + Session["SchoolID"].ToString() + " and strstandard='" + Session["stand"].ToString() + "' and strsubject='" + Session["subj"].ToString() + "' and strtextbook='" + Session["txt"].ToString() + "' and strunitno='" + Session["unit"].ToString()+"'";
                }
                ds1 = new DataSet();
                ds1 = da.ExceuteSql(str);
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    DataGrid dg = (DataGrid)e.Item.FindControl("dgsub");
                    dg.DataSource = ds1;
                    dg.DataBind();
                }          
        }
        catch { }
    }
    //protected void btncheck_Click(object sender, EventArgs e)
    //{
    //    DataAccess da = new DataAccess();
    //    string str;
    //    DataSet ds = new DataSet();
    //    da = new DataAccess();
    //    str = "select * from dbo.tblschoolsyllabus where strtextbook='" + txttextbookname.Text.Trim() + "' and strstandard='" + ddlstandard.SelectedValue + "' and strsubject='" + ddlsubject.SelectedValue + "'";
    //    ds = da.ExceuteSql(str);
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        msgbox.alert("textbook is already assigned");
    //    }
    //    else
    //    {
    //        msgbox.alert("textbook is available");
    //    }

    //}
    protected void btndelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton delete = (ImageButton)sender;
        TableCell cell = delete.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        string strsql = "";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        strsql = "select intid from tblschoolsyllabus where strstandard='" + item.Cells[0].Text + "' and strsubject='" + item.Cells[1].Text + "' and strtextbook='" + item.Cells[2].Text + "' and strauthor='" + item.Cells[3].Text + "'and strunitno='" + item.Cells[5].Text + "'and strunitname='" + item.Cells[6].Text + "'  and intschool=" + Session["SchoolID"].ToString();
        ds = da.ExceuteSql(strsql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Functions.UserLogs(Session["UserID"].ToString(), "tblschoolsyllabus", ds.Tables[0].Rows[0]["intid"].ToString(), "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),101);

            }
        }
        strsql = "delete tblschoolsyllabus where strstandard='" + item.Cells[0].Text + "' and strsubject='" + item.Cells[1].Text + "' and strtextbook='" + item.Cells[2].Text + "' and strauthor='" + item.Cells[3].Text + "'and strunitno='" + item.Cells[5].Text + "'and strunitname='" + item.Cells[6].Text + "'  and intschool=" + Session["SchoolID"].ToString();
        da = new DataAccess();
        da.ExceuteSqlQuery(strsql);
        filldatagrid();
    }
    protected void btndelete1_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton delete = (ImageButton)sender;
        TableCell cell = delete.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        string strsql = "";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        strsql = "select intid from tblschoolsyllabus where intid='" + item.Cells[0].Text + "' and strlessonName='" + item.Cells[1].Text + "'  and intschool=" + Session["SchoolID"].ToString();
        ds = da.ExceuteSql(strsql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Functions.UserLogs(Session["UserID"].ToString(), "tblschoolsyllabus", ds.Tables[0].Rows[0]["intid"].ToString(), "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),101);

            }
        }
        strsql = "delete tblschoolsyllabus where intid='" + item.Cells[0].Text + "' and strlessonName='" + item.Cells[1].Text + "'  and intschool=" + Session["SchoolID"].ToString();
        da = new DataAccess();
        da.ExceuteSqlQuery(strsql);
        fillgrid();
    }
}
