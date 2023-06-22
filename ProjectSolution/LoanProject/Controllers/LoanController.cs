using LoanData.ViewModels;
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
        public async Task<IActionResult> Index(int groupId)
        {
            var response = await loanService.GetMainPage(groupId);
            return View(response);
        }

        [HttpGet]
        public async Task<IActionResult> MemberLoanIndex()
        {
            var response = await loanService.MemberSelectForLoanPlan();
            return View(response);
        }

        [HttpGet]
        public async Task<IActionResult> PersonalLoan(long nid, int groupId)
        {
            var response = await loanService.MemberLoanWithGroups(nid, groupId);
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> PersonalLoan(PersonalLoanViewModel model)
        {
            var response = await loanService.MemberLoanWithGroups(model);
            if(response == null)
            {
                return BadRequest(response);
            }
            return RedirectToAction("LoanIndex","Group");
        }

    }
}
