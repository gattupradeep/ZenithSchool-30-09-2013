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
/// Summary description for DropdownWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
[System.ComponentModel.ToolboxItem(true)]
public class DropdownWebService : System.Web.Services.WebService {
   
    public DropdownWebService () {
        
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
       
        
    }

    [WebMethod(EnableSession = true)]
    public CascadingDropDownNameValue[] BindCountrydropdown(string knownCategoryValues, string category)
    {

        SqlConnection concountry = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        concountry.Open();
        SqlCommand cmdcountry = new SqlCommand("select strstandard from tbldiscipline where intschool='" + Session["SchoolID"] + "' group by strstandard ", concountry);
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
    public CascadingDropDownNameValue[] BindStatedropdown(string knownCategoryValues, string category)
    {
        
        string CountryID;
        StringDictionary countrydetails = AjaxControlToolkit.CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
        CountryID = countrydetails["Country"].ToString();
        SqlConnection constate = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        constate.Open();
        SqlCommand cmdstate = new SqlCommand("select strsection from tbldiscipline where intschool='" + Session["SchoolID"] + "' and strstandard=@CountryID group by strsection", constate);
        cmdstate.Parameters.AddWithValue("@CountryID", CountryID);
        cmdstate.ExecuteNonQuery();
        SqlDataAdapter dastate = new SqlDataAdapter(cmdstate);
        DataSet dsstate = new DataSet();
        dastate.Fill(dsstate);
        constate.Close();
        List<CascadingDropDownNameValue> statedetails = new List<CascadingDropDownNameValue>();
        
        foreach (DataRow dtstaterow in dsstate.Tables[0].Rows)
        {
            string stateID = dtstaterow["strsection"].ToString();
            string statename = dtstaterow["strsection"].ToString();
            statedetails.Add(new CascadingDropDownNameValue(statename, stateID));
        }
        return statedetails.ToArray();
        
        
    }

    [WebMethod(EnableSession = true)]
    public CascadingDropDownNameValue[] BindRegiondropdown(string knownCategoryValues, string category)
    {
        string stateID, country;
        StringDictionary statedetails = AjaxControlToolkit.CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
        //StringDictionary countrydetails = AjaxControlToolkit.CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
        stateID = statedetails["State"].ToString();
        country = statedetails["Country"].ToString();
        SqlConnection conregion = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        conregion.Open();
        SqlCommand cmdregion = new SqlCommand("select distinct a.strfirstname+' '+strmiddlename+' '+strlastname+'-'+convert(varchar(50),introllno) as name,a.intid from tblstudent a,tbldiscipline b where a.intid=b.intstudent and a.intschool='" + Session["SchoolID"] + "' and b.strsection=@stateID and b.strstandard=@country", conregion);
        cmdregion.Parameters.AddWithValue("@stateID", stateID);
        cmdregion.Parameters.AddWithValue("@country", country);
        cmdregion.ExecuteNonQuery();
        SqlDataAdapter daregion = new SqlDataAdapter(cmdregion);
        DataSet dsregion = new DataSet();
        daregion.Fill(dsregion);
        conregion.Close();
        List<CascadingDropDownNameValue> regiondetails = new List<CascadingDropDownNameValue>();
        foreach (DataRow dtregionrow in dsregion.Tables[0].Rows)
        {
            string regionID = dtregionrow["name"].ToString();
            string regionname = dtregionrow["name"].ToString();
            regiondetails.Add(new CascadingDropDownNameValue(regionname, regionID));

        }
        return regiondetails.ToArray();
       
    }
    

   
}

