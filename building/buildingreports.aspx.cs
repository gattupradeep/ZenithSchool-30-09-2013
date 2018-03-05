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

public partial class school_buildingreports : System.Web.UI.Page
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
            fillbuildname();
            fillfloor();
            fillotherrooms();
            //fillnoofrooms();
            fillclass();
            ddlsection.Items.Insert(0,"-Select-");
            //fillgrid();
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
            if (Session["PatronType"] == "Students" || Session["PatronType"] == "Parents" || Session["PatronType"].ToString() == "Teaching Staffs")
            {
                trsidemenu.Visible = false;
            }
        }
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
            fillotherrooms();
            trclasses.Visible = false;
            trothers.Visible = true;
        }
    }
    
    protected void fillgrid()
    {
        if (ddlbuildname.SelectedValue == "-Select-")
        {
            if (txtroomno.Text == "")
            {
                if(ddlclass.SelectedValue=="-Select-")
                {
                    if (ddlotherroom.SelectedValue == "-Select-")
                    {
                        strsql = "select * from tblroomcapacity where intschool='" + Session["SchoolID"] + "' and intid = ''";
                    }
                }
            }
        }
        if(ddlbuildname.SelectedValue == "All")
        {
            strsql = "select a.*,a.strclass+' - '+a.strsection as roomname,b.*,b.strbuildname as buildingname from tblroomcapacity a, tblbuilding b where a.intbuildname=b.intid and a.strclass!='' and a.intschool=" + Session["SchoolID"].ToString();
            strsql += " union all select a.*,a.strother as roomname,b.*,b.strbuildname as buildingname from tblroomcapacity a, tblbuilding b where a.intbuildname=b.intid and a.strother !='' and a.intschool=" + Session["SchoolID"].ToString();
        }
        if (ddlbuildname.SelectedIndex > 1 && ddlfloor.SelectedIndex <= 1)
        {
            strsql = "select a.*,a.strclass+' - '+a.strsection as roomname,b.*,b.strbuildname as buildingname from tblroomcapacity a, tblbuilding b where a.intbuildname=b.intid and a.strclass!='' and a.intbuildname= '" + ddlbuildname.SelectedValue + "' and a.intschool=" + Session["SchoolID"].ToString();
            strsql += " union all select a.*,a.strother as roomname,b.*,b.strbuildname as buildingname from tblroomcapacity a, tblbuilding b where a.intbuildname=b.intid and a.strother !='' and a.intbuildname= '" + ddlbuildname.SelectedValue + "' and a.intschool=" + Session["SchoolID"].ToString();
        }
        if (ddlbuildname.SelectedIndex > 1 && ddlfloor.SelectedIndex > 1)
        {
            strsql = "select a.*,a.strclass+' - '+a.strsection as roomname,b.*,b.strbuildname as buildingname from tblroomcapacity a, tblbuilding b where a.intbuildname=b.intid and a.strclass!='' and a.intbuildname= '" + ddlbuildname.SelectedValue + "' and a.strfloor='" + ddlfloor.SelectedValue + "' and a.intschool=" + Session["SchoolID"].ToString();
            strsql += " union all select a.*,a.strother as roomname,b.*,b.strbuildname as buildingname from tblroomcapacity a, tblbuilding b where a.intbuildname=b.intid and a.strother !='' and a.intbuildname= '" + ddlbuildname.SelectedValue + "' and a.strfloor='" + ddlfloor.SelectedValue + "' and a.intschool=" + Session["SchoolID"].ToString();
        }

        if(ddlroomtype.SelectedValue == "Classes")
        {
            if(ddlclass.SelectedValue == "All")
            {
                strsql = "select a.*,a.strclass+' - '+a.strsection as roomname,b.strbuildname as buildingname from tblroomcapacity a, tblbuilding b where a.intbuildname=b.intid and a.strclass !='' and a.intschool=" + Session["SchoolID"];
            }
            if (ddlclass.SelectedIndex > 1)
            {
                strsql = "select a.*,a.strclass+' - '+a.strsection as roomname,b.strbuildname as buildingname from tblroomcapacity a,tblbuilding b where a.intbuildname=b.intid and a.strclass='"+ ddlclass.SelectedValue +"' and a.intschool="+ Session["SchoolID"];
            }
            if(ddlclass.SelectedIndex > 1 && ddlsection.SelectedIndex > 1)
            {
                strsql = "select a.*,a.strclass+' - '+a.strsection as roomname,b.strbuildname as buildingname from tblroomcapacity a,tblbuilding b where a.intbuildname=b.intid and a.strclass='" + ddlclass.SelectedValue + "' and a.strsection = '" + ddlsection.SelectedValue + "' and a.intschool=" + Session["SchoolID"];
            }
            if (ddlclass.SelectedIndex > 1 && ddlsection.SelectedValue == "All")
            {
                strsql = "select a.*,a.strclass+' - '+a.strsection as roomname,b.strbuildname as buildingname from tblroomcapacity a,tblbuilding b where a.intbuildname=b.intid and a.strclass='" + ddlclass.SelectedValue + "' and a.intschool=" + Session["SchoolID"];
            }

        }
        if (ddlroomtype.SelectedValue == "Others")
        {

            if (ddlotherroom.SelectedValue == "All")
            {
                strsql = "select a.*,a.strother as roomname,b.strbuildname as buildingname from tblroomcapacity a,tblbuilding b where a.intbuildname=b.intid and a.strother!='' and a.intschool=" + Session["SchoolID"];
            }
            if (ddlotherroom.SelectedIndex > 1)
            {
                strsql = "select a.*,a.strother as roomname,b.strbuildname as buildingname from tblroomcapacity a, tblbuilding b where a.intbuildname=b.intid and a.strother='"+ ddlotherroom.SelectedValue +"' and a.intschool=" + Session["SchoolID"];
            }
        }
        if(txtroomno.Text != "")
        {
            strsql = "select a.*,a.strclass+' - '+a.strsection as roomname,b.strbuildname as buildingname from tblroomcapacity a, tblbuilding b where a.intbuildname=b.intid and a.strclass!='' and strroomno = '" + txtroomno.Text + "' and a.intschool=" + Session["SchoolID"];
            strsql += " union all select a.*,a.strother as roomname,b.strbuildname as buildingname from tblroomcapacity a, tblbuilding b where a.intbuildname=b.intid and a.strother!='' and strroomno = '" + txtroomno.Text + "' and a.intschool=" + Session["SchoolID"];
        }
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        dgreports.DataSource = ds;
        dgreports.DataBind();
    }

    protected void fillbuildname()
    {
        strsql = "select * from tblbuilding where intid in(select intbuildname from tblroomcapacity where intschool=" + Session["SchoolID"].ToString() + ")";
        SqlDataAdapter da = new SqlDataAdapter(strsql, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlbuildname.DataSource = ds;
        ddlbuildname.DataTextField = "strbuildname";
        ddlbuildname.DataValueField = "intid";
        ddlbuildname.DataBind();
        ddlbuildname.Items.Insert(0, "-Select-");
        ddlbuildname.Items.Insert(1 , "All");
    }

    protected void fillfloor()
    {
        if (ddlbuildname.SelectedValue == "-Select-")
        {
            ddlfloor.Items.Clear();
            ddlfloor.Items.Insert(0, "-Select-");
            txttotroomsinfloor.Text = "";
        }
        if (ddlbuildname.SelectedValue == "All")
        {
            ddlfloor.Items.Clear();
            ddlfloor.Items.Insert(0, "-Select-");
        }
        if(ddlbuildname.SelectedIndex > 1)
        {
            ddlfloor.Items.Clear();
            strsql = "select strfloor from tblroomcapacity where intbuildname= '" + ddlbuildname.SelectedValue + "' and intschool= '" + Session["SchoolID"].ToString() + "' group by strfloor";
            SqlDataAdapter da = new SqlDataAdapter(strsql, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            ddlfloor.DataSource = ds;
            ddlfloor.DataTextField = "strfloor";
            ddlfloor.DataValueField = "strfloor";
            ddlfloor.DataBind();
            ddlfloor.Items.Insert(0, "-Select-");
            ddlfloor.Items.Insert(1, "All");
        }
    }

    protected void fillclass()
    {
        DataAccess da = new DataAccess();
        strsql = "select strclass from tblroomcapacity where intschool=" + Session["SchoolID"].ToString() + " and strclass!='' group by strclass";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        if (ds.Tables[0].Rows.Count > 0)
            ddlclass.DataSource = ds;
        ddlclass.DataTextField = "strclass";
        ddlclass.DataValueField = "strclass";
        ddlclass.DataBind();
        ddlclass.Items.Insert(0, "-Select-");
        ddlclass.Items.Insert(1, "All");
    }

    protected void fillsection()
    {
        strsql = "select strsection from tblroomcapacity where strclass= '" + ddlclass.SelectedValue  +"' and intschool=" + Session["SchoolID"].ToString() + " group by strsection";
        DataSet ds = new DataSet(); ;
        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        if (ds.Tables[0].Rows.Count > 0)
            ddlsection.DataSource = ds;
        ddlsection.DataTextField = "strsection";
        ddlsection.DataValueField = "strsection";
        ddlsection.DataBind();
        ddlsection.Items.Insert(0, "-Select-");
        ddlsection.Items.Insert(1, "All");
    }
    protected void fillotherrooms()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        strsql = "select distinct strother from tblroomcapacity where intschool = "+ Session["SchoolID"] +" and strother !=''";
        ds = da.ExceuteSql(strsql);
        ddlotherroom.DataSource = ds;
        ddlotherroom.DataBind();
        ddlotherroom.DataTextField = "strother";
        ddlotherroom.DataValueField = "strother";
        ddlotherroom.Items.Insert(0,"-Select-");
        ddlotherroom.Items.Insert(1,"All");
    }

    protected void ddlbuildname_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlclass.SelectedIndex = 0;
        ddlsection.Items.Clear();
        ddlsection.Items.Insert(0, "-Select-");
        ddlotherroom.SelectedIndex = 0;
        txtroomno.Text = "";
        txttotroomsinfloor.Text = "";
        fillfloor();
        fillnoofrooms();
        fillgrid();
    }

    protected void fillnoofrooms()
    {
        if (ddlbuildname.SelectedValue == "-Select-")
        {
            strsql = "select * from tblassignbuilding where intschool = 17 and intid=''";
        }
        if (ddlbuildname.SelectedValue == "All")
        {
            strsql = "select sum(inttroom-intfroom+1) as noofrooms from tblassignbuilding where intschool = "+Session["SchoolID"];

        }
        if(ddlbuildname.SelectedIndex > 1)
        {
        strsql = "select sum(inttroom-intfroom+1) as noofrooms from tblassignbuilding where intbuilding= '" + ddlbuildname.SelectedValue + "'";
        }
        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        if (ds.Tables[0].Rows.Count > 0)
            txttotroomsinbuild.Text = ds.Tables[0].Rows[0]["noofrooms"].ToString();
        else
            txttotroomsinbuild.Text = "";
    }

    protected void ddlsection_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlbuildname.SelectedIndex = 0;
        ddlfloor.SelectedIndex = 0;
        txttotroomsinbuild.Text = "";
        txttotroomsinfloor.Text = "";
        txtroomno.Text = "";
        fillgrid();
    }

    protected void ddlfloor_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlfloor.SelectedValue == "-Select-")
        {
            strsql = "select sum(inttroom-intfroom+1) as noofrooms from tblassignbuilding where intbuilding= '" + ddlbuildname.SelectedValue + "' ";
        }
        if(ddlfloor.SelectedValue=="All")
        {
            strsql = "select sum(inttroom-intfroom+1) as noofrooms from tblassignbuilding where intbuilding= '" + ddlbuildname.SelectedValue + "' ";
        }
        if(ddlfloor.SelectedIndex > 1)
        {
            strsql = "select sum(inttroom-intfroom+1) as noofrooms from tblassignbuilding where intbuilding= '" + ddlbuildname.SelectedValue + "' and strfloor= '" + ddlfloor.SelectedValue + "'";
        }
        da = new DataAccess();
        ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txttotroomsinfloor.Text = ds.Tables[0].Rows[0]["noofrooms"].ToString();
        }
        fillgrid();
    }
    protected void ddlclass_SelectedIndexChanged1(object sender, EventArgs e)
    {
        ddlbuildname.SelectedIndex = 0;
        ddlfloor.Items.Clear();
        ddlfloor.Items.Insert(0, "-Select-");
        txttotroomsinbuild.Text = "";
        txttotroomsinfloor.Text = "";
        txtroomno.Text = "";
        fillsection();
        fillgrid();
    }

    protected void ddlotherroom_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlbuildname.SelectedIndex = 0;
        ddlfloor.Items.Clear();
        ddlfloor.Items.Insert(0, "-Select-");
        txttotroomsinbuild.Text = "";
        txttotroomsinfloor.Text = "";
        ddlclass.SelectedIndex = 0;
        ddlsection.SelectedIndex = 0;
        txtroomno.Text = "";
        fillgrid();
    }
    protected void txtroomno_TextChanged(object sender, EventArgs e)
    {
        ddlbuildname.SelectedIndex = 0;
        ddlfloor.Items.Clear();
        ddlfloor.Items.Insert(0, "-Select-");
        ddlclass.SelectedIndex = 0;
        ddlsection.Items.Clear();
        ddlsection.Items.Insert(0,"-Select-");
        fillgrid();
    }
}
