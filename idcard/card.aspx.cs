using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Drawing.Imaging;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Net;


public partial class idcard_card : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["id"] != null)
            {

                if (Request["id"].ToString() == "1")
                {
                    print();
                }

            }
        }
    }
    protected void print()
    {

        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str;

        str = "select a.intid,a.strfirstname+''+a.strmiddlename+''+a.strlastname as name,a.strstandard+' - '+a.strsection as standard,a.intadmitno,";
        str += " convert(varchar(10),b.StartDate,103) as year, CONVERT(varchar(10),b.EndDate,103) as year1 from tblAcademicYear b,tblstudent a";
        str += " where b.intactive=1 and a.intschool=" + Session["Schoolid"].ToString();
       
        ds = da.ExceuteSql(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string filePath = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "idcard\\card\\"+ds.Tables[0].Rows[i]["intid"].ToString()+".jpg";
                //Response.AppendHeader("content-disposition", "attachment;filename=" + ds.Tables[0].Rows[i]["intid"].ToString()+".jpg");
                
                Response.ContentType = "image/jpeg";
                //Response.WriteFile(filePath);
                Response.Flush();
                Response.Close();
            }
        }
    }
}
