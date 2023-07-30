using LoanData.DTOs;
using LoanData.Models.Loan;
using LoanData.Models.Member;
using LoanData.ViewModels;

namespace LoanService.ServiceInterface
{
    public interface ILoanPlanService
    {
        public Task<List<Installment>> GetMainPage();
        public Task<LoanPlanGroupSelectionViewModel> MemberGroupSelectForLoanPlan(long memberNid, int groupId);
        public Task<List<MemberBase>> MemberSelectForLoanPlan();
        public Task<PersonalLoanFormViewModel> MemberLoanWithGroups(long memberNID, int groupId);
        public Task<List<LoanGroupDto>> SelectingGroupForLoan();
        public Task<GroupLoanFormViewModel> GroupLoanPlan(int groupId);
        public Task<IList<LoanBasic>> GroupLoanPlanSubmit(IList<LoanBasic> loans);

    }
}
