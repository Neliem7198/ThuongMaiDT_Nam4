namespace DA_BookStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PROMOCODE")]
    public partial class PROMOCODE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PROMOCODE()
        {
            HOADONMUAHANGs = new HashSet<HOADONMUAHANG>();
        }

        [Key]
        [StringLength(10)]
        public string CODE { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayThem { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayHetHan { get; set; }

        public int? SoTienGiam { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADONMUAHANG> HOADONMUAHANGs { get; set; }
    }
}
