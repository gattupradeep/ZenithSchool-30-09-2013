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

public partial class student_Approve_RejectWithdrawal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtdate.Text = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            fillgrid();
            trtag.Visible = false;
        }
    }    
    protected void fillgrid()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str = "select a.*,b.intadmitno,b.strfirstname+' '+b.strmiddlename+' '+b.strlastname as name,convert(varchar(11),a.dt_dateOf_TCissued,103) as tcissued,convert(varchar(11),a.dt_dateOf_studentleft,103) as dtleft,'Waiting for approval' as status from tblstudentwithdrawal a,tblstudent b where a.int_studentid=b.intid and a.intschool=" + Session["SchoolID"].ToString() + " and a.dt_dateOf_requestOfwithdrawal=convert(datetime,'" + txtdate.Text.Trim() + "',103) and a.intapprove=0";
        str = str + " union all  select a.*,b.intadmitno,b.strfirstname+' '+b.strmiddlename+' '+b.strlastname as name,convert(varchar(11),a.dt_dateOf_TCissued,103) as tcissued,convert(varchar(11),a.dt_dateOf_studentleft,103) as dtleft,'Approved' as status  from tblstudentwithdrawal a,tblstudent b   where a.int_studentid=b.intid and a.intschool=" + Session["SchoolID"].ToString() + " and a.dt_dateOf_requestOfwithdrawal=convert(datetime,'" + txtdate.Text.Trim() + "',103) and a.intapprove=1";
        str = str + " union all  select a.*,b.intadmitno,b.strfirstname+' '+b.strmiddlename+' '+b.strlastname as name,convert(varchar(11),a.dt_dateOf_TCissued,103) as tcissued,convert(varchar(11),a.dt_dateOf_studentleft,103) as dtleft,'Rejected' as status  from tblstudentwithdrawal a,tblstudent b   where a.int_studentid=b.intid and a.intschool=" + Session["SchoolID"].ToString() + " and a.dt_dateOf_requestOfwithdrawal=convert(datetime,'" + txtdate.Text.Trim() + "',103) and a.intapprove=2";            
            
        ds = da.ExceuteSql(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dgwithdrawal.DataSource = ds;
            dgwithdrawal.DataBind();
            dgwithdrawal.Visible = true;
        }
        else
        {
            dgwithdrawal.Visible = false;
        }
    }
    protected void dgwithdrawal_EditCommand(object source, DataGridCommandEventArgs e)
    {
        DateTime dt = DateTime.Now;
        string st = string.Format("{0:yy }", dt);
        int tcno = int.Parse(st);
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str = "select max(str_TcNumber) as tcno from tblstudentwithdrawal where intschool=" + Session["SchoolID"].ToString();
        ds = da.ExceuteSql(str);
        int tc =0;
        if(ds.Tables[0].Rows.Count > 0)
           tc = int.Parse(ds.Tables[0].Rows[0]["tcno"].ToString());
        if(tc==0)
            str = "update tblstudentwithdrawal set intapprove=1,str_TcNumber="+DateTime.Now.Day.ToString()+""+DateTime.Now.Month.ToString()+""+tcno+ " where intid=" + e.Item.Cells[0].Text + " and intschool=" + Session["SchoolID"].ToString();
        else
            str = "update tblstudentwithdrawal set intapprove=1,str_TcNumber=" + (tc+1) + " where intid=" + e.Item.Cells[0].Text + " and intschool=" + Session["SchoolID"].ToString();
           da.ExceuteSqlQuery(str);
        Functions.UserLogs(Session["UserID"].ToString(), "tblstudentwithdrawal", e.Item.Cells[0].Text, "Approved", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 281);
        str = "update tblstudent set intTransferredID=1 where intadmitno='" + e.Item.Cells[1].Text + "'";
        da.ExceuteSqlQuery(str);
        Functions.UserLogs(Session["UserID"].ToString(), "tblstudent", e.Item.Cells[0].Text, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 281);

        fillgrid();
    }
    protected void dgwithdrawal_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        msgbox.alert("Please fill reason and click submit");
        trtag.Visible = true;
        hdnfld.Value = e.Item.Cells[0].Text;
    }    
    protected void txtdate_TextChanged(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void dgwithdrawal_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.Cells[6].Text == "Waiting for approval")
        {
            e.Item.Cells[7].Enabled = true;
            e.Item.Cells[8].Enabled = true;
        }
        if (e.Item.Cells[6].Text == "Approved")
        {
            e.Item.Cells[7].Enabled = false;
            e.Item.Cells[8].Enabled = false;
        }
        if (e.Item.Cells[6].Text == "Rejected")
        {
            e.Item.Cells[7].Enabled = false;
            e.Item.Cells[8].Enabled = false;
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str = "update tblstudentwithdrawal set intapprove=2,str_ReasonForRejecting='" + txtreason.Text.Trim() + "' where intid=" + hdnfld.Value + " and intschool=" + Session["SchoolID"].ToString();
        da.ExceuteSqlQuery(str);
        Functions.UserLogs(Session["UserID"].ToString(), "tblstudentwithdrawal", hdnfld.Value, "Rejected", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 281);
        fillgrid();
        trtag.Visible = false;
    }
}
