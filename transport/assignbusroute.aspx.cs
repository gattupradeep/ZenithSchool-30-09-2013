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

public partial class transport_assignbusroute : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public SqlCommand cmd;
    public string strsql;
    public DataAccess da;
    public DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillgrid();
            fillroute();
            fillhour();
            fillminutes();
            Clear();
        }
    }

    private void fillgrid()
    {
        DataAccess da = new DataAccess();
        string sql = "select convert(varchar(5),a.dtpickuptime,108) as dtpickuptime,convert(varchar(5),a.dtdroptime,108) as dtdroptime,a.*,b.strroutename";
		sql += " from tblassignbusroute a,tblroute b where a.intschool=" + Session["SchoolID"].ToString()+" and a.introute=b.intid and a.intschool=b.intschool";
       // string sql = " select  * from tblassignbusroute";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);       
        dgasgnbusroute.DataSource = ds.Tables[0];       
        dgasgnbusroute.DataBind();
    }

    private void fillroute()
    {
        string sql;
        sql = "select * from tblroute where intschool=" + Session["SchoolID"].ToString();
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        ddlroute.DataSource = ds;
        ddlroute.DataTextField = "strroutename";
        ddlroute.DataValueField = "intid";
        ddlroute.DataBind();
    }

    public void fillhour()
    {
        int i, j = 0;
        for (i = 0; i <= 12; i++)
        {
            if (i < 10)
            {
                ListItem li;
                li = new ListItem("0"+i.ToString(), "0" + i.ToString());
                ddlpickhour.Items.Insert(j, li);
                ddldrophour.Items.Insert(j, li);
            }
            else
            {
                ListItem li;
                li = new ListItem(i.ToString(), i.ToString());
                ddlpickhour.Items.Insert(j, li);
                ddldrophour.Items.Insert(j, li);
            }
                j++;
        }
    }
    public void fillminutes()
    {
        int i, j = 0;
        for (i = 0; i <= 55; i=i+5)
        {
            if (i < 10)
            {
                ListItem li;
                li = new ListItem("0"+i.ToString(), "0" + i.ToString());
                ddlpickmin.Items.Insert(j, li);
                ddldropmin.Items.Insert(j, li);
            }
            else
            {
                ListItem li;
                li = new ListItem(i.ToString(), i.ToString());
                ddlpickmin.Items.Insert(j, li);
                ddldropmin.Items.Insert(j, li);
            }
            j++;
        }
    }
    private void Clear()
    {
        txtdestination.Text = "";
        txtamount.Text = "";
        ddlpickhour.SelectedIndex = 0;
        ddlpickmin.SelectedIndex = 0;
        ddldrophour.SelectedIndex = 0;
        ddldropmin.SelectedIndex = 0;        
        btnSave.Text = "Save";
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlCommand RegCommand;
        SqlParameter OutPutParam;
        SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        Conn.Open();
        RegCommand = new SqlCommand("spassignbusroute", Conn);
        RegCommand.CommandType = CommandType.StoredProcedure;
        OutPutParam = RegCommand.Parameters.Add("@rc", SqlDbType.Int);
        OutPutParam.Direction = ParameterDirection.Output;
        if (btnSave.Text == "Save")
        {
            RegCommand.Parameters.Add("@intID", "0");
        }
        else
        {
            RegCommand.Parameters.Add("@intID", Session["intID"].ToString());
        }
        RegCommand.Parameters.Add("@introute", ddlroute.SelectedValue);
        RegCommand.Parameters.Add("@strdestination", txtdestination.Text);
        RegCommand.Parameters.Add("@dtpickuptime", ddlpickhour.SelectedValue + ":" + ddlpickmin.SelectedValue + " " + ddlpickcat.SelectedValue );
        RegCommand.Parameters.Add("@dtdroptime", ddldrophour.SelectedValue + ":" + ddldropmin.SelectedValue + " " + ddldropcat.SelectedValue);
        RegCommand.Parameters.Add("@intamount", txtamount.Text);
        RegCommand.Parameters.Add("@intschool", Session["SchoolID"].ToString());
        RegCommand.ExecuteNonQuery();
        if ((int)(RegCommand.Parameters["@rc"].Value) == 0)
        {
            MsgBox1.alert("The Pickup place already assigned!");
        }
        Conn.Close();
        string id = Convert.ToString(OutPutParam.Value);
        if (btnSave.Text == "Save")
        {
            Functions.UserLogs(Session["UserID"].ToString(), "tblassignbusroute", id, "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 118);
        }
        else
        {
            Functions.UserLogs(Session["UserID"].ToString(), "tblassignbusroute", id, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 118);
        }
        Clear();
        fillgrid();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Details Saved Successfully!')", true);
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Clear();
    }
    //protected void dgasgnbusroute_DeleteCommand(object source, DataGridCommandEventArgs e)
    //{
    //    string sql = "delete tblassignbusroute where intid=" + e.Item.Cells[0].Text;
    //    cmd = new SqlCommand(sql, conn);
    //    conn.Open();
    //    cmd.ExecuteNonQuery();
    //    conn.Close();
    //    fillgrid();
    //}
    protected void dgasgnbusroute_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["intID"] = e.Item.Cells[0].Text;
        txtdestination.Text = e.Item.Cells[1].Text;
        ddlroute.Text = e.Item.Cells[2].Text;     
        string ss = DateTime.Parse(e.Item.Cells[3].Text).Hour.ToString();
        if (DateTime.Parse(e.Item.Cells[3].Text).Hour == 0)
            ddlpickhour.SelectedValue = "12";
        else
        {
            if (DateTime.Parse(e.Item.Cells[3].Text).Hour > 12)
            {
                ss = (DateTime.Parse(e.Item.Cells[3].Text).Hour - 12).ToString();
                int tt = DateTime.Parse(e.Item.Cells[3].Text).Hour - 12;
                if (tt < 10)
                    ss = "0" + ss;
                else
                ss = DateTime.Parse(e.Item.Cells[3].Text).Hour.ToString();
                ddlpickhour.SelectedValue = ss;
                ddlpickcat.SelectedValue = "PM";
            }
            else
            {
                ss = DateTime.Parse(e.Item.Cells[3].Text).Hour.ToString();
                int tt = DateTime.Parse(e.Item.Cells[3].Text).Hour - 12;
                if (tt < 10)
                    ss = "0" + ss;
                else
                ss = DateTime.Parse(e.Item.Cells[3].Text).Hour.ToString();
                ddlpickhour.SelectedValue = ss;
                ddlpickcat.SelectedValue = "AM";
            }
        }

        ddlpickmin.SelectedValue = DateTime.Parse(e.Item.Cells[3].Text).Minute.ToString();  
        string ts = DateTime.Parse(e.Item.Cells[4].Text).Hour.ToString();
        if (DateTime.Parse(e.Item.Cells[4].Text).Hour == 0)
            ddldrophour.SelectedValue = "12";
        else
        {
            if (DateTime.Parse(e.Item.Cells[4].Text).Hour > 12)
            {
                ts = (DateTime.Parse(e.Item.Cells[4].Text).Hour - 12).ToString();
                int tt = DateTime.Parse(e.Item.Cells[4].Text).Hour - 12;
                if (tt < 10)
                    ts = "0" + ts;
                else
                ts = DateTime.Parse(e.Item.Cells[4].Text).Hour.ToString();
                ddldrophour.SelectedValue = ts;
                ddldropcat.SelectedValue = "PM";
            }
            else
            {
                ts = DateTime.Parse(e.Item.Cells[4].Text).Hour.ToString();
                int tt = DateTime.Parse(e.Item.Cells[4].Text).Hour - 12;
                if (tt < 10)
                    ts = "0" + ts;
                else
                    ts = DateTime.Parse(e.Item.Cells[4].Text).Hour.ToString();
                ddldrophour.SelectedValue = ts;
                ddldropcat.SelectedValue = "AM";
            }
        }
        ddldropmin.SelectedValue = DateTime.Parse(e.Item.Cells[4].Text).Minute.ToString();    
        txtamount.Text = e.Item.Cells[5].Text;
        btnSave.Text = "Update";
    }
    protected void btndelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton delete = (ImageButton)sender;
        TableCell cell = delete.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        string sql = "delete tblassignbusroute where intid=" + item.Cells[0].Text;
        cmd = new SqlCommand(sql, conn);
        conn.Open();
        Functions.UserLogs(Session["UserID"].ToString(), "tblassignbusroute", item.Cells[0].Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),118);
        cmd.ExecuteNonQuery();
        conn.Close();
        fillgrid();
    }
}
