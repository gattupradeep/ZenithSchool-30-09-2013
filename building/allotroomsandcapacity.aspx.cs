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

public partial class school_allotroomsandcapacity : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public string strsql;
    public DataAccess da;
    public DataSet ds;
    public SqlCommand cmd;

    protected void Page_Load(object sender, EventArgs e)
    {       
        if (!IsPostBack)
        {
            if (ddlroomtype.SelectedValue == "Classes")
            {
                trclasses.Visible = true;
                trothers.Visible = false;
            }
            if (ddlroomtype.SelectedValue == "Others")
            {
                trclasses.Visible = false;
                trothers.Visible = true;
            }
            fillbuildname();
            fillfloor();
            fillroomno();
            fillclass();
            fillsection();
            fillgrid();

        }
    }

    protected void fillgrid()
    {
        strsql = "select a.*,a.strclass+' - '+a.strsection as roomname,b.strbuildname from tblroomcapacity a, tblbuilding b where a.intbuildname=b.intid and a.intschool=" + Session["SchoolID"] +" and a.strclass !='' ";
        strsql += " union all";
        strsql += " select a.*,a.strother as roomname,b.strbuildname from tblroomcapacity a, tblbuilding b where a.intbuildname=b.intid and a.intschool=" + Session["SchoolID"] + " and a.strother!=''";

        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        dgcapacity.DataSource = ds;
        dgcapacity.DataBind();
    }

    protected void fillbuildname()
    {
        strsql = "select * from tblbuilding where intschool=" + Session["SchoolID"].ToString();
        SqlDataAdapter da = new SqlDataAdapter(strsql, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlbuildname.DataSource = ds;
        ddlbuildname.DataTextField = "strbuildname";
        ddlbuildname.DataValueField = "intid";
        ddlbuildname.DataBind();
    }

    protected void fillfloor()
    {
        ddlfloor.Items.Clear();
        strsql = "select strfloortype from tblcountry where intcountryID = (select intcountryid from tbldetails where intschoolid=" + Session["SchoolID"].ToString() +")";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        string strfloor = "Floor";
        if (ds.Tables[0].Rows.Count > 0)
            strfloor = ds.Tables[0].Rows[0]["strfloortype"].ToString();

        strsql = "select intnooffloors from tblbuilding where intschool= '"+ Session["schoolID"].ToString()+"' and intid = '" + ddlbuildname.SelectedValue+"'" ;
        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);

        int n = int.Parse(ds.Tables[0].Rows[0]["intnooffloors"].ToString());

        ListItem Li;
        Li = new ListItem("Ground Floor", "Ground Floor");
        ddlfloor.Items.Add(Li);
        for (int i = 1; i <= n; i++)
        {
            string std;
            if (i == 1)
                std = "1st " + strfloor;
            else if (i == 2)
                std = "2nd " + strfloor;
            else if (i == 3)
                std = "3rd " + strfloor;
            else
                std = i.ToString() + "th " + strfloor;

            Li = new ListItem(std, std);
            ddlfloor.Items.Add(Li);
        }
    }

    protected void fillroomno()
    {
        ddlrooms.Items.Clear();
        int i, k, j;
        int l = 0;
        strsql = "select intfroom,inttroom,* from tblassignbuilding where strfloor='" + ddlfloor.SelectedValue + "' and intbuilding='" + ddlbuildname.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString();
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            i = int.Parse(ds.Tables[0].Rows[0]["intfroom"].ToString());
            j = int.Parse(ds.Tables[0].Rows[0]["inttroom"].ToString());
            for (k = i; k <= j; k++)
            {
                ListItem li;
                li = new ListItem(k.ToString(), k.ToString());
                ddlrooms.Items.Insert(l, li);
                l++;
            }
        }
    }

    protected void fillclass()
    {
        DataAccess da = new DataAccess();
        strsql = "select * from tblschoolstandard where intschoolid=" + Session["SchoolID"].ToString() + " order by intschoolstandardid";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddlclass.DataSource = ds;
        ddlclass.DataTextField = "strstandard";
        ddlclass.DataValueField = "strstandard";
        ddlclass.DataBind();
    }

    protected void fillsection()
    {
        DataAccess da = new DataAccess();
        strsql = "select * from tblschoolsection where intschoolid=" + Session["SchoolID"].ToString();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        ddlsection.DataSource = ds;
        ddlsection.DataTextField = "strsection";
        ddlsection.DataValueField = "strsection";
        ddlsection.DataBind();
    }

    protected void clear()
    {
        txtcapacity.Text = "";
        txtother.Text = "";
        btnSave.Text = "Save";
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        DataAccess da = new DataAccess();
        if (btnSave.Text == "Save")
            strsql = "select * from tblroomcapacity where intbuildname=" + ddlbuildname.SelectedValue + " and strfloor='" + ddlfloor.SelectedValue + "' and strroomno='" + ddlrooms.SelectedValue + "'  and intschool=" + Session["SchoolID"].ToString();
        else
            strsql = "select * from tblroomcapacity where intbuildname=" + ddlbuildname.SelectedValue + " and strfloor='" + ddlfloor.SelectedValue + "' and strroomno='" + ddlrooms.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + "  and intid !=" + Session["ID"].ToString();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            msgbox.alert("Room Already Alloted");
        }
        else
        {
            da = new DataAccess();
            if (btnSave.Text == "Save")
                strsql = "select * from tblroomcapacity where strclass + ' - ' + strsection ='" + ddlclass.SelectedValue + " - " + ddlsection.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString();
            else
                strsql = "select * from tblroomcapacity where strclass + ' - ' + strsection ='" + ddlclass.SelectedValue + " - " + ddlsection.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + "  and intid !=" + Session["ID"].ToString();
            ds = new DataSet();
            ds = da.ExceuteSql(strsql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                msgbox.alert("Class Already Alloted");
            }
            else
            {
                SqlCommand RegCommand;
                SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);

                Conn.Open();
                RegCommand = new SqlCommand("sproomcapacity", Conn);
                RegCommand.CommandType = CommandType.StoredProcedure;
                if (btnSave.Text == "Save")
                {
                    RegCommand.Parameters.Add("@intID", "0");
                }
                else
                {
                    RegCommand.Parameters.Add("@intID", Session["ID"].ToString());
                }
                RegCommand.Parameters.Add("@intbuildname", ddlbuildname.SelectedValue);
                RegCommand.Parameters.Add("@strfloor", ddlfloor.SelectedValue);
                RegCommand.Parameters.Add("@strroomno", ddlrooms.SelectedValue);
                RegCommand.Parameters.Add("@strroomtype", ddlroomtype.SelectedValue);
                if (ddlroomtype.SelectedValue == "Classes")
                {
                    RegCommand.Parameters.Add("@strclass", ddlclass.SelectedValue);
                    RegCommand.Parameters.Add("@strsection", ddlsection.SelectedValue);
                    RegCommand.Parameters.Add("@strother", "");
                }
                if (ddlroomtype.SelectedValue == "Others")
                {
                    RegCommand.Parameters.Add("@strclass", "");
                    RegCommand.Parameters.Add("@strsection", "");
                    RegCommand.Parameters.Add("@strother", txtother.Text.ToString());
                }
                RegCommand.Parameters.Add("@strcapacity", txtcapacity.Text.ToString());
                RegCommand.Parameters.Add("@intschool", Session["SchoolID"].ToString());
                RegCommand.ExecuteNonQuery();
                Conn.Close();
                clear();
                fillgrid();
            }
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        clear();
    }

    //protected void dgcapacity_DeleteCommand(object source, DataGridCommandEventArgs e)
    //{
    //    strsql = "delete tblroomcapacity where intid=" + e.Item.Cells[0].Text;
    //    cmd = new SqlCommand(strsql, conn);
    //    conn.Open();
    //    cmd.ExecuteNonQuery();
    //    conn.Close();
    //    fillgrid();
    //}

    protected void dgcapacity_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["ID"] = e.Item.Cells[0].Text;
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        strsql = "select * from tblroomcapacity where intschool='"+ Session["SchoolID"] +"' and intid ='"+ Session["ID"] +"'";
        ds = da.ExceuteSql(strsql);
        fillbuildname();
        ddlbuildname.SelectedValue =ds.Tables[0].Rows[0]["intbuildname"].ToString();
        fillfloor();
        ddlfloor.SelectedValue=ds.Tables[0].Rows[0]["strfloor"].ToString();
        fillroomno();
        ddlrooms.SelectedValue = ds.Tables[0].Rows[0]["strroomno"].ToString();
        ddlroomtype.SelectedValue = ds.Tables[0].Rows[0]["strroomtype"].ToString();
        if(ddlroomtype.SelectedValue == "Classes")
        {
            ddlclass.SelectedValue = ds.Tables[0].Rows[0]["strclass"].ToString();
            ddlsection.SelectedValue = ds.Tables[0].Rows[0]["strsection"].ToString();
            txtother.Text = "";
            trclasses.Visible = true;
            trothers.Visible = false;
        }
        if (ddlroomtype.SelectedValue == "Others")
        {
            trclasses.Visible = false;
            trothers.Visible = true;
            ddlclass.SelectedValue = "";
            ddlsection.SelectedValue = "";
            txtother.Text = ds.Tables[0].Rows[0]["strother"].ToString();
        }
        txtcapacity.Text = ds.Tables[0].Rows[0]["strcapacity"].ToString();
        //ddlbuildname.SelectedValue = e.Item.Cells[8].Text;
        //fillfloor();
        //ddlfloor.SelectedValue = e.Item.Cells[2].Text;
        //fillroomno();
        //ddlrooms.SelectedValue = e.Item.Cells[3].Text;
        //ddlclass.SelectedValue = e.Item.Cells[4].Text;
        //fillsection();
        //ddlsection.SelectedValue = e.Item.Cells[5].Text;
        //txtcapacity.Text = e.Item.Cells[6].Text;
        //txtother.Text = e.Item.Cells[7].Text;
        btnSave.Text = "Update";
        fillgrid();
    }

    protected void ddlfloor_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            fillroomno();
        }
        catch { }
    }

    protected void ddlbuildname_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            fillfloor();
            fillroomno();
        }
        catch { }
    }

    protected void ddlclass_SelectedIndexChanged1(object sender, EventArgs e)
    {
        fillsection();
    }
    protected void ddlroomtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlroomtype.SelectedValue == "Classes")
        {
            trclasses.Visible = true;
            trothers.Visible = false;
        }
        if (ddlroomtype.SelectedValue == "Others")
        {
            trclasses.Visible = false;
            trothers.Visible = true;
        }
    }
    protected void btndelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton delete = (ImageButton)sender;
        TableCell cell = delete.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        strsql = "delete tblroomcapacity where intid=" + item.Cells[0].Text;
        cmd = new SqlCommand(strsql, conn);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
        fillgrid();
    }
}
