namespace DA_BookStore.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QLPhone : DbContext
    {
        public QLPhone()
            : base("name=QLPhone")
        {
        }

        public virtual DbSet<BINHLUAN> BINHLUANs { get; set; }
        public virtual DbSet<CTGIOHANG> CTGIOHANGs { get; set; }
        public virtual DbSet<CTHOADONMUAHANG> CTHOADONMUAHANGs { get; set; }
        public virtual DbSet<CTXEM> CTXEMs { get; set; }
        public virtual DbSet<DIENTHOAI> DIENTHOAIs { get; set; }
        public virtual DbSet<HANGSANXUAT> HANGSANXUATs { get; set; }
        public virtual DbSet<HOADONMUAHANG> HOADONMUAHANGs { get; set; }
        public virtual DbSet<KHUYENMAI> KHUYENMAIs { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIENs { get; set; }
        public virtual DbSet<PROMOCODE> PROMOCODEs { get; set; }
        public virtual DbSet<QUANGCAO> QUANGCAOs { get; set; }
        public virtual DbSet<TAIKHOAN> TAIKHOANs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BINHLUAN>()
                .Property(e => e.TenTaiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<BINHLUAN>()
                .Property(e => e.MaDienThoai)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CTGIOHANG>()
                .Property(e => e.MaDienThoai)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CTGIOHANG>()
                .Property(e => e.TenTaiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<CTHOADONMUAHANG>()
                .Property(e => e.MaDienThoai)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CTHOADONMUAHANG>()
                .Property(e => e.MaHDMua)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CTXEM>()
                .Property(e => e.MaDienThoai)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CTXEM>()
                .Property(e => e.TenTaiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<DIENTHOAI>()
                .Property(e => e.MaDienThoai)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DIENTHOAI>()
                .Property(e => e.ManHinh)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DIENTHOAI>()
                .Property(e => e.CameraSau)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DIENTHOAI>()
                .Property(e => e.CameraTruoc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DIENTHOAI>()
                .Property(e => e.HeDieuHanh)
                .IsUnicode(false);

            modelBuilder.Entity<DIENTHOAI>()
                .Property(e => e.CPU)
                .IsUnicode(false);

            modelBuilder.Entity<DIENTHOAI>()
                .Property(e => e.MaKhuyenMai)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DIENTHOAI>()
                .Property(e => e.MaHangSanXuat)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DIENTHOAI>()
                .Property(e => e.HinhDienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<DIENTHOAI>()
                .HasMany(e => e.BINHLUANs)
                .WithRequired(e => e.DIENTHOAI)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DIENTHOAI>()
                .HasMany(e => e.CTGIOHANGs)
                .WithRequired(e => e.DIENTHOAI)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DIENTHOAI>()
                .HasMany(e => e.CTHOADONMUAHANGs)
                .WithRequired(e => e.DIENTHOAI)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DIENTHOAI>()
                .HasMany(e => e.CTXEMs)
                .WithRequired(e => e.DIENTHOAI)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HANGSANXUAT>()
                .Property(e => e.MaHangSanXuat)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HANGSANXUAT>()
                .Property(e => e.TenHangSanXuat)
                .IsUnicode(false);

            modelBuilder.Entity<HOADONMUAHANG>()
                .Property(e => e.MaHDMua)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HOADONMUAHANG>()
                .Property(e => e.TenTaiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<HOADONMUAHANG>()
                .Property(e => e.CODE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HOADONMUAHANG>()
                .HasMany(e => e.CTHOADONMUAHANGs)
                .WithRequired(e => e.HOADONMUAHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHUYENMAI>()
                .Property(e => e.MaKhuyenMai)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.TenTaiKhoanNV)
                .IsUnicode(false);

            modelBuilder.Entity<PROMOCODE>()
                .Property(e => e.CODE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<QUANGCAO>()
                .Property(e => e.MaQuangCao)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<QUANGCAO>()
                .Property(e => e.LinkQC)
                .IsUnicode(false);

            modelBuilder.Entity<QUANGCAO>()
                .Property(e => e.HinhQC)
                .IsUnicode(false);

            modelBuilder.Entity<QUANGCAO>()
                .Property(e => e.SdtChuQC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<QUANGCAO>()
                .Property(e => e.EmailChuQC)
                .IsUnicode(false);

            modelBuilder.Entity<QUANGCAO>()
                .Property(e => e.LoaiQC)
                .IsUnicode(false);

            modelBuilder.Entity<QUANGCAO>()
                .Property(e => e.ViTriQuangCao)
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.TenTaiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.MauKhau)
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.Sdt)
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .HasMany(e => e.BINHLUANs)
                .WithRequired(e => e.TAIKHOAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TAIKHOAN>()
                .HasMany(e => e.CTGIOHANGs)
                .WithRequired(e => e.TAIKHOAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TAIKHOAN>()
                .HasMany(e => e.CTXEMs)
                .WithRequired(e => e.TAIKHOAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TAIKHOAN>()
                .HasMany(e => e.HOADONMUAHANGs)
                .WithRequired(e => e.TAIKHOAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TAIKHOAN>()
                .HasOptional(e => e.NHANVIEN)
                .WithRequired(e => e.TAIKHOAN);
        }
    }
}
