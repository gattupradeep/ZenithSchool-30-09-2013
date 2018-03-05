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

public partial class admin_academicterm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillyear();
            fillyear1();
            //Clear();
            fillAcademic();
        }
    }

    private void fillyear()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string sql = "select intyear from tblAcademicYear where intschool=" + Session["SchoolID"].ToString();
        ds = da.ExceuteSql(sql);
        ddlyear.DataSource = ds;
        ddlyear.DataTextField = "intyear";
        ddlyear.DataValueField = "intyear";
        ddlyear.DataBind();
        
    }
    private void fillyear1()
    {
        int i;
        int j = 0;
        for (i = 2011; i <= DateTime.Today.Year + 10; i++)
        {
            ListItem li;
            li = new ListItem(i.ToString(), i.ToString());
            ddlyear1.Items.Insert(j, li);
            ddlyear2.Items.Insert(j, li);
            j++;
        }
    }

    private void fillAcademic()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string sql = "select *, intid as ID, convert(varchar(10),ddtstartdate,103) as startdate, convert(varchar(10),ddtenddate,103) as enddate from tblschoolacademicterms where intschoolid=" + Session["SchoolID"].ToString();
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            dgAcademic.DataSource = ds.Tables[0];
            dgAcademic.DataBind();
        }
    }

    private void Clear()
    {
        ddlyear.SelectedValue = DateTime.Today.Year.ToString();

        ddlyear1.SelectedValue = DateTime.Today.Year.ToString();
        ddlyear2.SelectedValue = DateTime.Today.Year.ToString();

        ddlday1.SelectedValue = DateTime.Today.Day.ToString();
        ddlday2.SelectedValue = DateTime.Today.Day.ToString();

        ddlmonth1.SelectedValue = DateTime.Today.Month.ToString();
        ddlmonth2.SelectedValue = DateTime.Today.Month.ToString();
        btnSave.Text = "Save";
    }

    protected void dgAcademic_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["ID"] = e.Item.Cells[0].Text;
        ddlyear.SelectedValue =e.Item.Cells[1].Text;
        ddlterm.SelectedValue= e.Item.Cells[2].Text;
        ddlday1.SelectedValue = DateTime.Parse(e.Item.Cells[3].Text).Day.ToString();
        ddlmonth1.SelectedValue = DateTime.Parse(e.Item.Cells[3].Text).Month.ToString();
        ddlyear1.SelectedValue = DateTime.Parse(e.Item.Cells[3].Text).Year.ToString();
        ddlday2.SelectedValue = DateTime.Parse(e.Item.Cells[4].Text).Day.ToString();
        ddlmonth2.SelectedValue = DateTime.Parse(e.Item.Cells[4].Text).Month.ToString();
        ddlyear2.SelectedValue = DateTime.Parse(e.Item.Cells[4].Text).Year.ToString();
        btnSave.Text = "Update";
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {


        if (int.Parse(ddlyear1.SelectedValue) < int.Parse(ddlyear.SelectedValue) || int.Parse(ddlyear1.SelectedValue) > int.Parse(ddlyear.SelectedValue) + 1 || int.Parse(ddlyear2.SelectedValue) < int.Parse(ddlyear.SelectedValue) || int.Parse(ddlyear2.SelectedValue) > int.Parse(ddlyear.SelectedValue) + 1)
        {
            msgbox.alert("Invalid Start/End Year");
        }
        else if (DateTime.Parse(ddlyear1.SelectedValue + "/" + ddlmonth1.SelectedValue + "/" + ddlday1.SelectedValue) > DateTime.Parse(ddlyear2.SelectedValue + "/" + ddlmonth2.SelectedValue + "/" + ddlday2.SelectedValue))
        {
            msgbox.alert("Start Date is Greater than End Date");
        }
        else
        {
            SqlCommand RegCommand;
            SqlParameter OutPutParam;
            SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"]);

            Conn.Open();
            RegCommand = new SqlCommand("spschoolacademicterms", Conn);
            RegCommand.CommandType = CommandType.StoredProcedure;
            OutPutParam = RegCommand.Parameters.Add("@rc", SqlDbType.Int);
            OutPutParam.Direction = ParameterDirection.Output;
            if (btnSave.Text == "Save")
            {
                RegCommand.Parameters.Add("@intid", "0");
            }
            else
            {
                RegCommand.Parameters.Add("@intid", Session["ID"].ToString());
            }
            RegCommand.Parameters.Add("@intschoolid", Session["SchoolID"]);
            RegCommand.Parameters.Add("@intYear", ddlyear.SelectedValue);
            RegCommand.Parameters.Add("@strterm",ddlterm.SelectedValue);
            RegCommand.Parameters.Add("@ddtstartdate", ddlmonth1.SelectedValue + "/" + ddlday1.SelectedValue + "/" + ddlyear1.SelectedValue);
            RegCommand.Parameters.Add("@ddtenddate", ddlmonth2.SelectedValue + "/" + ddlday2.SelectedValue + "/" + ddlyear2.SelectedValue);
            RegCommand.ExecuteNonQuery();
            Conn.Close();
            string id = Convert.ToString(OutPutParam.Value);
            if (btnSave.Text == "Save")
            {
                Functions.UserLogs(Session["UserID"].ToString(), "tblschoolacademicterms", id, "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 0);
            }
            else
            {
                Functions.UserLogs(Session["UserID"].ToString(), "tblschoolacademicterms", id, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 0);
            }
            fillAcademic();
            Clear();
        }
    }
   
    //protected void dgAcademic_DeleteCommand(object source, DataGridCommandEventArgs e)
    //{
    //    try
    //    {
    //        DataAccess da = new DataAccess();
    //        string sql = "delete tblschoolacademicterms where ID=" + e.Item.Cells[0].Text;
    //        da.ExceuteSqlQuery(sql);
    //        fillAcademic();
    //    }
    //    catch { }
    //}

    
   
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Clear();
    }


    protected void btndelete_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ImageButton delete = (ImageButton)sender;
            TableCell cell = delete.Parent as TableCell;
            DataGridItem item = cell.Parent as DataGridItem;
            DataAccess da = new DataAccess();
            string sql = "delete tblschoolacademicterms where intID=" + item.Cells[0].Text;
            //Functions.UserLogs(Session["UserID"].ToString(), "tblschoolacademicterms", item.Cells[0].Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString());

            da.ExceuteSqlQuery(sql);
            fillAcademic();
        }
        catch { }
    }
}

