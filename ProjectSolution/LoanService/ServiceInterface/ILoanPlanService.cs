using LoanData.Models.Loan;
using LoanData.Models.Member;
using LoanData.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanService.ServiceInterface
{
    public interface ILoanPlanService
    {
        public Task<LoanPlanningViewModel> GetMainPage(int groupId);
        //public Task<LoanPlanningViewModel> PostMainPage(LoanPlanningViewModel model);
        public Task<List<MemberBase>> MemberSelectForLoanPlan();
        public Task<PersonalLoanViewModel> MemberLoanWithGroups(long memberNID, int groupId);
        public Task<PersonalLoanViewModel> MemberLoanWithGroups(PersonalLoanViewModel model);
    }
}
