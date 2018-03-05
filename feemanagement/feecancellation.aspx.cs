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
using System.Reflection;

public partial class feemanagement_feecancellation : System.Web.UI.Page
{
    DataSet ds;
    Csfeemenagement Clsfee = new Csfeemenagement();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Page Page = (Page)HttpContext.Current.CurrentHandler;
            if (!String.IsNullOrEmpty(Page.Request.QueryString["AdmissionNo"]))
                txtadmno.Text = Request["AdmissionNo"].ToString();
            else
                txtadmno.Text = txtadmno.Text.ToString();
            Studentdetails();
        }
        removequerystring();
    }
    protected void fillgrid()
    {
        ds = new DataSet();
        ds = Clsfee.fncGetFeePaymentForGRID(txtadmno.Text.Trim(), tdClasstxt.InnerHtml.Trim(),"");
        grd_trasaction.DataSource = ds;
        grd_trasaction.DataBind();
        if (ds.Tables[0].Rows.Count > 0)
            trGrid.Visible = true;
        else
            trGrid.Visible = false;
    }
    protected void removequerystring()
    {
        PropertyInfo isreadonly = typeof(System.Collections.Specialized.NameValueCollection).GetProperty("IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
        isreadonly.SetValue(this.Request.QueryString, false, null);
        this.Request.QueryString.Remove("AdmissionNo");
    }
    protected void Cancel_Click(object sender, EventArgs e)
    {
        Button list = (Button)sender;
        TableCell cell = list.Parent as TableCell;
        DataGridItem item = cell.Parent as DataGridItem;
        int index = item.ItemIndex;
        Button Cancel = new Button();
        Cancel = (Button)item.FindControl("Cancel");
        if (Cancel.Text == "Cancel")
        {
            Clsfee.fncCancelFeePayment(Int32.Parse(item.Cells[0].Text), Int32.Parse(Session["UserID"].ToString()));
            Cancel.Text = "Canceled";
        }
        cancelled();
        removequerystring();
    }
    protected void cancelled()
    {
        fillgrid();
        if (grd_trasaction.Items.Count > 0)
        {
            ds = new DataSet();
            ds = Clsfee.fncGetFeePaymentForGRID(txtadmno.Text.Trim(), string.Empty, string.Empty);
            for (int i = 0; i < grd_trasaction.Items.Count; i++)
            {
                DataGridItem item = grd_trasaction.Items[i];
                Button cancel = (Button)item.FindControl("Cancel");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (int.Parse(ds.Tables[0].Rows[i]["Cancel"].ToString()) == 1)
                        cancel.Text = "canceled";
                    else
                        cancel.Text = "Cancel";
                }
            }
        }
        else
            ScriptManager.RegisterStartupScript(this, this.GetType(), "clientscripts", "alert('No record found for selected admission number"+ txtadmno.Text.Trim() +"')", true);

    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        Studentdetails();
    }
    protected void Studentdetails()
    {
        if (txtadmno.Text != string.Empty)
        {
            ds = new DataSet();
            ds = Clsfee.fncGetStudentNameforAdmision(txtadmno.Text.Trim());
            if (ds.Tables[0].Rows[0]["ERROR"].ToString() == "VALID")
            {
                trstudent.Visible = true;
                tdClasstxt.InnerHtml = ds.Tables[0].Rows[0]["Class"].ToString();
                tdnametxt.InnerHtml = ds.Tables[0].Rows[0]["StudentName"].ToString();
                cancelled();
            }
            else
            {
                trstudent.Visible = false;
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Invalid admission number');", true);
                txtadmno.Text = string.Empty;
                txtadmno.Focus();
            }
        }
    }
    protected void txtadmno_TextChanged(object sender, EventArgs e)
    {
        if (txtadmno.Text != string.Empty)
        {
            grd_trasaction.DataSource = null;
            grd_trasaction.DataBind();
            Studentdetails();
        }
        else
        {
            trstudent.Visible = false;
            grd_trasaction.DataSource = null;
            grd_trasaction.DataBind();
        }
        removequerystring();
    }
}


