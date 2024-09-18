using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QLTHUVIEN.Models;

public partial class QltvContext : DbContext
{
    public QltvContext()
    {
    }

    public QltvContext(DbContextOptions<QltvContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Chucnang> Chucnangs { get; set; }

    public virtual DbSet<Nhanvien> Nhanviens { get; set; }

    public virtual DbSet<Nxb> Nxbs { get; set; }

    public virtual DbSet<Phieumuon> Phieumuons { get; set; }

    public virtual DbSet<Sach> Saches { get; set; }

    public virtual DbSet<Sinhvien> Sinhviens { get; set; }

    public virtual DbSet<Tacgium> Tacgia { get; set; }

    public virtual DbSet<Theloai> Theloais { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vitri> Vitris { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=localhost;Database=qltv;User=root;Password=020403;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chucnang>(entity =>
        {
            entity.HasKey(e => e.MaChucNang).HasName("PRIMARY");

            entity.ToTable("chucnang");

            entity.Property(e => e.ChucVu).HasMaxLength(255);
        });

        modelBuilder.Entity<Nhanvien>(entity =>
        {
            entity.HasKey(e => e.MaNv).HasName("PRIMARY");

            entity.ToTable("nhanvien");

            entity.Property(e => e.MaNv)
                .HasMaxLength(50)
                .HasColumnName("MaNV");
            entity.Property(e => e.DiaChi).HasMaxLength(500);
            entity.Property(e => e.GioiTinh).HasMaxLength(10);
            entity.Property(e => e.NgaySinh).HasColumnType("date");
            entity.Property(e => e.Sdt)
                .HasMaxLength(20)
                .HasColumnName("SDT");
            entity.Property(e => e.TenNv)
                .HasMaxLength(50)
                .HasColumnName("TenNV");
        });

        modelBuilder.Entity<Nxb>(entity =>
        {
            entity.HasKey(e => e.MaNxb).HasName("PRIMARY");

            entity.ToTable("nxb");

            entity.Property(e => e.MaNxb)
                .HasMaxLength(20)
                .HasColumnName("MaNXB");
            entity.Property(e => e.DiaChi).HasMaxLength(150);
            entity.Property(e => e.Gmail).HasMaxLength(150);
            entity.Property(e => e.TenNxb)
                .HasMaxLength(150)
                .HasColumnName("TenNXB");
        });

        modelBuilder.Entity<Phieumuon>(entity =>
        {
            entity.HasKey(e => new { e.MaMuon, e.MaSach }).HasName("PRIMARY");

            entity.ToTable("phieumuon");

            entity.HasIndex(e => e.MaNv, "MaNV");

            entity.HasIndex(e => e.MaSv, "MaSV");

            entity.HasIndex(e => e.MaSach, "MaSach");

            entity.Property(e => e.MaMuon).HasMaxLength(50);
            entity.Property(e => e.MaSach).HasMaxLength(20);
            entity.Property(e => e.HinhThuc).HasMaxLength(150);
            entity.Property(e => e.MaNv)
                .HasMaxLength(50)
                .HasColumnName("MaNV");
            entity.Property(e => e.MaSv)
                .HasMaxLength(20)
                .HasColumnName("MaSV");
            entity.Property(e => e.NgayMuon).HasColumnType("datetime");
            entity.Property(e => e.NgayTra).HasColumnType("datetime");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.Phieumuons)
                .HasForeignKey(d => d.MaNv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("phieumuon_ibfk_1");

            entity.HasOne(d => d.MaSachNavigation).WithMany(p => p.Phieumuons)
                .HasForeignKey(d => d.MaSach)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("phieumuon_ibfk_3");

            entity.HasOne(d => d.MaSvNavigation).WithMany(p => p.Phieumuons)
                .HasForeignKey(d => d.MaSv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("phieumuon_ibfk_2");
        });

        modelBuilder.Entity<Sach>(entity =>
        {
            entity.HasKey(e => e.MaSach).HasName("PRIMARY");

            entity.ToTable("sach");

            entity.HasIndex(e => e.MaNxb, "MaNXB");

            entity.HasIndex(e => e.MaTacGia, "MaTacGia");

            entity.Property(e => e.MaSach).HasMaxLength(20);
            entity.Property(e => e.MaNxb)
                .HasMaxLength(20)
                .HasColumnName("MaNXB");
            entity.Property(e => e.MaTacGia).HasMaxLength(20);
            entity.Property(e => e.MaTheLoai).HasMaxLength(20);
            entity.Property(e => e.MaViTri).HasMaxLength(20);
            entity.Property(e => e.NamXb).HasColumnName("NamXB");
            entity.Property(e => e.NgonNgu).HasMaxLength(150);
            entity.Property(e => e.TenSach).HasMaxLength(150);

            entity.HasOne(d => d.MaNxbNavigation).WithMany(p => p.Saches)
                .HasForeignKey(d => d.MaNxb)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sach_ibfk_1");

            entity.HasOne(d => d.MaTacGiaNavigation).WithMany(p => p.Saches)
                .HasForeignKey(d => d.MaTacGia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sach_ibfk_2");
        });

        modelBuilder.Entity<Sinhvien>(entity =>
        {
            entity.HasKey(e => e.MaSv).HasName("PRIMARY");

            entity.ToTable("sinhvien");

            entity.Property(e => e.MaSv)
                .HasMaxLength(20)
                .HasColumnName("MaSV");
            entity.Property(e => e.HoTen).HasMaxLength(150);
            entity.Property(e => e.Lop).HasMaxLength(150);
        });

        modelBuilder.Entity<Tacgium>(entity =>
        {
            entity.HasKey(e => e.MaTacGia).HasName("PRIMARY");

            entity.ToTable("tacgia");

            entity.Property(e => e.MaTacGia).HasMaxLength(20);
            entity.Property(e => e.DiaChi).HasMaxLength(250);
            entity.Property(e => e.TenTacGia).HasMaxLength(150);
            entity.Property(e => e.TimeCreate).HasColumnType("datetime");
            entity.Property(e => e.TimeUpdate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Theloai>(entity =>
        {
            entity.HasKey(e => e.MaTheLoai).HasName("PRIMARY");

            entity.ToTable("theloai");

            entity.Property(e => e.MaTheLoai).HasMaxLength(50);
            entity.Property(e => e.TenTheLoai).HasMaxLength(255);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Username).HasName("PRIMARY");

            entity.ToTable("user");

            entity.HasIndex(e => e.MaNv, "MaNV");

            entity.Property(e => e.Username).HasMaxLength(50);
            entity.Property(e => e.MaNv)
                .HasMaxLength(50)
                .HasColumnName("MaNV");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsFixedLength();

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.MaNv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_ibfk_1");
        });

        modelBuilder.Entity<Vitri>(entity =>
        {
            entity.HasKey(e => e.MaViTri).HasName("PRIMARY");

            entity.ToTable("vitri");

            entity.Property(e => e.MaViTri).HasMaxLength(20);
            entity.Property(e => e.Ke).HasMaxLength(150);
            entity.Property(e => e.Khu).HasMaxLength(150);
            entity.Property(e => e.Ngan).HasMaxLength(150);
            entity.Property(e => e.TimeCreate).HasColumnType("datetime");
            entity.Property(e => e.TimeUpdate).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
