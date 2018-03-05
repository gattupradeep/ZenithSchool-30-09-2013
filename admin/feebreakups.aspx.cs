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

public partial class feemanagement_feebreakups : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public DataAccess da;
    public DataSet ds;
    string sql;
    protected DataTable table;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlfeemode.Focus();
            clear();
            dggrid();
            if (Request["mode"] != null)
            {
                frompopup();
                focusgrid();
            }
            else if (Session["selectedfeemode"] != null)
            {
                ddlfeebreakups.SelectedIndex = 2;
                dggrid();
                dgsetfee.Focus();
            }
            else
            {
                ddlfeebreakups.SelectedIndex = 0;
            }
        }
        else
        {
            Session.Remove("selectedfeemode");
            Session.Remove("selectedfeetype");
            Session.Remove("selectedclass");
        }
    }
    protected void fillgrid()
    {
        try
        {
            string sql = "";
            da = new DataAccess();
            ds = new DataSet();
            if (txtstd.Text != "" && ddlfeetitle.SelectedValue != "0" && ddlfeemode.SelectedValue != "0")
            {
                sql += "select intfeetype,strfeebreakups,intamount from tblfeetypes where intfeemode=" + ddlfeemode.SelectedValue + " and";
                sql += " intfeetype=" + ddlfeetitle.SelectedValue + " and strstandard in ('" + txtstd.Text.Replace(",", "','") + "') and";
                sql += " intschool=" + Session["SchoolID"] + " group by strfeebreakups,intamount,intfeetype";
                sql += " union all select 0 as intfeetype,'' as strfeebreakups,0 as intamount";
                ds = da.ExceuteSql(sql);
                grid.DataSource = ds;
                grid.DataBind();
                trgrd.Visible = true;
            }
            else
            {
                trbutton.Visible = false;
            }
        }
        catch { }
    }
    protected void fillgrdview()
    {
        try
        {
            string sql = "";
            da = new DataAccess();
            ds = new DataSet();

            sql = "select a.strstandard, b.strfeemode,c.strfeetype,sum(a.intamount) as intamount,a.intfeemode,a.intfeetype,a.intactivate from tblfeetypes a,";
            sql += " (select * from tblfeemode where intschool=" + Session["SchoolID"];
            sql += " union all";
            sql += " select distinct -2 as intid,'New Admission' as strfeemode," + Session["SchoolID"] + " as intschool,0 as intactivate from tblfeemode where intschool=" + Session["SchoolID"];
            sql += " union all";
            sql += " select distinct -1 as intid,'Others' as strfeemode," + Session["SchoolID"] + " as intschool,0 as intactivate from tblfeemode where intschool=" + Session["SchoolID"] + ") b,";
            sql += " tblfeemaster c where a.intschool=b.intschool and b.intschool=c.intschool and a.intschool=" + Session["SchoolID"] + " and a.intfeemode=b.intid";
            sql += " and a.intfeetype=c.intID and a.intactivate=0 ";

            if (ddlfeemode.SelectedIndex > 0)
            {
                sql += " and a.intfeemode=" + ddlfeemode.SelectedValue;
            }
            if (ddlfeetitle.SelectedIndex > 0)
            {
                sql += " and a.intfeetype=" + ddlfeetitle.SelectedValue;
            }
            sql += " group by a.strstandard, b.strfeemode, c.strfeetype,a.intfeemode,a.intfeetype,a.intactivate";

            sql += " union all";

            sql += " select a.strstandard, b.strfeemode,c.strfeetype,sum(a.intamount) as intamount,a.intfeemode,a.intfeetype,a.intactivate from tblfeetypes a,";

            sql += " (select * from tblfeemode where intschool=" + Session["SchoolID"];
            sql += " union all";
            sql += " select distinct -2 as intid,'New Admission' as strfeemode," + Session["SchoolID"] + " as intschool,0 as intactivate from tblfeemode where intschool=" + Session["SchoolID"];
            sql += " union all";
            sql += " select distinct -1 as intid,'Others' as strfeemode," + Session["SchoolID"] + " as intschool,0 as intactivate from tblfeemode where intschool=" + Session["SchoolID"] + ") b,";

            sql += " tblfeemaster c where a.intschool=b.intschool and b.intschool=c.intschool and a.intschool=" + Session["SchoolID"] + " and a.intfeemode=b.intid";
            sql += " and a.intfeetype=c.intID and a.intactivate=1 and ";

            sql += " (a.intfeetype not in (select distinct intfeetype from tblfeetypes where intschool=" + Session["SchoolID"] + " and intactivate=0) or";
            sql += " a.strstandard not in (select distinct strstandard from tblfeetypes where intschool=" + Session["SchoolID"] + " and intactivate=0))";

            if (ddlfeemode.SelectedIndex > 0)
            {
                sql += " and a.intfeemode=" + ddlfeemode.SelectedValue;
            }
            if (ddlfeetitle.SelectedIndex > 0)
            {
                sql += " and a.intfeetype=" + ddlfeetitle.SelectedValue;
            }
            sql += " group by a.strstandard, b.strfeemode, c.strfeetype,a.intfeemode,a.intfeetype,a.intactivate";

            ds = da.ExceuteSql(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                trgrdview.Visible = true;
                if (ddlfeebreakups.SelectedIndex == 2)
                {
                    dgsetfee.Columns[7].Visible = false;
                    dgsetfee.Columns[8].Visible = false;
                    dgsetfee.Columns[9].Visible = true;
                    dgsetfee.Columns[10].Visible = true;
                    dgsetfee.Columns[11].Visible = false;
                    trgrdview.Visible = true;
                    trgrd.Visible = false;
                }
                else if (ddlfeebreakups.SelectedIndex == 0)
                {
                    dgsetfee.Columns[7].Visible = true;
                    dgsetfee.Columns[8].Visible = true;
                    dgsetfee.Columns[9].Visible = false;
                    dgsetfee.Columns[10].Visible = false;
                    dgsetfee.Columns[11].Visible = true;
                    trgrdview.Visible = true;
                    trgrd.Visible = false;
                }
                else
                {
                    trgrdview.Visible = false;
                    trgrd.Visible = true;
                }

                if (ds.Tables[0].Rows.Count > 15)
                {
                    dgsetfee.AllowPaging = true;
                    dgsetfee.PageSize = 15;
                }
                else
                {
                    dgsetfee.AllowPaging = false;
                    dgsetfee.PageSize = 15;
                }
            }
            else
            {
                trgrdview.Visible = false;
                if (txtstd.Text != "" && ddlfeebreakups.SelectedIndex > 0)
                {
                    msgbox.alert("Record not found for selected Creteria");
                }
            }
            dgsetfee.DataSource = ds;
            dgsetfee.DataBind();
            if (ddlfeebreakups.SelectedIndex == 2)
            {
                Session["selectedfeemode"] = ddlfeemode.SelectedValue;
                Session["selectedfeetype"] = ddlfeetitle.SelectedValue;
                Session["selectedclass"] = txtstd.Text;
            }
        }
        catch { }
    }
    protected void fillchk()
    {
        try
        {
            for (int i = 0; i < dgsetfee.Items.Count; i++)
            {
                DataGridItem feeitem = dgsetfee.Items[i];
                CheckBox chk = (CheckBox)feeitem.FindControl("checkdeactivate");
                DataSet ds = new DataSet();
                DataAccess da = new DataAccess();
                string sql = "select intactivate from tblfeetypes where intschool=" + Session["SchoolID"] + " and strstandard='" + feeitem.Cells[0].Text + "'";
                sql += " and intfeemode=" + feeitem.Cells[4].Text + " and intfeetype=" + feeitem.Cells[5].Text + " and intactivate=0 and";
                sql += " intid not in (select intid from tblfeetypes where intschool=" + Session["SchoolID"] + " and strstandard='" + feeitem.Cells[0].Text + "'";
                sql += " and intfeemode=" + feeitem.Cells[4].Text + " and intfeetype=" + feeitem.Cells[5].Text + " and intactivate=1)";
                ds = da.ExceuteSql(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                    {
                        if (ds.Tables[0].Rows[j]["intactivate"].ToString() == "0")
                        {
                            chk.Checked = false;
                        }
                    }
                }
                else
                {
                    chk.Checked = true;
                }
            }
        }
        catch
        { }
    }
    protected void lblvalue()
    {
        try
        {
            if (Session["selectedclass"] != null && Session["selectedfeemode"] != null && Session["selectedfeetype"] != null)
            {
                lblsclass.Text = Session["selectedclass"].ToString();
                lblsmode.Text = Session["selectedfeemode"].ToString();
                lblstype.Text = Session["selectedfeetype"].ToString();
            }
            else
            {
                lblsclass.Text = "";
                lblsmode.Text = "";
                lblstype.Text = "";
            }
        }
        catch { }
    }
    protected void fillfeemode()
    {
        try
        {
            da = new DataAccess();
            ds = new DataSet();
            sql = "select * from (";
            sql += " select intid,strfeemode from tblfeemode where intactivate = 0 and intschool=" + Session["schoolID"];
            sql += " group by intid,strfeemode";
            sql += " union all";
            sql += " select intfeemode as intid,'New Admission' as strfeemode from tblfeemaster where intschool=" + Session["schoolID"];
            sql += " and intfeemode=-2 and intactivate = 0 group by intfeemode";
            sql += " union all";
            sql += " select intfeemode as intid,'Others' as strfeemode from tblfeemaster where intschool=" + Session["schoolID"];
            sql += " and intfeemode=-1 and intactivate = 0 group by intfeemode";
            sql += " ) as a";
            if (lblgrdfeemode.Text != "")
            {
                sql += " where a.intid=" + lblgrdfeemode.Text;
            }
            ds = da.ExceuteSql(sql);
            ddlfeemode.DataSource = ds;
            ddlfeemode.DataTextField = "strfeemode";
            ddlfeemode.DataValueField = "intid";
            ddlfeemode.DataBind();
            if (lblgrdfeemode.Text == "")
            {
                ListItem list = new ListItem("-Select-", "0");
                ddlfeemode.Items.Insert(0, list);
            }
            if (lblsmode.Text != "")
                ddlfeemode.SelectedValue = lblsmode.Text;
            if (Request["feemode"] != null)
                ddlfeemode.SelectedValue = Request["feemode"];
        }
        catch { }
    }
    protected void fillfeetitle()
    {
        try
        {
            da = new DataAccess();
            ds = new DataSet();
            sql = "select * from tblfeemaster where intfeemode=" + ddlfeemode.SelectedValue + " and intactivate=0 and intschool=" + Session["SchoolID"];
            if (lblgrdfeetype.Text != "")
            {
                sql += " and intid=" + lblgrdfeetype.Text;
            }
            ds = da.ExceuteSql(sql);
            ddlfeetitle.DataSource = ds;
            ddlfeetitle.DataTextField = "strfeetype";
            ddlfeetitle.DataValueField = "intid";
            ddlfeetitle.DataBind();
            if (lblgrdfeetype.Text == "")
            {
                ListItem list = new ListItem("-Select-", "0");
                ddlfeetitle.Items.Insert(0, list);
            }
            if (lblstype.Text != "")
                ddlfeetitle.SelectedValue = lblstype.Text;
            if (Request["feetype"] != null)
                ddlfeetitle.SelectedValue = Request["feetype"];
        }
        catch { }
    }
    protected void fillstandard()
    {
        try
        {
            da = new DataAccess();
            ds = new DataSet();

            sql = "select distinct strstandard+' - '+strsection as stdsec from tblstandard_section_subject where intschool=" + Session["SchoolID"];
            if (lblgrdstd.Text != "")
            {
                sql += " and strstandard+' - '+strsection='" + lblgrdstd.Text + "'";
            }
            else
            {
                sql += " and strstandard+' - '+strsection not in (select strstandard from tblfeetypes where intschool=" + Session["SchoolID"];
                if (ddlfeemode.SelectedIndex > 0)
                {
                    sql += " and intfeemode=" + ddlfeemode.SelectedValue;
                }
                if (ddlfeetitle.SelectedIndex > 0)
                {
                    sql += " and intfeetype=" + ddlfeetitle.SelectedValue;
                }
                sql += " group by strstandard)";
            }
            ds = da.ExceuteSql(sql);
            ddlstandard.DataSource = ds;
            ddlstandard.DataTextField = "stdsec";
            ddlstandard.DataValueField = "stdsec";
            ddlstandard.DataBind();
            if (txtstd.Text != "")
            {
                DataSet ds2 = new DataSet();
                string sql1 = "select strstandard+' - '+strsection as stdsec from tblstandard_section_subject where intschool=" + Session["SchoolID"] + " and";
                sql1 += " strstandard+' - '+strsection in ('" + txtstd.Text.Replace(",", "','") + "') group by strstandard+' - '+strsection ";
                ds2 = da.ExceuteSql(sql1);
                string[] sclass = txtstd.Text.Split(',');
                for (int i = 0; i < ddlstandard.Items.Count; i++)
                {
                    for (int j = 0; j < ds2.Tables[0].Rows.Count; j++)
                    {
                        if (ddlstandard.Items[j].Text == ds2.Tables[0].Rows[j]["stdsec"].ToString())
                        {
                            ddlstandard.Items[j].Selected = true;
                        }
                    }
                }
            }
        }
        catch { }
    }
    protected void clear()
    {
        try
        {
            lblvalue();
            fillfeemode();
            fillfeetitle();
            if (lblsclass.Text != "")
            {
                txtstd.Text = lblsclass.Text;
            }
            else
            {
                txtstd.Text = "";
            }
            fillstandard();
            chkall.Checked = false;
            ddlfeebreakups.SelectedIndex = 0;
            trbreakups.Visible = true;
            btnSave.Visible = false;
            trgrd.Visible = false;
            btnClear.Text = "Clear";
            btnSave.Text = "Done";
        }
        catch { }
    }
    protected void ddlfeemode_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblsmode.Text = ddlfeemode.SelectedValue;
            txtstd.Text = "";
            fillfeetitle();
            fillstandard();
            dggrid();
            ddlfeetitle.Focus();
        }
        catch { }
    }
    protected void dggrid()
    {
        try
        {
            dgsetfee.CurrentPageIndex = 0;
            fillgrdview();
            fillchk();
        }
        catch { }
    }
    protected void ddlstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        dggrid();
    }
    protected void ddlfeetitle_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblstype.Text = ddlfeetitle.SelectedValue;
            if (ddlfeemode.SelectedIndex > 0)
            {
                if (lblsclass.Text != "")
                {
                    txtstd.Text = lblsclass.Text;
                }
                else
                {
                    txtstd.Text = "";
                }
                fillstandard();
                chkall.Checked = false;
                dggrid();
                ddlstandard.Focus();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Clientsripts", "alert('Please select feemode to proceed')", true);
            }
        }
        catch { }
    }
    protected void grid_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        try
        {
            DataRowView dr = (DataRowView)e.Item.DataItem;
            TextBox txtfeetype = (TextBox)e.Item.FindControl("txtfeetype");
            TextBox txtamount = (TextBox)e.Item.FindControl("txtamount");
            txtfeetype.Text = dr["strfeebreakups"].ToString();
            txtamount.Text = dr["intamount"].ToString();
            if (int.Parse(dr["intfeetype"].ToString()) > 0)
            {
                e.Item.Cells[5].Enabled = false;
                e.Item.Cells[6].Enabled = true;
                e.Item.Cells[7].Enabled = true;
            }
            else
            {
                e.Item.Cells[5].Enabled = true;
                e.Item.Cells[6].Enabled = false;
                e.Item.Cells[7].Enabled = false;
            }
        }
        catch { }
    }
    protected void standard()
    {
        try
        {
            da = new DataAccess();
            ds = new DataSet();
            sql = "select strstandard from tblfeetypes where intfeemode=" + ddlfeemode.SelectedValue + " and intfeetype=" + ddlfeetitle.SelectedValue + "";
            sql += " and intschool=" + Session["SchoolID"];
            if (ddlfeemode.SelectedValue != "1")
            {
                sql += " and strstandard in ('" + txtstd.Text.Replace(", ", "','") + "')";
            }
            ds = da.ExceuteSql(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string std = ds.Tables[0].Rows[0]["strstandard"].ToString();
                for (int i = 0; i < ddlstandard.Items.Count; i++)
                {
                    if (ddlstandard.Items[i].Selected)
                    {
                        std += ddlstandard.Items[i].Text + ", ";
                    }
                }
            }
        }
        catch { }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        try
        {
            if (btnClear.Text == "Clear")
            {
                Response.Redirect("feebreakups.aspx");
            }
            else
            {
                dgsetfee.Focus();
            }
            btnSave.Visible = false;
            trgrdview.Visible = true;
            dggrid();
            btnClear.Text = "Clear";
        }
        catch { }

    }
    protected void btnapply_Click(object sender, EventArgs e)
    {
        applly();
    }
    protected void applly()
    {
        try
        {
            if (ddlfeemode.SelectedIndex > 0 && ddlfeetitle.SelectedIndex > 0)
            {
                string name = "";
                for (int i = 0; i < ddlstandard.Items.Count; i++)
                {
                    if (ddlstandard.Items[i].Selected)
                    {
                        if (name == "")
                            name += ddlstandard.Items[i].Text;
                        else
                            name += "," + ddlstandard.Items[i].Text;
                    }
                }
                txtstd.Text = name;
                lblsclass.Text = name;
            }
            else
            {
                if (ddlfeemode.SelectedIndex > 0 && ddlfeetitle.SelectedIndex == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Clientsripts", "alert('Please select feetype to proceed')", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Clientsripts", "alert('Please select feemode and feeType to proceed')", true);
                }
                chkall.Checked = false;
                for (int i = 0; i < ddlstandard.Items.Count; i++)
                {
                    if (ddlstandard.Items[i].Selected)
                    {
                        ddlstandard.Items[i].Selected = false;
                    }
                }
            }
            trgrd.Visible = false;
            trgrdview.Visible = false;
            ddlfeebreakups.Focus();
            ddlfeebreakups.SelectedIndex = 0;
        }
        catch { }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            for (int j = 0; j < grid.Items.Count; j++)
            {
                DataGridItem Item = grid.Items[j];
                TextBox txtfeetype = (TextBox)Item.FindControl("txtfeetype");
                TextBox txtamount = (TextBox)Item.FindControl("txtamount");
                for (int i = 0; i < ddlstandard.Items.Count; i++)
                {
                    if (ddlstandard.Items[i].Selected)
                    {
                        if (txtfeetype.Text != "" && double.Parse(txtamount.Text) != 0)
                        {
                            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
                            conn.Open();
                            SqlCommand command = new SqlCommand("spfeetype", conn);
                            command.CommandType = CommandType.StoredProcedure;
                            SqlParameter param = command.Parameters.Add("@rc", SqlDbType.Int);
                            param.Direction = ParameterDirection.Output;
                            da = new DataAccess();
                            ds = new DataSet();
                            sql = "";
                            sql = "select intid from tblfeetypes where intfeemode=" + ddlfeemode.SelectedValue + " and";
                            sql += " intfeetype=" + ddlfeetitle.SelectedValue + " and";
                            sql += " strstandard ='" + ddlstandard.Items[i].Text + "' and intschool=" + Session["SchoolID"];
                            ds = da.ExceuteSql(sql);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                if (j != ds.Tables[0].Rows.Count)
                                {
                                    for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                                    {
                                        if (j == k)
                                        {
                                            command.Parameters.Add("@intid", ds.Tables[0].Rows[k]["intid"].ToString());
                                            command.Parameters.Add("@intfeemode", ddlfeemode.SelectedValue);
                                            command.Parameters.Add("@intfeetype", ddlfeetitle.SelectedValue);
                                            command.Parameters.Add("@strstandard", ddlstandard.Items[i].Text);
                                            command.Parameters.Add("@intschool", Session["SchoolID"]);
                                            command.Parameters.Add("@strfeebreakups", txtfeetype.Text.Trim());
                                            command.Parameters.Add("@intamount", txtamount.Text.Trim());
                                            command.Parameters.Add("@intactivate", "0");
                                            command.ExecuteNonQuery();
                                            if ((int)(command.Parameters["@rc"].Value) == 0)
                                            {
                                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscripts", "alert('Feetype and Amount already exist!')", true);
                                            }
                                            conn.Close();
                                        }
                                    }
                                }
                                else
                                {
                                    command.Parameters.Add("@intid", "0");
                                    command.Parameters.Add("@intfeemode", ddlfeemode.SelectedValue);
                                    command.Parameters.Add("@intfeetype", ddlfeetitle.SelectedValue);
                                    command.Parameters.Add("@strstandard", ddlstandard.Items[i].Text);
                                    command.Parameters.Add("@intschool", Session["SchoolID"]);
                                    command.Parameters.Add("@strfeebreakups", txtfeetype.Text.Trim());
                                    command.Parameters.Add("@intamount", txtamount.Text.Trim());
                                    command.Parameters.Add("@intactivate", "0");
                                    command.ExecuteNonQuery();
                                    if ((int)(command.Parameters["@rc"].Value) == 0)
                                    {
                                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscripts", "alert('Feetype and Amount already exist!')", true);
                                    }
                                    conn.Close();
                                }
                            }
                            else
                            {
                                command.Parameters.Add("@intid", "0");
                                command.Parameters.Add("@intfeemode", ddlfeemode.SelectedValue);
                                command.Parameters.Add("@intfeetype", ddlfeetitle.SelectedValue);
                                command.Parameters.Add("@strstandard", ddlstandard.Items[i].Text);
                                command.Parameters.Add("@intschool", Session["SchoolID"]);
                                command.Parameters.Add("@strfeebreakups", txtfeetype.Text.Trim());
                                command.Parameters.Add("@intamount", txtamount.Text.Trim());
                                command.Parameters.Add("@intactivate", "0");
                                command.ExecuteNonQuery();
                                if ((int)(command.Parameters["@rc"].Value) == 0)
                                {
                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscripts", "alert('Feetype and Amount already exist!')", true);
                                }
                                conn.Close();
                            }
                        }
                    }
                }
            }
            if (btnSave.Text != "Update")
            {
                ddlfeemode.Focus();
            }
            else
            {
                dgsetfee.Focus();
            }
            clear();
            dggrid();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscripts", "alert('Feetype and Amount added successfully')", true);
        }
        catch { }
    }
    protected void dgsetfee_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        try
        {
            dgsetfee.CurrentPageIndex = 0;
            dgsetfee.CurrentPageIndex = e.NewPageIndex;
            fillgrdview();
            fillchk();
        }
        catch { }
    }
    protected void dgsetfee_EditCommand(object source, DataGridCommandEventArgs e)
    {
        try
        {
            lblgrdfeemode.Text = e.Item.Cells[4].Text;
            fillfeemode();
            ddlfeemode.SelectedValue = e.Item.Cells[4].Text;
            lblgrdfeetype.Text = e.Item.Cells[5].Text;
            lblgrdfeemode.Text = "";
            fillfeetitle();
            ddlfeetitle.SelectedValue = e.Item.Cells[5].Text;
            lblgrdfeetype.Text = "";
            lblgrdstd.Text = e.Item.Cells[0].Text;
            fillstandard();
            lblgrdstd.Text = "";
            chkall.Checked = true;
            ddlstandard.SelectedValue = e.Item.Cells[0].Text;
            txtstd.Text = e.Item.Cells[0].Text;
            string sql = "";
            da = new DataAccess();
            ds = new DataSet();
            sql = "select intid,intfeetype,strfeebreakups,intamount from tblfeetypes where intfeemode=" + e.Item.Cells[4].Text + " and";
            sql += " intfeetype=" + e.Item.Cells[5].Text + " and strstandard ='" + e.Item.Cells[0].Text + "' and";
            sql += " intschool=" + Session["SchoolID"] + " group by intid, strfeebreakups,intamount,intfeetype";
            sql += " union all select 0 as intid, 0 as intfeetype,'' as strfeebreakups,0 as intamount";
            ds = da.ExceuteSql(sql);
            grid.DataSource = ds;
            grid.DataBind();
            trgrd.Visible = true;
            btnSave.Visible = true;
            trgrdview.Visible = false;
            trbreakups.Visible = false;
            ddlfeebreakups.SelectedIndex = 0;
            btnSave.Text = "Update";
            btnClear.Text = "Cancel";
            focusgrid();
        }
        catch { }
    }
    protected void dgsetfee_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        try
        {
            int select =0;
            if (ddlfeemode.SelectedIndex > 0 && ddlfeetitle.SelectedIndex > 0)
                select = 2;
            else if(ddlfeemode.SelectedIndex > 0 && ddlfeetitle.SelectedIndex == 0)
                select = 1;

            Response.Redirect("feebreakupsdetails.aspx?class='" + e.Item.Cells[0].Text + "'&&feemode=" + e.Item.Cells[4].Text + "&&feetype=" + e.Item.Cells[5].Text + "&&ddlselect="+ select +"", true);
        }
        catch { }
    }
    protected void bntbreakups_Click(object sender, EventArgs e)
    {
        try
        {
            dgsetfee.Visible = true;
            dggrid();
        }
        catch { }
    }
    protected void ddlfeebreakups_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtstd.Text != "")
            {
                if (ddlfeebreakups.SelectedIndex > 0)
                {
                    btnSave.Visible = true;
                    if (ddlfeebreakups.SelectedIndex == 1)
                    {
                        trgrd.Visible = true;
                        trgrdview.Visible = false;
                        btnSave.Visible = true;
                        fillgrid();
                        grid.Focus();
                    }
                    else
                    {
                        trgrd.Visible = false;
                        trgrdview.Visible = true;
                        btnSave.Visible = false;
                        dggrid();
                        dgsetfee.Focus();
                    }
                }
                else
                {
                    trgrd.Visible = false;
                    btnSave.Visible = false;
                    trgrdview.Visible = false;
                }
            }
            else
            {
                ddlfeebreakups.SelectedIndex = 0;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Clientsripts", "alert('Please select class to proceed')", true);
            }
        }
        catch { }
    }
    protected void imageadd_Click(object sender, ImageClickEventArgs e)
    {
        if (ddlfeebreakups.SelectedIndex != 2)
        {
            addselect();
        }
        ImageButton image = sender as ImageButton;
        TableCell cell = image.Parent as TableCell;
        DataGridItem Item = cell.Parent as DataGridItem;
        int index = Item.ItemIndex;
        TextBox txtfeetype = (TextBox)Item.FindControl("txtfeetype");
        TextBox txtamount = (TextBox)Item.FindControl("txtamount");
        try
        {
            if (ddlfeebreakups.SelectedIndex == 2)
            {
                DataAccess da = new DataAccess();
                DataSet ds2 = new DataSet();
                string sql = "insert into tblfeetypestemp values(" + ddlfeemode.SelectedValue + "," + ddlfeetitle.SelectedValue + ",'" + txtfeetype.Text + "'," + txtamount.Text + "," + Session["SchoolID"] + ")";
                da.ExceuteSqlQuery(sql);
                //sql = "select max(intid) as intid from tblfeetypestemp";
                //ds2 = da.ExceuteSql(sql);
                //Functions.UserLogs(Session["UserID"].ToString(), "tblfeetypestemp", ds2.Tables[0].Rows[0]["intid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),);
                selectgrid();
            }
            else
            {
                for (int i = 0; i < ddlstandard.Items.Count; i++)
                {
                    if (ddlstandard.Items[i].Selected)
                    {
                        if (txtfeetype.Text != "" && double.Parse(txtamount.Text) != 0)
                        {
                            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
                            conn.Open();
                            SqlCommand command = new SqlCommand("spfeetype", conn);
                            command.CommandType = CommandType.StoredProcedure;
                            SqlParameter param = command.Parameters.Add("@rc", SqlDbType.Int);
                            param.Direction = ParameterDirection.Output;
                            command.Parameters.Add("@intid", "0");
                            command.Parameters.Add("@intfeemode", ddlfeemode.SelectedValue);
                            command.Parameters.Add("@intfeetype", ddlfeetitle.SelectedValue);
                            command.Parameters.Add("@strstandard", ddlstandard.Items[i].Text);
                            command.Parameters.Add("@intschool", Session["SchoolID"]);
                            command.Parameters.Add("@strfeebreakups", txtfeetype.Text.Trim());
                            command.Parameters.Add("@intamount", txtamount.Text.Trim());
                            command.Parameters.Add("@intactivate", "0");
                            command.ExecuteNonQuery();
                            if ((int)(command.Parameters["@rc"].Value) == 0)
                            {
                                msgbox.alert("Fee type  already Exists!");
                            }
                            conn.Close();

                        }
                        else
                        {
                            msgbox.alert("Please fill fee type and amount to add next");
                        }
                    }
                }
                fillgrid();
            }
            focusgrid();
        }
        catch
        {
            txtfeetype.Text = "";
            txtamount.Text = "";
            msgbox.alert("Please fill fee type and amount Properly");
            focusgrid();
        }
    }
    protected void focusgrid()
    {
        try
        {
            for (int j = 0; j < grid.Items.Count; j++)
            {
                DataGridItem item = grid.Items[j];
                TextBox txttype = (TextBox)item.FindControl("txtfeetype");
                TextBox txtamou = (TextBox)item.FindControl("txtamount");
                if (j == grid.Items.Count - 1)
                {
                    txttype.Focus();
                }
            }
        }
        catch { }
    }
    protected void imagedelete_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ImageButton image = sender as ImageButton;
            TableCell cell = image.Parent as TableCell;
            DataGridItem Item = cell.Parent as DataGridItem;
            int index = Item.ItemIndex;
            DataAccess da = new DataAccess();
            if (ddlfeebreakups.SelectedIndex != 2)
            {
                
                DataSet ds = new DataSet();
                //sql = "select intid from tblfeetypes where strfeebreakups='" + Item.Cells[1].Text + "' and intfeetype=" + Item.Cells[0].Text + " and strstandard in ('" + txtstd.Text.Replace(",", "','") + "')";
                //ds = da.ExceuteSql(sql);
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //    {
                //        Functions.UserLogs(Session["UserID"].ToString(), "tblfeetypes", ds.Tables[0].Rows[0]["intid"].ToString(), "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString());

                //    }
                //}

                sql = "delete tblfeetypes where strfeebreakups='" + Item.Cells[1].Text + "' and intfeetype=" + Item.Cells[0].Text + " and strstandard in ('" + txtstd.Text.Replace(",", "','") + "')";
                da.ExceuteSqlQuery(sql);
                fillgrid();
            }
            else
            {
                
                DataSet ds = new DataSet();
                //sql = "select intid from tblfeetypestemp where strfeebreakups='" + Item.Cells[1].Text + "' and intfeetype=" + Item.Cells[0].Text;
                //ds = da.ExceuteSql(sql);
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //    {
                //        Functions.UserLogs(Session["UserID"].ToString(), "tblfeetypestemp", ds.Tables[0].Rows[0]["intid"].ToString(), "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString());

                //    }
                //}

                sql = "delete tblfeetypestemp where strfeebreakups='" + Item.Cells[1].Text + "' and intfeetype=" + Item.Cells[0].Text;
                da.ExceuteSqlQuery(sql);
                selectgrid();
            }
            focusgrid();
        }
        catch { }
    }
    protected void selectgrid()
    {
        try
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select intfeetype,strfeebreakups,intamount from tblfeetypestemp where intschool=" + Session["SchoolID"];
            str += " group by intfeetype,strfeebreakups,intamount";
            str += " union all";
            str += " select 0 as intfeetype,'' as strfeebreakups,0 as intamount";
            ds = da.ExceuteSql(str);
            grid.DataSource = ds;
            grid.DataBind();
        }
        catch { }
    }
    protected void imageupdate_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ImageButton image = sender as ImageButton;
            TableCell cell = image.Parent as TableCell;
            DataGridItem Item = cell.Parent as DataGridItem;
            int index = Item.ItemIndex;
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            sql = "";
            sql = "select * from";
            if (ddlfeebreakups.SelectedIndex != 2)
            {
                sql += " tblfeetypes";
            }
            else
            {
                sql += " tblfeetypestemp";
            }
            sql += " where strfeebreakups='" + Item.Cells[1].Text + "' and intfeetype=" + Item.Cells[0].Text;
            ds = da.ExceuteSql(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                TextBox txtfeetype = (TextBox)Item.FindControl("txtfeetype");
                TextBox txtamount = (TextBox)Item.FindControl("txtamount");
                if (ddlfeebreakups.SelectedIndex != 2)
                {
                    sql = "update tblfeetypes";
                }
                else
                {
                    sql = "update tblfeetypestemp";
                }
                sql += " set strfeebreakups='" + txtfeetype.Text + "' ,intamount='" + txtamount.Text + "' where";
                if (ddlfeebreakups.SelectedIndex != 2)
                {
                    sql += " strstandard in ('" + txtstd.Text.Replace(",", "','") + "') and";
                }
                sql += " strfeebreakups='" + Item.Cells[1].Text + "' and intfeetype=" + Item.Cells[0].Text;
                da.ExceuteSqlQuery(sql);
                msgbox.alert("Updated successfully");
            }
            if (ddlfeebreakups.SelectedIndex != 2)
            {
                fillgrid();
            }
            else
            {
                selectgrid();
            }
            focusgrid();
        }
        catch { }
    }
    protected void imageselect_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ImageButton image = sender as ImageButton;
            TableCell cell = image.Parent as TableCell;
            DataGridItem Item = cell.Parent as DataGridItem;
            int index = Item.ItemIndex;
            DataAccess da = new DataAccess();
            ds = new DataSet();
            string sql = "";
            sql = "select intfeetype,strfeebreakups,intamount from tblfeetypes where intfeemode=" + Item.Cells[4].Text + " and";
            sql += " intfeetype=" + Item.Cells[5].Text + " and strstandard='" + Item.Cells[0].Text + "'  and";
            sql += " intschool=" + Session["SchoolID"] + " group by strfeebreakups,intamount,intfeetype union all";
            sql += " select 0 as intfeetype,'' as strfeebreakups,0 as intamount";
            ds = da.ExceuteSql(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string str5 = "delete tblfeetypestemp where intschool=" + Session["SchoolID"];
               // Functions.UserLogs(Session["UserID"].ToString(), "tblfeetypestemp", Session["SchoolID"].ToString(), "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString());

                da.ExceuteSqlQuery(str5);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i]["strfeebreakups"].ToString() != "" && double.Parse(ds.Tables[0].Rows[i]["intamount"].ToString()) != 0)
                    {
                        string str = "insert into tblfeetypestemp values(" + Item.Cells[4].Text + "," + Item.Cells[5].Text + ",'" + ds.Tables[0].Rows[i]["strfeebreakups"].ToString() + "',";
                        str += " " + ds.Tables[0].Rows[i]["intamount"].ToString() + ",";
                        str += " " + Session["SchoolID"] + ")";
                        da.ExceuteSqlQuery(str);
                        DataSet ds2 = new DataSet();
                        //str = "select max(intid) as intid from tblfeetypestemp";
                        //ds2 = da.ExceuteSql(str);
                        //Functions.UserLogs(Session["UserID"].ToString(), "tblfeetypestemp", ds2.Tables[0].Rows[0]["intid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString());
                    }
                }
            }
            selectgrid();
            lblstdsec.Text = Item.Cells[0].Text;
            trgrd.Visible = true;
            btnSave.Visible = true;
            trgrdview.Visible = false;
            btnClear.Text = "Cancel";
            focusgrid();
        }
        catch { }
    }
    protected void frompopup()
    {
        try
        {
            if (Request["mode"] != null && Request["type"] != null && Request["c"] != null)
            {
                string sql = "";
                da = new DataAccess();
                ds = new DataSet();
                sql = "select intid, intfeetype,strfeebreakups,intamount from tblfeetypes where intfeemode=" + Request["mode"] + " and";
                sql += " intfeetype=" + Request["type"] + " and strstandard ='" + Request["c"] + "' and";
                sql += " intschool=" + Session["SchoolID"] + " group by intid, strfeebreakups,intamount,intfeetype union all";
                sql += " select 0 as intid, 0 as intfeetype,'' as strfeebreakups,0 as intamount";
                ds = da.ExceuteSql(sql);
                grid.DataSource = ds;
                grid.DataBind();
                trgrd.Visible = true;
                btnSave.Visible = true;
                trgrdview.Visible = false;
                ddlfeebreakups.SelectedIndex = 2;
                btnClear.Text = "Cancel";
            }
        }
        catch { }
    }
    protected void imageview_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ImageButton image = sender as ImageButton;
            TableCell cell = image.Parent as TableCell;
            DataGridItem item = cell.Parent as DataGridItem;
            int index = item.ItemIndex;
            Response.Redirect("feebreakupsdetails.aspx?class='" + item.Cells[0].Text + "'&&feemode=" + item.Cells[4].Text + "&&feetype=" + item.Cells[5].Text + "", true);
        }
        catch { }
    }
    protected void addselect()
    {
        try
        {
            if (trbreakups.Visible == true)
            {
                for (int j = 0; j < grid.Items.Count - 1; j++)
                {
                    DataGridItem Item = grid.Items[j];
                    TextBox txtfeetype = (TextBox)Item.FindControl("txtfeetype");
                    TextBox txtamount = (TextBox)Item.FindControl("txtamount");
                    for (int i = 0; i < ddlstandard.Items.Count; i++)
                    {
                        if (ddlstandard.Items[i].Selected)
                        {
                            if (txtfeetype.Text != "" && double.Parse(txtamount.Text) != 0)
                            {

                                SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
                                conn.Open();
                                SqlCommand command = new SqlCommand("spfeetype", conn);
                                command.CommandType = CommandType.StoredProcedure;
                                SqlParameter param = command.Parameters.Add("@rc", SqlDbType.Int);
                                param.Direction = ParameterDirection.Output;
                                command.Parameters.Add("@intid", "0");
                                command.Parameters.Add("@intfeemode", ddlfeemode.SelectedValue);
                                command.Parameters.Add("@intfeetype", ddlfeetitle.SelectedValue);
                                command.Parameters.Add("@strstandard", ddlstandard.Items[i].Text);
                                command.Parameters.Add("@intschool", Session["SchoolID"]);
                                command.Parameters.Add("@strfeebreakups", txtfeetype.Text.Trim());
                                command.Parameters.Add("@intamount", txtamount.Text.Trim());
                                command.Parameters.Add("@intactivate", "0");
                                command.ExecuteNonQuery();
                                conn.Close();

                            }
                        }
                    }
                }
            }
        }
        catch { }
    }
    protected void checkdeactivate_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            CheckBox check = sender as CheckBox;
            TableCell cell = check.Parent as TableCell;
            DataGridItem item = cell.Parent as DataGridItem;
            int index = item.ItemIndex;
            CheckBox chk = (CheckBox)item.FindControl("checkdeactivate");
            DataAccess da = new DataAccess();
            string sql = "";
            if (chk.Checked)
            {
                //sql = "select intid from tblfeetypes where strstandard='" + item.Cells[0].Text + "' and intfeemode=" + item.Cells[4].Text;
                //sql += " and intfeetype=" + item.Cells[5].Text + " and intschool=" + Session["SchoolID"];
                //ds = da.ExceuteSql(sql);
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //    {
                //        Functions.UserLogs(Session["UserID"].ToString(), "tblfeetypes", ds.Tables[0].Rows[0]["intid"].ToString(), "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString());

                //    }
                //}

                sql = "update tblfeetypes set intactivate=1 where strstandard='" + item.Cells[0].Text + "' and intfeemode=" + item.Cells[4].Text;
                sql += " and intfeetype=" + item.Cells[5].Text + " and intschool=" + Session["SchoolID"];
                da.ExceuteSqlQuery(sql);

            }
            else
            {
                //sql = "select intid from tblfeetypes where strstandard='" + item.Cells[0].Text + "' and intfeemode=" + item.Cells[4].Text;
                //sql += " and intfeetype=" + item.Cells[5].Text + " and intschool=" + Session["SchoolID"];
                //ds = da.ExceuteSql(sql);
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //    {
                //        Functions.UserLogs(Session["UserID"].ToString(), "tblfeetypes", ds.Tables[0].Rows[0]["intid"].ToString(), "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString());

                //    }
                //}

                sql = "update tblfeetypes set intactivate=0 where strstandard='" + item.Cells[0].Text + "' and intfeemode=" + item.Cells[4].Text;
                sql += " and intfeetype=" + item.Cells[5].Text + " and intschool=" + Session["SchoolID"];
                da.ExceuteSqlQuery(sql);
            }
            dgsetfee.Focus();
        }
        catch { }
    }
    protected void txtstd_TextChanged(object sender, EventArgs e)
    {
        try
        {
            for (int i = 0; i < ddlstandard.Items.Count; i++)
            {
                int select = 0;
                if (ddlstandard.Items[i].Selected)
                {
                    select = 1;
                }
                if (select != 1)
                {
                    txtstd.Text = "";
                    msgbox.alert("Select Class to Proceed");
                }

            }
        }
        catch { }
    }
    protected void chkall_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            for (int i = 0; i < ddlstandard.Items.Count; i++)
            {
                if (chkall.Checked == true)
                    ddlstandard.Items[i].Selected = true;
                else
                    ddlstandard.Items[i].Selected = false;
            }
            applly();
            
        }
        catch { }
    }
}
