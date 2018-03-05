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

public partial class school_classtimingsandperiods : System.Web.UI.Page
{
    public DataAccess da;
    public DataSet ds;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillclass();
            trinterval1.Visible = true;
            trtag1.Visible = false;
            trtag2.Visible = false;
            if (Request["sid"] != null)
            {
                ddlclass.SelectedValue = Session["ClassTimingsClassID"].ToString();
                filldetails();
                btncancel.Visible = true;
            }

            int SPI = 0;
            try
            {
                SPI = int.Parse(Session["SProfileIndex"].ToString());
            }
            catch
            {
                SPI = 0;
            }
            if (SPI < 2 && SPI !=0)
                Session["SProfileIndex"] = 2;
        }
    }

    protected void ddlnoofperiods_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillperiods();
    }

    protected void ddlnoofintervals_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlnoofintervals.SelectedValue == "1")
            {
                trinterval1.Visible = true;
                trtag1.Visible = false;
                trtag2.Visible = false;
            }
            else if (ddlnoofintervals.SelectedValue == "2")
            {
                trinterval1.Visible = true;
                trtag1.Visible = true;
                lblI3.Visible = false;
                ddlinterval3.Visible = false;
                trtag2.Visible = false;

            }
            else if (ddlnoofintervals.SelectedValue == "3")
            {
                trinterval1.Visible = true;
                trtag1.Visible = true;
                lblI3.Visible = true;
                ddlinterval3.Visible = true;
                trtag2.Visible = false;
            }
            else if (ddlnoofintervals.SelectedValue == "4")
            {
                trinterval1.Visible = true;
                trtag1.Visible = true;
                trtag2.Visible = true;
                lblI3.Visible = true;
                ddlinterval3.Visible = true;
                lblI5.Visible = false;
                ddlinterval5.Visible = false;
            }
            else if (ddlnoofintervals.SelectedValue == "5")
            {
                trinterval1.Visible = true;
                trtag1.Visible = true;
                trtag2.Visible = true;
                lblI5.Visible = true;
                ddlinterval5.Visible = true;
                lblI3.Visible = true;
                ddlinterval3.Visible = true;
            }
        }
        catch { }

    }

    protected void dlperiods_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        try
        {
            DataRowView dr = (DataRowView)e.Item.DataItem;
            DropDownList dlhh = new DropDownList();
            DropDownList dlmm = new DropDownList();
            dlhh = (DropDownList)e.Item.FindControl("ddlHH");
            dlmm = (DropDownList)e.Item.FindControl("ddlMM");
            Label lblhh = (Label)e.Item.FindControl("lblhh");
            Label lblmm = (Label)e.Item.FindControl("lblmm");
            dlhh.SelectedValue = lblhh.Text;
            dlmm.SelectedValue = lblmm.Text;
        }
        catch { }

    }

    protected void btnset_Click(object sender, EventArgs e)
    {
        filltheperiods();
        fillperiodstemp(1);
    }

    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("viewclasstimingsandperiods.aspx");
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ddlnoofperiods.SelectedIndex == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Select the Number of Periods!')", true);
        }
        else
        {
            fillperiodstemp(1);
            savetimings();
            if (lbltimingerror.Text == "")
            {
                if (btnSave.Text == "Save/Next")
                    Response.Redirect("../school/workingdays.aspx");
                else
                    Response.Redirect("../school/viewclasstimingsandperiods.aspx");
            }
        }
    }
    
    protected void filldetails()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str = "select * from tblclasstimings where strclass='"+ddlclass.SelectedValue+"' and intschoolid=" + Request["sid"].ToString();
        ds = da.ExceuteSql(str);
        if (ds.Tables[0].Rows.Count >0)
        {
            Session["ClassTimingsID"] = ds.Tables[0].Rows[0]["intclasstimingsid"].ToString();
            ddlnoofperiods.SelectedValue = ds.Tables[0].Rows[0]["intperiods"].ToString();
            fillperiods();
            ddlnoofintervals.SelectedValue = ds.Tables[0].Rows[0]["intintervals"].ToString();
            try
            {
                if (ddlnoofintervals.SelectedValue == "1")
                {
                    trinterval1.Visible = true;
                    trtag1.Visible = false;
                    trtag2.Visible = false;
                }
                else if (ddlnoofintervals.SelectedValue == "2")
                {
                    trinterval1.Visible = true;
                    trtag1.Visible = true;
                    lblI3.Visible = false;
                    ddlinterval3.Visible = false;

                    trtag2.Visible = false;
                }
                else if (ddlnoofintervals.SelectedValue == "3")
                {
                    trinterval1.Visible = true;
                    trtag1.Visible = true;
                    lblI3.Visible = true;
                    ddlinterval3.Visible = true;

                    trtag2.Visible = false;
                }
                else if (ddlnoofintervals.SelectedValue == "4")
                {
                    trinterval1.Visible = true;
                    trtag1.Visible = true;
                    trtag2.Visible = true;
                    lblI3.Visible = true;
                    ddlinterval3.Visible = true;
                    lblI5.Visible = false;
                    ddlinterval5.Visible = false;
                }
                else if (ddlnoofintervals.SelectedValue == "5")
                {
                    trinterval1.Visible = true;
                    trtag1.Visible = true;
                    trtag2.Visible = true;
                    lblI5.Visible = true;
                    ddlinterval5.Visible = true;
                    lblI3.Visible = true;
                    ddlinterval3.Visible = true;
                }
            }
            catch { }

            ddlinterval1.SelectedValue = ds.Tables[0].Rows[0]["intfirstintervals"].ToString();
            ddlinterval2.SelectedValue = ds.Tables[0].Rows[0]["intsecondintervals"].ToString();
            ddllunch.SelectedValue = ds.Tables[0].Rows[0]["intlunch"].ToString();
            ddlinterval3.SelectedValue = ds.Tables[0].Rows[0]["intThirdIntervals"].ToString();
            ddlinterval4.SelectedValue = ds.Tables[0].Rows[0]["intFourthIntervals"].ToString();
            ddlinterval5.SelectedValue = ds.Tables[0].Rows[0]["intFifthIntervals"].ToString();

            da = new DataAccess();
            str = "select *,replace(strperiod,' Period','') as strper from tblschoolperiods where strclass='" + ddlclass.SelectedValue + "' and intschoolid =" + Request["sid"].ToString();
            ds = new DataSet();
            ds = da.ExceuteSql(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblstarttime.Text = ds.Tables[0].Rows[0]["strSTHH"].ToString() + " : " + ds.Tables[0].Rows[0]["strSTMM"].ToString();
                dlperiods.DataSource = ds;
                dlperiods.DataBind();
            }
            else
            {
                fillperiodstemp(2);
            }
            btnSave.Text = "Update";
        }
        else
        {
            btnSave.Text = "Save/Next";
        }
    }

    protected void fillperiodstemp(int fid)
    {
        if (ddlnoofperiods.SelectedIndex > 0)
        {
            DataAccess da = new DataAccess();
            string str;
            DataSet ds = new DataSet();

            str = "delete tblschoolperiodstemp where intschoolid=" + Session["SchoolID"].ToString();
            Functions.UserLogs(Session["UserID"].ToString(), "tblschoolperiodstemp", Session["SchoolID"].ToString(), "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),325);

            da.ExceuteSqlQuery(str);
            int j = 0;
            for (int i = 1; i <= int.Parse(ddlnoofperiods.SelectedValue); i++)
            {
                string li = "";
                if (i == 1)
                    li = "1st Period";
                else if (i == 2)
                    li = "2nd Period";
                else if (i == 3)
                    li = "3rd Period";
                else
                    li = i.ToString() + "th Period";

                da = new DataAccess();
                string STHH1 = "00";
                string STMM1 = "00";
                int STHH = 0;
                int STMM = 0;
               
                str = "select strassemblyend from tbltimingsandperiods where intschoolid=" + Session["SchoolID"].ToString();
                da = new DataAccess();
                ds = da.ExceuteSql(str);
                if (ds.Tables[0].Rows.Count > 0)
                  {
                     try
                        {
                         STHH = DateTime.Parse(ds.Tables[0].Rows[0]["strassemblyend"].ToString()).Hour;
                         STMM = DateTime.Parse(ds.Tables[0].Rows[0]["strassemblyend"].ToString()).Minute;
                         if (STHH < 10)
                           STHH1 = "0" + STHH.ToString();
                         else
                            STHH1 = STHH.ToString();
                         if (STMM < 10)
                            STMM1 = "0" + STMM.ToString();
                         else
                            STMM1 = STMM.ToString();
                       }
                   catch
                      {
                       STHH1 = "00";
                       STMM1 = "00";
                      }
                  }

                if (i == 1)
                {
                    j++;
                    str = "insert into tblschoolperiodstemp (intschoolid,strperiod,strSTHH,strSTMM,strETHH,strETMM,intorder,strerror) ";
                    str = str + "values(" + Session["SchoolID"].ToString() + ",'" + li + "','" + STHH1 + "','" + STMM1 + "','00','00'," + j + ",'')";
                }
                else
                {
                    j++;
                    str = "insert into tblschoolperiodstemp (intschoolid,strperiod,strSTHH,strSTMM,strETHH,strETMM,intorder,strerror) ";
                    str = str + "values(" + Session["SchoolID"].ToString() + ",'" + li + "','00','00','00','00'," + j + ",'')";
                }
                da.ExceuteSqlQuery(str);
                DataSet ds2 = new DataSet();
                str = "select max(intid) as intid from tblschoolperiodstemp";
                ds2 = da.ExceuteSql(str);
                Functions.UserLogs(Session["UserID"].ToString(), "tblschoolperiodstemp", ds2.Tables[0].Rows[0]["intid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),325);

                if (ddlnoofperiods.SelectedValue == "1")
                {
                }
                else
                {
                    if (i.ToString() == ddlinterval1.SelectedValue)
                    {
                        j++;
                        da = new DataAccess();
                        str = "insert into tblschoolperiodstemp (intschoolid,strperiod,strSTHH,strSTMM,strETHH,strETMM,intorder,strerror) ";
                        str = str + "values(" + Session["SchoolID"].ToString() + ",'First Interval','00','00','00','00'," + j + ",'')";
                        da.ExceuteSqlQuery(str);

                        ds2 = new DataSet();
                        str = "select max(intid) as intid from tblschoolperiodstemp";
                        ds2 = da.ExceuteSql(str);
                        Functions.UserLogs(Session["UserID"].ToString(), "tblschoolperiodstemp", ds2.Tables[0].Rows[0]["intid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),325);
                    }
                    if (i.ToString() == ddlinterval2.SelectedValue)
                    {
                        if (int.Parse(ddlnoofintervals.SelectedValue) >= 2)
                        {
                            j++;
                            da = new DataAccess();
                            str = "insert into tblschoolperiodstemp (intschoolid,strperiod,strSTHH,strSTMM,strETHH,strETMM,intorder,strerror) ";
                            str = str + "values(" + Session["SchoolID"].ToString() + ",'Second Interval','00','00','00','00'," + j + ",'')";
                            da.ExceuteSqlQuery(str);

                            ds2 = new DataSet();
                            str = "select max(intid) as intid from tblschoolperiodstemp";
                            ds2 = da.ExceuteSql(str);
                            Functions.UserLogs(Session["UserID"].ToString(), "tblschoolperiodstemp", ds2.Tables[0].Rows[0]["intid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),325);
                        }
                    }
                    if (i.ToString() == ddlinterval3.SelectedValue)
                    {
                        if (int.Parse(ddlnoofintervals.SelectedValue) >= 3)
                        {
                            j++;
                            da = new DataAccess();
                            str = "insert into tblschoolperiodstemp (intschoolid,strperiod,strSTHH,strSTMM,strETHH,strETMM,intorder,strerror) ";
                            str = str + "values(" + Session["SchoolID"].ToString() + ",'Third Interval','00','00','00','00'," + j + ",'')";
                            da.ExceuteSqlQuery(str);

                            ds2 = new DataSet();
                            str = "select max(intid) as intid from tblschoolperiodstemp";
                            ds2 = da.ExceuteSql(str);
                            Functions.UserLogs(Session["UserID"].ToString(), "tblschoolperiodstemp", ds2.Tables[0].Rows[0]["intid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),325);
                        
                        }
                    }

                    if (i.ToString() == ddlinterval4.SelectedValue)
                    {
                        if (int.Parse(ddlnoofintervals.SelectedValue) >= 4)
                        {

                            j++;
                            da = new DataAccess();
                            str = "insert into tblschoolperiodstemp (intschoolid,strperiod,strSTHH,strSTMM,strETHH,strETMM,intorder,strerror) ";
                            str = str + "values(" + Session["SchoolID"].ToString() + ",'Fourth Interval','00','00','00','00'," + j + ",'')";
                            da.ExceuteSqlQuery(str);

                            ds2 = new DataSet();
                            str = "select max(intid) as intid from tblschoolperiodstemp";
                            ds2 = da.ExceuteSql(str);
                            Functions.UserLogs(Session["UserID"].ToString(), "tblschoolperiodstemp", ds2.Tables[0].Rows[0]["intid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),325);
                        }
                    }

                    if (i.ToString() == ddlinterval5.SelectedValue)
                    {
                        if (int.Parse(ddlnoofintervals.SelectedValue) == 5)
                        {
                            j++;
                            da = new DataAccess();
                            str = "insert into tblschoolperiodstemp (intschoolid,strperiod,strSTHH,strSTMM,strETHH,strETMM,intorder,strerror) ";
                            str = str + "values(" + Session["SchoolID"].ToString() + ",'Fifth Interval','00','00','00','00'," + j + ",'')";
                            da.ExceuteSqlQuery(str);

                            ds2 = new DataSet();
                            str = "select max(intid) as intid from tblschoolperiodstemp";
                            ds2 = da.ExceuteSql(str);
                            Functions.UserLogs(Session["UserID"].ToString(), "tblschoolperiodstemp", ds2.Tables[0].Rows[0]["intid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),325);
                        }
                    }

                    if (i.ToString() == ddllunch.SelectedValue)
                    {
                        j++;
                        da = new DataAccess();
                        str = "insert into tblschoolperiodstemp (intschoolid,strperiod,strSTHH,strSTMM,strETHH,strETMM,intorder,strerror) ";
                        str = str + "values(" + Session["SchoolID"].ToString() + ",'Lunch','00','00','00','00'," + j + ",'')";
                        da.ExceuteSqlQuery(str);

                        ds2 = new DataSet();
                        str = "select max(intid) as intid from tblschoolperiodstemp";
                        ds2 = da.ExceuteSql(str);
                        Functions.UserLogs(Session["UserID"].ToString(), "tblschoolperiodstemp", ds2.Tables[0].Rows[0]["intid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),325);
                    }
                }
            }

            if (fid == 1)
            {
                for (int i = 0; i < dlperiods.Items.Count; i++)
                {
                    DataListItem dgi = dlperiods.Items[i];
                    DropDownList ddlhh = (DropDownList)dgi.FindControl("ddlhh");
                    DropDownList ddlmm = (DropDownList)dgi.FindControl("ddlmm");
                    Label lblperiod = (Label)dgi.FindControl("lblperiod");
                    da = new DataAccess();
                    str = "update tblschoolperiodstemp set strETHH='" + ddlhh.SelectedValue + "',strETMM='" + ddlmm.SelectedValue + "',strerror='' where intschoolid=" + Session["SchoolID"].ToString() + " and strperiod='" + lblperiod.Text + "'";
                    Functions.UserLogs(Session["UserID"].ToString(), "tblschoolperiodstemp", lblperiod.Text, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),325);

                    da.ExceuteSqlQuery(str);
                }
            }

            da = new DataAccess();
            str = "select *,replace(strperiod,' Period','') as strper from tblschoolperiodstemp where intschoolid=" + Session["SchoolID"].ToString() + " order by intorder";
            ds = new DataSet();
            ds = da.ExceuteSql(str);
            lblstarttime.Text = ds.Tables[0].Rows[0]["strSTHH"].ToString() + ":" + ds.Tables[0].Rows[0]["strSTMM"].ToString();
            dlperiods.DataSource = ds;
            dlperiods.DataBind();
            
            str = "select strassemblyend from tbltimingsandperiods where intschoolid=" + Session["SchoolID"].ToString();
            da = new DataAccess();
            ds = da.ExceuteSql(str);
            lblstarttime.Text = ds.Tables[0].Rows[0]["strassemblyend"].ToString();
            
            
            
        }
        else
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please Select No of Periods!')", true);
    
      }

    protected void filltheperiods()
    {
        lbltimingerror.Text = "";
            try
            {
                if (int.Parse(ddlnoofperiods.SelectedValue) <= int.Parse(ddlnoofintervals.SelectedValue))
                    lbltimingerror.Text = "No Of Intervals Cannot Be Greater Than or Equal To No Of Periods";
            }
            catch
            {
                lbltimingerror.Text = "No Of Intervals Cannot Be Greater Than or Equal To No Of Periods";
            }
    }

    private void savetimings()
    {
        filltheperiods();

        string STHH1 = "00";
        string STMM1 = "00";
        int STHH = 0;
        int STMM = 0;
        string str;
        str = "select strassemblyend from tbltimingsandperiods where intschoolid=" + Session["SchoolID"].ToString();
        da = new DataAccess();
        ds = da.ExceuteSql(str);

        if (ds.Tables[0].Rows.Count > 0)
        {
            try
            {
                STHH = DateTime.Parse(ds.Tables[0].Rows[0]["strassemblyend"].ToString()).Hour;
                STMM = DateTime.Parse(ds.Tables[0].Rows[0]["strassemblyend"].ToString()).Minute;
                if (STHH < 10)
                    STHH1 = "0" + STHH.ToString();
                else
                    STHH1 = STHH.ToString();
                if (STMM < 10)
                    STMM1 = "0" + STMM.ToString();
                else
                    STMM1 = STMM.ToString();
            }
            catch
            {
                STHH1 = "00";
                STMM1 = "00";
            }
        }

        //string ETHH1 = "00";
        //string ETMM1 = "00";
        //int ETHH = 0;
        //int ETMM = 0;
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    try
        //    {
        //        ETHH = DateTime.Parse(ds.Tables[0].Rows[0]["strendtime"].ToString()).Hour;
        //        ETMM = DateTime.Parse(ds.Tables[0].Rows[0]["strendtime"].ToString()).Minute;
        //        if (ETHH < 10)
        //            ETHH1 = "0" + ETHH.ToString();
        //        else
        //            ETHH1 = ETHH.ToString();
        //        if (ETMM < 10)
        //            ETMM1 = "0" + ETMM.ToString();
        //        else
        //            ETMM1 = ETMM.ToString();
        //    }
        //    catch
        //    {
        //        ETHH1 = "00";
        //        ETMM1 = "00";
        //    }
        //}

        int interror = 0;
        for (int i = 0; i < dlperiods.Items.Count; i++)
        {
            DataListItem dgi = dlperiods.Items[i];
            DropDownList ddlhh = (DropDownList)dgi.FindControl("ddlhh");
            DropDownList ddlmm = (DropDownList)dgi.FindControl("ddlmm");
            Label lblperiod = (Label)dgi.FindControl("lblperiod");
            DateTime ST = DateTime.Parse(STHH1 + ":" + STMM1);
            DateTime ET = DateTime.Parse(ddlhh.SelectedValue + ":" + ddlmm.SelectedValue);
            //DateTime ET1 = DateTime.Parse(ETHH1 + ":" + ETMM1);
            if (ST >= ET)
            {
                if (lbltimingerror.Text == "")
                    lbltimingerror.Text = "Invalid End Time for " + lblperiod.Text;
                else
                    lbltimingerror.Text = lbltimingerror.Text + " / " + lblperiod.Text;
                interror = 1;
                ddlhh.BackColor = System.Drawing.Color.Red;
                ddlmm.BackColor = System.Drawing.Color.Red;
            }
            //else if (ET > ET1)
            //{
            //    if (lbltimingerror.Text == "")
            //        lbltimingerror.Text = "End Time Greater Than School End Time for " + lblperiod.Text;
            //    else
            //        lbltimingerror.Text = lbltimingerror.Text + " / " + "End Time Greater Than School End Time for " + lblperiod.Text;
            //    interror = 1;
            //    ddlhh.BackColor = System.Drawing.Color.Red;
            //    ddlmm.BackColor = System.Drawing.Color.Red;
            //}
            else
            {
                ddlhh.BackColor = System.Drawing.Color.White;
                ddlmm.BackColor = System.Drawing.Color.White;
            }

            //if (i == dlperiods.Items.Count - 1)
            //{
            //    if (ET != ET1)
            //    {
            //        if (lbltimingerror.Text == "")
            //            lbltimingerror.Text = "School End Time Mismatch" + lblperiod.Text;
            //        else
            //            lbltimingerror.Text = lbltimingerror.Text + " / " + "School End Time Mismatch";
            //        interror = 1;
            //        ddlhh.BackColor = System.Drawing.Color.Red;
            //        ddlmm.BackColor = System.Drawing.Color.Red;
            //    }
            //}
            STHH1 = ddlhh.SelectedValue;
            STMM1 = ddlmm.SelectedValue;
        }

        if (interror == 1)
            lbltimingerror.Visible = true;
        else
        {
            SqlCommand command;
            SqlParameter OutPutParam;
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
            conn.Open();
            command = new SqlCommand("spclasstimings", conn);
            command.CommandType = CommandType.StoredProcedure;
            OutPutParam = command.Parameters.Add("@rc", SqlDbType.Int);
            OutPutParam.Direction = ParameterDirection.Output;
            if (btnSave.Text == "Save/Next")
                command.Parameters.Add("@intclasstimingsid", "0");
            else
                command.Parameters.Add("@intclasstimingsid", Session["ClassTimingsID"].ToString());
            command.Parameters.Add("@intschoolid", Session["SchoolID"]);
            command.Parameters.Add("@intperiods", ddlnoofperiods.SelectedValue);
            command.Parameters.Add("@intintervals", ddlnoofintervals.SelectedValue);
            command.Parameters.Add("@intfirstintervals", ddlinterval1.SelectedValue);
            command.Parameters.Add("@intsecondintervals", ddlinterval2.SelectedValue);
            command.Parameters.Add("@intThirdIntervals", ddlinterval3.SelectedValue);
            command.Parameters.Add("@intFourthIntervals", ddlinterval4.SelectedValue);
            command.Parameters.Add("@intFifthIntervals", ddlinterval5.SelectedValue);
            command.Parameters.Add("@intlunch", ddllunch.SelectedValue);
            command.Parameters.Add("@strclass", ddlclass.SelectedValue);
            command.Parameters.Add("@strsection", "");
            command.ExecuteNonQuery();
            conn.Close();

            str = "delete tblschoolperiods where strclass='" + ddlclass.SelectedValue + "' and intschoolid=" + Session["SchoolID"].ToString();
            Functions.UserLogs(Session["UserID"].ToString(), "tblschoolperiods", ddlclass.SelectedValue, "Deleted", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 325);
            da.ExceuteSqlQuery(str);

            if (ds.Tables[0].Rows.Count > 0)
            {
                try
                {
                    STHH = DateTime.Parse(ds.Tables[0].Rows[0]["strassemblyend"].ToString()).Hour;
                    STMM = DateTime.Parse(ds.Tables[0].Rows[0]["strassemblyend"].ToString()).Minute;
                    if (STHH < 10)
                        STHH1 = "0" + STHH.ToString();
                    else
                        STHH1 = STHH.ToString();
                    if (STMM < 10)
                        STMM1 = "0" + STMM.ToString();
                    else
                        STMM1 = STMM.ToString();
                }
                catch
                {
                    STHH1 = "00";
                    STMM1 = "00";
                }
            }

            for (int i = 0; i < dlperiods.Items.Count; i++)
            {
                int j = i + 1;
                DataListItem dgi = dlperiods.Items[i];
                DropDownList ddlhh = (DropDownList)dgi.FindControl("ddlhh");
                DropDownList ddlmm = (DropDownList)dgi.FindControl("ddlmm");
                Label lblperiod = (Label)dgi.FindControl("lblperiod");
                da = new DataAccess();
                str = "insert into tblschoolperiods (intschoolid,strperiod,strSTHH,strSTMM,strETHH,strETMM,intorder,strclass) ";
                str = str + "values(" + Session["SchoolID"].ToString() + ",'" + lblperiod.Text + "','" + STHH1 + "','" + STMM1 + "','" + ddlhh.SelectedValue + "','" + ddlmm.SelectedValue + "'," + j.ToString() + ",'" + ddlclass.SelectedValue + "')";
                da.ExceuteSqlQuery(str);
                STHH1 = ddlhh.SelectedValue;
                STMM1 = ddlmm.SelectedValue;

                DataSet ds2 = new DataSet();
                str = "select max(intperiodsid) as intperiodsid from tblschoolperiods";
                ds2 = da.ExceuteSql(str);
                Functions.UserLogs(Session["UserID"].ToString(), "tblschoolperiods", ds2.Tables[0].Rows[0]["intperiodsid"].ToString(), "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 325);


            }
        }
    }

    private void fillperiods()
    {
        try
        {
            ddlinterval1.Items.Clear();
            ddlinterval2.Items.Clear();
            ddllunch.Items.Clear();
            ddlinterval3.Items.Clear();
            ddlinterval4.Items.Clear();
            ddlinterval5.Items.Clear();
            ListItem li;
            for (int i = 1; i <= int.Parse(ddlnoofperiods.SelectedValue); i++)
            {
                if (i == 1)
                    li = new ListItem("1st Period", i.ToString());
                else if (i == 2)
                    li = new ListItem("2nd Period", i.ToString());
                else if (i == 3)
                    li = new ListItem("3rd Period", i.ToString());
                else
                    li = new ListItem(i.ToString() + "th Period", i.ToString());

                ddlinterval1.Items.Add(li);
            }

            ListItem li3;
            for (int i = 1; i <= int.Parse(ddlnoofperiods.SelectedValue); i++)
            {
                if (i == 1)
                    li3 = new ListItem("1st Period", i.ToString());
                else if (i == 2)
                    li3 = new ListItem("2nd Period", i.ToString());
                else if (i == 3)
                    li3 = new ListItem("3rd Period", i.ToString());
                else
                    li3 = new ListItem(i.ToString() + "th Period", i.ToString());

                ddlinterval3.Items.Add(li3);
            }

            ListItem li4;
            for (int i = 1; i <= int.Parse(ddlnoofperiods.SelectedValue); i++)
            {
                if (i == 1)
                    li4 = new ListItem("1st Period", i.ToString());
                else if (i == 2)
                    li4 = new ListItem("2nd Period", i.ToString());
                else if (i == 3)
                    li4 = new ListItem("3rd Period", i.ToString());
                else
                    li4 = new ListItem(i.ToString() + "th Period", i.ToString());

                ddlinterval4.Items.Add(li4);
            }

            ListItem li5;
            for (int i = 1; i <= int.Parse(ddlnoofperiods.SelectedValue); i++)
            {
                if (i == 1)
                    li5 = new ListItem("1st Period", i.ToString());
                else if (i == 2)
                    li5 = new ListItem("2nd Period", i.ToString());
                else if (i == 3)
                    li5 = new ListItem("3rd Period", i.ToString());
                else
                    li5 = new ListItem(i.ToString() + "th Period", i.ToString());

                ddlinterval5.Items.Add(li5);
            }

            ListItem li1;
            for (int i = 1; i <= int.Parse(ddlnoofperiods.SelectedValue); i++)
            {
                if (i == 1)
                    li1 = new ListItem("1st Period", i.ToString());
                else if (i == 2)
                    li1 = new ListItem("2nd Period", i.ToString());
                else if (i == 3)
                    li1 = new ListItem("3rd Period", i.ToString());
                else
                    li1 = new ListItem(i.ToString() + "th Period", i.ToString());

                ddlinterval2.Items.Add(li1);
            }

            ListItem li2;
            for (int i = 1; i <= int.Parse(ddlnoofperiods.SelectedValue); i++)
            {
                if (i == 1)
                    li2 = new ListItem("1st Period", i.ToString());
                else if (i == 2)
                    li2 = new ListItem("2nd Period", i.ToString());
                else if (i == 3)
                    li2 = new ListItem("3rd Period", i.ToString());
                else
                    li2 = new ListItem(i.ToString() + "th Period", i.ToString());

                ddllunch.Items.Add(li2);
            }
        }
        catch { }
    }
    
    protected void ddlETHH_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList list = (DropDownList)sender;
        TableCell cell = list.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        int index = item.ItemIndex;
        DropDownList dlhh = new DropDownList();
        DropDownList dlmm = new DropDownList();
        dlhh = (DropDownList)item.FindControl("ddlETHH");
        dlmm = (DropDownList)item.FindControl("ddlETMM");
        if (DateTime.Parse(item.Cells[1].Text) > DateTime.Parse(dlhh.SelectedValue + ":" + dlmm.SelectedValue))
        {
            //lblerror.Text = "Invalid Time!";
        }
        else
        {
            DataAccess da = new DataAccess();
            string str = "select intid from tblschoolperiodstemp where intschool=" + item.Cells[5].Text + " and intorder=" + item.Cells[4].Text + "+1";
            ds = da.ExceuteSql(str);

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Functions.UserLogs(Session["UserID"].ToString(), "tblschoolperiodstemp", ds.Tables[0].Rows[0]["intid"].ToString(), "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),325);

                }
            }

            str = "update tblschoolperiodstemp set strSTHH='" + dlhh.SelectedValue + "',strSTMM='" + dlmm.SelectedValue + "' where intschool=" + item.Cells[5].Text + " and intorder=" + item.Cells[4].Text + "+1";
            da.ExceuteSqlQuery(str);

            da = new DataAccess();
            str = "update tblschoolperiodstemp set strETHH='" + dlhh.SelectedValue + "',strETMM='" + dlmm.SelectedValue + "' where intid=" + item.Cells[3].Text;
            Functions.UserLogs(Session["UserID"].ToString(), "tblschoolperiodstemp", item.Cells[3].Text, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),325);

            da.ExceuteSqlQuery(str);
            filltheperiods();
        }
    }

    protected void ddlETMM_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList list = (DropDownList)sender;
        TableCell cell = list.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        int index = item.ItemIndex;
        DropDownList dlhh = new DropDownList();
        DropDownList dlmm = new DropDownList();
        dlhh = (DropDownList)item.FindControl("ddlETHH");
        dlmm = (DropDownList)item.FindControl("ddlETMM");
        if (DateTime.Parse(item.Cells[1].Text) > DateTime.Parse(dlhh.SelectedValue + ":" + dlmm.SelectedValue))
        {
            //lblerror.Text = "Invalid Time!";
        }
        else
        {
            ///lblerror.Text = "";
            DataAccess da = new DataAccess();
            string str = "select intid from tblschoolperiodstemp where intschool=" + item.Cells[5].Text + " and intorder=" + item.Cells[4].Text + "+1";
            ds = da.ExceuteSql(str);

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Functions.UserLogs(Session["UserID"].ToString(), "tblschoolperiodstemp", ds.Tables[0].Rows[0]["intid"].ToString(), "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),325);

                }
            }

            str = "update tblschoolperiodstemp set strSTHH='" + dlhh.SelectedValue + "',strSTMM='" + dlmm.SelectedValue + "' where intschool=" + item.Cells[5].Text + " and intorder=" + item.Cells[4].Text + "+1";
            da.ExceuteSqlQuery(str);

            da = new DataAccess();
            str = "update tblschoolperiodstemp set strETHH='" + dlhh.SelectedValue + "',strETMM='" + dlmm.SelectedValue + "' where intid=" + item.Cells[3].Text;
            Functions.UserLogs(Session["UserID"].ToString(), "tblschoolperiodstemp", item.Cells[3].Text, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(),325);

            da.ExceuteSqlQuery(str);

            filltheperiods();
        }
    }

    protected void dg_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        try
        {
            DataRowView dr = (DataRowView)e.Item.DataItem;
            DropDownList dlhh = new DropDownList();
            DropDownList dlmm = new DropDownList();
            dlhh = (DropDownList)e.Item.FindControl("ddlETHH");
            dlmm = (DropDownList)e.Item.FindControl("ddlETMM");
            dlhh.SelectedValue = dr["strETHH"].ToString();
            dlmm.SelectedValue = dr["strETMM"].ToString();
        }
        catch { }
    }

    private void fillclass()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string sql = "select * from tblschoolstandard where intschoolid=" + Session["SchoolID"].ToString();
        ds = da.ExceuteSql(sql);
        ddlclass.DataSource = ds;
        ddlclass.DataTextField = "strstandard";
        ddlclass.DataValueField = "strstandard";
        ddlclass.DataBind();
    }
     protected void ddlclass_SelectedIndexChanged(object sender, EventArgs e)
     {
         filldetails();
     }
}
