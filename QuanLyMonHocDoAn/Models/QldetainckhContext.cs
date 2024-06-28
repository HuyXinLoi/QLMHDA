using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QuanLyMonHocDoAn.Models;

public partial class QldetainckhContext : DbContext
{

    public QldetainckhContext(DbContextOptions options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Bienbanchamdecuong> Bienbanchamdecuongs { get; set; }

    public virtual DbSet<Bienbannghiemthu> Bienbannghiemthus { get; set; }

    public virtual DbSet<Chitietdonxingiahan> Chitietdonxingiahans { get; set; }

    public virtual DbSet<Chitiethoidongdecuong> Chitiethoidongdecuongs { get; set; }

    public virtual DbSet<Chitiethoidongnghiemthu> Chitiethoidongnghiemthus { get; set; }

    public virtual DbSet<Chitietnhom> Chitietnhoms { get; set; }

    public virtual DbSet<Chuongtrinh> Chuongtrinhs { get; set; }

    public virtual DbSet<Dangky> Dangkies { get; set; }

    public virtual DbSet<Detai> Detais { get; set; }

    public virtual DbSet<Donxingiahan> Donxingiahans { get; set; }

    public virtual DbSet<Giangvien> Giangviens { get; set; }

    public virtual DbSet<Hoidongduyetdecuong> Hoidongduyetdecuongs { get; set; }

    public virtual DbSet<Hoidongnghiemthu> Hoidongnghiemthus { get; set; }

    public virtual DbSet<Khoa> Khoas { get; set; }

    public virtual DbSet<Nganh> Nganhs { get; set; }

    public virtual DbSet<Nhom> Nhoms { get; set; }

    public virtual DbSet<Sinhvien> Sinhviens { get; set; }

    public virtual DbSet<ThongBaoChamLai> ThongBaoChamLais { get; set; }

    public virtual DbSet<Thongbao> Thongbaos { get; set; }

    public virtual DbSet<Trangthai> Trangthais { get; set; }

    public virtual DbSet<Typeaccount> Typeaccounts { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.MaAccount).HasName("PK__ACCOUNT__0A2B8E3443ADF5D7");

            entity.ToTable("ACCOUNT");

            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.HoVaTen).HasMaxLength(50);
            entity.Property(e => e.Pass)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.MaTypeAccountNavigation).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.MaTypeAccount)
                .HasConstraintName("FK__ACCOUNT__MaTypeA__60A75C0F");
        });

        modelBuilder.Entity<Bienbanchamdecuong>(entity =>
        {
            entity.HasKey(e => e.IdbienBan).HasName("PK__BIENBANC__61A114E2EED07913");

            entity.ToTable("BIENBANCHAMDECUONG");

            entity.Property(e => e.IdbienBan).HasColumnName("IDBienBan");
            entity.Property(e => e.MinhChung).HasMaxLength(255);
        });

        modelBuilder.Entity<Bienbannghiemthu>(entity =>
        {
            entity.HasKey(e => e.IdbienBan).HasName("PK__BIENBANN__D0123202EAFC80F7");

            entity.ToTable("BIENBANNGHIEMTHU");

            entity.Property(e => e.IdbienBan).HasColumnName("IDBienBan");
            entity.Property(e => e.LinkBienBan).HasMaxLength(250);

            entity.HasOne(d => d.MaDeTaiNavigation).WithMany(p => p.Bienbannghiemthus)
                .HasForeignKey(d => d.MaDeTai)
                .HasConstraintName("FK__BIENBANNG__MaDeT__4BAC3F29");

            entity.HasOne(d => d.MaHoiDongNavigation).WithMany(p => p.Bienbannghiemthus)
                .HasForeignKey(d => d.MaHoiDong)
                .HasConstraintName("FK__BIENBANNG__MaHoi__4CA06362");
        });

        modelBuilder.Entity<Chitietdonxingiahan>(entity =>
        {
            entity.HasKey(e => e.MaCtdxgh).HasName("PK__CHITIETD__79A1495864A38662");

            entity.ToTable("CHITIETDONXINGIAHAN");

            entity.Property(e => e.MaCtdxgh)
                .ValueGeneratedNever()
                .HasColumnName("MaCTDXGH");
        });

        modelBuilder.Entity<Chitiethoidongdecuong>(entity =>
        {
            entity.HasKey(e => e.Idct);

            entity.ToTable("CHITIETHOIDONGDECUONG", tb => tb.HasTrigger("SuaTV"));

            entity.Property(e => e.Idct).HasColumnName("IDCT");
        });

        modelBuilder.Entity<Chitiethoidongnghiemthu>(entity =>
        {
            entity.HasKey(e => e.Idct);

            entity.ToTable("CHITIETHOIDONGNGHIEMTHU", tb => tb.HasTrigger("SuaTVNT"));

            entity.Property(e => e.Idct).HasColumnName("IDCT");
        });

        modelBuilder.Entity<Chitietnhom>(entity =>
        {
            entity.HasKey(e => e.IdCtnhom);

            entity.ToTable("CHITIETNHOM");

            entity.Property(e => e.IdCtnhom).HasColumnName("IdCTNhom");
            entity.Property(e => e.HoTen).HasMaxLength(50);
            entity.Property(e => e.IddangKy).HasColumnName("IDDangKy");
            entity.Property(e => e.MaNhom)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.MaSoSinhVien)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Chuongtrinh>(entity =>
        {
            entity.HasKey(e => e.MaCt);

            entity.ToTable("CHUONGTRINH");

            entity.Property(e => e.MaCt)
                .HasMaxLength(10)
                .HasColumnName("MaCT");
            entity.Property(e => e.TenCt)
                .HasMaxLength(50)
                .HasColumnName("TenCT");
        });

        modelBuilder.Entity<Dangky>(entity =>
        {
            entity.HasKey(e => e.IddangKy).HasName("PK__DANGKY__735660836B7DE7F7");

            entity.ToTable("DANGKY");

            entity.Property(e => e.IddangKy).HasColumnName("IDDangKy");
            entity.Property(e => e.LinkDeCuong).HasMaxLength(150);
            entity.Property(e => e.MaNhom)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.MaSoSinhVien)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NgayDangKy).HasColumnType("datetime");
            entity.Property(e => e.TrangThai).HasDefaultValue(1);
        });

        modelBuilder.Entity<Detai>(entity =>
        {
            entity.HasKey(e => e.MaDeTai).HasName("PK__DETAI__9F967D5BB67B2C6A");

            entity.ToTable("DETAI");

            entity.Property(e => e.KetQua).HasMaxLength(10);
            entity.Property(e => e.KinhPhiDuKien).HasColumnType("money");
            entity.Property(e => e.MaNganh).HasMaxLength(10);
            entity.Property(e => e.MaNhom)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.MaSoSinhVien)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NgayKetThuc).HasColumnType("datetime");
            entity.Property(e => e.NgayThucHien).HasColumnType("datetime");
            entity.Property(e => e.TenDeTai).HasMaxLength(255);

            entity.HasOne(d => d.MaGiangVienNavigation).WithMany(p => p.Detais)
                .HasForeignKey(d => d.MaGiangVien)
                .HasConstraintName("FK__DETAI__MaGiangVi__5EBF139D");

            entity.HasOne(d => d.MaHoiDongNavigation).WithMany(p => p.Detais)
                .HasForeignKey(d => d.MaHoiDong)
                .HasConstraintName("FK__DETAI__MaHoiDong__4E88ABD4");

            entity.HasOne(d => d.MaNganhNavigation).WithMany(p => p.Detais)
                .HasForeignKey(d => d.MaNganh)
                .HasConstraintName("FK__DETAI__MaNganh__4F7CD00D");

            entity.HasOne(d => d.MaTrangThaiNavigation).WithMany(p => p.Detais)
                .HasForeignKey(d => d.MaTrangThai)
                .HasConstraintName("FK__DETAI__MaTrangTh__5070F446");
        });

        modelBuilder.Entity<Donxingiahan>(entity =>
        {
            entity.HasKey(e => e.MaDonXinGiaHan).HasName("PK__DONXINGI__CD4EFD9BDCF17B9F");

            entity.ToTable("DONXINGIAHAN");

            entity.Property(e => e.MaDonXinGiaHan).ValueGeneratedNever();
            entity.Property(e => e.MaCtdxgh).HasColumnName("MaCTDXGH");

            entity.HasOne(d => d.MaCtdxghNavigation).WithMany(p => p.Donxingiahans)
                .HasForeignKey(d => d.MaCtdxgh)
                .HasConstraintName("FK__DONXINGIA__MaCTD__6754599E");

            entity.HasOne(d => d.MaDeTaiNavigation).WithMany(p => p.Donxingiahans)
                .HasForeignKey(d => d.MaDeTai)
                .HasConstraintName("FK__DONXINGIA__MaDeT__52593CB8");

            entity.HasOne(d => d.MaGiangVienNavigation).WithMany(p => p.Donxingiahans)
                .HasForeignKey(d => d.MaGiangVien)
                .HasConstraintName("FK__DONXINGIA__MaGia__6477ECF3");
        });

        modelBuilder.Entity<Giangvien>(entity =>
        {
            entity.HasKey(e => e.MaGiangVien).HasName("PK__GIANGVIE__C03BEEBAEF35B90B");

            entity.ToTable("GIANGVIEN");

            entity.Property(e => e.Gmail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MaCt)
                .HasMaxLength(50)
                .HasColumnName("MaCT");
            entity.Property(e => e.MaKhoa).HasMaxLength(10);
            entity.Property(e => e.MaSoGiangVien)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Nganh).HasMaxLength(10);
            entity.Property(e => e.TenGiangVien).HasMaxLength(255);
            entity.Property(e => e.TrinhDo).HasMaxLength(50);
        });

        modelBuilder.Entity<Hoidongduyetdecuong>(entity =>
        {
            entity.HasKey(e => e.MaHoiDong).HasName("PK__HOIDONGD__998808B357E61839");

            entity.ToTable("HOIDONGDUYETDECUONG");

            entity.Property(e => e.MaCt)
                .HasMaxLength(10)
                .HasColumnName("MaCT");
            entity.Property(e => e.MaKhoa).HasMaxLength(10);
            entity.Property(e => e.SoLuongTv).HasColumnName("SoLuongTV");
            entity.Property(e => e.TenHoiDong).HasMaxLength(50);
        });

        modelBuilder.Entity<Hoidongnghiemthu>(entity =>
        {
            entity.HasKey(e => e.MaHoiDong).HasName("PK__HOIDONGN__998808B3C1A427BD");

            entity.ToTable("HOIDONGNGHIEMTHU");

            entity.Property(e => e.MaCt)
                .HasMaxLength(10)
                .HasColumnName("MaCT");
            entity.Property(e => e.MaKhoa).HasMaxLength(10);
            entity.Property(e => e.NgayNghiemThu).HasColumnType("datetime");
            entity.Property(e => e.SoLuongTv).HasColumnName("SoLuongTV");
            entity.Property(e => e.TenHoiDong).HasMaxLength(50);

            entity.HasOne(d => d.MaKhoaNavigation).WithMany(p => p.Hoidongnghiemthus)
                .HasForeignKey(d => d.MaKhoa)
                .HasConstraintName("FK__HOIDONGNG__MaKho__5629CD9C");
        });

        modelBuilder.Entity<Khoa>(entity =>
        {
            entity.HasKey(e => e.MaKhoa).HasName("PK__KHOA__653904057D92585F");

            entity.ToTable("KHOA");

            entity.Property(e => e.MaKhoa).HasMaxLength(10);
            entity.Property(e => e.TenKhoa).HasMaxLength(1000);
        });

        modelBuilder.Entity<Nganh>(entity =>
        {
            entity.HasKey(e => e.MaNganh).HasName("PK__NGANH__A2CEF50DA21238F5");

            entity.ToTable("NGANH");

            entity.Property(e => e.MaNganh).HasMaxLength(10);
            entity.Property(e => e.MaCt)
                .HasMaxLength(50)
                .HasColumnName("MaCT");
            entity.Property(e => e.MaKhoa).HasMaxLength(10);
            entity.Property(e => e.TenNganh).HasMaxLength(1000);

            entity.HasOne(d => d.MaKhoaNavigation).WithMany(p => p.Nganhs)
                .HasForeignKey(d => d.MaKhoa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NGANH__MaKhoa__59063A47");
        });

        modelBuilder.Entity<Nhom>(entity =>
        {
            entity.HasKey(e => e.MaNhom).HasName("PK__NHOM__234F91CDCE31D14F");

            entity.ToTable("NHOM");

            entity.Property(e => e.MaNhom)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TenNhom)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)");
        });

        modelBuilder.Entity<Sinhvien>(entity =>
        {
            entity.HasKey(e => e.MaSinhVien);

            entity.ToTable("SINHVIEN");

            entity.Property(e => e.Cccd)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CCCD");
            entity.Property(e => e.ChiNhanhNganHang).HasMaxLength(150);
            entity.Property(e => e.DiaChi).HasMaxLength(150);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.HoTen).HasMaxLength(50);
            entity.Property(e => e.Lop).HasMaxLength(100);
            entity.Property(e => e.MaNganh).HasMaxLength(10);
            entity.Property(e => e.MaSoSinhVien)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NienKhoa)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Sdt)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SDT");
            entity.Property(e => e.TknganHang)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TKNganHang");

            entity.HasOne(d => d.MaAccountNavigation).WithMany(p => p.Sinhviens)
                .HasForeignKey(d => d.MaAccount)
                .HasConstraintName("FK__SINHVIEN__MaAcco__571DF1D5");
        });

        modelBuilder.Entity<ThongBaoChamLai>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ThongBaoChamLai");

            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Thongbao).HasColumnType("ntext");
        });

        modelBuilder.Entity<Thongbao>(entity =>
        {
            entity.ToTable("THONGBAO");

            entity.Property(e => e.NoiDungTb).HasColumnType("ntext");
            entity.Property(e => e.TenThongBao).HasMaxLength(50);
        });

        modelBuilder.Entity<Trangthai>(entity =>
        {
            entity.HasKey(e => e.MaTrangThai).HasName("PK__TRANGTHA__AADE4138B751F8C7");

            entity.ToTable("TRANGTHAI");

            entity.Property(e => e.TenTrangThai).HasMaxLength(50);
        });

        modelBuilder.Entity<Typeaccount>(entity =>
        {
            entity.HasKey(e => e.MaTypeAccount).HasName("PK__TYPEACCO__4CA6144FEF9249B0");

            entity.ToTable("TYPEACCOUNT");

            entity.Property(e => e.TenTypeAccount)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

    }

}
