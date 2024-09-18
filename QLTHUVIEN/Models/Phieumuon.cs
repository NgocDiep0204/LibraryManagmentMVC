using System;
using System.Collections.Generic;

namespace QLTHUVIEN.Models;

public partial class Phieumuon
{
    public string MaMuon { get; set; } = null!;

    public string MaSach { get; set; } = null!;

    public string MaNv { get; set; } = null!;

    public string MaSv { get; set; } = null!;

    public DateTime? NgayMuon { get; set; }

    public DateTime? NgayTra { get; set; }

    public string? HinhThuc { get; set; }

    public int? SoNgayMuon { get; set; }

    public virtual Nhanvien MaNvNavigation { get; set; } = null!;

    public virtual Sach MaSachNavigation { get; set; } = null!;

    public virtual Sinhvien MaSvNavigation { get; set; } = null!;
}
