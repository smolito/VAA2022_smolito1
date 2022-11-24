using System;
using System.Collections.Generic;

namespace WpfApp1;

public partial class Schedule
{
    public Schedule (string? date, string? timeFrom, string? timeTo)
    {
        UserId = LoggedUser.Id;
        Date = date;
        TimeFrom = timeFrom;
        TimeTo = timeTo;
    }

    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? Date { get; set; }

    public string? TimeFrom { get; set; }

    public string? TimeTo { get; set; }
}
