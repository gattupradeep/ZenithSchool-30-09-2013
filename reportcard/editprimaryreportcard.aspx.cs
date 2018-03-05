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

public partial class reportcard_editprimaryreportcard : System.Web.UI.Page
{
    public string strsql;
    public DataAccess da;
    public DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillstandard();
            ddlexamtype.Items.Insert(0, "--Select--");
            if (Request["hid"] != null)
            {

                if (Session["SearchStudentStandard"] != null)
                {
                    ddlstandard.SelectedValue = Session["SearchStudentStandard"].ToString();
                    fillbystandard();
                    fillgrid();
                }
                if (Session["SearchStudentExamtype"] != null)
                {
                    ddlexamtype.SelectedValue = Session["SearchStudentExamtype"].ToString();
                    fillbyexamtype();
                    fillgrid();
                }

            }
        }
    }
   
    protected void fillstandard()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str;
        str = "select strstandard from tblprimaryreportcard group by strstandard";
        ds = da.ExceuteSql(str);
        ddlstandard.DataSource = ds;
        ddlstandard.DataTextField = "strstandard";
        ddlstandard.DataValueField = "strstandard";
        ddlstandard.DataBind();
        ddlstandard.Items.Insert(0, "--Select--");
    }
    protected void fillteacher()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str;
        str = "select a.strfirstname+''+a.strmiddlename+''+a.strlastname as name,a.intid,b.inthometeacher from tblemployee a,tblprimaryreportcard b where a.intid=b.inthometeacher and b.strstandard='" + ddlstandard.SelectedValue + "' and a.intschool=" + Session["Schoolid"].ToString() + " group by a.strfirstname,a.strmiddlename,a.strlastname,a.intid,b.inthometeacher";
        ds = da.ExceuteSql(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblteacher.Text = ds.Tables[0].Rows[0]["name"].ToString();
        }
    }
    protected void fillexamtype()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str;
        str = "select a.strexamtype,a.intexamtypeid,b.intexamtype from tblexamtype a,tblprimaryreportcard b where a.intexamtypeid=b.intexamtype group by a.strexamtype,a.intexamtypeid,b.intexamtype";
        ds = da.ExceuteSql(str);
        ddlexamtype.DataSource = ds;
        ddlexamtype.DataTextField = "strexamtype";
        ddlexamtype.DataValueField = "intexamtype";
        ddlexamtype.DataBind();
        ddlexamtype.Items.Insert(0, "--Select--");
    }

   protected void ddlstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillteacher();
        fillexamtype();
        fillbystandard();
        //fillgrid();
    }
   protected void fillbystandard()
   {
       if (ddlstandard.SelectedIndex > 0)
       {
           fillgrid();
           fillteacher();
           fillexamtype();
       }
       else
       {
           ddlexamtype.Items.Clear();
           ddlexamtype.Items.Insert(0, "--Select--");
           fillgrid();
       }
       Session["SearchStudentStandard"] = ddlstandard.SelectedValue;
   }
   protected void fillbyexamtype()
   {
       if (ddlstandard.SelectedIndex > 0)
       {
           fillgrid();

       }
       else
       {

           fillgrid();
       }
       Session["SearchStudentExamtype"] = ddlexamtype.SelectedValue;
   }
   protected void fillgrid()
    {
        string str;
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        str = "select a.strfirstname+''+a.strmiddlename+''+a.strlastname as name,b.intstudent,b.stradmissionno,b.intexamtype,b.inthometeacher from tblstudent a,tblprimaryreportcard b where b.strstandard='" + ddlstandard.SelectedValue + "' and b.intstudent=a.intid and a.intschool=" + Session["Schoolid"].ToString();
        if (ddlexamtype.SelectedIndex > 0)
        {
            str = str + " and b.intexamtype='" + ddlexamtype.SelectedValue + "'";
        }
        str = str + " group by a.strfirstname,a.strmiddlename,a.strlastname,b.intstudent,b.stradmissionno,b.intexamtype,b.inthometeacher";
        ds = da.ExceuteSql(str);
        dgstudent.DataSource = ds;
        dgstudent.DataBind();
    }
   protected void dgstudent_EditCommand(object source, DataGridCommandEventArgs e)
   {
       Response.Redirect("Primaryreportcard.aspx?hid=" + e.Item.Cells[0].Text + "&hid3='" + e.Item.Cells[2].Text + "'&hid1=" + e.Item.Cells[3].Text + "&hid2=" + e.Item.Cells[4].Text);
   }
   protected void ddlexamtype_SelectedIndexChanged(object sender, EventArgs e)
   {
       fillbyexamtype();
       fillgrid();
   }
   protected void dgstudent_UpdateCommand(object source, DataGridCommandEventArgs e)
   {
       Response.Redirect("viewprimaryreportcard.aspx?hid=" + e.Item.Cells[0].Text + "&hid3='" + e.Item.Cells[2].Text + "'&hid1=" + e.Item.Cells[3].Text + "&hid2=" + e.Item.Cells[4].Text + " &rd=2&sbackto=1");
   }
   protected void btndelete_Click(object sender, ImageClickEventArgs e)
   {
       ImageButton delete = (ImageButton)sender;
       TableCell cell = delete.Parent as TableCell;
       DataGridItem item = cell.Parent as DataGridItem;
       DataAccess da = new DataAccess();

       strsql = "select intreportid from tblprimaryreportcard where intstudent=" + item.Cells[0].Text + " and intexamtype=" + ddlexamtype.SelectedValue;
       ds = da.ExceuteSql(strsql);
       if (ds.Tables[0].Rows.Count > 0)
       {
           for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
           {
               Functions.UserLogs(Session["UserID"].ToString(), "tblprimaryreportcard", ds.Tables[0].Rows[i]["intreportid"].ToString(), "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),329);
           }
       }

       string sql = "delete tblprimaryreportcard where intstudent=" + item.Cells[0].Text +" and intexamtype=" +ddlexamtype.SelectedValue;
       da.ExceuteSqlQuery(sql);
       fillgrid();
   }
}
