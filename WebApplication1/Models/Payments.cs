namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Payments
    {
        public int Id { get; set; }

        public int? StudentsId { get; set; }

        public decimal? Amount { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PaymentDate { get; set; }

        public int? Installments { get; set; }

        public bool Deleted { get; set; }

        public int? CourseId { get; set; }

        public int UserId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UpdateDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }
    }
}
