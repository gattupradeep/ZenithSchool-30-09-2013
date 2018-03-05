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

public partial class Lunch_menutimetable : System.Web.UI.Page
{
   public SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"]);
   public SqlCommand cmd;
   public string strsql;
   public DataAccess da;
   public DataSet ds;
   protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            filltype();
            if (Request["sid"] != null)
            {
                edit();
            }
            //fillgrid();
        }
   }
   protected void edit()
   {
       DataAccess da = new DataAccess();
       string sql = "select * from tblmenutimetable where intschool=" + Session["SchoolID"].ToString() + " and intid=" + Request["sid"].ToString();
       DataSet ds = new DataSet();
       ds = da.ExceuteSql(sql);
       ddlday.SelectedValue = ds.Tables[0].Rows[0]["strday"].ToString();
       ddltype.SelectedValue = ds.Tables[0].Rows[0]["strtype"].ToString();
       string meals = ds.Tables[0].Rows[0]["strmealstype"].ToString();
       if (rbtveg.Text == meals)
       {
           rbtveg.Checked = true;
           rbtnonveg.Checked = false;
       }
       else
       {
           rbtnonveg.Checked = true;
           rbtveg.Checked = false;
       }
       txtfoodname.Text = ds.Tables[0].Rows[0]["strfoodname"].ToString();
       Txtcurryname.Text = ds.Tables[0].Rows[0]["strcurryname"].ToString();
       txtmaindish.Text = ds.Tables[0].Rows[0]["strmaindish"].ToString();
       Txtsidedish.Text = ds.Tables[0].Rows[0]["strsidedish"].ToString();
       txtadditional.Text = ds.Tables[0].Rows[0]["stradditional"].ToString();
       Btnsave.Text = "Update";
       fillgrid();
       Session["day"] = ds.Tables[0].Rows[0]["strday"].ToString();
    }
    protected void fillgrid()
    {
        DataAccess da = new DataAccess();
        string sql;
        if (Btnsave.Text != "Update")
        {
            sql = "select * from tblmenutimetable where intschool=" + Session["SchoolID"].ToString() +" and strtype='" +ddltype.SelectedValue +"'";
        }

        else
        {
            sql = "select * from tblmenutimetable where intschool=" + Session["SchoolID"].ToString() + " and intid=" + Request["sid"].ToString() + " and strtype='" + ddltype.SelectedValue + "'"; 
        }
        
        DataSet ds = new DataSet();
        ds = da.ExceuteSql(sql);
        dgmenutimetable.DataSource = ds;
        dgmenutimetable.DataBind();
        if (ddltype.SelectedValue == "Lunch")
        {
            trlunch.Visible = true;
            trsidedish.Visible = true;
            tradditional.Visible = true;
            trbreakfast.Visible = false;
            trdrink.Visible = false;
            dgmenutimetable.Columns[4].Visible = false;
            dgmenutimetable.Columns[5].Visible = false;
            dgmenutimetable.Columns[6].Visible = true;
            dgmenutimetable.Columns[7].Visible = true;
            dgmenutimetable.Columns[8].Visible = true;
        }
        else if (ddltype.SelectedValue == "Breakfast")
        {
            trlunch.Visible = false;
            trsidedish.Visible = false;
            tradditional.Visible = false;
            trbreakfast.Visible = true;
            trdrink.Visible = true;
            dgmenutimetable.Columns[4].Visible = true;
            dgmenutimetable.Columns[5].Visible = true;
            dgmenutimetable.Columns[6].Visible = false;
            dgmenutimetable.Columns[7].Visible = false;
            dgmenutimetable.Columns[8].Visible = false;
           
        }
       else
        {
            dgmenutimetable.Columns[4].Visible = true;
            dgmenutimetable.Columns[5].Visible = true;
            dgmenutimetable.Columns[6].Visible = true;
            dgmenutimetable.Columns[7].Visible = true;
            dgmenutimetable.Columns[8].Visible = true;
        }
       
     }
    protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
    {
        filltype();
        //fillgrid();
    }
   protected void filltype()
    {
        if (ddltype.SelectedValue == "Lunch")
        {
            trlunch.Visible = true;
            trsidedish.Visible = true;
            tradditional.Visible = true;
            trbreakfast.Visible = false;
            trdrink.Visible = false;
        }
        else
        {
            trbreakfast.Visible = true;
            trdrink.Visible = true;
            Txtsidedish.Text = "";
            txtadditional.Text = "";
            trsidedish.Visible = false;
            tradditional.Visible = false;
            trlunch.Visible = false;
        }
    }
   protected void btnsave_Click(object sender, EventArgs e)
   {
       //if (ddltype.SelectedIndex == 0)
       //{
       //    MsgBox1.alert("Please select Menu type");
       //}
       if (ddlday.SelectedIndex == 0)
       {
           //ScriptManager.RegisterStartupScript(this, GetType(), "clientscript", "Alert('Please select a day');", true);
           MsgBox1.alert("Please select a day");
       }
       if (ddlday.SelectedIndex > 0)
       {
           SqlCommand cmd;
           SqlParameter Outputparameter;
           SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"]);
           Conn.Open();
           cmd = new SqlCommand("spmenutimetable", Conn);
           cmd.CommandType = CommandType.StoredProcedure;
           Outputparameter = cmd.Parameters.Add("@rc", SqlDbType.Int);
           Outputparameter.Direction = ParameterDirection.Output;
           if (Btnsave.Text == "Save")
               cmd.Parameters.Add("@intid", "0");
           else
               cmd.Parameters.Add("@intid", Session["sid"].ToString());
           cmd.Parameters.Add("@strday", ddlday.SelectedValue);
           cmd.Parameters.Add("@strtype", ddltype.SelectedValue);
           string meal;
           if (rbtveg.Checked == true)
               meal = rbtveg.Text;
           else
               meal = rbtnonveg.Text;
           cmd.Parameters.Add("@strmealstype", meal);
           cmd.Parameters.Add("@strfoodname", txtfoodname.Text.Trim());
           cmd.Parameters.Add("@strcurryname", Txtcurryname.Text.Trim());
           cmd.Parameters.Add("@strmaindish", txtmaindish.Text.Trim());
           cmd.Parameters.Add("@strsidedish", Txtsidedish.Text.Trim());
           cmd.Parameters.Add("@stradditional", txtadditional.Text.Trim());
           cmd.Parameters.Add("@intschool", Session["SchoolID"].ToString());
           cmd.ExecuteNonQuery();
           if (cmd.Parameters["@rc"].Value.ToString() == "0")
           {
               ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Already Exist')", true);
               //MsgBox1.alert("Already Exist");
           }
           Conn.Close();
          
           string id = Convert.ToString(Outputparameter.Value);
           if (Btnsave.Text == "Save")
           {
               Functions.UserLogs(Session["UserID"].ToString(), "tblmenutimetable", id, "Added", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 61);
               ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Details Saved Successfully')", true);
           }
           else
           {
               Functions.UserLogs(Session["UserID"].ToString(), "tblmenutimetable", id, "Updated", Session["PatronType"].ToString(), Session["SchoolID"].ToString(), 61);
           }
           if (Btnsave.Text == "Update")
           {
               //allclear();
              // Response.Redirect("edit_lunch_menu.aspx?sid=" + Session["sid"].ToString());
               ScriptManager.RegisterStartupScript(Page, Page.GetType(), "redirect script", "alert('Details Update Successfully!'); location.href='edit_lunch_menu.aspx?sid=" + Session["sid"].ToString()+"';", true);
           }
           else
           {
               fillgrid();
               allclear();
           }           
       }
   }

    protected void allclear()
    {
        txtfoodname.Text = "";
        Txtcurryname.Text = "";
        Txtsidedish.Text = "";
        txtadditional.Text = "";
        txtmaindish.Text="";
        ddltype.SelectedIndex = 0;
        ddlday.SelectedIndex = 0;
        Btnsave.Text = "Save";
    }
    protected void btnclear_Click1(object sender, EventArgs e)
    {
        allclear();
    }

   
}

