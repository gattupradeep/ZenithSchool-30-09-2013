using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

[WebService]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

[System.Web.Script.Services.ScriptService]
public class autofillforleavecategory : System.Web.Services.WebService
{
    public SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public autofillforleavecategory()
    {

    }

    [WebMethod(EnableSession = true)]
    public string[] GetCompletionList1(string prefixText, int count)
    {
        DataSet ds = new DataSet();
        
        string sql = "select strfirstname+' '+strmiddlename+' '+strlastname as Name from";
        sql += " tblemployee where intschool="+Session["SchoolID"].ToString()+" and strfirstname+''+strmiddlename+' '+strlastname like '" + prefixText + "%'";
        SqlDataAdapter da = new SqlDataAdapter(sql,cn);
        da.Fill(ds);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];

        List<string> txtItems = new List<string>();
        String dbValues;

        foreach (DataRow row in dt.Rows)
        {
            dbValues = row["Name"].ToString();
            dbValues = dbValues.ToLower();
            txtItems.Add(dbValues);
        }

        return txtItems.ToArray();
    }
    public string[] GetCompletionList2(string prefixText, int count)
    {
        DataSet ds = new DataSet();

        string sql = "select b.strleavecategory from tblassignstaffleave a,tblleavecategory b where b.intID=a.intleavecategory ";  
        sql += " and a.intschool="+Session["SchoolID"].ToString()+" group by b.strleavecategory like '" + prefixText + "%'";
        SqlDataAdapter da = new SqlDataAdapter(sql, cn);
        da.Fill(ds);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];

        List<string> txtItems = new List<string>();
        String dbValues;

        foreach (DataRow row in dt.Rows)
        {
            dbValues = row["strleavecategory"].ToString();
            dbValues = dbValues.ToLower();
            txtItems.Add(dbValues);
        }

        return txtItems.ToArray();
    }

}


