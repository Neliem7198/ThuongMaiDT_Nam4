namespace DA_BookStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HANGSANXUAT")]
    public partial class HANGSANXUAT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HANGSANXUAT()
        {
            DIENTHOAIs = new HashSet<DIENTHOAI>();
        }

        [Key]
        [StringLength(10)]
        public string MaHangSanXuat { get; set; }

        [StringLength(50)]
        public string TenHangSanXuat { get; set; }

        public bool? HienThiTL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DIENTHOAI> DIENTHOAIs { get; set; }
    }
}
