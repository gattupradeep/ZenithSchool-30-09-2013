using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections.Specialized;
using AjaxControlToolkit;
using System.Configuration;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


/// <summary>
/// Summary description for disciplineassign
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
[System.ComponentModel.ToolboxItem(true)]

public class disciplineassign : System.Web.Services.WebService {

    public disciplineassign () {

        //Uncomment the following line if using designed components 
        //InitializeComponent();
      
    }

    [WebMethod(EnableSession=true)]
    public CascadingDropDownNameValue[] BindStandarddropdown(string knownCategoryValues, string category)
    {
        
        SqlConnection concountry = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        concountry.Open();
        SqlCommand cmdcountry = new SqlCommand("select strstandard from tblschoolstandard where intschoolid='" + Session["SchoolID"] + "' group by strstandard", concountry);
        SqlDataAdapter dacountry = new SqlDataAdapter(cmdcountry);
        cmdcountry.ExecuteNonQuery();
        DataSet dscountry = new DataSet();
        dacountry.Fill(dscountry);
        concountry.Close();
        List<CascadingDropDownNameValue> countrydetails = new List<CascadingDropDownNameValue>();
        foreach (DataRow dtrow in dscountry.Tables[0].Rows)
        {
            string CountryID = dtrow["strstandard"].ToString();
            string CountryName = dtrow["strstandard"].ToString();

            //countrydetails.Add(new CascadingDropDownNameValue("All", "All"));
            countrydetails.Add(new CascadingDropDownNameValue(CountryName, CountryID));
        }
        return countrydetails.ToArray();
    }

    [WebMethod(EnableSession = true)]
    public CascadingDropDownNameValue[] BindSectionropdown(string knownCategoryValues, string category)
    {

        string StandardID;
        string sectionID = "";
        StringDictionary countrydetails = AjaxControlToolkit.CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
        StandardID = countrydetails["Standard"].ToString();
        SqlConnection constate = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        constate.Open();
        SqlCommand cmdstate = new SqlCommand("select strsection from tblstandard_section_subject where intschoolid='" + Session["SchoolID"] + "' and strstandard=@StandardID group by strsection", constate);
        cmdstate.Parameters.AddWithValue("@StandardID", StandardID);
        cmdstate.ExecuteNonQuery();
        SqlDataAdapter dastate = new SqlDataAdapter(cmdstate);
        DataSet dsstate = new DataSet();
        dastate.Fill(dsstate);
        constate.Close();
        List<CascadingDropDownNameValue> statedetails = new List<CascadingDropDownNameValue>();

        foreach (DataRow dtstaterow in dsstate.Tables[0].Rows)
        {
             sectionID = dtstaterow["strsection"].ToString();
            string sectionname = dtstaterow["strsection"].ToString();
            statedetails.Add(new CascadingDropDownNameValue(sectionname, sectionID));
        }
        return statedetails.ToArray();


    }

    [WebMethod(EnableSession = true)]
    public CascadingDropDownNameValue[] BindStudentdropdown(string knownCategoryValues, string category)
    {
        string sectionID, Standard;
        StringDictionary statedetails = AjaxControlToolkit.CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
        //StringDictionary countrydetails = AjaxControlToolkit.CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
        sectionID = statedetails["Section"].ToString();
        Standard = statedetails["Standard"].ToString();
        SqlConnection conregion = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        conregion.Open();
        SqlCommand cmdregion = new SqlCommand("select distinct strfirstname+' '+strmiddlename+' '+strlastname+'-'+convert(varchar(50),introllno) as name,intid from tblstudent where intschool='" + Session["SchoolID"] + "' and strsection=@sectionID and strstandard=@Standard", conregion);
        cmdregion.Parameters.AddWithValue("@sectionID", sectionID);
        cmdregion.Parameters.AddWithValue("@Standard", Standard);
        cmdregion.ExecuteNonQuery();
        SqlDataAdapter daregion = new SqlDataAdapter(cmdregion);
        DataSet dsregion = new DataSet();
        daregion.Fill(dsregion);
        conregion.Close();
        List<CascadingDropDownNameValue> regiondetails = new List<CascadingDropDownNameValue>();
        foreach (DataRow dtregionrow in dsregion.Tables[0].Rows)
        {
            string regionID = dtregionrow["intid"].ToString();
            string regionname = dtregionrow["name"].ToString();
            regiondetails.Add(new CascadingDropDownNameValue(regionname, regionID));

        }
        return regiondetails.ToArray();
        

    }
    
    
}

