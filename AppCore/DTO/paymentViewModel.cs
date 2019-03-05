using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class paymentViewModel
    {
        public int loanId { get; set; }
        public int installmentId { get; set; }
        public DateTime paymentDate { get; set; }
        public double emi { get; set; }
        public double penalty { get; set; }
        public string reason { get; set; }
    }
}
