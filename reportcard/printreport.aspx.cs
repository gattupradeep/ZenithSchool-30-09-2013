﻿using System;
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

public partial class reportcard_printreport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["id"] != null)
        {
            if (Request["id"].ToString() == "1")
            {
                string filepath = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "reportcard\\pdffilest\\Secondaryreportcard.pdf";
                Response.ContentType = "Application/pdf";
                Response.WriteFile(filepath);
            }
            if (Request["id"].ToString() == "2")
            {
                string filepath = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "reportcard\\pdffilest\\Primaryreportcard.pdf";
                Response.ContentType = "Application/pdf";
                Response.WriteFile(filepath);
            }
        }
    }
}
