namespace DA_BookStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TAIKHOAN")]
    public partial class TAIKHOAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TAIKHOAN()
        {
            BINHLUANs = new HashSet<BINHLUAN>();
            CTGIOHANGs = new HashSet<CTGIOHANG>();
            CTXEMs = new HashSet<CTXEM>();
            HOADONMUAHANGs = new HashSet<HOADONMUAHANG>();
        }

        [Key]
        [StringLength(50)]
        public string TenTaiKhoan { get; set; }

        [Required]
        [StringLength(200)]
        public string MauKhau { get; set; }

        [StringLength(50)]
        public string HoTen { get; set; }

        [Required]
        [StringLength(10)]
        public string Sdt { get; set; }

        [Required]
        [StringLength(100)]
        public string DiaChi { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public bool? GioiTinh { get; set; }

        public bool? HienThiTK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BINHLUAN> BINHLUANs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTGIOHANG> CTGIOHANGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTXEM> CTXEMs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADONMUAHANG> HOADONMUAHANGs { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
