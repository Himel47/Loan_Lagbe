using LoanData.Models.Loan;

namespace LoanService.ServiceInterface.Api
{
    public interface IApiInstallmentService
    {
        public Task<InstallmentPayment> PaymentParticularInstallment(InstallmentPayment installment);
    }
}
