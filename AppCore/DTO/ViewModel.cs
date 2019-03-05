﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTO
{
    public class ViewModel
    {
        public LoanTypeInfo submittedLoanInfo { get; set; }

        public UserInfo submittedPersonalInfo { get; set; }

        public UserInfo submittedGranterInfo { get; set; }
    }


    public class LoanTypeInfo

    {
        [Required]
        public string LoanTypeName { get; set; }
        [Required]
        public double InterestRate { get; set; }
        [Required]
        public int NoOfInstallment { get; set; }

    }

    public class UserInfo

    {
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

        public string Relation { get; set; }

        [Required]
        public string Mobile { get; set; }
        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public string VerificationType { get; set; }
        [Required]
        public string VerificationCode { get; set; }
    }
}
