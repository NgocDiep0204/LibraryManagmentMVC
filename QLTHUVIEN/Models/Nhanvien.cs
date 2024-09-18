using System;
using System.Collections.Generic;

namespace QLTHUVIEN.Models;

public partial class Nhanvien
{
    public string MaNv { get; set; } = null!;

    public int MaChucNang { get; set; }

    public string? TenNv { get; set; }

    public string? GioiTinh { get; set; }

    public DateTime? NgaySinh { get; set; }

    public string? DiaChi { get; set; }

    public string? Sdt { get; set; }

    public virtual ICollection<Phieumuon> Phieumuons { get; set; } = new List<Phieumuon>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
