using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
     //http://219.95.171.165/zenith/
        txtpassword.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + btnlogin.UniqueID + "').click();return false;}} else {return true}; ");

    }

    protected void btnlogin_Click(object sender, EventArgs e)
    {
        string sql;
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();

        try
        {
            sql = "select stremailid,strpassword,intschoolid from tblschool where stremailid = '" + txtuser.Text + "' ";
            ds = da.ExceuteSql(sql);

            if (ds.Tables[0].Rows.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Invalid User! Try again!')", true);
            }
            else if (ds.Tables[0].Rows.Count == 1)
            {
                if (ds.Tables[0].Rows[0][1].ToString() == txtpassword.Text.ToString())
                {
                    Session["SchoolID"] = "2";
                    Session["PatronType"] = "Super Admin";
                    Session["UserID"] = 0;
                    HttpCookie myCookie = new HttpCookie("logintype");
                    string val = "Super Admin";
                    DateTime now = DateTime.Now;
                    myCookie.Value = val;
                    myCookie.Expires = now.AddDays(1);
                    Response.Cookies.Add(myCookie);
                    redirectpages();                    
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Invalid Passowrd! Try again!')", true);
                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert(" + ex.Message + ")", true);
        }
    }

    protected void redirectpages()
    {
        string sql = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();

        Session["UserRights"] = "No";
        
        sql = "select * from tblschooldetails where intschoolid = " + Session["SchoolID"].ToString();
        ds = new DataSet();
        ds = da.ExceuteSql(sql);
        Session["SProfileIndex"] = 1;
        if (ds.Tables[0].Rows.Count > 0)
        {
            sql = "select * from tbltimingsandperiods where intschoolid = " + Session["SchoolID"].ToString();
            ds = new DataSet();
            ds = da.ExceuteSql(sql);
            Session["SProfileIndex"] = 2;
            if (ds.Tables[0].Rows.Count > 0)
            {
                sql = "select * from tblworkingdays where intschoolid = " + Session["SchoolID"].ToString();
                ds = new DataSet();
                ds = da.ExceuteSql(sql);
                Session["SProfileIndex"] = 3;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    sql = "select * from tblschoolstandard where intschoolid = " + Session["SchoolID"].ToString();
                    ds = new DataSet();
                    ds = da.ExceuteSql(sql);
                    Session["SProfileIndex"] = 4;
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        sql = "select * from tblstandard_section_subject where intschoolid = " + Session["SchoolID"].ToString();
                        ds = new DataSet();
                        ds = da.ExceuteSql(sql);
                        Session["SProfileIndex"] = 5;
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            sql = "select * from tblexamorder where intschoolid = " + Session["SchoolID"].ToString();
                            ds = new DataSet();
                            ds = da.ExceuteSql(sql);
                            Session["SProfileIndex"] = 6;
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                sql = "select * from tblschoolexampaper where intschoolid = " + Session["SchoolID"].ToString();
                                ds = new DataSet();
                                ds = da.ExceuteSql(sql);
                                Session["SProfileIndex"] = 7;
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    sql = "select * from tblschoolexamsettings where intschoolid = " + Session["SchoolID"].ToString();
                                    ds = new DataSet();
                                    ds = da.ExceuteSql(sql);
                                    Session["SProfileIndex"] = 8;
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        sql = "select * from tblschoolgrading where intschoolid = " + Session["SchoolID"].ToString();
                                        ds = new DataSet();
                                        ds = da.ExceuteSql(sql);
                                        Session["SProfileIndex"] = 9;
                                        if (ds.Tables[0].Rows.Count > 0)
                                        {
                                            sql = "select * from tblschoolperiods where intschoolid = " + Session["SchoolID"].ToString();
                                            ds = new DataSet();
                                            ds = da.ExceuteSql(sql);
                                            Session["SProfileIndex"] = 10;
                                            {
                                                if (ds.Tables[0].Rows.Count > 0)
                                                {
                                                    Session["SProfileIndex"] = 12;
                                                    Session["UserRights"] = "Yes";
                                                    Response.Redirect("school/viewschooldetails.aspx");
                                                }
                                                else
                                                    Response.Redirect("school/classtimingsandperiods.aspx");
                                            }
                                        }
                                        else
                                        {
                                            Response.Redirect("school/schoolgrading.aspx");
                                        }
                                    }
                                    else
                                        Response.Redirect("school/examdetailsettings.aspx");
                                }
                                else
                                    Response.Redirect("school/assignexampapers.aspx");
                            }
                            else
                                Response.Redirect("school/assignexamtypes.aspx");
                        }
                        else
                            Response.Redirect("school/subject_language_ExtraCurricular.aspx");
                    }
                    else
                        Response.Redirect("school/Class_Section_Subject_Details.aspx");
                }
                else
                    Response.Redirect("school/workingdays.aspx");
            }
            else
                Response.Redirect("school/timingsandperiods.aspx");
        }
        else
            Response.Redirect("school/schooldetails.aspx");
    }
}
