using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using WebApplication1.ViewModels.Course;

namespace WebApplication1.ViewModels.Payment
{
    public class PaymentResponseViewModel
    {
        public List<StudentResponseViewModel> Students { get; set; }
        public List<PaymentViewModel>Payments { get; set; }
        public List<UpdatePaymentViewModel> UpdatePayments { get; set; }
    }
}