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

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

[System.Web.Script.Services.ScriptService]
public class AutoCompletename : System.Web.Services.WebService
{
    public SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    public AutoCompletename()
    {

    }

    [WebMethod(EnableSession = true)]
    public string[] GetCompletionList1(string prefixText, int count)
    {
        DataSet ds = new DataSet();
        
        string sql = "select CONVERT(varchar(50),intadmitno)+' - '+strfirstname+''+strmiddlename+''+strlastname as admnoName from";
        sql += " tblstudent where intschool="+Session["SchoolID"].ToString()+" and intadmitno like '"+prefixText+"'";
        SqlDataAdapter da = new SqlDataAdapter(sql,cn);
        da.Fill(ds);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];

        List<string> txtItems = new List<string>();
        String dbValues;

        foreach (DataRow row in dt.Rows)
        {
            dbValues = row["admnoName"].ToString();
            dbValues = dbValues.ToLower();
            txtItems.Add(dbValues);
        }

        return txtItems.ToArray();
    }

}

