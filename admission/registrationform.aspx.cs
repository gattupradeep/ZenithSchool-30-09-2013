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

public partial class admission_registrationform : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            year();
            fillddlcountry();
            fillddlstate();
            fillLanguages();
            fillsubject();
            trbrosis.Visible = true;
            trbrother.Visible = false;
            trstaff.Visible = false;
            trgroup.Visible = false;
            ddlcountry.Items.Insert(0, "-Select-");
            standard();
            txtdate.Text = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();
        }
    }
    protected void year()
    {
        int i;
        int j = 0;
        for (i = 2011; i <= DateTime.Today.Year + 10; i++)
        {
            ListItem li;
            li = new ListItem(i.ToString(), i.ToString());
            ddlyear.Items.Insert(j, li);
            j++;
        }
        ddlyear.Items.Insert(0, "Select");
    }
    private void fillddlcountry()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        string sql = "select strcountryname,intcountryID from tblcountry order by strcountryname";
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlcountry.DataSource = ds;
        ddlcountry.DataTextField = "strcountryname";
        ddlcountry.DataValueField = "intcountryID";
        ddlcountry.DataBind();
       
    }
    private void fillddlstate()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        string sql = "select strstate,intstateID from tblstate where intcountryid=" + ddlcountry.SelectedValue + " order by strstate";
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlstate.DataSource = ds;
        ddlstate.DataTextField = "strstate";
        ddlstate.DataValueField = "intstateID";
        ddlstate.DataBind();
        ddlstate.Items.Insert(0, "-Select-");
    }
    protected void fillcity()
    {
        string str;
        DataSet ds;
        DataAccess da = new DataAccess();
        str = "select strcity,intcityID from tblcity where intstateid=" + ddlstate.SelectedValue + " order by strcity";
        da = new DataAccess();
        ds = da.ExceuteSql(str);
        ddlcity.DataSource = ds;
        ddlcity.DataTextField = "strcity";
        ddlcity.DataValueField = "intcityID";
        ddlcity.DataBind();

    }
    protected void fillLanguages()
    {
        string str;
        DataSet ds;
        DataAccess da = new DataAccess();
        str = "select * from tblLanguages";
        da = new DataAccess();
        ds = da.ExceuteSql(str);
        ddlsecondlanguage.DataSource = ds;
        ddlsecondlanguage.DataTextField = "strlanguagename";
        ddlsecondlanguage.DataValueField = "strlanguagename";
        ddlsecondlanguage.DataBind();
        ddlsecondlanguage.Items.Insert(0, "--Select--");

        ddlthirdlanguage.DataSource = ds;
        ddlthirdlanguage.DataTextField = "strlanguagename";
        ddlthirdlanguage.DataValueField = "strlanguagename";
        ddlthirdlanguage.DataBind();
        ddlthirdlanguage.Items.Insert(0, "--Select--");
    }
    protected void standard()
    {
        string str;
        DataSet ds;
        DataAccess da = new DataAccess();
        str = "select * from dbo.tblschoolstandard where intschoolid=" + Session["SchoolID"].ToString();
        da = new DataAccess();
        ds = da.ExceuteSql(str);
        ddlstandard.DataSource = ds;
        ddlstandard.DataTextField = "strstandard";
        ddlstandard.DataValueField = "strstandard";
        ddlstandard.Items.Clear();
        ListItem li;
        for (int i = 0; i <= ds.Tables[0].Rows.Count; i++)
        {
            if (i == 0)
            {
                li = new ListItem("-Select-", i.ToString());
            }
            else
            {
                li = new ListItem(ds.Tables[0].Rows[i - 1]["strstandard"].ToString(), ds.Tables[0].Rows[i - 1]["strstandard"].ToString());
            }
            ddlstandard.Items.Add(li);
        }
      }
    private void fillsubject()
    {
        try
        {
            DataAccess da = new DataAccess();
            string sql = "select * from tblschoolsubject where intschoolid=" + Session["SchoolID"];
            DataSet ds = new DataSet();
            ds = da.ExceuteSql(sql);
            chksubjects.Items.Clear();
            ListItem li;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                li = new ListItem(ds.Tables[0].Rows[i]["strsubject"].ToString(), ds.Tables[0].Rows[i]["strsubject"].ToString());
                chksubjects.Items.Add(li);
            }
        }
        catch { }
    }
    protected string selectedsubject()
    {

        string str = "";

        for (int i = 0; i < chksubjects.Items.Count; i++)
        {
            if (chksubjects.Items[i].Selected == true)
            {
                if (str.Length == 0)
                {
                    str = chksubjects.Items[i].Value.ToString();
                }
                else
                {
                    str = str + "," + chksubjects.Items[i].Value.ToString();
                }
            }
        }
        return str;

    }
    protected void send()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str = "select str_mobile,str_emailid from tblstudentadmission where  intschool=" + Session["SchoolID"].ToString();
        ds = da.ExceuteSql(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            string strUrl = "http://sms1.mmsworld.in/pushsms.php";
            Functions.HttpPost(strUrl, "username=johnirin&password=mmsworld123&sender=SCHOOL&to=" + ds.Tables[0].Rows[0]["str_mobile"].ToString() + "&message= 'Your Apllication form is registered and Your registered number is:="+lbladminid.Text+"' &priority=1");
        }
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        if (lbladminid.Text == "0")
        {
            savedetails();
            if (txtchild.Text != "" && txtadmn.Text != "" && txtclass.Text != "" && txtremarks.Text != "")
                Add();
        }
            dgregistration.Visible = false;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Successfully Saved! and Your Registration Number is:"+lbladminid.Text+"')", true);
            clear();
            send();
    }
    protected void savedetails()
    {
        SqlCommand command;
        SqlParameter outparam;
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        conn.Open();
        command = new SqlCommand("spstudentadmission", conn);
        command.CommandType = CommandType.StoredProcedure;
        outparam = command.Parameters.Add("@ID", SqlDbType.Int);
        outparam.Direction = ParameterDirection.Output;
        command.Parameters.Add("@intid", lbladminid.Text);
        command.Parameters.Add("@str_firstname", txtfirst.Text.Trim());
        command.Parameters.Add("@str_middlename", txtmiddle.Text.Trim());
        command.Parameters.Add("@str_lastname", txtlast.Text.Trim());
        command.Parameters.Add("@str_nationality", txtnationality.Text.Trim());
        command.Parameters.Add("@str_studentbirth", txtstudentbirth.Text.Trim());
        command.Parameters.Add("@str_mothertongue", txtmothertongue.Text.Trim());
        command.Parameters.Add("@str_religion", txtreligion.Text.Trim());
        command.Parameters.Add("@dtdate", txtdate.Text.Trim());
        string gender;
        if (RBfemale.Checked)
            gender = RBfemale.Text;
        else
            gender = RBmale.Text;
        command.Parameters.Add("@str_gender", gender);
        command.Parameters.Add("@str_dateofbirth", txtbirthdate.Text.Trim());
        command.Parameters.Add("@intAge", txtage.Text.Trim());
        if(txtfathername.Text!="")
        {
             command.Parameters.Add("@str_fatherorguardianname", txtfathername.Text.Trim());
        }
        else
        {
             command.Parameters.Add("@str_fatherorguardianname", "");
        }
        if (txtmothername.Text != "")
        {
            command.Parameters.Add("@str_mothername", txtmothername.Text.Trim());
        }
        else
        {
            command.Parameters.Add("@str_mothername","");
        }
        if (txtfatheroccupation.Text != "")
        {
            command.Parameters.Add("@str_fatherorguardianoccupation", txtfatheroccupation.Text.Trim());
        }
        else
        {
            command.Parameters.Add("@str_fatherorguardianoccupation", "");
        }
        if (txtmotheroccupation.Text != "")
        {
            command.Parameters.Add("@str_motheroccupation", txtmotheroccupation.Text.Trim());
        }
        else
        {
            command.Parameters.Add("@str_motheroccupation", "");
        }
        if (txtfatherqualification.Text != "")
        {
            command.Parameters.Add("@str_fatherorguardianqualification", txtfatherqualification.Text.Trim());
        }
        else
        {
            command.Parameters.Add("@str_fatherorguardianqualification","");
        }
        if (txtmotherqualification.Text != "")
        {
            command.Parameters.Add("@str_motherqualification", txtmotherqualification.Text.Trim());
        }
        else
        {
            command.Parameters.Add("@str_motherqualification", "");
        }
        
        command.Parameters.Add("@str_emailid", txtemail.Text.Trim());
        command.Parameters.Add("@str_phone", Txtphone.Text.Trim());
        command.Parameters.Add("@str_mobile", Txtmobile.Text.Trim());
        command.Parameters.Add("@str_hometown", txthometown.Text.Trim());
        command.Parameters.Add("@str_state", ddlstate.SelectedValue);
        command.Parameters.Add("@str_city", ddlcity.SelectedValue);
        command.Parameters.Add("@str_country", ddlcountry.SelectedValue);
        command.Parameters.Add("@str_address", txtpermanent.Text.Trim());
        if (RBno.Checked)
        {
            command.Parameters.Add("@intstaffworking", "");
            command.Parameters.Add("@str_staff1", "");
            command.Parameters.Add("@str_department1", "");
            command.Parameters.Add("@str_designation1", "");
            command.Parameters.Add("@str_relation", "");
        }
        else
        {
            command.Parameters.Add("@intstaffworking", "1");
            command.Parameters.Add("@str_staff1", txtstaff1.Text.Trim());
            command.Parameters.Add("@str_department1", txtdept1.Text.Trim());
            command.Parameters.Add("@str_designation1", txtdesig1.Text.Trim());
            command.Parameters.Add("@str_relation", txtrelation.Text.Trim());
        }
        if (txtpreviousschool1.Text != "")
        {
            command.Parameters.Add("@str_previous_schoolname1", txtpreviousschool1.Text.Trim());
        }
        else
        {
            command.Parameters.Add("@str_previous_schoolname1", "");
        }
        if (txtpreviousschool2.Text != "")
        {
            command.Parameters.Add("@str_previous_schoolname2", txtpreviousschool2.Text.Trim());
        }
        else
        {
            command.Parameters.Add("@str_previous_schoolname2", "");
        }
        if (txtpreviousschool3.Text != "")
        {
            command.Parameters.Add("@str_previous_schoolname3", txtpreviousschool3.Text.Trim());
        }
        else
        {
            command.Parameters.Add("@str_previous_schoolname3", "");
        }
        if (txtpreviousmedium1.Text != "")
        {
            command.Parameters.Add("@str_previous_medium1", txtpreviousmedium1.Text.Trim());
        }
        else
        {
            command.Parameters.Add("@str_previous_medium1", "");
        }
        if (txtpreviousmedium2.Text != "")
        {
            command.Parameters.Add("@str_previous_medium2", txtpreviousmedium2.Text.Trim());
        }
        else
        {
            command.Parameters.Add("@str_previous_medium2", "");
        }
        if (txtpreviousmedium3.Text != "")
        {
            command.Parameters.Add("@str_previous_medium3", txtpreviousmedium3.Text.Trim());
        }
        else
        {
            command.Parameters.Add("@str_previous_medium3", "");
        }
        if (txtpreviousagrr1.Text != "")
        {
            command.Parameters.Add("@str_previous_aggregatemarks1", txtpreviousagrr1.Text.Trim());
        }
        else
        {
            command.Parameters.Add("@str_previous_aggregatemarks1", "");
        }
        if (txtpreviousagrr2.Text != "")
        {
            command.Parameters.Add("@str_previous_aggregatemarks2", txtpreviousagrr2.Text.Trim());
        }
        else
        {
            command.Parameters.Add("@str_previous_aggregatemarks2", "");
        }
        if (txtpreviousagrr3.Text != "")
        {
            command.Parameters.Add("@str_previous_aggregatemarks3", txtpreviousagrr3.Text.Trim());
        }
        else
        {
            command.Parameters.Add("@str_previous_aggregatemarks3", "");
        }
        if (txtpreviousclass1.Text != "")
        {
            command.Parameters.Add("@str_previous_classstudied1", txtpreviousclass1.Text.Trim());
        }
        else
        {
            command.Parameters.Add("@str_previous_classstudied1", "");
        }
        if (txtpreviousclass2.Text != "")
        {
            command.Parameters.Add("@str_previous_classstudied2", txtpreviousclass2.Text.Trim());
        }
        else
        {
            command.Parameters.Add("@str_previous_classstudied2", "");
        }
        if (txtpreviousclass3.Text != "")
        {
            command.Parameters.Add("@str_previous_classstudied3", txtpreviousclass3.Text.Trim());
        }
        else
        {
            command.Parameters.Add("@str_previous_classstudied3", "");
        }
        if (txtsports1.Text != "")
        {
            command.Parameters.Add("@str_sports1", txtsports1.Text.Trim());
        }
        else
        {
            command.Parameters.Add("@str_sports1", "");
        }
        if (txtsports2.Text != "")
        {
            command.Parameters.Add("@str_sports2", txtsports2.Text.Trim());
        }
        else
        {
            command.Parameters.Add("@str_sports2", "");
        }
        if (txtsports3.Text != "")
        {
            command.Parameters.Add("@str_sports3", txtsports3.Text.Trim());
        }
        else
        {
            command.Parameters.Add("@str_sports3", "");
        }
        command.Parameters.Add("@str_specialareas", txtareas.Text.Trim());
        command.Parameters.Add("@str_standard", ddlstandard.SelectedValue);
        if (ddlsecondlanguage.SelectedIndex > 0)
        {
              command.Parameters.Add("@str_second_language", ddlsecondlanguage.SelectedValue);
        }
        else
        {
            command.Parameters.Add("@str_second_language", "");
        }
        if (ddlthirdlanguage.SelectedIndex>0)
        {
            command.Parameters.Add("@str_third_language", ddlthirdlanguage.SelectedValue);
        }
        else
        {
            command.Parameters.Add("@str_third_language", "");
        }
       
        if (chksubjects.SelectedValue != "")
        {
            command.Parameters.Add("@str_subjects", selectedsubject());
        }
        else
        {
            command.Parameters.Add("@str_subjects", "");
        }
        string hostel;
        if (RByes1.Checked)
            hostel = RByes1.Text;
        else
            hostel = RBno1.Text;
        command.Parameters.Add("@str_hostel", hostel);
        string transport;
        if (RBown.Checked)
        {
            transport = RBown.Text;
        }
        else
        {
            if (RBschool.Checked)
                transport = RBschool.Text;
            else
                transport = "No Transport";
        }
        command.Parameters.Add("@str_transport", transport);
        command.Parameters.Add("@intapprove", "0");
        command.Parameters.Add("@intapprovedby", "0");
        command.Parameters.Add("@intwaitlist", "0");
        command.Parameters.Add("@intwaitlistapprovedby", "0");
        command.Parameters.Add("@str_presentclass", txtpresentclass.Text.Trim());
        command.Parameters.Add("@intyear", ddlyear.SelectedValue);
        command.Parameters.Add("@intapplicationno", "");
        command.Parameters.Add("@intadmissionno", "");
        command.Parameters.Add("@intregistrationno","");
        command.Parameters.Add("@intadmissionapprove", "0");
        command.Parameters.Add("@intadmissionapprovedby", "0");
        command.Parameters.Add("@intschool", Session["SchoolID"].ToString());
        command.ExecuteNonQuery();
        if ((int)(command.Parameters["@ID"].Value) > 0)
        {
            int sid = (int)(command.Parameters["@ID"].Value);
            lbladminid.Text = sid.ToString();
        }
        conn.Close();
    }
    protected void clear()
    {
        txtfirst.Text = "";
        txtmiddle.Text = "";
        txtlast.Text = "";
        txtnationality.Text = "";
        txtreligion.Text = "";
        txtmothertongue.Text = "";
        txtstudentbirth.Text = "";
        txtbirthdate.Text = "";
        txtage.Text = "";
        txtfathername.Text = "";
        txtmothername.Text = "";
        txtmotheroccupation.Text = "";
        txtfatheroccupation.Text = "";
        txtfatherqualification.Text = "";
        txtmotherqualification.Text = "";
        txtemail.Text = "";
        Txtphone.Text = "";
        Txtmobile.Text = "";
        txthometown.Text = "";
        txtpermanent.Text = "";
        txtdept1.Text = "";
        txtdesig1.Text = "";
        txtrelation.Text = "";
        txtstaff1.Text = "";
        txtpreviousschool1.Text = "";
        txtpreviousschool2.Text = "";
        txtpreviousschool3.Text = "";
        txtpreviousmedium1.Text = "";
        txtpreviousmedium2.Text = "";
        txtpreviousmedium3.Text = "";
        txtpreviousclass1.Text = "";
        txtpreviousclass2.Text = "";
        txtpreviousclass3.Text = "";
        txtpreviousagrr1.Text = "";
        txtpreviousagrr2.Text = "";
        txtpreviousagrr3.Text = "";
        txtpreviousclass1.Text = "";
        txtpreviousclass2.Text = "";
        txtpreviousclass3.Text = "";
        txtsports1.Text = "";
        txtsports2.Text = "";
        txtsports3.Text = "";
        txtareas.Text = "";
        ddlsecondlanguage.Items.Insert(0, "--Select--");
        ddlthirdlanguage.Items.Insert(0, "--Select--");
        lbladminid.Text = "";
        txtpresentclass.Text = "";
    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        clear();
    }
    protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillddlstate();
        fillcity();
    }
    protected void Add()
    {
         SqlCommand command;
         SqlParameter outparam;
         SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
         conn.Open();
         command = new SqlCommand("spbrothersister", conn);
         command.CommandType = CommandType.StoredProcedure;
         outparam = command.Parameters.Add("@ID", SqlDbType.Int);
         outparam.Direction = ParameterDirection.Output;
         if (btnadd.Text == "Add")
         {
          command.Parameters.Add("@intid", "0");
         }
         else
         {
           command.Parameters.Add("@intid", Session["brosisid"].ToString());
         }
         command.Parameters.Add("@intapplication", lbladminid.Text);
         command.Parameters.Add("@strnameofthechild", txtchild.Text.Trim());
         command.Parameters.Add("@stradmission", txtadmn.Text.Trim());
         command.Parameters.Add("@strclass", txtclass.Text.Trim());
         command.Parameters.Add("@strremarks", txtremarks.Text.Trim());
         command.Parameters.Add("@intschool", Session["SchoolID"].ToString());
         command.ExecuteNonQuery();
         conn.Close();
         clear1();
    }
    protected void clear1()
    {
        txtchild.Text = "";
        txtclass.Text = "";
        txtadmn.Text = "";
        txtremarks.Text = "";
        btnadd.Text = "Add";
    }
    protected void fillgrid()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str = "select * from tblbrothersister where intschool=" + Session["SchoolID"].ToString() + " and intapplication=" + lbladminid.Text;
        ds = da.ExceuteSql(str);
        dgregistration.DataSource = ds;
        dgregistration.DataBind();
    }
    protected void dgregistration_editcommand(object source, DataGridCommandEventArgs e)
    {
        Session["brosisid"] = e.Item.Cells[0].Text;
        txtchild.Text = e.Item.Cells[1].Text;
        txtadmn.Text = e.Item.Cells[2].Text;
        txtclass.Text = e.Item.Cells[3].Text;
        txtremarks.Text = e.Item.Cells[4].Text;
        btnadd.Text = "Update";
    }
    protected void dgregistration_deletecommand(object source, DataGridCommandEventArgs e)
    {
        DataAccess da = new DataAccess();
        string sql = "delete tblbrothersister where intid=" + e.Item.Cells[0].Text;
        da.ExceuteSqlQuery(sql);
        fillgrid();
    }
    protected void txtbirthdate_TextChanged(object sender, EventArgs e)
    {
        string strsql = "select year(getdate()) as gyear,year('"+ txtbirthdate.Text+"') as dobyear, year(getdate())-year('" + txtbirthdate.Text + "') as age,month('" + txtbirthdate.Text + "') as dobmonth,month(getdate()) as gmonth,day('" + txtbirthdate.Text + "') as dobday,day(getdate()) as gday";
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(strsql);
        string gmonth = ds.Tables[0].Rows[0]["gmonth"].ToString();
        string dobmonth = ds.Tables[0].Rows[0]["dobmonth"].ToString();
        string dobday = ds.Tables[0].Rows[0]["dobday"].ToString();
        string gday = ds.Tables[0].Rows[0]["gday"].ToString();
        string z = ds.Tables[0].Rows[0]["age"].ToString();
        int zy = int.Parse(z);
        int gm = int.Parse(gmonth);
        int dm = int.Parse(dobmonth);
        int gd = int.Parse(gday);
        int dd = int.Parse(dobday);
        int gy = int.Parse(ds.Tables[0].Rows[0]["gyear"].ToString());
        int doby = int.Parse(ds.Tables[0].Rows[0]["dobyear"].ToString());
        if (doby < gy)
        {
            if (gm > dm)
            {
                txtage.Text = z.ToString();
            }
            else if (gm == dm)
            {
                if (gd > dd)
                    txtage.Text = z.ToString();
                else
                    txtage.Text = (zy - 1).ToString();
            }
            else
                txtage.Text = (zy - 1).ToString();
        }
        else
        {
            msgbox.alert("Enter the valid year");
        }
    
    }
    protected void btnadd_Click(object sender, EventArgs e)
    {
        if (lbladminid.Text == "0")
        {
            savedetails();
            Add();
        }
        else
        {
            Add();
        }
        fillgrid();
        dgregistration.Visible = true;
    }
    protected void RBno_CheckedChanged(object sender, EventArgs e)
    {
        trstaff.Visible = false;
    }
    protected void RByes_CheckedChanged(object sender, EventArgs e)
    {
        trstaff.Visible = true;
    }
    protected void RBno0_CheckedChanged(object sender, EventArgs e)
    {
        trbrother.Visible = false;
    }
    protected void RByes0_CheckedChanged(object sender, EventArgs e)
    {
        trbrother.Visible = true;
    }
    
    protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillcity();
    }
    
}
