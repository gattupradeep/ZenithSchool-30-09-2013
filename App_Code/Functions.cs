using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Mail;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;
using System.IO;
using System.Net;
using System.Text;

/// <summary>
/// Summary description for Function
/// </summary>
public class Functions
{
    private static byte[] KEY_64 = { 42, 16, 93, 156, 78, 4, 218, 32 };
    private static byte[] IV_64 = { 55, 103, 246, 79, 36, 99, 167, 3 };

    public Functions()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static string getstrddldate(string strday, string strmon, string stryr)
    {
        string strret;
        DateTime dt;

        try
        {
            //Server
            System.Globalization.CultureInfo british = new System.Globalization.CultureInfo("en-GB");
            dt = DateTime.Parse(strday.ToString() + "/" + strmon.ToString() + "/" + stryr.ToString(), british);

            //Local
            //dt = DateTime.Parse(strmon.ToString() + "/" + strday.ToString() + "/" + stryr.ToString());
            strret = dt.ToString();
        }
        catch (Exception ex)
        {
            strret = "Invalid";
        }
        return (strret);
    }

    public static bool IsDBNull(object dbvalue)
    {
        return dbvalue == DBNull.Value;
    }

    public static string FixNull(object dbvalue)
    {
        if (dbvalue == DBNull.Value)
        {
            return "";
        }
        else
        {
            //NOTE: This will cast value to string if
            //it isn't a string.

            return dbvalue.ToString();
        }
    }

    public static Boolean checksqlinj(string strdata)
    {
        int chkvalue = 0;

        chkvalue = strdata.IndexOf("!");
        chkvalue = chkvalue + strdata.IndexOf("%");
        chkvalue = chkvalue + strdata.IndexOf("@");
        chkvalue = chkvalue + strdata.IndexOf("DECLARE");
        chkvalue = chkvalue + strdata.IndexOf("VARCHAR");

        if (chkvalue == -5)
        {
            return (false);
        }
        else
        {
            return (true);
        }
    }

    public static int checkstring(string strdata)
    {
        int chkvalue = 0;
        if (strdata.IndexOf("&") >=0)
        {
            chkvalue = 1;
        }
        else if (strdata.IndexOf(",") >=0)
        {
            chkvalue = 1;
        }
        else if (strdata.IndexOf("'") >= 0)
        {
            chkvalue = 1;
        }
        return (chkvalue);
    }

    public static long checkphone(string strdata)
    {
        long chkvalue = 0;
        string phnum = "";

        phnum = Functions.splchar(strdata);
        try
        {
            chkvalue = long.Parse(phnum.ToString());
        }
        catch (Exception ex)
        {
            chkvalue = 0;
        }
        return (chkvalue);
    }

    public static string splchar(string userstr)
    {
        string returnstr = "";

        returnstr = userstr.ToString().Trim();
        returnstr = returnstr.Replace("–", "");
        returnstr = returnstr.Replace("'", "");
        returnstr = returnstr.Replace("´", "");
        returnstr = returnstr.Replace("’", "");
        returnstr = returnstr.Replace("`", "");
        returnstr = returnstr.Replace("’", "");
        returnstr = returnstr.Replace("/", "");
        returnstr = returnstr.Replace("\"", "");
        returnstr = returnstr.Replace(",", "");
        returnstr = returnstr.Replace(".", "");
        returnstr = returnstr.Replace("*", "");
        returnstr = returnstr.Replace("+", "");
        returnstr = returnstr.Replace("@", "");
        returnstr = returnstr.Replace("÷", "");
        returnstr = returnstr.Replace("±", "");
        returnstr = returnstr.Replace("!", "");
        returnstr = returnstr.Replace("?", "");
        returnstr = returnstr.Replace("®", "");
        returnstr = returnstr.Replace("^", "");
        returnstr = returnstr.Replace("-", "");
        returnstr = returnstr.Replace("_", "");
        returnstr = returnstr.Replace(" ", "");

        return (returnstr);
    }

    public static string StrMoney(string strprice)
    {
        string strdecval = "";
        string strreturn = "";

        if (strprice.IndexOf(".") > -1)
        {
            strdecval = strprice.Substring(strprice.IndexOf(".") + 1);
            if (strdecval.Length > 2)
            {
                strreturn = strprice.Substring(0, strprice.IndexOf(".") + 1) + strdecval.Substring(0, 2);
            }
            else if (strdecval.Length == 2)
            {
                strreturn = strprice;
            }
            else if (strdecval.Length == 1)
            {
                strreturn = strprice + "0";
            }
        }
        else
        {
            strreturn = strprice + ".00";
        }
        return (strreturn);
    }

