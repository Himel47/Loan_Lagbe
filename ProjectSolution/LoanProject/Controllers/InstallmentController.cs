using LoanService.ServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace LoanProject.Controllers
{
    public class InstallmentController : Controller
    {
        private readonly IInstallmentService installmentService;

        public InstallmentController(IInstallmentService installmentService)
        {
            this.installmentService = installmentService;
        }


        public async Task<IActionResult> InstallmentIndex(int groupId, long nid, int loanId)
        {
            var response = await installmentService.PersonalLoanSchedule(groupId, nid, loanId);

            return View(response);
        }

        public async Task<IActionResult> InstallmentSchedule()
        {
            var response = await installmentService.AllInstallmentSchedule();
            return View(response);
        }

        public async Task<IActionResult> InstallmentPayment(int groupId, long nid, int loanId, int installmentId)
        {
            var respoonse = await installmentService.SubmitInstallment(groupId, nid, loanId, installmentId);

            if (respoonse != null)
            {
                return View(respoonse);
            }

            return NotFound();
        }
    }
}
