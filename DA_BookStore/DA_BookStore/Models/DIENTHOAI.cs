namespace DA_BookStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DIENTHOAI")]
    public partial class DIENTHOAI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DIENTHOAI()
        {
            BINHLUANs = new HashSet<BINHLUAN>();
            CTGIOHANGs = new HashSet<CTGIOHANG>();
            CTHOADONMUAHANGs = new HashSet<CTHOADONMUAHANG>();
            CTXEMs = new HashSet<CTXEM>();
        }

        [Key]
        [StringLength(10)]
        public string MaDienThoai { get; set; }

        [Required]
        [StringLength(100)]
        public string TenDienThoai { get; set; }

        [StringLength(15)]
        public string ManHinh { get; set; }

        [StringLength(5)]
        public string CameraSau { get; set; }

        [StringLength(5)]
        public string CameraTruoc { get; set; }

        [StringLength(50)]
        public string HeDieuHanh { get; set; }

        [StringLength(50)]
        public string CPU { get; set; }

        [StringLength(10)]
        public string MaKhuyenMai { get; set; }

        [StringLength(10)]
        public string MaHangSanXuat { get; set; }

        public int? GiaBan { get; set; }

        public int? SoLanTruyCap { get; set; }

        [StringLength(100)]
        public string HinhDienThoai { get; set; }

        public int? SoLuongTon { get; set; }

        public string GioiThieuDienThoai { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayPhatHanh { get; set; }

        public bool? HienThiDT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BINHLUAN> BINHLUANs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTGIOHANG> CTGIOHANGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHOADONMUAHANG> CTHOADONMUAHANGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTXEM> CTXEMs { get; set; }

        public virtual HANGSANXUAT HANGSANXUAT { get; set; }

        public virtual KHUYENMAI KHUYENMAI { get; set; }
    }
}
