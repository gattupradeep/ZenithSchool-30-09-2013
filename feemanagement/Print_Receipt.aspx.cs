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

public partial class feemanagement_Print_Receipt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            tdReceiptNo.InnerHtml = Request.QueryString["rn"].ToString();
            tdReceiptDate.InnerHtml = Request.QueryString["rd"].ToString();
            tdStudentNo.InnerHtml = Request.QueryString["adn"].ToString();
            tdStudentName.InnerHtml = Request.QueryString["sn"].ToString();
            tdReceivedFrom.InnerHtml = Request.QueryString["rf"].ToString();
            tdDiscription.InnerHtml = Request.QueryString["dc"].ToString();
            tdAmount.InnerHtml = Request.QueryString["amt"].ToString();
            tdPaymode.InnerHtml = Request.QueryString["pm"].ToString();
            tdChequeNo.InnerHtml = Request.QueryString["cn"].ToString();
            tdCashier.InnerHtml = Request.QueryString["cr"].ToString();
            Response.Clear();
            Response.Write("<script>window.print();</script>");
            Response.Write("<script>window.close();</script>");
        }
    }
}
