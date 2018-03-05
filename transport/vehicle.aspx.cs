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

public partial class transport_vehicle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {        
        if (!IsPostBack)
        {
            fillowner();
            fillgrid();
            fillddl();
        }
    }
    private void fillowner()
    {
        DataAccess da = new DataAccess();
        string sql = "select intid, strownername from tblowner where intschool=" + Session["SchoolID"].ToString();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        ddlowner.DataSource = ds;
        ddlowner.DataTextField = "strownername";
        ddlowner.DataValueField = "intid";
        ddlowner.DataBind();
        //ddlowner.Items.Insert(0, "Select");
    }
    private void fillgrid()
    {
        DataAccess da = new DataAccess();
        string sql = "select a.intid, a.strregno,a.strvehicleno,a.strengineno,a.strchassisno,a.strbrand,a.strmodel,a.strvehiclecolor,b.strownername from dbo.tblvehiclemaster a,dbo.tblowner b where a.intownerid=b.intid and a.intschool=" + Session["SchoolID"].ToString();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        dgvehicle.DataSource = ds;
        dgvehicle.DataBind();        
    }
    private void fillddl()
    {
        DataAccess da = new DataAccess();
        string sql = "select intid,strvehiclecategory from tblvehiclecategory";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        ddlvehicletype.DataSource = ds;
        ddlvehicletype.DataTextField = "strvehiclecategory";
        ddlvehicletype.DataValueField = "intid";
        ddlvehicletype.DataBind();        
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlCommand command;
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        SqlParameter param;
        SqlParameter OutPutParam;
        conn.Open();
        command = new SqlCommand("SPvehiclemaster", conn);
        param = command.Parameters.Add("ReturnValue", SqlDbType.Int);
        param.Direction = ParameterDirection.ReturnValue;

        OutPutParam = command.Parameters.Add("@rc", SqlDbType.Int);
        OutPutParam.Direction = ParameterDirection.Output;
        command.CommandType = CommandType.StoredProcedure;
        if (btnSave.Text == "Save")
        {
            command.Parameters.Add("@intid", "0");
        }
        else
        {
            command.Parameters.Add("@intid", Session["intid"].ToString());
        }
        command.Parameters.Add("@intschool", Session["SchoolID"].ToString());
        command.Parameters.Add("@intownerid", ddlowner.SelectedValue);
        command.Parameters.Add("@strregno", txtregno.Text.Trim());
        command.Parameters.Add("@strvehicleno", txtvehicleno.Text.Trim());
        command.Parameters.Add("@strengineno", txtengineno.Text.Trim());
        command.Parameters.Add("@strchassisno", txtchassisno.Text.Trim());
        command.Parameters.Add("@strbrand", txtbrand.Text.Trim());
        command.Parameters.Add("@strmodel", txtmodel.Text.Trim());
        command.Parameters.Add("@inttypeid", ddlvehicletype.SelectedValue);
        command.Parameters.Add("@strfueltype", txtfuel.Text.Trim());
        command.Parameters.Add("@strvehiclecolor", txtvehiclecolor.Text.Trim());
        command.Parameters.Add("@intseats", txtseats.Text.Trim());
        command.Parameters.Add("@strluxuryinfo", txtluxury.Text.Trim());
        command.Parameters.Add("@strpermitinfo", txtpermit.Text.Trim());
        command.Parameters.Add("@strboardcolor", txtboardcolor.Text.Trim());
        command.Parameters.Add("@intratekm", txtrate.Text.Trim());
        command.Parameters.Add("@strfcno", txtfcno.Text.Trim());
        command.Parameters.Add("@dtfcdate",  txtfcissuedate.Text);
        command.Parameters.Add("@dtfcedate",  txtfcenddate.Text);
        command.Parameters.Add("@strinsuranceno", txtinsuranceno.Text.Trim());
        command.Parameters.Add("@dtinsurancesdate", txtinsuranceissuedate.Text);
        command.Parameters.Add("@dtinsuranceedate", txtinsuranceenddate.Text);
        command.Parameters.Add("@intfreeservices", txtfreeservices.Text.Trim());        
        command.ExecuteNonQuery();
        conn.Close();
        string id = Convert.ToString(OutPutParam.Value);
        if (btnSave.Text == "Save")
        {
            Functions.UserLogs(Session["UserID"].ToString(), "tblvehiclemaster", id, "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 116);
        }
        else
        {
            Functions.UserLogs(Session["UserID"].ToString(), "tblvehiclemaster", id, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 116);
        }
        Clear();
        fillgrid();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Details Saved Successfully!')", true);
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        Clear();
    }
    private void Clear()
    {
        txtboardcolor.Text = "";
        txtbrand.Text = "";
        txtchassisno.Text = "";
        txtengineno.Text = "";
        txtfcno.Text = "";
        txtfreeservices.Text = "";
        txtfuel.Text = "";
        txtinsuranceno.Text = "";
        txtluxury.Text = "";
        txtmodel.Text = "";
        txtpermit.Text = "";
        txtrate.Text = "";
        txtseats.Text = "";
        txtvehiclecolor.Text = "";
        txtregno.Text = "";
        txtvehicleno.Text = "";
        btnSave.Text = "Save";
        txtinsuranceenddate.Text = "";
        txtinsuranceissuedate.Text = "";
        txtfcenddate.Text = "";
        txtfcissuedate.Text = "";
    }
    //protected void dgvehicle_DeleteCommand(object source, DataGridCommandEventArgs e)
    //{
    //    DataAccess da = new DataAccess();
    //    string sql = "delete tblvehiclemaster where intid=" + e.Item.Cells[0].Text;
    //    da.ExceuteSqlQuery(sql);
    //    fillgrid();
    //    Clear();
    //}
    protected void dgvehicle_EditCommand(object source, DataGridCommandEventArgs e)
    {
         Session["intid"] = e.Item.Cells[0].Text;
        DataAccess da = new DataAccess();
        string sql = "select a.intID, a.strownername, b.*, convert(varchar(11),b.dtfcdate,103) as dtfcdate,convert(varchar(11),b.dtfcedate,103) as dtfcedate,convert(varchar(11),b.dtinsurancesdate,103) as dtinsurancesdate,convert(varchar(11),b.dtinsuranceedate,103) as dtinsuranceedate from tblvehiclemaster b,tblowner a where a.intid=b.intownerid " + " and b.intschool=" + Session["SchoolID"].ToString() + " and b.intid=" + e.Item.Cells[0].Text;
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlowner.SelectedItem.Text = ds.Tables[0].Rows[0]["strownername"].ToString();
            txtregno.Text = ds.Tables[0].Rows[0]["strregno"].ToString();
            txtvehicleno.Text = ds.Tables[0].Rows[0]["strvehicleno"].ToString();
            txtengineno.Text = ds.Tables[0].Rows[0]["strengineno"].ToString();
            txtchassisno.Text = ds.Tables[0].Rows[0]["strchassisno"].ToString();
            txtbrand.Text = ds.Tables[0].Rows[0]["strbrand"].ToString();
            txtmodel.Text = ds.Tables[0].Rows[0]["strmodel"].ToString();
            txtfuel.Text = ds.Tables[0].Rows[0]["strfueltype"].ToString();
            txtinsuranceno.Text = ds.Tables[0].Rows[0]["strinsuranceno"].ToString();
            txtluxury.Text = ds.Tables[0].Rows[0]["strluxuryinfo"].ToString();
            txtpermit.Text = ds.Tables[0].Rows[0]["strpermitinfo"].ToString();
            txtrate.Text = ds.Tables[0].Rows[0]["intratekm"].ToString();
            txtfreeservices.Text = ds.Tables[0].Rows[0]["intfreeservices"].ToString();
            txtfcno.Text = ds.Tables[0].Rows[0]["strfcno"].ToString();
            txtboardcolor.Text = ds.Tables[0].Rows[0]["strboardcolor"].ToString();
            txtseats.Text = ds.Tables[0].Rows[0]["intseats"].ToString();
            txtvehiclecolor.Text = ds.Tables[0].Rows[0]["strvehiclecolor"].ToString();
            ddlvehicletype.SelectedValue = ds.Tables[0].Rows[0]["inttypeid"].ToString();
            txtfcissuedate.Text = ds.Tables[0].Rows[0]["dtfcdate"].ToString();
            txtfcenddate.Text = ds.Tables[0].Rows[0]["dtfcedate"].ToString();
            txtinsuranceissuedate.Text = ds.Tables[0].Rows[0]["dtinsurancesdate"].ToString();
            txtinsuranceenddate.Text = ds.Tables[0].Rows[0]["dtinsuranceedate"].ToString();
            //ddlday1.SelectedValue = DateTime.Parse(ds.Tables[0].Rows[0]["dtfcdate"].ToString()).Day.ToString();
            //ddlmonth1.SelectedValue = DateTime.Parse(ds.Tables[0].Rows[0]["dtfcdate"].ToString()).Month.ToString();
            //ddlyear1.SelectedValue = DateTime.Parse(ds.Tables[0].Rows[0]["dtfcdate"].ToString()).Year.ToString();

            //ddlday2.SelectedValue = DateTime.Parse(ds.Tables[0].Rows[0]["dtfcedate"].ToString()).Day.ToString();
            //ddlmonth2.SelectedValue = DateTime.Parse(ds.Tables[0].Rows[0]["dtfcedate"].ToString()).Month.ToString();
            //ddlyear2.SelectedValue = DateTime.Parse(ds.Tables[0].Rows[0]["dtfcedate"].ToString()).Year.ToString();

            //ddlday3.SelectedValue = DateTime.Parse(ds.Tables[0].Rows[0]["dtinsurancesdate"].ToString()).Day.ToString();
            //ddlmonth3.SelectedValue = DateTime.Parse(ds.Tables[0].Rows[0]["dtinsurancesdate"].ToString()).Month.ToString();
            //ddlyear3.SelectedValue = DateTime.Parse(ds.Tables[0].Rows[0]["dtinsurancesdate"].ToString()).Year.ToString();

            //ddlday4.SelectedValue = DateTime.Parse(ds.Tables[0].Rows[0]["dtinsuranceedate"].ToString()).Day.ToString();
            //ddlmonth4.SelectedValue = DateTime.Parse(ds.Tables[0].Rows[0]["dtinsuranceedate"].ToString()).Month.ToString();
            //ddlyear4.SelectedValue = DateTime.Parse(ds.Tables[0].Rows[0]["dtinsuranceedate"].ToString()).Year.ToString();           
        }
        btnSave.Text = "Update";
    }
    protected void btndelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton delete = (ImageButton)sender;
        TableCell cell = delete.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        DataAccess da = new DataAccess();
        string sql = "delete tblvehiclemaster where intid=" + item.Cells[0].Text;
        Functions.UserLogs(Session["UserID"].ToString(), "tblvehiclemaster",item.Cells[0].Text, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),116);

        da.ExceuteSqlQuery(sql);
        fillgrid();
        Clear();
    }

}
