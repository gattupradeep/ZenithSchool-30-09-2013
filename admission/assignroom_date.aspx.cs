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

public partial class admission_assignroom_date : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillstandard();
            fillgrid();
            buildname();
            fillfloor();
            fillroomno();
            staff();
            labelcount.Text = "0";
            lblallocated.Text = "0";
            trlabel.Visible = false;
            trbuildingname.Visible = false;
            trroomnumber.Visible = false;
            trroomcapacity.Visible = false;
            seats.Visible = false;
            dgadmissioninterview.Columns[3].Visible = false;
            dgadmissioninterview.Columns[4].Visible = false;
            dgadmissioninterview.Columns[5].Visible = false;
        }
    }
    protected void fillstandard()
    {
        try
        {
            if (ddlapproval.SelectedValue == "1")
            {
                DataAccess da = new DataAccess();
                string sql = "select max(intid) as appid,str_standard from tblstudentadmission  where intapprove=1 and intschool=" + Session["SchoolID"] + " group by str_standard";
                DataSet ds = new DataSet();
                ds = da.ExceuteSql(sql);
                chkstandard.Items.Clear();
                ListItem li;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    da = new DataAccess();
                    sql = "select max(inttoappl) as appid,strstandard from tbladmissioninterview where strstandard='" + ds.Tables[0].Rows[i]["str_standard"].ToString() + "' and intschool=" + Session["SchoolID"].ToString() + " group by strstandard";
                    DataSet ds1 = new DataSet();
                    ds1 = da.ExceuteSql(sql);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        if (int.Parse(ds.Tables[0].Rows[i]["appid"].ToString()) > int.Parse(ds1.Tables[0].Rows[0]["appid"].ToString()))
                        {
                            li = new ListItem(ds.Tables[0].Rows[i]["str_standard"].ToString(), ds.Tables[0].Rows[i]["str_standard"].ToString());
                            chkstandard.Items.Add(li);
                        }
                    }
                    else
                    {
                        li = new ListItem(ds.Tables[0].Rows[i]["str_standard"].ToString(), ds.Tables[0].Rows[i]["str_standard"].ToString());
                        chkstandard.Items.Add(li);
                    }
                }
            }
        
            if(ddlapproval.SelectedValue=="2")
            {
                DataAccess da = new DataAccess();
                string sql = "select max(intid) as appid,str_standard from tblstudentadmission  where intwaitlist=1 and intschool=" + Session["SchoolID"] + " group by str_standard";
                DataSet ds = new DataSet();
                ds = da.ExceuteSql(sql);
                chkstandard.Items.Clear();
                ListItem li;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    da = new DataAccess();
                    sql = "select max(inttoappl) as appid,strstandard from tbladmissioninterview where strstandard='" + ds.Tables[0].Rows[i]["str_standard"].ToString() + "' and intschool=" + Session["SchoolID"].ToString() + " group by strstandard";
                    DataSet ds1 = new DataSet();
                    ds1 = da.ExceuteSql(sql);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        if (int.Parse(ds.Tables[0].Rows[i]["appid"].ToString()) > int.Parse(ds1.Tables[0].Rows[0]["appid"].ToString()))
                        {
                            li = new ListItem(ds.Tables[0].Rows[i]["str_standard"].ToString(), ds.Tables[0].Rows[i]["str_standard"].ToString());
                            chkstandard.Items.Add(li);
                        }
                    }
                    else
                    {
                        li = new ListItem(ds.Tables[0].Rows[i]["str_standard"].ToString(), ds.Tables[0].Rows[i]["str_standard"].ToString());
                        chkstandard.Items.Add(li);
                    }
                }
            }
         }
        catch { }
    }
    protected string selectedstandard()
    {
        
            string str = "";
           
            for (int i = 0; i < chkstandard.Items.Count; i++)
            {
                if (chkstandard.Items[i].Selected == true)
                {
                    if (str.Length == 0)
                    {
                        str = chkstandard.Items[i].Value.ToString();
                    }
                    else
                    {
                        str = str + "," + chkstandard.Items[i].Value.ToString();
                    }
                }
            }
            return str;
    }

    protected void Editstandard()
    {
        try
        {
            DataAccess da = new DataAccess();
            string sql = "select strstandard from tbladmissioninterview where intid=" + lblhid.Text + " and intschool=" + Session["SchoolID"]+" group by strstandard";
            DataSet ds = new DataSet();
            ds = da.ExceuteSql(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                chkstandard.Items.Clear();
                ListItem li;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    li = new ListItem(ds.Tables[0].Rows[i]["strstandard"].ToString(), ds.Tables[0].Rows[i]["strstandard"].ToString());
                    chkstandard.Items.Add(li);
                }
                selectedstandard();
            }
        }
        catch { }
    }

   protected void buildname()
    {
        if (ddlapproval.SelectedValue == "1")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select * from tblbuilding where intschool=" + Session["SchoolID"].ToString();
            ds = da.ExceuteSql(str);
            ddlbuildname.DataSource = ds;
            ddlbuildname.DataTextField = "strbuildname";
            ddlbuildname.DataValueField = "intid";
            ddlbuildname.DataBind();
            ddlbuildname.Items.Insert(0, "-Select-");
        }
        if (ddlapproval.SelectedValue == "2")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "select * from tblbuilding where intschool=" + Session["SchoolID"].ToString();
            ds = da.ExceuteSql(str);
            ddlbuildname.DataSource = ds;
            ddlbuildname.DataTextField = "strbuildname";
            ddlbuildname.DataValueField = "intid";
            ddlbuildname.DataBind();
            ddlbuildname.Items.Insert(0, "-Select-");
        }
    }
   protected void fillfloor()
   {
       if (ddlapproval.SelectedValue == "1")
       {
           DataAccess da = new DataAccess();
           DataSet ds = new DataSet();
           string str = "select strfloor from tblroomcapacity  where intbuildname='" + ddlbuildname.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + " group by strfloor";
           ds = da.ExceuteSql(str);
           ddlfloor.DataTextField = "strfloor";
           ddlfloor.DataValueField = "strfloor";
           ddlfloor.DataSource = ds;
           ddlfloor.DataBind();
           ddlfloor.Items.Insert(0, "-Select-");
       }
       if (ddlapproval.SelectedValue == "2")
       {
           DataAccess da = new DataAccess();
           DataSet ds = new DataSet();
           string str = "select strfloor from tblroomcapacity  where intbuildname='" + ddlbuildname.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + " group by strfloor";
           ds = da.ExceuteSql(str);
           ddlfloor.DataTextField = "strfloor";
           ddlfloor.DataValueField = "strfloor";
           ddlfloor.DataSource = ds;
           ddlfloor.DataBind();
           ddlfloor.Items.Insert(0, "-Select-");

       }
   }
   protected void fillroomno()
   {
       if (ddlapproval.SelectedValue == "1")
       {
           DataAccess da = new DataAccess();
           DataSet ds = new DataSet();
           string str = "select strroomno from tblroomcapacity  where  strfloor='" + ddlfloor.SelectedValue + "' and intbuildname='" + ddlbuildname.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + " group by strroomno";
           ds = da.ExceuteSql(str);
           ddlroomno.DataTextField = "strroomno";
           ddlroomno.DataValueField = "strroomno";
           ddlroomno.DataSource = ds;
           ddlroomno.DataBind();
           ddlroomno.Items.Insert(0, "-Select-");
       }
       if (ddlapproval.SelectedValue == "2")
       {
           DataAccess da = new DataAccess();
           DataSet ds = new DataSet();
           string str = "select strroomno from tblroomcapacity  where  strfloor='" + ddlfloor.SelectedValue + "' and intbuildname='" + ddlbuildname.SelectedValue + "' and intschool=" + Session["SchoolID"].ToString() + " group by strroomno";
           ds = da.ExceuteSql(str);
           ddlroomno.DataTextField = "strroomno";
           ddlroomno.DataValueField = "strroomno";
           ddlroomno.DataSource = ds;
           ddlroomno.DataBind();
           ddlroomno.Items.Insert(0, "-Select-");
       }
   }
    protected void fillroomname()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str = "select a.strclass+' - '+a.strsection as roomname,a.strroomno,a.strcapacity,a.strfloor,b.strbuildname from tblroomcapacity a, tblbuilding b where a.intbuildname=b.intid and a.intbuildname='"+ddlbuildname.SelectedValue+"' and a.strfloor='" + ddlfloor.SelectedValue + "' and a.strroomno=" + ddlroomno.SelectedValue + " and a.intschool=" + Session["SchoolID"].ToString() + " and a.strclass !=''";
        str += " union  all ";
        str += " select a.strother as roomname,a.strroomno,a.strcapacity,a.strfloor,b.strbuildname from tblroomcapacity a, tblbuilding b where a.intbuildname=b.intid and a.intbuildname='" + ddlbuildname.SelectedValue + "' and a.strfloor='" + ddlfloor.SelectedValue + "' and a.strroomno=" + ddlroomno.SelectedValue + " and a.intschool=" + Session["SchoolID"].ToString() + " and a.strother!='' ";
        ds = da.ExceuteSql(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblroomname.Text = ds.Tables[0].Rows[0]["roomname"].ToString();
            lblroomcapacity.Text = ds.Tables[0].Rows[0]["strcapacity"].ToString();
        }
    }
    protected void staff()
    {
        DataAccess da = new DataAccess();
        DataSet ds = new DataSet();
        string str = "select intid,strfirstname+''+strmiddlename+''+strlastname as name from tblemployee where intschool=" + Session["SchoolID"].ToString();
        ds = da.ExceuteSql(str);
        ddlstaff.DataTextField = "name";
        ddlstaff.DataValueField = "intid";
        ddlstaff.DataSource = ds;
        ddlstaff.DataBind();
        ddlstaff.Items.Insert(0, "-Select-");
    }
    protected void save()
    {
        if (ddlapproval.SelectedValue == "1")
        {
            
            DataAccess da = new DataAccess();
            string str;
            DataSet ds = new DataSet();
            da = new DataAccess();
            ds = new DataSet();
            if (lblallocated.Text != "0")
            {
                str = "select MIN(a.intid)as fromappl,MAX(a.intid) as toappl from tblstudentadmission a,tbladmissioninterview b where a.str_standard in('" + selectedstandard().Replace(",", "','") + "') and a.intapprove=1 and  a.str_standard=b.strstandard and a.intid>b.inttoappl and a.intschool=" + Session["SchoolID"].ToString();
                ds = da.ExceuteSql(str);
                for (int i = 0; i < chkstandard.Items.Count; i++)
                {
                    if (chkstandard.Items[i].Selected == true)
                    {
                        str = "insert into tbladmissioninterview(dtdate,dttime,strcontactperson,strstandard,strremarks,strbuildingname,strfloor,introomno,strroomname,introomcapacity,intfromappl,inttoappl,intstaff,intschool,intapprove_waitlist)values('" + txtdate.Text + "','" + txttime.Text + "','" + txtcontact.Text + "','" + chkstandard.Items[i].Text + "','" + txtremarks.Text + "','" + ddlbuildname.SelectedValue + "','" + ddlfloor.SelectedValue + "','" + ddlroomno.SelectedValue + "','" + lblroomname.Text + "','" + lblroomcapacity.Text + "','" + ds.Tables[0].Rows[0]["fromappl"].ToString() + "','" + ds.Tables[0].Rows[0]["toappl"].ToString() + "','" + ddlstaff.SelectedValue + "'," + Session["SchoolID"].ToString() + "," + ddlapproval.SelectedValue + ")";
                        ds = da.ExceuteSql(str);
                    }
                }
            }
            else
            {
                str = "select MIN(intid) as fromappl,MAX(intid) as toappl from tblstudentadmission where str_standard in('" + selectedstandard().Replace(",", "','") + "') and intapprove=1 and intschool= " + Session["SchoolID"].ToString();
                ds = da.ExceuteSql(str);
                for (int i = 0; i < chkstandard.Items.Count; i++)
                {
                    if (chkstandard.Items[i].Selected == true)
                    {
                        str = "insert into tbladmissioninterview(dtdate,dttime,strcontactperson,strstandard,strremarks,strbuildingname,strfloor,introomno,strroomname,introomcapacity,intfromappl,inttoappl,intstaff,intschool,intapprove_waitlist)values('" + txtdate.Text + "','" + txttime.Text + "','" + txtcontact.Text + "','" + chkstandard.Items[i].Text + "','" + txtremarks.Text + "','" + ddlbuildname.SelectedValue + "','" + ddlfloor.SelectedValue + "','" + ddlroomno.SelectedValue + "','" + lblroomname.Text + "','" + lblroomcapacity.Text + "','" + ds.Tables[0].Rows[0]["fromappl"].ToString() + "','" + ds.Tables[0].Rows[0]["toappl"].ToString() + "','" + ddlstaff.SelectedValue + "'," + Session["SchoolID"].ToString() + "," + ddlapproval.SelectedValue + ")";
                        ds = da.ExceuteSql(str);
                    }
                }
            }

            fillgrid();

        }
        if (ddlapproval.SelectedValue == "2")
        {
            DataAccess da = new DataAccess();
            string str;
            DataSet ds = new DataSet();
            da = new DataAccess();
            ds = new DataSet();
            if (lblallocated.Text != "0")
            {
                str = "select MIN(a.intid)as fromappl,MAX(a.intid) as toappl from tblstudentadmission a,tbladmissioninterview b where a.str_standard in('" + selectedstandard().Replace(",", "','") + "') and a.intwaitlist=1 and  a.str_standard=b.strstandard and a.intid>b.inttoappl and a.intschool=" + Session["SchoolID"].ToString();
                ds = da.ExceuteSql(str);
                for (int i = 0; i < chkstandard.Items.Count; i++)
                {
                    if (chkstandard.Items[i].Selected == true)
                    {
                        str = "insert into tbladmissioninterview(dtdate,dttime,strcontactperson,strstandard,strremarks,strbuildingname,strfloor,introomno,strroomname,introomcapacity,intfromappl,inttoappl,intstaff,intschool,intapprove_waitlist)values('" + txtdate.Text + "','" + txttime.Text + "','" + txtcontact.Text + "','" + chkstandard.Items[i].Text + "','" + txtremarks.Text + "','" + ddlbuildname.SelectedValue + "','" + ddlfloor.SelectedValue + "','" + ddlroomno.SelectedValue + "','" + lblroomname.Text + "','" + lblroomcapacity.Text + "','" + ds.Tables[0].Rows[0]["fromappl"].ToString() + "','" + ds.Tables[0].Rows[0]["toappl"].ToString() + "','" + ddlstaff.SelectedValue + "'," + Session["SchoolID"].ToString() + "," + ddlapproval.SelectedValue + ")";
                        ds = da.ExceuteSql(str);
                    }
                }
            }
            else
            {
                str = "select MIN(intid) as fromappl,MAX(intid) as toappl from tblstudentadmission where str_standard in('" + selectedstandard().Replace(",", "','") + "') and intwaitlist=1 and intschool= " + Session["SchoolID"].ToString();
                ds = da.ExceuteSql(str);
                for (int i = 0; i < chkstandard.Items.Count; i++)
                {
                    if (chkstandard.Items[i].Selected == true)
                    {
                        str = "insert into tbladmissioninterview(dtdate,dttime,strcontactperson,strstandard,strremarks,strbuildingname,strfloor,introomno,strroomname,introomcapacity,intfromappl,inttoappl,intstaff,intschool,intapprove_waitlist)values('" + txtdate.Text + "','" + txttime.Text + "','" + txtcontact.Text + "','" + chkstandard.Items[i].Text + "','" + txtremarks.Text + "','" + ddlbuildname.SelectedValue + "','" + ddlfloor.SelectedValue + "','" + ddlroomno.SelectedValue + "','" + lblroomname.Text + "','" + lblroomcapacity.Text + "','" + ds.Tables[0].Rows[0]["fromappl"].ToString() + "','" + ds.Tables[0].Rows[0]["toappl"].ToString() + "','" + ddlstaff.SelectedValue + "'," + Session["SchoolID"].ToString() + "," + ddlapproval.SelectedValue + ")";
                        ds = da.ExceuteSql(str);
                    }
                }
            }
        }
    }
     
        
   protected void selectstandard()
    {
        if (ddlapproval.SelectedValue == "1")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "";
            if (labelcount.Text == "0")
            {
                str = "select strcapacity as a,ct from(select count(*) as ct from tblstudentadmission a where intapprove=1 and str_standard in('" + selectedstandard().Replace(",", "','") + "'))as b,(select strcapacity from tblroomcapacity where intschool=" + Session["schoolID"].ToString() + " and intbuildname='" + ddlbuildname.SelectedValue + "' and strfloor='" + ddlfloor.SelectedValue + "' and strroomno='" + ddlroomno.SelectedValue + "') as c";
                ds = da.ExceuteSql(str);
                //ct(select standard count) is greater than a (room capacity) roomcapacity show in available seats(labelcount.text) and standard count show in seats to be allocated(lblallocated.Text)
                if (int.Parse(ds.Tables[0].Rows[0]["ct"].ToString()) > int.Parse(ds.Tables[0].Rows[0]["a"].ToString()))
                {
                    labelcount.Text = ds.Tables[0].Rows[0]["a"].ToString(); ;
                    lblallocated.Text = ds.Tables[0].Rows[0]["ct"].ToString();
                    trlabel.Visible = true;
                }
                else
                {
                    //ct(select standard count) is less than a (room capacity) they filled in this condition. Standard count and room capacity equal means filled in this condition.Suppose standard count less than room capacity means again want to select another standard now its went else condition.
                    if (labelcount.Text == "0")
                    {
                        str = "select strcapacity-ct as a,ct from  (select count(*) as ct from tblstudentadmission a where intapprove=1 and str_standard in('" + selectedstandard().Replace(",", "','") + "'))as b,(select strcapacity from tblroomcapacity where intschool=" + Session["schoolID"].ToString() + " and intbuildname='" + ddlbuildname.SelectedValue + "' and strfloor='" + ddlfloor.SelectedValue + "' and strroomno=" + ddlroomno.SelectedValue + ") as c";
                        ds = da.ExceuteSql(str);

                        labelcount.Text = ds.Tables[0].Rows[0]["a"].ToString();
                        if (ds.Tables[0].Rows[0]["a"].ToString() == "0")
                        {
                            msgbox.alert("The seats fully filled");
                        }
                        if (int.Parse(ds.Tables[0].Rows[0]["a"].ToString()) < 0)
                        {

                            msgbox.alert(" " + ds.Tables[0].Rows[0]["a"].ToString() + " Applications excessed than room capacity");
                        }
                        else
                        {
                            msgbox.alert("The remaining seats is " + ds.Tables[0].Rows[0]["a"].ToString());
                        }
                    }
                    else
                    {
                        //Remaining room capacity fill in labelcount.text they filled in this condition.
                        str = "select '" + labelcount.Text + "'-ct as a,ct from  (select count(*) as ct from tblstudentadmission a where intapprove=1 and str_standard in('" + selectedstandard().Replace(",", "','") + "'))as b";
                        ds = da.ExceuteSql(str);

                        labelcount.Text = ds.Tables[0].Rows[0]["a"].ToString();
                        if (ds.Tables[0].Rows[0]["a"].ToString() == "0")
                        {
                            msgbox.alert("The seats fully filled");
                        }
                        if (int.Parse(ds.Tables[0].Rows[0]["a"].ToString()) < 0)
                        {
                            msgbox.alert(" " + ds.Tables[0].Rows[0]["a"].ToString() + " Applications excessed than room capacity");
                        }
                        else
                        {
                            msgbox.alert("The remaining seats is " + ds.Tables[0].Rows[0]["a"].ToString());
                        }
                    }
                    save();
                    fillgrid();
                    fillstandard();
                }
            }
            else
            {
                //after that available function(protected void btnavailable) remaining allocated seats(standard count)  so in this if condition want available seats here available seats is 0 only allocated seats is remaining. so its come to this else condition, then ew select room capacity and same if condition function here doing in this function.
                str = "select ct from(select count(*) as ct from tblstudentadmission a where intapprove=1 and str_standard in('" + selectedstandard().Replace(",", "','") + "'))as b,(select strcapacity from tblroomcapacity where intschool=" + Session["schoolID"].ToString() + " and intbuildname='" + ddlbuildname.SelectedValue + "' and strfloor='" + ddlfloor.SelectedValue + "' and strroomno=" + ddlroomno.SelectedValue + ") as c";
                ds = da.ExceuteSql(str);
                //ct(select standard count) is greater than a (room capacity) standard count show in seats to be allocated(lblallocated.Text)
                if (int.Parse(ds.Tables[0].Rows[0]["ct"].ToString()) > int.Parse(labelcount.Text))
                {
                    lblallocated.Text = ds.Tables[0].Rows[0]["ct"].ToString();
                    trlabel.Visible = true;
                }
                else
                {
                    //ct(select standard count) is less than a (room capacity) they filled in this condition. Standard count and room capacity equal means filled in this condition.Suppose standard count less than room capacity means again want to select another standard now its went else condition.
                    if (labelcount.Text == "0")
                    {
                        str = "select strcapacity-ct as a,ct from  (select count(*) as ct from tblstudentadmission a where intapprove=1 and str_standard in('" + selectedstandard().Replace(",", "','") + "'))as b,(select strcapacity from tblroomcapacity where intschool=" + Session["schoolID"].ToString() + " and intbuildname='" + ddlbuildname.SelectedValue + "' and strfloor='" + ddlfloor.SelectedValue + "' and strroomno=" + ddlroomno.SelectedValue + ") as c";
                        ds = da.ExceuteSql(str);

                        labelcount.Text = ds.Tables[0].Rows[0]["a"].ToString();
                        if (ds.Tables[0].Rows[0]["a"].ToString() == "0")
                        {
                            msgbox.alert("The seats fully filled");
                        }
                        if (int.Parse(ds.Tables[0].Rows[0]["a"].ToString()) < 0)
                        {

                            msgbox.alert(" " + ds.Tables[0].Rows[0]["a"].ToString() + " Applications excessed than room capacity");
                        }
                        else
                        {
                            msgbox.alert("The remaining seats is " + ds.Tables[0].Rows[0]["a"].ToString());
                        }
                    }
                    else
                    {
                        //Remaining room capacity fill in labelcount.text they filled in this condition.
                        str = "select '" + labelcount.Text + "'-ct as a,ct from  (select count(*) as ct from tblstudentadmission a where intapprove=1 and str_standard in('" + selectedstandard().Replace(",", "','") + "'))as b";
                        ds = da.ExceuteSql(str);

                        labelcount.Text = ds.Tables[0].Rows[0]["a"].ToString();
                        if (ds.Tables[0].Rows[0]["a"].ToString() == "0")
                        {
                            msgbox.alert("The seats fully filled");
                        }
                        if (int.Parse(ds.Tables[0].Rows[0]["a"].ToString()) < 0)
                        {
                            msgbox.alert(" " + ds.Tables[0].Rows[0]["a"].ToString() + " Applications excessed than room capacity");
                        }
                        else
                        {
                            msgbox.alert("The remaining seats is " + ds.Tables[0].Rows[0]["a"].ToString());
                        }
                    }
                    save();
                    fillgrid();
                    fillstandard();
                }
            }
        }
        if (ddlapproval.SelectedValue == "2")
        {
             DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "";
            if (labelcount.Text == "0")
            {
                str = "select strcapacity as a,ct from(select count(*) as ct from tblstudentadmission a where intwaitlist=1 and str_standard in('" + selectedstandard().Replace(",", "','") + "'))as b,(select strcapacity from tblroomcapacity where intschool=" + Session["schoolID"].ToString() + " and intbuildname='" + ddlbuildname.SelectedValue + "' and strfloor='" + ddlfloor.SelectedValue + "' and strroomno=" + ddlroomno.SelectedValue + ") as c";
                ds = da.ExceuteSql(str);
                //ct(select standard count) is greater than a (room capacity) roomcapacity show in available seats(labelcount.text) and standard count show in seats to be allocated(lblallocated.Text)
                if (int.Parse(ds.Tables[0].Rows[0]["ct"].ToString()) > int.Parse(ds.Tables[0].Rows[0]["a"].ToString()))
                {
                    labelcount.Text = ds.Tables[0].Rows[0]["a"].ToString(); ;
                    lblallocated.Text = ds.Tables[0].Rows[0]["ct"].ToString();
                    trlabel.Visible = true;
                }
                else
                {

                    if (labelcount.Text == "0")
                    {
                        str = "select strcapacity-ct as a,ct from  (select count(*) as ct from tblstudentadmission a where intwaitlist=1 and str_standard in('" + selectedstandard().Replace(",", "','") + "'))as b,(select strcapacity from tblroomcapacity where intschool=" + Session["schoolID"].ToString() + " and intbuildname='" + ddlbuildname.SelectedValue + "' and strfloor='" + ddlfloor.SelectedValue + "' and strroomno=" + ddlroomno.SelectedValue + ") as c";
                        ds = da.ExceuteSql(str);

                        labelcount.Text = ds.Tables[0].Rows[0]["a"].ToString();
                        if (ds.Tables[0].Rows[0]["a"].ToString() == "0")
                        {
                            msgbox.alert("The seats fully filled");
                        }
                        if (int.Parse(ds.Tables[0].Rows[0]["a"].ToString()) < 0)
                        {

                            msgbox.alert(" " + ds.Tables[0].Rows[0]["a"].ToString() + " Applications excessed than room capacity");
                        }
                        else
                        {
                            msgbox.alert("The remaining seats is " + ds.Tables[0].Rows[0]["a"].ToString());
                        }
                    }
                    else
                    {
                        str = "select '" + labelcount.Text + "'-ct as a,ct from  (select count(*) as ct from tblstudentadmission a where intwaitlist=1 and str_standard in('" + selectedstandard().Replace(",", "','") + "'))as b";
                        ds = da.ExceuteSql(str);

                        labelcount.Text = ds.Tables[0].Rows[0]["a"].ToString();
                        if (ds.Tables[0].Rows[0]["a"].ToString() == "0")
                        {
                            msgbox.alert("The seats fully filled");
                        }
                        if (int.Parse(ds.Tables[0].Rows[0]["a"].ToString()) < 0)
                        {
                            msgbox.alert(" " + ds.Tables[0].Rows[0]["a"].ToString() + " Applications excessed than room capacity");
                        }
                        else
                        {
                            msgbox.alert("The remaining seats is " + ds.Tables[0].Rows[0]["a"].ToString());
                        }
                    }
                    save();
                    fillgrid();
                    fillstandard();
                }
            }
            else
            {
                str = "select ct from(select count(*) as ct from tblstudentadmission a where intwaitlist=1 and str_standard in('" + selectedstandard().Replace(",", "','") + "'))as b,(select strcapacity from tblroomcapacity where intschool=" + Session["schoolID"].ToString() + " and intbuildname='" + ddlbuildname.SelectedValue + "' and strfloor='" + ddlfloor.SelectedValue + "' and strroomno=" + ddlroomno.SelectedValue + ") as c";
                ds = da.ExceuteSql(str);

                if (int.Parse(ds.Tables[0].Rows[0]["ct"].ToString()) > int.Parse(labelcount.Text))
                {
                    lblallocated.Text = ds.Tables[0].Rows[0]["ct"].ToString();
                    trlabel.Visible = true;
                }
                else
                {
                    if (labelcount.Text == "0")
                    {
                        str = "select strcapacity-ct as a,ct from  (select count(*) as ct from tblstudentadmission a where intwaitlist=1 and str_standard in('" + selectedstandard().Replace(",", "','") + "'))as b,(select strcapacity from tblroomcapacity where intschool=" + Session["schoolID"].ToString() + " and intbuildname='" + ddlbuildname.SelectedValue + "' and strfloor='" + ddlfloor.SelectedValue + "' and strroomno=" + ddlroomno.SelectedValue + ") as c";
                        ds = da.ExceuteSql(str);

                        labelcount.Text = ds.Tables[0].Rows[0]["a"].ToString();
                        if (ds.Tables[0].Rows[0]["a"].ToString() == "0")
                        {
                            msgbox.alert("The seats fully filled");
                        }
                        if (int.Parse(ds.Tables[0].Rows[0]["a"].ToString()) < 0)
                        {

                            msgbox.alert(" " + ds.Tables[0].Rows[0]["a"].ToString() + " Applications excessed than room capacity");
                        }
                        else
                        {
                            msgbox.alert("The remaining seats is " + ds.Tables[0].Rows[0]["a"].ToString());
                        }
                    }
                    else
                    {
                        str = "select '" + labelcount.Text + "'-ct as a,ct from  (select count(*) as ct from tblstudentadmission a where intwaitlist=1 and str_standard in('" + selectedstandard().Replace(",", "','") + "'))as b";
                        ds = da.ExceuteSql(str);

                        labelcount.Text = ds.Tables[0].Rows[0]["a"].ToString();
                        if (ds.Tables[0].Rows[0]["a"].ToString() == "0")
                        {
                            msgbox.alert("The seats fully filled");
                        }
                        if (int.Parse(ds.Tables[0].Rows[0]["a"].ToString()) < 0)
                        {
                            msgbox.alert(" " + ds.Tables[0].Rows[0]["a"].ToString() + " Applications excessed than room capacity");
                        }
                        else
                        {
                            msgbox.alert("The remaining seats is " + ds.Tables[0].Rows[0]["a"].ToString());
                        }
                    }
                    save();
                    fillgrid();
                    fillstandard();
                }
            }
        }
       
    }

    //protected void selectstandard1()
    //{
    //    if (ddlapproval.SelectedValue == "1")
    //    {
    //        DataAccess da = new DataAccess();
    //        DataSet ds = new DataSet();
    //        string str = "";
    //        if (labelcount.Text == "0")
    //        {
    //            str = "select strcapacity as a,ct from(select count(*) as ct from tblstudentadmission a where intapprove=1 and str_standard in('" + selectedstandard().Replace(",", "','") + "'))as b,(select strcapacity from tblroomcapacity where intschool=" + Session["schoolID"].ToString() + " and intbuildname='" + ddlbuildname.SelectedValue + "' and strfloor='" + ddlfloor.SelectedValue + "' and strroomno=" + ddlroomno.SelectedValue + ") as c";
    //            ds = da.ExceuteSql(str);
    //            if (int.Parse(ds.Tables[0].Rows[0]["ct"].ToString()) > int.Parse(ds.Tables[0].Rows[0]["a"].ToString()))
    //            {
    //                labelcount.Text = ds.Tables[0].Rows[0]["a"].ToString(); ;
    //                lblallocated.Text = ds.Tables[0].Rows[0]["ct"].ToString();
    //                trlabel.Visible = true;
    //            }
    //            else
    //            {
    //                if (labelcount.Text == "0")
    //                {
    //                    str = "select strcapacity-ct as a,ct from  (select count(*) as ct from tblstudentadmission a where intapprove=1 and str_standard in('" + selectedstandard().Replace(",", "','") + "'))as b,(select strcapacity from tblroomcapacity where intschool=" + Session["schoolID"].ToString() + " and intbuildname='" + ddlbuildname.SelectedValue + "' and strfloor='" + ddlfloor.SelectedValue + "' and strroomno=" + ddlroomno.SelectedValue + ") as c";
    //                    ds = da.ExceuteSql(str);

    //                    labelcount.Text = ds.Tables[0].Rows[0]["a"].ToString();
    //                    if (ds.Tables[0].Rows[0]["a"].ToString() == "0")
    //                    {
    //                        msgbox.alert("The seats fully filled");
    //                    }
    //                    if (int.Parse(ds.Tables[0].Rows[0]["a"].ToString()) < 0)
    //                    {

    //                        msgbox.alert(" " + ds.Tables[0].Rows[0]["a"].ToString() + " Applications excessed than room capacity");
    //                    }
    //                    else
    //                    {
    //                        msgbox.alert("The remaining seats is " + ds.Tables[0].Rows[0]["a"].ToString());
    //                    }
    //                }
    //                else
    //                {
    //                    str = "select '" + labelcount.Text + "'-ct as a,ct from  (select count(*) as ct from tblstudentadmission a where intapprove=1 and str_standard in('" + selectedstandard().Replace(",", "','") + "'))as b";
    //                    ds = da.ExceuteSql(str);

    //                    labelcount.Text = ds.Tables[0].Rows[0]["a"].ToString();
    //                    if (ds.Tables[0].Rows[0]["a"].ToString() == "0")
    //                    {
    //                        msgbox.alert("The seats fully filled");
    //                    }
    //                    if (int.Parse(ds.Tables[0].Rows[0]["a"].ToString()) < 0)
    //                    {
    //                        msgbox.alert(" " + ds.Tables[0].Rows[0]["a"].ToString() + " Applications excessed than room capacity");
    //                    }
    //                    else
    //                    {
    //                        msgbox.alert("The remaining seats is " + ds.Tables[0].Rows[0]["a"].ToString());
    //                    }
    //                }
    //            }
    //        }
    //        else
    //        {
    //            str = "select ct from(select count(*) as ct from tblstudentadmission a where intapprove=1 and str_standard in('" + selectedstandard().Replace(",", "','") + "'))as b,(select strcapacity from tblroomcapacity where intschool=" + Session["schoolID"].ToString() + " and intbuildname='" + ddlbuildname.SelectedValue + "' and strfloor='" + ddlfloor.SelectedValue + "' and strroomno=" + ddlroomno.SelectedValue + ") as c";
    //            ds = da.ExceuteSql(str);

    //            if (int.Parse(ds.Tables[0].Rows[0]["ct"].ToString()) > int.Parse(labelcount.Text))
    //            {
    //                lblallocated.Text = ds.Tables[0].Rows[0]["ct"].ToString();
    //                trlabel.Visible = true;
    //            }
    //            else
    //            {
    //                if (labelcount.Text == "0")
    //                {
    //                    str = "select strcapacity-ct as a,ct from  (select count(*) as ct from tblstudentadmission a where intapprove=1 and str_standard in('" + selectedstandard().Replace(",", "','") + "'))as b,(select strcapacity from tblroomcapacity where intschool=" + Session["schoolID"].ToString() + " and intbuildname='" + ddlbuildname.SelectedValue + "' and strfloor='" + ddlfloor.SelectedValue + "' and strroomno=" + ddlroomno.SelectedValue + ") as c";
    //                    ds = da.ExceuteSql(str);

    //                    labelcount.Text = ds.Tables[0].Rows[0]["a"].ToString();
    //                    if (ds.Tables[0].Rows[0]["a"].ToString() == "0")
    //                    {
    //                        msgbox.alert("The seats fully filled");
    //                    }
    //                    if (int.Parse(ds.Tables[0].Rows[0]["a"].ToString()) < 0)
    //                    {

    //                        msgbox.alert(" " + ds.Tables[0].Rows[0]["a"].ToString() + " Applications excessed than room capacity");
    //                    }
    //                    else
    //                    {
    //                        msgbox.alert("The remaining seats is " + ds.Tables[0].Rows[0]["a"].ToString());
    //                    }
    //                }
    //                else
    //                {
    //                    str = "select '" + labelcount.Text + "'-ct as a,ct from  (select count(*) as ct from tblstudentadmission a where intapprove=1 and str_standard in('" + selectedstandard().Replace(",", "','") + "'))as b";
    //                    ds = da.ExceuteSql(str);

    //                    labelcount.Text = ds.Tables[0].Rows[0]["a"].ToString();
    //                    if (ds.Tables[0].Rows[0]["a"].ToString() == "0")
    //                    {
    //                        msgbox.alert("The seats fully filled");
    //                    }
    //                    if (int.Parse(ds.Tables[0].Rows[0]["a"].ToString()) < 0)
    //                    {
    //                        msgbox.alert(" " + ds.Tables[0].Rows[0]["a"].ToString() + " Applications excessed than room capacity");
    //                    }
    //                    else
    //                    {
    //                        msgbox.alert("The remaining seats is " + ds.Tables[0].Rows[0]["a"].ToString());
    //                    }
    //                }
    //            }
    //        }
    //    }
    //    if (ddlapproval.SelectedValue == "2")
    //    {
    //        DataAccess da = new DataAccess();
    //        DataSet ds = new DataSet();
    //        string str = "";
    //        if (labelcount.Text == "0")
    //        {
    //            str = "select strcapacity as a,ct from(select count(*) as ct from tblstudentadmission a where intwaitlist=1 and str_standard in('" + selectedstandard().Replace(",", "','") + "'))as b,(select strcapacity from tblroomcapacity where intschool=" + Session["schoolID"].ToString() + " and intbuildname='" + ddlbuildname.SelectedValue + "' and strfloor='" + ddlfloor.SelectedValue + "' and strroomno=" + ddlroomno.SelectedValue + ") as c";
    //            ds = da.ExceuteSql(str);
    //            if (int.Parse(ds.Tables[0].Rows[0]["ct"].ToString()) > int.Parse(ds.Tables[0].Rows[0]["a"].ToString()))
    //            {
    //                labelcount.Text = ds.Tables[0].Rows[0]["a"].ToString(); ;
    //                lblallocated.Text = ds.Tables[0].Rows[0]["ct"].ToString();
    //                trlabel.Visible = true;
    //            }
    //            else
    //            {
    //                if (labelcount.Text == "0")
    //                {
    //                    str = "select strcapacity-ct as a,ct from  (select count(*) as ct from tblstudentadmission a where intwaitlist=1 and str_standard in('" + selectedstandard().Replace(",", "','") + "'))as b,(select strcapacity from tblroomcapacity where intschool=" + Session["schoolID"].ToString() + " and intbuildname='" + ddlbuildname.SelectedValue + "' and strfloor='" + ddlfloor.SelectedValue + "' and strroomno=" + ddlroomno.SelectedValue + ") as c";
    //                    ds = da.ExceuteSql(str);

    //                    labelcount.Text = ds.Tables[0].Rows[0]["a"].ToString();
    //                    if (ds.Tables[0].Rows[0]["a"].ToString() == "0")
    //                    {
    //                        msgbox.alert("The seats fully filled");
    //                    }
    //                    if (int.Parse(ds.Tables[0].Rows[0]["a"].ToString()) < 0)
    //                    {

    //                        msgbox.alert(" " + ds.Tables[0].Rows[0]["a"].ToString() + " Applications excessed than room capacity");
    //                    }
    //                    else
    //                    {
    //                        msgbox.alert("The remaining seats is " + ds.Tables[0].Rows[0]["a"].ToString());
    //                    }
    //                }
    //                else
    //                {
    //                    str = "select '" + labelcount.Text + "'-ct as a,ct from  (select count(*) as ct from tblstudentadmission a where intwaitlist=1 and str_standard in('" + selectedstandard().Replace(",", "','") + "'))as b";
    //                    ds = da.ExceuteSql(str);

    //                    labelcount.Text = ds.Tables[0].Rows[0]["a"].ToString();
    //                    if (ds.Tables[0].Rows[0]["a"].ToString() == "0")
    //                    {
    //                        msgbox.alert("The seats fully filled");
    //                    }
    //                    if (int.Parse(ds.Tables[0].Rows[0]["a"].ToString()) < 0)
    //                    {
    //                        msgbox.alert(" " + ds.Tables[0].Rows[0]["a"].ToString() + " Applications excessed than room capacity");
    //                    }
    //                    else
    //                    {
    //                        msgbox.alert("The remaining seats is " + ds.Tables[0].Rows[0]["a"].ToString());
    //                    }
    //                }
    //            }
    //        }
    //        else
    //        {
    //            str = "select ct from(select count(*) as ct from tblstudentadmission a where intwaitlist=1 and str_standard in('" + selectedstandard().Replace(",", "','") + "'))as b,(select strcapacity from tblroomcapacity where intschool=" + Session["schoolID"].ToString() + " and intbuildname='" + ddlbuildname.SelectedValue + "' and strfloor='" + ddlfloor.SelectedValue + "' and strroomno=" + ddlroomno.SelectedValue + ") as c";
    //            ds = da.ExceuteSql(str);

    //            if (int.Parse(ds.Tables[0].Rows[0]["ct"].ToString()) > int.Parse(labelcount.Text))
    //            {
    //                lblallocated.Text = ds.Tables[0].Rows[0]["ct"].ToString();
    //                trlabel.Visible = true;
    //            }
    //            else
    //            {
    //                if (labelcount.Text == "0")
    //                {
    //                    str = "select strcapacity-ct as a,ct from  (select count(*) as ct from tblstudentadmission a where intwaitlist=1 and str_standard in('" + selectedstandard().Replace(",", "','") + "'))as b,(select strcapacity from tblroomcapacity where intschool=" + Session["schoolID"].ToString() + " and intbuildname='" + ddlbuildname.SelectedValue + "' and strfloor='" + ddlfloor.SelectedValue + "' and strroomno=" + ddlroomno.SelectedValue + ") as c";
    //                    ds = da.ExceuteSql(str);

    //                    labelcount.Text = ds.Tables[0].Rows[0]["a"].ToString();
    //                    if (ds.Tables[0].Rows[0]["a"].ToString() == "0")
    //                    {
    //                        msgbox.alert("The seats fully filled");
    //                    }
    //                    if (int.Parse(ds.Tables[0].Rows[0]["a"].ToString()) < 0)
    //                    {

    //                        msgbox.alert(" " + ds.Tables[0].Rows[0]["a"].ToString() + " Applications excessed than room capacity");
    //                    }
    //                    else
    //                    {
    //                        msgbox.alert("The remaining seats is " + ds.Tables[0].Rows[0]["a"].ToString());
    //                    }
    //                }
    //                else
    //                {
    //                    str = "select '" + labelcount.Text + "'-ct as a,ct from  (select count(*) as ct from tblstudentadmission a where intwaitlist=1 and str_standard in('" + selectedstandard().Replace(",", "','") + "'))as b";
    //                    ds = da.ExceuteSql(str);

    //                    labelcount.Text = ds.Tables[0].Rows[0]["a"].ToString();
    //                    if (ds.Tables[0].Rows[0]["a"].ToString() == "0")
    //                    {
    //                        msgbox.alert("The seats fully filled");
    //                    }
    //                    if (int.Parse(ds.Tables[0].Rows[0]["a"].ToString()) < 0)
    //                    {
    //                        msgbox.alert(" " + ds.Tables[0].Rows[0]["a"].ToString() + " Applications excessed than room capacity");
    //                    }
    //                    else
    //                    {
    //                        msgbox.alert("The remaining seats is " + ds.Tables[0].Rows[0]["a"].ToString());
    //                    }
    //                }
    //            }
    //        }
    //    }

    //}
    
    protected void clear()
    {
        txtdate.Text = "";
        txttime.Text = "";
        txtcontact.Text = "";
        txtremarks.Text = "";
        btnsave.Text = "Save";

    }
    protected void fillgrid()
    {
        if (RBsY.Checked == true)
        {
            if (ddlapproval.SelectedValue == "1")
            {
                DataAccess da = new DataAccess();
                DataSet ds = new DataSet();
                string str = "select a.intid,convert(varchar(10),a.dtdate,111) as dtdate,a.dttime,a.strbuildingname,a.strfloor,a.strroomname,a.intstaff,a.strstandard,b.strbuildname,a.intfromappl,a.inttoappl,c.strfirstname+' '+c.strmiddlename+' '+c.strlastname as name from tbladmissioninterview a,tblbuilding b,tblemployee c,tblstudentadmission d where a.strbuildingname=b.intid and a.intstaff=c.intid and a.intschool=" + Session["SchoolID"].ToString() + " and d.intapprove=1 and d.intid>=a.intfromappl and d.intid<=a.inttoappl group by  a.intid,a.dtdate,a.dttime,a.strbuildingname,a.strfloor,a.strroomname,a.intstaff,a.strstandard,b.strbuildname,a.intfromappl,a.inttoappl,c.strfirstname+' '+c.strmiddlename+' '+c.strlastname";
                ds = da.ExceuteSql(str);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dgadmissioninterview.DataSource = ds;
                    dgadmissioninterview.DataBind();
                    dgadmissioninterview.Columns[3].Visible = true;
                    dgadmissioninterview.Columns[4].Visible = true;
                    dgadmissioninterview.Columns[5].Visible = false;
                }
            }
            if (ddlapproval.SelectedValue == "2")
            {
                DataAccess da = new DataAccess();
                DataSet ds = new DataSet();
                string str = "select a.intid,convert(varchar(10),a.dtdate,111) as dtdate,a.dttime,a.strbuildingname,a.strfloor,a.strroomname,a.intstaff,a.strstandard,b.strbuildname,a.intfromappl,a.inttoappl,c.strfirstname+' '+c.strmiddlename+' '+c.strlastname as name from tbladmissioninterview a,tblbuilding b,tblemployee c,tblstudentadmission d where a.strbuildingname=b.intid and a.intstaff=c.intid and a.intschool=" + Session["SchoolID"].ToString() + " and d.intwaitlist=1 and d.intid>=a.intfromappl and d.intid<=a.inttoappl group by  a.intid,a.dtdate,a.dttime,a.strbuildingname,a.strfloor,a.strroomname,a.intstaff,a.strstandard,b.strbuildname,a.intfromappl,a.inttoappl,c.strfirstname+' '+c.strmiddlename+' '+c.strlastname";
                ds = da.ExceuteSql(str);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dgadmissioninterview.DataSource = ds;
                    dgadmissioninterview.DataBind();
                    dgadmissioninterview.Columns[3].Visible = true;
                    dgadmissioninterview.Columns[4].Visible = true;
                    dgadmissioninterview.Columns[5].Visible = false;

                }
            }
        }
        else
        {
            if (ddlapproval.SelectedValue == "1")
            {
                DataAccess da = new DataAccess();
                DataSet ds = new DataSet();
                string str = "select a.intid,convert(varchar(10),a.dtdate,111) as dtdate,a.dttime,a.intstaff,a.strstandard,a.strbuildingname,a.strfloor,a.strroomname,a.intfromappl,a.inttoappl,c.strfirstname+' '+c.strmiddlename+' '+c.strlastname as name from tbladmissioninterview a,tblemployee c,tblstudentadmission d where  a.intstaff=c.intid and a.intschool=" + Session["SchoolID"].ToString() + " and d.intapprove=1 and d.intid>=a.intfromappl and d.intid<=a.inttoappl group by  a.intid,a.dtdate,a.dttime,a.intstaff,a.strstandard,a.intfromappl,a.inttoappl,a.strbuildingname,a.strfloor,a.strroomname,c.strfirstname+' '+c.strmiddlename+' '+c.strlastname";
                ds = da.ExceuteSql(str);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dgadmissioninterview.DataSource = ds;
                    dgadmissioninterview.DataBind();
                    dgadmissioninterview.Columns[3].Visible = false;
                    dgadmissioninterview.Columns[4].Visible = false;
                    dgadmissioninterview.Columns[5].Visible = false;

                }
            }
            if (ddlapproval.SelectedValue == "2")
            {
                DataAccess da = new DataAccess();
                DataSet ds = new DataSet();
                string str = "select a.intid,convert(varchar(10),a.dtdate,111) as dtdate,a.dttime,a.intstaff,a.strstandard,a.strbuildingname,a.strfloor,a.strroomname,a.intfromappl,a.inttoappl,c.strfirstname+' '+c.strmiddlename+' '+c.strlastname as name from tbladmissioninterview a,tblemployee c,tblstudentadmission d where a.intstaff=c.intid and a.intschool=" + Session["SchoolID"].ToString() + " and d.intwaitlist=1 and d.intid>=a.intfromappl and d.intid<=a.inttoappl group by  a.intid,a.dtdate,a.dttime,a.intstaff,a.strstandard,a.intfromappl,a.inttoappl,c.strfirstname+' '+c.strmiddlename+' '+c.strlastname";
                ds = da.ExceuteSql(str);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dgadmissioninterview.DataSource = ds;
                    dgadmissioninterview.DataBind();
                    dgadmissioninterview.Columns[3].Visible = false;
                    dgadmissioninterview.Columns[4].Visible = false;
                    dgadmissioninterview.Columns[5].Visible = false;

                }
            }
        }
    }
    protected void ddlbuildname_SelectedIndexChanged(object sender, EventArgs e)
    {
      fillfloor();
      fillroomno();
    }
    protected void ddlfloor_SelectedIndexChanged(object sender, EventArgs e)
    {
       fillroomno();
    }
    protected void ddlroomno_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillroomname();
    }
    protected void chkstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        string st = chkstandard.SelectedValue;
        if (RBsY.Checked== true)
        {
            selectstandard();
        }
        
    }
    protected void substitute()
    {
        //satff allocated for class room.
        DataAccess da = new DataAccess();
        DataSet ds, ds1 = new DataSet();
        string str = "select b.strfirstname+''+b.strmiddlename+''+b.strlastname as name,c.strsession,c.dtdate from tblemployee b,tblstaffattendance c where c.intstaff=b.intID and c.dtdate=convert(varchar(10),'" + txtdate.Text + "',103) and b.strfirstname+''+b.strmiddlename+''+b.strlastname ='" + ddlstaff.SelectedValue + "'";
        ds = da.ExceuteSql(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            msgbox.alert("The staff is leave so assign another staff");
        }
        if (ds.Tables[0].Rows.Count == 0)
        {
            str = "select  b.strfirstname+''+b.strmiddlename+''+b.strlastname as name,a.strday,a.strperiod,c.strSTHH+':'+c.strSTMM as starttime,c.strETHH+':'+c.strETMM as endtime from tbltimetable a,tblemployee b,tblschoolperiods c where a.strteacher=b.intID and a.strday=DATENAME(DW,convert(varchar(10),'" + txtdate.Text + "',103)) and b.intID=" + ddlstaff.SelectedValue + " and a.strperiod=c.strperiod and c.strSTHH+':'+c.strSTMM<'" + txttime.Text + "' and c.strETHH+':'+c.strETMM >'" + txttime.Text + "' and c.intschoolid=" + Session["SchoolID"].ToString() + " and a.strperiod Not like 'Interval%' and c.strperiod Not like 'Interval%' and a.strperiod !='Lunch' and c.strperiod!='Lunch' and a.intschool=" + Session["SchoolID"].ToString() + " and b.intschool=" + Session["SchoolID"].ToString();
            ds1 = da.ExceuteSql(str);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                msgbox.alert("The staff has period in this time so assign another staff");
            }
        }
    }
    protected void ddlstaff_SelectedIndexChanged(object sender, EventArgs e)
    {
        substitute();
    }
    protected void btnallocate_Click(object sender, EventArgs e)
    {
        //allocated seats(standard count) and available seats(room capacity) equal or allocated seats greater than available also we allocate same room. 
        if (ddlapproval.SelectedValue == "1")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "";
            str = "select '" + labelcount.Text + "'-ct as a,ct from  (select count(*) as ct from tblstudentadmission a where intapprove=1 and str_standard in('" + selectedstandard().Replace(",", "','") + "'))as b";
            ds = da.ExceuteSql(str);
            labelcount.Text = ds.Tables[0].Rows[0]["a"].ToString();
            if (int.Parse(ds.Tables[0].Rows[0]["a"].ToString()) < 0)
            {
                msgbox.alert("The seats fully filled");
            }
         }
        if (ddlapproval.SelectedValue == "2")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "";
            str = "select '" + labelcount.Text + "'-ct as a,ct from  (select count(*) as ct from tblstudentadmission a where intwaitlist=1 and str_standard in('" + selectedstandard().Replace(",", "','") + "'))as b";
            ds = da.ExceuteSql(str);
            labelcount.Text = ds.Tables[0].Rows[0]["a"].ToString();
            if (int.Parse(ds.Tables[0].Rows[0]["a"].ToString()) < 0)
            {
                msgbox.alert("The seats fully filled");
            }
          }
        save();
        fillgrid();
        fillstandard();
        labelcount.Text = "0";
        trlabel.Visible = false;
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        // cancel the selectstandard
        for (int i = 0; i < chkstandard.Items.Count; i++)
        {
            if (chkstandard.Items[i].Selected == true)
            {
                chkstandard.Items[i].Selected = false;
            }
        }
        trlabel.Visible = false;
        fillstandard();
    }
    protected void btnavailable_Click(object sender, EventArgs e)
    {
        // we call available function to shown remaining seats allocate(standard count) in alert message
        if (ddlapproval.SelectedValue == "1")
        {
            available();
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "";
            str = "select '" + labelcount.Text + "'-ct as a,ct from  (select count(*) as ct from tblstudentadmission a where intapprove=1 and str_standard in('" + selectedstandard().Replace(",", "','") + "'))as b";
            ds = da.ExceuteSql(str);
            labelcount.Text = ds.Tables[0].Rows[0]["a"].ToString();
            if (ds.Tables[0].Rows[0]["a"].ToString() == "0")
            {
                msgbox.alert("The seats fully filled");
            }
            if (int.Parse(ds.Tables[0].Rows[0]["a"].ToString()) < 0)
            {
                msgbox.alert(" " + ds.Tables[0].Rows[0]["a"].ToString() + " Applications excessed than room capacity");
            }
            else
            {
                msgbox.alert("The remaining seats is " + ds.Tables[0].Rows[0]["a"].ToString());
            }
            labelcount.Text = "0";
            fillgrid();
            fillstandard();
            trlabel.Visible = false;
        }
        if (ddlapproval.SelectedValue == "2")
        {
            available();
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "";
            str = "select '" + labelcount.Text + "'-ct as a,ct from  (select count(*) as ct from tblstudentadmission a where intwaitlist=1 and str_standard in('" + selectedstandard().Replace(",", "','") + "'))as b";
            ds = da.ExceuteSql(str);
            labelcount.Text = ds.Tables[0].Rows[0]["a"].ToString();
            if (ds.Tables[0].Rows[0]["a"].ToString() == "0")
            {
                msgbox.alert("The seats fully filled");
            }
            if (int.Parse(ds.Tables[0].Rows[0]["a"].ToString()) < 0)
            {
                msgbox.alert(" " + ds.Tables[0].Rows[0]["a"].ToString() + " Applications excessed than room capacity");
            }
            else
            {
                msgbox.alert("The remaining seats is " + ds.Tables[0].Rows[0]["a"].ToString());
            }
            labelcount.Text = "0";
            fillgrid();
            fillstandard();
            trlabel.Visible = false;
        }
    }
    protected void available()
    {
        //allocated seats(standard count) greater than available seats(roomcapacity) we allocate only available seats for satandard count they choose application id in this function and insert into table then this function call to btnavailable for to show remaining seats allocated(stadard count).(Remaining standard count allocate to another room this process go to protected void selectstandard main else condition) 
        if (ddlapproval.SelectedValue == "1")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "";
            str = "select MIN(intid) as fromappl,MAX(intid) as toappl from  (select top " + labelcount.Text + " * from tblstudentadmission where str_standard in('" + selectedstandard().Replace(",", "','") + "') and intapprove=1 and intschool=" + Session["SchoolID"].ToString() + ") as a";
            ds = da.ExceuteSql(str);
            for (int i = 0; i < chkstandard.Items.Count; i++)
            {
                if (chkstandard.Items[i].Selected == true)
                {
                    str = "insert into tbladmissioninterview(dtdate,dttime,strcontactperson,strstandard,strremarks,strbuildingname,strfloor,introomno,strroomname,introomcapacity,intfromappl,inttoappl,intstaff,intschool,intapprove_waitlist)values('" + txtdate.Text + "','" + txttime.Text + "','" + txtcontact.Text + "','" + chkstandard.Items[i].Text + "','" + txtremarks.Text + "','" + ddlbuildname.SelectedValue + "','" + ddlfloor.SelectedValue + "','" + ddlroomno.SelectedValue + "','" + lblroomname.Text + "','" + lblroomcapacity.Text + "','" + ds.Tables[0].Rows[0]["fromappl"].ToString() + "','" + ds.Tables[0].Rows[0]["toappl"].ToString() + "','" + ddlstaff.SelectedValue + "'," + Session["SchoolID"].ToString() + ","+ddlapproval.SelectedValue+")";
                    ds = da.ExceuteSql(str);
                }
            }
        }
        if (ddlapproval.SelectedValue == "2")
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string str = "";
            str = "select MIN(intid) as fromappl,MAX(intid) as toappl from  (select top " + labelcount.Text + " * from tblstudentadmission where str_standard in('" + selectedstandard().Replace(",", "','") + "') and intwaitlist=1 and intschool=" + Session["SchoolID"].ToString() + ") as a";
            ds = da.ExceuteSql(str);
            for (int i = 0; i < chkstandard.Items.Count; i++)
            {
                if (chkstandard.Items[i].Selected == true)
                {
                    str = "insert into tbladmissioninterview(dtdate,dttime,strcontactperson,strstandard,strremarks,strbuildingname,strfloor,introomno,strroomname,introomcapacity,intfromappl,inttoappl,intstaff,intschool,intapprove_waitlist)values('" + txtdate.Text + "','" + txttime.Text + "','" + txtcontact.Text + "','" + chkstandard.Items[i].Text + "','" + txtremarks.Text + "','" + ddlbuildname.SelectedValue + "','" + ddlfloor.SelectedValue + "','" + ddlroomno.SelectedValue + "','" + lblroomname.Text + "','" + lblroomcapacity.Text + "','" + ds.Tables[0].Rows[0]["fromappl"].ToString() + "','" + ds.Tables[0].Rows[0]["toappl"].ToString() + "','" + ddlstaff.SelectedValue + "'," + Session["SchoolID"].ToString() + ","+ddlapproval.SelectedValue+")";
                    ds = da.ExceuteSql(str);
                }
            }
        }
    }
    protected void ddlapproval_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillstandard();
        fillgrid();
        clear();
    }
    protected void dgadmissioninterview_EditCommand(object source, DataGridCommandEventArgs e)
    {
        if (RBsY.Checked == true)
        {
            if (ddlapproval.SelectedValue == "1")
            {
                lblhid.Text = e.Item.Cells[0].Text;
                DataAccess da = new DataAccess();
                DataSet ds = new DataSet();
                string str = "select a.intid,convert(varchar(10),a.dtdate,111) as dtdate,a.dttime,a.strcontactperson,a.strstandard,a.strremarks,a.strbuildingname,a.strfloor,a.introomno,a.strroomname,a.introomcapacity,a.intstaff,b.strbuildname,a.intfromappl,a.inttoappl,c.strfirstname+' '+c.strmiddlename+' '+c.strlastname as name from tbladmissioninterview a,tblbuilding b,tblemployee c,tblstudentadmission d where a.strbuildingname=b.intid and a.intstaff=c.intid and a.intschool=" + Session["SchoolID"].ToString() + " and a.intapprove_waitlist=" + ddlapproval.SelectedValue + " and  d.intapprove=1 and d.intid>=a.intfromappl and d.intid<=a.inttoappl and a.intid=" + lblhid.Text + " group by  a.intid,a.dtdate,a.dttime,a.strcontactperson,a.strstandard,a.strremarks,a.strbuildingname,a.strfloor,a.introomno,a.strroomname,a.introomcapacity,a.intstaff,b.strbuildname,a.intfromappl,a.inttoappl,c.strfirstname+' '+c.strmiddlename+' '+c.strlastname ";
                ds = da.ExceuteSql(str);
                txtdate.Text = ds.Tables[0].Rows[0]["dtdate"].ToString();
                txttime.Text = ds.Tables[0].Rows[0]["dttime"].ToString();
                buildname();
                ddlbuildname.SelectedValue = ds.Tables[0].Rows[0]["strbuildingname"].ToString();
                fillfloor();
                ddlfloor.SelectedValue = ds.Tables[0].Rows[0]["strfloor"].ToString();
                fillroomno();
                ddlroomno.SelectedValue = ds.Tables[0].Rows[0]["introomno"].ToString();
                lblroomname.Text = ds.Tables[0].Rows[0]["strroomname"].ToString();
                lblroomcapacity.Text = ds.Tables[0].Rows[0]["introomcapacity"].ToString();
                txtcontact.Text = ds.Tables[0].Rows[0]["strcontactperson"].ToString();
                ddlstaff.SelectedValue = ds.Tables[0].Rows[0]["intstaff"].ToString();
                txtremarks.Text = ds.Tables[0].Rows[0]["strremarks"].ToString();
                chkstandard.SelectedValue = ds.Tables[0].Rows[0]["strstandard"].ToString();
                Editstandard();
               
            }
            if (ddlapproval.SelectedValue == "2")
            {
                lblhid.Text = e.Item.Cells[0].Text;
                DataAccess da = new DataAccess();
                DataSet ds = new DataSet();
                string str = "select a.intid,convert(varchar(10),a.dtdate,111) as dtdate,a.dttime,a.strcontactperson,a.strstandard,a.strremarks,a.strbuildingname,a.strfloor,a.introomno,a.strroomname,a.introomcapacity,a.intstaff,b.strbuildname,a.intfromappl,a.inttoappl,c.strfirstname+' '+c.strmiddlename+' '+c.strlastname as name from tbladmissioninterview a,tblbuilding b,tblemployee c,tblstudentadmission d where a.strbuildingname=b.intid and a.intstaff=c.intid and a.intschool=" + Session["SchoolID"].ToString() + " and a.intapprove_waitlist=" + ddlapproval.SelectedValue + " and  d.intwaitlist=1 and d.intid>=a.intfromappl and d.intid<=a.inttoappl and a.intid=" + lblhid.Text + " group by  a.intid,a.dtdate,a.dttime,a.strcontactperson,a.strstandard,a.strremarks,a.strbuildingname,a.strfloor,a.introomno,a.strroomname,a.introomcapacity,a.intstaff,b.strbuildname,a.intfromappl,a.inttoappl,c.strfirstname+' '+c.strmiddlename+' '+c.strlastname ";
                ds = da.ExceuteSql(str);
                txtdate.Text = ds.Tables[0].Rows[0]["dtdate"].ToString();
                txttime.Text = ds.Tables[0].Rows[0]["dttime"].ToString();
                ddlbuildname.SelectedValue = ds.Tables[0].Rows[0]["strbuildingname"].ToString();
                ddlfloor.SelectedValue = ds.Tables[0].Rows[0]["strfloor"].ToString();
                ddlroomno.SelectedValue = ds.Tables[0].Rows[0]["introomno"].ToString();
                lblroomname.Text = ds.Tables[0].Rows[0]["strroomname"].ToString();
                lblroomcapacity.Text = ds.Tables[0].Rows[0]["introomcapacity"].ToString();
                txtcontact.Text = ds.Tables[0].Rows[0]["strcontactperson"].ToString();
                ddlstaff.SelectedValue = ds.Tables[0].Rows[0]["intstaff"].ToString();
                txtremarks.Text = ds.Tables[0].Rows[0]["strremarks"].ToString();
                chkstandard.SelectedValue = ds.Tables[0].Rows[0]["strstandard"].ToString();
                Editstandard();
               
            }
        }
        else
        {
            if (ddlapproval.SelectedValue == "1")
            {
                lblhid.Text = e.Item.Cells[0].Text;
                DataAccess da = new DataAccess();
                DataSet ds = new DataSet();
                string str = "select a.intid,convert(varchar(10),a.dtdate,111) as dtdate,a.dttime,a.strcontactperson,a.strstandard,a.strremarks,a.intstaff,a.intfromappl,a.inttoappl,c.strfirstname+' '+c.strmiddlename+' '+c.strlastname as name from tbladmissioninterview a,tblemployee c,tblstudentadmission d where a.intstaff=c.intid and a.intschool=" + Session["SchoolID"].ToString() + " and a.intapprove_waitlist=" + ddlapproval.SelectedValue + " and  d.intapprove=1 and d.intid>=a.intfromappl and d.intid<=a.inttoappl and a.intid=" + lblhid.Text + " group by  a.intid,a.dtdate,a.dttime,a.strcontactperson,a.strstandard,a.strremarks,a.intstaff,a.intfromappl,a.inttoappl,c.strfirstname+' '+c.strmiddlename+' '+c.strlastname ";
                ds = da.ExceuteSql(str);
                txtdate.Text = ds.Tables[0].Rows[0]["dtdate"].ToString();
                txttime.Text = ds.Tables[0].Rows[0]["dttime"].ToString();
                txtcontact.Text = ds.Tables[0].Rows[0]["strcontactperson"].ToString();
                ddlstaff.SelectedValue = ds.Tables[0].Rows[0]["intstaff"].ToString();
                txtremarks.Text = ds.Tables[0].Rows[0]["strremarks"].ToString();
                chkstandard.SelectedValue = ds.Tables[0].Rows[0]["strstandard"].ToString();
                Editstandard();
                btnsave.Text = "Update";
            }
            if (ddlapproval.SelectedValue == "2")
            {
                lblhid.Text = e.Item.Cells[0].Text;
                DataAccess da = new DataAccess();
                DataSet ds = new DataSet();
                string str = "select a.intid,convert(varchar(10),a.dtdate,111) as dtdate,a.dttime,a.strcontactperson,a.strstandard,a.strremarks,a.intstaff,a.intfromappl,a.inttoappl,c.strfirstname+' '+c.strmiddlename+' '+c.strlastname as name from tbladmissioninterview a,tblemployee c,tblstudentadmission d where a.intstaff=c.intid and a.intschool=" + Session["SchoolID"].ToString() + " and a.intapprove_waitlist=" + ddlapproval.SelectedValue + " and  d.intwaitlist=1 and d.intid>=a.intfromappl and d.intid<=a.inttoappl and a.intid=" + lblhid.Text + " group by  a.intid,a.dtdate,a.dttime,a.strcontactperson,a.strstandard,a.strremarks,a.intfromappl,a.inttoappl,c.strfirstname+' '+c.strmiddlename+' '+c.strlastname ";
                ds = da.ExceuteSql(str);
                txtdate.Text = ds.Tables[0].Rows[0]["dtdate"].ToString();
                txttime.Text = ds.Tables[0].Rows[0]["dttime"].ToString();
                txtcontact.Text = ds.Tables[0].Rows[0]["strcontactperson"].ToString();
                ddlstaff.SelectedValue = ds.Tables[0].Rows[0]["intstaff"].ToString();
                txtremarks.Text = ds.Tables[0].Rows[0]["strremarks"].ToString();
                chkstandard.SelectedValue = ds.Tables[0].Rows[0]["strstandard"].ToString();
                Editstandard();
                btnsave.Text = "Update";
            }
        }
    }
    protected void RBsY_CheckedChanged(object sender, EventArgs e)
    {
        trbuildingname.Visible = true;
        trroomnumber.Visible = true;
        trroomcapacity.Visible = true;
        seats.Visible = true;
        trsave.Visible = false;
        dgadmissioninterview.Columns[3].Visible = true;
        dgadmissioninterview.Columns[4].Visible = true;
        dgadmissioninterview.Columns[11].Visible = false;
       
    }
    protected void RBsN_CheckedChanged(object sender, EventArgs e)
    {
        trbuildingname.Visible =false;
        trroomnumber.Visible = false;
        trroomcapacity.Visible = false;
        seats.Visible = false;
        trsave.Visible = true;
        dgadmissioninterview.Columns[11].Visible = true;
        dgadmissioninterview.Columns[3].Visible = false;
        dgadmissioninterview.Columns[4].Visible = false;
      
    }
    //protected void btnsave_Click(object sender, EventArgs e)
    //{
    //     if (ddlapproval.SelectedValue == "1")
    //    {
    //        DataAccess da = new DataAccess();
    //        string str;
    //        DataSet ds = new DataSet();
    //        da = new DataAccess();
    //        ds = new DataSet();
    //        if (lblallocated.Text != "0")
    //        {
    //            str = "select MIN(a.intid)as fromappl,MAX(a.intid) as toappl from tblstudentadmission a,tbladmissioninterview b where a.str_standard in('" + selectedstandard().Replace(",", "','") + "') and a.intapprove=1 and  a.str_standard=b.strstandard and a.intid>b.inttoappl and a.intschool=" + Session["SchoolID"].ToString();
    //            ds = da.ExceuteSql(str);
    //            for (int i = 0; i < chkstandard.Items.Count; i++)
    //            {
    //                if (chkstandard.Items[i].Selected == true)
    //                {
    //                    str = "insert into tbladmissioninterview(dtdate,dttime,strcontactperson,strstandard,strremarks,strbuildingname,strfloor,introomno,strroomname,introomcapacity,intfromappl,inttoappl,intstaff,intschool,intapprove_waitlist)values('" + txtdate.Text + "','" + txttime.Text + "','" + txtcontact.Text + "','" + chkstandard.Items[i].Text + "','" + txtremarks.Text + "','" + ddlbuildname.SelectedValue + "','" + ddlfloor.SelectedValue + "','" + ddlroomno.SelectedValue + "','" + lblroomname.Text + "','" + lblroomcapacity.Text + "','" + ds.Tables[0].Rows[0]["fromappl"].ToString() + "','" + ds.Tables[0].Rows[0]["toappl"].ToString() + "','" + ddlstaff.SelectedValue + "'," + Session["SchoolID"].ToString() + ","+ddlapproval.SelectedValue+")";
    //                    ds = da.ExceuteSql(str);
    //                }
    //            }
    //        }
    //        else
    //        {
    //            str = "select MIN(intid) as fromappl,MAX(intid) as toappl from tblstudentadmission where str_standard in('" + selectedstandard().Replace(",", "','") + "') and intapprove=1 and intschool= " + Session["SchoolID"].ToString();
    //            ds = da.ExceuteSql(str);
    //            for (int i = 0; i < chkstandard.Items.Count; i++)
    //            {
    //                if (chkstandard.Items[i].Selected == true)
    //                {
    //                    str = "insert into tbladmissioninterview(dtdate,dttime,strcontactperson,strstandard,strremarks,strbuildingname,strfloor,introomno,strroomname,introomcapacity,intfromappl,inttoappl,intstaff,intschool,intapprove_waitlist)values('" + txtdate.Text + "','" + txttime.Text + "','" + txtcontact.Text + "','" + chkstandard.Items[i].Text + "','" + txtremarks.Text + "','" + ddlbuildname.SelectedValue + "','" + ddlfloor.SelectedValue + "','" + ddlroomno.SelectedValue + "','" + lblroomname.Text + "','" + lblroomcapacity.Text + "','" + ds.Tables[0].Rows[0]["fromappl"].ToString() + "','" + ds.Tables[0].Rows[0]["toappl"].ToString() + "','" + ddlstaff.SelectedValue + "'," + Session["SchoolID"].ToString() + "," + ddlapproval.SelectedValue + ")";
    //                    ds = da.ExceuteSql(str);
    //                }
    //            }
    //        }
    //    }
    //    if (ddlapproval.SelectedValue == "2")
    //    {
    //        DataAccess da = new DataAccess();
    //        string str;
    //        DataSet ds = new DataSet();
    //        da = new DataAccess();
    //        ds = new DataSet();
    //        if (lblallocated.Text != "0")
    //        {
    //            str = "select MIN(a.intid)as fromappl,MAX(a.intid) as toappl from tblstudentadmission a,tbladmissioninterview b where a.str_standard in('" + selectedstandard().Replace(",", "','") + "') and a.intwaitlist=1 and  a.str_standard=b.strstandard and a.intid>b.inttoappl and a.intschool=" + Session["SchoolID"].ToString();
    //            ds = da.ExceuteSql(str);
    //            for (int i = 0; i < chkstandard.Items.Count; i++)
    //            {
    //                if (chkstandard.Items[i].Selected == true)
    //                {
    //                    str = "insert into tbladmissioninterview(dtdate,dttime,strcontactperson,strstandard,strremarks,strbuildingname,strfloor,introomno,strroomname,introomcapacity,intfromappl,inttoappl,intstaff,intschool,intapprove_waitlist)values('" + txtdate.Text + "','" + txttime.Text + "','" + txtcontact.Text + "','" + chkstandard.Items[i].Text + "','" + txtremarks.Text + "','" + ddlbuildname.SelectedValue + "','" + ddlfloor.SelectedValue + "','" + ddlroomno.SelectedValue + "','" + lblroomname.Text + "','" + lblroomcapacity.Text + "','" + ds.Tables[0].Rows[0]["fromappl"].ToString() + "','" + ds.Tables[0].Rows[0]["toappl"].ToString() + "','" + ddlstaff.SelectedValue + "'," + Session["SchoolID"].ToString() + "," + ddlapproval.SelectedValue + ")";
    //                    ds = da.ExceuteSql(str);
    //                }
    //            }
    //        }
    //        else
    //        {
    //            str = "select MIN(intid) as fromappl,MAX(intid) as toappl from tblstudentadmission where str_standard in('" + selectedstandard().Replace(",", "','") + "') and intwaitlist=1 and intschool= " + Session["SchoolID"].ToString();
    //            ds = da.ExceuteSql(str);
    //            for (int i = 0; i < chkstandard.Items.Count; i++)
    //            {
    //                if (chkstandard.Items[i].Selected == true)
    //                {
    //                    str = "insert into tbladmissioninterview(dtdate,dttime,strcontactperson,strstandard,strremarks,strbuildingname,strfloor,introomno,strroomname,introomcapacity,intfromappl,inttoappl,intstaff,intschool,intapprove_waitlist)values('" + txtdate.Text + "','" + txttime.Text + "','" + txtcontact.Text + "','" + chkstandard.Items[i].Text + "','" + txtremarks.Text + "','" + ddlbuildname.SelectedValue + "','" + ddlfloor.SelectedValue + "','" + ddlroomno.SelectedValue + "','" + lblroomname.Text + "','" + lblroomcapacity.Text + "','" + ds.Tables[0].Rows[0]["fromappl"].ToString() + "','" + ds.Tables[0].Rows[0]["toappl"].ToString() + "','" + ddlstaff.SelectedValue + "'," + Session["SchoolID"].ToString() + "," + ddlapproval.SelectedValue + ")";
    //                    ds = da.ExceuteSql(str);
    //                }
    //            }
    //        }
    //    }
    
    //}
    protected void btnsave_Click1(object sender, EventArgs e)
    {
       if (ddlapproval.SelectedValue == "1")
        {
           
            DataAccess da = new DataAccess();
            string str;
            DataSet ds = new DataSet();
            str = "delete tbladmissioninterview where intid='" + lblhid.Text + "' and intschool=" + Session["SchoolID"].ToString();
            da.ExceuteSqlQuery(str);
            if (lblallocated.Text != "0")
            {
                str = "select MIN(a.intid)as fromappl,MAX(a.intid) as toappl from tblstudentadmission a,tbladmissioninterview b where a.str_standard in('" + selectedstandard().Replace(",", "','") + "') and a.intapprove=1 and  a.str_standard=b.strstandard and a.intid>b.inttoappl and a.intschool=" + Session["SchoolID"].ToString();
                ds = da.ExceuteSql(str);
                for (int i = 0; i < chkstandard.Items.Count; i++)
                {
                    if (chkstandard.Items[i].Selected == true)
                    {
                        str = "insert into tbladmissioninterview(dtdate,dttime,strcontactperson,strstandard,strremarks,intfromappl,inttoappl,intstaff,intschool,intapprove_waitlist)values('" + txtdate.Text + "','" + txttime.Text + "','" + txtcontact.Text + "','" + chkstandard.Items[i].Text + "','" + txtremarks.Text + "','" + ds.Tables[0].Rows[0]["fromappl"].ToString() + "','" + ds.Tables[0].Rows[0]["toappl"].ToString() + "','" + ddlstaff.SelectedValue + "'," + Session["SchoolID"].ToString() + "," + ddlapproval.SelectedValue + ")";
                        ds = da.ExceuteSql(str);
                    }
                }
            }
           else
            {
                str = "select MIN(intid) as fromappl,MAX(intid) as toappl from tblstudentadmission where str_standard in('" + selectedstandard().Replace(",", "','") + "') and intapprove=1 and intschool= " + Session["SchoolID"].ToString();
                ds = da.ExceuteSql(str);

                for (int i = 0; i < chkstandard.Items.Count; i++)
                {
                    if (chkstandard.Items[i].Selected == true)
                    {
                        str = "insert into tbladmissioninterview(dtdate,dttime,strcontactperson,strstandard,strremarks,intfromappl,inttoappl,intstaff,intschool,intapprove_waitlist)values('" + txtdate.Text + "','" + txttime.Text + "','" + txtcontact.Text + "','" + chkstandard.Items[i].Text + "','" + txtremarks.Text + "','" + ds.Tables[0].Rows[0]["fromappl"].ToString() + "','" + ds.Tables[0].Rows[0]["toappl"].ToString() + "','" + ddlstaff.SelectedValue + "'," + Session["SchoolID"].ToString() + "," + ddlapproval.SelectedValue + ")";
                        ds = da.ExceuteSql(str);
                    }
                }

            }
           fillgrid();
           clear();
            
        }
        if (ddlapproval.SelectedValue == "2")
        {
            DataAccess da = new DataAccess();
            string str;
            DataSet ds = new DataSet();
            da = new DataAccess();
            ds = new DataSet();
            str = "delete tbladmissioninterview where dtdate='" + txtdate.Text + "',dttime='" + txttime.Text + "',intfromappl='" + ds.Tables[0].Rows[0]["fromappl"].ToString() + "',inttoappl='" + ds.Tables[0].Rows[0]["toappl"].ToString() + "',intschool=" + Session["SchoolID"].ToString(); 
            if (lblallocated.Text != "0")
            {
                str = "select MIN(a.intid)as fromappl,MAX(a.intid) as toappl from tblstudentadmission a,tbladmissioninterview b where a.str_standard in('" + selectedstandard().Replace(",", "','") + "') and a.intwaitlist=1 and  a.str_standard=b.strstandard and a.intid>b.inttoappl and a.intschool=" + Session["SchoolID"].ToString();
                ds = da.ExceuteSql(str);
                for (int i = 0; i < chkstandard.Items.Count; i++)
                {
                    if (chkstandard.Items[i].Selected == true)
                    {
                        str = "insert into tbladmissioninterview(dtdate,dttime,strcontactperson,strstandard,strremarks,intfromappl,inttoappl,intstaff,intschool,intapprove_waitlist)values('" + txtdate.Text + "','" + txttime.Text + "','" + txtcontact.Text + "','" + chkstandard.Items[i].Text + "','" + txtremarks.Text + "','" + ds.Tables[0].Rows[0]["fromappl"].ToString() + "','" + ds.Tables[0].Rows[0]["toappl"].ToString() + "','" + ddlstaff.SelectedValue + "'," + Session["SchoolID"].ToString() + "," + ddlapproval.SelectedValue + ")";
                        ds = da.ExceuteSql(str);
                    }
                }
            }
            else
            {
                str = "select MIN(intid) as fromappl,MAX(intid) as toappl from tblstudentadmission where str_standard in('" + selectedstandard().Replace(",", "','") + "') and intwaitlist=1 and intschool= " + Session["SchoolID"].ToString();
                ds = da.ExceuteSql(str);
                for (int i = 0; i < chkstandard.Items.Count; i++)
                {
                    if (chkstandard.Items[i].Selected == true)
                    {
                        str = "insert into tbladmissioninterview(dtdate,dttime,strcontactperson,strstandard,strremarks,intfromappl,inttoappl,intstaff,intschool,intapprove_waitlist)values('" + txtdate.Text + "','" + txttime.Text + "','" + txtcontact.Text + "','" + chkstandard.Items[i].Text + "','" + txtremarks.Text + "','" + ds.Tables[0].Rows[0]["fromappl"].ToString() + "','" + ds.Tables[0].Rows[0]["toappl"].ToString() + "','" + ddlstaff.SelectedValue + "'," + Session["SchoolID"].ToString() + "," + ddlapproval.SelectedValue + ")";
                        ds = da.ExceuteSql(str);
                    }
                }
                
            }
            fillgrid();
            clear();
        }
       
    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        clear();
    }
    protected void btndelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton delete = (ImageButton)sender;
        TableCell cell = delete.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        DataAccess da = new DataAccess();
        string sql = "delete tbladmissioninterview where intID=" + item.Cells[0].Text;
        da.ExceuteSqlQuery(sql);
        fillgrid();
    }
}


