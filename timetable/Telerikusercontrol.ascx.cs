using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.IO;



public partial class Telerikusercontrol : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public string intid
    {
        get
        {
            if (ViewState["intid"] == null)
            {
                return "";
            }
            return (string)ViewState["intid"];
        }
        set
        {

            ViewState["intid"] = value;

        }
    }


    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
        this.ProductDataSource.SelectParameters["intid"].DefaultValue = this.intid;

        this.DataBind();
    }


    protected void ProductsView_DataBound(object sender, EventArgs e)
    {
        System.Web.UI.WebControls.Image image = (System.Web.UI.WebControls.Image)ProductsView.FindControl("image");
        if (image == null) return;
        if (!File.Exists(MapPath(image.ImageUrl)))
        {

            image.ImageUrl = "../images/noimage.jpg";
        }
    }
}
