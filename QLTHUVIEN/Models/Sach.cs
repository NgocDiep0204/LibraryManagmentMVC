using System;
using System.Collections.Generic;

namespace QLTHUVIEN.Models;

public partial class Sach
{
    public string MaSach { get; set; } = null!;

    public string MaNxb { get; set; } = null!;

    public string MaTacGia { get; set; } = null!;

    public string? TenSach { get; set; }

    public string MaTheLoai { get; set; } = null!;

    public string MaViTri { get; set; } = null!;

    public int? NamXb { get; set; }

    public int? SoLuong { get; set; }

    public int? Muon { get; set; }

    public int? LanTaiBan { get; set; }

    public string? NgonNgu { get; set; }

    public virtual Nxb MaNxbNavigation { get; set; } = null!;

    public virtual Tacgium MaTacGiaNavigation { get; set; } = null!;

    public virtual ICollection<Phieumuon> Phieumuons { get; set; } = new List<Phieumuon>();
}
