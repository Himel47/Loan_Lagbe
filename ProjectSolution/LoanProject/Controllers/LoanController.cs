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

    }
}
