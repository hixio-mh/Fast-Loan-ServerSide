using System;
using System.Collections.Generic;
using System.Text;

namespace FwCore.DBContext.Model
{
    public class LoanInstallment
    {
        public int LoanInstallmentId { get; set; }
        public double EMI { get; set; }
        public DateTime ScheduleDate { get; set; }
        public DateTime ActualPayDate { get; set;}
        public double Penalty { get; set; }
        public double PayAmount { get; set; }
        public string Reason { get; set; }
        
    }
}
