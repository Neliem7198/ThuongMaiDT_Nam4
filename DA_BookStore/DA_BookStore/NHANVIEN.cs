namespace DA_BookStore
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHANVIEN")]
    public partial class NHANVIEN
    {
        [Key]
        [StringLength(50)]
        public string TenTaiKhoanNV { get; set; }

        [StringLength(20)]
        public string ChucVuNV { get; set; }

        public bool? HienThiNV { get; set; }

        public virtual TAIKHOAN TAIKHOAN { get; set; }
    }
}
