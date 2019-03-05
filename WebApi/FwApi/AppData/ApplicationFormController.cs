using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DTO;
using FwCore.DBContext.Model;
using FwCore.DBContext;
using Newtonsoft.Json.Linq;
using Microsoft.EntityFrameworkCore;

namespace FwApi.AppData
{

    public class ApplicationFormController : Controller
    {
        private readonly AppDataDbContext  _context;
       

        public ApplicationFormController(AppDataDbContext context)
        {
            _context = context;
           

        }

        


        [Route("api/applicationForm/apply")]
        [HttpPost]

        public async Task<ActionResult> ApplyForLoan([FromBody] ApplyLoanViewModel model)
        {
            LoanApplication _loanApplication = new LoanApplication();

            _loanApplication.LoanType = model.submittedLoanInfo.LoanType;
            _loanApplication.LoanAmount = model.submittedLoanInfo.LoanAmount;
            _loanApplication.Installments = model.submittedLoanInfo.Installments;

            _loanApplication.UserFirstName = model.submittedPersonalInfo.FirstName;
            _loanApplication.UserLastName = model.submittedPersonalInfo.LastName;
            _loanApplication.UserFatherName = model.submittedPersonalInfo.FathersName;
            _loanApplication.UserMotherName = model.submittedPersonalInfo.MothersName;
            _loanApplication.UserPresentAddress = model.submittedPersonalInfo.PresentAddress;
            _loanApplication.UserPermanentAddress = model.submittedPersonalInfo.PermanentAddress;
            _loanApplication.UserCity = model.submittedPersonalInfo.City;
            _loanApplication.UserState = model.submittedPersonalInfo.State;
            _loanApplication.UserZipCode = model.submittedPersonalInfo.ZipCode;
            _loanApplication.UserCountry = model.submittedPersonalInfo.Country;
            _loanApplication.UserNationality = model.submittedPersonalInfo.Nationality;
            _loanApplication.UserOccupation = model.submittedGranterInfo.Occupation;
            _loanApplication.UserDateOfBirth = model.submittedPersonalInfo.DateOfBirth;
            _loanApplication.UserGender = model.submittedPersonalInfo.Gender;
            _loanApplication.UserReligion = model.submittedPersonalInfo.Religion;
            _loanApplication.UserMobile = model.submittedPersonalInfo.MobileNo;
            _loanApplication.UserEmailAddress = model.submittedPersonalInfo.Email;
            _loanApplication.UserVerificationType = model.submittedPersonalInfo.VerificationIdType;
            _loanApplication.UserVerificationCode = model.submittedPersonalInfo.VerificationIdNo;

            _loanApplication.GranterFirstName = model.submittedGranterInfo.FirstName;
            _loanApplication.GranterLastName = model.submittedGranterInfo.LastName;
            _loanApplication.GranterFatherName = model.submittedGranterInfo.FathersName;
            _loanApplication.GranterMotherName = model.submittedGranterInfo.MothersName;
            _loanApplication.GranterPresentAddress = model.submittedGranterInfo.PresentAddress;
            _loanApplication.GranterPermanentAddress = model.submittedGranterInfo.PermanentAddress;
            _loanApplication.GranterCity = model.submittedGranterInfo.City;
            _loanApplication.GranterState = model.submittedGranterInfo.State;
            _loanApplication.GranterZipCode = model.submittedGranterInfo.ZipCode;
            _loanApplication.GranterCountry = model.submittedPersonalInfo.Country;
            _loanApplication.GranterNationality = model.submittedGranterInfo.Nationality;
            _loanApplication.GranterOccupation = model.submittedGranterInfo.Occupation;
            _loanApplication.GranterDateOfBirth = model.submittedGranterInfo.DateOfBirth;
            _loanApplication.GranterGender = model.submittedGranterInfo.Gender;
            _loanApplication.GranterReligion = model.submittedGranterInfo.Religion;
            _loanApplication.GranterRelation = model.submittedGranterInfo.Relation;
            _loanApplication.GranterMobile = model.submittedGranterInfo.MobileNo;
            _loanApplication.GranterEmailAddress = model.submittedGranterInfo.Email;
            _loanApplication.GranterVerificationType = model.submittedGranterInfo.VerificationIdType;
            _loanApplication.GranterVerificationCode = model.submittedGranterInfo.VerificationIdNo;

            _context.LoanApplications.Add(_loanApplication);
            await _context.SaveChangesAsync();

            return Ok();
            //return CreatedAtAction("GetLoanApplication", new { id = _loanApplication.LoanApplicationId }, model);
        }




        [Route("api/applicationForm/getApplications")]
        [HttpGet]

        public async Task<ActionResult<IEnumerable<LoanApplication>>> getApplications()
        {
            return await _context.LoanApplications.ToListAsync();

        }

        // DELETE
        [Route("api/applicationForm/deleteApplication")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<LoanApplication>> deleteApplication(int id)
        {
            var loanApplication = await _context.LoanApplications.FindAsync(id);
            if (loanApplication == null)
            {
                return NotFound();
            }

            _context.LoanApplications.Remove(loanApplication);
            await _context.SaveChangesAsync();

            return loanApplication;
        }




        //{

        //    //var str = model.ToString();
        //    //var json = JObject.Parse(str);
        //    //var first = json.GetValue("submittedLoanInfo");
        //    //var jsonLoan = JObject.Parse(first.ToString());
        //    //var loant = jsonLoan.GetValue("LoanType");

        //    //ViewModel vm = new ViewModel();

        //    //model.submittedLoanInfo.LoanTypeName =;

        //    return Ok();
        //}
    }
}