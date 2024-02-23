using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.ViewModels.Payment
{
    public class PaymentViewModel
    {
        public int Id { get; set; }
        public int? StudentsId { get; set; }
        public string StudentName { get; set; }
        public DateTime? PaymentDate { get; set; }
        public decimal? Amount { get; set; }
        public int? Installments { get; set; }
        public int? CourseId { get; set; }
        public string CourseName { get; set; }
    }
}