using System;
using System.Collections.Generic;

namespace QLTHUVIEN.Models;

public partial class Nxb
{
    public string MaNxb { get; set; } = null!;

    public string? TenNxb { get; set; }

    public string? Gmail { get; set; }

    public int? Sdt { get; set; }

    public string? DiaChi { get; set; }

    public virtual ICollection<Sach> Saches { get; set; } = new List<Sach>();
}
