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

public partial class school_school_uniform_details : System.Web.UI.Page
{
    public int c = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillweekdays();
            if (Request["id"] != null)
            {
                fillclasstype();
                fillgrid();
                btncancel.Visible = true;
            }
            else
            {
                fillclasstype();
                btncancel.Visible = false;
                fillgrid();
            }            
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        clear();
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("../school/viewschooluniform.aspx");
    }
    //protected void dgschool_DeleteCommand(object source, DataGridCommandEventArgs e)
    //{
    //    string str = "";
    //    DataAccess da = new DataAccess();
    //    str = "delete tblschooluniform where intschooluniformid=" + e.Item.Cells[0].Text + " and intschoolid=" + Session["SchoolID"].ToString();
    //    da.ExceuteSqlQuery(str);
    //    fillgrid();
    //}
    protected void dgschool_EditCommand(object source, DataGridCommandEventArgs e)
    {
        string str = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();
        str = "select * from tblschooluniform where intschoolid=" + Session["SchoolID"].ToString() + "and intschooluniformid=" + e.Item.Cells[0].Text;
        ds = da.ExceuteSql(str);
        Session["intschooluniformid"] = e.Item.Cells[0].Text;
        for (int i = 0; i < chkweeks.Items.Count; i++)
        {
            if (chkweeks.Items[i].Selected == true)
                chkweeks.Items[i].Selected = false;
        }                                                                            
        for (int i = 0; i < chkstandard.Items.Count; i++)
        {
            if (chkstandard.Items[i].Selected == true)
                chkstandard.Items[i].Selected = false;
        }
        string[] abc = ds.Tables[0].Rows[0]["strweekdays"].ToString().Split(',');
        for (int i = 0; i < chkweeks.Items.Count; i++)
        {
            for (int j = 0; j < abc.Length; j++)
            {
                if (chkweeks.Items[i].Value.ToString() == abc[j].ToString())
                    chkweeks.Items[i].Selected = true;
            }
        }
        string[] ab = ds.Tables[0].Rows[0]["strstandard"].ToString().Split(',');
        for (int i = 0; i < chkstandard.Items.Count; i++)
        {
            for (int j = 0; j < ab.Length; j++)
            {
                if (chkstandard.Items[i].Value.ToString() == ab[j].ToString())
                    chkstandard.Items[i].Selected = true;
            }
        }
        txtshirt.Text = e.Item.Cells[3].Text;
        txttrouser.Text = e.Item.Cells[4].Text;
        txtBshoes.Text = e.Item.Cells[5].Text;
        txtBsocks.Text = e.Item.Cells[6].Text;
        txtBother.Text = ds.Tables[0].Rows[0]["strBother"].ToString();
        txttop.Text = e.Item.Cells[7].Text;
        txtbottom.Text = e.Item.Cells[8].Text;
        txtGshoes.Text = e.Item.Cells[9].Text;
        txtGsocks.Text = e.Item.Cells[10].Text;
        txtGother.Text = ds.Tables[0].Rows[0]["strGother"].ToString();
        btnSave.Text = "Update";
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        checkforvalid();
        int std = 0;
        int wee = 0;
        for (int j = 0; j < chkstandard.Items.Count; j++)
        {
            if (chkstandard.Items[j].Selected == true)
                std = 1;
        }
        for (int j = 0; j < chkweeks.Items.Count; j++)
        {
            if (chkweeks.Items[j].Selected == true)
                wee = 1;
        }
        if (std == 1)
        {
            if (wee == 1)
            {
                if ((txtshirt.Text != "" || txttop.Text != "") && (txttrouser.Text != "" || txtbottom.Text != "") && (txtBshoes.Text != "" || txtGshoes.Text != "") && (txtBsocks.Text != "" || txtGsocks.Text != ""))
                {
                    if (c == 0)
                    {
                        SqlCommand command = new SqlCommand();
                        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
                        SqlParameter OutPutParam;
                        conn.Open();
                        command = new SqlCommand("SPschooluniform", conn);
                        command.CommandType = CommandType.StoredProcedure;
                        OutPutParam = command.Parameters.Add("@rc", SqlDbType.Int);
                        OutPutParam.Direction = ParameterDirection.Output;
                        if (btnSave.Text == "Save")
                        {
                            command.Parameters.Add("@intid", "0");
                        }
                        else
                        {
                            command.Parameters.Add("@intid", Session["intschooluniformid"].ToString());

                        }
                        command.Parameters.Add("@strstandard", selectedstandard());
                        command.Parameters.Add("@strweekdays", selectedweeks());
                        command.Parameters.Add("@strshirt", txtshirt.Text.Trim());
                        command.Parameters.Add("@strtrouserOrpant", txttrouser.Text.Trim());
                        command.Parameters.Add("@strBshoes", txtBshoes.Text.Trim());
                        command.Parameters.Add("@strBsocks", txtBsocks.Text.Trim());
                        command.Parameters.Add("@strBother", txtBother.Text.Trim());
                        command.Parameters.Add("@strtop", txttop.Text.Trim());
                        command.Parameters.Add("@strbottom", txtbottom.Text.Trim());
                        command.Parameters.Add("@strGshoe", txtGshoes.Text.Trim());
                        command.Parameters.Add("@strGsocks", txtGsocks.Text.Trim());
                        command.Parameters.Add("@strGother", txtGother.Text.Trim());
                        command.Parameters.Add("@intschool", Session["SchoolID"].ToString());
                        command.ExecuteNonQuery();
                        if ((int)(command.Parameters["@rc"].Value) > 0)
                        {
                            int sid = (int)(command.Parameters["@rc"].Value);
                            try
                            {
                                if (FileUpload1.PostedFile.FileName != "")
                                {
                                    FileUpload1.PostedFile.SaveAs(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\uniform\\" + sid + "_boys.jpg");
                                }
                                if (FileUpload2.PostedFile.FileName != "")
                                {
                                    FileUpload2.PostedFile.SaveAs(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "images\\uniform\\" + sid + "_girls.jpg");
                                }
                            }
                            catch { }
                        }
                        conn.Close();
                        string id = Convert.ToString(OutPutParam.Value);
                        if (btnSave.Text == "Save")
                        {
                            Functions.UserLogs(Session["UserID"].ToString(), "tblschooluniform", id, "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 31);
                        }
                        else
                        {
                            Functions.UserLogs(Session["UserID"].ToString(), "tblschooluniform", id, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 31);

                        }
                        clear();
                        fillgrid();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Uniform is already assigned for selected standard and weekdays')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Enter Values Atleast for Boy or Girl')", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Select Atleast One Week Day')", true);
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Select Atleast One Standard')", true);
        }
    }
    protected void clear()
    {
        txtBother.Text = "";
        txtbottom.Text = "";
        txtBshoes.Text = "";
        txtBsocks.Text = "";
        txtGother.Text = "";
        txtGshoes.Text = "";
        txtGsocks.Text = "";
        txtshirt.Text = "";
        txttop.Text = "";
        txttrouser.Text = "";
        btnSave.Text = "Save";
        for (int i = 0; i < chkweeks.Items.Count; i++)
        {
            if (chkweeks.Items[i].Selected == true)
                chkweeks.Items[i].Selected = false;
        }
        for (int i = 0; i < chkstandard.Items.Count; i++)
        {
            if (chkstandard.Items[i].Selected == true)
                chkstandard.Items[i].Selected = false;
        }
    }
    protected void checkforvalid()
    {
        string str = "";
        string weekday = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();
        for (int i = 0; i < chkstandard.Items.Count; i++)
        {
            if (chkstandard.Items[i].Selected == true)
            {
                if(btnSave.Text=="Save")
                    str = "select strweekdays from tblschooluniform where strstandard like '%" + chkstandard.Items[i].Text + "%' and intschoolid=" + Session["SchoolID"].ToString();
                else
                    str = "select strweekdays from tblschooluniform where strstandard like '%" + chkstandard.Items[i].Text + "%' and intschoolid=" + Session["SchoolID"].ToString() + " and intschooluniformid !=" + Session["intschooluniformid"];
                ds = da.ExceuteSql(str);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                    {
                        for (int k = 0; k < chkweeks.Items.Count; k++)
                        {
                            if (chkweeks.Items[k].Selected)
                            {
                                if (ds.Tables[0].Rows[j]["strweekdays"].ToString().IndexOf(chkweeks.Items[k].Text) > -1)
                                {
                                    weekday = weekday + chkweeks.Items[k].Text;                                    
                                    c = 1;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    protected void fillweekdays()
    {
        try
        {
            string sql = "";
            DataSet ds = new DataSet();
            DataAccess da = new DataAccess();
            sql = "select * from (select 'Monday' as strday union all select 'Tuesday' as strday union all select 'Wednesday' as strday union all select 'Thursday' as strday union all select 'Friday' as strday union all select 'Saturday' as strday union all select 'Sunday' as strday) as a where strday not in (select strweekholidays from tblworkingdays  where intschoolid=" + Session["SchoolID"].ToString() + " and strmode='Holiday')";
            ds = da.ExceuteSql(sql);
            chkweeks.Items.Clear();
            chkweeks.DataValueField = "strday";
            chkweeks.DataTextField = "strday";
            chkweeks.DataSource = ds;
            chkweeks.DataBind();
        }
        catch { }
    }
    protected void fillclasstype()
    {
        try
        {
            string sql = "";
            DataSet ds = new DataSet();
            DataAccess da = new DataAccess();
            sql = "select * from tblschoolstandard where intschoolid=" + Session["SchoolID"];
            ds = da.ExceuteSql(sql);
            chkstandard.Items.Clear();
            ListItem li;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                li = new ListItem(ds.Tables[0].Rows[i]["strstandard"].ToString(), ds.Tables[0].Rows[i]["strstandard"].ToString());
                chkstandard.Items.Add(li);
            }
            
        }
        catch { }
    }    
    protected string selectedweeks()
    {
        string str = "";
        for (int i = 0; i <chkweeks.Items.Count; i++)
        {
            if (chkweeks.Items[i].Selected == true)
            {
                if (str.Length == 0)
                {
                    str = chkweeks.Items[i].Value.ToString();
                }
                else
                {
                    str = str + "," + chkweeks.Items[i].Value.ToString();
                }
                chkweeks.Items[i].Selected = false;
            }
        }
        return str;        
    }
    protected string selectedstandard()
    {
        string str = "";
        for (int i = 0; i < chkstandard.Items.Count; i++)
        {
            if (chkstandard.Items[i].Selected == true)
            {
                if (str.Length == 0)
                {
                    str = chkstandard.Items[i].Value.ToString();
                }
                else
                {
                    str = str + "," + chkstandard.Items[i].Value.ToString();
                }
                chkstandard.Items[i].Selected = false;
            }
        }
        return str;
    }
   protected void fillgrid()
    {
        string str = "";
        DataSet ds = new DataSet();
        DataAccess da = new DataAccess();
        str = "select *,strBother +',' + strGother as other from dbo.tblschooluniform where intschoolid=" + Session["SchoolID"].ToString();
        ds = da.ExceuteSql(str);
        dgschool.DataSource = ds;
        dgschool.DataBind();
    }

    //protected void filluniformdetails()
    //{
    //    string str;
    //    DataSet ds;
    //    DataAccess da = new DataAccess();
    //    str = "select *  from dbo.tblschooluniform where intschoolid=" + Session["SchoolID"].ToString();
    //    da = new DataAccess();
    //    ds = new DataSet();
    //    ddlstandard.SelectedValue = ds.Tables[0].Rows[0][""].ToString();
    //    txtshirt.Text = ds.Tables[0].Rows[0][""].ToString();
    //    txttrouser.Text = ds.Tables[0].Rows[0][""].ToString();
    //    txtBshoes.Text = ds.Tables[0].Rows[0][""].ToString();
    //    txtBsocks.Text = ds.Tables[0].Rows[0][""].ToString();
    //    txtBother.Text = ds.Tables[0].Rows[0][""].ToString();
    //    txttop.Text = ds.Tables[0].Rows[0][""].ToString();
    //    txtbottom.Text = ds.Tables[0].Rows[0][""].ToString();
    //    txtGshoes.Text = ds.Tables[0].Rows[0][""].ToString();
    //    txtGsocks.Text = ds.Tables[0].Rows[0][""].ToString();
    //    txtGother.Text = ds.Tables[0].Rows[0][""].ToString();
    //    string[] abc = ds.Tables[0].Rows[0]["strweekdays"].ToString().Split(',');
    //    for (int i = 0; i < chkweeks.Items.Count; i++)
    //    {
    //        for (int j = 0; j < abc.Length; j++)
    //        {
    //            if (chkweeks.Items[i].Value == abc[j].ToString())
    //                chkweeks.Items[i].Selected = true;
    //        }
    //    }
    //}
   protected void btndelete_Click(object sender, ImageClickEventArgs e)
   {
       ImageButton delete = (ImageButton)sender;
       TableCell cell = delete.Parent as TableCell;
       DataGridItem item = cell.Parent as DataGridItem;
       string str = "";
       DataAccess da = new DataAccess();
       str = "delete tblschooluniform where intschooluniformid=" + item.Cells[0].Text + " and intschoolid=" + Session["SchoolID"].ToString();
       Functions.UserLogs(Session["UserID"].ToString(), "tblschooluniform", item.Cells[0].Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),31);

       da.ExceuteSqlQuery(str);
       fillgrid();
   }
}
