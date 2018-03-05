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

public partial class school_viewschooldetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["PatronType"].ToString() != "Admin" && Session["PatronType"].ToString() != "Super Admin")
                btnedit.Visible = false;
        }
        catch
        {
            Response.Redirect("../login.aspx");
        }
        if (!IsPostBack)
        {
            setnext();
            filldetails();
        }        
    }

    protected void btnedit_Click(object sender, EventArgs e)
    {
        Response.Redirect("schooldetails.aspx?sid=" + Session["SchoolID"]);
    }

    protected void setnext()
    {
        string sql = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();
        
        sql = "select * from tblschooldetails where intschoolid=" + Session["SchoolID"].ToString();
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
        }
        else
            Response.Redirect("../school/schooldetails.aspx");
    }

    protected void filldetails()
    {
        string sql = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();

        try
        {
            sql = "select a.*,strcountryname,strstate,strcity,strboardname,convert(varchar(10),dtaccyearstart,111) as dtstart,convert(varchar(10),dtaccyearend,111) as dtend from tblschooldetails a, tblcountry c,tblstate d, tblcity e,tblboard f where a.intcountryid=c.intcountryID and a.intstateid=d.intstateid and a.intcityid=e.intcityid and a.intboardid = f.intboardid and a.intschoolid=" + Session["SchoolID"].ToString();
            ds = da.ExceuteSql(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblbranch.Text = ds.Tables[0].Rows[0]["strbranch"].ToString();
                lblschoolname.Text = ds.Tables[0].Rows[0]["strschoolname"].ToString();
                lblyear.Text = ds.Tables[0].Rows[0]["intyear"].ToString();
                lblboard.Text = ds.Tables[0].Rows[0]["strboardname"].ToString();
                lblyearstart.Text = ds.Tables[0].Rows[0]["dtstart"].ToString();
                lblyearend.Text = ds.Tables[0].Rows[0]["dtend"].ToString();
                lbladdress.Text = ds.Tables[0].Rows[0]["straddress"].ToString();
                lblcountry.Text = ds.Tables[0].Rows[0]["strcountryname"].ToString();
                lblstate.Text = ds.Tables[0].Rows[0]["strstate"].ToString();
                lblcity.Text = ds.Tables[0].Rows[0]["strcity"].ToString();
                lblpincode.Text = ds.Tables[0].Rows[0]["strpincode"].ToString();
                lblphone.Text = ds.Tables[0].Rows[0]["strcountrycode"].ToString() + ds.Tables[0].Rows[0]["strcitycode"].ToString() + ds.Tables[0].Rows[0]["strphone"].ToString();
                lblemail.Text = ds.Tables[0].Rows[0]["stremail"].ToString();
                lblfax.Text = ds.Tables[0].Rows[0]["strfax"].ToString();
                lblwebsite.Text = ds.Tables[0].Rows[0]["strwebsite"].ToString();
                if (int.Parse(ds.Tables[0].Rows[0]["inttransport"].ToString()) == 1)
                    lbltransport.Text = "Available";
                else
                    lbltransport.Text = "Not available";
                if (int.Parse(ds.Tables[0].Rows[0]["inthostelfecility"].ToString()) == 1)
                    lblhostel.Text = "Available";
                else
                    lblhostel.Text = "Not available";
                if (int.Parse(ds.Tables[0].Rows[0]["intlibrary"].ToString()) == 1)
                    lbllibrary.Text = "Available";
                else
                    lbllibrary.Text = "Not available";

                //sql = "select * from tblschoolgroup where intschoolid=" + Session["SchoolID"].ToString();
                //ds = new DataSet();
                //ds = da.ExceuteSql(sql);
                //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //{
                //    if (lblgroups.Text == "")
                //    {
                //        lblgroups.Text = ds.Tables[0].Rows[i]["strschoolgroupname"].ToString();
                //    }
                //    else
                //    {
                //        lblgroups.Text = lblgroups.Text + ", " + ds.Tables[0].Rows[i]["strschoolgroupname"].ToString();
                //    }
                //}
                //fillhousenameandcolor();
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert(" + ex.Message + ")", true);
        } 
    }
    

    //protected void fillhousenameandcolor()
    //{
    //    DataAccess da = new DataAccess();
    //    string sql = "select strhousename from tblschoolhouse where intschoolid=" + Session["SchoolID"].ToString();
    //    DataSet ds = new DataSet();
    //    ds = da.ExceuteSql(sql);
    //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //    {
    //        if (lblhousenames.Text == "")
    //        {
    //            lblhousenames.Text = ds.Tables[0].Rows[i]["strhousename"].ToString();
    //        }
    //        else
    //        {
    //            lblhousenames.Text = lblhousenames.Text + ", " + ds.Tables[0].Rows[i]["strhousename"].ToString();
    //        }
    //    }
    //}

}
