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
using System.IO;

public partial class school_homework : System.Web.UI.Page
{
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Request["hid"] != null && Request["hwf"] != null)
            //if(Request["hid"] != null)
            {
                Edithomeworkdetails();
            }
            else
            {
                fillteacher();
                fillstandard();
                fillsubject();
                filltextbook();
                fillunit();
                filllessonname();
                clear();
            }
            if (Session["PatronType"].ToString() == "Teaching Staffs")
            {
                ddlteacher.SelectedValue = Session["UserID"].ToString();
                ddlteacher.Enabled = false;
                fillstandard();
            }
        }
        else
        {
            if (Session["PatronType"].ToString() == "Teaching Staffs")
            {
                ddlteacher.SelectedValue = Session["UserID"].ToString();
                ddlteacher.Enabled = false;
            }
        }
    }

    private void fillstandard()
    {
        DataAccess da = new DataAccess();
        //string str = "select strstandard from tblschoolsyllabus where intschool='" + Session["SchoolID"].ToString() + "' group by strstandard";
        string str = "select strstandards from (select strstandard+' - '+strsection as strstandards from tbltimetable where strteacher=" + ddlteacher.SelectedValue + " and strsubject!='Language' and strsubject!='%Language' and strsubject!='Extra Activities' and intschool=" + Session["SchoolID"].ToString() + " union all select strstandard+' - '+strsection as strstandards from tbltimetable2 where strteacher=" + ddlteacher.SelectedValue + " and intschool=" + Session["SchoolID"].ToString() + " union all select strstandard+' - '+strsection as strstandards  from tbltimetable3 where strteacher=" + ddlteacher.SelectedValue + " and intschool=" + Session["SchoolID"].ToString() + " ) as a group by strstandards ";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(str);
        ddlstandard.DataSource = ds;
        ddlstandard.DataTextField = "strstandards";
        ddlstandard.DataValueField = "strstandards";
        ddlstandard.DataBind();
        ListItem li = new ListItem("-Select-", "0");
        ddlstandard.Items.Insert(0, li);
    }

    protected void fillteacher()
    {
        DataAccess da = new DataAccess();
        string str;
        DataSet ds;
        da = new DataAccess();
        //str = "select intid,strtittle+' ' +strfirstname +' ' +ltrim(strmiddlename)+' ' + ltrim(strlastname) as staffname from tblemployee where intid in(select strteacher from tbltimetable where strstandard + ' - ' + strsection ='" + ddlstandard.SelectedValue + "'  and strsubject!='Language' and strsubject!='%Language' and strsubject!='Extra Activities' and intschool=" + Session["SchoolID"].ToString() + " group by strteacher union all select strteacher from tbltimetable2 where strstandard1 + ' - ' + strsection1 ='" + ddlstandard.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + " group by strteacher union all select strteacher from tbltimetable3 where strstandard + ' - ' + strsection ='" + ddlstandard.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + " group by strteacher) order by staffname";
        str = "select intid,strtittle+' ' +strfirstname +' ' +ltrim(strmiddlename)+' ' + ltrim(strlastname) as staffname from tblemployee where intschool= " + Session["SchoolID"].ToString() + " and strtype='Teaching Staffs'";
        if (Session["PatronType"].ToString() == "Teaching Staffs")
        {
            str += " and intID=" + Session["UserID"];
        }
        ds = new DataSet();
        ds = da.ExceuteSql(str);
        ddlteacher.DataSource = ds;
        ddlteacher.DataTextField = "staffname";
        ddlteacher.DataValueField = "intid";
        ddlteacher.DataBind();
        ListItem li = new ListItem("-Select-", "0");
        ddlteacher.Items.Insert(0, li);
    }

    protected void fillsubject()
    {
        DataAccess da = new DataAccess();
        string str;
        DataSet ds;
        da = new DataAccess();
        str = "select * from (select strsubject from tbltimetable where strstandard + ' - ' + strsection ='" + ddlstandard.SelectedValue + "'  and strsubject!='Language' and strsubject!='%Language' and strsubject!='Extra Activities' and strteacher=" + ddlteacher.SelectedValue + " and intschool=" + Session["SchoolID"].ToString() + " group by strsubject union all select strlanguage as strsubject from tbltimetable2 where strstandard1 + ' - ' + strsection1 ='" + ddlstandard.SelectedValue + "' and strteacher=" + ddlteacher.SelectedValue + " and intschool=" + Session["SchoolID"].ToString() + " group by strlanguage union all select strlanguage as strsubject from tbltimetable3 where strstandard + ' - ' + strsection ='" + ddlstandard.SelectedValue + "' and strteacher=" + ddlteacher.SelectedValue + " and intschool=" + Session["SchoolID"].ToString() + " group by strlanguage) as a  order by strsubject";
        ds = new DataSet();
        ds = da.ExceuteSql(str);
        ddlsubject.DataSource = ds;
        ddlsubject.DataTextField = "strsubject";
        ddlsubject.DataValueField = "strsubject";
        ddlsubject.DataBind();
        ListItem li = new ListItem("-Select-", "0");
        ddlsubject.Items.Insert(0, li);
    }

    protected void filltextbook()
    {
        DataAccess da = new DataAccess();
        string str;
        DataSet ds;
        da = new DataAccess();
        str = "select strtextbookname,intid from tblschooltextbook where intid in(select inttextbook from tblschoolsyllabus where strstandard='" + ddlstandard.SelectedValue + "' and strsubject='" + ddlsubject.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + ")";
        ds = new DataSet();
        ds = da.ExceuteSql(str);
        ddltextbook.DataSource = ds;
        ddltextbook.DataTextField = "strtextbookname";
        ddltextbook.DataValueField = "intid";
        ddltextbook.DataBind();
        ListItem li = new ListItem("-Select-", "0");
        ddltextbook.Items.Insert(0, li);
    }

    protected void fillunit()
    {
        DataAccess da = new DataAccess();
        string str = "select strunitno from tblschoolsyllabus where strstandard='" + ddlstandard.SelectedValue + "' and inttextbook=" + ddltextbook.SelectedValue + " and strsubject='" + ddlsubject.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + " group by strunitno";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(str);
        ddlunit.DataSource = ds;
        ddlunit.DataTextField = "strunitno";
        ddlunit.DataValueField = "strunitno";
        ddlunit.DataBind();
        ListItem li = new ListItem("-Select-", "0");
        ddlunit.Items.Insert(0, li);
    }

    protected void filllessonname()
    {
        DataAccess da = new DataAccess();
        string str = "select strlessonname from tblschoolsyllabus where strstandard='" + ddlstandard.SelectedValue + "' and inttextbook=" + ddltextbook.SelectedValue + " and strunitno='" + ddlunit.SelectedValue + "' and strsubject='" + ddlsubject.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + " group by strlessonname";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(str);
        ddllessonname.DataSource = ds;
        ddllessonname.DataTextField = "strlessonName";
        ddllessonname.DataValueField = "strlessonName";
        ddllessonname.DataBind();
        ListItem li = new ListItem("-Select-", "0");
        ddllessonname.Items.Insert(0, li);

    }
    protected void Edithomeworkdetails()
    {
        DataAccess da = new DataAccess();
        string str;
        DataSet ds;
        da = new DataAccess();
        str ="select strstandard,a.intemployee,b.strsubject,d.intid as inttextbook,b.strunit,b.strlesson,b.intid as inttopic,";
        str += "convert(varchar(10),a.dtassigndate,111) as strassigndate,convert(varchar(10),a.dtduedate,111) as strduedate";
        str +=",convert(varchar(10),a.dtpublishdate,111) as strpublishdate,a.intstatus,a.inthwfrom,a.strattachments";
        str += " from tblhomework a,tblhomeworktopics b,tblhomeworkAttachments c,tblschooltextbook d,tblemployee e";
        str += " where a.inttopic=b.intid and a.intemployee=e.intID and a.intschool=" + Session["SchoolID"].ToString()+" and a.intid=" + Request["hid"].ToString();

        if (Request["hwf"].ToString() == "1")
        {
            str = str + " and b.inttextbook=d.intid and inthwfrom=1";
        }
        else
        {
            str += " and inthwfrom=0";
        }
        str += " group by a.intid,strstandard,intemployee,b.strsubject,d.intid,b.strunit,b.strlesson,b.intid,dtassigndate,dtduedate,";
        str += " dtpublishdate,a.intstatus,a.inthwfrom,a.strattachments";

        ds = new DataSet();
        ds = da.ExceuteSql(str);
        fillteacher();
        ddlteacher.SelectedValue = ds.Tables[0].Rows[0]["intemployee"].ToString();
        fillstandard();
        ddlstandard.SelectedValue = ds.Tables[0].Rows[0]["strstandard"].ToString();
        fillsubject();
        ddlsubject.SelectedValue = ds.Tables[0].Rows[0]["strsubject"].ToString();
        filltextbook();
        ddltextbook.SelectedValue = ds.Tables[0].Rows[0]["inttextbook"].ToString();
        fillunit();
        ddlunit.SelectedValue = ds.Tables[0].Rows[0]["strunit"].ToString();
        filllessonname();
        ddllessonname.SelectedValue = ds.Tables[0].Rows[0]["strlesson"].ToString();
        filloldtopics();
        ddloldtopics.SelectedValue = ds.Tables[0].Rows[0]["inttopic"].ToString();
        edittopic();
        txtassign.Text = ds.Tables[0].Rows[0]["strassigndate"].ToString();
        txtduedate.Text = ds.Tables[0].Rows[0]["strduedate"].ToString();
        txtpublish.Text = ds.Tables[0].Rows[0]["strpublishdate"].ToString();
        int status = int.Parse(ds.Tables[0].Rows[0]["intstatus"].ToString());
        if (status == 1)
        {
            rbactive.Checked = true;
            rbinactive.Checked = false;
        }
        else
        {
            rbinactive.Checked = true;
            rbactive.Checked = false;
        }
        int hwfrom = int.Parse(ds.Tables[0].Rows[0]["inthwfrom"].ToString());
        if (hwfrom == 1)
        {
            RdbTextBook.Checked = true;
            RdbGeneral.Checked = false;
            trtextbook.Visible = true;
            trunit.Visible = true;
            trlessionname.Visible = true;
            RdbTextBook.Visible = true;
            RdbGeneral.Visible = false;
        }
        else
        {
            RdbGeneral.Checked = true;
            RdbTextBook.Checked = false;
            trtextbook.Visible = false;
            trunit.Visible = false;
            trlessionname.Visible = false;
            RdbGeneral.Visible = true;
            RdbTextBook.Visible = false;
            
        }

        Session["AttachedHomework"] = ds.Tables[0].Rows[0]["strattachments"].ToString();
      
        fillgrid();
        fillgrid1();
        ddlstandard.Enabled = false;
        ddlteacher.Enabled = false;
        ddlsubject.Enabled = false;
        ddltextbook.Enabled = false;
        ddllessonname.Enabled = false;
        ddlunit.Enabled = false;
        lblhid.Text = Request["hid"].ToString();
        btnsave.Text = "Update";
    }

    protected void filloldtopics()
    {
        DataAccess da = new DataAccess();
        string str;
        DataSet ds;
        da = new DataAccess();
        str = "select strtopic,intid from tblhomeworktopics where intschool=" + Session["SchoolID"].ToString() + " and strsubject='" + ddlsubject.SelectedValue + "' and inttextbook=" + ddltextbook.SelectedValue + " and strstandard='" + ddlstandard.SelectedValue + "' and strunit='" + ddlunit.SelectedValue + "' and strlesson='" + ddllessonname.SelectedValue + "'";
        ds = new DataSet();
        ds = da.ExceuteSql(str);
        ddloldtopics.DataSource = ds;
        ddloldtopics.DataTextField = "strtopic";
        ddloldtopics.DataValueField = "intid";
        ddloldtopics.DataBind();
        ListItem li;
        li = new ListItem("New Topic", "0");
        ddloldtopics.Items.Insert(0, li);
    }

    protected void savetopic()
    {
        if (ddloldtopics.SelectedIndex == 0)
        {
            if (txttopic.Text != "")
            {
                if (txtdescrip.Text != "")
                {
                    SqlCommand command;
                    SqlParameter OutPutParam;
                    SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);

                    conn.Open();
                    command = new SqlCommand("sphomeworktopics", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    OutPutParam = command.Parameters.Add("@ID", SqlDbType.Int);
                    OutPutParam.Direction = ParameterDirection.Output;
                    if (ddloldtopics.SelectedIndex == 0)
                        command.Parameters.Add("@intid", "0");
                    else
                        command.Parameters.Add("@intid", ddloldtopics.SelectedValue);
                    command.Parameters.Add("@intschool", Session["SchoolID"].ToString());
                    command.Parameters.Add("@strstandard", ddlstandard.SelectedValue);
                    command.Parameters.Add("@strsubject", ddlsubject.SelectedValue);
                    command.Parameters.Add("@inttextbook", ddltextbook.SelectedValue);
                    command.Parameters.Add("@strunit", ddlunit.SelectedValue);
                    command.Parameters.Add("@strlesson", ddllessonname.SelectedValue);
                    command.Parameters.Add("@strtopic", txttopic.Text.Trim());
                    command.Parameters.Add("@strdescription", txtdescrip.Text.Trim());

                    command.ExecuteNonQuery();

                    if (command.Parameters["@ID"].Value != null)
                    {
                        lblid.Text = command.Parameters["@ID"].Value.ToString();
                        conn.Close();
                        if (lblid.Text == "0")
                            msgbox.alert("Topic Already Exists");
                    }
                    else
                    { }
                    conn.Close();
                    string id = Convert.ToString(OutPutParam.Value);
                    if (ddloldtopics.SelectedIndex == 0)
                        Functions.UserLogs(Session["UserID"].ToString(), "tblhomeworktopics", id, "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 58);
                    else
                        Functions.UserLogs(Session["UserID"].ToString(), "tblhomeworktopics", id, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 58);
                    filloldtopics();
                    ddloldtopics.SelectedValue = lblid.Text;
                }
                else
                    //msgbox.alert("Please Enter Topic Description");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please Enter Topic Description')", true);
            }
            else
                //msgbox.alert("Please Enter Topic");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please Enter Topic')", true);
        }
    }

    protected void savehomework()
    {
        try
        {
            if (btnsave.Text == "Save")
            {
                SqlCommand command;
                SqlParameter OutPutParam;
                SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);

                conn.Open();
                command = new SqlCommand("sphomework", conn);
                command.CommandType = CommandType.StoredProcedure;
                OutPutParam = command.Parameters.Add("@ID", SqlDbType.Int);
                OutPutParam.Direction = ParameterDirection.Output;
                if (lblhid.Text == "0")
                    command.Parameters.Add("@intid", "0");
                else
                    command.Parameters.Add("@intid", lblhid.Text);

                command.Parameters.Add("@intschool", Session["SchoolID"].ToString());
                command.Parameters.Add("@intemployee", ddlteacher.SelectedValue);
                command.Parameters.Add("@inttopic", lblid.Text.Trim());
                command.Parameters.Add("@strtopic", txttopic.Text.Trim());
                command.Parameters.Add("@strdescription", txtdescrip.Text.Trim());
                command.Parameters.Add("@dtassigndate", txtassign.Text.Trim());
                command.Parameters.Add("@dtduedate", txtduedate.Text.Trim());
                command.Parameters.Add("@dtpublishdate", txtpublish.Text.Trim());

                if (Session["AttachedHomework"] != "" && Session["NewAttachments"] != "")

                    command.Parameters.Add("@strattachments", Session["AttachedHomework"] + "," + Session["NewAttachments"]);


                else if (Session["AttachedHomework"] != "" && Session["NewAttachments"] == "")

                    command.Parameters.Add("@strattachments", Session["AttachedHomework"]);
                else if (Session["AttachedHomework"] == "" && Session["NewAttachments"] != "")

                    command.Parameters.Add("@strattachments", Session["NewAttachments"]);
                else

                    command.Parameters.Add("@strattachments", lblid.Text.Trim());


                int st;
                if (rbactive.Checked == true)
                    st = 1;
                else
                    st = 0;
                command.Parameters.Add("@intstatus", st);
                int se;
                if (RdbTextBook.Checked == true)
                    se = 1;
                else
                    se = 0;
                command.Parameters.Add("@inthwfrom", se);
                command.ExecuteNonQuery();
                conn.Close();
                string id = Convert.ToString(OutPutParam.Value);
                if (lblhid.Text == "0")
                    Functions.UserLogs(Session["UserID"].ToString(), "tblhomework", id, "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 58);
                else
                    Functions.UserLogs(Session["UserID"].ToString(), "tblhomework", id, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 58);
                clear();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Details Saved Successfully')", true);
            }

            else
            {
                SqlCommand command;
                SqlParameter OutPutParam;
                SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);

                conn.Open();
                command = new SqlCommand("sphomework", conn);
                command.CommandType = CommandType.StoredProcedure;
                OutPutParam = command.Parameters.Add("@ID", SqlDbType.Int);
                OutPutParam.Direction = ParameterDirection.Output;
                if (lblhid.Text == "0")
                    command.Parameters.Add("@intid", "0");
                else
                    command.Parameters.Add("@intid", lblhid.Text);

                command.Parameters.Add("@intschool", Session["SchoolID"].ToString());
                command.Parameters.Add("@intemployee", ddlteacher.SelectedValue);
                command.Parameters.Add("@inttopic", lblid.Text.Trim());
                command.Parameters.Add("@strtopic", txttopic.Text.Trim());
                command.Parameters.Add("@strdescription", txtdescrip.Text.Trim());
                command.Parameters.Add("@dtassigndate", txtassign.Text.Trim());
                command.Parameters.Add("@dtduedate", txtduedate.Text.Trim());
                command.Parameters.Add("@dtpublishdate", txtpublish.Text.Trim());

                if (Session["AttachedHomework"] != "" && Session["NewAttachments"] != "")

                    command.Parameters.Add("@strattachments", Session["AttachedHomework"] + "," + Session["NewAttachments"]);


                else if (Session["AttachedHomework"] != "" && Session["NewAttachments"] == "")

                    command.Parameters.Add("@strattachments", Session["AttachedHomework"]);
                else if (Session["AttachedHomework"] == "" && Session["NewAttachments"] != "")

                    command.Parameters.Add("@strattachments", Session["NewAttachments"]);
                else

                    command.Parameters.Add("@strattachments", lblid.Text.Trim());


                int st;
                if (rbactive.Checked == true)
                    st = 1;
                else
                    st = 0;
                command.Parameters.Add("@intstatus", st);
                int se;
                if (RdbTextBook.Checked == true)

                    se = 1;
                else
                    se = 0;
                command.Parameters.Add("@inthwfrom", se);
                command.ExecuteNonQuery();
                conn.Close();
                string id = Convert.ToString(OutPutParam.Value);
                if (lblhid.Text == "0")
                    Functions.UserLogs(Session["UserID"].ToString(), "tblhomework", id, "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 58);
                else
                    Functions.UserLogs(Session["UserID"].ToString(), "tblhomework", id, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 58);
                clear();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Details Update Successfully')", true);
                Response.Redirect("edit_homework.aspx?hid=" + ddlstandard.SelectedValue + "&staff=" + ddlteacher.SelectedValue);
            }
        }
        catch { }
       
    }

    protected void saveAttatchments()
    {
        try
        {

            if (lblattached.Text == "")
            {
                if (FileUpload1.PostedFile.ContentLength > 0)
                {
                    if (FileUpload1.PostedFile.FileName != "")
                    {
                        string filename = FileUpload1.FileName;
                        string ext = System.IO.Path.GetExtension(this.FileUpload1.PostedFile.FileName);
                        FileUpload1.PostedFile.SaveAs(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\homeworktemp\\" + Session["UserID"].ToString() + "-" + filename);
                        if (lblattached.Text == "")
                            lblattached.Text = Session["UserID"].ToString() + "-" + filename;
                        else
                            lblattached.Text = lblattached.Text + "," + Session["UserID"].ToString() + "-" + filename;
                    }
                }
            }
            string[] arr = lblattached.Text.Split(',');
            Session["NewAttachments"] = "";
            for (int i = 0; i < arr.Length; i++)
            {
                SqlCommand command;
                SqlParameter OutPutParam;
                SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
                conn.Open();
                command = new SqlCommand("sphomeworkattachments", conn);
                command.CommandType = CommandType.StoredProcedure;
                OutPutParam = command.Parameters.Add("@ID", SqlDbType.Int);
                OutPutParam.Direction = ParameterDirection.Output;
                command.Parameters.Add("@intschool", Session["SchoolID"].ToString());
                command.Parameters.Add("@inttopic", lblid.Text.Trim());
                command.Parameters.Add("@strfilename", arr[i]);
                if (arr[i].ToString() != "")
                {
                    command.ExecuteNonQuery();
                    if (command.Parameters["@ID"].Value != null)
                    {
                        if (command.Parameters["@ID"].Value.ToString() != "0")
                        {
                            FileUpload1.PostedFile.SaveAs(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\homeworktemp\\" + Session["UserID"].ToString() + "-" + arr[i]);
                            if (Session["NewAttachments"].ToString() != "")
                            {
                                Session["NewAttachments"] = Session["NewAttachments"].ToString() + "," + command.Parameters["@ID"].Value.ToString();
                            }
                            else
                            {
                                Session["NewAttachments"] = command.Parameters["@ID"].Value.ToString();
                            }
                        }
                    }
                }
                conn.Close();
                string id = Convert.ToString(OutPutParam.Value);
                Functions.UserLogs(Session["UserID"].ToString(), "tblhomeworkAttachments", id, "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 58);
            }
        }
        catch
        {
            msgbox.alert("Select a File to Attach");
        }
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        if (txtassign.Text != "")
        {
            if (txtpublish.Text != "")
            {
                if (txtduedate.Text != "")
                {
                    if (lblid.Text != "")
                        savetopic();
                    saveAttatchments();
                    savehomework();
                    fillgrid();
                    Session["NewAttachments"] = "";
                    Session["AttachedHomework"] = "";
                }
                else
                {
                    msgbox.alert("Please Select Due Date");
                }
            }
            else
            {
                msgbox.alert("Please Select Publish Date");
            }
        }
        else
        {
            msgbox.alert("Please Select Assign Date");
        }
    }

    protected void clear()
    {
        txtassign.Text = "";
        txtdescrip.Text = "";
        txtduedate.Text = "";
        txtpublish.Text = "";
        txttopic.Text = "";
        ddloldtopics.SelectedValue = "0";
        Session["AttachedHomework"] = "";
        chknewattachments.Items.Clear();
        chkoldattachments.Items.Clear();
        trattachment.Visible = false;
        trattachment1.Visible = false;
        lblid.Text = "0";
        lblattached.Text = "";
    }

    protected void ddlstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        //fillteacher();
        fillsubject();
        filltextbook();
        fillunit();
        filllessonname();
        filloldtopics();
        clear();
        ClientScript.RegisterStartupScript(this.GetType(), "altert", "EndRequestHandler(sender, args)", true);
    }

    protected void ddlteacher_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillstandard();
        fillsubject();
        filltextbook();
        fillunit();
        filllessonname();
        filloldtopics();
        clear();
    }
    
    protected void fillgrid()
    {
        try
        {
            DataAccess da = new DataAccess();
            string sql;
            //" + Session["AttachedHomework"] + "
            if (Session["AttachedHomework"] != "")
                sql = "select * from tblhomeworkattachments where intid not in(" + Session["AttachedHomework"] + ") and intschool=" + Session["SchoolID"].ToString() + " and inttopic=" + lblid.Text;
               
            else
                sql = "select * from tblhomeworkattachments where intschool=" + Session["SchoolID"].ToString() + " and inttopic=" + lblid.Text;
            DataSet ds = new DataSet();
            ds = da.ExceuteSql(sql);
            chkoldattachments.Items.Clear();
            ListItem li;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                li = new ListItem(ds.Tables[0].Rows[i]["strfilename"].ToString(), ds.Tables[0].Rows[i]["intid"].ToString());

                chkoldattachments.Items.Add(li);
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                trattachment.Visible = true;
                trattachment1.Visible = true;
            }
            else
            {
                trattachment.Visible = false;
                trattachment1.Visible = false;
            }
        }
        catch { }

    }

    protected void fillgrid1()
    {
        DataSet ds = new DataSet();
        try
        {
            ListItem li;
            DataAccess da = new DataAccess();
            string sql;
            if (Session["AttachedHomework"] != "")
            {

                sql = "select * from tblhomeworkattachments where intid in(" + Session["AttachedHomework"] + ") and intschool=" + Session["SchoolID"].ToString() + " and inttopic=" + lblid.Text;


                ds = da.ExceuteSql(sql);
                chknewattachments.Items.Clear();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    li = new ListItem(ds.Tables[0].Rows[i]["strfilename"].ToString(), ds.Tables[0].Rows[i]["intid"].ToString());
                    chknewattachments.Items.Add(li);
                }
           }
            else
                chknewattachments.Items.Clear();
        }
        catch { }
    }

    protected void dgclassroom_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        DataSet ds;
        DataAccess da = new DataAccess();
        string str = "";
        str = "select a.intoldtopic,b.inthomeworkid,b.strattatch from dbo.tblhomework a,dbo.tblhomeworkAttachments b where a.intid = b.inthomeworkid and  b.intid=" + e.Item.Cells[0].Text;
        ds = new DataSet();
        ds = da.ExceuteSql(str);
        string filePaths = Server.MapPath("~/images/homework/" + ds.Tables[0].Rows[0]["strattatch"].ToString());
        if (System.IO.File.Exists(filePaths))
        {
            System.IO.File.Delete(filePaths);
        }
        str = "delete tblhomeworkAttachments where intid=" + e.Item.Cells[0].Text;
        Functions.UserLogs(Session["UserID"].ToString(), "tblhomeworkAttachments", e.Item.Cells[0].Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),58);

        da.ExceuteSqlQuery(str);
        fillgrid();
    }

    protected void ddloldtopics_SelectedIndexChanged(object sender, EventArgs e)
    {
        edittopic();
    }

    protected void edittopic()
    {
        if (ddloldtopics.SelectedIndex > 0)
        {
            DataAccess da = new DataAccess();
            string str = "select * from tblhomeworktopics where intid=" + ddloldtopics.SelectedValue + " and intschool=" + Session["SchoolID"].ToString();
            DataSet ds = new DataSet();
            ds = da.ExceuteSql(str);
            txttopic.Text = ds.Tables[0].Rows[0]["strtopic"].ToString();
            txtdescrip.Text = ds.Tables[0].Rows[0]["strdescription"].ToString();
            lblid.Text = ddloldtopics.SelectedValue;
            trattachment.Visible = false;
            trattachment1.Visible = false;

        }
        else
        {
            txtdescrip.Text = "";
            txttopic.Text = "";
            lblid.Text = "0";
            chknewattachments.Items.Clear();
            chkoldattachments.Items.Clear();
            trattachment.Visible = false;
            trattachment1.Visible = false;
        }
    }

    protected void ddlsubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        filltextbook();
        fillunit();
        filllessonname();
        clear();
    }

    protected void ddlunit_SelectedIndexChanged(object sender, EventArgs e)
    {
        filllessonname();
        filloldtopics();
        clear();
    }

    protected void ddllessonname_SelectedIndexChanged(object sender, EventArgs e)
    {
        filloldtopics();
        clear();
    }
    protected void ddltextbook_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillunit();
        filllessonname();
    }

    protected void btnadd_Click(object sender, EventArgs e)
    {
        string sec = "";
        for (int s = 0; s < chkoldattachments.Items.Count; s++)
        {
            if (chkoldattachments.Items[s].Selected == true)
            {
                if (sec == "")
                    sec = chkoldattachments.Items[s].Value;
                else
                    sec = sec + "," + chkoldattachments.Items[s].Value;
            }
        }
       if (Session["AttachedHomework"] != "")

            Session["AttachedHomework"] = Session["AttachedHomework"].ToString() + "," + sec;
        else
            Session["AttachedHomework"] = sec;
        fillgrid();
        fillgrid1();
    }

    protected void btnremove_Click(object sender, EventArgs e)
    {
        string sec = "";
        for (int s = 0; s < chknewattachments.Items.Count; s++)
        {
            if (chknewattachments.Items[s].Selected == true)
            {
            }
            else
            {
                if (sec == "")
                    sec = chknewattachments.Items[s].Value;
                else
                    sec = sec + "," + chknewattachments.Items[s].Value;
            }
        }

        Session["AttachedHomework"] = sec;
        fillgrid();
        fillgrid1();
    }

    protected void RdbTextBook_CheckedChanged(object sender, EventArgs e)
    {
        //fillstandard();
        ddloldtopics.Items.Clear();
        ddllessonname.Visible = true;
        filllessonname();
        ddlunit.Visible = true;
        fillunit();
        ddltextbook.Visible = true;
        filltextbook();
        trtextbook.Visible = true;
        trunit.Visible = true;
        trlessionname.Visible = true;
    }
    protected void RdbGeneral_CheckedChanged(object sender, EventArgs e)
    {
        ddloldtopics.Visible = false;
        ddllessonname.Visible = false;
        ddlunit.Visible = false;
        ddltextbook.Visible = false;
        trtextbook.Visible = false;
        trunit.Visible = false;
        trlessionname.Visible = false;
        trddloldtopics.Visible = false;

    }

    protected void btnPrevious_Click(object sender, EventArgs e)
    {
        fillgrid();
        fillgrid1();
        trattachment.Visible = true;
        trattachment1.Visible = true;

    }
    protected void btnupload_Click(object sender, EventArgs e)
    {
        if (FileUpload1.PostedFile.FileName != "")
        {
            string filename = FileUpload1.FileName;
            string ext = System.IO.Path.GetExtension(this.FileUpload1.PostedFile.FileName);
            FileUpload1.PostedFile.SaveAs(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\homeworktemp\\" + Session["UserID"].ToString() + "-" + filename);
            if (lblattached.Text == "")
                lblattached.Text = Session["UserID"].ToString() + "-" + filename;
            else
                lblattached.Text = lblattached.Text + "," + Session["UserID"].ToString() + "-" + filename;
        }
    }


}

