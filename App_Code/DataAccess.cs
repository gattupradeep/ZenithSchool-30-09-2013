using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for DataAccess
/// </summary>

    public class DataAccess
    {
        public void ExceuteSqlQuery(string sql)
        {
            SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"]);
            SqlDataAdapter sada = new SqlDataAdapter();
            SqlCommand cmd;

            Conn.Open();
            cmd = new SqlCommand(sql, Conn);
            cmd.ExecuteNonQuery();
            Conn.Close();
        }

        public DataSet ExceuteSql(string sql)
        {
            SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"]);
            SqlDataAdapter sada = new SqlDataAdapter();
            DataSet ds;

            sada = new SqlDataAdapter(sql, Conn);
            ds = new DataSet();
            sada.Fill(ds);
            return (ds);
        }
        
        public string fetchdata(string strqry)
        {
            DataSet ds = new DataSet();
            DataAccess da = new DataAccess();

            ds = new DataSet();
            ds = da.ExceuteSql(strqry);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                return "Dont Know";
            }
        }

        public void filllogs(int UserID,string strMaster,int MasterID,int SchoolID)
        {
            SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"]);
            SqlDataAdapter sada = new SqlDataAdapter();
            SqlCommand cmd;

            Conn.Open();
            cmd = new SqlCommand("insert into tbldailylogs(intuserid,strmaster,intmasterid,intschool) values(" + UserID.ToString() + ",'" + strMaster.ToString() + "'," + MasterID.ToString() + "," + SchoolID.ToString() + ")");
            cmd.ExecuteNonQuery();
            Conn.Close();
        }

    }

