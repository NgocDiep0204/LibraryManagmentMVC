using System;
using System.Collections.Generic;

namespace QLTHUVIEN.Models;

public partial class Tacgium
{
    public string MaTacGia { get; set; } = null!;

    public string? TenTacGia { get; set; }

    public DateTime? TimeUpdate { get; set; }

    public DateTime? TimeCreate { get; set; }

    public string? DiaChi { get; set; }

    public virtual ICollection<Sach> Saches { get; set; } = new List<Sach>();
}
