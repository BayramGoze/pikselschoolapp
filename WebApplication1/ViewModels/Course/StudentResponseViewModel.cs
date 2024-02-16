using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.ViewModels.Course
{
    public class StudentResponseViewModel
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string StudentName { get; set; }

        public DateTime? RecordDate { get; set; }

        public int? CourseId { get; set; }
        public string CourseName { get; set; }

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
        public int? PaymentType { get; set; }
        public string PaymentName { get; set; } = string.Empty;

        public int? InstalmentCount { get; set; }

    }
}