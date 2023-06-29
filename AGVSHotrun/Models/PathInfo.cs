using System;
using System.Collections.Generic;

namespace AGVSHotrun.Models;

public partial class PathInfo
{
    public DateTime ChangeTime { get; set; }

    public int AGVID { get; set; }

    public int? Location { get; set; }
}
