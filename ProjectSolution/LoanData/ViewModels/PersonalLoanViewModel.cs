using LoanData.Models.Group;
using LoanData.Models.Loan;
using LoanData.Models.Member;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LoanData.ViewModels
{
    public class PersonalLoanViewModel
    {
        public long SelectedMemberNID { get; set; }
        public MemberBase SelectedMember { get; set; }
        public int SelectedGroupId { get; set; }
        public List<LoanGroup> MemberContainingGroups { get; set; }
        public List<LoanBasic> LoanBasic { get; set; }
        public List<InstallmentPayment>? AllInstallments { get; set; }
        public SelectList SubmissionPeriod { get; set; }
    }
}
