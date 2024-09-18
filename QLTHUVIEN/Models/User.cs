using System;
using System.Collections.Generic;

namespace QLTHUVIEN.Models;

public partial class User
{
    public string Username { get; set; } = null!;

    public string MaNv { get; set; } = null!;

    public string? Password { get; set; }

    public virtual Nhanvien MaNvNavigation { get; set; } = null!;
}
