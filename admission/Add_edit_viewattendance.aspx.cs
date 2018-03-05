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

public partial class admission_Add_edit_viewattendance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            standard();
            date();
            time();
            buildname();
            trstandard.Visible = false;
            trbuilding.Visible = false;
            trfloor.Visible = false;
            trroom.Visible = false;
        }
    }
    protected void standard()
    {
        if (RBsY.Checked == true)
        {
            if (ddllist.SelectedValue == "1")
            {
                DataAccess da = new DataAccess();
                DataSet ds = new DataSet();
                string str = "select a.strstandard from tbladmissioninterview a,tblbuilding b  where a.strfloor='" + ddlfloor.SelectedValue + "' and b.strbuildname='" + ddlbuildname.SelectedValue + "' and  a.introomno=" + ddlroom.SelectedValue + " and a.intapprove_waitlist=" + ddllist.SelectedValue + " and a.intschool=" + Session["SchoolID"].ToString() + " group by a.strstandard";
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
                string str = "select a.strstandard from tbladmissioninterview a,tblbuilding b  where a.strfloor='" + ddlfloor.SelectedValue + "' and b.strbuildname='" + ddlbuildname.SelectedValue + "' and  a.introomno=" + ddlroom.SelectedValue + " and a.intapprove_waitlist=" + ddllist.SelectedValue + " and a.intschool=" + Session["SchoolID"].ToString() + " group by a.strstandard";
                ds = da.ExceuteSql(str);
                ddlstandard.DataTextField = "strstandard";
                ddlstandard.DataValueField = "strstandard";
                ddlstandard.DataSource = ds;
                ddlstandard.DataBind();
                ddlstandard.Items.Insert(0, "-Select-");
            }
        }
        else
        {
            if (ddllist.SelectedValue == "1")
            {
                DataAccess da = new DataAccess();
                DataSet ds = new DataSet();
                string str = "select strstandard from tbladmissioninterview  where intapprove_waitlist=" + ddllist.SelectedValue + " and intschool=" + Session["SchoolID"].ToString() + " group by strstandard";
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
                string str = "select strstandard from tbladmissioninterview where intapprove_waitlist=" + ddllist.SelectedValue + " and intschool=" + Session["SchoolID"].ToString() + " group by strstandard";
                ds = da.ExceuteSql(str);
                ddlstandard.DataTextField = "strstandard";
                ddlstandard.DataValueField = "strstandard";
                ddlstandard.DataSource = ds;
                ddlstandard.DataBind();
                ddlstandard.Items.Insert(0, "-Select-");
            }
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
    protected void time()
    {
        if (ddllist.SelectedValue == "1")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select dttime from tbladmissioninterview where dtdate='" + ddldate.SelectedValue + "' and intapprove_waitlist=" + ddllist.SelectedValue + " and intschool=" + Session["SchoolID"].ToString() + " group by dttime";
            ds = da.ExceuteSql(str);
            ddltime.DataTextField = "dttime";
            ddltime.DataValueField = "dttime";
            ddltime.DataSource = ds;
            ddltime.DataBind();
            ddltime.Items.Insert(0, "-Select-");

        }
        if (ddllist.SelectedValue == "2")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select dttime from tbladmissioninterview where dtdate='" + ddldate.SelectedValue + "' and intapprove_waitlist=" + ddllist.SelectedValue + " and intschool=" + Session["SchoolID"].ToString() + " group by dttime";
            ds = da.ExceuteSql(str);
            ddltime.DataTextField = "dttime";
            ddltime.DataValueField = "dttime";
            ddltime.DataSource = ds;
            ddltime.DataBind();
            ddltime.Items.Insert(0, "-Select-");

        }
    }
    protected void buildname()
    {
        if (ddllist.SelectedValue == "1")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select b.strbuildname from tbladmissioninterview a,tblbuilding b where dtdate='" + ddldate.SelectedValue + "' and a.intapprove_waitlist=" + ddllist.SelectedValue + " and b.intid=a.strbuildingname and a.intschool=" + Session["SchoolID"].ToString() + " group by b.strbuildname";
            ds = da.ExceuteSql(str);
            ddlbuildname.DataSource = ds;
            ddlbuildname.DataTextField = "strbuildname";
            ddlbuildname.DataValueField = "strbuildname";
            ddlbuildname.DataBind();
            ddlbuildname.Items.Insert(0, "-Select-");

        }
        if (ddllist.SelectedValue == "2")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select b.strbuildname from tbladmissioninterview a,tblbuilding b where dtdate='" + ddldate.SelectedValue + "' and a.intapprove_waitlist=" + ddllist.SelectedValue + " and b.intid=a.strbuildingname and a.intschool=" + Session["SchoolID"].ToString() + " group by b.strbuildname";
            ds = da.ExceuteSql(str);
            ddlbuildname.DataSource = ds;
            ddlbuildname.DataTextField = "strbuildname";
            ddlbuildname.DataValueField = "strbuildname";
            ddlbuildname.DataBind();
            ddlbuildname.Items.Insert(0, "-Select-");

        }
    }
    protected void floor()
    {
        if (ddllist.SelectedValue == "1")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select a.strfloor from tbladmissioninterview a,tblbuilding b where b.strbuildname='" + ddlbuildname.SelectedValue + "' and a.intapprove_waitlist=" + ddllist.SelectedValue + " and a.intschool=" + Session["SchoolID"].ToString() + " group by a.strfloor";
            ds = da.ExceuteSql(str);
            ddlfloor.DataTextField = "strfloor";
            ddlfloor.DataValueField = "strfloor";
            ddlfloor.DataSource = ds;
            ddlfloor.DataBind();
            ddlfloor.Items.Insert(0, "-Select-");
        }
        if (ddllist.SelectedValue == "2")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select a.strfloor from tbladmissioninterview a,tblbuilding b where b.strbuildname='" + ddlbuildname.SelectedValue + "' and a.intapprove_waitlist=" + ddllist.SelectedValue + " and a.intschool=" + Session["SchoolID"].ToString() + " group by a.strfloor";
            ds = da.ExceuteSql(str);
            ddlfloor.DataTextField = "strfloor";
            ddlfloor.DataValueField = "strfloor";
            ddlfloor.DataSource = ds;
            ddlfloor.DataBind();
            ddlfloor.Items.Insert(0, "-Select-");

        }
    }
    protected void roomno()
    {
        if (ddllist.SelectedValue == "1")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select a.introomno from tbladmissioninterview a,tblbuilding b where a.strfloor='" + ddlfloor.SelectedValue + "' and b.strbuildname='" + ddlbuildname.SelectedValue + "' and a.intapprove_waitlist=" + ddllist.SelectedValue + " and a.intschool=" + Session["SchoolID"].ToString() + " group by a.introomno";
            ds = da.ExceuteSql(str);
            ddlroom.DataTextField = "introomno";
            ddlroom.DataValueField = "introomno";
            ddlroom.DataSource = ds;
            ddlroom.DataBind();
            ddlroom.Items.Insert(0, "-Select-");
        }
        if (ddllist.SelectedValue == "2")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select a.introomno from tbladmissioninterview a,tblbuilding b where a.strfloor='" + ddlfloor.SelectedValue + "' and b.strbuildname='" + ddlbuildname.SelectedValue + "' and a.intapprove_waitlist=" + ddllist.SelectedValue + " and a.intschool=" + Session["SchoolID"].ToString() + " group by a.introomno";
            ds = da.ExceuteSql(str);
            ddlroom.DataTextField = "introomno";
            ddlroom.DataValueField = "introomno";
            ddlroom.DataSource = ds;
            ddlroom.DataBind();
            ddlroom.Items.Insert(0, "-Select-");
        }
    }
    protected void filldetails()
    {
        if (RBsY.Checked == true)
        {
            if (ddllist.SelectedValue == "1")
            {
                DataAccess da = new DataAccess();
                DataSet ds, ds1 = new DataSet();
                string str = "select * from tbladmissioninterview  where intapprove_waitlist=" + ddllist.SelectedValue + " and intschool=" + Session["SchoolID"].ToString();
                ds = da.ExceuteSql(str);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    str = "select b.strfirstname+' '+b.strmiddlename+' ' +b.strlastname as name from tbladmissioninterview a,tblemployee b,tblbuilding c where intapprove_waitlist=" + ddllist.SelectedValue + " and c.strbuildname='" + ddlbuildname.SelectedValue + "' and a.strfloor='" + ddlfloor.SelectedValue + "' and a.introomno='" + ddlroom.SelectedValue + "' and c.intid=a.strbuildingname and b.intid=a.intstaff and a.intschool=" + Session["SchoolID"].ToString() + " group by  b.strfirstname+' '+b.strmiddlename+' ' +b.strlastname";
                    ds = da.ExceuteSql(str);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblinvigilator.Text = ds.Tables[0].Rows[0]["name"].ToString();

                    }
                }
            }
            if (ddllist.SelectedValue == "2")
            {
                DataAccess da = new DataAccess();
                DataSet ds, ds1 = new DataSet();
                string str = "select * from tbladmissioninterview  where intapprove_waitlist=" + ddllist.SelectedValue + " and intschool=" + Session["SchoolID"].ToString();
                ds = da.ExceuteSql(str);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    str = "select b.strfirstname+' '+b.strmiddlename+' ' +b.strlastname as name from tbladmissioninterview a,tblemployee b,tblbuilding c where intapprove_waitlist=" + ddllist.SelectedValue + " and c.strbuildname='" + ddlbuildname.SelectedValue + "' and a.strfloor='" + ddlfloor.SelectedValue + "' and a.introomno='" + ddlroom.SelectedValue + "' and c.intid=a.strbuildingname and b.intid=a.intstaff and a.intschool=" + Session["SchoolID"].ToString() + " group by  b.strfirstname+' '+b.strmiddlename+' ' +b.strlastname";
                    ds = da.ExceuteSql(str);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblinvigilator.Text = ds.Tables[0].Rows[0]["name"].ToString();

                    }
                }
            }
        }
        else
        {
            if (ddllist.SelectedValue == "1")
            {
                DataAccess da = new DataAccess();
                DataSet ds, ds1 = new DataSet();
                string str = "select * from tbladmissioninterview  where intapprove_waitlist=" + ddllist.SelectedValue + " and intschool=" + Session["SchoolID"].ToString();
                ds = da.ExceuteSql(str);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    str = "select b.strfirstname+' '+b.strmiddlename+' ' +b.strlastname as name from tbladmissioninterview a,tblemployee b where intapprove_waitlist=" + ddllist.SelectedValue + " and b.intid=a.intstaff and a.intschool=" + Session["SchoolID"].ToString() + " group by  b.strfirstname+' '+b.strmiddlename+' ' +b.strlastname";
                    ds = da.ExceuteSql(str);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblinvigilator.Text = ds.Tables[0].Rows[0]["name"].ToString();

                    }
                }
            }
            if (ddllist.SelectedValue == "2")
            {
                DataAccess da = new DataAccess();
                DataSet ds, ds1 = new DataSet();
                string str = "select * from tbladmissioninterview  where intapprove_waitlist=" + ddllist.SelectedValue + " and intschool=" + Session["SchoolID"].ToString();
                ds = da.ExceuteSql(str);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    str = "select b.strfirstname+' '+b.strmiddlename+' ' +b.strlastname as name from tbladmissioninterview a,tblemployee b where intapprove_waitlist=" + ddllist.SelectedValue + " and c.intid=a.strbuildingname and b.intid=a.intstaff and a.intschool=" + Session["SchoolID"].ToString() + " group by  b.strfirstname+' '+b.strmiddlename+' ' +b.strlastname";
                    ds = da.ExceuteSql(str);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblinvigilator.Text = ds.Tables[0].Rows[0]["name"].ToString();

                    }
                }
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //insert and update are same button once we select checkboxlist for present student give save means its insert to the table then you want any edit just change which one you want edit then click again save button now its goto update function.
        if (RBsY.Checked == true)
        {
            if (ddllist.SelectedValue == "1")
            {
                DataAccess da = new DataAccess();
                DataSet ds = new DataSet();
                string str = "select a.intapplication,a.strstandard,a.strbuildingname,a.strfloor,a.introomno from tbladmissionattendance a, tblbuilding b,tblstudentadmission c where a.strstandard=c.str_standard and b.strbuildname=a.strbuildingname and a.strstandard='" + ddlstandard.SelectedValue + "' and a.strbuildingname='" + ddlbuildname.SelectedValue + "' and a.strfloor='" + ddlfloor.SelectedValue + "' and a.introomno=" + ddlroom.SelectedValue + " and a.intapprove_waitlist=" + ddllist.SelectedValue + "  and c.intid=a.intapplication and a.intschool=" + Session["SchoolID"].ToString();
                ds = da.ExceuteSql(str);
                for (int i = 0; i < dgadmissionattendance.Items.Count; i++)
                {
                    DataGridItem dgi = dgadmissionattendance.Items[i];
                    CheckBox chkapprove = (CheckBox)dgi.FindControl("chklist");
                    string attendance = "";
                    if (chkapprove.Checked == true)
                    {
                        attendance = "Present";
                    }
                    else
                    {
                        attendance = "Absent";
                    }
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        str = "update tbladmissionattendance set strattendance='" + attendance + "' where intid=" + dgi.Cells[0].Text + " and strstandard='" + dgi.Cells[2].Text + "' and intschool=" + Session["SchoolID"].ToString() + " and intapprove_waitlist=" + ddllist.SelectedValue + "";
                        da.ExceuteSql(str);
                    }
                    else
                    {
                        str = "insert into tbladmissionattendance(intapplication,dtdate,dttime,strstandard,strstudent,strattendance,intschool,intapprove_waitlist,strbuildingname,strfloor,introomno)values(" + dgi.Cells[1].Text + ",'" + ddldate.SelectedValue + "','" + ddltime.SelectedValue + "','" + dgi.Cells[2].Text + "','" + dgi.Cells[3].Text + "','" + attendance + "'," + Session["SchoolID"].ToString() + "," + ddllist.SelectedValue + ",'" + ddlbuildname.SelectedValue + "','" + ddlfloor.SelectedValue + "','" + ddlroom.SelectedValue + "')";
                        da.ExceuteSql(str);
                    }
                }
                fillgrid();
                msgbox.alert("Successfully Saved");
            }
            if (ddllist.SelectedValue == "2")
            {
                DataAccess da = new DataAccess();
                DataSet ds = new DataSet();
                string str = "select a.intapplication,a.strstandard,a.strbuildingname,a.strfloor,a.introomno from tbladmissionattendance a, tblbuilding b,tblstudentadmission c where a.strstandard=c.str_standard and b.strbuildname=a.strbuildingname and a.strstandard='" + ddlstandard.SelectedValue + "' and a.strbuildingname='" + ddlbuildname.SelectedValue + "' and a.strfloor='" + ddlfloor.SelectedValue + "' and a.introomno=" + ddlroom.SelectedValue + " and a.intapprove_waitlist=" + ddllist.SelectedValue + "  and c.intid=a.intapplication and a.intschool=" + Session["SchoolID"].ToString();
                ds = da.ExceuteSql(str);
                for (int i = 0; i < dgadmissionattendance.Items.Count; i++)
                {
                    DataGridItem dgi = dgadmissionattendance.Items[i];
                    CheckBox chkapprove = (CheckBox)dgi.FindControl("chklist");
                    string attendance = "";
                    if (chkapprove.Checked == true)
                    {
                        attendance = "Present";
                    }
                    else
                    {
                        attendance = "Absent";
                    }
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        str = "update tbladmissionattendance set strattendance='" + attendance + "' where intid=" + dgi.Cells[0].Text + " and strstandard='" + dgi.Cells[2].Text + "' and intschool=" + Session["SchoolID"].ToString() + " and intapprove_waitlist=" + ddllist.SelectedValue + "";
                        da.ExceuteSql(str);
                    }
                    else
                    {
                        str = "insert into tbladmissionattendance(intapplication,dtdate,dttime,strstandard,strstudent,strattendance,intschool,intapprove_waitlist,strbuildingname,strfloor,introomno)values(" + dgi.Cells[1].Text + ",'" + ddldate.SelectedValue + "','" + ddltime.SelectedValue + "','" + dgi.Cells[2].Text + "','" + dgi.Cells[3].Text + "','" + attendance + "'," + Session["SchoolID"].ToString() + "," + ddllist.SelectedValue + ",'" + ddlbuildname.SelectedValue + "','" + ddlfloor.SelectedValue + "','" + ddlroom.SelectedValue + "')";
                        da.ExceuteSql(str);
                    }
                }
                fillgrid();
                msgbox.alert("Successfully Saved");
            }
        }
        else
        {
            if (ddllist.SelectedValue == "1")
            {
                DataAccess da = new DataAccess();
                DataSet ds = new DataSet();
                string str = "select a.intapplication,a.strstandard from tbladmissionattendance a,tblstudentadmission c where a.strstandard=c.str_standard and a.strstandard='" + ddlstandard.SelectedValue + "' and a.intapprove_waitlist=" + ddllist.SelectedValue + "  and c.intid=a.intapplication and a.intschool=" + Session["SchoolID"].ToString();
                ds = da.ExceuteSql(str);
                for (int i = 0; i < dgadmissionattendance.Items.Count; i++)
                {
                    DataGridItem dgi = dgadmissionattendance.Items[i];
                    CheckBox chkapprove = (CheckBox)dgi.FindControl("chklist");
                    string attendance = "";
                    if (chkapprove.Checked == true)
                    {
                        attendance = "Present";
                    }
                    else
                    {
                        attendance = "Absent";
                    }
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        str = "update tbladmissionattendance set strattendance='" + attendance + "' where intid=" + dgi.Cells[0].Text + " and strstandard='" + dgi.Cells[2].Text + "' and intschool=" + Session["SchoolID"].ToString() + " and intapprove_waitlist=" + ddllist.SelectedValue + "";
                        da.ExceuteSql(str);
                    }
                    else
                    {
                        str = "insert into tbladmissionattendance(intapplication,dtdate,dttime,strstandard,strstudent,strattendance,intschool,intapprove_waitlist)values(" + dgi.Cells[1].Text + ",'" + ddldate.SelectedValue + "','" + ddltime.SelectedValue + "','" + dgi.Cells[2].Text + "','" + dgi.Cells[3].Text + "','" + attendance + "'," + Session["SchoolID"].ToString() + "," + ddllist.SelectedValue + ")";
                        da.ExceuteSql(str);
                    }
                }
                fillgrid();
                msgbox.alert("Successfully Saved");
            }
            if (ddllist.SelectedValue == "2")
            {
                DataAccess da = new DataAccess();
                DataSet ds = new DataSet();
                string str = "select a.intapplication,a.strstandard from tbladmissionattendance a, tblstudentadmission c where a.strstandard=c.str_standard and a.strstandard='" + ddlstandard.SelectedValue + "' and a.intapprove_waitlist=" + ddllist.SelectedValue + "  and c.intid=a.intapplication and a.intschool=" + Session["SchoolID"].ToString();
                ds = da.ExceuteSql(str);
                for (int i = 0; i < dgadmissionattendance.Items.Count; i++)
                {
                    DataGridItem dgi = dgadmissionattendance.Items[i];
                    CheckBox chkapprove = (CheckBox)dgi.FindControl("chklist");
                    string attendance = "";
                    if (chkapprove.Checked == true)
                    {
                        attendance = "Present";
                    }
                    else
                    {
                        attendance = "Absent";
                    }
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        str = "update tbladmissionattendance set strattendance='" + attendance + "' where intid=" + dgi.Cells[0].Text + " and strstandard='" + dgi.Cells[2].Text + "' and intschool=" + Session["SchoolID"].ToString() + " and intapprove_waitlist=" + ddllist.SelectedValue + "";
                        da.ExceuteSql(str);
                    }
                    else
                    {
                        str = "insert into tbladmissionattendance(intapplication,dtdate,dttime,strstandard,strstudent,strattendance,intschool,intapprove_waitlist)values(" + dgi.Cells[1].Text + ",'" + ddldate.SelectedValue + "','" + ddltime.SelectedValue + "','" + dgi.Cells[2].Text + "','" + dgi.Cells[3].Text + "','" + attendance + "'," + Session["SchoolID"].ToString() + "," + ddllist.SelectedValue + ")";
                        da.ExceuteSql(str);
                    }
                }
                fillgrid();
                msgbox.alert("Successfully Saved");
            }
        }
    }
    protected void clear()
    {
        lblinvigilator.Text = "";
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        clear();
    }
    protected void fillgrid()
    {
        // There is no fields in tbladmissionattendance its go to else condition and its fill application id,studentname,standard ,attendance we want to choose present student in checkboxlist in datagrid and we enter the save button its insert into table after that its shown in fillgird only present student we tick the checkboxlist.
        if (RBsY.Checked == true)
        {
            if (ddllist.SelectedValue == "1")
            {
                DataAccess da = new DataAccess();
                DataSet ds = new DataSet();
                string str = "select a.intapplication,a.strstandard,a.strbuildingname,a.strfloor,a.introomno from tbladmissionattendance a, tblbuilding b,tblstudentadmission c where a.strstandard=c.str_standard and b.strbuildname=a.strbuildingname and a.strstandard='" + ddlstandard.SelectedValue + "' and a.strbuildingname='" + ddlbuildname.SelectedValue + "' and a.strfloor='" + ddlfloor.SelectedValue + "' and a.introomno=" + ddlroom.SelectedValue + " and a.intapprove_waitlist=" + ddllist.SelectedValue + "  and c.intid=a.intapplication and a.intschool=" + Session["SchoolID"].ToString();
                ds = da.ExceuteSql(str);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    str = "select a.intid,a.intapplication,a.strstandard,b.str_firstname+' '+str_middlename+' '+str_lastname as name,a.strattendance from tbladmissionattendance a,tblstudentadmission b where b.intid=a.intapplication and a.intapprove_waitlist=" + ddllist.SelectedValue + " and a.strstandard='" + ddlstandard.SelectedValue + "' and a.strbuildingname='" + ddlbuildname.SelectedValue + "' and a.strfloor='" + ddlfloor.SelectedValue + "' and a.introomno=" + ddlroom.SelectedValue + " and a.intschool=" + Session["SchoolID"].ToString() + " and b.intschool=" + Session["SchoolID"].ToString();
                    ds = da.ExceuteSql(str);
                    dgadmissionattendance.DataSource = ds;
                    dgadmissionattendance.DataBind();
                }
                else
                {
                    str = "select b.intid, b.intid as intapplication,b.str_standard as strstandard,b.str_firstname+' '+str_middlename+' '+str_lastname as name,'Null' as strattendance from tbladmissioninterview a,tblstudentadmission b,tblbuilding c where a.strstandard=b.str_standard and b.intapprove=1 and b.intid>=a.intfromappl and b.intid<=a.inttoappl and b.str_standard='" + ddlstandard.SelectedValue + "' and c.intid=a.strbuildingname and c.strbuildname='" + ddlbuildname.SelectedValue + "' and a.strfloor='" + ddlfloor.SelectedValue + "' and a.introomno=" + ddlroom.SelectedValue + " and a.intschool=" + Session["SchoolID"].ToString();
                    ds = da.ExceuteSql(str);
                    dgadmissionattendance.DataSource = ds;
                    dgadmissionattendance.DataBind();
                }
            }
            if (ddllist.SelectedValue == "2")
            {

                DataAccess da = new DataAccess();
                DataSet ds = new DataSet();
                string str = "select a.intapplication,a.strstandard,a.strbuildingname,a.strfloor,a.introomno from tbladmissionattendance a, tblbuilding b,tblstudentadmission c where a.strstandard=c.str_standard and b.strbuildname=a.strbuildingname and a.strstandard='" + ddlstandard.SelectedValue + "' and a.strbuildingname='" + ddlbuildname.SelectedValue + "' and a.strfloor='" + ddlfloor.SelectedValue + "' and a.introomno=" + ddlroom.SelectedValue + " and a.intapprove_waitlist=" + ddllist.SelectedValue + "  and c.intid=a.intapplication and a.intschool=" + Session["SchoolID"].ToString();
                ds = da.ExceuteSql(str);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    str = "select a.intid,a.intapplication,a.strstandard,b.str_firstname+' '+str_middlename+' '+str_lastname as name,a.strattendance from tbladmissionattendance a,tblstudentadmission b where b.intid=a.intapplication and a.intapprove_waitlist=" + ddllist.SelectedValue + " and a.strstandard='" + ddlstandard.SelectedValue + "' and a.strbuildingname='" + ddlbuildname.SelectedValue + "' and a.strfloor='" + ddlfloor.SelectedValue + "' and a.introomno=" + ddlroom.SelectedValue + " and a.intschool=" + Session["SchoolID"].ToString() + " and b.intschool=" + Session["SchoolID"].ToString();
                    ds = da.ExceuteSql(str);
                    dgadmissionattendance.DataSource = ds;
                    dgadmissionattendance.DataBind();
                }
                else
                {
                    str = "select b.intid, b.intid as intapplication,b.str_standard as strstandard,b.str_firstname+' '+str_middlename+' '+str_lastname as name,'Null' as strattendance from tbladmissioninterview a,tblstudentadmission b,tblbuilding c where a.strstandard=b.str_standard and b.intwaitlist=1 and b.intid>=a.intfromappl and b.intid<=a.inttoappl and b.str_standard='" + ddlstandard.SelectedValue + "' and c.intid=a.strbuildingname and c.strbuildname='" + ddlbuildname.SelectedValue + "' and a.strfloor='" + ddlfloor.SelectedValue + "' and a.introomno=" + ddlroom.SelectedValue + " and a.intschool=" + Session["SchoolID"].ToString();
                    ds = da.ExceuteSql(str);
                    dgadmissionattendance.DataSource = ds;
                    dgadmissionattendance.DataBind();
                }
            }
        }
        else
        {
            if (ddllist.SelectedValue == "1")
            {
                DataAccess da = new DataAccess();
                DataSet ds = new DataSet();
                string str = "select a.intapplication,a.strstandard from tbladmissionattendance a,tblstudentadmission c where a.strstandard=c.str_standard and a.strstandard='" + ddlstandard.SelectedValue + "' and a.intapprove_waitlist=" + ddllist.SelectedValue + "  and c.intid=a.intapplication and a.intschool=" + Session["SchoolID"].ToString();
                ds = da.ExceuteSql(str);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    str = "select a.intid,a.intapplication,a.strstandard,b.str_firstname+' '+str_middlename+' '+str_lastname as name,a.strattendance from tbladmissionattendance a,tblstudentadmission b where b.intid=a.intapplication and a.intapprove_waitlist=" + ddllist.SelectedValue + " and a.strstandard='" + ddlstandard.SelectedValue + "' and a.intschool=" + Session["SchoolID"].ToString() + " and b.intschool=" + Session["SchoolID"].ToString();
                    ds = da.ExceuteSql(str);
                    dgadmissionattendance.DataSource = ds;
                    dgadmissionattendance.DataBind();
                }
                else
                {
                    str = "select b.intid, b.intid as intapplication,b.str_standard as strstandard,b.str_firstname+' '+str_middlename+' '+str_lastname as name,'Null' as strattendance from tbladmissioninterview a,tblstudentadmission b where a.strstandard=b.str_standard and b.intapprove=1 and b.intid>=a.intfromappl and b.intid<=a.inttoappl and b.str_standard='" + ddlstandard.SelectedValue + "' and a.intschool=" + Session["SchoolID"].ToString();
                    ds = da.ExceuteSql(str);
                    dgadmissionattendance.DataSource = ds;
                    dgadmissionattendance.DataBind();
                }
            }
           if (ddllist.SelectedValue == "2")
            {

                DataAccess da = new DataAccess();
                DataSet ds = new DataSet();
                string str = "select a.intapplication,a.strstandard from tbladmissionattendance a,tblstudentadmission c where a.strstandard=c.str_standard and a.strstandard='" + ddlstandard.SelectedValue + "' and a.intapprove_waitlist=" + ddllist.SelectedValue + "  and c.intid=a.intapplication and a.intschool=" + Session["SchoolID"].ToString();
                ds = da.ExceuteSql(str);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    str = "select a.intid,a.intapplication,a.strstandard,b.str_firstname+' '+str_middlename+' '+str_lastname as name,a.strattendance from tbladmissionattendance a,tblstudentadmission b where b.intid=a.intapplication and a.intapprove_waitlist=" + ddllist.SelectedValue + " and a.strstandard='" + ddlstandard.SelectedValue + "' and a.intschool=" + Session["SchoolID"].ToString() + " and b.intschool=" + Session["SchoolID"].ToString();
                    ds = da.ExceuteSql(str);
                    dgadmissionattendance.DataSource = ds;
                    dgadmissionattendance.DataBind();
                }
                else
                {
                    str = "select b.intid, b.intid as intapplication,b.str_standard as strstandard,b.str_firstname+' '+str_middlename+' '+str_lastname as name,'Null' as strattendance from tbladmissioninterview a,tblstudentadmission b where a.strstandard=b.str_standard and b.intwaitlist=1 and b.intid>=a.intfromappl and b.intid<=a.inttoappl and b.str_standard='" + ddlstandard.SelectedValue + "' and a.intschool=" + Session["SchoolID"].ToString();
                    ds = da.ExceuteSql(str);
                    dgadmissionattendance.DataSource = ds;
                    dgadmissionattendance.DataBind();
                }
            }
        }
    }
    protected void ddlstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        //clear();
        fillgrid();
        dgadmissionattendance.Visible = true;
    }
    protected void ddllist_SelectedIndexChanged(object sender, EventArgs e)
    {
        trstandard.Visible = false;
        dgadmissionattendance.Visible = false;
        date();
    }
    protected void dgadmissionattendance_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                DataRowView dr = (DataRowView)e.Item.DataItem;
                CheckBox chkapprove = (CheckBox)e.Item.FindControl("chklist");
                string atten = dr["strattendance"].ToString();
                if (e.Item.Cells[4].Text == "Present")
                {
                    chkapprove.Checked = true;
                }
                else
                {
                    chkapprove.Checked = false;
                }
            }

        }
        catch { }
    }
    protected void ddldate_SelectedIndexChanged(object sender, EventArgs e)
    {
        time();
        trstandard.Visible = false;
    }
    protected void ddltime_SelectedIndexChanged(object sender, EventArgs e)
    {
        filldetails();
        standard();
        trstandard.Visible = true;
    }
    protected void ddlfloor_SelectedIndexChanged(object sender, EventArgs e)
    {
        roomno();
        trstandard.Visible = false;
    }
    protected void ddlroom_SelectedIndexChanged(object sender, EventArgs e)
    {
        filldetails();
        standard();
        trstandard.Visible = true;
        dgadmissionattendance.Visible = true;
        fillgrid();
    }
    protected void ddlbuildname_SelectedIndexChanged(object sender, EventArgs e)
    {
        floor();
        roomno();
    }
    protected void RBsY_CheckedChanged(object sender, EventArgs e)
    {
        if (RBsY.Checked)
        {
            trbuilding.Visible = true;
            trfloor.Visible = true;
            trroom.Visible = true;
        }
    }
    protected void RBsN_CheckedChanged(object sender, EventArgs e)
    {
        if (RBsN.Checked)
        {
            trbuilding.Visible = false;
            trfloor.Visible = false;
            trroom.Visible = false;
        }
    }
}
