using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FwCore.DBContext.Model
{
   public class Granter
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GranterId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FatherName { get; set; }
        [Required]
        public string MotherName { get; set; }
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

        [Required]
        public string Relation { get; set; }

        [Required]
        public string Mobile { get; set; }
        [Required]
        public string EmailAddress { get; set; }

        public virtual VerificationSource Verification { get; set; }

        //public int LoanId { get; set; }
        //public virtual Loan Loan { get; set; }
    }
}
