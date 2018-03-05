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
using System.Reflection;

public partial class Admin_login : System.Web.UI.Page
{
    public DataAccess da;
    public DataSet ds;
    public string strback, strnav, strfoot, strtitle, str;
    public int nindex = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        txtpassword.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + btnlogin.UniqueID + "').click();return false;}} else {return true}; ");
    }
    protected void btnlogin_Click(object sender, EventArgs e)
    {
        string sql="";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        try
        {
            if (ddlpatron.SelectedValue == "Staffs" || ddlpatron.SelectedValue == "Parents" || ddlpatron.SelectedValue == "Students")
            {
                if (ddlpatron.SelectedValue == "Parents")
                    sql = "select strparentusername,strparentpassword,intid,strstandard + ' - ' + strsection as strclass from tblstudent where intschool=" + Session["SchoolID"].ToString() + " and strparentusername= '" + txtusername.Text + "'";
                else if (ddlpatron.SelectedValue == "Students")
                    sql = "select strstudentusername,strstudentpassword,intid,strstandard + ' - ' + strsection as strclass from tblstudent where intschool=" + Session["SchoolID"].ToString() + " and strstudentusername= '" + txtusername.Text + "'";
                else if (ddlpatron.SelectedValue == "Staffs")
                    sql = "select loginid,strpassword,intid,strtype from tblemployee where intschool=" + Session["SchoolID"].ToString() + " and loginid= '" + txtusername.Text + "'";
                ds = da.ExceuteSql(sql);

                if (ds.Tables[0].Rows.Count == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Login ID not registered!')", true);
                }
                else if (ds.Tables[0].Rows.Count == 1)
                {
                    if (ds.Tables[0].Rows[0][1].ToString() == txtpassword.Text.ToString())
                    {
                        if (ddlpatron.SelectedValue == "Students")
                            Session["PatronType"] = "Students";
                        else if (ddlpatron.SelectedValue == "Parents")
                            Session["PatronType"] = "Parents";
                        else if(ddlpatron.SelectedValue == "Staffs")
                            Session["PatronType"] = ds.Tables[0].Rows[0]["strtype"].ToString();

                        Session["UserID"] = ds.Tables[0].Rows[0]["intid"].ToString();
                        Session["UserRights"] = "Yes";

                        if (ddlpatron.SelectedValue == "Students" || ddlpatron.SelectedValue == "Parents")
                        {
                            Session["StudentClass"] = ds.Tables[0].Rows[0]["strclass"].ToString();
                            Response.Redirect("../welcome/welcome_students.aspx");
                        }
                        else if (ddlpatron.SelectedValue == "Staffs")
                        {
                            if (ds.Tables[0].Rows[0]["strtype"].ToString() == "Admin")
                                Response.Redirect("../welcome/welcome_admin.aspx");
                            else if (ds.Tables[0].Rows[0]["strtype"].ToString() == "Super Admin")
                                Response.Redirect("../school/viewschooldetails.aspx");
                            else
                                Response.Redirect("../welcome/welcome_teacher.aspx");
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Invalid Passowrd! Try again!')", true);
                    }
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Invalid User!')", true);
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert(" + ex.Message + ")", true);
        }
    }
}

