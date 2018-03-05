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

public partial class communication_inbox : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            fillgrid();
        }
    }
    protected void fillgrid()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str="";
        if (Request["im"].ToString() == "1")
            str = "select intid,convert(varchar(10),dtdate,111) as dtdate,strsubject,intreceiverid,strpatrontype from tblmailbox where intschool= " + Session["SchoolID"].ToString() + " and intreceiverid=" + Session["UserID"].ToString() + " and intviewed<>2 order by dtdate desc";
        if (Request["im"].ToString() == "2")
            str = "select intid,convert(varchar(10),dtdate,111) as dtdate,strsubject,intreceiverid,strpatrontype from tblmailbox where intschool= " + Session["SchoolID"].ToString() + " and intsenderid=" + Session["UserID"].ToString() + " and intviewed<>2 order by dtdate desc";
        if (Request["im"].ToString() == "3")
            str = "select intid,convert(varchar(10),dtdate,111) as dtdate,strsubject,intreceiverid,strpatrontype from tblmailbox where intschool= " + Session["SchoolID"].ToString() + " and intviewed=2 order by dtdate desc";
        ds = da.ExceuteSql(str);
        dginboxmail.DataSource = ds;
        dginboxmail.DataBind();
        dginboxmail.Columns[4].Visible = false;
        dginboxmail.Columns[5].Visible = false;
       
      
        if (Request["im"].ToString() == "1")
        {
            
           
            dginboxmail.Columns[4].Visible = true;
            dginboxmail.Columns[5].Visible = true;
            lblheading.Text = "Inbox()";
            headerlable1.InnerText = "Inbox Mails";
            da = new DataAccess();
            str = "select(select count(*) from(select * from tblmailbox where intreceiverid='" + Session["UserID"].ToString() + "' and intviewed = 0) as a) as unreadcount from tblmailbox where intschool=" + Session["SchoolID"] + " and intreceiverid='" + Session["UserID"].ToString() + "'";
            ds = new DataSet();
            ds = da.ExceuteSql(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblheading.Text = "Inbox("+ds.Tables[0].Rows[0]["unreadcount"].ToString()+")";
            }

        }
        if (Request["im"].ToString() == "2")
        {
            dginboxmail.Columns[4].Visible = true;
            dginboxmail.Columns[5].Visible = true;
            lblheading.Text = "Sent Mails";
            headerlable1.InnerText = "Sent Mails";
            lblunreadcount.Visible = false;
        }
        if (Request["im"].ToString() == "3")
        {
            //dginboxmail.Columns[4].Visible = true;
            dginboxmail.Columns[4].Visible = true;
           
            lblheading.Text = "Deleted Mails";
            headerlable1.InnerText = "Deleted Mails";
            lblunreadcount.Visible = false;
        }
    }

    protected void dginboxmail_EditCommand(object source, DataGridCommandEventArgs e)
    {
        if (Request["im"].ToString() == "1")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "update tblmailbox set intviewed=1 where intid=" + e.Item.Cells[0].Text;
            Functions.UserLogs(Session["UserID"].ToString(), "tblmailbox", e.Item.Cells[0].Text, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),276 );

            ds = da.ExceuteSql(str);
            Response.Redirect("viewinbox.aspx?lid=" + e.Item.Cells[0].Text);
        }
        else if (Request["im"].ToString() == "2")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select strpatrontype from tblmailbox where intsenderid=" + Session["Userid"].ToString() + " and intid=" + e.Item.Cells[0].Text;
            ds = da.ExceuteSql(str);
            Response.Redirect("viewinbox.aspx?lid=" + e.Item.Cells[0].Text);
        }
        else
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "update tblmailbox set intviewed=2 where intid=" + e.Item.Cells[0].Text;
            Functions.UserLogs(Session["UserID"].ToString(), "tblmailbox", e.Item.Cells[0].Text, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),276 );

            ds = da.ExceuteSql(str);
            Response.Redirect("viewinbox.aspx?lid=" + e.Item.Cells[0].Text);
        }
    }
   
    protected void btndelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton delete = (ImageButton)sender;
        TableCell cell = delete.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str = "update tblmailbox set intviewed=2 where intid=" + item.Cells[0].Text;
        Functions.UserLogs(Session["UserID"].ToString(), "tblmailbox", item.Cells[0].Text, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),276 );

        ds = da.ExceuteSql(str);
        fillgrid();
    }
}
