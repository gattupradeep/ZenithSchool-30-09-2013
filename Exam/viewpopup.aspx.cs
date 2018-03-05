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

public partial class Exam_viewpopup : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public DataAccess da;
    public DataSet ds;
    public string str;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["hid"] != null)
            {
                fillgrid();
                view();
                tr3tag.Visible = true;
                tr1.Visible = true;
            }
        }
    }
    protected void fillgrid()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        da = new DataAccess();
        str = "select a.strexamtype,a.strclass,a.strsubjectname,a.strexampaper,convert(varchar(10),a.dtexamdate,103)as dtexamdate,a.strexamstarttime+'-'+a.strexamendtime as time,a.strinvegilator,b.intid,b.strfirstname+''+b.strmiddlename+''+b.strlastname as name from tblexamschedule a,tblemployee b where a.intschool=" + Session["Schoolid"].ToString() + " and b.intschool=" + Session["Schoolid"].ToString() + " and b.intID=a.strinvegilator and a.intid=" + Request["hid"].ToString();
        ds = da.ExceuteSql(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblexamtype.Text = ds.Tables[0].Rows[0]["strexamtype"].ToString();
            lblstandard.Text = ds.Tables[0].Rows[0]["strclass"].ToString();
            lblsubject.Text = ds.Tables[0].Rows[0]["strsubjectname"].ToString();
            lblexampaper.Text = ds.Tables[0].Rows[0]["strexampaper"].ToString();
            lbldate.Text = ds.Tables[0].Rows[0]["dtexamdate"].ToString();
            lbltime.Text = ds.Tables[0].Rows[0]["time"].ToString();
            lblinvigilator.Text=ds.Tables[0].Rows[0]["name"].ToString();
        }
    }
    protected void view()
    {
        string errmsg = "";
        DataAccess da = new DataAccess();
        DataAccess  da1;
        DataSet ds, ds1;
        string str;
        str = "select strauthorname from tblschoolsyllabus a, tblschooltextbook b where a.inttextbook=b.intid and  strclass='" + lblstandard.Text + "'  and a.strsubject='" + lblsubject.Text + "' and a.intschool=" + Session["SchoolID"].ToString() + "";
        ds = new DataSet();
        ds = da.ExceuteSql(str);
        DataTable dtProducts = new DataTable("table1");
        ds = new DataSet();
        dtProducts = new DataTable("table1");
        dtProducts.Columns.Add("strunitno");
        dtProducts.Columns.Add("unit");
        dtProducts.Columns.Add("ProductID");
        dtProducts.Columns.Add("count");
        DataTable dtProductsDetails = new DataTable("table2");
        dtProductsDetails = new DataTable("table2");
        dtProductsDetails.Columns.Add("ProductID");
        dtProductsDetails.Columns.Add("strunitno");
        dtProductsDetails.Columns.Add("unit");
        dtProductsDetails.Columns.Add("strlessonName");
        dtProductsDetails.Columns.Add("count");
        str = "select strunintno as unit,strunintno,strlessonnames from tblexamschedulelessons where intschool=" + Session["SchoolID"].ToString() + " and intexamid=" + Request["hid"].ToString();
        DataSet dataset = new DataSet();
        dataset = da.ExceuteSql(str);
        if (dataset.Tables[0].Rows.Count > 0)
        {
            lblsetportion.Text = "Syllabus";

            for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)
            {
               
                str = "select a.intid,b.strtextbookname + ' - ' + a.strlessonname as strlesson,c.strunintno from tblschoolsyllabus a,tblschooltextbook b,tblexamschedulelessons c where a.inttextbook=b.intid and a.intid in(" + dataset.Tables[0].Rows[i]["strlessonnames"].ToString() + ") and c.strunintno='" + dataset.Tables[0].Rows[i]["strunintno"].ToString() + "' and c.intexamid=" + Request["hid"].ToString() + " and a.intschool=" + Session["SchoolID"].ToString();
                ds1 = new DataSet();
                da1 = new DataAccess();
                ds1 = da1.ExceuteSql(str);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                    {
                        DataRow drProductsDetails = dtProductsDetails.NewRow();
                        drProductsDetails["ProductID"] = j;
                        drProductsDetails["strlessonname"] = ds1.Tables[0].Rows[j]["strlesson"].ToString();
                        drProductsDetails["strunitno"] = dataset.Tables[0].Rows[i]["strunintno"].ToString();
                        drProductsDetails["unit"] = dataset.Tables[0].Rows[i]["unit"].ToString();
                        if (Session["count"] == null)
                        {
                            drProductsDetails["count"] = j + 1;
                        }
                        else
                        {
                            int l = j;
                            j = int.Parse(Session["count"].ToString());
                            if (Session["c"] == null)
                                drProductsDetails["count"] = j + 1;
                            else
                            {
                                j = int.Parse(Session["c"].ToString());
                                drProductsDetails["count"] = j + 1;
                            }
                            Session["c"] = j + 1;
                            j = l;
                        }
                        dtProductsDetails.Rows.Add(drProductsDetails);

                    }
               }
                if (Session["count"] == null)
                    Session["count"] = dataset.Tables[0].Rows.Count;
                else
                    Session["count"] = int.Parse(Session["count"].ToString()) + ds1.Tables[0].Rows.Count;
                    DataRow drProducts = dtProducts.NewRow();
                    drProducts["ProductID"] = i;
                    drProducts["strunitno"] = dataset.Tables[0].Rows[i]["strunintno"].ToString();
                    drProducts["unit"] = dataset.Tables[0].Rows[i]["unit"].ToString();
                    dtProducts.Rows.Add(drProducts);
                }
            
             }
            else
            {

                if (errmsg == "")
                {
                    errmsg = "No Portion Set For This exam";
                }
                else
                {
                    errmsg = errmsg + " and  No Portion is set for this exam ";
                }
                if (errmsg != "")
                {
                    MsgBox.alert(errmsg);

                }

            }

            ds.Tables.Add(dtProducts);
            ds.Tables.Add(dtProductsDetails);
            ds.Relations.Add("myRelation", ds.Tables["table1"].Columns["strunitno"], ds.Tables["table2"].Columns["strunitno"]);
            dglesson1.DataSource = ds.Tables["table1"];
            dglesson1.DataBind();
            Session["count"] = null;
            Session["c"] = null;
            dglesson1.Visible = true;
            
    }
   
    
    
}
