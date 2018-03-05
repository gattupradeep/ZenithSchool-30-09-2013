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

public partial class Tutorials_Pop_view_tutorial : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataAccess da = new DataAccess();
            DataSet ds = new DataSet();
            string strsql = "select a.*,convert(varchar(10),dtpublishdate,103) as publishdate,convert(varchar(10),dtdate,103) as date,b.strfirstname +' '+strmiddlename+' '+strlastname as teachername,c.strtextbookname from tbltutorial a,tblemployee b,tblschooltextbook c where a.intschool =" + Session["SchoolID"] + " and b.intid = a.intteacher and c.intid=a.inttextbook and a.intid=" + Request["tutorial"];
            ds = da.ExceuteSql(strsql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lbldate.Text = ds.Tables[0].Rows[0]["date"].ToString();
                lblpublishdate.Text = ds.Tables[0].Rows[0]["publishdate"].ToString();
                lblclass.Text = ds.Tables[0].Rows[0]["strclass"].ToString();
                lblteacher.Text = ds.Tables[0].Rows[0]["teachername"].ToString();
                lblsubject.Text = ds.Tables[0].Rows[0]["strsubject"].ToString();
                lbltextbook.Text = ds.Tables[0].Rows[0]["strtextbookname"].ToString();
                lblunit.Text = ds.Tables[0].Rows[0]["strunit"].ToString();
                lbllesson.Text = ds.Tables[0].Rows[0]["strlesson"].ToString();
                lbldescripton.Text = ds.Tables[0].Rows[0]["strdescription"].ToString();
                string[] audiofile = ds.Tables[0].Rows[0]["straudiofilename"].ToString().Split("|".ToCharArray());
                int audiofilelength =audiofile.Length;
                string audiolink = "None";
                for (int j = 1; j < audiofilelength; j++)
                {
                    if (j == 1)
                    {
                        audiolink = "<div id='playlist'><div href='" + "../Tutorials/Audio/" + audiofile[j].ToString() + "' style='width: 200px;' class='item'><div> <div class='btn play'></div><div class='title'>" + audiofile[j].ToString() + "</div></div><div class='player inactive'></div></div>";
                    }
                    else
                    {
                        audiolink = audiolink + "<br/ ><div href='" + "../Tutorials/Audio/" + audiofile[j].ToString() + "' style='width: 200px;' class='item'><div> <div class='btn play'></div><div class='title'>" + audiofile[j].ToString() + "</div></div><div class='player inactive'></div></div>";
                    }
                }
                lblaudio.Text = audiolink + "</div>";
                string[] docfile = ds.Tables[0].Rows[0]["strdocumentname"].ToString().Split("|".ToCharArray());
                int docfilelength = docfile.Length;
                string doclink = "None";
                for (int k = 1; k < docfilelength; k++)
                {
                    if (k == 1)
                    {
                        doclink = k + "." + "<a href='" + "../Tutorials/Docs/" + docfile[k].ToString() + "' target='_blank'>" + docfile[k].ToString() + "</a>";
                    }
                    else
                    {
                        doclink = doclink + "<br />" + k + ".<a href='" + "../Tutorials/Docs/" + docfile[k].ToString() + "' target='_blank'>" + docfile[k].ToString() + "</a>";
                    }
                }
                lbldocument.Text = doclink;
            }
        }
    }
}