    public static string Strdecmial(string strprice, int noofdec)
    {
        string strzeros = "";
        string strdecval = "";
        string strreturn = "";

        if (strprice.IndexOf(".") > -1)
        {
            strdecval = strprice.Substring(strprice.IndexOf(".") + 1);
            if (strdecval.Length > noofdec)
            {
                strreturn = strprice.Substring(0, strprice.IndexOf(".") + 1) + strdecval.Substring(0, noofdec);
            }
            else if (strdecval.Length == noofdec)
            {
                strreturn = strprice;
            }
            else if (strdecval.Length < noofdec)
            {
                strzeros = "";
                for (int i = 0; i < noofdec - strdecval.Length; i++)
                {
                    strzeros = strzeros + "0";
                }
                strreturn = strprice + strzeros;
            }
        }
        else
        {
            strzeros = "";
            for (int i = 0; i < noofdec; i++)
            {
                strzeros = strzeros + "0";
            }
            strreturn = strprice + "." + strzeros;
        }
        return (strreturn);
    }

    public static string StrAlignText(string strtext)
    {
        string rettext = "";
        string aligntxt = "";

        if (strtext.Length > 0)
        {
            aligntxt = strtext.ToLower().Substring(1);
            rettext = strtext.ToUpper().Substring(0, 1) + aligntxt;
        }

        return (rettext);
    }

    public static string StrAlignWords(string strtext)
    {
        string txt;
        string rettext = "";
        string aligntxt = "";

        strtext = strtext.Trim();
        txt = strtext.Replace(" ", "_");
        txt = txt.Replace("__", "_");
        if (strtext.Length > 0)
        {
            if (txt.IndexOf("_") >= 0)
            {
                aligntxt = txt.Substring(0, txt.IndexOf("_"));
                aligntxt = StrAlignText(aligntxt);

                txt = txt.Substring(txt.IndexOf("_"));
                while (txt.IndexOf("_") >= 0)
                {
                    txt = txt.Substring(1);
                    if (txt.IndexOf("_") > 0)
                    {
                        aligntxt = aligntxt + " " + StrAlignText(txt.Substring(0, txt.IndexOf("_")));
                        txt = txt.Substring(txt.IndexOf("_"));
                    }
                    else
                    {
                        if (txt.Length > 2)
                        {
                            aligntxt = aligntxt + " " + StrAlignText(txt);
                        }
                        else
                        {
                            aligntxt = aligntxt + " " + txt;
                        }
                    }
                }
            }
            else
            {
                aligntxt = StrAlignText(strtext);
            }
        }
        rettext = aligntxt;
        return (rettext);
    }

    public static string BreakString(string strtext, int intbr)
    {
        int brval;
        int a, b, c, intmod;
        string brtxt, fulltxt;

        brval = intbr;
        brtxt = strtext;
        c = brtxt.Length / brval;
        intmod = brtxt.Length % brval;
        if (intmod > 0)
        {
            c = c + 1;
        }

        if (brtxt.Length > brval)
        {
            b = 0;
            fulltxt = "";
            for (a = 0; a < c; a++)
            {
                if (brtxt.Length > b + brval)
                {
                    fulltxt = fulltxt + brtxt.Substring(b, brval) + "<br/>";
                    b = b + brval;
                }
                else
                {
                    fulltxt = fulltxt + brtxt.Substring(b);
                }
            }
            brtxt = fulltxt;
        }
        return (brtxt);
    }
            
    public static void Sendmail(string msgto,string msgfrom,string strSubject, string bdy)
    {
        try
        {
            MailMessage msg = new MailMessage();
            msg.To = msgto;
            msg.From = msgfrom;
            msg.Bcc = "johnvjouse@hotmail.com,jay@marshal.com.my,gopichand@marshal.com.my,giribabu.sayineni@gmail.com";
            msg.Subject = strSubject;
            msg.BodyFormat = MailFormat.Html;
            msg.Body = bdy;

            MailAuthentication(msg);

            SmtpMail.SmtpServer = System.Configuration.ConfigurationSettings.AppSettings["SmtpServerName"];
            SmtpMail.Send(msg);
        }
        catch (Exception)
        {
        }
    }

