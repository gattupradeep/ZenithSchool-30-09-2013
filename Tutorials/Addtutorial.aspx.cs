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

public partial class Tutorials_Addtutorial : System.Web.UI.Page
{
    public DataAccess da;
    public DataSet ds;
    public string strsql;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Page.Form.Attributes.Add("enctype", "multipart/form-data");
            if (Request.QueryString["Msg"] != null)
                ScriptManager.RegisterStartupScript(this, GetType(), "Alert", "alert('Details Saved Successfully'); ", true);
            if (Session["PatronType"].ToString() == "Teaching Staffs")
            {
                fillteacher();
                ddlteacher.SelectedValue = Session["UserID"].ToString();
                ddlteacher.Enabled = false;
                fillclass();
                fillsubject();
            }
            fillgrid();
            fillclass();
            ddlteacher.Items.Insert(0, "-Select-");
            ddlsubject.Items.Insert(0, "-Select-");
            ddltextbook.Items.Insert(0, "-Select-");
            ddlunit.Items.Insert(0, "-Select-");
            ddllesson.Items.Insert(0, "-Select-");
            txtdate.Text = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();

        }
        else
        {
            if (Session["PatronType"].ToString() == "Teaching Staffs")
            {
                //fillteacher();
                ddlteacher.SelectedValue = Session["UserID"].ToString();
                ddlteacher.Enabled = false;
                //fillclass();
                //fillsubject();
            }
        }
    }
    protected void fillclass()
    {
        da = new DataAccess();
        ds = new DataSet();
        if (Session["PatronType"].ToString() == "Teaching Staffs")
            strsql = "select class from (select strstandard+' - '+strsection as class from tbltimetable where strteacher=" + ddlteacher.SelectedValue + " and strsubject!='Language' and strsubject!='%Language' and strsubject!='Extra Activities' and intschool=" + Session["SchoolID"].ToString() + " union all select strstandard+' - '+strsection as class from tbltimetable2 where strteacher=" + ddlteacher.SelectedValue + " and intschool=" + Session["SchoolID"].ToString() + " union all select strstandard+' - '+strsection as class  from tbltimetable3 where strteacher=" + ddlteacher.SelectedValue + " and intschool=" + Session["SchoolID"].ToString() + " ) as a group by class ";
        else
            strsql = "select strstandard+' - '+strsection as class from tblstandard_section_subject where intschoolid=" + Session["SchoolID"] + " group by strstandard+' - '+strsection";
        ds = da.ExceuteSql(strsql);
        ddlclass.DataSource = ds;
        ddlclass.DataValueField = "class";
        ddlclass.DataTextField = "class";
        ddlclass.Items.Clear();
        ddlclass.DataBind();
        ddlclass.Items.Insert(0, "-Select-");
    }
    protected void fillteacher()
    {
        da = new DataAccess();
        ds = new DataSet();
        if (Session["PatronType"].ToString() == "Teaching Staffs")
        {
            strsql = "select a.strfirstname+' '+a.strmiddlename+' '+a.strlastname as teachername, a.intid from tblemployee a,tblteachingclass b where b.intschool =" + Session["SchoolID"] + " and a.intid=b.intemployee ";
            strsql += " and a.intID=" + Session["UserID"];
        }
        else
            strsql = "select a.strfirstname+' '+a.strmiddlename+' '+a.strlastname as teachername, a.intid from tblemployee a,tblteachingclass b where b.intschool =" + Session["SchoolID"] + " and b.strteachclass='" + ddlclass.SelectedValue + "' and a.intid=b.intemployee ";
        strsql += " group by a.intid,a.strfirstname+' '+a.strmiddlename+' '+a.strlastname";
        ds = da.ExceuteSql(strsql);
        ddlteacher.DataSource = ds;
        ddlteacher.DataTextField = "teachername";
        ddlteacher.DataValueField = "intid";
        ddlteacher.Items.Clear();
        ddlteacher.DataBind();
        ddlteacher.Items.Insert(0, "-Select-");
    }
    protected void fillsubject()
    {
        da = new DataAccess();
        ds = new DataSet();
        strsql = "select strsubject from tblschoolsyllabus where intschool=" + Session["SchoolID"].ToString() + " and strstandard ='" + ddlclass.SelectedValue + "' group by strsubject";
        ds = da.ExceuteSql(strsql);
        ddlsubject.DataSource = ds;
        ddlsubject.DataTextField = "strsubject";
        ddlsubject.DataValueField = "strsubject";
        ddlsubject.Items.Clear();
        ddlsubject.DataBind();
        ddlsubject.Items.Insert(0, "-Select-");
    }
    protected void filltextbook()
    {
        da = new DataAccess();
        ds = new DataSet();
        strsql = "select intid,strtextbookname from tblschooltextbook where intschool=" + Session["SchoolID"] + " and strclass='" + ddlclass.SelectedValue + "' and strsubject='" + ddlsubject.SelectedValue + "'";
        ds = da.ExceuteSql(strsql);
        ddltextbook.DataSource = ds;
        ddltextbook.DataTextField = "strtextbookname";
        ddltextbook.DataValueField = "intid";
        ddltextbook.Items.Clear();
        ddltextbook.DataBind();
        ddltextbook.Items.Insert(0, "-Select-");
    }
    protected void fillunit()
    {
        da = new DataAccess();
        ds = new DataSet();
        strsql = "select strunitno from dbo.tblschoolsyllabus where intschool=" + Session["SchoolID"].ToString() + " and strsubject='" + ddlsubject.SelectedValue + "' and strstandard='" + ddlclass.SelectedValue + "' and  inttextbook='" + ddltextbook.SelectedValue + "' group by strunitno";
        ds = da.ExceuteSql(strsql);
        ddlunit.DataSource = ds;
        ddlunit.DataTextField = "strunitno";
        ddlunit.DataValueField = "strunitno";
        ddlunit.Items.Clear();
        ddlunit.DataBind();
        ddlunit.Items.Insert(0, "-Select-");
    }
    protected void filllesson()
    {
        da = new DataAccess();
        ds = new DataSet();
        strsql = "select strlessonname from dbo.tblschoolsyllabus where intschool=" + Session["SchoolID"].ToString() + " and strsubject='" + ddlsubject.SelectedValue + "' and strstandard='" + ddlclass.SelectedValue + "' and  inttextbook='" + ddltextbook.SelectedValue + "' and strunitno='" + ddlunit.SelectedValue + "' group by strlessonname";
        ds = da.ExceuteSql(strsql);
        ddllesson.DataSource = ds;
        ddllesson.DataTextField = "strlessonname";
        ddllesson.DataValueField = "strlessonname";
        ddllesson.Items.Clear();
        ddllesson.DataBind();
        ddllesson.Items.Insert(0, "-Select-");
    }
    protected void ddlclass_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlclass.SelectedIndex > 0)
        {
            if (Session["PatronType"].ToString() == "Teaching Staffs")
                fillsubject();
            else
                fillteacher();
        }
    }
    protected void ddlteacher_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlteacher.SelectedIndex > 0)
        {
            fillsubject();
        }
    }
    protected void ddlsubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlsubject.SelectedIndex > 0)
        {
            filltextbook();
        }
    }
    protected void ddltextbook_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddltextbook.SelectedIndex > 0)
        {
            fillunit();
        }
    }
    protected void ddlunit_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlunit.SelectedIndex > 0)
        {
            filllesson();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlCommand cmd;
        SqlParameter outputparam;
        SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        Conn.Open();
        cmd = new SqlCommand("SPtutorial", Conn);
        cmd.CommandType = CommandType.StoredProcedure;
        outputparam = cmd.Parameters.Add("@rc", SqlDbType.Int);
        outputparam.Direction = ParameterDirection.Output;
        if (btnSave.Text == "Save")
        {
            cmd.Parameters.Add("@intid", "0");
        }
        else
        {
            cmd.Parameters.Add("@intid", Session["editTTid"].ToString());
        }
        cmd.Parameters.Add("@dtpublishdate", DateTime.Parse(txtpublishdate.Text).ToString("yyyy/MM/dd"));
        cmd.Parameters.Add("@dtdate", DateTime.Parse(txtdate.Text).ToString("yyyy/MM/dd"));
        cmd.Parameters.Add("@strclass", ddlclass.SelectedValue);
        cmd.Parameters.Add("@intteacher", ddlteacher.SelectedValue);
        cmd.Parameters.Add("@strsubject", ddlsubject.SelectedValue);
        cmd.Parameters.Add("@inttextbook", ddltextbook.SelectedValue);
        cmd.Parameters.Add("@strunit", ddlunit.SelectedValue);
        cmd.Parameters.Add("@strlesson", ddllesson.SelectedValue);
        cmd.Parameters.Add("@straudiofilename", "0");
        cmd.Parameters.Add("@strdocumentname", "0");
        cmd.Parameters.Add("@strdescription", txtdescription.Text.Trim());
        cmd.Parameters.Add("@intschool", Session["SchoolID"].ToString());
        cmd.ExecuteNonQuery();
        string filename = Session["SchoolID"].ToString();
        string audiofile = "";
        string docfile = "";
        int rowid = 0;
        DataAccess daid = new DataAccess();
        DataSet dsid = new DataSet();
        string sqlid = "select top 1 intid from tbltutorial where intschool = " + Session["SchoolID"] + " order by intid desc ";
        dsid = daid.ExceuteSql(sqlid);
        if (dsid.Tables[0].Rows.Count < 1)
        {
            rowid = 1;
            filename = "1_" + filename;
        }
        else
        {
            if (btnSave.Text == "Save")
            {
                rowid = int.Parse(dsid.Tables[0].Rows[0]["intid"].ToString());
                filename = dsid.Tables[0].Rows[0]["intid"] + "_" + filename;
            }
            else
            {
                filename = Session["editTTid"].ToString() + "_" + filename;
            }
        }
        HttpFileCollection uploadedFiles = Request.Files;
        if (uploadedFiles.Count > 0)
        {
            for (int i = 0; i < uploadedFiles.Count; i++)
            {
                HttpPostedFile userPostedFile = uploadedFiles[i];
                try
                {
                    if (userPostedFile.ContentLength > 0)
                    {
                        string ext = System.IO.Path.GetExtension(userPostedFile.FileName).ToLower();
                        string storefile = userPostedFile.FileName.Replace(userPostedFile.FileName, filename.ToString() + userPostedFile.FileName);
                        if (ext == ".mp3")
                        {
                            userPostedFile.SaveAs(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "Tutorials\\Audio\\" + storefile);
                            audiofile = audiofile + "|" + storefile;
                        }
                        if (ext == ".jpg" || ext == ".gif" || ext == ".doc" || ext == ".docx" || ext == ".pdf" || ext == ".png" || ext == ".txt" || ext == ".rtf")
                        {
                            userPostedFile.SaveAs(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "Tutorials\\Docs\\" + storefile);
                            docfile = docfile + "|" + storefile;
                        }
                    }
                }
                catch
                {
                }
                finally
                {

                }
            }
            if (audiofile != "")
            {
                DataAccess daupd1 = new DataAccess();
                string sql1 = "";
                if (btnSave.Text == "Save")
                {
                    sql1 = "update tbltutorial set straudiofilename='" + audiofile + "' where intid=" + rowid;
                    Functions.UserLogs(Session["UserID"].ToString(), "tbltutorial", rowid.ToString(), "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 319);

                }
                else
                {
                    sql1 = "update tbltutorial set straudiofilename='" + audiofile + "' where intid=" + Session["editTTid"];
                    Functions.UserLogs(Session["UserID"].ToString(), "tbltutorial", Session["editTTid"].ToString(), "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 319);

                }
                daupd1.ExceuteSqlQuery(sql1);
            }
            if (docfile != "")
            {
                DataAccess daupd2 = new DataAccess();
                string sql2 = "";
                if (btnSave.Text == "Save")
                {
                    sql2 = "update tbltutorial set strdocumentname='" + docfile + "' where intid=" + rowid;
                    Functions.UserLogs(Session["UserID"].ToString(), "tbltutorial", rowid.ToString(), "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 319);


                }
                else
                {
                    sql2 = "update tbltutorial set strdocumentname='" + docfile + "' where intid=" + Session["editTTid"];
                    Functions.UserLogs(Session["UserID"].ToString(), "tbltutorial", Session["editTTid"].ToString(), "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 319);

                }
                daupd2.ExceuteSqlQuery(sql2);
            }
        }
        Session.Remove("editTTid");
        Conn.Close();
        string id = Convert.ToString(outputparam.Value);
        if (btnSave.Text == "Save")
        {
            Functions.UserLogs(Session["UserID"].ToString(), "tbltutorial", id, "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 319);
        }
        else
        {
            Functions.UserLogs(Session["UserID"].ToString(), "tbltutorial", id, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 319);
        }
        btnSave.Text = "Save";
        Response.Redirect("Addtutorial.aspx?Msg=Msg", false);
    }
    protected void fillgrid()
    {
        try
        {
            dgtutorial.Visible = true;
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            strsql = "select a.*,convert(varchar(10),dtpublishdate,103) as publishdate,convert(varchar(10),dtdate,103) as date,b.strfirstname +' '+strmiddlename+' '+strlastname as teachername,c.strtextbookname from tbltutorial a,tblemployee b,tblschooltextbook c where a.intschool =" + Session["SchoolID"] + " and b.intid = a.intteacher and c.intid=a.inttextbook ";
            ds = da.ExceuteSql(strsql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgtutorial.DataSource = ds;
                dgtutorial.DataBind();
            }
            else
            {
                dgtutorial.Visible = false;
            }
        }
        catch { }
    }
    protected void dgtutorial_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        DataAccess da = new DataAccess();
        strsql = "delete from tbltutorial where intid="+ e.Item.Cells[0].Text;
        Functions.UserLogs(Session["UserID"].ToString(), "tbltutorial", e.Item.Cells[0].Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),319);
        da.ExceuteSqlQuery(strsql);
        fillgrid();
    }
    protected void dgtutorial_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["editTTid"] = e.Item.Cells[0].Text;
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        strsql = "select *,convert(varchar(10),dtpublishdate,111) as publishdate,convert(varchar(10),dtdate,111) as date from tbltutorial where intid = " + e.Item.Cells[0].Text;
        ds = da.ExceuteSql(strsql);
        txtdate.Text = ds.Tables[0].Rows[0]["date"].ToString();
        txtpublishdate.Text = ds.Tables[0].Rows[0]["publishdate"].ToString();
        ddlclass.SelectedValue = ds.Tables[0].Rows[0]["strclass"].ToString();
        fillteacher();
        ddlteacher.SelectedValue = ds.Tables[0].Rows[0]["intteacher"].ToString();
        fillsubject();
        ddlsubject.SelectedValue = ds.Tables[0].Rows[0]["strsubject"].ToString();
        filltextbook();
        ddltextbook.SelectedValue = ds.Tables[0].Rows[0]["inttextbook"].ToString();
        fillunit();
        ddlunit.SelectedValue = ds.Tables[0].Rows[0]["strunit"].ToString();
        filllesson();
        ddllesson.SelectedValue = ds.Tables[0].Rows[0]["strlesson"].ToString();
        txtdescription.Text = ds.Tables[0].Rows[0]["strdescription"].ToString();

        btnSave.Text = "Update";
    }
    protected void clear()
    {
        txtdate.Text = "";
        txtpublishdate.Text = "";
        ddlclass.SelectedIndex = 0;
        if (Session["PatronType"].ToString() != "Teaching Staffs")
        {
            ddlteacher.Items.Clear();
            ddlteacher.Items.Insert(0, "-Select-");
        }           
        ddlsubject.Items.Clear();
        ddlsubject.Items.Insert(0, "-Select-");
        ddltextbook.Items.Clear();
        ddltextbook.Items.Insert(0, "-Select-");
        ddlunit.Items.Clear();
        ddlunit.Items.Insert(0, "-Select-");
        ddllesson.Items.Clear();
        ddllesson.Items.Insert(0, "-Select-");
        txtdescription.Text = "";
        btnSave.Text = "Save";
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Response.Redirect("Addtutorial.aspx",false);
    }
}
