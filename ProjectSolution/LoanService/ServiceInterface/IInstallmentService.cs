
using LoanData.Models.Loan;
using LoanData.ViewModels;

namespace LoanService.ServiceInterface
{
    public interface IInstallmentService
    {
        public Task<List<InstallmentPayment>> AllInstallmentSchedule();
        public Task<PersonalInstallmentViewModel> PersonalLoanSchedule(int groupId, long nid, int loanId);
        public Task<InstallmentPayment> SubmitInstallment(int groupId, long nid, int loanId, int installmentId);


    }
}
