
using LoanData.Models.Loan;

namespace LoanService.ServiceInterface
{
    public interface IInstallmentService
    {
        public Task<List<InstallmentPayment>> AllInstallmentSchedule();
        public Task<List<InstallmentPayment>> PersonalLoanSchedule(int groupId, long nid, int loanId);
        public Task<InstallmentPayment> SubmitInstallment(int groupId, long nid, int loanId, int installmentId);


    }
}
