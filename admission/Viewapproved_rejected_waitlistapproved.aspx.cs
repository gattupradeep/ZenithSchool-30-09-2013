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

public partial class admission_Viewapproved_rejected_waitlistapproved : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
            standard();
            student();
        }
    }
    protected void standard()
    {
        string str;
        DataSet ds;
        DataAccess da = new DataAccess();
        str = "select str_standard from dbo.tblstudentadmission where intschool=" + Session["SchoolID"].ToString() + " group by str_standard";
        da = new DataAccess();
        ds = da.ExceuteSql(str);
        ddlstandard.DataSource = ds;
        ddlstandard.DataTextField = "str_standard";
        ddlstandard.DataValueField = "str_standard";
        ddlstandard.DataBind();
        ddlstandard.Items.Insert(0, "-Select-");
        ddlstandard.Items.Insert(1, "-All-");
    }
    protected void student()
    {
        string str;
        DataSet ds;
        DataAccess da = new DataAccess();
        str = "select str_firstname + '' + str_middlename + '' + str_lastname as name,intid from dbo.tblstudentadmission where intschool=" + Session["SchoolID"].ToString();
        da = new DataAccess();
        ds = da.ExceuteSql(str);
        ddlstudent.DataSource = ds;
        ddlstudent.DataTextField = "name";
        ddlstudent.DataValueField = "intid";
        ddlstudent.DataBind();
        ddlstudent.Items.Insert(0, "-Select-");
    }
   protected void fillgrid()
    {

        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str = "select *,convert(varchar(11),dtdate,103) as date, str_firstname + '' + str_middlename + '' + str_lastname as name,str_fatherorguardianname,str_mothername,str_fatherorguardianqualification,str_fatherorguardianoccupation,str_motherqualification,str_motheroccupation,convert(varchar(11),str_dateofbirth,103) as dateofbirth,intage,str_standard,str_second_language+' - '+str_third_language as language,str_hostel,str_transport from tblstudentadmission where intschool=" + Session["SchoolID"].ToString();
        ds=da.ExceuteSql(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ddllist.SelectedValue == "Approved")
            {
                 str = "select *,convert(varchar(11),dtdate,103) as date, str_firstname + '' + str_middlename + '' + str_lastname as name,str_fatherorguardianname,str_mothername,str_fatherorguardianqualification,str_fatherorguardianoccupation,str_motherqualification,str_motheroccupation,convert(varchar(11),str_dateofbirth,103) as dateofbirth,intage,str_standard,str_second_language+' - '+str_third_language as language,str_hostel,str_transport from tblstudentadmission where intschool=" + Session["SchoolID"].ToString() + " and intapprove=1";

                  if (ddlstandard.SelectedIndex > 1)
                    {
                        str = str + " and str_standard='" + ddlstandard.SelectedValue + "'";
                    }
                    if (ddlstudent.SelectedIndex > 0)
                    {
                        str = str + "and intid ='" + ddlstudent.SelectedValue + "'";
                    }
            }
               if (ddllist.SelectedValue == "Rejected")
                {
                    str = "select *,convert(varchar(11),dtdate,103) as date, str_firstname + '' + str_middlename + '' + str_lastname as name,str_fatherorguardianname,str_mothername,str_fatherorguardianqualification,str_fatherorguardianoccupation,str_motherqualification,str_motheroccupation,convert(varchar(11),str_dateofbirth,103) as dateofbirth,intage,str_standard,str_second_language+' - '+str_third_language as language,str_hostel,str_transport from tblstudentadmission where intschool=" + Session["SchoolID"].ToString() + " and intapprove=2";

                       if (ddlstandard.SelectedIndex > 1)
                        {
                            str = str + " and str_standard='" + ddlstandard.SelectedValue + "'";
                        }
                        if (ddlstudent.SelectedIndex > 0)
                        {
                            str = str + "and intid ='" + ddlstudent.SelectedValue + "'";
                        }
                       
                 }
               if (ddllist.SelectedValue == "Waitlisted Approved")
               {
                   str = "select *,convert(varchar(11),dtdate,103) as date, str_firstname + '' + str_middlename + '' + str_lastname as name,str_fatherorguardianname,str_mothername,str_fatherorguardianqualification,str_fatherorguardianoccupation,str_motherqualification,str_motheroccupation,convert(varchar(11),str_dateofbirth,103) as dateofbirth,intage,str_standard,str_second_language+' - '+str_third_language as language,str_hostel,str_transport from tblstudentadmission where intschool=" + Session["SchoolID"].ToString() + " and intwaitlist=1";

                   if (ddlstandard.SelectedIndex > 1)
                   {
                       str = str + " and str_standard='" + ddlstandard.SelectedValue + "'";
                   }
                   if (ddlstudent.SelectedIndex > 0)
                   {
                       str = str + "and intid ='" + ddlstudent.SelectedValue + "'";
                   }
                  
             }
                
             }
         ds = da.ExceuteSql(str);
         dgadmission.DataSource = ds;
         dgadmission.DataBind();
    }
    protected void dgadmission_UpdateCommand(object source, DataGridCommandEventArgs e)
    {
        Response.Redirect("view_approvalrequest.aspx?lid=" + e.Item.Cells[0].Text);
    }
   protected void ddlstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void ddlstudent_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str = "select str_staff1,str_department1,str_designation1 from tblstudentadmission where intschool=" + Session["SchoolID"].ToString() + " and intid=" + ddlstudent.SelectedValue + " group by str_staff1,str_department1,str_designation1";
        ds = da.ExceuteSql(str);
       fillgrid();
    }
   protected void dgadmission_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        try
        {
            //In grid there is no staff,department,designation and groups(that means in grid) we hide in this process.
            DataRowView dr = (DataRowView)e.Item.DataItem;
            Label lblstaff = (Label)e.Item.FindControl("lblstaffname");
            if (dr["str_staff1"].ToString() == "")
                lblstaff.Visible = false;
            Label lbldept = (Label)e.Item.FindControl("lbldepartment");
            if (dr["str_department1"].ToString() == "")
                lbldept.Visible = false;
            Label lbldesig = (Label)e.Item.FindControl("lbldesignation");
            if (dr["str_designation1"].ToString() == "")
                lbldesig.Visible = false;
            Label lblgroups = (Label)e.Item.FindControl("lblgroup");
            if (dr["str_groups"].ToString() == "")
                lblgroups.Visible = false;
         }
        catch { }
    }
    protected void ddllist_SelectedIndexChanged(object sender, EventArgs e)
    {
        standard();
        student();
       
    }
}
