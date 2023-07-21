

using LoanData.DTOs;

namespace LoanData.ViewModels
{
    public class LoanPlanGroupSelectionViewModel
    {
        public SelectiveMemberDto Member { get; set; }
        public List<LoanGroupDto> MemberContainingGroups { get; set; }

    }
}
