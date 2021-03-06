﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CalendarEvent
/// </summary>
public class CalendarEvent
{
    public int id { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public DateTime start { get; set; }
    public DateTime end { get; set; }
    public string intschool { get; set; }
    public string backgroundcolor { get; set; }
    public string textcolor { get; set; }
    public string patrontype { get; set; }
    public int userid { get; set; }
}
