namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Instructors
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string InstructorName { get; set; }

        [StringLength(50)]
        public string InstructorExpert { get; set; }

        [StringLength(50)]
        public string InstructorAge { get; set; }

        public bool Deleted { get; set; }

        public int UserId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UpdateDate { get; set; }
    }
}
