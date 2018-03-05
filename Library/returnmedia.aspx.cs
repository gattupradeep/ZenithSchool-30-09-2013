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

public partial class Library_returnmedia : System.Web.UI.Page
{
    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public SqlCommand cmd;
    public string strsql;
    public DataAccess da;
    public DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Txtbarcode.Text == "")
        {
            MsgBox1.alert("Please enter Barcode");
        }
        else
        {
            strsql = "select * from (select a.intschool,a.intid, strpatrontype,strname,intbarcode,strtitle,";
            strsql += " convert(varchar(10),dtdateofissue,103) as dtdateofissue1, dtdateofissue, convert(varchar(10)";
            strsql += " ,dtdateofissue+b.intnoofdays,103) as expirydate, ";
            strsql += " (datediff(day,(dtdateofissue+b.intnoofdays),getdate())) as execess,b.intid as intid1,b.intnoofrenewals as noofrenewals, 0 as fine";
            strsql += " from tblissueamedia a, tblreturndate b where a.strpatrontype=b.strpatron and a.strdepartment=b.intdepartment and ";
            strsql += " a.strdesignation=b.intdesignation and a.intmediatype=b.intmediatype and a.intmediacategory=b.intmediacategory and a.intreturn=1 and a.strpatrontype='Employee' ";
            strsql += " union all";
            strsql += " select a.intschool,a.intid, strpatrontype,strname,intbarcode,strtitle,";
            strsql += " convert(varchar(10),dtdateofissue,103) as dtdateofissue1, dtdateofissue,";
            strsql += " convert(varchar(10),dtdateofissue+b.intnoofdays,103) as expirydate, ";
            strsql += " (datediff(day,(dtdateofissue+b.intnoofdays),getdate())) as execess,b.intid as intid1,b.intnoofrenewals as noofrenewals, 0 as fine ";
            strsql += " from tblissueamedia a, tblreturndate b where a.strpatrontype=b.strpatron and a.strstandard=b.strstandard and a.intmediatype=b.intmediatype and a.intmediacategory=b.intmediacategory and intreturn=1 and ";
            strsql += " a.strpatrontype='Student') as a  where intschool="+Session["SchoolId"].ToString()+" and intbarcode='" + Txtbarcode.Text + "'";
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            ds = da.ExceuteSql(strsql);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                strsql = "select top 1 intissueid,convert(varchar(10),dtrenewdate,103) as dtrenewdate from tblrenewmedia where intissueid = '" + ds.Tables[0].Rows[i]["intid"].ToString() + "' order by intissueid desc";
                da = new DataAccess();
                DataSet dsm = new DataSet();
                dsm = da.ExceuteSql(strsql);
                if(dsm.Tables[0].Rows.Count > 0)
                {
                    ds.Tables[0].Rows[i]["dtdateofissue1"] = dsm.Tables[0].Rows[0]["dtrenewdate"].ToString();
                    ds.Tables[0].Rows[i]["dtdateofissue"] = dsm.Tables[0].Rows[0]["dtrenewdate"].ToString();
                }
                strsql = "select * from tblreturndate where intid=" + ds.Tables[0].Rows[i]["intid1"].ToString();
                da = new DataAccess();
                DataSet ds1 = new DataSet();
                ds1 = da.ExceuteSql(strsql);
                double dbfine = 0;
                int noofdays = int.Parse(ds.Tables[0].Rows[i]["execess"].ToString());
                if (noofdays > 0)
                {
                    if (ds1.Tables[0].Rows.Count > 0)
                    {

                        if (ds1.Tables[0].Rows[0]["intupto4"].ToString() != "0" && int.Parse(ds.Tables[0].Rows[i]["execess"].ToString()) > int.Parse(ds1.Tables[0].Rows[0]["intupto4"].ToString()))
                        {
                            dbfine = double.Parse(ds1.Tables[0].Rows[0]["intfineperday"].ToString());
                            //noofdays = int.Parse(ds1.Tables[0].Rows[0]["intupto4"].ToString()) - noofdays;
                        }

                        if (dbfine == 0)
                        {
                            if (ds1.Tables[0].Rows[0]["intupto4"].ToString() != "0" && int.Parse(ds.Tables[0].Rows[i]["execess"].ToString()) > int.Parse(ds1.Tables[0].Rows[0]["intupto3"].ToString()))
                            {
                                dbfine = double.Parse(ds1.Tables[0].Rows[0]["intfine4"].ToString());
                                noofdays = int.Parse(ds1.Tables[0].Rows[0]["intupto4"].ToString()) - noofdays;
                            }
                            if (ds1.Tables[0].Rows[0]["intupto4"].ToString() != "0" && int.Parse(ds.Tables[0].Rows[i]["execess"].ToString()) > int.Parse(ds1.Tables[0].Rows[0]["intupto3"].ToString()) && int.Parse(ds.Tables[0].Rows[i]["execess"].ToString()) <= int.Parse(ds1.Tables[0].Rows[0]["intupto4"].ToString()))
                            {
                                dbfine = double.Parse(ds1.Tables[0].Rows[0]["intfine4"].ToString());
                                noofdays = 0;
                            }
                        }

                        if (dbfine == 0)
                        {
                            if (ds1.Tables[0].Rows[0]["intupto3"].ToString() != "0" && int.Parse(ds.Tables[0].Rows[i]["execess"].ToString()) > int.Parse(ds1.Tables[0].Rows[0]["intupto2"].ToString()))
                            {
                                dbfine = double.Parse(ds1.Tables[0].Rows[0]["intfine3"].ToString());
                                noofdays = int.Parse(ds1.Tables[0].Rows[0]["intupto3"].ToString()) - noofdays;
                            }
                            if (ds1.Tables[0].Rows[0]["intupto3"].ToString() != "0" && int.Parse(ds.Tables[0].Rows[i]["execess"].ToString()) > int.Parse(ds1.Tables[0].Rows[0]["intupto2"].ToString()) && int.Parse(ds.Tables[0].Rows[i]["execess"].ToString()) <= int.Parse(ds1.Tables[0].Rows[0]["intupto3"].ToString()))
                            {
                                dbfine = double.Parse(ds1.Tables[0].Rows[0]["intfine3"].ToString());
                                noofdays = 0;
                            }
                        }

                        if (dbfine == 0)
                        {
                            if (ds1.Tables[0].Rows[0]["intupto2"].ToString() != "0" && int.Parse(ds.Tables[0].Rows[i]["execess"].ToString()) > int.Parse(ds1.Tables[0].Rows[0]["intupto1"].ToString()))
                            {
                                dbfine = double.Parse(ds1.Tables[0].Rows[0]["intfine2"].ToString());
                                noofdays = int.Parse(ds1.Tables[0].Rows[0]["intupto2"].ToString()) - noofdays;
                            }
                            if (ds1.Tables[0].Rows[0]["intupto2"].ToString() != "0" && int.Parse(ds.Tables[0].Rows[i]["execess"].ToString()) > int.Parse(ds1.Tables[0].Rows[0]["intupto1"].ToString()) && int.Parse(ds.Tables[0].Rows[i]["execess"].ToString()) <= int.Parse(ds1.Tables[0].Rows[0]["intupto2"].ToString()))
                            {
                                dbfine = double.Parse(ds1.Tables[0].Rows[0]["intfine2"].ToString());
                                noofdays = 0;
                            }
                        }

                        if (dbfine == 0)
                        {
                            if (ds1.Tables[0].Rows[0]["intupto1"].ToString() != "0" && int.Parse(ds.Tables[0].Rows[i]["execess"].ToString()) > int.Parse(ds1.Tables[0].Rows[0]["intupto1"].ToString()))
                            {
                                dbfine = double.Parse(ds1.Tables[0].Rows[0]["intfine1"].ToString());
                                noofdays = int.Parse(ds1.Tables[0].Rows[0]["intupto1"].ToString()) - noofdays;
                            }
                            if (ds1.Tables[0].Rows[0]["intupto1"].ToString() != "0" && int.Parse(ds.Tables[0].Rows[i]["execess"].ToString()) <= int.Parse(ds1.Tables[0].Rows[0]["intupto1"].ToString()))
                            {
                                dbfine = double.Parse(ds1.Tables[0].Rows[0]["intfine1"].ToString());
                                noofdays = 0;
                            }
                        }

                        if (noofdays < 0)
                        {
                            dbfine = 0;
                            noofdays = 0;
                            ds.Tables[0].Rows[i]["execess"] = 0;
                        }

                        if (ds1.Tables[0].Rows[0]["intupto4"].ToString() != "0" && int.Parse(ds.Tables[0].Rows[i]["execess"].ToString()) > int.Parse(ds1.Tables[0].Rows[0]["intupto4"].ToString()))
                        {
                            dbfine = noofdays * double.Parse(ds1.Tables[0].Rows[0]["intfineperday"].ToString());
                        }
                        else
                        {
                            dbfine = dbfine + (noofdays * double.Parse(ds1.Tables[0].Rows[0]["intfineperday"].ToString()));
                        }
                    }
                    ds.Tables[0].Rows[i]["fine"] = dbfine;
                }
                else
                {
                    ds.Tables[0].Rows[i]["fine"] = dbfine;
                    ds.Tables[0].Rows[i]["execess"] = 0;
                }
            }
            dgreturnmedia.DataSource = ds;
            dgreturnmedia.DataBind();
        }
    }
    protected void dgreturnmedia_EditCommand(object source, DataGridCommandEventArgs e)
    {
        Session["return"] = e.Item.Cells[1].Text;
        DateTime currentdate = DateTime.Now;
        DataAccess da = new DataAccess();
        string sql = "update tblissueamedia set intreturn =0,dtreturndate='" + currentdate + "' where intschool='" + Session["SchoolID"].ToString() + "' and intid='" + Session["return"] + "'";
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
    }
    protected void dgreturnmedia_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        DateTime currentdate = DateTime.Now;
        Session["renew"] = e.Item.Cells[1].Text;
        int noofrenewals = int.Parse(e.Item.Cells[11].Text);
        if(noofrenewals > 1)
        {
            MsgBox1.alert("You can not renew, Please return the media");
        }
        else
        {
            DataAccess da = new DataAccess();
            string sql = "select * from tblrenewmedia where intissueid = '" + Session["renew"] + "'";
            DataSet ds2 = new DataSet();
            ds2 = da.ExceuteSql(sql);
            if (ds2.Tables[0].Rows.Count > noofrenewals)
            {
                MsgBox1.alert("Oops! You can not renew ");
            }
            else
            {
                da = new DataAccess();
                string strsql = "insert into tblrenewmedia (intissueid,dtrenewdate) values('" + Session["renew"] + "' , '" + currentdate + "')";
                DataSet ds1 = new DataSet();
                ds1 = da.ExceuteSql(strsql);
            }
        }
    }
}
