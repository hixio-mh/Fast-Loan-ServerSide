using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTO
{
    public class ApplyLoanViewModel
    {
        public LoanTypeInfo submittedLoanInfo { get; set; }

        public UserInfo submittedPersonalInfo { get; set; }

        public UserInfo submittedGranterInfo { get; set; }

    }

    public class LoanTypeInfo

    {
        [Required]
        public string LoanType { get; set; }
        [Required]
        public int LoanAmount { get; set; }
        [Required]
        public int Installments { get; set; }

    }

    public class UserInfo

    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FathersName { get; set; }
        [Required]
        public string MothersName { get; set; }
        [Required]
        public string PresentAddress { get; set; }
        [Required]
        public string PermanentAddress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Nationality { get; set; }
        [Required]
        public string Occupation { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Religion { get; set; }

        public string Relation { get; set; }

        [Required]
        public string MobileNo { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        public string VerificationIdType { get; set; }
        [Required]
        public string VerificationIdNo { get; set; }
    }
}
