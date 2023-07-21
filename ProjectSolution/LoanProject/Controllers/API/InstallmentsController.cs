using LoanData.Models.Loan;
using LoanService.ServiceInterface.Api;
using Microsoft.AspNetCore.Mvc;

namespace LoanProject.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstallmentsController : ControllerBase
    {
        private readonly IApiInstallmentService installmentService;

        public InstallmentsController(IApiInstallmentService installmentService)
        {
            this.installmentService = installmentService;
        }


        [HttpPost]
        public async Task<JsonResult> SubmitPayment([FromForm] InstallmentPayment payment)
        {
            var response = await installmentService.PaymentParticularInstallment(payment);

            if (response == null)
            {
                return new JsonResult(BadRequest());
            }

            return new JsonResult(Ok("Payment Updated"));
        }

    }
}
