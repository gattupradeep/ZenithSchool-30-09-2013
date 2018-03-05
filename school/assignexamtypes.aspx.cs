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

public partial class school_assignexamtypes : System.Web.UI.Page
{
    public string strsql;
    public DataAccess da1;
    public DataSet ds1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int SPI = 0;
            try
            {
                SPI = int.Parse(Session["SProfileIndex"].ToString());
            }
            catch
            {
                SPI = 0;
            }
            if (SPI < 6 && SPI != 0)
                Session["SProfileIndex"] = 6;

            fillexamtype();
            allclear();
            if (Request["sid"] != null)
                filldetails();
        }

    }

    protected void ddlorderno_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList list = (DropDownList)sender;
        TableCell cell = list.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        int index = item.ItemIndex;
        DropDownList ddlorder = new DropDownList();
        ddlorder = (DropDownList)item.FindControl("ddlorderno");

        DataAccess da = new DataAccess();
        string str = "update tblexamorder set intorderno= (select intorderno from tblexamorder where intexamorderid=" + item.Cells[0].Text + ") where intorderno=" + ddlorder.SelectedValue;
        Functions.UserLogs(Session["UserID"].ToString(), "tblexamorder", ddlorder.SelectedValue, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),43);

        da.ExceuteSqlQuery(str);

        str = "update tblexamorder set intorderno='" + ddlorder.SelectedValue + "' where intexamorderid='" + item.Cells[0].Text + "'";//and intorder=" + item.Cells[4].Text + "+1";
        Functions.UserLogs(Session["UserID"].ToString(), "tblexamorder", item.Cells[0].Text, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),43);

        da.ExceuteSqlQuery(str);
        Session["order"] = ddlorder.SelectedValue;

        fillgrid();
    }

    protected void chkexamtypes_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillexamtypes();
    }

    protected void dgexamorder_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        string strsql = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();

        strsql = "select count(strexamtype) as strexamtype from tblexamorder where intschoolid='" + Session["SchoolID"].ToString() + "'";// group by intid,intschoolid,strexamtype,intorderno";
        ds = da.ExceuteSql(strsql);
        int count = int.Parse(ds.Tables[0].Rows[0]["strexamtype"].ToString());

        DataRowView dr = (DataRowView)e.Item.DataItem;
        DropDownList ddlorder = new DropDownList();
        ddlorder = (DropDownList)e.Item.FindControl("ddlorderno");

        try
        {
            for (int i = 1; i <= count; i++)
            {
                ListItem li;
                li = new ListItem(i.ToString(), i.ToString());
                ddlorder.Items.Add(li);
            }
            ddlorder.SelectedValue = dr["intorderno"].ToString();
        }
        catch { }
    }

    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("../school/viewexamtypes.aspx");
    }

    protected void btnaddexam_Click(object sender, EventArgs e)
    {
        Session["SelectedExamTypes"] = selectedexams();
        if (txtaddexamtype.Text != "")
        {
            try
            {
                string qry = "";
                DataAccess da = new DataAccess();
                DataSet ds = new DataSet();
                qry = "select * from tblexamtype where strexamtype='" + txtaddexamtype.Text.ToString() + "'";
                ds = da.ExceuteSql(qry);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Exam Type Already Exists!')", true);
                }
                else
                {
                    string strsql = "insert into tblexamtype(strexamtype)values('" + txtaddexamtype.Text + "')";
                    da.ExceuteSqlQuery(strsql);
                    txtaddexamtype.Text = "";
                    fillexamtype();
                    fillexamtype1();

                    DataSet ds2 = new DataSet();
                    strsql = "select max(intexamtypeid) as intexamtypeid from tblexamtype";
                    ds2 = da.ExceuteSql(strsql);
                    Functions.UserLogs(Session["UserID"].ToString(), "tblexamtype", ds2.Tables[0].Rows[0]["intexamtypeid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),43);
                }
            }
            catch { }
        }
    }

    protected void btnsave_Click1(object sender, EventArgs e)
    {
        if (Request["sid"] != null)
            Response.Redirect("viewexamtypes.aspx");
        else
            redirectpages();
    }

    protected void filldetails()
    {
        string qry;
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();

        qry = "select strexamtype from tblexamorder where intschoolid=" + Session["SchoolID"].ToString();
        ds = da.ExceuteSql(qry);
        for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
        {

            for (int i = 0; i < chkexamtypes.Items.Count; i++)
            {
                if (chkexamtypes.Items[i].Text == ds.Tables[0].Rows[j]["strexamtype"].ToString())
                {
                    chkexamtypes.Items[i].Selected = true;
                    strsql = " select * from tblschoolexamsettings where strexamtype='" + chkexamtypes.Items[i].Text + "' and intschoolid=" + Session["SchoolID"].ToString();
                    da1 = new DataAccess();
                    ds1 = new DataSet();
                    ds1 = da1.ExceuteSql(strsql);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        chkexamtypes.Items[i].Enabled = false;
                    }
                }
            }
        }
        fillgrid();
    }

    protected void fillexamtype()
    {
        string sql = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();

        sql = "select * from tblexamtype";
        ds = da.ExceuteSql(sql);

        chkexamtypes.Items.Clear();
        ListItem li;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            li = new ListItem(ds.Tables[0].Rows[i]["strexamtype"].ToString(), ds.Tables[0].Rows[i]["strexamtype"].ToString());
            chkexamtypes.Items.Add(li);
        }
    }

    protected void fillexamtype1()
    {
        try
        {
            for (int i = 0; i < chkexamtypes.Items.Count; i++)
            {
                string[] abc = Session["SelectedExamTypes"].ToString().Split(',');
                for (int j = 0; j < abc.Length; j++)
                {
                    if (chkexamtypes.Items[i].Value.ToString() == abc[j].Trim())
                    {
                        chkexamtypes.Items[i].Selected = true;
                        strsql = " select * from tblschoolexamsettings where strexamtype='" + abc[j].Trim() + "' and intschoolid=" + Session["SchoolID"].ToString();
                        da1 = new DataAccess();
                        ds1 = new DataSet();
                        ds1 = da1.ExceuteSql(strsql);
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            chkexamtypes.Items[i].Enabled = false;
                        }

                    }
                }
            }
        }
        catch { }
    }

    protected string selectedexams()
    {
        string str = "";
        for (int i = 0; i < chkexamtypes.Items.Count; i++)
        {
            if (chkexamtypes.Items[i].Selected == true)
            {
                if (str.Length == 0)
                {
                    str = chkexamtypes.Items[i].Value.ToString();
                }
                else
                {
                    str = str + "," + chkexamtypes.Items[i].Value.ToString();
                }
            }
        }
        return str;
    }

    protected void allclear()
    {
        for (int i = 0; i < chkexamtypes.Items.Count; i++)
        {
            chkexamtypes.Items[i].Selected = false;
        }
    }

    protected void fillexamtypes()
    {
        string strsql = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();

        strsql = "delete tblexamorder where intschoolid=" + Session["SchoolID"].ToString();
        Functions.UserLogs(Session["UserID"].ToString(), "tblexamorder",Session["SchoolID"].ToString() , "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),43);

        da.ExceuteSqlQuery(strsql);
        int j = 0;
        for (int i = 0; i < chkexamtypes.Items.Count; i++)
        {
            if (chkexamtypes.Items[i].Selected == true)
            {
                j++;

                strsql = "insert into tblexamorder(intschoolid,strexamtype,intorderno) values(" + Session["SchoolID"].ToString() + ",'" + chkexamtypes.Items[i].Value + "'," + j.ToString() + ")";
                da.ExceuteSqlQuery(strsql);

                DataSet ds2 = new DataSet();
                strsql = "select max(intexamorderid) as intexamorderid from tblexamorder";
                ds2 = da.ExceuteSql(strsql);
                Functions.UserLogs(Session["UserID"].ToString(), "tblexamorder", ds2.Tables[0].Rows[0]["intexamorderid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),43);
            }
        }
        fillgrid();
    }

    protected void fillgrid()
    {
        string strsql = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();

        strsql = " select * from tblexamorder where intschoolid=" + Session["SchoolID"].ToString() + " order by intorderno ";
        ds = da.ExceuteSql(strsql);

        dgexamorder.DataSource = ds;
        dgexamorder.DataBind();
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
                                            Session["SProfileIndex"] = 10;
                                            Session["UserRights"] = "Yes";
                                            Response.Redirect("../school/viewschooldetails.aspx");
                                        }
                                        else
                                            Response.Redirect("../school/schoolgrading.aspx");
                                    }
                                    else
                                        Response.Redirect("../school/examdetailsettings.aspx");
                                }
                                else
                                    Response.Redirect("../school/assignexampapers.aspx");
                            }
                            else
                                Response.Redirect("../school/assignexamtypes.aspx");
                        }
                        else
                            Response.Redirect("../school/subject_language_ExtraCurricular.aspx");
                    }
                    else
                        Response.Redirect("../school/Class_Section_Subject_Details.aspx");
                }
                else
                    Response.Redirect("../school/workingdays.aspx");
            }
            else
                Response.Redirect("../school/timingsandperiods.aspx");
        }
        else
            Response.Redirect("../school/schooldetails.aspx");
    }

}
