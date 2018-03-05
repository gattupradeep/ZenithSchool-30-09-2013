using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{
    public WebService()
    {
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    //[System.Web.Services.WebMethod]
    public List<string> Getstudentname(string prefixText, string contextKey)
    {
        string query;
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        conn.Open();
        if (contextKey == "--Select--" || contextKey == "All")
        {
            query = "select top 10 strfirstname+' '+strmiddlename+' '+strlastname as name from tblstudent where strfirstname+' '+strmiddlename+' '+strlastname like '%" + prefixText + "%' ";
        }
        else
        {
            query = "select top 10 strfirstname+' '+strmiddlename+' '+strlastname as name from tblstudent where strfirstname+' '+strmiddlename+' '+strlastname like '%" + prefixText + "%' and strstandard + ' - ' + strsection='" + contextKey + "'";
        }
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(query);
        List<string> studentname = new List<string>();
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            studentname.Add(ds.Tables[0].Rows[i][0].ToString());
        }
        return studentname;
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public List<string> GetAdmissionNo(string prefixText, string contextKey)
    {
        string query;
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        conn.Open();
        if (contextKey == "--Select--" || contextKey == "All")
        {
            query = "select top 10 intadmitno from tblstudent where intadmitno like '%" + prefixText + "%' ";
        }
        else
        {
            query = "select top 10 intadmitno from tblstudent where intadmitno like '%" + prefixText + "%' and strstandard + ' - ' + strsection='" + contextKey + "'";
        }
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(query);
        List<string> admissionnno = new List<string>();

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            admissionnno.Add(ds.Tables[0].Rows[i][0].ToString());
        }
        return admissionnno;
    }
}
