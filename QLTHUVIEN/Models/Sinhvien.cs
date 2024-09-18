using System;
using System.Collections.Generic;

namespace QLTHUVIEN.Models;

public partial class Sinhvien
{
    public string MaSv { get; set; } = null!;

    public string? HoTen { get; set; }

    public string? Lop { get; set; }

    public virtual ICollection<Phieumuon> Phieumuons { get; set; } = new List<Phieumuon>();
}
