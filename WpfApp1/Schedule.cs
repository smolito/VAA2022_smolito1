using System;
using System.Collections.Generic;

namespace WpfApp1;

public partial class Schedule
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? Streamer { get; set; }

    public string? Date { get; set; }

    public string? TimeFrom { get; set; }

    public string? TimeTo { get; set; }
}
