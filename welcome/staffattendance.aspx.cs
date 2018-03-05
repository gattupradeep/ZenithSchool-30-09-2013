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


public partial class welcome_staffattendance : System.Web.UI.Page
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
        string str = "";
        string str2 = "select year('" + DateTime.Now.ToString() + "') as years,month('" + DateTime.Now.ToString() + "') as months,day('" + DateTime.Now.ToString() + "') as day";
        ds2 = da2.ExceuteSql(str2);
        int year = int.Parse(ds2.Tables[0].Rows[0]["years"].ToString());
        int month = int.Parse(ds2.Tables[0].Rows[0]["months"].ToString());
        int day = int.Parse(ds2.Tables[0].Rows[0]["day"].ToString());

        DataTable dtProducts = new DataTable("table1");       
        dtProducts = new DataTable("table1");
        dtProducts.Columns.Add("department");       
        dtProducts.Columns.Add("staffname");
        dtProducts.Columns.Add("leavetype");
        dtProducts.Columns.Add("designation");
        dtProducts.Columns.Add("stafftype");        
        
        DataSet ds, dataset = new DataSet();
        DataAccess da = new DataAccess();
        dataset = new DataSet();       
        str = "select a.intid,b.strdepartmentname,c.strdesignation,a.strfirstname+''+a.strmiddlename+' '+a.strlastname as staffname,a.strtype,";
        str += " '0' as attendance from tblemployee a,tbldepartment b,tbldesignation c where";
        str += " a.intschool='" + Session["schoolID"].ToString() + "'";
        str+=" and a.intDepartment=b.intid and a.intDesignation=c.intid";

        ds = da.ExceuteSql(str);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            DataSet ds1 = new DataSet();
            DataAccess da1 = new DataAccess();
            string sql = "select *, 'c'+ltrim(str(day(dtdate))) as days from tblstaffattendance where";
            sql += " intemployee=" + ds.Tables[0].Rows[i]["intid"].ToString() + " and  intschool='" + Session["schoolID"].ToString() + "' and";
            sql += " month(dtdate)=" + month + " and";
            sql += " year(dtdate)=" + year + "and day(dtdate)=" + day;
            ds1 = da1.ExceuteSql(sql);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                {
                    if (ds1.Tables[0].Rows[j]["strmodeofleave"].ToString() == "Fullday")
                    {
                        DataRow drProducts = dtProducts.NewRow();                            
                        ds.Tables[0].Rows[i]["attendance"] = "A";                            
                        drProducts["leavetype"] = "Fullday";
                        drProducts["staffname"] = ds.Tables[0].Rows[i]["staffname"].ToString();
                        drProducts["designation"] = ds.Tables[0].Rows[i]["strdesignation"].ToString();
                        drProducts["stafftype"] = ds.Tables[0].Rows[i]["strtype"].ToString();
                        drProducts["department"] = ds.Tables[0].Rows[i]["strdepartmentname"].ToString();
                        dtProducts.Rows.Add(drProducts);
                    }
                    else if (ds1.Tables[0].Rows[j]["strmodeofleave"].ToString() == "Halfday")
                    {
                        DataRow drProducts = dtProducts.NewRow();
                        ds.Tables[0].Rows[i]["attendance"] = "A";                            
                        drProducts["leavetype"] = "Fullday";
                        drProducts["staffname"] = ds.Tables[0].Rows[i]["staffname"].ToString();
                        drProducts["designation"] = ds.Tables[0].Rows[i]["strdesignation"].ToString();
                        drProducts["stafftype"] = ds.Tables[0].Rows[i]["strtype"].ToString();
                        drProducts["department"] = ds.Tables[0].Rows[i]["strdepartmentname"].ToString();
                        dtProducts.Rows.Add(drProducts);
                    }
                }
            }
        }         
            int b = 0;
            for (int m = 0; m < ds.Tables[0].Rows.Count; m++)
            {
                if (ds.Tables[0].Rows[m]["attendance"].ToString() == "A")
                {
                    b = b + 1;
                }
            }
            dataset.Tables.Add(dtProducts);
            dgattendance.DataSource = dataset.Tables["table1"];
            dgattendance.DataBind();                
            lbltotalstrength.Text = ds.Tables[0].Rows.Count.ToString();
            lbltoatlabsent.Text = b.ToString();
    }
   
}
