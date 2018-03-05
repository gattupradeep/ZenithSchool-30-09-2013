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

public partial class student_withdrawalpopup : System.Web.UI.Page
{
    public DataSet ds;
    Csfeemenagement CsFee = new Csfeemenagement();
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void btnapply_Click(object sender, EventArgs e)
    {
        Page Page = (Page)HttpContext.Current.CurrentHandler;
        if (!String.IsNullOrEmpty(Page.Request.QueryString["Mode"])) 
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.parent.location.href = 'feecancellation.aspx?AdmissionNo=" + tdadmitno.InnerHtml.Trim() + "'; </script>");
        else
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.parent.location.href = 'studentfee.aspx?date=" + Request["date"] + "&AdmissionNo=" + tdadmitno.InnerHtml.Trim() + "'; </script>");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Page Page = (Page)HttpContext.Current.CurrentHandler;
        if(!String.IsNullOrEmpty(Page.Request.QueryString["Mode"]))
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.parent.location.href = 'feecancellation.aspx'; </script>");
        else
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.parent.location.href = 'studentfee.aspx?date=" + Request["date"] + "'; </script>");
    }
    protected void ddlname_SelectedIndexChanged(object sender, EventArgs e)
    {
        tdparent.InnerHtml = "";
        tdadmitno.InnerHtml = "";
        ds = new DataSet();
        ds = CsFee.fncGetParent_For_Student(ddlstandard.SelectedValue, ddlsection.SelectedValue, ddlname.SelectedValue);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["Parent_details"].ToString() != "Mother")
                tdparent.InnerHtml = ds.Tables[0].Rows[0]["Father_Guardian"].ToString();
            else
                tdparent.InnerHtml = ds.Tables[0].Rows[0]["Mother"].ToString();
            tdadmitno.InnerHtml = ds.Tables[0].Rows[0]["AdmissionNo"].ToString();
        }
    }
}