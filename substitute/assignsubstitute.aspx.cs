﻿using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class substitute_assignsubstitute : System.Web.UI.Page
{
    public DataAccess da,da1;
    public DataSet ds,ds1;
    public string strsql;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            fillgrid();
    }

    protected void fillgrid()
    {
        da = new DataAccess();
        strsql = "select a.* from(select '' as serialno, strtittle + ' ' + strfirstname + ' ' + strmiddlename + ' ' + strlastname as strstaffname,datename(dw,dtdate)as strday,convert(varchar(10),dtdate,103) as strleavedate,convert(varchar(10),dtdate,101) as strleavedate1,b.*,'' as teachingclass,'' as teachingsubject, 'Not Assigned' as status from tblstaffattendance b, tblemployee c where  c.strtype='Teaching Staffs' and b.intstaff=c.intid and cast(convert(varchar(10),dtdate,101) as datetime)>=cast(convert(varchar(10),getdate(),101) as datetime) and b.intschool=" + Session["SchoolID"].ToString() + ") as a,(select strday,strteacher from tbltimetable where intschool=" + Session["SchoolID"].ToString() + " and strsubject not like '%Language' and strsubject !='Language' and strsubject!='Extra Activities' group by strday,strteacher union all select strday,strteacher from tbltimetable2 where intschool=" + Session["SchoolID"].ToString() + " group by strday,strteacher union all select strday,strteacher from tbltimetable3 where intschool=" + Session["SchoolID"].ToString() + " group by strday,strteacher) as b where a.intstaff=b.strteacher and a.strday=b.strday ";
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            strsql = "select strclass from (";
            strsql = strsql + "select strstandard + ' - ' + strsection as strclass,strsubject,strperiod from tbltimetable ";
            strsql = strsql + "where strsubject not like '%Language' and strsubject != 'Extra Activities' and strperiod not like '%Interval' ";
            strsql = strsql + "and strteacher=" + ds.Tables[0].Rows[i]["intstaff"].ToString() + " and ";
            strsql = strsql + "strday='" + ds.Tables[0].Rows[i]["strday"].ToString() + "' union all ";
            strsql = strsql + "select strstandard1 + ' - ' + strsection1 as strclass,strlanguage as strsubject,strperiod from tbltimetable2 ";
            strsql = strsql + "where strteacher=" + ds.Tables[0].Rows[i]["intstaff"].ToString() + " and strday='" + ds.Tables[0].Rows[i]["strday"].ToString() + "' union all ";
            strsql = strsql + "select strstandard + ' - ' + strsection as strclass,strlanguage as strsubject,strperiod from tbltimetable3 ";
            strsql = strsql + "where strteacher=" + ds.Tables[0].Rows[i]["intstaff"].ToString() + " and strday='" + ds.Tables[0].Rows[i]["strday"].ToString() + "') as a group by strclass";

            da1 = new DataAccess();
            ds1 = new DataSet();
            ds1 = da1.ExceuteSql(strsql);
            string strteachingclass = "";
            for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
            {
                if (strteachingclass == "")
                    strteachingclass = ds1.Tables[0].Rows[j]["strclass"].ToString();
                else
                    strteachingclass = strteachingclass + ", " + ds1.Tables[0].Rows[j]["strclass"].ToString();
            }

            ds.Tables[0].Rows[i]["teachingclass"] = strteachingclass;

            strsql = "select strsubject from (";
            strsql = strsql + "select strstandard + ' - ' + strsection as strclass,strsubject,strperiod from tbltimetable ";
            strsql = strsql + "where strsubject not like '%Language' and strsubject != 'Extra Activities' and strperiod not like '%Interval' ";
            strsql = strsql + "and strteacher=" + ds.Tables[0].Rows[i]["intstaff"].ToString() + " and ";
            strsql = strsql + "strday='" + ds.Tables[0].Rows[i]["strday"].ToString() + "' union all ";
            strsql = strsql + "select strstandard1 + ' - ' + strsection1 as strclass,strlanguage as strsubject,strperiod from tbltimetable2 ";
            strsql = strsql + "where strteacher=" + ds.Tables[0].Rows[i]["intstaff"].ToString() + " and strday='" + ds.Tables[0].Rows[i]["strday"].ToString() + "' union all ";
            strsql = strsql + "select strstandard + ' - ' + strsection as strclass,strlanguage as strsubject,strperiod from tbltimetable3 ";
            strsql = strsql + "where strteacher=" + ds.Tables[0].Rows[i]["intstaff"].ToString() + " and strday='" + ds.Tables[0].Rows[i]["strday"].ToString() + "') as a group by strsubject";
            da1 = new DataAccess();
            ds1 = new DataSet();
            ds1 = da1.ExceuteSql(strsql);
            string strteachingsubject = "";
            for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
            {
                if (strteachingsubject == "")
                    strteachingsubject = ds1.Tables[0].Rows[j]["strsubject"].ToString();
                else
                    strteachingsubject = strteachingsubject + ", " + ds1.Tables[0].Rows[j]["strsubject"].ToString();
            }
            ds.Tables[0].Rows[i]["teachingsubject"] = strteachingsubject;

            strsql = "select * from tblsubstitutetimetable where strteacher>0 and intstaff=" + ds.Tables[0].Rows[i]["intstaff"].ToString() + " and dtdate='" + ds.Tables[0].Rows[i]["strleavedate1"].ToString() + "'";
            da1 = new DataAccess();
            ds1 = new DataSet();
            ds1 = da1.ExceuteSql(strsql);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                strsql = "select * from tblsubstitutetimetable where strteacher<1 and intstaff=" + ds.Tables[0].Rows[i]["intstaff"].ToString() + " and dtdate='" + ds.Tables[0].Rows[i]["strleavedate1"].ToString() + "'";
                da1 = new DataAccess();
                ds1 = new DataSet();
                ds1 = da1.ExceuteSql(strsql);
                if (ds1.Tables[0].Rows.Count > 0)
                    ds.Tables[0].Rows[i]["status"] = "Not Completely Assigned";
                else
                    ds.Tables[0].Rows[i]["status"] = "Assigned";
            }

            ds.Tables[0].Rows[i]["serialno"] = (i + 1).ToString();
        }
        dgassignstaff.DataSource = ds;
        dgassignstaff.DataBind();
    }

    protected void dgassignstaff_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        try
        {
            DataRowView dr = (DataRowView)e.Item.DataItem;
            Button btnassign = (Button)e.Item.FindControl("btnassign");
            if (dr["status"].ToString() == "Not Assigned")
            {
                e.Item.BackColor = System.Drawing.ColorTranslator.FromHtml("#4F6228");
            }
            if (dr["status"].ToString() == "Not Completely Assigned")
            {
                e.Item.BackColor = System.Drawing.ColorTranslator.FromHtml("#C2D69B");
            }
            if (dr["status"].ToString() == "Assigned")
            {
                e.Item.BackColor = System.Drawing.ColorTranslator.FromHtml("#9BBB59");
                btnassign.Text = "Edit";
            }
        }
        catch { }
    }

    protected void btnassign_Click(object sender, EventArgs e)
    {
        Button view = (Button)sender;
        TableCell cell = view.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        Response.Redirect("assigneditsubstitute.aspx?sid="+item.Cells[0].Text);
    }
}