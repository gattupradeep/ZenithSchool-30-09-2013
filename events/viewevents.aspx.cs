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

public partial class events_viewevents : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            filleventtype();
            fillgrid();
           
            if (Session["PatronType"] == "Students" || Session["PatronType"] == "Parents" || Session["PatronType"].ToString() == "Teaching Staffs")
            {
                trsidemenu.Visible = false;
            }
        }
    }
    private void fillgrid()
    {
        DataAccess da = new DataAccess();
        string sql = "";
        //sql = "select convert(varchar(10),a.event_start,103) as event_start, convert(varchar(10),a.event_end,103) as event_end,a.title,b.streventtype  from tblevents a,tbleventtype b where b.intid=a.event_id and a.intschool=" + Session["schoolID"].ToString();

        //if (ddleventtype.SelectedIndex>0)
        //{
           // sql = "select convert(varchar(10),a.event_start,103) as event_start, convert(varchar(10),a.event_end,103) as event_end,a.title,b.streventtype  from tblevents a,tbleventtype b where b.intid=a.event_id and a.event_id='" + ddleventtype.SelectedValue + "' and intschool=" + Session["schoolID"].ToString();
       // }

        sql = "select a.event_id ,a.title,a.description,b.intid, convert(varchar(10),a.event_start,103) as event_start,convert(varchar(10),a.event_end,103) as event_end from tblevents a,tbleventtype b";

        sql += "  where a.title=b.streventtype and a.intschool=2 ";

        if (ddleventtype.SelectedIndex > 0)
            sql += " and b.intid =" + ddleventtype.SelectedValue;
       
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        dgevents.DataSource = ds;
        dgevents.DataBind();
    }
    protected void filleventtype()
    {
        DataAccess da = new DataAccess();
        string sql = "select * from tbleventtype where intschool='" + Session["schoolID"].ToString() + "'";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        ddleventtype.DataSource = ds;
        ddleventtype.DataTextField = "streventtype";
        ddleventtype.DataValueField = "intid";
        ddleventtype.DataBind();
        ListItem list = new ListItem("--Select--", "0");
        ddleventtype.Items.Insert(0, list);
    }
    protected void ddleventtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid();
    }
}
