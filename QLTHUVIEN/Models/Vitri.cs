using System;
using System.Collections.Generic;

namespace QLTHUVIEN.Models;

public partial class Vitri
{
    public string MaViTri { get; set; } = null!;

    public string? Ngan { get; set; }

    public string? Ke { get; set; }

    public DateTime? TimeUpdate { get; set; }

    public DateTime? TimeCreate { get; set; }

    public string? Khu { get; set; }
}
