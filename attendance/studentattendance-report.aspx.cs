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

public partial class detailsrecord_studentattendance_report : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {            
            fillstandard();
            ddlsection.Items.Insert(0, "--Select--");           
            lbldate.Text =DateTime.Now.ToShortDateString();
            txtdate.Text = DateTime.Now.ToShortDateString();
            string CurrentMonth = String.Format("{0:MMMM}", DateTime.Now);
            lblmonthandyear.Text = CurrentMonth + "&" + DateTime.Now.Year.ToString();  
        }
    }   
    protected void fillstandard()
    {
        string str;
        DataSet ds;
        DataAccess da = new DataAccess();
        str = "select strstandard from tblstandard_section_subject where intschoolid='" + Session["SchoolID"].ToString() + "' group by strstandard";
        da = new DataAccess();
        ds = da.ExceuteSql(str);
        ddlstandard.DataSource = ds;
        ddlstandard.DataTextField = "strstandard";
        ddlstandard.DataValueField = "strstandard";
        ddlstandard.DataBind();
        ddlstandard.Items.Insert(0, "--Select--");        
    }
    protected void fillsection()
    {
        ddlsection.Items.Clear();
        string str;
        DataSet ds;
        DataAccess da = new DataAccess();
        str = "select strsection from tblstandard_section_subject where intschoolid='" + Session["SchoolID"].ToString() + "' group by strsection";
        da = new DataAccess();
        ds = da.ExceuteSql(str);
        ddlsection.DataSource = ds;
        ddlsection.DataTextField = "strsection";
        ddlsection.DataValueField = "strsection";
        ddlsection.DataBind();
        ddlsection.Items.Insert(0, "--Select--");        
    }
    protected void ddlstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillsection();
        fillhometeacher();
        lblstandard.Text = ddlstandard.SelectedItem.Text;
        lblsection.Text = "";
        lblhometeacher.Text = "";
    }
    protected void ddlsection_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillhometeacher();
        lblsection.Text = ddlsection.SelectedItem.Text;
    }
    protected void fillhometeacher()
    {
        DataAccess da=new DataAccess();
        string str;
        DataSet ds;
        if (ddlstandard.SelectedIndex > 0 && ddlsection.SelectedIndex > 0)
        {
            lblstandard.Text = "";
            lblsection.Text = "";
            lblhometeacher.Text = "";
            lbldate.Text = "";
            string stdsec = ddlstandard.SelectedValue + " - " + ddlsection.SelectedValue;

            str = "select a.strfirstname+' '+a.strmiddlename+' '+a.strlastname as teachername from tblemployee a,tblhomeclass b where a.intschool=" + Session["SchoolID"].ToString() + " and a.intid=b.intemployee and b.strhomeclass='" + stdsec + "'";
            ds = new DataSet();
            ds = da.ExceuteSql(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblhometeacher.Text = ds.Tables[0].Rows[0]["teachername"].ToString();
            }
            
                lblstandard.Text = ddlstandard.SelectedItem.Text;
            
            
                lblsection.Text = ddlsection.SelectedItem.Text;
            
           lbldate.Text = txtdate.Text.Trim();
        }
    }
    protected void txtdate_TextChanged(object sender, EventArgs e)
    {
        lbldate.Text = "";
        lbldate.Text = txtdate.Text.Trim();
    }
    protected void dgattendance_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
