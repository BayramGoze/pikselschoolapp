namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Students
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string StudentName { get; set; }

        public DateTime? RecordDate { get; set; }

        public int? CourseId { get; set; }

        public decimal? CourseAmount { get; set; }

        [StringLength(50)]
        public string Telephone { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(11)]
        public string IdentityNumber { get; set; }

        public string Adress { get; set; }

        public string Education { get; set; }

        public int? PaymentDay { get; set; }

        public DateTime? Birthday { get; set; }

        public string Image { get; set; }

        public bool Deleted { get; set; }

        public int? PaymentType { get; set; }

        public int? InstalmentCount { get; set; }

        public int UserId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UpdateDate { get; set; }
    }
}
