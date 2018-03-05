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

public partial class communication_viewinbox : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["lid"] != null)
            filldetails();
        }
    }
    protected void filldetails()
    {
        DataAccess da = new DataAccess();
        DataSet ds,ds1,ds2 = new DataSet();
        string str = "select * from tblmailbox where intschool=" + Session["SchoolID"].ToString() + " and intid=" + Request["lid"].ToString();
        ds = new DataSet();
        ds = da.ExceuteSql(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblfrom.Text = ds.Tables[0].Rows[0]["strsenderpatrontype"].ToString();
            lblto.Text = ds.Tables[0].Rows[0]["strpatrontype"].ToString();
            
        }
        if (lblfrom.Text == "Students")
        {
            str = "select a.intsenderid,a.strsenderpatrontype,b.strfirstname+' '+b.strmiddlename+' '+b.strlastname as name from tblmailbox a,tblstudent b where b.intid=a.intsenderid and strsenderpatrontype='" + ds.Tables[0].Rows[0]["strsenderpatrontype"].ToString() + "' and a.intid=" + Request["lid"].ToString();
            ds2 = new DataSet();
            ds2 = da.ExceuteSql(str);
            lblfrom.Text = "0";
            lblfrom.Text = ds2.Tables[0].Rows[0]["name"].ToString();
          
        }
        else
        {
            if (lblfrom.Text == "Super Admin")
            {
                str = "select intsenderid,strsenderpatrontype from tblmailbox  where strsenderpatrontype='" + ds.Tables[0].Rows[0]["strsenderpatrontype"].ToString() + "' and intid=" + Request["lid"].ToString();
                ds2 = new DataSet();
                ds2 = da.ExceuteSql(str);
                lblfrom.Text = "0";
                lblfrom.Text = ds2.Tables[0].Rows[0]["strsenderpatrontype"].ToString();
            }
            else
            {
                str = "select a.intsenderid,a.strsenderpatrontype,b.strfirstname+' '+b.strmiddlename+' '+b.strlastname as name from tblmailbox a,tblemployee b where b.intid=a.intsenderid and strsenderpatrontype='" + ds.Tables[0].Rows[0]["strsenderpatrontype"].ToString() + "' and a.intid=" + Request["lid"].ToString();
                ds2 = new DataSet();
                ds2 = da.ExceuteSql(str);
                lblfrom.Text = "0";
                lblfrom.Text = ds2.Tables[0].Rows[0]["name"].ToString();
            }
           
        }
        if (lblto.Text == "Student")
        {
            str = ";WITH Cte AS(SELECT CAST('<M>' + REPLACE( intreceiverid,  ',' , '</M><M>') + '</M>' AS XML) AS Names FROM  dbo.tblmailbox where intid=" + Request["lid"].ToString() + ")SELECT Split.a.value('.', 'VARCHAR(100)') AS Names FROM Cte CROSS APPLY Names.nodes('/M') Split(a)";
            ds2 = new DataSet();
            ds2 = da.ExceuteSql(str);
            lblto.Text = "0";
            for (int j = 0; j < ds2.Tables[0].Rows.Count; j++)
            {
                str = " select a.intreceiverid,a.strpatrontype,b.strfirstname+' '+b.strmiddlename+' '+b.strlastname as name from tblmailbox a,tblstudent b where b.intid=" + ds2.Tables[0].Rows[j]["Names"] + " and strpatrontype='" + ds.Tables[0].Rows[0]["strpatrontype"].ToString() + "' and a.intid=" + Request["lid"].ToString();
                ds1 = new DataSet();
                ds1 = da.ExceuteSql(str);

                if (lblto.Text == "0")
                    lblto.Text = ds1.Tables[0].Rows[0]["name"].ToString();
                else
                    lblto.Text = lblto.Text + ',' + ds1.Tables[0].Rows[0]["name"].ToString();

            }

        }
       else
        {
            str = ";WITH Cte AS(SELECT CAST('<M>' + REPLACE( intreceiverid,  ',' , '</M><M>') + '</M>' AS XML) AS Names FROM  dbo.tblmailbox where intid=" + Request["lid"].ToString() + ")SELECT Split.a.value('.', 'VARCHAR(100)') AS Names FROM Cte CROSS APPLY Names.nodes('/M') Split(a)";
            ds2 = new DataSet();
            ds2 = da.ExceuteSql(str);
            lblto.Text = "0";
            if (lblto.Text == "Super Admin")
            {
                str = "select intreceiverid,strpatrontype from tblmailbox  where strpatrontype='" + ds.Tables[0].Rows[0]["strpatrontype"].ToString() + "' and intid=" + Request["lid"].ToString();
                ds1 = new DataSet();
                ds1 = da.ExceuteSql(str);
                if (lblto.Text == "0")
                    lblto.Text = "Super Admin";
            }
            else
            {
                for (int j = 0; j < ds2.Tables[0].Rows.Count; j++)
                {

                    str = "select a.intreceiverid,a.strpatrontype,b.strfirstname+' '+b.strmiddlename+' '+b.strlastname as name from tblmailbox a,tblemployee b where b.intid=" + ds2.Tables[0].Rows[j]["Names"] + " and strpatrontype='" + ds.Tables[0].Rows[0]["strpatrontype"].ToString() + "' and a.intid=" + Request["lid"].ToString();
                    ds1 = new DataSet();
                    ds1 = da.ExceuteSql(str);

                    if (lblto.Text == "0")
                        lblto.Text = ds1.Tables[0].Rows[0]["name"].ToString();
                    else
                        lblto.Text = lblto.Text + ',' + ds1.Tables[0].Rows[0]["name"].ToString();

                }
            }
            
        }
        lblsubject.Text = ds.Tables[0].Rows[0]["strsubject"].ToString();
        lblmessage.Text = ds.Tables[0].Rows[0]["strmessage"].ToString();
  }
}
