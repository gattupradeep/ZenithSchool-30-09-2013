using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class timetable_setlanguage : System.Web.UI.Page
{
    public string str;
    public DataSet ds, ds1;
    public DataAccess da, da1;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            fillsecondgrid();
    }

    protected void fillsecondgrid()
    {
        DataAccess da = new DataAccess();
        string str;
        DataSet ds, ds1 = new DataSet();
        da = new DataAccess();
        str = "select strteacher,strlanguage as strlanguage2,strstandard1 as strstandard,strsection1 as strsection from tbltimetable2 where intschool='" + Session["SchoolID"].ToString() + "' and strstandard='" + Session["2ndlangstandard"].ToString() + "' and strsection='" + Session["2ndlangsection"].ToString() + "' and strday='" + Session["2ndlangday"].ToString() + "' and strperiod='" + Session["2ndlangperiod"].ToString() + "'";
        ds = new DataSet();
        ds = da.ExceuteSql(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            btnupdate.Text = "Update";
        }
        else
        {
            str = "select  0 as strteacher,strsecondlanguage as strlanguage2,'' as strstandard,'' as strsection from tblstudent where strstandard + ' - ' + strsection = '" + Session["setlangclass"].ToString() + "' and intschool=" + Session["SchoolID"].ToString() + " group by strsecondlanguage";
            //str = str + "union all select  0 as strteacher,strthirdlanguage as strlanguage2,'' as strstandard,'' as strsection from tblstudent where strstandard + ' - ' + strsection = '" + Session["setlangclass"].ToString() + "' and intschool=" + Session["SchoolID"].ToString() + " group by strsecondlanguage";
            ds = new DataSet();
            ds = da.ExceuteSql(str);
            btnupdate.Text = "Save";
        }
        dg2.DataSource = ds;
        dg2.DataBind();

        lbltitle.Text = Session["2ndlangstandard"].ToString() + " " + Session["2ndlangsection"].ToString() + " - " + Session["2ndlangday"].ToString() + " - " + Session["2ndlangperiod"].ToString();
    }

    protected void dg2_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        try
        {
            DataRowView dr = (DataRowView)e.Item.DataItem;
            string strsql;
            DropDownList ddlsec = (DropDownList)e.Item.FindControl("ddlsection");
            DropDownList ddltech = (DropDownList)e.Item.FindControl("ddlteacher");

            DataAccess da2 = new DataAccess();
            DataSet ds2 = new DataSet();

            strsql = "select strsection from tblstandard_section_subject where intschoolid=" + Session["SchoolID"].ToString()+" group by strsection";
            da2 = new DataAccess();
            ds2 = new DataSet();
            ds2 = da2.ExceuteSql(strsql);
            ddlsec.DataSource = ds2;
            ddlsec.DataTextField = "strsection";
            ddlsec.DataValueField = "strsection";
            ddlsec.DataBind();

            strsql = "select 'None' as teachername,-1 as intid union all select strfirstname+' ' + strmiddlename +' '+strlastname as teachername,intID from tblemployee where intschool=" + Session["SchoolID"].ToString() + " and intid in(select intemployee from tblteachingsubjects where strteachsubject='Language' and intschool=" + Session["SchoolID"].ToString() + " group by intemployee) and  intid not in( select strteacher from tbltimetable2 where strday='" + Session["2ndlangday"].ToString() + "' and strperiod='" + Session["2ndlangperiod"].ToString() + "' and strstandard+strsection<>'" + Session["2ndlangstandard"].ToString() + Session["2ndlangsection"].ToString() + "'  and intschool=" + Session["SchoolID"].ToString() + ") union all select 'Shift Teacher' as teachername,0 as intid";
            da2 = new DataAccess();
            ds2 = new DataSet();
            ds2 = da2.ExceuteSql(strsql);
            ddltech.DataSource = ds2;
            ddltech.DataTextField = "teachername";
            ddltech.DataValueField = "intid";
            ddltech.DataBind();

            if (btnupdate.Text == "Update")
            {
                ddlsec.SelectedValue = dr["strsection"].ToString();
                ddltech.SelectedValue = dr["strteacher"].ToString();
            }
        }
        catch { }
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        int interror=0;
        for (int j = 0; j < dg2.Items.Count; j++)
        {
            DataGridItem dgi = dg2.Items[j];
            DropDownList ddlsec = (DropDownList)dg2.Items[j].FindControl("ddlsection");
            DropDownList ddltech = (DropDownList)dg2.Items[j].FindControl("ddlteacher");
            for (int j1 = j + 1; j1 < dg2.Items.Count; j1++)
            {
                DataGridItem dgi1 = dg2.Items[j1];
                DropDownList ddlsec1 = (DropDownList)dg2.Items[j1].FindControl("ddlsection");
                DropDownList ddltech1 = (DropDownList)dg2.Items[j1].FindControl("ddlteacher");
                if (ddltech.SelectedValue == ddltech1.SelectedValue)
                    interror = 1;
            }
        }
        if (interror == 0)
        {
            da = new DataAccess();
            ds = new DataSet();
            str = "select intid from tbltimetable2 where intschool='" + Session["SchoolID"].ToString() + "' and strstandard='" + Session["2ndlangstandard"].ToString() + "' and strsection='" + Session["2ndlangsection"].ToString() + "' and strday='" + Session["2ndlangday"].ToString() + "' and strperiod='" + Session["2ndlangperiod"].ToString() + "'";
            ds = da.ExceuteSql(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Functions.UserLogs(Session["UserID"].ToString(), "tbltimetable2", ds.Tables[0].Rows[i]["intid"].ToString(), "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 62);

                }
            }
            da = new DataAccess();
            str = "delete tbltimetable2 where intschool='" + Session["SchoolID"].ToString() + "' and strstandard='" + Session["2ndlangstandard"].ToString() + "' and strsection='" + Session["2ndlangsection"].ToString() + "' and strday='" + Session["2ndlangday"].ToString() + "' and strperiod='" + Session["2ndlangperiod"].ToString() + "'";
            da.ExceuteSqlQuery(str);

            for (int j = 0; j < dg2.Items.Count; j++)
            {
                DataGridItem dgi = dg2.Items[j];

                DropDownList ddlsec = (DropDownList)dg2.Items[j].FindControl("ddlsection");
                DropDownList ddltech = (DropDownList)dg2.Items[j].FindControl("ddlteacher");

                str = "insert into tbltimetable2(strstandard,strsection,strday,strperiod,strlanguage,strteacher,strstandard1,strsection1,intschool)";
                str = str + "values('" + Session["2ndlangstandard"].ToString() + "','" + Session["2ndlangsection"].ToString() + "',";
                str = str + "'" + Session["2ndlangday"].ToString() + "','" + Session["2ndlangperiod"].ToString() + "','" + dgi.Cells[1].Text + "',";
                str = str + "'" + ddltech.SelectedValue + "','" + Session["2ndlangstandard"].ToString() + "','" + ddlsec.SelectedValue + "'," + Session["SchoolID"].ToString() + ")";
                da = new DataAccess();
                da.ExceuteSqlQuery(str);

                DataSet ds2 = new DataSet();
                str = "select max(intid) as intid from tbltimetable2";
                ds2 = da.ExceuteSql(str);
                Functions.UserLogs(Session["UserID"].ToString(), "tbltimetable2", ds2.Tables[0].Rows[0]["intid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),62);
            }
            ClientScript.RegisterStartupScript(this.GetType(), "OpenWin1", "<script>self.close()</script>");
        }
        else
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Same teacher cannont be assigned for two Languages')", true);
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(this.GetType(), "OpenWin1", "<script>self.close()</script>");
    }
 }
