namespace DA_BookStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BINHLUAN")]
    public partial class BINHLUAN
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string TenTaiKhoan { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MaDienThoai { get; set; }

        public string NoiDung { get; set; }

        public virtual DIENTHOAI DIENTHOAI { get; set; }

        public virtual TAIKHOAN TAIKHOAN { get; set; }
    }
}
