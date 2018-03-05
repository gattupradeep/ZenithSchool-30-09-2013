using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;
using System.Data.SqlClient;
/// <summary>
/// <summary>
/// Summary description for homework
/// </summary>
namespace Telerik.Web.Examples.Integration.GridAndCombo2
{

    public class homework : GridBoundColumn
    {
        public homework()
        {
            //
            // TODO: Add constructor logic here
            //
        }
          public static string ConnectionString
        {
            get { return ConfigurationManager.AppSettings["conn"]; }
        }

        //RadGrid will call this method when it initializes the controls inside the filtering item cells
        protected override void SetupFilterControls(TableCell cell)
        {
            base.SetupFilterControls(cell);
            cell.Controls.RemoveAt(0);
            RadComboBox combo = new RadComboBox();
            combo.Visible = false;
            if (this.UniqueName != "intid")
            {
                combo.ID = ("RadComboBox1" + this.UniqueName);
                combo.Visible = true;
            }
                combo.ShowToggleImage = false;
                combo.Skin = "Office2007";
                combo.EnableLoadOnDemand = true;
                combo.AutoPostBack = true;
                combo.MarkFirstMatch = true;
                combo.Height = Unit.Pixel(100);
                combo.ItemsRequested += this.list_ItemsRequested;
                combo.SelectedIndexChanged += this.list_SelectedIndexChanged;
                cell.Controls.AddAt(0, combo);
                cell.Controls.RemoveAt(1);
           
        }

        //RadGrid will cal this method when the value should be set to the filtering input control(s)
        protected override void SetCurrentFilterValueToControl(TableCell cell)
        {
            base.SetCurrentFilterValueToControl(cell);
            RadComboBox combo = (RadComboBox)cell.Controls[0];
            if ((this.CurrentFilterValue != string.Empty))
            {
                combo.Text = this.CurrentFilterValue;
            }
        }

        //RadGrid will cal this method when the filtering value should be extracted from the filtering input control(s)
        protected override string GetCurrentFilterValueFromControl(TableCell cell)
        {
            RadComboBox combo = (RadComboBox)cell.Controls[0];
            return combo.Text;
        }

        private void list_ItemsRequested(object o, RadComboBoxItemsRequestedEventArgs e)
        {
            if (this.DataField == "strstaffname")
            {
                ((RadComboBox)o).DataTextField = this.DataField;
                ((RadComboBox)o).DataValueField = this.DataField;
                ((RadComboBox)o).DataSource = GetDataTable("SELECT b.strfirstname + ' ' + ltrim(b.strmiddlename) + ' ' + ltrim(b.strlastname)as strstaffname FROM tblhomework a,tblemployee b WHERE a.intemployee=b.intid and b.strfirstname + ' ' + ltrim(b.strmiddlename) + ' ' + ltrim(b.strlastname) LIKE '" + e.Text + "%' group by b.strfirstname + ' ' + ltrim(b.strmiddlename) + ' ' + ltrim(b.strlastname)");
                ((RadComboBox)o).DataBind();
            }
            if (this.DataField == "strsubject")
            {
                ((RadComboBox)o).DataTextField = this.DataField;
                ((RadComboBox)o).DataValueField = this.DataField;
                ((RadComboBox)o).DataSource = GetDataTable("SELECT b.strsubject  FROM tblhomework a,tblhomeworktopics b WHERE b.strsubject LIKE '%' group by b.strsubject");
                ((RadComboBox)o).DataBind();
            }
            if (this.DataField == "strstandard")
            {
                ((RadComboBox)o).DataTextField = this.DataField;
                ((RadComboBox)o).DataValueField = this.DataField;
                ((RadComboBox)o).DataSource = GetDataTable("SELECT b.strstandard FROM tblhomework a,tblhomeworktopics b WHERE  b.strstandard LIKE '" + e.Text + "%' group by b.strstandard");
                ((RadComboBox)o).DataBind();
            }
            if (this.DataField == "strtopic")
            {
                ((RadComboBox)o).DataTextField = this.DataField;
                ((RadComboBox)o).DataValueField = this.DataField;
                ((RadComboBox)o).DataSource = GetDataTable("SELECT DISTINCT strtopic FROM tblhomeworktopics WHERE strtopic LIKE '" + e.Text + "%'");
                ((RadComboBox)o).DataBind();
            }
            if (this.DataField == "strdescription")
            {
                ((RadComboBox)o).DataTextField = this.DataField;
                ((RadComboBox)o).DataValueField = this.DataField;
                ((RadComboBox)o).DataSource = GetDataTable("SELECT DISTINCT strdescription FROM tblhomework WHERE strdescription LIKE '" + e.Text + "%'");
                ((RadComboBox)o).DataBind();
            }
            if (this.DataField == "strassigndate")
            {
                ((RadComboBox)o).DataTextField = this.DataField;
                ((RadComboBox)o).DataValueField = this.DataField;
                ((RadComboBox)o).DataSource = GetDataTable("SELECT DISTINCT (convert(varchar(10),dtassigndate,103)) as strassigndate FROM tblhomework WHERE convert(varchar(10),dtassigndate,103) LIKE '" + e.Text + "%'");
                ((RadComboBox)o).DataBind();
            }
            if (this.DataField == "strduedate")
            {
                ((RadComboBox)o).DataTextField = this.DataField;
                ((RadComboBox)o).DataValueField = this.DataField;
                ((RadComboBox)o).DataSource = GetDataTable("SELECT DISTINCT (convert(varchar(10),dtduedate,103)) as strduedate FROM tblhomework WHERE convert(varchar(10),dtduedate,103) LIKE '" + e.Text + "%'");
                ((RadComboBox)o).DataBind();
            }
            if (this.DataField == "strpublishdate")
            {
                ((RadComboBox)o).DataTextField = this.DataField;
                ((RadComboBox)o).DataValueField = this.DataField;
                ((RadComboBox)o).DataSource = GetDataTable("SELECT DISTINCT (convert(varchar(10),dtpublishdate,103)) as strpublishdate FROM tblhomework WHERE convert(varchar(10),dtpublishdate,103) LIKE '" + e.Text + "%'");
                ((RadComboBox)o).DataBind();
            }
            //else
            //{
            //    ((RadComboBox)o).DataTextField = this.DataField;
            //    ((RadComboBox)o).DataValueField = this.DataField;
            //    ((RadComboBox)o).DataSource = GetDataTable("SELECT DISTINCT " + this.UniqueName + " FROM tblhomeworktopics WHERE " + this.UniqueName + " LIKE '" + e.Text + "%'");
            //    ((RadComboBox)o).DataBind();
            //}
        }

        private void list_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            GridFilteringItem filterItem = (GridFilteringItem)((RadComboBox)o).NamingContainer;
            if ((this.UniqueName == "Index"))
            {
                //this is filtering for integer column type
                filterItem.FireCommandEvent("Filter", new Pair("EqualTo", this.UniqueName));
            }
            //filtering for string column type
            filterItem.FireCommandEvent("Filter", new Pair("Contains", this.UniqueName));
        }

        public static DataTable GetDataTable(string query)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand(query, conn);

            DataTable myDataTable = new DataTable();

            conn.Open();
            try
            {
                adapter.Fill(myDataTable);
            }
            finally
            {
                conn.Close();
            }
            return myDataTable;
        }

    }
    
}