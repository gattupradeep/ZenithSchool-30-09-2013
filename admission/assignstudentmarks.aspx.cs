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

public partial class admission_assignstudentmarks : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillgrid();
        }
    }
    protected void standard()
    {
        if (ddllist.SelectedValue == "1")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select strstandard from tbladmissionattendance where dtdate='" + ddldate.SelectedValue + "' and  intapprove_waitlist=" + ddllist.SelectedValue + "  and  intschool=" + Session["SchoolID"].ToString() + " group by strstandard";
            ds = da.ExceuteSql(str);
            ddlstandard.DataTextField = "strstandard";
            ddlstandard.DataValueField = "strstandard";
            ddlstandard.DataSource = ds;
            ddlstandard.DataBind();
            ddlstandard.Items.Insert(0, "-Select-");
        }
        if (ddllist.SelectedValue == "2")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select strstandard from tbladmissionattendance where dtdate='" + ddldate.SelectedValue + "' and  intapprove_waitlist=" + ddllist.SelectedValue + "  and  intschool=" + Session["SchoolID"].ToString() + " group by strstandard";
            ds = da.ExceuteSql(str);
            ddlstandard.DataTextField = "strstandard";
            ddlstandard.DataValueField = "strstandard";
            ddlstandard.DataSource = ds;
            ddlstandard.DataBind();
            ddlstandard.Items.Insert(0, "-Select-");
        }
    }
    protected void date()
    {
        if (ddllist.SelectedValue == "1")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select convert(varchar(10),dtdate,111) as dtdate from tbladmissioninterview where intapprove_waitlist=" + ddllist.SelectedValue + " and intschool=" + Session["SchoolID"].ToString() + " group by dtdate";
            ds = da.ExceuteSql(str);
            ddldate.DataTextField = "dtdate";
            ddldate.DataValueField = "dtdate";
            ddldate.DataSource = ds;
            ddldate.DataBind();
            ddldate.Items.Insert(0, "-Select-");
            ddldate.Items.Insert(1, "-All-");
        }
        if (ddllist.SelectedValue == "2")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select convert(varchar(10),dtdate,111) as dtdate from tbladmissioninterview where intapprove_waitlist=" + ddllist.SelectedValue + " and intschool=" + Session["SchoolID"].ToString() + " group by dtdate";
            ds = da.ExceuteSql(str);
            ddldate.DataTextField = "dtdate";
            ddldate.DataValueField = "dtdate";
            ddldate.DataSource = ds;
            ddldate.DataBind();
            ddldate.Items.Insert(0, "-Select-");
            ddldate.Items.Insert(1, "-All-");
        }
    }
    protected void filldetails()
    {
        if (ddllist.SelectedValue == "1")
        {
            DataAccess da = new DataAccess();
            DataSet ds, ds1 = new DataSet();
            string str = "select * from tblstudentadmission where intapprove=1 and intschool=" + Session["SchoolID"].ToString() + " and str_standard='" + ddlstandard.SelectedValue + "'";
            ds1 = new DataSet();
            ds1 = da.ExceuteSql(str);
            str = "select c.* from tblstudentadmission a,tbladmissionpassmarkassigned b,tbladmissionattendance c where a.str_standard='" + ddlstandard.SelectedValue + "' and a.str_standard=b.strstandard and a.intapprove=1 and a.intid=c.intapplication and b.intschool=" + Session["SchoolID"].ToString() + " and c.intschool=" + Session["SchoolID"].ToString();
            ds = da.ExceuteSql(str);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                str = "select c.intid,b.intmarksrequired,b.intpassmarks,c.strattendance from tblstudentadmission a,tbladmissionpassmarkassigned b,tbladmissionattendance c where a.str_standard='" + ddlstandard.SelectedValue + "' and a.str_standard=b.strstandard and a.intapprove=1 and a.intid=c.intapplication and c.intid=" + ds.Tables[0].Rows[0]["intid"].ToString() + " and b.intschool=" + Session["SchoolID"].ToString();
                ds = da.ExceuteSql(str);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblmarks.Text = ds.Tables[0].Rows[0]["intmarksrequired"].ToString();
                    lblpassmark.Text = ds.Tables[0].Rows[0]["intpassmarks"].ToString();
                }
            }
        }
        if (ddllist.SelectedValue == "2")
        {
            DataAccess da = new DataAccess();
            DataSet ds, ds1 = new DataSet();
            string str = "select * from tblstudentadmission where intwaitlist=1 and intschool=" + Session["SchoolID"].ToString() + " and str_standard='" + ddlstandard.SelectedValue + "'";
            ds1 = new DataSet();
            ds1 = da.ExceuteSql(str);
            str = "select c.* from tblstudentadmission a,tbladmissionpassmarkassigned b,tbladmissionattendance c where a.str_standard='" + ddlstandard.SelectedValue + "' and a.str_standard=b.strstandard and a.intwaitlist=1 and a.intid=c.intapplication and b.intschool=" + Session["SchoolID"].ToString() + " and c.intschool=" + Session["SchoolID"].ToString();
            ds = da.ExceuteSql(str);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                str = "select c.intid,b.intmarksrequired,b.intpassmarks,c.strattendance from tblstudentadmission a,tbladmissionpassmarkassigned b,tbladmissionattendance c where a.str_standard='" + ddlstandard.SelectedValue + "' and a.str_standard=b.strstandard and a.intwaitlist=1 and a.intid=c.intapplication and c.intid=" + ds.Tables[0].Rows[0]["intid"].ToString() + " and b.intschool=" + Session["SchoolID"].ToString();
                ds = da.ExceuteSql(str);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblmarks.Text = ds.Tables[0].Rows[0]["intmarksrequired"].ToString();
                    lblpassmark.Text = ds.Tables[0].Rows[0]["intpassmarks"].ToString();
                }
            }
        }
    }
   protected void clear()
    {
        lblmarks.Text = "";
        lblpassmark.Text = "";
    }
   protected void fillgrid()
    {
        if (ddllist.SelectedValue == "1")
        {
            // There is no fields in tbladmissionstudentmarks its go to else condition and its fill application id,studentname,marks we want to enter in datagrid and we enter the update button its insert into table then we get result and  now its went to if condition for shown in fillgird
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select * from tbladmissionstudentmarks where strstandard='" + ddlstandard.SelectedValue + "' and intapprove_waitlist=" + ddllist.SelectedValue + " and intschool=" + Session["SchoolID"].ToString();
            ds=da.ExceuteSql(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                str = "select a.intid,a.intapplication,b.strstudent,a.intmarksscored,a.strresult from tbladmissionstudentmarks a,tbladmissionattendance b where a.intschool=" + Session["SchoolID"].ToString() + " and b.intschool=" + Session["SchoolID"].ToString() + " and a.intapplication=b.intapplication and a.strstandard='" + ddlstandard.SelectedValue + "' and a.intapprove_waitlist=" + ddllist.SelectedValue;
                ds = da.ExceuteSql(str);
                dgadmissionresult.DataSource = ds;
                dgadmissionresult.DataBind();
            }
            else
            {
                str = "select b.intid,a.intid as intapplication,b.strstudent,0 as intmarksscored,'N/A' as strresult from tblstudentadmission a,tbladmissionattendance b where a.str_standard=b.strstandard and a.intapprove=1 and a.intid=b.intapplication and a.str_standard='" + ddlstandard.SelectedValue + "' and b.intschool="+Session["SchoolId"].ToString()+" and a.intschool=" + Session["SchoolID"].ToString();
                ds = da.ExceuteSql(str);
                dgadmissionresult.DataSource = ds;
                dgadmissionresult.DataBind();
            }
            
        }
        if (ddllist.SelectedValue == "2")
        {

            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select * from tbladmissionstudentmarks where strstandard='" + ddlstandard.SelectedValue + "' and intapprove_waitlist="+ddllist.SelectedValue+" and intschool=" + Session["SchoolID"].ToString();
            ds = da.ExceuteSql(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                str = "select a.intid,a.intapplication,b.strstudent,b.strattendance,a.intmarksscored,a.strresult from tbladmissionstudentmarks a,tbladmissionattendance b where a.intschool=" + Session["SchoolID"].ToString() + " and b.intschool=" + Session["SchoolID"].ToString() + " and a.intapplication=b.intapplication and a.strstandard='" + ddlstandard.SelectedValue + "' and a.intapprove_waitlist=" + ddllist.SelectedValue;
                ds = da.ExceuteSql(str);
                dgadmissionresult.DataSource = ds;
                dgadmissionresult.DataBind();
            }
            else
            {
                str = "select b.intid,a.intid as intapplication,b.strstudent,b.strattendance,0 as intmarksscored,'N/A' as strresult from tblstudentadmission a,tbladmissionattendance b where a.str_standard=b.strstandard and a.intwaitlist=1 and  a.intid=b.intapplication and a.str_standard='" + ddlstandard.SelectedValue + "' and b.intschool=" + Session["SchoolId"].ToString() + " and a.intschool=" + Session["SchoolID"].ToString();
                ds = da.ExceuteSql(str);
                dgadmissionresult.DataSource = ds;
                dgadmissionresult.DataBind();
            }
        }
    }
    protected void ddllist_SelectedIndexChanged(object sender, EventArgs e)
    {
        date();
        clear();
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        //insert and update are same button once we enter the mark tnd give update means its insert to the table then you want any edit just change which one you want edit then click again update button now its goto update function.
        if (ddllist.SelectedValue == "1")
        {
             DataAccess da = new DataAccess();
             DataSet ds = new DataSet();
             string str = "select * from tbladmissionstudentmarks where strstandard='" + ddlstandard.SelectedValue + "' and intapprove_waitlist=" + ddllist.SelectedValue + " and intschool=" + Session["SchoolID"].ToString();
             ds=da.ExceuteSql(str);
             for (int i = 0; i < dgadmissionresult.Items.Count; i++)
             {
                 DataGridItem dgi = dgadmissionresult.Items[i];
                 TextBox textresult = (TextBox)dgi.FindControl("txtresult");
                 string result = "";
                 if (int.Parse(textresult.Text) >= int.Parse(lblpassmark.Text))
                 {
                      result = "Pass";
                 }
                 else
                 {
                      result = "Fail";
                 }
                 if (int.Parse(textresult.Text) > int.Parse(lblmarks.Text))
                 {
                     msgbox.alert("Marks are exceed than maximum marks");
                 }
                 else
                 {
                     if (ds.Tables[0].Rows.Count > 0)
                     {
                         str = "update tbladmissionstudentmarks set intmarksscored='" + textresult.Text.Trim() + "',strresult='" + result + "' where intid=" + dgi.Cells[0].Text + " and strstandard='" + ddlstandard.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + " and intapprove_waitlist=" + ddllist.SelectedValue + "";
                         da.ExceuteSql(str);
                     }
                     else
                     {
                         str = "insert into tbladmissionstudentmarks(dtdate,intapplication,strstandard,intmarksscored,strresult,intschool,intapprove_waitlist)values('" + ddldate.SelectedValue + "','" + dgi.Cells[1].Text + "','" + ddlstandard.SelectedValue + "'," + textresult.Text.Trim() + ",'" + result + "'," + Session["SchoolID"].ToString() + "," + ddllist.SelectedValue + ")";
                         da.ExceuteSql(str);
                     }
                     fillgrid();
                     msgbox.alert("Successfully Saved");
                 }

             }
             
        }
        if (ddllist.SelectedValue == "2")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select * from tbladmissionstudentmarks where strstandard='" + ddlstandard.SelectedValue + "' and intapprove_waitlist=" + ddllist.SelectedValue + " and intschool=" + Session["SchoolID"].ToString();
            ds = da.ExceuteSql(str);
            for (int i = 0; i < dgadmissionresult.Items.Count; i++)
            {
                DataGridItem dgi = dgadmissionresult.Items[i];
                TextBox textresult = (TextBox)dgi.FindControl("txtresult");
                string result = "";
                if (int.Parse(textresult.Text) >= int.Parse(lblpassmark.Text))
                {
                    result = "Pass";
                }
                else
                {
                    result = "Fail";
                }
                if (int.Parse(textresult.Text) > int.Parse(lblmarks.Text))
                {
                    msgbox.alert("Marks are exceed than maximum marks");
                }
                else
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        str = "update tbladmissionstudentmarks set intmarksscored='" + textresult.Text.Trim() + "',strresult='" + result + "' where intid=" + dgi.Cells[0].Text + " and strstandard='" + ddlstandard.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + " and intapprove_waitlist=" + ddllist.SelectedValue + "";
                        da.ExceuteSql(str);
                    }
                    else
                    {
                        str = "insert into tbladmissionstudentmarks(dtdate,intapplication,strstandard,intmarksscored,strresult,intschool,intapprove_waitlist)values('" + ddldate.SelectedValue + "','" + dgi.Cells[1].Text + "','" + ddlstandard.SelectedValue + "'," + textresult.Text.Trim() + ",'" + result + "'," + Session["SchoolID"].ToString() + "," + ddllist.SelectedValue + ")";
                        da.ExceuteSql(str);
                    }
                    fillgrid();
                    msgbox.alert("Successfully Saved");
                }
             }
        }
    }
    protected void ddlstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        clear();
        filldetails();
        fillgrid();
        
    }
    protected void dgadmissionresult_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        try
        {
            DataRowView dr = (DataRowView)e.Item.DataItem;
            TextBox textresult = (TextBox)e.Item.FindControl("txtresult");
            textresult.Text = dr["intmarksscored"].ToString();
        }
        catch { } 
    }
    protected void ddldate_SelectedIndexChanged(object sender, EventArgs e)
    {
        standard();
    }
    protected void txtresult_TextChanged(object sender, EventArgs e)
    {
        for (int i = 0; i < dgadmissionresult.Items.Count; i++)
        {
            DataGridItem dgi = dgadmissionresult.Items[i];
            TextBox textresult = (TextBox)dgi.FindControl("txtresult");

            if (int.Parse(textresult.Text) > int.Parse(lblmarks.Text))
            {
                msgbox.alert("Marks are exceed than maximum marks");
            }
        }
    }
}
