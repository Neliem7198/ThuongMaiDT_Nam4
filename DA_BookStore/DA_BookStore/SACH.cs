namespace DA_BookStore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SACH")]
    public partial class SACH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SACH()
        {
            CTGIOHANGs = new HashSet<CTGIOHANG>();
            CTHOADONMUAHANGs = new HashSet<CTHOADONMUAHANG>();
            CTXEMSACHes = new HashSet<CTXEMSACH>();
        }

        [Key]
        [StringLength(10)]
        public string MaSach { get; set; }

        [Required]
        [StringLength(100)]
        public string TenSach { get; set; }

        [StringLength(20)]
        public string SKU { get; set; }

        [StringLength(10)]
        public string MaKhuyenMai { get; set; }

        [StringLength(10)]
        public string MaNhaXuatBan { get; set; }

        public int? GiaBan { get; set; }

        public int? SoLanTruyCap { get; set; }

        [StringLength(100)]
        public string HinhSach { get; set; }

        public int? SoLuongTon { get; set; }

        [StringLength(50)]
        public string TenTacGia { get; set; }

        public string GioiThieuSach { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayXuatBan { get; set; }

        public bool? HienThiS { get; set; }

        [StringLength(30)]
        public string MaTL1 { get; set; }

        [StringLength(30)]
        public string MaTL2 { get; set; }

        [StringLength(30)]
        public string MaTL3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTGIOHANG> CTGIOHANGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHOADONMUAHANG> CTHOADONMUAHANGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTXEMSACH> CTXEMSACHes { get; set; }

        public virtual KHUYENMAI KHUYENMAI { get; set; }

        public virtual NHAXUATBAN NHAXUATBAN { get; set; }

        public virtual THELOAI THELOAI { get; set; }

        public virtual THELOAI THELOAI1 { get; set; }

        public virtual THELOAI THELOAI2 { get; set; }
    }
}
