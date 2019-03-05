using System;
using System.Collections.Generic;
using System.Text;

namespace FwCore.DBContext.Model
{
    public class Loan
    {
        public int LoanId { get; set; }
        public virtual LoanType LoanType { get; set; }
        public virtual User User { get; set; }
        public virtual Status Status { get; set; }
        public virtual Granter Granter { get; set; }
        public virtual Document Document { get; set; }

        public string ApprovedBy { get; set; }
        public string OperateBy { get; set; }
        public DateTime IssueDate { get; set; }
        public virtual List<LoanInstallment> LoanInstallments { get; set; }
    }
}
