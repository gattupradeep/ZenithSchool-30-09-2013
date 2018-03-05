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

public partial class admin_schoollogintheme : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public SqlCommand cmd;
    public DataSet ds;
    public string sql;
    public DataAccess da;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            fillgrid();
    }

    protected void fillgrid()
    {
        try
        {
            sql = "select *,'<table border=\"1\"><tr><td style=\"width: 50px; height: 50px; background-color:#' + strbackground +'\"></td></tr></table>' as strback,'<table border=\"1\"><tr><td style=\"width: 50px; height: 50px; background-color:#' + strnavigation +'\"></td></tr></table>' as strnav,'<table border=\"1\"><tr><td style=\"width: 50px; height: 50px; background-color:#' + strfooter +'\"></td></tr></table>' as strfoot,'<table border=\"1\"><tr><td style=\"width: 50px; height: 50px; background-color:#' + strimagestitle +'\"></td></tr></table>' as strtitle from tbltheme";
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            ds = da.ExceuteSql(sql);
            dgdesig.DataSource = ds;
            dgdesig.DataBind();

            string theme = dgdesig.Items[0].Cells[1].Text;
            da = new DataAccess();
            string str = "select * from tblschooltheme where intschool=" + Session["SchoolID"].ToString();
            ds = new DataSet();
            ds = da.ExceuteSql(str);
            if (ds.Tables[0].Rows.Count > 0)
                theme = ds.Tables[0].Rows[0]["inttheme"].ToString();


            for (int i = 0; i < dgdesig.Items.Count; i++)
            {
                DataGridItem dgi = dgdesig.Items[i];
                RadioButton rbsel1 = new RadioButton();

                rbsel1 = (RadioButton)dgi.FindControl("rbselect");
                if (dgi.Cells[1].Text == theme)
                    rbsel1.Checked = true;
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + ex.Message + "')", true);
        }
    }

    protected void rbselect_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            RadioButton list = (RadioButton)sender;
            TableCell cell = list.Parent as TableCell;
            DataGridItem item = cell.Parent as DataGridItem;
            int index = item.ItemIndex;
            RadioButton rbsel = new RadioButton();

            rbsel = (RadioButton)item.FindControl("rbselect");

            for (int i = 0; i < dgdesig.Items.Count; i++)
            {
                DataGridItem dgi = dgdesig.Items[i];
                RadioButton rbsel1 = new RadioButton();

                rbsel1 = (RadioButton)dgi.FindControl("rbselect");
                if (i != index)
                    rbsel1.Checked = false;
                else
                    rbsel1.Checked = true;
            }


            da = new DataAccess();
            string str = "select * from tblschooltheme where intschool=" + Session["SchoolID"].ToString();
            DataSet ds = new DataSet();
            ds = da.ExceuteSql(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                str = "update tblschooltheme set inttheme=" + item.Cells[1].Text + " where intschool=" + Session["SchoolID"].ToString();
                Functions.UserLogs(Session["UserID"].ToString(), "tblschooltheme", Session["SchoolID"].ToString(), "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),112);
            }
            else
            {
                str = "insert into tblschooltheme (intschool,inttheme) values(" + Session["SchoolID"].ToString() + "," + item.Cells[1].Text + ")";
                da.ExceuteSqlQuery(str);

                DataSet ds2 = new DataSet();
                str = "select max(intid) as intid from tblschooltheme";
                ds2 = da.ExceuteSql(str);
                Functions.UserLogs(Session["UserID"].ToString(), "tblschooltheme", ds2.Tables[0].Rows[0]["intid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),112);
            
            }
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Theme is changed Successfully!')", true);

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + ex.Message + "')", true);
        }
    }
}
