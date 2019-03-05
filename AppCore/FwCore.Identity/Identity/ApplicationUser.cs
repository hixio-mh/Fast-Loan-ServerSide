using FwCore.Identity.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FwCore.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base() { }

        //[Required(ErrorMessage = "First Name is Required.")]
        public string FirstName { get; set; }

        //[Required(ErrorMessage = "Last Name is Required.")]
        public string LastName { get; set; }
        
        public string PresentAddress { get; set; }
        
        public string PermanentAddress { get; set; }
        
        public string City { get; set; }
        
        public string State { get; set; }
        
        public string ZipCode { get; set; }
        
        public string Country { get; set; }
        
        public string Nationality { get; set; }
       
        public string Gender { get; set; }
        
        public string Religion { get; set; }
     
        public string Mobile { get; set; }

        public virtual List<LoanManage> LoanManage { get; set; }



    }
}
