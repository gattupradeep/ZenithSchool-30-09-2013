using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;
using System.Configuration;



/// <summary>
/// EventDAO class is the main class which interacts with the database. SQL Server express edition
/// has been used.
/// the event information is stored in a table named 'event' in the database.
///
/// Here is the table format:
/// event(event_id int, title varchar(100), description varchar(200),event_start datetime, event_end datetime)
/// event_id is the primary key
/// </summary>
public class EventDAO
{
	//change the connection string as per your database connection.
    //IU MS Sql Server
    

   	//this method retrieves all events within range start-end
    public static List<CalendarEvent> getEvents(DateTime start, DateTime end)
    {
        string Schoolid = HttpContext.Current.Session["SchoolID"].ToString();
        
        List<CalendarEvent> events = new List<CalendarEvent>();
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Conn"]);
        //SqlCommand cmd = new SqlCommand("SELECT event_id, description, title, event_start, event_end FROM event where event_start>=@start AND event_end<=@end", con);
        SqlCommand cmd = new SqlCommand("SELECT intid,title,description,remainder_start, remainder_end,intschool,strbackgroundcolor,strtextcolor,strpatrontype,Userid FROM tblremainder where remainder_start>=@start AND remainder_end<=@end AND strpatrontype='" + HttpContext.Current.Session["PatronType"].ToString() + "' and Userid=" + HttpContext.Current.Session["UserID"].ToString()  + " and  intschool=" + Schoolid.ToString(), con);
             
        cmd.Parameters.AddWithValue("@start", start);
        cmd.Parameters.AddWithValue("@end", end);
        
        using (con)
        {
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CalendarEvent cevent = new CalendarEvent();
                cevent.id = int.Parse(reader["intid"].ToString());
                cevent.title = (string)reader["title"];
                cevent.description = (string)reader["description"];
                cevent.start = (DateTime)reader["remainder_start"];
                cevent.end = (DateTime)reader["remainder_end"];
                cevent.backgroundcolor = (string)reader["strbackgroundcolor"];
                cevent.textcolor = (string)reader["strtextcolor"];
                cevent.patrontype= (string) reader["strpatrontype"];
                cevent.userid = int.Parse(reader["Userid"].ToString());
                events.Add(cevent);
            }
        }
        return events;
        //side note: if you want to show events only related to particular users,
        //if user id of that user is stored in session as Session["userid"]
        //the event table also contains a extra field named 'user_id' to mark the event for that particular user
        //then you can modify the SQL as:
        //SELECT event_id, description, title, event_start, event_end FROM event where user_id=@user_id AND event_start>=@start AND event_end<=@end
        //then add paramter as:cmd.Parameters.AddWithValue("@user_id", HttpContext.Current.Session["userid"]);
    }

	//this method updates the event title and description
    public static void updateEvent(int id, String title, String description, String backgroundcolor, String textcolor)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Conn"]);
        SqlCommand cmd = new SqlCommand("UPDATE tblremainder SET title=@title, description=@description,strbackgroundcolor=@strbackgroundcolor,strtextcolor=@strtextcolor WHERE intid=@intid ", con);
        
        cmd.Parameters.AddWithValue("@title", title);
        cmd.Parameters.AddWithValue("@description", description);
        cmd.Parameters.AddWithValue("@intid", id);
        cmd.Parameters.AddWithValue("@strbackgroundcolor",backgroundcolor);
        cmd.Parameters.AddWithValue("@strtextcolor", textcolor);
       
        using (con)
        {
            con.Open();
            cmd.ExecuteNonQuery();
        }
    }

	//this method updates the event start and end time
    public static void updateEventTime(int id, DateTime start, DateTime end)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Conn"]);
        SqlCommand cmd = new SqlCommand("UPDATE tblremainder SET remainder_start=@remainder_start, remainder_end=@remainder_end WHERE intid=@intid ", con);
        cmd.Parameters.AddWithValue("@remainder_start", start);
        cmd.Parameters.AddWithValue("@remainder_end", end);
        cmd.Parameters.AddWithValue("@intid", id);
        //cmd.Parameters.AddWithValue("@strpatrontype", strpatrontype);
        //cmd.Parameters.AddWithValue("@Userid", userid);
        using (con)
        {
            con.Open();
            cmd.ExecuteNonQuery();
        }
    }

	//this mehtod deletes event with the id passed in.
    public static void deleteEvent(int id)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Conn"]);
        SqlCommand cmd = new SqlCommand("DELETE FROM tblremainder WHERE (intid = @intid)", con);
        cmd.Parameters.AddWithValue("@intid", id);
        using (con)
        {
            con.Open();
            cmd.ExecuteNonQuery();
        }
    }

	//this method adds events to the database
    public static int addEvent(CalendarEvent cevent)
    {
        //add event to the database and return the primary key of the added event row
      
        //insert
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Conn"]);
        SqlCommand cmd = new SqlCommand("INSERT INTO tblremainder(title, description, remainder_start, remainder_end,intschool,strbackgroundcolor,strtextcolor,strpatrontype,Userid) VALUES(@title, @description, @remainder_start, @remainder_end,@intschool,@strbackgroundcolor,@strtextcolor,@strpatrontype,@Userid)", con);
        
       
        cmd.Parameters.AddWithValue("@title", cevent.title);
        cmd.Parameters.AddWithValue("@description", cevent.description);
        cmd.Parameters.AddWithValue("@remainder_start", cevent.start);
        cmd.Parameters.AddWithValue("@remainder_end", cevent.end);
        cmd.Parameters.AddWithValue("@intschool", cevent.intschool);
        cmd.Parameters.AddWithValue("@strbackgroundcolor", cevent.backgroundcolor);
        cmd.Parameters.AddWithValue("@strtextcolor", cevent.textcolor);
        cmd.Parameters.AddWithValue("@strpatrontype", HttpContext.Current.Session["PatronType"].ToString());
        cmd.Parameters.AddWithValue("@Userid", HttpContext.Current.Session["UserID"].ToString());
        int key = 0;
        using (con)
        {
            con.Open();
            cmd.ExecuteNonQuery();

            //get primary key of inserted row
            cmd = new SqlCommand("SELECT max(intid) FROM tblremainder where title=@title AND description=@description AND remainder_start=@remainder_start AND remainder_end=@remainder_end AND strbackgroundcolor=@strbackgroundcolor AND strtextcolor=@strtextcolor and strpatrontype=@strpatrontype and Userid=@Userid and intschool=@intschool", con);
        
           
            cmd.Parameters.AddWithValue("@title", cevent.title);
            cmd.Parameters.AddWithValue("@description", cevent.description);
            cmd.Parameters.AddWithValue("@remainder_start", cevent.start);
            cmd.Parameters.AddWithValue("@remainder_end", cevent.end);
            cmd.Parameters.AddWithValue("@intschool", cevent.intschool);
            cmd.Parameters.AddWithValue("@strbackgroundcolor", cevent.backgroundcolor);
            cmd.Parameters.AddWithValue("@strtextcolor", cevent.textcolor);
            cmd.Parameters.AddWithValue("@strpatrontype", HttpContext.Current.Session["PatronType"].ToString());
            cmd.Parameters.AddWithValue("@Userid", HttpContext.Current.Session["UserID"].ToString());
            key = (int)cmd.ExecuteScalar();
        }

        return key;

    }


    
}
