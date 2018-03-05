using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Collections.Generic;
using AjaxControlToolkit;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
public class FeeDrpCascading : System.Web.Services.WebService {

    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    Csfeemenagement ClsFee = new Csfeemenagement();
    public FeeDrpCascading () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    [WebMethod]
    public CascadingDropDownNameValue[] BindModedropdown(string knownCategoryValues, string category)
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("SELECT 'Cash' [Mode] UNION ALL SELECT 'Cheque' [Mode] UNION ALL SELECT 'Visa' [Mode] UNION ALL SELECT 'Master' [Mode] UNION ALL SELECT 'TT' [Mode] UNION ALL SELECT 'Credit Card' [Mode] ", conn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        cmd.ExecuteNonQuery();
        DataSet ds = new DataSet();
        da.Fill(ds);
        conn.Close();
        List<CascadingDropDownNameValue> Modedetails = new List<CascadingDropDownNameValue>();
        foreach (DataRow dtrow in ds.Tables[0].Rows)
        {
            string ModeID = dtrow["Mode"].ToString();
            string ModeName = dtrow["Mode"].ToString();
            Modedetails.Add(new CascadingDropDownNameValue(ModeName, ModeID));
        }
        return Modedetails.ToArray();
    }

    [WebMethod(EnableSession = true)]
    public CascadingDropDownNameValue[] BindYeardropdown(string knownCategoryValues, string category)
    {
        conn.Open();
        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand("DBSP_GET_ACADEMIC_YEAR", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        cmd.Parameters.AddWithValue("@SchoolID", Session["SchoolID"]);
        cmd.ExecuteNonQuery();
        da.Fill(ds);
        conn.Close();
        List<CascadingDropDownNameValue> Modedetails = new List<CascadingDropDownNameValue>();
        foreach (DataRow dtrow in ds.Tables[0].Rows)
        {
            string YearID = dtrow["AcademicYear"].ToString();
            string YearName = dtrow["AcademicYear"].ToString();
            Modedetails.Add(new CascadingDropDownNameValue(YearName, YearID));
        }
        return Modedetails.ToArray();
    }
    [WebMethod(EnableSession = true)]
    public CascadingDropDownNameValue[] BindClassdropdown(string knownCategoryValues, string category)
    {
        string Year = string.Empty;
        StringDictionary Modedetails = AjaxControlToolkit.CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
        //BusinessEntityCollection <Location> locationList = Location.List(Convert.ToInt32(Session["AreaIntKey"].ToString()));
        Year = Modedetails["Year"];
        conn.Open();
        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand("GET_FEE_ASSIGNED_CLASS", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        cmd.Parameters.AddWithValue("@Year", Year);
        cmd.Parameters.AddWithValue("@SchoolID", Session["SchoolID"]);
        cmd.ExecuteNonQuery();
        da.Fill(ds);
        conn.Close();
        List<CascadingDropDownNameValue> Ledgerdetails = new List<CascadingDropDownNameValue>();
        foreach (DataRow dtrow in ds.Tables[0].Rows)
        {
            string StandardID = dtrow["strstandard"].ToString();
            string StandardName = dtrow["strstandard"].ToString();
            Ledgerdetails.Add(new CascadingDropDownNameValue(StandardName, StandardID));
        }
        return Ledgerdetails.ToArray();
    }
    
    [WebMethod(EnableSession = true)]
    public string Class_FeeMode_Year_Class(int Year, string Class)
    {
        try
        {
            conn.Open();
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("DBSP_GET_FEEMODE_FROR_YEAR_CLASS", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@Year", Year);
            cmd.Parameters.AddWithValue("@Class", Class);
            cmd.Parameters.AddWithValue("@SchoolID", Session["SchoolID"]);
            cmd.ExecuteNonQuery();
            da.Fill(ds);
            conn.Close();
            return ds.GetXml();
        }
        catch (SqlException err)
        {
            throw new ApplicationException("Data error=" + err.Message.ToString());
        }
    }

    [WebMethod(EnableSession = true)]
    public int FeeModeID_for_FeeMode(string FeeMode)
    {
        try
        {
            int FeemodeID = 0;
            conn.Open();
            SqlCommand cmd = new SqlCommand("DBSP_GET_FEEMODEID_FOR_FEEMODE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@FeeMode", FeeMode);
            cmd.Parameters.AddWithValue("@SchoolID", Session["SchoolID"]);
            SqlParameter Param = new SqlParameter("@FeemodeID", SqlDbType.Int);
            Param.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(Param);
            cmd.ExecuteNonQuery();
            conn.Close();
            FeemodeID =(int)Param.Value;
            return FeemodeID;
        }
        catch (SqlException err)
        {
            throw new ApplicationException("Data error=" + err.Message.ToString());
        }
    }

    [WebMethod(EnableSession = true)]
    public CascadingDropDownNameValue[] BindStandarddropdown(string knownCategoryValues, string category)
    {
        string Year = string.Empty;
        StringDictionary Modedetails = AjaxControlToolkit.CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
        conn.Open();
        DataSet ds = new DataSet();
        ds = ClsFee.fncFill_Standard();
        List<CascadingDropDownNameValue> Ledgerdetails = new List<CascadingDropDownNameValue>();
        foreach (DataRow dtrow in ds.Tables[0].Rows)
        {
            string StandardID = dtrow["strstandard"].ToString();
            string StandardName = dtrow["strstandard"].ToString();
            Ledgerdetails.Add(new CascadingDropDownNameValue(StandardName, StandardID));
        }
        return Ledgerdetails.ToArray();
    }

    [WebMethod(EnableSession = true)]
    public CascadingDropDownNameValue[] BindSectiondropdown(string knownCategoryValues, string category)
    {
        string Standard = string.Empty;
        StringDictionary Modedetails = AjaxControlToolkit.CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
        Standard = Modedetails["Standard"];
        conn.Open();
        DataSet ds = new DataSet();
        ds = ClsFee.Get_Section_For_Standard(Standard);
        List<CascadingDropDownNameValue> Ledgerdetails = new List<CascadingDropDownNameValue>();
        foreach (DataRow dtrow in ds.Tables[0].Rows)
        {
            string StandardID = dtrow["Section"].ToString();
            string StandardName = dtrow["Section"].ToString();
            Ledgerdetails.Add(new CascadingDropDownNameValue(StandardName, StandardID));
        }
        return Ledgerdetails.ToArray();
    }

    [WebMethod(EnableSession = true)]
    public CascadingDropDownNameValue[] BindStudentdropdown(string knownCategoryValues, string category)
    {
        string Standard = string.Empty;
        string Section = string.Empty;
        StringDictionary Modedetails = AjaxControlToolkit.CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
        Standard = Modedetails["Standard"];
        Section = Modedetails["Section"];
        conn.Open();
        DataSet ds = new DataSet();
        ds = ClsFee.fncFillStudent_For_Section_Standard(Standard,Section);
        List<CascadingDropDownNameValue> Ledgerdetails = new List<CascadingDropDownNameValue>();
        foreach (DataRow dtrow in ds.Tables[0].Rows)
        {
            string StandardID = dtrow["AdmissionNo"].ToString();
            string StandardName = dtrow["Student"].ToString();
            Ledgerdetails.Add(new CascadingDropDownNameValue(StandardName, StandardID));
        }
        return Ledgerdetails.ToArray();
    }
}

