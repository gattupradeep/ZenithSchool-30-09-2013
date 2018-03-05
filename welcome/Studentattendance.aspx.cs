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
using System.IO;
using System.Globalization;

public partial class welcome_Studentattendance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {            
            fillgrd2();
        }
    }   
    protected void fillgrd2()
    {
        DataSet ds2 = new DataSet();
        DataAccess da2 = new DataAccess();        
        string str2 = "select year('" + DateTime.Now.ToString() + "') as years,month('" + DateTime.Now.ToString() + "') as months,day('"+DateTime.Now.ToString()+"') as day";
        ds2 = da2.ExceuteSql(str2);
        int year = int.Parse(ds2.Tables[0].Rows[0]["years"].ToString());
        int month = int.Parse(ds2.Tables[0].Rows[0]["months"].ToString());
        int day = int.Parse(ds2.Tables[0].Rows[0]["day"].ToString());        
        str2 = "select strstandard,strsection,0 as Strength,0 as present,0 as absent  from tblstudent where intschool=" + Session["schoolID"].ToString() + " group by strstandard,strsection";
        DataSet dataset,ds = new DataSet();
        DataAccess da = new DataAccess();
        dataset = new DataSet();
        dataset = da.ExceuteSql(str2);
        for (int k = 0; k < dataset.Tables[0].Rows.Count; k++)
        {            
            da = new DataAccess();
            string str = "select strstandard,strsection,intid,";
            str += " '0' as attendance from tblstudent where";
            str += " intschool=" + Session["schoolID"].ToString()+" and strstandard='"+dataset.Tables[0].Rows[k]["strstandard"].ToString()+"' and strsection='"+dataset.Tables[0].Rows[k]["strsection"].ToString()+"'";
            ds = da.ExceuteSql(str);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataSet ds1 = new DataSet();
                DataAccess da1 = new DataAccess();
                string sql = "select *, 'c'+ltrim(str(day(dtdate))) as days from tblstudentattendance where";
                sql += " intstudent=" + ds.Tables[0].Rows[i]["intid"].ToString() + " and  intschool='" + Session["schoolID"].ToString() + "' and";
                sql += " month(dtdate)=" + month + " and";
                sql += " year(dtdate)=" + year + " and day(dtdate)="+day;
                ds1 = da1.ExceuteSql(sql);
                if (ds1.Tables[0].Rows.Count == 0)
                {
                    ds.Tables[0].Rows[i]["attendance"] = "P";
                }
                for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                {
                    if (ds1.Tables[0].Rows[j]["strsession"].ToString() == "Full Day")
                    {                                            
                        ds.Tables[0].Rows[i]["attendance"] = "A";                        
                    }
                    else
                    {                                
                        ds.Tables[0].Rows[i]["attendance"] ="A" ;
                    }                   
                }

            }
            int a = 0;
            int b = 0;
            for (int m = 0; m < ds.Tables[0].Rows.Count; m++)
            {
                if (ds.Tables[0].Rows[m]["attendance"].ToString() == "P")
                {
                    a = a + 1;
                }
                else
                {
                    b = b + 1;
                }
            }
            dataset.Tables[0].Rows[k]["present"] = a;
            dataset.Tables[0].Rows[k]["absent"] = b;
            dataset.Tables[0].Rows[k]["Strength"] = ds.Tables[0].Rows.Count;
        }
        dgattendance.DataSource = dataset;
        dgattendance.DataBind();
        int present = 0;
        int absent = 0;
        int strength = 0;
        for (int f = 0; f < dataset.Tables[0].Rows.Count; f++)
        {
            strength = strength + int.Parse( dataset.Tables[0].Rows[f]["Strength"].ToString());
            present = present + int.Parse(dataset.Tables[0].Rows[f]["present"].ToString());
            absent = absent + int.Parse(dataset.Tables[0].Rows[f]["absent"].ToString());
        }
        lbltotalstrength.Text = strength.ToString();
        lbltotalpresent.Text = present.ToString();
        lbltoatlabsent.Text = absent.ToString();

    }    
}
