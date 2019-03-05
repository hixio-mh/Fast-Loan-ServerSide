using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FwCore.DBContext.Model
{
    public class LoanType
    {
        public int LoanTypeId { get; set; }
        
        public string LoanTypeName { get; set; }
        
        public double InterestRate { get; set; }
      
        public int NoOfInstallment { get; set; }
   
        public double LoanAmount { get; set; }


    }
}