    public static void Sendmail1(string msgto, string msgfrom, string strSubject, string bdy)
    {
        try
        {
            MailMessage msg = new MailMessage();
            msg.To = msgto;
            msg.From = msgfrom;
            msg.Subject = strSubject;
            msg.BodyFormat = MailFormat.Html;
            msg.Body = bdy;

            MailAuthentication(msg);

            SmtpMail.SmtpServer = System.Configuration.ConfigurationSettings.AppSettings["SmtpServerName"];
            SmtpMail.Send(msg);
        }
        catch (Exception)
        {
        }
    }

    public static void MailAuthentication(System.Web.Mail.MailMessage mail)
    {
        mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");    //basic authentication
        mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", "info@theschools.in"); //set your username here
        mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", "TheSchools");    //set your password here
    }

    public static string Encryption(string value)
    {
        if (value != "")
        {
            DESCryptoServiceProvider CryptoProvidor = new DESCryptoServiceProvider();
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, CryptoProvidor.CreateEncryptor(KEY_64, IV_64), CryptoStreamMode.Write);
            StreamWriter sw = new StreamWriter(cs);
            sw.Write(value);
            sw.Flush();
            cs.FlushFinalBlock();
            ms.Flush();
            return Convert.ToBase64String(ms.GetBuffer(),0,Convert.ToInt32(ms.Length));
        }
        return String.Empty;
    }

    public static string Descryption(string value)
    {
        if (value != "")
        {
            DESCryptoServiceProvider CryptoProvidor = new DESCryptoServiceProvider();
            Byte[] buf = Convert.FromBase64String(value);
            MemoryStream ms = new MemoryStream(buf);
            CryptoStream cs = new CryptoStream(ms, CryptoProvidor.CreateDecryptor(KEY_64, IV_64), CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cs);
            return sr.ReadToEnd();
        }
        return String.Empty;
    }

    public static void ResizeFromStream(string fromFile, string toFile)
    {
        int intNewWidth = 150;
        int intNewHeight = 180;
        System.Drawing.Image imgInput = System.Drawing.Image.FromFile(fromFile);

        //Determine image format 
        System.Drawing.Imaging.ImageFormat fmtImageFormat = imgInput.RawFormat;

       
        //create new bitmap 
        System.Drawing.Bitmap bmpResized = new System.Drawing.Bitmap(imgInput, intNewWidth, intNewHeight);

        //save bitmap to disk 
        bmpResized.Save(toFile, fmtImageFormat);


        //release used resources 
        imgInput.Dispose();
        bmpResized.Dispose();
       
    }

    public static string HttpPost(string uri, string parameters)
    {
        WebRequest webRequest = WebRequest.Create(uri);
        webRequest.ContentType = "application/x-www-form-urlencoded";
        webRequest.Method = "POST";
        byte[] bytes = Encoding.ASCII.GetBytes(parameters);
        Stream os = null;
        try
        { // send the Post
            webRequest.ContentLength = bytes.Length;   //Count bytes to send
            os = webRequest.GetRequestStream();
            os.Write(bytes, 0, bytes.Length);         //Send it
        }
        catch
        {
        }
        finally
        {
            if (os != null)
            {
                os.Close();
            }
        }

        try
        { // get the response
            WebResponse webResponse = webRequest.GetResponse();
            if (webResponse == null)
            { return null; }
            StreamReader sr = new StreamReader(webResponse.GetResponseStream());
            return sr.ReadToEnd().Trim();
        }
        catch
        {
        }
        return null;
    }
    public static void UserLogs(string intStaffID, string strTableName, string intIdentityID, string strActionType,string strPatronType, string intSchoolID,int menuid)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"]);
        SqlDataAdapter sada = new SqlDataAdapter();
        SqlCommand cmd;
        conn.Open();
        cmd = new SqlCommand("SP_UserLogs", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        sada = new SqlDataAdapter(cmd);
        cmd.Parameters.AddWithValue("@intStaffID", intStaffID);
        cmd.Parameters.AddWithValue("@strTableName", strTableName);
        cmd.Parameters.AddWithValue("@intIdentityID", intIdentityID);
        cmd.Parameters.AddWithValue("@strActionType", strActionType);
        cmd.Parameters.AddWithValue("@strPatronType", strPatronType);
        cmd.Parameters.AddWithValue("@intSchoolID", intSchoolID);
        cmd.Parameters.AddWithValue("@menuid", @menuid);
        cmd.ExecuteNonQuery();
        conn.Close();
    }


    public static void UserLogs(object p, string p_2, string p_3, string p_4, string p_5, string p_6, int p_7)
    {
        throw new NotImplementedException();
    }
}
