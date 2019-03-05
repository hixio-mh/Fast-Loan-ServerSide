using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTO
{
    public class LoginViewModel
    {
        //User Name
        [Required(ErrorMessage = "User Name is Required.")]
        public string UserName { get; set; }


        //Passward
        [Required(ErrorMessage = "Password is Required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }//c

    public class RegisterViewModel
    {
        //public string Id { get; set; }
        [Required(ErrorMessage = "First Name is Required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required.")]
        public string LastName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is Required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "User Name is Required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is Required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }//c

    public class UserViewModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "First Name is Required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "User Name is Required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is Required.")]
        [EmailAddress(ErrorMessage = "Email is not valid.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Password is Required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is Required.")]
        [Compare("Password", ErrorMessage = "Password not match.")]
        public string ConfirmPassword { get; set; }

        public List<string> Roles { get; set; }
    }//c


}//ns
