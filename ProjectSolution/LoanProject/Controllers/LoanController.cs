using LoanData.Models.Loan;
using LoanService.ServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace LoanProject.Controllers
{
    public class LoanController : Controller
    {
        private readonly ILoanPlanService loanService;

        public LoanController(ILoanPlanService loanService)
        {
            this.loanService = loanService;
        }


        [HttpGet]
        public async Task<IActionResult> LoanIndex()
        {
            var response = await loanService.GetMainPage();
            return View(response);
        }

        [HttpGet]
        public async Task<IActionResult> Index(long nid, int groupId)
        {
            var response = await loanService.MemberLoanWithGroups(nid, groupId);
            return View(response);
        }

        [HttpGet]
        public async Task<IActionResult> MemberLoanGroupIndex(long nid, int groupId)
        {
            var response = await loanService.MemberGroupSelectForLoanPlan(nid, groupId);
            return View(response);
        }

        [HttpGet]
        public async Task<IActionResult> MemberLoanIndex()
        {
            var response = await loanService.MemberSelectForLoanPlan();
            return View(response);
        }

        [HttpGet]
        public async Task<IActionResult> GroupSelection()
        {
            var response = await loanService.SelectingGroupForLoan();
            return View(response);
        }

        [HttpGet]
        public async Task<IActionResult> GroupLoanPlan(int groupId)
        {
            var response = await loanService.GroupLoanPlan(groupId);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> GroupLoan(IList<LoanBasic> loans)
        {
            if (loans.Count == 0)
            {
                return BadRequest();
            }

            var response = await loanService.GroupLoanPlanSubmit(loans);
            return View(response);
        }



    }
}
