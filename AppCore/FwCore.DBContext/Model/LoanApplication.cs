using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FwCore.DBContext.Model
{
    public class LoanApplication
    {
        
        public int LoanApplicationId { get; set; }
        [Required]
        public string LoanType { get; set; }
        [Required]
        public double LoanAmount { get; set; }
        [Required]
        public int Installments { get; set; }


        [Required]
        public string UserFirstName { get; set; }
        [Required]
        public string UserLastName { get; set; }
        [Required]
        public string UserFatherName { get; set; }
        [Required]
        public string UserMotherName { get; set; }
        [Required]
        public string UserPresentAddress { get; set; }
        [Required]
        public string UserPermanentAddress { get; set; }
        [Required]
        public string UserCity { get; set; }
        [Required]
        public string UserState { get; set; }
        [Required]
        public string UserZipCode { get; set; }
        [Required]
        public string UserCountry { get; set; }
        [Required]
        public string UserNationality { get; set; }
        [Required]
        public string UserOccupation { get; set; }

        [Required]
        public DateTime UserDateOfBirth { get; set; }
        [Required]
        public string UserGender { get; set; }
        [Required]
        public string UserReligion { get; set; }

        [Required]
        public string UserMobile { get; set; }
        [Required]
        public string UserEmailAddress { get; set; }
        [Required]
        public string UserVerificationType { get; set; }
        [Required]
        public string UserVerificationCode { get; set; }

        [Required]
        public string GranterFirstName { get; set; }
        [Required]
        public string GranterLastName { get; set; }
        [Required]
        public string GranterFatherName { get; set; }
        [Required]
        public string GranterMotherName { get; set; }
        [Required]
        public string GranterPresentAddress { get; set; }
        [Required]
        public string GranterPermanentAddress { get; set; }
        [Required]
        public string GranterCity { get; set; }
        [Required]
        public string GranterState { get; set; }
        [Required]
        public string GranterZipCode { get; set; }
        [Required]
        public string GranterCountry { get; set; }
        [Required]
        public string GranterNationality { get; set; }
        [Required]
        public string GranterOccupation { get; set; }

        [Required]
        public DateTime GranterDateOfBirth { get; set; }
        [Required]
        public string GranterGender { get; set; }
        [Required]
        public string GranterReligion { get; set; }

        [Required]
        public string GranterRelation { get; set; }

        [Required]
        public string GranterMobile { get; set; }
        [Required]
        public string GranterEmailAddress { get; set; }
        [Required]
        public string GranterVerificationType { get; set; }
        [Required]
        public string GranterVerificationCode { get; set; }


    }
}
