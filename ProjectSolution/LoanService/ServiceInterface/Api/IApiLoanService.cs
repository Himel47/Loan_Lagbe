using LoanData.Models.Loan;
using Microsoft.AspNetCore.Mvc;

namespace LoanService.ServiceInterface.Api
{
    public interface IApiLoanService
    {
        public Task<IEnumerable<Installment>> GetAllLoans();
        public Task<JsonResult> SubmitLoanPlan(LoanBasic loan);
    }
}
