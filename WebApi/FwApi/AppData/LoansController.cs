using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FwCore.DBContext;
using FwCore.DBContext.Model;
using DTO;

namespace FwApi.AppData
{
   
    public class LoansController : Controller
    {
        private readonly AppDataDbContext _context;

        public LoansController(AppDataDbContext context)
        {
            _context = context;
        }

        [Route("api/loans/getAllLoans")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Loan>>> GetLoans()
        {
            var loanInfo = _context.Loans.ToList();
            var loanTypeInfo = _context.LoanTypes.ToList();
            var userInfo = _context.Users.ToList();
            var verificationInfo = _context.VerificationSources.ToList();
            var granterInfo = _context.Granters.ToList();
            var statusInfo = _context.Statuses.ToList();
            var documentInfo = _context.Documents.ToList();
            var installmentInfo = _context.LoanInstallments.ToList();

            //var result = from l in loanInfo
            //             join lt in loanTypeInfo
            //             on l.LoanId equals lt.LoanTypeId
            //             join u in userInfo
            //             on lt.LoanTypeId equals u.UserId
            //             join g in granterInfo
            //             on u.UserId equals g.GranterId
            //             join s in statusInfo 
            //             on g.GranterId equals s.StatusId
            //             join d in documentInfo
            //             on s.StatusId equals d.Id
            //             join i in installmentInfo
            //             on d.Id equals i.LoanInstallmentId
            //             select new
            //             {
            //                 loanInfo=l,
            //                 loanTypeInfo=lt

            //             };

            return await _context.Loans.ToListAsync();
        }

        // GET: api/Loans/5 loans/payment
        [Route("api/loans/payment")]
        [HttpPost]
        public async Task<ActionResult<Loan>> GetLoan([FromBody] paymentViewModel model)
        {
            
           var i= _context.LoanInstallments.Where(x => x.LoanInstallmentId == model.installmentId).First();
            i.ActualPayDate = model.paymentDate;
            i.Penalty = model.penalty;
            i.Reason = model.reason;
            i.PayAmount = i.EMI + model.penalty;
            await _context.SaveChangesAsync();
            
            return Ok();
        }

        // PUT: api/Loans/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoan(int id, Loan loan)
        {
            if (id != loan.LoanId)
            {
                return BadRequest();
            }

            _context.Entry(loan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoanExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Loans
        [Route("api/loans/approve")]
        [HttpPost]
        public async Task<ActionResult<Loan>> PostLoan([FromBody] ApprovalViewModel model)
        {
            var applicationInfo= _context.LoanApplications.Where(x=>x.LoanApplicationId==model.ApplicationId).First();
            
            Loan loan = new Loan();
            loan.LoanType = new LoanType()
            {
                LoanTypeName=applicationInfo.LoanType,
                InterestRate=getInterest(applicationInfo.LoanType),
                
                NoOfInstallment=applicationInfo.Installments,
                LoanAmount=applicationInfo.LoanAmount
            };


            loan.User = new User()
            {
                
                FirstName= applicationInfo.UserFirstName,
                LastName=applicationInfo.UserLastName,
                FatherName= applicationInfo.UserFatherName,
                MotherName= applicationInfo.UserMotherName,
                PresentAddress= applicationInfo.UserPresentAddress,
                PermanentAddress= applicationInfo.UserPermanentAddress,
                City= applicationInfo.UserCity,
                State=applicationInfo.UserState,
                ZipCode= applicationInfo.UserZipCode,
                Country= applicationInfo.UserCountry,
                Nationality= applicationInfo.UserNationality,
                Occupation= applicationInfo.UserOccupation,
                DateOfBirth= applicationInfo.UserDateOfBirth,
                Gender= applicationInfo.UserGender,
                Religion= applicationInfo.UserReligion,
                Mobile= applicationInfo.UserMobile,
                EmailAddress= applicationInfo.UserEmailAddress,
               
            };

            loan.User.Verification = new VerificationSource()
            {
                VerificationType = applicationInfo.UserVerificationType,
                VerificationCode = applicationInfo.UserVerificationCode
            };



            loan.Granter = new Granter()
            {
                FirstName = applicationInfo.GranterFirstName,
                LastName = applicationInfo.GranterLastName,
                FatherName = applicationInfo.GranterFatherName,
                MotherName = applicationInfo.GranterMotherName,
                PresentAddress = applicationInfo.GranterPresentAddress,
                PermanentAddress = applicationInfo.GranterPermanentAddress,
                City = applicationInfo.GranterCity,
                State = applicationInfo.GranterState,
                ZipCode = applicationInfo.GranterZipCode,
                Country = applicationInfo.GranterCountry,
                Nationality = applicationInfo.GranterNationality,
                Occupation = applicationInfo.GranterOccupation,
                DateOfBirth = applicationInfo.GranterDateOfBirth,
                Gender = applicationInfo.GranterGender,
                Religion = applicationInfo.GranterReligion,
                Relation=applicationInfo.GranterRelation,
                Mobile = applicationInfo.GranterMobile,
                EmailAddress = applicationInfo.GranterEmailAddress,

            };

            loan.Document = new Document()
            {
                FileName="File"
            };

            loan.Granter.Verification = new VerificationSource()
            {
                VerificationType = applicationInfo.GranterVerificationType,
                VerificationCode = applicationInfo.GranterVerificationCode
            };

            loan.ApprovedBy = model.ApproveBy;
            loan.OperateBy = model.OperateBy;
            loan.Status = new Status()
            {
                LoanStatus=model.Status
            };
          
            Double getInterest(string loanType)
            {
                double interest=0;
                if (loanType== "Personal Loan")
                {
                    interest = 10;

                }


                else if (loanType == "Home Loan")
                {
                    interest = 15;

                }


                else if (loanType == "Car Loan")
                {
                    interest = 12;

                }
                else  
                {
                    interest = 8;

                }
                return interest;
            }

            if (model.Status != "Pending")
            {
                loan.IssueDate = model.IssueDate;

                List<LoanInstallment> installments = new List<LoanInstallment>();

                for (int i = 0; i < applicationInfo.Installments; i++)
                {
                    installments.Add(new LoanInstallment
                    {
                        EMI = getEMI(),
                        ScheduleDate = getScheduleList(i),
                        //ActualPayDate = DateTime.Now,
                        Penalty = 0,
                        PayAmount = 0,
                        //Reason = ""
                    });

                }

                DateTime getScheduleList(int i)
                {
                    DateTime nextMonth = model.IssueDate.AddMonths(i + 1);



                    return nextMonth;
                }
                Double getEMI()
                {
                    var loanAmount = applicationInfo.LoanAmount;
                    var interest = getInterest(applicationInfo.LoanType);
                    var numberOfPayments = applicationInfo.Installments;
                    // rate of interest and number of payments for monthly payments
                    var rateOfInterest = interest / 1200;


                    // loan amount = (interest rate * loan amount) / (1 - (1 + interest rate)^(number of payments * -1))
                    var paymentAmount = (rateOfInterest * loanAmount) / (1 - Math.Pow(1 + rateOfInterest, numberOfPayments * -1));

                    return paymentAmount;
                }

                loan.LoanInstallments = installments;


                _context.Loans.Add(loan);

                await _context.SaveChangesAsync();

                _context.LoanApplications.Remove(applicationInfo);

                await _context.SaveChangesAsync();

            }

                      

            return Ok();
        }

        [Route("api/loans/deleteLoan")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Loan>> DeleteLoan(int id)
        {
            var loanInfo = _context.Loans.ToList();
            var loanTypeInfo = _context.LoanTypes.ToList();
            var userInfo = _context.Users.ToList();
            var verificationInfo = _context.VerificationSources.ToList();
            var granterInfo = _context.Granters.ToList();
            var statusInfo = _context.Statuses.ToList();
            var documentInfo = _context.Documents.ToList();
            var installmentInfo = _context.LoanInstallments.ToList();

            var loan = await _context.Loans.FindAsync(id);
            if (loan == null)
            {
                return NotFound();
            }

            _context.Loans.Remove(loan);
            await _context.SaveChangesAsync();

            return loan;
        }

        private bool LoanExists(int id)
        {
            return _context.Loans.Any(e => e.LoanId == id);
        }
    }
}
