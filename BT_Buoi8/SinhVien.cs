namespace BT_Buoi8
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SinhVien")]
    public partial class SinhVien
    {
        [Key]
        [StringLength(10)]
        public string MaSV { get; set; }

        [StringLength(100)]
        public string TenSV { get; set; }

        [StringLength(50)]
        public string Khoa { get; set; }

        public decimal? DiemTB { get; set; }
    }
}
