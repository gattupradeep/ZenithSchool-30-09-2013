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

public partial class admission_View_assigned_room_date : System.Web.UI.Page
{
   protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["lid"] != null)
                filldetails();
            trbuilding.Visible = false;
            trroom.Visible = false;
        }
    }
   protected void filldetails()
   {
       DataAccess da = new DataAccess();
       DataSet ds = new DataSet();
       if (lblbuild.Visible == true)
       {
           string str = " select a.intid,convert(varchar(10),a.dtdate,103) as dtdate,a.dttime,a.strbuildingname,a.strfloor,a.strroomname,a.intstaff,a.strstandard,a.intfromappl,a.inttoappl,c.strfirstname+' '+c.strmiddlename+' '+c.strlastname as name from tbladmissioninterview a,tblemployee c,tblstudentadmission d where a.intstaff=c.intid and a.intschool=" + Session["SchoolID"].ToString() + " and a.intid=" + Request["lid"].ToString();
           ds = new DataSet();
           ds = da.ExceuteSql(str);
           if (ds.Tables[0].Rows.Count > 0)
           {
               lbldate.Text = ds.Tables[0].Rows[0]["dtdate"].ToString();
               lbltime.Text = ds.Tables[0].Rows[0]["dttime"].ToString();
               lblbuild.Text = ds.Tables[0].Rows[0]["strbuildingname"].ToString();
               lblfloor.Text = ds.Tables[0].Rows[0]["strfloor"].ToString();
               lblroom.Text = ds.Tables[0].Rows[0]["strroomname"].ToString();
               lblstandard.Text = ds.Tables[0].Rows[0]["strstandard"].ToString();
               lblfrom.Text = ds.Tables[0].Rows[0]["intfromappl"].ToString();
               lblto.Text = ds.Tables[0].Rows[0]["inttoappl"].ToString();
               lblstaff.Text = ds.Tables[0].Rows[0]["name"].ToString();
               trbuilding.Visible = true;
               trroom.Visible = true;
           }
       }
       else
       {
           string str = " select a.intid,convert(varchar(10),a.dtdate,103) as dtdate,a.dttime,a.intstaff,a.strstandard,a.intfromappl,a.inttoappl,c.strfirstname+' '+c.strmiddlename+' '+c.strlastname as name from tbladmissioninterview a,tblemployee c,tblstudentadmission d where a.intstaff=c.intid and a.intschool=" + Session["SchoolID"].ToString() + " and a.intid=" + Request["lid"].ToString();
           ds = new DataSet();
           ds = da.ExceuteSql(str);
           if (ds.Tables[0].Rows.Count > 0)
           {
               lbldate.Text = ds.Tables[0].Rows[0]["dtdate"].ToString();
               lbltime.Text = ds.Tables[0].Rows[0]["dttime"].ToString();
               lblstandard.Text = ds.Tables[0].Rows[0]["strstandard"].ToString();
               lblfrom.Text = ds.Tables[0].Rows[0]["intfromappl"].ToString();
               lblto.Text = ds.Tables[0].Rows[0]["inttoappl"].ToString();
               lblstaff.Text = ds.Tables[0].Rows[0]["name"].ToString();
               trbuilding.Visible = false;
               trroom.Visible = false;
           }
       }
   }
   protected void btnback_Click(object sender, EventArgs e)
   {
       Response.Redirect("viewassignedroom_date.aspx?lid");
   }
}
