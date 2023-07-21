using LoanData.Models.Loan;
using LoanService.ServiceInterface.Api;
using Microsoft.AspNetCore.Mvc;

namespace LoanProject.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly IApiLoanService loanService;

        public LoansController(IApiLoanService loanService)
        {
            this.loanService = loanService;
        }

        public IActionResult GetAllLoans()
        {
            var Loans = loanService.GetAllLoans();

            return Ok(Loans);
        }

        [HttpPost]
        public async Task<JsonResult> SubmitLoanPlan([FromForm] LoanBasic loan)
        {
            var response = await loanService.SubmitLoanPlan(loan);
            if (response == null)
            {
                return new JsonResult(BadRequest());
            }

            return new JsonResult(Ok("Loan Provided and\nSchedule Created Successfully!"));
        }
        //LoanPlanningViewModel model



    }
}
