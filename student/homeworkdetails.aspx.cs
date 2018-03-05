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


public partial class school_homeworkdetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            view();
        }
    }

    protected void view()
    {
        DataAccess da = new DataAccess();
        string str;
        DataSet ds, ds1;
        da = new DataAccess();
        str = "select c.intid as employeeid,b.strstandard,c.strfirstname + ' ' + ltrim(c.strmiddlename) + ' ' + ltrim(c.strlastname) as strstaffname,b.strsubject,a.strattachments,a.strtopic,a.intstatus";
        str += " ,a.strdescription,convert(varchar(10),a.dtassigndate,103) as strassigndate,";
        str += "convert(varchar(10),a.dtduedate,103) as strduedate,convert(varchar(10),a.dtpublishdate,103) as strpublishdate";
        str += ",b.strunit,b.strlesson,d.strtextbookname ";
        str += "from tblhomework a, tblhomeworktopics b, tblemployee c,tblschooltextbook d ";
        str += "where a.inttopic=b.intid and a.intemployee=c.intID and b.strstandard=d.strclass";
        if (Request["hid1"] != null)
        {
            str += " and a.intid=" + Request["hid1"].ToString() + " and a.intschool=" + Session["SchoolID"].ToString();
            if (Request["hwf"].ToString() == "1")
            {
                str = str + " and b.inttextbook=d.intid ";
            }
            else
            {
                trtextbook.Visible = false;
                trunitlession.Visible = false;
            }
        }
        else if (Request["hid2"] != null)
        {
            str += " and a.intid=" + Request["hid2"].ToString() + " and a.intschool=" + Session["SchoolID"].ToString();
            if (Request["hwf"].ToString() == "1")
            {
                str = str + " and b.inttextbook=d.intid ";
            }
            else
            {
                trtextbook.Visible = false;
                trunitlession.Visible = false;
            }
        }
        else
        {
            str += " and a.intid=" + Request["hid"].ToString() + " and a.intschool=" + Session["SchoolID"].ToString();
            if (Request["hwf"].ToString() == "1")
            {
                str = str + " and b.inttextbook=d.intid ";
            }
            else
            {
                trtextbook.Visible = false;
                trunitlession.Visible = false;
            }
        }
            ds = new DataSet();
            ds = da.ExceuteSql(str);
        
        if (ds.Tables[0].Rows.Count > 0)
        {

            lblteacher.Text = ds.Tables[0].Rows[0]["strstaffname"].ToString();
            lblstandard.Text = ds.Tables[0].Rows[0]["strstandard"].ToString();
            lblsubject.Text = ds.Tables[0].Rows[0]["strsubject"].ToString();
            lblunit.Text = ds.Tables[0].Rows[0]["strunit"].ToString();
            lbllesson.Text = ds.Tables[0].Rows[0]["strlesson"].ToString();
            lbltextbook.Text = ds.Tables[0].Rows[0]["strtextbookname"].ToString();
            lbltopic.Text = ds.Tables[0].Rows[0]["strtopic"].ToString();
            lbldescript.Text = ds.Tables[0].Rows[0]["strdescription"].ToString();
            lblassigned.Text = ds.Tables[0].Rows[0]["strassigndate"].ToString();
            lbldue.Text = ds.Tables[0].Rows[0]["strduedate"].ToString();
            lblpublish.Text = ds.Tables[0].Rows[0]["strpublishdate"].ToString();
            int status = int.Parse(ds.Tables[0].Rows[0]["intstatus"].ToString());
            hdnid.Value = ds.Tables[0].Rows[0]["employeeid"].ToString();

            if (status == 1)
                lblstatus.Text = "Active";
            else
                lblstatus.Text = "In Active";

            if (ds.Tables[0].Rows[0]["strattachments"].ToString() != "")
            {
                str = "select intid,strfilename from tblhomeworkAttachments where intid in (" + ds.Tables[0].Rows[0]["strattachments"].ToString() + ")";
                ds1 = new DataSet();
                ds1 = da.ExceuteSql(str);
                string attatch = "";
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    if (attatch == "")
                        attatch = "<a href=" + "../images/homeworktemp/" + ds1.Tables[0].Rows[i]["strfilename"].ToString() + " target=" + "_blank" + ">" + ds1.Tables[0].Rows[i]["strfilename"].ToString() + "</a>";
                    else
                        attatch = attatch + "," + "<a href=" + "../images/homeworktemp/" + ds1.Tables[0].Rows[i]["strfilename"].ToString() + " target=" + "_blank" + ">" + ds1.Tables[0].Rows[i]["strfilename"].ToString() + "</a>";
                }
                lblattatchments.Text = attatch;
                tdattachment.Visible = true;
                
            }
            else
                tdattachment.Visible = false;
            
        }
    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        if (Request["hid1"] != null)
            Response.Redirect("viewhomework.aspx?hid1");
        else if (Request["hid2"] != null)
            Response.Redirect("edit_homework.aspx?hid2="+lblstandard.Text +"&tr="+hdnid.Value);
        else
            Response.Redirect("view_student_homework.aspx?hid");
    }
}
