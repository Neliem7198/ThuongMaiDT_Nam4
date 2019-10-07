namespace DA_BookStore.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BookStore : DbContext
    {
        public BookStore()
            : base("name=BookStore2")
        {
        }

        public virtual DbSet<CTGIOHANG> CTGIOHANGs { get; set; }
        public virtual DbSet<CTHOADONMUAHANG> CTHOADONMUAHANGs { get; set; }
        public virtual DbSet<CTXEMSACH> CTXEMSACHes { get; set; }
        public virtual DbSet<HOADONMUAHANG> HOADONMUAHANGs { get; set; }
        public virtual DbSet<KHUYENMAI> KHUYENMAIs { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIENs { get; set; }
        public virtual DbSet<NHAXUATBAN> NHAXUATBANs { get; set; }
        public virtual DbSet<PROMOCODE> PROMOCODEs { get; set; }
        public virtual DbSet<QUANGCAO> QUANGCAOs { get; set; }
        public virtual DbSet<SACH> SACHes { get; set; }
        public virtual DbSet<TAIKHOAN> TAIKHOANs { get; set; }
        public virtual DbSet<THELOAI> THELOAIs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CTGIOHANG>()
                .Property(e => e.MaSach)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CTGIOHANG>()
                .Property(e => e.TenTaiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<CTHOADONMUAHANG>()
                .Property(e => e.MaSach)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CTHOADONMUAHANG>()
                .Property(e => e.MaHDMua)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CTXEMSACH>()
                .Property(e => e.MaSach)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CTXEMSACH>()
                .Property(e => e.TenTaiKhoan)
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

            modelBuilder.Entity<NHAXUATBAN>()
                .Property(e => e.MaNhaXuatBan)
                .IsFixedLength()
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

            modelBuilder.Entity<SACH>()
                .Property(e => e.MaSach)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .Property(e => e.SKU)
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .Property(e => e.MaKhuyenMai)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .Property(e => e.MaNhaXuatBan)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .Property(e => e.HinhSach)
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .Property(e => e.MaTL1)
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .Property(e => e.MaTL2)
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .Property(e => e.MaTL3)
                .IsUnicode(false);

            modelBuilder.Entity<SACH>()
                .HasMany(e => e.CTGIOHANGs)
                .WithRequired(e => e.SACH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SACH>()
                .HasMany(e => e.CTHOADONMUAHANGs)
                .WithRequired(e => e.SACH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SACH>()
                .HasMany(e => e.CTXEMSACHes)
                .WithRequired(e => e.SACH)
                .WillCascadeOnDelete(false);

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
                .HasMany(e => e.CTGIOHANGs)
                .WithRequired(e => e.TAIKHOAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TAIKHOAN>()
                .HasMany(e => e.CTXEMSACHes)
                .WithRequired(e => e.TAIKHOAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TAIKHOAN>()
                .HasMany(e => e.HOADONMUAHANGs)
                .WithRequired(e => e.TAIKHOAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TAIKHOAN>()
                .HasOptional(e => e.NHANVIEN)
                .WithRequired(e => e.TAIKHOAN);

            modelBuilder.Entity<THELOAI>()
                .Property(e => e.MaTheLoai)
                .IsUnicode(false);

            modelBuilder.Entity<THELOAI>()
                .HasMany(e => e.SACHes)
                .WithOptional(e => e.THELOAI)
                .HasForeignKey(e => e.MaTL1);

            modelBuilder.Entity<THELOAI>()
                .HasMany(e => e.SACHes1)
                .WithOptional(e => e.THELOAI1)
                .HasForeignKey(e => e.MaTL2);

            modelBuilder.Entity<THELOAI>()
                .HasMany(e => e.SACHes2)
                .WithOptional(e => e.THELOAI2)
                .HasForeignKey(e => e.MaTL3);
        }
    }
}
